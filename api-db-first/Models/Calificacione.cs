using System;
using System.Collections.Generic;

namespace api_db_first.Models;

public partial class Calificacione
{
    public int CalificacionId { get; set; }

    public int EstudianteId { get; set; }

    public string Materia { get; set; } = null!;

    public decimal Nota { get; set; }

    public string? Estado { get; set; }

    public string? Periodo { get; set; }

    public DateTime? Fecha { get; set; }

    public virtual Estudiante Estudiante { get; set; } = null!;
}
