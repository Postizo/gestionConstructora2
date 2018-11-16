using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;
using Datos;

namespace Negocio
{
    public class SubGruposCN
    {
        public static List<Subgrupos> Listar()
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            return db.Subgrupos.ToList();
     
        }
        public static List<Subgrupos> Listar_solocontabilidad()
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            return db.Subgrupos.Where(p=> p.Tipo >= 0).ToList();

        }
        public static Subgrupos Listar(int id)
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            return (Subgrupos)db.Subgrupos.SingleOrDefault<Subgrupos>(p => p.Id_Subgrupo == id);
         
        }

        public static Subgrupos Listar(string Cod_sigrid)
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            return (Subgrupos)db.Subgrupos.SingleOrDefault<Subgrupos>(p => p.Cod == Cod_sigrid);

        }

        public static List<Subgrupos> ListarporGrupo(int id_grupo)
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            return db.Subgrupos.Where(p=>p.Id_Grupo == id_grupo).ToList();
      
        }

        public static Subgrupos Añadir(string nombre,int Id_grupo)
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            Subgrupos SubGru = new Subgrupos();
            SubGru.Nombre = nombre;
            SubGru.Id_Grupo  = Id_grupo;
            db.Subgrupos.Add(SubGru);
            if (!SubGru.IsValid) return SubGru; //Validacion
            db.SaveChanges();
            return SubGru;
        }
        public static Subgrupos Borrar(int id)
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            Subgrupos SubGru = db.Subgrupos.SingleOrDefault<Subgrupos>(p => p.Id_Subgrupo == id);
            db.Subgrupos.Remove(SubGru);
            if (!SubGru.IsValid) return SubGru; //Validacion     
            db.SaveChanges();
            return SubGru;
        }
        public static Subgrupos Modificar(int id_subgrupo,string Nombre, int id_grupo)
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            Subgrupos SubGru = (Subgrupos)db.Subgrupos.SingleOrDefault<Subgrupos>(p => p.Id_Subgrupo == id_subgrupo);
            if (SubGru != null)
            {
                SubGru.Nombre = Nombre;
                SubGru.Id_Grupo = id_grupo;
                if (!SubGru.IsValid) return SubGru; //Validacion
                db.SaveChanges();
                return SubGru;
            }
            else
            {
                return null;
            }
        }
        public static List<Subgrupos> Sort(string column, string sortOrder, List<Subgrupos> list)
        {
            switch (column)
            {
                case "Nombre":
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
                case "Grupos":
                    {
                        if (sortOrder == "Ascending")
                        {
                            return list.OrderBy(x => x.Grupos.Nombre).ToList();

                        }
                        else
                        {
                            return list.OrderByDescending(x => x.Grupos.Nombre).ToList();
                        }

                    }

            }
            return list;

        }

    }
}
