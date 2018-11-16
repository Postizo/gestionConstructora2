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
using System.Globalization;

namespace GestionConstructora
{
    public partial class Form_FacturasCapitulos : Form
    {
        Obras Obr = new Obras();
        DataTable Dt = new DataTable();

        public Form_FacturasCapitulos(DataTable dt,bool apuntes)
        {
            InitializeComponent();
            Dt = dt;
            if (apuntes)
            {
                dglineas.Visible = true;
                dgcontabilidad.Visible = false;
                suma();
                dglineas.DataSource = Dt;
                Grid_diseño();
            } 
            else
            {
                dglineas.Visible = false;
                dgcontabilidad.Visible = true;
                dgcontabilidad.DataSource = Dt;
            }
         
            this.Text = "Apuntes";       
        }
        public void suma()
        {
            DataRow dr;
            decimal sumdebe = 0;
            decimal sumhaber =0;
            foreach (DataRow row in Dt.Rows)
            {
                sumdebe += (row["Debe"].ToString() != "") ? Convert.ToDecimal(row["Debe"]):0;
                sumhaber += (row["Haber"].ToString() !="")? Convert.ToDecimal(row["Haber"]):0;
            }
            dr = Dt.NewRow();
            dr["Descripcion"] = "Totales";
            dr["debe"] = sumdebe;
            dr["haber"] = sumhaber;
            Dt.Rows.Add(dr);
            string specifier = "N";
            CultureInfo culture = CultureInfo.CreateSpecificCulture("es-ES");

            lsadlo.Text = (sumdebe - sumhaber).ToString(specifier, culture);
           


        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            string Title = "" ;
            ContaWIN.M_PrintDGV.Print_DataGridView(dglineas, Title, true, false, true, false);
        }
        public void Grid_diseño()
        {
            foreach (DataGridViewRow row in dglineas.Rows)
            {
              if (row.Index == dglineas.Rows.Count - 1)
                {
                    row.DefaultCellStyle.Font = new Font(Font.FontFamily, 14);
                    row.DefaultCellStyle.BackColor = Color.LightBlue;
                }
           
            }
            foreach (DataGridViewColumn Col in dglineas.Columns)
            {
                if (Col.ValueType.Name == "Double" || Col.ValueType.Name == "Decimal")
                {
                    Col.Width = 100;
                    Col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
            }


            try
            {
                dglineas.Columns["Fecha"].Width = 100;
                dglineas.Columns["Asiento"].Width = 90;
                dglineas.Columns["Cuenta"].Width = 100;
                dglineas.Columns["Descripcion"].Width = 320;
                dglineas.Columns["debe"].DefaultCellStyle.Format = "#,0";
                dglineas.Columns["haber"].DefaultCellStyle.Format = "#,0";
                dglineas.Refresh();
            }
            catch (Exception)
            {

               
            }
            try
            {
                dglineas.Columns["Cuenta"].Width = 100;
                dglineas.Columns["Fecha"].Width = 90;
                dglineas.Columns["Descripcion"].Width = 380;
              
                dglineas.Columns["Debe"].DefaultCellStyle.Format = "#,0";
                dglineas.Columns["Haber"].DefaultCellStyle.Format = "#,0";
                dglineas.Refresh();
            }
            catch (Exception)
            {


            }




        }

        private void Form_FacturasCapitulos_Load(object sender, EventArgs e)
        {
          //  Grid_diseño();
        }
    }
}
