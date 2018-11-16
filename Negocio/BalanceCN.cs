using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;
using Datos;
using System.Diagnostics;


namespace Negocio
{
    public class BalanceCN
    {

        //Tipo = 0 Ingresos
        //Tipo = 1 Gastos

      

        // LO QUE REALMENTE VALE ( Lo anterior es para el formBalnce que no vale para nada)
        #region "BALANCE 2"   
        public static List<Balance> ListarlineasBalance(string id_informe)
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            var query = db.Balance.Where(p => p.Id_Informe == id_informe);
            return query.ToList();
        }
        public static decimal IngresosObra_Conta(Obras Obr, int id_grupo, string id_infor)
        {
            return Obr.Balance.Where(p => p.Cuentas.Id_Grupo == id_grupo).Where(p => p.Id_Informe == id_infor).Sum(d => d.Imp_Haber - d.Imp_debe);
        }
        public static decimal IngresosObra_ContaSubgrupos(Obras Obr, int id_subgrupos, string id_infor)
        {
            return Obr.Balance.Where(p => p.Cuentas.Id_SubGrupo == id_subgrupos).Where(p => p.Id_Informe == id_infor).Sum(d => d.Imp_Haber - d.Imp_debe);
        }

        public static decimal GastosObra_Conta(Obras Obr, int id_grupo, string id_infor)
        {
            return Obr.Balance.Where(p => p.Cuentas.Id_Grupo == id_grupo).Where(p => p.Id_Informe == id_infor).Sum(d => d.Imp_debe - d.Imp_Haber);
        }
        public static decimal GastosObra_ContSubgruposa(Obras Obr, int id_subgrupos, string id_infor)
        {
            return Obr.Balance.Where(p => p.Cuentas.Id_SubGrupo == id_subgrupos).Where(p => p.Id_Informe == id_infor).Sum(d => d.Imp_debe - d.Imp_Haber);
        }

        public static decimal Debe_Cuenta(Obras Obr, int id_grupo, string id_infor)
        {
            return Obr.Balance.Where(p => p.Cuentas.Id_Grupo == id_grupo).Where(p => p.Id_Informe == id_infor).Sum(d => d.Imp_debe);
        }
        public static decimal Haber_Cuenta(Obras Obr, int id_grupo, string id_infor)
        {
            return Obr.Balance.Where(p => p.Cuentas.Id_Grupo == id_grupo).Where(p => p.Id_Informe == id_infor).Sum(d => d.Imp_Haber);
        }
        public static decimal Saldo_Cuenta(Obras Obr, int id_grupo, string id_infor)
        {
            return Obr.Balance.Where(p => p.Cuentas.Id_Grupo == id_grupo).Where(p => p.Id_Informe == id_infor).Sum(d => d.Imp_debe  - d.Imp_Haber );
        }
        public static List<Obras> Obras_EnBalance(string id_infor)
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            List<Obras> lobras = new List<Obras>();
            var query = from t in db.Balance
                        where t.Id_Informe == id_infor                       
                        group t by new { t.Id_Obra, t.Id_empresa }
                       into grp                       
                        select new 
                        {
                            Id_Informe = "",
                            Id_empresa = grp.Key.Id_empresa,
                            Id_Obra = grp.Key.Id_Obra
                        };

            foreach (var b in query)
            {
                lobras.Add(ObraCN.Listar(b.Id_Obra, b.Id_empresa));
             
            }
          
            return lobras;
        }


        #endregion


        public static void Añadir(List<Balance> inf)
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            foreach (Balance Lineas in inf)
            {
                db.Balance.Add(Lineas);
            }
            db.SaveChanges();
        }
        public static void Borrar(string id)
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            db.Database.ExecuteSqlCommand("DELETE FROM Balance WHERE id_informe = '" + id  + "'");

        }
        public static List<Balance> Sort(string column, string sortOrder,List<Balance> list)
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
                case "Cuenta":
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
                case "Fecha":
                    {
                        if (sortOrder == "Ascending")
                        {
                            return list.OrderBy(x => x.fecha).ToList();

                        }
                        else
                        {
                            return list.OrderByDescending(x => x.fecha).ToList();
                        }
                    }
                case "Debe":
                    {
                        if (sortOrder == "Ascending")
                        {
                            return list.OrderBy(x => x.Imp_debe).ToList();

                        }
                        else
                        {
                            return list.OrderByDescending(x => x.Imp_debe).ToList();
                        }
                       
                    }
                case "Haber":
                    {
                        if (sortOrder == "Ascending")
                        {
                            return list.OrderBy(x => x.Imp_Haber).ToList();

                        }
                        else
                        {
                            return list.OrderByDescending(x => x.Imp_Haber).ToList();
                        }
                       
                    }
            }
            return list;

        }

    }
  
}
