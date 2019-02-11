using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio;
using Entidad;
using System.ComponentModel.DataAnnotations;

namespace GestionConstructora
{
    public partial class Form_Obras2 : Form
    {
        int i = -1;
        int estado = 0;
        string Tipo = "Propia";
        Empresas Emp = new Empresas();
        public Form_Obras2(Empresas Empresa)
        {
            Emp = Empresa;
            InitializeComponent();
            DiseñoGrid();
            CargaPanel();
            pdatos.Visible = false;
        }
        #region BOTONES 


        private List<ValidationResult> Añadir()
        {
            Obras Obr = new Obras();
            Obr = ObraCN.Añadir(Convert.ToInt32(txtidobra.Text), Emp.Id_Empresa, txtnombre.Text, Tipo, Convert.ToDouble(txtm_construido.Text), Convert.ToInt32(txt_idsigrid.Text));
            return Obr.ValidationErrors;

        }
        private List<ValidationResult> Modifica()
        {
            Obras Obr = new Obras();
            Obr = ObraCN.Modificar(i, Emp.Id_Empresa, txtnombre.Text, Tipo, Convert.ToDouble(txtm_construido.Text), Convert.ToInt32(txt_idsigrid.Text));
            return Obr.ValidationErrors;
        }
        private void bttnuevo_Click(object sender, EventArgs e)
        {
            estado = 1;
            Pepara_Panel(pdatos, llegenda, true, "Nueva Obra", true);
        }

        private void btteditar_Click(object sender, EventArgs e)
        {

            estado = 2;
            Pepara_Panel(pdatos, llegenda, true, "Modifica Obra", true);
            CargaPanel(ObraCN.Listar(i, Emp.Id_Empresa));

        }
        private void bttborrar_Click(object sender, EventArgs e)
        {
            estado = 0;
            ObraCN.Borrar(i);
            CargaPanel();
        }
        #endregion

        #region EVENTOS
        private void dgobras_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridView grid = (DataGridView)sender;
            SortOrder so = SortOrder.None;
            if (grid.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None ||
                grid.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Ascending)
            {
                so = SortOrder.Descending;
            }
            else
            {
                so = SortOrder.Ascending;
            }
            //set SortGlyphDirection after databinding otherwise will always be none 
            grid.DataSource = ObraCN.Sort(grid.Columns[e.ColumnIndex].Name, so.ToString(), (List<Obras>)grid.DataSource);
            grid.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = so;

        }
        private void dgempresas_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            i = Convert.ToInt32(dgobras.Rows[e.RowIndex].Cells["Id_Obra"].Value);
        }
        #endregion

        #region PROCEDIMIENTOS
        public void DiseñoGrid()
        {
            dgobras.AutoGenerateColumns = false;
            dgobras.EnableHeadersVisualStyles = false;
            dgobras.ColumnHeadersDefaultCellStyle.BackColor = Color.AliceBlue;
            dgobras.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgobras.ColumnHeadersDefaultCellStyle.Font = new Font(FontFamily.GenericSansSerif, 9.0F, FontStyle.Bold);
            foreach (DataGridViewColumn col in dgobras.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.Programmatic;
            }
        }

        public void CargaPanel()
        {
            Emp = EmpresasCN.Listar(Emp.Id_Empresa);
            txtnombre.Text = string.Empty;
            if (Emp.Obras.Count  == 0) return;
            if (Emp.Obras.OrderBy(p => p.Id_Obra).ThenByDescending(p => p.Id_Obra).Select(p => p.Id_Obra).ToList()[0] > 0)
            {
                txtidobra.Text = Convert.ToString(-1);
            }
            else
            {
                txtidobra.Text = Convert.ToString(Emp.Obras.OrderBy(p => p.Id_Obra).ThenByDescending(p => p.Id_Obra).Select(p => p.Id_Obra).ToList()[0] - 1);
            }

            txt_idsigrid.Text = "0";
            txtm_construido.Text = "0";
            rbestudio.Checked = true;
            dgobras.DataSource = Emp.Obras.ToList();

            //Colores
            txtnombre.BackColor = Color.Ivory;
            txtidobra.BackColor = Color.Ivory;
            txtm_construido.BackColor = Color.Ivory;
            txt_idsigrid.BackColor = Color.Ivory;

            // Enable
            txtnombre.ReadOnly = false;
            txtidobra.ReadOnly = false;


        }
        public void CargaPanel(Obras Obr)
        {
            txtnombre.Text = Obr.Nombre;
            txtidobra.Text = Convert.ToString(Obr.Id_Obra);
            txt_idsigrid.Text = Convert.ToString(Obr.Id_Sigrid);
            txtm_construido.Text = Convert.ToString(Obr.Construido);

            if (Obr.Finalizada)
            { rbfinalizada.Checked = true; }
            else
            { rbejecucion.Checked = true; }
            if (Obr.Id_Obra < 0)
            {
                rbestudio.Checked = true;
            }
             //Colores
            txtnombre.BackColor = Color.Ivory;
            txt_idsigrid.BackColor = Color.Ivory;
            txtm_construido.BackColor = Color.Ivory;

            txtidobra.BackColor = Color.AliceBlue;

            // Enable
            txtnombre.ReadOnly = false;
            txtidobra.ReadOnly = true;

        }

        public void Pepara_Panel(Panel p, Label l, bool visible, string legenda, bool agrega)
        {
            p.Visible = visible;
            l.Text = legenda;
            if (agrega == true)
            {
                dgobras.ReadOnly = true;
                pbotones.Enabled = false;
            }
            else
            {
                dgobras.ReadOnly = false;
                pbotones.Enabled = true;

            }
        }


        #endregion

        private void bttgrupos_rel_Click(object sender, EventArgs e)
        {
           
        }

        private void Rbingresos_CheckedChanged(object sender, EventArgs e)
        {
            Tipo = "Propia";
        }

        private void rbgastos_CheckedChanged(object sender, EventArgs e)
        {
            Tipo = "Ajena";
        }

        private void txtm_construido_Validated(object sender, EventArgs e)
        {
            int number;
            if (Int32.TryParse(txtm_construido.Text, out number) == false)
            {
                txtm_construido.Text = "0";
            }

        }

        private void pbotones_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bttañadir_Click_1(object sender, EventArgs e)
        {
          
            List<ValidationResult> Errores = (estado == 1) ? Añadir() : Modifica();

            if (Errores.Count == 0)
            {
                Pepara_Panel(pdatos, llegenda, false, "", false);
                CargaPanel();
            }
            else
            {
                foreach (ValidationResult r in Errores)
                {
                    MessageBox.Show(r.ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            Cambiarestado();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        public void Cambiarestado()
        {
            if ((i < 0) && (rbfinalizada.Checked || rbejecucion.Checked))
            {
                MessageBox.Show("No puede pasar la Obra a Finalizada o Ejecucion, pongans en contacto con el Administrador");
                return;
            }

            if ((rbfinalizada.Checked) ||(rbejecucion.Checked))
            {
                ObraCN.ModificarEstado(i,Emp.Id_Empresa, rbfinalizada.Checked);
            }           
        }

        private void bttgruposrel_Click(object sender, EventArgs e)
        {
            Form_Grupos_Rel f = new Form_Grupos_Rel(i, Emp.Id_Empresa);
            f.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form_Obrasmetros f = new Form_Obrasmetros();
            f.ShowDialog();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ListaObras f = new ListaObras();
           // f.MdiParent = this;
            f.ShowDialog();
         //  f.FormClosed += new FormClosedEventHandler(f_FormClosed);
        }
    }
}
