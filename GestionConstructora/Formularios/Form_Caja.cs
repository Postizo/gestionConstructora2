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
    public partial class Form_Caja : Form
    {
        Guid id_infr = new Guid();
        Guid id_informemellegadelotro;
        DateTime fini, ffin;
        DataTable dt = new DataTable();
        DataTable dtcomprobacion = new DataTable();
        DataTable dtpresupuestadas = new DataTable();
        DataTable dtcontabilidad = new DataTable();
        DataTable dtresumenObra = new DataTable();
        DataTable dtresumencontabilidad = new DataTable();
        DataTable dtgastosporproveedor = new DataTable();
        DataTable dtgastosmanoobra = new DataTable();
        DataTable dtproveedores = new DataTable();

        Empresas Emp = new Empresas();
        Obras Obr = new Obras ();
        public Form_Caja(Empresas Empresa)
        {
            Emp = Empresa;
            Emp = EmpresasCN.Listar(Emp.Id_Empresa);
            InitializeComponent();
            Diseño_form();
            pderecha.Visible = true;
            PreparaTabla();
            pgeneral.ColumnStyles[0].Width = 0;
            Calcular_Grid(false);
        }
        public Form_Caja(Obras obr, Guid p_id_informemellegadelotro,DateTime p_fini,DateTime p_ffin)
        {          
            Emp = EmpresasCN.Listar(obr.Id_Empresa);
            Obr = obr;
            fini = p_fini;
            ffin = p_ffin;
          
            id_informemellegadelotro = p_id_informemellegadelotro;
            InitializeComponent();
            Diseño_form();
            pderecha.Visible = true;
            PreparaTabla();
            pgeneral.ColumnStyles[0].Width = 0;
            Calcular_Grid(true);      
            Form_Caja.Grid_Diseño(dgproveedores, this.Font);

            this.Text = "Caja Obra: " + Obr.Nombre + " Perido: " + fini + " - " + ffin;
        }

        private void Form_BalanceTo_Activated(object sender, EventArgs e)
        {
           
            Grid_Diseño(dglineas,this.Font );           
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
                      

            dgcontabilidad.AutoGenerateColumns = false;
            dgcontabilidad.EnableHeadersVisualStyles = false;
            dgcontabilidad.ColumnHeadersDefaultCellStyle.BackColor = Color.Honeydew;
            dgcontabilidad.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgcontabilidad.ColumnHeadersDefaultCellStyle.Font = new Font(FontFamily.GenericSansSerif, 9.0F, FontStyle.Bold);

            dggastosproveedor.AutoGenerateColumns = false;
            dggastosproveedor.EnableHeadersVisualStyles = false;
            dggastosproveedor.ColumnHeadersDefaultCellStyle.BackColor = Color.Honeydew;
            dggastosproveedor.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dggastosproveedor.ColumnHeadersDefaultCellStyle.Font = new Font(FontFamily.GenericSansSerif, 9.0F, FontStyle.Bold);


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
            dt.Columns.Add("Facturado-Certificado", Type.GetType("System.Double"));
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

            dtgastosporproveedor.Columns.Add("id_Proveedor");
            dtgastosporproveedor.Columns.Add("Proveedor");
            dtgastosporproveedor.Columns.Add("Importe", Type.GetType("System.Double"));

            dtgastosmanoobra.Columns.Add("Empleado");
            dtgastosmanoobra.Columns.Add("Importe", Type.GetType("System.Double"));
        }
        private void Calcular_Grid(bool solounaobra)
        {            
           
            List<Obras> L_Obras_Selecionadas = new List<Obras>();
            if (solounaobra)
            {
                L_Obras_Selecionadas = Emp.Obras.Where(p=> p.Id_Obra == Obr.Id_Obra).ToList();
                id_infr = id_informemellegadelotro;
                Check_Cuentas(L_Obras_Selecionadas);
                //Rellenamos el grid de las Obras en Curso
                foreach (Obras Obr in L_Obras_Selecionadas.Where(p => p.Id_Obra >= 0 && p.Finalizada == false).ToList())
                {
                    //BalanceCN.Añadir(CalculoCN.Creacion_Informe(id_infr.ToString(), Emp, Emp.Obras.Where(t => t.Id_Obra == Obr.Id_Obra).ToList(), false, 0, DateTime.Today));
                    Cosas_CW(Obr, id_infr);
                    Agrega_Row(Obr);
                }

                AgregaTotales(dt, 1);
                dglineas.DataSource = dt;
            }
            else
            {
                L_Obras_Selecionadas = Emp.Obras.ToList();
                id_infr = Guid.NewGuid();
                Check_Cuentas(L_Obras_Selecionadas);
                //Rellenamos el grid de las Obras en Curso
                foreach (Obras Obr in L_Obras_Selecionadas.Where(p => p.Id_Obra >= 0 && p.Finalizada == false).ToList())
                {
                    BalanceCN.Añadir(CalculoCN.Creacion_Informe(id_infr.ToString(), Emp, Emp.Obras.Where(t => t.Id_Obra == Obr.Id_Obra).ToList(), false, 0, DateTime.Today));
                    Cosas_CW(Obr, id_infr);
                    Agrega_Row(Obr);
                }

                AgregaTotales(dt, 1);
                dglineas.DataSource = dt;
            }
                      
           
                      
            ///Rellenamos el grid de las Obras en Curso
            //foreach (Obras Obr in L_Obras_Selecionadas.Where(p => p.Id_Obra < 0).ToList())
            //{
            //    Cosas_CW(Obr);
            //    Agrega_Row_Presupuestadas(Obr);
            //}
            //AgregaTotales(dtpresupuestadas, 1);
            //dgpresupuestados.DataSource = dtpresupuestadas;
                  
        }
        public void rellenaproveedores (Empresas Emp)
        {
            
            dtgastosporproveedor.Rows.Clear();
            DataRow dr = dtgastosporproveedor.NewRow();
            List<Facturas_ca> f = new List<Facturas_ca>();
            List<Obras> L_Obras_Selecionadas = Emp.Obras.Where(t => Obras_Selecionadas_int().Contains(t.Id_Obra)).ToList();
            foreach (Obras Obr in L_Obras_Selecionadas)
            {
                foreach (Facturas_ca fac in Obr.Facturas_ca)
                {
                    f.Add(fac);
                }
            }

            var Groupbyprovee = from p in f
                                group p by p.Id_proveedor   into g
                            select new Facturas_ca
                            {
                                Id_proveedor  = g.Key,
                                Base  = g.Sum(m=> m.Base),                              
                                Proveedor = g.Select(m => m.Proveedor).ToList()[0],
                             };


            foreach (Facturas_ca Fac in Groupbyprovee.ToList())
            {
                dr =  dtgastosporproveedor.NewRow();
                dr["Id_Proveedor"] = Fac.Id_proveedor;
                dr["Proveedor"] = Fac.Proveedor;
                dr["Importe"] = Fac.Base;
                dtgastosporproveedor.Rows.Add(dr);
            }                                    
            dggastosproveedor.DataSource = dtgastosporproveedor;
            AgregaTotales(dtgastosporproveedor, 1);
        }
        public void rellenamanoobra(Empresas Emp)
        {
            dtgastosmanoobra.Rows.Clear();
            DataRow dr = dtgastosmanoobra.NewRow();
            List<ParteTrabajo> Partes = new List<ParteTrabajo>();
            List<Obras> L_Obras_Selecionadas = Emp.Obras.Where(t => Obras_Selecionadas_int().Contains(t.Id_Obra)).ToList();
            foreach (Obras Obr in L_Obras_Selecionadas)
            {
                foreach (ParteTrabajo fac in Obr.ParteTrabajo)
                {
                    Partes.Add(fac);
                }
            }

            var Groupbyprovee = from p in Partes
                                group p by p.Empleado  into g
                                select new ParteTrabajo 
                                {
                                    Empleado = g.Key,
                                    TotalImporte = g.Sum(m => m.TotalImporte),
                                
                                };


            foreach (ParteTrabajo part in Groupbyprovee.ToList())
            {
                dr = dtgastosmanoobra.NewRow();              
                dr["Empleado"] = part.Empleado;
                dr["Importe"] = part.TotalImporte;
                dtgastosmanoobra.Rows.Add(dr);
            }
            dgempleados .DataSource = dtgastosmanoobra;
            AgregaTotales(dtgastosmanoobra, 0);
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
            Form_Balance2.Mostrar_Inform(lOb, false, dtresumencontabilidad, dgresumencontable, id_infr);

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
            dr["Concepto"] = "TOTAL INGRESADO EN BANCO";
            dr["Importe"] = (Obr.C_Total_Facturado) - (Obr.C_RetencionGarantia + Obr.Confirming_Aceptado + Obr.Confirming_Pendiente);
            dtcontabilidad.Rows.Add(dr);            
            dgcontabilidad.DataSource = dtcontabilidad;
            dgcontabilidad.Columns["Id_Grupo"].Visible = false;
            string specifier = "N";
            CultureInfo culture = CultureInfo.CreateSpecificCulture("es-ES");
            lcobrocliente.Text = "Pendiente de Cobro al Cliente...  " + Convert.ToDecimal ((Obr.C_Total_Facturado) - ((Obr.C_Total_Facturado) - (Obr.C_RetencionGarantia + Obr.Confirming_Aceptado + Obr.Confirming_Pendiente))).ToString(specifier, culture);
              

        }
        public void CargaresumenOnbra(Empresas Empr)
        {
            //List<FacturasDetalles> Facturas = Publico.DevuelveFactuli(Obr, 3, "", 0, 0);
            //List<FacturasDetalles> Albaranes = Publico.DevuelveAlbaranes(Obr, 3, "", 0, 0);
            //List<FacturasDetalles> Partetrabajo = Publico.DevuelveParteTrabajo(Obr, 3, "", 0, 0);
            dtresumenObra.Rows.Clear();
            DataRow dr = dtresumenObra.NewRow();
            dr["Concepto"] = "FACTURAS";
            dr["Importe"] = Emp.Obras.Where(t => Obras_Selecionadas_int().Contains(t.Id_Obra)).Sum(p=> p.Facturas_ca.Sum(i => i.Facturas_li.Sum(a => a.Base)));
            dtresumenObra.Rows.Add(dr);
            dr = dtresumenObra.NewRow();
            dr["Concepto"] = "ALBARANES";
            dr["Importe"] = Emp.Obras.Where(t => Obras_Selecionadas_int().Contains(t.Id_Obra)).Sum(p => p.Albaranes_ca .Sum(i => i.Albaran_li.Sum(a => a.Base)));
            dtresumenObra.Rows.Add(dr);
            dr = dtresumenObra.NewRow();
            dr["Concepto"] = "MANO DE OBRA";
            dr["Importe"] = Emp.Obras.Where(t => Obras_Selecionadas_int().Contains(t.Id_Obra)).Sum(i=> i.ParteTrabajo.Sum(p => p.TotalImporte));
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
            dr["Certificaciones"] =  Obr.Obras_Lineas.Sum(p => p.Importe_Certificado);
            dr["Cobro"] = (Obr.C_Total_Facturado) - (Obr.C_RetencionGarantia + Obr.Confirming_Aceptado + Obr.Confirming_Pendiente);
            dr["Pendiente_Cobro"] = Convert.ToDecimal(dr["Certificaciones"]) - Convert.ToDecimal(dr["Cobro"]);
            if (Obr.iva == false)
            {
                dr["Facturado-Certificado"] = Obr.C_Total_Facturado -  Convert.ToDecimal(dr["Certificaciones"]);
            }
            else
            {
                dr["Facturado-Certificado"] =  (Obr.C_Total_Facturado/ Convert.ToDecimal (1.21)) -  Convert.ToDecimal(dr["Certificaciones"]);
            }
         
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
        public static  void Cosas_CW(Obras Obr, Guid id_infr)
        {
            List<Grupos> lgrupos = GruposCN.Listar_solocontabilidad();
            List<Grupos> lgrupostesoreria = GruposCN.Listar_solocontabilidastesoreria();
            decimal Importe = 0;
            decimal presupuestado = 0;
            //Ingresos Directos
            foreach (Grupos Grup in lgrupos.Where(p => p.Id_TipoCoste == 1 && p.Id_Tipo ==0))
            {
                Importe = BalanceCN.IngresosObra_Conta(Obr, Grup.Id_Grupo, id_infr.ToString());
                presupuestado = (Obr.Presu_Conta.Where(p => p.id_Grupo == Grup.Id_Grupo).ToList().Count > 0) ? Obr.Presu_Conta.Where(p => p.id_Grupo == Grup.Id_Grupo).ToList()[0].Presupuestado : 0;
                Obr.Total_Ingresos1_Conta += Importe;
                Obr.P_Total_Ingresos1_Conta += presupuestado;
            }
            // Ingresos no repartir
            foreach (Grupos Grup in lgrupos.Where(p => p.Id_TipoCoste == 7 && p.Id_Tipo == 7))
            {
                Importe = BalanceCN.IngresosObra_Conta(Obr, Grup.Id_Grupo, id_infr.ToString());
                presupuestado = (Obr.Presu_Conta.Where(p => p.id_Grupo == Grup.Id_Grupo).ToList().Count > 0) ? Obr.Presu_Conta.Where(p => p.id_Grupo == Grup.Id_Grupo).ToList()[0].Presupuestado : 0;
                Obr.Total_restoIngresos7_Conta += Importe;
                Obr.P_Total_restoIngresos7_Conta += presupuestado;
            }
            //Gastos de contribucion directa
            foreach (Grupos Grup in lgrupos.Where(p => p.Id_Tipo == 1 && p.Id_TipoCoste == 2))
            {
                Importe = BalanceCN.GastosObra_Conta(Obr, Grup.Id_Grupo, id_infr.ToString());
                presupuestado = (Obr.Presu_Conta.Where(p => p.id_Grupo == Grup.Id_Grupo).ToList().Count > 0) ? Obr.Presu_Conta.Where(p => p.id_Grupo == Grup.Id_Grupo).ToList()[0].Presupuestado : 0;
                Obr.Total_GastosContribuciondirecta2_Conta += Importe;
                Obr.P_Total_GastosContribuciondirecta2_Conta += presupuestado;
            }
            //Gastos directos
            foreach (Grupos Grup in lgrupos.Where(p => p.Id_Tipo == 1 && p.Id_TipoCoste == 3))
            {
                Importe = BalanceCN.GastosObra_Conta(Obr, Grup.Id_Grupo, id_infr.ToString());
                presupuestado = (Obr.Presu_Conta.Where(p => p.id_Grupo == Grup.Id_Grupo).ToList().Count > 0) ? Obr.Presu_Conta.Where(p => p.id_Grupo == Grup.Id_Grupo).ToList()[0].Presupuestado : 0;
                Obr.Total_Gastosdirectos3_Conta += Importe;
                Obr.P_Total_Gastosdirectos3_Conta += presupuestado;
            }
            //hipotecas 
            foreach (Grupos Grup in lgrupos.Where(p => p.Id_TipoCoste == 16))
            {
                Importe = BalanceCN.Debe_Cuenta(Obr, Grup.Id_Grupo, id_infr.ToString());
                presupuestado = (Obr.Presu_Conta.Where(p => p.id_Grupo == Grup.Id_Grupo).ToList().Count > 0) ? Obr.Presu_Conta.Where(p => p.id_Grupo == Grup.Id_Grupo).ToList()[0].Presupuestado : 0;
                Obr.Total_Hipotecas += Importe;
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
        public static void AgregaTotales(DataTable T,int  titulo)
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
        public static void Grid_Diseño(DataGridView dg,Font fon)
        {
            foreach (DataGridViewRow Row in dg.Rows)
            {
                if (Row.Index == dg.Rows.Count -1)
                {
                    Row.DefaultCellStyle.Font = new Font(fon.FontFamily, 12);
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
            try
            {
                foreach (DataGridViewRow Row in dglineas.Rows)
                {
                    if (Convert.ToDecimal(Row.Cells["P_Inicial"].Value) > Convert.ToDecimal(Row.Cells["P_Obra"].Value))
                    {
                        Row.Cells["P_Obra"].Style.ForeColor = Color.Red;
                    }
                    else
                    {
                        Row.Cells["P_Obra"].Style.ForeColor = Color.Green;
                    }
                    foreach (DataGridViewCell cell in Row.Cells)
                    {
                        //
                    }
                }
            }
            catch (Exception)
            {

               
            }
            
           
        }
        #region "Eventos"

        private void Form_Calculo_FormClosed(object sender, FormClosedEventArgs e)
        {
          
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
        private void HideAllTabsOnTabControl(TabControl theTabControl)
        {
            theTabControl.Appearance = TabAppearance.FlatButtons;
            theTabControl.ItemSize = new Size(0, 1);
            theTabControl.SizeMode = TabSizeMode.Fixed;
        }
        private void ShowAllTabsOnTabControl(TabControl theTabControl)
        {
            theTabControl.Appearance = TabAppearance.Normal;
            theTabControl.ItemSize = new Size(83, 18);
            theTabControl.SizeMode = TabSizeMode.Fixed;
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
                if (fini != Convert.ToDateTime("01/01/0001 0:00:00"))
                { Dtdetalles = CalculoCN.Lineas_DetalleAsientos(Emp, Obr.Id_Obra, cuentas, fini, ffin); }
                else
                { Dtdetalles = CalculoCN.Lineas_DetalleAsientos(Emp, 0, Obr.Id_Obra, cuentas, DateTime.Now); }

                Form_FacturasCapitulos f = new Form_FacturasCapitulos(Dtdetalles,true);
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
                if (fini != Convert.ToDateTime("01/01/0001 0:00:00"))
                { Dtdetalles = CalculoCN.Lineas_DetalleAsientos(Emp,Obr.Id_Obra, cuentas,fini, ffin); }
                else
                { Dtdetalles = CalculoCN.Lineas_DetalleAsientos(Emp, 0, Obr.Id_Obra, cuentas, DateTime.Now); }
               
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

        private void bttverproveedores_Click_1(object sender, EventArgs e)
        {           
            dgresumenObra.Visible = false;
            dggastosproveedor.Visible = true;
            dgempleados.Visible = false ;
            rellenaproveedores(Emp);
            Grid_Diseño(dggastosproveedor,this.Font);
            bttverproveedores.Visible = false;
            bttverpersonal.Visible = false;
            bttatras.Visible = true;           
        }

        private void bttverpersonal_Click(object sender, EventArgs e)
        {         
            dgresumenObra.Visible = false;
            dggastosproveedor.Visible = false;
            dgempleados.Visible = true;
            rellenamanoobra(Emp);
            Grid_Diseño(dggastosproveedor,this.Font);
            bttverproveedores.Visible = false;
            bttverpersonal.Visible = false;
            bttatras.Visible = true;
        }

        private void pbotonessecundarios_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bttatras_Click(object sender, EventArgs e)
        {
            dgresumenObra.Visible = true;
            dggastosproveedor.Visible = false;
            dgempleados.Visible = false;
            bttatras.Visible = false;
            bttverproveedores.Visible = true;
            bttverpersonal.Visible = true;
            bttatras.Visible = false;
        }
        public List<int> Obras_Selecionadas_int()
        {
            List<int> l = new List<int>();
            foreach (DataGridViewRow row in dglineas.SelectedRows)
            {
                l.Add(Convert.ToInt32(row.Cells["id_obra"].Value));
            }
            return l;
        }

        private void dglineas_SelectionChanged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            bttatras.PerformClick();
            if (dglineas.SelectedRows.Count > 1)
            {
              
                tabControl1.SelectedIndex = 0;
              
                HideAllTabsOnTabControl(tabControl1);
                CargaresumenOnbra(Emp);
            }
            else
            {
                if (tabControl1.Appearance == TabAppearance.FlatButtons)
                {
                    ShowAllTabsOnTabControl(tabControl1);
                    tabControl1.SelectedIndex = 0;                   
                } 

                try
                {
                    // Emp = EmpresasCN.Listar(Emp.Id_Empresa);

                    Obras Obr = Emp.Obras.Where(p => p.Id_Obra == Convert.ToInt32(dglineas["Id_Obra", dglineas.CurrentCell.RowIndex].Value)).ToList()[0];
                    if (fini == Convert.ToDateTime("01/01/0001 0:00:00")) this.Text = "Caja Obra: " + Obr.Nombre + "   Perido Completo";
                    rellenatablacomprobacion(Obr);
                    CargaGridContable(Obr);
                    CargaresumenOnbra(Emp);
                    Grid_Diseño(dgresumenObra,this.Font);
                    Grid_Diseño_Principal();
                    Form_SaldoProveedores.Cargar(dtproveedores, Emp, "00", dgproveedores, Obr.Id_Obra,fini.Month,ffin.Month);
                    Form_Caja.Grid_Diseño(dgproveedores, this.Font);
                    if (tabControl1.SelectedTab.Name == "tabresumenconta") CargarGridResumenContabilidad(ObraCN.Listar(Obr.Id_Obra, Emp.Id_Empresa));


                }
                catch (Exception)
                {

                    //throw;
                }

            }




            this.Cursor = Cursors.Default;
        }
    }
}

//