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
    
    public partial class Presu_Calidad
    {
        public int Id_linea { get; set; }
        public int Id_elemento { get; set; }
        public int Tipo_Calidad { get; set; }
        public string Calidad { get; set; }
        public decimal Precio { get; set; }
    
        public virtual Presu_Elementos Presu_Elementos { get; set; }
    }
}