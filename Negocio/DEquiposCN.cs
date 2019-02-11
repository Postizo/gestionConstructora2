using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Entidad;
namespace Negocio
{
    public class DEquiposCN
    {
        #region "EQUIPOS"


        public static List<D_Equipos> ListarEquipos()
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            return db.D_Equipos.ToList();
        }
        public static D_Equipos ListarEquipos(string referencia)
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            D_Equipos Equipo = db.D_Equipos.SingleOrDefault<D_Equipos>(p => p.Referencia == referencia);
            return Equipo;
        }

        public static D_Equipos ModificarEquipos(string Referencia, string nombre, string alias, decimal pvp)
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            D_Equipos Equipo = db.D_Equipos.SingleOrDefault<D_Equipos>(p => p.Referencia == Referencia);
            if (Equipo != null)
            {
                Equipo.Nombre = nombre;
                Equipo.N_Alternativo = alias;
                Equipo.Pvp = pvp;
                db.SaveChanges();
                return Equipo;
            }
            else
            {
                return null;
            }
        }
        public static D_Equipos ModificarEquiposPVp(string Referencia, decimal pvp)
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            D_Equipos Equipo = db.D_Equipos.SingleOrDefault<D_Equipos>(p => p.Referencia == Referencia);
            if (Equipo != null)
            {             
                Equipo.Pvp = pvp;
                db.SaveChanges();
                return Equipo;
            }
            else
            {
                return null;
            }
        }
        public static D_Equipos ModificarEquiposProveedor(string Referencia, string provee, int id_provee)
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            D_Equipos Equipo = db.D_Equipos.SingleOrDefault<D_Equipos>(p => p.Referencia == Referencia);
            if (Equipo != null)
            {
                Equipo.id_proveedor = id_provee;
                Equipo.Proveedor = provee;           
                db.SaveChanges();
                return Equipo;
            }
            else
            {
                return null;
            }
        }
        public static D_Equipos ModificarEquiposGrupos(string Referencia, string grupo)
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            D_Equipos Equipo = db.D_Equipos.SingleOrDefault<D_Equipos>(p => p.Referencia == Referencia);
            if (Equipo != null)
            {
                Equipo.Grupo = grupo;               
                db.SaveChanges();
                return Equipo;
            }
            else
            {
                return null;
            }
        }
        public static D_Equipos ModificarTiempos(string Referencia, int T_programacion, int t_volcado, int t_instalacion, int t_puestamarcha )
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            D_Equipos Equipo = db.D_Equipos.SingleOrDefault<D_Equipos>(p => p.Referencia == Referencia);
            if (Equipo != null)
            {
                Equipo.T_programacion = T_programacion;
                Equipo.T_volcado  = t_volcado;
                Equipo.T_instalacion = t_instalacion;
                Equipo.T_puestamarcha =  t_puestamarcha;
                db.SaveChanges();
                return Equipo;
            }
            else
            {
                return null;
            }
        }

        public static D_Equipos AñadirEquipos(string Referencia)
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            D_Equipos Equipo = db.D_Equipos.SingleOrDefault<D_Equipos>(p => p.Referencia == Referencia);
            if (Equipo == null)
            {

                Equipo = new D_Equipos();
                Equipo.Referencia = Referencia;
                Equipo.Nombre = "";
                Equipo.N_Alternativo = "";
                Equipo.id_proveedor = 12;
                Equipo.Proveedor = "-TODOS-";
                Equipo.Pvp = 0;
                Equipo.T_programacion = 0;
                Equipo.T_volcado = 0;
                Equipo.T_instalacion = 0;
                Equipo.T_puestamarcha = 0;
                Equipo.Comentario = "";
                Equipo.Grupo = "";
                Equipo.Activo = true;
                db.D_Equipos.Add(Equipo);
                db.SaveChanges();
            }

            return Equipo;
        }
        public static void BorrarEquipos(string id)
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            D_Equipos Equipo = db.D_Equipos.SingleOrDefault<D_Equipos>(p => p.Referencia == id);
            db.D_Equipos.Remove(Equipo);
            db.SaveChanges();
        }

        #endregion

        #region "PROVEEDORES"

        public static D_provee ListarProveedores(int id_provee)
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            D_provee Provee = db.D_provee.SingleOrDefault<D_provee>(p => p.id_proveedor == id_provee);
            return Provee;
        }

        public static List<D_provee> ListarProveedores()
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            return db.D_provee.OrderBy(p => p.Proveedor).ToList();

        }
        public static D_provee ModificarProveedor(int id_provee, decimal descuento)
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            D_provee Provee = db.D_provee.SingleOrDefault<D_provee>(p => p.id_proveedor == id_provee);
            if (Provee != null)
            {
                Provee.descuento = descuento;
                db.SaveChanges();
                return Provee;
            }
            else
            {
                return null;
            }
        }
        public static D_provee AñadirProvee(string nombre, decimal descuento)
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            D_provee Provee = db.D_provee.SingleOrDefault<D_provee>(p => p.Proveedor.Trim() == nombre.Trim());
            if (Provee == null)
            {              
                Provee = new D_provee();
                Provee.Proveedor = nombre;
                Provee.descuento = descuento;
                db.D_provee.Add(Provee);
                db.SaveChanges();
                 return Provee;
            }
            else
            {
                return null;
            }
           

           
        }
        public static void BorrarProvee(int id_provee)
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            D_provee Provee = db.D_provee.SingleOrDefault<D_provee>(p => p.id_proveedor == id_provee);
            db.D_provee.Remove(Provee);
            db.SaveChanges();
        }

        #endregion

        #region "PRESUS"
        public static D_Presuca ListarPresu(int id)
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            D_Presuca Presu = db.D_Presuca.SingleOrDefault<D_Presuca>(p => p.id_presu == id);
            return Presu;
        }
        public static decimal ListarPresuSumaCoste(int id_Obra, int id_emp)
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            D_Presuca presus =  db.D_Presuca.SingleOrDefault<D_Presuca>(p => p.id_Obra == id_Obra && p.id_empresa == id_emp);
            if (presus == null) return 0;
            var Lineas = presus.D_Presuli;
            foreach (D_Presuli presu in Lineas)
            {
                presu.calculos();
            }
            decimal coste = Lineas.Sum(p => p.Costo * p.unidades);
            decimal mo = Lineas.Sum(p => p.Mo_Impor * p.unidades);
            decimal gg = Lineas.Sum(p => p.Gastos_Generales * p.unidades);
            decimal tot = coste + mo + gg;
            return tot;
        }
        public static decimal ListarPresuSumaVenta(int id_Obra, int id_emp)
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            D_Presuca presus = db.D_Presuca.SingleOrDefault<D_Presuca>(p => p.id_Obra == id_Obra && p.id_empresa == id_emp);
            if (presus == null) return 0;
            var Lineas = presus.D_Presuli;
            foreach (D_Presuli presu in Lineas)
            {
                presu.calculos();
            }          
            return Lineas.Sum(p => p.Tot_Unidad * p.unidades);
        }
        public static List<D_Presuca> ListarPresu()
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            List<D_Presuca> Presu = db.D_Presuca.ToList();
            return Presu;
        }
        public static D_Presuca AñadirPresucabecera(string nombre)
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            D_Presuca Presu = new D_Presuca();
            Presu.Nombre = nombre;
            Presu.CosteProgramador = 50;
            Presu.GG = 0.13M;
            Presu.Beneficio = 0.06M;
            Presu.MargenMat = 0.25M;
            Presu.m_construdios = 1;
            Presu.id_Obra = 0;
            Presu.id_empresa  = 12;

            db.D_Presuca.Add(Presu);
            db.SaveChanges();

            return Presu;
        }
        public static D_Presuca ModificarPresuGenerales(int id_presu, decimal costeprogramador, decimal gg, decimal benefic, decimal margenmatareial,int m_construdis,int id_obr)
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            D_Presuca Presu = db.D_Presuca.SingleOrDefault<D_Presuca>(p => p.id_presu == id_presu);
            if (Presu != null)
            {
                Presu.CosteProgramador = costeprogramador;
                Presu.GG = gg / 100;
                Presu.Beneficio = benefic / 100;
                Presu.MargenMat = margenmatareial / 100;
                Presu.m_construdios = m_construdis;
                Presu.id_empresa = 12;
                Presu.id_Obra = id_obr;
                db.SaveChanges();
                return Presu;
            }
            else
            {
                return null;
            }
        }
        public static D_Presuli ListarLinea(int id_presu,string referencia)
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            D_Presuli linea = db.D_Presuli.SingleOrDefault<D_Presuli>(p => p.id_presu == id_presu && p.@ref.Trim() == referencia.Trim());
            if (linea != null)
            {
                return linea; 
            }
            else
            {
                return null;
            }     
        }


        public static List<D_Presuli> ListarLineas(int id_presu)
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            List<D_Presuli> Listalineas = db.D_Presuli.Where(p => p.id_presu == id_presu).ToList();
            foreach (D_Presuli presu in Listalineas)
            {
                presu.calculos();
            }
            return Listalineas;
        }


        public static D_Presuli AñadirLineas(int id_presu, string Referencia, decimal pvp, decimal dte, decimal costo, int mobra,string grupo)
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            D_Presuli Linea = new D_Presuli();
            Linea.id_presu = id_presu;
            Linea.@ref = Referencia.Trim();
            Linea.unidades = 0;
            Linea.pvp = pvp;
            Linea.dte = dte;
            Linea.Costo = costo;
            Linea.Mobra = mobra;
            Linea.Grupo = grupo;

            db.D_Presuli.Add(Linea);
            db.SaveChanges();


            return Linea;
        }
        public static void BorrarPresu(int id_preesu)
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            D_Presuca Presu = db.D_Presuca.SingleOrDefault<D_Presuca>(p=>  p.id_presu == id_preesu);
            db.D_Presuca.Remove(Presu);
            db.SaveChanges();
        }

        public static void BorrarLineas(string referen, int id_preesu )
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            D_Presuli Linea = db.D_Presuli.SingleOrDefault<D_Presuli>(p => p.@ref.Trim() == referen.Trim() && p.id_presu == id_preesu);
            db.D_Presuli.Remove(Linea);
            db.SaveChanges();
        }
        public static D_Presuli ModificarUnidades(string Referencia, int unidades, int id_presuu)
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            D_Presuli Linea = db.D_Presuli.SingleOrDefault<D_Presuli>(p => p.@ref.Trim() == Referencia.Trim() && p.id_presu == id_presuu);
            if (Linea != null)
            {
                Linea.unidades = unidades;
                db.SaveChanges();
                return Linea;
            }
            else
            {
                return null;
            }
        }
        public static D_Presuli Modificargrup(string Referencia, int id_presuu,string grupo)
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            D_Presuli Linea = db.D_Presuli.SingleOrDefault<D_Presuli>(p => p.@ref.Trim() == Referencia.Trim() && p.id_presu == id_presuu);
            if (Linea != null)
            {
                Linea.Grupo = grupo;
                db.SaveChanges();
                return Linea;
            }
            else
            {
                return null;
            }
        }
        public static D_Presuli ModificarPrecio(string Referencia, decimal coste, int  id_presuu )
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            D_Presuli Linea = db.D_Presuli.SingleOrDefault<D_Presuli>(p => p.@ref.Trim() == Referencia.Trim() && p.id_presu == id_presuu);
            if (Linea != null)
            {
                Linea.Costo = coste;
                db.SaveChanges();
                return Linea;
            }
            else
            {
                return null;
            }
        }
        public static D_Presuli Recalculo(string Referencia, int id_presuu,decimal pvp, decimal dte,decimal costa, int mobra )
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            D_Presuli Linea = db.D_Presuli.SingleOrDefault<D_Presuli>(p => p.@ref.Trim() == Referencia.Trim() && p.id_presu == id_presuu);
            if (Linea != null)
            {
                Linea.Costo = costa;
                Linea.pvp = pvp;
                Linea.dte = dte;
                Linea.Mobra = mobra;                    
                db.SaveChanges();
                return Linea;
            }
            else
            {
                return null;
            }
        }



        #endregion
        #region "FAMILIAS"
        public static D_Familias ListarFamilias(int id_familia)
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            D_Familias Familia = db.D_Familias.SingleOrDefault<D_Familias>(p => p.id == id_familia);
          
            return Familia;
        }

        public static List<D_Familias> ListarFamilias()
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            List<D_Familias> Familias = db.D_Familias.OrderBy(p => p.Orden).ToList();
            foreach (D_Familias fam in Familias)
            {
                fam.Nombre = fam.Orden + "- " + fam.Nombre;
            }
            return Familias;

        }
        public static D_Familias ModificarFamilias(int id_familia,string Nombre, string Orden)
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            D_Familias Familia = db.D_Familias.SingleOrDefault<D_Familias>(p => p.id == id_familia);
            if (Familia != null)
            {
                Familia.Nombre = Nombre;
                Familia.Orden = Orden;
                db.SaveChanges();
                return Familia;
            }
            else
            {
                return null;
            }
        }
        public static D_Familias AñadirFamilia(string nombre, string Orden)
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            D_Familias Familia = db.D_Familias.SingleOrDefault<D_Familias>(p => p.Nombre.Trim() == nombre.Trim());
            if (Familia == null)
            {
                Familia = new D_Familias();
                Familia.Nombre = nombre;
                Familia.Orden = Orden;
                db.D_Familias.Add(Familia);
                db.SaveChanges();
                return Familia;
            }
            else
            {
                return null;
            }



        }
        public static void BorrarFamilia(int id_familia)
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            D_Familias Familia = db.D_Familias.SingleOrDefault<D_Familias>(p => p.id == id_familia);
            db.D_Familias.Remove(Familia);
            db.SaveChanges();
        }
        #endregion

    }
}
