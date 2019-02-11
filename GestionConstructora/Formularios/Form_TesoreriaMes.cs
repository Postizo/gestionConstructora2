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
    public partial class Form_TesoreriaMes : Form
    {
        Est_Tesoreria Tesoreria;
        DataTable Dtprincipal = new DataTable();
        public Form_TesoreriaMes(Est_Tesoreria Tesoreri)
        {
            InitializeComponent();              
            Tesoreria = Tesoreri;
            Preparatabla();
          
            dgmeses.DataSource = Dtprincipal;
          
        }
        public void Diseño_form()
        {
            dgmeses.AutoGenerateColumns = false;
            dgmeses.EnableHeadersVisualStyles = false;
            dgmeses.ColumnHeadersDefaultCellStyle.BackColor = Color.Honeydew;
            dgmeses.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgmeses.ColumnHeadersDefaultCellStyle.Font = new Font(FontFamily.GenericSansSerif, 9.0F, FontStyle.Bold);

        }
        public void Preparatabla()
        {
            Dtprincipal.Columns.Add("id");
            Dtprincipal.Columns.Add("id_Tesoreria");
            Dtprincipal.Columns.Add("mes");
            Dtprincipal.Columns.Add("año");
            Dtprincipal.Columns.Add("MesAño");
            Dtprincipal.Columns.Add("Importe", Type.GetType("System.Double"));

            int Meses = Publico.GetMonthDifference(Tesoreria.finicioprevisto, Tesoreria.ffin);
            for (int i = 0; i < Meses; i++)
            {
                DataRow Dr = Dtprincipal.NewRow();
                DateTime FechaBucle = Tesoreria.finicioprevisto.AddMonths(i);
                Dr["id_Tesoreria"] = Tesoreria.Id_tesoreria;
                Dr["mes"] = FechaBucle.Month;
                Dr["año"] = FechaBucle.Year;
                Dr["MesAño"] = Publico.MonthName(FechaBucle.Month).ToUpper() + "  " + FechaBucle.Year.ToString();
                Dr["id"] = 0;
                Dr["Importe"] = 0;
                Est_TesoreriaMes DatosMes = (Tesoreria.Est_TesoreriaMes.Where(p => p.mes == FechaBucle.Month && p.año == FechaBucle.Year).Count() > 0) ? Tesoreria.Est_TesoreriaMes.Where(p => p.mes == FechaBucle.Month && p.año == FechaBucle.Year).ToList()[0] : null;
                if (DatosMes != null)
                {
                    Dr["id"] = DatosMes.id;
                    Dr["Importe"] = DatosMes.importe;
                }
                Dtprincipal.Rows.Add(Dr);
            }
            DataRow Dtotales = Dtprincipal.NewRow();
            Dtotales["id_Tesoreria"] = Tesoreria.Id_tesoreria;
            Dtotales["mes"] = 0;
            Dtotales["año"] = 0;
            Dtotales["id"] = 0;

            Dtotales["MesAño"] = "TOTAL";
            Dtotales["Importe"] = 0;
            Dtprincipal.Rows.Add(Dtotales);
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Est_TesoreriaCN.BorrarMeses(Tesoreria.Id_tesoreria);
            foreach (DataGridViewRow Row in dgmeses.Rows)
            {
                if (Convert.ToDecimal(Row.Cells["dcimporte"].Value.ToString()) == 0 || Row.Cells["dcMesAño"].Value.ToString() == "TOTAL") continue;
                Est_TesoreriaMes Mes = new Est_TesoreriaMes();
                Mes.id_tesoreria = Convert.ToInt32(Row.Cells["dcidtesoreria"].Value.ToString());             
                Mes.mes = Convert.ToInt32(Row.Cells["dcmes"].Value.ToString());
                Mes.año = Convert.ToInt32(Row.Cells["dcaño"].Value.ToString());
                Mes.nombre = Row.Cells["dcMesAño"].Value.ToString();
                Mes.importe = Convert.ToDecimal(Row.Cells["dcimporte"].Value.ToString());
                Est_TesoreriaCN.AñadirMes(Mes);
            }

            this.Close();
        }
        public void CalcularTotal()
        {
            decimal Suma = 0;
            foreach (DataGridViewRow Row in dgmeses.Rows)
            {
                if (Row.Cells["dcMesAño"].Value.ToString() == "TOTAL") continue;
                Suma += Convert.ToDecimal(Row.Cells["dcimporte"].Value.ToString());
            }
            try { dgmeses["dcimporte", dgmeses.Rows.Count - 1].Value = Suma; }catch (Exception){ }

            foreach (DataGridViewRow Row in dgmeses.Rows)
            {
                if (Row.Cells["dcMesAño"].Value.ToString() != "TOTAL") if (Convert.ToInt32(Row.Cells["dcaño"].Value) < DateTime.Today.Year || Convert.ToInt32(Row.Cells["dcmes"].Value) < DateTime.Today.Month && Convert.ToInt32(Row.Cells["dcaño"].Value) == DateTime.Today.Year) Row.DefaultCellStyle.ForeColor = Color.Red;
                if (Row.Cells["dcMesAño"].Value.ToString() == "TOTAL") Row.DefaultCellStyle.BackColor = Color.Gray;
                
            }
           
            dgmeses.Refresh();
        }


        private void dgmeses_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            CalcularTotal();
        }

        private void Form_TesoreriaMes_Load(object sender, EventArgs e)
        {
            CalcularTotal();
        }
    }
}

