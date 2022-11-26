using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LinkPro_Proyect.Models;

namespace LinkPro_Proyect.Controllers
{
    public class GestionPacienteController : Controller
    {
        // GET: GestionPaciente
        public ActionResult Pacientes()
        {
            return View();
        }
        // GET: GestionHorario
        public ActionResult Index()
        {
            return View();
        }
        // GET: GestionCitas
        public ActionResult Citas()
        {
            return View();
        }
    }
}