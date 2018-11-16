namespace GestionConstructora
{
    partial class Form_Facturas
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pgeneral = new System.Windows.Forms.TableLayoutPanel();
            this.pizquierda = new System.Windows.Forms.TableLayoutPanel();
            this.button2 = new System.Windows.Forms.Button();
            this.listObras = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pderecho = new System.Windows.Forms.TableLayoutPanel();
            this.dgfacturas = new System.Windows.Forms.DataGridView();
            this.Id_Factura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.documento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.N_Factura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.proveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cif = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Base = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.importe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AsientoCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ltitulo = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbpendientes = new System.Windows.Forms.RadioButton();
            this.rbfacturadas = new System.Windows.Forms.RadioButton();
            this.bttimprimir = new System.Windows.Forms.Button();
            this.txtcuenta = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbgrupo = new System.Windows.Forms.ComboBox();
            this.bttver = new System.Windows.Forms.Button();
            this.bttpagar = new System.Windows.Forms.Button();
            this.pgeneral.SuspendLayout();
            this.pizquierda.SuspendLayout();
            this.pderecho.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgfacturas)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pgeneral
            // 
            this.pgeneral.ColumnCount = 2;
            this.pgeneral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.pgeneral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pgeneral.Controls.Add(this.pizquierda, 0, 0);
            this.pgeneral.Controls.Add(this.pderecho, 1, 0);
            this.pgeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pgeneral.Location = new System.Drawing.Point(0, 0);
            this.pgeneral.Name = "pgeneral";
            this.pgeneral.RowCount = 1;
            this.pgeneral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pgeneral.Size = new System.Drawing.Size(1088, 711);
            this.pgeneral.TabIndex = 0;
            // 
            // pizquierda
            // 
            this.pizquierda.ColumnCount = 2;
            this.pizquierda.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pizquierda.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pizquierda.Controls.Add(this.button2, 0, 2);
            this.pizquierda.Controls.Add(this.listObras, 0, 1);
            this.pizquierda.Controls.Add(this.label2, 0, 0);
            this.pizquierda.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pizquierda.Location = new System.Drawing.Point(3, 3);
            this.pizquierda.Name = "pizquierda";
            this.pizquierda.RowCount = 3;
            this.pizquierda.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.263158F));
            this.pizquierda.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 78.94736F));
            this.pizquierda.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.78947F));
            this.pizquierda.Size = new System.Drawing.Size(194, 705);
            this.pizquierda.TabIndex = 1;
            // 
            // button2
            // 
            this.pizquierda.SetColumnSpan(this.button2, 2);
            this.button2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button2.Location = new System.Drawing.Point(1, 594);
            this.button2.Margin = new System.Windows.Forms.Padding(1);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(192, 110);
            this.button2.TabIndex = 7;
            this.button2.Text = "VISUALIZAR";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // listObras
            // 
            this.listObras.BackColor = System.Drawing.Color.Honeydew;
            this.pizquierda.SetColumnSpan(this.listObras, 2);
            this.listObras.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listObras.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listObras.FormattingEnabled = true;
            this.listObras.ItemHeight = 20;
            this.listObras.Location = new System.Drawing.Point(3, 40);
            this.listObras.Name = "listObras";
            this.listObras.Size = new System.Drawing.Size(188, 550);
            this.listObras.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.pizquierda.SetColumnSpan(this.label2, 2);
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(188, 37);
            this.label2.TabIndex = 4;
            this.label2.Text = "OBRAS";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pderecho
            // 
            this.pderecho.ColumnCount = 1;
            this.pderecho.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pderecho.Controls.Add(this.dgfacturas, 0, 1);
            this.pderecho.Controls.Add(this.ltitulo, 0, 0);
            this.pderecho.Controls.Add(this.tableLayoutPanel3, 0, 2);
            this.pderecho.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pderecho.Location = new System.Drawing.Point(203, 3);
            this.pderecho.Name = "pderecho";
            this.pderecho.RowCount = 3;
            this.pderecho.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.263158F));
            this.pderecho.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 78.94736F));
            this.pderecho.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.78947F));
            this.pderecho.Size = new System.Drawing.Size(882, 705);
            this.pderecho.TabIndex = 2;
            // 
            // dgfacturas
            // 
            this.dgfacturas.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgfacturas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgfacturas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgfacturas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id_Factura,
            this.fecha,
            this.documento,
            this.N_Factura,
            this.proveedor,
            this.Cif,
            this.Base,
            this.importe,
            this.AsientoCompra});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.MintCream;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgfacturas.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgfacturas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgfacturas.Location = new System.Drawing.Point(3, 40);
            this.dgfacturas.Name = "dgfacturas";
            this.dgfacturas.ReadOnly = true;
            this.dgfacturas.RowHeadersVisible = false;
            this.dgfacturas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgfacturas.Size = new System.Drawing.Size(876, 550);
            this.dgfacturas.TabIndex = 3;
            this.dgfacturas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgfacturas_CellContentClick);
            this.dgfacturas.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgfacturas_CellContentDoubleClick);
            this.dgfacturas.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgfacturas_ColumnHeaderMouseClick);
            // 
            // Id_Factura
            // 
            this.Id_Factura.DataPropertyName = "Id_Factura";
            this.Id_Factura.HeaderText = "id_factura";
            this.Id_Factura.Name = "Id_Factura";
            this.Id_Factura.ReadOnly = true;
            this.Id_Factura.Visible = false;
            // 
            // fecha
            // 
            this.fecha.DataPropertyName = "Fecha";
            this.fecha.HeaderText = "Fecha";
            this.fecha.Name = "fecha";
            this.fecha.ReadOnly = true;
            // 
            // documento
            // 
            this.documento.DataPropertyName = "Ref_Fac";
            this.documento.HeaderText = "Nº Documento";
            this.documento.Name = "documento";
            this.documento.ReadOnly = true;
            // 
            // N_Factura
            // 
            this.N_Factura.DataPropertyName = "Su_ref";
            this.N_Factura.HeaderText = "Nº Factura";
            this.N_Factura.Name = "N_Factura";
            this.N_Factura.ReadOnly = true;
            // 
            // proveedor
            // 
            this.proveedor.DataPropertyName = "Proveedor";
            this.proveedor.HeaderText = "Proveedor";
            this.proveedor.Name = "proveedor";
            this.proveedor.ReadOnly = true;
            this.proveedor.Width = 300;
            // 
            // Cif
            // 
            this.Cif.DataPropertyName = "Cif";
            this.Cif.HeaderText = "Cif";
            this.Cif.Name = "Cif";
            this.Cif.ReadOnly = true;
            // 
            // Base
            // 
            this.Base.DataPropertyName = "Base";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Base.DefaultCellStyle = dataGridViewCellStyle1;
            this.Base.HeaderText = "Base";
            this.Base.Name = "Base";
            this.Base.ReadOnly = true;
            this.Base.Width = 90;
            // 
            // importe
            // 
            this.importe.DataPropertyName = "TotImporte";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.importe.DefaultCellStyle = dataGridViewCellStyle2;
            this.importe.HeaderText = "Importe";
            this.importe.Name = "importe";
            this.importe.ReadOnly = true;
            this.importe.Width = 90;
            // 
            // AsientoCompra
            // 
            this.AsientoCompra.DataPropertyName = "ApunteCompra";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.AsientoCompra.DefaultCellStyle = dataGridViewCellStyle3;
            this.AsientoCompra.HeaderText = "AsientoCompra";
            this.AsientoCompra.Name = "AsientoCompra";
            this.AsientoCompra.ReadOnly = true;
            this.AsientoCompra.Width = 80;
            // 
            // ltitulo
            // 
            this.ltitulo.AutoSize = true;
            this.ltitulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ltitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ltitulo.Location = new System.Drawing.Point(3, 0);
            this.ltitulo.Name = "ltitulo";
            this.ltitulo.Size = new System.Drawing.Size(876, 37);
            this.ltitulo.TabIndex = 2;
            this.ltitulo.Text = ".";
            this.ltitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.BackColor = System.Drawing.Color.LavenderBlush;
            this.tableLayoutPanel3.ColumnCount = 5;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.46753F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.46753F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.68831F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.37663F));
            this.tableLayoutPanel3.Controls.Add(this.label4, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.panel1, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.bttimprimir, 4, 1);
            this.tableLayoutPanel3.Controls.Add(this.txtcuenta, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.cbgrupo, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.bttver, 4, 0);
            this.tableLayoutPanel3.Controls.Add(this.bttpagar, 4, 2);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 596);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(876, 106);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 36);
            this.label4.TabIndex = 30;
            this.label4.Text = "Estado:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.rbpendientes);
            this.panel1.Controls.Add(this.rbfacturadas);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(103, 73);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(245, 30);
            this.panel1.TabIndex = 29;
            // 
            // rbpendientes
            // 
            this.rbpendientes.AutoSize = true;
            this.rbpendientes.Checked = true;
            this.rbpendientes.Location = new System.Drawing.Point(3, 6);
            this.rbpendientes.Name = "rbpendientes";
            this.rbpendientes.Size = new System.Drawing.Size(78, 17);
            this.rbpendientes.TabIndex = 2;
            this.rbpendientes.TabStop = true;
            this.rbpendientes.Text = "Pendientes";
            this.rbpendientes.UseVisualStyleBackColor = true;
            this.rbpendientes.CheckedChanged += new System.EventHandler(this.rbpendientes_CheckedChanged);
            // 
            // rbfacturadas
            // 
            this.rbfacturadas.AutoSize = true;
            this.rbfacturadas.Location = new System.Drawing.Point(87, 6);
            this.rbfacturadas.Name = "rbfacturadas";
            this.rbfacturadas.Size = new System.Drawing.Size(93, 17);
            this.rbfacturadas.TabIndex = 0;
            this.rbfacturadas.Text = "Contabilizadas";
            this.rbfacturadas.UseVisualStyleBackColor = true;
            this.rbfacturadas.CheckedChanged += new System.EventHandler(this.rbfacturadas_CheckedChanged);
            // 
            // bttimprimir
            // 
            this.bttimprimir.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bttimprimir.Location = new System.Drawing.Point(695, 38);
            this.bttimprimir.Name = "bttimprimir";
            this.bttimprimir.Size = new System.Drawing.Size(178, 29);
            this.bttimprimir.TabIndex = 27;
            this.bttimprimir.Text = "IMPRIMIR";
            this.bttimprimir.UseVisualStyleBackColor = true;
            this.bttimprimir.Click += new System.EventHandler(this.bttpagar_Click);
            // 
            // txtcuenta
            // 
            this.txtcuenta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtcuenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcuenta.Location = new System.Drawing.Point(103, 3);
            this.txtcuenta.Name = "txtcuenta";
            this.txtcuenta.Size = new System.Drawing.Size(245, 20);
            this.txtcuenta.TabIndex = 23;
            this.txtcuenta.TextChanged += new System.EventHandler(this.txtcuenta_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 35);
            this.label3.TabIndex = 22;
            this.label3.Text = "Capitulos:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 35);
            this.label1.TabIndex = 21;
            this.label1.Text = "Buscar:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbgrupo
            // 
            this.cbgrupo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbgrupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbgrupo.FormattingEnabled = true;
            this.cbgrupo.Location = new System.Drawing.Point(103, 38);
            this.cbgrupo.Name = "cbgrupo";
            this.cbgrupo.Size = new System.Drawing.Size(245, 21);
            this.cbgrupo.TabIndex = 24;
            this.cbgrupo.SelectionChangeCommitted += new System.EventHandler(this.cbgrupo_SelectedIndexChanged);
            // 
            // bttver
            // 
            this.bttver.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bttver.Location = new System.Drawing.Point(695, 3);
            this.bttver.Name = "bttver";
            this.bttver.Size = new System.Drawing.Size(178, 29);
            this.bttver.TabIndex = 28;
            this.bttver.Text = "VER";
            this.bttver.UseVisualStyleBackColor = true;
            this.bttver.Click += new System.EventHandler(this.bttver_Click);
            // 
            // bttpagar
            // 
            this.bttpagar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bttpagar.Location = new System.Drawing.Point(695, 73);
            this.bttpagar.Name = "bttpagar";
            this.bttpagar.Size = new System.Drawing.Size(178, 30);
            this.bttpagar.TabIndex = 31;
            this.bttpagar.Text = "PAGAR";
            this.bttpagar.UseVisualStyleBackColor = true;
            this.bttpagar.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form_Facturas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1088, 711);
            this.Controls.Add(this.pgeneral);
            this.Name = "Form_Facturas";
            this.Text = "Facturas";
            this.pgeneral.ResumeLayout(false);
            this.pizquierda.ResumeLayout(false);
            this.pizquierda.PerformLayout();
            this.pderecho.ResumeLayout(false);
            this.pderecho.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgfacturas)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel pgeneral;
        private System.Windows.Forms.TableLayoutPanel pizquierda;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ListBox listObras;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel pderecho;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label ltitulo;
        private System.Windows.Forms.DataGridView dgfacturas;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtcuenta;
        private System.Windows.Forms.ComboBox cbgrupo;
        private System.Windows.Forms.Button bttver;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rbfacturadas;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rbpendientes;
        private System.Windows.Forms.Button bttimprimir;
        private System.Windows.Forms.Button bttpagar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id_Factura;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn documento;
        private System.Windows.Forms.DataGridViewTextBoxColumn N_Factura;
        private System.Windows.Forms.DataGridViewTextBoxColumn proveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cif;
        private System.Windows.Forms.DataGridViewTextBoxColumn Base;
        private System.Windows.Forms.DataGridViewTextBoxColumn importe;
        private System.Windows.Forms.DataGridViewTextBoxColumn AsientoCompra;
    }
}