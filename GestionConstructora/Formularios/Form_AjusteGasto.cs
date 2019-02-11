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
using Negocio;

namespace GestionConstructora
{
    public partial class Form_AjusteGasto : Form
    {
        public Obras Obr { get; set; }
        int id_tipoCoste;
        bool modifica = false;
        Balance_Fijos BalanceBBDD = new Balance_Fijos();
        public Form_AjusteGasto(Obras obr)
        {
            InitializeComponent();
            Obr = obr;
            Diseño_form();
            CargaGrid();
        }
        public void CargaGrid()
        {
            dgingresos.DataSource = Obr.Balance_Fijos.Where(p => p.id_TipoCoste == 1).ToList();
            dggastos.DataSource = Obr.Balance_Fijos.Where(p=> p.id_TipoCoste == 3).ToList();
            dgajustes.DataSource = Obr.Balance_Fijos.Where(p => p.id_TipoCoste == 4).ToList();
            txtvalorventa.Text = Obr.ValorVenta.ToString() ;
            
        }
        public void Diseño_form()
        {
            dgingresos.AutoGenerateColumns = false;
            dgingresos.EnableHeadersVisualStyles = false;
            dgingresos.ColumnHeadersDefaultCellStyle.BackColor = Color.Honeydew;
            dgingresos.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgingresos.ColumnHeadersDefaultCellStyle.Font = new Font(FontFamily.GenericSansSerif, 9.0F, FontStyle.Bold);

            dggastos.AutoGenerateColumns = false;
            dggastos.EnableHeadersVisualStyles = false;
            dggastos.ColumnHeadersDefaultCellStyle.BackColor = Color.Honeydew;
            dggastos.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dggastos.ColumnHeadersDefaultCellStyle.Font = new Font(FontFamily.GenericSansSerif, 9.0F, FontStyle.Bold);

            dgajustes.AutoGenerateColumns = false;
            dgajustes.EnableHeadersVisualStyles = false;
            dgajustes.ColumnHeadersDefaultCellStyle.BackColor = Color.Honeydew;
            dgajustes.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgajustes.ColumnHeadersDefaultCellStyle.Font = new Font(FontFamily.GenericSansSerif, 9.0F, FontStyle.Bold);
        }

        private void button1_Click(object sender, EventArgs e)
        {          
            this.Close();
        }
        private void entrada(object sender, EventArgs e)
        {
            TextBox campo;
            campo = (TextBox)sender;
            if (campo.Text == "0") campo.Text = "";

        }
        private void salida(object sender, EventArgs e)
        {
            TextBox campo;
            campo = (TextBox)sender;
            if (campo.Text == "") campo.Text = "0";

        }

        private void button5_Click(object sender, EventArgs e)
        {
            id_tipoCoste = 1;
            modifica = false;
            CargabalanceFijo(0);
            Cambiarestado();
          
        }

        private void bttnuevogasto_Click(object sender, EventArgs e)
        {
            id_tipoCoste = 3;
            modifica = false;
            CargabalanceFijo(0);
            Cambiarestado();
        }

