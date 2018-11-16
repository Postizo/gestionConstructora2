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

namespace GestionConstructora
{
    public partial class Form_AjusteGasto : Form
    {
        public Obras Obr { get; set; }
        
        public Form_AjusteGasto(Obras obr)
        {
            InitializeComponent();
            Obr = obr;
            txctimporte.Text = Obr.Ajuste.ToString();
            txtcomentario.Text = Obr.Comentario_Ajuste;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Obr.Ajuste = Convert.ToDecimal(txctimporte.Text);
            Obr.Comentario_Ajuste = txtcomentario.Text;
            ObraCN.ModificarAjuste(Obr.Id_Obra, Obr.Id_Empresa, Convert.ToDecimal(txctimporte.Text), txtcomentario.Text);
            this.Close();
        }
        private void entrada(object sender, EventArgs e)
        {
            TextBox campo;
            campo = (TextBox)sender;
            if (campo.Text == "0") campo.Text = "";

        }
        private void salida(object sender, EventArgs e)
        {
            TextBox campo;
            campo = (TextBox)sender;
            if (campo.Text == "") campo.Text = "0";

        }
    }
}
