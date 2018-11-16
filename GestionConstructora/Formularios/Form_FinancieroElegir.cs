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
using Negocio.Presupuestos;
using System.Reflection;
using Negocio;

namespace GestionConstructora
{
    public partial class Form_FinancieroElegir : Form
    {
        Est_Financiero Estudiselec; 
        public Form_FinancieroElegir()
        {            
            InitializeComponent();          
            Diseño_form();
            CargaIni();
        }
        

        public void CargaIni()
        {
            dgpresu.DataSource = Est_FinancieroCN.Listar();
        }
              
        public void Diseño_form()
        {
            dgpresu.AutoGenerateColumns = false;
            dgpresu.EnableHeadersVisualStyles = false;
            dgpresu.ColumnHeadersDefaultCellStyle.BackColor = Color.Honeydew;
            dgpresu.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgpresu.ColumnHeadersDefaultCellStyle.Font = new Font(FontFamily.GenericSansSerif, 9.0F, FontStyle.Bold);

            dgpresu.AutoGenerateColumns = false;
            dgpresu.EnableHeadersVisualStyles = false;
            dgpresu.ColumnHeadersDefaultCellStyle.BackColor = Color.Honeydew;
            dgpresu.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgpresu.ColumnHeadersDefaultCellStyle.Font = new Font(FontFamily.GenericSansSerif, 9.0F, FontStyle.Bold);
        }      
        

        private void dgpresu_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            Estudiselec = Est_FinancieroCN.Listar(Convert.ToInt32(dgpresu.CurrentRow.Cells["id_Estudio"].Value));         
            Form_Financiero f = new Form_Financiero(Estudiselec);
            f.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtnombre.Text == "")
            {
                MessageBox.Show("Introduce un nombre");
                return;
            }
            Form_Financiero f = new Form_Financiero(txtnombre.Text);
            f.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Est_FinancieroCN.Borrar(Convert.ToInt32(dgpresu.CurrentRow.Cells["id_Estudio"].Value));
            CargaIni();
        }
    }     
}
