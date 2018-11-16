namespace GestionConstructora
{
    partial class Form_Tesoreria
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dginformes = new System.Windows.Forms.DataGridView();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Diasemana = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ingresos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Gastos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Saldo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ffin = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.finimovi = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.ffinmovi = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dgmovimientos = new System.Windows.Forms.DataGridView();
            this.Concepto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Debe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Haber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Saldo_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.dgcuentas = new System.Windows.Forms.DataGridView();
            this.Empresa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cuenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.cbmeses = new System.Windows.Forms.ComboBox();
            this.dggastosfijos = new System.Windows.Forms.DataGridView();
            this.Orden = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gf_fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gf_Concepto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gf_importe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.txtimporte = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cbconcepto = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            this.fagregar = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dginformes)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgmovimientos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgcuentas)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dggastosfijos)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(869, 543);
            this.tabControl1.TabIndex = 31;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.dginformes);
            this.tabPage1.Controls.Add(this.ffin);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(845, 455);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "TESORERIA";
            // 
            // dginformes
            // 
            this.dginformes.AllowUserToAddRows = false;
            this.dginformes.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dginformes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dginformes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dginformes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Fecha,
            this.Diasemana,
            this.Ingresos,
            this.Gastos,
            this.Saldo});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.MintCream;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dginformes.DefaultCellStyle = dataGridViewCellStyle5;
            this.dginformes.Location = new System.Drawing.Point(6, 58);
            this.dginformes.Name = "dginformes";
            this.dginformes.ReadOnly = true;
            this.dginformes.RowHeadersVisible = false;
            this.dginformes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dginformes.Size = new System.Drawing.Size(498, 391);
            this.dginformes.TabIndex = 34;
            // 
            // Fecha
            // 
            this.Fecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Fecha.DataPropertyName = "Fecha";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.Fecha.DefaultCellStyle = dataGridViewCellStyle1;
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            this.Fecha.ReadOnly = true;
            // 
            // Diasemana
            // 
            this.Diasemana.DataPropertyName = "Diasemana";
            this.Diasemana.HeaderText = "Diasemana";
            this.Diasemana.Name = "Diasemana";
            this.Diasemana.ReadOnly = true;
            this.Diasemana.Visible = false;
            // 
            // Ingresos
            // 
            this.Ingresos.DataPropertyName = "Ingresos";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.Ingresos.DefaultCellStyle = dataGridViewCellStyle2;
            this.Ingresos.HeaderText = "Ingresos";
            this.Ingresos.Name = "Ingresos";
            this.Ingresos.ReadOnly = true;
            // 
            // Gastos
            // 
            this.Gastos.DataPropertyName = "Gastos";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.Gastos.DefaultCellStyle = dataGridViewCellStyle3;
            this.Gastos.HeaderText = "Gastos";
            this.Gastos.Name = "Gastos";
            this.Gastos.ReadOnly = true;
            // 
            // Saldo
            // 
            this.Saldo.DataPropertyName = "Saldo";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.Saldo.DefaultCellStyle = dataGridViewCellStyle4;
            this.Saldo.HeaderText = "Saldo";
            this.Saldo.Name = "Saldo";
            this.Saldo.ReadOnly = true;
            // 
            // ffin
            // 
            this.ffin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.ffin.Location = new System.Drawing.Point(6, 32);
            this.ffin.Name = "ffin";
            this.ffin.Size = new System.Drawing.Size(178, 20);
            this.ffin.TabIndex = 32;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(190, 30);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(177, 22);
            this.button1.TabIndex = 33;
            this.button1.Text = "CALCULAR";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 31;
            this.label1.Text = "Fecha Fin";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.dgmovimientos);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.dgcuentas);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(861, 517);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "MOVIMIENTOS";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.finimovi);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.ffinmovi);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(6, 393);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(348, 121);
            this.groupBox1.TabIndex = 43;
            this.groupBox1.TabStop = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(6, 96);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(178, 22);
            this.button2.TabIndex = 41;
            this.button2.Text = "CALCULAR";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // finimovi
            // 
            this.finimovi.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.finimovi.Location = new System.Drawing.Point(6, 29);
            this.finimovi.Name = "finimovi";
            this.finimovi.Size = new System.Drawing.Size(178, 20);
            this.finimovi.TabIndex = 40;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 37;
            this.label3.Text = "Fecha Fin";
            // 
            // ffinmovi
            // 
            this.ffinmovi.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.ffinmovi.Location = new System.Drawing.Point(6, 67);
            this.ffinmovi.Name = "ffinmovi";
            this.ffinmovi.Size = new System.Drawing.Size(178, 20);
            this.ffinmovi.TabIndex = 38;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 39;
            this.label4.Text = "Fecha Inicio";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(7, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 13);
            this.label5.TabIndex = 42;
            this.label5.Text = "MOVIMIENTOS";
            // 
            // dgmovimientos
            // 
            this.dgmovimientos.AllowUserToAddRows = false;
            this.dgmovimientos.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgmovimientos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgmovimientos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgmovimientos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Concepto,
            this.Debe,
            this.Haber,
            this.Saldo_});
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.MintCream;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgmovimientos.DefaultCellStyle = dataGridViewCellStyle9;
            this.dgmovimientos.Location = new System.Drawing.Point(10, 28);
            this.dgmovimientos.Name = "dgmovimientos";
            this.dgmovimientos.ReadOnly = true;
            this.dgmovimientos.RowHeadersVisible = false;
            this.dgmovimientos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgmovimientos.Size = new System.Drawing.Size(840, 354);
            this.dgmovimientos.TabIndex = 41;
            // 
            // Concepto
            // 
            this.Concepto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Concepto.DataPropertyName = "Concepto";
            this.Concepto.HeaderText = "Concepto";
            this.Concepto.Name = "Concepto";
            this.Concepto.ReadOnly = true;
            // 
            // Debe
            // 
            this.Debe.DataPropertyName = "debe";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = null;
            this.Debe.DefaultCellStyle = dataGridViewCellStyle6;
            this.Debe.HeaderText = "Debe";
            this.Debe.Name = "Debe";
            this.Debe.ReadOnly = true;
            // 
            // Haber
            // 
            this.Haber.DataPropertyName = "haber";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N2";
            dataGridViewCellStyle7.NullValue = null;
            this.Haber.DefaultCellStyle = dataGridViewCellStyle7;
            this.Haber.HeaderText = "Haber";
            this.Haber.Name = "Haber";
            this.Haber.ReadOnly = true;
            // 
            // Saldo_
            // 
            this.Saldo_.DataPropertyName = "Saldo";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N2";
            dataGridViewCellStyle8.NullValue = null;
            this.Saldo_.DefaultCellStyle = dataGridViewCellStyle8;
            this.Saldo_.HeaderText = "Saldo";
            this.Saldo_.Name = "Saldo_";
            this.Saldo_.ReadOnly = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(502, 385);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 20);
            this.label2.TabIndex = 36;
            this.label2.Text = "Cuentas";
            // 
            // dgcuentas
            // 
            this.dgcuentas.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgcuentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgcuentas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Empresa,
            this.Cuenta,
            this.Nombre,
            this.cta});
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.MintCream;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgcuentas.DefaultCellStyle = dataGridViewCellStyle10;
            this.dgcuentas.Location = new System.Drawing.Point(506, 408);
            this.dgcuentas.Name = "dgcuentas";
            this.dgcuentas.ReadOnly = true;
            this.dgcuentas.RowHeadersVisible = false;
            this.dgcuentas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgcuentas.Size = new System.Drawing.Size(344, 103);
            this.dgcuentas.TabIndex = 35;
            // 
            // Empresa
            // 
            this.Empresa.HeaderText = "Empresa";
            this.Empresa.Name = "Empresa";
            this.Empresa.ReadOnly = true;
            this.Empresa.Visible = false;
            // 
            // Cuenta
            // 
            this.Cuenta.DataPropertyName = "CtaCte";
            this.Cuenta.HeaderText = "Cuenta";
            this.Cuenta.Name = "Cuenta";
            this.Cuenta.ReadOnly = true;
            this.Cuenta.Width = 180;
            // 
            // Nombre
            // 
            this.Nombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Nombre.DataPropertyName = "Banco";
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            // 
            // cta
            // 
            this.cta.DataPropertyName = "cta";
            this.cta.HeaderText = "cta";
            this.cta.Name = "cta";
            this.cta.ReadOnly = true;
            this.cta.Visible = false;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.cbmeses);
            this.tabPage3.Controls.Add(this.dggastosfijos);
            this.tabPage3.Controls.Add(this.groupBox2);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(845, 455);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "GASTOS FIJOS";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // cbmeses
            // 
            this.cbmeses.FormattingEnabled = true;
            this.cbmeses.Items.AddRange(new object[] {
            "ENERO",
            "FEBRERO",
            "MARZO",
            "ABRIL",
            "MAYO",
            "JUNIO",
            "JULIO",
            "AGOSTO",
            "SEPTIEMBRE",
            "OCTUBRE",
            "NOVIEMBRE",
            "DICIEMBRE"});
            this.cbmeses.Location = new System.Drawing.Point(104, 7);
            this.cbmeses.Name = "cbmeses";
            this.cbmeses.Size = new System.Drawing.Size(178, 21);
            this.cbmeses.TabIndex = 47;
            this.cbmeses.SelectionChangeCommitted += new System.EventHandler(this.cbmeses_SelectionChangeCommitted);
            // 
            // dggastosfijos
            // 
            this.dggastosfijos.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dggastosfijos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dggastosfijos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Orden,
            this.gf_fecha,
            this.gf_Concepto,
            this.gf_importe});
            this.dggastosfijos.Location = new System.Drawing.Point(8, 34);
            this.dggastosfijos.Name = "dggastosfijos";
            this.dggastosfijos.Size = new System.Drawing.Size(480, 392);
            this.dggastosfijos.TabIndex = 46;
            // 
            // Orden
            // 
            this.Orden.DataPropertyName = "Orden";
            this.Orden.HeaderText = "Orden";
            this.Orden.Name = "Orden";
            this.Orden.Visible = false;
            // 
            // gf_fecha
            // 
            this.gf_fecha.DataPropertyName = "Fecha";
            this.gf_fecha.HeaderText = "Fecha";
            this.gf_fecha.Name = "gf_fecha";
            // 
            // gf_Concepto
            // 
            this.gf_Concepto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.gf_Concepto.DataPropertyName = "Concepto";
            this.gf_Concepto.HeaderText = "Concepto";
            this.gf_Concepto.Name = "gf_Concepto";
            // 
            // gf_importe
            // 
            this.gf_importe.DataPropertyName = "Importe";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle11.Format = "N2";
            dataGridViewCellStyle11.NullValue = null;
            this.gf_importe.DefaultCellStyle = dataGridViewCellStyle11;
            this.gf_importe.HeaderText = "Importe";
            this.gf_importe.Name = "gf_importe";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Controls.Add(this.txtimporte);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.cbconcepto);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.fagregar);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Location = new System.Drawing.Point(494, 26);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(348, 172);
            this.groupBox2.TabIndex = 45;
            this.groupBox2.TabStop = false;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(99, 144);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(87, 22);
            this.button4.TabIndex = 46;
            this.button4.Text = "BORRAR";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // txtimporte
            // 
            this.txtimporte.Location = new System.Drawing.Point(6, 107);
            this.txtimporte.Name = "txtimporte";
            this.txtimporte.Size = new System.Drawing.Size(178, 20);
            this.txtimporte.TabIndex = 45;
            this.txtimporte.TextChanged += new System.EventHandler(this.txtimporte_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 91);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 13);
            this.label9.TabIndex = 43;
            this.label9.Text = "Importe";
            // 
            // cbconcepto
            // 
            this.cbconcepto.FormattingEnabled = true;
            this.cbconcepto.Items.AddRange(new object[] {
            "ALQUILER",
            "LUZ"});
            this.cbconcepto.Location = new System.Drawing.Point(6, 67);
            this.cbconcepto.Name = "cbconcepto";
            this.cbconcepto.Size = new System.Drawing.Size(178, 21);
            this.cbconcepto.TabIndex = 42;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(6, 144);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(87, 22);
            this.button3.TabIndex = 41;
            this.button3.Text = "AGREGAR";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // fagregar
            // 
            this.fagregar.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fagregar.Location = new System.Drawing.Point(6, 29);
            this.fagregar.Name = "fagregar";
            this.fagregar.Size = new System.Drawing.Size(178, 20);
            this.fagregar.TabIndex = 40;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 51);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 13);
            this.label7.TabIndex = 37;
            this.label7.Text = "Cooncepto";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 13);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 13);
            this.label8.TabIndex = 39;
            this.label8.Text = "Fecha Inicio";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(3, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 13);
            this.label6.TabIndex = 44;
            this.label6.Text = "GASTOS FIJOS";
            // 
            // Form_Tesoreria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 558);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form_Tesoreria";
            this.Text = "Form_Tesoreria";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dginformes)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgmovimientos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgcuentas)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dggastosfijos)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dginformes;
        private System.Windows.Forms.DateTimePicker ffin;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DateTimePicker finimovi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker ffinmovi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgmovimientos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgcuentas;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Diasemana;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ingresos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Gastos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Saldo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Empresa;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cuenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn cta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Concepto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Debe;
        private System.Windows.Forms.DataGridViewTextBoxColumn Haber;
        private System.Windows.Forms.DataGridViewTextBoxColumn Saldo_;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cbconcepto;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DateTimePicker fagregar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtimporte;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.DataGridView dggastosfijos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Orden;
        private System.Windows.Forms.DataGridViewTextBoxColumn gf_fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn gf_Concepto;
        private System.Windows.Forms.DataGridViewTextBoxColumn gf_importe;
        private System.Windows.Forms.ComboBox cbmeses;
    }
}