using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;
using Datos;

namespace Negocio
{
    public class CuentasCn
    {
    
        public static List<Cuentas> Listar(bool solotrata)
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            if (solotrata == true)
            {
                return db.Cuentas.Where(p => p.TrataCuenta == true).ToList();
            }
            else
            {
                return db.Cuentas.ToList();
            }
   
        }
        public static List<Cuentas> Listar(bool solotrata, string busca, int id_empresa)
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            if (solotrata == true)
            {
                return db.Cuentas.Where(p => p.TrataCuenta == solotrata).Where(p=> p.Id_Empresa == id_empresa).Where(p => p.Cuenta.Contains(busca)).ToList();
            }
            else
            {
                return db.Cuentas.ToList().Where(p => p.Id_Empresa == id_empresa).Where(p => p.Cuenta.Contains(busca)).ToList();
            }

        }

        public static Cuentas Listar(int id_empresa, string cuenta)
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            Cuentas c = new Cuentas();
            var a = db.Cuentas.Where(p => p.Id_Empresa == id_empresa).Where(p => p.Cuenta == cuenta).ToList();
            if (a.Count > 0 )return a[0]; else return null;

        }

        public static void Añadir(Cuentas cuen)
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            db.Cuentas.Add(cuen);
            db.SaveChanges();
        }

        public static Cuentas Añadir(int id_empresa, string cuenta, string nombre, int Id_grupo, int id_subgrupo, bool tratacuenta)
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            Cuentas Cuenta = new Cuentas();
            Cuenta.Id_Empresa = id_empresa;
            Cuenta.Cuenta = cuenta;
            Cuenta.Nombre = nombre;
            Cuenta.Id_Grupo = Id_grupo;
            Cuenta.Id_SubGrupo = id_subgrupo;
            Cuenta.TrataCuenta = tratacuenta;
            db.Cuentas.Add(Cuenta);
            db.SaveChanges();
            return Cuenta;
        }
       
        public static void Borrar(int id_empresa, string cuenta)
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            Cuentas Cuenta = db.Cuentas.Where(p => p.Id_Empresa == id_empresa).Where(p => p.Cuenta == cuenta).ToList()[0];
            db.Cuentas.Remove(Cuenta);
            db.SaveChanges();
        }

        public static void Modificar(int id_empresa, string cuenta, string nombre, int Id_grupo, int id_subgrupo, bool tratacuenta)
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            Cuentas Cuenta = db.Cuentas.Where(p => p.Id_Empresa == id_empresa).Where(p => p.Cuenta == cuenta).ToList()[0];

            if (Cuenta != null)
            {
                Cuenta.Nombre = nombre;
                Cuenta.Id_Grupo = Id_grupo;
                Cuenta.Id_SubGrupo = id_subgrupo;
                Cuenta.TrataCuenta = tratacuenta;
                db.SaveChanges();
            }

        }
        public static List<Cuentas> Sort(string column, string sortOrder, List<Cuentas> list)
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
              
                case "Cuentas":
                    {
                        if (sortOrder == "Ascending")
                        {
                            return list.OrderBy(x => x.Cuenta).ToList();
                        }
                        else
                        {
                            return list.OrderByDescending(x => x.Cuenta).ToList();
                        }
                       
                    }
                case "Trata":
                    {
                        if (sortOrder == "Ascending")
                        {
                            return list.OrderBy(x => x.TrataCuenta).ToList();

                        }
                        else
                        {
                            return list.OrderByDescending(x => x.TrataCuenta).ToList();
                        }
                  
                    }
   
            }
            return list;

        }
    }
}
