using System;
using System.Collections.Generic;

namespace api_db_first.Models;

public partial class Cuenta
{
    public int CuentaId { get; set; }

    public string NumeroCuenta { get; set; } = null!;

    public int ClienteId { get; set; }

    public decimal Saldo { get; set; }

    public string? TipoCuenta { get; set; }

    public DateTime? FechaApertura { get; set; }

    public bool? Activa { get; set; }

    public virtual Cliente Cliente { get; set; } = null!;

    public virtual ICollection<Transaccione> TransaccioneCuentaDestinoNavigations { get; set; } = new List<Transaccione>();

    public virtual ICollection<Transaccione> TransaccioneCuentaOrigenNavigations { get; set; } = new List<Transaccione>();
}
