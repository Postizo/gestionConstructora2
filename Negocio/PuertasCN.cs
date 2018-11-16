using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;
using Datos;

namespace Negocio
{
     public class PuertasCN
    {
        public static object Listar_usuarios()
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            return db.Puertas.Select(m => new { m.nombre , m.id_user }).Distinct().OrderBy(m=> m.nombre ).ToList(); 
        }
        public static List<Puertas> Listar_accesos(int id_user, DateTime fechau)
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            return db.Puertas.Where(p=> p.fecha == fechau).Where(p=> p.id_user == id_user).OrderBy(p=> p.hora).ToList();
        }
        public static object Listar_accesosColectivos(DateTime fechau)
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            return db.Puertas.Where(p => p.fecha == fechau).
                GroupBy(p=> p.id_user).
                Select(m=> new {id_user = m.Key, nombre = m.Min(a=> a.nombre), apellido = m.Min(a=> a.apellido), hora_ini = m.Min(a=> a.hora), hora_fin = m.Max(a=> a.hora)}).
                ToList();
        }
    }
}
