using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace LinkPro_Proyect.Models
{
    public class UsuarioCLS
    {
        [Display(Name = "Id Usuario")]
        [Required]
        public int usuarioid { get; set; }
        [Display(Name = "Id Rol")]
        [Required]
        public int id_rol { get; set; }
        [Display(Name = "Nombre de Usuario")]
        [Required]
        [StringLength(100, ErrorMessage ="Longitud de maxima de 100 caracteres")]
        public string nombre_usuario { get; set; }
        [Display(Name = "E-Mail")]
        [StringLength(50, ErrorMessage = "Longitud Maxima 50 Caracteres")]
        [EmailAddress(ErrorMessage = "Ingrese un Mail valido")]
        [Required]
        public string email { get; set; }
        [Display(Name = "Contraseña")]
        [StringLength(32, ErrorMessage = "Longitud Maxima 32 Caracteres")]
        [DataType(DataType.Password)]
        [Required]
        public string secretpass { get; set; }
        public string bhabilitado { get; set; }

        //Porpiedades adicionales
        [Display(Name = "Rol del Usuario")]
        public string nombrerol { get; set; }

    }
}