using System;
using System.Collections.Generic;

namespace HermesCrud.Models;

public partial class Rol
{
    public int IdRol { get; set; }

    public string NombreRol { get; set; } = null!;

    public bool EstadoRol { get; set; }

    public virtual ICollection<RolPrivilegio> RolPrivilegios { get; set; } = new List<RolPrivilegio>();

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
