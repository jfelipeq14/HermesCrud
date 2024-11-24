using System;
using System.Collections.Generic;

namespace HermesCrud.Models;

public partial class Pais
{
    public int IdPais { get; set; }

    public int CodigoPais { get; set; }

    public string NombrePais { get; set; } = null!;

    public virtual ICollection<Departamento> Departamentos { get; set; } = new List<Departamento>();
}
