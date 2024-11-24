using System;
using System.Collections.Generic;

namespace HermesCrud.Models;

public partial class Actividad
{
    public int IdActividad { get; set; }

    public string NombreActividad { get; set; } = null!;

    public virtual ICollection<Paquete> Paquetes { get; set; } = new List<Paquete>();
}
