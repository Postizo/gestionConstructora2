using Negocio;
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
using System.Reflection;

namespace GestionConstructora
{
    public partial class Form_Dequipos : Form
    {
        List<D_Equipos> Equipos = new List<D_Equipos>();
        List<D_provee> Proveedores = new List<D_provee>();
        List<D_Familias> Familias = new List<D_Familias>();

        public Form_Dequipos()
        {
            InitializeComponent();
            ini();
            Equipos = DEquiposCN.ListarEquipos();
            Proveedores = DEquiposCN.ListarProveedores();
            Familias = DEquiposCN.ListarFamilias();
            dgequipos.DataSource = Equipos;
            dgproveedores.DataSource = Proveedores;
            dgfamilias.DataSource = Familias;

            cbproveeauto.DataSource = Proveedores;
            cbproveeauto.DisplayMember = "Proveedor";
            cbproveeauto.ValueMember = "id_proveedor";
            cbproveeauto.SelectedValue = -1;
            dgtiempos.DataSource = Equipos;
            instru.Text = "-Actualizacion automatica de los equipos. Seleccionar el excel con los equipos con el siguiente formato. \n 1 Columna:- Referencia \n 2 Columna: Nombre Articulo \n 3 Columna: PVP \n 4 Alias \n  El archivo NO debe contener CABECERA Los articulos que ya existan se actualizara su precio y los que no existan se agregara como articulo nuevo.";

        }
        public void ini()
        {
            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic |
                  BindingFlags.Instance | BindingFlags.SetProperty, null,
                  dgequipos, new object[] { true });
            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic |
            BindingFlags.Instance | BindingFlags.SetProperty, null,
            dgtiempos, new object[] { true });

            dgequipos.AutoGenerateColumns = false;
            dgequipos.EnableHeadersVisualStyles = false;
            dgequipos.ColumnHeadersDefaultCellStyle.BackColor = Color.Honeydew;
            dgequipos.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgequipos.ColumnHeadersDefaultCellStyle.Font = new Font(FontFamily.GenericSansSerif, 9.0F, FontStyle.Bold);

            dgtiempos.AutoGenerateColumns = false;
            dgtiempos.EnableHeadersVisualStyles = false;
            dgtiempos.ColumnHeadersDefaultCellStyle.BackColor = Color.Honeydew;
            dgtiempos.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgtiempos.ColumnHeadersDefaultCellStyle.Font = new Font(FontFamily.GenericSansSerif, 9.0F, FontStyle.Bold);

            dgproveedores.AutoGenerateColumns = false;
            dgproveedores.EnableHeadersVisualStyles = false;
            dgproveedores.ColumnHeadersDefaultCellStyle.BackColor = Color.Honeydew;
            dgproveedores.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgproveedores.ColumnHeadersDefaultCellStyle.Font = new Font(FontFamily.GenericSansSerif, 9.0F, FontStyle.Bold);

            dgfamilias.AutoGenerateColumns = false;
            dgfamilias.EnableHeadersVisualStyles = false;
            dgfamilias.ColumnHeadersDefaultCellStyle.BackColor = Color.Honeydew;
            dgfamilias.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgfamilias.ColumnHeadersDefaultCellStyle.Font = new Font(FontFamily.GenericSansSerif, 9.0F, FontStyle.Bold);


            e_proveedor.DataSource = DEquiposCN.ListarProveedores();
            e_proveedor.DisplayMember = "Proveedor";
            e_proveedor.ValueMember = "id_proveedor";


            e_grupo.DataSource = DEquiposCN.ListarFamilias();
            e_grupo.DisplayMember = "Nombre";
            e_grupo.ValueMember = "Nombre";

            cbprove.DataSource = DEquiposCN.ListarProveedores();
            cbprove.DisplayMember = "Proveedor";
            cbprove.ValueMember = "id_proveedor";

