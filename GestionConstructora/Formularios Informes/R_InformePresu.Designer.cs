﻿namespace GestionConstructora
{
    partial class R_InformePresu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.reportViewer2 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // reportViewer2
            // 
            this.reportViewer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer2.LocalReport.ReportEmbeddedResource = "GestionConstructora.Informes.I_Presu.rdlc";
            this.reportViewer2.Location = new System.Drawing.Point(0, 0);
            this.reportViewer2.Name = "reportViewer2";
            this.reportViewer2.Size = new System.Drawing.Size(681, 661);
            this.reportViewer2.TabIndex = 0;
            // 
            // R_InformePresu
            // 
            this.ClientSize = new System.Drawing.Size(681, 661);
            this.Controls.Add(this.reportViewer2);
            this.Name = "R_InformePresu";
            this.Load += new System.EventHandler(this.R_InformeTecnico_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource D_PresucaBindingSource;
        private System.Windows.Forms.BindingSource D_PresuliBindingSource;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer2;
    }
}