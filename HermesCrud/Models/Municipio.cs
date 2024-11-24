using System;
using System.Collections.Generic;

namespace HermesCrud.Models;

public partial class Municipio
{
    public int IdMunicipio { get; set; }

    public int CodigoMunicipio { get; set; }

    public string NombreMunicipio { get; set; } = null!;

    public int IdDepartamento { get; set; }

    public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();

    public virtual Departamento oDepartamento { get; set; } = null!;

    public virtual ICollection<Paquete> Paquetes { get; set; } = new List<Paquete>();
}
