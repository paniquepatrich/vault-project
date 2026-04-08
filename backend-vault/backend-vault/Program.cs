using backend_vault.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// --- 1. SECCIÓN DE SERVICIOS (Configuración antes de construir) ---

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// AQUÍ registramos la Base de Datos (SQLite)
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlite("Data Source=vault.db"));

// AQUÍ registramos el CORS para que React no sea bloqueado
builder.Services.AddCors(options => {
    options.AddDefaultPolicy(policy => {
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

// --- 2. CONSTRUCCIÓN DE LA APP (Solo una vez) ---
// Justo antes de builder.Build()
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowNextjs",
        policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

var app = builder.Build();

// Justo antes de app.Run()
app.UseCors("AllowNextjs");

// --- 3. SECCIÓN DE MIDDLEWARE (Configuración de cómo se comporta la app) ---

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// IMPORTANTE: El CORS debe ir antes de MapControllers
app.UseCors();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();