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
        public string fecha_atencion { get; set; }
        [Display(Name ="Hora de atencion")]
        [StringLength(5,  ErrorMessage ="Formato de Hora: hh:mm")]
        [Required]
        public string start_atencion { get; set; }
        [Display(Name ="Observaciones de la Cita")]
        [StringLength(500, ErrorMessage = "Sobre paso el maximo de caracteres")]
        public string observaciones { get; set; }
        public int bhabilitado { get; set; }
        //Propiedades Adicionales
        [Display(Name = "Estado")]
        public string nombreEstado { get; set; }
        public string NombrePaciente { get; set; }
        public string NombreMedico { get; set; }
        public string fullInicio { get; set; }
        public string fullFin { get; set; }

    }

}