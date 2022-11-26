using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LinkPro_Proyect.Models
{
    public class MedicoCLS
    {
        [Display(Name = "Id Medico")]
        [Required]
        public int medicoid { get; set; }
        [Display(Name = "Id Usuario")]
        public int id_usuario { get; set; }
        [Display(Name = "Id Sucursal")]
        public int id_sucursal { get; set; }
        [Display(Name = "Id Estado")]
        [Required]
        public int id_estado { get; set; }
        [Display(Name ="Id Especialidad/es")]
        [Required]
        public int id_medicoespecial { get; set; }
        [Display(Name = "Nombre")]
        [Required]
        [StringLength(50, ErrorMessage = "Longitud Maxima 50 Caracteres")]
        public string nombre { get; set; }
        [Display(Name = "Apellido")]
        [Required]
        [StringLength(50, ErrorMessage = "Longitud Maxima 50 Caracteres")]
        public string apellido { get; set; }
        [Display(Name = "Telefono")]
        [Required]
        [StringLength(9, ErrorMessage = "Ingrese 9 numeros")]
        public string telefono { get; set; }
        [Display(Name = "Email")]
        [Required]
        [StringLength(50, ErrorMessage = "Longitud maxima 50 caracteres")]
        public int email { get; set; }
        [Required]
        [Display(Name = "El ultimo cambio se realizo en la fecha:")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime fecha_registro { get; set; }
        [Display(Name ="El ultimo cambio lo realizo el usuario:")]
        public string usuario_registro { get; set; }
        public int bhabilitado { get; set; }

        //Propiedades Adicionales
        [Display(Name ="Tipo de Usuario")]
        public string tipousuario { get; set; }
        [Display(Name = "Nombre de la Sucursal")]
        public string nombresucursal { get; set; }
        [Display(Name = "Estado actual del Usuario")]
        public string estadoactual { get; set; }
        [Display(Name = "Especialidad/es")]
        public string nombrespecial { get; set; }
    }
}