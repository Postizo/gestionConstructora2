namespace GestionConstructora
{
    partial class Form_AjusteGasto
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_AjusteGasto));
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtctimporte = new System.Windows.Forms.TextBox();
            this.txtcomentario = new System.Windows.Forms.RichTextBox();
            this.bttaceptar = new System.Windows.Forms.Button();
            this.dgingresos = new System.Windows.Forms.DataGridView();
            this.Id_Gastodcingresos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Conceptodcingresos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Importedcingresos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.añodcingresos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label6 = new System.Windows.Forms.Label();
            this.txtvalorventa = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtaño = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtconcepto = new System.Windows.Forms.TextBox();
            this.bttok = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dggastos = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgajustes = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btteditargastos = new System.Windows.Forms.Button();
            this.btteditarajustes = new System.Windows.Forms.Button();
            this.bttnuevoajuste = new System.Windows.Forms.Button();
            this.btteliminargasto = new System.Windows.Forms.Button();
            this.bttelimnarajuste = new System.Windows.Forms.Button();
            this.btteliminaringresos = new System.Windows.Forms.Button();
            this.btteditaringresos = new System.Windows.Forms.Button();
            this.bttnuevoingreso = new System.Windows.Forms.Button();
            this.bttnuevogasto = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgingresos)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dggastos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgajustes)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Importe";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 149);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Comentarios";
            // 
            // txtctimporte
            // 
            this.txtctimporte.BackColor = System.Drawing.Color.Ivory;
            this.txtctimporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtctimporte.Location = new System.Drawing.Point(16, 80);
            this.txtctimporte.Name = "txtctimporte";
            this.txtctimporte.Size = new System.Drawing.Size(100, 20);
            this.txtctimporte.TabIndex = 21;
            this.txtctimporte.Text = "0";
            this.txtctimporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtctimporte.Enter += new System.EventHandler(this.entrada);
            this.txtctimporte.Leave += new System.EventHandler(this.salida);
            // 
            // txtcomentario
            // 
            this.txtcomentario.BackColor = System.Drawing.Color.Ivory;
            this.txtcomentario.Location = new System.Drawing.Point(16, 165);
            this.txtcomentario.Name = "txtcomentario";
            this.txtcomentario.Size = new System.Drawing.Size(341, 131);
            this.txtcomentario.TabIndex = 22;
            this.txtcomentario.Text = "";
            // 
            // bttaceptar
            // 
            this.bttaceptar.Location = new System.Drawing.Point(768, 521);
            this.bttaceptar.Name = "bttaceptar";
            this.bttaceptar.Size = new System.Drawing.Size(125, 29);
            this.bttaceptar.TabIndex = 23;
            this.bttaceptar.Text = "GUARDAR";
            this.bttaceptar.UseVisualStyleBackColor = true;
            this.bttaceptar.Click += new System.EventHandler(this.button1_Click);
            // 
            // dgingresos
            // 
            this.dgingresos.AllowUserToAddRows = false;
            this.dgingresos.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgingresos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgingresos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgingresos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id_Gastodcingresos,
            this.Conceptodcingresos,
            this.Importedcingresos,
            this.añodcingresos});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.MintCream;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgingresos.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgingresos.Location = new System.Drawing.Point(8, 30);
            this.dgingresos.Name = "dgingresos";
            this.dgingresos.ReadOnly = true;
            this.dgingresos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgingresos.Size = new System.Drawing.Size(498, 120);
            this.dgingresos.TabIndex = 35;
            this.dgingresos.RowLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgingresos_RowLeave);
            this.dgingresos.SelectionChanged += new System.EventHandler(this.dgingresos_SelectionChanged);
            // 
            // Id_Gastodcingresos
            // 
            this.Id_Gastodcingresos.DataPropertyName = "id_Gasto";
            this.Id_Gastodcingresos.HeaderText = "Id_gasto";
            this.Id_Gastodcingresos.Name = "Id_Gastodcingresos";
            this.Id_Gastodcingresos.ReadOnly = true;
            this.Id_Gastodcingresos.Visible = false;
            // 
            // Conceptodcingresos
            // 
            this.Conceptodcingresos.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Conceptodcingresos.DataPropertyName = "Concepto";
            this.Conceptodcingresos.HeaderText = "Concepto";
            this.Conceptodcingresos.Name = "Conceptodcingresos";
            this.Conceptodcingresos.ReadOnly = true;
            // 
            // Importedcingresos
            // 
            this.Importedcingresos.DataPropertyName = "Importe";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = null;
            this.Importedcingresos.DefaultCellStyle = dataGridViewCellStyle1;
            this.Importedcingresos.HeaderText = "Importe";
            this.Importedcingresos.Name = "Importedcingresos";
            this.Importedcingresos.ReadOnly = true;
            // 
            // añodcingresos
            // 
            this.añodcingresos.DataPropertyName = "Año";
            this.añodcingresos.HeaderText = "Año";
            this.añodcingresos.Name = "añodcingresos";
            this.añodcingresos.ReadOnly = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Blue;
            this.label6.Location = new System.Drawing.Point(5, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 13);
            this.label6.TabIndex = 36;
            this.label6.Text = "INGRESOS";
            // 
            // txtvalorventa
            // 
            this.txtvalorventa.BackColor = System.Drawing.Color.Ivory;
            this.txtvalorventa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtvalorventa.Location = new System.Drawing.Point(98, 518);
            this.txtvalorventa.Name = "txtvalorventa";
            this.txtvalorventa.Size = new System.Drawing.Size(100, 20);
            this.txtvalorventa.TabIndex = 38;
            this.txtvalorventa.Text = "0";
            this.txtvalorventa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtvalorventa.TextChanged += new System.EventHandler(this.txtvalorventa_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 521);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 37;
            this.label3.Text = "Valor Venta";
            // 
            // txtaño
            // 
            this.txtaño.BackColor = System.Drawing.Color.Ivory;
            this.txtaño.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtaño.Location = new System.Drawing.Point(17, 122);
            this.txtaño.Name = "txtaño";
            this.txtaño.Size = new System.Drawing.Size(100, 20);
            this.txtaño.TabIndex = 40;
            this.txtaño.Text = "0";
            this.txtaño.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(14, 106);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 13);
            this.label7.TabIndex = 39;
            this.label7.Text = "Año ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtconcepto);
            this.groupBox1.Controls.Add(this.bttok);
            this.groupBox1.Controls.Add(this.txtcomentario);
            this.groupBox1.Controls.Add(this.txtaño);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtctimporte);
            this.groupBox1.Location = new System.Drawing.Point(526, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(367, 339);
            this.groupBox1.TabIndex = 41;
            this.groupBox1.TabStop = false;
            this.groupBox1.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(13, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 13);
            this.label8.TabIndex = 55;
            this.label8.Text = "Concepto";
            // 
            // txtconcepto
            // 
            this.txtconcepto.BackColor = System.Drawing.Color.Ivory;
            this.txtconcepto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtconcepto.Location = new System.Drawing.Point(16, 32);
            this.txtconcepto.Name = "txtconcepto";
            this.txtconcepto.Size = new System.Drawing.Size(341, 20);
            this.txtconcepto.TabIndex = 56;
            this.txtconcepto.Text = "0";
            this.txtconcepto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // bttok
            // 
            this.bttok.Image = global::GestionConstructora.Properties.Resources.comprobado_1_;
            this.bttok.Location = new System.Drawing.Point(296, 302);
            this.bttok.Name = "bttok";
            this.bttok.Size = new System.Drawing.Size(61, 29);
            this.bttok.TabIndex = 54;
            this.bttok.UseVisualStyleBackColor = true;
            this.bttok.Click += new System.EventHandler(this.button8_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(6, 198);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 43;
            this.label4.Text = "GASTOS";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DarkRed;
            this.label5.Location = new System.Drawing.Point(6, 376);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 45;
            this.label5.Text = "AJUSTES";
            // 
            // dggastos
            // 
            this.dggastos.AllowUserToAddRows = false;
            this.dggastos.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dggastos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dggastos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dggastos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.MintCream;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dggastos.DefaultCellStyle = dataGridViewCellStyle4;
            this.dggastos.Location = new System.Drawing.Point(8, 214);
            this.dggastos.Name = "dggastos";
            this.dggastos.ReadOnly = true;
            this.dggastos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dggastos.Size = new System.Drawing.Size(498, 120);
            this.dggastos.TabIndex = 46;
            this.dggastos.RowLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dggastos_RowLeave);
            this.dggastos.SelectionChanged += new System.EventHandler(this.dggastos_SelectionChanged);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "id_gasto";
            this.dataGridViewTextBoxColumn1.HeaderText = "Id_gasto";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Concepto";
            this.dataGridViewTextBoxColumn2.HeaderText = "Concepto";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Importe";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn3.HeaderText = "Importe";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Año";
            this.dataGridViewTextBoxColumn4.HeaderText = "Año";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dgajustes
            // 
            this.dgajustes.AllowUserToAddRows = false;
            this.dgajustes.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgajustes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgajustes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgajustes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.MintCream;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgajustes.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgajustes.Location = new System.Drawing.Point(8, 392);
            this.dgajustes.Name = "dgajustes";
            this.dgajustes.ReadOnly = true;
            this.dgajustes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgajustes.Size = new System.Drawing.Size(498, 120);
            this.dgajustes.TabIndex = 47;
            this.dgajustes.RowLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgajustes_RowLeave);
            this.dgajustes.SelectionChanged += new System.EventHandler(this.dgajustes_SelectionChanged);
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Id_Gasto";
            this.dataGridViewTextBoxColumn5.HeaderText = "Id_gasto";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Visible = false;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Concepto";
            this.dataGridViewTextBoxColumn6.HeaderText = "Concepto";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "Importe";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            this.dataGridViewTextBoxColumn7.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewTextBoxColumn7.HeaderText = "Importe";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "Año";
            this.dataGridViewTextBoxColumn8.HeaderText = "Año";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // btteditargastos
            // 
            this.btteditargastos.Image = global::GestionConstructora.Properties.Resources.editar1;
            this.btteditargastos.Location = new System.Drawing.Point(410, 340);
            this.btteditargastos.Name = "btteditargastos";
            this.btteditargastos.Size = new System.Drawing.Size(45, 29);
            this.btteditargastos.TabIndex = 49;
            this.btteditargastos.UseVisualStyleBackColor = true;
            this.btteditargastos.Click += new System.EventHandler(this.button3_Click);
            // 
            // btteditarajustes
            // 
            this.btteditarajustes.Image = global::GestionConstructora.Properties.Resources.editar1;
            this.btteditarajustes.Location = new System.Drawing.Point(410, 515);
            this.btteditarajustes.Name = "btteditarajustes";
            this.btteditarajustes.Size = new System.Drawing.Size(45, 29);
            this.btteditarajustes.TabIndex = 53;
            this.btteditarajustes.UseVisualStyleBackColor = true;
            this.btteditarajustes.Click += new System.EventHandler(this.button6_Click);
            // 
            // bttnuevoajuste
            // 
            this.bttnuevoajuste.Image = global::GestionConstructora.Properties.Resources.anadir;
            this.bttnuevoajuste.Location = new System.Drawing.Point(359, 515);
            this.bttnuevoajuste.Name = "bttnuevoajuste";
            this.bttnuevoajuste.Size = new System.Drawing.Size(45, 29);
            this.bttnuevoajuste.TabIndex = 52;
            this.bttnuevoajuste.UseVisualStyleBackColor = true;
            this.bttnuevoajuste.Click += new System.EventHandler(this.bttnuevoajuste_Click);
            // 
            // btteliminargasto
            // 
            this.btteliminargasto.Image = global::GestionConstructora.Properties.Resources.boton_de_borrar;
            this.btteliminargasto.Location = new System.Drawing.Point(461, 340);
            this.btteliminargasto.Name = "btteliminargasto";
            this.btteliminargasto.Size = new System.Drawing.Size(45, 29);
            this.btteliminargasto.TabIndex = 55;
            this.btteliminargasto.UseVisualStyleBackColor = true;
            this.btteliminargasto.Click += new System.EventHandler(this.btteliminargasto_Click);
            // 
            // bttelimnarajuste
            // 
            this.bttelimnarajuste.Image = global::GestionConstructora.Properties.Resources.boton_de_borrar;
            this.bttelimnarajuste.Location = new System.Drawing.Point(461, 515);
            this.bttelimnarajuste.Name = "bttelimnarajuste";
            this.bttelimnarajuste.Size = new System.Drawing.Size(45, 29);
            this.bttelimnarajuste.TabIndex = 56;
            this.bttelimnarajuste.UseVisualStyleBackColor = true;
            this.bttelimnarajuste.Click += new System.EventHandler(this.bttelimnarajuste_Click);
            // 
            // btteliminaringresos
            // 
            this.btteliminaringresos.Image = ((System.Drawing.Image)(resources.GetObject("btteliminaringresos.Image")));
            this.btteliminaringresos.Location = new System.Drawing.Point(461, 156);
            this.btteliminaringresos.Name = "btteliminaringresos";
            this.btteliminaringresos.Size = new System.Drawing.Size(45, 29);
            this.btteliminaringresos.TabIndex = 54;
            this.btteliminaringresos.UseVisualStyleBackColor = true;
            this.btteliminaringresos.Click += new System.EventHandler(this.btteliminaringresos_Click);
            // 
            // btteditaringresos
            // 
            this.btteditaringresos.Image = ((System.Drawing.Image)(resources.GetObject("btteditaringresos.Image")));
            this.btteditaringresos.Location = new System.Drawing.Point(410, 156);
            this.btteditaringresos.Name = "btteditaringresos";
            this.btteditaringresos.Size = new System.Drawing.Size(45, 29);
            this.btteditaringresos.TabIndex = 51;
            this.btteditaringresos.UseVisualStyleBackColor = true;
            this.btteditaringresos.Click += new System.EventHandler(this.button4_Click);
            // 
            // bttnuevoingreso
            // 
            this.bttnuevoingreso.Image = ((System.Drawing.Image)(resources.GetObject("bttnuevoingreso.Image")));
            this.bttnuevoingreso.Location = new System.Drawing.Point(359, 156);
            this.bttnuevoingreso.Name = "bttnuevoingreso";
            this.bttnuevoingreso.Size = new System.Drawing.Size(45, 29);
            this.bttnuevoingreso.TabIndex = 50;
            this.bttnuevoingreso.UseVisualStyleBackColor = true;
            this.bttnuevoingreso.Click += new System.EventHandler(this.button5_Click);
            // 
            // bttnuevogasto
            // 
            this.bttnuevogasto.Image = global::GestionConstructora.Properties.Resources.anadir;
            this.bttnuevogasto.Location = new System.Drawing.Point(359, 340);
            this.bttnuevogasto.Name = "bttnuevogasto";
            this.bttnuevogasto.Size = new System.Drawing.Size(45, 29);
            this.bttnuevogasto.TabIndex = 48;
            this.bttnuevogasto.UseVisualStyleBackColor = true;
            this.bttnuevogasto.Click += new System.EventHandler(this.bttnuevogasto_Click);
            // 
            // Form_AjusteGasto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(907, 556);
            this.Controls.Add(this.bttelimnarajuste);
            this.Controls.Add(this.btteliminargasto);
            this.Controls.Add(this.btteliminaringresos);
            this.Controls.Add(this.btteditarajustes);
            this.Controls.Add(this.bttnuevoajuste);
            this.Controls.Add(this.btteditaringresos);
            this.Controls.Add(this.bttnuevoingreso);
            this.Controls.Add(this.btteditargastos);
            this.Controls.Add(this.bttnuevogasto);
            this.Controls.Add(this.dgajustes);
            this.Controls.Add(this.dggastos);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtvalorventa);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dgingresos);
            this.Controls.Add(this.bttaceptar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_AjusteGasto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "v";
            this.Load += new System.EventHandler(this.Form_AjusteGasto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgingresos)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dggastos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgajustes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtctimporte;
        private System.Windows.Forms.RichTextBox txtcomentario;
        private System.Windows.Forms.Button bttaceptar;
        private System.Windows.Forms.DataGridView dgingresos;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtvalorventa;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtaño;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button bttok;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dggastos;
        private System.Windows.Forms.DataGridView dgajustes;
        private System.Windows.Forms.Button bttnuevogasto;
        private System.Windows.Forms.Button btteditargastos;
        private System.Windows.Forms.Button btteditaringresos;
        private System.Windows.Forms.Button bttnuevoingreso;
        private System.Windows.Forms.Button btteditarajustes;
        private System.Windows.Forms.Button bttnuevoajuste;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtconcepto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id_Gastodcingresos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Conceptodcingresos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Importedcingresos;
        private System.Windows.Forms.DataGridViewTextBoxColumn añodcingresos;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.Button btteliminaringresos;
        private System.Windows.Forms.Button btteliminargasto;
        private System.Windows.Forms.Button bttelimnarajuste;
    }
}