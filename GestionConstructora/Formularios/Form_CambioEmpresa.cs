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
    public partial class Form_CambioEmpresa : Form
    {
        public Empresas Empresa { get; set; }    
        public Form_CambioEmpresa()
        {
            InitializeComponent();
            DiseñoGrid();
            dgempresas.DataSource = EmpresasCN.Listar();
        }
        public void DiseñoGrid()
        {
            dgempresas.AutoGenerateColumns = false;
            dgempresas.EnableHeadersVisualStyles = false;
            dgempresas.ColumnHeadersDefaultCellStyle.BackColor = Color.AliceBlue;
            dgempresas.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgempresas.ColumnHeadersDefaultCellStyle.Font = new Font(FontFamily.GenericSansSerif, 9.0F, FontStyle.Bold);
            foreach (DataGridViewColumn col in dgempresas.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.Programmatic;
            }
        }

        private void dgempresas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Empresa = EmpresasCN.Listar(Convert.ToInt32(dgempresas["Id_empresa", e.RowIndex].Value));
            if(Empresa != null) this.Close();
        }
    }
}
