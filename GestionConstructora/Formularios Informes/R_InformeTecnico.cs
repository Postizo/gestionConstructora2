using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using Entidad;
using Microsoft.Reporting.WinForms;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace GestionConstructora
{
    public partial class R_InformeTecnico : Form
    {
       List<D_Presuca> Presu = new List<D_Presuca>();
        List<D_Presuli> Lineas = new List<D_Presuli>();
        bool Direccion;
        public R_InformeTecnico(List<D_Presuca> presu,List<D_Presuli > lineas,bool direccion )
        {
            InitializeComponent();
            Presu = presu;
            Lineas = lineas;
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
            page.Landscape = true;
            reportViewer1.SetPageSettings(page);
        }


    
        private void R_InformeTecnico_Load(object sender, EventArgs e)
        {
            //preparamos el report
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            //ReportViewer1.LocalReport.ReportPath = "\turuta_donde_este el reporte"

            //Cargamos los dataSet de los Report
            reportViewer1.LocalReport.DataSources.Clear(); //borro los ds
            var data2 = new ReportDataSource("Lineas", Lineas);
            var data1 = new ReportDataSource("Presu", Presu);
          

            reportViewer1.LocalReport.DataSources.Add(data1);
            reportViewer1.LocalReport.DataSources.Add(data2);

          //  Cargamos los parametros
            ReportParameter[] parameters = new ReportParameter[2];
            parameters[0] = new ReportParameter("Direccion", Direccion.ToString());
            parameters[1] = new ReportParameter("m_construdios", Presu[0].m_construdios.ToString());
            reportViewer1.LocalReport.SetParameters(parameters);
            this.reportViewer1.RefreshReport();
        }
    }
}
