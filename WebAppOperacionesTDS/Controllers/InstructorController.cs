using Microsoft.AspNetCore.Mvc;
using WebAppOperacionesTDS.Models;

namespace WebAppOperacionesTDS.Controllers
{
    public class InstructorController : Controller
    {

        public List<Instructor> GetInstructors()
        {
            var RegistrosInstructor = new List<Instructor>();

            RegistrosInstructor.Add(new Instructor()
            {
                Idinstructor = 1,
                Nombres = "Juan Carlos",
                Apellidos = "Torres Garcia",
                DNI = 4258754,
                EDAD = 35,
                Especialidad = "Ingeniero de Sistemas",
                Estado = "Activo"
            });

            RegistrosInstructor.Add(new Instructor()
            {
                Idinstructor = 2,
                Nombres = "Maria Alejandra",
                Apellidos = "Morante Garcia",
                DNI = 42569878,
                EDAD = 20,
                Especialidad = "Ciencias de la comunicación",
                Estado = "Inactivo"
            });

            RegistrosInstructor.Add(new Instructor()
            {
                Idinstructor = 3,
                Nombres = "Brandon Daniel",
                Apellidos = "Melendez Panana",
                DNI = 76528896,
                EDAD = 21,
                Especialidad = "Ingeniero Informático",
                Estado = "Activo"
            });

            RegistrosInstructor.Add(new Instructor()
            {
                Idinstructor = 4,
                Nombres = "Iris cat",
                Apellidos = "Espinoza sotelo",
                DNI = 76524323,
                EDAD = 25,
                Especialidad = "Trabajo Social",
                Estado = "Activo"
            });

            RegistrosInstructor.Add(new Instructor()
            {
                Idinstructor = 5,
                Nombres = "Tatiana Lucia",
                Apellidos = "Urpeque Espinoza",
                DNI = 15248812,
                EDAD = 22,
                Especialidad = "Derecho",
                Estado = "Inactivo"
            });

            RegistrosInstructor.Add(new Instructor()
            {
                Idinstructor = 6,
                Nombres = "Carlos Jose",
                Apellidos = "Alberca Torres",
                DNI = 15523273,
                EDAD = 28,
                Especialidad = "Ingeniero Industrial",
                Estado = "Activo"
            });

            return RegistrosInstructor;
        }

        public IActionResult Index()
        {
            var modelo = GetInstructors();
            return View(modelo);
        }

        public IActionResult VDIndex()
        {
            ViewData["Id"] = "Id";
            ViewData["No"] = "Nombres";
            ViewData["Ap"] = "Apellidos";
            ViewData["Dn"] = "Dni";
            ViewData["Ed"] = "Edad";
            ViewData["Es"] = "Especialidad";
            ViewData["Est"] = "Estado";

            var VDModel = GetInstructors();
            ViewData["Registros"] = VDModel;
            return View();
        }
    }
}
