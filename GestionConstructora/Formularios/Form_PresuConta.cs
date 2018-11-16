using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidad;
using Negocio;

namespace GestionConstructora
{
   
    public partial class Form_PresuConta : Form
    {
        Empresas Emp = new Empresas();
        DataTable dt = new DataTable();
        Obras Obrsel = new Obras();
      
        public Form_PresuConta(Empresas emp)
        {
            InitializeComponent();
            Emp = emp;
            DiseñoGrid();      
        }

        public void DiseñoGrid()
        {
            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic |
            BindingFlags.Instance | BindingFlags.SetProperty, null,
            dginforme, new object[] { true });
            pderecha.Visible = false;

            dginforme.EnableHeadersVisualStyles = false;
            dginforme.ColumnHeadersDefaultCellStyle.BackColor = Color.AliceBlue;
            dginforme.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dginforme.ColumnHeadersDefaultCellStyle.Font = new Font(FontFamily.GenericSansSerif, 9.0F, FontStyle.Bold);
            listObras.DataSource = Emp.Obras.ToList().Where(p => p.Id_Obra != 0).ToList();
            listObras.DisplayMember = "Nombre";
            listObras.ValueMember = "id_Obra";
        }

        public void Creagrid()
        {
            //Limpiamos 

            dt = new DataTable();
            DataRow Dr = dt.NewRow();
            DataRow R_Totales = dt.NewRow();
            dginforme.DataSource = null;
            dginforme.Columns.Clear();
            dginforme.Rows.Clear();

            //CREAMOS LA TABLA EN MEMORIA
            dt.Columns.Add("id_Grupo");
            dt.Columns.Add("Nombre");
            dt.Columns.Add("id_tipo");
            dt.Columns.Add("Presupuestado", Type.GetType("System.Double"));
            List<Grupos> Grups = GruposCN.Listar_solocontabilidad();
         
            foreach (Grupos Grup in Grups.OrderBy(p=> p.Id_TipoCoste))
            {
                Dr = dt.NewRow();
                Dr["id_Grupo"] = Grup.Id_Grupo;
                Dr["id_tipo"] = Grup.Id_TipoCoste ;

                Dr["Nombre"] = Grup.Nombre;
                if (Emp.Obras.Where(p => p.Id_Obra == Obrsel.Id_Obra).ToList().Count > 0)
                {
                    Dr["Presupuestado"] = (Emp.Obras.Where(p => p.Id_Obra == Obrsel.Id_Obra).ToList()[0].Presu_Conta.Where(p => p.id_Grupo == Grup.Id_Grupo).ToList().Count > 0) ?  Emp.Obras.Where(p => p.Id_Obra == Obrsel.Id_Obra).ToList()[0].Presu_Conta.Where(p => p.id_Grupo == Grup.Id_Grupo).ToList()[0].Presupuestado : 0;    
                }
                else
                {
                    Dr["Presupuestado"] = 0;
                }
                dt.Rows.Add(Dr);      
            }
            dginforme.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Obrsel = Emp.Obras.Where(t => Obras_Selecionadas_int().Contains(t.Id_Obra)).ToList()[0];         
            Creagrid();
            pderecha.Visible = true;
            pgeneral.ColumnStyles[0].Width = 0;
            txtinfo.Text = "Presupuesto de Ingresos";
            Grid_diseño();
        }
        public List<int> Obras_Selecionadas_int()
        {
            List<int> l = new List<int>();
            foreach (object item in listObras.SelectedItems)
            {
                l.Add(((Obras)item).Id_Obra);
            }
            return l;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pgeneral.ColumnStyles[0].Width = 200;
            pderecha.Visible = false;
        }
        public void Grid_diseño()
        {
            foreach (DataGridViewColumn Col in dginforme.Columns)
            {
                if (Col.ValueType.Name == "Double" || Col.ValueType.Name == "Decimal")
                {
                    Col.Width = 100;
                    Col.DefaultCellStyle.Format = "#,0.###";
                    Col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
            }
            dginforme.Columns["Nombre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            dginforme.Columns["Nombre"].Width = 200;
            dginforme.Columns["id_Grupo"].Visible = false;
            dginforme.Columns["id_tipo"].Visible = false;

            foreach (DataGridViewRow Row in dginforme.Rows)
            {

                if (Convert.ToInt32(Row.Cells["Id_Tipo"].Value) == 1 || Convert.ToInt32(Row.Cells["Id_Tipo"].Value) == 7)
                {
                    Row.DefaultCellStyle.ForeColor = Color.Blue;
                    Row.DefaultCellStyle.BackColor = Color.WhiteSmoke;
                    Row.DefaultCellStyle.Font = new Font(dginforme.Font, FontStyle.Bold);
                }
                if (Convert.ToInt32(Row.Cells["Id_Tipo"].Value) == 2)
                {
                    Row.DefaultCellStyle.ForeColor = Color.Firebrick;
                    Row.DefaultCellStyle.BackColor = Color.WhiteSmoke;
                    Row.DefaultCellStyle.Font = new Font(dginforme.Font, FontStyle.Bold);
                }
                if (Convert.ToInt32(Row.Cells["Id_Tipo"].Value) == 3)
                {
                    Row.DefaultCellStyle.ForeColor = Color.Firebrick;
                    Row.DefaultCellStyle.BackColor = Color.WhiteSmoke;
                    Row.DefaultCellStyle.Font = new Font(dginforme.Font, FontStyle.Bold);
                }
                ////if ((Row.Index % 2) == 0) Row.DefaultCellStyle.BackColor = Color.WhiteSmoke;

                ////if (Row.Cells["Obra"].Value.ToString() == "TOTALES")
                ////{
                ////    Row.DefaultCellStyle.BackColor = Color.LightSteelBlue;
                ////    Row.DefaultCellStyle.Font = new Font(dginforme.Font, FontStyle.Bold);
                ////}

                //foreach (DataGridViewCell Cell in Row.Cells)
                //{
                //    if (Cell.ValueType.Name == "Double" || Cell.ValueType.Name == "Decimal")
                //    {
                //        if (Cell.Value == DBNull.Value) continue;
                //    }      

                //}

            }
        }

        private void dginforme_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            Presu_ContaCN.Añadir_Presu(Obrsel, Convert.ToInt32(dginforme["id_Grupo", e.RowIndex].Value), Convert.ToDecimal(dginforme["Presupuestado", e.RowIndex].Value));          
        }

        private void dginforme_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            string name = null;
            name = dginforme.Columns[e.ColumnIndex].Name;
            if (name == "Presupuestado")
            { 
                try         
                {
                    // Valor actual de la celda 
                    string value = dginforme.CurrentCell.EditedFormattedValue.ToString();
                    // Reemplazamos el punto por la coma decimal. 
                    value = value.Replace(".", ",");
                    // Escribimos el nuevo valor. 
                    decimal cellValue = Convert.ToDecimal(value);
                    dginforme.CurrentCell.Value = cellValue;
                }
                catch (Exception ex)
                {
                }

            }
        }
    }
}
