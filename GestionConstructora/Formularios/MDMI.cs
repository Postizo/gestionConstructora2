using Negocio;
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

namespace GestionConstructora
{
    public partial class MDMI : Form
    {
        Empresas EMPreSeleccionada = EmpresasCN.Listar(7);

        public MDMI()
        {
          
            InitializeComponent();
            RegistarMetadatas Reg = new RegistarMetadatas();
            Reg.registerBuddyClasses();
            CargarBarraestado();
        }

        private void empresasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form_Empresas f = new Form_Empresas();
            f.MdiParent = this;
            f.Show();
            f.FormClosed += new FormClosedEventHandler(f_FormClosed);
        }

        private void obrasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form_Obras2 f = new Form_Obras2(EMPreSeleccionada);
            f.MdiParent = this;
            f.Show();
            f.FormClosed += new FormClosedEventHandler(f_FormClosed);
        }

        private void gruposToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form_Grupos f = new Form_Grupos();
            f.MdiParent = this;
            f.Show();
            f.FormClosed += new FormClosedEventHandler(f_FormClosed);
        }

        private void subGruposToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form_SubGrupos f = new Form_SubGrupos();
            f.MdiParent = this;
            f.Show();
            f.FormClosed += new FormClosedEventHandler(f_FormClosed);
        }

        private void cuentasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form_Cuentas f = new Form_Cuentas(EMPreSeleccionada);
            f.MdiParent = this;
            f.Show();
            f.FormClosed += new FormClosedEventHandler(f_FormClosed);
        }

        private void ingresosYGastosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form_Balance2 f = new Form_Balance2(EMPreSeleccionada);
            f.MdiParent = this;
            f.Show();
            f.FormClosed += new FormClosedEventHandler(f_FormClosed);
        }
        private void f_FormClosed(object sender, FormClosedEventArgs e)
        {

            EMPreSeleccionada = EmpresasCN.Listar(EMPreSeleccionada.Id_Empresa);
        }

        private void controlDeObrasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListaObras f = new ListaObras();
            f.MdiParent = this;
            f.Show();
        }

        private void segumientoPresupuestoToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }
        private void importacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void facturasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Facturas f = new Form_Facturas(EMPreSeleccionada);
            f.MdiParent = this;
            f.Show();
            f.FormClosed += new FormClosedEventHandler(f_FormClosed);
        }

        private void comparacionDeObrasToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void seguimientoDeObrasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Segumiento f = new Form_Segumiento(EMPreSeleccionada);
            f.MdiParent = this;
            f.Show();
            f.FormClosed += new FormClosedEventHandler(f_FormClosed);
        }

        private void compracionDeObrasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_ComparaObras f = new Form_ComparaObras(EMPreSeleccionada);
            f.MdiParent = this;
            f.Show();
            f.FormClosed += new FormClosedEventHandler(f_FormClosed);
        }

        private void aplicarGeneralesYBeneficioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_CostesObra f = new Form_CostesObra(EMPreSeleccionada);
            f.MdiParent = this;
            f.Show();
            f.FormClosed += new FormClosedEventHandler(f_FormClosed);
        }
        private void mantenimientoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        public void CargarBarraestado()
        {
            try
            {
                labempresa.Text = EMPreSeleccionada.Nombre;
                labservidor.Text = EMPreSeleccionada.Servidor_ContaWin;
                labbddcontawin.Text = EMPreSeleccionada.BBDD_ContaWin;
                labversion.Text = ProductVersion;
            }
            catch
            {

            }

            


        }
        private void cambiarDeEmpresaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_CambioEmpresa f = new Form_CambioEmpresa();
           
            f.ShowDialog ();
            EMPreSeleccionada = f.Empresa;
            CargarBarraestado();
        }
        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        private void evoluciónDeGastosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_CuadroGasto f = new Form_CuadroGasto(EMPreSeleccionada);
            f.MdiParent = this;
            f.Show();
            f.FormClosed += new FormClosedEventHandler(f_FormClosed);
        }

        private void presupuestoIngresosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_PresuConta  f = new Form_PresuConta(EMPreSeleccionada);
            f.MdiParent = this;
            f.Show();
            f.FormClosed += new FormClosedEventHandler(f_FormClosed);
        }

        private void masterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Form_BalanceTo f = new Form_BalanceTo(EMPreSeleccionada);
            f.MdiParent = this;
            this.Cursor = Cursors.Default;
            f.Show();
            f.FormClosed += new FormClosedEventHandler(f_FormClosed);
        }

        private void presupuestoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_PresupuestoElegir f = new Form_PresupuestoElegir(EMPreSeleccionada,1);
            f.MdiParent = this;
            f.Show();
            f.FormClosed += new FormClosedEventHandler(f_FormClosed);
        }

        private void cajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Form_Caja f = new Form_Caja(EMPreSeleccionada);
            f.MdiParent = this;
            this.Cursor = Cursors.Default;
            f.Show();
            f.FormClosed += new FormClosedEventHandler(f_FormClosed);
        }

        private void listadosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void mantenimientoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form_Presu_mantenimiento f = new Form_Presu_mantenimiento();
            f.MdiParent = this;
            f.Show();
            f.FormClosed += new FormClosedEventHandler(f_FormClosed);
        }

        private void saldoProveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void presupuestosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form_PresupuestoElegir f = new Form_PresupuestoElegir(EMPreSeleccionada, 0);
            f.MdiParent = this;
            f.Show();
            f.FormClosed += new FormClosedEventHandler(f_FormClosed);
        }
        

        private void MDMI_Load(object sender, EventArgs e)
        {
            //ListaObras f = new ListaObras();
            //f.MdiParent = this;
            //f.Show();
            //f.FormClosed += new FormClosedEventHandler(f_FormClosed);
        }

        private void comparaObrasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_ComparaObras f = new Form_ComparaObras(EMPreSeleccionada);
            f.MdiParent = this;
            f.Show();
            f.FormClosed += new FormClosedEventHandler(f_FormClosed);
        }

        private void estudioFinancieroToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Form_FinancieroElegir f = new Form_FinancieroElegir();
            f.MdiParent = this;
            f.Show();
            f.FormClosed += new FormClosedEventHandler(f_FormClosed);
        }

        private void balanceOtraVezToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_BalanEmpresas f = new Form_BalanEmpresas();
            f.MdiParent = this;
            f.Show();
            f.FormClosed += new FormClosedEventHandler(f_FormClosed);
        }

        private void saldoProveedoresToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form_SaldoProveedores f = new Form_SaldoProveedores(EMPreSeleccionada);
            f.MdiParent = this;
            f.Show();
            f.FormClosed += new FormClosedEventHandler(f_FormClosed);
        }

        private void comprasProveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Provedores f = new Form_Provedores();
            f.MdiParent = this;
            f.Show();
          
        }

        private void buscadorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Buscador f = new Form_Buscador(EMPreSeleccionada);
            f.MdiParent = this;
            f.Show();
            f.FormClosed += new FormClosedEventHandler(f_FormClosed);
        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void importarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_ImportarTarifas f = new Form_ImportarTarifas(EMPreSeleccionada);
            f.MdiParent = this;
            f.Show();
            f.FormClosed += new FormClosedEventHandler(f_FormClosed);
        }

        private void tesoreriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Tesoreria f = new Form_Tesoreria (EMPreSeleccionada);
            f.MdiParent = this;
            f.Show();
            f.FormClosed += new FormClosedEventHandler(f_FormClosed);
        }

        private void controlDeAccesoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Puertas f = new Form_Puertas(EMPreSeleccionada);
            f.MdiParent = this;
            f.Show();
            f.FormClosed += new FormClosedEventHandler(f_FormClosed);
        }

        private void mantenimientoToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Form_Dequipos f = new Form_Dequipos();
            f.MdiParent = this;
            f.Show();
            f.FormClosed += new FormClosedEventHandler(f_FormClosed);
        }

        private void presupuestoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form_DpresuElegir f = new Form_DpresuElegir();
            f.MdiParent = this;
            f.Show();
            f.FormClosed += new FormClosedEventHandler(f_FormClosed);
        }

        private void tesoreriaFinancieraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_TesoreriaFinanciera f = new Form_TesoreriaFinanciera();
            f.MdiParent = this;
            f.Show();
            f.FormClosed += new FormClosedEventHandler(f_FormClosed);
        }
    }
}
