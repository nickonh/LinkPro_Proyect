using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LinkPro_Proyect.Models
{
    public class HorarioCLS
    {
        public int horarioid { get; set; }
        public int id_medico { get; set; }
        public int id_disp { get; set; }//-
        public string fecha_atention { get; set; }
        public string hora_atention { get; set; }//
        public string fecha_fin { get; set; }//
        public string hora_fin { get; set; }//
        public string fecha_registro { get; set; }
        public string usuario_registro { get; set; }
        public bool all_day { get; set; }

        //Propiedades extras
        public string Hora { get; set; }
        public string NombreMedico { get; set; }
        public string nombreDisp { get; set; }
        public string colorDisp { get; set; }
        public string textDisp { get; set; }
        public string fullinicio { get; set; }
        public string fullfin { get; set; }

    }
}