        private void bttnuevoajuste_Click(object sender, EventArgs e)
        {
            id_tipoCoste = 4;
            modifica = false;
            CargabalanceFijo(0);
            Cambiarestado();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (modifica)
            {
                BalanceCN.EditarFijos(CreaBalanceFijo());
            }
            else
            {
                BalanceCN.AñadirFijos(CreaBalanceFijo());
            }
            Cambiarestado();
            Obr = ObraCN.Listar(Obr.Id_Obra, Obr.Id_Empresa);
            CargaGrid();
        }
        private void CargabalanceFijo(int id_Gasto)
        {
            if (!modifica)
            {
                txtconcepto.Text = "";
                txtctimporte.Text = "0";
                txtaño.Text = "0";
                txtcomentario.Text = "";
            }
            else
            {
                BalanceBBDD = BalanceCN.ListarFijos(id_Gasto);
                id_tipoCoste = BalanceBBDD.id_TipoCoste;
                txtconcepto.Text = BalanceBBDD.Concepto;
                txtctimporte.Text = BalanceBBDD.Importe.ToString();
                txtaño.Text = BalanceBBDD.Año.ToString();
                txtcomentario.Text = BalanceBBDD.Comentario.ToString();
            }
   

        }
        private void BorrarFijo(int id_Gasto)
        {
            BalanceCN.BorrarFijos(id_Gasto);
            Obr = ObraCN.Listar(Obr.Id_Obra, Obr.Id_Empresa);
            CargaGrid();
        }
        private Balance_Fijos CreaBalanceFijo()
        {
            Balance_Fijos BalanceFijo = new Balance_Fijos();
            if (modifica) BalanceFijo.Id_Gasto = BalanceBBDD.Id_Gasto;
            BalanceFijo.Id_empresa = Obr.Id_Empresa;
            BalanceFijo.id_Obra = Obr.Id_Obra;
            BalanceFijo.Concepto = txtconcepto.Text;
            BalanceFijo.id_TipoCoste =id_tipoCoste;
            BalanceFijo.Importe = Convert.ToDecimal(txtctimporte.Text);
            BalanceFijo.Año = Convert.ToInt32(txtaño.Text);
            BalanceFijo.Comentario = txtcomentario.Text;
            return BalanceFijo;
        }
        private void Cambiarestado()
        {
            dgingresos.Enabled = !dgingresos.Enabled;
            dggastos.Enabled = !dggastos.Enabled;
            dgajustes.Enabled = !dgajustes.Enabled;
            bttnuevoajuste.Enabled = !bttnuevoajuste.Enabled;
            bttnuevogasto.Enabled = !bttnuevogasto.Enabled;
            bttnuevoingreso.Enabled = !bttnuevoingreso.Enabled;
            btteditaringresos.Enabled = !btteditaringresos.Enabled;
            btteditargastos.Enabled = !btteditargastos.Enabled;
            btteditarajustes.Enabled = !btteditarajustes.Enabled;
            bttaceptar.Enabled = !bttaceptar.Enabled;
            groupBox1.Visible = !groupBox1.Visible;
            btteliminargasto.Visible = !btteliminargasto.Visible;
            btteliminaringresos.Visible = !btteliminaringresos.Visible;
            bttelimnarajuste.Visible = !bttelimnarajuste.Visible;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dgingresos.SelectedRows.Count <= 0) return;
            modifica = true;
            CargabalanceFijo(Convert.ToInt32(dgingresos.SelectedRows[0].Cells[0].Value));
            Cambiarestado();
            txtconcepto.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dggastos.SelectedRows.Count <= 0) return;
            modifica = true;
            CargabalanceFijo(Convert.ToInt32(dggastos.SelectedRows[0].Cells[0].Value));
            Cambiarestado();
            txtconcepto.Focus();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (dgajustes.SelectedRows.Count <= 0) return;
            modifica = true;
            CargabalanceFijo(Convert.ToInt32(dgajustes.SelectedRows[0].Cells[0].Value));
            Cambiarestado();
            txtconcepto.Focus();
        }

        private void Form_AjusteGasto_Load(object sender, EventArgs e)
        {
            dggastos.ClearSelection();
            dgajustes.ClearSelection();
        }

        private void dgingresos_SelectionChanged(object sender, EventArgs e)
        {
            
        }

        private void dggastos_SelectionChanged(object sender, EventArgs e)
        {
      
        }

        private void dgajustes_SelectionChanged(object sender, EventArgs e)
        {
          
        }

        private void dggastos_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            dgingresos.ClearSelection();
            dgajustes.ClearSelection();
        }

        private void dgingresos_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            dggastos.ClearSelection();
            dgajustes.ClearSelection();
        }

        private void dgajustes_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            dggastos.ClearSelection();
            dgingresos.ClearSelection();
        }

        private void btteliminaringresos_Click(object sender, EventArgs e)
        {
            if (dgingresos.SelectedRows.Count <= 0) return;
            BorrarFijo(Convert.ToInt32(dgingresos.SelectedRows[0].Cells[0].Value));
        }

        private void btteliminargasto_Click(object sender, EventArgs e)
        {
            if (dggastos.SelectedRows.Count <= 0) return;
            BorrarFijo(Convert.ToInt32(dggastos.SelectedRows[0].Cells[0].Value));
        }

        private void bttelimnarajuste_Click(object sender, EventArgs e)
        {

            if (dgajustes.SelectedRows.Count <= 0) return;
            BorrarFijo(Convert.ToInt32(dgajustes.SelectedRows[0].Cells[0].Value));
        }

        private void txtvalorventa_TextChanged(object sender, EventArgs e)
        {
            if (txtvalorventa.Text != "")
            {
                ObraCN.ModificarAjuste(Obr.Id_Obra, Obr.Id_Empresa, 0, "", Convert.ToDecimal(txtvalorventa.Text), 0, 0);
            }
            
        }
    }
}
