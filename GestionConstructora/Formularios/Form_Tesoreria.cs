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
using Negocio; 
namespace GestionConstructora
{
    public partial class Form_Tesoreria : Form
    {
        DataTable dtinforme = new DataTable();
        DataTable dtcuentas = new DataTable();
        DataTable dtmovimientos = new DataTable();
        Empresas Emp;
        public Form_Tesoreria(Empresas Empresa)
        {
            Emp = Empresa;
            InitializeComponent();
            prepara();
        }
        public void  prepara()
        {
            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic |
               BindingFlags.Instance | BindingFlags.SetProperty, null,
               dginformes, new object[] { true });
            
            dginformes.AutoGenerateColumns = false;
            dginformes.EnableHeadersVisualStyles = false;
            dginformes.ColumnHeadersDefaultCellStyle.BackColor = Color.AliceBlue;
            dginformes.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dginformes.ColumnHeadersDefaultCellStyle.Font = new Font(FontFamily.GenericSansSerif, 9.0F, FontStyle.Bold);

            dginformes.AutoGenerateColumns = false;
            dginformes.EnableHeadersVisualStyles = false;
            dginformes.ColumnHeadersDefaultCellStyle.BackColor = Color.AliceBlue;
            dginformes.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dginformes.ColumnHeadersDefaultCellStyle.Font = new Font(FontFamily.GenericSansSerif, 9.0F, FontStyle.Bold);

            dggastosfijos.AutoGenerateColumns = false;
            dggastosfijos.EnableHeadersVisualStyles = false;
            dggastosfijos.ColumnHeadersDefaultCellStyle.BackColor = Color.AliceBlue;
            dggastosfijos.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dggastosfijos.ColumnHeadersDefaultCellStyle.Font = new Font(FontFamily.GenericSansSerif, 9.0F, FontStyle.Bold);



            dtinforme.Columns.Add("Fecha");
            dtinforme.Columns.Add("Diasemana");   
            dtinforme.Columns.Add("Gastos", Type.GetType("System.Decimal"));
            dtinforme.Columns.Add("Ingresos", Type.GetType("System.Decimal"));
            dtinforme.Columns.Add("Saldo", Type.GetType("System.Decimal"));

            dgcuentas.AutoGenerateColumns = false;

            cbmeses.SelectedIndex = DateTime.Today.Month - 1; 
            dtcuentas = BancosCN.TraeCuentas(Emp); 
            dgcuentas.DataSource = dtcuentas;
            dggastosfijos.DataSource = GastosFijosCN.Listar(Emp.Id_Empresa,cbmeses.SelectedIndex+1);
       

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Genbera_Informe();
        }
        public void Genbera_Informe()
        {
            dtinforme.Rows.Clear();
            DateTime Fecharecorre = DateTime.Today;
            double Sald = 0;
            foreach (DataRow dr in dtcuentas.Rows)
            {
                Sald +=  BancosCN.SP_SaldoBanco(Emp, dr["cta"].ToString() ,Convert.ToDateTime(DateTime.Today.ToShortDateString()));
            }
            
            while (Fecharecorre < Convert.ToDateTime(ffin.Value.ToShortDateString()))
            {
               DataRow  Fila = dtinforme.NewRow();
               Fila["Fecha"] = Fecharecorre.ToShortDateString();
               Fila["Diasemana"] = Fecharecorre.DayOfWeek;
               Fila["Saldo"] = Sald; //Funcion trae saldo;
               decimal d = Emp.Obras.Sum(p => p.Facturas_ca.Where(a => a.FechaPago == Fecharecorre).Sum(a => a.TotImporte));
                d += GastosFijosCN.ListarImporte(Emp.Id_Empresa, Fecharecorre);
               Fila["Gastos"] = d ;
               Fila["Ingresos"] = 0;
               dtinforme.Rows.Add(Fila);
               Fecharecorre = Fecharecorre.AddDays(1);
             }

            if (dtinforme.Rows.Count > 0)
            {
                for (int i = 0; i < dtinforme.Rows.Count; i++)
                {
                    double saldo;
                    if (i == 0) {
                        saldo = Convert.ToDouble(dtinforme.Rows[i]["Saldo"]);
                    }
                    else { saldo = Convert.ToDouble(dtinforme.Rows[i-1]["Saldo"]); }
                    double ingresos = Convert.ToDouble(dtinforme.Rows[i]["Ingresos"]);
                    double gastos = Convert.ToDouble(dtinforme.Rows[i]["Gastos"]);
                    saldo = saldo + ingresos;
                    saldo = saldo - gastos;
                    dtinforme.Rows[i]["Saldo"] = saldo ;
                }
            }
            dginformes.DataSource = dtinforme;
            grid_diseño();
        }
        public void grid_diseño()
        {
            dginformes.Columns["Ingresos"].DefaultCellStyle.ForeColor = Color.Green;
            dginformes.Columns["Gastos"].DefaultCellStyle.ForeColor = Color.Red;


        }

        private void button2_Click(object sender, EventArgs e)
        {
            dtmovimientos.Rows.Clear();
            DateTime Fecharecorre = DateTime.Today;
            double Sald = 0;
            foreach (DataRow dr in dtcuentas.Rows)
            {
                Sald += BancosCN.SP_SaldoBanco(Emp, dr["cta"].ToString(), Convert.ToDateTime(finimovi.Value.ToShortDateString()));
            }

            dtmovimientos = BancosCN.Movimientos_Bancos(Emp, Convert.ToDateTime(finimovi.Value.ToShortDateString()), Convert.ToDateTime(ffinmovi.Value.ToShortDateString()));
          

            if (dtmovimientos.Rows.Count > 0)
            {
                dtmovimientos.Rows[0]["Saldo"] = Sald;
                for (int i = 0; i < dtmovimientos.Rows.Count; i++)
                {
                    double saldo;
                    if (i == 0)
                    {
                        saldo = Convert.ToDouble(dtmovimientos.Rows[i]["Saldo"]);
                    }
                    else { saldo = Convert.ToDouble(dtmovimientos.Rows[i - 1]["Saldo"]); }
                    double ingresos = Convert.ToDouble(dtmovimientos.Rows[i]["Haber"]);
                    double gastos = Convert.ToDouble(dtmovimientos.Rows[i]["Debe"]);
                    saldo = saldo + ingresos;
                    saldo = saldo - gastos;
                    dtmovimientos.Rows[i]["Saldo"] = saldo;
                }
            }
            dgmovimientos.DataSource = dtmovimientos;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtimporte.Text = txtimporte.Text.Replace(".", ",");
            decimal n; bool isNumeric = decimal.TryParse(txtimporte.Text, out n);
            if (!isNumeric) return;
            GastosFijosCN.Añadir(Emp.Id_Empresa, fagregar.Value, Convert.ToDecimal(txtimporte.Text), cbconcepto.Text);
            dggastosfijos.DataSource = GastosFijosCN.Listar(Emp.Id_Empresa, cbmeses.SelectedIndex +1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dggastosfijos.SelectedRows.Count < 0) return;
            GastosFijosCN.Borrar(Convert.ToInt32(dggastosfijos.SelectedRows[0].Cells["orden"].Value));
            dggastosfijos.DataSource = GastosFijosCN.Listar(Emp.Id_Empresa, cbmeses.SelectedIndex+1);
        }

        private void txtimporte_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void cbmeses_SelectionChangeCommitted(object sender, EventArgs e)
        {
            dggastosfijos.DataSource = GastosFijosCN.Listar(Emp.Id_Empresa, cbmeses.SelectedIndex + 1);
        }
    }
}
