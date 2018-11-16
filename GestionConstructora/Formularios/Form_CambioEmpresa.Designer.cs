namespace GestionConstructora
{
    partial class Form_CambioEmpresa
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
            this.dgempresas = new System.Windows.Forms.DataGridView();
            this.Id_Empresa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgempresas)).BeginInit();
            this.SuspendLayout();
            // 
            // dgempresas
            // 
            this.dgempresas.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgempresas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgempresas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgempresas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id_Empresa,
            this.Nombre});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.MintCream;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgempresas.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgempresas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgempresas.Location = new System.Drawing.Point(0, 0);
            this.dgempresas.Name = "dgempresas";
            this.dgempresas.ReadOnly = true;
            this.dgempresas.RowHeadersVisible = false;
            this.dgempresas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgempresas.Size = new System.Drawing.Size(531, 225);
            this.dgempresas.TabIndex = 10;
            this.dgempresas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgempresas_CellDoubleClick);
            // 
            // Id_Empresa
            // 
            this.Id_Empresa.DataPropertyName = "Id_Empresa";
            this.Id_Empresa.HeaderText = "Id";
            this.Id_Empresa.Name = "Id_Empresa";
            this.Id_Empresa.ReadOnly = true;
            // 
            // Nombre
            // 
            this.Nombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Nombre.DataPropertyName = "Nombre";
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            // 
            // Form_CambioEmpresa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 225);
            this.Controls.Add(this.dgempresas);
            this.Name = "Form_CambioEmpresa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Empresas";
            ((System.ComponentModel.ISupportInitialize)(this.dgempresas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgempresas;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id_Empresa;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
    }
}