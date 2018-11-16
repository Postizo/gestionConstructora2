using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Entidad;
using Negocio;
using System.Drawing.Printing;
using System.Threading;
using System.Drawing.Imaging;

namespace GestionConstructora
{
    public partial class Form_Financiero : Form
    {
        Est_Financiero InformeSelec = new Est_Financiero();
        Decimal Forma;
        string nombre;
        public Form_Financiero(string nom)
        {
            InitializeComponent();
            nombre = nom;
            ltitulo.Text = "ESTUDIO FINANCIERO: " + nom.ToUpper();
            printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
        }
        public Form_Financiero(Est_Financiero Informe)
        {
            InitializeComponent();
            InformeSelec = Informe;
            CargarEstudio();
            printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
        }
        public void GuardarEstudio()
        {
            if (InformeSelec.Id_Estudio != 0)  Est_FinancieroCN.Borrar(InformeSelec.Id_Estudio);
            InformeSelec = new Est_Financiero();
            InformeSelec.Nombre = nombre;
            InformeSelec.Fini = fcompra.Value ;
            InformeSelec.Ffin = fventa.Value ;
            InformeSelec.mts_Construidos = Convert.ToInt32(txtmetrosTC.Text.Replace(".", ""));
            InformeSelec.mts_Utiles = Convert.ToInt32(txtmetrosutilesTC.Text.Replace(".", ""));
            InformeSelec.Compra_Bruto = Convert.ToDouble(txtcomprabruto.Text);
            InformeSelec.Gastos_Adquisicion = Convert.ToDouble(txtpergastoadq.Text.Replace("%",""));
            InformeSelec.CosteReforma = Convert.ToInt32(txtreforpreciosmts.Text.Replace(".", "")) ;
            InformeSelec.Impuestos = Convert.ToDouble(txtcomunes.Text);
            InformeSelec.Mantenimiento = Convert.ToDouble(txtmantenimientoanuales.Text) ;
            InformeSelec.AporCapital = Convert.ToInt32(txtperaportcapital.Text.Replace("%", "")) ;
            InformeSelec.ImpHipoteca = Convert.ToInt32(txtperimphipoteca.Text.Replace("%", ""));
            InformeSelec.TipoInteres = Convert.ToDouble(txttipointeres.Text.Replace("%", "")) ;
            InformeSelec.AñoAmortizacion = Convert.ToInt32(txtmesamortizacion.Text);
            InformeSelec.P_Venta = Convert.ToInt32(txtventametros.Text.Replace(".",""));
            InformeSelec.GastosVenta = Convert.ToDouble(txtgastosventas.Text);
            InformeSelec.Comentarios =  txtcomentarios.Text ;
            Est_FinancieroCN.Añadir(InformeSelec);
        }


        public void  CargarEstudio()
        {
            nombre  = InformeSelec.Nombre;
            ltitulo.Text = "ESTUDIO FINANCIERO: " + InformeSelec.Nombre.ToUpper();
            fcompra.Value = InformeSelec.Fini;
            fventa.Value = InformeSelec.Ffin;
            txtmetrosTC.Text = InformeSelec.mts_Construidos.ToString();
            txtmetrosutilesTC.Text = InformeSelec.mts_Utiles.ToString();
            txtcomprabruto.Text = InformeSelec.Compra_Bruto.ToString();
            txtpergastoadq.Text = InformeSelec.Gastos_Adquisicion.ToString("00.00");
            txtreforpreciosmts.Text = InformeSelec.CosteReforma.ToString();
            txtcomunes.Text = InformeSelec.Impuestos.ToString();
            txtmantenimientoanuales.Text = InformeSelec.Mantenimiento.ToString();
            txtperaportcapital.Text = InformeSelec.AporCapital.ToString();
            txtperimphipoteca.Text = InformeSelec.ImpHipoteca.ToString();
            txttipointeres.Text =  InformeSelec.TipoInteres.ToString("00.00");
            txtmesamortizacion.Text = InformeSelec.AñoAmortizacion.ToString();
            txtventametros.Text = InformeSelec.P_Venta.ToString();
            txtgastosventas.Text = InformeSelec.GastosVenta.ToString();
            txtcomentarios.Text = InformeSelec.Comentarios.ToString();
            PorcesCalcular();
        }
   
