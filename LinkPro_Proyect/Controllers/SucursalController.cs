using LinkPro_Proyect.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkPro_Proyect.Controllers
{
    public class SucursalController : Controller
    {
        // GET: Sucursal
        public ActionResult Index(int? id)
        {
            List<SucursalCLS> listsucursal = null;
            llenarlista();

            using (var bd = new LinkPro_Test_Old_Update()) 
            {
                var idM = (from medico in bd.Medico
                           join sucursal in bd.Sucursal
                           on medico.MEDICOID equals sucursal.ID_MEDICO
                           where medico.BHABILITADO == 1
                           select new
                           {
                               idMedic = medico.MEDICOID,
                               idSucur = sucursal.SUCURSALID
                           }).FirstOrDefault();

                listsucursal = (from sucursal in bd.Sucursal
                                join medico in bd.Medico
                                on sucursal.ID_MEDICO equals medico.MEDICOID
                                join region in bd.Region
                                on sucursal.ID_REGION equals region.REGIONID
                                join ciudad in bd.Ciudad
                                on sucursal.ID_CIUDAD equals ciudad.CIUDADID
                                join comuna in bd.Comuna
                                on sucursal.ID_COMUNA equals comuna.COMUNAID
                                where sucursal.BHABILITADO == 1
                                select new SucursalCLS
                                {
                                    sucursalid = sucursal.SUCURSALID,
                                    nombre_sucursal = sucursal.NOMBRE_SUCURSAL,
                                    nombre_region = region.NOMBRE,
                                    nombre_ciudad= ciudad.NOMBRE,
                                    nombre_comuna= comuna.NOMBRE,
                                    nombre_medico= medico.NOMBRE,
                                    apellido_medico= medico.APELLIDO,
                                    direccion= sucursal.DIRECCION,
                                    fullname = medico.NOMBRE + " " + medico.APELLIDO,
                                    descripcion = sucursal.DESCRIPCION
                                }).ToList();

                ViewBag.Med = idM.idMedic;
            }
                return View(listsucursal);
        }

        public ActionResult Filtrar(int? cityparam) 
        {
            List<SucursalCLS> listaSucursal = new List<SucursalCLS>();
            using (var bd = new LinkPro_Test_Old_Update()) 
            {
                if(cityparam == null) 
                {
                    listaSucursal = (from sucursal in bd.Sucursal
                                    join medico in bd.Medico
                                    on sucursal.ID_MEDICO equals medico.MEDICOID
                                    join region in bd.Region
                                    on sucursal.ID_REGION equals region.REGIONID
                                    join ciudad in bd.Ciudad
                                    on sucursal.ID_CIUDAD equals ciudad.CIUDADID
                                    join comuna in bd.Comuna
                                    on sucursal.ID_COMUNA equals comuna.COMUNAID
                                    where sucursal.BHABILITADO == 1
                                    select new SucursalCLS
                                    {
                                        sucursalid = sucursal.SUCURSALID,
                                        nombre_sucursal = sucursal.NOMBRE_SUCURSAL,
                                        nombre_region = region.NOMBRE,
                                        nombre_ciudad = ciudad.NOMBRE,
                                        nombre_comuna = comuna.NOMBRE,
                                        nombre_medico = medico.NOMBRE,
                                        apellido_medico = medico.APELLIDO,
                                        direccion = sucursal.DIRECCION,
                                        fullname = medico.NOMBRE + " " + medico.APELLIDO,
                                        descripcion = sucursal.DESCRIPCION
                                    }).ToList();
                }
                else 
                {
                    listaSucursal = (from sucursal in bd.Sucursal
                                     join medico in bd.Medico
                                     on sucursal.ID_MEDICO equals medico.MEDICOID
                                     join region in bd.Region
                                     on sucursal.ID_REGION equals region.REGIONID
                                     join ciudad in bd.Ciudad
                                     on sucursal.ID_CIUDAD equals ciudad.CIUDADID
                                     join comuna in bd.Comuna
                                     on sucursal.ID_COMUNA equals comuna.COMUNAID
                                     where sucursal.BHABILITADO == 1
                                     && sucursal.SUCURSALID == cityparam
                                     select new SucursalCLS
                                     {
                                         sucursalid = sucursal.SUCURSALID,
                                         nombre_sucursal = sucursal.NOMBRE_SUCURSAL,
                                         nombre_region = region.NOMBRE,
                                         nombre_ciudad = ciudad.NOMBRE,
                                         nombre_comuna = comuna.NOMBRE,
                                         nombre_medico = medico.NOMBRE,
                                         apellido_medico = medico.APELLIDO,
                                         direccion = sucursal.DIRECCION,
                                         fullname = medico.NOMBRE + " " + medico.APELLIDO,
                                         descripcion = sucursal.DESCRIPCION
                                     }).ToList();
                }
            }
            return PartialView("_TablaSucursal", listaSucursal);
        }
        [HttpPost]
        public string Guardar(SucursalCLS oSucursalCLS, HttpPostedFileBase foto, int titulo) 
        {
            var algo = "";

            string rpta = "";
            try 
            {
                if(!ModelState.IsValid || (foto==null && titulo == -1)) 
                {
                    llenarlista();
                    var query = (from state in ModelState.Values
                                 from error in state.Errors
                                 select error.ErrorMessage).ToList();

                    if (foto == null) 
                    {
                        oSucursalCLS.mensaje = "La foto es obligatoria";
                        rpta += "<ul><li> Debe Ingresar una foto</li></ul>";
                    }
                    rpta += "<ul class='list-group'>";
                    foreach (var item in query)
                    {
                        rpta += "<li class= 'list-group-item'>" + item + "</li>";
                    }
                    rpta += "</ul>";

                    return rpta;
                }
                else
                {
                    byte[] fotoBD = null;
                    if(foto != null) 
                    {
                        BinaryReader lector = new BinaryReader(foto.InputStream);
                        fotoBD = lector.ReadBytes((int)foto.ContentLength);
                    }
                    using (var bd =new LinkPro_Test_Old_Update()) 
                    {
                        if(titulo == -1) 
                        {
                            Sucursal oSucursal = new Sucursal();
                            oSucursal.SUCURSALID = oSucursalCLS.sucursalid;
                            oSucursal.ID_REGION = oSucursalCLS.id_region;
                            oSucursal.ID_CIUDAD = oSucursalCLS.id_ciudad;
                            oSucursal.ID_COMUNA = oSucursalCLS.id_comuna;
                            oSucursal.DIRECCION = oSucursalCLS.direccion;
                            oSucursal.DESCRIPCION = oSucursalCLS.descripcion;
                            oSucursal.FOTO = fotoBD;
                            oSucursal.NOMBRE_FOTO = oSucursalCLS.nombre_foto;

                            //oSucursal.ID_MEDICO = medic;
                            oSucursal.ID_MEDICO = 1;

                            oSucursal.BHABILITADO = 1;
                            bd.Sucursal.Add(oSucursal);
                            rpta = bd.SaveChanges().ToString();
                            if (rpta == "0") rpta = "";

                        }
                    }
                }
                
                    
            }
            catch (Exception ex) 
            {
                rpta = "";
                algo = ex.ToString();
            }
            return rpta;
        }

        public void listRegion() 
        {
            List<SelectListItem> listReg;
            using (var bd = new LinkPro_Test_Old_Update()) 
            {
                listReg = (from reg in bd.Region
                           where reg.BHABILITADO == 1
                           select new SelectListItem
                           {
                               Text = reg.NOMBRE,
                               Value = reg.REGIONID.ToString()
                           }).ToList();
            }
            listReg.Insert(0, new SelectListItem { Text = "--Seleccione--" });
            ViewBag.listReg = listReg;
        }

        public void listCiudad()
        {
            List<SelectListItem> listCiudad;
            using (var bd = new LinkPro_Test_Old_Update())
            {
                listCiudad=(from item in bd.Ciudad
                           where item.BHABILITADO == 1
                           select new SelectListItem
                           {
                               Text = item.NOMBRE,
                               Value = item.CIUDADID.ToString()
                           }).ToList();
            }
            listCiudad.Insert(0, new SelectListItem { Text = "--Seleccione--" });
            ViewBag.listciudad = listCiudad;
        }

        public void listComuna()
        {
            List<SelectListItem> listComuna;
            using (var bd = new LinkPro_Test_Old_Update())
            {
                listComuna = (from item in bd.Comuna
                              where item.BHABILITADO == 1
                              select new SelectListItem
                              {
                                  Text = item.NOMBRE,
                                  Value = item.COMUNAID.ToString()
                              }).ToList();
            }
            listComuna.Insert(0, new SelectListItem { Text = "--Seleccione--" });
            ViewBag.listcomuna = listComuna;
        }

        public void llenarlista() 
        {
            listRegion();
            listCiudad();
            listComuna();
        }
    }
}