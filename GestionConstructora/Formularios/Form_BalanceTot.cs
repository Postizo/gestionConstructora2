using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio;
using Entidad;
using System.Reflection;
using System.Globalization;

namespace GestionConstructora
{
    public partial class Form_BalanceTo : Form
    {
        Guid id_infr = new Guid();
        DataTable dt = new DataTable();
        DataTable dtcomprobacion = new DataTable();
        DataTable dtpresupuestadas = new DataTable();
        DataTable dtcontabilidad = new DataTable();
        DataTable dtresumenObra = new DataTable();
        DataTable dtresumencontabilidad = new DataTable();      
        Empresas Emp = new Empresas();

        public Form_BalanceTo(Empresas Empresa)
        {
            Emp = Empresa;
            InitializeComponent();
            PreparaTabla();
            Diseño_form();
            pderecha.Visible = true;
            pgeneral.ColumnStyles[0].Width = 0;
            foreach (Empresas emp in EmpresasCN.Listar())
            {
                Emp = emp;// EmpresasCN.Listar(Emp.Id_Empresa);
                if (Emp.Obras.Count > 0)
                {
                    Calcular_Grid();
                }           
               
            }
            AgregaTotales(dt, 1);
            dglineas.DataSource = dt;
            AgregaTotales(dtpresupuestadas, 1);
            dgpresupuestados.DataSource = dtpresupuestadas;

        }
        private void Form_BalanceTo_Load(object sender, EventArgs e)
        {

        }
        private void Form_BalanceTo_Activated(object sender, EventArgs e)
        {                    
            Grid_Diseño(dglineas);
            Grid_Diseño(dgpresupuestados);
            Grid_Diseño_Principal();
        }     
        public void Diseño_form()
        {
            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic |
            BindingFlags.Instance | BindingFlags.SetProperty, null,
            dglineas, new object[] { true });
            pderecha.Visible = false;
            dglineas.AutoGenerateColumns = false;
            dglineas.EnableHeadersVisualStyles = false;
            dglineas.ColumnHeadersDefaultCellStyle.BackColor = Color.AliceBlue;
            dglineas.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dglineas.ColumnHeadersDefaultCellStyle.Font = new Font(FontFamily.GenericSansSerif, 9.0F, FontStyle.Bold);

            dgcomprobacion.AutoGenerateColumns = false;
            dgcomprobacion.EnableHeadersVisualStyles = false;
            dgcomprobacion.ColumnHeadersDefaultCellStyle.BackColor = Color.Honeydew;
            dgcomprobacion.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgcomprobacion.ColumnHeadersDefaultCellStyle.Font = new Font(FontFamily.GenericSansSerif, 9.0F, FontStyle.Bold);

            dgpresupuestados.AutoGenerateColumns = false;
            dgpresupuestados.EnableHeadersVisualStyles = false;
            dgpresupuestados.ColumnHeadersDefaultCellStyle.BackColor = Color.Honeydew;
            dgpresupuestados.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgpresupuestados.ColumnHeadersDefaultCellStyle.Font = new Font(FontFamily.GenericSansSerif, 9.0F, FontStyle.Bold);

