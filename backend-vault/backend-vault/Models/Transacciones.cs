namespace backend_vault.Models
{
    public enum TipoTransaccion { Ingreso, Egreso }
    public class Transacciones
    {
        public int Id {  get; set; }
        public decimal Monto { get; set; }
        public TipoTransaccion Categoria { get; set; } 
        public DateTime Fecha { get; set; }

    }

}
