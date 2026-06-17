using System;
using System.Collections.Generic;

namespace api_db_first.Models;

public partial class AuditoriaPrestamo
{
    public int AuditoriaId { get; set; }

    public int PrestamoId { get; set; }

    public int UsuarioId { get; set; }

    public int LibroId { get; set; }

    public string? Accion { get; set; }

    public string? Usuario { get; set; }

    public DateTime? Fecha { get; set; }
}
