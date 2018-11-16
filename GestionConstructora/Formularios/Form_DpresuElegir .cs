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
    public partial class Form_DpresuElegir : Form
    {
        D_Presuca Presuselect; 
        public Form_DpresuElegir()
        {            
            InitializeComponent();          
            Diseño_form();
            CargaIni();
        }
        

        public void CargaIni()
        {
            dgpresu.DataSource = DEquiposCN.ListarPresu();
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
            Presuselect = DEquiposCN.ListarPresu(Convert.ToInt32(dgpresu.CurrentRow.Cells["id_presu"].Value));         
            Form_Dpresu f = new Form_Dpresu(Presuselect);
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
            Presuselect =  DEquiposCN.AñadirPresucabecera(txtnombre.Text);
            DEquiposCN.AñadirLineas(Presuselect.id_presu, "--DISEÑO--", 0, 0, 0, 0,"");
            Form_Dpresu f = new Form_Dpresu(Presuselect);
            f.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult ms = MessageBox.Show("Se borarra el presupuesto seleccionado, ¿Desea continuar?","Advertecia",MessageBoxButtons.OKCancel);

            if (ms == DialogResult.OK)
            {
                DEquiposCN.BorrarPresu(Convert.ToInt32(dgpresu.CurrentRow.Cells["id_presu"].Value));
                CargaIni();
            }
         
        }
    }     
}
