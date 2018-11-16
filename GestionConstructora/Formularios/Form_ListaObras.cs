using Negocio.Gestion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionConstructora
{
    public partial class ListaObras : Form
    {
        string filtro = "";
        int ide = 0;


        ObraGes ObrGeneral = new ObraGes();
      
        public ListaObras()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            List_Obras.DataSource  = ObrGeneral.Listar(filtro);
        }
        private void List_Obras_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
          if (e.RowIndex == -1) return;
          List_Obras.Enabled  = false;
          lloading.Visible = true;
          lloading.Refresh();
          ide = Convert.ToInt32(List_Obras.Rows[e.RowIndex].Cells["ide"].Value);
          ObraDetallecs f = new ObraDetallecs(ide);
            f.MdiParent = this.MdiParent;
            this.Close();
            f.Show();

        }
   
        public void Filtro()
        {
            filtro = "";
            if (Rbabiertas.Checked == true)
            {
                filtro += " AND est >1";
            }
            if (RbTodas .Checked == true)
            {
                filtro += "";
            }
            if (txtbuscar.Text != "")
            {
                filtro += " AND c.res like '%"+ txtbuscar.Text +"%'";
            }
            List_Obras.DataSource = ObrGeneral.Listar(filtro);
        }
  
       
        private void txtbuscar_TextChanged(object sender, EventArgs e)
        {
            Filtro();
        }

        private void RbTodas_CheckedChanged(object sender, EventArgs e)
        {
            Filtro();
        }

        private void Rbabiertas_CheckedChanged(object sender, EventArgs e)
        {
            Filtro();
        }

       
    }


}
