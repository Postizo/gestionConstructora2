
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class ObrasMeta
    {
        [Required(ErrorMessage = "El nombre es un campo obligatorio.")]
        [StringLength(150, MinimumLength = 3, ErrorMessage = "El nombre no puede estar vacio ")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El Codigo de Sigrid es un campo obligatorio.")]
        [Range(0, Int32.MaxValue, ErrorMessage = "El valor {0} no es válido para el Codigo de Sigrid")]
        public int Id_Sigrid { get; set; }

        [Required(ErrorMessage = "Los m Construidos es un campo obligatorio.")]
        [Range(0, Int32.MaxValue, ErrorMessage = "El valor {0} no es válido para metros construidos")]
        public double Construido { get; set; }
    }

    [MetadataType(typeof(ObrasMeta))]
    public partial class Obras :IValidable
    {
        public string campocompara { get; set; }
        public decimal Solo_Man_Obra { get; set; }
        public  decimal Total_Ingresos1_Conta { get; set; }
        public decimal  P_Total_Ingresos1_Conta { get; set; }
        public decimal Total_GastosContribuciondirecta2_Conta { get; set; }
        public decimal P_Total_GastosContribuciondirecta2_Conta { get; set; }
        public decimal Total_Gastosdirectos3_Conta { get; set; }
        public decimal P_Total_Gastosdirectos3_Conta { get; set; }
        public decimal Total_GastosGENERAL5_Conta { get; set; }
        public decimal P_Total_GastosGENERAL5_Conta { get; set; }
        public decimal Total_restoIngresos7_Conta { get; set; }
        public decimal Total_Hipotecas { get; set; }
        public decimal P_Total_restoIngresos7_Conta { get; set; }
        public decimal C_Total_Facturado { get; set; }
        public decimal C_RetencionGarantia { get; set; }
        public decimal Confirming_Aceptado { get; set; }
        public decimal Confirming_Pendiente { get; set; }
        public decimal RepercutidoGeneral19 { get; set; }
        public decimal PorcentajeSobeGenerales { get; set; }


        public List<Obras_Lineas> Capitulos { get; set; }
        private List<ValidationResult> _ValidationErrors;
               
        public bool IsValid
        {
            get
            {
                var validator = Validator.Validate(this);
                _ValidationErrors = validator.Item2;
                return validator.Item1;
            }

            set
            {
                throw new NotImplementedException();
            }
        }
        public List<ValidationResult> ValidationErrors
        {
            get
            {
                return _ValidationErrors;
            }

            set
            {
                _ValidationErrors = value;
            }
        }
        public void PREPARAOBRA()
        {
           
            Agregar_el_desglose();          
        }
        
        private void Agregar_el_desglose()
        {
            // Procedimiento para listar la obra en nuestro modo basada en la agrupacion de los grupos, los meteremos en al propiedad Capitulos
            var Subcapitus = from p in Obras_Lineas
                             group p by new { p.Id_Subgrupo, p.Id_Fase }  into g
                             select new Obras_Lineas
                             {
                                 Id_Obra = g.Select(m => m.Id_Obra).ToList()[0],
                                 Id_Grupo = g.Select(m => m.Id_Grupo).ToList()[0],
                                 Id_Subgrupo = g.Key.Id_Subgrupo,
                                 Id_Fase= g.Key.Id_Fase,
                                 Nombre = g.Select(m => m.Subgrupos.Nombre).ToList()[0],
                                 Importe_presu = g.Sum(m => m.Importe_presu),
                                 Importe_P_venta = g.Sum(m => m.Importe_P_venta),
                                 Importe_CostePrevisto = g.Sum(m => m.Importe_CostePrevisto),
                                 Importe_VentaPrevista = g.Sum(m => m.Importe_VentaPrevista),
                                 Importe_Certificado = g.Sum(m => m.Importe_Certificado),
                                 Importe_Facturado = g.Sum(m => m.Importe_Facturado),
                                 Importe_Pagado = g.Sum(m => m.Importe_Pagado),
                                 Importe_Albaranes = g.Sum(m => m.Importe_Albaranes),
                                 Importe_ManoObra = g.Sum(m => m.Importe_ManoObra),
                                 Importe_CosteReal = g.Sum(m => m.Importe_CosteReal),
                                 //Importe_CosteReal_venta = g.Sum(m => m.Importe_CosteReal_venta),
                                 Capitulo = g.Key.ToString(),
                                 Medidas = g.Sum(m => m.Medidas),
                                 Unidad_Medida = g.Select(m => m.Unidad_Medida).ToList()[0],
                                 Id_TipoCoste = g.Select(m => m.Id_TipoCoste).ToList()[0],
                                 Grupos = g.Select(m => m.Grupos).ToList()[0],
                                 Subgrupos = g.Select(m => m.Subgrupos).ToList()[0],
                                 
                                 
                             };


            var Capitu = from p in Obras_Lineas
                         group p by  new { p.Id_Grupo, p.Id_Fase } into g
                         select new Obras_Lineas { Id_Obra = g.Select(m => m.Id_Obra).ToList()[0],
                             Id_Grupo = g.Key.Id_Grupo,
                             Id_Subgrupo = g.Select(m => m.Id_Subgrupo).ToList()[0],
                             Id_Fase = g.Key.Id_Fase,
                             Nombre = g.Select(m => m.Grupos.Nombre).ToList()[0],
                             Importe_presu = g.Sum(m => m.Importe_presu),
                             Importe_P_venta = g.Sum(m => m.Importe_P_venta),
                             Importe_CostePrevisto = g.Sum(m => m.Importe_CostePrevisto),
                             Importe_VentaPrevista = g.Sum(m => m.Importe_VentaPrevista),
                             Importe_Certificado = g.Sum(m => m.Importe_Certificado),
                             Importe_Facturado = g.Sum(m => m.Importe_Facturado ),
                             Importe_Pagado = g.Sum(m => m.Importe_Pagado),
                             Importe_Albaranes = g.Sum(m => m.Importe_Albaranes),
                             Importe_ManoObra = g.Sum(m => m.Importe_ManoObra),
                             Importe_CosteReal = g.Sum(m => m.Importe_CosteReal),
                             Capitulo = g.Key.ToString(),
                             Medidas = g.Sum(m => m.Medidas),
                             Unidad_Medida = g.Select(m => m.Unidad_Medida).ToList()[0],
                             Subcapitulos = Subcapitus.Where(p => p.Id_Subgrupo != 0).Where(p => p.Id_Grupo == g.Key.Id_Grupo).ToList(),
                             Id_TipoCoste = g.Select(m => m.Id_TipoCoste).ToList()[0],
                             Grupos = g.Select(m => m.Grupos).ToList()[0],
                             Subgrupos = g.Select(m => m.Subgrupos).ToList()[0],
                            

                         };
            Capitulos = Capitu.ToList();
           
        }
        public void QUitarCP()
        {
            //double CP = this.Obras_Lineas.Where(p => p.Id_TipoCoste == 3).Sum(p => p.Medidas);

            //foreach (Obras_Lineas linea  this.Obras_Lineas)
            //{

            //}
        }

        //private void Calculo_Importes()
        //{
        //    foreach (Obras_Lineas Capitulos in this.Capitulos)
        //    {
        //        Capitulos.Importe_Gastado = this.Facturas_ca.Where(p => p.Estado == 0 || p.Estado == 1).Sum(p => p.Facturas_li.Where(a => a.Id_grupo == Capitulos.Id_Grupo).Sum(a => a.Base));
        //        Capitulos.Importe_Pagado = this.Facturas_ca.Where(p => p.Estado == 1).Sum(p => p.Facturas_li.Where(a => a.Id_grupo == Capitulos.Id_Grupo).Sum(a => a.Base));                              

        //        if (Capitulos.Subcapitulos.Count > 0)
        //        {
        //            foreach (Obras_Lineas SubCap in Capitulos.Subcapitulos)
        //            {
        //                SubCap.Importe_Gastado = this.Facturas_ca.Where(p => p.Estado == 0 || p.Estado == 1).Sum(p => p.Facturas_li.Where(a => a.id_subgrupo  == SubCap.Id_Subgrupo).Sum(a => a.Base));
        //                SubCap.Importe_Pagado = this.Facturas_ca.Where(p => p.Estado == 1).Sum(p => p.Facturas_li.Where(a => a.id_subgrupo  == SubCap.Id_Subgrupo).Sum(a => a.Base));
        //            }
        //        }
        //    }
        //}

    }
}