        public void CalcultaTIR()
        {            
            DataTable dt = new DataTable();
            dt.Columns.Add("Nombre", Type.GetType("System.String"));
            dt.Columns.Add("Importe", Type.GetType("System.Double"));

            //Fondos Iniciales
            DataRow Dr = dt.NewRow();
            Dr["Nombre"] = "Flujo de Caja Inicial";
            Dr["Importe"] =  (Convert.ToDouble(txtflujospropios.Text) - Convert.ToDouble(txtreforma.Text)) *-1 ;
            dt.Rows.Add(Dr);
            //De años
            double year = Math.Ceiling(Convert.ToDouble(Convert.ToInt32(txtmesdif.Text) / Convert.ToDouble(12)));
            int mes = 0;
            // Años totales
            for (int i = 0; i < year; i++)
            {
                int mesdeeste = 0;
                double impor = 0;
                Dr = dt.NewRow();
                Dr["Nombre"] = "Flujo de caja del año " + (i+1).ToString() ;               
                mesdeeste = (Convert.ToInt32(txtmesdif.Text) - mes < 12) ? (Convert.ToInt32(txtmesdif.Text) - mes):12;               
                if (i == 0) impor = Convert.ToDouble(txtreforma.Text);

                impor += ((Convert.ToDouble(txtcomunes.Text) / Convert.ToDouble(txtmesdif.Text)) * mesdeeste);
                impor += ((Convert.ToDouble(txtmantenimientoanuales.Text) / Convert.ToDouble(12)) * mesdeeste);
                impor += calculoitereses(mes, mes + mesdeeste);
                impor += calculocuotapasgadas(mes, mes + mesdeeste);
                Dr["Importe"] = impor * -1;

                mes += 12;
                dt.Rows.Add(Dr);
            }

            //Fondos Finales
            Dr = dt.NewRow();
            Dr["Nombre"] = "FCVTA";
            Dr["Importe"] = Convert.ToDouble(txtventa.Text) - Convert.ToDouble(txthipotecapendiente.Text) - Convert.ToDouble(txtgastosventas.Text);
            dt.Rows.Add(Dr);
            int e = dt.Rows.Count;
            int x = 0;
            double[] c = new double [e];
            foreach (DataRow r in dt.Rows)
            {
                c[x] =Math.Round(Convert.ToDouble(r["Importe"]),2);
                x++;
            }
            double IRRValue = ContaWIN.M_Finan.P_IRR(ref c);
            ltir.Text = "TIR : " +  IRRValue.ToString() + "%";
            ltir2.Text = "TIR : " + IRRValue.ToString() + "%";
            dataGridView1.DataSource = dt;
           
        }
  
        public DataTable  TablaAmortizacion(double Cantidad_del_prestamo, double tasa_interes_anual,int Plazo)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("N", typeof(Int32));
            dt.Columns.Add("Cuota", Type.GetType("System.Double"));
            dt.Columns.Add("Capital", Type.GetType("System.Double"));
            dt.Columns.Add("Intereses", Type.GetType("System.Double"));
            dt.Columns.Add("Saldo", Type.GetType("System.Double"));

            double pago, Interes_pagado, Capital_pagado, tasa_interes_mensual;
            int fila,  i;

            tasa_interes_mensual = (tasa_interes_anual / 100) / 12;

            //Calculo de la cuota mensual
            pago = tasa_interes_mensual + 1;
            pago = (float)Math.Pow(pago, Plazo);
            pago = pago - 1;
            pago = tasa_interes_mensual / pago;
            pago = tasa_interes_mensual + pago;
            pago = Cantidad_del_prestamo * pago;




            Console.WriteLine();
            fila = 1;
            Console.WriteLine();
            Console.WriteLine();
            Console.Write(" Numero de pago \t");
            Console.Write("Pago \t\t");
            Console.Write("Intereses Pagados \t\t");
            Console.Write("Capital Pagado \t\t");
            Console.Write("Monto del prestamo \t");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("\t0");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t{0}", Cantidad_del_prestamo);


