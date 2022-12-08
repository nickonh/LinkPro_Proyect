using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace LinkPro_Proyect.Models
{
    public class HorarioCLS
    {
        [Key]
        public int horarioid { get; set; }
        [Display(Name = "Especialidad")]
        public int id_especialidad { get; set; }
        public int id_medico { get; set; }
        [Display(Name = "Disponibilidad")]
        [Required]
        public int id_disp { get; set; }
        [Display(Name = "Fecha Atencion")]
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime fecha_atention { get; set; }
        [Display(Name = "Hora Atencion")]
        [Required]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm:ss}")]
        public TimeSpan hora_atention { get; set; }
        [Required]
        public DateTime fecha_fin { get; set; }//
        [Display(Name = "Hora Finlizacion")]
        [Required]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm:ss}")]
        public TimeSpan hora_fin { get; set; }//
        public string fecha_registro { get; set; }
        public string usuario_registro { get; set; }
        public bool all_day { get; set; }

        //Propiedades extras
        public string NombreMedico { get; set; }
        [Display(Name = "Disponibilidad")]
        public string nombreDisp { get; set; }
        public string colorDisp { get; set; }
        public string textDisp { get; set; }
        public string fullinicio { get; set; }
        public string fullfin { get; set; }
        [Display(Name = "Especialidad")]
        public string nombreEspecialidad { get; set; }
        public string HoraInicio { get; set; }
        public string HoraFin { get; set; }
        public string cadena_fechaI { get; set; }
        public string cadena_fechaF { get; set; }

    }
}