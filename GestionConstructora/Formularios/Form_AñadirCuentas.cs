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
    public partial class Form_AñadirCuentas : Form
    {
        bool tratacuenta = true;
        public Form_AñadirCuentas()
        {
            InitializeComponent();
            CargaPanel();
        }
        public Form_AñadirCuentas(Cuentas Cuent)
        {
            InitializeComponent();
            CargaPanel();
            CargaPanel(Cuent);
        }

        #region BOTONES   
        private void bttAñadir_Click(object sender, EventArgs e)
        {
             CuentasCn.Añadir(Convert.ToInt32(cbempresa.SelectedValue), txtcuenta.Text, txtnombre.Text, Convert.ToInt32(cbgrupo.SelectedValue), Convert.ToInt32(cbsubgrupo.SelectedValue), tratacuenta);
             this.Close();
        }

        #endregion

        #region "Eventos"
        private void chtratacuenta_CheckedChanged(object sender, EventArgs e)
        {
            tratacuenta = chtratacuenta.Checked ? true : false;
        }
        private void cbgrupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cbsubgrupo.DataSource = SubGruposCN.ListarporGrupo(Convert.ToInt32(cbgrupo.SelectedValue));
                cbsubgrupo.DisplayMember = "Nombre";
                cbsubgrupo.ValueMember = "Id_Subgrupo";
                cbsubgrupo.SelectedValue = -1;
            }
            catch { }

        }
        #endregion
        #region "procedimientos"
        public void CargaPanel()
        {
            cbempresa.DataSource = EmpresasCN.Listar();
            cbempresa.DisplayMember = "Nombre";
            cbempresa.ValueMember = "Id_Empresa";
            cbempresa.SelectedValue = -1;

            txtcuenta.Text = string.Empty;
            txtnombre.Text = string.Empty;

            cbgrupo.DataSource = GruposCN.Listar_solocontabilidad();
            cbgrupo.DisplayMember = "Nombre";
            cbgrupo.ValueMember = "Id_Grupo";
            cbgrupo.SelectedValue = -1;

            cbsubgrupo.DataSource = SubGruposCN.ListarporGrupo(Convert.ToInt32(cbgrupo.SelectedValue));
            cbsubgrupo.DisplayMember = "Nombre";
            cbsubgrupo.ValueMember = "Id_Subgrupo";
            cbsubgrupo.SelectedValue = -1;
            
            chtratacuenta.Checked = true;
           

        }
        public void CargaPanel(Cuentas Cuenta)
        {
            cbempresa.SelectedValue = Cuenta.Id_Empresa;
            txtcuenta.Text = Cuenta.Cuenta;
            txtnombre.Text = Cuenta.Nombre;
            cbgrupo.SelectedValue = Cuenta.Id_Grupo;
            cbsubgrupo.SelectedValue = Cuenta.Id_SubGrupo;
            txtnombre.Select();
        }
        #endregion
    }
}
