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
using System.Globalization;

namespace GestionConstructora
{
    public partial class Form_PartidasFactu_Det : Form
    {      
        List<FacturasDetalles> Facturas;
        List<FacturasDetalles> Albaranes;
        List<FacturasDetalles> ManoObra;
        List<Obras_Lineas> Obras_Lineas;

        Obras OBR = new Obras();
        DataTable dt = new DataTable();
        public Form_PartidasFactu_Det(List<FacturasDetalles> Li_Facturas, List<FacturasDetalles> Li_Albaranes, List<FacturasDetalles> Li_ManoObra,List<Obras_Lineas> Li_Obraslineas)
        {
            Facturas = Li_Facturas;
            Albaranes = Li_Albaranes;
            ManoObra = Li_ManoObra;
            Obras_Lineas = Li_Obraslineas;
            InitializeComponent();
            RellenaGrid();
            Diseño_form();
            rellenatablacomprobacion();
        }
        public void Diseño_form()
        {
            dgresumen.AutoGenerateColumns = false;
            dgresumen.EnableHeadersVisualStyles = false;
            dgresumen.ColumnHeadersDefaultCellStyle.BackColor = Color.Honeydew;
            dgresumen.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgresumen.ColumnHeadersDefaultCellStyle.Font = new Font(FontFamily.GenericSansSerif, 9.0F, FontStyle.Bold);
        }          

        public void RellenaGrid()
        {
            string specifier;
            CultureInfo culture;
            specifier = "N";
            culture = CultureInfo.CreateSpecificCulture("es-ES");
          
            lbtotalMaterial.Text = Convert.ToDecimal(Facturas.Sum(p => p.Importe) + Albaranes.Sum(p => p.Importe)).ToString(specifier,culture);
            LbManodeObra.Text = Convert.ToDecimal(ManoObra.Sum(p => p.Importe)).ToString(specifier, culture);
            LbTotal.Text = Convert.ToDecimal(Facturas.Sum(p => p.Importe) + Albaranes.Sum(p => p.Importe) + ManoObra.Sum(p => p.Importe)).ToString (specifier, culture);

           //RELLENAMOS EL GRID DE FACTURAS
            Ai.Control.TreeNode tn = new Ai.Control.TreeNode();
            foreach (FacturasDetalles Detallesfac in Facturas)
            {
                tn = new Ai.Control.TreeNode();                
                Publico.Elige_Icono(10, tn,imageList1);
                tn.Text = Detallesfac.Factura;         
                AddColumnsNode(tn, treefac, Detallesfac, imageList1);          
                treefac.Nodes.Add(tn);
            }
            //RELLENAMOS EL GRID DE ALBARANES
            tn = new Ai.Control.TreeNode();
            foreach (FacturasDetalles DetallesAlb in Albaranes)
            {
                tn = new Ai.Control.TreeNode();
                Publico.Elige_Icono(10, tn, imageList1);
                tn.Text = DetallesAlb.Factura;
                AddColumnsNode(tn, treealb, DetallesAlb, imageList1);
                treealb.Nodes.Add(tn);
            }
            //RELLENAMOS EL GRID DE ALBARANES
            tn = new Ai.Control.TreeNode();
            foreach (FacturasDetalles DetallesMO in ManoObra)
            {
                tn = new Ai.Control.TreeNode();
                Publico.Elige_Icono(10, tn, imageList1);
                tn.Text = DetallesMO.Factura;
                AddColumnsNode(tn, treeMO, DetallesMO, imageList1);
                treeMO.Nodes.Add(tn);
            }
        }
        public void rellenatablacomprobacion()
        {
            
            dt.Columns.Add("Concepto");
            dt.Columns.Add("Presupuestado", Type.GetType("System.Double"));
            dt.Columns.Add("Real", Type.GetType("System.Double"));

            DataRow dr = dt.NewRow();
            dr["Concepto"] = "MATERIALES";
            dr["Presupuestado"] = Obras_Lineas.Where(p => p.Mano_Obra == false).Sum(p => p.Importe_CostePrevisto );
            dr["Real"] = Convert.ToDecimal(Facturas.Sum(p => p.Importe) + Albaranes.Sum(p => p.Importe));
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Concepto"] = "MANO DE OBRA";
            dr["Presupuestado"] = Obras_Lineas.Where(p => p.Mano_Obra == true).Sum(p => p.Importe_CostePrevisto);
            dr["Real"] = Convert.ToDecimal(ManoObra.Sum(p => p.Importe));
                   
            dt.Rows.Add(dr);            
            Form_Caja.AgregaTotales(dt, 0);            
            dgresumen.DataSource = dt;           
        }



        public static void AddColumnsNode(Ai.Control.TreeNode tn, Ai.Control.MultiColumnTree Multicolumn, FacturasDetalles factudeta, ImageList img)
        {
            Publico.Elige_Icono(10, tn, img);
            tn.UseNodeStyleForSubItems = false;

            for (int i = 0; i < Multicolumn.Columns.Count; i++)
            {
                switch (Multicolumn.Columns[i].Name)
                {
                   
                    case "Fecha":
                        tn.SubItems.Add(factudeta.Fecha );
                        break;
                    case "Proveedor":
                        tn.SubItems.Add(factudeta.Proveedor );
                        break;
                    case "Descripcion":
                        tn.SubItems.Add(factudeta.Descripcion);
                        break;
                    case "Importe":
                        tn.SubItems.Add(factudeta.Importe);
                        break;
                    default:                 
                        break;
                }
            }
        }

        private void Form_PartidasFactu_Det_Load(object sender, EventArgs e)
        {
            Form_Caja.Grid_Diseño(dgresumen, this.Font);
        }
    }
}
