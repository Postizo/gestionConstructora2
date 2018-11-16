using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidad;

namespace GestionConstructora
{
    public partial class Form_PartidasFactu : Form
    {
        List<Obras_Lineas> Partidas;
        List<FacturasDetalles> Facturas;
        List<FacturasDetalles> Albaranes;
        List<FacturasDetalles> Partetrabajo;
        int fase;

        Obras OBR = new Obras();
        public Form_PartidasFactu(Obras obr, int id_grupo, int? id_subgrupo,int fas)
        {
            InitializeComponent();
            if (id_subgrupo != null)
            {
                OBR = obr;
                fase = fas;
                Partidas = OBR.Obras_Lineas.Where(p=> p.Id_Fase == fase).Where(p => p.Id_Grupo == id_grupo).Where(p => p.Id_Subgrupo == id_subgrupo).ToList();
                Publico.CargaTree(OBR, treepartida, imageList1, 0, true, false, false, true, Partidas,fase);
                rbpresuactual.Checked = true;
            }
        }

        //public List<FacturasDetalles> DevuelveFactuli(Obras Obr, string codpartida)
        //{
        //    List<FacturasDetalles> Li = new List<FacturasDetalles>();

        //    foreach (Facturas_ca Fac in Obr.Facturas_ca.ToList())
        //    {
        //        if (Fac.Facturas_li.Where(p => p.Cap_sigrid == codpartida).Count() > 0)
        //        {
        //            foreach (Facturas_li linea in Fac.Facturas_li.Where(p => p.Cap_sigrid == codpartida))
        //            {
        //                FacturasDetalles i = Fac.Facturas_li.Select(g => new FacturasDetalles
        //                {
        //                    Fecha = Fac.Fecha,
        //                    Factura = Fac.Ref_Fac,
        //                    Proveedor = Fac.Proveedor,
        //                    Descripcion = linea.Descripcion,
        //                    Precio = linea.Pre,
        //                    Cantidad = linea.Cantidad,
        //                    Importe = linea.Base,
        //                    Cap_Sigrid = linea.Cap_sigrid
        //                }).ToList()[0];
        //                Li.Add(i);
        //            }
        //        }
        //    }
        //    return Li.ToList();
        //}
        //public List<FacturasDetalles> DevuelveAlbaranes(Obras Obr, string codpartida)
        //{
        //    List<FacturasDetalles> Li = new List<FacturasDetalles>();

        //    foreach (Albaranes_ca Alb in Obr.Albaranes_ca.ToList())
        //    {
        //        if (Alb.Albaran_li.Where(p => p.Cap_sigrid == codpartida).Count() > 0)
        //        {
        //            foreach (Albaran_li linea in Alb.Albaran_li.Where(p => p.Cap_sigrid == codpartida))
        //            {
        //                FacturasDetalles i = Alb.Albaran_li.Select(g => new FacturasDetalles
        //                {
        //                    Fecha = Alb.Fecha,
        //                    Factura = Alb.Ref_Alb,
        //                    Proveedor = Alb.Proveedor,
        //                    Descripcion = linea.Descripcion,
        //                    Precio = linea.Pre,
        //                    Cantidad = linea.Cantidad,
        //                    Importe = linea.Base,
        //                    Cap_Sigrid = linea.Cap_sigrid
        //                }).ToList()[0];
        //                Li.Add(i);
        //            }
        //        }
        //    }
        //    return Li.ToList();
        //}
        //public List<FacturasDetalles> DevuelveParteTrabajo(Obras Obr, string codpartida)
        //{
        //    List<FacturasDetalles> Li = new List<FacturasDetalles>();
        //    foreach (ParteTrabajo  linea in Obr.ParteTrabajo.Where(p => p.Cap_Sigrid == codpartida))
        //    {
        //        FacturasDetalles i = Obr.ParteTrabajo.Select(g => new FacturasDetalles
        //        {
        //            Fecha = linea.fecha,
        //            Factura = linea.Ref_Parte,
        //            Proveedor = linea.Empleado,
        //            Descripcion = "",
        //            Precio = linea.Precio,
        //            Cantidad = Convert.ToInt32(linea.Horas),
        //            Importe = linea.TotalImporte,
        //            Cap_Sigrid = linea.Cap_Sigrid
        //        }).ToList()[0];
        //        Li.Add(i);
        //    }
  
