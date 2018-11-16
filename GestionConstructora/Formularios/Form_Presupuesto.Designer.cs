namespace GestionConstructora
{
    partial class Form_Presupuesto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Presupuesto));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.TreeListViewItemCollection.TreeListViewItemCollectionComparer treeListViewItemCollectionComparer1 = new System.Windows.Forms.TreeListViewItemCollection.TreeListViewItemCollectionComparer();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.linfo = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dglineas = new System.Windows.Forms.DataGridView();
            this.Id_estancia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estancia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.cbestancias = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.label10 = new System.Windows.Forms.Label();
            this.rbalta = new System.Windows.Forms.RadioButton();
            this.rbmedia = new System.Windows.Forms.RadioButton();
            this.rbbaja = new System.Windows.Forms.RadioButton();
            this.label11 = new System.Windows.Forms.Label();
            this.txtviviendas = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lpresupuest = new System.Windows.Forms.TreeListView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.txtbeneficio = new System.Windows.Forms.TextBox();
            this.txtgastosgenerales = new System.Windows.Forms.TextBox();
            this.txtmargenmateriales = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txttotalmanoobra = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtndias = new System.Windows.Forms.TextBox();
            this.txthorasdias = new System.Windows.Forms.TextBox();
            this.txtNpersonas = new System.Windows.Forms.TextBox();
            this.txtCtHora = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Dgresumen = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Importe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbDespeglar = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dglineas)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgresumen)).BeginInit();
            this.SuspendLayout();
            // 
            // linfo
            // 
            this.linfo.AutoSize = true;
            this.linfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linfo.ForeColor = System.Drawing.Color.Blue;
            this.linfo.Location = new System.Drawing.Point(14, 9);
            this.linfo.Name = "linfo";
            this.linfo.Size = new System.Drawing.Size(51, 20);
            this.linfo.TabIndex = 5;
            this.linfo.Text = "label1";
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
            this.imageList1.Images.SetKeyName(9, "recibir(1).png");
            this.imageList1.Images.SetKeyName(10, "recibir.png");
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 177F));
            this.tableLayoutPanel1.Controls.Add(this.dglineas, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel2, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 0F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 139F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(428, 373);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // dglineas
            // 
            this.dglineas.AllowUserToAddRows = false;
            this.dglineas.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dglineas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dglineas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id_estancia,
            this.Estancia});
            this.tableLayoutPanel1.SetColumnSpan(this.dglineas, 2);
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.MintCream;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dglineas.DefaultCellStyle = dataGridViewCellStyle1;
            this.dglineas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dglineas.Location = new System.Drawing.Point(3, 3);
            this.dglineas.Name = "dglineas";
            this.dglineas.ReadOnly = true;
            this.dglineas.RowHeadersVisible = false;
            this.dglineas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dglineas.Size = new System.Drawing.Size(422, 228);
            this.dglineas.TabIndex = 27;
            // 
            // Id_estancia
            // 
            this.Id_estancia.DataPropertyName = "Id_estancia";
            this.Id_estancia.HeaderText = "Id";
            this.Id_estancia.Name = "Id_estancia";
            this.Id_estancia.ReadOnly = true;
            this.Id_estancia.Visible = false;
            this.Id_estancia.Width = 90;
            // 
            // Estancia
            // 
            this.Estancia.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Estancia.DataPropertyName = "Nombre";
            this.Estancia.HeaderText = "Estancia";
            this.Estancia.Name = "Estancia";
            this.Estancia.ReadOnly = true;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.Controls.Add(this.label4);
            this.flowLayoutPanel1.Controls.Add(this.cbestancias);
            this.flowLayoutPanel1.Controls.Add(this.button1);
            this.flowLayoutPanel1.Controls.Add(this.button3);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 237);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(245, 133);
            this.flowLayoutPanel1.TabIndex = 30;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 13);
            this.label4.TabIndex = 33;
            this.label4.Text = "Nueva Estancia";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbestancias
            // 
            this.cbestancias.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbestancias.FormattingEnabled = true;
            this.cbestancias.Location = new System.Drawing.Point(3, 16);
            this.cbestancias.Name = "cbestancias";
            this.cbestancias.Size = new System.Drawing.Size(203, 24);
            this.cbestancias.TabIndex = 34;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 46);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(203, 27);
            this.button1.TabIndex = 35;
            this.button1.Text = "Agregar Estancia";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(3, 79);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(203, 27);
            this.button3.TabIndex = 36;
            this.button3.Text = "Borrar Estancia";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.label10);
            this.flowLayoutPanel2.Controls.Add(this.rbalta);
            this.flowLayoutPanel2.Controls.Add(this.rbmedia);
            this.flowLayoutPanel2.Controls.Add(this.rbbaja);
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(254, 237);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(171, 133);
            this.flowLayoutPanel2.TabIndex = 31;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(3, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(112, 13);
            this.label10.TabIndex = 34;
            this.label10.Text = "Calidad de la Obra";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rbalta
            // 
            this.rbalta.AutoSize = true;
            this.rbalta.Checked = true;
            this.rbalta.Location = new System.Drawing.Point(3, 16);
            this.rbalta.Name = "rbalta";
            this.rbalta.Size = new System.Drawing.Size(43, 17);
            this.rbalta.TabIndex = 0;
            this.rbalta.TabStop = true;
            this.rbalta.Text = "Alta";
            this.rbalta.UseVisualStyleBackColor = true;
            this.rbalta.CheckedChanged += new System.EventHandler(this.rbalta_CheckedChanged);
            // 
            // rbmedia
            // 
            this.rbmedia.AutoSize = true;
            this.rbmedia.Location = new System.Drawing.Point(3, 39);
            this.rbmedia.Name = "rbmedia";
            this.rbmedia.Size = new System.Drawing.Size(54, 17);
            this.rbmedia.TabIndex = 1;
            this.rbmedia.Text = "Media";
            this.rbmedia.UseVisualStyleBackColor = true;
            this.rbmedia.CheckedChanged += new System.EventHandler(this.rbmedia_CheckedChanged);
            // 
            // rbbaja
            // 
            this.rbbaja.AutoSize = true;
            this.rbbaja.Location = new System.Drawing.Point(3, 62);
            this.rbbaja.Name = "rbbaja";
            this.rbbaja.Size = new System.Drawing.Size(46, 17);
            this.rbbaja.TabIndex = 2;
            this.rbbaja.Text = "Baja";
            this.rbbaja.UseVisualStyleBackColor = true;
            this.rbbaja.CheckedChanged += new System.EventHandler(this.rbbaja_CheckedChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(212, 126);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(80, 13);
            this.label11.TabIndex = 35;
            this.label11.Text = "Nº Viviendas";
            // 
            // txtviviendas
            // 
            this.txtviviendas.BackColor = System.Drawing.Color.Ivory;
            this.txtviviendas.Location = new System.Drawing.Point(316, 119);
            this.txtviviendas.Name = "txtviviendas";
            this.txtviviendas.Size = new System.Drawing.Size(100, 20);
            this.txtviviendas.TabIndex = 26;
            this.txtviviendas.Text = "1";
            this.txtviviendas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtviviendas.TextChanged += new System.EventHandler(this.txtviviendas_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Location = new System.Drawing.Point(12, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(434, 392);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detalle Presupuesto";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Nombre";
            this.columnHeader4.Width = 250;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Importe";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader5.Width = 100;
            // 
            // lpresupuest
            // 
            this.lpresupuest.BackColor = System.Drawing.SystemColors.Control;
            this.lpresupuest.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5});
            treeListViewItemCollectionComparer1.Column = 0;
            treeListViewItemCollectionComparer1.SortOrder = System.Windows.Forms.SortOrder.None;
            this.lpresupuest.Comparer = treeListViewItemCollectionComparer1;
            this.lpresupuest.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lpresupuest.Location = new System.Drawing.Point(480, 32);
            this.lpresupuest.MultiSelect = false;
            this.lpresupuest.Name = "lpresupuest";
            this.lpresupuest.Size = new System.Drawing.Size(382, 374);
            this.lpresupuest.SmallImageList = this.imageList1;
            this.lpresupuest.Sorting = System.Windows.Forms.SortOrder.None;
            this.lpresupuest.TabIndex = 6;
            this.lpresupuest.UseCompatibleStateImageBehavior = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.txtbeneficio);
            this.groupBox2.Controls.Add(this.txtgastosgenerales);
            this.groupBox2.Controls.Add(this.txtmargenmateriales);
            this.groupBox2.Controls.Add(this.txtviviendas);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Location = new System.Drawing.Point(12, 430);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(427, 192);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Margenes Comerciales";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(215, 148);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(201, 31);
            this.button2.TabIndex = 25;
            this.button2.Text = "CALCULAR";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtbeneficio
            // 
            this.txtbeneficio.BackColor = System.Drawing.Color.Ivory;
            this.txtbeneficio.Location = new System.Drawing.Point(316, 84);
            this.txtbeneficio.Name = "txtbeneficio";
            this.txtbeneficio.Size = new System.Drawing.Size(100, 20);
            this.txtbeneficio.TabIndex = 24;
            this.txtbeneficio.Text = "6";
            this.txtbeneficio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtbeneficio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ReplacePunto);
            this.txtbeneficio.Validated += new System.EventHandler(this.txtimporte_Validated);
            // 
            // txtgastosgenerales
            // 
            this.txtgastosgenerales.BackColor = System.Drawing.Color.Ivory;
            this.txtgastosgenerales.Location = new System.Drawing.Point(316, 60);
            this.txtgastosgenerales.Name = "txtgastosgenerales";
            this.txtgastosgenerales.Size = new System.Drawing.Size(100, 20);
            this.txtgastosgenerales.TabIndex = 23;
            this.txtgastosgenerales.Text = "13";
            this.txtgastosgenerales.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtgastosgenerales.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ReplacePunto);
            this.txtgastosgenerales.Validated += new System.EventHandler(this.txtimporte_Validated);
            // 
            // txtmargenmateriales
            // 
            this.txtmargenmateriales.BackColor = System.Drawing.Color.Ivory;
            this.txtmargenmateriales.Location = new System.Drawing.Point(316, 35);
            this.txtmargenmateriales.Name = "txtmargenmateriales";
            this.txtmargenmateriales.Size = new System.Drawing.Size(100, 20);
            this.txtmargenmateriales.TabIndex = 22;
            this.txtmargenmateriales.Text = "45";
            this.txtmargenmateriales.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtmargenmateriales.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ReplacePunto);
            this.txtmargenmateriales.Validated += new System.EventHandler(this.txtimporte_Validated);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(212, 87);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "Beneficio";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(212, 63);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(107, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Gastos Generales";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(212, 39);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Margen Material";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txttotalmanoobra);
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.txtndias);
            this.groupBox3.Controls.Add(this.txthorasdias);
            this.groupBox3.Controls.Add(this.txtNpersonas);
            this.groupBox3.Controls.Add(this.txtCtHora);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(10, 17);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(196, 164);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Mano de Obra";
            // 
            // txttotalmanoobra
            // 
            this.txttotalmanoobra.BackColor = System.Drawing.Color.Ivory;
            this.txttotalmanoobra.Location = new System.Drawing.Point(90, 131);
            this.txttotalmanoobra.Name = "txttotalmanoobra";
            this.txttotalmanoobra.Size = new System.Drawing.Size(100, 20);
            this.txttotalmanoobra.TabIndex = 21;
            this.txttotalmanoobra.Text = "1";
            this.txttotalmanoobra.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txttotalmanoobra.TextChanged += new System.EventHandler(this.txtimporte_Validated);
            this.txttotalmanoobra.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ReplacePunto);
            this.txttotalmanoobra.Validated += new System.EventHandler(this.txtimporte_Validated);
            // 
            // groupBox4
            // 
            this.groupBox4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox4.Location = new System.Drawing.Point(17, 115);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(173, 10);
            this.groupBox4.TabIndex = 11;
            this.groupBox4.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(14, 134);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Total";
            // 
            // txtndias
            // 
            this.txtndias.BackColor = System.Drawing.Color.Ivory;
            this.txtndias.Location = new System.Drawing.Point(90, 94);
            this.txtndias.Name = "txtndias";
            this.txtndias.Size = new System.Drawing.Size(100, 20);
            this.txtndias.TabIndex = 19;
            this.txtndias.Text = "1";
            this.txtndias.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtndias.TextChanged += new System.EventHandler(this.txtCtHora_TextChanged);
            this.txtndias.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ReplacePunto);
            this.txtndias.Validated += new System.EventHandler(this.txtimporte_Validated);
            // 
            // txthorasdias
            // 
            this.txthorasdias.BackColor = System.Drawing.Color.Ivory;
            this.txthorasdias.Location = new System.Drawing.Point(90, 70);
            this.txthorasdias.Name = "txthorasdias";
            this.txthorasdias.Size = new System.Drawing.Size(100, 20);
            this.txthorasdias.TabIndex = 18;
            this.txthorasdias.Text = "1";
            this.txthorasdias.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txthorasdias.TextChanged += new System.EventHandler(this.txtCtHora_TextChanged);
            this.txthorasdias.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ReplacePunto);
            this.txthorasdias.Validated += new System.EventHandler(this.txtimporte_Validated);
            // 
            // txtNpersonas
            // 
            this.txtNpersonas.BackColor = System.Drawing.Color.Ivory;
            this.txtNpersonas.Location = new System.Drawing.Point(90, 46);
            this.txtNpersonas.Name = "txtNpersonas";
            this.txtNpersonas.Size = new System.Drawing.Size(100, 20);
            this.txtNpersonas.TabIndex = 17;
            this.txtNpersonas.Text = "1";
            this.txtNpersonas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtNpersonas.TextChanged += new System.EventHandler(this.txtCtHora_TextChanged);
            this.txtNpersonas.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ReplacePunto);
            this.txtNpersonas.Validated += new System.EventHandler(this.txtimporte_Validated);
            // 
            // txtCtHora
            // 
            this.txtCtHora.BackColor = System.Drawing.Color.Ivory;
            this.txtCtHora.Location = new System.Drawing.Point(90, 22);
            this.txtCtHora.Name = "txtCtHora";
            this.txtCtHora.Size = new System.Drawing.Size(100, 20);
            this.txtCtHora.TabIndex = 16;
            this.txtCtHora.Text = "1";
            this.txtCtHora.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCtHora.TextChanged += new System.EventHandler(this.txtCtHora_TextChanged);
            this.txtCtHora.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ReplacePunto);
            this.txtCtHora.Validated += new System.EventHandler(this.txtimporte_Validated);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(14, 97);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Nº Dias";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Horas/Dia";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Nº Personas";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Cte Hora";
            // 
            // Dgresumen
            // 
            this.Dgresumen.AllowUserToAddRows = false;
            this.Dgresumen.BackgroundColor = System.Drawing.SystemColors.Control;
            this.Dgresumen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgresumen.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.Importe});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.MintCream;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Dgresumen.DefaultCellStyle = dataGridViewCellStyle3;
            this.Dgresumen.Enabled = false;
            this.Dgresumen.Location = new System.Drawing.Point(479, 449);
            this.Dgresumen.Name = "Dgresumen";
            this.Dgresumen.ReadOnly = true;
            this.Dgresumen.RowHeadersVisible = false;
            this.Dgresumen.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.Dgresumen.Size = new System.Drawing.Size(382, 175);
            this.Dgresumen.TabIndex = 28;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Concepto";
            this.dataGridViewTextBoxColumn2.HeaderText = "Concepto";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // Importe
            // 
            this.Importe.DataPropertyName = "Importe";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = null;
            this.Importe.DefaultCellStyle = dataGridViewCellStyle2;
            this.Importe.HeaderText = "Importe";
            this.Importe.Name = "Importe";
            this.Importe.ReadOnly = true;
            // 
            // cbDespeglar
            // 
            this.cbDespeglar.AutoSize = true;
            this.cbDespeglar.Location = new System.Drawing.Point(479, 424);
            this.cbDespeglar.Name = "cbDespeglar";
            this.cbDespeglar.Size = new System.Drawing.Size(76, 17);
            this.cbDespeglar.TabIndex = 29;
            this.cbDespeglar.Text = "Ver detalle";
            this.cbDespeglar.UseVisualStyleBackColor = true;
            this.cbDespeglar.CheckedChanged += new System.EventHandler(this.cbDespeglar_CheckedChanged);
            // 
            // Form_Presupuesto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 634);
            this.Controls.Add(this.cbDespeglar);
            this.Controls.Add(this.Dgresumen);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.lpresupuest);
            this.Controls.Add(this.linfo);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_Presupuesto";
            this.Text = "Presupuesto";
            this.Load += new System.EventHandler(this.Form_Presupuesto_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dglineas)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgresumen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label linfo;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dglineas;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id_estancia;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estancia;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbestancias;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.TreeListView lpresupuest;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtbeneficio;
        private System.Windows.Forms.TextBox txtgastosgenerales;
        private System.Windows.Forms.TextBox txtmargenmateriales;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txttotalmanoobra;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtndias;
        private System.Windows.Forms.TextBox txthorasdias;
        private System.Windows.Forms.TextBox txtNpersonas;
        private System.Windows.Forms.TextBox txtCtHora;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView Dgresumen;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.RadioButton rbalta;
        private System.Windows.Forms.RadioButton rbmedia;
        private System.Windows.Forms.RadioButton rbbaja;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Importe;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox cbDespeglar;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtviviendas;
    }
}