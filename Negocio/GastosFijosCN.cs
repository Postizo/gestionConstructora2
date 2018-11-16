using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;
using Datos;

namespace Negocio
{
   public  class GastosFijosCN
    {
        public static List<Gastos_Fijos> Listar(int id_empresa,int month )
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            return db.Gastos_Fijos.Where(p => p.Id_Empresa == id_empresa).Where(p=> p.Fecha.Month == month).OrderBy(p=> p.Fecha).ToList() ;
        }
        public static decimal ListarImporte(int id_empresa, DateTime fecha)
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            if (db.Gastos_Fijos.Where(p => p.Id_Empresa == id_empresa).Where(p => p.Fecha == fecha).ToList().Count <= 0)
            {
                return 0;
            } else
            {
                return db.Gastos_Fijos.Where(p => p.Id_Empresa == id_empresa).Where(p => p.Fecha == fecha).Sum(p => p.Importe);
            }
              
        }
        public static Gastos_Fijos Añadir(int id_empresa, DateTime fecha, decimal importe, string concepto)
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            Gastos_Fijos Gf = new Gastos_Fijos();
            Gf.Id_Empresa = id_empresa;
            Gf.Fecha = fecha;
            Gf.Importe = importe;
            Gf.Concepto = concepto;
            db.Gastos_Fijos.Add(Gf);

            db.Gastos_Fijos.Add(Gf);
            db.SaveChanges();
            return Gf;          
        }
        public static Gastos_Fijos Borrar(int orden)
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            Gastos_Fijos Gf = db.Gastos_Fijos.SingleOrDefault<Gastos_Fijos>(p => p.Orden == orden);
            db.Gastos_Fijos.Remove(Gf);
            db.SaveChanges();
            return Gf;
        }

    }
}