        //    return Li.ToList();
        //}
    public static void AddColumnsNode(Ai.Control.TreeNode tn, Ai.Control.MultiColumnTree Multicolumn, Obras_Lineas lin, ImageList img, decimal suma)
    {
        Publico.Elige_Icono(11, tn, img);
        tn.UseNodeStyleForSubItems = false;

        for (int i = 0; i < Multicolumn.Columns.Count; i++)
        {
            switch (Multicolumn.Columns[i].Name)
            {

                case "Nombre":
                    tn.SubItems.Add(lin.Nombre);
                    break;
                case "Presupuestado":
                    tn.SubItems.Add(lin.Importe);
                    break;
                case "Gastado":
                    tn.SubItems.Add(Math.Round(suma, 0));
                    break;
                case "Coste_Real":
                    tn.SubItems.Add(lin.Importe_CosteReal);
                    break;
                case "Imp_Certifi":
                    tn.SubItems.Add(lin.Importe_Certificado);
                    break;
                case "Presu_Venta":
                    tn.SubItems.Add(lin.Importe_P_venta);
                    break;
                case "%Realizado":
                    if (lin.Importe_P_venta != 0) { tn.SubItems.Add(lin.Importe_Certificado / lin.Importe_P_venta); } else { tn.SubItems.Add(0); };
                    break;
                //case "%Venta":
                //    if (lin.Importe_P_venta != 0) { tn.SubItems.Add(lin.Importe_CosteReal_venta / lin.Importe_P_venta); } else { tn.SubItems.Add(0); };
                //    break;
                case "%Incurrido":
                    if (lin.Importe_presu != 0) { tn.SubItems.Add(lin.Importe_Facturado / lin.Importe_presu); } else { tn.SubItems.Add(0); };
                    break;
                case "%CosteReal":
                    if (lin.Importe_presu != 0) { tn.SubItems.Add(lin.Importe_CosteReal / lin.Importe_presu); } else { tn.SubItems.Add(0); };
                    break;
                case "IsFactu":
                    tn.SubItems.Add(0);
                    break;
                default:
                    break;
            }
        }
    }
    private void rbcostereal_CheckedChanged(object sender, EventArgs e)
    {

    }

    private void rbincurrido_CheckedChanged(object sender, EventArgs e)
    {

    }

    private void button1_Click(object sender, EventArgs e)
    {
        if (treepartida.SelectedNode == null) return;
        string Capitulo = treepartida.SelectedNode.SubItems[Publico.Busca("Codigo", treepartida)].Value.ToString();
        Facturas = Publico.DevuelveFactuli(OBR,0,Capitulo,0,0);
        Albaranes = Publico.DevuelveAlbaranes(OBR,0, Capitulo, 0, 0);
        Partetrabajo = Publico.DevuelveParteTrabajo(OBR, 0, Capitulo, 0, 0);

        Form_PartidasFactu_Det f = new Form_PartidasFactu_Det(Facturas, Albaranes, Partetrabajo,OBR.Obras_Lineas.Where(p=> p.Id_Fase == fase).Where(p=> p.Capitulo == Capitulo).ToList());
        f.ShowDialog();

    }

    private void rbpresuactual_CheckedChanged(object sender, EventArgs e)
    {
        treepartida.Columns[Publico.Busca("Presupuestado", treepartida)].Visible = false;
        treepartida.Columns[Publico.Busca("%Presupuesto", treepartida)].Visible = false;
        treepartida.Columns[Publico.Busca("Presu_Venta", treepartida)].Visible = false;
        treepartida.Columns[Publico.Busca("%Presu_Venta", treepartida)].Visible = false;

        treepartida.Columns[Publico.Busca("CostePrevisto", treepartida)].Visible = true;
        treepartida.Columns[Publico.Busca("%Costeprevisto", treepartida)].Visible = true;
        treepartida.Columns[Publico.Busca("VentaPrevista", treepartida)].Visible = true;
        treepartida.Columns[Publico.Busca("%Ventaprevista", treepartida)].Visible = true;
    }

    private void rbpresuoriginal_CheckedChanged(object sender, EventArgs e)
    {
        treepartida.Columns[Publico.Busca("Presupuestado", treepartida)].Visible = true;
        treepartida.Columns[Publico.Busca("%Presupuesto", treepartida)].Visible = true;
        treepartida.Columns[Publico.Busca("Presu_Venta", treepartida)].Visible = true;
        treepartida.Columns[Publico.Busca("%Presu_Venta", treepartida)].Visible = true;

        treepartida.Columns[Publico.Busca("CostePrevisto", treepartida)].Visible = false;
        treepartida.Columns[Publico.Busca("%Costeprevisto", treepartida)].Visible = false;
        treepartida.Columns[Publico.Busca("VentaPrevista", treepartida)].Visible = false;
        treepartida.Columns[Publico.Busca("%Ventaprevista", treepartida)].Visible = false;
    }
}
}
