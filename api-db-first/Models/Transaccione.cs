using System;
using System.Collections.Generic;

namespace api_db_first.Models;

public partial class Transaccione
{
    public int TransaccionId { get; set; }

    public int? CuentaOrigen { get; set; }

    public int? CuentaDestino { get; set; }

    public decimal Monto { get; set; }

    public string? TipoTransaccion { get; set; }

    public DateTime? Fecha { get; set; }

    public string? Descripcion { get; set; }

    public virtual Cuenta? CuentaDestinoNavigation { get; set; }

    public virtual Cuenta? CuentaOrigenNavigation { get; set; }
}
