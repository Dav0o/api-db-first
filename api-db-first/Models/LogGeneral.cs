using System;
using System.Collections.Generic;

namespace api_db_first.Models;

public partial class LogGeneral
{
    public int LogId { get; set; }

    public string? Tabla { get; set; }

    public string? Accion { get; set; }

    public int? RegistroId { get; set; }

    public string? Descripcion { get; set; }

    public string? Usuario { get; set; }

    public DateTime? Fecha { get; set; }
}
