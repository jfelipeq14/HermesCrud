using System;
using System.Collections.Generic;

namespace HermesCrud.Models;

public partial class Servicio
{
    public int IdServicio { get; set; }

    public int IdCategoriaServicio { get; set; }

    public string NombreServicio { get; set; } = null!;

    public decimal ValorServicio { get; set; }

    public bool EstadoServicio { get; set; }

    public virtual ICollection<DetallePaqueteServicio> DetallePaqueteServicios { get; set; } = new List<DetallePaqueteServicio>();

    public virtual CategoriaServicio oCategoriaServicio { get; set; } = null!;
}
