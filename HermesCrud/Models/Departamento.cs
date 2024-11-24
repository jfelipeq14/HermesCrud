using System;
using System.Collections.Generic;

namespace HermesCrud.Models;

public partial class Departamento
{
    public int IdDepartamento { get; set; }

    public int CodigoDepartamento { get; set; }

    public string NombreDepartamento { get; set; } = null!;

    public int IdPais { get; set; }

    public virtual Pais oPais { get; set; } = null!;

    public virtual ICollection<Municipio> Municipios { get; set; } = new List<Municipio>();
}
