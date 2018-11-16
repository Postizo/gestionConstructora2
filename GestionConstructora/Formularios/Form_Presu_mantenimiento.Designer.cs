namespace GestionConstructora
{
    partial class Form_Presu_mantenimiento
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Presu_mantenimiento));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panelizquierda = new System.Windows.Forms.TableLayoutPanel();
            this.dgestancias = new System.Windows.Forms.DataGridView();
            this.id_estancia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.dgelementos = new System.Windows.Forms.DataGridView();
            this.lelementos = new System.Windows.Forms.Label();
            this.Id_Elemento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unidades = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panelizquierda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgestancias)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgelementos)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.splitContainer1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(658, 564);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 16);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panelizquierda);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Size = new System.Drawing.Size(652, 545);
            this.splitContainer1.SplitterDistance = 301;
            this.splitContainer1.TabIndex = 0;
            // 
            // panelizquierda
            // 
            this.panelizquierda.ColumnCount = 2;
            this.panelizquierda.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelizquierda.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 129F));
            this.panelizquierda.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.panelizquierda.Controls.Add(this.dgestancias, 0, 1);
            this.panelizquierda.Controls.Add(this.button1, 0, 3);
            this.panelizquierda.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelizquierda.Location = new System.Drawing.Point(0, 0);
            this.panelizquierda.Name = "panelizquierda";
            this.panelizquierda.RowCount = 4;
            this.panelizquierda.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.panelizquierda.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelizquierda.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            this.panelizquierda.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.panelizquierda.Size = new System.Drawing.Size(301, 545);
            this.panelizquierda.TabIndex = 0;
            // 
            // dgestancias
            // 
            this.dgestancias.AllowUserToAddRows = false;
            this.dgestancias.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgestancias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgestancias.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_estancia,
            this.dataGridViewTextBoxColumn2});
            this.panelizquierda.SetColumnSpan(this.dgestancias, 2);
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.MintCream;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgestancias.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgestancias.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgestancias.Location = new System.Drawing.Point(3, 23);
            this.dgestancias.Name = "dgestancias";
            this.dgestancias.ReadOnly = true;
            this.dgestancias.RowHeadersVisible = false;
            this.dgestancias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgestancias.Size = new System.Drawing.Size(295, 466);
            this.dgestancias.TabIndex = 27;
            this.dgestancias.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgestancias_RowEnter);
            // 
            // id_estancia
            // 
            this.id_estancia.DataPropertyName = "id_Estancia";
            this.id_estancia.HeaderText = "Id_Estancia";
            this.id_estancia.Name = "id_estancia";
            this.id_estancia.ReadOnly = true;
            this.id_estancia.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Nombre";
            this.dataGridViewTextBoxColumn2.HeaderText = "Estancia";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Location = new System.Drawing.Point(3, 516);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(166, 26);
            this.button1.TabIndex = 30;
            this.button1.Text = "Crear Estancia";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 194F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.button3, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.button2, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.dgelementos, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lelementos, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(347, 545);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // button3
            // 
            this.button3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button3.Location = new System.Drawing.Point(3, 515);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(147, 27);
            this.button3.TabIndex = 32;
            this.button3.Text = "Crear Elementos";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button2.Location = new System.Drawing.Point(156, 515);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(188, 27);
            this.button2.TabIndex = 31;
            this.button2.Text = "Modificar Elementos";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dgelementos
            // 
            this.dgelementos.AllowUserToAddRows = false;
            this.dgelementos.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgelementos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgelementos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id_Elemento,
            this.dataGridViewTextBoxColumn5,
            this.Unidades});
            this.tableLayoutPanel1.SetColumnSpan(this.dgelementos, 2);
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.MintCream;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgelementos.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgelementos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgelementos.Location = new System.Drawing.Point(3, 23);
            this.dgelementos.Name = "dgelementos";
            this.dgelementos.RowHeadersVisible = false;
            this.dgelementos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgelementos.Size = new System.Drawing.Size(341, 466);
            this.dgelementos.TabIndex = 27;
            this.dgelementos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgelementos_CellDoubleClick);
            this.dgelementos.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgelementos_CellEndEdit);
            this.dgelementos.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgelementos_RowEnter);
            // 
            // lelementos
            // 
            this.lelementos.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.lelementos, 2);
            this.lelementos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lelementos.ForeColor = System.Drawing.Color.Blue;
            this.lelementos.Location = new System.Drawing.Point(3, 0);
            this.lelementos.Name = "lelementos";
            this.lelementos.Size = new System.Drawing.Size(341, 20);
            this.lelementos.TabIndex = 28;
            this.lelementos.Text = "linfo";
            this.lelementos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Id_Elemento
            // 
            this.Id_Elemento.DataPropertyName = "Id_Elemento";
            this.Id_Elemento.HeaderText = "Id_Elemento";
            this.Id_Elemento.Name = "Id_Elemento";
            this.Id_Elemento.Visible = false;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Nombre";
            this.dataGridViewTextBoxColumn5.HeaderText = "Elementos";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // Unidades
            // 
            this.Unidades.HeaderText = "Unidades";
            this.Unidades.Name = "Unidades";
            // 
            // Form_Presu_mantenimiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 564);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_Presu_mantenimiento";
            this.Text = "Presupuesto Mantenimiento";
            this.groupBox1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panelizquierda.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgestancias)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgelementos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel panelizquierda;
        private System.Windows.Forms.DataGridView dgestancias;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_estancia;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dgelementos;
        private System.Windows.Forms.Label lelementos;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id_Elemento;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unidades;
    }
}