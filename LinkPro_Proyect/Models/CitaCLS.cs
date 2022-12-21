using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace LinkPro_Proyect.Models
{
    public class CitaCLS
    {
        [Display(Name = "ID Cita")]
        [Required]
        public int citasid { get; set; }
        [Display(Name = "ID Medico")]
        [Required]
        public int id_medico { get; set; }
        [Display(Name = "ID Paciente")]
        [Required]
        public int id_paciente { get; set; }
        [Display(Name = "ID Estado")]
        [Required]
        public int id_estado { get; set; }
        [Display(Name = "Codigo de Reserva")]
        [Required]
        public int code_reservaid { get; set; }
        [Display(Name = "ID Horario")]
        [Required]
        public int id_horario { get; set; }
        [Display(Name = "Fecha de Atencion")]
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime fecha_atencion { get; set; }
        [Display(Name ="Hora de Atencion")]
        [Required]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm:ss}")]
        public TimeSpan hora_atencion { get; set; }
        [Display(Name = "Fecha de Finalizacion")]
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime fecha_fin { get; set; }
        [Display(Name = "Hora de Atencion")]
        [Required]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm:ss}")]
        public TimeSpan hora_Fin { get; set; }
        [Display(Name ="Observaciones de la Cita")]
        [StringLength(500, ErrorMessage = "Sobre paso el maximo de caracteres")]
        public string observaciones { get; set; }

        public int bhabilitado { get; set; }


        //----Propiedades Adicionales----
        
        //Propiedades del Medico
        public int id_especialidad { get; set; }
        public string nombreEspecial { get; set; }
        public string NombreMedico { get; set; }

        //Propiedades del Horario
        public string fullInicio { get; set; }
        public string fullFin { get; set; }

        //Propiedades del Estado
        [Display(Name = "Estado")]
        public string nombreEstado { get; set; }

        //Propiedades del Paciente
        [Display(Name = "E-Mail")]
        [StringLength(50, ErrorMessage = "Longitud Maxima 50 Caracteres")]
        [EmailAddress(ErrorMessage = "Ingrese un Mail valido")]
        [Required]
        public string emailPaciente { get; set; }
        public string nombrePaciente { get; set; }
        public string apellidoPaciente { get; set; }
        public string saveFono { get; set; }
        public string registroRut { get; set; }

        //----Propiedades Adicionales----

    }

}