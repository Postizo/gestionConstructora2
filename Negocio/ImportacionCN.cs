using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;
using Negocio.Gestion;
using Datos;

namespace Negocio
{
  public class ImportacionCN
    {
        public static List<Obras_Lineas>  L_DetalleObra = new List<Obras_Lineas>();
        public static List<Obras_Lineas> Importacion_Presupuesto(Obras Obr,bool confase)
        {
            L_DetalleObra = new List<Obras_Lineas>();
            ObraGes ObraSIgrid = new ObraGes(Obr.Id_Sigrid, 0);
            Obr.Obras_Lineas.Clear();

            foreach (Capitulo cap in ObraSIgrid.Capitulos)
            {
                recursivo(cap, Obr, confase);
            }
            L_DetalleObra.Add(agregarlineaACOPIO(Obr));
            return L_DetalleObra;
        }
        public static void recursivo(Capitulo Cap,Obras obr,bool confases)
        {

            if (Cap.SubCapitulos.Count == 0)
            {
                if (Cap.Partidas.Count > 0)
                {
                    List<Partida> Partidas = (confases) ? Cap.Partidas : Cap.Partidas.Where(p => p.Fas == 0).ToList();
                    foreach (Partida Partid in Partidas) //Cambuiamos para solo coger los 0
                    {
                      L_DetalleObra.Add(agregarlinea(obr, Partid, Cap.Partidas));
                      
                    }
                }
             
            }
            else
            {
                foreach (Capitulo lin in Cap.SubCapitulos)
                {                    
                    recursivo(lin, obr, confases);
                }
            }

        }
        public static Obras_Lineas agregarlineaACOPIO(Obras Obr)
        {
            Obras_Lineas Linea1 = new Obras_Lineas();
            Linea1.Id_linea = 9999;
            Linea1.Id_Obra = Obr.Id_Obra;
            Linea1.Id_ObraSigrid = Obr.Id_Sigrid;
            Linea1.Id_Empresa = Obr.Id_Empresa;
            Linea1.Id_Estado = 0;
            Linea1.Id_Fase = 0;
            Linea1.Capitulo ="ACOPIO";
            Linea1.Subcapitulo = "";
            Linea1.Id_Grupo =  163;
            Linea1.Grupos = GruposCN.Listar(163);
            Linea1.Id_Subgrupo = 109;
            Linea1.Subgrupos =  SubGruposCN.Listar(109);
            Linea1.Id_TipoCoste = Obr.Grupos_Rel.Where(p => p.Cod_Sigrid == Linea1.Subcapitulo).Count() > 0 ? Obr.Grupos_Rel.Where(p => p.Cod_Sigrid == Linea1.Subcapitulo).ToList()[0].Grupos.Id_TipoCoste : -1;
            Linea1.Nombre = "ACOPIOS";
            Linea1.Medidas = 1;
            Linea1.Unidad_Medida = "";
            Linea1.Importe = 0;
            //los que valen
            Linea1.Importe_P_venta = 0;
            Linea1.Importe_presu = 0;
            Linea1.Importe_VentaPrevista = 0;
            Linea1.Importe_CostePrevisto = 0;
            Linea1.Importe_Certificado = 0;
            Linea1.Importe_Facturado = 0;// Obr.Facturas_ca.Sum(p => p.Facturas_li.Where(a => a.Id_grupo == Linea1.Id_Grupo).Sum(a => a.Base));
            Linea1.Importe_Albaranes = 0;// Obr.Albaranes_ca.Sum(p => p.Albaran_li.Where(a => a.Id_grupo == Linea1.Id_Grupo).Sum(a => a.Base));
            Linea1.Importe_ManoObra = 0;// Obr.ParteTrabajo.Where(a => a.Id_Grupo == Linea1.Id_Grupo).Sum(p => p.TotalImporte);
            Linea1.Importe_CosteReal = 0;// Linea1.Importe_Facturado + Linea1.Importe_Albaranes + Linea1.Importe_ManoObra;
            Linea1.Mano_Obra = (Linea1.Capitulo.Substring(0, 2) == "MO" && Linea1.Capitulo.Substring(0, 3) !=  "MOD") ? true : false;

            //  Linea1.Importe_CosteReal_venta = (Linea1.Importe_CosteReal > 0) ? Linea1.Importe_CosteReal * Convert.ToDecimal(1.25) : 0;
            Linea1.Fecha_importado = DateTime.Today;
            return Linea1;
        }
        public  static Obras_Lineas agregarlinea(Obras Obr, Partida Part, List<Partida> Pars)
        {
            Obras_Lineas Linea1 = new Obras_Lineas();
            Linea1.Id_linea = Part.Ide;
            Linea1.Id_Obra = Obr.Id_Obra;
            Linea1.Id_ObraSigrid = Obr.Id_Sigrid;
            Linea1.Id_Empresa = Obr.Id_Empresa;
            Linea1.Id_Estado = 0;
            Linea1.Id_Fase = Part.Fas ;
            Linea1.Capitulo = Part.Cod.PadLeft(2, Convert.ToChar("0"));
            Linea1.Subcapitulo = Part.Cod;
            Linea1.Id_Grupo = Obr.Grupos_Rel.Where(p => p.Cod_Sigrid == Linea1.Subcapitulo).Count() > 0 ? Obr.Grupos_Rel.Where(p => p.Cod_Sigrid == Linea1.Subcapitulo).ToList()[0].Id_Grupo : 163;
            Linea1.Grupos = Obr.Grupos_Rel.Where(p => p.Cod_Sigrid == Linea1.Subcapitulo).Count() > 0 ? GruposCN.Listar(Obr.Grupos_Rel.Where(p => p.Cod_Sigrid == Linea1.Subcapitulo).ToList()[0].Id_Grupo) : GruposCN.Listar(163);
            Linea1.Id_Subgrupo = Obr.Grupos_Rel.Where(p => p.Cod_Sigrid == Linea1.Subcapitulo).Count() > 0 ? Obr.Grupos_Rel.Where(p => p.Cod_Sigrid == Linea1.Subcapitulo).ToList()[0].Id_Subgrupo : 109;
            Linea1.Subgrupos = Obr.Grupos_Rel.Where(p => p.Cod_Sigrid == Linea1.Subcapitulo).Count() > 0 ? SubGruposCN.Listar(Obr.Grupos_Rel.Where(p => p.Cod_Sigrid == Linea1.Subcapitulo).ToList()[0].Id_Subgrupo) : SubGruposCN.Listar(109);
            Linea1.Id_TipoCoste = (Part.Tipo +1) * -1; //Obr.Grupos_Rel.Where(p => p.Cod_Sigrid == Linea1.Subcapitulo).Count() > 0 ? Obr.Grupos_Rel.Where(p => p.Cod_Sigrid == Linea1.Subcapitulo).ToList()[0].Grupos.Id_TipoCoste : -1;
            Linea1.Nombre = Part.Nombre;
            Linea1.Medidas = Part.Can_Coste != 0 ? Part.Can_Coste : 1 ;
            Linea1.Unidad_Medida = "" ;
            Linea1.Importe = Convert.ToDecimal(Part.Imp_Presupuestado);
            //los que valen
            Linea1.Importe_presu = Convert.ToDecimal(Pars.Where(p => p.Ide == Part.Ide).Count()) > 0 ? Convert.ToDecimal(Pars.Where(p => p.Ide == Part.Ide).OrderByDescending(p => p.Fas).ToList()[0].Imp_Presupuestado) : 0;
            Linea1.Importe_P_venta = Convert.ToDecimal(Pars.Where(p => p.Ide == Part.Ide).Count()) > 0 ? Convert.ToDecimal(Pars.Where(p => p.Ide == Part.Ide).OrderByDescending(p => p.Fas).ToList()[0].Imp_Oferta) : 0; //Convert.ToDecimal(Part.Imp_Oferta);    
            Linea1.Importe_VentaPrevista  = Convert.ToDecimal(Part.Imp_Venta);
            Linea1.Importe_CostePrevisto  = Convert.ToDecimal(Part.Imp_Coste);
            if(Part.Fas ==0 ) Linea1.Importe_Certificado = Convert.ToDecimal(Pars.Where(p => p.Fas != 0).Where(p => p.Ide == Part.Ide).Count()) > 0 ? Convert.ToDecimal(Pars.Where(p => p.Fas != 0).Where(p => p.Ide == Part.Ide).OrderByDescending(p => p.Fas).ToList()[0].Imp_Venta) : 0;
            if (Part.Fas != 0) Linea1.Importe_Certificado = Convert.ToDecimal(Part.Imp_Venta) - Convert.ToDecimal(Pars.Where(p => p.Fas == Part.Fas - 1).Where(p=> p.Fas != 0).Where(p => p.Ide == Part.Ide).Sum(p=> p.Imp_Venta));
            Linea1.Importe_Facturado = 0;// Obr.Facturas_ca.Sum(p => p.Facturas_li.Where(a => a.Cap_sigrid == Linea1.Capitulo).Sum(a => a.Base));
            Linea1.Importe_Albaranes = 0; //= Obr.Albaranes_ca.Sum(p => p.Albaran_li.Where(a => a.Cap_sigrid.Trim() == Linea1.Capitulo.Trim() ).Sum(a => a.Base));
            Linea1.Importe_ManoObra = 0;// Obr.ParteTrabajo.Where(a => a.Cap_Sigrid == Linea1.Capitulo).Sum(p => p.TotalImporte);           
            Linea1.Importe_CosteReal = 0;// Linea1.Importe_Facturado + Linea1.Importe_Albaranes + Linea1.Importe_ManoObra;
            Linea1.Mano_Obra = (Linea1.Capitulo.Substring(0, 2) == "MO") ? true : false ; 

          //  Linea1.Importe_CosteReal_venta = (Linea1.Importe_CosteReal > 0) ? Linea1.Importe_CosteReal * Convert.ToDecimal(1.25) : 0;
            Linea1.Fecha_importado = DateTime.Today;
            return Linea1;
        }

