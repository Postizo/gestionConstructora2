namespace GestionConstructora
{
    partial class Form_ImportarTarifas
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
            this.dgexcel = new System.Windows.Forms.DataGridView();
            this.Id_prove = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Codigo_tar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre_tar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio_ta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Url_tar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgsigrid = new System.Windows.Forms.DataGridView();
            this.Codigo_si = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre_si = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio_si = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cbprovedorestarifa = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtbuscaexcel = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtbuscasigri = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbfabricantes = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgexcel)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgsigrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgexcel
            // 
            this.dgexcel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgexcel.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id_prove,
            this.Codigo_tar,
            this.Nombre_tar,
            this.Precio_ta,
            this.Url_tar});
            this.dgexcel.Location = new System.Drawing.Point(5, 24);
            this.dgexcel.Name = "dgexcel";
            this.dgexcel.Size = new System.Drawing.Size(718, 256);
            this.dgexcel.TabIndex = 2;
            this.dgexcel.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgexcel_CellDoubleClick);
            // 
            // Id_prove
            // 
            this.Id_prove.DataPropertyName = "Id_Proveedor";
            this.Id_prove.HeaderText = "id";
            this.Id_prove.Name = "Id_prove";
            this.Id_prove.Visible = false;
            // 
            // Codigo_tar
            // 
            this.Codigo_tar.DataPropertyName = "Codigo";
            this.Codigo_tar.HeaderText = "Codigo";
            this.Codigo_tar.Name = "Codigo_tar";
            this.Codigo_tar.Width = 150;
            // 
            // Nombre_tar
            // 
            this.Nombre_tar.DataPropertyName = "Nombre";
            this.Nombre_tar.HeaderText = "Nombre";
            this.Nombre_tar.Name = "Nombre_tar";
            this.Nombre_tar.Width = 400;
            // 
            // Precio_ta
            // 
            this.Precio_ta.DataPropertyName = "Precio";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = null;
            this.Precio_ta.DefaultCellStyle = dataGridViewCellStyle1;
            this.Precio_ta.HeaderText = "Precio";
            this.Precio_ta.Name = "Precio_ta";
            // 
            // Url_tar
            // 
            this.Url_tar.DataPropertyName = "Url";
            this.Url_tar.HeaderText = "url";
            this.Url_tar.Name = "Url_tar";
            this.Url_tar.Visible = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(9, 33);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(165, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "ACTUALIZAR TODOS";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Location = new System.Drawing.Point(729, 403);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(230, 162);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(9, 62);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(165, 23);
            this.button4.TabIndex = 8;
            this.button4.Text = "INSERTAR";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "label4";
            this.label4.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Fabricante";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(2, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "PRODUCTOS EN TARIFA";
            // 
            // dgsigrid
            // 
            this.dgsigrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgsigrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Codigo_si,
            this.Nombre_si,
            this.Precio_si});
            this.dgsigrid.Location = new System.Drawing.Point(5, 312);
            this.dgsigrid.Name = "dgsigrid";
            this.dgsigrid.Size = new System.Drawing.Size(718, 253);
            this.dgsigrid.TabIndex = 9;
            // 
            // Codigo_si
            // 
            this.Codigo_si.DataPropertyName = "cod";
            this.Codigo_si.HeaderText = "Codigo";
            this.Codigo_si.Name = "Codigo_si";
            this.Codigo_si.Width = 150;
            // 
            // Nombre_si
            // 
            this.Nombre_si.DataPropertyName = "res";
            this.Nombre_si.HeaderText = "Nombre";
            this.Nombre_si.Name = "Nombre_si";
            this.Nombre_si.Width = 400;
            // 
            // Precio_si
            // 
            this.Precio_si.DataPropertyName = "pco";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.Precio_si.DefaultCellStyle = dataGridViewCellStyle2;
            this.Precio_si.HeaderText = "Precio";
            this.Precio_si.Name = "Precio_si";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(2, 296);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "PRODUCTOS EN SIGRID";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(747, 162);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(194, 47);
            this.dataGridView1.TabIndex = 11;
            this.dataGridView1.Visible = false;
            // 
            // cbprovedorestarifa
            // 
            this.cbprovedorestarifa.FormattingEnabled = true;
            this.cbprovedorestarifa.Items.AddRange(new object[] {
            "Zenio\t",
            "Scheneider",
            "Jung"});
            this.cbprovedorestarifa.Location = new System.Drawing.Point(71, 19);
            this.cbprovedorestarifa.Name = "cbprovedorestarifa";
            this.cbprovedorestarifa.Size = new System.Drawing.Size(215, 21);
            this.cbprovedorestarifa.TabIndex = 12;
            this.cbprovedorestarifa.SelectedIndexChanged += new System.EventHandler(this.cbprovedorestarifa_SelectedIndexChanged);
            this.cbprovedorestarifa.SelectionChangeCommitted += new System.EventHandler(this.Cbproveedorestarifa_SelectionChangeCommitted);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtbuscaexcel);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.cbprovedorestarifa);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(729, 24);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(294, 79);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Productos en Tarifa";
            // 
            // txtbuscaexcel
            // 
            this.txtbuscaexcel.Location = new System.Drawing.Point(71, 49);
            this.txtbuscaexcel.Name = "txtbuscaexcel";
            this.txtbuscaexcel.Size = new System.Drawing.Size(215, 20);
            this.txtbuscaexcel.TabIndex = 14;
            this.txtbuscaexcel.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Buscar";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtbuscasigri);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.cbfabricantes);
            this.groupBox3.Location = new System.Drawing.Point(729, 312);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(294, 69);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Productos en Sigrid";
            // 
            // txtbuscasigri
            // 
            this.txtbuscasigri.Location = new System.Drawing.Point(69, 42);
            this.txtbuscasigri.Name = "txtbuscasigri";
            this.txtbuscasigri.Size = new System.Drawing.Size(215, 20);
            this.txtbuscasigri.TabIndex = 17;
            this.txtbuscasigri.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 49);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Buscar";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Fabricante";
            // 
            // cbfabricantes
            // 
            this.cbfabricantes.FormattingEnabled = true;
            this.cbfabricantes.Location = new System.Drawing.Point(69, 15);
            this.cbfabricantes.Name = "cbfabricantes";
            this.cbfabricantes.Size = new System.Drawing.Size(215, 21);
            this.cbfabricantes.TabIndex = 14;
            this.cbfabricantes.SelectionChangeCommitted += new System.EventHandler(this.cbfabricantes_SelectionChangeCommitted_1);
            // 
            // Form_ImportarTarifas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1030, 577);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgsigrid);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgexcel);
            this.Name = "Form_ImportarTarifas";
            this.Text = "Form_ImportarTarifas";
            ((System.ComponentModel.ISupportInitialize)(this.dgexcel)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgsigrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgexcel;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgsigrid;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ComboBox cbprovedorestarifa;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbfabricantes;
        private System.Windows.Forms.TextBox txtbuscaexcel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtbuscasigri;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo_si;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre_si;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio_si;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id_prove;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo_tar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre_tar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio_ta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Url_tar;
    }
}