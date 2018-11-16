namespace GestionConstructora
{
    partial class Form_Provedores
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.button2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.finicio = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.ffin = new System.Windows.Forms.DateTimePicker();
            this.dgempresas = new System.Windows.Forms.DataGridView();
            this.Id_Empresa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Empresa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.dginforme = new System.Windows.Forms.DataGridView();
            this.id_Proveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Proveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Importe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgempresas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dginforme)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.Controls.Add(this.button2);
            this.flowLayoutPanel1.Controls.Add(this.button3);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(1, 503);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(841, 29);
            this.flowLayoutPanel1.TabIndex = 11;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(3, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(177, 22);
            this.button2.TabIndex = 25;
            this.button2.Text = "ATRAS";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(415, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Fecha Inicio:";
            // 
            // finicio
            // 
            this.finicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.finicio.Location = new System.Drawing.Point(415, 20);
            this.finicio.Name = "finicio";
            this.finicio.Size = new System.Drawing.Size(178, 20);
            this.finicio.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(415, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Fecha Fin";
            // 
            // ffin
            // 
            this.ffin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.ffin.Location = new System.Drawing.Point(415, 59);
            this.ffin.Name = "ffin";
            this.ffin.Size = new System.Drawing.Size(178, 20);
            this.ffin.TabIndex = 5;
            // 
            // dgempresas
            // 
            this.dgempresas.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgempresas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgempresas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgempresas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id_Empresa,
            this.Empresa});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.MintCream;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgempresas.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgempresas.Location = new System.Drawing.Point(20, 3);
            this.dgempresas.Name = "dgempresas";
            this.dgempresas.ReadOnly = true;
            this.dgempresas.RowHeadersVisible = false;
            this.dgempresas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgempresas.Size = new System.Drawing.Size(389, 175);
            this.dgempresas.TabIndex = 23;
            // 
            // Id_Empresa
            // 
            this.Id_Empresa.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Id_Empresa.DataPropertyName = "Id_Empresa";
            this.Id_Empresa.HeaderText = "id_Empresa";
            this.Id_Empresa.Name = "Id_Empresa";
            this.Id_Empresa.ReadOnly = true;
            this.Id_Empresa.Visible = false;
            // 
            // Empresa
            // 
            this.Empresa.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Empresa.DataPropertyName = "Nombre";
            this.Empresa.HeaderText = "Empresa";
            this.Empresa.Name = "Empresa";
            this.Empresa.ReadOnly = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(415, 87);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(177, 22);
            this.button1.TabIndex = 24;
            this.button1.Text = "CALCULAR";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dginforme
            // 
            this.dginforme.AllowUserToAddRows = false;
            this.dginforme.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dginforme.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_Proveedor,
            this.Proveedor,
            this.Importe});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dginforme.DefaultCellStyle = dataGridViewCellStyle6;
            this.dginforme.Location = new System.Drawing.Point(1, -4);
            this.dginforme.Name = "dginforme";
            this.dginforme.RowHeadersWidth = 35;
            this.dginforme.Size = new System.Drawing.Size(841, 501);
            this.dginforme.TabIndex = 29;
            this.dginforme.Visible = false;
            // 
            // id_Proveedor
            // 
            this.id_Proveedor.DataPropertyName = "id_Proveedor";
            this.id_Proveedor.HeaderText = "Id";
            this.id_Proveedor.Name = "id_Proveedor";
            this.id_Proveedor.Visible = false;
            // 
            // Proveedor
            // 
            this.Proveedor.DataPropertyName = "Proveedor";
            this.Proveedor.HeaderText = "Proveedor";
            this.Proveedor.Name = "Proveedor";
            this.Proveedor.Width = 500;
            // 
            // Importe
            // 
            this.Importe.DataPropertyName = "Importe";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = null;
            this.Importe.DefaultCellStyle = dataGridViewCellStyle5;
            this.Importe.HeaderText = "Importe";
            this.Importe.Name = "Importe";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgempresas);
            this.panel1.Controls.Add(this.ffin);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.finicio);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(622, 189);
            this.panel1.TabIndex = 30;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(186, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(177, 22);
            this.button3.TabIndex = 26;
            this.button3.Text = "IMPRIMIR";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form_Provedores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 543);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dginforme);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "Form_Provedores";
            this.Text = "Form_Provedores";
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgempresas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dginforme)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker finicio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker ffin;
        private System.Windows.Forms.DataGridView dgempresas;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id_Empresa;
        private System.Windows.Forms.DataGridViewTextBoxColumn Empresa;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dginforme;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_Proveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Proveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Importe;
        private System.Windows.Forms.Button button3;
    }
}