        public static void ImportesFactus(Obras Obr)
        {
            var l = Obr.Facturas_ca.SelectMany(p => p.Facturas_li).ToList();
            foreach (Facturas_li Facli in l)
            {
                if (Obr.Obras_Lineas.Where(p => p.Capitulo.Trim() == Facli.Cap_sigrid.Trim()).Count() > 0)
                {
                    Obr.Obras_Lineas.Where(p => p.Capitulo.Trim() == Facli.Cap_sigrid.Trim()).ToList()[0].Importe_Facturado += Facli.Base;
                }
                else
                {
                    Obr.Obras_Lineas.Where(p => p.Capitulo.Trim() == "ACOPIO").ToList()[0].Importe_Facturado += Facli.Base;
                }
                    
            }
            foreach (Albaran_li Albli in Obr.Albaranes_ca.SelectMany(p => p.Albaran_li).ToList())
            {
                if (Obr.Obras_Lineas.Where(p => p.Capitulo.Trim() == Albli.Cap_sigrid.Trim()).Count() > 0)
                {
                    Obr.Obras_Lineas.Where(p => p.Capitulo.Trim() == Albli.Cap_sigrid.Trim()).ToList()[0].Importe_Albaranes += Albli.Base;
                }
                else
                {
                    Obr.Obras_Lineas.Where(p => p.Capitulo.Trim() == "ACOPIO").ToList()[0].Importe_Albaranes += Albli.Base;
                }

               
            }
            foreach (ParteTrabajo Parte in Obr.ParteTrabajo.ToList())
            {
                if (Obr.Obras_Lineas.Where(p => p.Capitulo.Trim() == Parte.Cap_Sigrid.Trim()).Count() > 0)
                {
                    Obr.Obras_Lineas.Where(p => p.Capitulo.Trim() == Parte.Cap_Sigrid.Trim()).ToList()[0].Importe_ManoObra += Parte.TotalImporte;
                }
                else {
                    Obr.Obras_Lineas.Where(p => p.Capitulo.Trim() == "ACOPIO").ToList()[0].Importe_ManoObra += Parte.TotalImporte;
                }
                   
            }
            foreach (Obras_Lineas lin in Obr.Obras_Lineas)
            {
                lin.Importe_CosteReal = lin.Importe_Facturado + lin.Importe_Albaranes + lin.Importe_ManoObra;
            }
        }
    }
    
}
