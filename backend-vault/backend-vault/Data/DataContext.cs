using System.Collections.Generic;
using backend_vault.Models;
using Microsoft.EntityFrameworkCore;

namespace backend_vault.Data
{
    public class DataContext : DbContext
    {
        // El constructor: Recibe la configuración (como la ruta de la DB) 
        // y se la pasa a la clase padre (base)
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        // Esta es tu tabla en la base de datos
        public DbSet<Transacciones> Transacciones { get; set; }
    }
}