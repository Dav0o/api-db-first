using System;
using System.Collections.Generic;

namespace api_db_first.Models;

public partial class ProductosAuditorium
{
    public int AuditoriaId { get; set; }

    public int ProductoId { get; set; }

    public decimal? PrecioAnterior { get; set; }

    public decimal? PrecioNuevo { get; set; }

    public string? Usuario { get; set; }

    public DateTime? Fecha { get; set; }
}
