namespace api_db_first.DTOs
{
    public class ProductoListarDto
    {
        public string? Nombre { get; set; }
        public bool SoloActivos { get; set; } = true;
        public decimal? PrecioMinimo { get; set; }
        public decimal? PrecioMaximo { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;
    }

    public class ProductoObtenerPorIDDto
    {
        public int ProductoID { get; set; }
    }

    public class ProductoInsertarDto
    {
        public string Nombre { get; set; } = null!;
        public string? Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public bool Activo { get; set; } = true;
    }

    public class ProductoActualizarDto
    {
        public int ProductoID { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public decimal? Precio { get; set; }
        public int? Stock { get; set; }
        public bool? Activo { get; set; }
    }

    public class ProductoEliminarDto
    {
        public int ProductoID { get; set; }
    }

    public class ProductoEliminarFisicoDto
    {
        public int ProductoID { get; set; }
    }
}
