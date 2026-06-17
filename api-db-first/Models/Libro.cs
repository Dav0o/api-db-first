using System;
using System.Collections.Generic;

namespace api_db_first.Models;

public partial class Libro
{
    public int LibroId { get; set; }

    public string Titulo { get; set; } = null!;

    public string Autor { get; set; } = null!;

    public string? Isbn { get; set; }

    public string? Editorial { get; set; }

    public int? AñoPublicacion { get; set; }

    public int CopiasTotal { get; set; }

    public int CopiasDisponibles { get; set; }

    public bool? Activo { get; set; }

    public virtual ICollection<Prestamo> Prestamos { get; set; } = new List<Prestamo>();
}
