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
using System.Drawing.Printing;
using Microsoft.Reporting.WinForms;

namespace GestionConstructora
{
    public partial class R_TesoreriaFinanciera : Form
    {
        List<LineasEstFinanciera> Lineas = new List<LineasEstFinanciera>();
        public R_TesoreriaFinanciera(List<LineasEstFinanciera> lines)
        {
            InitializeComponent();
            Lineas = lines;
            Conf_PAge();
        }

        private void R_TesoreriaFinanciera_Load(object sender, EventArgs e)
        {
            //preparamos el report
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            //ReportViewer1.LocalReport.ReportPath = "\turuta_donde_este el reporte"

            //Cargamos los dataSet de los Report
            reportViewer1.LocalReport.DataSources.Clear(); //borro los ds
            var data1 = new ReportDataSource("Lineas", Lineas);
           

            reportViewer1.LocalReport.DataSources.Add(data1);
          

            //  Cargamos los parametros
            //reportViewer1[] parameters = new ReportParameter[1];
            //parameters[0] = new ReportParameter("Campo", campo);
            //reportViewer1.LocalReport.SetParameters(parameters);
            this.reportViewer1.RefreshReport();
        }       
     
        private void Conf_PAge()
        {
            var page = new PageSettings();
            page.Margins.Bottom = 20;
            page.Margins.Top = 20;
            page.Margins.Left = 5;
            page.Margins.Right = 5;
            page.Landscape = false;
            reportViewer1.SetPageSettings(page);
        }

    }
}
