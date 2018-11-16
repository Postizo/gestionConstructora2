using Entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ImportarTarifasCN
    {
        public static DataTable ParseToExcel(string fileName)
        {
            string connectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 12.0 Xml;HDR=YES;';", fileName); ;


            DataSet data = new DataSet();

            foreach (var sheetName in GetExcelSheetNames(connectionString))
            {
                using (OleDbConnection con = new OleDbConnection(connectionString))
                {
                    var dataTable = new DataTable();
                    string query = string.Format("SELECT * FROM [{0}]", sheetName);
                    con.Open();
                    OleDbDataAdapter adapter = new OleDbDataAdapter(query, con);
                    adapter.Fill(dataTable);
                    data.Tables.Add(dataTable);
                }
            }
            return data.Tables[0];
        }
        static string[] GetExcelSheetNames(string connectionString)
        {
            OleDbConnection con = null;
            DataTable dt = null;
            con = new OleDbConnection(connectionString);
            con.Open();
            dt = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

            if (dt == null)
            {
                return null;
            }

            String[] excelSheetNames = new String[dt.Rows.Count];
            int i = 0;

            foreach (DataRow row in dt.Rows)
            {
                excelSheetNames[i] = row["TABLE_NAME"].ToString();
                i++;
            }

            return excelSheetNames;
        }
        public static DataTable Busca_Fabricantes(Empresas Empresa)
        {
            Conexion.IniciarSesion(Empresa.Servidor_Sigrid, Empresa.BBDD_Sigrid, Empresa.Usuario_Sigrid, Empresa.Pwd_Sigrid);
            DataTable dt = Conexion.GDatos.TraerDataTableSql("SELECT ide,res FROM con WHERE con.tip = 6");
            Conexion.FinalizarSesion();
            if (dt.Rows.Count > 0)
                return dt;
            else
                return default(DataTable);

        }
        public static DataTable Buscar_productor_PorFabricante(Empresas Empresa, int Fabide,string busca)
        {
            Conexion.IniciarSesion(Empresa.Servidor_Sigrid, Empresa.BBDD_Sigrid, Empresa.Usuario_Sigrid, Empresa.Pwd_Sigrid);
            DataTable dt = new DataTable();
            if (busca == "")
            { dt = Conexion.GDatos.TraerDataTableSql("SELECT cod, res, pco FROM  con, pro WHERE  con.ide = pro.ide AND con.tip = 3 and fabide = " + Fabide + ""); }
            else
            { dt = Conexion.GDatos.TraerDataTableSql("SELECT cod,res,pco FROM  con,pro WHERE  con.ide=pro.ide AND con.tip = 3 and fabide =" + Fabide + " AND (res like'%" + busca + "%' OR cod like'%" + busca + "%')"); }


         
            Conexion.FinalizarSesion();
            if (dt.Rows.Count > 0)
                return dt;
            else
                return default(DataTable);
        }
        public static DataTable Buscar_productosTarifa(Empresas Empresa, int Fabide,string busca)
        {
            Conexion.IniciarSesion(Empresa.Servidor_ContaWin, "GestionConstructora", Empresa.Usuario_ContaWin, Empresa.Pwd_ContaWin);
            DataTable dt = new DataTable();
            if (busca == "")
            { dt = Conexion.GDatos.TraerDataTableSql("SELECT * FROM TarifasProvee WHERE Id_Proveedor = " + Fabide + ""); }
            else
            {  dt = Conexion.GDatos.TraerDataTableSql("SELECT * FROM TarifasProvee WHERE Id_Proveedor = " + Fabide + " AND (Nombre like'%" + busca + "%' OR Codigo like'%" + busca + "%')"); }
            
            Conexion.FinalizarSesion();
            return dt;
           
        }

        public static int ObtieneIDE(Empresas Empresa)
        {
            Conexion.IniciarSesion(Empresa.Servidor_Sigrid, Empresa.BBDD_Sigrid, Empresa.Usuario_Sigrid, Empresa.Pwd_Sigrid);
            DataTable dt = Conexion.GDatos.TraerDataTableSql("SELECT TOP 1 ide + 1 FROM Con ORDER By ide desc");
            Conexion.FinalizarSesion();                       
            if (dt.Rows.Count > 0)
                return Convert.ToInt32(dt.Rows[0][0]);
            else
                return default(Int32);
        }
        public static int CompruebaSiexiste(Empresas Empresa, string fabref)
        {

            Conexion.IniciarSesion(Empresa.Servidor_Sigrid, Empresa.BBDD_Sigrid, Empresa.Usuario_Sigrid, Empresa.Pwd_Sigrid);
            DataTable dt = Conexion.GDatos.TraerDataTableSql("SELECT * FROM con, pro where pro.ide = con.ide and con.cod = '" + fabref + "'");
            Conexion.FinalizarSesion();

            if (dt.Rows.Count > 0)
                return Convert.ToInt32(dt.Rows[0][0]);
            else
                return 0;
        }
        
        public static void Insert_Mod_Producto(Empresas Empresa,Producto Produc)
        {
            int Ide;
            int Existe;
            Existe = ImportarTarifasCN.CompruebaSiexiste(Empresa, Produc.pro_fabref);
            Conexion.IniciarSesion(Empresa.Servidor_Sigrid, Empresa.BBDD_Sigrid, Empresa.Usuario_Sigrid, Empresa.Pwd_Sigrid);

            if ((Existe == 0))
            {
                // 'EL ARTICULO NO EXISTE
                Ide = ImportarTarifasCN.ObtieneIDE(Empresa);
                // Insertamos la linea en la tabla con 
                Conexion.GDatos.EjecutarSql("INSERT INTO con (ide,emp,tip,cod,res,fec) VALUES(" + Ide + "," + Produc.c_emp + "," + Produc.c_tip + ",'" + Produc.c_cod + "','" + Produc.c_res + "'," + Produc.c_fec + ")");
                // Insertamos la linea en la tabla con 
                Conexion.GDatos.EjecutarSql("INSERT INTO Pro (ide,cla,fabide,fabref,prvide,natide,tex,pco) VALUES  (" + Ide + "," + Produc.pro_cla + "," + Produc.pro_fabide + ",'" + Produc.pro_fabref + "'," + Produc.pro_prvide + "," + Produc.pro_natide + ",'" + Produc.pro_tex + "'," + Produc.pro_pco.ToString().Replace(",", ".") + ")");       
            }
            else
            {
                // 'EL ARTICULO NO EXISTE
                Ide = Existe;
                // Modificamos el Precio del Articulo
                Conexion.GDatos.EjecutarSql("UPDATE Pro  SET  pco =" + Produc.pro_pco.ToString().Replace(",", ".") + " WHERE ide =" + Ide + "");              
            }
            Conexion.FinalizarSesion();
        }
        public class Producto
        {
            public int c_emp = 0;
            public int c_tip;
            public string c_cod;
            public string c_res;
            public int c_fec;
            public int pro_cla;
            public int pro_fabide;
            public string pro_fabref;
            public int pro_prvide;
            public int pro_natide;
            public string pro_tex;
            public double pro_pco;
            public  Producto()
            {
                c_emp = 0;
                c_tip = 0;
                c_cod = string.Empty;
                c_res = string.Empty;
                c_fec = 0;
                pro_cla = 0;
                pro_fabide = 0;
                pro_fabref = string.Empty;
                pro_prvide = 0;
                pro_natide = 0;
                pro_tex = string.Empty;
                pro_pco = 0.0;
            }
        }

        public class Fabricante
        {
            public int c_emp = 0;
            public int c_tip;
            public string c_cod;
            public string c_res;
            public int c_fec;


            public  Fabricante()
            {
                c_emp = 0;
                c_tip = 0;
                c_cod = string.Empty;
                c_res = string.Empty;
                c_fec = 0;
            }
        }


    }

}
