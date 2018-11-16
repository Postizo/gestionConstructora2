using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio;
using Entidad;


namespace GestionConstructora
{
    public partial class Form_ImportarTarifas : Form
    {
        Empresas Emp = new Empresas();
        DataTable dtexcel = new DataTable();
        DataTable dtsigrid = new DataTable();
        DataTable dtcoinciden = new DataTable();



        public Form_ImportarTarifas(Empresas Empresa)
        {
            InitializeComponent();
            Emp = Empresa;
            dtsigrid = ImportarTarifasCN.Busca_Fabricantes(Emp);
            cbfabricantes.DataSource = dtsigrid;
            cbfabricantes.ValueMember = "ide";
            cbfabricantes.DisplayMember = "res";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int cont = 0;
            dtcoinciden.Rows.Clear();
            foreach (DataRow dr in dtexcel.Rows)
            {

                if (dtsigrid.AsEnumerable().Where(myRow => myRow.ItemArray[0].ToString() == dr[1].ToString()).Count() > 0)
                {
                    DataRow drigual = dtsigrid.AsEnumerable().Where(myRow => myRow.ItemArray[0].ToString() == dr[1].ToString()).ToList()[0];
                    DataRow drcop = dtcoinciden.NewRow();
                    drcop[1] = dr[1];
                    drcop[2] = dr[2];
                    drcop[3] = dr[3];
                    dtcoinciden.Rows.Add(drcop);
                    cont++;
                }
            }
            dataGridView1.DataSource = dtcoinciden;
            label4.Text = cont.ToString();

            foreach (DataRow dr in dtcoinciden.Rows)
            {
                ImportarTarifasCN.Producto NuevoProducto = new ImportarTarifasCN.Producto();
                NuevoProducto.c_emp = 4;
                NuevoProducto.c_tip = 3;
                NuevoProducto.c_cod = dr[1].ToString();
                NuevoProducto.c_res = dr[2].ToString();
                NuevoProducto.c_fec = Convert.ToInt32(DateTime.Now.ToString("yyyyMMdd"));
                NuevoProducto.pro_cla = 3;
                NuevoProducto.pro_fabide = Convert.ToInt32(cbfabricantes.SelectedValue);
                NuevoProducto.pro_fabref = dr[1].ToString();
                NuevoProducto.pro_prvide = 323222;
                NuevoProducto.pro_natide = 0;
                NuevoProducto.pro_tex = dr[2].ToString();
                NuevoProducto.pro_pco = Convert.ToDouble(dr[3].ToString());
                ImportarTarifasCN.Insert_Mod_Producto(Emp, NuevoProducto);

            }
        }

        //private void button1_Click(object sender, EventArgs e)
        ////{
        ////    OpenFileDialog openFileDialog1 = new OpenFileDialog();

        ////    openFileDialog1.InitialDirectory = "c:\\";
        ////    openFileDialog1.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm|All files (*.*)|*.*";
        ////    openFileDialog1.FilterIndex = 2;
        ////    openFileDialog1.RestoreDirectory = true;

        ////    if (openFileDialog1.ShowDialog() == DialogResult.OK)
        ////    {
        ////        try
        ////        {
        ////            txtdirectorio.Text = openFileDialog1.FileName;
        ////            dtexcel = ImportarTarifasCN.ParseToExcel(txtdirectorio.Text);
        ////            dtcoinciden = ImportarTarifasCN.ParseToExcel(txtdirectorio.Text);
        ////            dgexcel.DataSource = dtexcel;
        ////        }
        ////        catch (Exception ex)
        ////        {
        ////            MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
        ////        }
        ////    }
        //}
        
       

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow  dr in dgexcel.SelectedRows)
            {
                ImportarTarifasCN.Producto NuevoProducto = new ImportarTarifasCN.Producto();
                NuevoProducto.c_emp = 4;
                NuevoProducto.c_tip = 3;
                NuevoProducto.c_cod = dr.Cells[1].Value.ToString();
                NuevoProducto.c_res = (dr.Cells[2].Value.ToString().Length > 125)? dr.Cells [2].Value.ToString().Substring(125, 0) : dr.Cells[2].Value.ToString();
                NuevoProducto.c_fec = Convert.ToInt32(DateTime.Now.ToString("yyyyMMdd"));
                NuevoProducto.pro_cla = 3;
                NuevoProducto.pro_fabide = Convert.ToInt32(cbfabricantes.SelectedValue);
                NuevoProducto.pro_fabref = dr.Cells[1].Value.ToString();
                NuevoProducto.pro_prvide = 323222;
                NuevoProducto.pro_natide = 0;
                NuevoProducto.pro_tex = (dr.Cells[2].Value.ToString().Length > 125) ? dr.Cells[2].Value.ToString().Substring(125, 0) : dr.Cells[2].Value.ToString();
                NuevoProducto.pro_pco = Convert.ToDouble(dr.Cells[3].Value.ToString());
                ImportarTarifasCN.Insert_Mod_Producto(Emp, NuevoProducto);
            }
        }
        
        private void Cbproveedorestarifa_SelectionChangeCommitted(object sender, EventArgs e)
        {
            dtexcel = new DataTable();
            dtexcel  = ImportarTarifasCN.Buscar_productosTarifa(Emp, Convert.ToInt32(cbprovedorestarifa.SelectedIndex +1),txtbuscaexcel.Text );
            dtcoinciden = ImportarTarifasCN.Buscar_productosTarifa(Emp, Convert.ToInt32(cbprovedorestarifa.SelectedIndex + 1), txtbuscaexcel.Text);
            dgexcel.DataSource = dtexcel;
        }

     
        private void cbfabricantes_SelectionChangeCommitted_1(object sender, EventArgs e)
        {
            dtsigrid = new DataTable();
            dtsigrid = ImportarTarifasCN.Buscar_productor_PorFabricante(Emp, Convert.ToInt32(cbfabricantes.SelectedValue),txtbuscasigri.Text );
            dgsigrid.DataSource = dtsigrid;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dtexcel = new DataTable();
            dtexcel = ImportarTarifasCN.Buscar_productosTarifa(Emp, Convert.ToInt32(cbprovedorestarifa.SelectedIndex + 1), txtbuscaexcel.Text);
            dgexcel.DataSource = dtexcel;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            dtsigrid = new DataTable();
            dtsigrid = ImportarTarifasCN.Buscar_productor_PorFabricante(Emp, Convert.ToInt32(cbfabricantes.SelectedValue), txtbuscasigri.Text);
            dgsigrid.DataSource = dtsigrid;
        }
        private void cbprovedorestarifa_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dgexcel_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgexcel[4, e.RowIndex].Value.ToString() != "")
                {
                    System.Diagnostics.Process.Start(dgexcel[4, e.RowIndex].Value.ToString());
                }
            }
            catch (Exception)
            {

                
            }
           
           
        }
    }
}
