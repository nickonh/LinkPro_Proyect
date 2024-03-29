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
    
    public partial class Sucursal
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sucursal()
        {
            this.Medico1 = new HashSet<Medico>();
        }
    
        public int SUCURSALID { get; set; }
        public string NOMBRE_SUCURSAL { get; set; }
        public Nullable<System.DateTime> FECHA_REGISTRO { get; set; }
        public string USUARIO_REGISTRO { get; set; }
        public Nullable<int> BHABILITADO { get; set; }
        public Nullable<int> ID_COMUNA { get; set; }
        public Nullable<int> ID_REGION { get; set; }
        public Nullable<int> ID_CIUDAD { get; set; }
        public Nullable<int> ID_MEDICO { get; set; }
        public string DIRECCION { get; set; }
        public byte[] FOTO { get; set; }
        public string NOMBRE_FOTO { get; set; }
        public string DESCRIPCION { get; set; }
    
        public virtual Ciudad Ciudad { get; set; }
        public virtual Comuna Comuna { get; set; }
        public virtual Medico Medico { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Medico> Medico1 { get; set; }
        public virtual Region Region { get; set; }
    }
}
