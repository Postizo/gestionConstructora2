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
            Ai.Control.ColumnHeader columnHeader18 = new Ai.Control.ColumnHeader();
            Ai.Control.ColumnHeader columnHeader19 = new Ai.Control.ColumnHeader();
            Ai.Control.ColumnHeader columnHeader20 = new Ai.Control.ColumnHeader();
            Ai.Control.ColumnHeader columnHeader21 = new Ai.Control.ColumnHeader();
            Ai.Control.ColumnHeader columnHeader22 = new Ai.Control.ColumnHeader();
            Ai.Control.ColumnHeader columnHeader23 = new Ai.Control.ColumnHeader();
            Ai.Control.ColumnHeader columnHeader24 = new Ai.Control.ColumnHeader();
            Ai.Control.ColumnHeader columnHeader25 = new Ai.Control.ColumnHeader();
            Ai.Control.ColumnHeader columnHeader26 = new Ai.Control.ColumnHeader();
            Ai.Control.ColumnHeader columnHeader27 = new Ai.Control.ColumnHeader();
            Ai.Control.ColumnHeader columnHeader28 = new Ai.Control.ColumnHeader();
            Ai.Control.ColumnHeader columnHeader29 = new Ai.Control.ColumnHeader();
            Ai.Control.ColumnHeader columnHeader30 = new Ai.Control.ColumnHeader();
            Ai.Control.ColumnHeader columnHeader31 = new Ai.Control.ColumnHeader();
            Ai.Control.ColumnHeader columnHeader32 = new Ai.Control.ColumnHeader();
            Ai.Control.ColumnHeader columnHeader33 = new Ai.Control.ColumnHeader();
            Ai.Control.ColumnHeader columnHeader34 = new Ai.Control.ColumnHeader();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.treepartida = new Ai.Control.MultiColumnTree();
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
            // treepartida
            // 
            this.treepartida.AllowMultiline = true;
            columnHeader18.CustomFilter = null;
            columnHeader18.EnableFiltering = true;
            columnHeader18.EnableFrozen = true;
            columnHeader18.EnableSorting = true;
            columnHeader18.MaximumValue = 0D;
            columnHeader18.MinimumValue = 0D;
            columnHeader18.Name = "Nombre";
            columnHeader18.Tag = null;
            columnHeader18.Text = "Nombre";
            columnHeader18.Width = 350;
            columnHeader19.ColumnAlign = System.Windows.Forms.HorizontalAlignment.Right;
            columnHeader19.CustomFilter = null;
            columnHeader19.CustomFormat = "#,#";
            columnHeader19.Format = Ai.Control.ColumnFormat.Custom;
            columnHeader19.MaximumValue = 0D;
            columnHeader19.MinimumValue = 0D;
            columnHeader19.Name = "Presupuestado";
            columnHeader19.Tag = null;
            columnHeader19.Text = "Presu_Coste";
            columnHeader19.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            columnHeader20.ColumnAlign = System.Windows.Forms.HorizontalAlignment.Right;
            columnHeader20.CustomFilter = null;
            columnHeader20.CustomFormat = "#,#";
            columnHeader20.Format = Ai.Control.ColumnFormat.Custom;
            columnHeader20.MaximumValue = 0D;
            columnHeader20.MinimumValue = 0D;
            columnHeader20.Name = "CostePrevisto";
            columnHeader20.Tag = null;
            columnHeader20.Text = "Presu_Coste";
            columnHeader20.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            columnHeader21.ColumnAlign = System.Windows.Forms.HorizontalAlignment.Right;
            columnHeader21.CustomFilter = null;
            columnHeader21.CustomFormat = "#,#";
            columnHeader21.Format = Ai.Control.ColumnFormat.Custom;
            columnHeader21.MaximumValue = 0D;
            columnHeader21.MinimumValue = 0D;
            columnHeader21.Name = "Coste_Real";
            columnHeader21.Tag = null;
            columnHeader21.Text = "Coste_real";
            columnHeader21.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            columnHeader22.ColumnAlign = System.Windows.Forms.HorizontalAlignment.Center;
            columnHeader22.CustomFilter = null;
            columnHeader22.Format = Ai.Control.ColumnFormat.Percent;
            columnHeader22.MaximumValue = 0D;
            columnHeader22.MinimumValue = 0D;
            columnHeader22.Name = "%Presupuesto";
            columnHeader22.Tag = null;
            columnHeader22.Text = "%";
            columnHeader22.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            columnHeader22.Width = 60;
            columnHeader23.ColumnAlign = System.Windows.Forms.HorizontalAlignment.Center;
            columnHeader23.CustomFilter = null;
            columnHeader23.Format = Ai.Control.ColumnFormat.Percent;
            columnHeader23.MaximumValue = 0D;
            columnHeader23.MinimumValue = 0D;
            columnHeader23.Name = "%Costeprevisto";
            columnHeader23.Tag = null;
            columnHeader23.Text = "%";
            columnHeader23.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            columnHeader23.Width = 60;
            columnHeader24.ColumnAlign = System.Windows.Forms.HorizontalAlignment.Right;
            columnHeader24.CustomFilter = null;
            columnHeader24.CustomFormat = "#,#";
            columnHeader24.Format = Ai.Control.ColumnFormat.Custom;
            columnHeader24.MaximumValue = 0D;
            columnHeader24.MinimumValue = 0D;
            columnHeader24.Name = "Presu_Venta";
            columnHeader24.Tag = null;
            columnHeader24.Text = "Presu_venta";
            columnHeader24.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            columnHeader25.ColumnAlign = System.Windows.Forms.HorizontalAlignment.Right;
            columnHeader25.CustomFilter = null;
            columnHeader25.CustomFormat = "#,#";
            columnHeader25.Format = Ai.Control.ColumnFormat.Custom;
            columnHeader25.MaximumValue = 0D;
            columnHeader25.MinimumValue = 0D;
            columnHeader25.Name = "VentaPrevista";
            columnHeader25.Tag = null;
            columnHeader25.Text = "Presu_venta";
            columnHeader25.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            columnHeader26.ColumnAlign = System.Windows.Forms.HorizontalAlignment.Right;
            columnHeader26.CustomFilter = null;
            columnHeader26.CustomFormat = "#,#";
            columnHeader26.Format = Ai.Control.ColumnFormat.Custom;
            columnHeader26.MaximumValue = 0D;
            columnHeader26.MinimumValue = 0D;
            columnHeader26.Name = "Certificado";
            columnHeader26.Tag = null;
            columnHeader26.Text = "Certificado";
            columnHeader26.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            columnHeader27.ColumnAlign = System.Windows.Forms.HorizontalAlignment.Center;
            columnHeader27.CustomFilter = null;
            columnHeader27.Format = Ai.Control.ColumnFormat.Percent;
            columnHeader27.MaximumValue = 0D;
            columnHeader27.MinimumValue = 0D;
            columnHeader27.Name = "%Presu_Venta";
            columnHeader27.Tag = null;
            columnHeader27.Text = "%Realizado";
            columnHeader27.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            columnHeader27.Width = 60;
            columnHeader28.ColumnAlign = System.Windows.Forms.HorizontalAlignment.Center;
            columnHeader28.CustomFilter = null;
            columnHeader28.Format = Ai.Control.ColumnFormat.Percent;
            columnHeader28.MaximumValue = 0D;
            columnHeader28.MinimumValue = 0D;
            columnHeader28.Name = "%Ventaprevista";
            columnHeader28.Tag = null;
            columnHeader28.Text = "%Realizado";
            columnHeader28.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            columnHeader28.Width = 60;
            columnHeader29.ColumnAlign = System.Windows.Forms.HorizontalAlignment.Right;
            columnHeader29.CustomFilter = null;
            columnHeader29.CustomFormat = "#,#";
            columnHeader29.Format = Ai.Control.ColumnFormat.Custom;
            columnHeader29.MaximumValue = 0D;
            columnHeader29.MinimumValue = 0D;
            columnHeader29.Name = "Diferencia";
            columnHeader29.Tag = null;
            columnHeader29.Text = "Diferencia";
            columnHeader29.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            columnHeader30.ColumnAlign = System.Windows.Forms.HorizontalAlignment.Center;
            columnHeader30.CustomFilter = null;
            columnHeader30.Format = Ai.Control.ColumnFormat.Percent;
            columnHeader30.MaximumValue = 0D;
            columnHeader30.MinimumValue = 0D;
            columnHeader30.Name = "%Diferencia";
            columnHeader30.Tag = null;
            columnHeader30.Text = "%Diferencia";
            columnHeader30.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            columnHeader31.CustomFilter = null;
            columnHeader31.MaximumValue = 0D;
            columnHeader31.MinimumValue = 0D;
            columnHeader31.Name = "TipoCoste";
            columnHeader31.Tag = null;
            columnHeader31.Visible = false;
            columnHeader32.CustomFilter = null;
            columnHeader32.MaximumValue = 0D;
            columnHeader32.MinimumValue = 0D;
            columnHeader32.Name = "id_grupo";
            columnHeader32.Tag = null;
            columnHeader32.Text = "id_grupo";
            columnHeader32.Visible = false;
            columnHeader33.CustomFilter = null;
            columnHeader33.MaximumValue = 0D;
            columnHeader33.MinimumValue = 0D;
            columnHeader33.Name = "id_subgrupo";
            columnHeader33.Tag = null;
            columnHeader33.Text = "id_subgrupo";
            columnHeader33.Visible = false;
            columnHeader34.CustomFilter = null;
            columnHeader34.MaximumValue = 0D;
            columnHeader34.MinimumValue = 0D;
            columnHeader34.Name = "Codigo";
            columnHeader34.Tag = null;
            columnHeader34.Visible = false;
            this.treepartida.Columns.Add(columnHeader18);
            this.treepartida.Columns.Add(columnHeader19);
            this.treepartida.Columns.Add(columnHeader20);
            this.treepartida.Columns.Add(columnHeader21);
            this.treepartida.Columns.Add(columnHeader22);
            this.treepartida.Columns.Add(columnHeader23);
            this.treepartida.Columns.Add(columnHeader24);
            this.treepartida.Columns.Add(columnHeader25);
            this.treepartida.Columns.Add(columnHeader26);
            this.treepartida.Columns.Add(columnHeader27);
            this.treepartida.Columns.Add(columnHeader28);
            this.treepartida.Columns.Add(columnHeader29);
            this.treepartida.Columns.Add(columnHeader30);
            this.treepartida.Columns.Add(columnHeader31);
            this.treepartida.Columns.Add(columnHeader32);
            this.treepartida.Columns.Add(columnHeader33);
            this.treepartida.Columns.Add(columnHeader34);
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