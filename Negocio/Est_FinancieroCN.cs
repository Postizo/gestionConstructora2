using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;
namespace Negocio
{
     public  class Est_FinancieroCN
    {
        public static List<Est_Financiero> Listar()
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            return db.Est_Financiero.ToList();           
        }
        public static Est_Financiero Listar(int id)
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            return db.Est_Financiero.SingleOrDefault<Est_Financiero>(p => p.Id_Estudio == id);
        }
        public static void Borrar(int Id_Est)
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();          
            db.Est_Financiero.Remove(db.Est_Financiero.SingleOrDefault<Est_Financiero>(p => p.Id_Estudio == Id_Est));
            db.SaveChanges();
      
        }
        public static Est_Financiero Añadir(Est_Financiero Est)
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
                      db.Est_Financiero.Add(Est);
            db.SaveChanges();
            return Est;
        }
    }
}
