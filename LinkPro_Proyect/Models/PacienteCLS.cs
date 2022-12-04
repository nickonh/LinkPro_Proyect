using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace LinkPro_Proyect.Models
{
    public class PacienteCLS
    {
        [Display(Name = "Id Paciente")]
        [Required]
        public int pacienteid { get; set; }
        [Display(Name = "Id Usuario")]
        [Required]
        public int id_usuario { get; set; }
        [Display(Name ="Id Ficha")]
        public int id_ficha { get; set; }
        [Display(Name = "Comuna")]
        public int id_comuna { get; set; }
        [Display(Name = "Ciudad")]
        public int id_ciudad { get; set; }
        [Display(Name = "Region")]
        public int id_region { get; set; }
        [Display(Name = "Sexo")]
        public int sexo { get; set; }
        [Display(Name = "Estado")]
        public int id_estado { get; set; }
        [Display(Name = "Id Documento")]
        public int id_Documento { get; set; }
        [Display(Name = "Nombre")]
        [Required]
        [StringLength(50, ErrorMessage = "Longitud Maxima 50 Caracteres")]
        public string nombre { get; set; }
        [Display(Name = "Apellido")]
        [Required]
        [StringLength(50, ErrorMessage = "Longitud Maxima 50 Caracteres")]
        public string apellido { get; set; }
        [Display(Name = "Rut")]
        [Required]
        [StringLength(15, ErrorMessage = "Longitud Maxima 15 Caracteres")]
        public string rut { get; set; }
        [Display(Name = "Direccion")]
        [Required]
        [StringLength(50, ErrorMessage = "Longitud Maxima 50 Caracteres")]
        public string direccion { get; set; }
        [Display(Name = "Telefono Celular")]
        [Required]
        [StringLength(9, ErrorMessage = "Longitud Maxima 9 Caracteres")]
        public string telefono { get; set; }
        [Display(Name = "Fecha de Nacimiento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime fecha_nacimiento { get; set; }
        [Display(Name = "E-Mail")]
        [StringLength(50, ErrorMessage = "Longitud Maxima 50 Caracteres")]
        [EmailAddress(ErrorMessage = "Ingrese un Mail valido")]
        [Required]
        public string email { get; set; }
        [Required]
        [Display(Name = "Fecha de inscripcion")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime fecha_inscrito { get; set; }
        public int bhabilitado { get; set; }

        //Propiedades Adicionales
        [Display(Name ="Estado actual del Usuario")]
        public string estadoactual { get; set; }

        //Propiedades Adicionales Usuario

        [Display(Name ="Rol del Usuario")]
        public string nombrerol { get; set; }

        //Propiedad Adicional tabla Relacional 

        public IEnumerable<CitaCLS> Citas { get; set; }
    }
}