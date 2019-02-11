using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;
using Datos;
using System.Data.Entity;
using Negocio.Gestion;
using System.Data;

namespace Negocio
{
  public class ObraCN
    {
        public static List<Obras> Listar(int id_empresa)
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            return db.Obras.Where(p=> p.Id_Empresa == id_empresa).ToList();
        }
        public static Obras Listar(int id, int id_empresa)
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            return db.Obras.SingleOrDefault<Obras>(p => p.Id_Obra == id && p.Id_Empresa == id_empresa);       
        }
        public static Obras Listar(string nombre)
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            return db.Obras.SingleOrDefault<Obras>(p => p.Nombre == nombre);
        }
        public static List<Obras> ListarObras_Metros()
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            return db.Obras.Where(p=> p.Id_Sigrid != 0).ToList();
        }

        //public static List<Obras> Listar(List <int> ids)
        //{
        //    GestionConstructoraEntities db = new GestionConstructoraEntities();
        //    return db.Obras.Where(t => ids.Contains(t.Id_Obra)).ToList() ;
        //}

        public static Obras Añadir(int Id_Obra,int Id_empresa,  string nombre,string tipo,double m_construido,int id_sigrid )
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            Obras Obr = new Obras();
            Obr.Id_Empresa  = Id_empresa;
            Obr.Id_Obra = Id_Obra;
            Obr.Id_Sigrid = id_sigrid;
            Obr.Importado_presu = true;
            Obr.Nombre = nombre;
            Obr.Tipo_Obra = tipo;
            Obr.Construido = m_construido;
            Obr.M_Viviendas = m_construido;
            Obr.Ajuste = 0;
            Obr.Comentario_Ajuste = "";
            Obr.M_Construidos = 1;
            Obr.M_Escriturados = 1;
            Obr.M_Utiles = 1;
            Obr.M_ZonasComunes =1;
            Obr.M_Rasante = 1;
            Obr.M_Viviendas = 1;
            db.Obras.Add(Obr);
            if (!Obr.IsValid) return Obr; //Validacion
            db.SaveChanges();
            return Obr;
        }

        public static Obras Borrar(int id)
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            Obras Obr = db.Obras.SingleOrDefault<Obras>(p => p.Id_Obra  == id);
            if (!Obr.IsValid) return Obr; //Validacion
            db.Obras.Remove(Obr);
            db.SaveChanges();
            return Obr;
        }
        public static Obras Modificar(int id_obra,int id_empresa, string Nombre, string tipo, double m_construido,int id_sigrid)
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            Obras Obr = db.Empresas.Where(p => p.Id_Empresa == id_empresa).ToList()[0].Obras.Where(p => p.Id_Obra == id_obra).ToList()[0];
            if (Obr != null)
            {
                Obr.Nombre = Nombre;
                Obr.Id_Empresa = id_empresa;
                Obr.Id_Sigrid = id_sigrid;
                Obr.Tipo_Obra = tipo;
                Obr.Construido = m_construido;
                if (!Obr.IsValid) return Obr; //Validacion
                db.SaveChanges();
                return Obr;
            }
            else
            {
                return null;
            }
        }
        public static void Modificar(int id_obra,int id_empresa, bool importado)
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            Obras Obr = db.Empresas.Where(p=> p.Id_Empresa == id_empresa).ToList()[0].Obras.Where(p => p.Id_Obra == id_obra).ToList()[0];
            if (Obr != null)
            {
                Obr.Importado_presu = importado;
                db.SaveChanges();
            }
        }

        public static void ModificarEstado(int id_obra, int id_empresa, bool finalizada)
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            Obras Obr = db.Empresas.Where(p => p.Id_Empresa == id_empresa).ToList()[0].Obras.Where(p => p.Id_Obra == id_obra).ToList()[0];
            if (Obr != null)
            {
                Obr.Finalizada  = finalizada;
                db.SaveChanges();
            }
        }
        public static void Modificarmetros(int id_obra, int id_empresa, int m_escriturados, int m_construidos, int m_utiles)
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            Obras Obr = db.Empresas.Where(p => p.Id_Empresa == id_empresa).ToList()[0].Obras.Where(p => p.Id_Obra == id_obra).ToList()[0];
            if (Obr != null)
            {
                Obr.M_Escriturados  = m_escriturados ;
                Obr.M_Construidos = m_construidos;
                Obr.M_Utiles = m_utiles;
                db.SaveChanges();
            }
        }

        public static void Añadir_lineas(Obras Obr, List<Obras_Lineas> Line)
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();  
            foreach (Obras_Lineas l in Line)
            {
                //if (Obr.Obras_Lineas.Where(p => p.Capitulo == l.Capitulo).Count() > 0) continue;
                l.Grupos = null;
                l.Subgrupos = null;
                db.Obras_Lineas.Add(l);
                db.SaveChanges();
            }
        }
        public static void Añadir_lineas(Obras_Lineas Line)
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            db.Obras_Lineas.Add(Line);
            db.SaveChanges();
           
        }
        public static void Borrar_Lineas(int id_obra, string cap)
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            Obras_Lineas Line = db.Obras_Lineas.SingleOrDefault<Obras_Lineas>(p => p.Id_Obra == id_obra && p.Capitulo == cap);
            if (Line == null) return; 
            db.Obras_Lineas.Remove(Line);
            db.SaveChanges();
        }
        public static void Borrar_Lineas_Obra(Obras Obr)
        {
            using (GestionConstructoraEntities db = new GestionConstructoraEntities())
            {
                db.Database.ExecuteSqlCommand("DELETE FROM Obras_Lineas WHERE id_Obra = " + Obr.Id_Obra  + " AND id_empresa = "+ Obr.Id_Empresa + " AND id_fase = 0");
            }                 
        }
        public static void Borrar_Lineas_ObraTodas(Obras Obr)
        {
            using (GestionConstructoraEntities db = new GestionConstructoraEntities())
            {
                db.Database.ExecuteSqlCommand("DELETE FROM Obras_Lineas WHERE id_Obra = " + Obr.Id_Obra + " AND id_empresa = " + Obr.Id_Empresa + "");
            }
        }

        public static void Modificar_linea(int id_obra, string cap, string Unidad_medida, double medidas)
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            Obras_Lineas Line = db.Obras_Lineas.Where(p => p.Id_Obra == id_obra).Where(p => p.Capitulo == cap).ToList()[0];
            if (Line != null)
            {
                Line.Unidad_Medida = Unidad_medida;
                Line.Medidas = medidas;
                db.SaveChanges();
            }
        }
        public static Obras_Lineas Listar_linea(int id_obra, string cap)
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            return db.Obras_Lineas.Where(p => p.Id_Obra == id_obra).Where(p=> p.Capitulo == cap).ToList()[0];

        }
        public static void CambiarGrupo(int id_Obra, string cap_sigrid, int id_grupo, int id_subgrupo)
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            List<Obras_Lineas> Line = db.Obras_Lineas.Where(p => p.Id_Obra == id_Obra).Where(p => p.Capitulo == cap_sigrid).ToList();
            foreach (Obras_Lineas Linea in Line)
            {
                if (Linea != null)
                {
                    Linea.Id_Grupo  = id_grupo;
                    Linea.Id_Subgrupo =  id_subgrupo;
                    db.SaveChanges();
                }
            }
        }
        public static void CambiarGrupo(int id_Obra, int id_grupo, int? id_subgrupo)
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            List<Obras_Lineas> Line = new List<Obras_Lineas>();
            if (id_subgrupo == null)
            { Line = db.Obras_Lineas.Where(p => p.Id_Obra == id_Obra).Where(p => p.Id_Grupo  == id_grupo).ToList(); }
            else
            { Line = db.Obras_Lineas.Where(p => p.Id_Obra == id_Obra).Where(p=> p.Id_Subgrupo  == id_subgrupo).ToList(); }

            foreach (Obras_Lineas Linea in Line)
            {
                if (Linea != null)
                {
                    Linea.Id_Grupo  = 163;
                    Linea.Id_Subgrupo  = 109;
                    db.SaveChanges();
                }
            }

        }
        public static void ModificarAjuste(int id_Obra, int id_empresa, decimal importe, string comentario,decimal valorventa,decimal cobrado, decimal gastos)
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            Obras Obr = db.Empresas.Where(p => p.Id_Empresa == id_empresa).ToList()[0].Obras.Where(p => p.Id_Obra == id_Obra).ToList()[0];
            if (Obr != null)
            {
                Obr.Ajuste = importe;
                Obr.Comentario_Ajuste = comentario;
                Obr.ValorVenta = valorventa;
                Obr.Cobrado2017 = cobrado;
                Obr.Gastos2017 = gastos;

                db.SaveChanges();
            }
        }
        public static List<Obras> Sort(string column, string sortOrder, List<Obras> list)
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
                case "Id_Obra":
                    {
                        if (sortOrder == "Ascending")
                        {
                            return list.OrderBy(x => x.Id_Obra).ToList();

                        }
                        else
                        {
                            return list.OrderByDescending(x => x.Id_Obra).ToList();
                        }
                    }

            }
            return list;

        }
        public static DataTable  CargarFasesObra(Empresas Empresa, Obras Obr)
        {       
            Conexion.IniciarSesion(Empresa.Servidor_Sigrid, Empresa.BBDD_Sigrid, Empresa.Usuario_Sigrid, Empresa.Pwd_Sigrid);
            DataTable dtfases = Conexion.GDatos.TraerDataTableSql("SELECT res,fasnum  FROM obrfas where obride = " + Obr.Id_Sigrid + " ORDER BY fasnum");
            DataRow dr = dtfases.NewRow();
            dr[0] = "GENERAL";
            dr[1] = 0;                
            dtfases.Rows.Add(dr);
            Conexion.FinalizarSesion();            
            return dtfases;
        }
    }
}
