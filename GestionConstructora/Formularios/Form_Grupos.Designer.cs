namespace GestionConstructora
{
    partial class Form_Grupos
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Grupos));
            this.pcontenedor = new System.Windows.Forms.TableLayoutPanel();
            this.psubgrupos = new System.Windows.Forms.FlowLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtsubrgrupo = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.bttañadirsubgrupo = new System.Windows.Forms.Button();
            this.bttborrarsubgrupo = new System.Windows.Forms.Button();
            this.pbotones = new System.Windows.Forms.FlowLayoutPanel();
            this.bttagregar = new System.Windows.Forms.Button();
            this.btteditar = new System.Windows.Forms.Button();
            this.bttborrar = new System.Windows.Forms.Button();
            this.pdatos = new System.Windows.Forms.FlowLayoutPanel();
            this.llegenda = new System.Windows.Forms.Label();
            this.lnombre = new System.Windows.Forms.Label();
            this.txtnombre = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.bttañadir = new System.Windows.Forms.Button();
            this.bttver = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgsubgrupos = new System.Windows.Forms.DataGridView();
            this.Id_Subgrupos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lsubgrupo = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.dggrupos = new System.Windows.Forms.DataGridView();
            this.Id_grupos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Grupo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.rbgastos = new System.Windows.Forms.RadioButton();
            this.Rbingresos = new System.Windows.Forms.RadioButton();
            this.prbtipos = new System.Windows.Forms.FlowLayoutPanel();
            this.pcontenedor.SuspendLayout();
            this.psubgrupos.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.pbotones.SuspendLayout();
            this.pdatos.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgsubgrupos)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dggrupos)).BeginInit();
            this.prbtipos.SuspendLayout();
            this.SuspendLayout();
            // 
            // pcontenedor
            // 
            this.pcontenedor.ColumnCount = 2;
            this.pcontenedor.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pcontenedor.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pcontenedor.Controls.Add(this.psubgrupos, 1, 1);
            this.pcontenedor.Controls.Add(this.pbotones, 0, 2);
            this.pcontenedor.Controls.Add(this.pdatos, 0, 1);
            this.pcontenedor.Controls.Add(this.tableLayoutPanel1, 1, 0);
            this.pcontenedor.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.pcontenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcontenedor.Location = new System.Drawing.Point(0, 0);
            this.pcontenedor.Name = "pcontenedor";
            this.pcontenedor.RowCount = 3;
            this.pcontenedor.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.pcontenedor.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.pcontenedor.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.pcontenedor.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.pcontenedor.Size = new System.Drawing.Size(850, 628);
            this.pcontenedor.TabIndex = 1;
            this.pcontenedor.Paint += new System.Windows.Forms.PaintEventHandler(this.pcontenedor_Paint);
            // 
            // psubgrupos
            // 
            this.psubgrupos.BackColor = System.Drawing.SystemColors.Control;
            this.psubgrupos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.psubgrupos.Controls.Add(this.label3);
            this.psubgrupos.Controls.Add(this.label4);
            this.psubgrupos.Controls.Add(this.txtsubrgrupo);
            this.psubgrupos.Controls.Add(this.flowLayoutPanel2);
            this.psubgrupos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.psubgrupos.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.psubgrupos.Location = new System.Drawing.Point(426, 252);
            this.psubgrupos.Margin = new System.Windows.Forms.Padding(1);
            this.psubgrupos.Name = "psubgrupos";
            this.psubgrupos.Size = new System.Drawing.Size(423, 249);
            this.psubgrupos.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(316, 20);
            this.label3.TabIndex = 24;
            this.label3.Text = "MODIFICA SUBGRUPOS";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 20);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(2, 5, 2, 2);
            this.label4.Size = new System.Drawing.Size(316, 24);
            this.label4.TabIndex = 22;
            this.label4.Text = "Nombre Subgrupo";
            // 
            // txtsubrgrupo
            // 
            this.txtsubrgrupo.BackColor = System.Drawing.Color.Ivory;
            this.txtsubrgrupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsubrgrupo.Location = new System.Drawing.Point(3, 47);
            this.txtsubrgrupo.Name = "txtsubrgrupo";
            this.txtsubrgrupo.Size = new System.Drawing.Size(316, 23);
            this.txtsubrgrupo.TabIndex = 21;
            this.txtsubrgrupo.TextChanged += new System.EventHandler(this.txtsubrgrupo_TextChanged);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.bttañadirsubgrupo);
            this.flowLayoutPanel2.Controls.Add(this.bttborrarsubgrupo);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 76);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(175, 82);
            this.flowLayoutPanel2.TabIndex = 23;
            // 
            // bttañadirsubgrupo
            // 
            this.bttañadirsubgrupo.Enabled = false;
            this.bttañadirsubgrupo.Image = global::GestionConstructora.Properties.Resources.mas;
            this.bttañadirsubgrupo.Location = new System.Drawing.Point(3, 3);
            this.bttañadirsubgrupo.Name = "bttañadirsubgrupo";
            this.bttañadirsubgrupo.Size = new System.Drawing.Size(75, 75);
            this.bttañadirsubgrupo.TabIndex = 1;
            this.bttañadirsubgrupo.UseVisualStyleBackColor = true;
            this.bttañadirsubgrupo.Click += new System.EventHandler(this.bttAñadirsubgrupo_Click);
            // 
            // bttborrarsubgrupo
            // 
            this.bttborrarsubgrupo.Image = global::GestionConstructora.Properties.Resources.cancelar;
            this.bttborrarsubgrupo.Location = new System.Drawing.Point(84, 3);
            this.bttborrarsubgrupo.Name = "bttborrarsubgrupo";
            this.bttborrarsubgrupo.Size = new System.Drawing.Size(75, 75);
            this.bttborrarsubgrupo.TabIndex = 2;
            this.bttborrarsubgrupo.UseVisualStyleBackColor = true;
            this.bttborrarsubgrupo.Click += new System.EventHandler(this.bttborrar_subgrupos);
            // 
            // pbotones
            // 
            this.pbotones.Controls.Add(this.bttagregar);
            this.pbotones.Controls.Add(this.btteditar);
            this.pbotones.Controls.Add(this.bttborrar);
            this.pbotones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbotones.Location = new System.Drawing.Point(3, 505);
            this.pbotones.Name = "pbotones";
            this.pbotones.Size = new System.Drawing.Size(419, 120);
            this.pbotones.TabIndex = 6;
            // 
            // bttagregar
            // 
            this.bttagregar.Image = global::GestionConstructora.Properties.Resources.mas;
            this.bttagregar.Location = new System.Drawing.Point(3, 3);
            this.bttagregar.Name = "bttagregar";
            this.bttagregar.Size = new System.Drawing.Size(75, 75);
            this.bttagregar.TabIndex = 1;
            this.bttagregar.UseVisualStyleBackColor = true;
            this.bttagregar.Click += new System.EventHandler(this.bttnuevo_Click);
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
            // pdatos
            // 
            this.pdatos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pdatos.Controls.Add(this.llegenda);
            this.pdatos.Controls.Add(this.lnombre);
            this.pdatos.Controls.Add(this.txtnombre);
            this.pdatos.Controls.Add(this.label2);
            this.pdatos.Controls.Add(this.prbtipos);
            this.pdatos.Controls.Add(this.flowLayoutPanel1);
            this.pdatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pdatos.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pdatos.Location = new System.Drawing.Point(1, 252);
            this.pdatos.Margin = new System.Windows.Forms.Padding(1);
            this.pdatos.Name = "pdatos";
            this.pdatos.Size = new System.Drawing.Size(423, 249);
            this.pdatos.TabIndex = 5;
            // 
            // llegenda
            // 
            this.llegenda.AutoSize = true;
            this.llegenda.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.llegenda.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llegenda.Location = new System.Drawing.Point(3, 0);
            this.llegenda.Name = "llegenda";
            this.llegenda.Size = new System.Drawing.Size(310, 20);
            this.llegenda.TabIndex = 0;
            this.llegenda.Text = "label1";
            this.llegenda.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lnombre
            // 
            this.lnombre.AutoSize = true;
            this.lnombre.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lnombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnombre.Location = new System.Drawing.Point(1, 21);
            this.lnombre.Margin = new System.Windows.Forms.Padding(1);
            this.lnombre.Name = "lnombre";
            this.lnombre.Padding = new System.Windows.Forms.Padding(2, 10, 2, 2);
            this.lnombre.Size = new System.Drawing.Size(314, 25);
            this.lnombre.TabIndex = 8;
            this.lnombre.Text = "Nombre";
            // 
            // txtnombre
            // 
            this.txtnombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtnombre.Location = new System.Drawing.Point(1, 48);
            this.txtnombre.Margin = new System.Windows.Forms.Padding(1);
            this.txtnombre.Name = "txtnombre";
            this.txtnombre.Size = new System.Drawing.Size(314, 23);
            this.txtnombre.TabIndex = 9;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.bttañadir);
            this.flowLayoutPanel1.Controls.Add(this.bttver);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 129);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(157, 79);
            this.flowLayoutPanel1.TabIndex = 12;
            // 
            // bttañadir
            // 
            this.bttañadir.Image = global::GestionConstructora.Properties.Resources.comprobado_1_;
            this.bttañadir.Location = new System.Drawing.Point(1, 1);
            this.bttañadir.Margin = new System.Windows.Forms.Padding(1);
            this.bttañadir.Name = "bttañadir";
            this.bttañadir.Size = new System.Drawing.Size(75, 74);
            this.bttañadir.TabIndex = 14;
            this.bttañadir.UseVisualStyleBackColor = true;
            this.bttañadir.Click += new System.EventHandler(this.bttAñadir_Click);
            // 
            // bttver
            // 
            this.bttver.Image = global::GestionConstructora.Properties.Resources.participacion_2_;
            this.bttver.Location = new System.Drawing.Point(78, 1);
            this.bttver.Margin = new System.Windows.Forms.Padding(1);
            this.bttver.Name = "bttver";
            this.bttver.Size = new System.Drawing.Size(75, 74);
            this.bttver.TabIndex = 15;
            this.bttver.UseVisualStyleBackColor = true;
            this.bttver.Click += new System.EventHandler(this.bttver_subgrupos);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dgsubgrupos, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lsubgrupo, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(428, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(419, 245);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // dgsubgrupos
            // 
            this.dgsubgrupos.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgsubgrupos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgsubgrupos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgsubgrupos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id_Subgrupos,
            this.dataGridViewTextBoxColumn2});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.MintCream;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgsubgrupos.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgsubgrupos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgsubgrupos.Location = new System.Drawing.Point(3, 27);
            this.dgsubgrupos.Name = "dgsubgrupos";
            this.dgsubgrupos.ReadOnly = true;
            this.dgsubgrupos.RowHeadersVisible = false;
            this.dgsubgrupos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgsubgrupos.Size = new System.Drawing.Size(413, 214);
            this.dgsubgrupos.TabIndex = 14;
            this.dgsubgrupos.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgsubgrupos_RowEnter);
            this.dgsubgrupos.RowLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgsubgrupos_RowLeave);
            // 
            // Id_Subgrupos
            // 
            this.Id_Subgrupos.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Id_Subgrupos.DataPropertyName = "Id_Subgrupo";
            this.Id_Subgrupos.HeaderText = "Id_Subgrupo";
            this.Id_Subgrupos.Name = "Id_Subgrupos";
            this.Id_Subgrupos.ReadOnly = true;
            this.Id_Subgrupos.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Nombre";
            this.dataGridViewTextBoxColumn2.HeaderText = "Nombre";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // lsubgrupo
            // 
            this.lsubgrupo.AutoSize = true;
            this.lsubgrupo.BackColor = System.Drawing.SystemColors.Control;
            this.lsubgrupo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsubgrupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsubgrupo.Location = new System.Drawing.Point(3, 0);
            this.lsubgrupo.Name = "lsubgrupo";
            this.lsubgrupo.Size = new System.Drawing.Size(413, 24);
            this.lsubgrupo.TabIndex = 13;
            this.lsubgrupo.Text = "SUBGRUPOS";
            this.lsubgrupo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lsubgrupo.Visible = false;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.dggrupos, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(419, 245);
            this.tableLayoutPanel2.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(413, 24);
            this.label1.TabIndex = 14;
            this.label1.Text = "GRUPOS";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dggrupos
            // 
            this.dggrupos.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dggrupos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dggrupos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dggrupos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id_grupos,
            this.Grupo,
            this.tip});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.MintCream;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dggrupos.DefaultCellStyle = dataGridViewCellStyle2;
            this.dggrupos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dggrupos.Location = new System.Drawing.Point(3, 27);
            this.dggrupos.MultiSelect = false;
            this.dggrupos.Name = "dggrupos";
            this.dggrupos.ReadOnly = true;
            this.dggrupos.RowHeadersVisible = false;
            this.dggrupos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dggrupos.Size = new System.Drawing.Size(413, 215);
            this.dggrupos.TabIndex = 4;
            this.dggrupos.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgempresas_RowEnter);
            // 
            // Id_grupos
            // 
            this.Id_grupos.DataPropertyName = "Id_grupo";
            this.Id_grupos.HeaderText = "Id";
            this.Id_grupos.Name = "Id_grupos";
            this.Id_grupos.ReadOnly = true;
            this.Id_grupos.Visible = false;
            // 
            // Grupo
            // 
            this.Grupo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Grupo.DataPropertyName = "Nombre";
            this.Grupo.HeaderText = "Grupo";
            this.Grupo.Name = "Grupo";
            this.Grupo.ReadOnly = true;
            // 
            // tip
            // 
            this.tip.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.tip.DataPropertyName = "Tipo";
            this.tip.HeaderText = "Tipo";
            this.tip.Name = "tip";
            this.tip.ReadOnly = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1, 73);
            this.label2.Margin = new System.Windows.Forms.Padding(1);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(2, 5, 2, 2);
            this.label2.Size = new System.Drawing.Size(314, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "Tipo";
            // 
            // rbgastos
            // 
            this.rbgastos.AutoSize = true;
            this.rbgastos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbgastos.ForeColor = System.Drawing.Color.Red;
            this.rbgastos.Location = new System.Drawing.Point(89, 5);
            this.rbgastos.Name = "rbgastos";
            this.rbgastos.Size = new System.Drawing.Size(69, 20);
            this.rbgastos.TabIndex = 4;
            this.rbgastos.Text = "Gastos";
            this.rbgastos.UseVisualStyleBackColor = true;
           
            // 
            // Rbingresos
            // 
            this.Rbingresos.AutoSize = true;
            this.Rbingresos.Checked = true;
            this.Rbingresos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Rbingresos.ForeColor = System.Drawing.Color.Green;
            this.Rbingresos.Location = new System.Drawing.Point(5, 5);
            this.Rbingresos.Name = "Rbingresos";
            this.Rbingresos.Size = new System.Drawing.Size(78, 20);
            this.Rbingresos.TabIndex = 5;
            this.Rbingresos.TabStop = true;
            this.Rbingresos.Text = "Ingresos";
            this.Rbingresos.UseVisualStyleBackColor = true;
           
            // 
            // prbtipos
            // 
            this.prbtipos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.prbtipos.Controls.Add(this.Rbingresos);
            this.prbtipos.Controls.Add(this.rbgastos);
            this.prbtipos.Dock = System.Windows.Forms.DockStyle.Top;
            this.prbtipos.Location = new System.Drawing.Point(1, 95);
            this.prbtipos.Margin = new System.Windows.Forms.Padding(1);
            this.prbtipos.Name = "prbtipos";
            this.prbtipos.Padding = new System.Windows.Forms.Padding(2);
            this.prbtipos.Size = new System.Drawing.Size(314, 30);
            this.prbtipos.TabIndex = 11;
            // 
            // Form_Grupos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 628);
            this.Controls.Add(this.pcontenedor);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_Grupos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Grupos";
            this.pcontenedor.ResumeLayout(false);
            this.psubgrupos.ResumeLayout(false);
            this.psubgrupos.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.pbotones.ResumeLayout(false);
            this.pdatos.ResumeLayout(false);
            this.pdatos.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgsubgrupos)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dggrupos)).EndInit();
            this.prbtipos.ResumeLayout(false);
            this.prbtipos.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel pcontenedor;
        private System.Windows.Forms.FlowLayoutPanel pdatos;
        private System.Windows.Forms.Label lnombre;
        private System.Windows.Forms.TextBox txtnombre;
        private System.Windows.Forms.FlowLayoutPanel pbotones;
        private System.Windows.Forms.Button bttagregar;
        private System.Windows.Forms.Button btteditar;
        private System.Windows.Forms.Button bttborrar;
        private System.Windows.Forms.Label llegenda;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button bttañadir;
        private System.Windows.Forms.Button bttver;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dgsubgrupos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id_Subgrupos;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.Label lsubgrupo;
        private System.Windows.Forms.FlowLayoutPanel psubgrupos;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dggrupos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id_grupos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Grupo;
        private System.Windows.Forms.DataGridViewTextBoxColumn tip;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtsubrgrupo;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button bttañadirsubgrupo;
        private System.Windows.Forms.Button bttborrarsubgrupo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel prbtipos;
        private System.Windows.Forms.RadioButton Rbingresos;
        private System.Windows.Forms.RadioButton rbgastos;
    }
}