            for (i = 1; i <= Plazo; i++)
            {
                DataRow dr = dt.NewRow();
                Console.Write("\t{0}\t\t", fila);                               
                Console.Write("{0}\t", pago);
                Interes_pagado = tasa_interes_mensual * Cantidad_del_prestamo;
                Console.Write("{0}\t\t", Interes_pagado);
                Capital_pagado = pago - Interes_pagado;
                Console.Write("\t{0}\t", Capital_pagado);
                Cantidad_del_prestamo = Cantidad_del_prestamo - Capital_pagado;
                Console.Write("\t{0}\t", Cantidad_del_prestamo);

                dr["N"] = fila ;
                dr["Cuota"] = pago;
                dr["Capital"] = Capital_pagado;
                dr["Intereses"] =  Interes_pagado;
                dr["Saldo"] = Cantidad_del_prestamo;
                fila = fila + 1;
                dt.Rows.Add(dr);
            }
          return dt;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            PorcesCalcular();
        }

        public void PorcesCalcular()
        {
            DataTable dt = new DataTable();
            dt = TablaAmortizacion(Convert.ToDouble(txtimphipoteca.Text), Convert.ToDouble(txttipointeres.Text.Replace("%", "")), Convert.ToInt32(txtmesamortizacion.Text) * 12);
            dgamortizacion.DataSource = dt;
            txtintereses.Text = calculoitereses(0, Convert.ToInt32(txtmesdif.Text)).ToString();
            jaj();
            
            txtingresoventa.Text = txtventa.Text;
            txthipotecapendiente.Text = Math.Round(Convert.ToDouble(dt.Rows[Convert.ToInt32(txtmesdif.Text) - 1]["Saldo"]), 0).ToString();
            txtcuotassatisfechas.Text = Math.Round(calculocuotapasgadas(0, Convert.ToInt32(txtmesdif.Text)), 2).ToString();
            txtflujospropios.Text = (Convert.ToDouble(txtaportcapital.Text) + Convert.ToDouble(txtGastoAqui.Text) + Convert.ToDouble(txtreforma.Text) + Convert.ToDouble(txttotalcartera.Text) + Convert.ToDouble(txtcuotassatisfechas.Text)).ToString();
           
            txtflujobruto.Text = (Convert.ToDouble(txtingresoventa.Text) - Convert.ToDouble(txtgastosventas.Text) - Convert.ToDouble(txthipotecapendiente.Text)).ToString();
            txtplusvalia.Text = (Convert.ToDouble(txtingresoventa.Text) - Convert.ToDouble(txttotalgastos.Text)).ToString();
            label23.Text = "Beneficio Economico en " + txtmesdif.Text + " meses: ";
            label26.Text = "Beneficio sobre fondos propios en " + txtmesdif.Text + " meses";

            txtbnetosmeses.Text = (Math.Round((Convert.ToDouble(txtplusvalia.Text) / Convert.ToDouble(txttotalgastos.Text)) * 100, 2)).ToString() + "%";
            txtbpropiosmeses.Text = (Math.Round(((Convert.ToDouble(txtflujobruto.Text) / Convert.ToDouble(txtflujospropios.Text)) - 1) * 100, 2)).ToString() + "%";
            double netomese = Convert.ToDouble(txtbpropiosmeses.Text.Replace("%", ""));
            txtbpropiosanual.Text = (Math.Round((netomese / Convert.ToInt32(txtmesdif.Text)) * 12, 2)).ToString() + "%";
            CalcultaTIR();

            if (Convert.ToDouble(txtplusvalia.Text) >= 0) { txtplusvalia.ForeColor = Color.Green; } else { txtplusvalia.ForeColor = Color.Red; }
            if (Convert.ToDouble(txtflujobruto.Text) >= 0) { txtflujobruto.ForeColor = Color.Green; } else { txtflujobruto.ForeColor = Color.Red; }
            GuardarEstudio();
        }


