using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidad;
using Negocio;
using System.IO;
using System.Configuration;

namespace AutomaticosConstructora
{
    public partial class Form1 : Form
    {
        int Errores =0;
        int Vuelta=0;
        public Form1()
        {
            InitializeComponent();   
        }
        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (DateTime.Today.DayOfWeek == DayOfWeek.Sunday || DateTime.Today.DayOfWeek == DayOfWeek.Saturday) PROCESOS_PRINCIPALES(true); else PROCESOS_PRINCIPALES(false);
        }
        private  void Procesosinfase()
        {
            ListBox1.Items.Add(DateTime.Now.ToString() + " Sin Fases");
            List<Empresas> L_empresas = EmpresasCN.Listar().ToList().ToList();
            foreach (Empresas Empresa in L_empresas.ToList())
            {
                Guid id_infr = new Guid();
                id_infr = Guid.NewGuid();

                foreach (Obras Obr in Empresa.Obras.Where(p => p.Id_Sigrid != 0 && p.Finalizada == false && p.Id_Obra == 56).ToList())
                {
                    if (Obr.Importado_presu == false) continue;
                    AlbaranesCN.Borrar_Albaranres(Empresa.Id_Empresa, Obr.Id_Obra);
                    FacturasCN.Import_Facturas(Obr, id_infr.ToString(), Empresa);
                    AlbaranesCN.Import_Albaranes(Obr, id_infr.ToString(), Empresa);
                    PartesTrabajoCN.Import_PartesTrabajo(Obr, id_infr.ToString(), Empresa);
                    ObraCN.Borrar_Lineas_Obra(Obr);
                    Obras ObrActu = ObraCN.Listar(Obr.Id_Obra, Empresa.Id_Empresa);
                    ObrActu.PREPARAOBRA();
                    ObrActu.Obras_Lineas = ImportacionCN.Importacion_Presupuesto(ObrActu,false);
                    ImportacionCN.ImportesFactus(ObrActu);
                    ObraCN.Añadir_lineas(ObrActu, ObrActu.Obras_Lineas.ToList());
                    Log_ErroresCN.CapitulosSigridFaltarelacion(ObrActu, id_infr.ToString());
                }
                Log_ErroresCN.ENvioMail(id_infr.ToString());
            }
        }
        private void Procesosconfasefase()
        {
            ListBox1.Items.Add(DateTime.Now.ToString() + " Con Fases");
            List<Empresas> L_empresas = EmpresasCN.Listar().ToList().ToList();
            foreach (Empresas Empresa in L_empresas.ToList())
            {
                Guid id_infr = new Guid();
                id_infr = Guid.NewGuid();

                foreach (Obras Obr in Empresa.Obras.Where(p => p.Id_Sigrid != 0 && p.Finalizada == false && p.Id_Obra ==56).ToList())
                {
                    if (Obr.Importado_presu == false) continue;
                    AlbaranesCN.Borrar_Albaranres(Empresa.Id_Empresa, Obr.Id_Obra);
                    FacturasCN.Import_Facturas(Obr, id_infr.ToString(), Empresa);
                    AlbaranesCN.Import_Albaranes(Obr, id_infr.ToString(), Empresa);
                    PartesTrabajoCN.Import_PartesTrabajo(Obr, id_infr.ToString(), Empresa);
                    ObraCN.Borrar_Lineas_ObraTodas(Obr);
                    Obras ObrActu = ObraCN.Listar(Obr.Id_Obra, Empresa.Id_Empresa);
                    ObrActu.PREPARAOBRA();
                    ObrActu.Obras_Lineas = ImportacionCN.Importacion_Presupuesto(ObrActu,true);
                    ImportacionCN.ImportesFactus(ObrActu);
                    ObraCN.Añadir_lineas(ObrActu, ObrActu.Obras_Lineas.ToList());
                    Log_ErroresCN.CapitulosSigridFaltarelacion(ObrActu, id_infr.ToString());
                }
                Log_ErroresCN.ENvioMail(id_infr.ToString());
            }
        }

