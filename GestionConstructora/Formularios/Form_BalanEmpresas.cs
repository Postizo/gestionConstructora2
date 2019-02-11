using Entidad;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionConstructora
{
    public partial class Form_BalanEmpresas : Form
    {
        Guid id_infr = new Guid();
        Guid id_infrlocal = new Guid();
        DataTable dtcontabilidad = new DataTable();
        DataTable dtproveedores = new DataTable();

        DateTime fini;
        DateTime ffin;
        List<Obras> Obrselec = new List<Obras>();
        List<Empresas> Empresas = new List<Empresas>();
        List<Obras> ObrselecLocal = new List<Obras>();
        List<Obras> Obraspart = new List<Obras>();
        public Form_BalanEmpresas()
        {
            InitializeComponent();
            prepara();
            dgempresas.DataSource = EmpresasCN.Listar();

        }
        public void prepara()
        {
            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic |
               BindingFlags.Instance | BindingFlags.SetProperty, null,
               dgsubgrupos, new object[] { true });
            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic |
            BindingFlags.Instance | BindingFlags.SetProperty, null,
            dgresumen, new object[] { true });


            dgempresas.AutoGenerateColumns = false;
            dgempresas.EnableHeadersVisualStyles = false;
            dgempresas.ColumnHeadersDefaultCellStyle.BackColor = Color.AliceBlue;
            dgempresas.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgempresas.ColumnHeadersDefaultCellStyle.Font = new Font(FontFamily.GenericSansSerif, 9.0F, FontStyle.Bold);
            dgingresos.AutoGenerateColumns = false;
            dgingresos.EnableHeadersVisualStyles = false;
            dgingresos.ColumnHeadersDefaultCellStyle.BackColor = Color.AliceBlue;
            dgingresos.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgingresos.ColumnHeadersDefaultCellStyle.Font = new Font(FontFamily.GenericSansSerif, 9.0F, FontStyle.Bold);
            dggastos.AutoGenerateColumns = false;
            dggastos.EnableHeadersVisualStyles = false;
            dggastos.ColumnHeadersDefaultCellStyle.BackColor = Color.AliceBlue;
            dggastos.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dggastos.ColumnHeadersDefaultCellStyle.Font = new Font(FontFamily.GenericSansSerif, 9.0F, FontStyle.Bold);
            dgresultados.AutoGenerateColumns = false;
            dgresultados.EnableHeadersVisualStyles = false;
            dgresultados.ColumnHeadersDefaultCellStyle.BackColor = Color.AliceBlue;
            dgresultados.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgresultados.ColumnHeadersDefaultCellStyle.Font = new Font(FontFamily.GenericSansSerif, 9.0F, FontStyle.Bold);

            dgproveedores.AutoGenerateColumns = false;
            dgproveedores.EnableHeadersVisualStyles = false;
            dgproveedores.ColumnHeadersDefaultCellStyle.BackColor = Color.AliceBlue;
            dgproveedores.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgproveedores.ColumnHeadersDefaultCellStyle.Font = new Font(FontFamily.GenericSansSerif, 9.0F, FontStyle.Bold);

            dgobraspart.AutoGenerateColumns = false;
            dgobraspart.EnableHeadersVisualStyles = false;
            dgobraspart.ColumnHeadersDefaultCellStyle.BackColor = Color.AliceBlue;
            dgobraspart.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgobraspart.ColumnHeadersDefaultCellStyle.Font = new Font(FontFamily.GenericSansSerif, 9.0F, FontStyle.Bold);
            dgsubgrupos.Location = dgresumen.Location;
            dgsubgrupos.Size = dgresumen.Size;

            dtcontabilidad.Columns.Add("Id_Grupo");
            dtcontabilidad.Columns.Add("Concepto");
            dtcontabilidad.Columns.Add("tip");
            dtcontabilidad.Columns.Add("Importe", Type.GetType("System.Double"));
        }
        public void fechas()
        {
            fini = new DateTime(Convert.ToInt32(cbañoini.Text), Convert.ToInt32(cbini.SelectedIndex) + 1, 1);
            ffin = (cbfin.SelectedIndex ==11)?new DateTime(Convert.ToInt32(cbañofin.Text) +1, 1, 1).AddDays(-1): new DateTime(Convert.ToInt32(cbañofin.Text), Convert.ToInt32(cbfin.SelectedIndex) + 2, 1).AddDays(-1);
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgempresas.SelectedRows)
            {
                if (Convert.ToInt32(row.Cells["Id_Empresa"].Value) == 18 || Convert.ToInt32(row.Cells["Id_Empresa"].Value) == 19)
                {
                    gontraseña.Visible = true;
                    if (txtcontraseña.Text != "Conan8080") return;                   
                }
                else
                {
                    gontraseña.Visible = false;
                }
            }
           

            this.Cursor = Cursors.WaitCursor;
            id_infr = Guid.NewGuid();
            Empresas.Clear();
            foreach (DataGridViewRow row in dgempresas.SelectedRows)
            {
                Empresas.Add(EmpresasCN.Listar(Convert.ToInt32(row.Cells["Id_Empresa"].Value)));
            }
            

            foreach (Empresas Emp in Empresas)
            {
                Check_Cuentas(Emp.Obras.ToList(), Emp);
            }
            fechas();
            this.Text = "Balance de las Empresas: " + string.Join(" , ", Empresas.Select(p => p.Nombre.ToUpper()).ToArray()) + " DESDE: " + fini.ToShortDateString().ToUpper() + " HASTA: " + ffin.ToShortDateString().ToUpper();
            BalanceCN.Añadir(CalculoCN.Creacion_Informe(id_infr.ToString(), Empresas, false, 0, fini, ffin));

            CargarInforme();

            panel1.Visible = false;
            tab.Visible = true;
            button3.Visible = true;
            tab.Dock = DockStyle.Fill;
            Form_Caja.Grid_Diseño(dggastos, dggastos.Font);
            dgingresos.CurrentCell = null;
            dgingresos.Refresh();
            dggastos.Refresh();
            Form_Caja.Grid_Diseño(dgingresos, dgingresos.Font);
            dgingresos.Refresh();
            this.Cursor = Cursors.Default;

        }

        public void Check_Cuentas(List<Obras> l_Obras, Empresas Emp)
        {
            List<Cuentas> l = CalculoCN.Comprobacion_cuentas(Emp, l_Obras);
            List<string> le = new List<string>();
            foreach (Cuentas cuen in l)
            {
                DialogResult result = MessageBox.Show("¿Desea tratar la siguiente cuenta :" + cuen.Cuenta + "?", "Atencion", MessageBoxButtons.YesNoCancel);

                switch (result)
                {
                    case DialogResult.Yes:
                        //Grupos Gr = GruposCN.Listar_por_Cuenta(Convert.ToInt32(cuen.Cuenta.Substring(0, 3)));
                        //if (Gr != null)
                        //{
                        //    CuentasCn.Añadir(Emp.Id_Empresa, cuen.Cuenta, cuen.Nombre, Gr.Id_Grupo, 0, true);
                        //}
                        //else
                        //{
                        le.Add(cuen.Cuenta);
                        Form_AñadirCuentas f = new Form_AñadirCuentas(cuen);
                        f.ShowDialog();
                        // }
                        break;
                    case DialogResult.No:
                        cuen.Nombre = string.Empty;
                        cuen.Id_Grupo = 0;
                        cuen.Id_SubGrupo = 0;
                        CuentasCn.Añadir(cuen);
                        break;
                    case DialogResult.Cancel:
                        continue;
                }
            }
            Console.WriteLine();
        }

        public void CargarInforme()
        {
            DataTable dtingresos = new DataTable();
            DataTable dtgastos = new DataTable();
            DataTable dtresultados = new DataTable();

            decimal ImporteGastos = 0;
            decimal ImporteIngresos = 0;

            dtingresos.Columns.Add("Concepto");
            dtingresos.Columns.Add("Importe", Type.GetType("System.Double"));

            dtgastos.Columns.Add("Concepto");
            dtgastos.Columns.Add("Importe", Type.GetType("System.Double"));
             
            dtresultados.Columns.Add("Concepto");
            dtresultados.Columns.Add("Importe", Type.GetType("System.Double"));
            Obraspart.Clear();
            Obraspart = BalanceCN.Obras_EnBalance(id_infr.ToString()).OrderBy(p => p.Nombre).ToList();
            dgobraspart.DataSource = Obraspart;
            foreach (Obras Ob in Obraspart)
            {
                Form_Caja.Cosas_CW(Ob, id_infr);
                if (Ob.D_Presuca.ToList().Count > 0)
                {
                    Ob.D_Presuca.ToList()[0].D_Presuli.Clear();
                    Ob.D_Presuca.ToList()[0].D_Presuli = DEquiposCN.ListarLineas(Ob.D_Presuca.ToList()[0].id_presu);                   
                } 
            }

           
          
            CargaGridContable(Obraspart);


            List<Grupos> lgrupos = GruposCN.Listar_solocontabilidad();
            foreach (Grupos Grup in lgrupos.Where(p => p.Id_Tipo == 0 || p.Id_Tipo == 7))
            {
                DataRow Dr = dtingresos.NewRow();
                decimal Importe = 0;
                Dr["Concepto"] = Grup.Nombre;

                foreach (Empresas Emp in Empresas)
                {
                    foreach (Obras Obr in Emp.Obras)
                    {
                        Importe += BalanceCN.IngresosObra_Conta(Obr, Grup.Id_Grupo, id_infr.ToString());
                        ImporteIngresos += BalanceCN.IngresosObra_Conta(Obr, Grup.Id_Grupo, id_infr.ToString());
                    }
                }
                Dr["Importe"] = Importe;
                if (Importe > 0) dtingresos.Rows.Add(Dr);
            }
            Form_Caja.AgregaTotales(dtingresos, 0);
            dgingresos.DataSource = dtingresos;



            foreach (Grupos Grup in lgrupos.Where(p => p.Id_Tipo == 1))
            {
                DataRow Dr = dtgastos.NewRow();
                decimal Importe = 0;
                Dr["Concepto"] = Grup.Nombre;

                foreach (Empresas Emp in Empresas)
                {
                    foreach (Obras Obr in Emp.Obras)
                    {
                        Importe += BalanceCN.GastosObra_Conta(Obr, Grup.Id_Grupo, id_infr.ToString());
                        ImporteGastos += BalanceCN.GastosObra_Conta(Obr, Grup.Id_Grupo, id_infr.ToString());
                    }
                }
                Dr["Importe"] = Importe;
                if (Importe > 0) dtgastos.Rows.Add(Dr);
            }



            Form_Caja.AgregaTotales(dtgastos, 0);
            dggastos.DataSource = dtgastos;
            Form_Caja.Grid_Diseño(dggastos, dggastos.Font);


            DataRow Dl = dtresultados.NewRow();
            Dl["Concepto"] = "INGRESOS";
            Dl["Importe"] = ImporteIngresos;
            dtresultados.Rows.Add(Dl);

            Dl = dtresultados.NewRow();
            Dl["Concepto"] = "GASTOS";
            Dl["Importe"] = ImporteGastos;
            dtresultados.Rows.Add(Dl);

            Dl = dtresultados.NewRow();
            Dl["Concepto"] = "BENEFICIO / PERDIDA";
            Dl["Importe"] = ImporteIngresos - ImporteGastos;
            dtresultados.Rows.Add(Dl);
            dgresultados.DataSource = dtresultados;

            //linfo.Text = "BALANCE DE EMPRESAS: ";
            //foreach (Empresas Emp in Empresas)
            //{
            //    linfo.Text += Emp.Nombre + " ,";
            //}
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void dggastos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            //try
            //{
            //    DataTable Dtdetalles = new DataTable();
            //    Obras Obr = ObraCN.Listar(dgastos.Columns[e.ColumnIndex].HeaderText);
            //    if (Convert.ToInt32(dginforme["id_tipo", e.RowIndex].Value) == 50)
            //    {
            //        Obr = ObraCN.Listar("GENERAL");
            //    }

            //    string cuentas = string.Empty;
            //    if (Obr == null) return;
            //    List<Cuentas> lcuentas = Cuentas_Participes(Obr.Nombre, Convert.ToInt32(dginforme["id_grupo", e.RowIndex].Value), id_infr.ToString());

            //    if (lcuentas != null)
            //    {
            //        foreach (Cuentas d in lcuentas.ToList())
            //        {
            //            d.Cuenta = "'" + d.Cuenta + "'";
            //        }
            //        cuentas = string.Join(",", lcuentas.Select(p => p.Cuenta).ToArray());
            //    }

            //    Dtdetalles = CalculoCN.Lineas_DetalleAsientos(Emp, (Rbejercicios.Checked) ? Convert.ToInt32(cbejercicio.Text) : 0, Obr.Id_Obra, cuentas, flimite.Value);
            //    Form_FacturasCapitulos f = new Form_FacturasCapitulos(Dtdetalles);
            //    f.ShowDialog();
            //}
            //catch
            //{

            //}
        }

        private void tab_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tab.SelectedTab.Name == "tabPage3")
            {
                if (Empresas.Count == 1 && dgproveedores.Rows.Count <= 0)
                {
                    Form_SaldoProveedores.Cargar(dtproveedores, Empresas[0], "00", dgproveedores, -1, fini.Month, ffin.Month);
                    Form_Caja.Grid_Diseño(dgproveedores, this.Font);
                }
            }
        }
        private void dgingresos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //DataTable dtdetalles = new DataTable();

            //foreach (Empresas Emp in Empresas)
            //{
            //    decimal Importe = 0;
            //    foreach (Obras Obr in Emp.Obras)
            //    {
            //        DataRow Dr = dtdetalles.NewRow();
            //        Dr["Concepto"] = Obr.Nombre;

            //        dtgastosObra.Rows.Add(Dr);
            //        foreach (Grupos Grup in lgrupos.Where(p => p.Id_Tipo == 1 && p.))
            //        {
            //            Dr = dtgastosObra.NewRow();
            //            Importe = BalanceCN.GastosObra_Conta(Obr, Grup.Id_Grupo, id_infr.ToString());
            //            Dr["Concepto"] = Grup.Nombre;
            //            Dr["Importe"] = Importe;
            //            Dr["id_tip"] = 0;
            //            if (Importe > 0) dtgastosObra.Rows.Add(Dr);
            //        }


            //    }
            //}
            //dggastosobra.DataSource = dtgastosObra;

            //foreach (DataGridViewRow Row in dggastosobra.Rows)
            //{
            //    if (Convert.ToInt32(Row.Cells["id_tip"].Value) == 1)
            //    {
            //        Row.DefaultCellStyle.ForeColor = Color.Red;
            //        Row.DefaultCellStyle.BackColor = Color.WhiteSmoke;
            //        Row.DefaultCellStyle.Font = new Font(dggastosobra.Font, FontStyle.Bold);
            //    }
            //}
            //dggastosobra.Refresh();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool solototal = false;
            dgresumen.DataSource = null;
            dgresumen.Rows.Clear();
            Obrselec.Clear();
            DataTable dta = new DataTable();
            List<int> Ejercicios = new List<int>();
            for (int i = fini.Year; i <= ffin.Year; i++) Ejercicios.Add(i);

            foreach (DataGridViewRow Row in dgobraspart.SelectedRows)
            {
                Obrselec.Add(Obraspart.Where(p => p.Id_Obra == Convert.ToInt32(Row.Cells["Id_Obras"].Value)).Where(p => p.Id_Empresa == Convert.ToInt32(Row.Cells["Id_empres"].Value)).ToList()[0]);
            }
            if (Obrselec.Count == dgobraspart.Rows.Count) solototal = true;
            bool MostrarAjuste = (Obrselec.Where(p => p.Id_Empresa == 18 || p.Id_Empresa == 19).Count() > 0) ? false : true;

            // CALCULAR  Y REPRTIR EL AJUSTE GENERAL
            if (MostrarAjuste)
            {
                foreach (Obras Obr in Obrselec)
                {
                    Obr.PorcentajeSobeGenerales = 0;
                    Obr.RepercutidoGeneral19 = 0;
                }
                if (Obrselec.Where(x => x.Nombre.Contains(@"GENERAL")).ToList().Count > 0)
                {
                    decimal TotalGastosSinGeneral = Obrselec.Where(x => !x.Nombre.Contains(@"GENERAL")).ToList().Sum(p => p.Total_GastosContribuciondirecta2_Conta) + Obrselec.Where(x => !x.Nombre.Contains(@"GENERAL")).ToList().Sum(p => p.Total_Gastosdirectos3_Conta);
                    decimal TotalGastosGeneral = Obrselec.Where(x => x.Nombre.Contains(@"GENERAL")).ToList()[0].Total_GastosContribuciondirecta2_Conta + Obrselec.Where(x => x.Nombre.Contains(@"GENERAL")).ToList()[0].Total_Gastosdirectos3_Conta;
                    foreach (Obras Ob in Obrselec)
                    {
                        if (!Ob.Nombre.Contains(@"GENERAL"))
                        {
                            Ob.PorcentajeSobeGenerales = (Ob.Total_GastosContribuciondirecta2_Conta + Ob.Total_Gastosdirectos3_Conta) * 100 / TotalGastosSinGeneral;
                            Ob.RepercutidoGeneral19 = (Ob.PorcentajeSobeGenerales * TotalGastosGeneral) / 100;
                        }
                        else
                        {
                            Ob.RepercutidoGeneral19 = TotalGastosGeneral * -1;
                        }
                    }
                }
            }
            if (MostrarAjuste)
            {
                Form_Balance2.Mostrar_Inform2(Obrselec, false, dta, dgresumen, id_infr, Ejercicios);
            }
            else
            {                
                Form_Balance2.Mostrar_InformBATOR(Obrselec, false, dta, dgresumen, id_infr, Ejercicios, true);

            } 

            rbsolototales.Checked = (solototal)? true : false;
            dgresumen.Visible = true;
            rbimporte.Checked = true;
            Soloverpresu(true, rbsolototales.Checked);
            button3.Visible = true;
            button4.Visible = true;
            bttircaja.Visible = true;
            dgobraspart.Visible = false;
            label3.Visible = false;
            checkBox1.Visible = false;
            dgresumen.Dock = DockStyle.Fill;
            dgsubgrupos.Dock = DockStyle.Fill;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dgresumen.Visible == false && dgsubgrupos.Visible == false)
            {
                tab.Visible = false;
                panel1.Visible = true;
                return;
            }


            if (dgsubgrupos.Visible == true)
            {
                dgsubgrupos.Visible = false;
                dgresumen.Visible = true;


            }
            else
            {
                dgresumen.Visible = false;

                button4.Visible = false;
                bttircaja.Visible = false;
                dgobraspart.Visible = true;
                label3.Visible = true;
                checkBox1.Visible = true;
                button5.Text = "COMPLETA";
            }

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (rbimporte.Checked)
            {
                if (dgsubgrupos.Visible)
                    SoloverpresuSubgrupos(true);
                Soloverpresu(true, rbsolototales.Checked);

            }
            else
            {
                if (dgsubgrupos.Visible)
                    SoloverpresuSubgrupos(false);
                Soloverpresu(false, rbsolototales.Checked);
            }
        }
        private void Soloverpresu(bool flag,bool sologenerales)
        {
            if (flag)
            {
                foreach (DataGridViewColumn Col in dgresumen.Columns)
                {
                    Col.Visible = true;
                    if (Col.Name.Substring(0, 1) == "_" || Col.Name.Substring(0, 2) == "P_")
                    {
                        Col.Visible = false;
                    }
                    if (sologenerales)
                    {
                        if (Col.Name != "TOTAL CIA") Col.Visible = false;
                    }

                }


            }
            else
            {
                foreach (DataGridViewColumn Col in dgresumen.Columns)
                {
                    Col.Visible = false;
                    if (Col.Name.Substring(0, 1) == "_")
                    {
                        Col.Visible = true;
                        //if (sologenerales) if (Col.Name != "_TOTAL CIA") Col.Visible = false;
                    }
                   
                }
            }
            dgresumen.Columns["Concepto"].Visible = true;
            dgresumen.Columns["Id_concepto"].Visible = false;
            dgresumen.Columns["Id_Tipo"].Visible = false;
            dgresumen.Columns["Id_Grupo"].Visible = false;
            Form_Balance2.Grid_diseño2(dgresumen);
        }
        private void SoloverpresuSubgrupos(bool flag)
        {
            if (flag)
            {
                foreach (DataGridViewColumn Col in dgsubgrupos.Columns)
                {
                    Col.Visible = true;
                    if (Col.Name.Substring(0, 1) == "_" || Col.Name.Substring(0, 2) == "P_")
                    {
                        Col.Visible = false;
                    }
                }


            }
            else
            {
                foreach (DataGridViewColumn Col in dgsubgrupos.Columns)
                {
                    Col.Visible = false;
                    if (Col.Name.Substring(0, 1) == "_")
                    {
                        Col.Visible = true;
                    }
                }
            }
            dgsubgrupos.Columns["Concepto"].Visible = true;
            dgsubgrupos.Columns["Id_concepto"].Visible = false;
            dgsubgrupos.Columns["Id_Tipo"].Visible = false;
            dgsubgrupos.Columns["Id_Grupo"].Visible = false;
            Form_Balance2.Grid_diseño2(dgsubgrupos);
        }

        private void dgresumen_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {           
            Guid id_inforusar = new Guid();
            DateTime finilocal, ffinlocal;
            List<Obras> Obrasusar = new List<Obras>();
            if (button5.Text == "COMPLETA")
            {
                id_inforusar = id_infr;
                finilocal = fini;
                ffinlocal = ffin;
                Obrasusar = Obrselec;
            }
            else
            {
                id_inforusar = id_infrlocal;
                finilocal = DateTime.Today.AddYears(-100);
                ffinlocal = DateTime.Today;
                Obrasusar = ObrselecLocal;
            }
            if (e.ColumnIndex < 0 || e.RowIndex < 0) return;
            if (dgresumen[e.ColumnIndex, e.RowIndex].OwningColumn.HeaderText == "TOTAL SELEC") return;
            this.Cursor = Cursors.WaitCursor;
            // PARA MODIFICAR LOS AJUSTES
            if (Convert.ToInt32(dgresumen["id_tipo", e.RowIndex].Value) == 13 || Convert.ToInt32(dgresumen["id_tipo", e.RowIndex].Value) == 130 ||  Convert.ToInt32(dgresumen["id_tipo", e.RowIndex].Value) == 31 || Convert.ToInt32(dgresumen["id_tipo", e.RowIndex].Value) == 320 || Convert.ToInt32(dgresumen["id_tipo", e.RowIndex].Value) == 330)
            {
                Obras Obrrr = ObraCN.Listar(dgresumen.Columns[e.ColumnIndex].HeaderText);
                Form_AjusteGasto f = new Form_AjusteGasto(Obrrr);
                f.ShowDialog();            
                button3.PerformClick();
                button3.PerformClick();
                this.Cursor = Cursors.Default;
                return;
            }
            // PARA LOS TOTALES DE INGRESOS
            if (Convert.ToInt32(dgresumen["id_tipo", e.RowIndex].Value) == 11 )
            {
                DataTable Dtdetalles = new DataTable();
                List<int> id_gruposIngresos = new List<int>();
                List<Cuentas> lcuentas = new List<Cuentas>();
                Obras Obr = ObraCN.Listar(dgresumen.Columns[e.ColumnIndex].HeaderText);
                this.Cursor = Cursors.Default;
                if (Obr == null) return;
                List<Grupos> l = GruposCN.Listar_solocontabilidad().ToList().Where(p => p.Id_Tipo == 0 || p.Id_Tipo == 7).ToList();

                foreach (Grupos id in l)
                {
                    id_gruposIngresos.Add(id.Id_Grupo);
                }
                lcuentas = Form_Balance2.Cuentas_Participes(Obr.Nombre, id_gruposIngresos, id_inforusar.ToString());
                string cuentas = string.Empty;
                if (lcuentas != null)
                {
                    foreach (Cuentas d in lcuentas.ToList())
                    {
                        d.Cuenta = "'" + d.Cuenta + "'";
                    }
                    cuentas = string.Join(",", lcuentas.Select(p => p.Cuenta).ToArray());
                }

                Dtdetalles = CalculoCN.Lineas_DetalleAsientos(EmpresasCN.Listar(Obr.Id_Empresa), Obr.Id_Obra, cuentas, finilocal, ffinlocal);
                Form_FacturasCapitulos f = new Form_FacturasCapitulos(Dtdetalles,true);
                f.ShowDialog();
                this.Cursor = Cursors.Default;
                return;
            }

            // Para lo del Banco 
            if (Convert.ToInt32(dgresumen["id_tipo", e.RowIndex].Value) == 18)
            {
                Obras Obr = Obraspart.Where(p=> p.Nombre == dgresumen.Columns[e.ColumnIndex].HeaderText).ToList()[0] ;
                Form_FacturasCapitulos f = new Form_FacturasCapitulos(CargaGridbanco(Obr),false);
                f.ShowDialog();
                this.Cursor = Cursors.Default;
                return;            

            }

            DataTable dt = new DataTable();
            Form_Balance2.Mostrar_Inform2Ssubgrupo(Obrasusar, false, dt, dgsubgrupos, id_inforusar, Convert.ToInt32(dgresumen["id_grupo", e.RowIndex].Value));
            dgresumen.Visible = false;
            dgsubgrupos.Visible = true;
            SoloverpresuSubgrupos(true);
            Form_Caja.Grid_Diseño(dgsubgrupos, dgsubgrupos.Font);
            dgsubgrupos.Refresh();
            this.Cursor = Cursors.Default;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                foreach (DataGridViewRow Row in dgobraspart.Rows)
                {
                    Row.Selected = true;
                }
            }
            else
                foreach (DataGridViewRow Row in dgobraspart.Rows)
                {
                    Row.Selected = false;
                }
        }
        public void CargarInformeSubgrupos(int Id_Grupo)
        {

            DataTable dtsubgrupos = new DataTable();


            dtsubgrupos.Columns.Add("Concepto");
            dtsubgrupos.Columns.Add("Importe", Type.GetType("System.Double"));

            List<Grupos> lgrupos = GruposCN.Listar_solocontabilidad();
            foreach (Subgrupos SubGrup in lgrupos.Where(p => p.Id_Tipo == 1).Where(p => p.Id_Grupo == Id_Grupo).SelectMany(p => p.Subgrupos).ToList())
            {
                DataRow Dr = dtsubgrupos.NewRow();
                decimal Importe = 0;
                Dr["Concepto"] = SubGrup.Nombre;

                foreach (Empresas Emp in Empresas)
                {
                    foreach (Obras Obr in Emp.Obras)
                    {
                        Importe += BalanceCN.GastosObra_ContSubgruposa(Obr, SubGrup.Id_Subgrupo, id_infr.ToString());
                    }
                }
                Dr["Importe"] = Importe;
                if (Importe > 0) dtsubgrupos.Rows.Add(Dr);
            }
            Form_Caja.AgregaTotales(dtsubgrupos, 0);
            dgsubgrupos.DataSource = dtsubgrupos;
            Form_Caja.Grid_Diseño(dgingresos, dgingresos.Font);
        }


        private void button4_Click(object sender, EventArgs e)
        {
            string Title = "Informe creado a dia :" + DateTime.Now.ToShortDateString();
            if (dgresumen.Visible) ContaWIN.M_PrintDGV.Print_DataGridView(dgresumen, Title, false, false, true, true);
            if (dgsubgrupos.Visible) ContaWIN.M_PrintDGV.Print_DataGridView(dgsubgrupos, Title, false, false, true, true);

        }

        private void dgsubgrupos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0) return;
            if (Convert.ToInt32(dgsubgrupos["id_tipo", e.RowIndex].Value) == 50 && (dgsubgrupos[e.ColumnIndex, e.RowIndex].OwningColumn.HeaderText != "TOTAL CIA")) return;
            try
            {
                Guid id_inforusar = new Guid();
                DateTime finilocal, ffinlocal;
                List<Obras> Obrasusar = new List<Obras>();

                if (button5.Text == "COMPLETA")
                {
                    id_inforusar = id_infr;
                    finilocal = fini;
                    ffinlocal = ffin;
                    Obrasusar = Obrselec;
                }
                else
                {
                    id_inforusar = id_infrlocal;
                    finilocal = DateTime.Today.AddYears(-100);
                    ffinlocal = DateTime.Today;
                    Obrasusar = ObrselecLocal;
                }
                DataTable Dtdetalles = new DataTable();
                List<int> id_gruposIngresos = new List<int>();
                List<Cuentas> lcuentas = new List<Cuentas>();
                Obras Obr = ObraCN.Listar(dgsubgrupos.Columns[e.ColumnIndex].HeaderText);
                if (Obr == null) return;
                if (Convert.ToInt32(dgsubgrupos["id_tipo", e.RowIndex].Value) == 11)
                {
                    List<Grupos> l = GruposCN.Listar_solocontabilidad().ToList().Where(p => p.Id_Tipo == 0 || p.Id_Tipo == 7).ToList();

                    foreach (Grupos id in l)
                    {
                        id_gruposIngresos.Add(id.Id_Grupo);
                    }
                    lcuentas = Form_Balance2.Cuentas_Participes(Obr.Nombre, id_gruposIngresos, id_inforusar.ToString());

                }
                else
                {
                    lcuentas = Form_Balance2.Cuentas_ParticipesSubgrupos(Obr.Nombre, Convert.ToInt32(dgsubgrupos["id_grupo", e.RowIndex].Value), id_inforusar.ToString());
                }

                string cuentas = string.Empty;
                if (lcuentas != null)
                {
                    foreach (Cuentas d in lcuentas.ToList())
                    {
                        d.Cuenta = "'" + d.Cuenta + "'";
                    }
                    cuentas = string.Join(",", lcuentas.Select(p => p.Cuenta).ToArray());
                }

                Dtdetalles = CalculoCN.Lineas_DetalleAsientos(EmpresasCN.Listar(Obr.Id_Empresa), Obr.Id_Obra, cuentas, finilocal, ffinlocal);
                Form_FacturasCapitulos f = new Form_FacturasCapitulos(Dtdetalles,true);
                f.ShowDialog();
            }
            catch
            {

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Obras Obrsele = ObraCN.Listar(dgresumen.Columns[dgresumen.CurrentCell.ColumnIndex].HeaderText.ToString());
            if (Obrsele == null) return;
            Empresas Empresasel = EmpresasCN.Listar(Obrsele.Id_Empresa);
            this.Cursor = Cursors.WaitCursor;
            Form_Caja f;
            if (button5.Text == "COMPLETA")
            {
                f = new Form_Caja(Obrsele, id_infr, fini, ffin);
            }
            else
            {
                f = new Form_Caja(Obrsele, id_infrlocal, Convert.ToDateTime("01/01/0001 0:00:00"), Convert.ToDateTime("01/01/0001 0:00:00"));
            }

            this.Cursor = Cursors.Default;
            f.ShowDialog();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (button5.Text == "COMPLETA")
            {

                DataTable dt = new DataTable();
                ObrselecLocal = new List<Obras>();
                id_infrlocal = Guid.NewGuid();
                foreach (DataGridViewRow Row in dgobraspart.SelectedRows)
                {
                    ObrselecLocal.Add(ObraCN.Listar(Convert.ToInt32(Row.Cells["Id_Obras"].Value), Convert.ToInt32(Row.Cells["Id_empres"].Value)));
                }
                foreach (Obras Obr in ObrselecLocal)
                {
                    List<Obras> lisobr = new List<Obras>();
                    lisobr.Add(Obr);                    
                    BalanceCN.Añadir(CalculoCN.Creacion_Informe(id_infrlocal.ToString(), EmpresasCN.Listar(Obr.Id_Empresa), lisobr, true, 0, DateTime.Today));
                    Form_Caja.Cosas_CW(Obr, id_infrlocal);
                }
             
                dgresumen.DataSource = null;
                Form_Balance2.Mostrar_Inform2(ObrselecLocal, false, dt, dgresumen, id_infrlocal,new List<int>());
                Soloverpresu(true, rbsolototales.Checked);
                dgresumen.Refresh();
                button5.Text = "PERIODO SELECCIONADO";
            }
            else
            {
                dgresumen.DataSource = null;
                dgresumen.Rows.Clear();
                Obrselec.Clear();
                DataTable dta = new DataTable();
                foreach (DataGridViewRow Row in dgobraspart.SelectedRows)
                {
                    Obrselec.Add(Obraspart.Where(p => p.Id_Obra == Convert.ToInt32(Row.Cells["Id_Obras"].Value)).Where(p => p.Id_Empresa == Convert.ToInt32(Row.Cells["Id_empres"].Value)).ToList()[0]);
                }
              //  bool MostrarAjuste = (Obrselec.Where(p => p.Id_Empresa == 18).Count() > 0) ? false : true;
                Form_Balance2.Mostrar_Inform2(Obrselec, false, dta, dgresumen, id_infr,new List<int>());
                Soloverpresu(true, rbsolototales.Checked);
                button5.Text = "COMPLETA";
            }

            this.Cursor = Cursors.Default;
        }
        public void CargaGridContable(List<Obras> Obrs)
        {

            dtcontabilidad.Rows.Clear();
            decimal tot_facturado = 0, retencion = 0, confirming = 0, pendiente = 0;
            DataRow dr;
            List<Grupos> lgrupostesoreria = GruposCN.Listar_solocontabilidastesoreria();
            foreach (Grupos Grup in lgrupostesoreria)
            {
                dr = dtcontabilidad.NewRow();
                dr["Concepto"] = Grup.Nombre;
                dr["Id_Grupo"] = Grup.Id_Grupo;
                foreach (Obras Obr in Obrs)
                {
                    if (dr["Importe"] == DBNull.Value) dr["Importe"] = 0;
                    switch (Grup.Id_Grupo)
                    {
                        case 175:

                            tot_facturado = Convert.ToDecimal(dr["Importe"]) + Obr.C_Total_Facturado;
                            dr["Importe"] = Convert.ToDecimal(dr["Importe"]) + Obr.C_Total_Facturado;
                            dr["tip"] = "debe";
                            break;
                        case 179:
                            retencion = Convert.ToDecimal(dr["Importe"]) + Obr.C_RetencionGarantia;
                            dr["Importe"] = Convert.ToDecimal(dr["Importe"]) + Obr.C_RetencionGarantia;
                            dr["tip"] = "Saldo";
                            break;
                        case 180:
                            confirming = Convert.ToDecimal(dr["Importe"]) + Obr.Confirming_Aceptado;
                            dr["Importe"] = Convert.ToDecimal(dr["Importe"]) + Obr.Confirming_Aceptado;
                            dr["tip"] = "Saldo";
                            break;
                        case 181:
                            pendiente = Convert.ToDecimal(dr["Importe"]) + Obr.Confirming_Pendiente;
                            dr["Importe"] = Convert.ToDecimal(dr["Importe"]) + Obr.Confirming_Pendiente;
                            dr["tip"] = "Saldo";
                            break;
                        default:
                            break;
                    }
                }

                dtcontabilidad.Rows.Add(dr);
            }
            dr = dtcontabilidad.NewRow();
            dr["Concepto"] = "TOTAL INGRESADO EN BANCO";
            dr["Importe"] = (tot_facturado) - (retencion + confirming + pendiente);
            dtcontabilidad.Rows.Add(dr);
            dgcontabilidad.DataSource = dtcontabilidad;
            dgcontabilidad.Columns["Id_Grupo"].Visible = false;
            string specifier = "N";
            CultureInfo culture = CultureInfo.CreateSpecificCulture("es-ES");
            // lcobrocliente.Text = "Pendiente de Cobro al Cliente...  " + Convert.ToDecimal((Obr.C_Total_Facturado) - ((Obr.C_Total_Facturado) - (Obr.C_RetencionGarantia + Obr.Confirming_Aceptado + Obr.Confirming_Pendiente))).ToString(specifier, culture);


        }

        private void dgsubgrupos_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgresumen_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0) return;
            try
            {
                if (Convert.ToInt32(dgresumen["Id_Tipo", e.RowIndex].Value) == 13 || Convert.ToInt32(dgresumen["Id_Tipo", e.RowIndex].Value) == 130)
                {
                    DataGridViewCell cell = this.dgresumen.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    Obras Obr = ObraCN.Listar(dgresumen.Columns[e.ColumnIndex].Name);
                    cell.ToolTipText = "COMENTARIO AJUSTES OBRA:  \n" + Obr.Balance_Fijos.Where(p=> p.id_TipoCoste == 4).ToList()[0].Comentario;
                }
            }
            catch
            {

            }
        }
        public void  compruebaContraseña()
        {
           
         
        }
        public DataTable  CargaGridbanco(Obras Obr)
        {
            DataTable dtcontabilidad = new DataTable();
            dtcontabilidad.Columns.Add("Id_Grupo");
            dtcontabilidad.Columns.Add("Concepto");
            dtcontabilidad.Columns.Add("tip");
            dtcontabilidad.Columns.Add("Importe", Type.GetType("System.Double"));
            DataRow dr;
            List<Grupos> lgrupostesoreria = GruposCN.Listar_solocontabilidastesoreria();
            foreach (Grupos Grup in lgrupostesoreria)
            {
                dr = dtcontabilidad.NewRow();
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
                dtcontabilidad.Rows.Add(dr);
            }
            dr = dtcontabilidad.NewRow();
            dr["Concepto"] = "TOTAL INGRESADO EN BANCO";
            dr["Importe"] = (Obr.C_Total_Facturado) - (Obr.C_RetencionGarantia + Obr.Confirming_Aceptado + Obr.Confirming_Pendiente);
            dtcontabilidad.Rows.Add(dr);
            return dtcontabilidad;
    
        }

        private void txtcontraseña_TextChanged(object sender, EventArgs e)
        {
            button1.PerformClick();
        }

        private void rbtodas_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtodas.Checked) Soloverpresu(rbimporte.Checked, rbsolototales.Checked);
        }

        private void rbsolototales_CheckedChanged(object sender, EventArgs e)
        {
            if (rbsolototales.Checked) Soloverpresu(rbimporte.Checked, rbsolototales.Checked);
        }
        public void OcultaMuetsraTodas()
        {
           
        }
    }
}
