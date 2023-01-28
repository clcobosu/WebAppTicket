using System;
using System.Collections.Generic;

namespace WebAppPrueba.Models;

public partial class Ticket
{
    public int Id { get; set; }

    public string IdClient { get; set; } = null!;

    public string Operador { get; set; } = null!;

    public string Incidencia { get; set; } = null!;

    public DateTime FechaIngreso { get; set; }
}
