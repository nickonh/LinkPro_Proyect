using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Web;

namespace LinkPro_Proyect.Models
{
    public class SucursalCLS
    {
        [Key]
        public int sucursalid { get; set; }
        [Display(Name ="Nombre de tú Sucursal")]
        [Required]
        [StringLength(100, ErrorMessage = "Longitud Maxima 100 Caracteres")]
        public string nombre_sucursal { get; set; }
        [Display(Name ="Fecha de Registro")]

        public DateTime fecha_registro { get; set; }
        [Display(Name ="Usuario que realizo el Registro")]
        public string user_registro { get; set; }
        [Display(Name ="Comuna")]
        [Required]
        public int id_comuna { get; set; }
        [Display(Name ="Region")]
        [Required]
        public int id_region { get; set; }
        [Display(Name ="Ciudad")]
        [Required]
        public int id_ciudad { get; set; }
        [Display(Name ="Medico")]
        public int id_medico { get; set; }
        [Display(Name = "Dirección")]
        [Required]
        [StringLength(200, ErrorMessage = "Longitud Maxima 200 Caracteres")]
        public string direccion { get; set; }
        [Display(Name = "Descripción")]
        [StringLength(500, ErrorMessage = "Longitud Maxima 500 Caracteres")]
        [Required]
        public string descripcion { get; set; }
        public int bhabilitado { get; set; }

        //Propiedades adicionales
        [Display(Name = "Comuna")]
        public string nombre_comuna { get; set; }
        [Display(Name = "Region")]
        public string nombre_region { get; set; }
        [Display(Name = "Ciudad")]
        public string nombre_ciudad { get; set; }
        
        public string nombre_medico { get; set; }
        public string apellido_medico { get; set; }
        [Display(Name = "Profesional a cargo")]
        public string fullname { get; set; }
        public string nombre_foto { get; set; }
        public string mensaje { get; set; }

    }
}