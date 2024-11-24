using System;
using System.Collections.Generic;

namespace HermesCrud.Models;

public partial class Cliente
{
    public int IdCliente { get; set; }

    public int IdUsuario { get; set; }

    public string NumeroContacto { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public int IdMunicipio { get; set; }

    public string Sexo { get; set; } = null!;

    public string TipoDeSangre { get; set; } = null!;

    public string Eps { get; set; } = null!;

    public bool EstadoCliente { get; set; }

    public virtual ICollection<DetalleReservaViajero> DetalleReservaViajeros { get; set; } = new List<DetalleReservaViajero>();

    public virtual Municipio oMunicipio { get; set; } = null!;

    public virtual Usuario oUsuario { get; set; } = null!;

    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
}
