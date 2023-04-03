using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAppOperacionesTDS.Data.DataAccess;
using WebAppOperacionesTDS.Data.Interface;
using WebAppOperacionesTDS.Models;
using X.PagedList;

namespace WebAppOperacionesTDS.Controllers
{
    [Authorize]// Este código sirve que para cuando queramos ver las vistas, automaticamente la pagina nos pida loguearnos con 
               //el correo registrado respectivamente
    public class OperacionController : Controller
    {
        //  [Route("WebAppOpe")] este para el URL ROUTER

        //ESTE ES LA INYECCIÓN POR DEPENDENCIA EN EL CONTROLADOR
        public readonly IDAOperacion DAOPeracion;
        public readonly IDALugar DALugar;
        public readonly IDACliente DACliente;
        public readonly IDAServicios DAServicios;
        //ESTO TAMBIÉN
        private ServiceBancosReference.ServiceBancosClient Service = new
            ServiceBancosReference.ServiceBancosClient();
        public IActionResult ServiceIndex()
        {
            ViewBag.CuentasServicios = Service.GetCuentasAsync().Result;
            return View();
        }

        public OperacionController(IDAOperacion DAOPeracion, IDALugar DALugar, IDACliente DACliente, IDAServicios DAServicios)
        {
            this.DAOPeracion = DAOPeracion;
            this.DALugar = DALugar;
            this.DACliente = DACliente;
            this.DAServicios = DAServicios;
        }

        public IActionResult Index(int page=1) //EL INDEX ES EL NOMBRE DE LA CLASE EN LA VISTA
        {
            var pageNumber = page;
            //var model = new DAOperacion();//INYECCIÓN
            var informacionDB = DAOPeracion.GetOperacion();
            var Datos = informacionDB.OrderByDescending(x => x.IdOperacion).ToList().ToPagedList(pageNumber, 8); //Compaginación
            return View(Datos);

        }
        public IActionResult Create()
        {
            //var Lugar = new DALugar(); //INYECCIÓN
            ViewBag.Lugar = DALugar.GetLugar();

            //var Servicio = new DAServicios();//INYECCIÓN
            ViewBag.Servicio = DAServicios.GetServicio();

            //var Cliente = new DACliente();//INYECCIÓN
            ViewBag.Cliente = DACliente.GetCliente();
            return View();
        }
        [HttpPost]

        public IActionResult Create(Operacion operacion) //Recordar que el create de aca no se refiere
            //a la carpeta, si no al metodo o clase create
        {
            operacion.IdOperacion = 0;
            operacion.FechaRegistro = DateTime.Now;
            //var modelinsert = new DAOperacion();//INYECCIÓN
            var model = DAOPeracion.InsertOperaciones(operacion);
            if (model > 0)
            {
                return RedirectToAction("Index"); //IMPORTANTE ESTO, PONER A QUE CLASE QUIERES QUE
                //REDIRIJA
                //Si el valor de "model" es mayor que cero, redirige a la acción "Index" de este controlador. Esto sugiere que la inserción
                //fue exitosa y que se debe mostrar una vista que muestre una lista de todas las operaciones registradas en la base de
                //datos.
            }
            else
            {
                return View(model);
            }

        }

        public IActionResult Details(int id)
        {
            //var detOperacion = new DAOperacion();//INYECCIÓN
            var modelodetalle = DAOPeracion.GetIdOperacion(id);
            return View(modelodetalle);
        }

        public IActionResult Edit(int id)
        {
            //var Lugar = new DALugar();//INYECCIÓN
            ViewBag.Lugar = DALugar.GetLugar();

            //var Cliente = new DACliente();//INYECCIÓN
            ViewBag.Cliente = DACliente.GetCliente();

            //var Servicio = new DAServicios();//INYECCIÓN
            ViewBag.Servicio = DAServicios.GetServicio();

            //var Operacion = new DAOperacion();//INYECCIÓN
            var model = DAOPeracion.GetIdOperacion(id);
            return View(model);
        }

        [HttpPost]

        public IActionResult Edit(Operacion operacion) 
        {
            operacion.FechaModificacion = DateTime.Now;
            //var model = new DAOperacion();//INYECCIÓN
            var resultado = DAOPeracion.UpdateOperacion(operacion);
            if (resultado)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(resultado);
            }
        }
        public IActionResult Delete(int id)
        {
            //var OperacionDelete = new DAOperacion();
            var resultado = DAOPeracion.DeleteTrabajos(id);
            return RedirectToAction("Index");
        }

    }
}
