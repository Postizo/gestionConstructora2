using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using System.IO;

namespace Negocio
{
    public class Conexion
    {
        public static GDatos GDatos;
        public static bool IniciarSesion(string nombreServidor, string baseDatos, string usuario, string password)
        {
            GDatos = new SqlServer(nombreServidor, baseDatos, usuario, password);
            return GDatos.Autenticar();
        } //fin inicializa sesion

        public static void FinalizarSesion()
        {
            GDatos.CerrarConexion();
        }
        //fin FinalizaSesion

        //Conexion SIGRID

 
        //public string SERVIDOR_SIGRID = "192.0.0.181";
        //public  string BBDD_SIGRID = "Eunate";
        //public  string USER_SIGRID = "Fernando";
        //public  string PWD_SIGRID = "8080";
      
        //Conexion ContaWin

        //public  string SERVIDOR_CW = "192.0.100.16";
        //public  string BBDD_CW = "CWS_OBANOS";
        //public  string USER_CW = "Fernando";
        //public  string PWD_CW = "8080";

        //Cadena Conexion ContaWin

       // public  string CNNWIN = "";
       // public  string CNNWIN3 = "";

        public Conexion()
        {
            // CNNWIN = "Provider=SQLOLEDB.1;User ID=" + USER_CW + ";password=" + PWD_CW + ";Data Source=" + SERVIDOR_CW + ";Initial Catalog=" + BBDD_CW + "";
           // CNNWIN3 = "Data Source=" + SERVIDOR_CW + ";Initial Catalog=" + BBDD_CW + ";User ID=" + USER_CW + ";Password=" + PWD_CW + "";
        }
      
    }//end class util
}
