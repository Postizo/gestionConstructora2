namespace GestionConstructora
{
    partial class Form_PresupuestoOficial
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_PresupuestoOficial));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            this.linfo = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
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
            this.button2 = new System.Windows.Forms.Button();
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.txtbeneficio);
            this.groupBox2.Controls.Add(this.txtgastosgenerales);
            this.groupBox2.Controls.Add(this.txtmargenmateriales);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Location = new System.Drawing.Point(12, 32);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(427, 192);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Margenes Comerciales";
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
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle20.BackColor = System.Drawing.Color.MintCream;
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Dgresumen.DefaultCellStyle = dataGridViewCellStyle20;
            this.Dgresumen.Enabled = false;
            this.Dgresumen.Location = new System.Drawing.Point(445, 32);
            this.Dgresumen.Name = "Dgresumen";
            this.Dgresumen.ReadOnly = true;
            this.Dgresumen.RowHeadersVisible = false;
            this.Dgresumen.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.Dgresumen.Size = new System.Drawing.Size(435, 194);
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
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle19.Format = "N0";
            dataGridViewCellStyle19.NullValue = null;
            this.Importe.DefaultCellStyle = dataGridViewCellStyle19;
            this.Importe.HeaderText = "Importe";
            this.Importe.Name = "Importe";
            this.Importe.ReadOnly = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(215, 114);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(201, 31);
            this.button2.TabIndex = 26;
            this.button2.Text = "CALCULAR";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form_PresupuestoOficial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 260);
            this.Controls.Add(this.Dgresumen);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.linfo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_PresupuestoOficial";
            this.Text = "Presupuesto";
            this.Load += new System.EventHandler(this.Form_Presupuesto_Load);
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
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Importe;
        private System.Windows.Forms.Button button2;
    }
}