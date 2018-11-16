using Negocio;
using Negocio.Gestion;
using Entidad;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Globalization;
using System.Diagnostics;

namespace GestionConstructora
{
    public partial class ObraDetallecs : Form
    {
        int Obr_ide;
        int fas_Actu;
        ObraGes ObrGeneral;
        public ObraDetallecs(Int32 Ide)
        {
            Obr_ide = Ide;
            fas_Actu = 0;
            InitializeComponent();
            ObrGeneral = new ObraGes(Obr_ide, fas_Actu);
            CargarDetalleObras();
            CargaTree();
    
        }

        #region  NODOS
        public void CargaTree()
        {
            Ai.Control.TreeNode tn = new Ai.Control.TreeNode();

            foreach (Capitulo Cap in ObrGeneral.Capitulos)
            {
                tn = new Ai.Control.TreeNode();
                tn.Text = Cap.Cod + "  " + Cap.Nombre;
                AddColumnsNode(tn, Cap);

                foreach (Capitulo SubCap in Cap.SubCapitulos)
                {
                    Ai.Control.TreeNode child = new Ai.Control.TreeNode();
                    child.Text = SubCap.Cod + "  " + SubCap.Nombre;
                    AddColumnsNode(child, SubCap);
                    tn.Nodes.Add(child);
                }
                treeCap.Nodes.Add(tn);
            }

            tn = new Ai.Control.TreeNode();
            tn.Text = "Totales";            tn.NodeFont = new Font("Verdana", 9.00F, FontStyle.Bold);
            tn.BackColor = Color.LightGray;
            AddColumnsTotales(tn, ObrGeneral);
            treeCap.Nodes.Add(tn);
            treeCap.Refresh();


        }
        public void AddColumnsTotales(Ai.Control.TreeNode tn, ObraGes obr)
        {
            tn.Image = PictureBox1.Image;
            tn.ExpandedImage = PictureBox2.Image;
            tn.UseNodeStyleForSubItems = false;

            for (int i = 1; i <= treeCap.Columns.Count; i++)
            {
                switch (i)
                {
                    case 1:
                        tn.SubItems.Add(obr.Ide);
                        break;
                    case 2:
                        tn.SubItems.Add(obr.Imp_Presupuestado);
                        break;
                    case 3:
                        tn.SubItems.Add(obr.Imp_Coste);
                        break;
                    case 4:
                        tn.SubItems.Add(obr.Desv_Propia);

                        if (obr.Desv_Propia < 0) { tn.SubItems[i].Color = Color.Red; } else { tn.SubItems[i].Color = Color.Green; }
                        break;
                    case 5:
                        tn.SubItems.Add(obr.Desv_Propia_Por);
                        if (obr.Desv_Propia_Por < 0) { tn.SubItems[i].Color = Color.Red; } else { tn.SubItems[i].Color = Color.Green; }
                        break;
                    case 6:
                        tn.SubItems.Add(obr.Imp_Oferta);
                        break;
                    case 7:
                        tn.SubItems.Add(obr.Imp_Venta);

                        break;

                    default:

                        break;
                }
            }

        }
        public void AddColumnsPar(Ai.Control.TreeNode tn, Partida par)
        {
            tn.Image = PictureBox1.Image;
            tn.ExpandedImage = PictureBox2.Image;
            tn.UseNodeStyleForSubItems = false;

            for (int i = 1; i <= treeCap.Columns.Count; i++)
            {
                switch (i)
                {
                    case 1:
                        tn.SubItems.Add(par.Imp_Presupuestado);
                        break;
                    case 2:
                        tn.SubItems.Add(par.Imp_Coste);
                        break;
                    case 3:
                        if (par.Desv_Propia_Por < 0)
                        {
                            if (par.Desv_Propia_Por < -100)
                            { tn.SubItems.Add(100); }
                            else
                            { tn.SubItems.Add(par.Desv_Propia_Por * -1); }

                        }
                        else
                        {
                            if (par.Desv_Propia_Por > 100)
                            { tn.SubItems.Add(100); }
                            else
                            { tn.SubItems.Add(par.Desv_Propia_Por); }
                        }
                        if (par.Desv_Propia_Por < 0) { tn.SubItems[i].Color = Color.Red; } else { tn.SubItems[i].Color = Color.Green; }
                        break;
                    case 4:
                        tn.SubItems.Add(par.Imp_Oferta);
                        break;
                    case 5:
                        tn.SubItems.Add(par.Imp_Venta);
                        break;
                    default:
                        break;
                }
            }
        }
        public void AddColumnsNode(Ai.Control.TreeNode tn, Capitulo cap)
        {
            tn.Image = PictureBox1.Image;
            tn.ExpandedImage = PictureBox2.Image;
            tn.UseNodeStyleForSubItems = false;

            for (int i = 1; i <= treeCap.Columns.Count; i++)
            {
                switch (i)
                {
                    case 1:
                        tn.SubItems.Add(cap.Ide);
                        break;
                    case 2:
                        if (cap.Imp_Presupuestado == 0) { tn.SubItems.Add(0); } else { tn.SubItems.Add(cap.Imp_Presupuestado); }                     
                        break;
                    case 3:
                        tn.SubItems.Add(cap.Imp_Coste);
                        break;
                    case 4:
                        tn.SubItems.Add(cap.Desv_Propia);
                        if (cap.Desv_Propia < 0) { tn.SubItems[i].Color = Color.Red; } else { tn.SubItems[i].Color = Color.Green; }
                        break;
                    case 5:
                        tn.SubItems.Add(cap.Desv_Propia_Por);
                        if (cap.Desv_Propia_Por < 0) { tn.SubItems[i].Color = Color.Red; } else { tn.SubItems[i].Color = Color.Green; }  
                        break;
                    case 6:
                        tn.SubItems.Add(cap.Imp_Oferta);
                        break;
                    case 7:
                        tn.SubItems.Add(cap.Imp_Venta);
                        break;
                    default:
                        break;
                }
            }

        }