            cbproveetiemp.DataSource = DEquiposCN.ListarProveedores();
            cbproveetiemp.DisplayMember = "Proveedor";
            cbproveetiemp.ValueMember = "id_proveedor";

        }


        public void refresca()
        {

            List<D_Equipos> Busqueda = new List<D_Equipos>();

            if (Convert.ToInt32(cbprove.SelectedValue) != 12)
            {
                Busqueda = Equipos.Where(p => p.Nombre.ToUpper().Contains(txtbuscar.Text.ToUpper()) || p.Referencia.ToUpper().Contains(txtbuscar.Text.ToUpper())).Where(p => p.id_proveedor == Convert.ToUInt32(cbprove.SelectedValue)).ToList();             
            }
            else
            {
                Busqueda = Equipos.Where(p => p.Nombre.ToUpper().Contains(txtbuscar.Text.ToUpper()) || p.Referencia.ToUpper().Contains(txtbuscar.Text.ToUpper())).ToList();              
            }
            if (chalias.Checked)
            {
                Busqueda = Busqueda.Where(p => p.N_Alternativo == "").ToList();
            }
            if (chtiempos.Checked)
            {
                Busqueda = Busqueda.Where(p => p.T_programacion  == 0 && p.T_instalacion ==0  && p.T_puestamarcha ==0 && p.T_volcado ==0).ToList();
            }
            linfo.Text = Busqueda.Count.ToString();
            linfot.Text = Busqueda.Count.ToString();
            dgequipos.DataSource = Busqueda;
            dgtiempos.DataSource = Busqueda;
        }


        private void dgequipos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgequipos["E_ref", e.RowIndex].Value == null) return;

            if (dgequipos.Columns[e.ColumnIndex].Name != "E_ref")
            {
                if (dgequipos.Columns[e.ColumnIndex].Name == "e_proveedor")
                {
                    DEquiposCN.ModificarEquiposProveedor(dgequipos["E_ref", e.RowIndex].Value.ToString(), dgequipos["e_proveedor", e.RowIndex].FormattedValue.ToString(), Convert.ToInt32(dgequipos["e_proveedor", e.RowIndex].Value.ToString()));
                }
                if (dgequipos.Columns[e.ColumnIndex].Name == "e_grupo")
                {
                    DEquiposCN.ModificarEquiposGrupos(dgequipos["E_ref", e.RowIndex].Value.ToString(), dgequipos["e_grupo", e.RowIndex].FormattedValue.ToString().Trim());
                }


            
                if (dgequipos["E_nombre", e.RowIndex].Value == null) return;
                if (dgequipos["E_Alias", e.RowIndex].Value == null) dgequipos["E_Alias", e.RowIndex].Value = "";
                if (dgequipos["e_pvp", e.RowIndex].Value == null) return;
                DEquiposCN.ModificarEquipos(dgequipos["E_ref", e.RowIndex].Value.ToString(), dgequipos["E_nombre", e.RowIndex].Value.ToString(), dgequipos["E_Alias", e.RowIndex].Value.ToString(), Convert.ToDecimal(dgequipos["e_pvp", e.RowIndex].Value.ToString()));
            }
            else
            {
                DEquiposCN.AñadirEquipos(dgequipos["E_ref", e.RowIndex].Value.ToString().Trim() );
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Equipos.Clear();
            Equipos.Add(new D_Equipos());
            dgequipos.DataSource = null;
            dgequipos.DataSource = Equipos;
            dgequipos.Columns["E_ref"].ReadOnly = false;
            txtbuscar.Enabled = false;
            cbprove.Enabled = false;
            button1.Enabled = false;
            button3.Enabled = false;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Equipos = DEquiposCN.ListarEquipos();
            dgequipos.DataSource = Equipos;
            dgequipos.Columns["E_ref"].ReadOnly = true;
            txtbuscar.Text = "";
            txtbuscar.Enabled = true;
            cbprove.Enabled = true;
            button1.Enabled = true;
            button3.Enabled = true;
            refresca();
        }

        private void dgequipos_DataError(object sender, DataGridViewDataErrorEventArgs e)
        { 
            try
            {

            }
            catch (Exception)
            {

            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgequipos.SelectedRows)
            {
                DEquiposCN.BorrarEquipos(dgequipos["E_ref", row.Index].Value.ToString());
            }
            button2.PerformClick();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            txtbuscartiem.Text = txtbuscar.Text;
            refresca();
        }

        private void txtbuscartiem_TextChanged(object sender, EventArgs e)
        {
            txtbuscar.Text = txtbuscartiem.Text;
            refresca();
        }

        private void cbproveetiemp_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cbprove.SelectedIndex = cbproveetiemp.SelectedIndex;
            refresca();
        }

        private void cbprove_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cbproveetiemp.SelectedIndex = cbprove.SelectedIndex;
            refresca();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            button6.Enabled = false;
            button5.Visible = true;
            Proveedores.Clear();
            Proveedores.Add(new D_provee());
            dgproveedores.DataSource = null;
            dgproveedores.DataSource = Proveedores;
            dgproveedores.Columns["P_provee"].ReadOnly = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgproveedores.SelectedRows)
            {
                DEquiposCN.BorrarEquipos(dgequipos["P_id_Provee", row.Index].Value.ToString());
            }
            button5.PerformClick();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (dgproveedores["P_Provee", 0].Value == null) return;
            if (dgproveedores["P_descuento", 0].Value == null) return;
            DEquiposCN.AñadirProvee(dgproveedores["P_provee", 0].Value.ToString(), Convert.ToDecimal(dgproveedores["p_descuento", 0].Value.ToString()) / 100);

            Proveedores = DEquiposCN.ListarProveedores();
            dgproveedores.DataSource = Proveedores;
            dgproveedores.Columns["P_provee"].ReadOnly = false;
            button6.Enabled = true;
            button5.Visible = false;
        }
        private void dgproveedores_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (button6.Enabled == true)
            {
                if (dgproveedores["P_Provee", e.RowIndex].Value == null) return;
                if (dgproveedores["P_descuento", e.RowIndex].Value == null) return;
                DEquiposCN.ModificarProveedor(Convert.ToInt32(dgproveedores["P_id_Provee", e.RowIndex].Value.ToString()), Convert.ToDecimal(dgproveedores["P_descuento", e.RowIndex].Value.ToString()));
            }
        }
        private void dgtiempos_CellEndEdit_1(object sender, DataGridViewCellEventArgs e)
        {
            if (dgtiempos.Columns[e.ColumnIndex].Name != "T_ref")
            {
                if (dgtiempos["T_ref", e.RowIndex].Value == null) return;
                if (dgtiempos["T_programacion", e.RowIndex].Value == null) return;
                if (dgtiempos["T_volcado", e.RowIndex].Value == null) return;
                if (dgtiempos["T_instalacion", e.RowIndex].Value == null) return;
                if (dgtiempos["T_puestamarcha", e.RowIndex].Value == null) return;
                DEquiposCN.ModificarTiempos(dgtiempos["T_ref", e.RowIndex].Value.ToString(), Convert.ToInt32(dgtiempos["T_programacion", e.RowIndex].Value.ToString()), Convert.ToInt32(dgtiempos["T_volcado", e.RowIndex].Value.ToString()), Convert.ToInt32(dgtiempos["T_instalacion", e.RowIndex].Value.ToString()), Convert.ToInt32(dgtiempos["T_puestamarcha", e.RowIndex].Value.ToString()));
            }
        }

        private void dgtiempos_CellValidated(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgequipos_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            string name = null;
            name = dgequipos.Columns[e.ColumnIndex].Name;
            if (name == "E_Pvp")
            {
                try
                {
                    // Valor actual de la celda 
                    string value = dgequipos.CurrentCell.EditedFormattedValue.ToString();
                    // Reemplazamos el punto por la coma decimal. 
                    value = value.Replace(".", ",");
                    // Escribimos el nuevo valor. 
                    decimal cellValue = Convert.ToDecimal(value);
                    dgequipos.CurrentCell.Value = cellValue;
                }
                catch (Exception ex)
                {
                }
            }
        }

        private void dgproveedores_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            string name = null;
            name = dgproveedores.Columns[e.ColumnIndex].Name;
            if (name == "P_descuento")
            {
                try
                {
                    // Valor actual de la celda 
                    string value = dgproveedores.CurrentCell.EditedFormattedValue.ToString();
                    // Reemplazamos el punto por la coma decimal. 
                    value = value.Replace(".", ",");
                    value = (Convert.ToDecimal(value) / 100).ToString();
                    // Escribimos el nuevo valor. 
                    decimal cellValue = Convert.ToDecimal(value);
                    dgproveedores.CurrentCell.Value = cellValue;
                }
                catch (Exception ex)
                {
                }
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {   
            if (Convert.ToInt32(cbproveeauto.SelectedValue) == 0)
            {
                MessageBox.Show("Selecciona un proveedor", "Aviso");
                return;
            }        
            string fileName = null;
            using (OpenFileDialog openFileDialog1 = new OpenFileDialog())
            {
                openFileDialog1.InitialDirectory = "c:\\";
                openFileDialog1.Filter = "All files (*.*)|*.*";
                openFileDialog1.FilterIndex = 1;
                openFileDialog1.RestoreDirectory = true;
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    fileName = openFileDialog1.FileName;
                    txtbuscar2.Text = fileName;
                }
            }

            if (fileName != null)
            {
                DataTable dt = new DataTable();
                try{
                   Publico.ExceltoDt(fileName, dt);
                }
               catch (Exception){ MessageBox.Show("Error en el procesamiento del Excel. Necesita una version de Excel 2013", "Aviso",MessageBoxButtons.OK, MessageBoxIcon.Error);}
                try{
                    Importacion(dt);
                }
                catch (Exception){MessageBox.Show("Error en la importacion de los equipos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);}
  
            }
        }
        private void Importacion(DataTable dt)
        {
            this.Cursor = Cursors.WaitCursor;
            int contadormodificado =0;
            int contadornuevo = 0;
            foreach (DataRow dr in dt.Rows)
            {
                if (DEquiposCN.ListarEquipos(dr[0].ToString().Trim()) == null)
                {
                    DEquiposCN.AñadirEquipos(dr[0].ToString());
                    DEquiposCN.ModificarEquipos(dr[0].ToString(), dr[1].ToString(), dr[3].ToString(), Convert.ToDecimal(dr[2].ToString()));
                    DEquiposCN.ModificarEquiposProveedor(dr[0].ToString(),cbproveeauto.Text, Convert.ToInt32(cbproveeauto.SelectedValue));
                    contadornuevo++;
                }
                else
                {
                    DEquiposCN.ModificarEquiposPVp(dr[0].ToString(), Convert.ToDecimal(dr[2].ToString()));
                    contadormodificado++;
                }               
            }
            lnuevos.Text = contadornuevo.ToString();
            lmodificados.Text = contadormodificado.ToString();
            this.Cursor = Cursors.Default;
        }
        private void chalias_CheckedChanged(object sender, EventArgs e)
        {
            chaliast.Checked = chalias.Checked;
            refresca();
        }

        private void chtiempos_CheckedChanged(object sender, EventArgs e)
        {
            chtiempost.Checked = chtiempos.Checked;
            refresca();
        }

        private void chaliast_CheckedChanged(object sender, EventArgs e)
        {
            chalias.Checked = chaliast.Checked;
            refresca();
        }

        private void chtiempost_CheckedChanged(object sender, EventArgs e)
        {
            chtiempos.Checked = chtiempost.Checked;
            refresca();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            button8.Enabled = false;
            button7.Visible = true;
            Familias.Clear();
            Familias.Add(new D_Familias());
            dgfamilias.DataSource = null;
            dgfamilias.DataSource = Familias;
           
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (dgfamilias["F_Nombre", 0].Value == null) return;
            if (dgfamilias["F_Orden", 0].Value == null) return;
            DEquiposCN.AñadirFamilia(dgfamilias["F_Nombre", 0].Value.ToString(), dgfamilias["F_Orden", 0].Value.ToString().PadLeft(2, Convert.ToChar("0")));

            Familias = DEquiposCN.ListarFamilias();
            dgfamilias.DataSource = Familias;
            //dgfamilias.Columns["F_id_Familia"].ReadOnly = false;
            button8.Enabled = true;
            button7.Visible = false;
        }

        private void dgfamilias_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (button8.Enabled == true)
            {
                if (dgfamilias["F_id_Familia", e.RowIndex].Value == null) return;
                if (dgfamilias["F_Nombre", e.RowIndex].Value == null) return;
                if (dgfamilias["F_Orden", e.RowIndex].Value == null) return;
                DEquiposCN.ModificarFamilias(Convert.ToInt32(dgfamilias["F_id_Familia", e.RowIndex].Value.ToString()), dgfamilias["F_Nombre", e.RowIndex].Value.ToString(), dgfamilias["F_Orden", e.RowIndex].Value.ToString().PadLeft(2,Convert.ToChar("0")));
            }
        }
    }
}
