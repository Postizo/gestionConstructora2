namespace GestionConstructora
{
    partial class Form_PresupuestoElegir
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_PresupuestoElegir));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.P_Presupuestos = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.dgpresupuestos = new System.Windows.Forms.DataGridView();
            this.Id_Presupuesto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id_version = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.dgpresu = new System.Windows.Forms.DataGridView();
            this.id_Obra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.P_Presupuestos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgpresupuestos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgpresu)).BeginInit();
            this.SuspendLayout();
            // 
            // P_Presupuestos
            // 
            this.P_Presupuestos.Controls.Add(this.dgpresu);
            this.P_Presupuestos.Controls.Add(this.button4);
            this.P_Presupuestos.Controls.Add(this.button3);
            this.P_Presupuestos.Controls.Add(this.dgpresupuestos);
            this.P_Presupuestos.Location = new System.Drawing.Point(19, 11);
            this.P_Presupuestos.Name = "P_Presupuestos";
            this.P_Presupuestos.Size = new System.Drawing.Size(409, 355);
            this.P_Presupuestos.TabIndex = 2;
            this.P_Presupuestos.TabStop = false;
            this.P_Presupuestos.Text = "Cabecera Presupuesto";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(202, 325);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(176, 24);
            this.button4.TabIndex = 34;
            this.button4.Text = "Crear Nuevo Presupuesto";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(17, 325);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(165, 24);
            this.button3.TabIndex = 33;
            this.button3.Text = "Copiar a nueva Version";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // dgpresupuestos
            // 
            this.dgpresupuestos.AllowUserToAddRows = false;
            this.dgpresupuestos.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgpresupuestos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgpresupuestos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id_Presupuesto,
            this.Id_version,
            this.dataGridViewTextBoxColumn2});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.MintCream;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgpresupuestos.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgpresupuestos.Location = new System.Drawing.Point(17, 19);
            this.dgpresupuestos.Name = "dgpresupuestos";
            this.dgpresupuestos.ReadOnly = true;
            this.dgpresupuestos.RowHeadersVisible = false;
            this.dgpresupuestos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgpresupuestos.Size = new System.Drawing.Size(361, 300);
            this.dgpresupuestos.TabIndex = 32;
            this.dgpresupuestos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgpresupuestos_CellDoubleClick);
            // 
            // Id_Presupuesto
            // 
            this.Id_Presupuesto.DataPropertyName = "Id_Presu";
            this.Id_Presupuesto.HeaderText = "Id";
            this.Id_Presupuesto.Name = "Id_Presupuesto";
            this.Id_Presupuesto.ReadOnly = true;
            this.Id_Presupuesto.Width = 90;
            // 
            // Id_version
            // 
            this.Id_version.DataPropertyName = "id_version";
            this.Id_version.HeaderText = "Version";
            this.Id_version.Name = "Id_version";
            this.Id_version.ReadOnly = true;
            this.Id_version.Width = 90;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Nombre";
            this.dataGridViewTextBoxColumn2.HeaderText = "Presupuesto";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
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
            // dgpresu
            // 
            this.dgpresu.AllowUserToAddRows = false;
            this.dgpresu.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgpresu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgpresu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_Obra,
            this.dataGridViewTextBoxColumn4});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.MintCream;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgpresu.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgpresu.Location = new System.Drawing.Point(17, 19);
            this.dgpresu.Name = "dgpresu";
            this.dgpresu.ReadOnly = true;
            this.dgpresu.RowHeadersVisible = false;
            this.dgpresu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgpresu.Size = new System.Drawing.Size(361, 300);
            this.dgpresu.TabIndex = 35;
            this.dgpresu.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgpresu_CellDoubleClick);
            this.dgpresu.DoubleClick += new System.EventHandler(this.dgpresu_DoubleClick);
            // 
            // id_Obra
            // 
            this.id_Obra.DataPropertyName = "Id_Obra";
            this.id_Obra.HeaderText = "Id";
            this.id_Obra.Name = "id_Obra";
            this.id_Obra.ReadOnly = true;
            this.id_Obra.Width = 90;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Nombre";
            this.dataGridViewTextBoxColumn4.HeaderText = "Presupuesto";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // Form_PresupuestoElegir
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 400);
            this.Controls.Add(this.P_Presupuestos);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_PresupuestoElegir";
            this.Text = "Elegir Presupuesto";
            this.P_Presupuestos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgpresupuestos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgpresu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox P_Presupuestos;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridView dgpresupuestos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id_Presupuesto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id_version;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.DataGridView dgpresu;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_Obra;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
    }
}