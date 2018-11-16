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
using Negocio.Gestion;
using System.ComponentModel.DataAnnotations;

namespace GestionConstructora
{
    public partial class Form_Grupos_Rel : Form
    {
        int id_empresa = 0;
        int id_subgrupo = 0;
        int estado = 0;
        int Id_tipo = 0;
        string Tipo = "";
        bool visiblesubgrupo = false;
        Obras Obr = new Obras();
        public Form_Grupos_Rel(int id_obra, int id_emprea)
        {

            Obr = EmpresasCN.Listar(id_emprea).Obras.Where(p => p.Id_Obra == id_obra).ToList()[0];
            InitializeComponent();
            Cargarpropios();
            Cargarobra();
        }
        public void Cargarpropios()
        {
            lpropios.Items.Clear();
            foreach (Grupos Gr in GruposCN.Listar_solocontructora())
            {
                string conca = "";
                TreeListViewItem itemA = new TreeListViewItem(Gr.Id_Grupo.ToString(), 0);
                itemA.SubItems.Add(Gr.Orden + "-" + Gr.Nombre);

                foreach (Grupos_Rel Rel in Gr.Grupos_Rel.Where(p => p.Id_Empresa == Obr.Id_Empresa && p.Id_Obra == Obr.Id_Obra).ToList())
                {
                    conca += Rel.Cod_Sigrid + ",";
                }
                itemA.SubItems.Add(conca);
                if (Gr.Subgrupos.Count > 0)
                {
                    foreach (Subgrupos Subg in Gr.Subgrupos)
                    {
                        string concasub = "";
                        TreeListViewItem itemB = new TreeListViewItem(Subg.Id_Subgrupo.ToString(), 0);
                        itemB.SubItems.Add(Subg.Orden + "-" + Subg.Nombre);

                        foreach (Grupos_Rel Relsub in Gr.Grupos_Rel.Where(p => p.Id_Empresa == Obr.Id_Empresa && p.Id_Obra == Obr.Id_Obra && p.Id_Subgrupo == Subg.Id_Subgrupo).ToList())
                        {
                            concasub = Relsub.Cod_Sigrid + ",";
                        }
                        itemB.SubItems.Add(concasub);
                        itemA.Items.Add(itemB);
                    }

                }
                lpropios.Items.Add(itemA);
            }
        }
        public void Cargarobra()
        {
            lobra.Items.Clear();
            foreach (Obras_Lineas lineas in Obr.Obras_Lineas.Where(p => p.Id_Fase == 0).Where(p => p.Id_Grupo == 163))
            {
                TreeListViewItem itemA = new TreeListViewItem(lineas.Capitulo.ToString().PadLeft(2, Convert.ToChar("0")), 0);
                itemA.SubItems.Add(lineas.Nombre);
                lobra.Items.Add(itemA);
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (lobra.SelectedItems.Count <= 0) return;
            if (lpropios.SelectedItems.Count <= 0) return;
            if (lpropios.SelectedItems[0].Items.Count > 0) return;

            if (lpropios.SelectedItems[0].Level == 0)
            {
                foreach (TreeListViewItem Seleccionados in lobra.SelectedItems)
                {
                    Grupos Gr = GruposCN.Listar(Convert.ToInt32(lpropios.SelectedItems[0].SubItems[0].Text));
                    string Capsigri = Seleccionados.SubItems[0].Text.ToString();

                    GruposCN.Añadir_rel(Obr, Gr.Id_Grupo, Capsigri);
                    ObraCN.CambiarGrupo(Obr.Id_Obra, Capsigri, Gr.Id_Grupo, 0);
                }
            }
            else
            {
                foreach (TreeListViewItem Seleccionados in lobra.SelectedItems)
                {
                    Subgrupos Sub = SubGruposCN.Listar(Convert.ToInt32(lpropios.SelectedItems[0].SubItems[0].Text));
                    string Capsigri = Seleccionados.SubItems[0].Text.ToString();

                    GruposCN.Añadir_rel(Obr, Sub.Id_Grupo, Sub.Id_Subgrupo, Capsigri);
                    ObraCN.CambiarGrupo(Obr.Id_Obra, Capsigri, Sub.Id_Grupo, Sub.Id_Subgrupo);
                }
            }
            Obr = ObraCN.Listar(Obr.Id_Obra, Obr.Id_Empresa);
            Cargarobra();
            Cargarpropios();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (lpropios.SelectedItems.Count <= 0) return;

            if (lpropios.SelectedItems[0].Level == 0)
            {
                Grupos Gr = GruposCN.Listar(Convert.ToInt32(lpropios.SelectedItems[0].SubItems[0].Text));
                foreach (Grupos_Rel Rel in Gr.Grupos_Rel.Where(p => p.Id_Empresa == Obr.Id_Empresa && p.Id_Obra == Obr.Id_Obra).ToList())
                {
                    GruposCN.Borrar_rel(Obr, Gr.Id_Grupo);
                    ObraCN.CambiarGrupo(Obr.Id_Obra, Gr.Id_Grupo, null);
                }

            }
            else
            {
                Subgrupos Sub = SubGruposCN.Listar(Convert.ToInt32(lpropios.SelectedItems[0].SubItems[0].Text));
                GruposCN.Borrar_rel_subgrup(Obr, Sub.Id_Subgrupo);
                ObraCN.CambiarGrupo(Obr.Id_Obra, Sub.Id_Grupo, Sub.Id_Subgrupo);
            }

            Obr = ObraCN.Listar(Obr.Id_Obra, Obr.Id_Empresa);
            Cargarobra();
            Cargarpropios();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            var li = Obr.Facturas_ca.SelectMany(p => p.Facturas_li.ToList());

            //CAMBIAMOS FACTURAS
            foreach (Facturas_li Linea in li)
            {
                Grupos_Rel gr = GruposCN.Listar_rel(Obr.Id_Obra, Linea.Cap_sigrid);
                if (gr != null) //Comprobacion que todos los capitulos que tienen las lineas de la factura esten en la tabla Grupos_rel
                {
                    if  (gr.Id_Subgrupo == 0)                    
                        FacturasCN.CambiarGrupo(Obr.Id_Obra, gr.Id_Grupo, null, Linea);
                    else                 
                        FacturasCN.CambiarGrupo(Obr.Id_Obra, gr.Id_Grupo, gr.Id_Subgrupo, Linea);                    
                }
            }
            //CAMBIAMOS ALBARANES
            var al = Obr.Albaranes_ca.SelectMany(p => p.Albaran_li.ToList());
            foreach (Albaran_li Linea in al)
            {
                Grupos_Rel gr = GruposCN.Listar_rel(Obr.Id_Obra, Linea.Cap_sigrid);
                if (gr != null) //Comprobacion que todos los capitulos que tienen las lineas de la factura esten en la tabla Grupos_rel
                {
                    if (gr.Id_Subgrupo == 0)
                        AlbaranesCN.CambiarGrupo(Obr.Id_Obra, gr.Id_Grupo, null, Linea);
                    else
                        AlbaranesCN.CambiarGrupo(Obr.Id_Obra, gr.Id_Grupo, gr.Id_Subgrupo, Linea);
                }
            }
            //CAMBIAMOS MO
            var partTraba = Obr.ParteTrabajo.ToList();
            foreach (ParteTrabajo Linea in partTraba)
            {
                Grupos_Rel gr = GruposCN.Listar_rel(Obr.Id_Obra, Linea.Cap_Sigrid);
                if (gr != null) //Comprobacion que todos los capitulos que tienen las lineas de la factura esten en la tabla Grupos_rel
                {
                    if (gr.Id_Subgrupo == 0)
                        PartesTrabajoCN.CambiarGrupo(Obr.Id_Obra, gr.Id_Grupo, null, Linea);
                    else
                        PartesTrabajoCN.CambiarGrupo(Obr.Id_Obra, gr.Id_Grupo, gr.Id_Subgrupo, Linea);
                }
            }


        }
    }
}