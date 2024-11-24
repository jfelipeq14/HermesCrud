using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using HermesCrud.Models;
using HermesCrud.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HermesCrud.Controllers
{
    public class HomeController : Controller
    {
        private readonly HermesContext _DBContext;

        public HomeController(HermesContext context)
        {
            _DBContext = context;
        }

        public IActionResult Index()
        {
            List<Reserva> list = _DBContext.Reserva.Include(c=>c.oCliente).Include(p=>p.oProgramacion).ToList();
            return View(list);
        }

        [HttpGet]
        public IActionResult ReservaDetalle(int idReserva)
        {
            ReservaVM oReservaVM = new ReservaVM()
            {
                oReserva = new Reserva(),
                oListaCliente = _DBContext.Cliente.Select(c => new SelectListItem
                {
                    Text = c.oUsuario.Nombre,
                    Value = c.IdCliente.ToString()
                }).ToList(),
                oListaProgramacion = _DBContext.Programacion.Select(p => new SelectListItem
                {
                    Text = p.FechaEjecucion.ToString(),
                    Value = p.IdProgramacion.ToString()
                }).ToList()
            };

            if (idReserva != 0)
            {
                oReservaVM.oReserva = _DBContext.Reserva.Find(idReserva);
            }

            return View(oReservaVM);
        }

        [HttpPost]
        public IActionResult ReservaDetalle(ReservaVM oReservaVM)
        {
            if (oReservaVM.oReserva.IdReserva == 0)
            {
                _DBContext.Reserva.Add(oReservaVM.oReserva);
            }
            else
            {
                _DBContext.Reserva.Update(oReservaVM.oReserva);
            }

            _DBContext.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Eliminar(int idReserva)
        {
            Reserva oReserva = _DBContext.Reserva.Include(c => c.oCliente).Include(p=>p.oProgramacion).Where(r => r.IdReserva == idReserva).FirstOrDefault();

            return View(oReserva);
        }

        [HttpPost]
        public IActionResult Eliminar(Reserva oReserva)
        {
            _DBContext.Reserva.Remove(oReserva);
            _DBContext.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}
