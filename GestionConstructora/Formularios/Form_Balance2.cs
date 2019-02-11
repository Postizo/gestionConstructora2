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
        public static DataRow Crea_Fila(DataRow Dr, Grupos Grup, List<Obras> L_Obras, Guid id_info, List<int> ejercicios)
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
                        Importe = (Grup.Id_Grupo == 188) ? BalanceCN.Debe_Cuenta(Obr, Grup.Id_Grupo, id_info.ToString()): BalanceCN.GastosObra_Conta(Obr, Grup.Id_Grupo, id_info.ToString());
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
                    case 320: //Ingresos FIJOS 
                        Importe = Obr.Balance_Fijos.Where(p => ejercicios.Select(i => i.ToString(CultureInfo.InvariantCulture)).Aggregate((s1, s2) => s1 + ", " + s2).Contains(p.Año.ToString()) && p.id_TipoCoste == 1 && p.Id_Gasto == Grup.Id_Grupo).ToList().Sum(p => p.Importe);
                        // presupuestado = (Obr.Presu_Conta.Where(p => p.id_Grupo == Grup.Id_Grupo).ToList().Count > 0) ? Obr.Presu_Conta.Where(p => p.id_Grupo == Grup.Id_Grupo).ToList()[0].Presupuestado : 0;
                        Dr[Obr.Nombre] = Importe;
                        Dr["P_" + Obr.Nombre] = presupuestado;
                        break;
                    case 330: //Gastos FIJOS 
                        Importe = Obr.Balance_Fijos.Where(p => ejercicios.Select(i => i.ToString(CultureInfo.InvariantCulture)).Aggregate((s1, s2) => s1 + ", " + s2).Contains(p.Año.ToString()) && p.id_TipoCoste == 3 && p.Id_Gasto == Grup.Id_Grupo).ToList().Sum(p => p.Importe);
                        // presupuestado = (Obr.Presu_Conta.Where(p => p.id_Grupo == Grup.Id_Grupo).ToList().Count > 0) ? Obr.Presu_Conta.Where(p => p.id_Grupo == Grup.Id_Grupo).ToList()[0].Presupuestado : 0;
                        Dr[Obr.Nombre] = Importe;
                        Dr["P_" + Obr.Nombre] = presupuestado;
                        break;
                    case 130: //AJUSTES FIJOS 
                        Importe = Obr.Balance_Fijos.Where(p => ejercicios.Select(i => i.ToString(CultureInfo.InvariantCulture)).Aggregate((s1, s2) => s1 + ", " + s2).Contains(p.Año.ToString()) && p.id_TipoCoste == 4 && p.Id_Gasto == Grup.Id_Grupo).ToList().Sum(p => p.Importe);
                        // presupuestado = (Obr.Presu_Conta.Where(p => p.id_Grupo == Grup.Id_Grupo).ToList().Count > 0) ? Obr.Presu_Conta.Where(p => p.id_Grupo == Grup.Id_Grupo).ToList()[0].Presupuestado : 0;
                        Dr[Obr.Nombre] = Importe;
                        Dr["P_" + Obr.Nombre] = presupuestado;
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
                        Importe = (Subgrup.Id_Grupo == 188) ? BalanceCN.Debe_CuentaSubgrupo(Obr, Subgrup.Id_Subgrupo, id_info.ToString()) : BalanceCN.GastosObra_ContSubgruposa(Obr, Subgrup.Id_Subgrupo, id_info.ToString());
                        
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
                        break;                  ;
                    default:
                        Console.WriteLine("Default case");
                        break;
                }
                Dr["TOTAL CIA"] = Convert.ToDecimal(Dr["TOTAL CIA"]) + Importe;
                Dr["P_TOTAL CIA"] = Convert.ToDecimal(Dr["P_TOTAL CIA"]) + presupuestado;

            }
            return Dr;
        }
        public static DataRow Crea_Fila_Totales(DataRow Dr, List<Obras> L_Obras, string Nombre, int Concepto, int tipo, List<int> ejercicios,Guid? id_infro = null)
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
                        Importe = Obr.Total_Ingresos1_Conta + Obr.Total_restoIngresos7_Conta + Obr.Balance_Fijos.Where(p => ejercicios.Select(i => i.ToString(CultureInfo.InvariantCulture)).Aggregate((s1, s2) => s1 + ", " + s2).Contains(p.Año.ToString()) && p.id_TipoCoste == 1).ToList().Sum(p => p.Importe);
                        presupuestado = Obr.P_Total_Ingresos1_Conta; ;
                        Dr[Obr.Nombre] = Importe;
                        Dr["P_" + Obr.Nombre] = presupuestado;
                        break;
                    case 2: //Gastos de contribucion directa 
                        Importe =  Obr.Total_GastosContribuciondirecta2_Conta;
                        presupuestado = Obr.P_Total_GastosContribuciondirecta2_Conta;
                        Dr[Obr.Nombre] = Importe;
                        Dr["P_" + Obr.Nombre] = presupuestado;
                        break;                       
                    case 22: // iNGRESOS - Gastos de contribucion directa 
                        Importe = (Obr.Total_Ingresos1_Conta + Obr.Total_restoIngresos7_Conta) - Obr.Total_GastosContribuciondirecta2_Conta;
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
                        Importe = Obr.Total_Gastosdirectos3_Conta + Obr.Total_GastosContribuciondirecta2_Conta + Obr.Balance_Fijos.Where(p => ejercicios.Select(i => i.ToString(CultureInfo.InvariantCulture)).Aggregate((s1, s2) => s1 + ", " + s2).Contains(p.Año.ToString()) && p.id_TipoCoste == 3).ToList().Sum(p => p.Importe);
                        presupuestado = Obr.P_Total_Gastosdirectos3_Conta + Obr.P_Total_GastosContribuciondirecta2_Conta;
                        Dr[Obr.Nombre] = Importe;
                        Dr["P_" + Obr.Nombre] = presupuestado;
                        break;
                    case 6: //TOTAL RESULTADO EXPLOTACION NETO 
                        Importe = (Obr.Total_Ingresos1_Conta - (Obr.Total_GastosContribuciondirecta2_Conta + Obr.Total_Gastosdirectos3_Conta));
                        presupuestado = (Obr.P_Total_Ingresos1_Conta - (Obr.P_Total_GastosContribuciondirecta2_Conta + Obr.P_Total_Gastosdirectos3_Conta));
                        Dr[Obr.Nombre] = Importe;
                        Dr["P_" + Obr.Nombre] = presupuestado;
                        break;
                    case 8: //TOTAL RESULTADO FINAL 
                        Importe = (Obr.Total_restoIngresos7_Conta + Obr.Total_Ingresos1_Conta + Obr.Balance_Fijos.Where(p => ejercicios.Select(i => i.ToString(CultureInfo.InvariantCulture)).Aggregate((s1, s2) => s1 + ", " + s2).Contains(p.Año.ToString()) && p.id_TipoCoste == 1).ToList().Sum(p => p.Importe)) - (Obr.Total_GastosContribuciondirecta2_Conta + Obr.Total_Gastosdirectos3_Conta + Obr.Balance_Fijos.Where(p => ejercicios.Select(i => i.ToString(CultureInfo.InvariantCulture)).Aggregate((s1, s2) => s1 + ", " + s2).Contains(p.Año.ToString()) && p.id_TipoCoste == 3).ToList().Sum(p => p.Importe));
                        presupuestado = (Obr.P_Total_restoIngresos7_Conta + Obr.P_Total_Ingresos1_Conta) - (Obr.P_Total_GastosContribuciondirecta2_Conta + Obr.P_Total_Gastosdirectos3_Conta);
                        Dr[Obr.Nombre] = Importe;
                        Dr["P_" + Obr.Nombre] = presupuestado;
                        break;
                    case 13: //AJUSTE
                        Importe = Obr.Balance_Fijos.Where(p => ejercicios.Select(i => i.ToString(CultureInfo.InvariantCulture)).Aggregate((s1, s2) => s1 + ", " + s2).Contains(p.Año.ToString()) && p.id_TipoCoste == 4).ToList().Sum(p => p.Importe);
                        //presupuestado = (Obr.P_Total_restoIngresos7_Conta + Obr.P_Total_Ingresos1_Conta) - (Obr.P_Total_GastosContribuciondirecta2_Conta + Obr.P_Total_Gastosdirectos3_Conta + Obr.P_Total_GastosGENERAL5_Conta);
                        Dr[Obr.Nombre] = Importe;
                        Dr["P_" + Obr.Nombre] = presupuestado;
                        break;
                    case 14: // TOTAL RESULTADO FINAL - AJUSTE
                        Importe = (Obr.Total_restoIngresos7_Conta + Obr.Total_Ingresos1_Conta + Obr.Balance_Fijos.Where(p => ejercicios.Select(i => i.ToString(CultureInfo.InvariantCulture)).Aggregate((s1, s2) => s1 + ", " + s2).Contains(p.Año.ToString()) && p.id_TipoCoste == 1).ToList().Sum(p => p.Importe)) - (Obr.Total_GastosContribuciondirecta2_Conta + Obr.Total_Gastosdirectos3_Conta + Obr.Balance_Fijos.Where(p => ejercicios.Select(i => i.ToString(CultureInfo.InvariantCulture)).Aggregate((s1, s2) => s1 + ", " + s2).Contains(p.Año.ToString()) && p.id_TipoCoste == 3).ToList().Sum(p => p.Importe) + Obr.Balance_Fijos.Where(p => ejercicios.Select(i => i.ToString(CultureInfo.InvariantCulture)).Aggregate((s1, s2) => s1 + ", " + s2).Contains(p.Año.ToString()) && p.id_TipoCoste == 4).ToList().Sum(p => p.Importe) + Obr.RepercutidoGeneral19);
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
                        Importe =((Obr.Total_restoIngresos7_Conta + Obr.Total_Ingresos1_Conta + Obr.Balance_Fijos.Where(p => ejercicios.Select(i => i.ToString(CultureInfo.InvariantCulture)).Aggregate((s1, s2) => s1 + ", " + s2).Contains(p.Año.ToString()) && p.id_TipoCoste == 1).ToList().Sum(p => p.Importe)) - (Obr.Total_GastosContribuciondirecta2_Conta + Obr.Total_Gastosdirectos3_Conta + Obr.Balance_Fijos.Where(p => ejercicios.Select(i => i.ToString(CultureInfo.InvariantCulture)).Aggregate((s1, s2) => s1 + ", " + s2).Contains(p.Año.ToString()) && p.id_TipoCoste == 3).ToList().Sum(p => p.Importe))) - (Obr.Total_Hipotecas + Obr.Balance_Fijos.Where(p => ejercicios.Select(i => i.ToString(CultureInfo.InvariantCulture)).Aggregate((s1, s2) => s1 + ", " + s2).Contains(p.Año.ToString()) && p.id_TipoCoste == 4).ToList().Sum(p => p.Importe) + Obr.RepercutidoGeneral19);
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
                    case 19: //AJUESTE GENERAL
                        Importe = Obr.RepercutidoGeneral19;
                        presupuestado = 0;
                        Dr[Obr.Nombre] = Importe;
                        Dr["P_" + Obr.Nombre] = presupuestado;
                        break;
                    case 31: //VALOR VENTA
                        Importe = (Obr.ValorVenta == null)?0: Convert.ToDecimal(Obr.ValorVenta);
                        presupuestado = 0;
                        Dr[Obr.Nombre] = Importe;
                        Dr["P_" + Obr.Nombre] = presupuestado;
                        break;
                    //case 32: //COBRADO 2017
                    //    Importe = (Obr.Cobrado2017 == null) ? 0 : Convert.ToDecimal(Obr.Cobrado2017);
                    //    presupuestado = 0;
                    //    Dr[Obr.Nombre] = Importe;
                    //    Dr["P_" + Obr.Nombre] = presupuestado;
                    //    break;
                    //case 33: //GASTOS 2017
                    //    Importe = (Obr.Gastos2017 == null) ? 0 : Convert.ToDecimal(Obr.Gastos2017);
                    //    presupuestado = 0;
                    //    Dr[Obr.Nombre] = Importe;
                    //    Dr["P_" + Obr.Nombre] = presupuestado;
                    //    break;
                    case 34: //GASTOS 2017
                        Importe = Convert.ToDecimal(Obr.ValorVenta) - (Obr.Balance_Fijos.Where(p => ejercicios.Select(i => i.ToString(CultureInfo.InvariantCulture)).Aggregate((s1, s2) => s1 + ", " + s2).Contains(p.Año.ToString()) && p.id_TipoCoste == 1 && p.Concepto.Contains("Cepsa")).ToList().Sum(p => p.Importe) + BalanceCN.IngresosObra_Conta(Obr, 186, id_infro.ToString()));
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
        public static void Mostrar_Inform(List<Obras> L_Obras, bool congenerales,DataTable dt, DataGridView dg, Guid id_infro,List<int> ejercicios)
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
                Crea_Fila(Dr, Grup, L_Obras.Where(p => p.Nombre != "GENERAL").ToList(), id_infro,ejercicios);
                dt.Rows.Add(Dr);
            }
            //--------------------TOTALES INGRESOS 1
            R_Totales = dt.NewRow();
            Crea_Fila_Totales(R_Totales, L_Obras, "TOT. INGRESOS DIRECTOS", 1, 1, ejercicios);
            dt.Rows.Add(R_Totales);

            //AGREGAMOS LOS GASTOS DE CONTIBUCION DIRECTA
            foreach (Grupos Grup in lgrupos.Where(p => p.Id_Tipo == 1 && p.Id_TipoCoste == 2))
            {
                DataRow Dr = dt.NewRow();
                Crea_Fila(Dr, Grup, L_Obras.Where(p => p.Nombre != "GENERAL").ToList(), id_infro, ejercicios);
                if (Convert.ToDecimal(Dr["TOTAL CIA"]) != 0 || Convert.ToDecimal(Dr["P_TOTAL CIA"]) != 0) dt.Rows.Add(Dr);
            }
            //--------------------AGREGAMOS  GASTOS DE CONTIBUCION DIRECTA 2
            R_Totales = dt.NewRow();
            Crea_Fila_Totales(R_Totales, L_Obras, "TOT. GASTOS DE CONTIBUCION DIRECTA", 2, 2, ejercicios);
            dt.Rows.Add(R_Totales);

            //AGREGAMOS LOS GASTOS DIRECTOS
            foreach (Grupos Grup in lgrupos.Where(p => p.Id_Tipo == 1 && p.Id_TipoCoste == 3))
            {
                DataRow Dr = dt.NewRow();
                Crea_Fila(Dr, Grup, L_Obras.Where(p => p.Nombre != "GENERAL").ToList(), id_infro, ejercicios);
                if (Convert.ToDecimal(Dr["TOTAL CIA"]) != 0 || Convert.ToDecimal(Dr["P_TOTAL CIA"]) != 0) dt.Rows.Add(Dr);
            }
            //--------------------AGREGAMOS TOTALES GASTOS DIRECTOS 3
            R_Totales = dt.NewRow();
            Crea_Fila_Totales(R_Totales, L_Obras, "TOT. GASTOS DIRECTOS", 3, 3,ejercicios);
            dt.Rows.Add(R_Totales);

            //--------------------AGREGAMOS TOTALES RESULTADO DE EXPLOTACION DIRECTA 4
            if (congenerales)
            {

                R_Totales = dt.NewRow();
                Crea_Fila_Totales(R_Totales, L_Obras, "TOT. EXPLOTACION DIRECTO", 4, 4,ejercicios);
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
                Crea_Fila_Totales(R_Totales, L_Obras.Where(p => p.Nombre != "GENERAL").ToList(), "TOT. GASTOS GENERALES", 5, 5,ejercicios);
                dt.Rows.Add(R_Totales);
                //--------------------AGREGAMOS TOTALES RESULTADO DE EXPLOTACION NETO 6
                R_Totales = dt.NewRow();
                Crea_Fila_Totales(R_Totales, L_Obras.Where(p => p.Nombre != "GENERAL").ToList(), "TOT. EXPLOTACION DIRECTO GENERALES", 6, 6,ejercicios);
                dt.Rows.Add(R_Totales);
            }

            // AGREGAMOS LOS INGRESOS NO REPARTIR

            foreach (Grupos Grup in lgrupos.Where(p => p.Id_Tipo == 7))
            {
                DataRow Dr = dt.NewRow();
                Crea_Fila(Dr, Grup, L_Obras, id_infro, ejercicios);
                if (Convert.ToDecimal(Dr["TOTAL CIA"]) != 0) dt.Rows.Add(Dr);
            }

            //--------------------AGREGAMOS TOTALES RESULTADO 8
            R_Totales = dt.NewRow();
            Crea_Fila_Totales(R_Totales, L_Obras.Where(p => p.Nombre != "GENERAL").ToList(), "TOT. RESULTADO FINAL", 8, 8,ejercicios);
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
        public static void Mostrar_Inform2(List<Obras> L_Obras, bool congenerales, DataTable dta, DataGridView dg, Guid id_infro, List<int> ejercicios)
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
           

            //--------------------TOTALES INGRESOS 1
            R_Totales = dta.NewRow();
            Crea_Fila_Totales(R_Totales, L_Obras, "TOT. FACTURADO", 11, 11,ejercicios);
            dta.Rows.Add(R_Totales);

            //AGREGAMOS LOS GASTOS DE CONTIBUCION DIRECTA
            foreach (Grupos Grup in lgrupos.Where(p => p.Id_Tipo == 1 && p.Id_TipoCoste == 2))
            {
                DataRow Dr = dta.NewRow();
                Crea_Fila(Dr, Grup, L_Obras.Where(p => p.Nombre != "GENERAL").ToList(), id_infro, ejercicios);
                if (Convert.ToDecimal(Dr["TOTAL CIA"]) != 0 || Convert.ToDecimal(Dr["P_TOTAL CIA"]) != 0) dta.Rows.Add(Dr);
            }
            
            //--------------------AGREGAMOS TOTALES GASTOS CONTRIBUCION DIRECTA 2
            R_Totales = dta.NewRow();
            Crea_Fila_Totales(R_Totales, L_Obras, " MARGEN DE CONTRIBUCIÓN", 22, 22,ejercicios);
            dta.Rows.Add(R_Totales);
            
            //AGREGAMOS LOS GASTOS DIRECTOS
            foreach (Grupos Grup in lgrupos.Where(p => p.Id_Tipo == 1 && p.Id_TipoCoste == 3))
            {
                DataRow Dr = dta.NewRow();
                Crea_Fila(Dr, Grup, L_Obras.Where(p => p.Nombre != "GENERAL").ToList(), id_infro, ejercicios);
                if (Convert.ToDecimal(Dr["TOTAL CIA"]) != 0 || Convert.ToDecimal(Dr["P_TOTAL CIA"]) != 0) dta.Rows.Add(Dr);
            }


            //--------------------AGREGAMOS TOTALES GASTOS DIRECTOS 3
            R_Totales = dta.NewRow();
            Crea_Fila_Totales(R_Totales, L_Obras, "TOT. GASTOS ", 3, 3,ejercicios);
            dta.Rows.Add(R_Totales);

            R_Totales = dta.NewRow();
            dta.Rows.Add(R_Totales);

            //--------------------AGREGAMOS TOTALES RESULTADO 8
            R_Totales = dta.NewRow();
            Crea_Fila_Totales(R_Totales, L_Obras.Where(p => p.Nombre != "GENERAL").ToList(), "BENEFICIO / PERDIDA", 8, 8,ejercicios);
            dta.Rows.Add(R_Totales);
            //--------------------AGREGAMOS AJUSTES  13
            R_Totales = dta.NewRow();
            Crea_Fila_Totales(R_Totales, L_Obras.Where(p => p.Nombre != "GENERAL").ToList(), "AJUSTE", 13, 13,ejercicios);
            dta.Rows.Add(R_Totales);
            //--------------------AGREGAMOS AJUSTES GENERALES 19
            R_Totales = dta.NewRow();
            Crea_Fila_Totales(R_Totales, L_Obras.Where(p => p.Nombre != "GENERAL").ToList(), "AJUSTE GENERAL", 19, 19,ejercicios);
            dta.Rows.Add(R_Totales);

            //--------------------AGREGAMOS TOTALES RESULTADO 14
            R_Totales = dta.NewRow();
            Crea_Fila_Totales(R_Totales, L_Obras.Where(p => p.Nombre != "GENERAL").ToList(), "TOT. RESULTADO", 14, 14,ejercicios);
            dta.Rows.Add(R_Totales);

            R_Totales = dta.NewRow();
            dta.Rows.Add(R_Totales);
          
            //--------------------AGREGAMOS TOTALES HIPOTECAS 16
            R_Totales = dta.NewRow();
            Crea_Fila_Totales(R_Totales, L_Obras.Where(p => p.Nombre != "GENERAL").ToList(), "HIPOTECAS / INTERESES", 16, 16,ejercicios);
            dta.Rows.Add(R_Totales);

           
            //--------------------AGREGAMOS TOTALES INCLUYENDO LAS HIPOTECAS 17
            R_Totales = dta.NewRow();
            Crea_Fila_Totales(R_Totales, L_Obras.Where(p => p.Nombre != "GENERAL").ToList(), "TOT. RESULTADO", 17, 17,ejercicios);
            dta.Rows.Add(R_Totales);

            R_Totales = dta.NewRow();
            dta.Rows.Add(R_Totales);          

            //--------------------AGREGAMOS LO INGRESADO EN BANCO 18
            R_Totales = dta.NewRow();
            Crea_Fila_Totales(R_Totales, L_Obras, "TOT. INGRESO BANCO ", 18, 18,ejercicios);
            dta.Rows.Add(R_Totales);

            R_Totales = dta.NewRow();
            dta.Rows.Add(R_Totales);

            //--------------------------------AGREGAMOS EL PRESUPUESTO
            R_Totales = dta.NewRow();
            Crea_Fila_Totales(R_Totales, L_Obras.Where(p => p.Nombre != "GENERAL").ToList(), "PRESUPUESTO COSTE", 90, 90,ejercicios);
            dta.Rows.Add(R_Totales);
            R_Totales = dta.NewRow();
            Crea_Fila_Totales(R_Totales, L_Obras.Where(p => p.Nombre != "GENERAL").ToList(), "PRESUPUESTO VENTA", 91, 91,ejercicios);
            dta.Rows.Add(R_Totales);
            R_Totales = dta.NewRow();
            Crea_Fila_Totales(R_Totales, L_Obras.Where(p => p.Nombre != "GENERAL").ToList(), "BENEFICIO PREVISTO", 92, 92,ejercicios);
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
        public static void Mostrar_InformBATOR(List<Obras> L_Obras, bool congenerales, DataTable dta, DataGridView dg, Guid id_infro,List<int>  ejercicios, bool valorventa)
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


            //AGRGEAMOS  VALOR VENTA
            if (valorventa)
            {
                R_Totales = dta.NewRow();
                Crea_Fila_Totales(R_Totales, L_Obras, "VALOR VENTA", 31, 31,ejercicios);
                dta.Rows.Add(R_Totales);
            }          

            //AGREGAMOS LOS INGRESOS
            foreach (Grupos Grup in lgrupos.Where(p => p.Id_Tipo == 0 || p.Id_Tipo == 7))
            {
                DataRow Dr = dta.NewRow();
                Crea_Fila(Dr, Grup, L_Obras.Where(p => p.Nombre != "GENERAL").ToList(), id_infro, ejercicios);
                if (Convert.ToDecimal(Dr["TOTAL CIA"]) != 0 || Convert.ToDecimal(Dr["P_TOTAL CIA"]) != 0) dta.Rows.Add(Dr);
            }

            //AGREGAMOS LOS INGRESOS FIJOS
            foreach (Balance_Fijos IngresosFijos in BalanceCN.ListarFijos().Where(p=> ejercicios.Select(i => i.ToString(CultureInfo.InvariantCulture)).Aggregate((s1, s2) => s1 + ", " + s2).Contains(p.Año.ToString()) && p.id_TipoCoste == 1).ToList()) 
            {
                DataRow Dr = dta.NewRow();
                Grupos Grp = new Grupos();
                Grp.Id_TipoCoste = 32;
                Grp.Id_Grupo = IngresosFijos.Id_Gasto;
                Grp.Nombre = IngresosFijos.Concepto;
                Crea_Fila(Dr, Grp, L_Obras.ToList(), id_infro, ejercicios);
                if (Convert.ToDecimal(Dr["TOTAL CIA"]) != 0 || Convert.ToDecimal(Dr["P_TOTAL CIA"]) != 0) dta.Rows.Add(Dr);
            }

            //--------------------TOTALES INGRESOS 1
            R_Totales = dta.NewRow();
            Crea_Fila_Totales(R_Totales, L_Obras, "TOT. INGRESADO", 11, 11,ejercicios);
            dta.Rows.Add(R_Totales);

            //AGREGAMOS LOS GASTOS DE CONTIBUCION DIRECTA
            foreach (Grupos Grup in lgrupos.Where(p => p.Id_Tipo == 1 && p.Id_TipoCoste == 2))
            {
                DataRow Dr = dta.NewRow();
                Crea_Fila(Dr, Grup, L_Obras.Where(p => p.Nombre != "GENERAL").ToList(), id_infro, ejercicios);
                if (Convert.ToDecimal(Dr["TOTAL CIA"]) != 0 || Convert.ToDecimal(Dr["P_TOTAL CIA"]) != 0) dta.Rows.Add(Dr);
            }            

            //AGREGAMOS LOS GASTOS DIRECTOS
            foreach (Grupos Grup in lgrupos.Where(p => p.Id_Tipo == 1 && p.Id_TipoCoste == 3))
            {
                DataRow Dr = dta.NewRow();
                Crea_Fila(Dr, Grup, L_Obras.Where(p => p.Nombre != "GENERAL").ToList(), id_infro, ejercicios);
                if (Convert.ToDecimal(Dr["TOTAL CIA"]) != 0 || Convert.ToDecimal(Dr["P_TOTAL CIA"]) != 0) dta.Rows.Add(Dr);
            }
            //AGREGAMOS LOS GASTOS FIJOS
            foreach (Balance_Fijos GastosFijos in BalanceCN.ListarFijos().Where(p => ejercicios.Select(i => i.ToString(CultureInfo.InvariantCulture)).Aggregate((s1, s2) => s1 + ", " + s2).Contains(p.Año.ToString()) && p.id_TipoCoste == 3).ToList())
            {
                DataRow Dr = dta.NewRow();
                Grupos Grp = new Grupos();
                Grp.Id_TipoCoste = 33;
                Grp.Id_Grupo = GastosFijos.Id_Gasto;
                Grp.Nombre = GastosFijos.Concepto;
                Crea_Fila(Dr, Grp, L_Obras.ToList(), id_infro, ejercicios);
                if (Convert.ToDecimal(Dr["TOTAL CIA"]) != 0 || Convert.ToDecimal(Dr["P_TOTAL CIA"]) != 0) dta.Rows.Add(Dr);
            }
           
            //--------------------AGREGAMOS TOTALES GASTOS DIRECTOS 3
            R_Totales = dta.NewRow();
            Crea_Fila_Totales(R_Totales, L_Obras, "TOT. GASTOS ", 5, 5,ejercicios);
            dta.Rows.Add(R_Totales);

            R_Totales = dta.NewRow();
            dta.Rows.Add(R_Totales);

            //--------------------AGREGAMOS TOTALES RESULTADO 8
            R_Totales = dta.NewRow();
            Crea_Fila_Totales(R_Totales, L_Obras.Where(p => p.Nombre != "GENERAL").ToList(), "BENEFICIO / PERDIDA", 8, 8,ejercicios);
            dta.Rows.Add(R_Totales);
            //--------------------AGREGAMOS AJUSTES  13
            foreach (Balance_Fijos AjustesFijos in BalanceCN.ListarFijos().Where(p => ejercicios.Select(i => i.ToString(CultureInfo.InvariantCulture)).Aggregate((s1, s2) => s1 + ", " + s2).Contains(p.Año.ToString()) && p.id_TipoCoste == 4).ToList())
            {
                DataRow Dr = dta.NewRow();
                Grupos Grp = new Grupos();
                Grp.Id_TipoCoste = 13;
                Grp.Id_Grupo = AjustesFijos.Id_Gasto;
                Grp.Nombre = AjustesFijos.Concepto;
                Crea_Fila(Dr, Grp, L_Obras.ToList(), id_infro, ejercicios);
                if (Convert.ToDecimal(Dr["TOTAL CIA"]) != 0 || Convert.ToDecimal(Dr["P_TOTAL CIA"]) != 0) dta.Rows.Add(Dr);
            }
            //--------------------AGREGAMOS AJUSTES GENERALES 19
            //R_Totales = dta.NewRow();
            //Crea_Fila_Totales(R_Totales, L_Obras.Where(p => p.Nombre != "GENERAL").ToList(), "AJUSTE GENERAL", 19, 19);
            //dta.Rows.Add(R_Totales);

            //--------------------AGREGAMOS TOTALES RESULTADO 14
            R_Totales = dta.NewRow();
            Crea_Fila_Totales(R_Totales, L_Obras.Where(p => p.Nombre != "GENERAL").ToList(), "TOT. RESULTADO", 14, 14,ejercicios);
            dta.Rows.Add(R_Totales);


            //--------------------AGREGAMOS TOTALES HIPOTECAS 16
            //R_Totales = dta.NewRow();
            //Crea_Fila_Totales(R_Totales, L_Obras.Where(p => p.Nombre != "GENERAL").ToList(), "HIPOTECAS / INTERESES", 16, 16);
            //dta.Rows.Add(R_Totales);


            //--------------------AGREGAMOS TOTALES INCLUYENDO LAS HIPOTECAS 17
            //R_Totales = dta.NewRow();
            //Crea_Fila_Totales(R_Totales, L_Obras.Where(p => p.Nombre != "GENERAL").ToList(), "TOT. RESULTADO", 17, 17);
            //dta.Rows.Add(R_Totales);

            //R_Totales = dta.NewRow();
            //dta.Rows.Add(R_Totales);

            //--------------------AGREGAMOS LO INGRESADO EN BANCO 18
            //R_Totales = dta.NewRow();
            //Crea_Fila_Totales(R_Totales, L_Obras, "TOT. INGRESO BANCO ", 18, 18);
            //dta.Rows.Add(R_Totales);

            //R_Totales = dta.NewRow();
            //dta.Rows.Add(R_Totales);

            //--------------------AGREGAMOS TOTALES RESULTADO 34
            if (valorventa)
            {
                R_Totales = dta.NewRow();
                Crea_Fila_Totales(R_Totales, L_Obras.Where(p => p.Nombre != "GENERAL").ToList(), "FALTA PAGAR CEPSA", 34, 34, ejercicios, id_infro);
                dta.Rows.Add(R_Totales);

            }

            //--------------------------------AGREGAMOS EL PRESUPUESTO
            //R_Totales = dta.NewRow();
            //Crea_Fila_Totales(R_Totales, L_Obras.Where(p => p.Nombre != "GENERAL").ToList(), "PRESUPUESTO COSTE", 90, 90);
            //dta.Rows.Add(R_Totales);
            //R_Totales = dta.NewRow();
            //Crea_Fila_Totales(R_Totales, L_Obras.Where(p => p.Nombre != "GENERAL").ToList(), "PRESUPUESTO VENTA", 91, 91);
            //dta.Rows.Add(R_Totales);
            //R_Totales = dta.NewRow();
            //Crea_Fila_Totales(R_Totales, L_Obras.Where(p => p.Nombre != "GENERAL").ToList(), "BENEFICIO PREVISTO", 92, 92);
            //dta.Rows.Add(R_Totales);



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


          
            foreach (Subgrupos SubGrup in lgrupos.Where(p=> p.Id_Grupo == Id_grupo).SelectMany(p=> p.Subgrupos).ToList())
            {
                DataRow Dr = dt.NewRow();
                Crea_FilaSubgrupos (Dr, SubGrup, L_Obras.Where(p => p.Nombre != "GENERAL").ToList(), id_infro);
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
                    Col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
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
                if (Convert.ToInt32(Row.Cells["Id_Tipo"].Value) == 34)
                {
                    Row.DefaultCellStyle.ForeColor = Color.DarkBlue;
                    Row.DefaultCellStyle.BackColor = Color.WhiteSmoke;
                    Row.DefaultCellStyle.Font = new Font(dginforme.Font, FontStyle.Bold);
                }
                if (Convert.ToInt32(Row.Cells["Id_Tipo"].Value) == 31)
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
                if (Convert.ToInt32(Row.Cells["Id_Tipo"].Value) == 22)
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
             
                if (Convert.ToInt32(Row.Cells["Id_Tipo"].Value) == 16)
                {
                    Row.DefaultCellStyle.ForeColor = Color.Firebrick;
                    Row.DefaultCellStyle.BackColor = Color.WhiteSmoke;
                    Row.DefaultCellStyle.Font = new Font(dginforme.Font, FontStyle.Bold);
                }
                if (Convert.ToInt32(Row.Cells["Id_Tipo"].Value) == 130)
                {
                    Row.DefaultCellStyle.ForeColor = Color.Firebrick;
                    Row.DefaultCellStyle.BackColor = Color.WhiteSmoke;
                    Row.DefaultCellStyle.Font = new Font(dginforme.Font, FontStyle.Bold);
                }
                if (Convert.ToInt32(Row.Cells["Id_Tipo"].Value) == 19)
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
                            case 10:
                                Cell.Style.ForeColor = Color.Blue;
                                break;
                            case 70:
                                Cell.Style.ForeColor = Color.Blue;
                                break;
                            case 320:                               
                                Cell.Style.ForeColor = Color.Blue;
                                break;
                            case 4:                               
                                if (Convert.ToInt32(Cell.Value) >= 0)
                                    Cell.Style.ForeColor = Color.Green;
                                else
                                    Cell.Style.ForeColor = Color.Red;
                               break;                          
                            case 17:                               
                                if (Convert.ToInt32(Cell.Value) >= 0)
                                    Cell.Style.ForeColor = Color.Green;
                                else
                                    Cell.Style.ForeColor = Color.Red;
                                break;                          
                            case 6:                               
                                if (Convert.ToInt32(Cell.Value) >= 0)
                                    Cell.Style.ForeColor = Color.Green;
                                else
                                    Cell.Style.ForeColor = Color.Red;
                                break;
                            case 8:                               
                                if (Convert.ToInt32(Cell.Value) >= 0)
                                    Cell.Style.ForeColor = Color.Green;
                                else
                                    Cell.Style.ForeColor = Color.Red;
                                break;
                            case 22:                               
                                if (Convert.ToInt32(Cell.Value) >= 0)
                                    Cell.Style.ForeColor = Color.Green;
                                else
                                    Cell.Style.ForeColor = Color.Red;
                                break;
                            case 14:                             
                                if (Convert.ToInt32(Cell.Value) >= 0)
                                    Cell.Style.ForeColor = Color.Green;
                                else
                                    Cell.Style.ForeColor = Color.Red;
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

    }
}

//