namespace api_db_first.Models
{
    public class ProductoResult
    {
        public int ProductoID { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public DateTime FechaCreacion { get; set; }
        public bool Activo { get; set; }
        public DateTime? FechaActualizacion { get; set; }
    }
}
