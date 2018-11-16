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
    public partial class Form_Cuentas : Form
    {
      
        string cuenta = string.Empty;
        int estado = 0;
        bool tratacuenta = false ;
        Empresas Emp = new Empresas();
        public Form_Cuentas(Empresas Empresa)
        {
            Emp = Empresa;
            InitializeComponent();
            DiseñoGrid();
            CargaPanel();
            pdatos.Visible = false;
        }
        #region BOTONES   
        private void bttAñadir_Click(object sender, EventArgs e)
        {
            if (estado == 1)
                CuentasCn.Añadir( Convert.ToInt32(cbempresa.SelectedValue), txtcuenta.Text, txtnombre.Text, Convert.ToInt32(cbgrupo.SelectedValue), Convert.ToInt32(cbsubgrupo.SelectedValue),tratacuenta);
            else
                CuentasCn.Modificar(Convert.ToInt32(cbempresa.SelectedValue), txtcuenta.Text, txtnombre.Text, Convert.ToInt32(cbgrupo.SelectedValue), Convert.ToInt32(cbsubgrupo.SelectedValue), tratacuenta);
            RefrescaPanel();
            Pepara_Panel(pdatos, llegenda, false, "",false);       
        }
        private void bttnuevo_Click(object sender, EventArgs e)
        {
            estado = 1;
            Pepara_Panel(pdatos, llegenda, true, "Nueva Cuenta",true);
            CargaPanel();
            pbotones.Enabled = false;
        }

        private void btteditar_Click(object sender, EventArgs e)
        {
            estado = 2;
            Pepara_Panel(pdatos, llegenda, true, "Modifica Cuenta",true);
            CargaPanel(CuentasCn.Listar(Emp.Id_Empresa, cuenta));
            pbotones.Enabled = false;
        }
        private void bttborrar_Click(object sender, EventArgs e)
        {
            if (dgcuentas.SelectedRows.Count == 0) return;
            estado = 0;
            CuentasCn.Borrar(Emp.Id_Empresa, cuenta);
            dgcuentas.DataSource = CuentasCn.Listar(chbuscatrata.Checked);

        }
        #endregion

        #region EVENTOS
        private void dgcuentas_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
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
            grid.DataSource = CuentasCn.Sort(grid.Columns[e.ColumnIndex].Name, so.ToString(), (List<Cuentas>)grid.DataSource);
            grid.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = so;

        }
        private void dgempresas_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
          
            cuenta  = Convert.ToString(dgcuentas.Rows[e.RowIndex].Cells["cuentas"].Value);

        }
        private void chtratacuenta_CheckedChanged(object sender, EventArgs e)
        {
            tratacuenta = chtratacuenta.Checked ? true : false;
        }
        private void cbgrupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cbsubgrupo.DataSource = SubGruposCN.ListarporGrupo(Convert.ToInt32(cbgrupo.SelectedValue));
                cbsubgrupo.DisplayMember = "Nombre";
                cbsubgrupo.ValueMember = "Id_Subgrupo";
                cbsubgrupo.SelectedValue = -1;
            }
            catch { }

        }
        #endregion

        #region PROCEDIMIENTOS

        public void DiseñoGrid()
        {
            dgcuentas.AutoGenerateColumns = false;
            dgcuentas.EnableHeadersVisualStyles = false;
            dgcuentas.ColumnHeadersDefaultCellStyle.BackColor = Color.AliceBlue;
            dgcuentas.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgcuentas.ColumnHeadersDefaultCellStyle.Font = new Font(FontFamily.GenericSansSerif, 9.0F, FontStyle.Bold);
            foreach (DataGridViewColumn col in dgcuentas.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.Programmatic;
            }
        }

        public void CargaPanel()
        {
            cbempresa.DataSource = EmpresasCN.Listar();
            cbempresa.DisplayMember = "Nombre";
            cbempresa.ValueMember = "Id_Empresa";
            cbempresa.SelectedValue = -1;
            
            txtcuenta.Text = string.Empty;
            txtnombre.Text = string.Empty;

            cbgrupo.DataSource = GruposCN.Listar_solocontabilidad();
            cbgrupo.DisplayMember = "Nombre";
            cbgrupo.ValueMember = "Id_Grupo";
            cbgrupo.SelectedValue = -1;

            cbsubgrupo.DataSource = SubGruposCN.ListarporGrupo(Convert.ToInt32(cbgrupo.SelectedValue));
            cbsubgrupo.DisplayMember = "Nombre";
            cbsubgrupo.ValueMember = "Id_Subgrupo";
            cbsubgrupo.SelectedValue = -1;

            chtratacuenta.Checked = true;
            dgcuentas.DataSource = Emp.Cuentas.Where(p=> p.TrataCuenta == chbuscatrata.Checked).ToList();

            //Colores
            cbempresa.BackColor = Color.Ivory;
        
            txtcuenta.BackColor = Color.Ivory;
            txtnombre.BackColor = Color.Ivory;
            cbgrupo.BackColor = Color.Ivory;
            cbsubgrupo.BackColor = Color.Ivory;
            
            // Enable
            cbempresa.Enabled = true;           
            txtcuenta.ReadOnly = false;
            txtnombre.ReadOnly = false;
            cbgrupo.Enabled = true;
            cbsubgrupo.Enabled = true;

        }
        public void RefrescaPanel()
        {
            
            txtcuenta.Text = string.Empty;
            txtnombre.Text = string.Empty;
    
            cbgrupo.SelectedValue = -1;

            cbsubgrupo.DataSource = SubGruposCN.ListarporGrupo(Convert.ToInt32(cbgrupo.SelectedValue));
            cbsubgrupo.DisplayMember = "Nombre";
            cbsubgrupo.ValueMember = "Id_Subgrupo";
            cbsubgrupo.SelectedValue = -1;

            chtratacuenta.Checked = true;
            dgcuentas.DataSource = CuentasCn.Listar(chbuscatrata.Checked, txtbuscar.Text, Emp.Id_Empresa);
        }

        public void CargaPanel(Cuentas Cuenta)
        {
            //Carga datos
            cbempresa.SelectedValue = Cuenta.Id_Empresa;
  
            txtcuenta.Text = Cuenta.Cuenta ;
            txtnombre.Text = Cuenta.Nombre ;
            cbgrupo.SelectedValue = Cuenta.Id_Grupo;
            cbsubgrupo.SelectedValue = Cuenta.Id_SubGrupo;
            chtratacuenta.Checked = Cuenta.TrataCuenta;
            //Colores
            cbempresa.BackColor = Color.AliceBlue;
           
            txtcuenta.BackColor = Color.AliceBlue;
            txtnombre.BackColor = Color.Ivory;
            cbgrupo.BackColor = Color.Ivory;
            cbsubgrupo.BackColor = Color.Ivory;
            // Enable
            cbempresa.Enabled = false;
        
            txtcuenta.ReadOnly = true;
            txtnombre.ReadOnly = false;
            cbgrupo.Enabled = true;
            cbsubgrupo.Enabled = true;
        }

        public void Pepara_Panel(Panel p, Label l, bool visible, string legenda,bool agrega)
        {
            p.Visible = visible;
            l.Text = legenda;
            if (agrega == true)
            {
                dgcuentas.ReadOnly = true;
                pbotones.Enabled = false;
                pbuscar.Enabled = false;
            }
            else
            {
                dgcuentas.ReadOnly = false ;
                pbotones.Enabled = true;
                pbuscar.Enabled = true;
            }

        }




        #endregion



        private void button1_Click(object sender, EventArgs e)
        {
            dgcuentas.DataSource = CuentasCn.Listar(chbuscatrata.Checked, txtbuscar.Text,Emp.Id_Empresa );
        }  

        private void txtbuscar_TextChanged(object sender, EventArgs e)
        {
            dgcuentas.DataSource = CuentasCn.Listar(chbuscatrata.Checked, txtbuscar.Text, Emp.Id_Empresa);
        }
    }
}
