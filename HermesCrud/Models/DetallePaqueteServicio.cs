using System;
using System.Collections.Generic;

namespace HermesCrud.Models;

public partial class DetallePaqueteServicio
{
    public int IdDetallePaqueteServicio { get; set; }

    public int IdPaquete { get; set; }

    public int IdServicio { get; set; }

    public int CantidadServicioPaquete { get; set; }

    public decimal? ValorServicioPaquete { get; set; }

    public virtual Paquete oPaquete { get; set; } = null!;

    public virtual Servicio oServicio { get; set; } = null!;
}
