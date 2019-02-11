using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;
using System.Security.Principal;
using System.Globalization;

namespace Negocio
{
    public class CalculoCN
    {
        public static List<Cuentas> Comprobacion_cuentas(Empresas Empresa,List<Obras> Obras)
        {
            List<Cuentas> CuentasConta = new List<Cuentas>();
            List<Cuentas> CuentasConstructora = new List<Cuentas>();
            string Canales_Obras = Obras.Select(i => i.Id_Obra.ToString(CultureInfo.InvariantCulture)).Aggregate((s1, s2) => s1 + ", " + s2);
            //Cogemos las cuentas que tenemos en nuestra Base de datos
            CuentasConstructora = (List<Cuentas>)Empresa.Cuentas.ToList();
            //Cogemos las cuentas que tenemos en la base de datos de CONTAWIN
            Conexion.IniciarSesion(Empresa.Servidor_ContaWin , Empresa.BBDD_ContaWin , Empresa.Usuario_ContaWin , Empresa.Pwd_ContaWin );
            DataTable dtcuentasConta = Conexion.GDatos.TraerDataTableSql("SELECT a.Cuenta, canal, p.titulo FROM Apuntes a LEFT JOIN Plan_cuentas p ON p.Cuenta = a.Cuenta WHERE ejercicio >=2018  AND canal in(" + Canales_Obras + ") AND Diario <>'B' AND Diario <> 'E'  AND Diario <>'C' AND (a.cuenta like '6%' or a.cuenta like '7%' or a.cuenta like '43%' or a.cuenta like '41%' or a.cuenta like '440%' or a.cuenta like '5%') GROUP BY a.Cuenta,a.Canal, p.titulo");
            foreach (DataRow row in dtcuentasConta.Rows)
            {
                Cuentas Cuenta = new Cuentas(Convert.ToString(row[0]));
                Cuenta.Id_Empresa = Empresa.Id_Empresa;
               //Cuenta.Id_Obra = Convert.ToInt32(row["canal"]);
                Cuenta.Nombre = Convert.ToString(row["titulo"]);
                CuentasConta.Add(Cuenta);
            }
            Conexion.FinalizarSesion();


            var query = from c in CuentasConta
                        where !(from o in CuentasConstructora select o.Cuenta).Contains(c.Cuenta)
                        select c;

            return query.ToList();  
        }

        public static List<int> Comprobacion_canales(Empresas Empresa, int Ejercicio)
        {
            List<int> l_canalaes = new List<int>();
            Conexion.IniciarSesion(Empresa.Servidor_ContaWin, Empresa.BBDD_ContaWin, Empresa.Usuario_ContaWin, Empresa.Pwd_ContaWin);
            DataTable dtcanales = Conexion.GDatos.TraerDataTableSql("SELECT a.Canal FROM Apuntes  a WHERE ejercicio >=2018  AND Ejercicio = " + Ejercicio.ToString() + " AND Diario <>'B' AND Diario <> 'E' AND Diario <>'C' AND (a.cuenta like '6%' or a.cuenta like '7%' or a.cuenta like '5%'  or a.cuenta like '4%') GROUP BY a.Canal");
            Conexion.FinalizarSesion();
            foreach (DataRow row in dtcanales.Rows)
            {
                l_canalaes.Add(Convert.ToInt32(row["canal"]));
            }
            return l_canalaes;
        }

        public static DataTable Lineas_DetalleAsientos(Empresas Empresa,int ejercicio,int Id_Obra,string cuentas, DateTime fecha)
        {
            DataTable DtDetalles = new DataTable();
            Conexion.IniciarSesion(Empresa.Servidor_ContaWin, Empresa.BBDD_ContaWin, Empresa.Usuario_ContaWin, Empresa.Pwd_ContaWin);
            if (ejercicio == 0)
            {
                DtDetalles = Conexion.GDatos.TraerDataTableSql("SELECT Fecha,Asiento,Cuenta,Descripcion, debe as 'Debe', haber as 'Haber' FROM Apuntes  WHERE ejercicio >=2018  AND Cuenta in(" + cuentas +") AND canal = " + Id_Obra + " AND Diario <>'B' AND Diario <> 'E' AND   Diario <>'C' AND Fecha <='" + fecha + "'");
            }
            else
           {
                DtDetalles = Conexion.GDatos.TraerDataTableSql("SELECT Fecha,Asiento,Cuenta,Descripcion, debe as 'Debe', haber as 'Haber'  FROM Apuntes  WHERE ejercicio >=2018  AND Cuenta in(" + cuentas + ")  AND Ejercicio = " + ejercicio + " AND canal =" + Id_Obra + " AND Diario <>'B' AND Diario <> 'E'  AND  Diario <>'C' AND Fecha <='" + fecha + "'");
            }
            Conexion.FinalizarSesion();
            return DtDetalles;
        }
        public static DataTable Lineas_DetalleAsientos(Empresas Empresa, int Id_Obra, string cuentas, DateTime fechaini, DateTime fechafin)
        {
            DataTable DtDetalles = new DataTable();
            Conexion.IniciarSesion(Empresa.Servidor_ContaWin, Empresa.BBDD_ContaWin, Empresa.Usuario_ContaWin, Empresa.Pwd_ContaWin);
            DtDetalles = Conexion.GDatos.TraerDataTableSql("SELECT Fecha,Asiento,Cuenta,Descripcion, debe as 'Debe', haber as 'Haber' FROM Apuntes  WHERE ejercicio >=2018  AND Cuenta in(" + cuentas + ") AND canal = " + Id_Obra + " AND Diario <>'B' AND Diario <> 'E'  AND Diario <>'C' AND Fecha >='" + fechaini + "' AND Fecha <='" + fechafin + "'"); 
            Conexion.FinalizarSesion();
            return DtDetalles; 
        }



