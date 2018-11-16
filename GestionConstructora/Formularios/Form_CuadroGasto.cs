using Entidad;
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

namespace GestionConstructora
{
    public partial class Form_CuadroGasto : Form
    {
        Empresas Emp = new Empresas();
        DataTable dt = new DataTable();
        public Form_CuadroGasto(Empresas emp)
        {
            InitializeComponent();
            Emp = emp;
            DiseñoGrid();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pderecha.Visible = true;
            List<Obras> L_Obras_Selecionadas = Emp.Obras.Where(t => Obras_Selecionadas_int().Contains(t.Id_Obra)).ToList();
            CreaCuadro(L_Obras_Selecionadas);
            pgeneral.ColumnStyles[0].Width = 0;
            txtinfo.Text = "Inicio: " + finicio.Value.ToShortDateString() + " \n" + "Fin: " + finicio.Value.ToShortDateString();
            Grid_diseño();
        }
        private void Acumulado()
        {
            
        }
        private void CreaCuadro(List<Obras> Obrs)
        {
            //Limpiamos 

            dt = new DataTable();
            DataRow Dr = dt.NewRow();
            DataRow R_Totales = dt.NewRow();
            dginforme.DataSource = null;
            dginforme.Columns.Clear();
            dginforme.Rows.Clear();
            
            //CREAMOS LA TABLA EN MEMORIA
            dt.Columns.Add("Obra");
            DateTime Fbucle = finicio.Value;
            while (Fbucle < ffin.Value)
            {
                dt.Columns.Add(Fbucle.ToShortDateString(), Type.GetType("System.Double"));
                Fbucle = Fbucle.AddDays(1);
            }

            foreach (Obras Obr in Obrs)
            {
                Dr = dt.NewRow();
                Dr["Obra"] = Obr.Nombre;
                Fbucle = finicio.Value;
                while (Fbucle < ffin.Value)
                {
                    Dr[Fbucle.ToShortDateString()] =Obr.Facturas_ca.Where(p=> p.Estado == 0).Where(p=>p.FechaPago !=null). Where(p =>  p.FechaPago.Value == Fbucle.Date).Sum(p => p.TotImporte);
                    Fbucle = Fbucle.AddDays(1);
                }
                dt.Rows.Add(Dr); 
            }
            Dr = dt.NewRow();
            Dr["Obra"] = "TOTALES";
            Fbucle = finicio.Value;
            while (Fbucle < ffin.Value)
            {
                double suma = 0;
                foreach (DataRow row in dt.Rows)
                {    
                     suma += Convert.ToDouble(row[Fbucle.ToShortDateString()]);
                }
                Dr[Fbucle.ToShortDateString()] = suma;
                Fbucle = Fbucle.AddDays(1);
            }
            dt.Rows.Add(Dr);


            dginforme.DataSource = dt;
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
                    Col.DefaultCellStyle.Format = "#,0";
                    Col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
            }
            dginforme.Columns["Obra"].AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            dginforme.Columns["Obra"].Width = 200;


            foreach (DataGridViewRow Row in dginforme.Rows)
            {
                if ((Row.Index % 2) == 0) Row.DefaultCellStyle.BackColor = Color.WhiteSmoke;

                if (Row.Cells["Obra"].Value.ToString() == "TOTALES")
                {
                    Row.DefaultCellStyle.BackColor = Color.LightSteelBlue;
                    Row.DefaultCellStyle.Font = new Font(dginforme.Font, FontStyle.Bold);
                }
                               
                //foreach (DataGridViewCell Cell in Row.Cells)
                //{
                //    if (Cell.ValueType.Name == "Double" || Cell.ValueType.Name == "Decimal")
                //    {
                //        if (Cell.Value == DBNull.Value) continue;    
                   
                //}

            }
        }
    }
}
