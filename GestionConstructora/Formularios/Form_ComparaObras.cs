using Entidad;

using Negocio;
using Negocio.Gestion;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionConstructora
{  
    public partial class Form_ComparaObras : Form
    {   
        List<Obras> L_Obras_Selecionadas = new List<Obras>();
        Empresas Emp = new Empresas();     
        string campo = "CostePrevistom";
        string metros_s = "m_escriturados";
        public Form_ComparaObras(Empresas Empresa)
        {
            Emp = Empresa;
            InitializeComponent();
            DiseñoGrid();
        }
        
        #region "Botones"
        private void button1_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Cargaobras();
            if (L_Obras_Selecionadas.Count > 0) Mostrar_Inform(); ;

            this.Cursor = Cursors.Default;

        }
        #endregion
        
        #region "Proceso Principal"
        public void Mostrar_Inform()
        {
            this.Cursor = Cursors.WaitCursor;
            pderecha.Visible = true;
            //Limpiamos
            treemetros.Nodes.Clear();
            treemetros.Columns.Clear();
            treemetros.Refresh();           
            ltitulo.Text = "COMPARACION ENTRE DIFERENTES OBRAS";    
            Cargar_y_Vista_tree();
            this.Cursor = Cursors.Default;
        }

        #endregion
        
        #region "Proceso Secundarios"
        public void DiseñoGrid()
        {
          
            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic |
            BindingFlags.Instance | BindingFlags.SetProperty, null,
            dgobras, new object[] { true });
            pderecha.Visible = false;
            dgobras.AutoGenerateColumns = false;
            dgobras.EnableHeadersVisualStyles = false;
            dgobras.ColumnHeadersDefaultCellStyle.BackColor = Color.AliceBlue;
            dgobras.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgobras.ColumnHeadersDefaultCellStyle.Font = new Font(FontFamily.GenericSansSerif, 9.0F, FontStyle.Bold);
            dgobras.DataSource = Emp.Obras.Where(p => p.Id_Sigrid != 0).ToList();
           
        }
        public void Cargar_y_Vista_tree()
        {
            //Mandamos cargar el treee segun la vista que queremos con Indirectos o sin ellos
            foreach (Obras Obr in L_Obras_Selecionadas)
            {
                Obr.PREPARAOBRA();             
            }
            Publico.CargaTree_ComparaObras(L_Obras_Selecionadas, treemetros, imageList1, true,  metros_s,0);

        }

        #endregion

        #region "EVENTOS"
        private void treobra_AfterSelect(object sender, Ai.Control.TreeNodeEventArgs e)
        {
        //    if (treeobra.SelectedNode == null) return;
        //    if (Convert.ToInt32(treeobra.SelectedNode.SubItems[Publico.Busca("TipoCoste", treeobra)].Value) != -1)
        //    {
        //        treeobra.SelectedNode.Image = imageList1.Images[5];
        //        treeobra.SelectedNode.ExpandedImage = imageList1.Images[6];
        //    }
        //    else
        //    {
        //        treeobra.SelectedNode.Image = imageList1.Images[4];
        //        treeobra.SelectedNode.ExpandedImage = imageList1.Images[6];
        //    }
        }

        private void treobra_BeforeSelect(object sender, Ai.Control.TreeNodeEventArgs e)
        {
            //if (treeobra.SelectedNode == null) return;
            //if (treeobra.SelectedNode.Nodes.Count == 0)
            //{
            //    if (Convert.ToInt32(treeobra.SelectedNode.SubItems[Publico.Busca("TipoCoste", treeobra)].Value) != -1)
            //    {
            //        treeobra.SelectedNode.Image = imageList1.Images[5];
            //        treeobra.SelectedNode.ExpandedImage = imageList1.Images[5];
            //    }
            //    else
            //    {
            //        treeobra.SelectedNode.Image = imageList1.Images[4];
            //        treeobra.SelectedNode.ExpandedImage = imageList1.Images[4];
            //    }
  
            //}
        }
        private void treeobra_SelectedNodeChanged(object sender, EventArgs e)
        {
            //if (treeobra.SelectedNode == null) return;
            //if (treeobra.SelectedNode.Level == 0)
            //{
            //    treeobra.SelectedNode.collapse();
            //}
        }

        #endregion

        private void rbpresupuesto_CheckedChanged(object sender, EventArgs e)
        {
            if (rbescriturados.Checked) metros_s = "m_escriturados";
            if (rbconstruidos .Checked) metros_s = "m_construidos";
            if (rbutiles.Checked) metros_s = "m_utiles";

            Mostrar_Inform();

        }

        private void treemetros_Click(object sender, EventArgs e)
        {

        }
        private void Cargaobras()
        {
            L_Obras_Selecionadas.Clear();
            foreach (DataGridViewRow Row in dgobras.Rows)
            {
              
                if (Convert.ToBoolean(Row.Cells["dcpresu"].Value) == true || Convert.ToBoolean(Row.Cells["dccreal"].Value) == true || Convert.ToBoolean(Row.Cells["dccertificado"].Value) == true)
                {
                    Obras Obr = ObraCN.Listar(Row.Cells["dcObra"].Value.ToString());
                    if (Convert.ToBoolean(Row.Cells["dcpresu"].Value) == true) Obr.campocompara = "CostePrevistom";
                    if (Convert.ToBoolean(Row.Cells["dccreal"].Value) == true) Obr.campocompara = "CstRealm";
                    if (Convert.ToBoolean(Row.Cells["dccertificado"].Value) == true) Obr.campocompara = "Certm";

                    L_Obras_Selecionadas.Add(Obr);
                } 

            }
            
        }

        private void dgobras_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgobras.EndEdit();
            try
            {
                if (Convert.ToBoolean(dgobras[dgobras.Columns[e.ColumnIndex].Name, e.RowIndex].Value) == true)
                {
                    foreach (DataGridViewCell cell in dgobras.Rows[e.RowIndex].Cells)
                    {
                        if (cell.ValueType.Name == "Boolean" && dgobras.Columns[cell.ColumnIndex].Name != dgobras.Columns[e.ColumnIndex].Name)
                        {
                            cell.Value = false;
                        }
                    }

                }
            }
            catch (Exception)
            {

                //  throw;
            }

        }

        private void dgobras_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void dgobras_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
         
          
            
        }

        private void dgobras_CellClick(object sender, DataGridViewCellEventArgs e)
        {
         

        }
    }
}
