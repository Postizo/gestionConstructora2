using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public partial class Obras_Lineas
    {
        //LOS QUE VALEN 
        public List<Obras_Lineas> Subcapitulos { get; set; }
        //public decimal Importe_presu { get; set; }
        //public decimal Importe_P_venta { get; set; }
        //public decimal Importe_VentaPrevista { get; set; }
        //public decimal Importe_CostePrevisto { get; set; }
        //public decimal Importe_Certificado { get; set; }
        //public decimal Importe_CosteReal { get; set; }        
        //public decimal Importe_Facturado { get; set; }
        //public decimal Importe_Pagado { get; set; }
        //public decimal Importe_Albaranes { get; set; } 
        //public decimal Importe_ManoObra { get; set; }
     
        //---------------------------------------------------------------


        public decimal Porcen_SobreTotal { get; set; }
       // public decimal Importe_CosteReal_venta { get; set; } // Cosa Rara
        public decimal Importe_PresuSOLOCOSTES { get; set; }
        public decimal Importe_PresuIndirectos { get; set; }
        public decimal Importe_PresuGenerales { get; set; }
        public decimal Importe_PresuBeneficio { get; set; }
        public Obras_Lineas()
        {
            Subcapitulos = new List<Obras_Lineas>();
        }
     
    }
}
