using System;
using System.Collections.Generic;

namespace HermesCrud.Models;

public partial class CategoriaServicio
{
    public int IdCategoriaServicio { get; set; }

    public string NombreCategoriaServicio { get; set; } = null!;

    public virtual ICollection<Servicio> Servicios { get; set; } = new List<Servicio>();
}
