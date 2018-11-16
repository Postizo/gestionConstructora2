using Entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class BancosCN
    {
        public static DataTable TraeCuentas(Empresas Empresa)
        {
            List<int> l_canalaes = new List<int>();
            Conexion.IniciarSesion(Empresa.Servidor_ContaWin, "Comercial", Empresa.Usuario_ContaWin, Empresa.Pwd_ContaWin);
            DataTable dtcuentas = Conexion.GDatos.TraerDataTableSql("SELECT ctacte,Banco,cdBanco + Cdsucur + cta as 'cta' FROM Bancos where estacion = " + Empresa.Id_Banco.ToString());
            Conexion.FinalizarSesion();            
            return dtcuentas;
        }
      
        public static DataTable Movimientos_Bancos(Empresas Empresa, DateTime fini, DateTime ffin)
        {           
            Conexion.IniciarSesion(Empresa.Servidor_ContaWin, "Comercial", Empresa.Usuario_ContaWin, Empresa.Pwd_ContaWin);
            DataTable dtmovimientos = Conexion.GDatos.TraerDataTableSql("SELECT fechavalor,Concepto,debe,haber, 0.0 as 'Saldo' FROM MovimientosBANCO where estacion =" + Empresa.Id_Banco * -1  + " AND FechaOperacion between '"+ fini +"' and '"+ ffin +"'");
            Conexion.FinalizarSesion();
            return dtmovimientos;
        }
        public static double SP_SaldoBanco(Empresas Empresa, string Cta, DateTime FechaIni)
        {
           
            double SaldoIni;
            double SumaMov;
            Conexion.IniciarSesion(Empresa.Servidor_ContaWin, "Comercial", Empresa.Usuario_ContaWin, Empresa.Pwd_ContaWin);
            DataTable dtsaldoincial = Conexion.GDatos.TraerDataTableSql("SELECT SaldoBanco AS Imp FROM Bancos WHERE  (CdBanco + CdSucur + Cta) ='" + Cta + "'");
                     
          
            if (dtsaldoincial.Rows .Count  ==0 )
                SaldoIni = 0;
            else
                SaldoIni = (dtsaldoincial.Rows[0]["Imp"].ToString() == "") ? 0 : Convert.ToDouble(dtsaldoincial.Rows[0]["Imp"]);

            DataTable dtmovimientos = Conexion.GDatos.TraerDataTableSql("SELECT (ISNULL(SUM(Haber),0) - ISNULL(SUM(Debe),0)) AS Imp from MovimientosBanco WHERE NCta ='" + Cta + "' AND FechaOperacion < '" + FechaIni + "'");
                     
            if (dtmovimientos.Rows.Count == 0 )
                SumaMov = 0;
            else if (Convert.ToDouble(dtmovimientos.Rows[0]["Imp"]) == 0)
            {
                dtmovimientos = Conexion.GDatos.TraerDataTableSql("SELECT (ISNULL(SUM(Haber),0) - ISNULL(SUM(Debe),0)) AS Imp from MovimientosBanco WHERE NCta ='" + Cta + "' AND FechaOperacion < '" + FechaIni.AddDays(-1) + "'");
              
                if (dtmovimientos.Rows.Count == 0)
                    SumaMov = 0;
                else
                    SumaMov = (dtmovimientos.Rows[0]["Imp"].ToString() == "") ? 0 : Convert.ToDouble(dtmovimientos.Rows[0]["Imp"]);
            }
            else
                SumaMov = (dtmovimientos.Rows[0]["Imp"].ToString() == "") ? 0 : Convert.ToDouble(dtmovimientos.Rows[0]["Imp"]);

            return SaldoIni + SumaMov;
        }

    }
}
