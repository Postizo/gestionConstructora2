namespace GestionConstructora
{
    partial class Form_Puertas
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dginforme = new System.Windows.Forms.DataGridView();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Apellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.txtbuscar = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.cbusuarios = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.rbtodos = new System.Windows.Forms.RadioButton();
            this.rbindividual = new System.Windows.Forms.RadioButton();
            this.fini = new System.Windows.Forms.DateTimePicker();
            this.dinformecolectivo = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hora_Final = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dginforme)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dinformecolectivo)).BeginInit();
            this.SuspendLayout();
            // 
            // dginforme
            // 
            this.dginforme.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dginforme.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dginforme.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nombre,
            this.Apellido,
            this.Hora});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.MintCream;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dginforme.DefaultCellStyle = dataGridViewCellStyle5;
            this.dginforme.Location = new System.Drawing.Point(7, 12);
            this.dginforme.Name = "dginforme";
            this.dginforme.ReadOnly = true;
            this.dginforme.RowHeadersVisible = false;
            this.dginforme.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dginforme.Size = new System.Drawing.Size(488, 523);
            this.dginforme.TabIndex = 42;
            // 
            // Nombre
            // 
            this.Nombre.DataPropertyName = "Nombre";
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            // 
            // Apellido
            // 
            this.Apellido.DataPropertyName = "apellido";
            this.Apellido.HeaderText = "Apellido";
            this.Apellido.Name = "Apellido";
            this.Apellido.ReadOnly = true;
            // 
            // Hora
            // 
            this.Hora.DataPropertyName = "hora";
            this.Hora.HeaderText = "Hora";
            this.Hora.Name = "Hora";
            this.Hora.ReadOnly = true;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // txtbuscar
            // 
            this.txtbuscar.Location = new System.Drawing.Point(6, 19);
            this.txtbuscar.Name = "txtbuscar";
            this.txtbuscar.Size = new System.Drawing.Size(302, 20);
            this.txtbuscar.TabIndex = 43;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.txtbuscar);
            this.groupBox1.Location = new System.Drawing.Point(1, 541);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(488, 50);
            this.groupBox1.TabIndex = 44;
            this.groupBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(314, 17);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 44;
            this.button1.Text = "Examinar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cbusuarios
            // 
            this.cbusuarios.FormattingEnabled = true;
            this.cbusuarios.Location = new System.Drawing.Point(519, 67);
            this.cbusuarios.Name = "cbusuarios";
            this.cbusuarios.Size = new System.Drawing.Size(200, 21);
            this.cbusuarios.TabIndex = 45;
            this.cbusuarios.SelectionChangeCommitted += new System.EventHandler(this.cbusuarios_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(516, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 46;
            this.label1.Text = "Usuarios";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(516, 12);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 13);
            this.label9.TabIndex = 47;
            this.label9.Text = "Fecha";
            // 
            // rbtodos
            // 
            this.rbtodos.AutoSize = true;
            this.rbtodos.Checked = true;
            this.rbtodos.Location = new System.Drawing.Point(519, 94);
            this.rbtodos.Name = "rbtodos";
            this.rbtodos.Size = new System.Drawing.Size(55, 17);
            this.rbtodos.TabIndex = 48;
            this.rbtodos.TabStop = true;
            this.rbtodos.Text = "Todos";
            this.rbtodos.UseVisualStyleBackColor = true;
            this.rbtodos.CheckedChanged += new System.EventHandler(this.rbtodos_CheckedChanged);
            // 
            // rbindividual
            // 
            this.rbindividual.AutoSize = true;
            this.rbindividual.Location = new System.Drawing.Point(519, 117);
            this.rbindividual.Name = "rbindividual";
            this.rbindividual.Size = new System.Drawing.Size(70, 17);
            this.rbindividual.TabIndex = 49;
            this.rbindividual.Text = "Individual";
            this.rbindividual.UseVisualStyleBackColor = true;
            // 
            // fini
            // 
            this.fini.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fini.Location = new System.Drawing.Point(519, 28);
            this.fini.Name = "fini";
            this.fini.Size = new System.Drawing.Size(200, 20);
            this.fini.TabIndex = 50;
            this.fini.ValueChanged += new System.EventHandler(this.fini_ValueChanged);
            // 
            // dinformecolectivo
            // 
            this.dinformecolectivo.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dinformecolectivo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dinformecolectivo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.Hora_Final});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.MintCream;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dinformecolectivo.DefaultCellStyle = dataGridViewCellStyle6;
            this.dinformecolectivo.Location = new System.Drawing.Point(535, 217);
            this.dinformecolectivo.Name = "dinformecolectivo";
            this.dinformecolectivo.ReadOnly = true;
            this.dinformecolectivo.RowHeadersVisible = false;
            this.dinformecolectivo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dinformecolectivo.Size = new System.Drawing.Size(179, 309);
            this.dinformecolectivo.TabIndex = 51;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Nombre";
            this.dataGridViewTextBoxColumn1.HeaderText = "Nombre";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "apellido";
            this.dataGridViewTextBoxColumn2.HeaderText = "Apellido";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "hora_ini";
            this.dataGridViewTextBoxColumn3.HeaderText = "Hora Inicial";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // Hora_Final
            // 
            this.Hora_Final.DataPropertyName = "hora_fin";
            this.Hora_Final.HeaderText = "Hora Final";
            this.Hora_Final.Name = "Hora_Final";
            this.Hora_Final.ReadOnly = true;
            // 
            // Form_Puertas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 594);
            this.Controls.Add(this.dinformecolectivo);
            this.Controls.Add(this.fini);
            this.Controls.Add(this.rbindividual);
            this.Controls.Add(this.rbtodos);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbusuarios);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dginforme);
            this.Name = "Form_Puertas";
            this.Text = "Control de Accesos";
            ((System.ComponentModel.ISupportInitialize)(this.dginforme)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dinformecolectivo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dginforme;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox txtbuscar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cbusuarios;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RadioButton rbtodos;
        private System.Windows.Forms.RadioButton rbindividual;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Apellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hora;
        private System.Windows.Forms.DateTimePicker fini;
        private System.Windows.Forms.DataGridView dinformecolectivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hora_Final;
    }
}