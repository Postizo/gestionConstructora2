using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;
using Datos;
using ContaWIN;

namespace Negocio
{
   public class AlbaranesCN
    {
        public static void Import_Albaranes(Obras Obr, string id_log, Empresas Empresa)
        {
            bool Correcto = true;
            Conexion.IniciarSesion(Empresa.Servidor_Sigrid, Empresa.BBDD_Sigrid, Empresa.Usuario_Sigrid, Empresa.Pwd_Sigrid);
            DataTable dtfacturasca = Conexion.GDatos.TraerDataTableSql("SELECT * FROM con condoc, dca doc WHERE est = 1 and condoc.tip = 14 and condoc.ide = doc.ide and doc.obride = " + Obr.Id_Sigrid.ToString() + " order by fec desc");

            foreach (DataRow row in dtfacturasca.Rows)
            {
                Correcto = true;
                if (Obr.Albaranes_ca.Where(p => p.Id_AlbSigrid == Convert.ToInt32(row["ide"].ToString())).Count() > 0) continue; //Comprobacion ya existe en nuestra BBDD
                Albaranes_ca Albaran = new Albaranes_ca();
                Albaran.Id_AlbSigrid = Convert.ToInt32(row["ide"].ToString());
                Albaran.Id_Obra = Obr.Id_Obra;
                Albaran.Id_Empresa = Obr.Id_Empresa;
                Albaran.Fecha = DateTime.ParseExact(row["fec"].ToString(), "yyyyMMdd", null);
                Albaran.Ref_Alb = row["cod"].ToString();
                Albaran.Su_ref = row["entref"].ToString();
                Albaran.Id_Formapago = Convert.ToInt32(row["pagide"].ToString());
                Albaran.Id_proveedor = Convert.ToInt32(row["entide"].ToString());
                Albaran.Proveedor = row["entres"].ToString();
                Albaran.Cif = row["entcif"].ToString();
                Albaran.Direccion = row["dirdir1"].ToString();
                Albaran.Base = Convert.ToDecimal(row["totbas"].ToString());
                Albaran.Cuota = Convert.ToDecimal(row["totiva"].ToString());
                Albaran.TotImporte = Convert.ToDecimal(row["totdoc"].ToString());
                Albaran.Estado = -1;


                DataTable dtfacturasli = Conexion.GDatos.TraerDataTableSql("SELECT * ,(SELECT cod FROM obrparpar paraux WHERE paraux.ide = par.padide) as 'Cap_Sigrid',ISNULL(rec.valpor,0) as 'valpor1',ISNULL(rec.reccla,0) as 'reccla1'  FROM dcapro dc LEFT JOIN dcarec rec ON dc.docide =rec.docide  LEFT JOIN obrparpar par ON dc.paride = par.ide LEFT JOIN iva i ON dc.ivaide = i.ide where  dc.docide =" + row["ide"].ToString() + "");
                foreach (DataRow linea in dtfacturasli.Rows)
                {
                    decimal valpor = 0;
                    Albaran_li ALb_lineas = new Albaran_li();
                    ALb_lineas.Id_Alb_liSigrid = Convert.ToInt32(linea["ide"].ToString());
                    ALb_lineas.Id_producto = Convert.ToInt32(linea["proide"].ToString());
                    ALb_lineas.Descripcion = linea["res"].ToString();
                    ALb_lineas.Descripcion2 = linea["tex"].ToString();
                    ALb_lineas.Pre_sindescuento = Convert.ToDecimal(linea["tar"].ToString());
                    ALb_lineas.Pre = Convert.ToDecimal(linea["pre"].ToString());
                    ALb_lineas.Descuento = 0; //Convert.ToDouble(linea["dto"].ToString());
                    ALb_lineas.Cantidad = Convert.ToDouble(linea["can"].ToString());
                    if (linea["iva"].ToString() == "")
                    {
                        Log_ErroresCN.Añadir(1, "Capturar Facturas", Albaran.Ref_Alb, "Id_Factura", 2, "NO existe iva en alguna de las lineas de la factura: " + Albaran.Ref_Alb + "", id_log,Obr.Id_Empresa,Obr.Id_Obra,Obr.Nombre);
                        Correcto = false;
                        break;
                    }
                    ALb_lineas.Iva = Convert.ToDouble(linea["iva"].ToString()) * 100;
                    //lo de los descuentos
                    if (Convert.ToDecimal(linea["valpor1"].ToString()) > 0 && Convert.ToInt32(linea["reccla1"].ToString()) == 1)
                    {
                        valpor = Convert.ToDecimal(linea["valpor1"].ToString());
                        ALb_lineas.Base = (Convert.ToDecimal(linea["tot"].ToString())) - ((Convert.ToDecimal(linea["tot"].ToString()) * valpor));
                    }
                    else
                    {
                        ALb_lineas.Base = Convert.ToDecimal(linea["tot"].ToString());
                    }


                    ALb_lineas.Cuota = Convert.ToDecimal(linea["ivacuo"].ToString());
                    ALb_lineas.Importe = ALb_lineas.Base + ALb_lineas.Cuota;
                    ALb_lineas.Cap_sigrid = linea["Cod"].ToString();
                 

                    Grupos_Rel gr = GruposCN.Listar_rel(Obr.Id_Obra, ALb_lineas.Cap_sigrid);
                    if (gr == null) //Comprobacion que todos los capitulos que tienen las lineas de la factura esten en la tabla Grupos_rel
                    {
                        if (ALb_lineas.Cap_sigrid != "")
                        {
                           // Log_ErroresCN.Añadir(3, "Capturar Albaranes", ALb_lineas.Cap_sigrid, "Id_Albaran", 0, "NO existe relacion con el capitulo:" + ALb_lineas.Cap_sigrid + "", id_log, Obr.Id_Empresa, Obr.Id_Obra, Obr.Nombre);
                            ALb_lineas.Id_grupo = 163;
                            ALb_lineas.id_subgrupo = 109;
                            ALb_lineas.Mano_Obra = (ALb_lineas.Cap_sigrid.Substring(0, 2) == "MO") ? true : false;
                        }
                        else
                        {
                            Log_ErroresCN.Añadir(3, "Capturar Albaranes", Albaran.Ref_Alb, "Id_Albaran", 3, "No se ha asignado partida en alguna de las lineas del Albaran:" + Albaran.Ref_Alb + "----(" + Albaran.Fecha.ToShortDateString() + ")", id_log, Obr.Id_Empresa, Obr.Id_Obra, Obr.Nombre);
                            Correcto = false;
                            break;
                        }

                    }
                    else
                    {
                      ALb_lineas.Id_grupo = gr.Id_Grupo;
                      ALb_lineas.id_subgrupo = gr.Id_Subgrupo;
                        ALb_lineas.Mano_Obra = (ALb_lineas.Cap_sigrid.Substring(0, 2) == "MO") ? true : false;
                    }
                   
                    Albaran.Albaran_li.Add(ALb_lineas);
                }
                //Comprobacion que las lineas de albaran y la cabecera coinciden
                if (Correcto == true)
                {
                    if (Albaran.Base != Albaran.Albaran_li.Sum(p => p.Base))
                    {
                        Log_ErroresCN.Añadir(3, "Capturar Albaranes", Albaran.Ref_Alb, "Id_Albaran", 4, "NO COINCIDEN LAS BASES en el Albaran:" + Albaran.Ref_Alb, id_log, Obr.Id_Empresa, Obr.Id_Obra, Obr.Nombre);
                        Correcto = false;

                    }
                }

                if (Correcto == true) Añadir(Albaran);
            }

        }
        public static void Añadir(Albaranes_ca Albaran)
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            db.Albaranes_ca.Add(Albaran);
            db.SaveChanges();
        }
        public static void Borrar_Albaranres(int id_empresa, int id_obra)
        { 
            using (GestionConstructoraEntities db = new GestionConstructoraEntities())
            {
              
                db.Database.ExecuteSqlCommand("DELETE FROM Albaranes_ca WHERE id_Empresa = " + id_empresa + " AND id_obra = " + id_obra + " ");
           

            }
        }
        public static void CambiarGrupo(int id_Obra, int id_grupo, int? id_subgrupo, Albaran_li linea)
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            Albaran_li Line = db.Albaran_li.Where(p => p.Id_Alb_li == linea.Id_Alb_li).ToList()[0];
            Line.Id_grupo = id_grupo;
            var a = (id_subgrupo == null) ? Line.id_subgrupo = 0 : Line.id_subgrupo = id_subgrupo;
            db.SaveChanges();

        }
    }
}
