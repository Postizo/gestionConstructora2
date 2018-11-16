using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio;
using Entidad;
using System.Reflection;

namespace GestionConstructora
{
    public partial class Form_Buscador : Form
    {
        Empresas Emp = new Empresas();
    
        public Form_Buscador(Empresas Empresa)
        {
            InitializeComponent();
            Emp = Empresa;
            Diseño_form();
       
        }
        public void Diseño_form()
        {
            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic |
            BindingFlags.Instance | BindingFlags.SetProperty, null,
            dglineas, new object[] { true });        
            dglineas.AutoGenerateColumns = false;
            dglineas.EnableHeadersVisualStyles = false;
            dglineas.ColumnHeadersDefaultCellStyle.BackColor = Color.AliceBlue;
            dglineas.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dglineas.ColumnHeadersDefaultCellStyle.Font = new Font(FontFamily.GenericSansSerif, 8.0F, FontStyle.Bold);

            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic |
         BindingFlags.Instance | BindingFlags.SetProperty, null,
         dgdesglose, new object[] { true });
            dgdesglose.AutoGenerateColumns = false;
            dgdesglose.EnableHeadersVisualStyles = false;
            dgdesglose.ColumnHeadersDefaultCellStyle.BackColor = Color.AliceBlue;
            dgdesglose.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgdesglose.ColumnHeadersDefaultCellStyle.Font = new Font(FontFamily.GenericSansSerif, 8.0F, FontStyle.Bold);
        }
        private void button1_Click(object sender, EventArgs e)
        {
          dglineas.DataSource =   BuscadorCn.ListarProductos(Emp, txtbuscar.Text);
        }

        private void dglineas_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int id_pro;
            id_pro = Convert.ToInt32(dglineas.Rows[e.RowIndex].Cells["ide_pro"].Value);
            dgdesglose.DataSource = BuscadorCn.ListarPDocumentis(Emp, id_pro);
        }
    }
}
