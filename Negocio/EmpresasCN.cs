using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;
using Datos;

namespace Negocio
{
    public class EmpresasCN
    {
        public static List<Empresas> Listar()
        {
            List<Empresas> lempresas = new List<Empresas>();
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            foreach (Empresas Emp in db.Empresas.ToList())
            {
                Emp.Conexion();
                lempresas.Add(Emp);    
            }
             return lempresas;        
        }

        public static Empresas Listar(int id)
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            Empresas Empresa = db.Empresas.SingleOrDefault<Empresas>(p => p.Id_Empresa == id);
            Empresa.Conexion();
            return Empresa;     
        }

        public static Empresas Añadir(string Nombre, string BBDD, string Servidor, string Usuario, string Pwd)
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            Empresas Emp = new Empresas();
            Emp.Nombre = Nombre;
            Emp.BBDD_ContaWin = BBDD;
            Emp.Servidor_ContaWin = Servidor;
            Emp.Usuario_ContaWin = Usuario;
            Emp.Pwd_ContaWin = Pwd;
            db.Empresas.Add(Emp);
            db.SaveChanges();
            return Emp;
        }
        public static void Borrar(int id)
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            Empresas Emp = db.Empresas.SingleOrDefault<Empresas>(p => p.Id_Empresa == id);
            db.Empresas.Remove(Emp);
            db.SaveChanges();
        }
        public static void Modificar(int id_empresa, string Nombre, string BBDD, string Servidor, string Usuario, string Pwd)
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            Empresas Emp = db.Empresas.SingleOrDefault<Empresas>(p => p.Id_Empresa == id_empresa);
            if (Emp != null)
            {
                Emp.Nombre = Nombre;
                Emp.BBDD_ContaWin = BBDD;
                Emp.Servidor_ContaWin = Servidor;
                Emp.Usuario_ContaWin = Usuario;
                Emp.Pwd_ContaWin = Pwd;
                db.SaveChanges();
            }
        }

        public static List<Empresas> Sort(string column, string sortOrder, List<Empresas> list)
        {
            switch (column)
            {
                case "Empresa":
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
                case "bbdd":
                    {
                        if (sortOrder == "Ascending")
                        {
                            return list.OrderBy(x => x.BBDD_ContaWin).ToList();

                        }
                        else
                        {
                            return list.OrderByDescending(x => x.BBDD_ContaWin).ToList();
                        }

                    }
                case "Servidor":
                    {
                        if (sortOrder == "Ascending")
                        {
                            return list.OrderBy(x => x.Servidor_ContaWin).ToList();
                        }
                        else
                        {
                            return list.OrderByDescending(x => x.Servidor_ContaWin).ToList();
                        }

                    }
              }
            return list;

        }


    }
}
