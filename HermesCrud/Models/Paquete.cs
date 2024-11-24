using System;
using System.Collections.Generic;

namespace HermesCrud.Models;

public partial class Paquete
{
    public int IdPaquete { get; set; }

    public string NombrePaquete { get; set; } = null!;

    public int IdMunicipio { get; set; }

    public int IdActividad { get; set; }

    public decimal NivelActividad { get; set; }

    public decimal InversionPaquete { get; set; }

    public decimal ReservaPaquete { get; set; }

    public virtual ICollection<DetallePaqueteServicio> DetallePaqueteServicios { get; set; } = new List<DetallePaqueteServicio>();

    public virtual Actividad oActividad { get; set; } = null!;

    public virtual Municipio oMunicipio { get; set; } = null!;

    public virtual ICollection<Programacion> Programaciones { get; set; } = new List<Programacion>();
}
