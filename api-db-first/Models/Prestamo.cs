using System;
using System.Collections.Generic;

namespace api_db_first.Models;

public partial class Prestamo
{
    public int PrestamoId { get; set; }

    public int LibroId { get; set; }

    public int UsuarioId { get; set; }

    public DateTime? FechaPrestamo { get; set; }

    public DateTime FechaDevolucionEsperada { get; set; }

    public DateTime? FechaDevolucionReal { get; set; }

    public decimal? Multa { get; set; }

    public string? Estado { get; set; }

    public virtual Libro Libro { get; set; } = null!;

    public virtual UsuariosBiblioteca Usuario { get; set; } = null!;
}
