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
    public partial class Form_Segumiento : Form
    {
        Obras Obr = new Obras();
        Guid id_infr = new Guid();
        Empresas Emp = new Empresas();
        int fase = 0;
        public Form_Segumiento(Empresas Empresa)
        {
            Emp = Empresa;
            InitializeComponent();
            DiseñoGrid();

        }

        #region "Botones"
 

        public void linea_Ingresos()
        {
            List<Grupos> lgrupos = GruposCN.Listar_solocontabilidad();
            List<Grupos> lgrupostesoreria = GruposCN.Listar_solocontabilidastesoreria();
            decimal Importe = 0;
            decimal presupuestado = 0;

            foreach (Grupos Grup in lgrupos.Where(p => p.Id_Tipo == 0))
            {
                Importe = BalanceCN.IngresosObra_Conta(Obr, Grup.Id_Grupo, id_infr.ToString());
                presupuestado = (Obr.Presu_Conta.Where(p => p.id_Grupo == Grup.Id_Grupo).ToList().Count > 0) ? Obr.Presu_Conta.Where(p => p.id_Grupo == Grup.Id_Grupo).ToList()[0].Presupuestado : 0;
                Obr.Total_Ingresos1_Conta += Importe;
                Obr.P_Total_Ingresos1_Conta += presupuestado;
            }
            foreach (Grupos Grup in lgrupos.Where(p => p.Id_Tipo == 1 && p.Id_TipoCoste == 2))
            {
                Importe = BalanceCN.GastosObra_Conta(Obr, Grup.Id_Grupo, id_infr.ToString());
                presupuestado = (Obr.Presu_Conta.Where(p => p.id_Grupo == Grup.Id_Grupo).ToList().Count > 0) ? Obr.Presu_Conta.Where(p => p.id_Grupo == Grup.Id_Grupo).ToList()[0].Presupuestado : 0;
                Obr.Total_GastosContribuciondirecta2_Conta += Importe;
                Obr.P_Total_GastosContribuciondirecta2_Conta += presupuestado;
            }
            foreach (Grupos Grup in lgrupos.Where(p => p.Id_Tipo == 1 && p.Id_TipoCoste == 3))
            {
                Importe = BalanceCN.GastosObra_Conta(Obr, Grup.Id_Grupo, id_infr.ToString());
                presupuestado = (Obr.Presu_Conta.Where(p => p.id_Grupo == Grup.Id_Grupo).ToList().Count > 0) ? Obr.Presu_Conta.Where(p => p.id_Grupo == Grup.Id_Grupo).ToList()[0].Presupuestado : 0;
                Obr.Total_Gastosdirectos3_Conta += Importe;
                Obr.P_Total_Gastosdirectos3_Conta += presupuestado;
            }

            //HAcemos lo de Contabilidad del confirming
            foreach (Grupos Grup in lgrupostesoreria)
            {
                switch (Grup.Id_Grupo)
                {
                    case 175:
                        Obr.C_Total_Facturado = BalanceCN.Debe_Cuenta(Obr, Grup.Id_Grupo, id_infr.ToString());
                        Obr.Confirming_Pendiente = BalanceCN.Saldo_Cuenta(Obr, Grup.Id_Grupo, id_infr.ToString());
                        break;
                    case 179:
                        Obr.C_RetencionGarantia = BalanceCN.Saldo_Cuenta(Obr, Grup.Id_Grupo, id_infr.ToString());
                        break;
                    case 180:
                        Obr.Confirming_Aceptado = BalanceCN.Saldo_Cuenta(Obr, Grup.Id_Grupo, id_infr.ToString());
                        break;

                    default:
                        break;
                }
            }

        }
        public List<int> Obras_Selecionadas_int()
        {
            List<int> l = new List<int>();
            foreach (object item in listObras.SelectedItems)
            {
                l.Add(((Obras)item).Id_Obra);
            }
            return l;
        }

        #endregion

        #region "Proceso Principal"
        public void Mostrar_Inform()
        {
            pderecha.Visible = true;
            //Limpiamos
            // Obr.Obras_Lineas = ImportacionCN.Importacion_Presupuesto(Obr);
            Obr.PREPARAOBRA();
            Cargar_y_Vista_tree();
            this.Text = "SEGUIMIENTO DEL PRESUPUESTO DE LA OBRA:" + Obr.Nombre + "";
            //lfeccertifi.Text = Obr.FechaCerti.ToString();
            CargaGridContable();

        }

        public void CargaGridContable()
        {
            DataTable dt = new DataTable();
            DataRow dr;
            dt.Columns.Add("Id_Grupo");
            dt.Columns.Add("Concepto");
            dt.Columns.Add("tip");
            dt.Columns.Add("Importe", Type.GetType("System.Double"));
            List<Grupos> lgrupostesoreria = GruposCN.Listar_solocontabilidastesoreria();

            foreach (Grupos Grup in lgrupostesoreria)
            {

                dr = dt.NewRow();
                dr["Concepto"] = Grup.Nombre;
                dr["Id_Grupo"] = Grup.Id_Grupo;

                switch (Grup.Id_Grupo)
                {
                    case 175:
                        dr["Importe"] = Obr.C_Total_Facturado;
                        dr["tip"] = "debe";
                        break;
                    case 179:
                        dr["Importe"] = Obr.C_RetencionGarantia;
                        dr["tip"] = "Saldo";
                        break;
                    case 180:
                        dr["Importe"] = Obr.Confirming_Aceptado;
                        dr["tip"] = "Saldo";
                        break;
                    case 181:
                        dr["Importe"] = Obr.Confirming_Pendiente;
                        dr["tip"] = "Saldo";
                        break;
                    default:
                        break;
                }
                dt.Rows.Add(dr);
            }
            dr = dt.NewRow();
            dr["Concepto"] = "TOTAL COBRADO";
            dr["Importe"] = (Obr.C_Total_Facturado) - (Obr.C_RetencionGarantia + Obr.Confirming_Aceptado + Obr.Confirming_Pendiente);
            dt.Rows.Add(dr);
            //dgcontabilidad.DataSource = dt;
            //dgcontabilidad.Columns["Concepto"].Width = 350;
            //dgcontabilidad.Columns["Importe"].Width = 150;
            //dgcontabilidad.Columns["Importe"].DefaultCellStyle.Format = "#,0";
            //dgcontabilidad.Columns["tip"].Visible = false;
            //dgcontabilidad.Columns["id_grupo"].Visible = false;

        }

        #endregion

        #region "Proceso Secundarios"
        public void DiseñoGrid()
        {
            pderecha.Visible = false;
            listObras.DataSource = Emp.Obras.Where(p => p.Id_Sigrid != 0 && p.Finalizada == false).ToList();
            listObras.DisplayMember = "Nombre";
            listObras.ValueMember = "id_Obra";
           
        }
        public void Cargar_y_Vista_tree()
        {
            Publico.CargaTree(Obr, treeobra, imageList1, 0, true, false, true, true, null,fase);
            Publico.CargaTree(Obr, treemetros, imageList1, 0, true, false, false, true, null,fase);

        }
        #endregion

        #region "EVENTOS"






        #endregion

        private void button3_Click(object sender, EventArgs e)
        {
            if (treeobra.SelectedNode == null) return;
            int id_Grupo = Convert.ToInt32(treeobra.SelectedNode.SubItems[Publico.Busca("id_grupo", treeobra)].Value);
            int id_subgrupo = Convert.ToInt32(treeobra.SelectedNode.SubItems[Publico.Busca("id_subgrupo", treeobra)].Value);
            Form_PartidasFactu f = new Form_PartidasFactu(Obr, id_Grupo, id_subgrupo,fase);
            f.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ContaWIN.M_PrintTREE.Print_DataGridView(treeobra, "", false, false, true, true);
        }

        private void ltitulo_Click(object sender, EventArgs e)
        {

        }

        private void rbcostereal_CheckedChanged(object sender, EventArgs e)
        {
            treeobra.Columns[Publico.Busca("Presupuestado", treeobra)].Visible = true;
            treeobra.Columns[Publico.Busca("%Presupuesto", treeobra)].Visible = true;
            treeobra.Columns[Publico.Busca("Presu_Venta", treeobra)].Visible = true;
            treeobra.Columns[Publico.Busca("%Presu_Venta", treeobra)].Visible = true;

            treeobra.Columns[Publico.Busca("CostePrevisto", treeobra)].Visible = false;
            treeobra.Columns[Publico.Busca("%Costeprevisto", treeobra)].Visible = false;
            treeobra.Columns[Publico.Busca("VentaPrevista", treeobra)].Visible = false;
            treeobra.Columns[Publico.Busca("%Ventaprevista", treeobra)].Visible = false;

        }

        private void rbincurrido_CheckedChanged(object sender, EventArgs e)
        {
            treeobra.Columns[Publico.Busca("Presupuestado", treeobra)].Visible = false;
            treeobra.Columns[Publico.Busca("%Presupuesto", treeobra)].Visible = false;
            treeobra.Columns[Publico.Busca("Presu_Venta", treeobra)].Visible = false;
            treeobra.Columns[Publico.Busca("%Presu_Venta", treeobra)].Visible = false;

            treeobra.Columns[Publico.Busca("CostePrevisto", treeobra)].Visible = true;
            treeobra.Columns[Publico.Busca("%Costeprevisto", treeobra)].Visible = true;
            treeobra.Columns[Publico.Busca("VentaPrevista", treeobra)].Visible = true;
            treeobra.Columns[Publico.Busca("%Ventaprevista", treeobra)].Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            int nodoselect;
            if (treeobra.SelectedNode == null) return;
            List<FacturasDetalles> Facturas;
            List<FacturasDetalles> Albaranes;
            List<FacturasDetalles> Partetrabajo;
            int id_Grupo = Convert.ToInt32(treeobra.SelectedNode.SubItems[Publico.Busca("id_grupo", treeobra)].Value);
            int id_subgrupo = Convert.ToInt32(treeobra.SelectedNode.SubItems[Publico.Busca("id_subgrupo", treeobra)].Value);
            nodoselect = (treeobra.SelectedNode.Level > 0) ? 2 : 1;
            if (Convert.ToString(treeobra.SelectedNode.SubItems[Publico.Busca("Nombre", treeobra)].Value) == "Total Seguimiento") nodoselect = 3;
            Facturas = Publico.DevuelveFactuli(Obr, nodoselect, "", id_Grupo, id_subgrupo);
            Albaranes = Publico.DevuelveAlbaranes(Obr, nodoselect, "", id_Grupo, id_subgrupo);
            Partetrabajo = Publico.DevuelveParteTrabajo(Obr, nodoselect, "", id_Grupo, id_subgrupo);
            Form_PartidasFactu_Det f = new Form_PartidasFactu_Det(Facturas, Albaranes, Partetrabajo, (nodoselect == 1) ? Obr.Obras_Lineas.Where(p=> p.Id_Fase == fase).Where(p => p.Id_Grupo == id_Grupo).ToList() : Obr.Obras_Lineas.Where(p => p.Id_Fase == fase).Where(p => p.Id_Grupo == id_Grupo && p.Id_Subgrupo == id_subgrupo).ToList());
            this.Cursor = Cursors.Default;
            f.ShowDialog();

        }
        private void treeobra_SelectedNodeChanged(object sender, EventArgs e)
        {


        }
        private void label2_Click(object sender, EventArgs e)
        {
            Publico.Diseño_(treeobra);
        }
        private void dgcontabilidad_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.ColumnIndex < 0 || e.RowIndex < 0) return;
            //try
            //{
            //    DataTable Dtdetalles = new DataTable();
            //    int id_grupo;
            //    string cuentas = string.Empty;
            //    if (Obr == null) return;
            //    id_grupo = (Convert.ToInt32(dgcontabilidad["id_grupo", e.RowIndex].Value) == 181) ? 175 : Convert.ToInt32(dgcontabilidad["id_grupo", e.RowIndex].Value);
            //    List <Cuentas> lcuentas = Cuentas_Participes(Obr.Nombre, id_grupo, id_infr.ToString());
            //    if (lcuentas != null)
            //    {
            //        foreach (Cuentas d in lcuentas.ToList())
            //        {
            //            d.Cuenta = "'" + d.Cuenta + "'";
            //        }
            //        cuentas = string.Join(",", lcuentas.Select(p => p.Cuenta).ToArray());
            //    }
            //    Dtdetalles = CalculoCN.Lineas_DetalleAsientos(Emp, 0, Obr.Id_Obra, cuentas,DateTime.Now);
            //    Form_FacturasCapitulos f = new Form_FacturasCapitulos(Dtdetalles);
            //    f.ShowDialog();
            //}
            //catch
            //{

            //}
        }
        public List<Cuentas> Cuentas_Participes(string Nombreobra, int id_grupo, string id_infor)
        {
            Obras Obr = ObraCN.Listar(Nombreobra);
            if (Obr != null)
            {
                return Obr.Balance.Where(b => b.Id_Informe == id_infor).Select(x => x.Cuentas).Where(x => x.Id_Grupo == id_grupo).GroupBy(x => x.Cuenta).Select(g => g.First()).ToList();
            }
            else
            { return null; }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            MuestraObras();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            MuestraObras();
        }
        public void MuestraObras()
        {
            if (radioButton1.Checked)
            {
                listObras.DataSource = Emp.Obras.Where(p => p.Id_Sigrid != 0 && p.Finalizada == false).ToList();
                listObras.DisplayMember = "Nombre";
                listObras.ValueMember = "id_Obra";

            }
            else
            {
                listObras.DataSource = Emp.Obras.Where(p => p.Id_Sigrid != 0 && p.Finalizada == true).ToList();
                listObras.DisplayMember = "Nombre";
                listObras.ValueMember = "id_Obra";

            }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Obr = Emp.Obras.Where(t => Obras_Selecionadas_int().Contains(t.Id_Obra)).ToList()[0];
            cbfases.DataSource = ObraCN.CargarFasesObra(Emp, Obr);
            cbfases.DisplayMember = "res";
            cbfases.ValueMember = "fasnum";
          
            id_infr = Guid.NewGuid();
            BalanceCN.Añadir(CalculoCN.Creacion_Informe(id_infr.ToString(), Emp, Emp.Obras.Where(t => t.Id_Obra == Obr.Id_Obra).ToList(), false, fase, DateTime.Today));
            linea_Ingresos();
            Mostrar_Inform();
            Emp = EmpresasCN.Listar(Emp.Id_Empresa);
            rbpresuactual.Checked = true;
            this.Cursor = Cursors.Default;
        }

        private void cbini_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void cbfases_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Obr = Emp.Obras.Where(t => Obras_Selecionadas_int().Contains(t.Id_Obra)).ToList()[0];
            fase = Convert.ToInt32(cbfases.SelectedValue);
                   
            Mostrar_Inform();
            Emp = EmpresasCN.Listar(Emp.Id_Empresa);
            rbpresuactual.Checked = true;
            this.Cursor = Cursors.Default;
        }
    }
}
