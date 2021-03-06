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
    
    public partial class Obras_Lineas
    {
        public int Id_linea { get; set; }
        public int Id_Empresa { get; set; }
        public int Id_Obra { get; set; }
        public int Id_ObraSigrid { get; set; }
        public int Id_Estado { get; set; }
        public int Id_Fase { get; set; }
        public int Id_TipoCoste { get; set; }
        public string Capitulo { get; set; }
        public string Subcapitulo { get; set; }
        public int Id_Grupo { get; set; }
        public int Id_Subgrupo { get; set; }
        public string Nombre { get; set; }
        public double Medidas { get; set; }
        public string Unidad_Medida { get; set; }
        public System.DateTime Fecha_importado { get; set; }
        public decimal Importe { get; set; }
        public decimal Importe_presu { get; set; }
        public decimal Importe_P_venta { get; set; }
        public decimal Importe_VentaPrevista { get; set; }
        public decimal Importe_CostePrevisto { get; set; }
        public decimal Importe_Certificado { get; set; }
        public decimal Importe_CosteReal { get; set; }
        public decimal Importe_Facturado { get; set; }
        public decimal Importe_Pagado { get; set; }
        public decimal Importe_Albaranes { get; set; }
        public decimal Importe_ManoObra { get; set; }
        public int Orden { get; set; }
        public bool Mano_Obra { get; set; }
    
        public virtual Estados Estados { get; set; }
        public virtual Grupos Grupos { get; set; }
        public virtual Obras Obras { get; set; }
        public virtual Subgrupos Subgrupos { get; set; }
    }
}