            dgcontabilidad.AutoGenerateColumns = false;
            dgcontabilidad.EnableHeadersVisualStyles = false;
            dgcontabilidad.ColumnHeadersDefaultCellStyle.BackColor = Color.Honeydew;
            dgcontabilidad.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgcontabilidad.ColumnHeadersDefaultCellStyle.Font = new Font(FontFamily.GenericSansSerif, 9.0F, FontStyle.Bold);
        }
        public void PreparaTabla()
        {
            dt.Columns.Add("Id_Obra");
            dt.Columns.Add("Nombre");
            dt.Columns.Add("Tipo");
            dt.Columns.Add("P_Inicial", Type.GetType("System.Double"));
            dt.Columns.Add("P_Obra", Type.GetType("System.Double"));
            dt.Columns.Add("Desvio_P" , Type.GetType("System.Double"));
            dt.Columns.Add("Imp_CosteReal", Type.GetType("System.Double"));
            dt.Columns.Add("P_I_Venta", Type.GetType("System.Double"));
            dt.Columns.Add("P_Venta", Type.GetType("System.Double"));            
            dt.Columns.Add("B_Inicial", Type.GetType("System.Double"));
            dt.Columns.Add("B_Obra", Type.GetType("System.Double"));
            dt.Columns.Add("Certificaciones", Type.GetType("System.Double"));
            dt.Columns.Add("Cobro", Type.GetType("System.Double"));
            dt.Columns.Add("Pendiente_Cobro", Type.GetType("System.Double"));

            dtcomprobacion.Columns.Add("Concepto");
            dtcomprobacion.Columns.Add("Sigrid", Type.GetType("System.Double"));
            dtcomprobacion.Columns.Add("CW", Type.GetType("System.Double"));

            dtpresupuestadas.Columns.Add("Id_Obra");
            dtpresupuestadas.Columns.Add("Nombre");
            dtpresupuestadas.Columns.Add("P_Inicial", Type.GetType("System.Double"));
            dtpresupuestadas.Columns.Add("P_I_Venta", Type.GetType("System.Double"));
            dtpresupuestadas.Columns.Add("B_Inicial", Type.GetType("System.Double"));
            
            dtcontabilidad.Columns.Add("Id_Grupo");
            dtcontabilidad.Columns.Add("Concepto");
            dtcontabilidad.Columns.Add("tip");
            dtcontabilidad.Columns.Add("Importe", Type.GetType("System.Double"));
                   
            dtresumenObra.Columns.Add("Concepto"); 
            dtresumenObra.Columns.Add("Importe", Type.GetType("System.Double"));
        }
        private void Calcular_Grid()
        {            
            id_infr = Guid.NewGuid();
            List<Obras> L_Obras_Selecionadas = Emp.Obras.ToList(); 
            Check_Cuentas(L_Obras_Selecionadas);
            //Rellenamos el grid de las Obras en Curso
            foreach (Obras Obr in L_Obras_Selecionadas.Where(p => p.Id_Obra > 0 && p.Finalizada == false ).ToList())
            {
                BalanceCN.Añadir(CalculoCN.Creacion_Informe(id_infr.ToString(), Emp, Emp.Obras.Where(t => t.Id_Obra == Obr.Id_Obra).ToList(), false, 0, DateTime.Today));
                Cosas_CW(Obr);
                Agrega_Row(Obr);
            }
                                
            //Rellenamos el grid de las Obras en Curso
            foreach (Obras Obr in L_Obras_Selecionadas.Where(p => p.Id_Obra < 0).ToList())
            {
                Cosas_CW(Obr);
                Agrega_Row_Presupuestadas(Obr);
            }
          

        }
        public void rellenatablacomprobacion(Obras Obr)
        {
            dtcomprobacion.Rows.Clear();
            DataRow dr = dtcomprobacion.NewRow();
            dr["Concepto"] = "CERTIFICACIONES";
            dr["Sigrid"] = Obr.Obras_Lineas.Sum(p => p.Importe_Certificado);
            dr["CW"] = Obr.Total_Ingresos1_Conta;
            dtcomprobacion.Rows.Add(dr);          

            dr = dtcomprobacion.NewRow();            
            dr["Concepto"] = "MATERIALES";
            dr["Sigrid"] = Obr.Facturas_ca.Sum(p => p.Facturas_li.Sum(a => a.Base)) + Obr.Albaranes_ca.Sum(p => p.Albaran_li.Sum(a => a.Base));
            dr["CW"] = (Obr.Total_Gastosdirectos3_Conta + Obr.Total_GastosContribuciondirecta2_Conta) - Obr.Solo_Man_Obra;
            dtcomprobacion.Rows.Add(dr);

            dr = dtcomprobacion.NewRow();
            dr["Concepto"] = "MANO DE OBRA";
            dr["Sigrid"] = Obr.ParteTrabajo.Sum(p=> p.TotalImporte);
            dr["CW"] = Obr.Solo_Man_Obra;
            dtcomprobacion.Rows.Add(dr);          
            dgcomprobacion.DataSource = dtcomprobacion;
           
        }
        private void CargarGridResumenContabilidad(Obras Obr)
        {
            List<Obras> lOb = new List<Obras>();
            lOb.Add(Obr);
            dtresumencontabilidad.Rows.Clear();
            Form_Balance2.Mostrar_Inform(lOb, false, dtresumencontabilidad, dgresumencontable, id_infr,new List<int>());

            foreach (DataGridViewColumn col in dgresumencontable.Columns){col.Visible = false;}
            foreach (DataGridViewColumn col in dgresumencontable.Columns) { if (col.HeaderText == Obr.Nombre || col.HeaderText == "%" || col.HeaderText == "Concepto") col.Visible = true; }
         

        }
        public void CargaGridContable(Obras Obr)
        {
            dtcontabilidad.Rows.Clear();
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
            dr["Concepto"] = "TOTAL COBRADO";
            dr["Importe"] = (Obr.C_Total_Facturado) - (Obr.C_RetencionGarantia + Obr.Confirming_Aceptado + Obr.Confirming_Pendiente);
            dtcontabilidad.Rows.Add(dr);            
            dgcontabilidad.DataSource = dtcontabilidad;
            string specifier = "N";
            CultureInfo culture = CultureInfo.CreateSpecificCulture("es-ES");
            lcobrocliente.Text = "Pendiente de Cobro al Cliente...  " + Convert.ToDecimal ((Obr.C_Total_Facturado) - ((Obr.C_Total_Facturado) - (Obr.C_RetencionGarantia + Obr.Confirming_Aceptado + Obr.Confirming_Pendiente))).ToString(specifier, culture);

              

        }
        public void CargaresumenOnbra(Obras Obr)
        {
            //List<FacturasDetalles> Facturas = Publico.DevuelveFactuli(Obr, 3, "", 0, 0);
            //List<FacturasDetalles> Albaranes = Publico.DevuelveAlbaranes(Obr, 3, "", 0, 0);
            //List<FacturasDetalles> Partetrabajo = Publico.DevuelveParteTrabajo(Obr, 3, "", 0, 0);
            dtresumenObra.Rows.Clear();
            DataRow dr = dtresumenObra.NewRow();
            dr["Concepto"] = "FACTURAS";
            dr["Importe"] = Obr.Facturas_ca.Sum(p => p.Facturas_li.Sum(a => a.Base));
            dtresumenObra.Rows.Add(dr);
            dr = dtresumenObra.NewRow();
            dr["Concepto"] = "ALBARANES";
            dr["Importe"] = Obr.Albaranes_ca.Sum(p => p.Albaran_li.Sum(a => a.Base));
            dtresumenObra.Rows.Add(dr);
            dr = dtresumenObra.NewRow();
            dr["Concepto"] = "MANO DE OBRA";
            dr["Importe"] = Obr.ParteTrabajo.Sum(p => p.TotalImporte);
            dtresumenObra.Rows.Add(dr);
            AgregaTotales(dtresumenObra, 0);
            dgresumenObra.DataSource = dtresumenObra;
        }     

