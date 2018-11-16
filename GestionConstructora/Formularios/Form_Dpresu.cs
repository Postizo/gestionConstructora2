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
    public partial class Form_Dpresu : Form
    {
        List<string> listNew = new List<string>();
        D_Presuca Presu = new D_Presuca();
        List<D_Equipos> Equipos = new List<D_Equipos>();
        int cellcol;
        int cellrow;
        string campo = "alias";

        public Form_Dpresu(D_Presuca presu)
        {
            Presu = presu;
            InitializeComponent();
            ini();
            refresca();
        }
        public void ini()
        {
            cbobra.DataSource = ObraCN.Listar(12);
            cbobra.DisplayMember = "Nombre";
            cbobra.ValueMember = "id_Obra";
            cbobra.SelectedValue = -2;
            cbobra.Text  = "";

            Equipos = DEquiposCN.ListarEquipos();
            if (Presu.Nombre != string.Empty)
            {
                txtcosteprogramador.Text = Presu.CosteProgramador.ToString();
                txtgastosgenerales.Text = (Presu.GG * 100).ToString();
                txtbenef.Text = (Presu.Beneficio * 100).ToString();
                txtmargenmater.Text = (Presu.MargenMat * 100).ToString();
                txtmetrosconstrudios.Text = Presu.m_construdios.ToString();
                cbobra.SelectedValue = Presu.id_Obra;
                if (Presu.id_Obra ==0) cbobra.SelectedValue = -100;
            }

            dglineas.AutoGenerateColumns = false;
            dglineas.EnableHeadersVisualStyles = false;
            dglineas.ColumnHeadersDefaultCellStyle.BackColor = Color.Honeydew;
            dglineas.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dglineas.ColumnHeadersDefaultCellStyle.Font = new Font(FontFamily.GenericSansSerif, 9.0F, FontStyle.Bold);
            linfo.Text = Presu.Nombre.ToUpper() + "  ------    Nº" + Presu.id_presu.ToString();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {          
            DEquiposCN.ModificarPresuGenerales(Presu.id_presu, Convert.ToDecimal(txtcosteprogramador.Text), Convert.ToDecimal(txtgastosgenerales.Text), Convert.ToDecimal(txtbenef.Text), Convert.ToDecimal(txtmargenmater.Text), Convert.ToInt32(txtmetrosconstrudios.Text) ,Convert.ToInt32(cbobra.SelectedValue));
            Presu = DEquiposCN.ListarPresu(Presu.id_presu);
            pparametrosgenarles.Visible = false;
            button4.Enabled = true;
            refresca();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (DEquiposCN.ListarLineas(Presu.id_presu).Count > 0)
            {
                DialogResult result;
                result = MessageBox.Show("El presupuesto ya tiene equipos agregados, si modifica alguno de los parametros generales se recalcura el presupuesto.¿Desea Continuar?", "Alerta", MessageBoxButtons.YesNo);
                if (result == System.Windows.Forms.DialogResult.No)
                {
                    return;
                }
            }
            if (pparametrosgenarles.Visible == false)
            {
                pparametrosgenarles.Visible = true;
                button4.Enabled = false;
            }

        }

        private void toolStripComboBox2_TextUpdate(object sender, EventArgs e)
        {
            try
            {
                string i = this.cbbuscaproduc.Text;
                this.cbbuscaproduc.Items.Clear();
                this.cbbuscaproduc.Items.AddRange(Equipos.Where(p => p.Nombre.ToUpper().Contains(cbbuscaproduc.Text.ToUpper()) || p.Referencia.ToUpper().Contains(cbbuscaproduc.Text.ToUpper())).Select(p => p.Referencia + "  **  " + p.Nombre).ToArray());
              
                Cursor = Cursors.Default;              
                this.cbbuscaproduc.DroppedDown = true;
                this.cbbuscaproduc.Text = i;
                this.cbbuscaproduc.SelectionStart = this.cbbuscaproduc.Text.Length;
            }
            catch (Exception)
            {
            }
        }
        private void toolStripComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            lerror.Text = ".";
            string Referencia;

            try
            {
                Referencia = cbbuscaproduc.Text.Split(new[] { "**" }, StringSplitOptions.None)[0].Trim();
            }
            catch (Exception)
            {
                lerror.Text = "La referencia no es valida";
                return;
            }
            D_Equipos Equipo = DEquiposCN.ListarEquipos(Referencia);
            if (Equipo == null)
            {
                lerror.Text = "No existe esa referencia en la BBDD";
                return;
            }
            if (DEquiposCN.ListarLinea(Presu.id_presu, Referencia) != null)
            {
                lerror.Text = "Ya existe esa referencia en el presupuesto";
                return;
            }

            int Tiempo = (Equipo.T_instalacion + Equipo.T_programacion + Equipo.T_puestamarcha + Equipo.T_volcado);
            decimal costo = Math.Round(Equipo.Pvp * (1 - Equipo.D_provee.descuento), 2);
            DEquiposCN.AñadirLineas(Presu.id_presu, Referencia.Trim(), Equipo.Pvp, Equipo.D_provee.descuento, costo, Tiempo,Equipo.Grupo);
            cbbuscaproduc.Text = "";
            refresca();
        }
        public void refresca()
        {
            
                dglineas.DataSource = null;
                dglineas.DataSource = DEquiposCN.ListarLineas(Presu.id_presu);
           
          
          
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

            DialogResult result;
            result = MessageBox.Show("Va eliminar los productos seleccionados del presupuesto.¿Desea continuar?", "Alerta", MessageBoxButtons.YesNo);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                foreach (DataGridViewRow row in dglineas.SelectedRows)
                {
                    if (dglineas["ref", row.Index].Value.ToString() == "--DISEÑO--") continue;
                    DEquiposCN.BorrarLineas(dglineas["Ref", row.Index].Value.ToString(), Presu.id_presu);
                }
                refresca();
            }


        }

        private void dglineas_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dglineas.Columns[e.ColumnIndex].Name == "Unidades")
            {
                if (dglineas["ref", e.RowIndex].Value == null) return;
                if (dglineas["Unidades", e.RowIndex].Value == null) return;
                DEquiposCN.ModificarUnidades(dglineas["ref", e.RowIndex].Value.ToString(), Convert.ToInt32(dglineas["Unidades", e.RowIndex].Value), Presu.id_presu);
                refresca();
                dglineas.CurrentCell = dglineas[cellcol, cellrow];

            }
            if (dglineas.Columns[e.ColumnIndex].Name == "Grupo")
            {  
                DEquiposCN.Modificargrup(dglineas["ref", e.RowIndex].Value.ToString(), Presu.id_presu ,dglineas["Grupo", e.RowIndex].Value.ToString());
                refresca();
                dglineas.CurrentCell = dglineas[cellcol, cellrow];

            }
            if (dglineas.Columns[e.ColumnIndex].Name == "Coste")
            {
                if (dglineas["ref", e.RowIndex].Value == null) return;
                if (dglineas["ref", e.RowIndex].Value.ToString() != "--DISEÑO--")
                {
                    refresca();
                    dglineas.CurrentCell = dglineas[cellcol, cellrow];
                    return;
                }

                DEquiposCN.ModificarPrecio(dglineas["ref", e.RowIndex].Value.ToString(), Convert.ToDecimal(dglineas["Coste", e.RowIndex].Value), Presu.id_presu);
                refresca();
                dglineas.CurrentCell = dglineas[cellcol, cellrow];
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            List<D_Presuca> Presus = new List<D_Presuca>();
            Presus.Add(Presu);
            R_InformeTecnico f = new R_InformeTecnico(Presus, DEquiposCN.ListarLineas(Presu.id_presu),false);
            f.ShowDialog();

        }

        private void dglineas_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            cellcol = dglineas.CurrentCell.ColumnIndex;
            cellrow = dglineas.CurrentCell.RowIndex;
        }

        private void dglineas_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            string name = null;
            name = dglineas.Columns[e.ColumnIndex].Name;
            if (name == "Coste")
            {
                try
                {
                    // Valor actual de la celda 
                    string value = dglineas.CurrentCell.EditedFormattedValue.ToString();
                    // Reemplazamos el punto por la coma decimal. 
                    value = value.Replace(".", ",");
                    // Escribimos el nuevo valor. 
                    decimal cellValue = Convert.ToDecimal(value);
                    dglineas.CurrentCell.Value = cellValue;
                }
                catch (Exception ex)
                {

                }


            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            List<D_Presuca> Presus = new List<D_Presuca>();
            Presus.Add(Presu);
            R_InformeTecnico f = new R_InformeTecnico(Presus, DEquiposCN.ListarLineas(Presu.id_presu), true);
            f.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<D_Presuli> Presupuesto = DEquiposCN.ListarLineas(Presu.id_presu);
            foreach (D_Presuli Linea in Presupuesto)
            {
                int Tiempo = (Linea.D_Equipos.T_instalacion + Linea.D_Equipos.T_programacion + Linea.D_Equipos.T_puestamarcha + Linea.D_Equipos.T_volcado);
                decimal costo = Math.Round(Linea.D_Equipos.Pvp * (1 - Linea.D_Equipos.D_provee.descuento), 2);
                DEquiposCN.Recalculo(Linea.@ref, Linea.id_presu, Linea.D_Equipos.Pvp, Linea.D_Equipos.D_provee.descuento, costo, Tiempo);
            }
            refresca();
        }

        private void dglineas_CellErrorTextChanged(object sender, DataGridViewCellEventArgs e)
        {
         
        }

        private void dglineas_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<D_Presuca> Presus = new List<D_Presuca>();
            Presus.Add(Presu);
            R_InformePresu f = new R_InformePresu(Presus, DEquiposCN.ListarLineas(Presu.id_presu), true, campo);
            f.ShowDialog();
        }

        private void rbalias_CheckedChanged(object sender, EventArgs e)
        {
            if (rbalias.Checked) campo = "alias";
            if (rbnombre.Checked) campo = "nombre";

        }

        private void rbnombre_CheckedChanged(object sender, EventArgs e)
        {
            if (rbalias.Checked) campo = "alias";
            if (rbnombre.Checked) campo = "nombre";
        }
    }   
}