        #endregion

        #region CARGARDATOS

        public void CargarDetalleObras()
        {
            List_Fases.AutoGenerateColumns = false;
            ltitulo.Text = ObrGeneral.Nombre;
            lestado.Text = "FASE" + fas_Actu.ToString();
            List_Fases.DataSource = ObrGeneral.Fases;
        }
        public void CargaPartidas(Capitulo cap, int fas)
        {
            treePar.Nodes.Clear();
            Ai.Control.TreeNode tn;
            foreach (Partida Par in cap.DevuelvePartidas(fas))
            {

                tn = new Ai.Control.TreeNode();
                string[] lineas = new string[] { };
                lineas = Cadena2lineas(Par.Nombre, 40);
                if (lineas[1] != "")
                {
                    tn.Text = Par.Cod + "  " + lineas[0] + System.Environment.NewLine + lineas[1];
                }
                else { tn.Text = Par.Cod + "  " + lineas[0]; }

                AddColumnsPar(tn, Par);
                treePar.Nodes.Add(tn);
            }
            treePar.Refresh();

        }


       
        #endregion

        #region  EVENTOS
        private void tree_ColumnBackgroundPaint(object sender, Ai.Control.ColumnBackgroundPaintEventArgs e)
        {

        }
        private void tree_ColumnCustomFilter(object sender, Ai.Control.ColumnCustomFilterEventArgs e)
        {
            // Perform your custom filter dialog here.
            // If you want to cancel the operation, set e.CancelFilter to true.
            // Add your custom filtering like this.
            e.Column.CustomFilter = column1CustomFilter;
        }
        private bool column1CustomFilter(object value)
        {
            // This is just a sample, to perform custom filtering operation on specified column.
            // Return true if the value is meet your custom filter parameter, false otherwise.
            return true;
        }
        private void treeCap_SelectedNodeChanged(object sender, EventArgs e)
        {

            if (treeCap.SelectedNode == null) return;

            if (treeCap.SelectedNode.Level == 0)
            {
                treeCap.SelectedNode.collapse();
                Int32 Id_ = Convert.ToInt32(treeCap.SelectedNode.SubItems[1].Value);
                Capitulo Cap = ObrGeneral.Capitulos.Find(x => x.Ide == Id_);
                CargaPartidas(Cap, fas_Actu);
            }
            else
            {
                Int32 IdCapitulo_ = Convert.ToInt32(treeCap.SelectedNode.Parent.SubItems[1].Value);
                Int32 Id_ = Convert.ToInt32(treeCap.SelectedNode.SubItems[1].Value);
                Capitulo Cap = ObrGeneral.Capitulos.Find(x => x.Ide == IdCapitulo_);
                Capitulo SubCapitulo = Cap.SubCapitulos.Find(x => x.Ide == Id_);
                CargaPartidas(SubCapitulo, fas_Actu);
            }
          
            

        }

        private void treeCap_AfterSelect(object sender, Ai.Control.TreeNodeEventArgs e)
        {
            if (treeCap.SelectedNode == null) return;
            treeCap.SelectedNode.Image = PictureBox1.Image;
            treeCap.SelectedNode.ExpandedImage = PictureBox2.Image;
        }

        private void treeCap_BeforeSelect(object sender, Ai.Control.TreeNodeEventArgs e)
        {
            if (treeCap.SelectedNode == null) return;
            if (treeCap.SelectedNode.Nodes.Count == 0)
            {

                treeCap.SelectedNode.Image = PictureBox1.Image;
                treeCap.SelectedNode.ExpandedImage = PictureBox1.Image;

            }
        }
        private void List_Fases_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
           
        }

     
        #endregion

        public string[] Cadena2lineas(string cadena, int maxlenght)
        {
            string[] cadenas = new string[] {"",""};
          
            if (cadena.Length > maxlenght)
            {
                for (int i = cadena.Length- 1; i >= 0; i--)
                {
                    if (cadena.Substring(i, 1) == " " && i != cadena.Length - 1)
                    {
                        cadenas[0] = cadena.Substring(0, i);
                        cadenas[1] = cadena.Substring(i, cadena.Length - i);
                        break;
                    }
                }

            }
            else
            {
                cadenas[0] = cadena;
            }

            return cadenas;
        }

        private void List_Fases_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            fas_Actu = Convert.ToInt32(List_Fases.Rows[e.RowIndex].Cells["Fase"].Value);
            treeCap.Nodes.Clear();
            treePar.Nodes.Clear();
            ObrGeneral.CalculosTotales(fas_Actu);
            CargarDetalleObras();
            CargaTree();
        }
    }






}
