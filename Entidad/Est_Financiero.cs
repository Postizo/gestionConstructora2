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
    
    public partial class Est_Financiero
    {
        public int Id_Estudio { get; set; }
        public string Nombre { get; set; }
        public System.DateTime Fini { get; set; }
        public System.DateTime Ffin { get; set; }
        public int mts_Construidos { get; set; }
        public int mts_Utiles { get; set; }
        public double Compra_Bruto { get; set; }
        public double Gastos_Adquisicion { get; set; }
        public int CosteReforma { get; set; }
        public double Impuestos { get; set; }
        public double Mantenimiento { get; set; }
        public int AporCapital { get; set; }
        public int ImpHipoteca { get; set; }
        public double TipoInteres { get; set; }
        public int AñoAmortizacion { get; set; }
        public int P_Venta { get; set; }
        public double GastosVenta { get; set; }
        public string Comentarios { get; set; }
    }
}
