//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Entidad
{
    using System;
    using System.Collections.Generic;
    
    public partial class Presu_Presu_Ca
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Presu_Presu_Ca()
        {
            this.Presu_Presu_li = new HashSet<Presu_Presu_li>();
        }
    
        public int Id_Presu { get; set; }
        public int Id_Version { get; set; }
        public string Nombre { get; set; }
        public decimal CteHora { get; set; }
        public decimal nPersonas { get; set; }
        public decimal horas_dias { get; set; }
        public decimal ndias { get; set; }
        public decimal T_Manoobra { get; set; }
        public decimal M_Materias { get; set; }
        public decimal G_Generales { get; set; }
        public decimal Beneficio { get; set; }
        public Nullable<int> U_Casas { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Presu_Presu_li> Presu_Presu_li { get; set; }
    }
}