using Entidad;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionConstructora
{
    public partial class Form_Puertas : Form
    {
        DataTable dtimportar = new DataTable();
        Empresas Emp = new Empresas();
        DataTable dtcolectivo = new DataTable();
        public Form_Puertas(Empresas Empresa)
        {        
            Emp = Empresa;
            InitializeComponent();
            ini();
        }
        public void ini()
        {
            cbusuarios.DataSource = PuertasCN.Listar_usuarios ();
            cbusuarios.DisplayMember = "nombre";
            cbusuarios.ValueMember = "id_user";

            dinformecolectivo.Size = dginforme.Size;
            dinformecolectivo.Location = dginforme.Location;
            dginforme.Visible = false;

            dginforme.AutoGenerateColumns = false;
            dginforme.EnableHeadersVisualStyles = false;
            dginforme.ColumnHeadersDefaultCellStyle.BackColor = Color.AliceBlue;
            dginforme.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dginforme.ColumnHeadersDefaultCellStyle.Font = new Font(FontFamily.GenericSansSerif, 9.0F, FontStyle.Bold);

            dinformecolectivo.AutoGenerateColumns = false;
            dinformecolectivo.EnableHeadersVisualStyles = false;
            dinformecolectivo.ColumnHeadersDefaultCellStyle.BackColor = Color.AliceBlue;
            dinformecolectivo.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dinformecolectivo.ColumnHeadersDefaultCellStyle.Font = new Font(FontFamily.GenericSansSerif, 9.0F, FontStyle.Bold);

        }
        private void button1_Click(object sender, EventArgs e)
        {
            dtimportar = new DataTable();
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
                    txtbuscar.Text = fileName;
                }
            }
            
            if (fileName != null)
            {
                //Do something with the file, for example read text from drr
                string text = File.ReadAllText(fileName);
                dtimportar = GetDataTableFromCsv(fileName, true);
                DataRow drr = CalculoCN.Fecha_Ultima(Emp);
                DateTime Fechaultima = Convert.ToDateTime(Convert.ToDateTime(drr[0].ToString()).ToShortDateString() + ' ' + Convert.ToDateTime(drr[1].ToString()).ToShortTimeString());
                quitafechaanteriores(Fechaultima);
                CalculoCN.Insertar_Puertas(Emp, dtimportar);
                dginforme.DataSource = dtimportar;
                MessageBox.Show("Proceso Importacion Correcto", "Aviso");
            }
        }
        static DataTable GetDataTableFromCsv(string path, bool isFirstRowHeader)
        {
            string header = isFirstRowHeader ? "Yes" : "No";
            string pathOnly = Path.GetDirectoryName(path);
            string fileName = Path.GetFileName(path);
            string sql = @"SELECT * FROM [" + fileName + "]";

            using (OleDbConnection connection = new OleDbConnection(
                      @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + pathOnly +
                      ";Extended Properties=\"Text;HDR=" + header + "\""))
            using (OleDbCommand command = new OleDbCommand(sql, connection))
            using (OleDbDataAdapter adapter = new OleDbDataAdapter(command))
            {
                DataTable dataTable = new DataTable();
                dataTable.Locale = CultureInfo.CurrentCulture;
                adapter.Fill(dataTable);
                return dataTable;
            }
        }
        public void quitafechaanteriores(DateTime FechaUltima)
        {
            
            for (int i = dtimportar.Rows.Count - 1; i >= 0; i--)
            {
                DateTime fecha = Convert.ToDateTime(Convert.ToDateTime(dtimportar.Rows[i][0].ToString()).ToShortDateString() + ' ' + Convert.ToDateTime(dtimportar.Rows[i][1].ToString()).ToShortTimeString());
                if (fecha <= FechaUltima)
                {
                    DataRow dr = dtimportar.Rows[i];
                    dr.Delete();
                }
                else
                {
                    Console.WriteLine("");
                }
            }
            dtimportar.AcceptChanges();  
        }

        private void cbusuarios_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (rbindividual.Checked) { Individual(); } else { Colectivo(); }
        }

        private void fini_ValueChanged(object sender, EventArgs e)
        {
            if (rbindividual.Checked) { Individual(); } else { Colectivo(); }          
        }
        public void Individual()
        {
            dinformecolectivo.Visible = false;
            dginforme.Visible = true;

            List<Puertas> a = PuertasCN.Listar_accesos(Convert.ToInt32(cbusuarios.SelectedValue), Convert.ToDateTime(fini.Value.ToShortDateString())); ;
            dginforme.DataSource = a;
        }
        public void Colectivo()
        {
            dinformecolectivo.Visible = true;
            dginforme.Visible = false;          
            dinformecolectivo.DataSource = PuertasCN.Listar_accesosColectivos(Convert.ToDateTime(fini.Value.ToShortDateString()));
        }

        private void rbtodos_CheckedChanged(object sender, EventArgs e)
        {
            if (rbindividual.Checked) { Individual(); } else { Colectivo(); }
        }
    }
}
