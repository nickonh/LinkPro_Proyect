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
    
    public partial class Documentos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Documentos()
        {
            this.Paciente = new HashSet<Paciente>();
        }
    
        public int DOCUMENTOID { get; set; }
        public string NOMBRE_ARCHIVO { get; set; }
        public byte[] CONTENIDO { get; set; }
        public string EXTENSION { get; set; }
        public int ID_MEDICO { get; set; }
        public int ID_PACIENTE { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Paciente> Paciente { get; set; }
        public virtual Medico Medico { get; set; }
        public virtual Paciente Paciente1 { get; set; }
    }
}
