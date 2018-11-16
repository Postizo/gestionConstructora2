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
using Negocio;
using Entidad;
using ContaWIN;

namespace GestionConstructora
{
    public partial class Form_SaldoProveedores : Form
    {
        DataTable dtproveedores = new DataTable();
        Empresas Emp = new Empresas();

        public Form_SaldoProveedores(Empresas Empresa)
        {
            Emp = Empresa;
            InitializeComponent();
            PreparaTabla();
            this.Cursor = Cursors.WaitCursor;
            Cargar(dtproveedores,Emp,textBox1.Text, dgproveedores,-1,0,12);
            this.Cursor = Cursors.Default;
        }
        public void  DiseñoGrid()
        {
            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic |
             BindingFlags.Instance | BindingFlags.SetProperty, null,
             dgproveedores , new object[] { true });
          
            dgproveedores.AutoGenerateColumns = false;
            dgproveedores.EnableHeadersVisualStyles = false;
            dgproveedores.ColumnHeadersDefaultCellStyle.BackColor = Color.AliceBlue;
            dgproveedores.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgproveedores.ColumnHeadersDefaultCellStyle.Font = new Font(FontFamily.GenericSansSerif, 9.0F, FontStyle.Bold);
        }
        public static void PreparaTabla()
        {            
           
        }
        public static void Cargar(DataTable dtproveedores,Empresas Emp,string cuenta,DataGridView dgproveedores,int canal,int  mesinicial, int mesfinal)
        {
            
            dtproveedores.Rows.Clear();
            dtproveedores = CalculoCN.Cuentas_Proveer(Emp, cuenta,canal);
            dtproveedores.Columns.Add("Saldo", Type.GetType("System.Double"));
            List<DataRow> drs = new List<DataRow>();
            foreach (DataRow Row in dtproveedores.Rows)
            {
                M_Contawin Conta = new M_Contawin(Emp.CNNWIN);
                Row["Saldo"] =  Conta.CW_ConsultaSaldo(Row["Cuenta"].ToString(),DateTime.Today.Year,0, mesinicial, mesfinal, "0",canal);
                if (Convert.ToDouble(Row["Saldo"]) == 0) drs.Add(Row);
            }
            foreach (DataRow Row in drs)
            {
                dtproveedores.Rows.Remove(Row);
            }
            Form_Caja.AgregaTotales(dtproveedores, 0);          
            dgproveedores.DataSource = dtproveedores;
          
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cargar(dtproveedores,Emp,textBox1.Text, dgproveedores,-1,0,12);
            Form_Caja.Grid_Diseño(dgproveedores, this.Font);
        }

        private void dgproveedores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgproveedores_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataTable dtextracto = new DataTable();
            string cuenta = dgproveedores["Cuentas", e.RowIndex].Value.ToString();
            dtextracto = CalculoCN.Extracto_cuenta(Emp, cuenta, DateTime.Today.Year);
            Form_FacturasCapitulos f = new Form_FacturasCapitulos(dtextracto,true);
            f.ShowDialog();
        }

        private void Form_SaldoProveedores_Load(object sender, EventArgs e)
        {
            Form_Caja.Grid_Diseño(dgproveedores, this.Font);
        }
    }
}
