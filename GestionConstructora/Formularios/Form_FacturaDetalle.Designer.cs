namespace GestionConstructora
{
    partial class Form_FacturaDetalle
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtdireprovee = new System.Windows.Forms.TextBox();
            this.txtcifprovee = new System.Windows.Forms.TextBox();
            this.txtnombreprovee = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txt_suref = new System.Windows.Forms.TextBox();
            this.txtref_fac = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lcuenta = new System.Windows.Forms.Label();
            this.txtfecha = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtimporte = new System.Windows.Forms.TextBox();
            this.txtbase = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtcuota = new System.Windows.Forms.TextBox();
            this.dglineas = new System.Windows.Forms.DataGridView();
            this.Empresa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.obra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cuentas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cif = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cuota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Grupo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dglineas)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtdireprovee);
            this.groupBox1.Controls.Add(this.txtcifprovee);
            this.groupBox1.Controls.Add(this.txtnombreprovee);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(322, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(351, 117);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Proveedor";
            // 
            // txtdireprovee
            // 
            this.txtdireprovee.BackColor = System.Drawing.Color.Azure;
            this.txtdireprovee.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdireprovee.Location = new System.Drawing.Point(101, 81);
            this.txtdireprovee.Name = "txtdireprovee";
            this.txtdireprovee.Size = new System.Drawing.Size(244, 23);
            this.txtdireprovee.TabIndex = 13;
            // 
            // txtcifprovee
            // 
            this.txtcifprovee.BackColor = System.Drawing.Color.Azure;
            this.txtcifprovee.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcifprovee.Location = new System.Drawing.Point(101, 49);
            this.txtcifprovee.Name = "txtcifprovee";
            this.txtcifprovee.Size = new System.Drawing.Size(244, 23);
            this.txtcifprovee.TabIndex = 12;
            // 
            // txtnombreprovee
            // 
            this.txtnombreprovee.BackColor = System.Drawing.Color.Azure;
            this.txtnombreprovee.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtnombreprovee.Location = new System.Drawing.Point(101, 13);
            this.txtnombreprovee.Name = "txtnombreprovee";
            this.txtnombreprovee.Size = new System.Drawing.Size(244, 23);
            this.txtnombreprovee.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(15, 80);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(2, 5, 2, 2);
            this.label5.Size = new System.Drawing.Size(80, 24);
            this.label5.TabIndex = 10;
            this.label5.Text = "Direccion";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(15, 48);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(2, 5, 2, 2);
            this.label4.Size = new System.Drawing.Size(35, 24);
            this.label4.TabIndex = 9;
            this.label4.Text = "CIF";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 16);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(2, 5, 2, 2);
            this.label3.Size = new System.Drawing.Size(68, 24);
            this.label3.TabIndex = 8;
            this.label3.Text = "Nombre";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txt_suref);
            this.groupBox2.Controls.Add(this.txtref_fac);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.lcuenta);
            this.groupBox2.Controls.Add(this.txtfecha);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(304, 117);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Factura";
            // 
            // txt_suref
            // 
            this.txt_suref.BackColor = System.Drawing.Color.Azure;
            this.txt_suref.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_suref.Location = new System.Drawing.Point(92, 81);
            this.txt_suref.Name = "txt_suref";
            this.txt_suref.Size = new System.Drawing.Size(206, 23);
            this.txt_suref.TabIndex = 9;
            // 
            // txtref_fac
            // 
            this.txtref_fac.BackColor = System.Drawing.Color.Azure;
            this.txtref_fac.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtref_fac.Location = new System.Drawing.Point(92, 49);
            this.txtref_fac.Name = "txtref_fac";
            this.txtref_fac.Size = new System.Drawing.Size(206, 23);
            this.txtref_fac.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 80);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(2, 5, 2, 2);
            this.label2.Size = new System.Drawing.Size(61, 24);
            this.label2.TabIndex = 7;
            this.label2.Text = "Su Ref";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 48);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(2, 5, 2, 2);
            this.label1.Size = new System.Drawing.Size(59, 24);
            this.label1.TabIndex = 6;
            this.label1.Text = "Nº Ref";
            // 
            // lcuenta
            // 
            this.lcuenta.AutoSize = true;
            this.lcuenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lcuenta.Location = new System.Drawing.Point(6, 16);
            this.lcuenta.Name = "lcuenta";
            this.lcuenta.Padding = new System.Windows.Forms.Padding(2, 5, 2, 2);
            this.lcuenta.Size = new System.Drawing.Size(56, 24);
            this.lcuenta.TabIndex = 5;
            this.lcuenta.Text = "Fecha";
            // 
            // txtfecha
            // 
            this.txtfecha.BackColor = System.Drawing.Color.Azure;
            this.txtfecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtfecha.Location = new System.Drawing.Point(92, 17);
            this.txtfecha.Name = "txtfecha";
            this.txtfecha.Size = new System.Drawing.Size(206, 23);
            this.txtfecha.TabIndex = 4;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtimporte);
            this.groupBox3.Controls.Add(this.txtbase);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.txtcuota);
            this.groupBox3.Location = new System.Drawing.Point(679, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(194, 117);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Totales";
            // 
            // txtimporte
            // 
            this.txtimporte.BackColor = System.Drawing.Color.Azure;
            this.txtimporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtimporte.Location = new System.Drawing.Point(92, 81);
            this.txtimporte.Name = "txtimporte";
            this.txtimporte.Size = new System.Drawing.Size(96, 23);
            this.txtimporte.TabIndex = 9;
            // 
            // txtbase
            // 
            this.txtbase.BackColor = System.Drawing.Color.Azure;
            this.txtbase.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbase.Location = new System.Drawing.Point(92, 49);
            this.txtbase.Name = "txtbase";
            this.txtbase.Size = new System.Drawing.Size(96, 23);
            this.txtbase.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 80);
            this.label6.Name = "label6";
            this.label6.Padding = new System.Windows.Forms.Padding(2, 5, 2, 2);
            this.label6.Size = new System.Drawing.Size(66, 24);
            this.label6.TabIndex = 7;
            this.label6.Text = "Importe";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(6, 48);
            this.label7.Name = "label7";
            this.label7.Padding = new System.Windows.Forms.Padding(2, 5, 2, 2);
            this.label7.Size = new System.Drawing.Size(48, 24);
            this.label7.TabIndex = 6;
            this.label7.Text = "Base";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(6, 16);
            this.label8.Name = "label8";
            this.label8.Padding = new System.Windows.Forms.Padding(2, 5, 2, 2);
            this.label8.Size = new System.Drawing.Size(54, 24);
            this.label8.TabIndex = 5;
            this.label8.Text = "Cuota";
            // 
            // txtcuota
            // 
            this.txtcuota.BackColor = System.Drawing.Color.Azure;
            this.txtcuota.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcuota.Location = new System.Drawing.Point(92, 17);
            this.txtcuota.Name = "txtcuota";
            this.txtcuota.Size = new System.Drawing.Size(96, 23);
            this.txtcuota.TabIndex = 4;
            // 
            // dglineas
            // 
            this.dglineas.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dglineas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dglineas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dglineas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Empresa,
            this.obra,
            this.Cuentas,
            this.Cif,
            this.Cuota,
            this.Nombre,
            this.Grupo});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.MintCream;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dglineas.DefaultCellStyle = dataGridViewCellStyle2;
            this.dglineas.Location = new System.Drawing.Point(12, 193);
            this.dglineas.Name = "dglineas";
            this.dglineas.ReadOnly = true;
            this.dglineas.RowHeadersVisible = false;
            this.dglineas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dglineas.Size = new System.Drawing.Size(861, 169);
            this.dglineas.TabIndex = 4;
            // 
            // Empresa
            // 
            this.Empresa.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Empresa.DataPropertyName = "Descripcion";
            this.Empresa.HeaderText = "Descripcion";
            this.Empresa.Name = "Empresa";
            this.Empresa.ReadOnly = true;
            // 
            // obra
            // 
            this.obra.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.obra.DataPropertyName = "Cantidad";
            this.obra.HeaderText = "Unidades";
            this.obra.Name = "obra";
            this.obra.ReadOnly = true;
            // 
            // Cuentas
            // 
            this.Cuentas.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Cuentas.DataPropertyName = "Pre";
            this.Cuentas.HeaderText = "Precio";
            this.Cuentas.Name = "Cuentas";
            this.Cuentas.ReadOnly = true;
            // 
            // Cif
            // 
            this.Cif.DataPropertyName = "Base";
            this.Cif.HeaderText = "Base";
            this.Cif.Name = "Cif";
            this.Cif.ReadOnly = true;
            // 
            // Cuota
            // 
            this.Cuota.DataPropertyName = "Cuota";
            this.Cuota.HeaderText = "Cuota";
            this.Cuota.Name = "Cuota";
            this.Cuota.ReadOnly = true;
            // 
            // Nombre
            // 
            this.Nombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Nombre.DataPropertyName = "Importe";
            this.Nombre.HeaderText = "Importe";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            // 
            // Grupo
            // 
            this.Grupo.DataPropertyName = "id_grupo.tostring()";
            this.Grupo.HeaderText = "id_grupo";
            this.Grupo.Name = "Grupo";
            this.Grupo.ReadOnly = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Tomato;
            this.label9.Location = new System.Drawing.Point(346, 157);
            this.label9.Name = "label9";
            this.label9.Padding = new System.Windows.Forms.Padding(2, 5, 2, 2);
            this.label9.Size = new System.Drawing.Size(167, 24);
            this.label9.TabIndex = 8;
            this.label9.Text = "DETALLE FACTURAS";
            // 
            // Form_FacturaDetalle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(897, 383);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dglineas);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form_FacturaDetalle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "-";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_FacturaDetalle_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dglineas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtdireprovee;
        private System.Windows.Forms.TextBox txtcifprovee;
        private System.Windows.Forms.TextBox txtnombreprovee;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_suref;
        private System.Windows.Forms.TextBox txtref_fac;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lcuenta;
        private System.Windows.Forms.TextBox txtfecha;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtimporte;
        private System.Windows.Forms.TextBox txtbase;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtcuota;
        private System.Windows.Forms.DataGridView dglineas;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Empresa;
        private System.Windows.Forms.DataGridViewTextBoxColumn obra;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cuentas;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cif;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cuota;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Grupo;
    }
}