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

namespace GestionConstructora
{
    public partial class Form_Presu_mantenimiento : Form
    {
        Presu_Estancias Estancia_M;
        Presu_Elementos Elemento_M;
        public Form_Presu_mantenimiento()
        {
            InitializeComponent();            
            Diseño_form();
            CargaIni();
        }
        public void CargaIni()
        {          
            dgestancias.DataSource = PresupuestosCN.Listar_Estancias();                  
        }

        public void Diseño_form()
        {
            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic |
            BindingFlags.Instance | BindingFlags.SetProperty, null,
            dgelementos, new object[] { true });
            dgelementos.AutoGenerateColumns = false;
            dgelementos.EnableHeadersVisualStyles = false;
            dgelementos.ColumnHeadersDefaultCellStyle.BackColor = Color.AliceBlue;
            dgelementos.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgelementos.ColumnHeadersDefaultCellStyle.Font = new Font(FontFamily.GenericSansSerif, 9.0F, FontStyle.Bold);

            dgestancias.AutoGenerateColumns = false;
            dgestancias.EnableHeadersVisualStyles = false;
            dgestancias.ColumnHeadersDefaultCellStyle.BackColor = Color.Honeydew;
            dgestancias.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgestancias.ColumnHeadersDefaultCellStyle.Font = new Font(FontFamily.GenericSansSerif, 9.0F, FontStyle.Bold);
            
        }

        private void bttnuevopresu_Click(object sender, EventArgs e)
        {

        }
                

       
        public void Cargar_elementos()
        {
            lelementos.Text = "ELEMENTOS DE LA ESTANCIA:  " + Estancia_M.Nombre.ToUpper() ;
            List<Presu_Elem_Estan > Yaelegido =  PresupuestosCN.Listar_ElementosEstancia(Estancia_M.Id_Estancia);
            List<Presu_Elementos> Todoselementos = PresupuestosCN.Listar_Elementos();
            dgelementos.DataSource = Todoselementos;
            foreach (DataGridViewRow RoW in dgelementos.Rows)
            {
                int Unidades = (Yaelegido.Where(p => p.Id_elementos == Convert.ToInt32(RoW.Cells["Id_elemento"].Value)).Count() > 0) ? Yaelegido.Where(p => p.Id_elementos == Convert.ToInt32(RoW.Cells["Id_elemento"].Value)).ToList()[0].Unidades : 0;
                RoW.Cells["Unidades"].Value = Unidades;
            }
            dgelementos.CurrentCell = dgelementos[2, 0];


        }

        private void dgestancias_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Estancia_M = PresupuestosCN.Listar_Estancia(Convert.ToInt32(dgestancias["id_estancia", e.RowIndex].Value));
                Cargar_elementos();
            }
            catch (Exception)
            {
            
            }         
        }
        private void dgelementos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgelementos.Columns["Unidades"].Index == e.ColumnIndex)
            {
                PresupuestosCN.AñadiroUpdateElemetoEtsancia(Estancia_M.Id_Estancia, Convert.ToInt32(dgelementos.CurrentRow.Cells ["id_elemento"].Value), Convert.ToInt32(dgelementos.CurrentRow.Cells["Unidades"].Value));

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void dgelementos_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Elemento_M = PresupuestosCN.ListarElementos(Convert.ToInt32(dgelementos["id_elemento",e.RowIndex].Value));
            }
            catch (Exception)
            {

            }

        }
        private void button3_Click(object sender, EventArgs e)
        {
            Form_PresuElemen f = new Form_PresuElemen(null);
            f.ShowDialog();
            Cargar_elementos();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form_PresuElemen f = new Form_PresuElemen(1);
            f.ShowDialog();          
            CargaIni();
        }

        private void dgelementos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Form_PresuElemen f = new Form_PresuElemen(Elemento_M);
            f.ShowDialog();
            Cargar_elementos();
        }
    }
}