        public static DateTime Primerafecha(Empresas Empresa, string Canales_Obras, DateTime fecha)
        {
            Conexion.IniciarSesion(Empresa.Servidor_ContaWin, Empresa.BBDD_ContaWin, Empresa.Usuario_ContaWin, Empresa.Pwd_ContaWin);
            DataTable dtPrimerafecha = new DataTable();
            dtPrimerafecha = Conexion.GDatos.TraerDataTableSql("SELECT  top 1 fecha FROM Apuntes  WHERE  canal in(" + Canales_Obras + ") AND Diario <>'B' AND Diario <> 'E'  AND Diario <>'C' AND Fecha <='" + fecha + "' ORDER BY Fecha ");
            Conexion.FinalizarSesion();
            if (dtPrimerafecha.Rows.Count > 0)
            {
                return Convert.ToDateTime(dtPrimerafecha.Rows[0][0]);
            }
            else
            {
                return DateTime.Today;
            }        
        }

        public static List<Balance> Creacion_Informe(string id_infr, List<Empresas> Empresas, bool desglose, int ejercicio, DateTime fechaini, DateTime fechafin)
        {
            List<Cuentas> CuentasConta = new List<Cuentas>();
            List<Cuentas> CuentasConstructora = new List<Cuentas>();
            List<Balance> Inform = new List<Balance>();
            List<int> ObrasFaltan = new List<int>();
            DataTable dtcuentasConta = new DataTable();
            foreach (Empresas Empresa in Empresas)
            {
                //Cogemos las cuentas que tenemos en nuestra Base de datos
                CuentasConstructora = (List<Cuentas>)Empresa.Cuentas.ToList();
                //Cogemos las cuentas que tenemos en la base de datos de CONTAWIN           
                Conexion.IniciarSesion(Empresa.Servidor_ContaWin, Empresa.BBDD_ContaWin, Empresa.Usuario_ContaWin, Empresa.Pwd_ContaWin);
                string Canales_Obras = Empresa.Obras.ToList().Select(i => i.Id_Obra.ToString(CultureInfo.InvariantCulture)).Aggregate((s1, s2) => s1 + ", " + s2);
                dtcuentasConta = Conexion.GDatos.TraerDataTableSql("SELECT cuenta,canal,Sum(debe) as 'debe',sum(haber) as 'haber' FROM Apuntes  WHERE ejercicio >=2018  AND   Diario <>'B' AND Diario <> 'E' AND Diario <>'C' AND Fecha >='" + fechaini + "' AND Fecha <='" + fechafin + "' GROUP BY Cuenta,canal");
                //dtcuentasConta = Conexion.GDatos.TraerDataTableSql("SELECT *  FROM Apuntes  WHERE   Diario <>'B' AND Diario <> 'E' AND Diario <>'C' AND Fecha >='" + fechaini + "' AND Fecha <='" + fechafin + "'");

                string usu = WindowsIdentity.GetCurrent().Name.ToString();

                foreach (DataRow row in dtcuentasConta.Rows)
                {
                    //if (Convert.ToInt32(row["Canal"]) == 79 && Empresa.Id_Empresa == 7 && Convert.ToInt32(row["ejercicio"]) != DateTime.Now.Year)
                    //{
                    //    continue;
                    //}
                    if (Empresa.Obras.Where(p => p.Id_Obra == Convert.ToInt32(row["canal"])).Count() == 0)
                    {
                        ObrasFaltan.Add(Convert.ToInt32(row["canal"]));
                        continue;
                    }
                    Balance LineaInfor = new Balance();
                    var Cuen = CuentasConstructora.Where(p => p.Cuenta == Convert.ToString(row["Cuenta"])).ToList(); //Where(p => p.Id_Obra == Convert.ToInt32(row["canal"]))
                    if (Cuen.Count == 0) continue; // Si la cuenta no se encuentra en la BBDD, todavia no la han agregado pasamos de ella
                    Cuentas Cuent = Cuen[0];
                    if (Cuent.TrataCuenta == false) continue; // Si la cuenta no se trata pasamos de ella
                    LineaInfor.Id_Obra = Convert.ToInt32(row["canal"]);
                    LineaInfor.Id_Informe = id_infr.ToString();
                    LineaInfor.Usuario = usu;
                    LineaInfor.Imp_debe = string.IsNullOrEmpty(Convert.ToString(row["debe"])) ? 0 : Convert.ToDecimal(row["debe"]);
                    LineaInfor.Imp_Haber = string.IsNullOrEmpty(Convert.ToString(row["haber"])) ? 0 : Convert.ToDecimal(row["haber"]);
                    LineaInfor.Cuenta = Cuent.Id_Cuenta;
                    LineaInfor.Nombre = (desglose) ? Convert.ToString(row["descripcion"]) : "";
                    LineaInfor.fecha = (desglose) ? Convert.ToDateTime(row["Fecha"]) : DateTime.Today;
                    LineaInfor.Id_empresa = Empresa.Id_Empresa;
                    Inform.Add(LineaInfor);
                }
                Conexion.FinalizarSesion();
            }
            
            
          
            return Inform.ToList();

        }

