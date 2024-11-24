using System;
using System.Collections.Generic;

namespace HermesCrud.Models;

public partial class Permiso
{
    public int IdPermiso { get; set; }

    public string NombrePermiso { get; set; } = null!;

    public bool EstadoPermiso { get; set; }

    public virtual ICollection<Privilegio> Privilegios { get; set; } = new List<Privilegio>();
}
