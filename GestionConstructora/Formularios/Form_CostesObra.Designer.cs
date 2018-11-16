namespace GestionConstructora
{
    partial class Form_CostesObra
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_CostesObra));
            this.pgeneral = new System.Windows.Forms.TableLayoutPanel();
            this.pizquierda = new System.Windows.Forms.TableLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.listObras = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pderecha = new System.Windows.Forms.TableLayoutPanel();
            this.treeobra = new Ai.Control.MultiColumnTree();
            this.ltitulo = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.dgcuentas = new System.Windows.Forms.DataGridView();
            this.Id_TipoCoste = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Concepto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Porcentaje = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Importe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.pgeneral.SuspendLayout();
            this.pizquierda.SuspendLayout();
            this.pderecha.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgcuentas)).BeginInit();
            this.SuspendLayout();
            // 
            // pgeneral
            // 
            this.pgeneral.ColumnCount = 2;
            this.pgeneral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.pgeneral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pgeneral.Controls.Add(this.pizquierda, 0, 0);
            this.pgeneral.Controls.Add(this.pderecha, 1, 0);
            this.pgeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pgeneral.Location = new System.Drawing.Point(0, 0);
            this.pgeneral.Name = "pgeneral";
            this.pgeneral.RowCount = 1;
            this.pgeneral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pgeneral.Size = new System.Drawing.Size(1052, 610);
            this.pgeneral.TabIndex = 0;
            // 
            // pizquierda
            // 
            this.pizquierda.BackColor = System.Drawing.SystemColors.Control;
            this.pizquierda.ColumnCount = 1;
            this.pizquierda.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pizquierda.Controls.Add(this.button1, 0, 2);
            this.pizquierda.Controls.Add(this.listObras, 0, 1);
            this.pizquierda.Controls.Add(this.label2, 0, 0);
            this.pizquierda.Controls.Add(this.tableLayoutPanel1, 0, 3);
            this.pizquierda.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pizquierda.Location = new System.Drawing.Point(3, 3);
            this.pizquierda.Name = "pizquierda";
            this.pizquierda.RowCount = 4;
            this.pizquierda.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.pizquierda.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 78.49462F));
            this.pizquierda.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.75269F));
            this.pizquierda.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.75269F));
            this.pizquierda.Size = new System.Drawing.Size(194, 604);
            this.pizquierda.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Location = new System.Drawing.Point(3, 483);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(188, 55);
            this.button1.TabIndex = 8;
            this.button1.Text = "CALCULAR";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listObras
            // 
            this.listObras.BackColor = System.Drawing.Color.Honeydew;
            this.listObras.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listObras.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listObras.FormattingEnabled = true;
            this.listObras.ItemHeight = 20;
            this.listObras.Location = new System.Drawing.Point(3, 33);
            this.listObras.Name = "listObras";
            this.listObras.Size = new System.Drawing.Size(188, 444);
            this.listObras.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(188, 30);
            this.label2.TabIndex = 2;
            this.label2.Text = "OBRAS";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 544);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(188, 57);
            this.tableLayoutPanel1.TabIndex = 9;
            // 
            // pderecha
            // 
            this.pderecha.ColumnCount = 1;
            this.pderecha.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pderecha.Controls.Add(this.treeobra, 0, 1);
            this.pderecha.Controls.Add(this.ltitulo, 0, 0);
            this.pderecha.Controls.Add(this.tableLayoutPanel2, 0, 2);
            this.pderecha.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pderecha.Location = new System.Drawing.Point(203, 3);
            this.pderecha.Name = "pderecha";
            this.pderecha.RowCount = 3;
            this.pderecha.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.pderecha.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pderecha.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.pderecha.Size = new System.Drawing.Size(846, 604);
            this.pderecha.TabIndex = 1;
            // 
            // treeobra
            // 
            this.treeobra.AllowMultiline = true;
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
            columnHeader2.Text = "Total";
            columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            columnHeader2.Width = 90;
            columnHeader3.ColumnAlign = System.Windows.Forms.HorizontalAlignment.Right;
            columnHeader3.CustomFilter = null;
            columnHeader3.CustomFormat = "#,#";
            columnHeader3.Format = Ai.Control.ColumnFormat.Custom;
            columnHeader3.MaximumValue = 0D;
            columnHeader3.MinimumValue = 0D;
            columnHeader3.Name = "SoloCostes";
            columnHeader3.Tag = null;
            columnHeader3.Text = "Costes";
            columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            columnHeader4.ColumnAlign = System.Windows.Forms.HorizontalAlignment.Right;
            columnHeader4.CustomFilter = null;
            columnHeader4.CustomFormat = "#,#";
            columnHeader4.Format = Ai.Control.ColumnFormat.Custom;
            columnHeader4.MaximumValue = 0D;
            columnHeader4.MinimumValue = 0D;
            columnHeader4.Name = "CD";
            columnHeader4.Tag = null;
            columnHeader4.Text = "CD";
            columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            columnHeader4.Width = 90;
            columnHeader5.ColumnAlign = System.Windows.Forms.HorizontalAlignment.Right;
            columnHeader5.CustomFilter = null;
            columnHeader5.CustomFormat = "#,#";
            columnHeader5.Format = Ai.Control.ColumnFormat.Custom;
            columnHeader5.MaximumValue = 0D;
            columnHeader5.MinimumValue = 0D;
            columnHeader5.Name = "CG";
            columnHeader5.Tag = null;
            columnHeader5.Text = "CG";
            columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            columnHeader5.Width = 90;
            columnHeader6.ColumnAlign = System.Windows.Forms.HorizontalAlignment.Right;
            columnHeader6.CustomFilter = null;
            columnHeader6.CustomFormat = "#,#";
            columnHeader6.Format = Ai.Control.ColumnFormat.Custom;
            columnHeader6.MaximumValue = 0D;
            columnHeader6.MinimumValue = 0D;
            columnHeader6.Name = "Beneficio";
            columnHeader6.Tag = null;
            columnHeader6.Text = "Beneficio";
            columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            columnHeader6.Width = 90;
            columnHeader7.CustomFilter = null;
            columnHeader7.MaximumValue = 0D;
            columnHeader7.MinimumValue = 0D;
            columnHeader7.Name = "Coeficiente";
            columnHeader7.Tag = null;
            columnHeader7.Text = "Coeficiente";
            columnHeader7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            columnHeader7.Visible = false;
            columnHeader8.CustomFilter = null;
            columnHeader8.MaximumValue = 0D;
            columnHeader8.MinimumValue = 0D;
            columnHeader8.Name = "TipoCoste";
            columnHeader8.Tag = null;
            columnHeader8.Visible = false;
            columnHeader9.CustomFilter = null;
            columnHeader9.MaximumValue = 0D;
            columnHeader9.MinimumValue = 0D;
            columnHeader9.Name = "id_grupo";
            columnHeader9.Tag = null;
            columnHeader9.Text = "id_grupo";
            columnHeader9.Visible = false;
            columnHeader10.CustomFilter = null;
            columnHeader10.MaximumValue = 0D;
            columnHeader10.MinimumValue = 0D;
            columnHeader10.Name = "id_subgrupo";
            columnHeader10.Tag = null;
            columnHeader10.Text = "id_subgrupo";
            columnHeader10.Visible = false;
            this.treeobra.Columns.Add(columnHeader1);
            this.treeobra.Columns.Add(columnHeader2);
            this.treeobra.Columns.Add(columnHeader3);
            this.treeobra.Columns.Add(columnHeader4);
            this.treeobra.Columns.Add(columnHeader5);
            this.treeobra.Columns.Add(columnHeader6);
            this.treeobra.Columns.Add(columnHeader7);
            this.treeobra.Columns.Add(columnHeader8);
            this.treeobra.Columns.Add(columnHeader9);
            this.treeobra.Columns.Add(columnHeader10);
            this.treeobra.Culture = new System.Globalization.CultureInfo("es-ES");
            this.treeobra.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeobra.FullRowSelect = true;
            this.treeobra.Indent = -1;
            this.treeobra.LabelEdit = true;
            this.treeobra.Location = new System.Drawing.Point(0, 30);
            this.treeobra.Margin = new System.Windows.Forms.Padding(0);
            this.treeobra.Name = "treeobra";
            this.treeobra.Padding = new System.Windows.Forms.Padding(1);
            this.treeobra.SelectedNode = null;
            this.treeobra.Size = new System.Drawing.Size(846, 474);
            this.treeobra.TabIndex = 14;
            this.treeobra.BeforeSelect += new Ai.Control.MultiColumnTree.BeforeSelectEventHandler(this.treobra_BeforeSelect);
            this.treeobra.AfterSelect += new Ai.Control.MultiColumnTree.AfterSelectEventHandler(this.treobra_AfterSelect);
            this.treeobra.SelectedNodeChanged += new Ai.Control.MultiColumnTree.SelectedNodeChangedEventHandler(this.treeobra_SelectedNodeChanged);
            // 
            // ltitulo
            // 
            this.ltitulo.AutoSize = true;
            this.ltitulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ltitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ltitulo.Location = new System.Drawing.Point(3, 0);
            this.ltitulo.Name = "ltitulo";
            this.ltitulo.Size = new System.Drawing.Size(840, 30);
            this.ltitulo.TabIndex = 2;
            this.ltitulo.Text = "label5";
            this.ltitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.dgcuentas, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 507);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(840, 94);
            this.tableLayoutPanel2.TabIndex = 15;
            // 
            // dgcuentas
            // 
            this.dgcuentas.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgcuentas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgcuentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgcuentas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id_TipoCoste,
            this.Concepto,
            this.Porcentaje,
            this.Importe});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgcuentas.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgcuentas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgcuentas.Location = new System.Drawing.Point(3, 3);
            this.dgcuentas.Name = "dgcuentas";
            this.dgcuentas.RowHeadersVisible = false;
            this.dgcuentas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgcuentas.Size = new System.Drawing.Size(414, 88);
            this.dgcuentas.TabIndex = 2;
            this.dgcuentas.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgcuentas_CellEndEdit);
            this.dgcuentas.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgcuentas_CellLeave);
            this.dgcuentas.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgcuentas_CellValueChanged);
            // 
            // Id_TipoCoste
            // 
            this.Id_TipoCoste.DataPropertyName = "Id_TipoCoste";
            this.Id_TipoCoste.HeaderText = "Id_Tipocoste";
            this.Id_TipoCoste.Name = "Id_TipoCoste";
            this.Id_TipoCoste.Visible = false;
            // 
            // Concepto
            // 
            this.Concepto.DataPropertyName = "Nombre";
            this.Concepto.HeaderText = "Concepto";
            this.Concepto.Name = "Concepto";
            this.Concepto.Width = 200;
            // 
            // Porcentaje
            // 
            this.Porcentaje.DataPropertyName = "Porcen_SobreTotal";
            this.Porcentaje.HeaderText = "%";
            this.Porcentaje.Name = "Porcentaje";
            // 
            // Importe
            // 
            this.Importe.DataPropertyName = "Importe";
            this.Importe.HeaderText = "Importe";
            this.Importe.Name = "Importe";
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
            // 
            // Form_CostesObra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1052, 610);
            this.Controls.Add(this.pgeneral);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_CostesObra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agregar costes de la Obra";
            this.pgeneral.ResumeLayout(false);
            this.pizquierda.ResumeLayout(false);
            this.pizquierda.PerformLayout();
            this.pderecha.ResumeLayout(false);
            this.pderecha.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgcuentas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel pgeneral;
        private System.Windows.Forms.TableLayoutPanel pizquierda;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listObras;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TableLayoutPanel pderecha;
        private System.Windows.Forms.Label ltitulo;
        private System.Windows.Forms.ImageList imageList1;
        private Ai.Control.MultiColumnTree treeobra;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.DataGridView dgcuentas;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id_TipoCoste;
        private System.Windows.Forms.DataGridViewTextBoxColumn Concepto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Porcentaje;
        private System.Windows.Forms.DataGridViewTextBoxColumn Importe;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}