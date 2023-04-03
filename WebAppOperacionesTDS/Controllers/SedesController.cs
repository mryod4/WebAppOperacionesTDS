using Microsoft.AspNetCore.Mvc;
using WebAppOperacionesTDS.Models;

namespace WebAppOperacionesTDS.Controllers
{
    public class SedesController : Controller
    {
        private List<Sedes> getSedes()
        {
            var InfSedes = new List<Sedes>();

            InfSedes.Add(new Sedes
            {
                IdSedes = 001,
                Nombre = "Pisco",
                Direccion = "Las camelias Nº123",
                Responsable = "Juan Carlos Arenas Quispe"
            });

            InfSedes.Add(new Sedes
            {
                IdSedes = 002,
                Nombre = "Barranca",
                Direccion = "Las palmeras Nº145",
                Responsable = "Castillo Terrones Pachacuted"
            });

            InfSedes.Add(new Sedes
            {
                IdSedes = 003,
                Nombre = "Arequipa",
                Direccion = "Jr. Colon Nº943",
                Responsable = "Dina Boluarte Quispe Mamany"
            });
            return InfSedes;

        }

        public IActionResult VBIndex()
        {
            var model = getSedes();
            ViewBag.informacion = model;
            return View();
        }
        public IActionResult TDIndex()
        {
            var tdmodel = getSedes();
            TempData["Informacion"] = tdmodel;
            return View();
        }
    }
}
