using System;
using System.Collections.Generic;

namespace HermesCrud.Models;

public partial class DetalleReservaViajero
{
    public int IdDetalleReservaViajero { get; set; }

    public int IdReserva { get; set; }

    public int IdCliente { get; set; }

    public virtual Cliente oCliente { get; set; } = null!;

    public virtual Reserva oReserva { get; set; } = null!;
}
