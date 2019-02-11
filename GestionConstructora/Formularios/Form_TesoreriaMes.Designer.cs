namespace GestionConstructora
{
    partial class Form_TesoreriaMes
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgmeses = new System.Windows.Forms.DataGridView();
            this.dcid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dcidtesoreria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dcmes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dcaño = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dcMesAño = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dcimporte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgmeses)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.SeaShell;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.dgmeses, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.button1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 89.89247F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.10753F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(414, 465);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dgmeses
            // 
            this.dgmeses.AllowUserToAddRows = false;
            this.dgmeses.BackgroundColor = System.Drawing.Color.SeaShell;
            this.dgmeses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgmeses.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dcid,
            this.dcidtesoreria,
            this.dcmes,
            this.dcaño,
            this.dcMesAño,
            this.dcimporte});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.MintCream;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgmeses.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgmeses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgmeses.Location = new System.Drawing.Point(3, 3);
            this.dgmeses.Name = "dgmeses";
            this.dgmeses.RowHeadersVisible = false;
            this.dgmeses.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgmeses.Size = new System.Drawing.Size(408, 411);
            this.dgmeses.TabIndex = 23;
            this.dgmeses.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgmeses_CellEndEdit);
            // 
            // dcid
            // 
            this.dcid.DataPropertyName = "id";
            this.dcid.HeaderText = "id";
            this.dcid.Name = "dcid";
            this.dcid.Visible = false;
            this.dcid.Width = 5;
            // 
            // dcidtesoreria
            // 
            this.dcidtesoreria.DataPropertyName = "id_tesoreria";
            this.dcidtesoreria.HeaderText = "id_tesoreria";
            this.dcidtesoreria.Name = "dcidtesoreria";
            this.dcidtesoreria.Visible = false;
            // 
            // dcmes
            // 
            this.dcmes.DataPropertyName = "mes";
            this.dcmes.HeaderText = "mes";
            this.dcmes.Name = "dcmes";
            this.dcmes.Visible = false;
            // 
            // dcaño
            // 
            this.dcaño.DataPropertyName = "año";
            this.dcaño.HeaderText = "año";
            this.dcaño.Name = "dcaño";
            this.dcaño.Visible = false;
            // 
            // dcMesAño
            // 
            this.dcMesAño.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dcMesAño.DataPropertyName = "MesAño";
            this.dcMesAño.HeaderText = "Fecha";
            this.dcMesAño.Name = "dcMesAño";
            // 
            // dcimporte
            // 
            this.dcimporte.DataPropertyName = "Importe";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = null;
            this.dcimporte.DefaultCellStyle = dataGridViewCellStyle1;
            this.dcimporte.HeaderText = "Importe";
            this.dcimporte.Name = "dcimporte";
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(3, 420);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(408, 42);
            this.button1.TabIndex = 24;
            this.button1.Text = "GUARDAR";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form_TesoreriaMes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 465);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_TesoreriaMes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_TesoreriaMes";
            this.Load += new System.EventHandler(this.Form_TesoreriaMes_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgmeses)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dgmeses;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dcid;
        private System.Windows.Forms.DataGridViewTextBoxColumn dcidtesoreria;
        private System.Windows.Forms.DataGridViewTextBoxColumn dcmes;
        private System.Windows.Forms.DataGridViewTextBoxColumn dcaño;
        private System.Windows.Forms.DataGridViewTextBoxColumn dcMesAño;
        private System.Windows.Forms.DataGridViewTextBoxColumn dcimporte;
    }
}