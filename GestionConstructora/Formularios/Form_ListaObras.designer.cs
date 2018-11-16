namespace GestionConstructora
{
    partial class ListaObras
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListaObras));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pbuscar = new System.Windows.Forms.Panel();
            this.lloading = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Rbabiertas = new System.Windows.Forms.RadioButton();
            this.RbTodas = new System.Windows.Forms.RadioButton();
            this.txtbuscar = new System.Windows.Forms.TextBox();
            this.buscar = new System.Windows.Forms.Label();
            this.List_Obras = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1.SuspendLayout();
            this.pbuscar.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.List_Obras)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.pbuscar, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.List_Obras, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(423, 645);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // pbuscar
            // 
            this.pbuscar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbuscar.Controls.Add(this.lloading);
            this.pbuscar.Controls.Add(this.groupBox1);
            this.pbuscar.Controls.Add(this.txtbuscar);
            this.pbuscar.Controls.Add(this.buscar);
            this.pbuscar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbuscar.Location = new System.Drawing.Point(3, 454);
            this.pbuscar.Name = "pbuscar";
            this.pbuscar.Size = new System.Drawing.Size(417, 188);
            this.pbuscar.TabIndex = 5;
            // 
            // lloading
            // 
            this.lloading.AutoSize = true;
            this.lloading.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lloading.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lloading.ForeColor = System.Drawing.Color.Firebrick;
            this.lloading.Location = new System.Drawing.Point(0, 99);
            this.lloading.Name = "lloading";
            this.lloading.Size = new System.Drawing.Size(384, 63);
            this.lloading.TabIndex = 3;
            this.lloading.Text = "CARGANDO...";
            this.lloading.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Rbabiertas);
            this.groupBox1.Controls.Add(this.RbTodas);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 46);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(415, 53);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // Rbabiertas
            // 
            this.Rbabiertas.AutoSize = true;
            this.Rbabiertas.Dock = System.Windows.Forms.DockStyle.Left;
            this.Rbabiertas.Location = new System.Drawing.Point(65, 16);
            this.Rbabiertas.Name = "Rbabiertas";
            this.Rbabiertas.Size = new System.Drawing.Size(78, 34);
            this.Rbabiertas.TabIndex = 1;
            this.Rbabiertas.TabStop = true;
            this.Rbabiertas.Text = "ABIERTAS";
            this.Rbabiertas.UseVisualStyleBackColor = true;
            this.Rbabiertas.CheckedChanged += new System.EventHandler(this.Rbabiertas_CheckedChanged);
            // 
            // RbTodas
            // 
            this.RbTodas.AutoSize = true;
            this.RbTodas.Checked = true;
            this.RbTodas.Dock = System.Windows.Forms.DockStyle.Left;
            this.RbTodas.Location = new System.Drawing.Point(3, 16);
            this.RbTodas.Name = "RbTodas";
            this.RbTodas.Size = new System.Drawing.Size(62, 34);
            this.RbTodas.TabIndex = 0;
            this.RbTodas.TabStop = true;
            this.RbTodas.Text = "TODAS";
            this.RbTodas.UseVisualStyleBackColor = true;
            this.RbTodas.CheckedChanged += new System.EventHandler(this.RbTodas_CheckedChanged);
            // 
            // txtbuscar
            // 
            this.txtbuscar.BackColor = System.Drawing.SystemColors.Info;
            this.txtbuscar.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtbuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbuscar.Location = new System.Drawing.Point(0, 20);
            this.txtbuscar.Name = "txtbuscar";
            this.txtbuscar.Size = new System.Drawing.Size(415, 26);
            this.txtbuscar.TabIndex = 1;
            this.txtbuscar.TextChanged += new System.EventHandler(this.txtbuscar_TextChanged);
            // 
            // buscar
            // 
            this.buscar.AutoSize = true;
            this.buscar.Dock = System.Windows.Forms.DockStyle.Top;
            this.buscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buscar.Location = new System.Drawing.Point(0, 0);
            this.buscar.Name = "buscar";
            this.buscar.Size = new System.Drawing.Size(65, 20);
            this.buscar.TabIndex = 0;
            this.buscar.Text = "Buscar";
            // 
            // List_Obras
            // 
            this.List_Obras.AllowUserToAddRows = false;
            this.List_Obras.AllowUserToDeleteRows = false;
            this.List_Obras.AllowUserToResizeRows = false;
            this.List_Obras.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.List_Obras.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.List_Obras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.List_Obras.DefaultCellStyle = dataGridViewCellStyle1;
            this.List_Obras.Dock = System.Windows.Forms.DockStyle.Fill;
            this.List_Obras.GridColor = System.Drawing.SystemColors.Control;
            this.List_Obras.Location = new System.Drawing.Point(3, 3);
            this.List_Obras.MultiSelect = false;
            this.List_Obras.Name = "List_Obras";
            this.List_Obras.ReadOnly = true;
            this.List_Obras.RowHeadersVisible = false;
            this.List_Obras.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.List_Obras.Size = new System.Drawing.Size(417, 445);
            this.List_Obras.TabIndex = 2;
            this.List_Obras.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.List_Obras_CellMouseDoubleClick);
            // 
            // ListaObras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 645);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ListaObras";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listado de Obras";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.pbuscar.ResumeLayout(false);
            this.pbuscar.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.List_Obras)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView List_Obras;
        private System.Windows.Forms.Panel pbuscar;
        private System.Windows.Forms.Label lloading;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton Rbabiertas;
        private System.Windows.Forms.RadioButton RbTodas;
        private System.Windows.Forms.TextBox txtbuscar;
        private System.Windows.Forms.Label buscar;
    }
}