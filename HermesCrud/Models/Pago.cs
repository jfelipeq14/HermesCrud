using System;
using System.Collections.Generic;

namespace HermesCrud.Models;

public partial class Pago
{
    public int IdPago { get; set; }

    public int IdReserva { get; set; }

    public DateOnly? FechaPago { get; set; }

    public decimal ValorPago { get; set; }

    public string Comprobante { get; set; } = null!;

    public string EstadoPago { get; set; } = null!;

    public virtual Reserva oReserva { get; set; } = null!;
}
