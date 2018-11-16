using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;
using Datos;

namespace Negocio
{
    public class Presu_ContaCN
    {
        public static Presu_Conta Añadir_Presu(Obras Obr, int id_grupo, decimal Presupuestado)
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            
            if (db.Presu_Conta.Where(p => p.id_obra == Obr.Id_Obra).Where(p => p.id_empresa == Obr.Id_Empresa).Where(p => p.id_Grupo == id_grupo).ToList().Count > 0){
                Presu_Conta Presu = new Presu_Conta();
                Presu = db.Presu_Conta.Where(p => p.id_obra == Obr.Id_Obra).Where(p => p.id_empresa == Obr.Id_Empresa).Where(p => p.id_Grupo == id_grupo).ToList()[0];
                Presu.Presupuestado = Presupuestado;
                db.SaveChanges();
                return Presu;
            }
            else {
                Presu_Conta Presu = new Presu_Conta();
                Presu.id_obra = Obr.Id_Obra;
                Presu.id_empresa = Obr.Id_Empresa;
                Presu.id_Grupo = id_grupo;
                Presu.Presupuestado = Presupuestado;
                db.Presu_Conta.Add(Presu);
                db.SaveChanges();
               return Presu;
            }         
        }               
        public static void Borrar_rel(Obras Obr, int id_grupo)
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            if (db.Presu_Conta.Where(p => p.id_obra == Obr.Id_Obra).Where(p => p.id_empresa == Obr.Id_Empresa).Where(p => p.id_Grupo == id_grupo).ToList().Count > 0)
            {
                Presu_Conta Presu = db.Presu_Conta.Where(p => p.id_obra == Obr.Id_Obra).Where(p => p.id_empresa == Obr.Id_Empresa).Where(p => p.id_Grupo == id_grupo).ToList()[0];
                db.Presu_Conta.Remove(Presu);
                db.SaveChanges();
            }
        }

    }
}
