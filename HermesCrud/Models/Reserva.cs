using System;
using System.Collections.Generic;

namespace HermesCrud.Models;

public partial class Reserva
{
    public int IdReserva { get; set; }

    public int IdProgramacion { get; set; }

    public int IdCliente { get; set; }

    public DateOnly? FechaReserva { get; set; }

    public decimal ValorReserva { get; set; }

    public string EstadoReserva { get; set; } = null!;

    public virtual ICollection<DetalleReservaViajero> DetalleReservaViajeros { get; set; } = new List<DetalleReservaViajero>();

    public virtual Cliente oCliente { get; set; } = null!;

    public virtual Programacion oProgramacion { get; set; } = null!;

    public virtual ICollection<Pago> Pagos { get; set; } = new List<Pago>();
}
