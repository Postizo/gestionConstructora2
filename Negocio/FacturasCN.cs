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
    //  LOG errores 
    //  Id_Proceso                                //id_tipo_error
    //  0- Procesos Internos 
    //  1 - Importar Facturas                     0- La linea de Factura no tienen relacion(NO existe relacion con el capitulo)
    //                                            1- La Linea no tiene cuenta de COntaWIN Asignada
    //                                            2- La linea de fac no tienen IVA  
    //                                            3- No se ha asignado partida en alguna de las lineas de la factura
    //                                            4- NO COINCIDEN LAS BASES en la Factura  
    //
    //  2 - Contabilizar Facturas                 1- Errores internos de librerias de contawin 
    //                                            2-    
    //                                            3- No existe CIF en ContaWIn  
    //
    // 
    //  3 - Importar Albaranes                    0- La linea de Factura no tienen relacion(NO existe relacion con el capitulo)
    //                                            2- La linea de fac no tienen IVA  
    //                                            3- No se ha asignado partida en alguna de las lineas de la factura
    //                                            4- NO COINCIDEN LAS BASES en la Factura
    //
    //  4 - Importar Partes Trabajo               3- No se ha asignado partida en alguna de las lineas de la factura
    //  5 - Repaso General                        1 - Falta Relacion del Capitulo 

    public class FacturasCN
    {
        public static List<string> Provees = new List<string>();
        public static void Import_Facturas(Obras Obr, string id_log, Empresas Empresa)
        {
            bool Correcto = true;
            Conexion.IniciarSesion(Empresa.Servidor_Sigrid, Empresa.BBDD_Sigrid, Empresa.Usuario_Sigrid, Empresa.Pwd_Sigrid);
            DataTable dtfacturasca = Conexion.GDatos.TraerDataTableSql("SELECT * FROM con condoc, dcf doc WHERE est <> 1 and condoc.tip = 15 and condoc.ide = doc.ide and doc.obride = " + Obr.Id_Sigrid.ToString() + " order by fec desc");

            foreach (Facturas_ca fac in Obr.Facturas_ca)
            {
              DataRow[] foundRows = dtfacturasca.Select("ide = " + fac.Id_FacSigrid);
                if (foundRows.Count() > 0)
                {
                    Console.WriteLine("");
                }
                else
                {
                    Console.WriteLine("");
                }
            }



            foreach (DataRow row in dtfacturasca.Rows)
            {
                Correcto = true;
                if (Obr.Facturas_ca.Where(p => p.Id_FacSigrid == Convert.ToInt32(row["ide"].ToString())).Count() > 0) continue; //Comprobacion ya existe en nuestra BBDD
                Facturas_ca Factura = new Facturas_ca();
                Factura.Id_FacSigrid = Convert.ToInt32(row["ide"].ToString());
                Factura.Id_Obra = Obr.Id_Obra;
                Factura.Id_Empresa = Obr.Id_Empresa;
                Factura.Fecha = DateTime.ParseExact(row["fec"].ToString(), "yyyyMMdd", null);
                Factura.Ref_Fac = row["cod"].ToString();
                Factura.Su_ref = row["entref"].ToString();
                Factura.Id_Formapago = Convert.ToInt32(row["pagide"].ToString());
                Factura.Id_proveedor = Convert.ToInt32(row["entide"].ToString());
                Factura.Proveedor = row["entres"].ToString();
                Factura.Cif = row["entcif"].ToString();
                Factura.Direccion = row["dirdir1"].ToString();
                Factura.Base = Convert.ToDecimal(row["totbas"].ToString());
                Factura.Cuota = Convert.ToDecimal(row["totiva"].ToString());
                Factura.TotImporte = Convert.ToDecimal(row["totdoc"].ToString());
                Factura.Estado = -1;
                Factura.SujetoPasivo = Convert.ToBoolean(row["tipisp"]);

                DataTable dtfacturasli = Conexion.GDatos.TraerDataTableSql("SELECT * ,(SELECT cod FROM obrparpar paraux WHERE paraux.ide = par.padide) as 'Cap_Sigrid',ISNULL(rec.valpor,0) as 'valpor1',ISNULL(rec.reccla,0) as 'reccla1'  FROM dcfpro dc LEFT JOIN dcfrec rec ON dc.docide =rec.docide  LEFT JOIN obrparpar par ON dc.paride = par.ide LEFT JOIN iva i ON dc.ivaide = i.ide where  dc.docide =" + row["ide"].ToString() + "");
                foreach (DataRow linea in dtfacturasli.Rows)
                {
                    decimal valpor = 0;
                    Facturas_li Fac_lineas = new Facturas_li();
                    Fac_lineas.Id_Fac_liSigrid = Convert.ToInt32(linea["ide"].ToString());
                    Fac_lineas.Id_producto = Convert.ToInt32(linea["proide"].ToString());
                    Fac_lineas.Descripcion = linea["res"].ToString();
                    Fac_lineas.Descripcion2 = linea["tex"].ToString();
                    Fac_lineas.Pre_sindescuento = Convert.ToDecimal(linea["tar"].ToString());
                    Fac_lineas.Pre = Convert.ToDecimal(linea["pre"].ToString());
                    Fac_lineas.Descuento = 0; //Convert.ToDouble(linea["dto"].ToString());
                    Fac_lineas.Cantidad = Convert.ToDouble(linea["can"].ToString());
                    if (linea["iva"].ToString() == "")
                    {
                        Log_ErroresCN.Añadir(1, "Capturar Facturas", Factura.Ref_Fac, "Id_Factura", 2, "NO existe iva en alguna de las lineas de la factura: " + Factura.Ref_Fac + "", id_log, Obr.Id_Empresa, Obr.Id_Obra, Obr.Nombre);
                        Correcto = false;
                        break;
                    }
                    Fac_lineas.Iva = Convert.ToDouble(linea["iva"].ToString()) * 100;
                    //lo de los descuentos
                    if (Convert.ToDecimal(linea["valpor1"].ToString()) > 0 && Convert.ToInt32(linea["reccla1"].ToString()) == 1)
                    {
                        valpor = Convert.ToDecimal(linea["valpor1"].ToString());
                        Fac_lineas.Base = (Convert.ToDecimal(linea["tot"].ToString())) - ((Convert.ToDecimal(linea["tot"].ToString()) * valpor));
                    }
                    else
                    {
                        Fac_lineas.Base = Convert.ToDecimal(linea["tot"].ToString());
                    }
                                            
                    Fac_lineas.Cuota = Convert.ToDecimal(linea["ivacuo"].ToString());
                    Fac_lineas.Importe = Fac_lineas.Base + Fac_lineas.Cuota;
                    Fac_lineas.Cap_sigrid = linea["Cod"].ToString();
                    Fac_lineas.Tipo_Cuenta = linea["Item"].ToString();
                   
                    if (Fac_lineas.Tipo_Cuenta == "0")  
                    {
                        Log_ErroresCN.Añadir(1, "Capturar Facturas", Factura.Ref_Fac, "Id_Factura", 1, "NO existe cuenta en alguna de las lineas de la factura: " + Factura.Ref_Fac + "", id_log, Obr.Id_Empresa, Obr.Id_Obra, Obr.Nombre);
                        Correcto = false;
                        break;
                    }

                    Grupos_Rel gr = GruposCN.Listar_rel(Obr.Id_Obra, Fac_lineas.Cap_sigrid);
                    if (gr == null) //Comprobacion que todos los capitulos que tienen las lineas de la factura esten en la tabla Grupos_rel
                    {
                        if (Fac_lineas.Cap_sigrid != "")
                        {
                            //Log_ErroresCN.Añadir(1, "Capturar Facturas", Fac_lineas.Cap_sigrid, "Id_Factura", 0, "NO existe relacion con el capitulo:" + Fac_lineas.Cap_sigrid + "", id_log, Obr.Id_Empresa, Obr.Id_Obra, Obr.Nombre);
                            Fac_lineas.Id_grupo = 163;
                            Fac_lineas.id_subgrupo = 109;
                            Fac_lineas.Mano_Obra = (Fac_lineas.Cap_sigrid.Substring(0, 2) == "MO") ? true : false;
                        }
                        else
                        {
                            Log_ErroresCN.Añadir(1, "Capturar Facturas", Factura.Ref_Fac, "Id_Factura", 3, "No se ha asignado partida en alguna de las lineas de la factura:" + Factura.Ref_Fac + "----(" + Factura.Fecha.ToShortDateString() + ")", id_log, Obr.Id_Empresa, Obr.Id_Obra, Obr.Nombre);
                            Correcto = false;
                            break;
                        }
                    }
                    else
                    {
                        Fac_lineas.Id_grupo = gr.Id_Grupo;
                        Fac_lineas.id_subgrupo = gr.Id_Subgrupo;
                        Fac_lineas.Mano_Obra = (Fac_lineas.Cap_sigrid.Substring(0, 2) == "MO") ? true : false;
                    }                   
                    Factura.Facturas_li.Add(Fac_lineas);
                }
                //Comprobacion que las lineas de factura y la cabecera coinciden
                if (Correcto == true)
                {
                    if (Factura.Base != Factura.Facturas_li.Sum(p => p.Base))
                    {                       
                        Correcto = false;
                       
                    }
                }

                if (Correcto == true) Añadir(Factura);
            }                    
        }
        

        public static List<string> ContabilizarLasQueMAndo(Empresas Empresa, List<Facturas_ca> Pendientes_Facturar, string id_log)
        {
            Provees.Clear();
            List<string> Mensajes = new List<string>();
            int val = 0;
            //Obras Obr = Empresa.Obras.Where(p=> p.Id_Obra == Id_Obra).ToList()[0];
            //List<Facturas_ca> Pendientes_Facturar = Obr.Facturas_ca.Where(p => p.Estado == -1).ToList();
            foreach (Facturas_ca Factu in Pendientes_Facturar)
            {
               // if (Factu.Cuota == 0) continue;
                val = (Factu.SujetoPasivo == true) ? Factura_SujetoPasico(Factu, id_log, Empresa) : Factura_Normal(Factu, id_log, Empresa);
                if (val != 0) Cambiar_estado(Factu.Id_Factura, 0, val);
            }

            //AGREGAMOS LOS ERRORES

            foreach (string prove in Provees)
            {
                Log_ErroresCN.Añadir(2, "Contabilizar Facturas", "", "Id_Factura", 3, "No existe ninguna cuenta para el proveedor: " + prove, id_log,0,0,"");
            }
            string MesnajeContables = Log_ErroresCN.ConstruirMensajeMail(id_log, 2, 3, "Las siguientes Facturas han producido el siguiente error:");
            string MensajeAdministrativo = Log_ErroresCN.ConstruirMensajeMail(id_log, 2, 1, "Las siguientes Facturas han producido el siguiente error:");

            if (MesnajeContables != string.Empty) Mensajes.Add(MesnajeContables);
            if (MensajeAdministrativo != string.Empty) Mensajes.Add(MensajeAdministrativo);
            return Mensajes;
            // Log_ErroresCN.EnviarMail("informatica@avillanueva.com", "informatica@avillanueva.com", 25, "ferrita123%", "smtpparla.spamina.com", "ignacio@avillanueva.com", "PROCESO CONTABILIZAR FACTURAS PROCEDENTES DEL SIGRID", MesnajeContables);
            // Log_ErroresCN.EnviarMail("informatica@avillanueva.com", "informatica@avillanueva.com", 25, "ferrita123%", "smtpparla.spamina.com", "ignacio@avillanueva.com", "PROCESO CONTABILIZAR FACTURAS PROCEDENTES DEL SIGRID", MesnajeConstructores);
        }
        public static int Factura_SujetoPasico(Facturas_ca Fac, string id_log, Empresas Empresa)
        {
            long NumeroAsiento = 0;
            bool val = false;
            string Cuentaprovee;
            M_Contawin.IvaSoportado IvaSoportad = new M_Contawin.IvaSoportado();
            M_Contawin.IvaRepercutido IvaRepercutido = new M_Contawin.IvaRepercutido();

            M_Contawin.Apunte ApunteIVASoportado = new M_Contawin.Apunte();
            M_Contawin.Apunte ApunteIVARepercutido = new M_Contawin.Apunte();

            M_Contawin.Apunte ApunteProvee = new M_Contawin.Apunte();
            M_Contawin.Apunte ApunteCompra = new M_Contawin.Apunte();
            List<M_Contawin.Apunte> ApuntesCompra = new List<M_Contawin.Apunte>();
            M_Contawin Conta = new M_Contawin(Empresa.CNNWIN);

            //Comprobamos si estan todos los CIF en ContaWin
            Cuentaprovee = Conta.CW_Traecuenta_por_cif(Conta.Cn_CONTA2, Fac.Cif);
            if (Cuentaprovee == null)
            {
                if (Provees.FindAll(p => p == Fac.Cif + " -" + Fac.Proveedor).ToList().Count == 0) Provees.Add(Fac.Cif + " -" + Fac.Proveedor);
                return 0;
            }

            NumeroAsiento = Conta.CW_ProximoAsiento(Conta.Cn_CONTA, Fac.Fecha.Year);
            if (NumeroAsiento == 0)
            {
                Log_ErroresCN.Añadir(2, "Contabilizar Facturas", Fac.Id_Factura.ToString(), "Id_Factura", 1, "Error al agregar el apunte en Contawin a traves de las librerias", id_log,0,0,"");
                return 0;
            }

            //Agrupos las lineas de la factura en funcion de a que cuenta de compras va
            var ApuntesCompras = from p in Fac.Facturas_li
                                 group p by p.Tipo_Cuenta into g
                                 select new
                                 {
                                     Su_ref = g.Select(m => m.Facturas_ca.Su_ref).ToList()[0],
                                     Base = g.Sum(m => m.Base),
                                     Id_Obra = g.Select(m => m.Facturas_ca.Id_Obra).ToList()[0],
                                     Fecha = g.Select(m => m.Facturas_ca.Fecha).ToList()[0],
                                     Tipo_cuenta = g.Key
                                 };

            //Agregamos un apunte de compra por cada compra 
            foreach (var apunt in ApuntesCompras)
            {
                // APUNTE COMPRA
                ApunteCompra.Conexion = Conta.Cn_CONTA;
                ApunteCompra.asiento = NumeroAsiento;
                ApunteCompra.Id_Cuenta = apunt.Tipo_cuenta + Empresa.Cod_Contable + "00000"; //
                ApunteCompra.Importe = Convert.ToDouble(apunt.Base);
                ApunteCompra.TipoImporte = Contawin2009.TipoImporte.Debe;                                       
                ApunteCompra.Descripcion = "Factura Nº " + apunt.Su_ref;
                ApunteCompra.fecha = apunt.Fecha;
                ApunteCompra.AñoEjercicio = apunt.Fecha.Year;
                ApunteCompra.Referencia = apunt.Su_ref;
                ApunteCompra.Canal = apunt.Id_Obra;
                ApunteCompra.TipoDOC = 0;
                ApuntesCompra.Add(ApunteCompra);
            }

            // APUNTE IVA SOPORTADO
            ApunteIVASoportado.Conexion = Conta.Cn_CONTA;
            ApunteIVASoportado.asiento = NumeroAsiento;
            ApunteIVASoportado.Id_Cuenta = (Empresa.Id_Empresa == 9)? "4726500000"  :  "472" + Empresa.Cod_Contable + "00000";
            ApunteIVASoportado.Importe = Convert.ToDouble(Fac.Cuota);
            ApunteIVASoportado.TipoImporte = Contawin2009.TipoImporte.Debe;
            ApunteIVASoportado.Descripcion = "Fra Nº " + Fac.Su_ref + " " + Fac.Proveedor;
            ApunteIVASoportado.fecha = Fac.Fecha;
            ApunteIVASoportado.AñoEjercicio = Fac.Fecha.Year;
            ApunteIVASoportado.Referencia = Fac.Su_ref;
            ApunteIVASoportado.Canal = Fac.Id_Obra;
            ApunteIVASoportado.TipoDOC = 0;
            // APUNTE IVA REPERCUTIDO
            ApunteIVARepercutido.Conexion = Conta.Cn_CONTA;
            ApunteIVARepercutido.asiento = NumeroAsiento;
            ApunteIVARepercutido.Id_Cuenta = (Empresa.Id_Empresa == 9) ? "4776500000" : "477" + Empresa.Cod_Contable + "00000"; ;
            ApunteIVARepercutido.Importe = Convert.ToDouble(Fac.Cuota);
            ApunteIVARepercutido.TipoImporte = Contawin2009.TipoImporte.Haber;
            ApunteIVARepercutido.Descripcion = "Fra Nº " + Fac.Su_ref + " " + Fac.Proveedor;
            ApunteIVARepercutido.fecha = Fac.Fecha;
            ApunteIVARepercutido.AñoEjercicio = Fac.Fecha.Year;
            ApunteIVARepercutido.Referencia = Fac.Su_ref;
            ApunteIVARepercutido.Canal = Fac.Id_Obra;
            ApunteIVARepercutido.TipoDOC = 0;

            // APUNTE PROVEEDOR
            ApunteProvee.Conexion = Conta.Cn_CONTA;
            ApunteProvee.asiento = NumeroAsiento;
            ApunteProvee.Id_Cuenta = Cuentaprovee;  //CW_CrearCuentas("Compras", USU._Id_estacion, Albaran.Item("Id_producto"));
            ApunteProvee.Importe = Convert.ToDouble(Fac.Base);
            ApunteProvee.TipoImporte = Contawin2009.TipoImporte.Haber;
            ApunteProvee.Descripcion = "Fra Nº " + Fac.Su_ref + " " + Fac.Proveedor;
            ApunteProvee.fecha = Fac.Fecha;
            ApunteProvee.AñoEjercicio = Fac.Fecha.Year;
            ApunteProvee.Referencia = Fac.Su_ref;
            ApunteProvee.Canal = Fac.Id_Obra;
            ApunteProvee.TipoDOC = 0;

            //AGREGAMOS CON LAS LIBRERIAS LOS APUNTES
            //agregamos los apuntes de compra
            foreach (M_Contawin.Apunte ApunteComp in ApuntesCompra)
            {
                val = Conta.CW_AgregaApunte(ApunteComp);
                if (val == false)
                {
                    Log_ErroresCN.Añadir(2, "Contabilizar Facturas", Fac.Id_Factura.ToString(), "Id_Factura", 1, "Error al agregar el apunte en Contawin a traves de las librerias", id_log,0,0,"");
                    return 0;
                }
            }
            //agregamos el apunte de iva soportado
            val = Conta.CW_AgregaApunte(ApunteIVASoportado);
            if (val == false)
            {
                Log_ErroresCN.Añadir(2, "Contabilizar Facturas", Fac.Id_Factura.ToString(), "Id_Factura", 1, "Error al agregar el apunte en Contawin a traves de las librerias", id_log, 0, 0, "");
                return 0;
            }
            //agregamos el apunte de iva repercutido
            val = Conta.CW_AgregaApunte(ApunteIVARepercutido);
            if (val == false)
            {
                Log_ErroresCN.Añadir(2, "Contabilizar Facturas", Fac.Id_Factura.ToString(), "Id_Factura", 1, "Error al agregar el apunte en Contawin a traves de las librerias", id_log, 0, 0, "");
                return 0;
            }
            //agregamos el apunte del proveedor
            val = Conta.CW_AgregaApunte(ApunteProvee);
            if (val == false)
            {
                Log_ErroresCN.Añadir(2, "Contabilizar Facturas", Fac.Id_Factura.ToString(), "Id_Factura", 1, "Error al agregar el apunte en Contawin a traves de las librerias", id_log, 0, 0, "");
                return 0;
            }

            //CREAMOS EL REGISTRO DEL IVA
            var results = from p in Fac.Facturas_li
                          group p by p.Iva into g
                          select new
                          {
                              Id_Factura = g.Select(m => m.Facturas_ca.Id_Factura).ToList()[0],
                              Su_ref = g.Select(m => m.Facturas_ca.Su_ref).ToList()[0],
                              Proveedor = g.Select(m => m.Facturas_ca.Proveedor).ToList()[0],
                              Cif = g.Select(m => m.Facturas_ca.Cif).ToList()[0],
                              Base = g.Sum(m => m.Base),
                              Cuota = g.Sum(m => m.Cuota),
                              TotImporte = g.Sum(m => m.Importe),
                              Iva = g.Key,
                              Id_Obra = g.Select(m => m.Facturas_ca.Id_Obra).ToList()[0],
                              Fecha = g.Select(m => m.Facturas_ca.Fecha).ToList()[0],
                          };

            int cont = 0;
            foreach (var t in results)
            {

                //Creamos el registro de IVA SOPORTADO
                IvaSoportad.Conexion = Conta.Cn_CONTA;
                IvaSoportad.N_factura = t.Su_ref + "_" + cont.ToString();
                IvaSoportad.Cuenta_IVA = ApunteIVASoportado.Id_Cuenta;
                IvaSoportad.Cuenta_Total = ApunteProvee.Id_Cuenta;
                IvaSoportad.Cuenta_Base = ApunteCompra.Id_Cuenta;
                IvaSoportad.Titular = t.Proveedor;
                IvaSoportad.Cif = t.Cif;
                IvaSoportad.Base = Convert.ToDouble(t.Base);
                IvaSoportad.Importe = Convert.ToDouble(t.TotImporte);
                IvaSoportad.IVA_porcentaje = t.Iva;
                IvaSoportad.Cuota = Convert.ToDouble(t.Cuota);
                IvaSoportad.asiento = NumeroAsiento;
                IvaSoportad.Canal = t.Id_Obra;
                IvaSoportad.fecha = t.Fecha;
                IvaSoportad.TipoIVA = Convert.ToInt32(Conta.CW_TipoIvaContaWIN(Conta.Cn_CONTA2, 206, t.Iva));
                IvaSoportad.ndato340_1 = 1;
                IvaSoportad.sTipo340 = "I";
                IvaSoportad.NO347 = 0;

                //Creamos el registro de IVA REPERCUTIDO


                IvaRepercutido.Conexion = Conta.Cn_CONTA;
                IvaRepercutido.N_factura = t.Su_ref + "_" + cont.ToString();
                IvaRepercutido.Cuenta_IVA = ApunteIVARepercutido.Id_Cuenta;
                IvaRepercutido.Cuenta_Total = ApunteProvee.Id_Cuenta;
                IvaRepercutido.Cuenta_Base = ApunteCompra.Id_Cuenta;
                IvaRepercutido.Titular = t.Proveedor;
                IvaRepercutido.Cif = t.Cif;
                IvaRepercutido.Base = Convert.ToDouble(t.Base);
                IvaRepercutido.Importe = Convert.ToDouble(t.TotImporte);
                IvaRepercutido.IVA_porcentaje = t.Iva;
                IvaRepercutido.Cuota = Convert.ToDouble(t.Cuota);
                IvaRepercutido.asiento = NumeroAsiento;
                IvaRepercutido.fecha = t.Fecha;
                IvaRepercutido.TipoIVA = Convert.ToInt32(Conta.CW_TipoIvaContaWIN(Conta.Cn_CONTA2, 206, t.Iva));
                IvaRepercutido.canal = t.Id_Obra;
                IvaRepercutido.ndato340_1 = 1;
                IvaRepercutido.sTipo340 = "I";
                IvaRepercutido.NO347 = 1;

                val = Conta.CW_AgregarIVASOPORTADO(IvaSoportad);
                if (val == false)
                {
                    Log_ErroresCN.Añadir(2, "Contabilizar Facturas", t.Id_Factura.ToString(), "Id_Factura", 1, "Error al agregar el apunte en Contawin a traves de las librerias", id_log,0, 0, "");
                    return 0;
                }

                val = Conta.CW_AgregarIVAREPERCUTIDO(IvaRepercutido);
                if (val == false)
                {
                    Log_ErroresCN.Añadir(2, "Contabilizar Facturas", t.Id_Factura.ToString(), "Id_Factura", 1, "Error al agregar el apunte en Contawin a traves de las librerias", id_log, 0, 0, "");
                    return 0;
                }
                cont++;
            }
            return Convert.ToInt32(NumeroAsiento);
        }
        public static int Factura_Normal(Facturas_ca Fac, string id_log, Empresas Empresa)
        {
            long NumeroAsiento = 0;
            bool val = false;
            string Cuentaprovee;
            M_Contawin.IvaSoportado IvaSoportad = new M_Contawin.IvaSoportado();
            M_Contawin.Apunte ApunteIVA = new M_Contawin.Apunte();
            M_Contawin.Apunte ApunteProvee = new M_Contawin.Apunte();
            M_Contawin.Apunte ApunteCompra = new M_Contawin.Apunte();
            List<M_Contawin.Apunte> ApuntesCompra = new List<M_Contawin.Apunte>();
            M_Contawin Conta = new M_Contawin(Empresa.CNNWIN);

            //Comprobamos si estan todos los CIF en ContaWin
            Cuentaprovee = Conta.CW_Traecuenta_por_cif(Conta.Cn_CONTA2, Fac.Cif);
            if (Cuentaprovee == null)
            {
                if (Provees.FindAll(p => p == Fac.Cif + " -" + Fac.Proveedor).ToList().Count == 0) Provees.Add(Fac.Cif + " -" + Fac.Proveedor);
                return 0;
            }

            NumeroAsiento = Conta.CW_ProximoAsiento(Conta.Cn_CONTA, Fac.Fecha.Year);
            if (NumeroAsiento == 0)
            {
                Log_ErroresCN.Añadir(2, "Contabilizar Facturas", Fac.Id_Factura.ToString(), "Id_Factura", 1, "Error al agregar el apunte en Contawin a traves de las librerias", id_log,0,0,"");
                return 0;
            }

            //Agrupos las lineas de la factura en funcion de a que cuenta de compras va
            var ApuntesCompras = from p in Fac.Facturas_li
                                 group p by p.Tipo_Cuenta into g
                                 select new
                                 {
                                     Su_ref = g.Select(m => m.Facturas_ca.Su_ref).ToList()[0],
                                     Base = g.Sum(m => m.Base),
                                     Id_Obra = g.Select(m => m.Facturas_ca.Id_Obra).ToList()[0],
                                     Fecha = g.Select(m => m.Facturas_ca.Fecha).ToList()[0],
                                     Tipo_cuenta = g.Key
                                 };

            //Agregamos un apunte de compra por cada compra 
            foreach (var apunt in ApuntesCompras)
            {
                // APUNTE COMPRA
                ApunteCompra.Conexion = Conta.Cn_CONTA;
                ApunteCompra.asiento = NumeroAsiento;
                ApunteCompra.Id_Cuenta = apunt.Tipo_cuenta + Empresa.Cod_Contable + "00000"; //
                ApunteCompra.Importe = Convert.ToDouble(apunt.Base);
                ApunteCompra.TipoImporte = Contawin2009.TipoImporte.Debe;
                ApunteCompra.Descripcion = "Fra Nº " + Fac.Su_ref + " " + Fac.Proveedor;
                ApunteCompra.fecha = apunt.Fecha;
                ApunteCompra.AñoEjercicio = apunt.Fecha.Year;
                ApunteCompra.Referencia = apunt.Su_ref;
                ApunteCompra.Canal = apunt.Id_Obra;
                ApunteCompra.TipoDOC = 0;
                ApuntesCompra.Add(ApunteCompra);
            }

            // APUNTE IVA
            ApunteIVA.Conexion = Conta.Cn_CONTA;
            ApunteIVA.asiento = NumeroAsiento;
            ApunteIVA.Id_Cuenta = (Empresa.Id_Empresa == 9) ? "4726500000" : "472" + Empresa.Cod_Contable + "00000"; 
            ApunteIVA.Importe = Convert.ToDouble(Fac.Cuota);
            ApunteIVA.TipoImporte = Contawin2009.TipoImporte.Debe;
            ApunteIVA.Descripcion = "Fra Nº " + Fac.Su_ref + " " + Fac.Proveedor;
            ApunteIVA.fecha = Fac.Fecha;
            ApunteIVA.AñoEjercicio = Fac.Fecha.Year;
            ApunteIVA.Referencia = Fac.Su_ref;
            ApunteIVA.Canal = Fac.Id_Obra;
            ApunteIVA.TipoDOC = 0;

            // APUNTE PROVEEDOR
            ApunteProvee.Conexion = Conta.Cn_CONTA;
            ApunteProvee.asiento = NumeroAsiento;
            ApunteProvee.Id_Cuenta = Cuentaprovee;  //CW_CrearCuentas("Compras", USU._Id_estacion, Albaran.Item("Id_producto"));
            ApunteProvee.Importe = Convert.ToDouble(Fac.TotImporte);
            ApunteProvee.TipoImporte = Contawin2009.TipoImporte.Haber;
            ApunteProvee.Descripcion = "Fra Nº " + Fac.Su_ref + " " + Fac.Proveedor;
            ApunteProvee.fecha = Fac.Fecha;
            ApunteProvee.AñoEjercicio = Fac.Fecha.Year;
            ApunteProvee.Referencia = Fac.Su_ref;
            ApunteProvee.Canal = Fac.Id_Obra;
            ApunteProvee.TipoDOC = 0;

            //AGREGAMOS CON LAS LIBRERIAS LOS APUNTES
            //agregamos los apuntes de compra
            foreach (M_Contawin.Apunte ApunteComp in ApuntesCompra)
            {
                val = Conta.CW_AgregaApunte(ApunteComp);
                if (val == false)
                {
                    Log_ErroresCN.Añadir(2, "Contabilizar Facturas", Fac.Id_Factura.ToString(), "Id_Factura", 1, "Error al agregar el apunte en Contawin a traves de las librerias", id_log, 0, 0, "");
                    return 0;
                }
            }
            //agregamos el apunte de iva
            val = Conta.CW_AgregaApunte(ApunteIVA);
            if (val == false)
            {
                Log_ErroresCN.Añadir(2, "Contabilizar Facturas", Fac.Id_Factura.ToString(), "Id_Factura", 1, "Error al agregar el apunte en Contawin a traves de las librerias", id_log, 0, 0, "");
                return 0;
            }
            //agregamos el apunte del proveedor
            val = Conta.CW_AgregaApunte(ApunteProvee);
            if (val == false)
            {
                Log_ErroresCN.Añadir(2, "Contabilizar Facturas", Fac.Id_Factura.ToString (), "Id_Factura", 1, "Error al agregar el apunte en Contawin a traves de las librerias", id_log, 0, 0, "");
                return 0;
            }

            //CREAMOS EL REGISTRO DEL IVA
            var results = from p in Fac.Facturas_li
                          group p by p.Iva into g
                          select new
                          {
                              Id_Factura = g.Select(m => m.Facturas_ca.Id_Factura).ToList()[0],
                              Su_ref = g.Select(m => m.Facturas_ca.Su_ref).ToList()[0],
                              Proveedor = g.Select(m => m.Facturas_ca.Proveedor).ToList()[0],
                              Cif = g.Select(m => m.Facturas_ca.Cif).ToList()[0],
                              Base = g.Sum(m => m.Base),
                              Cuota = g.Sum(m => m.Cuota),
                              TotImporte = g.Sum(m => m.Importe),
                              Iva = g.Key,
                              Id_Obra = g.Select(m => m.Facturas_ca.Id_Obra).ToList()[0],
                              Fecha = g.Select(m => m.Facturas_ca.Fecha).ToList()[0],
                          };

            int cont = 0;
            foreach (var t in results)
            {

                //Creamos el registro de IVA
                IvaSoportad.Conexion = Conta.Cn_CONTA;
                IvaSoportad.N_factura = t.Su_ref + "_" + cont.ToString();
                IvaSoportad.Cuenta_IVA = ApunteIVA.Id_Cuenta;
                IvaSoportad.Cuenta_Total = ApunteProvee.Id_Cuenta;
                IvaSoportad.Cuenta_Base = ApunteCompra.Id_Cuenta;
                IvaSoportad.Titular = t.Proveedor;
                IvaSoportad.Cif = t.Cif;
                IvaSoportad.Base = Convert.ToDouble(t.Base);
                IvaSoportad.Importe = Convert.ToDouble(t.TotImporte);
                IvaSoportad.IVA_porcentaje = t.Iva;
                IvaSoportad.Cuota = Convert.ToDouble(t.Cuota);
                IvaSoportad.asiento = NumeroAsiento;
                IvaSoportad.Canal = t.Id_Obra;
                IvaSoportad.fecha = t.Fecha;
                IvaSoportad.TipoIVA = Convert.ToInt32(Conta.CW_TipoIvaContaWIN(Conta.Cn_CONTA2, 200, t.Iva));

                val = Conta.CW_AgregarIVASOPORTADO(IvaSoportad);
                if (val == false)
                {
                    Log_ErroresCN.Añadir(2, "Contabilizar Facturas", t.Id_Factura.ToString(), "Id_Factura", 1, "Error al agregar el apunte en Contawin a traves de las librerias", id_log, 0, 0, "");
                    return 0;
                }
                cont++;
            }


            return Convert.ToInt32(NumeroAsiento);
        }     
        public static void Añadir(Facturas_ca factura)
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            db.Facturas_ca.Add(factura);
            db.SaveChanges();
        }        
        public static void CambiarGrupo(int id_Obra, int id_grupo, int? id_subgrupo,Facturas_li linea)
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            Facturas_li  Line = db.Facturas_li.Where(p => p.Id_fac_li == linea.Id_fac_li).ToList()[0];
            Line.Id_grupo = id_grupo;
            var a = (id_subgrupo == null) ? Line.id_subgrupo =0 : Line.id_subgrupo = id_subgrupo;
            db.SaveChanges();

        }
        public static Facturas_ca Listar(int id)
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            return db.Facturas_ca.SingleOrDefault<Facturas_ca>(p => p.Id_Factura == id);
        }
        public static List<Aux_PrefCuentas> ListarAuxPrefijos()
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            return db.Aux_PrefCuentas.ToList();
        }
        public static Facturas_ca Cambiar_estado(int id,DateTime fechanueva)
        {
         
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            Facturas_ca fac = db.Facturas_ca.SingleOrDefault<Facturas_ca>(p => p.Id_Factura == id);
            if (fac != null)
            {
                fac.Fecha = fechanueva;             
                db.SaveChanges();
                return fac;
            }
            return null;
        }

        public static Facturas_ca Cambiar_estado(int id, int estado, int apuntecompra)
        {
            // 0= Facturado
            // 1= Pagado
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            Facturas_ca fac = db.Facturas_ca.SingleOrDefault<Facturas_ca>(p => p.Id_Factura == id);
            if (fac != null)
            {
                fac.Estado = estado;
                if (estado == 0) fac.ApunteCompra = apuntecompra;
                db.SaveChanges();
                return fac;
            }
            return null;
        }
        public static Facturas_ca AñadirMetodoPago(int id, int id_pago, DateTime Fechapago)
        {
            // 0= Facturado
            // 1= Pagado
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            Facturas_ca fac = db.Facturas_ca.SingleOrDefault<Facturas_ca>(p => p.Id_Factura == id);
            if (fac != null)
            {
                fac.Id_Formapago = id_pago;
                fac.FechaPago = Fechapago;
                db.SaveChanges();
                return fac;
            }
            return null;
        }
        public static List<Facturas_ca> Sort(string column, string sortOrder, List<Facturas_ca> list)
        {
            switch (column.ToUpper())
            {
                case "FECHA":
                    {
                        if (sortOrder == "Ascending")
                        {
                            return list.OrderBy(x => x.Fecha).ToList();

                        }
                        else
                        {
                            return list.OrderByDescending(x => x.Fecha).ToList();
                        }

                    }
                case "DOCUMENTO":
                    {
                        if (sortOrder == "Ascending")
                        {
                            return list.OrderBy(x => x.Ref_Fac).ToList();

                        }
                        else
                        {
                            return list.OrderByDescending(x => x.Ref_Fac).ToList();
                        }

                    }
                case "PROVEEDOR":
                    {
                        if (sortOrder == "Ascending")
                        {
                            return list.OrderBy(x => x.Proveedor).ToList();

                        }
                        else
                        {
                            return list.OrderByDescending(x => x.Proveedor).ToList();
                        }

                    }
                case "CIF":
                    {
                        if (sortOrder == "Ascending")
                        {
                            return list.OrderBy(x => x.Cif).ToList();

                        }
                        else
                        {
                            return list.OrderByDescending(x => x.Cif).ToList();
                        }

                    }
                case "IMPORTE":
                    {
                        if (sortOrder == "Ascending")
                        {
                            return list.OrderBy(x => x.TotImporte).ToList();

                        }
                        else
                        {
                            return list.OrderByDescending(x => x.TotImporte).ToList();
                        }

                    }

            }
            return list;

        }



    }
}
