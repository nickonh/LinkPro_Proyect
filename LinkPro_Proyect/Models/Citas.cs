//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LinkPro_Proyect.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Citas
    {
        public int CITASID { get; set; }
        public int ID_MEDICO { get; set; }
        public int ID_PACIENTE { get; set; }
        public Nullable<int> ID_ESTADO { get; set; }
        public int CODE_RESERVAID { get; set; }
        public Nullable<System.DateTime> FECHA_ATENCION { get; set; }
        public Nullable<System.TimeSpan> START_ATENCION { get; set; }
        public Nullable<System.TimeSpan> END_ATENCION { get; set; }
        public string OBSERVACIONES { get; set; }
        public int ID_HORARIO { get; set; }
    
        public virtual Estado Estado { get; set; }
        public virtual Horario Horario { get; set; }
        public virtual Medico Medico { get; set; }
        public virtual Paciente Paciente { get; set; }
    }
}