        private void Procesoprincipal_1(bool confases)
        {
            try
            {
                LPrincipal.Text = "Proceso Principal";
                Refreslabel();
                // Principal que cogemos de su modulo
                ListBox1.Items.Add(DateTime.Now.ToString() + " 1-Proceso Principal");
                if (confases)  Procesosconfasefase();  else Procesosinfase(); 
                lfacturas.ForeColor = Color.Green;
                lfacturas.Refresh();
              
                ListBox1.Refresh();
            }
            catch (Exception ex)
            {
                Errores += 1;                
                lfacturas.ForeColor = Color.Red;
            }
          
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            PictureBox1.Image = Properties.Resources.Clock1;           
            timer2.Start();
           
        }


        private void Button2_Click(object sender, EventArgs e)
        {
            if (DateTime.Today.DayOfWeek == DayOfWeek.Sunday || DateTime.Today.DayOfWeek == DayOfWeek.Saturday) PROCESOS_PRINCIPALES(true); else PROCESOS_PRINCIPALES(false);
            bttprimerinicio.Enabled = false;
        }

        private void Timer2_Tick(object sender, EventArgs e)
        {
            bttprimerinicio.PerformClick();
            timer2.Stop();
        }             
      
        public void PROCESOS_PRINCIPALES(bool confases)
        {
            // ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            // '''''''''''''''''''''''''''INICIO'''''''''''''''''''''''''''''
            // ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Activar_Botones(false, Panel4);
            ListBox1.Items.Add(DateTime.Now.ToString() + " INICIO PROCESO  " + Vuelta);
            ListBox1.Refresh();
            timer1.Stop();
            lUltima.Text = DateTime.Now.ToString();
            lproxima.Text = "Ejecutando";
            PictureBox1.Visible = false;
            ColoresLabel(Color.Black, Panel1);
            Refreslabel();
            // '''''''''''''''''''''1-CREACION''''''''''''''''''''
            Procesoprincipal_1(confases);                

            // ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            // '''''''''''''''''''''''''''FIN''''''''''''''''''''''''''''''''
            // ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Activar_Botones(true, Panel4);
            bttparar.Enabled = true;
            lerrores.Text = Errores.ToString() + " en Procesos";
            LPrincipal.Text = "Esperando";
            PictureBox1.Visible = true;
            ListBox1.Items.Add(DateTime.Now.ToString() + " FIN PROCESO  " + Vuelta);
            Vuelta += 1;
            Lvueltas.Text = "Proceso ejecutado " + Vuelta.ToString() + " veces";
            ListBox1.Refresh();
            lproxima.Text = DateTime.Now.AddMilliseconds(timer1.Interval).ToString();
            timer1.Start();
        }
        private void Button3_Click(object sender, EventArgs e)
        {
            if (LPrincipal.Text == "Parado")
            {
                timer1.Start();
                lproxima.Text = DateTime.Now.AddMilliseconds(timer1.Interval).ToString();
                Refreslabel();
                LPrincipal.Text = "Esperando";
                Activar_Botones(false, Panel1);
                ColoresLabel(Color.Black, Panel1);
                bttparar.Text = "Parar Automatico";
                PictureBox1.Image =  Properties.Resources.Clock1;

                return;
            }
            if (LPrincipal.Text == "Esperando")
            {
                timer1.Stop();
                LPrincipal.Text = "Parado";
                lUltima.Text = "Parado";
                lproxima.Text = "Parado";
                Refreslabel();
                Activar_Botones(true, Panel1);
                ColoresLabel(Color.Black, Panel1);
                bttparar.Text = "Reanudar Automatico";
                PictureBox1.Image = Properties.Resources.stop;
            }
        }
      

        public void Activar_Botones(bool activar, Panel panel)
        {
            foreach (Control Ctl in panel.Controls)
            {
                if ((Ctl) is Button)
                {
                    Button Control =(Button)Ctl;
                    Control.Enabled = activar;
                }
            }
        }
        public void ColoresLabel(Color color, Panel panel)
        {
            foreach (Control Ctl in panel.Controls)
            {                
                if ((Ctl) is Label)
                {
                    Label Control = (Label)Ctl;
                    Control.ForeColor = color;
                    Control.Refresh();
                }
            }
        }
        public void Refreslabel()
        {
            lUltima.Refresh();
            lproxima.Refresh();
            LPrincipal.Refresh();
        }

    }

}


