namespace GestionConstructora
{
    partial class Form_PresuConta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_PresuConta));
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.pgeneral = new System.Windows.Forms.TableLayoutPanel();
            this.pizquierda = new System.Windows.Forms.TableLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.listObras = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pderecha = new System.Windows.Forms.TableLayoutPanel();
            this.dginforme = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            this.txtinfo = new System.Windows.Forms.TextBox();
            this.toolStripContainer1.SuspendLayout();
            this.pgeneral.SuspendLayout();
            this.pizquierda.SuspendLayout();
            this.pderecha.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dginforme)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(8, 0);
            this.toolStripContainer1.Location = new System.Drawing.Point(887, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(8, 8);
            this.toolStripContainer1.TabIndex = 4;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // pgeneral
            // 
            this.pgeneral.ColumnCount = 2;
            this.pgeneral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.pgeneral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pgeneral.Controls.Add(this.pizquierda, 0, 0);
            this.pgeneral.Controls.Add(this.pderecha, 1, 0);
            this.pgeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pgeneral.Location = new System.Drawing.Point(0, 0);
            this.pgeneral.Name = "pgeneral";
            this.pgeneral.RowCount = 1;
            this.pgeneral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pgeneral.Size = new System.Drawing.Size(1064, 683);
            this.pgeneral.TabIndex = 3;
            // 
            // pizquierda
            // 
            this.pizquierda.BackColor = System.Drawing.SystemColors.Control;
            this.pizquierda.ColumnCount = 1;
            this.pizquierda.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pizquierda.Controls.Add(this.button1, 0, 2);
            this.pizquierda.Controls.Add(this.listObras, 0, 1);
            this.pizquierda.Controls.Add(this.label2, 0, 0);
            this.pizquierda.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pizquierda.Location = new System.Drawing.Point(3, 3);
            this.pizquierda.Name = "pizquierda";
            this.pizquierda.RowCount = 4;
            this.pizquierda.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.302326F));
            this.pizquierda.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 81.39534F));
            this.pizquierda.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.302327F));
            this.pizquierda.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.pizquierda.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.pizquierda.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.pizquierda.Size = new System.Drawing.Size(194, 677);
            this.pizquierda.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Location = new System.Drawing.Point(3, 525);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(188, 47);
            this.button1.TabIndex = 8;
            this.button1.Text = "CALCULAR";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listObras
            // 
            this.listObras.BackColor = System.Drawing.Color.Honeydew;
            this.listObras.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listObras.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listObras.FormattingEnabled = true;
            this.listObras.ItemHeight = 20;
            this.listObras.Location = new System.Drawing.Point(3, 56);
            this.listObras.Name = "listObras";
            this.listObras.Size = new System.Drawing.Size(188, 463);
            this.listObras.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(188, 53);
            this.label2.TabIndex = 2;
            this.label2.Text = "OBRAS";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pderecha
            // 
            this.pderecha.ColumnCount = 6;
            this.pderecha.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.pderecha.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.pderecha.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.pderecha.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pderecha.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pderecha.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.pderecha.Controls.Add(this.dginforme, 0, 0);
            this.pderecha.Controls.Add(this.button2, 0, 1);
            this.pderecha.Controls.Add(this.txtinfo, 5, 1);
            this.pderecha.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pderecha.Location = new System.Drawing.Point(203, 3);
            this.pderecha.Name = "pderecha";
            this.pderecha.RowCount = 2;
            this.pderecha.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pderecha.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.pderecha.Size = new System.Drawing.Size(858, 677);
            this.pderecha.TabIndex = 3;
            // 
            // dginforme
            // 
            this.dginforme.AllowUserToAddRows = false;
            this.pderecha.SetColumnSpan(this.dginforme, 6);
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dginforme.DefaultCellStyle = dataGridViewCellStyle1;
            this.dginforme.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dginforme.Location = new System.Drawing.Point(3, 3);
            this.dginforme.Name = "dginforme";
            this.dginforme.RowHeadersWidth = 35;
            this.dginforme.Size = new System.Drawing.Size(852, 631);
            this.dginforme.TabIndex = 4;
            this.dginforme.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dginforme_CellEndEdit);
            this.dginforme.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dginforme_CellValidated);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(3, 640);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(84, 34);
            this.button2.TabIndex = 5;
            this.button2.Text = "ATRAS";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtinfo
            // 
            this.txtinfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtinfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtinfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtinfo.Location = new System.Drawing.Point(661, 640);
            this.txtinfo.Multiline = true;
            this.txtinfo.Name = "txtinfo";
            this.txtinfo.ReadOnly = true;
            this.txtinfo.Size = new System.Drawing.Size(194, 34);
            this.txtinfo.TabIndex = 10;
            this.txtinfo.Text = "Line1\\r\\nLine 2";
            // 
            // Form_PresuConta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 683);
            this.Controls.Add(this.toolStripContainer1);
            this.Controls.Add(this.pgeneral);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_PresuConta";
            this.Text = "Presupuestos Contables";
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.pgeneral.ResumeLayout(false);
            this.pizquierda.ResumeLayout(false);
            this.pizquierda.PerformLayout();
            this.pderecha.ResumeLayout(false);
            this.pderecha.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dginforme)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.TableLayoutPanel pgeneral;
        private System.Windows.Forms.TableLayoutPanel pizquierda;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox listObras;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel pderecha;
        private System.Windows.Forms.DataGridView dginforme;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtinfo;
    }
}