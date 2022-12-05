using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LinkPro_Proyect.Models;
using static System.Net.WebRequestMethods;

namespace LinkPro_Proyect.Controllers
{
    public class GestionHorarioController : Controller
    {
        // GET: GestionHorario
        public ActionResult Index(int? id) 
        {
            using (var bd = new LinkPro_Test_Old_Update()) 
            {
                var idM=(from medico in bd.Medico
                    where medico.BHABILITADO == 1
                    select new 
                    {
                        id = medico.MEDICOID
                    }).FirstOrDefault();



                ViewBag.Med =idM.id;
            }
            return View();
        }

        public ActionResult GetCalendar(int? id)
        {
            try
            {
                List<HorarioCLS> listHorario = null;
                using (var bd = new LinkPro_Test_Old_Update())
                {
                    listHorario = (from horario in bd.Horario
                                   join medico in bd.Medico
                                   on horario.ID_MEDICO equals medico.MEDICOID
                                   join dispo in bd.Disponibilidad
                                   on horario.ID_DISP equals dispo.DISPID
                                   where horario.BHABILITADO == 1
                                   select new HorarioCLS
                                   {
                                       horarioid = horario.HORARIOID,
                                       id_medico = horario.ID_MEDICO,
                                       nombreDisp = dispo.NOMBRE,
                                       colorDisp = dispo.COLOR,
                                       textDisp = dispo.TEXTCOLOR,
                                       fecha_atention = horario.FECHA_ATENTION,
                                       hora_atention = horario.HORA_ATENTION,
                                       fullinicio = (horario.FECHA_ATENTION + " " + horario.HORA_ATENTION),
                                       fecha_fin = horario.FECHA_FIN,
                                       hora_fin = horario.HORA_FIN,
                                       fullfin = horario.FECHA_FIN + " " + horario.HORA_FIN,
                                       all_day = (bool)horario.ALL_DAY
                                   }).ToList();
                }
                return Json(new
                {
                    Data = listHorario,
                    IsSuccessful = true
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(new LinkPro_Proyect.Models.ExtraModels.Response 
                {
                    IsSuccessful= false,
                    Errors = new List<string> { ex.Message },
                }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}