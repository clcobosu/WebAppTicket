using System;
using System.Collections.Generic;

namespace WebAppPrueba.Models;

public partial class Client
{
    public int Id { get; set; }

    public string IdClient { get; set; } = null!;

    public string Nombres { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public string Departamento { get; set; } = null!;

    public string Pais { get; set; } = null!;

    public DateTime FechaIngreso { get; set; }
}
