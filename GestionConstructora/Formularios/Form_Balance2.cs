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
    public partial class Form_Balance2 : Form
    {
        Guid id_infr = new Guid();
        DataTable dt = new DataTable();
     
        Empresas Emp = new Empresas();
        public Form_Balance2(Empresas Empresa)
        {
            Emp = Empresa;
            Emp = EmpresasCN.Listar(Emp.Id_Empresa);
            InitializeComponent();
           // DiseñoGrid();

        }
        public static DataRow Crea_Fila(DataRow Dr, Grupos Grup, List<Obras> L_Obras, Guid id_info)
        {
            Dr["Concepto"] = Grup.Nombre;
            Dr["Id_Grupo"] = Grup.Id_Grupo;
            Dr["Id_concepto"] = Grup.Id_TipoCoste;
            Dr["Id_Tipo"] = Grup.Id_TipoCoste * 10;
            Dr["TOTAL CIA"] = 0;
            Dr["P_TOTAL CIA"] = 0;
            foreach (Obras Obr in L_Obras)
            {
                decimal Importe = 0;
                decimal presupuestado = 0;
                switch (Convert.ToInt32(Dr["Id_Tipo"]))
                {
                    case 10: //Ingresos Directos
                        Importe = BalanceCN.IngresosObra_Conta(Obr, Grup.Id_Grupo, id_info.ToString());
                        presupuestado = (Obr.Presu_Conta.Where(p => p.id_Grupo == Grup.Id_Grupo).ToList().Count > 0) ? Obr.Presu_Conta.Where(p => p.id_Grupo == Grup.Id_Grupo).ToList()[0].Presupuestado : 0;
                        //Obr.Total_Ingresos1_Conta += Importe;
                        Dr[Obr.Nombre] = Importe;
                        Dr["P_" + Obr.Nombre] = presupuestado;
                        Obr.P_Total_Ingresos1_Conta += presupuestado;
                        break;
                    case 20: //Gastos de contribucion directa
                        Importe = BalanceCN.GastosObra_Conta(Obr, Grup.Id_Grupo, id_info.ToString());
                        presupuestado = (Obr.Presu_Conta.Where(p => p.id_Grupo == Grup.Id_Grupo).ToList().Count > 0) ? Obr.Presu_Conta.Where(p => p.id_Grupo == Grup.Id_Grupo).ToList()[0].Presupuestado : 0;
                        //Obr.Total_GastosContribuciondirecta2_Conta += Importe;
                        Dr[Obr.Nombre] = Importe;
                        Dr["P_" + Obr.Nombre] = presupuestado;
                        Obr.P_Total_GastosContribuciondirecta2_Conta += presupuestado;
                        break;
                    case 30: //Gastos directos
                        Importe = BalanceCN.GastosObra_Conta(Obr, Grup.Id_Grupo, id_info.ToString());
                        presupuestado = (Obr.Presu_Conta.Where(p => p.id_Grupo == Grup.Id_Grupo).ToList().Count > 0) ? Obr.Presu_Conta.Where(p => p.id_Grupo == Grup.Id_Grupo).ToList()[0].Presupuestado : 0;
                        //Obr.Total_Gastosdirectos3_Conta += Importe;
                        Dr[Obr.Nombre] = Importe;
                        Dr["P_" + Obr.Nombre] = presupuestado;
                        Obr.P_Total_Gastosdirectos3_Conta += presupuestado;
                        break;
                    case 160: //Hipotecas 
                        Importe = BalanceCN.Debe_Cuenta(Obr, Grup.Id_Grupo, id_info.ToString());
                        presupuestado = 0;
                        //Obr.Total_Hipotecas  += Importe;
                        Dr[Obr.Nombre] = Importe;
                        Dr["P_" + Obr.Nombre] = presupuestado;                       
                        break;
                    case 70: //Ingresos no repartir 
                        Importe = BalanceCN.IngresosObra_Conta(Obr, Grup.Id_Grupo, id_info.ToString());
                        presupuestado = (Obr.Presu_Conta.Where(p => p.id_Grupo == Grup.Id_Grupo).ToList().Count > 0) ? Obr.Presu_Conta.Where(p => p.id_Grupo == Grup.Id_Grupo).ToList()[0].Presupuestado : 0;
                        Dr[Obr.Nombre] = Importe;
                        //Obr.Total_restoIngresos7_Conta += Importe;
                        Dr["P_" + Obr.Nombre] = presupuestado;
                        Obr.P_Total_restoIngresos7_Conta += presupuestado;
                        break;
                    default:
                        Console.WriteLine("Default case");
                        break;
                }
                Dr["TOTAL CIA"] = Convert.ToDecimal(Dr["TOTAL CIA"]) + Importe;
                Dr["P_TOTAL CIA"] = Convert.ToDecimal(Dr["P_TOTAL CIA"]) + presupuestado;

            }
            return Dr;
        }
        public static DataRow Crea_FilaSubgrupos(DataRow Dr, Subgrupos Subgrup, List<Obras> L_Obras, Guid id_info)
        {
            Dr["Concepto"] = Subgrup.Nombre;
            Dr["Id_Grupo"] = Subgrup.Id_Subgrupo;
            Dr["Id_concepto"] = Subgrup.Grupos.Id_TipoCoste;
            Dr["Id_Tipo"] = Subgrup.Grupos.Id_TipoCoste * 10;
            Dr["TOTAL CIA"] = 0;
            Dr["P_TOTAL CIA"] = 0;
            foreach (Obras Obr in L_Obras)
            {
                decimal Importe = 0;
                decimal presupuestado = 0;
                switch (Convert.ToInt32(Dr["Id_Tipo"]))
                {
                    case 10: //Ingresos Directos
                        Importe = BalanceCN.IngresosObra_ContaSubgrupos(Obr, Subgrup.Id_Subgrupo, id_info.ToString());
                        //presupuestado = (Obr.Presu_Conta.Where(p => p.id_Grupo == Grup.Id_Grupo).ToList().Count > 0) ? Obr.Presu_Conta.Where(p => p.id_Grupo == Grup.Id_Grupo).ToList()[0].Presupuestado : 0;
                        Obr.Total_Ingresos1_Conta += Importe;
                        Dr[Obr.Nombre] = Importe;
                        Dr["P_" + Obr.Nombre] = presupuestado;
                        Obr.P_Total_Ingresos1_Conta += presupuestado;
                        break;
                    case 20: //Gastos de contribucion directa
                        Importe = BalanceCN.GastosObra_ContSubgruposa(Obr, Subgrup.Id_Subgrupo, id_info.ToString());
                        //presupuestado = (Obr.Presu_Conta.Where(p => p.id_Grupo == Grup.Id_Grupo).ToList().Count > 0) ? Obr.Presu_Conta.Where(p => p.id_Grupo == Grup.Id_Grupo).ToList()[0].Presupuestado : 0;
                        Obr.Total_GastosContribuciondirecta2_Conta += Importe;
                        Dr[Obr.Nombre] = Importe;
                        Dr["P_" + Obr.Nombre] = presupuestado;
                        Obr.P_Total_GastosContribuciondirecta2_Conta += presupuestado;
                        break;
                    case 30: //Gastos directos
                        Importe = BalanceCN.GastosObra_ContSubgruposa(Obr, Subgrup.Id_Subgrupo, id_info.ToString());
                       // presupuestado = (Obr.Presu_Conta.Where(p => p.id_Grupo == Grup.Id_Grupo).ToList().Count > 0) ? Obr.Presu_Conta.Where(p => p.id_Grupo == Grup.Id_Grupo).ToList()[0].Presupuestado : 0;
                        Obr.Total_Gastosdirectos3_Conta += Importe;
                        Dr[Obr.Nombre] = Importe;
                        Dr["P_" + Obr.Nombre] = presupuestado;
                        Obr.P_Total_Gastosdirectos3_Conta += presupuestado;
                        break;
                    case 70: //Ingresos no repartir 
                        Importe = BalanceCN.IngresosObra_ContaSubgrupos(Obr, Subgrup.Id_Subgrupo, id_info.ToString());
                       // presupuestado = (Obr.Presu_Conta.Where(p => p.id_Grupo == Grup.Id_Grupo).ToList().Count > 0) ? Obr.Presu_Conta.Where(p => p.id_Grupo == Grup.Id_Grupo).ToList()[0].Presupuestado : 0;
                        Dr[Obr.Nombre] = Importe;
                        Obr.Total_restoIngresos7_Conta += Importe;
                        Dr["P_" + Obr.Nombre] = presupuestado;
                        Obr.P_Total_restoIngresos7_Conta += presupuestado;
                        break;

                    default:
                        Console.WriteLine("Default case");
                        break;
                }
                Dr["TOTAL CIA"] = Convert.ToDecimal(Dr["TOTAL CIA"]) + Importe;
                Dr["P_TOTAL CIA"] = Convert.ToDecimal(Dr["P_TOTAL CIA"]) + presupuestado;

            }
            return Dr;
        }
        public static DataRow Crea_Fila_Totales(DataRow Dr, List<Obras> L_Obras, string Nombre, int Concepto, int tipo)
        {
            Dr["Concepto"] = Nombre;
            Dr["Id_concepto"] = Concepto;
            Dr["Id_Grupo"] = 0;
            Dr["Id_Tipo"] = tipo;
            Dr["TOTAL CIA"] = 0;
            Dr["P_TOTAL CIA"] = 0;

            foreach (Obras Obr in L_Obras)
            {
                decimal Importe = 0;
                decimal  presupuestado = 0;
                switch (tipo)
                {
                    case 1: //Ingresos Directos +
                        Importe = Obr.Total_Ingresos1_Conta;
                        presupuestado = Obr.P_Total_Ingresos1_Conta; ;
                        Dr[Obr.Nombre] = Importe;
                        Dr["P_" + Obr.Nombre] = presupuestado;
                        break;
                    case 11: //Ingresos 
                        Importe = Obr.Total_Ingresos1_Conta + Obr.Total_restoIngresos7_Conta;
                        presupuestado = Obr.P_Total_Ingresos1_Conta; ;
                        Dr[Obr.Nombre] = Importe;
                        Dr["P_" + Obr.Nombre] = presupuestado;
                        break;
                    case 2: //Gastos de contribucion directa
                        Importe = Obr.Total_GastosContribuciondirecta2_Conta;
                        presupuestado = Obr.P_Total_GastosContribuciondirecta2_Conta;
                        Dr[Obr.Nombre] = Importe;
                        Dr["P_" + Obr.Nombre] = presupuestado;
                        break;
                    case 3: //Gastos directos
                        Importe = Obr.Total_Gastosdirectos3_Conta;
                        presupuestado =  Obr.P_Total_Gastosdirectos3_Conta;
                        Dr[Obr.Nombre] = Importe;
                        Dr["P_" + Obr.Nombre] = presupuestado;
                        break;
                    case 10: //Gastos directos + Gastos de contribucion directa
                        Importe = Obr.Total_Gastosdirectos3_Conta + Obr.Total_GastosContribuciondirecta2_Conta;
                        presupuestado = Obr.P_Total_Gastosdirectos3_Conta + Obr.P_Total_GastosContribuciondirecta2_Conta;
                        Dr[Obr.Nombre] = Importe;
                        Dr["P_" + Obr.Nombre] = presupuestado;
                        break;
                    case 4: //TOTAL EXPLOTACION DIRECTA
                        Importe = Obr.Total_Ingresos1_Conta - (Obr.Total_GastosContribuciondirecta2_Conta + Obr.Total_Gastosdirectos3_Conta);
                        presupuestado = Obr.P_Total_Ingresos1_Conta - (Obr.P_Total_GastosContribuciondirecta2_Conta + Obr.P_Total_Gastosdirectos3_Conta); 
                        Dr[Obr.Nombre] = Importe;
                        Dr["P_" + Obr.Nombre] = presupuestado;
                        break;
                    case 5: //TOTAL GASTOS GENERALES
                        Importe = Obr.Total_GastosGENERAL5_Conta;
                        presupuestado = Obr.P_Total_GastosGENERAL5_Conta; 
                        Dr[Obr.Nombre] = Importe;
                        Dr["P_" + Obr.Nombre] = presupuestado;
                        break;
                    case 6: //TOTAL RESULTADO EXPLOTACION NETO 
                        Importe = (Obr.Total_Ingresos1_Conta - (Obr.Total_GastosContribuciondirecta2_Conta + Obr.Total_Gastosdirectos3_Conta)) - Obr.Total_GastosGENERAL5_Conta;
                        presupuestado = (Obr.P_Total_Ingresos1_Conta - (Obr.P_Total_GastosContribuciondirecta2_Conta + Obr.P_Total_Gastosdirectos3_Conta)) - Obr.P_Total_GastosGENERAL5_Conta;
                        Dr[Obr.Nombre] = Importe;
                        Dr["P_" + Obr.Nombre] = presupuestado;
                        break;
                    case 8: //TOTAL RESULTADO FINAL 
                        Importe = (Obr.Total_restoIngresos7_Conta + Obr.Total_Ingresos1_Conta) - (Obr.Total_GastosContribuciondirecta2_Conta + Obr.Total_Gastosdirectos3_Conta + Obr.Total_GastosGENERAL5_Conta);
                        presupuestado = (Obr.P_Total_restoIngresos7_Conta + Obr.P_Total_Ingresos1_Conta) - (Obr.P_Total_GastosContribuciondirecta2_Conta + Obr.P_Total_Gastosdirectos3_Conta + Obr.P_Total_GastosGENERAL5_Conta);
                        Dr[Obr.Nombre] = Importe;
                        Dr["P_" + Obr.Nombre] = presupuestado;
                        break;
                    case 13: //AJUSTE
                        Importe = Obr.Ajuste;
                        //presupuestado = (Obr.P_Total_restoIngresos7_Conta + Obr.P_Total_Ingresos1_Conta) - (Obr.P_Total_GastosContribuciondirecta2_Conta + Obr.P_Total_Gastosdirectos3_Conta + Obr.P_Total_GastosGENERAL5_Conta);
                        Dr[Obr.Nombre] = Importe;
                        Dr["P_" + Obr.Nombre] = presupuestado;
                        break;
                    case 14: // TOTAL RESULTADO FINAL - AJUSTE
                        Importe = (Obr.Total_restoIngresos7_Conta + Obr.Total_Ingresos1_Conta) - (Obr.Total_GastosContribuciondirecta2_Conta + Obr.Total_Gastosdirectos3_Conta + Obr.Total_GastosGENERAL5_Conta +Obr.Ajuste);
                        //presupuestado = (Obr.P_Total_restoIngresos7_Conta + Obr.P_Total_Ingresos1_Conta) - (Obr.P_Total_GastosContribuciondirecta2_Conta + Obr.P_Total_Gastosdirectos3_Conta + Obr.P_Total_GastosGENERAL5_Conta);
                        Dr[Obr.Nombre] = Importe;
                        Dr["P_" + Obr.Nombre] = presupuestado;
                        break;
                    case 16: //TOTAL HIPOTECAS FINAL 
                        Importe = Obr.Total_Hipotecas;
                        presupuestado = 0;
                        Dr[Obr.Nombre] = Importe;
                        Dr["P_" + Obr.Nombre] = presupuestado;
                        break;
                    case 17: //TOTAL RESULTADO FINAL 
                        Importe =((Obr.Total_restoIngresos7_Conta + Obr.Total_Ingresos1_Conta) - (Obr.Total_GastosContribuciondirecta2_Conta + Obr.Total_Gastosdirectos3_Conta + Obr.Total_GastosGENERAL5_Conta)) - (Obr.Total_Hipotecas + Obr.Ajuste);
                        presupuestado = 0;
                        Dr[Obr.Nombre] = Importe;
                        Dr["P_" + Obr.Nombre] = presupuestado;
                        break;
                    case 18: //BANCO
                        Importe = (Obr.C_Total_Facturado) - (Obr.C_RetencionGarantia + Obr.Confirming_Aceptado + Obr.Confirming_Pendiente);
                        presupuestado = 0;
                        Dr[Obr.Nombre] = Importe;
                        Dr["P_" + Obr.Nombre] = presupuestado;
                        break;

                    case 90: //TOTAL PRESUPUESTO COSTE 
                        Importe = Obr.Obras_Lineas.Where(p=> p.Id_Fase ==0).Sum(p => p.Importe_CostePrevisto);
                        if (Importe == 0) if (Obr.D_Presuca.Count > 0) Importe = Obr.D_Presuca.ToList()[0].D_Presuli.Sum(p => (p.Costo * p.unidades) + (p.Mo_Impor * p.unidades) + (p.Gastos_Generales * p.unidades));
                                            
                         
                        // presupuestado = (Obr.P_Total_restoIngresos7_Conta + Obr.P_Total_Ingresos1_Conta) - (Obr.P_Total_GastosContribuciondirecta2_Conta + Obr.P_Total_Gastosdirectos3_Conta + Obr.P_Total_GastosGENERAL5_Conta);
                        Dr[Obr.Nombre] = Importe;
                        Dr["P_" + Obr.Nombre] = presupuestado;
                        break;
                    case 91: //TOTAL PRESUPUESTO VENTA 
                        Importe = Obr.Obras_Lineas.Where(p => p.Id_Fase == 0).Sum(p => p.Importe_VentaPrevista); ;
                        if (Importe == 0) if (Obr.D_Presuca.Count > 0) Importe = Obr.D_Presuca.ToList()[0].D_Presuli.Sum(p => (p.Tot_Unidad * p.unidades));
                        // presupuestado = (Obr.P_Total_restoIngresos7_Conta + Obr.P_Total_Ingresos1_Conta) - (Obr.P_Total_GastosContribuciondirecta2_Conta + Obr.P_Total_Gastosdirectos3_Conta + Obr.P_Total_GastosGENERAL5_Conta);
                        Dr[Obr.Nombre] = Importe;
                        Dr["P_" + Obr.Nombre] = presupuestado;
                        break;
                    case 92: //   TOTAL PRESUPUESTO COSTE  - TOTAL PRESUPUESTO VENTA 
                        Importe = (Obr.Obras_Lineas.Where(p => p.Id_Fase == 0).Sum(p => p.Importe_VentaPrevista))-(Obr.Obras_Lineas.Where(p => p.Id_Fase == 0).Sum(p => p.Importe_CostePrevisto));
                        if (Importe == 0) if (Obr.D_Presuca.Count > 0) Importe = Obr.D_Presuca.ToList()[0].D_Presuli.Sum(p => (p.Tot_Unidad * p.unidades) - ((p.Costo * p.unidades) + (p.Mo_Impor * p.unidades) + (p.Gastos_Generales * p.unidades)));
                        // presupuestado = (Obr.P_Total_restoIngresos7_Conta + Obr.P_Total_Ingresos1_Conta) - (Obr.P_Total_GastosContribuciondirecta2_Conta + Obr.P_Total_Gastosdirectos3_Conta + Obr.P_Total_GastosGENERAL5_Conta);
                        Dr[Obr.Nombre] = Importe;
                        Dr["P_" + Obr.Nombre] = presupuestado;
                        break;
                    default:
                      
                        break;
                }
                Dr["TOTAL CIA"] = Convert.ToDecimal(Dr["TOTAL CIA"]) + Importe;
                Dr["P_TOTAL CIA"] = Convert.ToDecimal(Dr["P_TOTAL CIA"]) + presupuestado;
            }
            return Dr;
        }
        public static  DataRow Crea_Fila_Generales(DataRow Dr, Grupos Grup, List<Obras> L_Obras, Guid id_info)
        {
           
            Dr["Concepto"] = Grup.Nombre;
            Dr["Id_Grupo"] = Grup.Id_Grupo;
            Dr["Id_concepto"] = Grup.Id_TipoCoste;
            Dr["Id_Tipo"] = 5 * 10;
            Dr["TOTAL CIA"] = 0;
            foreach (Obras Obr in L_Obras.Where(p => p.Nombre == "GENERAL").ToList())
            {             
                decimal Importe = BalanceCN.GastosObra_Conta(Obr, Grup.Id_Grupo, id_info.ToString());
                Obr.Total_GastosGENERAL5_Conta += Importe;
                Dr["TOTAL CIA"] = Importe;
            }

            foreach (Obras Obr in L_Obras.Where(p => p.Nombre != "GENERAL").ToList())
            {

                decimal Tot_General = L_Obras.Where(p => p.Nombre != "GENERAL").ToList().Sum(p => p.Total_GastosContribuciondirecta2_Conta + p.Total_Gastosdirectos3_Conta);
                decimal Tot_Obra = Obr.Total_GastosContribuciondirecta2_Conta + Obr.Total_Gastosdirectos3_Conta;
                decimal coefe = (Tot_Obra * 100) / Tot_General;
                decimal repartir = Convert.ToDecimal(Dr["TOTAL CIA"]);
                if (repartir == 0) continue;
                decimal Importe = (coefe * repartir) / 100;
                Obr.Total_GastosGENERAL5_Conta += Importe;
                Dr[Obr.Nombre] = Importe;
            }

            return Dr;
        }
        public static void Mostrar_Inform(List<Obras> L_Obras, bool congenerales,DataTable dt, DataGridView dg, Guid id_infro)
        {
            //Limpiamos 

            dt = new DataTable();
            DataRow R_TotGastos = dt.NewRow();
            DataRow R_Totales = dt.NewRow();
            dg.DataSource = null;
            dg.Columns.Clear();
            dg.Rows.Clear();


            List<Grupos> lgrupos = GruposCN.Listar_solocontabilidad();

            //CREAMOS LA TABLA EN MEMORIA
            dt.Columns.Add("Concepto");
            dt.Columns.Add("Id_concepto");
            dt.Columns.Add("Id_Tipo");
            dt.Columns.Add("Id_Grupo");


            foreach (Obras Obr in L_Obras)
            {
                dt.Columns.Add("P_" + Obr.Nombre, Type.GetType("System.Double"));
                dt.Columns.Add(Obr.Nombre, Type.GetType("System.Double"));
                dt.Columns.Add("_" + Obr.Nombre, Type.GetType("System.Double"));
            }
            dt.Columns.Add("TOTAL CIA", Type.GetType("System.Double"));
            dt.Columns.Add("P_TOTAL CIA", Type.GetType("System.Double"));
            //AGREGAMOS LOS INGRESOS
            foreach (Grupos Grup in lgrupos.Where(p => p.Id_Tipo == 0))
            {
                DataRow Dr = dt.NewRow();
                Crea_Fila(Dr, Grup, L_Obras.Where(p => p.Nombre != "GENERAL").ToList(), id_infro);
                dt.Rows.Add(Dr);
            }
            //--------------------TOTALES INGRESOS 1
            R_Totales = dt.NewRow();
            Crea_Fila_Totales(R_Totales, L_Obras, "TOT. INGRESOS DIRECTOS", 1, 1);
            dt.Rows.Add(R_Totales);

            //AGREGAMOS LOS GASTOS DE CONTIBUCION DIRECTA
            foreach (Grupos Grup in lgrupos.Where(p => p.Id_Tipo == 1 && p.Id_TipoCoste == 2))
            {
                DataRow Dr = dt.NewRow();
                Crea_Fila(Dr, Grup, L_Obras.Where(p => p.Nombre != "GENERAL").ToList(), id_infro);
                if (Convert.ToDecimal(Dr["TOTAL CIA"]) != 0 || Convert.ToDecimal(Dr["P_TOTAL CIA"]) != 0) dt.Rows.Add(Dr);
            }
            //--------------------AGREGAMOS  GASTOS DE CONTIBUCION DIRECTA 2
            R_Totales = dt.NewRow();
            Crea_Fila_Totales(R_Totales, L_Obras, "TOT. GASTOS DE CONTIBUCION DIRECTA", 2, 2);
            dt.Rows.Add(R_Totales);

            //AGREGAMOS LOS GASTOS DIRECTOS
            foreach (Grupos Grup in lgrupos.Where(p => p.Id_Tipo == 1 && p.Id_TipoCoste == 3))
            {
                DataRow Dr = dt.NewRow();
                Crea_Fila(Dr, Grup, L_Obras.Where(p => p.Nombre != "GENERAL").ToList(), id_infro);
                if (Convert.ToDecimal(Dr["TOTAL CIA"]) != 0 || Convert.ToDecimal(Dr["P_TOTAL CIA"]) != 0) dt.Rows.Add(Dr);
            }
            //--------------------AGREGAMOS TOTALES GASTOS DIRECTOS 3
            R_Totales = dt.NewRow();
            Crea_Fila_Totales(R_Totales, L_Obras, "TOT. GASTOS DIRECTOS", 3, 3);
            dt.Rows.Add(R_Totales);

            //--------------------AGREGAMOS TOTALES RESULTADO DE EXPLOTACION DIRECTA 4
            if (congenerales)
            {

                R_Totales = dt.NewRow();
                Crea_Fila_Totales(R_Totales, L_Obras, "TOT. EXPLOTACION DIRECTO", 4, 4);
                dt.Rows.Add(R_Totales);

                // AGREGAMOS LOS GASTOS GENERALES
                foreach (Grupos Grup in lgrupos.Where(p => p.Id_Tipo == 1))
                {
                    DataRow Dr = dt.NewRow();
                    Crea_Fila_Generales(Dr, Grup, L_Obras.ToList(), id_infro);
                    if (Convert.ToDecimal(Dr["TOTAL CIA"]) != 0) dt.Rows.Add(Dr);
                }

                //--------------------AGREGAMOS TOTALES GASTOS GENERALES 5
                R_Totales = dt.NewRow();
                Crea_Fila_Totales(R_Totales, L_Obras.Where(p => p.Nombre != "GENERAL").ToList(), "TOT. GASTOS GENERALES", 5, 5);
                dt.Rows.Add(R_Totales);
                //--------------------AGREGAMOS TOTALES RESULTADO DE EXPLOTACION NETO 6
                R_Totales = dt.NewRow();
                Crea_Fila_Totales(R_Totales, L_Obras.Where(p => p.Nombre != "GENERAL").ToList(), "TOT. EXPLOTACION DIRECTO GENERALES", 6, 6);
                dt.Rows.Add(R_Totales);
            }

            // AGREGAMOS LOS INGRESOS NO REPARTIR

            foreach (Grupos Grup in lgrupos.Where(p => p.Id_Tipo == 7))
            {
                DataRow Dr = dt.NewRow();
                Crea_Fila(Dr, Grup, L_Obras, id_infro);
                if (Convert.ToDecimal(Dr["TOTAL CIA"]) != 0) dt.Rows.Add(Dr);
            }

            //--------------------AGREGAMOS TOTALES RESULTADO 8
            R_Totales = dt.NewRow();
            Crea_Fila_Totales(R_Totales, L_Obras.Where(p => p.Nombre != "GENERAL").ToList(), "TOT. RESULTADO FINAL", 8, 8);
            dt.Rows.Add(R_Totales);


            foreach (DataRow row in dt.Rows)
            {
                foreach (Obras Obr in L_Obras)
                {
                    //   if ( Convert.ToInt32(row["Id_Tipo"]) == 4 || Convert.ToInt32(row["Id_Tipo"]) == 6 || Convert.ToInt32(row["Id_Tipo"]) == 8) continue;
                    row["_" + Obr.Nombre] = (Obr.Total_Ingresos1_Conta != 0) ? Convert.ToDecimal(row[Obr.Nombre]) / Obr.Total_Ingresos1_Conta : 0;
                }

            }

            try { dt.Columns.Remove(dt.Columns["GENERAL"]); dt.Columns.Remove(dt.Columns["_GENERAL"]); } catch { }

            dg.DataSource = dt;
            Grid_diseño(dg);
        }
        public static void Mostrar_Inform2(List<Obras> L_Obras, bool congenerales, DataTable dta, DataGridView dg, Guid id_infro)
        {
            //Limpiamos 

            dta.Columns.Clear();
            dta = new DataTable();
            DataRow R_TotGastos = dta.NewRow();
            DataRow R_Totales = dta.NewRow();
            dg.DataSource = null;
            dg.Columns.Clear();
            dg.Rows.Clear();
                

            List<Grupos> lgrupos = GruposCN.Listar_solocontabilidad();

            //CREAMOS LA TABLA EN MEMORIA
            dta.Columns.Add("Concepto");
            dta.Columns.Add("Id_concepto");
            dta.Columns.Add("Id_Tipo");
            dta.Columns.Add("Id_Grupo");


            foreach (Obras Obr in L_Obras)
            {
                dta.Columns.Add("P_" + Obr.Nombre, Type.GetType("System.Double"));
                dta.Columns.Add(Obr.Nombre, Type.GetType("System.Double"));
                dta.Columns.Add("_" + Obr.Nombre, Type.GetType("System.Double"));
            }
            dta.Columns.Add("TOTAL CIA", Type.GetType("System.Double"));
            dta.Columns.Add("P_TOTAL CIA", Type.GetType("System.Double"));



            //AGREGAMOS LOS GASTOS DE CONTIBUCION DIRECTA
            foreach (Grupos Grup in lgrupos.Where(p => p.Id_Tipo == 1 && p.Id_TipoCoste == 2))
            {
                DataRow Dr = dta.NewRow();
                Crea_Fila(Dr, Grup, L_Obras.Where(p => p.Nombre != "GENERAL").ToList(), id_infro);
                if (Convert.ToDecimal(Dr["TOTAL CIA"]) != 0 || Convert.ToDecimal(Dr["P_TOTAL CIA"]) != 0) dta.Rows.Add(Dr);
            }
           
            //AGREGAMOS LOS GASTOS DIRECTOS
            foreach (Grupos Grup in lgrupos.Where(p => p.Id_Tipo == 1 && p.Id_TipoCoste == 3))
            {
                DataRow Dr = dta.NewRow();
                Crea_Fila(Dr, Grup, L_Obras.Where(p => p.Nombre != "GENERAL").ToList(), id_infro);
                if (Convert.ToDecimal(Dr["TOTAL CIA"]) != 0 || Convert.ToDecimal(Dr["P_TOTAL CIA"]) != 0) dta.Rows.Add(Dr);
            }
                  

            //--------------------AGREGAMOS TOTALES GASTOS DIRECTOS 3
            R_Totales = dta.NewRow();
            Crea_Fila_Totales(R_Totales, L_Obras, "TOT. GASTOS ", 10, 10);
            dta.Rows.Add(R_Totales);

            R_Totales = dta.NewRow();
            dta.Rows.Add(R_Totales);


            //AGREGAMOS LOS INGRESOS
            //foreach (Grupos Grup in lgrupos.Where(p => p.Id_Tipo == 0 || p.Id_Tipo == 7))
            //{
            //    DataRow Dr = dta.NewRow();
            //    Crea_Fila(Dr, Grup, L_Obras.Where(p => p.Nombre != "GENERAL").ToList(), id_infro);
            //    // dta.Rows.Add(Dr);
            //}           

            //--------------------TOTALES INGRESOS 1
            R_Totales = dta.NewRow();
            Crea_Fila_Totales(R_Totales, L_Obras, "TOT. FACTURADO", 11, 11);
            dta.Rows.Add(R_Totales);
                                        

            //--------------------AGREGAMOS LO INGRESADO EN BANCO
            R_Totales = dta.NewRow();
            Crea_Fila_Totales(R_Totales, L_Obras, "TOT. INGRESO BANCO ", 18, 18);
            dta.Rows.Add(R_Totales);

            R_Totales = dta.NewRow();
            dta.Rows.Add(R_Totales);

            //--------------------AGREGAMOS TOTALES RESULTADO 8
            R_Totales = dta.NewRow();
            Crea_Fila_Totales(R_Totales, L_Obras.Where(p => p.Nombre != "GENERAL").ToList(), "BENEFICIO / PERDIDA", 8, 8);
            dta.Rows.Add(R_Totales);
        

            //--------------------AGREGAMOS TOTALES RESULTADO 13
            R_Totales = dta.NewRow();
            Crea_Fila_Totales(R_Totales, L_Obras.Where(p => p.Nombre != "GENERAL").ToList(), "AJUSTE", 13, 13);
            dta.Rows.Add(R_Totales);
            //--------------------AGREGAMOS TOTALES RESULTADO 14
            R_Totales = dta.NewRow();
            Crea_Fila_Totales(R_Totales, L_Obras.Where(p => p.Nombre != "GENERAL").ToList(), "TOT. RESULTADO", 14, 14);
            dta.Rows.Add(R_Totales);

            R_Totales = dta.NewRow();
            dta.Rows.Add(R_Totales);

            
            //AGREGAMOS Las HIPOTECAS
            foreach (Grupos Grup in lgrupos.Where(p => p.Id_Tipo == 16))
            {
                DataRow Dr = dta.NewRow();
                Crea_Fila(Dr, Grup, L_Obras.Where(p => p.Nombre != "GENERAL").ToList(), id_infro);
                // dta.Rows.Add(Dr);
            }

            //--------------------AGREGAMOS TOTALES HIPOTECAS 16
            R_Totales = dta.NewRow();
            Crea_Fila_Totales(R_Totales, L_Obras.Where(p => p.Nombre != "GENERAL").ToList(), "HIPOTECAS / INTERESES", 16, 16);
            dta.Rows.Add(R_Totales);

            R_Totales = dta.NewRow();
            dta.Rows.Add(R_Totales);
           
            //--------------------AGREGAMOS TOTALES HIPOTECAS 17
            R_Totales = dta.NewRow();
            Crea_Fila_Totales(R_Totales, L_Obras.Where(p => p.Nombre != "GENERAL").ToList(), "TOT. RESULTADO", 17, 17);
            dta.Rows.Add(R_Totales);

            R_Totales = dta.NewRow();
            dta.Rows.Add(R_Totales);


            //--------------------------------AGREGAMOS EL PRESUPUESTO
            R_Totales = dta.NewRow();
            Crea_Fila_Totales(R_Totales, L_Obras.Where(p => p.Nombre != "GENERAL").ToList(), "PRESUPUESTO COSTE", 90, 90);
            dta.Rows.Add(R_Totales);
            R_Totales = dta.NewRow();
            Crea_Fila_Totales(R_Totales, L_Obras.Where(p => p.Nombre != "GENERAL").ToList(), "PRESUPUESTO VENTA", 91, 91);
            dta.Rows.Add(R_Totales);
            R_Totales = dta.NewRow();
            Crea_Fila_Totales(R_Totales, L_Obras.Where(p => p.Nombre != "GENERAL").ToList(), "BENEFICIO PREVISTO", 92, 92);
            dta.Rows.Add(R_Totales);



            foreach (DataRow row in dta.Rows)
            {
                foreach (Obras Obr in L_Obras)
                {                  
                    if (row[Obr.Nombre].ToString() == "") continue;
                    row["_" + Obr.Nombre] = ((Obr.Total_Ingresos1_Conta + Obr.Total_restoIngresos7_Conta) != 0) ? Convert.ToDecimal(row[Obr.Nombre]) / (Obr.Total_Ingresos1_Conta + Obr.Total_restoIngresos7_Conta) : 0;
                }

            }
            try { dta.Columns.Remove(dta.Columns["GENERAL"]); dta.Columns.Remove(dta.Columns["_GENERAL"]); } catch { }

            dg.DataSource = dta;
            Grid_diseño2(dg);
        }
        public static void Mostrar_Inform2Ssubgrupo(List<Obras> L_Obras, bool congenerales, DataTable dt, DataGridView dg, Guid id_infro,int Id_grupo)
        {
            //Limpiamos 

            dt = new DataTable();
            DataRow R_TotGastos = dt.NewRow();
            DataRow R_Totales = dt.NewRow();
            dg.DataSource = null;
            dg.Columns.Clear();
            dg.Rows.Clear();


            List<Grupos> lgrupos = GruposCN.Listar_solocontabilidad();

            //CREAMOS LA TABLA EN MEMORIA
            dt.Columns.Add("Concepto");
            dt.Columns.Add("Id_concepto");
            dt.Columns.Add("Id_Tipo");
            dt.Columns.Add("Id_Grupo");


            foreach (Obras Obr in L_Obras)
            {
                dt.Columns.Add("P_" + Obr.Nombre, Type.GetType("System.Double"));
                dt.Columns.Add(Obr.Nombre, Type.GetType("System.Double"));
                dt.Columns.Add("_" + Obr.Nombre, Type.GetType("System.Double"));
            }
            dt.Columns.Add("TOTAL CIA", Type.GetType("System.Double"));
            dt.Columns.Add("P_TOTAL CIA", Type.GetType("System.Double"));


            //AGREGAMOS LOS GASTOS DE CONTIBUCION DIRECTA
            foreach (Subgrupos SubGrup in lgrupos.Where(p=> p.Id_Grupo == Id_grupo).SelectMany(p=> p.Subgrupos).ToList())
            {
                DataRow Dr = dt.NewRow();
                Crea_FilaSubgrupos (Dr, SubGrup, L_Obras.Where(p => p.Nombre != "GENERAL").ToList(), id_infro);
              //  if (Convert.ToDecimal(Dr["TOTAL CIA"]) != 0 || Convert.ToDecimal(Dr["P_TOTAL CIA"]) != 0)
                  dt.Rows.Add(Dr);
            }

            foreach (DataRow row in dt.Rows)
            {
                foreach (Obras Obr in L_Obras)
                {
                    if (row[Obr.Nombre].ToString() == "") continue;
                    row["_" + Obr.Nombre] = ((Obr.Total_Ingresos1_Conta + Obr.Total_restoIngresos7_Conta) != 0) ? Convert.ToDecimal(row[Obr.Nombre]) / (Obr.Total_Ingresos1_Conta + Obr.Total_restoIngresos7_Conta) : 0;
                }

            }
            try { dt.Columns.Remove(dt.Columns["GENERAL"]); dt.Columns.Remove(dt.Columns["_GENERAL"]); } catch { }
            Form_Caja.AgregaTotales(dt, 0);
            Form_Caja.Grid_Diseño(dg,dg.Font);
            dg.DataSource = dt;
            Grid_diseño2(dg);
        }
               
     

        public static void Grid_diseño2(DataGridView dginforme)
        {
            dginforme.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
  

            dginforme.Columns["Id_concepto"].Visible = false;
            dginforme.Columns["Id_Tipo"].Visible = false;
            dginforme.Columns["Id_Grupo"].Visible = false;

            try { dginforme.Columns["GENERAL"].DisplayIndex = 1; } catch { }

            foreach (DataGridViewColumn Col in dginforme.Columns)
            {
                if (Col.ValueType.Name == "Double" || Col.ValueType.Name == "Decimal")
                {
                    Col.Width = 70;
                    Col.DefaultCellStyle.Format = "#,0";
                }
                if (Col.Name.Substring(0, 2) == "P_")
                {
                    Col.Visible = false ;
                }

                if (Col.Name.Substring(0, 1) == "_")
                {
                    Col.Width = 70;
                    Col.HeaderText = Col.HeaderText.Replace("_", "%");                   
                    Col.DefaultCellStyle.Format = "P00";
                }


                if (Col.Name == "TOTAL CIA")
                {
                    Col.HeaderText = "TOTAL SELEC";
                    Col.DefaultCellStyle.BackColor = Color.Honeydew;
                }
                if (Col.Name == "GENERAL")
                {
                    Col.DefaultCellStyle.BackColor = Color.Cornsilk;
                }

            }
            dginforme.Columns["Concepto"].AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            dginforme.Columns["Concepto"].Width = 200;


            foreach (DataGridViewRow Row in dginforme.Rows)
            {
                if (Row.Cells["Id_Tipo"].Value.ToString () == "") continue;
                if (Convert.ToInt32(Row.Cells["Id_Tipo"].Value) == 1)
                {
                    Row.DefaultCellStyle.ForeColor = Color.Blue;
                    Row.DefaultCellStyle.BackColor = Color.WhiteSmoke;

                    Row.DefaultCellStyle.Font = new Font(dginforme.Font, FontStyle.Bold);
                }
                if (Convert.ToInt32(Row.Cells["Id_Tipo"].Value) == 11)
                {
                    Row.DefaultCellStyle.ForeColor = Color.Blue;
                    Row.DefaultCellStyle.BackColor = Color.WhiteSmoke;
                    Row.DefaultCellStyle.Font = new Font(dginforme.Font, FontStyle.Bold);
                }
                if (Convert.ToInt32(Row.Cells["Id_Tipo"].Value) == 18)
                {
                    Row.DefaultCellStyle.ForeColor = Color.DarkViolet;
                    Row.DefaultCellStyle.BackColor = Color.WhiteSmoke;
                    Row.DefaultCellStyle.Font = new Font(dginforme.Font, FontStyle.Bold);
                }
                if (Convert.ToInt32(Row.Cells["Id_Tipo"].Value) == 2)
                {
                    Row.DefaultCellStyle.ForeColor = Color.Firebrick;
                    Row.DefaultCellStyle.BackColor = Color.WhiteSmoke;
                    Row.DefaultCellStyle.Font = new Font(dginforme.Font, FontStyle.Bold);
                }
                if (Convert.ToInt32(Row.Cells["Id_Tipo"].Value) == 3)
                {
                    Row.DefaultCellStyle.ForeColor = Color.Firebrick;
                    Row.DefaultCellStyle.BackColor = Color.WhiteSmoke;
                    Row.DefaultCellStyle.Font = new Font(dginforme.Font, FontStyle.Bold);
                }
                if (Convert.ToInt32(Row.Cells["Id_Tipo"].Value) == 4)
                {
                    Row.DefaultCellStyle.ForeColor = Color.Black;
                    Row.DefaultCellStyle.BackColor = Color.LightGray;
                    Row.DefaultCellStyle.Font = new Font(dginforme.Font, FontStyle.Bold);
                }
                if (Convert.ToInt32(Row.Cells["Id_Tipo"].Value) == 5)
                {
                    Row.DefaultCellStyle.ForeColor = Color.Firebrick;
                    Row.DefaultCellStyle.BackColor = Color.WhiteSmoke;
                    Row.DefaultCellStyle.Font = new Font(dginforme.Font, FontStyle.Bold);
                }
                if (Convert.ToInt32(Row.Cells["Id_Tipo"].Value) == 6)
                {
                    Row.DefaultCellStyle.ForeColor = Color.Black;
                    Row.DefaultCellStyle.BackColor = Color.LightGray;
                    Row.DefaultCellStyle.Font = new Font(dginforme.Font, FontStyle.Bold);
                }
                if (Convert.ToInt32(Row.Cells["Id_Tipo"].Value) == 8)
                {
                    Row.DefaultCellStyle.ForeColor = Color.Black;
                    Row.DefaultCellStyle.BackColor = Color.LightGray;
                    Row.DefaultCellStyle.Font = new Font(dginforme.Font, FontStyle.Bold);
                }
                if (Convert.ToInt32(Row.Cells["Id_Tipo"].Value) == 14)
                {
                    Row.DefaultCellStyle.ForeColor = Color.Black;
                    Row.DefaultCellStyle.BackColor = Color.LightGray;
                    Row.DefaultCellStyle.Font = new Font(dginforme.Font, FontStyle.Bold);
                }
                if (Convert.ToInt32(Row.Cells["Id_Tipo"].Value) == 10)
                {
                    Row.DefaultCellStyle.ForeColor = Color.Firebrick;
                    Row.DefaultCellStyle.BackColor = Color.WhiteSmoke;
                    Row.DefaultCellStyle.Font = new Font(dginforme.Font, FontStyle.Bold);
                }
                if (Convert.ToInt32(Row.Cells["Id_Tipo"].Value) == 16)
                {
                    Row.DefaultCellStyle.ForeColor = Color.Firebrick;
                    Row.DefaultCellStyle.BackColor = Color.WhiteSmoke;
                    Row.DefaultCellStyle.Font = new Font(dginforme.Font, FontStyle.Bold);
                }
                if (Convert.ToInt32(Row.Cells["Id_Tipo"].Value) == 13)
                {
                    Row.DefaultCellStyle.ForeColor = Color.Firebrick;
                    Row.DefaultCellStyle.BackColor = Color.WhiteSmoke;
                    Row.DefaultCellStyle.Font = new Font(dginforme.Font, FontStyle.Bold);
                }
                if (Convert.ToInt32(Row.Cells["Id_Tipo"].Value) == 17)
                {
                    Row.DefaultCellStyle.ForeColor = Color.Black;
                    Row.DefaultCellStyle.BackColor = Color.LightGray;
                    Row.DefaultCellStyle.Font = new Font(dginforme.Font, FontStyle.Bold);
                }
                foreach (DataGridViewCell Cell in Row.Cells)
                {
                    if (Cell.ValueType.Name == "Double" || Cell.ValueType.Name == "Decimal")
                    {
                        if (Cell.Value == DBNull.Value) continue;
                        switch (Convert.ToInt32(Row.Cells["Id_Tipo"].Value))
                        {
                            case 1:
                                Cell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                                break;
                            case 11:
                                Cell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;                              
                                break;
                            case 18:
                                Cell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                                break;
                            case 2:
                                Cell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                                break;
                            case 3:
                                Cell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                                break;
                            case 4:
                                Cell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                                if (Convert.ToInt32(Cell.Value) >= 0)
                                    Cell.Style.ForeColor = Color.Green;
                                else
                                    Cell.Style.ForeColor = Color.Red;
                                break;
                            case 16:
                                Cell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                                break;
                            case 17:
                                Cell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                                if (Convert.ToInt32(Cell.Value) >= 0)
                                    Cell.Style.ForeColor = Color.Green;
                                else
                                    Cell.Style.ForeColor = Color.Red;
                                break;
                            case 5:
                                Cell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                                break;
                            case 6:
                                Cell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                                if (Convert.ToInt32(Cell.Value) >= 0)
                                    Cell.Style.ForeColor = Color.Green;
                                else
                                    Cell.Style.ForeColor = Color.Red;
                                break;
                            case 8:
                                Cell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                                if (Convert.ToInt32(Cell.Value) >= 0)
                                    Cell.Style.ForeColor = Color.Green;
                                else
                                    Cell.Style.ForeColor = Color.Red;
                                break;
                            case 14:
                                Cell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                                if (Convert.ToInt32(Cell.Value) >= 0)
                                    Cell.Style.ForeColor = Color.Green;
                                else
                                    Cell.Style.ForeColor = Color.Red;
                                break;
                            case 10:
                                Cell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                                Cell.Style.ForeColor = Color.Firebrick;
                                break;
                            case 13:
                                Cell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                                Cell.Style.ForeColor = Color.Firebrick;
                                break;
                            case 20:
                                Cell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                                Cell.Style.ForeColor = Color.Black;
                                break;
                            case 30:
                                Cell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                                Cell.Style.ForeColor = Color.Black;
                                break;
                            case 50:
                                Cell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                                Cell.Style.ForeColor = Color.Firebrick;
                                break;
                            case 70:
                                Cell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                                Cell.Style.ForeColor = Color.Blue;
                                break;
                            default:
                                Console.WriteLine("Default case");
                                break;
                        }

                    }

                }
            }
        }

        public static void Grid_diseño(DataGridView dginforme)
        {

            dginforme.Columns["Id_concepto"].Visible = false;
            dginforme.Columns["Id_Tipo"].Visible = false;
            dginforme.Columns["Id_Grupo"].Visible = false;

            try { dginforme.Columns["GENERAL"].DisplayIndex = 1; } catch { }

            foreach (DataGridViewColumn Col in dginforme.Columns)
            {
                if (Col.ValueType.Name == "Double" || Col.ValueType.Name == "Decimal")
                {
                    Col.Width = 100;
                    Col.DefaultCellStyle.Format = "#,0";
                }
                if (Col.Name.Substring(0, 2) == "P_")
                {
                    Col.Width = 60;
                    Col.HeaderText = "Presu";
                    Col.DefaultCellStyle.BackColor = Color.AntiqueWhite;
                }

                if (Col.Name.Substring(0, 1) == "_")
                {
                    Col.Width = 55;
                    Col.HeaderText = "%";
                    Col.DefaultCellStyle.BackColor = Color.Lavender;
                    Col.DefaultCellStyle.Format = "P00";
                }


                if (Col.Name == "TOTAL CIA")
                {
                    Col.DefaultCellStyle.BackColor = Color.Honeydew;
                }
                if (Col.Name == "GENERAL")
                {
                    Col.DefaultCellStyle.BackColor = Color.Cornsilk;
                }

            }
            dginforme.Columns["Concepto"].AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            dginforme.Columns["Concepto"].Width = 200;


            foreach (DataGridViewRow Row in dginforme.Rows)
            {
                if (Convert.ToInt32(Row.Cells["Id_Tipo"].Value) == 1)
                {
                    Row.DefaultCellStyle.ForeColor = Color.Blue;
                    Row.DefaultCellStyle.BackColor = Color.WhiteSmoke;

                    Row.DefaultCellStyle.Font = new Font(dginforme.Font, FontStyle.Bold);
                }
                if (Convert.ToInt32(Row.Cells["Id_Tipo"].Value) == 2)
                {
                    Row.DefaultCellStyle.ForeColor = Color.Firebrick;
                    Row.DefaultCellStyle.BackColor = Color.WhiteSmoke;
                    Row.DefaultCellStyle.Font = new Font(dginforme.Font, FontStyle.Bold);
                }
                if (Convert.ToInt32(Row.Cells["Id_Tipo"].Value) == 3)
                {
                    Row.DefaultCellStyle.ForeColor = Color.Firebrick;
                    Row.DefaultCellStyle.BackColor = Color.WhiteSmoke;
                    Row.DefaultCellStyle.Font = new Font(dginforme.Font, FontStyle.Bold);
                }
                if (Convert.ToInt32(Row.Cells["Id_Tipo"].Value) == 4)
                {
                    Row.DefaultCellStyle.ForeColor = Color.Black;
                    Row.DefaultCellStyle.BackColor = Color.LightGray;
                    Row.DefaultCellStyle.Font = new Font(dginforme.Font, FontStyle.Bold);
                }
                if (Convert.ToInt32(Row.Cells["Id_Tipo"].Value) == 5)
                {
                    Row.DefaultCellStyle.ForeColor = Color.Firebrick;
                    Row.DefaultCellStyle.BackColor = Color.WhiteSmoke;
                    Row.DefaultCellStyle.Font = new Font(dginforme.Font, FontStyle.Bold);
                }
                if (Convert.ToInt32(Row.Cells["Id_Tipo"].Value) == 6)
                {
                    Row.DefaultCellStyle.ForeColor = Color.Black;
                    Row.DefaultCellStyle.BackColor = Color.LightGray;
                    Row.DefaultCellStyle.Font = new Font(dginforme.Font, FontStyle.Bold);
                }
                if (Convert.ToInt32(Row.Cells["Id_Tipo"].Value) == 8)
                {
                    Row.DefaultCellStyle.ForeColor = Color.Black;
                    Row.DefaultCellStyle.BackColor = Color.LightGray;
                    Row.DefaultCellStyle.Font = new Font(dginforme.Font, FontStyle.Bold);
                }
                foreach (DataGridViewCell Cell in Row.Cells)
                {
                    if (Cell.ValueType.Name == "Double" || Cell.ValueType.Name == "Decimal")
                    {
                        if (Cell.Value == DBNull.Value) continue;
                        switch (Convert.ToInt32(Row.Cells["Id_Tipo"].Value))
                        {
                            case 1:
                                Cell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                break;
                            case 2:
                                Cell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                break;
                            case 3:
                                Cell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                break;
                            case 4:
                                Cell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                if (Convert.ToInt32(Cell.Value) >= 0)
                                    Cell.Style.ForeColor = Color.Green;
                                else
                                    Cell.Style.ForeColor = Color.Red;
                                break;
                            case 5:
                                Cell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                break;
                            case 6:
                                Cell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                if (Convert.ToInt32(Cell.Value) >= 0)
                                    Cell.Style.ForeColor = Color.Green;
                                else
                                    Cell.Style.ForeColor = Color.Red;
                                break;
                            case 8:
                                Cell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                if (Convert.ToInt32(Cell.Value) >= 0)
                                    Cell.Style.ForeColor = Color.Green;
                                else
                                    Cell.Style.ForeColor = Color.Red;
                                break;
                            case 10:
                                Cell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                                Cell.Style.ForeColor = Color.Blue;
                                break;
                            case 20:
                                Cell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                                Cell.Style.ForeColor = Color.Black;
                                break;
                            case 30:
                                Cell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                                Cell.Style.ForeColor = Color.Black;
                                break;
                            case 50:
                                Cell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                                Cell.Style.ForeColor = Color.Firebrick;
                                break;
                            case 70:
                                Cell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                                Cell.Style.ForeColor = Color.Blue;
                                break;
                            default:
                                Console.WriteLine("Default case");
                                break;
                        }

                    }

                }
            }
        }

        public static List<Cuentas> Cuentas_Participes(string Nombreobra, int id_grupo, string id_infor)
        {
            Obras Obr = ObraCN.Listar(Nombreobra);
            if (Obr != null)
            {
                return Obr.Balance.Where(b => b.Id_Informe == id_infor).Select(x => x.Cuentas).Where(x => x.Id_Grupo == id_grupo).GroupBy(x => x.Cuenta).Select(g => g.First()).ToList();
            }
            else
            { return null; }
        }
        public static List<Cuentas> Cuentas_ParticipesSubgrupos(string Nombreobra, int Id_Subgrupo, string id_infor)
        {
            Obras Obr = ObraCN.Listar(Nombreobra);
            if (Obr != null)
            {
                return Obr.Balance.Where(b => b.Id_Informe == id_infor).Select(x => x.Cuentas).Where(x => x.Id_SubGrupo == Id_Subgrupo).GroupBy(x => x.Cuenta).Select(g => g.First()).ToList();
            }
            else
            { return null; }
        }
        public static List<Cuentas> Cuentas_Participes(string Nombreobra, List<int> id_grupo, string id_infor)
        {
            Obras Obr = ObraCN.Listar(Nombreobra);
            List<Cuentas> L = new List<Cuentas>();
            if (Obr != null)
            {
                foreach ( int idgrupo in id_grupo  )
                {
                    L.AddRange(Obr.Balance.Where(b => b.Id_Informe == id_infor).Select(x => x.Cuentas).Where(x => x.Id_Grupo == idgrupo).GroupBy(x => x.Cuenta).Select(g => g.First()).ToList());
                }
                return L;
            }
            else
            { return null; }
        }


        //private void button1_Click(object sender, EventArgs e)
        //{
        //    if (Rbacumulados.Checked == false && cbejercicio.Text == "") return;
        //    if (Rbacumulados.Checked == true && listObras.SelectedIndex == -1) return;
        //    if (Rbacumulados.Checked == true)
        //    {
        //        Acumulado();
        //    }
        //    else
        //    {
        //        Por_Ejercicio();
        //    }

        //}



        //private void Acumulado()
        //{
        //    loading(true, progressBar1);
        //    id_infr = Guid.NewGuid();
        //    List<Obras> L_Obras_Selecionadas = Emp.Obras.Where(t => Obras_Selecionadas_int().Contains(t.Id_Obra)).ToList(); //ObraCN.Listar(Obras_Selecionadas_int()); 
        //    Check_Cuentas(L_Obras_Selecionadas);
        //    BalanceCN.Añadir(CalculoCN.Creacion_Informe(id_infr.ToString(), Emp, Emp.Obras.Where(t => Obras_Selecionadas_int().Contains(t.Id_Obra)).ToList(), false, 0, flimite.Value));

        //    pderecha.Visible = true;
        //    Mostrar_Inform(L_Obras_Selecionadas, false,dt,dginforme,id_infr);

        //    pgeneral.ColumnStyles[0].Width = 0;
        //    loading(false, progressBar1);
        //    txtinfo.Text = "Balance a fecha: " + flimite.Value.ToShortDateString() + " \n" + "Inicio Obra:" + CalculoCN.Primerafecha(Emp, Emp.Obras.Where(t => Obras_Selecionadas_int().Contains(t.Id_Obra)).ToList().Select(i => i.Id_Obra.ToString(CultureInfo.InvariantCulture)).Aggregate((s1, s2) => s1 + ", " + s2), flimite.Value).ToShortDateString();

        //}
        //private void Por_Ejercicio()
        //{
        //    loading(true, progressBar1);
        //    id_infr = Guid.NewGuid();
        //    List<Int32> l_onbras_int = CalculoCN.Comprobacion_canales(Emp, Convert.ToInt32(cbejercicio.Text));
        //    List<Obras> l_Obras_Ejer = Emp.Obras.Where(t => l_onbras_int.Contains(t.Id_Obra)).ToList();//   ObraCN.Listar(l_onbras_int);
        //    Check_Cuentas(l_Obras_Ejer);
        //    BalanceCN.Añadir(CalculoCN.Creacion_Informe(id_infr.ToString(), Emp, l_Obras_Ejer, false, Convert.ToInt32(cbejercicio.Text), flimite.Value));
        //    pderecha.Visible = true;
        //    Mostrar_Inform(l_Obras_Ejer, true,dt,dginforme, id_infr);          
        //    pgeneral.ColumnStyles[0].Width = 0;
        //    loading(false, progressBar1);
        //    txtinfo.Text = "Balance a fecha: " + flimite.Value.ToShortDateString();
        //}
        //public void Check_Cuentas(List<Obras> l_Obras)
        //{
        //    List<Cuentas> l = CalculoCN.Comprobacion_cuentas(Emp, l_Obras);
        //    List<string> le = new List<string>();
        //    foreach (Cuentas cuen in l)
        //    {
        //        DialogResult result = MessageBox.Show("¿Desea tratar la siguiente cuenta :" + cuen.Cuenta + "?", "Atencion", MessageBoxButtons.YesNoCancel);

        //        switch (result)
        //        {
        //            case DialogResult.Yes:
        //                Grupos Gr = GruposCN.Listar_por_Cuenta(Convert.ToInt32(cuen.Cuenta.Substring(0, 3)));
        //                if (Gr != null)
        //                {
        //                    CuentasCn.Añadir(Emp.Id_Empresa, cuen.Cuenta, cuen.Nombre, Gr.Id_Grupo, 0, true);
        //                }
        //                else
        //                {
        //                    le.Add(cuen.Cuenta);
        //                    Form_AñadirCuentas f = new Form_AñadirCuentas(cuen);
        //                    f.ShowDialog();
        //                }
        //                break;
        //            case DialogResult.No:
        //                cuen.Nombre = string.Empty;
        //                cuen.Id_Grupo = 0;
        //                cuen.Id_SubGrupo = 0;
        //                CuentasCn.Añadir(cuen);
        //                break;
        //            case DialogResult.Cancel:
        //                continue;
        //        }
        //    }
        //    Console.WriteLine();
        //}

        //private void loading(bool loading, ProgressBar progresbar)
        //{
        //    if (loading == true)
        //    {
        //        this.Cursor = Cursors.WaitCursor;
        //        progressBar1.Visible = true;
        //    }
        //    else
        //    {
        //        this.Cursor = Cursors.Default;
        //        progressBar1.Visible = false;
        //    }

        //}






        //public void forma()
        //{
        //    foreach (DataRow r in dt.Rows)
        //    {
        //        for (int i = 0; i < dt.Columns.Count; i++)
        //        { 
        //            if (dt.Columns[i].DataType.Name == "Double")
        //            {
        //                if (r[i].ToString() == "") continue;
        //                r[i] = Math.Round(Convert.ToDouble(r[i]), 0);
        //            }
        //        }
        //    }
        //}

        //public void DiseñoGrid()
        //{
        //    typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic |
        //    BindingFlags.Instance | BindingFlags.SetProperty, null,
        //    dginforme, new object[] { true });
        //    pderecha.Visible = false;

        //    dginforme.EnableHeadersVisualStyles = false;
        //    dginforme.ColumnHeadersDefaultCellStyle.BackColor = Color.AliceBlue;
        //    dginforme.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
        //    dginforme.ColumnHeadersDefaultCellStyle.Font = new Font(FontFamily.GenericSansSerif, 9.0F, FontStyle.Bold);
        //    listObras.DataSource = Emp.Obras.ToList().Where(p => p.Id_Obra >= 0).ToList();
        //    listObras.DisplayMember = "Nombre";
        //    listObras.ValueMember = "id_Obra";

        //}

        //public List<Obras> Obras_Selecionadas()
        //{
        //    List<Obras> l = new List<Obras>();
        //    foreach (object item in listObras.SelectedItems)
        //    {
        //        l.Add((Obras)item);
        //    }
        //    return l;
        //}
        //public List<int> Obras_Selecionadas_int()
        //{
        //    List<int> l = new List<int>();
        //    foreach (object item in listObras.SelectedItems)
        //    {
        //        l.Add(((Obras)item).Id_Obra);
        //    }
        //    return l;
        //}


        //private void Form_Calculo_FormClosed(object sender, FormClosedEventArgs e)
        //{
        //    BalanceCN.Borrar(id_infr.ToString());
        //}


        //private void dginforme_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        //{
        //    //if (e.ColumnIndex < 0 || e.RowIndex < 0) return;
        //    //if (Convert.ToInt32(dginforme["id_tipo", e.RowIndex].Value) < 0) return;
        //    //try
        //    //{
        //    //    List<Cuentas> lcuentas = Cuentas_Participes(dginforme.Columns[e.ColumnIndex].HeaderText, Convert.ToInt32(dginforme["id_grupo", e.RowIndex].Value), id_infr.ToString());
        //    //    if (lcuentas != null)
        //    //    {
        //    //        DataGridViewCell cell = this.dginforme.Rows[e.RowIndex].Cells[e.ColumnIndex];
        //    //        cell.ToolTipText = "";
        //    //        foreach (string d in lcuentas.Select(p => p.Cuenta).ToList())
        //    //        {
        //    //            cell.ToolTipText += d + "\n";
        //    //        }
        //    //    }
        //    //}
        //    //catch
        //    //{

        //    //}

        //}

        //private void button2_Click(object sender, EventArgs e)
        //{
        //    Emp = EmpresasCN.Listar(Emp.Id_Empresa);
        //    pgeneral.ColumnStyles[0].Width = 200;
        //    pderecha.Visible = false;
        //    rbindesglosado.Checked = true;
        //    rbgastdesglo.Checked = true;
        //}

        //private void dginforme_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        //{
        //    Grid_diseño(dginforme);
        //}

        //private void button4_Click(object sender, EventArgs e)
        //{
        //        string Title = txtinfo.Text.ToString().Replace("\n", " ") + ". Compañia: " + Emp.Nombre;
        //        ContaWIN.M_PrintDGV.Print_DataGridView(dginforme, Title, true, false, true, true);
        //}

        //private void button3_Click(object sender, EventArgs e)
        //{
        //    saveFileDialog1.Filter = "Excel File|*.xls";
        //    saveFileDialog1.Title = "Save an Excel File";
        //    saveFileDialog1.ShowDialog();
        //    forma();
        //    if (saveFileDialog1.FileName != "") Log_ErroresCN.ExportToExcel(dt, saveFileDialog1.FileName, "r");
        //}

        //private void label2_Click(object sender, EventArgs e)
        //{

        //}

        //private void VisualizarRows()
        //{
        //    dginforme.CurrentCell = null;
        //    foreach (DataGridViewRow Row in dginforme.Rows)
        //        switch (Convert.ToInt32(Row.Cells["Id_Tipo"].Value))
        //        {
        //            case 10:
        //                if (rbindesglosado.Checked) Row.Visible = true;
        //                if (rbintotales.Checked) Row.Visible = false;
        //                break;
        //            case 20:
        //                if (rbgastdesglo.Checked) Row.Visible = true;
        //                if (rbgastotal.Checked) Row.Visible = false;
        //                break;
        //            case 30:
        //                if (rbgastdesglo.Checked) Row.Visible = true;
        //                if (rbgastotal.Checked) Row.Visible = false;
        //                break;
        //            case 50:
        //                if (rbgastdesglo.Checked) Row.Visible = true;
        //                if (rbgastotal.Checked) Row.Visible = false;
        //                break;
        //            case 70:
        //                if (rbgastdesglo.Checked) Row.Visible = true;
        //                if (rbgastotal.Checked) Row.Visible = false;
        //                break;
        //        }
        //}

        //private void dginforme_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (e.ColumnIndex < 0 || e.RowIndex < 0) return;
        //    if (Convert.ToInt32(dginforme["id_tipo", e.RowIndex].Value) == 50 && (dginforme[e.ColumnIndex, e.RowIndex].OwningColumn.HeaderText != "TOTAL CIA")) return;
        //    try
        //    {
        //        DataTable Dtdetalles = new DataTable();
        //        Obras Obr = ObraCN.Listar(dginforme.Columns[e.ColumnIndex].HeaderText);
        //        if (Convert.ToInt32(dginforme["id_tipo", e.RowIndex].Value) == 50)
        //        {
        //            Obr = ObraCN.Listar("GENERAL");
        //        }

        //        string cuentas = string.Empty;
        //        if (Obr == null) return;
        //        List<Cuentas> lcuentas = Cuentas_Participes(Obr.Nombre, Convert.ToInt32(dginforme["id_grupo", e.RowIndex].Value), id_infr.ToString());

        //        if (lcuentas != null)
        //        {
        //            foreach (Cuentas d in lcuentas.ToList())
        //            {
        //                d.Cuenta = "'" + d.Cuenta + "'";
        //            }
        //            cuentas = string.Join(",", lcuentas.Select(p => p.Cuenta).ToArray());
        //        }

        //        Dtdetalles = CalculoCN.Lineas_DetalleAsientos(Emp, (Rbejercicios.Checked) ? Convert.ToInt32(cbejercicio.Text) : 0, Obr.Id_Obra, cuentas, flimite.Value);
        //        Form_FacturasCapitulos f = new Form_FacturasCapitulos(Dtdetalles,true);
        //        f.ShowDialog();
        //    }
        //    catch
        //    {

        //    }
        //}

        //private void rbindesglosado_CheckedChanged(object sender, EventArgs e)
        //{
        //    VisualizarRows();
        //}

        //private void rbgastdesglo_CheckedChanged(object sender, EventArgs e)
        //{
        //    VisualizarRows();
        //}

        //private void Rbacumulados_CheckedChanged(object sender, EventArgs e)
        //{
        //    listObras.Enabled = true;
        //    cbejercicio.Visible = false;
        //}

        //private void Rbejercicios_CheckedChanged(object sender, EventArgs e)
        //{
        //    listObras.Enabled = false;
        //    listObras.SelectedIndex = -1;
        //    cbejercicio.Visible = true;
        //}

        //private void checkBox1_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (Chversolopresu.Checked)
        //    {
        //        Soloverpresu(true);
        //       // Darvuelta(dt);
        //    }
        //    else
        //    {
        //        Soloverpresu(false);
        //    }


        //}
        //private void Soloverpresu(bool flag)
        //{
        //    if (flag)
        //    {
        //        foreach (DataGridViewColumn Col in dginforme.Columns)
        //        {
        //            if (Col.Name.Substring(0, 2) != "P_")
        //            {
        //                Col.Visible = false;
        //            }
        //            if (Col.Name.Substring(0, 2) == "P_")
        //            {
        //                Col.HeaderText = Col.Name.Substring(2);
        //                Col.Visible = true;
        //                Col.Width = 100;
        //            }
        //            if (Col.Name == "Concepto") Col.Visible = true; 
        //        }
        //    }
        //    else
        //    {
        //        foreach (DataGridViewColumn Col in dginforme.Columns)
        //        {
        //            if (Col.Name.Substring(0, 2) != "P_") Col.Visible = true;
        //            if (Col.Name.Substring(0, 2) == "P_")
        //            {
        //                Col.HeaderText = "Presu";                     
        //            }

        //        }
        //        dginforme.Columns["Id_concepto"].Visible = false;
        //        dginforme.Columns["Id_Tipo"].Visible = false;
        //        dginforme.Columns["Id_Grupo"].Visible = false;
        //    }           
        //}

        //private void pizquierda_Paint(object sender, PaintEventArgs e)
        //{

        //}

        //private void rbTodas_CheckedChanged(object sender, EventArgs e)
        //{

        //}

        //private void RbActivas_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (RbActivas.Checked == false )
        //    {
        //        listObras.DataSource = Emp.Obras.ToList().Where(p => p.Id_Obra != 0).ToList();
        //        listObras.DisplayMember = "Nombre";
        //        listObras.ValueMember = "id_Obra";
        //    }   
        //    else
        //    {
        //        listObras.DataSource = Emp.Obras.ToList().Where(p => p.Id_Obra != 0 && p.Importado_presu == true ).ToList();
        //        listObras.DisplayMember = "Nombre";
        //        listObras.ValueMember = "id_Obra";
        //    }         
        //}

        //public void Darvuelta(DataTable dtorigen)
        //{
        //    DataTable dtfinal = new DataTable();
        //    dtfinal.Columns.Add("Concepto");
        //    foreach (DataRow row in dtorigen.Rows )
        //    {              
        //        dtfinal.Columns.Add(row[0].ToString()); 
        //    }
        //    foreach (DataColumn Col in dtorigen.Columns)
        //    {
        //        DataRow dr;
        //        dr = dtfinal.NewRow();
        //        dr[0] = Col.ColumnName;
        //        foreach (DataRow  row in dtorigen.Rows)
        //        {
        //            dr[row[0].ToString()] = row[Col.ColumnName ];  //dr[] 
        //        }
        //        dtfinal.Rows.Add(dr);
        //    }
        //    dginforme.DataSource = dtfinal;
        //}
    }
}

//