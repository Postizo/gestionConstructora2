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
    public partial class Form_Empresas : Form
    {
        int i = 0;
        int estado = 0;
        public Form_Empresas()
        {
            InitializeComponent();
            DiseñoGrid();
            CargaPanel();
            pdatos.Visible = false;
        }
        #region BOTONES   
        private void bttAñadir_Click(object sender, EventArgs e)
        {
            if (estado == 1)
                EmpresasCN.Añadir(txtnombre.Text, txtbbdd.Text, txtservidor.Text, txtusuario.Text, txtpwd.Text);
            else
                EmpresasCN.Modificar(i, txtnombre.Text, txtbbdd.Text, txtservidor.Text, txtusuario.Text, txtpwd.Text);
            Pepara_Panel(pdatos, llegenda, false, "", false);
            CargaPanel();
      

        }
        private void bttnuevo_Click(object sender, EventArgs e)
        {
            estado = 1;
            Pepara_Panel(pdatos, llegenda, true, "Nueva Empresa",true);
            CargaPanel();
        }

        private void btteditar_Click(object sender, EventArgs e)
        {
            estado = 2;
            Pepara_Panel(pdatos, llegenda, true, "Modifica Empresa",true);
            CargaPanel(EmpresasCN.Listar(i));

        }
        private void bttborrar_Click(object sender, EventArgs e)
        {
            estado = 0;
            EmpresasCN.Borrar(i);
            CargaPanel();

        }
        #endregion

        #region EVENTOS
        private void dgempresas_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
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
            grid.DataSource = EmpresasCN.Sort(grid.Columns[e.ColumnIndex].Name, so.ToString(), (List<Empresas>)grid.DataSource);
            grid.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = so;

        }
        private void dgempresas_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            i = Convert.ToInt32(dgempresas.Rows[e.RowIndex].Cells["Id_Empresa"].Value);
        }
        #endregion

        #region PROCEDIMIENTOS
        public void DiseñoGrid()
        {
            dgempresas.AutoGenerateColumns = false;
            dgempresas.EnableHeadersVisualStyles = false;
            dgempresas.ColumnHeadersDefaultCellStyle.BackColor = Color.AliceBlue;
            dgempresas.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgempresas.ColumnHeadersDefaultCellStyle.Font = new Font(FontFamily.GenericSansSerif, 9.0F, FontStyle.Bold);
            foreach (DataGridViewColumn col in dgempresas.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.Programmatic;
            }
        }

        public void CargaPanel()
        {
            txtnombre.Text = string.Empty;
            txtbbdd.Text = string.Empty;
            txtservidor.Text = string.Empty;
            txtusuario.Text = string.Empty;
            txtpwd.Text = string.Empty;
            dgempresas.DataSource = EmpresasCN.Listar();
           

            //Colores
            txtnombre.BackColor = Color.Ivory;
            txtbbdd.BackColor = Color.Ivory;
            txtservidor.BackColor = Color.Ivory;
            txtusuario.BackColor = Color.Ivory;
            txtpwd.BackColor = Color.Ivory;

            // Enable
            txtnombre.ReadOnly = false;
            txtbbdd.ReadOnly = false;
            txtservidor.ReadOnly = false;
            txtusuario.ReadOnly = false;
            txtpwd.ReadOnly = false;

        }
        public void CargaPanel(Empresas emp)
        {
            txtnombre.Text = emp.Nombre;
            txtbbdd.Text = emp.BBDD_ContaWin;
            txtservidor.Text = emp.Servidor_ContaWin;
            txtusuario.Text = emp.Usuario_ContaWin;
            txtpwd.Text = emp.Pwd_ContaWin;
           //Colores
            txtnombre.BackColor = Color.Ivory;
            txtbbdd.BackColor = Color.Ivory;
            txtservidor.BackColor = Color.Ivory;
            txtusuario.BackColor = Color.Ivory;
            txtpwd.BackColor = Color.Ivory;

            // Enable
            txtnombre.ReadOnly = false;
            txtbbdd.ReadOnly = false;
            txtservidor.ReadOnly = false;
            txtusuario.ReadOnly = false;
            txtpwd.ReadOnly = false;

        }


        public void Pepara_Panel(Panel p, Label l, bool visible, string legenda,bool agrega)
        {
            p.Visible = visible;
            l.Text = legenda;
            if (agrega == true)
            {
                dgempresas.ReadOnly = true;
                pbotones.Enabled = false;
              
            }
            else
            {
                dgempresas.ReadOnly = false;
                pbotones.Enabled = true;
          
            }
        }


        #endregion
              
    }

}
