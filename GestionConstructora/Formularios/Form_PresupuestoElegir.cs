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
    public partial class Form_PresupuestoElegir : Form
    {
        Presu_Presu_Ca Presu_M;
        Empresas Emp;
        int Tip;
        public Form_PresupuestoElegir(Empresas emp, int tip)
        {
            Emp = emp;
            Tip = tip;
            InitializeComponent();          
            Diseño_form();
            if (Tip == 1)
            {               
                CargaIni();
            }
            else
            {
                CargaIni2();
            }              
        }
        

        public void CargaIni()
        {
            dgpresupuestos.Visible = true;
            dgpresu.Visible = false;
            dgpresupuestos.DataSource = PresupuestosCN.Listar();
        }

        public void CargaIni2()
        {
            dgpresu.DataSource = Emp.Obras.Where(p => p.Finalizada == false && p.Id_Sigrid  != 0).ToList();
            dgpresupuestos.Visible = false;
            dgpresu.Visible = true;
            button3.Visible = false;
            button4.Visible = false;
        }
        public void Diseño_form()
        {
            dgpresu.AutoGenerateColumns = false;
            dgpresu.EnableHeadersVisualStyles = false;
            dgpresu.ColumnHeadersDefaultCellStyle.BackColor = Color.Honeydew;
            dgpresu.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgpresu.ColumnHeadersDefaultCellStyle.Font = new Font(FontFamily.GenericSansSerif, 9.0F, FontStyle.Bold);

            dgpresupuestos.AutoGenerateColumns = false;
             dgpresupuestos.EnableHeadersVisualStyles = false;
            dgpresupuestos.ColumnHeadersDefaultCellStyle.BackColor = Color.Honeydew;
            dgpresupuestos.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgpresupuestos.ColumnHeadersDefaultCellStyle.Font = new Font(FontFamily.GenericSansSerif, 9.0F, FontStyle.Bold);
        }       
        
         
       
       
        private void bttnuevopresu_Click(object sender, EventArgs e)
        {
            

        }        
                private void dgpresupuestos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
                Presu_M = PresupuestosCN.Listar(Convert.ToInt32(dgpresupuestos.CurrentRow.Cells["Id_Presupuesto"].Value), Convert.ToInt32(dgpresupuestos.CurrentRow.Cells["id_version"].Value));
                P_Presupuestos.Enabled = false;
                Form_Presupuesto f = new Form_Presupuesto(Presu_M);
                f.Show();
                this.Close();       
        }

        

        private void button4_Click(object sender, EventArgs e)
        {
            Form_PresuElemen f = new Form_PresuElemen(2);
            f.ShowDialog();
            CargaIni();
        }

        private void dgpresu_DoubleClick(object sender, EventArgs e)
        {
         
        }

        private void dgpresu_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Obras Obr = ObraCN.Listar(Convert.ToInt32(dgpresu.CurrentRow.Cells["id_Obra"].Value), Emp.Id_Empresa);
            P_Presupuestos.Enabled = false;
            Form_PresupuestoOficial f = new Form_PresupuestoOficial(Obr);
            f.Show();
            this.Close();
        }
    }     
}
