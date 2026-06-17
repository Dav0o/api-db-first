using System;
using System.Collections.Generic;

namespace api_db_first.Models;

public partial class Empleado
{
    public int EmpleadoId { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string? Email { get; set; }

    public string? Telefono { get; set; }

    public int? DepartamentoId { get; set; }

    public string? Departamento { get; set; }

    public decimal Salario { get; set; }

    public DateTime? FechaContratacion { get; set; }

    public DateTime? FechaUltimoAumento { get; set; }

    public bool? Activo { get; set; }

    public virtual Departamento? DepartamentoNavigation { get; set; }
}
