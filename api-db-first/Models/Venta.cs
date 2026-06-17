using System;
using System.Collections.Generic;

namespace api_db_first.Models;

public partial class Venta
{
    public int VentaId { get; set; }

    public int ClienteId { get; set; }

    public int ProductoId { get; set; }

    public int Cantidad { get; set; }

    public decimal Total { get; set; }

    public DateTime? Fecha { get; set; }

    public virtual Cliente Cliente { get; set; } = null!;

    public virtual ICollection<DetalleVenta> DetalleVenta { get; set; } = new List<DetalleVenta>();

    public virtual Producto Producto { get; set; } = null!;
}
