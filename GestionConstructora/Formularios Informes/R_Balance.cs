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
using Microsoft.Reporting.WinForms;
using System.Drawing.Printing;

namespace GestionConstructora
{
    public partial class R_Balance : Form
    {
        List<ResumenTipos> Ingresos = new List<ResumenTipos>();
        List<ResumenTipos> Gastos = new List<ResumenTipos>();
        List<ResumenTipos> Resumen = new List<ResumenTipos>();
        string Titulo = string.Empty;
        public R_Balance(List<ResumenTipos> ingresos, List<ResumenTipos> gastos, List<ResumenTipos> resumen,string titulo)
        {
            InitializeComponent();
            Ingresos = ingresos;
            Gastos = gastos;
            Resumen = resumen;
            Titulo = titulo;
            Conf_PAge();
        }
        private void Conf_PAge()
        {
            var page = new PageSettings();
            page.Margins.Bottom = 20;
            page.Margins.Top = 20;
            page.Margins.Left = 100;
            page.Margins.Right = 20;
            page.Landscape = true;
            reportViewer1.SetPageSettings(page);
        }
            

        private void R_Balance_Load(object sender, EventArgs e)
        {
            //preparamos el report
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            //ReportViewer1.LocalReport.ReportPath = "\turuta_donde_este el reporte"
          
            //Cargamos los dataSet de los Report
            reportViewer1.LocalReport.DataSources.Clear(); //borro los ds
            var data1 = new ReportDataSource("Ingresos", Ingresos);
            var data2 = new ReportDataSource("Gastos", Gastos);
            var data3 = new ReportDataSource("Resumen", Resumen);
            reportViewer1.LocalReport.DataSources.Add(data1);
            reportViewer1.LocalReport.DataSources.Add(data2);
            reportViewer1.LocalReport.DataSources.Add(data3);
            //Cargamos los parametros
            ReportParameter[] parameters = new ReportParameter[1];
            parameters[0] = new ReportParameter("Titulo", Titulo);
            reportViewer1.LocalReport.SetParameters(parameters);
            this.reportViewer1.RefreshReport();
        }
    }
}
