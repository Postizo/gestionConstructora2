using Entidad;

using Negocio;
using Negocio.Gestion;

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
    public partial class Form_ComparaObras : Form
    {   
        List<Obras> L_Obras_Selecionadas = new List<Obras>();
        Empresas Emp = new Empresas();
        bool Repercutido = false;
        string Vista = "Seguimiento";
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
            L_Obras_Selecionadas = Publico.Obras_Selecionadas(listObras);
            Mostrar_Inform();
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
            Cargar_y_Vista_tree(Repercutido,Vista);
            this.Cursor = Cursors.Default;
        }

        #endregion


        #region "Proceso Secundarios"
        public void DiseñoGrid()
        {
            pderecha.Visible = false;
            listObras.DataSource = Emp.Obras.Where(p => p.Id_Sigrid != 0).ToList();
            listObras.DisplayMember = "Nombre";
            listObras.ValueMember = "id_Obra";
        }
        public void Cargar_y_Vista_tree(bool Repercutido,string Vista)
        {
            //Mandamos cargar el treee segun la vista que queremos con Indirectos o sin ellos
            foreach (Obras Obr in L_Obras_Selecionadas)
            {
                Obr.PREPARAOBRA();             
            }
            Publico.CargaTree_ComparaObras(L_Obras_Selecionadas, treemetros, imageList1, true, campo, metros_s,0);

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
            if (rbpresupuesto.Checked) campo = "CostePrevistom";
            if (rbcostereal.Checked) campo = "CstRealm";
            if (rbcertificado.Checked) campo = "Certm";

            if (rbescriturados.Checked) metros_s = "m_escriturados";
            if (rbconstruidos .Checked) metros_s = "m_construidos";
            if (rbutiles.Checked) metros_s = "m_utiles";

            Mostrar_Inform();

        }
    }
}
