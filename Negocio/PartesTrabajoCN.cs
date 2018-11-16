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
    public class PartesTrabajoCN
    {
        public static void Import_PartesTrabajo(Obras Obr, string id_log, Empresas Empresa)
        {
            bool Correcto = true;
            Conexion.IniciarSesion(Empresa.Servidor_Sigrid, Empresa.BBDD_Sigrid, Empresa.Usuario_Sigrid, Empresa.Pwd_Sigrid);
            DataTable dtpartes = Conexion.GDatos.TraerDataTableSql("SELECT *,par.cod as 'Cod_par',(SELECT cod FROM obrparpar paraux WHERE paraux.ide = par.padide) as 'Cap_Sigrid' FROM hmores dc,con,hmo,obrparpar par    where hmo.ide = dc.hmoide and con.ide = hmo.ide and dc.paride = par.ide  AND dc.obride =" + Obr.Id_Sigrid.ToString() + "");
            foreach (DataRow linea in dtpartes.Rows)
            {
                ParteTrabajo ParteTrabaj = new ParteTrabajo();
                Correcto = true;
                if (Obr.ParteTrabajo.Where(p => p.id_LineaParteSigrid == Convert.ToInt32(linea["ide"].ToString())).Count() > 0) continue; //Comprobacion ya existe en nuestra BB                 
                ParteTrabaj.id_LineaParteSigrid = Convert.ToInt32(linea["ide"].ToString());
                ParteTrabaj.Id_Obra = Obr.Id_Obra;
                ParteTrabaj.Id_Empresa = Obr.Id_Empresa;
                ParteTrabaj.Ref_Parte = linea["cod"].ToString();
                ParteTrabaj.Empleado = linea["res"].ToString();
                ParteTrabaj.fecha = DateTime.ParseExact(linea["fec"].ToString(), "yyyyMMdd", null);
                ParteTrabaj.Horas = Convert.ToDecimal(linea["can"].ToString());
                ParteTrabaj.Precio = Convert.ToDecimal(linea["pre"].ToString());
                ParteTrabaj.TotalImporte = Convert.ToDecimal(linea["tot"].ToString());
                ParteTrabaj.Cap_Sigrid = linea["Cod_par"].ToString();

                Grupos_Rel gr = GruposCN.Listar_rel(Obr.Id_Obra, ParteTrabaj.Cap_Sigrid);
                if (gr == null) //Comprobacion que todos los capitulos que tienen las lineas de la factura esten en la tabla Grupos_rel
                {
                    if (ParteTrabaj.Cap_Sigrid != "")
                    {
                       // Log_ErroresCN.Añadir(4, "Capturar Parte Trabajo", ParteTrabaj.Cap_Sigrid, "Id_LineaParte", 0, "NO existe relacion con el capitulo:" + ParteTrabaj.Cap_Sigrid + "", id_log, Obr.Id_Empresa, Obr.Id_Obra, Obr.Nombre);
                        ParteTrabaj.Id_Grupo  = 163;
                        ParteTrabaj.Id_Subgrupo  = 109;
                    }
                    else
                    {
                        Log_ErroresCN.Añadir(4, "Capturar Parte Trabajo", ParteTrabaj.Ref_Parte, "Id_Albaran", 3, "No se ha asignado partida en alguna de los partes de trabajo:" + ParteTrabaj.Ref_Parte + "----(" + ParteTrabaj.fecha.ToShortDateString() + ")", id_log, Obr.Id_Empresa, Obr.Id_Obra, Obr.Nombre);
                        Correcto = false;
                        break;
                    }
                   
                }
                else
                {
                    ParteTrabaj.Id_Grupo  = gr.Id_Grupo;
                    ParteTrabaj.Id_Subgrupo  = gr.Id_Subgrupo;
                }
                 if (Correcto == true) Añadir(ParteTrabaj);

            }

        }
        public static void Añadir(ParteTrabajo Partetrabaj)
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            db.ParteTrabajo.Add(Partetrabaj);
            db.SaveChanges();
        }
        public static void CambiarGrupo(int id_Obra, int id_grupo, int? id_subgrupo, ParteTrabajo linea)
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            ParteTrabajo Line = db.ParteTrabajo.Where(p => p.Id_LineaParte == linea.Id_LineaParte).ToList()[0];
            Line.Id_Grupo = id_grupo;
            var a = (id_subgrupo == null) ? Line.Id_Subgrupo = 0 : Line.Id_Subgrupo = id_subgrupo;
            db.SaveChanges();

        }
    }
}
