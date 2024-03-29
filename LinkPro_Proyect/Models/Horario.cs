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
    
    public partial class Horario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Horario()
        {
            this.Citas = new HashSet<Citas>();
        }
    
        public int HORARIOID { get; set; }
        public int ID_MEDICO { get; set; }
        public Nullable<System.DateTime> FECHA_ATENTION { get; set; }
        public Nullable<System.DateTime> FECHA_REGISTRO { get; set; }
        public string USUARIO_REGISTRO { get; set; }
        public Nullable<int> BHABILITADO { get; set; }
        public Nullable<int> ID_DISP { get; set; }
        public Nullable<System.TimeSpan> HORA_ATENTION { get; set; }
        public Nullable<System.DateTime> FECHA_FIN { get; set; }
        public Nullable<System.TimeSpan> HORA_FIN { get; set; }
        public Nullable<bool> ALL_DAY { get; set; }
        public Nullable<int> ID_ESPECIALIDAD { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Citas> Citas { get; set; }
        public virtual Medico Medico { get; set; }
        public virtual Disponibilidad Disponibilidad { get; set; }
        public virtual Especialidad Especialidad { get; set; }
    }
}
