namespace GestionConstructora
{
    partial class Form_Obrasmetros
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
            this.dgobras = new System.Windows.Forms.DataGridView();
            this.Id_Obra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_Empresa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_escriturados = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_construidos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_utiles = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgobras)).BeginInit();
            this.SuspendLayout();
            // 
            // dgobras
            // 
            this.dgobras.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgobras.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgobras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgobras.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id_Obra,
            this.id_Empresa,
            this.Nombre,
            this.m_escriturados,
            this.m_construidos,
            this.m_utiles});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.MintCream;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgobras.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgobras.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgobras.Location = new System.Drawing.Point(0, 0);
            this.dgobras.Name = "dgobras";
            this.dgobras.RowHeadersVisible = false;
            this.dgobras.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgobras.Size = new System.Drawing.Size(1105, 669);
            this.dgobras.TabIndex = 4;
            this.dgobras.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgobras_CellEndEdit);
            this.dgobras.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgobras_CellValidated);
            // 
            // Id_Obra
            // 
            this.Id_Obra.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Id_Obra.DataPropertyName = "Id_Obra";
            this.Id_Obra.HeaderText = "Id_Obra";
            this.Id_Obra.Name = "Id_Obra";
            this.Id_Obra.Visible = false;
            // 
            // id_Empresa
            // 
            this.id_Empresa.DataPropertyName = "id_empresa";
            this.id_Empresa.HeaderText = "Id_empresa";
            this.id_Empresa.Name = "id_Empresa";
            // 
            // Nombre
            // 
            this.Nombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Nombre.DataPropertyName = "Nombre";
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            // 
            // m_escriturados
            // 
            this.m_escriturados.DataPropertyName = "M_escriturados";
            this.m_escriturados.HeaderText = "Escriturados";
            this.m_escriturados.Name = "m_escriturados";
            // 
            // m_construidos
            // 
            this.m_construidos.DataPropertyName = "M_construidos";
            this.m_construidos.HeaderText = "Construidos";
            this.m_construidos.Name = "m_construidos";
            // 
            // m_utiles
            // 
            this.m_utiles.DataPropertyName = "M_Utiles";
            this.m_utiles.HeaderText = "Utiles";
            this.m_utiles.Name = "m_utiles";
            // 
            // Form_Obrasmetros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1105, 669);
            this.Controls.Add(this.dgobras);
            this.Name = "Form_Obrasmetros";
            this.Text = "Form_Obrasmetros";
            ((System.ComponentModel.ISupportInitialize)(this.dgobras)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgobras;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id_Obra;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_Empresa;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_escriturados;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_construidos;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_utiles;
    }
}