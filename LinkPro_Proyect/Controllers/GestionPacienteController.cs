using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            List<PacienteCLS> listPaciente = null;
            using (var bd = new LinkPro_Test_Old_Update())
            {
                listPaciente = (from paciente in bd.Paciente
                                join estado in bd.Estado
                                on paciente.ID_ESTADO equals estado.ESTADOID
                                //join cita in bd.Citas
                                //on paciente.PACIENTEID equals cita.ID_PACIENTE
                                //join medico in bd.Medico
                                //on cita.ID_MEDICO equals medico.MEDICOID
                                where paciente.BHABILITADO == 1
                                select new PacienteCLS
                                {
                                    pacienteid = paciente.PACIENTEID,
                                    nombre = paciente.NOMBRE,
                                    apellido = paciente.APELLIDO,
                                    estadoactual = estado.NOMBRE
                                }).ToList();

            }
            return View(listPaciente);
        }
        //GET: Cita

        public async Task<IActionResult>

        // GET: Detalles Paciente
        public ActionResult DetallesPaciente(int id)
        {
            llenarEstado();
            ViewBag.lista = listaEstado;
            PacienteCLS oPacienteCLS = new PacienteCLS();

            using (var bd = new LinkPro_Test_Old_Update())
            {
                Paciente oPaciente = bd.Paciente.Where(p => p.PACIENTEID.Equals(id)).First();
                if(oPaciente.ID_FICHA == null)
                    oPaciente.ID_FICHA = -1;
                oPacienteCLS.id_ficha = (int)oPaciente.ID_FICHA;
                oPacienteCLS.pacienteid = oPaciente.PACIENTEID;
                oPacienteCLS.nombre = oPaciente.NOMBRE;
                oPacienteCLS.apellido = oPaciente.APELLIDO;
                oPacienteCLS.rut = oPaciente.RUT;
                oPacienteCLS.direccion = oPaciente.DIRECCION;
                oPacienteCLS.telefono = oPaciente.TELEFONO;
                oPacienteCLS.fecha_nacimiento = (DateTime)oPaciente.FECHA_NACIMIENTO;
                oPacienteCLS.email = oPaciente.EMAIL;
                oPacienteCLS.fecha_inscrito = (DateTime)oPaciente.FECHA_INSCRITO;
                oPacienteCLS.id_estado = (int)oPaciente.ID_ESTADO;

            }
            return View(oPacienteCLS);
        }

        [HttpPost]
        public ActionResult DetallesPaciente(PacienteCLS oPacienteCLS, int id)
        {
            int idPaciente = id;
            if (!ModelState.IsValid)
            {
                return View(oPacienteCLS);
            }
            using (var bd = new LinkPro_Test_Old_Update())
            {
                Paciente oPaciente = bd.Paciente.Where(p => p.PACIENTEID.Equals(idPaciente)).First();
                oPaciente.ID_ESTADO = oPacienteCLS.id_estado;
                bd.SaveChanges();
            }
            return RedirectToAction("Pacientes");
        }

        // GET: Historial Cita
        public ActionResult HistorialCitas()
        {
            return View();
        }

        //Funciones de llenado
        List<SelectListItem> listaEstado;
        private void llenarEstado()
        {
            using (var bd = new LinkPro_Test_Old_Update())
            {
                listaEstado = (from estado in bd.Estado
                               select new SelectListItem
                               {
                                   Text = estado.NOMBRE,
                                   Value = estado.ESTADOID.ToString()
                               }).ToList();
                listaEstado.Insert(0, new SelectListItem { Text = "--Seleccione--", Value = "" });
                ViewBag.LEstado = listaEstado;
            }
        }
        private void llenarComuna() { }
        private void llenarCiudad() { }
        private void llenarRegion() { }
        private void llenarSexo() { }
    }


}