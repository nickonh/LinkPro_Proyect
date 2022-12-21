using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LinkPro_Proyect.Models;

namespace LinkPro_Proyect.Controllers
{
    public class CitaController : Controller
    {
        //GET: Gestionar Cita
        public ActionResult GestionCita() 
        {
            return View();
        }

        //public ActionResult GestionCita(CitaCLS oCitaCLS) 
        //{

        //    return View();
        //}


        // GET: Cita
        public ActionResult DetalleCitas(int id/*idLog*/)
        {
            List<CitaCLS> listCita = null;
            using (var bd = new LinkPro_Test_Old_Update())
            {
                listCita = (from cita in bd.Citas
                            join paciente in bd.Paciente
                            on cita.ID_PACIENTE equals paciente.PACIENTEID
                            join medico in bd.Medico
                            on cita.ID_MEDICO equals medico.MEDICOID
                            join estado in bd.Estado
                            on cita.ID_ESTADO equals estado.ESTADOID
                            //where cita.ID_MEDICO == idLog
                            //&& 
                            where cita.BHABILITADO == 1
                            && paciente.PACIENTEID == id
                            select new CitaCLS
                            {
                                citasid = cita.CITASID,
                                code_reservaid = (int)cita.CODE_RESERVAID,
                                nombreEstado = estado.NOMBRE,
                                fecha_atencion = (DateTime)cita.FECHA_ATENCION,
                                hora_atencion = (TimeSpan)cita.HORA_ATENCION,
                                observaciones = cita.OBSERVACIONES
                            }).ToList();
            }
            return View(listCita);
        }
    }
}