        public void Agrega_Row(Obras Obr)
        {
            DataRow dr= dt.NewRow();
            dr["Id_Obra"] = Obr.Id_Obra;
            dr["Nombre"] = Obr.Nombre;
            dr["Tipo"] = Obr.Tipo_Obra;
            dr["P_Inicial"] = Obr.P_Total_GastosContribuciondirecta2_Conta + Obr.P_Total_Gastosdirectos3_Conta;
            dr["P_Obra"] = Obr.Obras_Lineas.Sum(p => p.Importe_CostePrevisto);
            dr["Desvio_P"] =Convert.ToDecimal(dr["P_Obra"]) - Convert.ToDecimal(dr["P_Inicial"]);
            dr["Imp_CosteReal"] = Obr.Obras_Lineas.Sum(p => p.Importe_CosteReal);
            dr["P_I_Venta"] =  Obr.P_Total_Ingresos1_Conta;
            dr["P_Venta"] = Obr.Obras_Lineas.Sum(p => p.Importe_VentaPrevista);
            dr["B_Inicial"] = Convert.ToDecimal(dr["P_I_Venta"]) - Convert.ToDecimal(dr["P_Inicial"]);
            dr["B_Obra"] = Convert.ToDecimal(dr["P_Venta"]) - Convert.ToDecimal(dr["P_Obra"]);
            dr["Certificaciones"] = Obr.Obras_Lineas.Sum(p => p.Importe_Certificado);
            dr["Cobro"] = (Obr.C_Total_Facturado) - (Obr.C_RetencionGarantia + Obr.Confirming_Aceptado + Obr.Confirming_Pendiente);
            dr["Pendiente_Cobro"] = Convert.ToDecimal(dr["Certificaciones"]) - Convert.ToDecimal(dr["Cobro"]);
            dt.Rows.Add(dr);
        }
        public void Agrega_Row_Presupuestadas(Obras Obr)
        {
            DataRow dr = dtpresupuestadas .NewRow();
            dr["Id_Obra"] = Obr.Id_Obra;
            dr["Nombre"] = Obr.Nombre;           
            dr["P_Inicial"] = Obr.P_Total_GastosContribuciondirecta2_Conta + Obr.P_Total_Gastosdirectos3_Conta;
            dr["P_I_Venta"] =  Obr.P_Total_Ingresos1_Conta;
            dr["B_Inicial"] = Convert.ToDecimal(dr["P_I_Venta"]) - Convert.ToDecimal(dr["P_Inicial"]);           
            dtpresupuestadas.Rows.Add(dr);
        }
        public void Cosas_CW(Obras Obr)
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
            //GuARDAMOS LOS MAteriales y La MAno de OBRA
            Obr.Solo_Man_Obra = BalanceCN.GastosObra_Conta(Obr,118, id_infr.ToString());

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
        public void Check_Cuentas(List<Obras> l_Obras)
        {
            List<Cuentas> l = CalculoCN.Comprobacion_cuentas(Emp, l_Obras);
            List<string> le = new List<string>();
            foreach (Cuentas cuen in l)
            {
                DialogResult result = MessageBox.Show("¿Desea tratar la siguiente cuenta :" + cuen.Cuenta + "?", "Atencion", MessageBoxButtons.YesNoCancel);

                switch (result)
                {
                    case DialogResult.Yes:
                        Grupos Gr = GruposCN.Listar_por_Cuenta(Convert.ToInt32(cuen.Cuenta.Substring(0, 3)));
                        if (Gr != null)
                        {
                            CuentasCn.Añadir(Emp.Id_Empresa, cuen.Cuenta, cuen.Nombre, Gr.Id_Grupo, 0, true);
                        }
                        else
                        {
                            le.Add(cuen.Cuenta);
                            Form_AñadirCuentas f = new Form_AñadirCuentas(cuen);
                            f.ShowDialog();
                        }
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
        public void forma()
        {
            foreach (DataRow r in dt.Rows)
            {
                for (int i = 0; i < dt.Columns.Count; i++)
                { 
                    if (dt.Columns[i].DataType.Name == "Double")
                    {
                        if (r[i].ToString() == "") continue;
                        r[i] = Math.Round(Convert.ToDouble(r[i]), 0);
                    }
                }
            }
        }
        public void AgregaTotales(DataTable T,int  titulo)
        {
            Dictionary<int, double> Valores = new Dictionary<int, double>();
            foreach (DataColumn Col in T.Columns)
            {
                Valores.Add(Col.Ordinal, 0);
            }
            
            foreach (DataRow Row in T.Rows)
            {              
                foreach (DataColumn Col in T.Columns)
                {
                   
                    if (Col.DataType == Type.GetType("System.Double") || Col.DataType == Type.GetType("System.Decimal"))
                    {
                        if (Row[Col.Ordinal] == DBNull.Value) { Row[Col.Ordinal] = 0; }else { Row[Col.Ordinal] = Row[Col.Ordinal]; } 
                        Valores[Col.Ordinal] += Convert.ToDouble(Row[Col.Ordinal]);
                    }
                    
                }
            }
            DataRow dr = T.NewRow();
            dr[titulo] = "TOTALES";
            foreach (KeyValuePair<int, double> val in Valores)
            {
                if (val.Value != 0)  dr[val.Key] = val.Value;
            }
            T.Rows.Add(dr);            
        }

        public void Grid_Diseño(DataGridView dg)
        {
            foreach (DataGridViewRow Row in dg.Rows)
            {
                if (Row.Index == dg.Rows.Count -1)
                {
                    Row.DefaultCellStyle.Font = new Font(Font.FontFamily, 12);
                    Row.DefaultCellStyle.BackColor = Color.LightBlue;
                }
                foreach (DataGridViewCell cell in Row.Cells)
                {
                    if (cell.ValueType.Name  !="String" && cell.Value.ToString() !="") if (Convert.ToDecimal(cell.Value) < 0) cell.Style.ForeColor = Color.Red;
                }
            }
            dg.Refresh();
        }

        public void Grid_Diseño_Principal()
        {
            foreach (DataGridViewRow Row in dglineas.Rows)
            {
                if (Convert.ToDecimal(Row.Cells["P_Inicial"].Value) < Convert.ToDecimal(Row.Cells["P_Obra"].Value))
                    Row.Cells["P_Obra"].Style.ForeColor = Color.Red;
                else
                Row.Cells["P_Obra"].Style.ForeColor = Color.Green;
                if (Convert.ToDecimal(Row.Cells["P_I_Venta"].Value) > Convert.ToDecimal(Row.Cells["P_Venta"].Value))
                    Row.Cells["P_Venta"].Style.ForeColor = Color.Red;
                else
                Row.Cells["P_Venta"].Style.ForeColor = Color.Green;
                
                foreach (DataGridViewCell cell in Row.Cells)
                {
                   //
                }
            }
           
        }
       
        #region "Eventos"

        private void Form_Calculo_FormClosed(object sender, FormClosedEventArgs e)
        {
            BalanceCN.Borrar(id_infr.ToString());
        }

      
        private void button4_Click(object sender, EventArgs e)
        {
            string Title = Emp.Nombre;
            ContaWIN.M_PrintDGV.Print_DataGridView(dglineas, Title, true, false, true, true);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Excel File|*.xls";
            saveFileDialog1.Title = "Save an Excel File";
            saveFileDialog1.ShowDialog();
            forma();
            if (saveFileDialog1.FileName != "") Log_ErroresCN.ExportToExcel(dt, saveFileDialog1.FileName, "r");
        }

        private void dglineas_RowEnter(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dgcontabilidad_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0) return;
            try
            {
                DataTable Dtdetalles = new DataTable();
                int id_grupo;
                string cuentas = string.Empty;
                Obras Obr = Emp.Obras.Where(p => p.Id_Obra == Convert.ToInt32(dglineas["Id_Obra", dglineas.CurrentCell.RowIndex].Value)).ToList()[0];
                if (Obr == null) return;
                id_grupo = (Convert.ToInt32(dgcontabilidad["id_grupo", e.RowIndex].Value) == 181) ? 175 : Convert.ToInt32(dgcontabilidad["id_grupo", e.RowIndex].Value);
                List<Cuentas> lcuentas = Cuentas_Participes(Obr.Nombre, id_grupo, id_infr.ToString());
                if (lcuentas != null)
                {
                    foreach (Cuentas d in lcuentas.ToList())
                    {
                        d.Cuenta = "'" + d.Cuenta + "'";
                    }
                    cuentas = string.Join(",", lcuentas.Select(p => p.Cuenta).ToArray());
                }
                Dtdetalles = CalculoCN.Lineas_DetalleAsientos(Emp, 0, Obr.Id_Obra, cuentas, DateTime.Now);
                Form_FacturasCapitulos f = new Form_FacturasCapitulos(Dtdetalles,true );
                f.ShowDialog();
            }
            catch
            {

            }
        }
        private void dgresumencontable_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0) return;
            if (Convert.ToInt32(dgresumencontable["id_tipo", e.RowIndex].Value) == 50 && (dgresumencontable[e.ColumnIndex, e.RowIndex].OwningColumn.HeaderText != "TOTAL CIA")) return;
            try
            {
                DataTable Dtdetalles = new DataTable();
                Obras Obr = ObraCN.Listar(dgresumencontable.Columns[e.ColumnIndex].HeaderText);
                if (Convert.ToInt32(dgresumencontable["id_tipo", e.RowIndex].Value) == 50)
                {
                    Obr = ObraCN.Listar("GENERAL");
                }

                string cuentas = string.Empty;
                if (Obr == null) return;
                List<Cuentas> lcuentas = Cuentas_Participes(Obr.Nombre, Convert.ToInt32(dgresumencontable["id_grupo", e.RowIndex].Value), id_infr.ToString());

                if (lcuentas != null)
                {
                    foreach (Cuentas d in lcuentas.ToList())
                    {
                        d.Cuenta = "'" + d.Cuenta + "'";
                    }
                    cuentas = string.Join(",", lcuentas.Select(p => p.Cuenta).ToArray());
                }

                Dtdetalles = CalculoCN.Lineas_DetalleAsientos(Emp, 0, Obr.Id_Obra, cuentas, DateTime.Now);
                Form_FacturasCapitulos f = new Form_FacturasCapitulos(Dtdetalles,true);
                f.ShowDialog();
            }
            catch
            {

            }
        }





        #endregion

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Obras Obr = Emp.Obras.Where(p => p.Id_Obra == Convert.ToInt32(dglineas["Id_Obra", dglineas.CurrentCell.RowIndex].Value)).ToList()[0];
            if (tabControl1.SelectedTab.Name == "tabresumenconta")
            {
                CargarGridResumenContabilidad(ObraCN.Listar(Obr.Id_Obra,Emp.Id_Empresa));
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dglineas_MouseDoubleClick(object sender, MouseEventArgs e)
        {
         
           
        }

        private void dglineas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Obras Obrsele = ObraCN.Listar(dglineas["Nombre", e.RowIndex].Value.ToString());
            Empresas Empresasel = EmpresasCN.Listar(Obrsele.Id_Empresa);
            this.Cursor = Cursors.WaitCursor;
            Form_Caja f = new Form_Caja(Obrsele,id_infr, Convert.ToDateTime("01/01/0001 0:00:00"), Convert.ToDateTime("01/01/0001 0:00:00"));
          
            this.Cursor = Cursors.Default;
            f.ShowDialog();
        }
    }
}

//