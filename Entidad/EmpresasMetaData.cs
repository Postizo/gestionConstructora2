using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class EmpresasMetaData
    {
        [StringLength(150, MinimumLength = 3, ErrorMessage = "El nombre debe contener al menos tres caracteres y no superar 250")]
        public string Nombre { get; set; }

    }

    [MetadataType(typeof(EmpresasMetaData))]
    public partial class Empresas
    {
        public string CNNWIN;
        public string CNNWIN3;
        public Empresas()
        {
            this.Cuentas = new HashSet<Cuentas>();
            this.Obras = new HashSet<Obras>();
            Conexion();
        }
        public void Conexion()
        {
            
            CNNWIN = "Provider=SQLOLEDB.1;User ID=" + this.Usuario_ContaWin  + ";password=" + this.Pwd_ContaWin   + ";Data Source=" + this.Servidor_ContaWin + ";Initial Catalog=" + this.BBDD_ContaWin  + "";
            CNNWIN3 = "Data Source=" + this.Servidor_ContaWin + ";Initial Catalog=" + this.BBDD_ContaWin  + ";User ID=" + this.Usuario_ContaWin  + ";Password=" + this.Pwd_ContaWin  + "";
        }
    }

}
