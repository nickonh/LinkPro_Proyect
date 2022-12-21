using LinkPro_Proyect.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace LinkPro_Proyect.Controllers
{
    public class GestionHorarioController : Controller
    {
        // GET: GestionHorario
        public ActionResult Index(int? id)
        {
            List<MedicoCLS> listaMedico = null;
            using (var bd = new LinkPro_Test_Old_Update())
            {
                var idM = (from medico in bd.Medico
                           where medico.BHABILITADO == 1
                           //id del medico logueado
                           select new
                           {
                               id = medico.MEDICOID
                           }).FirstOrDefault();

                listaMedico = (from medico in bd.Medico
                               where idM.id == medico.MEDICOID
                               && medico.BHABILITADO == 1
                               select new MedicoCLS
                               {
                                   medicoid = medico.MEDICOID,
                                   nombre = medico.NOMBRE,
                                   apellido = medico.APELLIDO,
                               }).ToList();
                ViewBag.Med = idM.id;
            }
            return View(listaMedico);
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
                                       //id del medico logueado
                                       horarioid = horario.HORARIOID,
                                       id_medico = horario.ID_MEDICO,
                                       nombreDisp = dispo.NOMBRE,
                                       colorDisp = dispo.COLOR,
                                       textDisp = dispo.TEXTCOLOR,
                                       fecha_atention = (DateTime)horario.FECHA_ATENTION,
                                       hora_atention = (TimeSpan)horario.HORA_ATENTION,
                                       fullinicio = (horario.FECHA_ATENTION + " " + horario.HORA_ATENTION),
                                       fecha_fin = (DateTime)horario.FECHA_FIN,
                                       hora_fin = (TimeSpan)horario.HORA_FIN,
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
                    IsSuccessful = false,
                    Errors = new List<string> { ex.Message },
                }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult AjustarHorario()
        {
            llenarListas();
            int filtroCount = 1;
            List<HorarioCLS> listHorario = new List<HorarioCLS>();
            using (var bd = new LinkPro_Test_Old_Update())
            {
                listHorario = (from horario in bd.Horario
                               join disp in bd.Disponibilidad
                               on horario.ID_DISP equals disp.DISPID
                               join medico in bd.Medico
                               on horario.ID_MEDICO equals medico.MEDICOID
                               join med_esp in bd.Medico_Especial
                               on medico.MEDICOID equals med_esp.ID_MEDICO
                               join especial in bd.Especialidad
                               on med_esp.ID_ESPECIALIDAD equals especial.ESPECIALIDADID
                               where horario.BHABILITADO == 1
                               select new HorarioCLS
                               {
                                   horarioid = horario.HORARIOID,
                                   nombreEspecialidad = especial.NOMBRE,
                                   fecha_atention = (DateTime)horario.FECHA_ATENTION,
                                   hora_atention = (TimeSpan)horario.HORA_ATENTION,
                                   fecha_fin = (DateTime)horario.FECHA_ATENTION,
                                   hora_fin = (TimeSpan)horario.HORA_FIN,
                                   nombreDisp = disp.NOMBRE,
                                   HoraInicio = horario.HORA_ATENTION.ToString(),
                                   HoraFin = horario.HORA_FIN.ToString(),
                                   id_especialidad = especial.ESPECIALIDADID
                               }).ToList();

                var idM = (from medico in bd.Medico
                           where medico.BHABILITADO == 1
                           //id del medico logueado
                           select new
                           {
                               id = medico.MEDICOID
                           }).FirstOrDefault();

                ViewBag.searchCount = filtroCount;
                ViewBag.medic = idM.id;

            }
            return View(listHorario);
        }

        public ActionResult Filtrar(HorarioCLS oHorarioCLS)
        {
            llenarListas();
            string nombreDisp = oHorarioCLS.nombreDisp;
            int filtroCount = 0;

            List<HorarioCLS> listHorario = new List<HorarioCLS>();
            using (var bd = new LinkPro_Test_Old_Update())
            {
                if (nombreDisp == null)
                {
                    listHorario = (from horario in bd.Horario
                                   join disp in bd.Disponibilidad
                                   on horario.ID_DISP equals disp.DISPID
                                   join medico in bd.Medico
                                   on horario.ID_MEDICO equals medico.MEDICOID
                                   join med_esp in bd.Medico_Especial
                                   on medico.MEDICOID equals med_esp.ID_MEDICO
                                   join especial in bd.Especialidad
                                   on med_esp.ID_ESPECIALIDAD equals especial.ESPECIALIDADID
                                   where horario.BHABILITADO == 1
                                   select new HorarioCLS
                                   {
                                       horarioid = horario.HORARIOID,
                                       nombreEspecialidad = especial.NOMBRE,
                                       fecha_atention = (DateTime)horario.FECHA_ATENTION,
                                       hora_atention = (TimeSpan)horario.HORA_ATENTION,
                                       hora_fin = (TimeSpan)horario.HORA_FIN,
                                       nombreDisp = disp.NOMBRE,
                                       HoraInicio = horario.HORA_ATENTION.ToString(),
                                       HoraFin = horario.HORA_FIN.ToString()
                                   }).ToList();
                }
                else
                {
                    listHorario = (from horario in bd.Horario
                                   join disp in bd.Disponibilidad
                                   on horario.ID_DISP equals disp.DISPID
                                   join medico in bd.Medico
                                   on horario.ID_MEDICO equals medico.MEDICOID
                                   join med_esp in bd.Medico_Especial
                                   on medico.MEDICOID equals med_esp.ID_MEDICO
                                   join especial in bd.Especialidad
                                   on med_esp.ID_ESPECIALIDAD equals especial.ESPECIALIDADID
                                   where horario.BHABILITADO == 1
                                   && disp.NOMBRE.Contains(nombreDisp)
                                   select new HorarioCLS
                                   {
                                       horarioid = horario.HORARIOID,
                                       nombreEspecialidad = especial.NOMBRE,
                                       fecha_atention = (DateTime)horario.FECHA_ATENTION,
                                       hora_atention = (TimeSpan)horario.HORA_ATENTION,
                                       hora_fin = (TimeSpan)horario.HORA_FIN,
                                       nombreDisp = disp.NOMBRE,
                                       HoraInicio = horario.HORA_ATENTION.ToString(),
                                       HoraFin = horario.HORA_FIN.ToString()
                                   }).ToList();

                    
                }

                filtroCount = listHorario.Count();
                ViewBag.searchCount = filtroCount;
            }
            return PartialView("_TablaHorario", listHorario);
        }

        public string Guardar(HorarioCLS oHorarioCLS, int titulo, int medic)
        {
            string rpta = "";
            if (!ModelState.IsValid)
            {
                llenarListas();
                var query = (from state in ModelState.Values
                            from error in state.Errors
                            select error.ErrorMessage).ToList();

                rpta += "<ul class='list-group'>";
                foreach(var item in query) 
                {
                    rpta += "<li class= 'list-group-item'>" + item + "</li>";
                }
                rpta += "</ul>";

                return rpta;
            }
            else 
            {
                
                using (var bd = new LinkPro_Test_Old_Update())
                {
                    var listTime = (from horario in bd.Horario
                                    join med in bd.Medico
                                    on horario.ID_MEDICO equals med.MEDICOID
                                    where medic == horario.ID_MEDICO
                                    && horario.BHABILITADO == 1
                                    select new SelectListItem
                                    {
                                        Text = horario.HORA_ATENTION.ToString(),
                                        Value = horario.FECHA_ATENTION.ToString(),
                                    }).ToList();

                    string compH = oHorarioCLS.hora_atention.ToString();
                    string compF = oHorarioCLS.fecha_atention.ToString();
                    compF = converse(compF);


                    foreach (var item in listTime)
                    {
                        if (item.Text == compH && item.Value == compF)
                        {
                            rpta="true";
                        }
                    }
                    if (rpta.Equals(""))
                    {
                        llenarListas();
                        if (titulo == -1)
                        {
                            Horario oHorario = new Horario();
                            oHorario.ID_MEDICO = medic;
                            oHorario.BHABILITADO = 1;
                            oHorario.ALL_DAY = false;
                            oHorario.FECHA_REGISTRO = DateTime.UtcNow;

                            oHorario.ID_ESPECIALIDAD = oHorarioCLS.id_especialidad;
                            oHorario.FECHA_ATENTION = oHorarioCLS.fecha_atention;
                            oHorario.HORA_ATENTION = oHorarioCLS.hora_atention;
                            oHorario.FECHA_FIN = oHorarioCLS.fecha_atention;
                            oHorario.HORA_FIN = oHorarioCLS.hora_fin;
                            oHorario.ID_DISP = oHorarioCLS.id_disp;
                            bd.Horario.Add(oHorario);

                            rpta = bd.SaveChanges().ToString();

                        }
                        else 
                        {
                            Horario oHorario = bd.Horario.Where(p => p.HORARIOID == titulo).First();
                            oHorario.ID_ESPECIALIDAD = oHorarioCLS.id_especialidad;
                            oHorario.FECHA_ATENTION = oHorarioCLS.fecha_atention;
                            oHorario.HORA_ATENTION = oHorarioCLS.hora_atention;
                            oHorario.FECHA_FIN = oHorarioCLS.fecha_atention;
                            oHorario.HORA_FIN = oHorarioCLS.hora_fin;
                            oHorario.ID_DISP = oHorarioCLS.id_disp;
                            rpta = bd.SaveChanges().ToString();
                        }
                    }
                }
            }
            return rpta;
        }

        public string Eliminar(int id) 
        {
            string rpta = "";

            try
            {
                using (var bd = new LinkPro_Test_Old_Update())
                {
                    int idHorario = id;
                    Horario oHorario = bd.Horario.Where(p => p.HORARIOID == idHorario).First();
                    oHorario.BHABILITADO = 0;
                    rpta = bd.SaveChanges().ToString();

                }
            }
            catch (Exception)
            {

                rpta = "";
            }
            return rpta;
        }

        public JsonResult recuperarDatos(int? id) 
        {
            HorarioCLS oHorarioCLS = new HorarioCLS();
            using (var bd=new LinkPro_Test_Old_Update()) 
            {
                Horario oHorario = bd.Horario.Where(p => p.HORARIOID == id).First();
                oHorarioCLS.id_especialidad = (int)oHorario.ID_ESPECIALIDAD;
                oHorarioCLS.cadena_fechaI = ((DateTime)oHorario.FECHA_ATENTION).ToString("yyyy-MM-dd");
                oHorarioCLS.HoraInicio = ((TimeSpan)oHorario.HORA_ATENTION).ToString();
                oHorarioCLS.fecha_fin = (DateTime)oHorario.FECHA_FIN;
                oHorarioCLS.HoraFin = ((TimeSpan)oHorario.HORA_FIN).ToString();
                oHorarioCLS.id_disp = (int)oHorario.ID_DISP;
            }
            return Json(oHorarioCLS, JsonRequestBehavior.AllowGet);
        }

        public void listDisponible()
        {
            List<SelectListItem> listDisp;
            using (var bd = new LinkPro_Test_Old_Update())
            {
                listDisp = (from disp in bd.Disponibilidad
                            where disp.BHABILITADO == 1
                            select new SelectListItem
                            {
                                Text = disp.NOMBRE,
                                Value = disp.DISPID.ToString(),
                            }).ToList();
            }
            listDisp.Insert(0, new SelectListItem { Text = "--Seleccione--" });
            ViewBag.listDisponible = listDisp;
        }
        public void listEspecial()
        {
            List<SelectListItem> listEsp;
            using (var bd = new LinkPro_Test_Old_Update())
            {
                listEsp = (from esp in bd.Especialidad
                           join med_esp in bd.Medico_Especial
                           on esp.ESPECIALIDADID equals med_esp.ID_ESPECIALIDAD
                           join medico in bd.Medico
                           on med_esp.ID_MEDICO equals medico.MEDICOID
                           where esp.BHABILITADO == 1
                           select new SelectListItem
                           {
                               Text = esp.NOMBRE,
                               Value = esp.ESPECIALIDADID.ToString(),
                           }).ToList();
            }
            listEsp.Insert(0, new SelectListItem { Text = "--Seleccione--" });
            ViewBag.listaEspecial = listEsp;
        }

        public void llenarListas()
        {
            listDisponible();
            listEspecial();
        }
        public string converse(string val) 
        {
            char[] aux = { '-' };
            string[] saux;
            string[] cont = {"","","" };
            int i = 2;

            val = val.Substring(0,10);
            val = val.Replace("/", "-");

            saux = val.Split(aux);

            foreach(var word in saux) 
            {
                cont[i] = word + "-";
                i--;
            }
            val = String.Concat(cont);

            val = val.Substring(0, 10);
            return val;
        }

    }   

}