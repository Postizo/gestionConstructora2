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
namespace GestionConstructora
{
    public partial class Form_PresuElemen : Form
    {       
        public Presu_Elementos ELemento_M;
        public int id = 0;
        public Form_PresuElemen(Presu_Elementos elem )
        {
            ELemento_M = elem;
            InitializeComponent();
            Cargaini();
            this.Text = "Elementos";
        }
        public Form_PresuElemen(int  id_)
        {            
            InitializeComponent();
            id = id_;
            // id = 1 Nueva estancia
            // id = 2 Nueva presupuesto
            if (id == 1) this.Text = "Estancia";
            if (id == 2) this.Text = "Presupuesto";
            dglineas.Visible = false;
        }

        private void Cargaini()
        {                   
            if (ELemento_M == null)
            {
                ELemento_M =  PresupuestosCN.AñadirElementos("");
                PresupuestosCN.AñadirCalidad(ELemento_M.Id_Elemento, 1, "Baja", 0);
                PresupuestosCN.AñadirCalidad(ELemento_M.Id_Elemento, 2, "Media", 0);
                PresupuestosCN.AñadirCalidad(ELemento_M.Id_Elemento, 3, "Alta", 0);
                ELemento_M = PresupuestosCN.ListarElementos(ELemento_M.Id_Elemento);
               
            }
            else
            {
                txtnombre.Text = ELemento_M.Nombre;
            }
            dglineas.AutoGenerateColumns = false;
            dglineas.EnableHeadersVisualStyles = false;
            dglineas.ColumnHeadersDefaultCellStyle.BackColor = Color.Honeydew;
            dglineas.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dglineas.ColumnHeadersDefaultCellStyle.Font = new Font(FontFamily.GenericSansSerif, 9.0F, FontStyle.Bold);
            dglineas.DataSource = ELemento_M.Presu_Calidad.ToList();
            dglineas.DataSource = ELemento_M.Presu_Calidad.ToList();
        }
              

        private void txtnombre_TextChanged(object sender, EventArgs e)
        {
            
        }
              

        private void dglineas_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
           //PresupuestosCN.BorrarCalidad(Convert.ToInt32(dglineas["id_linea", e.RowIndex].Value));
        }
        private void dglineas_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dglineas.Columns["Precio"].Index == e.ColumnIndex)
            {
                PresupuestosCN.ActuCalidad(Convert.ToInt32(dglineas.CurrentRow.Cells["id_linea"].Value),Convert.ToDecimal(dglineas.CurrentRow.Cells["precio"].Value));
            }
        }
        private void Form_PresuElemen_FormClosed(object sender, FormClosedEventArgs e)
        {
            switch (id)
            {
                case 0:
                    PresupuestosCN.ActuElementos(ELemento_M.Id_Elemento, txtnombre.Text);
                    break;
                case 1:
                    PresupuestosCN.AñadirEstancia(txtnombre.Text);
                    break;
                case 2:
                    PresupuestosCN.AñadirPresu_ca(txtnombre.Text);
                    break;
                default:
                    break;
            }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
