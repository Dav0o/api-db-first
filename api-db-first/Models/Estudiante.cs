using System;
using System.Collections.Generic;

namespace api_db_first.Models;

public partial class Estudiante
{
    public int EstudianteId { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string? Carnet { get; set; }

    public string? Email { get; set; }

    public DateTime? FechaIngreso { get; set; }

    public bool? Activo { get; set; }

    public virtual ICollection<Calificacione> Calificaciones { get; set; } = new List<Calificacione>();
}
