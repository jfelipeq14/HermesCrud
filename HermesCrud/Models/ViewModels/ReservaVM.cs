using Microsoft.AspNetCore.Mvc.Rendering;

namespace HermesCrud.Models.ViewModels
{
    public class ReservaVM
    {
        public Reserva oReserva { get; set; }
        public List<SelectListItem> oListaProgramacion { get; set; }
        public List<SelectListItem> oListaCliente{ get; set; }
    }
}
