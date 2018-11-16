using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;
using Datos;

namespace Negocio.Presupuestos
{
    public class PresupuestosCN
    {
        public static List<Presu_Presu_Ca> Listar()
        {       
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            return db.Presu_Presu_Ca.ToList();
        }        

        public static Presu_Presu_Ca Listar(int id_presu, int id_version)
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            Presu_Presu_Ca Presupuesto = db.Presu_Presu_Ca.SingleOrDefault<Presu_Presu_Ca>(p => p.Id_Presu == id_presu && p.Id_Version == id_version);
            return Presupuesto;
        }
        public static Presu_Presu_Ca AñadirPresu_ca(Presu_Presu_Ca Pres_p )
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            Presu_Presu_Ca Presupuesto = db.Presu_Presu_Ca.SingleOrDefault<Presu_Presu_Ca>(p => p.Id_Presu == Pres_p.Id_Presu && p.Id_Version == Pres_p.Id_Version);
            Presupuesto.CteHora = Pres_p.CteHora;
            Presupuesto.nPersonas = Pres_p.nPersonas;
            Presupuesto.horas_dias = Pres_p.horas_dias;
            Presupuesto.ndias = Pres_p.ndias;
            Presupuesto.T_Manoobra = Pres_p.T_Manoobra;
            Presupuesto.M_Materias = Pres_p.M_Materias;
            Presupuesto.G_Generales = Pres_p.G_Generales;
            Presupuesto.Beneficio = Pres_p.Beneficio;
            Presupuesto.U_Casas = Pres_p.U_Casas;
            db.SaveChanges();
            return Presupuesto;
        }
        public static Presu_Presu_Ca AñadirPresu_ca(string nombre)
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            Presu_Presu_Ca Presu_ca = new Presu_Presu_Ca();
            Presu_ca.Nombre = nombre;
            Presu_ca.CteHora = 1;
            Presu_ca.nPersonas = 1;
            Presu_ca.horas_dias =1;
            Presu_ca.ndias = 1;
            Presu_ca.T_Manoobra = 1;
            Presu_ca.M_Materias = 45;
            Presu_ca.G_Generales =  13;
            Presu_ca.Beneficio =6;
            db.Presu_Presu_Ca.Add(Presu_ca);
            db.SaveChanges();
            return Presu_ca;
        }


        public static List<Presu_Estancias> Listar_Estancias()
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            return db.Presu_Estancias.ToList();           
        }
        public static Presu_Estancias Listar_Estancia(int id_estancia)
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            return db.Presu_Estancias.Where(p=> p.Id_Estancia == id_estancia).ToList()[0];
        }
        public static List<int> Listar_Versiones(int id)
        {
            List<int> l = new List<int>();
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            List<Presu_Presu_Ca> Presupuestos = db.Presu_Presu_Ca.Where(p => p.Id_Presu == id).ToList();
            foreach (Presu_Presu_Ca pr in Presupuestos)
            {
                l.Add(pr.Id_Version);
            }
            return l;
        }
        public static List<Presu_Elementos> Listar_Elementos()
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            return db.Presu_Elementos.ToList();
        }
        public static Presu_Elementos ListarElementos(int Id_elementos)
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            return db.Presu_Elementos.Where(p => p.Id_Elemento == Id_elementos).ToList()[0];

        }
        public static List<Presu_Elem_Estan > Listar_ElementosEstancia(int id_estancia )
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            return db.Presu_Elem_Estan.Where(p=> p.Id_estancia == id_estancia).ToList() ;
        }

        public static Presu_Presu_li AñadirLineas(int id_presu, int id_version, int id_estancia)
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            Presu_Presu_li Linea = new Presu_Presu_li();
            Linea.Id_Presu  = id_presu;
            Linea.Id_version  = id_version ;
            Linea.Id_Estancia = id_estancia;          
            db.Presu_Presu_li.Add(Linea);
            db.SaveChanges();
            return Linea;
        }
        public static Presu_Presu_li BorrarLinea(int id_presu, int id_version, int id_estancia)
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            Presu_Presu_li Linea = db.Presu_Presu_li.Where(p => p.Id_Presu == id_presu && p.Id_version == id_version  && p.Id_Estancia == id_estancia).ToList()[0];
            db.Presu_Presu_li.Remove(Linea);
            db.SaveChanges();
            return Linea;
        }


        public static Presu_Elem_Estan AñadiroUpdateElemetoEtsancia(int id_estancia, int id_elementos, int unidades)
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            Presu_Elem_Estan Linea = new Presu_Elem_Estan();
            Presu_Elem_Estan existe = (db.Presu_Elem_Estan.Where(p => p.Id_estancia == id_estancia && p.Id_elementos == id_elementos).Count() > 0) ? db.Presu_Elem_Estan.Where(p => p.Id_estancia == id_estancia && p.Id_elementos == id_elementos).ToList()[0] : null;
            if (existe == null)
            {
                Linea.Id_estancia = id_estancia;
                Linea.Id_elementos = id_elementos;
                Linea.Unidades = unidades;
                db.Presu_Elem_Estan.Add(Linea);
            }
            else
            {
                existe.Unidades = unidades;
            }
         
            db.SaveChanges();
            return Linea;
        }
        public static Presu_Elementos AñadirElementos(string nombre)
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            Presu_Elementos Elem = new Presu_Elementos();
            Elem.Nombre = nombre;
            db.Presu_Elementos.Add(Elem);
            db.SaveChanges();
            return Elem;
        }
        public static Presu_Elementos ActuElementos(int id_elemet, string nombre)
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            Presu_Elementos Elem =  db.Presu_Elementos.Where(p => p.Id_Elemento == id_elemet).ToList()[0];
            Elem.Nombre = nombre;          
            db.SaveChanges();
            return Elem;
        }
        public static Presu_Calidad AñadirCalidad(int id_elemet,int id_calidad, string calidad,decimal precio)
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            Presu_Calidad Elem = new Presu_Calidad();
            Elem.Id_elemento = id_elemet;
            Elem.Tipo_Calidad = id_calidad;
            Elem.Calidad = calidad;
            Elem.Precio = precio;
            db.Presu_Calidad.Add(Elem);
            db.SaveChanges();
            return Elem;
        }
        public static Presu_Estancias AñadirEstancia(string nombre)
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            Presu_Estancias Estancia = new Presu_Estancias();
            Estancia.Nombre = nombre;           
            db.Presu_Estancias.Add(Estancia);
            db.SaveChanges();
            return Estancia;
        }
      

        public static Presu_Calidad ActuCalidad(int id_linea, decimal precio)
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            Presu_Calidad Tarifa = db.Presu_Calidad.Where(p => p.Id_linea == id_linea).ToList()[0];
            Tarifa.Precio = precio;
            db.SaveChanges();
            return Tarifa;
        }
       
        public static void BorrarElemento(int id_element)
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            Presu_Elementos Element = db.Presu_Elementos.SingleOrDefault<Presu_Elementos>(p => p.Id_Elemento == id_element);
            db.Presu_Elementos.Remove(Element);
        }


    }
}
