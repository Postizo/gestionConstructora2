namespace GestionConstructora
{
    partial class Form_PartidasFactu
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_PartidasFactu));
            Ai.Control.ColumnHeader columnHeader1 = new Ai.Control.ColumnHeader();
            Ai.Control.ColumnHeader columnHeader2 = new Ai.Control.ColumnHeader();
            Ai.Control.ColumnHeader columnHeader3 = new Ai.Control.ColumnHeader();
            Ai.Control.ColumnHeader columnHeader4 = new Ai.Control.ColumnHeader();
            Ai.Control.ColumnHeader columnHeader5 = new Ai.Control.ColumnHeader();
            Ai.Control.ColumnHeader columnHeader6 = new Ai.Control.ColumnHeader();
            Ai.Control.ColumnHeader columnHeader7 = new Ai.Control.ColumnHeader();
            Ai.Control.ColumnHeader columnHeader8 = new Ai.Control.ColumnHeader();
            Ai.Control.ColumnHeader columnHeader9 = new Ai.Control.ColumnHeader();
            Ai.Control.ColumnHeader columnHeader10 = new Ai.Control.ColumnHeader();
            Ai.Control.ColumnHeader columnHeader11 = new Ai.Control.ColumnHeader();
            Ai.Control.ColumnHeader columnHeader12 = new Ai.Control.ColumnHeader();
            Ai.Control.ColumnHeader columnHeader13 = new Ai.Control.ColumnHeader();
            Ai.Control.ColumnHeader columnHeader14 = new Ai.Control.ColumnHeader();
            Ai.Control.ColumnHeader columnHeader15 = new Ai.Control.ColumnHeader();
            Ai.Control.ColumnHeader columnHeader16 = new Ai.Control.ColumnHeader();
            Ai.Control.ColumnHeader columnHeader17 = new Ai.Control.ColumnHeader();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.treepartida = new Ai.Control.MultiColumnTree();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbpresuoriginal = new System.Windows.Forms.RadioButton();
            this.rbpresuactual = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            this.imageList1.Images.SetKeyName(2, "");
            this.imageList1.Images.SetKeyName(3, "");
            this.imageList1.Images.SetKeyName(4, "carpeta(8).png");
            this.imageList1.Images.SetKeyName(5, "carpeta(10).png");
            this.imageList1.Images.SetKeyName(6, "d.png");
            this.imageList1.Images.SetKeyName(7, "carpeta_morada.png");
            this.imageList1.Images.SetKeyName(8, "carpeta_rojo.png");
            this.imageList1.Images.SetKeyName(9, "");
            this.imageList1.Images.SetKeyName(10, "llave-inglesa(1).png");
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.66666F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.treepartida, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.button1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1125, 592);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // treepartida
            // 
            this.treepartida.AllowMultiline = true;
            columnHeader1.CustomFilter = null;
            columnHeader1.EnableFiltering = true;
            columnHeader1.EnableFrozen = true;
            columnHeader1.EnableSorting = true;
            columnHeader1.MaximumValue = 0D;
            columnHeader1.MinimumValue = 0D;
            columnHeader1.Name = "Nombre";
            columnHeader1.Tag = null;
            columnHeader1.Text = "Nombre";
            columnHeader1.Width = 350;
            columnHeader2.ColumnAlign = System.Windows.Forms.HorizontalAlignment.Right;
            columnHeader2.CustomFilter = null;
            columnHeader2.CustomFormat = "#,#";
            columnHeader2.Format = Ai.Control.ColumnFormat.Custom;
            columnHeader2.MaximumValue = 0D;
            columnHeader2.MinimumValue = 0D;
            columnHeader2.Name = "Presupuestado";
            columnHeader2.Tag = null;
            columnHeader2.Text = "Presu_Coste";
            columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            columnHeader3.ColumnAlign = System.Windows.Forms.HorizontalAlignment.Right;
            columnHeader3.CustomFilter = null;
            columnHeader3.CustomFormat = "#,#";
            columnHeader3.Format = Ai.Control.ColumnFormat.Custom;
            columnHeader3.MaximumValue = 0D;
            columnHeader3.MinimumValue = 0D;
            columnHeader3.Name = "CostePrevisto";
            columnHeader3.Tag = null;
            columnHeader3.Text = "Presu_Coste";
            columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            columnHeader4.ColumnAlign = System.Windows.Forms.HorizontalAlignment.Right;
            columnHeader4.CustomFilter = null;
            columnHeader4.CustomFormat = "#,#";
            columnHeader4.Format = Ai.Control.ColumnFormat.Custom;
            columnHeader4.MaximumValue = 0D;
            columnHeader4.MinimumValue = 0D;
            columnHeader4.Name = "Coste_Real";
            columnHeader4.Tag = null;
            columnHeader4.Text = "Coste_real";
            columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            columnHeader5.ColumnAlign = System.Windows.Forms.HorizontalAlignment.Center;
            columnHeader5.CustomFilter = null;
            columnHeader5.Format = Ai.Control.ColumnFormat.Percent;
            columnHeader5.MaximumValue = 0D;
            columnHeader5.MinimumValue = 0D;
            columnHeader5.Name = "%Presupuesto";
            columnHeader5.Tag = null;
            columnHeader5.Text = "%";
            columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            columnHeader5.Width = 60;
            columnHeader6.ColumnAlign = System.Windows.Forms.HorizontalAlignment.Center;
            columnHeader6.CustomFilter = null;
            columnHeader6.Format = Ai.Control.ColumnFormat.Percent;
            columnHeader6.MaximumValue = 0D;
            columnHeader6.MinimumValue = 0D;
            columnHeader6.Name = "%Costeprevisto";
            columnHeader6.Tag = null;
            columnHeader6.Text = "%";
            columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            columnHeader6.Width = 60;
            columnHeader7.ColumnAlign = System.Windows.Forms.HorizontalAlignment.Right;
            columnHeader7.CustomFilter = null;
            columnHeader7.CustomFormat = "#,#";
            columnHeader7.Format = Ai.Control.ColumnFormat.Custom;
            columnHeader7.MaximumValue = 0D;
            columnHeader7.MinimumValue = 0D;
            columnHeader7.Name = "Presu_Venta";
            columnHeader7.Tag = null;
            columnHeader7.Text = "Presu_venta";
            columnHeader7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            columnHeader8.ColumnAlign = System.Windows.Forms.HorizontalAlignment.Right;
            columnHeader8.CustomFilter = null;
            columnHeader8.CustomFormat = "#,#";
            columnHeader8.Format = Ai.Control.ColumnFormat.Custom;
            columnHeader8.MaximumValue = 0D;
            columnHeader8.MinimumValue = 0D;
            columnHeader8.Name = "VentaPrevista";
            columnHeader8.Tag = null;
            columnHeader8.Text = "Presu_venta";
            columnHeader8.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            columnHeader9.ColumnAlign = System.Windows.Forms.HorizontalAlignment.Right;
            columnHeader9.CustomFilter = null;
            columnHeader9.CustomFormat = "#,#";
            columnHeader9.Format = Ai.Control.ColumnFormat.Custom;
            columnHeader9.MaximumValue = 0D;
            columnHeader9.MinimumValue = 0D;
            columnHeader9.Name = "Certificado";
            columnHeader9.Tag = null;
            columnHeader9.Text = "Certificado";
            columnHeader9.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            columnHeader10.ColumnAlign = System.Windows.Forms.HorizontalAlignment.Center;
            columnHeader10.CustomFilter = null;
            columnHeader10.Format = Ai.Control.ColumnFormat.Percent;
            columnHeader10.MaximumValue = 0D;
            columnHeader10.MinimumValue = 0D;
            columnHeader10.Name = "%Presu_Venta";
            columnHeader10.Tag = null;
            columnHeader10.Text = "%Realizado";
            columnHeader10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            columnHeader10.Width = 60;
            columnHeader11.ColumnAlign = System.Windows.Forms.HorizontalAlignment.Center;
            columnHeader11.CustomFilter = null;
            columnHeader11.Format = Ai.Control.ColumnFormat.Percent;
            columnHeader11.MaximumValue = 0D;
            columnHeader11.MinimumValue = 0D;
            columnHeader11.Name = "%Ventaprevista";
            columnHeader11.Tag = null;
            columnHeader11.Text = "%Realizado";
            columnHeader11.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            columnHeader11.Width = 60;
            columnHeader12.ColumnAlign = System.Windows.Forms.HorizontalAlignment.Right;
            columnHeader12.CustomFilter = null;
            columnHeader12.CustomFormat = "#,#";
            columnHeader12.Format = Ai.Control.ColumnFormat.Custom;
            columnHeader12.MaximumValue = 0D;
            columnHeader12.MinimumValue = 0D;
            columnHeader12.Name = "Diferencia";
            columnHeader12.Tag = null;
            columnHeader12.Text = "Diferencia";
            columnHeader12.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            columnHeader13.ColumnAlign = System.Windows.Forms.HorizontalAlignment.Center;
            columnHeader13.CustomFilter = null;
            columnHeader13.Format = Ai.Control.ColumnFormat.Percent;
            columnHeader13.MaximumValue = 0D;
            columnHeader13.MinimumValue = 0D;
            columnHeader13.Name = "%Diferencia";
            columnHeader13.Tag = null;
            columnHeader13.Text = "%Diferencia";
            columnHeader13.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            columnHeader14.CustomFilter = null;
            columnHeader14.MaximumValue = 0D;
            columnHeader14.MinimumValue = 0D;
            columnHeader14.Name = "TipoCoste";
            columnHeader14.Tag = null;
            columnHeader14.Visible = false;
            columnHeader15.CustomFilter = null;
            columnHeader15.MaximumValue = 0D;
            columnHeader15.MinimumValue = 0D;
            columnHeader15.Name = "id_grupo";
            columnHeader15.Tag = null;
            columnHeader15.Text = "id_grupo";
            columnHeader15.Visible = false;
            columnHeader16.CustomFilter = null;
            columnHeader16.MaximumValue = 0D;
            columnHeader16.MinimumValue = 0D;
            columnHeader16.Name = "id_subgrupo";
            columnHeader16.Tag = null;
            columnHeader16.Text = "id_subgrupo";
            columnHeader16.Visible = false;
            columnHeader17.CustomFilter = null;
            columnHeader17.MaximumValue = 0D;
            columnHeader17.MinimumValue = 0D;
            columnHeader17.Name = "Codigo";
            columnHeader17.Tag = null;
            columnHeader17.Visible = false;
            this.treepartida.Columns.Add(columnHeader1);
            this.treepartida.Columns.Add(columnHeader2);
            this.treepartida.Columns.Add(columnHeader3);
            this.treepartida.Columns.Add(columnHeader4);
            this.treepartida.Columns.Add(columnHeader5);
            this.treepartida.Columns.Add(columnHeader6);
            this.treepartida.Columns.Add(columnHeader7);
            this.treepartida.Columns.Add(columnHeader8);
            this.treepartida.Columns.Add(columnHeader9);
            this.treepartida.Columns.Add(columnHeader10);
            this.treepartida.Columns.Add(columnHeader11);
            this.treepartida.Columns.Add(columnHeader12);
            this.treepartida.Columns.Add(columnHeader13);
            this.treepartida.Columns.Add(columnHeader14);
            this.treepartida.Columns.Add(columnHeader15);
            this.treepartida.Columns.Add(columnHeader16);
            this.treepartida.Columns.Add(columnHeader17);
            this.tableLayoutPanel1.SetColumnSpan(this.treepartida, 2);
            this.treepartida.Culture = new System.Globalization.CultureInfo("es-ES");
            this.treepartida.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treepartida.Indent = -1;
            this.treepartida.Location = new System.Drawing.Point(0, 0);
            this.treepartida.Margin = new System.Windows.Forms.Padding(0);
            this.treepartida.Name = "treepartida";
            this.treepartida.Padding = new System.Windows.Forms.Padding(1);
            this.treepartida.SelectedNode = null;
            this.treepartida.Size = new System.Drawing.Size(1125, 552);
            this.treepartida.TabIndex = 21;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(753, 555);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(163, 23);
            this.button1.TabIndex = 20;
            this.button1.Text = "MATERIAL/M.OBRA";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.GhostWhite;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.rbpresuoriginal);
            this.panel1.Controls.Add(this.rbpresuactual);
            this.panel1.Location = new System.Drawing.Point(3, 555);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(182, 34);
            this.panel1.TabIndex = 19;
            // 
            // rbpresuoriginal
            // 
            this.rbpresuoriginal.AutoSize = true;
            this.rbpresuoriginal.Location = new System.Drawing.Point(3, 16);
            this.rbpresuoriginal.Name = "rbpresuoriginal";
            this.rbpresuoriginal.Size = new System.Drawing.Size(138, 17);
            this.rbpresuoriginal.TabIndex = 3;
            this.rbpresuoriginal.Text = "Presupuestos Originales";
            this.rbpresuoriginal.UseVisualStyleBackColor = true;
            this.rbpresuoriginal.CheckedChanged += new System.EventHandler(this.rbpresuoriginal_CheckedChanged);
            // 
            // rbpresuactual
            // 
            this.rbpresuactual.AutoSize = true;
            this.rbpresuactual.Location = new System.Drawing.Point(3, -3);
            this.rbpresuactual.Name = "rbpresuactual";
            this.rbpresuactual.Size = new System.Drawing.Size(152, 17);
            this.rbpresuactual.TabIndex = 2;
            this.rbpresuactual.Text = "Presupuestos Actualizados";
            this.rbpresuactual.UseVisualStyleBackColor = true;
            this.rbpresuactual.CheckedChanged += new System.EventHandler(this.rbpresuactual_CheckedChanged);
            // 
            // Form_PartidasFactu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1125, 592);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form_PartidasFactu";
            this.Text = "Deglose Grupo";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private Ai.Control.MultiColumnTree treepartida;
        private System.Windows.Forms.RadioButton rbpresuoriginal;
        private System.Windows.Forms.RadioButton rbpresuactual;
    }
}