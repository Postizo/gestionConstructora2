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
    public partial class Form_CostesObra : Form
    {
       
        List<Obras> L_Obras_Selecionadas = new List<Obras>();
        Obras Obr = new Obras();
        Empresas Emp = new Empresas();
        public Form_CostesObra(Empresas Empresa)
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
            Cargar_Gastos();
            this.Cursor = Cursors.Default;

        }
        #endregion
        
        #region "Proceso Principal"
        public void Mostrar_Inform()
        {
            pderecha.Visible = true;
            //Limpiamos
            ltitulo.Text = "COSTES DE LA OBRA:" + Obr.Nombre + "";
            Obr = Emp.Obras.Where(p => p.Id_Obra == L_Obras_Selecionadas[0].Id_Obra).ToList()[0];
            Obr.PREPARAOBRA();
         
            Cargar_y_Vista_tree();
        }
        
        public void Cargar_Gastos()
        {
            dgcuentas.DataSource = Obr.Capitulos.Where(p => p.Id_TipoCoste != -1).OrderBy(p=> p.Id_TipoCoste).ToList() ;
            Diseño();
        }
        
        #endregion


        #region "Proceso Secundarios"
         public void DiseñoGrid()
        {
            pderecha.Visible = false;
            listObras.DataSource = Emp.Obras.Where(p => p.Importado_presu == true).ToList();
            listObras.DisplayMember = "Nombre";
            listObras.ValueMember = "id_Obra";
            dgcuentas.AutoGenerateColumns = false;
            dgcuentas.EnableHeadersVisualStyles = false;
            dgcuentas.ColumnHeadersDefaultCellStyle.BackColor = Color.AliceBlue;
            dgcuentas.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgcuentas.ColumnHeadersDefaultCellStyle.Font = new Font(FontFamily.GenericSansSerif, 9.0F, FontStyle.Bold);
            foreach (DataGridViewColumn col in dgcuentas.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.Programmatic;
            }

        }
        public void Cargar_y_Vista_tree()
        {
            //Mandamos cargar el treee segun la vista que queremos con Indirectos o sin ellos
            Publico.CargaTree(Obr, treeobra, imageList1,0, true, false,false,true,null,0 );
           // for (int i = 0; i < treeobra.Columns.Count; i++) {treeobra.Columns[i].Visible = false;} //Ocultamos todas las columnas
           //treeobra.Columns[Publico.Busca("Nombre", treeobra)].Visible = true; 
   
        }

        #endregion

        #region "EVENTOS"
        private void treobra_AfterSelect(object sender, Ai.Control.TreeNodeEventArgs e)
        {
            if (treeobra.SelectedNode == null) return;
            switch (Convert.ToInt32(treeobra.SelectedNode.SubItems[Publico.Busca("TipoCoste", treeobra)].Value))
            {
                case -1:
                    treeobra.SelectedNode.Image = imageList1.Images[4];
                    treeobra.SelectedNode.ExpandedImage = imageList1.Images[6];
                    break;
                case -2:
                    treeobra.SelectedNode.Image = imageList1.Images[8];
                    treeobra.SelectedNode.ExpandedImage = imageList1.Images[6];
                    break;
                case -3:
                    treeobra.SelectedNode.Image = imageList1.Images[7];
                    treeobra.SelectedNode.ExpandedImage = imageList1.Images[6];
                    break;
                case -4:
                    treeobra.SelectedNode.Image = imageList1.Images[5];
                    treeobra.SelectedNode.ExpandedImage = imageList1.Images[6];
                    break;
            }
        }

        private void treobra_BeforeSelect(object sender, Ai.Control.TreeNodeEventArgs e)
        {
            if (treeobra.SelectedNode == null) return;
            if (treeobra.SelectedNode.Nodes.Count == 0)
            {
                switch (Convert.ToInt32(treeobra.SelectedNode.SubItems[Publico.Busca("TipoCoste", treeobra)].Value))
                {
                    case -1:
                        treeobra.SelectedNode.Image = imageList1.Images[4];
                        treeobra.SelectedNode.ExpandedImage = imageList1.Images[4];
                        break;
                    case -2:
                        treeobra.SelectedNode.Image = imageList1.Images[8];
                        treeobra.SelectedNode.ExpandedImage = imageList1.Images[8];
                        break;
                    case -3:
                        treeobra.SelectedNode.Image = imageList1.Images[7];
                        treeobra.SelectedNode.ExpandedImage = imageList1.Images[7];
                        break;
                    case -4:
                        treeobra.SelectedNode.Image = imageList1.Images[5];
                        treeobra.SelectedNode.ExpandedImage = imageList1.Images[5];
                        break;
                }

            }
        }
        private void treeobra_SelectedNodeChanged(object sender, EventArgs e)
        {
            if (treeobra.SelectedNode == null) return;
            if (treeobra.SelectedNode.Level == 0)
            {
                treeobra.SelectedNode.collapse();
            }
        }




        #endregion
            


        private void dgcuentas_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
           
          
        }
        public void Diseño()
        {
         
            dgcuentas.Columns["Importe"].DefaultCellStyle.Format = "#,#";
            dgcuentas.Columns["Porcentaje"].DefaultCellStyle.Format = "0.00\\%";

            foreach (DataGridViewRow Row in dgcuentas.Rows)
            {
                if (Convert.ToInt32(Row.Cells["Id_TipoCoste"].Value) == -2) Row.ReadOnly = true;
                if (Convert.ToInt32(Row.Cells["Id_TipoCoste"].Value) == -2) Row.DefaultCellStyle.ForeColor = Color.Red;
                if (Convert.ToInt32(Row.Cells["Id_TipoCoste"].Value) == -3)  Row.DefaultCellStyle.ForeColor = Color.Indigo;
                if (Convert.ToInt32(Row.Cells["Id_TipoCoste"].Value) == -4) Row.DefaultCellStyle.ForeColor = Color.Green ;
            }
         

        }

        private void dgcuentas_CellLeave(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgcuentas_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            decimal Impor, porcen;
            if (dgcuentas.Columns[e.ColumnIndex].Name == "Importe")
            {
                Impor = Convert.ToDecimal(dgcuentas["Importe", e.RowIndex].Value);
                porcen = (Impor * 100) / Obr.Capitulos.Where(p => p.Id_TipoCoste == -1).Sum(p => p.Importe_presu);
                dgcuentas["Porcentaje", e.RowIndex].Value = porcen;
            }
            else
            {
                porcen = Convert.ToDecimal(dgcuentas["Porcentaje", e.RowIndex].Value);
                Impor = (Obr.Capitulos.Where(p => p.Id_TipoCoste == -1).Sum(p => p.Importe_presu) * porcen) / 100;
                dgcuentas["Importe", e.RowIndex].Value = Impor;
            }

            if (Convert.ToInt32(dgcuentas["Id_TipoCoste", e.RowIndex].Value) == -3)
            {
                ObraCN.Borrar_Lineas(Obr.Id_Obra, "CG");
                Obras_Lineas Lin = new Obras_Lineas { Id_linea = 0, Id_Obra = Obr.Id_Obra, Id_ObraSigrid = Obr.Id_Sigrid, Id_TipoCoste = -3, Capitulo = "CG", Subcapitulo = "0", Id_Grupo = 94, Id_Subgrupo = 0, Nombre = "Costes Genearles", Medidas = 1, Unidad_Medida = "", Importe = Impor, Porcen_SobreTotal = porcen, Fecha_importado = DateTime.Today };
                ObraCN.Añadir_lineas(Lin);
            }

            if (Convert.ToInt32(dgcuentas["Id_TipoCoste", e.RowIndex].Value) == -4)
            {
                ObraCN.Borrar_Lineas(Obr.Id_Obra, "BENF");
                Obras_Lineas Lin = new Obras_Lineas { Id_linea = 0, Id_Obra = Obr.Id_Obra, Id_ObraSigrid = Obr.Id_Sigrid, Id_TipoCoste = -4, Capitulo = "BENF", Subcapitulo = "0", Id_Grupo = 95, Id_Subgrupo = 0, Nombre = "Beneficio", Medidas = 1, Unidad_Medida = "", Importe = Impor, Porcen_SobreTotal = porcen, Fecha_importado = DateTime.Today };
                ObraCN.Añadir_lineas(Lin);
            }
            Mostrar_Inform();
        }
    }
}