        public void jaj()
        {
            txtmetros.Text = txtmetrosTC.Text;
            txtmetrosutiles.Text = txtmetrosutilesTC.Text;

            txtGastoAqui.Text = ((Convert.ToDouble(txtpergastoadq.Text.Replace("%","")) * Convert.ToDouble(txtcomprabruto.Text)) / 100).ToString();
            if (rbutiles.Checked)
            {
                txtreforma.Text = (Convert.ToDouble(txtreforpreciosmts.Text) * Convert.ToDouble(txtmetrosutiles.Text)).ToString();
            }
            else
            {
                txtreforma.Text = (Convert.ToDouble(txtreforpreciosmts.Text) * Convert.ToDouble(txtmetrosTC.Text)).ToString();
            }
          
            txtcostetotal.Text = (Convert.ToDouble(txtcomprabruto.Text) + Convert.ToDouble(txtGastoAqui.Text) + Convert.ToDouble(txtreforma.Text) + Convert.ToDouble(txtgastoscomisones.Text)).ToString();

          
            txtprecipormetro.Text = (Math.Round(Convert.ToDouble(txtcostetotal.Text) / Convert.ToDouble(txtmetros.Text), 2)).ToString();
            txtprecipormetroutil.Text = (Math.Round(Convert.ToDouble(txtcostetotal.Text) / Convert.ToDouble(txtmetrosutiles.Text), 2)).ToString();
            txtprecipormetroTC.Text = (Math.Round(Convert.ToDouble(txtcomprabruto.Text) / Convert.ToDouble(txtmetros.Text), 2)).ToString();
            txtprecipormetroutilTC.Text = (Math.Round(Convert.ToDouble(txtcomprabruto.Text) / Convert.ToDouble(txtmetrosutiles.Text), 2)).ToString();

            txtventa.Text = (Convert.ToDouble(txtventametros.Text) * Convert.ToDouble(txtmetros.Text)).ToString();

            txtmantenimiento.Text = (((Convert.ToDouble(txtmantenimientoanuales.Text) / 12) * Convert.ToInt32(txtmesdif.Text))).ToString();
    
            txttotalcartera.Text = (Convert.ToDouble(txtcomunes.Text) + Convert.ToDouble(txtmantenimiento.Text) + Convert.ToDouble(txtintereses.Text)).ToString();
            txttotalgastos .Text = (Convert.ToDouble(txttotalcartera.Text) + Convert.ToDouble(txtcostetotal.Text)).ToString();          
        }

        public void calculosporcentajes()
        {         
            txtaportcapital.Text = (Convert.ToDouble(txtcomprabruto.Text) * Convert.ToDouble(txtperaportcapital.Text.Replace("%", "")) / 100).ToString();
            txtimphipoteca.Text = (Convert.ToDouble(txtcomprabruto.Text ) * Convert.ToDouble(txtperimphipoteca.Text.Replace("%", "")) / 100).ToString();           
        }
              
        private void txtperimphipoteca_TextChanged(object sender, EventArgs e)
        {        
            try
            {
                double perimphipoteca = Convert.ToDouble(txtperimphipoteca.Text.Replace("%", ""));
                txtperaportcapital.Text = (100 - perimphipoteca).ToString();
                calculosporcentajes();
               
            }
            catch (Exception) { }    
        }

