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
using System.ComponentModel.DataAnnotations;

namespace GestionConstructora
{
    public partial class Form_SubGrupos : Form
    {
        int i = 0;
        int estado = 0;
        public Form_SubGrupos()
        {
            InitializeComponent();
            DiseñoGrid();
            CargaPanel();
            pdatos.Visible = false;
        }

        #region BOTONES   
        private void bttAñadir_Click(object sender, EventArgs e)
        {
            List<ValidationResult> Errores = (estado == 1) ? Añadir() : Modifica();
            if (Errores.Count == 0)
            {
               // Pepara_Panel(pdatos, llegenda, false, "", false);
                CargaPanel();
            }
            else
            {
                foreach (ValidationResult r in Errores)
                {
                    MessageBox.Show(r.ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
         private List<ValidationResult> Añadir()
        {
            Subgrupos Subg = new Subgrupos();
         //   Subg = SubGruposCN.Añadir(txtnombre.Text, Convert.ToInt32(cbgrupo.SelectedValue));
            return Subg.ValidationErrors;

        }
        private List<ValidationResult> Modifica()
        {
            Subgrupos Subg = new Subgrupos();
          //  Subg = SubGruposCN.Modificar(i, txtnombre.Text, Convert.ToInt32(cbgrupo.SelectedValue));
            return Subg.ValidationErrors;
              
        }
        private void bttnuevo_Click(object sender, EventArgs e)
        {
            estado = 1;
         //   Pepara_Panel(pdatos, llegenda, true, "Nuevo SubGrupo",true);
        }

        private void btteditar_Click(object sender, EventArgs e)
        {
            estado = 2;
         //   Pepara_Panel(pdatos, llegenda, true, "Modifica SubGrupo",true);
            CargaPanel(SubGruposCN.Listar(i));

        }
        private void bttborrar_Click(object sender, EventArgs e)
        {
            estado = 0;
            SubGruposCN.Borrar(i);
            CargaPanel();

        }
        #endregion

        #region EVENTOS
        private void dgsubgrupos_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
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
            grid.DataSource = SubGruposCN.Sort(grid.Columns[e.ColumnIndex].Name, so.ToString(), (List<Subgrupos>)grid.DataSource);
            grid.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = so;

        }
        private void dgempresas_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            i = Convert.ToInt32(dgsubgrupos.Rows[e.RowIndex].Cells["Id_SubGrupo"].Value);
        }
        #endregion

        #region PROCEDIMIENTOS
        public void DiseñoGrid()
        {
            dgsubgrupos.AutoGenerateColumns = false;
            dgsubgrupos.EnableHeadersVisualStyles = false;
            dgsubgrupos.ColumnHeadersDefaultCellStyle.BackColor = Color.AliceBlue;
            dgsubgrupos.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgsubgrupos.ColumnHeadersDefaultCellStyle.Font = new Font(FontFamily.GenericSansSerif, 9.0F, FontStyle.Bold);
            foreach (DataGridViewColumn col in dgsubgrupos.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.Programmatic;
            }
        }

        public void CargaPanel()
        {
            //txtnombre.Text = string.Empty;
            //cbgrupo.DataSource = GruposCN.Listar_solocontabilidad();
            //cbgrupo.DisplayMember = "Nombre";
            //cbgrupo.ValueMember = "Id_Grupo";
            //dgsubgrupos.DataSource = SubGruposCN.Listar_solocontabilidad();      
            ////Colores
            //txtnombre.BackColor = Color.Ivory;
            //cbgrupo.BackColor = Color.Ivory;
            //// Enable
            //txtnombre.ReadOnly = false;
            //cbgrupo.Enabled = true;
        }
        public void CargaPanel(Subgrupos SubGru)
        {
            //txtnombre.Text = SubGru.Nombre;
            //cbgrupo.DataSource = GruposCN.Listar_solocontabilidad();
            //cbgrupo.DisplayMember = "Nombre";
            //cbgrupo.ValueMember = "Id_Grupo";
            //cbgrupo.SelectedValue = SubGru.Id_Grupo;
            ////Colores
            //txtnombre.BackColor = Color.Ivory;
            //cbgrupo.BackColor = Color.Ivory;
            //// Enable
            //txtnombre.ReadOnly = false;
            //cbgrupo.Enabled = true;
        }

        public void Pepara_Panel(Panel p, Label l, bool visible, string legenda,bool agrega)
        {
            p.Visible = visible;
            l.Text = legenda;
            if (agrega == true)
            {
                dgsubgrupos.ReadOnly = true;
                pbotones.Enabled = false;
            }
            else
            {
                dgsubgrupos.ReadOnly = false;
                pbotones.Enabled = true;

            }
        }


        #endregion
    }
}
