namespace GestionConstructora
{
    partial class Form_Obras
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Obras));
            this.llegenda = new System.Windows.Forms.Label();
            this.lnombre = new System.Windows.Forms.Label();
            this.txtnombre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pbotones = new System.Windows.Forms.FlowLayoutPanel();
            this.bttnuevo = new System.Windows.Forms.Button();
            this.btteditar = new System.Windows.Forms.Button();
            this.bttborrar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.pdatos = new System.Windows.Forms.FlowLayoutPanel();
            this.txtidobra = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_idsigrid = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtm_construido = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.prbtipos = new System.Windows.Forms.FlowLayoutPanel();
            this.Rbpropias = new System.Windows.Forms.RadioButton();
            this.Rbajenas = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.rbestudio = new System.Windows.Forms.RadioButton();
            this.rbejecucion = new System.Windows.Forms.RadioButton();
            this.rbfinalizada = new System.Windows.Forms.RadioButton();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.bttañadir = new System.Windows.Forms.Button();
            this.bttgruposrel = new System.Windows.Forms.Button();
            this.pcontenedor = new System.Windows.Forms.TableLayoutPanel();
            this.dgobras = new System.Windows.Forms.DataGridView();
            this.Id_Obra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button2 = new System.Windows.Forms.Button();
            this.pbotones.SuspendLayout();
            this.pdatos.SuspendLayout();
            this.prbtipos.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.pcontenedor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgobras)).BeginInit();
            this.SuspendLayout();
            // 
            // llegenda
            // 
            this.llegenda.AutoSize = true;
            this.llegenda.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.llegenda.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llegenda.Location = new System.Drawing.Point(3, 0);
            this.llegenda.Name = "llegenda";
            this.llegenda.Padding = new System.Windows.Forms.Padding(2, 10, 2, 2);
            this.llegenda.Size = new System.Drawing.Size(334, 32);
            this.llegenda.TabIndex = 1;
            this.llegenda.Text = "Nombre";
            this.llegenda.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lnombre
            // 
            this.lnombre.AutoSize = true;
            this.lnombre.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lnombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnombre.Location = new System.Drawing.Point(3, 32);
            this.lnombre.Name = "lnombre";
            this.lnombre.Padding = new System.Windows.Forms.Padding(2, 5, 2, 2);
            this.lnombre.Size = new System.Drawing.Size(334, 27);
            this.lnombre.TabIndex = 3;
            this.lnombre.Text = "Nombre";
            // 
            // txtnombre
            // 
            this.txtnombre.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtnombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtnombre.Location = new System.Drawing.Point(3, 62);
            this.txtnombre.Name = "txtnombre";
            this.txtnombre.Size = new System.Drawing.Size(334, 26);
            this.txtnombre.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 91);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(2, 5, 2, 2);
            this.label2.Size = new System.Drawing.Size(334, 27);
            this.label2.TabIndex = 7;
            this.label2.Text = "Obra(Canal)";
            // 
            // pbotones
            // 
            this.pbotones.Controls.Add(this.bttnuevo);
            this.pbotones.Controls.Add(this.btteditar);
            this.pbotones.Controls.Add(this.bttborrar);
            this.pbotones.Controls.Add(this.button1);
            this.pbotones.Controls.Add(this.button2);
            this.pbotones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pbotones.Location = new System.Drawing.Point(435, 551);
            this.pbotones.Name = "pbotones";
            this.pbotones.Size = new System.Drawing.Size(427, 82);
            this.pbotones.TabIndex = 2;
            this.pbotones.Paint += new System.Windows.Forms.PaintEventHandler(this.pbotones_Paint);
            // 
            // bttnuevo
            // 
            this.bttnuevo.Image = global::GestionConstructora.Properties.Resources.mas;
            this.bttnuevo.Location = new System.Drawing.Point(3, 3);
            this.bttnuevo.Name = "bttnuevo";
            this.bttnuevo.Size = new System.Drawing.Size(75, 75);
            this.bttnuevo.TabIndex = 1;
            this.bttnuevo.UseVisualStyleBackColor = true;
            this.bttnuevo.Click += new System.EventHandler(this.bttnuevo_Click);
            // 
            // btteditar
            // 
            this.btteditar.Image = global::GestionConstructora.Properties.Resources.editar;
            this.btteditar.Location = new System.Drawing.Point(84, 3);
            this.btteditar.Name = "btteditar";
            this.btteditar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btteditar.Size = new System.Drawing.Size(75, 75);
            this.btteditar.TabIndex = 0;
            this.btteditar.UseVisualStyleBackColor = true;
            this.btteditar.Click += new System.EventHandler(this.btteditar_Click);
            // 
            // bttborrar
            // 
            this.bttborrar.Image = global::GestionConstructora.Properties.Resources.cancelar;
            this.bttborrar.Location = new System.Drawing.Point(165, 3);
            this.bttborrar.Name = "bttborrar";
            this.bttborrar.Size = new System.Drawing.Size(75, 75);
            this.bttborrar.TabIndex = 2;
            this.bttborrar.UseVisualStyleBackColor = true;
            this.bttborrar.Click += new System.EventHandler(this.bttborrar_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(246, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 75);
            this.button1.TabIndex = 2;
            this.button1.Text = "METROS";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pdatos
            // 
            this.pdatos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pdatos.Controls.Add(this.llegenda);
            this.pdatos.Controls.Add(this.lnombre);
            this.pdatos.Controls.Add(this.txtnombre);
            this.pdatos.Controls.Add(this.label2);
            this.pdatos.Controls.Add(this.txtidobra);
            this.pdatos.Controls.Add(this.label4);
            this.pdatos.Controls.Add(this.txt_idsigrid);
            this.pdatos.Controls.Add(this.label3);
            this.pdatos.Controls.Add(this.txtm_construido);
            this.pdatos.Controls.Add(this.label5);
            this.pdatos.Controls.Add(this.prbtipos);
            this.pdatos.Controls.Add(this.label1);
            this.pdatos.Controls.Add(this.flowLayoutPanel2);
            this.pdatos.Controls.Add(this.flowLayoutPanel1);
            this.pdatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pdatos.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pdatos.Location = new System.Drawing.Point(435, 3);
            this.pdatos.Name = "pdatos";
            this.pdatos.Size = new System.Drawing.Size(427, 502);
            this.pdatos.TabIndex = 0;
            // 
            // txtidobra
            // 
            this.txtidobra.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtidobra.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtidobra.Location = new System.Drawing.Point(3, 121);
            this.txtidobra.Name = "txtidobra";
            this.txtidobra.Size = new System.Drawing.Size(334, 26);
            this.txtidobra.TabIndex = 18;
            this.txtidobra.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 150);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(2, 5, 2, 2);
            this.label4.Size = new System.Drawing.Size(334, 27);
            this.label4.TabIndex = 26;
            this.label4.Text = "Id Obra Sigrid";
            // 
            // txt_idsigrid
            // 
            this.txt_idsigrid.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_idsigrid.Location = new System.Drawing.Point(3, 180);
            this.txt_idsigrid.Name = "txt_idsigrid";
            this.txt_idsigrid.Size = new System.Drawing.Size(334, 26);
            this.txt_idsigrid.TabIndex = 28;
            this.txt_idsigrid.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 209);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(2, 5, 2, 2);
            this.label3.Size = new System.Drawing.Size(334, 27);
            this.label3.TabIndex = 22;
            this.label3.Text = "m² Construidos";
            // 
            // txtm_construido
            // 
            this.txtm_construido.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtm_construido.Location = new System.Drawing.Point(3, 239);
            this.txtm_construido.Name = "txtm_construido";
            this.txtm_construido.Size = new System.Drawing.Size(334, 26);
            this.txtm_construido.TabIndex = 23;
            this.txtm_construido.Text = "0";
            this.txtm_construido.Validated += new System.EventHandler(this.txtm_construido_Validated);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 268);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(2, 5, 2, 2);
            this.label5.Size = new System.Drawing.Size(334, 27);
            this.label5.TabIndex = 31;
            this.label5.Text = "Tipo Obra";
            // 
            // prbtipos
            // 
            this.prbtipos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.prbtipos.Controls.Add(this.Rbpropias);
            this.prbtipos.Controls.Add(this.Rbajenas);
            this.prbtipos.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.prbtipos.Location = new System.Drawing.Point(3, 298);
            this.prbtipos.Name = "prbtipos";
            this.prbtipos.Padding = new System.Windows.Forms.Padding(2);
            this.prbtipos.Size = new System.Drawing.Size(334, 37);
            this.prbtipos.TabIndex = 30;
            // 
            // Rbpropias
            // 
            this.Rbpropias.AutoSize = true;
            this.Rbpropias.Checked = true;
            this.Rbpropias.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Rbpropias.ForeColor = System.Drawing.Color.Black;
            this.Rbpropias.Location = new System.Drawing.Point(5, 5);
            this.Rbpropias.Name = "Rbpropias";
            this.Rbpropias.Size = new System.Drawing.Size(71, 21);
            this.Rbpropias.TabIndex = 5;
            this.Rbpropias.TabStop = true;
            this.Rbpropias.Text = "Abierta";
            this.Rbpropias.UseVisualStyleBackColor = true;
            // 
            // Rbajenas
            // 
            this.Rbajenas.AutoSize = true;
            this.Rbajenas.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Rbajenas.ForeColor = System.Drawing.Color.Black;
            this.Rbajenas.Location = new System.Drawing.Point(82, 5);
            this.Rbajenas.Name = "Rbajenas";
            this.Rbajenas.Size = new System.Drawing.Size(77, 21);
            this.Rbajenas.TabIndex = 4;
            this.Rbajenas.Text = "Cerrada";
            this.Rbajenas.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 338);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(2, 5, 2, 2);
            this.label1.Size = new System.Drawing.Size(334, 27);
            this.label1.TabIndex = 33;
            this.label1.Text = "Estado Obra";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel2.Controls.Add(this.rbestudio);
            this.flowLayoutPanel2.Controls.Add(this.rbejecucion);
            this.flowLayoutPanel2.Controls.Add(this.rbfinalizada);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 368);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Padding = new System.Windows.Forms.Padding(2);
            this.flowLayoutPanel2.Size = new System.Drawing.Size(334, 37);
            this.flowLayoutPanel2.TabIndex = 34;
            // 
            // rbestudio
            // 
            this.rbestudio.AutoSize = true;
            this.rbestudio.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbestudio.ForeColor = System.Drawing.Color.Black;
            this.rbestudio.Location = new System.Drawing.Point(5, 5);
            this.rbestudio.Name = "rbestudio";
            this.rbestudio.Size = new System.Drawing.Size(73, 21);
            this.rbestudio.TabIndex = 5;
            this.rbestudio.Text = "Estudio";
            this.rbestudio.UseVisualStyleBackColor = true;
            this.rbestudio.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // rbejecucion
            // 
            this.rbejecucion.AutoSize = true;
            this.rbejecucion.Checked = true;
            this.rbejecucion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbejecucion.ForeColor = System.Drawing.Color.Black;
            this.rbejecucion.Location = new System.Drawing.Point(84, 5);
            this.rbejecucion.Name = "rbejecucion";
            this.rbejecucion.Size = new System.Drawing.Size(87, 21);
            this.rbejecucion.TabIndex = 4;
            this.rbejecucion.TabStop = true;
            this.rbejecucion.Text = "Ejecucion";
            this.rbejecucion.UseVisualStyleBackColor = true;
            this.rbejecucion.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // rbfinalizada
            // 
            this.rbfinalizada.AutoSize = true;
            this.rbfinalizada.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbfinalizada.ForeColor = System.Drawing.Color.Black;
            this.rbfinalizada.Location = new System.Drawing.Point(177, 5);
            this.rbfinalizada.Name = "rbfinalizada";
            this.rbfinalizada.Size = new System.Drawing.Size(90, 21);
            this.rbfinalizada.TabIndex = 6;
            this.rbfinalizada.Text = "Finalizada";
            this.rbfinalizada.UseVisualStyleBackColor = true;
            this.rbfinalizada.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.bttañadir);
            this.flowLayoutPanel1.Controls.Add(this.bttgruposrel);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 411);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(334, 82);
            this.flowLayoutPanel1.TabIndex = 35;
            // 
            // bttañadir
            // 
            this.bttañadir.Image = global::GestionConstructora.Properties.Resources.mas;
            this.bttañadir.Location = new System.Drawing.Point(3, 3);
            this.bttañadir.Name = "bttañadir";
            this.bttañadir.Size = new System.Drawing.Size(75, 75);
            this.bttañadir.TabIndex = 1;
            this.bttañadir.UseVisualStyleBackColor = true;
            this.bttañadir.Click += new System.EventHandler(this.bttañadir_Click_1);
            // 
            // bttgruposrel
            // 
            this.bttgruposrel.Image = global::GestionConstructora.Properties.Resources.participacion_2_;
            this.bttgruposrel.Location = new System.Drawing.Point(84, 3);
            this.bttgruposrel.Name = "bttgruposrel";
            this.bttgruposrel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bttgruposrel.Size = new System.Drawing.Size(75, 75);
            this.bttgruposrel.TabIndex = 0;
            this.bttgruposrel.UseVisualStyleBackColor = true;
            this.bttgruposrel.Click += new System.EventHandler(this.bttgruposrel_Click);
            // 
            // pcontenedor
            // 
            this.pcontenedor.ColumnCount = 2;
            this.pcontenedor.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pcontenedor.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pcontenedor.Controls.Add(this.dgobras, 0, 0);
            this.pcontenedor.Controls.Add(this.pdatos, 1, 0);
            this.pcontenedor.Controls.Add(this.pbotones, 1, 1);
            this.pcontenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcontenedor.Location = new System.Drawing.Point(0, 0);
            this.pcontenedor.Name = "pcontenedor";
            this.pcontenedor.RowCount = 2;
            this.pcontenedor.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.pcontenedor.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.pcontenedor.Size = new System.Drawing.Size(865, 636);
            this.pcontenedor.TabIndex = 2;
            // 
            // dgobras
            // 
            this.dgobras.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgobras.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgobras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgobras.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id_Obra,
            this.Nombre});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.MintCream;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgobras.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgobras.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgobras.Location = new System.Drawing.Point(3, 3);
            this.dgobras.Name = "dgobras";
            this.dgobras.ReadOnly = true;
            this.dgobras.RowHeadersVisible = false;
            this.dgobras.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgobras.Size = new System.Drawing.Size(426, 502);
            this.dgobras.TabIndex = 3;
            this.dgobras.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgobras_ColumnHeaderMouseClick);
            this.dgobras.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgempresas_RowEnter);
            // 
            // Id_Obra
            // 
            this.Id_Obra.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Id_Obra.DataPropertyName = "Id_Obra";
            this.Id_Obra.HeaderText = "Id_Obra";
            this.Id_Obra.Name = "Id_Obra";
            this.Id_Obra.ReadOnly = true;
            // 
            // Nombre
            // 
            this.Nombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Nombre.DataPropertyName = "Nombre";
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(327, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 75);
            this.button2.TabIndex = 2;
            this.button2.Text = "CODIGOS SIGRID";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form_Obras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(865, 636);
            this.Controls.Add(this.pcontenedor);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_Obras";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Obras";
            this.pbotones.ResumeLayout(false);
            this.pdatos.ResumeLayout(false);
            this.pdatos.PerformLayout();
            this.prbtipos.ResumeLayout(false);
            this.prbtipos.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.pcontenedor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgobras)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btteditar;
        private System.Windows.Forms.Label llegenda;
        private System.Windows.Forms.Label lnombre;
        private System.Windows.Forms.TextBox txtnombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bttnuevo;
        private System.Windows.Forms.FlowLayoutPanel pbotones;
        private System.Windows.Forms.Button bttborrar;
        private System.Windows.Forms.TableLayoutPanel pcontenedor;
        private System.Windows.Forms.FlowLayoutPanel pdatos;
        private System.Windows.Forms.TextBox txtidobra;
        private System.Windows.Forms.DataGridView dgobras;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id_Obra;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_idsigrid;
        private System.Windows.Forms.TextBox txtm_construido;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.FlowLayoutPanel prbtipos;
        private System.Windows.Forms.RadioButton Rbpropias;
        private System.Windows.Forms.RadioButton Rbajenas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.RadioButton rbestudio;
        private System.Windows.Forms.RadioButton rbejecucion;
        private System.Windows.Forms.RadioButton rbfinalizada;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button bttañadir;
        private System.Windows.Forms.Button bttgruposrel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}