        public static List<Balance> Creacion_Informe(string id_infr,Empresas Empresa, List<Obras> Obras,bool desglose , int ejercicio,DateTime fecha)
        {
            List<Cuentas> CuentasConta = new List<Cuentas>();
            List<Cuentas> CuentasConstructora = new List<Cuentas>();
            List<Balance> Inform = new List<Balance>();
            DataTable dtcuentasConta = new DataTable();
            //Cogemos las cuentas que tenemos en nuestra Base de datos
            CuentasConstructora = (List<Cuentas>) Empresa.Cuentas.ToList();

                //Cogemos las cuentas que tenemos en la base de datos de CONTAWIN
                string Canales_Obras = Obras.Select(i => i.Id_Obra.ToString(CultureInfo.InvariantCulture)).Aggregate((s1, s2) => s1 + ", " + s2);
                Conexion.IniciarSesion(Empresa.Servidor_ContaWin, Empresa.BBDD_ContaWin, Empresa.Usuario_ContaWin, Empresa.Pwd_ContaWin);

            if (desglose)
            {
                if (ejercicio == 0)
                {
                    dtcuentasConta = Conexion.GDatos.TraerDataTableSql("SELECT * FROM Apuntes  WHERE ejercicio >=2018  AND canal in(" + Canales_Obras + ") AND Diario <>'B' AND Diario <> 'E'  AND Diario <>'C'  AND Fecha <='" + fecha +"'");
                }
                else
                {
                    dtcuentasConta = Conexion.GDatos.TraerDataTableSql("SELECT * FROM Apuntes  WHERE ejercicio >=2018  AND Ejercicio = " + ejercicio + " AND canal in(" + Canales_Obras + ") AND Diario <>'B' AND Diario <> 'E'  AND Diario <>'C' AND Fecha <='" + fecha + "'");
                }
            }
            else
            {
                if (ejercicio == 0)
                {
                    dtcuentasConta = Conexion.GDatos.TraerDataTableSql("SELECT Cuenta, SUM(debe) as 'Debe' , SUM(haber) as 'Haber',canal,ISNULL(Ejercicio,0) as 'ejercicio' FROM Apuntes  WHERE ejercicio >=2018  AND canal in(" + Canales_Obras + ") AND (Diario <>'B' AND Diario <> 'E'  AND Diario <>'C') AND Fecha <='" + fecha + "' GROUP BY Cuenta,canal, Ejercicio ");
                }
                else
                {
                    dtcuentasConta = Conexion.GDatos.TraerDataTableSql("SELECT Cuenta, SUM(debe) as 'Debe' , SUM(haber) as 'Haber',canal,ISNULL(Ejercicio,0)  as 'ejercicio'  FROM Apuntes  WHERE ejercicio >=2018  AND Ejercicio = " + ejercicio + " AND canal in(" + Canales_Obras + ") AND (Diario <>'B' AND Diario <> 'E' AND Diario <>'C' ) AND Fecha <='" + fecha + "' GROUP BY Cuenta,canal, Ejercicio");
                }

            }

            string usu = WindowsIdentity.GetCurrent().Name.ToString();

                foreach (DataRow row in dtcuentasConta.Rows)
                {
                if (Convert.ToInt32(row["Canal"]) == 79 && Empresa.Id_Empresa == 7 && Convert.ToInt32(row["ejercicio"]) != DateTime.Now.Year)
                {
                    continue;
                }
                    Balance LineaInfor = new Balance();
                    var Cuen = CuentasConstructora.Where(p => p.Cuenta == Convert.ToString(row["Cuenta"])).ToList(); //Where(p => p.Id_Obra == Convert.ToInt32(row["canal"]))
                    if (Cuen.Count == 0) continue; // Si la cuenta no se encuentra en la BBDD, todavia no la han agregado pasamos de ella
                    Cuentas Cuent = Cuen[0];
                    if (Cuent.TrataCuenta == false) continue; // Si la cuenta no se trata pasamos de ella
                    LineaInfor.Id_Obra = Convert.ToInt32(row["canal"]);
                    LineaInfor.Id_Informe = id_infr.ToString();
                    LineaInfor.Usuario = usu;
                    LineaInfor.Imp_debe = string.IsNullOrEmpty(Convert.ToString(row["debe"])) ? 0 : Convert.ToDecimal(row["debe"]);
                    LineaInfor.Imp_Haber = string.IsNullOrEmpty(Convert.ToString(row["haber"])) ? 0 : Convert.ToDecimal(row["haber"]);
                    LineaInfor.Cuenta = Cuent.Id_Cuenta;
                    LineaInfor.Nombre = (desglose)?Convert.ToString(row["descripcion"]):"";
                    LineaInfor.fecha = (desglose)?Convert.ToDateTime(row["Fecha"]):DateTime.Today;
                    LineaInfor.Id_empresa = Empresa.Id_Empresa;
                    Inform.Add(LineaInfor);
                }
                Conexion.FinalizarSesion();
            return Inform.ToList();

        }
        public static DataTable Cuentas_Proveer(Empresas Empresa, string filtr,int canal)
        {
            Conexion.IniciarSesion(Empresa.Servidor_ContaWin, Empresa.BBDD_ContaWin, Empresa.Usuario_ContaWin, Empresa.Pwd_ContaWin);
            DataTable dt = new DataTable();
            if (canal == -1)
            {
                dt = Conexion.GDatos.TraerDataTableSql(" SELECT Cuenta, Titulo as 'Proveedor'  FROM Plan_cuentas where nivel = 0 and cuenta between 400" + filtr + "00000 and 4009999999");
            }
            else
            {
                dt = Conexion.GDatos.TraerDataTableSql(" SELECT Cuenta, Titulo as 'Proveedor'  FROM Plan_cuentas where nivel = 0 and cuenta between 400" + filtr + "00000 and 4009999999 AND canal = " + canal + "");
            }
            
            Conexion.FinalizarSesion();
            if (dt.Rows.Count > 0)
            {
                return dt;
            }
            else
            {
                return null;
            }
        }
        public static DataTable Extracto_cuenta(Empresas Empresa, string Cta, int ejer )
        {
            Conexion.IniciarSesion(Empresa.Servidor_ContaWin, Empresa.BBDD_ContaWin, Empresa.Usuario_ContaWin, Empresa.Pwd_ContaWin);
            DataTable dt = new DataTable();
            dt = Conexion.GDatos.TraerDataTableSql("SELECT Apuntes.Cuenta, Apuntes.Fecha, Apuntes.Descripcion, Debe, Haber FROM Apuntes, Plan_Cuentas WHERE Apuntes.ejercicio >=2018  AND Apuntes.Cuenta = Plan_Cuentas.Cuenta AND(Diario <> 'B' AND Diario <> 'E') AND Apuntes.Cuenta = '" + Cta + "' AND Apuntes.Ejercicio = "+ ejer +" ORDER By Apuntes.Fecha");
            Conexion.FinalizarSesion();
            return dt;
          
        }

        public static DataRow Fecha_Ultima (Empresas Empresa)
        {
            Conexion.IniciarSesion(Empresa.Servidor_ContaWin, "GestionConstructora", Empresa.Usuario_ContaWin, Empresa.Pwd_ContaWin);
            DataTable dt = new DataTable();
            dt = Conexion.GDatos.TraerDataTableSql("SELECT top 1 fecha , hora  FROM Puertas order by fecha desc, hora desc");
            Conexion.FinalizarSesion();
            return dt.Rows[0];


        }
        public static void Insertar_Puertas(Empresas Emp,DataTable dt)
        {
            Conexion.IniciarSesion(Emp.Servidor_ContaWin, "GestionConstructora", Emp.Usuario_ContaWin, Emp.Pwd_ContaWin);
            foreach (DataRow dr in dt.Rows)
            {
                Conexion.GDatos.EjecutarSql("INSERT INTO Puertas VALUES('"+ dr[0].ToString() + "','"+ dr[1].ToString() + "',"+ dr[2].ToString() + ",'" + dr[3].ToString() + "','" + dr[4].ToString() + "','" + dr[5].ToString() + "')");
            }
            Conexion.FinalizarSesion();
        }

    }
}
