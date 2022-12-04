using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LinkPro_Proyect.Models;

namespace LinkPro_Proyect.Controllers
{
    public class FichaController : Controller
    {
        // GET: Ficha
        [HttpGet]
        public ActionResult Index(int id)
        {
            List<FichaCLS> listFicha = null;
            using (var bd = new LinkPro_Test_Old_Update())
            {
                listFicha = (from ficha in bd.Ficha
                             join paciente in bd.Paciente
                             on ficha.FICHAID equals paciente.ID_FICHA
                             join sexo in bd.Sexo
                             on ficha.ID_SEXO equals sexo.SEXOID
                             join afiliacion in bd.Afiliacion
                             on ficha.ID_AFILIACION equals afiliacion.AFILIACIONID
                             where paciente.PACIENTEID == id
                             select new FichaCLS
                             {
                                 id = id,
                                 fichaid = ficha.FICHAID,
                                 afiliacion = afiliacion.NOMBRE,
                                 sexo = sexo.NOMBRE,
                                 masa = (float)ficha.MASA,
                                 altura = (int)ficha.ALTURA,
                                 grupo_sangre = ficha.GRUPO_SANGRE,
                                 enfermedades = ficha.ENFERMEDADES,
                                 medicamentos = ficha.MEDICAMENTOS,
                                 alergias = ficha.ALERGIAS,
                                 observaciones = ficha.OBSERVACIONES,
                             }).ToList();
            }
            return View(listFicha);
        }

        //Post: Ficha
        public ActionResult Agregar()
        {
            llenarCombos();
            return View();
        }

        [HttpPost]
        public ActionResult Agregar(FichaCLS oFichaCLS, int id)
        {
            if (!ModelState.IsValid)
            {
                llenarCombos();
                return View(oFichaCLS);
            }
            using (var bd = new LinkPro_Test_Old_Update())
            {

                Ficha oFicha = new Ficha();
                oFicha.ID_AFILIACION = oFichaCLS.id_afiliacion;
                oFicha.ID_SEXO = oFichaCLS.id_sexo;
                oFicha.MASA = oFichaCLS.masa;
                oFicha.ALTURA = oFichaCLS.altura;
                oFicha.GRUPO_SANGRE = oFichaCLS.grupo_sangre;
                oFicha.ENFERMEDADES = oFichaCLS.enfermedades;
                oFicha.MEDICAMENTOS = oFichaCLS.medicamentos;
                oFicha.ALERGIAS = oFichaCLS.alergias;
                oFicha.OBSERVACIONES = oFichaCLS.observaciones;

                bd.Ficha.Add(oFicha);
                bd.SaveChanges();

                Paciente oPaciente = bd.Paciente.Where(p => p.PACIENTEID.Equals(id)).First();
                oPaciente.ID_FICHA = oFicha.FICHAID;
                bd.SaveChanges();
            }

            return RedirectToAction("Pacientes");
        }
        public ActionResult Editar(int id)
        {
            llenarCombos();
            FichaCLS oFichaCLS = new FichaCLS();
            using (var bd = new LinkPro_Test_Old_Update())
            {
                Ficha oFicha = bd.Ficha.Where(p => p.FICHAID.Equals(id)).First();
                oFichaCLS.fichaid = oFicha.FICHAID;
                oFichaCLS.id_afiliacion = (int)oFicha.ID_AFILIACION;
                oFichaCLS.id_sexo = (int)oFicha.ID_SEXO;
                oFichaCLS.masa = (int)oFicha.MASA;
                oFichaCLS.altura = (int)oFicha.ALTURA;
                oFichaCLS.grupo_sangre = oFicha.GRUPO_SANGRE;
                oFichaCLS.enfermedades = oFicha.ENFERMEDADES;
                oFichaCLS.medicamentos = oFicha.MEDICAMENTOS;
                oFichaCLS.alergias = oFicha.ALERGIAS;
                oFichaCLS.observaciones = oFicha.OBSERVACIONES;
            }
            return View(oFichaCLS);
        }
        [HttpPost]
        public ActionResult Editar(FichaCLS oFichaCLS)
        {
            if (!ModelState.IsValid)
            {
                return View(oFichaCLS);
            }
            int idFicha = oFichaCLS.fichaid;
            using (var bd = new LinkPro_Test_Old_Update())
            {
                Ficha oFicha = bd.Ficha.Where(p => p.FICHAID.Equals(idFicha)).First();
                oFicha.ID_AFILIACION = oFichaCLS.id_afiliacion;
                oFicha.ID_SEXO = oFichaCLS.id_sexo;
                oFicha.MASA = oFichaCLS.masa;
                oFicha.ALTURA = oFichaCLS.altura;
                oFicha.GRUPO_SANGRE = oFichaCLS.grupo_sangre;
                oFicha.ENFERMEDADES = oFichaCLS.enfermedades;
                oFicha.MEDICAMENTOS = oFichaCLS.medicamentos;
                oFicha.ALERGIAS = oFichaCLS.alergias;
                oFicha.OBSERVACIONES = oFichaCLS.observaciones;
                bd.SaveChanges();
            }
            //return RedirectToAction("Index");
            return RedirectToAction("Pacientes","GestionPaciente",null);
        }

        public void llenarAfiliacion()
        {
            List<SelectListItem> listaAfiliado;
            using (var bd = new LinkPro_Test_Old_Update())
            {
                listaAfiliado = (from afiliacion in bd.Afiliacion
                                 where afiliacion.BHABILITADO == 1
                                 select new SelectListItem
                                 {
                                     Text = afiliacion.NOMBRE,
                                     Value = afiliacion.AFILIACIONID.ToString()
                                 }).ToList();
                listaAfiliado.Insert(0, new SelectListItem { Text = "---Seleccione---", Value = "" });
                ViewBag.LAfiliado = listaAfiliado;
            }
        }
        public void llenarSexo()
        {
            List<SelectListItem> listaSexo;
            using (var bd = new LinkPro_Test_Old_Update())
            {
                listaSexo = (from sexo in bd.Sexo
                             where sexo.BHABILITADO == 1
                             select new SelectListItem
                             {
                                 Text = sexo.NOMBRE,
                                 Value = sexo.SEXOID.ToString()
                             }).ToList();
                listaSexo.Insert(0, new SelectListItem { Text = "---Seleccione---", Value = "" });
                ViewBag.LSexo = listaSexo;
            }
        }

        public void llenarCombos()
        {
            llenarAfiliacion();
            llenarSexo();
        }
    }
}