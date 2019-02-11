using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;
using Datos;
using System.Data.Entity;

namespace Negocio
{
 public   class Est_TesoreriaCN
    {
        public static List<Est_Tesoreria> Listar()
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            return db.Est_Tesoreria.ToList();
        }
        public static Est_Tesoreria Listar(int id)
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            return db.Est_Tesoreria.SingleOrDefault<Est_Tesoreria>(p => p.Id_tesoreria == id);
        }
        public static void Borrar(int Id_Est)
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            db.Est_Tesoreria.Remove(db.Est_Tesoreria.SingleOrDefault<Est_Tesoreria>(p => p.Id_tesoreria == Id_Est));
            db.SaveChanges();
        }
        public static void Editar(Est_Tesoreria Est)
        {           
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            Est_Tesoreria Estdb  = db.Est_Tesoreria.SingleOrDefault<Est_Tesoreria>(p => p.Id_tesoreria == Est.Id_tesoreria);
            Estdb.Nombre = Est.Nombre;
            Estdb.principal = Est.principal;
            Estdb.pte = Est.pte;
            Estdb.Carencia = Est.Carencia;
            Estdb.tipointeres = Est.tipointeres;
            Estdb.ptereforma = Est.ptereforma;
            Estdb.Realizado = Est.Realizado;
            Estdb.ffin = Est.ffin;
            Estdb.finicioprevisto = Est.finicioprevisto;
            Estdb.Comentario = Est.Comentario;
            Estdb.id_empresa = Est.id_empresa;
            Estdb.id_obra = Est.id_obra;
            Estdb.Comentario = Est.Comentario;
            Estdb.Plazo = Est.Plazo;
            Estdb.Venta = Est.Venta;
            Estdb.fventa = Est.fventa;
            Estdb.CompraTotal = Est.CompraTotal;
            Estdb.Fcompra = Est.Fcompra;

            db.SaveChanges();
            
        }
        public static void EditarPteandRealizado(int id_tesoreria, decimal pte , decimal realizado)
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            Est_Tesoreria Estdb = db.Est_Tesoreria.SingleOrDefault<Est_Tesoreria>(p => p.Id_tesoreria == id_tesoreria);          
            Estdb.ptereforma = pte;            
            Estdb.Realizado = realizado;           
            db.SaveChanges();

        }
        public static Est_Tesoreria Añadir(Est_Tesoreria Est)
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            db.Est_Tesoreria.Add(Est);
            db.SaveChanges();
            return Est;
        }


        public static void BorrarMeses(int Id_Est)
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            db.Database.ExecuteSqlCommand("DELETE FROM Est_TesoreriaMes WHERE id_tesoreria = '" + Id_Est.ToString() + "'");
        }
        public static Est_TesoreriaMes AñadirMes(Est_TesoreriaMes Mes)
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            db.Est_TesoreriaMes.Add(Mes);
            db.SaveChanges();
            return Mes;
        }


    }
}