        private void txtperaportcapital_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double perporcapital = Convert.ToDouble(txtperaportcapital.Text.Replace("%", ""));
                txtperimphipoteca.Text = (100 - perporcapital).ToString();
                calculosporcentajes();               
            }
            catch (Exception) { }
        }
     

        private void fcompra_ValueChanged(object sender, EventArgs e)
        {
            TimeSpan dias = fventa.Value.Subtract(fcompra.Value);
            decimal meses = Convert.ToDecimal(Convert.ToDecimal(dias.Days +1) / 30);
            txtmesdif.Text = (Math.Round(meses,0)).ToString() ;
        }     
      
        public double calculoitereses(int mesinicia, int mespara)
        {
            DataTable dt = new DataTable();
            dt = TablaAmortizacion(Convert.ToDouble(txtimphipoteca.Text), Convert.ToDouble(txttipointeres.Text.Replace("%", "")), Convert.ToInt32(txtmesamortizacion.Text) * 12);
            dgamortizacion.DataSource = dt;
            double intereses=0 ;
            for (int i = mesinicia; i < mespara; i++)
            {
                intereses += Convert.ToDouble(dt.Rows[i]["Intereses"]); 
            }
            return intereses;         
        }
        public double calculocuotapasgadas(int mesinicia, int mespara)
        {
            DataTable dt = new DataTable();
            dt = TablaAmortizacion(Convert.ToDouble(txtimphipoteca.Text), Convert.ToDouble(txttipointeres.Text.Replace("%", "")), Convert.ToInt32(txtmesamortizacion.Text) * 12);
            dgamortizacion.DataSource = dt;
            double intereses = 0;
            for (int i = mesinicia; i < mespara; i++)
            {
                intereses += Convert.ToDouble(dt.Rows[i]["Capital"]);
            }
            return intereses;

        }


        private void EventoCambiocalculados(object sender, EventArgs e)
        {
            try
            {
                TextBox campo;
                campo = (TextBox)sender;
                Forma = Convert.ToDecimal(campo.Text, CultureInfo.CreateSpecificCulture("es-ES"));
                campo.Text = String.Format("{0:N0}", Forma);
            }
            catch (Exception)
            {

            }            
        }
        private void EventodeCalculo(object sender, EventArgs e)
        {
            try
            {
                jaj();
                calculosporcentajes();
                TextBox campo;
                campo = (TextBox)sender;
                double numero = Convert.ToDouble(campo.Text);               
                campo.Text = numero.ToString("N0");
                campo.Select(campo.Text.Length, 0);
            
            }
            catch (Exception)
            {

            }
       }

        private void entrada(object sender, EventArgs e)
        {
            TextBox campo;
            campo = (TextBox)sender;
            if (campo.Text == "0") campo.Text = "";

        }
        private void salida(object sender, EventArgs e)
        {
            TextBox campo;
            campo = (TextBox)sender;
            if (campo.Text == "") campo.Text = "0";

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        Bitmap memoryImage;
        private Bitmap CaptureScreen()
        {
            Graphics myGraphics = this.CreateGraphics();
            Size s = this.Size;
            memoryImage = new Bitmap(s.Width, s.Height, myGraphics);
            Graphics memoryGraphics = Graphics.FromImage(memoryImage);
            memoryGraphics.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, s);
            return memoryImage;
        }

        private void printDocument1_PrintPage(System.Object sender,
               System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(memoryImage, 0, 0);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            bttcalcular.Visible = false;
            bttimprimrir.Visible = false;
            bttguardar.Visible = false;
            this.Refresh();
            Thread.Sleep(2000);
            CaptureScreen();
            printDocument1.Print();
            bttcalcular.Visible = true;
            bttimprimrir.Visible = true;
            bttguardar.Visible = true;
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //Mostrar aquí el SaveFileDialog.
            //Si el usuario no presiona cancelar, proceder a recuperar el nombre del archivo.
          
        }

        private void Form_Financiero_FormClosed(object sender, FormClosedEventArgs e)
        {
           // GuardarEstudio();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            bttcalcular.Visible = false;
            bttimprimrir.Visible = false;
            bttguardar.Visible = false;
            this.Refresh();       
            Thread.Sleep(2000);
            Bitmap bmp = CaptureScreen();
            saveFileDialog1.DefaultExt = "Png Image";
            saveFileDialog1.ValidateNames = true;
            saveFileDialog1.Filter = "Png Image (.png)|*.png |Tiff Image (.tiff)|*.tiff |Wmf Image (.wmf)|*.wmf";
            saveFileDialog1.Title = "Save an Image File";
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "")
            {
                string nombreArchivo = saveFileDialog1.FileName;
                using ( bmp )
                {
                    bmp.Save(nombreArchivo, ImageFormat.Png);
                }
            }

            bttcalcular.Visible = true;
            bttimprimrir.Visible = true;
            bttguardar.Visible = true;

        
                    
        }
    }
}
