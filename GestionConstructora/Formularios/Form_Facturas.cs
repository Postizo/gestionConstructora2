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

namespace GestionConstructora
{
    public partial class Form_Facturas : Form
    {
        Obras Obr = new Obras();
        Empresas Emp = new Empresas();
        public Form_Facturas(Empresas Empresa)
        {
            Emp = Empresa;
            InitializeComponent();
            DiseñoGrid();
        }
        public void DiseñoGrid()
        {
            cbgrupo.DataSource = GruposCN.Listar_solocontructora();
            cbgrupo.DisplayMember = "Nombre";
            cbgrupo.ValueMember = "Id_Grupo";
            listObras.DataSource = Emp.Obras.ToList().Where(p => p.Importado_presu == true).ToList();
            listObras.DisplayMember = "Nombre";
            listObras.ValueMember = "id_Obra";
            dgfacturas.AutoGenerateColumns = false;
            dgfacturas.EnableHeadersVisualStyles = false;
            dgfacturas.ColumnHeadersDefaultCellStyle.BackColor = Color.AliceBlue;
            dgfacturas.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgfacturas.ColumnHeadersDefaultCellStyle.Font = new Font(FontFamily.GenericSansSerif, 9.0F, FontStyle.Bold);
            foreach (DataGridViewColumn col in dgfacturas.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.Programmatic;
            }            
        }
                
        private void button2_Click(object sender, EventArgs e)
        {
            Obr = Emp.Obras.Where(p => p.Id_Obra == Publico.Obras_Selecionadas(listObras)[0].Id_Obra).ToList()[0];
            ltitulo.Text = "FACTURAS DE LA OBRA:" + Obr.Nombre + "";
            Actulizagrid();
        }

        private void dgfacturas_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = Convert.ToInt32(dgfacturas["Id_factura", e.RowIndex].Value);
            Facturas_ca Fac = FacturasCN.Listar(i);
            Form_FacturaDetalle f = new Form_FacturaDetalle(Fac);
            f.ShowDialog();
            Emp = EmpresasCN.Listar(Emp.Id_Empresa);
            Obr = Emp.Obras.Where(p => p.Id_Obra == Publico.Obras_Selecionadas(listObras)[0].Id_Obra).ToList()[0];
            Actulizagrid();
        }

        private void txtcuenta_TextChanged(object sender, EventArgs e)
        {
            dgfacturas.DataSource = Obr.Facturas_ca.Where(p => p.Ref_Fac.ToUpper().Contains(txtcuenta.Text.ToUpper()) || p.Proveedor.ToUpper().Contains(txtcuenta.Text.ToUpper())).ToList();
        }

        private void cbgrupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Facturas_ca> Li = new List<Facturas_ca>();
            foreach (Facturas_ca Fac in Obr.Facturas_ca.ToList())
            {
                if (Fac.Facturas_li.Where(p => p.Id_grupo == cbgrupo.SelectedIndex).Count() > 0)
                {
                    Li.Add(Fac);
                }
            }
            dgfacturas.DataSource = Li;
        }

        private void bttpagar_Click(object sender, EventArgs e)
        {
          
            string Title = (rbfacturadas.Checked== true )?"Facturas Contabilizadas. Obra:" + Obr.Nombre : "Facturas Pendientes. Obra:" + Obr.Nombre;
            ContaWIN.M_PrintDGV.Print_DataGridView(dgfacturas, Title, true, false, true,false);
        }
        public void Contabilizar()
        {
            Guid id_infr = new Guid();
            List<Int32> Factus = new List<Int32>();
            Empresas EMpresaContabilizar;
            id_infr = Guid.NewGuid();
            
            foreach (DataGridViewRow row in dgfacturas.SelectedRows) { Factus.Add( Convert.ToInt32(row.Cells["Id_Factura"].Value ));}
            List<Facturas_ca> Facturas = Obr.Facturas_ca.Where(p => Factus.Contains(p.Id_Factura)).ToList();
            Form_ParametrosFactu f = new Form_ParametrosFactu(Facturas);
    
            f.Location = new Point(((this.Width - f.Width) / 2) + this.Location.X, ((this.Height - f.Height) / 2) + this.Location.Y);
            f.ShowDialog(this);
            EMpresaContabilizar = f.Emp;
            List<string> Mensajes =  FacturasCN.ContabilizarLasQueMAndo(EMpresaContabilizar, Facturas, id_infr.ToString());
            foreach (string m in Mensajes)
            {
                if (m != string.Empty)MessageBox.Show(m, "GestionConstructora",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (Mensajes.Count == 0)
                MessageBox.Show("FACTURAS CONTABILIZADAS CON EXITO", "GestionConstructora", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        public void Pagar()
        {
            foreach (DataGridViewRow row in dgfacturas.SelectedRows)
            {
                FacturasCN.Cambiar_estado(Convert.ToInt32(row.Cells["Id_Factura"].Value), 1, 0);
            }
            Obr = Emp.Obras.Where(p => p.Id_Obra == Publico.Obras_Selecionadas(listObras)[0].Id_Obra).ToList()[0];
            Actulizagrid();
         
        }

        private void bttver_Click(object sender, EventArgs e)
        {
            if (dgfacturas.CurrentRow == null) return;
            int i = Convert.ToInt32(dgfacturas.SelectedRows[0].Cells["Id_factura"].Value);
            Facturas_ca Fac = FacturasCN.Listar(i);
            Form_FacturaDetalle f = new Form_FacturaDetalle(Fac);
            f.ShowDialog();
            Emp = EmpresasCN.Listar(Emp.Id_Empresa);
            Obr = Emp.Obras.Where(p => p.Id_Obra == Publico.Obras_Selecionadas(listObras)[0].Id_Obra).ToList()[0];
            Actulizagrid();
        }

        private void dgfacturas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void rbfacturadas_CheckedChanged(object sender, EventArgs e)
        {
            Actulizagrid();
        }

        private void rbpagadas_CheckedChanged(object sender, EventArgs e)
        {
            Actulizagrid();
        }
        private void Actulizagrid()
        {

            if (rbfacturadas.Checked)
            {
                dgfacturas.DataSource = Obr.Facturas_ca.Where(p => p.Estado == 0).ToList();
                bttpagar.Text = "CONTABILIZAR";
            }
            
            if (rbpendientes.Checked)
            {
                dgfacturas.DataSource = Obr.Facturas_ca.Where(p => p.Estado == -1).ToList();
                bttpagar.Text = "CONTABILIZAR";
            }

            if (txtcuenta.Text != "")
            {
                dgfacturas.DataSource = Obr.Facturas_ca.Where(p => p.Estado == 0).Where(p => p.Ref_Fac.ToUpper().Contains(txtcuenta.Text.ToUpper()) || p.Proveedor.ToUpper().Contains(txtcuenta.Text.ToUpper())).ToList();
            }

        }

        private void dgfacturas_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
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
            grid.DataSource = FacturasCN.Sort(grid.Columns[e.ColumnIndex].Name, so.ToString(), (List<Facturas_ca>)grid.DataSource);
            grid.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = so;
        }

        private void rbpendientes_CheckedChanged(object sender, EventArgs e)
        {
            Actulizagrid();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dgfacturas.CurrentRow == null) return;
            if (rbpendientes.Checked == true) Contabilizar();
            if (rbfacturadas.Checked == true) Pagar();
            Emp = EmpresasCN.Listar(Emp.Id_Empresa);
            Obr = Emp.Obras.Where(p => p.Id_Obra == Publico.Obras_Selecionadas(listObras)[0].Id_Obra).ToList()[0];
            Actulizagrid();
           
        }
    }
}
