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
    
    public partial class Presu_Presu_li
    {
        public int Id_linea { get; set; }
        public int Id_version { get; set; }
        public int Id_Presu { get; set; }
        public int Id_Estancia { get; set; }
    
        public virtual Presu_Estancias Presu_Estancias { get; set; }
        public virtual Presu_Presu_Ca Presu_Presu_Ca { get; set; }
    }
}