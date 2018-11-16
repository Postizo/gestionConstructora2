using Entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public  class BuscadorCn
    {
        public static DataTable ListarProductos(Empresas Empresa, string filtr)
        {
            Conexion.IniciarSesion(Empresa.Servidor_Sigrid, Empresa.BBDD_Sigrid, Empresa.Usuario_Sigrid, Empresa.Pwd_Sigrid);
            DataTable dt = new DataTable();
            dt = Conexion.GDatos.TraerDataTableSql("SELECT *   FROM con, pro WHERE  con.ide = pro.ide AND con.tip = 3 AND con.res LIKE '%"+ filtr + "%'");
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
        public static DataTable ListarPDocumentis(Empresas Empresa, int id_pro)
        {
            Conexion.IniciarSesion(Empresa.Servidor_Sigrid, Empresa.BBDD_Sigrid, Empresa.Usuario_Sigrid, Empresa.Pwd_Sigrid);
            DataTable dt = new DataTable();
            dt = Conexion.GDatos.TraerDataTableSql("SELECT obr.res,prv.raz, fecdoc, dc.can,dc.pre FROM dcfpro dc LEFT JOIN dcf dcf ON dcf.ide = dc.docide  LEFT JOIN dcfrec rec ON dc.docide =rec.docide  LEFT JOIN prv ON dcf.entide = prv.ide LEFT JOIN obr ON Obr.ide = dcf.obride WHERE dc.proide =" + id_pro + " ORDER BY fecdoc");
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
    }
}
