using Entidad;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionConstructora
{
    public partial class R_InformePresu : Form
    {
        List<D_Presuca> Presu = new List<D_Presuca>();
        List<D_Presuli> Lineas = new List<D_Presuli>();
        bool Direccion;       
        string campo = "";
        public R_InformePresu(List<D_Presuca> presu, List<D_Presuli> lineas,bool direccion, string camp)
        {
            InitializeComponent();
            Presu = presu;
            Lineas = lineas;
            campo = camp;
            Direccion = direccion;
            Conf_PAge();
        }
        private void Conf_PAge()
        {
            var page = new PageSettings();
            page.Margins.Bottom = 20;
            page.Margins.Top = 20;
            page.Margins.Left = 20;
            page.Margins.Right = 20;
            page.Landscape = false;
            reportViewer2.SetPageSettings(page);
        }

        private void R_InformeTecnico_Load(object sender, EventArgs e)
        {
            //preparamos el report
            reportViewer2.ProcessingMode = ProcessingMode.Local;
            //ReportViewer1.LocalReport.ReportPath = "\turuta_donde_este el reporte"

            //Cargamos los dataSet de los Report
            reportViewer2.LocalReport.DataSources.Clear(); //borro los ds
            var data2 = new ReportDataSource("Lineas", Lineas);
            var data1 = new ReportDataSource("Presu", Presu);


            reportViewer2.LocalReport.DataSources.Add(data1);
            reportViewer2.LocalReport.DataSources.Add(data2);

            //  Cargamos los parametros
            ReportParameter[] parameters = new ReportParameter[1];
            parameters[0] = new ReportParameter("Campo", campo);
            reportViewer2.LocalReport.SetParameters(parameters);          
            this.reportViewer2.RefreshReport();
       
        }
    }
}
