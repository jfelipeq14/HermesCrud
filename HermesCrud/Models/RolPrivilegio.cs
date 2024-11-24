using System;
using System.Collections.Generic;

namespace HermesCrud.Models;

public partial class RolPrivilegio
{
    public int IdRolPrivilegio { get; set; }

    public int IdRol { get; set; }

    public int IdPrivilegio { get; set; }

    public virtual Privilegio oPrivilegio { get; set; } = null!;

    public virtual Rol oRol { get; set; } = null!;
}
