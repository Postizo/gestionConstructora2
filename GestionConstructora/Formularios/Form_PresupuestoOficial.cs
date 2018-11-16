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
using Negocio.Presupuestos;
using System.Reflection;
using System.Globalization;

namespace GestionConstructora
{
    public partial class Form_PresupuestoOficial : Form
    {
        Obras Obr;
        DataTable Dt = new DataTable (); 
        decimal TotalMateriales = 0;        
        Decimal Forma;


        public Form_PresupuestoOficial(Obras obr)
        {
            Obr = obr;
            InitializeComponent();          
            Diseño_form();              

        }

        private void Form_Presupuesto_Load(object sender, EventArgs e)
        {      
            CargaIni();
            Dgresumen.ClearSelection();
        }
        public void CargaIni()
        {
            linfo.Text = "PRESUPUESTO " + Obr.Nombre ;
            //
            txtCtHora.Text = "0";
            txtNpersonas.Text = "0";
            txthorasdias.Text = "0";
            txtndias.Text = "0";
            txttotalmanoobra.Text = "0";
            txtmargenmateriales.Text = "45";
            txtgastosgenerales.Text = "13";
            txtbeneficio.Text = "6";                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       
                                
            PreparaTabla();
           
            CargarTabla();
           
        }

        public void Diseño_form()
        {
           
            Dgresumen.AutoGenerateColumns = false;
            Dgresumen.EnableHeadersVisualStyles = false;
            Dgresumen.ColumnHeadersDefaultCellStyle.BackColor = Color.WhiteSmoke;
            Dgresumen.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            Dgresumen.ColumnHeadersDefaultCellStyle.Font = new Font(FontFamily.GenericSansSerif, 9.0F, FontStyle.Bold);

        }       
       
    

        private void button4_Click(object sender, EventArgs e)
        {

        }

      
        public void PreparaTabla()
        {
            Dt.Columns.Add("Concepto");
            Dt.Columns.Add("Importe", Type.GetType("System.Double"));
        }
        private void CargarTabla()
        {
            decimal Mano_Obra,M_Materiales,G_Generales,Beneficio;
            Mano_Obra = Obr.Obras_Lineas.Where(p => p.Mano_Obra == true).Sum(p => p.Importe_presu);
            TotalMateriales = Obr.Obras_Lineas.Where(p => p.Mano_Obra == false).Sum(p => p.Importe_presu);
            M_Materiales = (TotalMateriales * Convert.ToDecimal(txtmargenmateriales.Text)) / 100;
            G_Generales = (TotalMateriales * Convert.ToDecimal(txtgastosgenerales.Text)) / 100;
            Beneficio = ((TotalMateriales + G_Generales + Mano_Obra) * Convert.ToDecimal(txtbeneficio.Text)) / 100;

            Dt.Rows.Clear();
            DataRow dr = Dt.NewRow();
            dr["Concepto"] = "MATERIALES";
            dr["Importe"] = TotalMateriales;
            Dt.Rows.Add(dr);
            dr = Dt.NewRow();
            dr["Concepto"] = "MANO DE OBRA";
            dr["Importe"] = Mano_Obra;
            Dt.Rows.Add(dr);
            dr = Dt.NewRow();
            dr["Concepto"] = "MARGEN MATERIALES";
            dr["Importe"] = M_Materiales;
            Dt.Rows.Add(dr);
            dr = Dt.NewRow();
            dr["Concepto"] = "GASTOS GENERALES";
            dr["Importe"] = G_Generales;
            Dt.Rows.Add(dr);
            dr = Dt.NewRow();
            dr["Concepto"] = "BENEFICIO";
            dr["Importe"] = Beneficio;
            Dt.Rows.Add(dr);
            dr = Dt.NewRow();
            dr["Concepto"] = "TOTAL";
            dr["Importe"] = TotalMateriales + Mano_Obra + M_Materiales + G_Generales + Beneficio;
            Dt.Rows.Add(dr);
            Dgresumen.DataSource = Dt;
            Form_Caja.Grid_Diseño(Dgresumen, this.Font);
            Dgresumen.ClearSelection();

        }

       
        private void txtCtHora_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txttotalmanoobra.Text = Math.Round((Convert.ToDecimal(txtCtHora.Text) * Convert.ToDecimal(txtNpersonas.Text) * Convert.ToDecimal(txthorasdias.Text) * Convert.ToDecimal(txtndias.Text)), 2).ToString();
            }
            catch (Exception)
            {

               
            }    

           
        }

       private void txtimporte_Validated(object sender, EventArgs e)
        {
            TextBox campo;
            try
            {
                campo = (TextBox)sender;
                Forma = Convert.ToDecimal(campo.Text, CultureInfo.CreateSpecificCulture("es-ES"));
                campo.Text = Forma.ToString("N2");
            }
            catch (Exception ex)
            {
            }
        }
        private void ReplacePunto(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(46))  e.KeyChar = (char)(44);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CargarTabla();
        }
    }
}
