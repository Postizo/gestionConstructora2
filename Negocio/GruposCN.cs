using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;
using Datos;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Validation;
using System.Data.Entity.Infrastructure;

namespace Negocio
{
    public class GruposCN 
    {
       
        public static List<Grupos> Listar_solocontructora()
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            return db.Grupos.Where(p => p.Id_Tipo == -1 || p.Id_Tipo == -99).ToList();     
        }
        public static List<Grupos> Listar_soloelectrica()
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            return db.Grupos.Where(p => p.Id_Tipo == -2 && p.Id_Tipo == -99).ToList();
        }
        public static List<Grupos> Listar_solocontabilidad()
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            return db.Grupos.Where(p=> p.Id_Tipo >= 0).ToList();
        }
        public static List<Grupos> Listar_solocontabilidastesoreria()
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            return db.Grupos.Where(p => p.Id_Tipo >= 100).ToList();
        }

        public static Grupos Listar(int id)
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            return db.Grupos.SingleOrDefault<Grupos>(p => p.Id_Grupo == id);       
        }
        public static Grupos Listar_con_Subgrupos(int id)
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            return db.Grupos.SingleOrDefault<Grupos>(p => p.Id_Grupo == id);
        }
        public static Grupos Listar_por_Cuenta(int cuenta)
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            if (db.Grupos.Where(p => p.Cuenta_prefijada == cuenta).Count() > 0)
            {
                return db.Grupos.Where(p => p.Cuenta_prefijada == cuenta).ToList()[0];
            }
            else
            {
                return null;
            }

        }
     
        public static Grupos Añadir(string nombre,int orden,int id_tipo,string tipo)
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            Grupos Gru = new Grupos();
            Gru.Nombre  = nombre ;
            Gru.Orden  = orden;
            Gru.Id_Tipo = id_tipo;  
            Gru.Tipo = tipo;
        
            if (!Gru.IsValid) return Gru; //Validacion
            db.Grupos.Add(Gru);
            db.SaveChanges();
            return Gru;
        }

        public static Grupos_Rel Listar_rel(int id_obra, string cod_sigrid)
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            if (db.Grupos_Rel.Where(p => p.Id_Obra == id_obra).Where(p => p.Cod_Sigrid == cod_sigrid).ToArray().Count() > 0)
            {
                return db.Grupos_Rel.Where(p => p.Id_Obra == id_obra).Where(p => p.Cod_Sigrid == cod_sigrid).ToArray()[0];
            }
            else
            {
                return null;
            }  
        }
     

        public static Grupos_Rel Añadir_rel(Obras Obr, int id_grupo, string cod_sigrid)
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            Grupos_Rel Grup_rel = new Grupos_Rel();
            Grup_rel.Id_Obra = Obr.Id_Obra ;
            Grup_rel.Id_Empresa = Obr.Id_Empresa;
            Grup_rel.Id_Grupo  = id_grupo;
            Grup_rel.Cod_Sigrid = cod_sigrid;
            db.Grupos_Rel.Add(Grup_rel);
            db.SaveChanges();
            return Grup_rel;
        }

        public static Grupos_Rel Añadir_rel(Obras Obr, int id_grupo, int id_subgrupo, string cod_sigrid)
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            Grupos_Rel Grup_rel = new Grupos_Rel();
            Grup_rel.Id_Obra = Obr.Id_Obra;
            Grup_rel.Id_Empresa =Obr.Id_Empresa ;
            Grup_rel.Id_Grupo = id_grupo;
            Grup_rel.Id_Subgrupo = id_subgrupo;
            Grup_rel.Cod_Sigrid = cod_sigrid;

            db.Grupos_Rel.Add(Grup_rel);
            db.SaveChanges();
            return Grup_rel;
        }
        public static void Borrar_rel(Obras obr, int id_grupo)
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            List<Grupos_Rel> Grup_rel = db.Grupos_Rel.Where(p=> p.Id_Obra == obr.Id_Obra).Where(p => p.Id_Empresa == obr.Id_Empresa).Where(p=> p.Id_Grupo == id_grupo).ToList();
            foreach (Grupos_Rel rel in Grup_rel)
            {
                db.Grupos_Rel.Remove(rel);
            }  
            db.SaveChanges();     
        }
        public static void Borrar_rel_subgrup(Obras obr, int id_subgrupo)
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            List<Grupos_Rel> Grup_rel = db.Grupos_Rel.Where(p => p.Id_Obra == obr.Id_Obra).Where(p=> p.Id_Empresa == obr.Id_Empresa).Where(p => p.Id_Subgrupo == id_subgrupo).ToList();
            foreach (Grupos_Rel rel in Grup_rel)
            {
                db.Grupos_Rel.Remove(rel);
            }
            db.SaveChanges();
        }
        public static Grupos  Borrar(int id)
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            Grupos Gru = db.Grupos.SingleOrDefault<Grupos>(p => p.Id_Grupo == id);
            db.Grupos.Remove(Gru);
            if (!Gru.IsValid) return Gru; //Validacion
            db.SaveChanges();
            return Gru;
        }
                    
          
        public static Grupos Modificar(int id_grupo, string nombre, int orden, int id_tipo, string tipo)
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            Grupos Gru = db.Grupos.SingleOrDefault<Grupos>(p => p.Id_Grupo == id_grupo);
            if (Gru != null)
            {
                Gru.Nombre = nombre;
                Gru.Orden = orden;
                Gru.Id_Tipo = id_tipo;
                Gru.Tipo = tipo;
                if (!Gru.IsValid) return Gru; //Validacion
                db.SaveChanges();
                return Gru;
            }
            else
            {
                return null;
            }
        }
      
        public static List<Grupos> Sort(string column, string sortOrder, List<Grupos> list)
        {
            switch (column)
            {
                case "Grupo":
                    {
                        if (sortOrder == "Ascending")
                        {
                            return list.OrderBy(x => x.Nombre).ToList();

                        }
                        else
                        {
                            return list.OrderByDescending(x => x.Nombre).ToList();
                        }

                    }
                case "tip":
                    {
                        if (sortOrder == "Ascending")
                        {
                            return list.OrderBy(x => x.Tipo).ToList();

                        }
                        else
                        {
                            return list.OrderByDescending(x => x.Tipo).ToList();
                        }

                    }
                
            }
            return list;

        }
    }
}
