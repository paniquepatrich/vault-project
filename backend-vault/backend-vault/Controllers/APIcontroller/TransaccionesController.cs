using backend_vault.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend_vault.Models;

// Asegúrate de importar el namespace donde está tu DbContext y Modelo
// using TuProyecto.Data; 
// using TuProyecto.Models;

[Route("api/[controller]")]
[ApiController]
public class TransaccionesController : ControllerBase
{
    private readonly DataContext _context;

    public TransaccionesController(DataContext context)
    {
        _context = context;
    }

    // GET: api/transacciones (Para leer todos los gastos)
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Transacciones>>> GetTransacciones()
    {
        return await _context.Transacciones.ToListAsync();
    }

    // POST: api/transacciones (Para crear un nuevo gasto)
    [HttpPost]
    public async Task<ActionResult<Transacciones>> PostTransaccion(Transacciones transaccion)
    {
        _context.Transacciones.Add(transaccion);
        await _context.SaveChangesAsync(); // Esto lo guarda físicamente en el .db

        return CreatedAtAction(nameof(GetTransacciones), new { id = transaccion.Id }, transaccion);
    }
}