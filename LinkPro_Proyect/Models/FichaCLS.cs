using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace LinkPro_Proyect.Models
{
    public class FichaCLS
    {
        [Display(Name = "ID Ficha")]
        [Required]
        public int fichaid { get; set; }
        [Display(Name = "Afiliación")]
        public int id_afiliacion { get; set; }
        [Display(Name = "Sexo")]
        public int id_sexo { get; set; }
        [Display(Name = "Masa")]
        [Required]
        public float masa { get; set; }
        [Display(Name = "Altura")]
        [Required]
        public int altura { get; set; }
        [Display(Name = "Grupo de Sangre")]
        [Required]
        [StringLength(20, ErrorMessage = "Longitud Maxima 20 Caracteres")]
        public string grupo_sangre { get; set; }
        [Display(Name = "Enfermedades")]
        [Required]
        [StringLength(300, ErrorMessage = "Longitud Maxima 300 Caracteres")]
        public string enfermedades { get; set; }
        [Display(Name = "Medicamentos")]
        [Required]
        [StringLength(300, ErrorMessage = "Longitud Maxima 300 caracteres")]
        public string medicamentos { get; set; }
        [Display(Name = "Alergias")]
        [Required]
        [StringLength(200, ErrorMessage = "Longitud maxima 200 caracteres")]
        public string alergias { get; set; }
        [Display(Name ="Observacion")]
        [StringLength(200, ErrorMessage = "Longitud maxima 200 caracteres")]
        public string observaciones { get; set; }
        //---------Funciones extras----------
        [Display(Name ="Sexo")]
        public string sexo { get; set; }
        [Display(Name = "Afiliacion")]
        public string afiliacion { get; set; }
        public int id { get; set; }
    }
}