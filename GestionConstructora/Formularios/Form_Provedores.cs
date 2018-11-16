using Entidad;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionConstructora
{
    public partial class Form_Provedores : Form
    {
        List<Empresas> LEmpresas = new List<Empresas>();
        DataTable dtgastosporproveedor = new DataTable();
        public Form_Provedores()
        {
            InitializeComponent();
         
            Diseño_form();
            dgempresas.DataSource = EmpresasCN.Listar();
        }
        public void Diseño_form()
        {
            dtgastosporproveedor.Columns.Add("id_Proveedor");
            dtgastosporproveedor.Columns.Add("Proveedor");
            dtgastosporproveedor.Columns.Add("Importe", Type.GetType("System.Double"));


            dgempresas.AutoGenerateColumns = false;
            dgempresas.EnableHeadersVisualStyles = false;
            dgempresas.ColumnHeadersDefaultCellStyle.BackColor = Color.Honeydew;
            dgempresas.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgempresas.ColumnHeadersDefaultCellStyle.Font = new Font(FontFamily.GenericSansSerif, 9.0F, FontStyle.Bold);

            dginforme.AutoGenerateColumns = false;
            dginforme.EnableHeadersVisualStyles = false;
            dginforme.ColumnHeadersDefaultCellStyle.BackColor = Color.Honeydew;
            dginforme.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dginforme.ColumnHeadersDefaultCellStyle.Font = new Font(FontFamily.GenericSansSerif, 9.0F, FontStyle.Bold);
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LEmpresas.Clear();

            foreach (DataGridViewRow row in dgempresas.SelectedRows)
            {
                LEmpresas.Add(EmpresasCN.Listar(Convert.ToInt32(row.Cells["Id_Empresa"].Value)));
            }
            dginforme.Visible = true;
            panel1.Visible = false;
            rellenaproveedores(LEmpresas,finicio.Value,ffin.Value);
            Form_Caja.Grid_Diseño(dginforme, dginforme.Font);

         
        }
        public void rellenaproveedores(List<Empresas> Emp,DateTime fini, DateTime ffin)
        {
        
            dtgastosporproveedor.Rows.Clear();
            dginforme.DataSource = null;
            DataRow dr ;
            List<Facturas_ca> f = new List<Facturas_ca>();
            List<Obras> L_Obras_Selecionadas = LEmpresas.SelectMany(p=> p.Obras).ToList();
            foreach (Obras Obr in L_Obras_Selecionadas)
            {
                foreach (Facturas_ca fac in Obr.Facturas_ca.Where(p=> p.Fecha >= fini && p.Fecha <= ffin).ToList())
                {
                    f.Add(fac);
                }
            }

           
           var Groupbyprovee = from p in f
                                group p by p.Id_proveedor into g                              
                                select new Facturas_ca
                                {
                                    Id_proveedor = g.Key,
                                    Base = g.Sum(m => m.Base),
                                    Proveedor = g.Select(m => m.Proveedor).ToList()[0],
                                };


            foreach (Facturas_ca Fac in Groupbyprovee.OrderBy(p=> p.Proveedor).ToList() )
            {
                dr = dtgastosporproveedor.NewRow();
                dr["Id_Proveedor"] = Fac.Id_proveedor;
                dr["Proveedor"] = Fac.Proveedor;
                dr["Importe"] = Fac.Base;
                dtgastosporproveedor.Rows.Add(dr);
            }
           dginforme .DataSource = dtgastosporproveedor;
           Form_Caja.AgregaTotales(dtgastosporproveedor, 1);
            f.Clear();
            Groupbyprovee = null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dginforme.Visible = false;
            panel1.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {

            string Title = "Compras a Proveedores desde: " + finicio.Value.ToShortDateString() + " a " + ffin.Value.ToShortDateString();
            ContaWIN.M_PrintDGV.Print_DataGridView(dginforme, Title,false, false, true, false);
        }
    }
}
