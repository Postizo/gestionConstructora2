using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Threading.Tasks;
using Entidad;
using Datos;
using Excel =Microsoft.Office.Interop.Excel;


namespace Negocio
{
  public class Log_ErroresCN
    {
        public static Log_Errores Añadir(int Id_Proceso, string Proceso,string id_item, string item,int tipo_error, string descripcion,string id_log,int id_empresa,int id_obra,string nombreobra)
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            Log_Errores log = new Log_Errores();
            log.Id_Proceso = Id_Proceso;
            log.Proceso = Proceso;
            log.Id_Item = id_item;
            log.Item  = item ;
            log.Tipo_error = tipo_error;
            log.Descripcion = descripcion;
            log.id_Log = id_log;
            log.id_empresa = id_empresa;
            log.Id_Obra = id_obra;
            log.NombreObra = nombreobra;
            log.Color = "";
            db.Log_Errores.Add(log);
            db.SaveChanges();
            return log;
        }
        public static List<Log_Errores> Listar_logs(string id_log, int id_proceso, int id_error)
        {
            GestionConstructoraEntities db = new GestionConstructoraEntities();
            return db.Log_Errores.Where(p => p.id_Log == id_log && p.Id_Proceso == id_proceso && p.Tipo_error == id_error).ToList();
        }
        public static string ConstruirMensajeMail(string id_log, int id_proceso, int id_error,string encabezado)
        {
            string mensaje = "";
            List<Log_Errores> Logs = Listar_logs(id_log, id_proceso, id_error);
            var Logsfilt = from p in Logs
                           group p by new { p.Id_Item, p.Id_Obra } into g
                           select new Log_Errores
                           {
                               Id_Item = g.Key.Id_Item,
                               Id_Obra = g.Key.Id_Obra,                                                          
                               NombreObra  = g.Select(m => m.NombreObra).ToList()[0],
                               Descripcion = g.Select(m => m.Descripcion).ToList()[0], 
                               Proceso = g.Select(m => m.Proceso).ToList()[0],
                           };

            foreach (Log_Errores log  in Logsfilt)
            {
                mensaje += "<tr><td>" + log.Id_Obra + "</td>" + "<td>" + log.NombreObra + "</td>" + "<td>" + log.Proceso + "</td>" + "<td>" + log.Descripcion + "</td>" + "<td>" + log.Id_Item + "</td></tr>";
            }
            if (Logs.Count == 0) mensaje = string.Empty;
            return mensaje;
        }
        public static void ENvioMail(string id_log)
        {
            //ENVIO DE MAILS DE FACTRAS CON ERRORES 
            string MensajeAdministrativo;
            MensajeAdministrativo = "<html><body><table border='1'><tr><th>Id Obra</th><th>Obra</th><th>Proceso</th><th>Descripcion</th><th>Codigo_Ref</th></tr>";
            MensajeAdministrativo += Log_ErroresCN.ConstruirMensajeMail(id_log, 1, 0, "");
            MensajeAdministrativo += Log_ErroresCN.ConstruirMensajeMail(id_log, 1, 1, "");
            MensajeAdministrativo += Log_ErroresCN.ConstruirMensajeMail(id_log, 1, 3, "");
            MensajeAdministrativo += Log_ErroresCN.ConstruirMensajeMail(id_log, 3, 0, "");
            MensajeAdministrativo += Log_ErroresCN.ConstruirMensajeMail(id_log, 3, 3, "");
            MensajeAdministrativo += Log_ErroresCN.ConstruirMensajeMail(id_log, 4, 0, "");
            MensajeAdministrativo += Log_ErroresCN.ConstruirMensajeMail(id_log, 5, 1, "");
            MensajeAdministrativo += "</table></body></html>";
            string[] mails = "ignacio@avillanueva.com".Split(Convert.ToChar(";"));
            foreach (string mail in mails)
            {
                Log_ErroresCN.EnviarMail("informatica@avillanueva.com", "informatica@avillanueva.com", 25, "ferrita123%", "smtpparla.spamina.com", mail, "PROCESO DIARIO: " + DateTime.Now.ToString(), MensajeAdministrativo);
            }

            //ENVIO DE MAILS DE FACTRAS CON ERRORES MIOS  
            string Mensajeadmin = Log_ErroresCN.ConstruirMensajeMail(id_log, 1, 4, "<br/> Las siguientes Facturas han producido el siguiente error:<br/>");
            string[] mailsadmin = "ignacio@avillanueva.com".Split(Convert.ToChar(";"));
            foreach (string mail in mailsadmin)
            {
                Log_ErroresCN.EnviarMail("informatica@avillanueva.com", "informatica@avillanueva.com", 25, "ferrita123%", "smtpparla.spamina.com", mail, "PROCESO DIARIO: " + DateTime.Now.ToString() , Mensajeadmin);
            }
        }
        public static void CapitulosSigridFaltarelacion(Obras Obr, string id_log )
        {
            //OBRAS_LINEAS
            List<string> Lienafalta = Obr.Obras_Lineas.Where(p => p.Id_Grupo == 163 && (p.Importe_presu !=0 || p.Importe_P_venta != 0 || p.Importe_CostePrevisto  != 0 || p.Importe_VentaPrevista  != 0 || p.Importe_CosteReal  != 0 || p.Importe_Certificado != 0)).GroupBy(p => p.Capitulo).Select(a => a.Key).ToList();
            foreach (string linea in Lienafalta)
            {
                Log_ErroresCN.Añadir(5, "Importacion General-Lineas", linea, "Importacion General", 1, "NO existe relacion con el capitulo:" + linea + "", id_log, Obr.Id_Empresa, Obr.Id_Obra, Obr.Nombre);
            }
            //FACTURAS
            var LineasFacturas = from b in Obr.Facturas_ca
                                 from c in b.Facturas_li
                                 where b.Id_Factura == c.Id_Factura && c.Id_grupo == 163
                                 select c;
            foreach (var linea in LineasFacturas.ToList())
            {
                Facturas_li l = (Facturas_li)linea;
                Log_ErroresCN.Añadir(5, "Importacion General-Facturas", l.Cap_sigrid , "Importacion General", 1, "NO existe relacion con el capitulo:" + l.Cap_sigrid + "", id_log, Obr.Id_Empresa, Obr.Id_Obra, Obr.Nombre);
            }
            //ALBARANES
            var LineasAlbaranes = from b in Obr.Albaranes_ca 
                                 from c in b.Albaran_li
                                 where b.Id_Albaran  == c.Id_Albaran  && c.Id_grupo == 163
                                 select c;
            foreach (var linea in LineasAlbaranes.ToList())
            {
                Albaran_li l = (Albaran_li)linea;
                Log_ErroresCN.Añadir(5, "Importacion General-Albaranes", l.Cap_sigrid ,"Importacion General", 1, "NO existe relacion con el capitulo:" + l.Cap_sigrid + "", id_log, Obr.Id_Empresa, Obr.Id_Obra, Obr.Nombre);
            }

            //PARTES
            List<string> LineaPartes = Obr.ParteTrabajo.Where(p => p.Id_Grupo == 163).GroupBy(p => p.Cap_Sigrid).Select(a => a.Key).ToList();
            foreach (string linea in LineaPartes)
            {
                Log_ErroresCN.Añadir(5, "Importacion General-Partes", linea, "Importacion General", 1, "NO existe relacion con el capitulo:" + linea + "", id_log, Obr.Id_Empresa, Obr.Id_Obra, Obr.Nombre);
            }




        }
        public  static void EnviarMail(string Correo, string Nombre, int Puerto, string Pass, string Host, string Destino, string Asunto, string Cuerpo, List<string> Adjuntos = null)
        {
            System.Net.Mail.MailMessage _Message = new System.Net.Mail.MailMessage();
            System.Net.Mail.SmtpClient _SMTP = new System.Net.Mail.SmtpClient();

            //CONFIGURACIÓN DEL STMP
            _SMTP.Credentials = new System.Net.NetworkCredential(Correo, Pass);
            _SMTP.Host = Host;
            _SMTP.Port = Puerto;
            _SMTP.EnableSsl = false;

            // CONFIGURACION DEL MENSAJE
            _Message.To.Add(Destino);
            //Cuenta de Correo al que se le quiere enviar el e-mail
            _Message.From = new System.Net.Mail.MailAddress(Correo, Nombre, System.Text.Encoding.UTF8);
            //Quien lo envía
            _Message.Subject = Asunto;
            //Sujeto del e-mail
            _Message.SubjectEncoding = System.Text.Encoding.UTF8;
            //Codificacion
            _Message.Body = Cuerpo;
            //contenido del mail
            _Message.BodyEncoding = System.Text.Encoding.UTF8;
            _Message.Priority = System.Net.Mail.MailPriority.Normal;
            _Message.IsBodyHtml = true;

            if (Adjuntos != null)
            {
                foreach (string Adjunto in Adjuntos)
                {
                    _Message.Attachments.Add(new System.Net.Mail.Attachment(Adjunto));
                }
            }

            //ENVIO

            try
            {
                _SMTP.Send(_Message);
                //  MessageBox.Show("Mensaje enviado correctamene", "Exito!", MessageBoxButtons.OK)
            }
            catch (System.Net.Mail.SmtpException ex)
            {
                Añadir(0, "Procesos internos", "", "Envio Mail", 0, "No ha podido envia este mail: " + Asunto, "",0,0,"");
            }
        }
        public static void ExportToExcel(System.Data.DataTable dt, string fileName, string sheetName)
        {
            // Verificamos los parámetros pasados
            //
            if (((dt == null) || (string.IsNullOrEmpty(fileName)) || (string.IsNullOrEmpty(sheetName))))
                throw new ArgumentNullException();

            Excel.Application app = null;
            Excel.Workbook book = null;
            Excel.Worksheet sheet = new Excel.Worksheet();

            try
            {
                // Referenciamos la aplicación Excel.
                //
                app = new Excel.Application();

                // Abrimos el libro de trabajo.
                //
                book = app.Workbooks.Add();

                // Referenciamos la hoja de cálculo del libro.
                //
                sheet = (Excel.Worksheet)book.Sheets[1];

                var _with1 = sheet;
                // Limpiamos el contenido de toda la hoja.
                //
                _with1.Cells.Select();
                _with1.Cells.ClearContents();

                // Seleccionamos la primera celda de la hoja.
                //
                _with1.Range["A1"].Select();

                // Escribimos los nombres de las columnas en la primera
                // celda de la primera fila de la hoja de cálculo
                //
                int fila = 1;
                int columna = 1;

                foreach (DataColumn dc in dt.Columns)
                {
                    _with1.Cells[fila, columna] = dc.ColumnName;
                    columna += 1;
                }

                // Establecemos los atributos de la fuente para las
                // celdas de la primera fila.
                //
                var _with2 = _with1.Range[_with1.Cells[1, 1], _with1.Cells[1, dt.Columns.Count]].Font;
                _with2.Name = "Calibri";
                _with2.Size = 12;

                // Insertamos los datos en la hoja de cálculo, comenzando por la
                // fila número 2, ya que la primera fila está ocupada
                // por el nombre de las columnas.
                //
                fila = 2;


                foreach (DataRow row in dt.Rows)
                {
                    // Primera columna
                    columna = 1;

                    foreach (DataColumn dc in dt.Columns)
                    {
                        _with1.Cells[fila, columna] = row[dc.ColumnName];

                        // Siguiente columna
                        columna += 1;
                    }

                    // Siguiente fila
                    fila += 1;

                }

                // Autoajustamos el ancho de todas las columnas utilizadas.
                //
                _with1.Columns.AutoFit();

                book.SaveAs(fileName);
            }
            catch (Exception ex)
            {
                // Se ha producido una excepción;
                // indicamos que el libro ha sido guardado.

                if ((book != null))
                {
                    book.Saved = true;
                }
                // Devolvemos la excepción al procedimiento llamador
                throw;

            }
            finally
            {
                sheet = null;

                if ((book != null))
                {
                    // Si procede, guardamos el libro de trabajo.
                    if ((!(book.Saved)))
                        book.Save();
                    // Cerramos el libro de Excel.
                    book.Close();
                }
                book = null;

                if ((app != null))
                {
                    // Si procede, cerramos Excel y disminuimos el recuento
                    // de referencias al objeto Excel.Application.
                    app.Quit();
                    while ((System.Runtime.InteropServices.Marshal.ReleaseComObject(app) > 0))
                    {
                        // Sin implementación.
                    }
                }
                app = null;

            }
        }

    }
}
