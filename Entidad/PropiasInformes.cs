using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class ResumenTipos
    {
        public int id_grupo { get; set; }
        public string Grup_Sigrid { get; set; }

        public string Nombre { get; set; }
        public decimal Importe { get; set; }
        public decimal Importe_Compara { get; set; }
        public decimal Desv { get; set; }
        public decimal Desv_Por { get; set; }
        public ResumenTipos() { }
    }
   
    public class LineasSeguimiento
    {
        public int id_grupo { get; set; }
        public string Grup_Sigrid { get; set; }

        public string Nombre { get; set; }
        public decimal Importe_presu { get; set; }
        public decimal Importe_Gastado { get; set; }
        public decimal Importe_Pagado { get; set; }
        public decimal Desv { get; set; }
        public decimal Desv_Por { get; set; }
        public LineasSeguimiento() { }
    }
    public class FacturasDetalles
    {
        public DateTime Fecha { get; set; }
        public string Factura { get; set; }

        public string Proveedor { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public double Cantidad { get; set; }
        public decimal Importe { get; set; }
        public string Cap_Sigrid { get; set; }
        public FacturasDetalles() { }
    }

    public class LineasBalance
    {
        public int Id { get; set; }
        public string Cuenta { get; set; }
        public string Nombre { get; set; }
        public double Total_compa { get; set; }
        public double Total { get; set; }
    }

    public class LineasEstFinanciera
    {
        public int Id_Mes { get; set; }
        public string MesAño { get; set; }
        public string NombreObra { get; set; }
        public decimal Saldo { get; set; }
        public decimal GastoFijo { get; set; }
        public decimal GastoHipoetas { get; set; }
        public decimal GastoObra { get; set; }
        public decimal TotGasto { get; set; }
        public decimal Venta { get; set; }
        public decimal pagoxcompra { get; set; }
        public decimal HiotecaPendiente { get; set; }

    }

}
