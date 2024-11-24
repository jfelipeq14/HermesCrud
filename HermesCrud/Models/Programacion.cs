using System;
using System.Collections.Generic;

namespace HermesCrud.Models;

public partial class Programacion
{
    public int IdProgramacion { get; set; }

    public DateOnly FechaInicioInscripcion { get; set; }

    public DateOnly FechaFinInscripcion { get; set; }

    public DateOnly FechaEjecucion { get; set; }

    public DateOnly FechaFinalizacion { get; set; }

    public TimeOnly HoraInicioRecogida { get; set; }

    public TimeOnly HoraFinRecogida { get; set; }

    public int IdPaquete { get; set; }

    public virtual Paquete oPaquete { get; set; } = null!;

    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
}
