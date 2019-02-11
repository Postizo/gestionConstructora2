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
using Negocio.Gestion;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace GestionConstructora
{
    public partial class Form_Grupos : Form
    {
        int id_grupo = 0;
        int id_subgrupo = 0;
        int estado = 0;
        int Id_tipo = 0;
        int Id_tipoCoste = 0;

        string Tipo = "";
        bool visiblesubgrupo = false;
        public Form_Grupos()
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
            if (Errores.Count ==0)
            {
                bttver.Enabled = true;
                visiblesubgrupo = false;
                Pepara_Panel(pdatos, llegenda, false, "", false);
                CargaPanel();
            }
            else
            {
                foreach (ValidationResult r in Errores)
                {
                    MessageBox.Show(r.ErrorMessage,"Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }       
        }
        private List<ValidationResult> Añadir()
        {
            Grupos Gr = new Grupos();
            Gr = GruposCN.Añadir(txtnombre.Text, 0, Id_tipo, Tipo,Id_tipoCoste);
            return Gr.ValidationErrors;

        }
        private List<ValidationResult> Modifica()
        {
            Grupos Gr = new Grupos();
            Gr = GruposCN.Modificar(id_grupo, txtnombre.Text, 0, Id_tipo, Tipo,Id_tipoCoste);     
            return Gr.ValidationErrors;              
        }

        private void bttnuevo_Click(object sender, EventArgs e)
        {
            estado = 1;
            bttver.Visible = false;
            Pepara_Panel(pdatos, llegenda, true, "Nuevo Grupo",true);
        }

        private void btteditar_Click(object sender, EventArgs e)
        {
            estado = 2;
            bttver.Visible = true;
            Pepara_Panel(pdatos, llegenda, true, "Modifica Grupo",true);
            CargaPanel(GruposCN.Listar(id_grupo));
           
        }
        private void bttborrar_Click(object sender, EventArgs e)
        {   
                estado = 0;
                List<ValidationResult> Errores = GruposCN.Borrar(id_grupo).ValidationErrors;
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
        }
        #endregion
        
        #region EVENTOS
        private void dggrupos_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
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
            grid.DataSource = GruposCN.Sort(grid.Columns[e.ColumnIndex].Name, so.ToString(), (List<Grupos>)grid.DataSource);
            grid.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = so;

        }
        private void dgempresas_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            id_grupo = Convert.ToInt32(dggrupos.Rows[e.RowIndex].Cells["Id_Grupos"].Value);
        }
        private void dgsubgrupos_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
          
            id_subgrupo = Convert.ToInt32(dgsubgrupos.Rows[e.RowIndex].Cells["Id_Subgrupos"].Value);
        }
        private void dgsubgrupos_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        #endregion

        #region PROCEDIMIENTOS
        public bool Val(Grupos Gr)
        {
            if (Gr.IsValid)
            {
                
                return true;
            }
            else
            {
                return false;
            }
        }
        public void DiseñoGrid()
        {
            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic |
               BindingFlags.Instance | BindingFlags.SetProperty, null,
               dggrupos, new object[] { true });
            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic |
            BindingFlags.Instance | BindingFlags.SetProperty, null,
            dgsubgrupos, new object[] { true });

            dggrupos.AutoGenerateColumns = false;
            dggrupos.EnableHeadersVisualStyles = false;
            dggrupos.ColumnHeadersDefaultCellStyle.BackColor = Color.AliceBlue;
            dggrupos.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dggrupos.ColumnHeadersDefaultCellStyle.Font = new Font(FontFamily.GenericSansSerif, 9.0F, FontStyle.Bold);
            foreach (DataGridViewColumn col in dggrupos.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.Programmatic;
            }
            dgsubgrupos.AutoGenerateColumns = false;
            dgsubgrupos.EnableHeadersVisualStyles = false;
            dgsubgrupos.ColumnHeadersDefaultCellStyle.BackColor = Color.Thistle;
            dgsubgrupos.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgsubgrupos.ColumnHeadersDefaultCellStyle.Font = new Font(FontFamily.GenericSansSerif, 9.0F, FontStyle.Bold);
            foreach (DataGridViewColumn col in dgsubgrupos.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.Programmatic;
            }
        }

        public void CargaPanel()
        {
            lsubgrupo.Visible = false;
            psubgrupos.Visible = false;
            dgsubgrupos.Visible = false;
            dgsubgrupos.DataSource = SubGruposCN.ListarporGrupo(id_grupo);
     
            txtnombre.Text = string.Empty;
            prbtipos.Visible = true;
            dggrupos.DataSource = GruposCN.Listar_solocontabilidad().Where(p => p.Id_Tipo == 0 || p.Id_Tipo == 1).ToList();

            //Colores
            txtnombre.BackColor = Color.Ivory;
            // Enable
            txtnombre.ReadOnly = false;
           
        }
        public void CargaPanel(Grupos Gru)
        {
            if (visiblesubgrupo == true)
            {
                lsubgrupo.Visible = true;
                psubgrupos.Visible = true;
                dgsubgrupos.Visible = true;
                dgsubgrupos.DataSource = SubGruposCN.ListarporGrupo(id_grupo);
            }                     
            txtnombre.Text = Gru.Nombre;
            Establecervalorcheck(Gru);
            Id_tipo = Gru.Id_Tipo;
            Id_tipoCoste = Gru.Id_TipoCoste;
            Tipo = Gru.Tipo;
            //Colores
            txtnombre.BackColor = Color.Ivory;
            // Enable
            txtnombre.ReadOnly = false;
        }

        public void Pepara_Panel(Panel p, Label l, bool visible, string legenda,bool agrega)
        {
            p.Visible = visible;
            l.Text = legenda;
            if (agrega == true)
            {
                dggrupos.ReadOnly = true;
                pbotones.Enabled = false;
            }
            else
            {
                dggrupos.ReadOnly = false;
                pbotones.Enabled = true;

            }
        }
       
        public void Establecervalorcheck(Grupos Gru)
        {
            switch (Gru.Id_TipoCoste)
            {
                case 1:
                    Rbingresos.Checked = true;
                    break;
                case 2:
                    rbgastocontribuciondirecta.Checked = true;
                    break;
                case 3:
                    rbgastos.Checked = true;

                    break;
                default:
                    break;
            }
            
        }

        #endregion

        private void pcontenedor_Paint(object sender, PaintEventArgs e)
        {

        }
        private void bttAñadirsubgrupo_Click(object sender, EventArgs e)
        {
            List<ValidationResult> Errores = Añadir_subgrupo();
            if (Errores.Count == 0)
            {
                txtsubrgrupo.Text = "";
                //dgsubgrupos.SelectedRows[0].Selected = false;
                Pepara_Panel(pdatos, llegenda, true, "Modifica Grupo", true);
                CargaPanel(GruposCN.Listar(id_grupo));
            }
            else
            {
                foreach (ValidationResult r in Errores)
                {
                    MessageBox.Show(r.ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private List<ValidationResult> Añadir_subgrupo()
        {
            Subgrupos Subg = new Subgrupos();
            Subg = SubGruposCN.Añadir(txtsubrgrupo.Text, id_grupo);
            return Subg.ValidationErrors;

        }

        private List<ValidationResult> Modifica_Subgrupo()
        {
            Subgrupos Subg = new Subgrupos();
            Subg = SubGruposCN.Modificar(id_grupo, txtnombre.Text, id_grupo);
            return Subg.ValidationErrors;
        }

        private void bttborrar_subgrupos(object sender, EventArgs e)
        {
            if (dgsubgrupos.RowCount == 0) return;
            List<ValidationResult> Errores = SubGruposCN.Borrar(id_subgrupo).ValidationErrors;
            if (Errores.Count == 0)
            {
                Pepara_Panel(pdatos, llegenda, true, "Modifica Grupo", true);
                CargaPanel(GruposCN.Listar(id_grupo));
            }
            else
            {
                foreach (ValidationResult r in Errores)
                {
                    MessageBox.Show(r.ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void bttver_subgrupos(object sender, EventArgs e)
        {
            bttver.Enabled = false;
            visiblesubgrupo = true;
            Pepara_Panel(pdatos, llegenda, true, "Modifica Grupo", true);
            CargaPanel(GruposCN.Listar(id_grupo));
        }
             

        private void txtsubrgrupo_TextChanged(object sender, EventArgs e)
        {
            if (txtsubrgrupo.Text == "")
            {
                bttañadirsubgrupo.Enabled = false;
            }
            else { bttañadirsubgrupo.Enabled = true; }
        }

        private void rbgastos_CheckedChanged(object sender, EventArgs e)
        {
            if (rbgastos.Checked) Cambioestado();
        }

        private void Rbingresos_CheckedChanged(object sender, EventArgs e)
        {
            if (Rbingresos.Checked) Cambioestado();
        }

        private void rbgastocontribuciondirecta_CheckedChanged(object sender, EventArgs e)
        {
            if (rbgastocontribuciondirecta.Checked) Cambioestado();
        }
        public void Cambioestado()
        {
            if (Rbingresos.Checked)
            {
                Id_tipo = 0;
                Id_tipoCoste = 1;
                Tipo = "Ingresos";
            }
            if (rbgastos.Checked)
            {
                Id_tipo = 1;
                Id_tipoCoste = 3;
                Tipo = "Gastos";
            }
            if (rbgastocontribuciondirecta.Checked)
            {
                Id_tipo = 1;
                Id_tipoCoste = 2;
                Tipo = "Gastos";
            }
        }
    }
}
