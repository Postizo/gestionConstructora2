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
    public partial class Form_Presupuesto : Form
    {
        Presu_Presu_Ca Presu_M;
        DataTable Dt = new DataTable (); 
        decimal TotalMateriales = 0;
        int calidad = 3;
        Decimal Forma;


        public Form_Presupuesto(Presu_Presu_Ca Presu_M_)
        {
            Presu_M = Presu_M_;
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
            linfo.Text = "PRESUPUESTO " + Presu_M.Id_Presu + "." + Presu_M.Nombre + "    Version: " + Presu_M.Id_Version;
            //
            txtCtHora.Text = Presu_M.CteHora.ToString();
            txtNpersonas.Text = Presu_M.nPersonas.ToString();
            txthorasdias.Text = Presu_M.horas_dias.ToString();
            txtndias.Text = Presu_M.ndias.ToString();
            txttotalmanoobra.Text = Presu_M.T_Manoobra.ToString();
            txtmargenmateriales.Text = Presu_M.M_Materias.ToString();
            txtgastosgenerales.Text = Presu_M.G_Generales.ToString();
            txtbeneficio .Text = Presu_M.Beneficio.ToString();
            txtviviendas.Text = Presu_M.U_Casas.ToString();
            cbestancias.DataSource = PresupuestosCN.Listar_Estancias();
            cbestancias.DisplayMember = "Nombre";
            cbestancias.ValueMember = "Id_estancia";
            PreparaTabla();
            CargarEstancias();
            CargarTabla();
           
        }

        public void Diseño_form()
        {
            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic |
            BindingFlags.Instance | BindingFlags.SetProperty, null,
            dglineas, new object[] { true });
            dglineas.AutoGenerateColumns = false;
            dglineas.EnableHeadersVisualStyles = false;
            dglineas.ColumnHeadersDefaultCellStyle.BackColor = Color.WhiteSmoke;
            dglineas.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dglineas.ColumnHeadersDefaultCellStyle.Font = new Font(FontFamily.GenericSansSerif, 9.0F, FontStyle.Bold);
            Dgresumen.AutoGenerateColumns = false;
            Dgresumen.EnableHeadersVisualStyles = false;
            Dgresumen.ColumnHeadersDefaultCellStyle.BackColor = Color.WhiteSmoke;
            Dgresumen.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            Dgresumen.ColumnHeadersDefaultCellStyle.Font = new Font(FontFamily.GenericSansSerif, 9.0F, FontStyle.Bold);

        }       
        private void CargarEstancias()
        {
            dglineas.DataSource = Presu_M.Presu_Presu_li.Select(p => p.Presu_Estancias).ToList();
            cargarArbol();
        }  
       
        private void button1_Click(object sender, EventArgs e)
        {
            PresupuestosCN.AñadirLineas(Presu_M.Id_Presu, Presu_M.Id_Version, Convert.ToInt32(cbestancias.SelectedValue));
            Presu_M = PresupuestosCN.Listar(Presu_M.Id_Presu, Presu_M.Id_Version);
            CargarEstancias();
            CargarTabla();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void cargarArbol()
        {
            TotalMateriales = 0;
            lpresupuest.Items.Clear();
            foreach (Presu_Estancias Estancias in Presu_M.Presu_Presu_li.Select(p => p.Presu_Estancias).ToList())
            {
                TreeListViewItem itemA = new TreeListViewItem(Estancias.Nombre, 0);
                foreach (Presu_Elementos Elementos in Estancias.Presu_Elem_Estan.Select(p=> p.Presu_Elementos).ToList())
                {
                    string Unidades = Elementos.Presu_Elem_Estan.Where(p=> p.Id_estancia == Estancias.Id_Estancia && p.Id_elementos == Elementos.Id_Elemento).ToList()[0].Unidades.ToString() ;
                    TreeListViewItem itemB = new TreeListViewItem(Unidades + "." +  Elementos.Nombre, 2);
                    decimal precio = Math.Round(Elementos.Presu_Calidad.Where(p => p.Tipo_Calidad == calidad).ToList()[0].Precio * Convert.ToUInt32(Unidades),0);

                    itemB.SubItems.Add(precio.ToString());
                    TotalMateriales += precio;
                    itemA.Items.Add(itemB);
                }               
                lpresupuest.Items.Add(itemA);
            }
            TreeListViewItem itemTota = new TreeListViewItem("TOTAL..................................................................................................................", 3);
            itemTota.SubItems.Add(TotalMateriales.ToString());
            lpresupuest.Items.Add(itemTota);
            lpresupuest.ExpandAll();
            TotalMateriales = TotalMateriales * Convert.ToInt32(txtviviendas.Text);
            cbDespeglar.Checked = true;
        }
        public void PreparaTabla()
        {
            Dt.Columns.Add("Concepto");
            Dt.Columns.Add("Importe", Type.GetType("System.Double"));
        }
        private void CargarTabla()
        {
            decimal Mano_Obra,M_Materiales,G_Generales,Beneficio;
            Mano_Obra = Convert.ToDecimal(txttotalmanoobra.Text);
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

        private void button2_Click(object sender, EventArgs e)
        {
            Presu_M.CteHora = Convert.ToDecimal(txtCtHora.Text);
            Presu_M.nPersonas = Convert.ToDecimal(txtNpersonas.Text);
            Presu_M.horas_dias = Convert.ToDecimal(txthorasdias.Text);
            Presu_M.ndias =  Convert.ToDecimal(txtndias.Text);
            Presu_M.T_Manoobra = Convert.ToDecimal(txttotalmanoobra.Text);
            Presu_M.M_Materias = Convert.ToDecimal(txtmargenmateriales.Text);
            Presu_M.G_Generales = Convert.ToDecimal(txtgastosgenerales.Text);
            Presu_M.Beneficio = Convert.ToDecimal(txtbeneficio .Text);
            Presu_M.U_Casas = Convert.ToInt32(txtviviendas.Text);
            

            PresupuestosCN.AñadirPresu_ca(Presu_M);
            cargarArbol();
            CargarTabla();
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

        private void rbalta_CheckedChanged(object sender, EventArgs e)
        {
            if (rbalta.Checked) calidad = 3;
            cargarArbol();
            CargarTabla();

        }

        private void rbmedia_CheckedChanged(object sender, EventArgs e)
        {
            if (rbmedia.Checked) calidad = 2;
            cargarArbol();
            CargarTabla();
        }

        private void rbbaja_CheckedChanged(object sender, EventArgs e)
        {
            if (rbbaja.Checked) calidad = 1;
            cargarArbol();
            CargarTabla();
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

        private void button3_Click(object sender, EventArgs e)
        {
            if (dglineas.CurrentCell == null) return;
            PresupuestosCN.BorrarLinea(Presu_M.Id_Presu, Presu_M.Id_Version,Convert.ToInt32(dglineas["id_estancia", dglineas.CurrentCell.RowIndex].Value));
            Presu_M = PresupuestosCN.Listar(Presu_M.Id_Presu, Presu_M.Id_Version);
            CargarEstancias();
            CargarTabla();
        }

        private void cbDespeglar_CheckedChanged(object sender, EventArgs e)
        {
            if (cbDespeglar.Checked == true) lpresupuest.ExpandAll();
            else
                lpresupuest.CollapseAll();
        }

        private void txtviviendas_TextChanged(object sender, EventArgs e)
        {
            //if (txtviviendas.Text == "") return ;
            //cargarArbol();           
            //CargarTabla();
        }
    }
}
