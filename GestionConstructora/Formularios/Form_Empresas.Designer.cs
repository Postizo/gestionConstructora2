namespace GestionConstructora
{
    partial class Form_Empresas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Empresas));
            this.pcontenedor = new System.Windows.Forms.TableLayoutPanel();
            this.pdatos = new System.Windows.Forms.FlowLayoutPanel();
            this.llegenda = new System.Windows.Forms.Label();
            this.lnombre = new System.Windows.Forms.Label();
            this.txtnombre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtbbdd = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtservidor = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtusuario = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtpwd = new System.Windows.Forms.TextBox();
            this.pbotones = new System.Windows.Forms.FlowLayoutPanel();
            this.bttAñadir = new System.Windows.Forms.Button();
            this.bttnuevo = new System.Windows.Forms.Button();
            this.btteditar = new System.Windows.Forms.Button();
            this.bttborrar = new System.Windows.Forms.Button();
            this.dgempresas = new System.Windows.Forms.DataGridView();
            this.Id_Empresa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Empresa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bbdd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Servidor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pcontenedor.SuspendLayout();
            this.pdatos.SuspendLayout();
            this.pbotones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgempresas)).BeginInit();
            this.SuspendLayout();
            // 
            // pcontenedor
            // 
            this.pcontenedor.ColumnCount = 2;
            this.pcontenedor.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pcontenedor.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pcontenedor.Controls.Add(this.dgempresas, 0, 0);
            this.pcontenedor.Controls.Add(this.pdatos, 1, 0);
            this.pcontenedor.Controls.Add(this.pbotones, 1, 1);
            this.pcontenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcontenedor.Location = new System.Drawing.Point(0, 0);
            this.pcontenedor.Name = "pcontenedor";
            this.pcontenedor.RowCount = 2;
            this.pcontenedor.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.pcontenedor.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.pcontenedor.Size = new System.Drawing.Size(651, 636);
            this.pcontenedor.TabIndex = 1;
            // 
            // pdatos
            // 
            this.pdatos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pdatos.Controls.Add(this.llegenda);
            this.pdatos.Controls.Add(this.lnombre);
            this.pdatos.Controls.Add(this.txtnombre);
            this.pdatos.Controls.Add(this.label2);
            this.pdatos.Controls.Add(this.txtbbdd);
            this.pdatos.Controls.Add(this.label3);
            this.pdatos.Controls.Add(this.txtservidor);
            this.pdatos.Controls.Add(this.label4);
            this.pdatos.Controls.Add(this.txtusuario);
            this.pdatos.Controls.Add(this.label5);
            this.pdatos.Controls.Add(this.txtpwd);
            this.pdatos.Controls.Add(this.bttAñadir);
            this.pdatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pdatos.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pdatos.Location = new System.Drawing.Point(328, 3);
            this.pdatos.Name = "pdatos";
            this.pdatos.Size = new System.Drawing.Size(320, 502);
            this.pdatos.TabIndex = 0;
            // 
            // llegenda
            // 
            this.llegenda.AutoSize = true;
            this.llegenda.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.llegenda.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llegenda.Location = new System.Drawing.Point(3, 0);
            this.llegenda.Name = "llegenda";
            this.llegenda.Padding = new System.Windows.Forms.Padding(2, 10, 2, 2);
            this.llegenda.Size = new System.Drawing.Size(295, 32);
            this.llegenda.TabIndex = 1;
            this.llegenda.Text = "Nombre";
            this.llegenda.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lnombre
            // 
            this.lnombre.AutoSize = true;
            this.lnombre.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lnombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnombre.Location = new System.Drawing.Point(3, 32);
            this.lnombre.Name = "lnombre";
            this.lnombre.Padding = new System.Windows.Forms.Padding(2, 5, 2, 2);
            this.lnombre.Size = new System.Drawing.Size(295, 27);
            this.lnombre.TabIndex = 3;
            this.lnombre.Text = "Nombre";
            // 
            // txtnombre
            // 
            this.txtnombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtnombre.Location = new System.Drawing.Point(3, 62);
            this.txtnombre.Name = "txtnombre";
            this.txtnombre.Size = new System.Drawing.Size(295, 26);
            this.txtnombre.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 91);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(2, 5, 2, 2);
            this.label2.Size = new System.Drawing.Size(295, 27);
            this.label2.TabIndex = 7;
            this.label2.Text = "BBDD";
            // 
            // txtbbdd
            // 
            this.txtbbdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbbdd.Location = new System.Drawing.Point(3, 121);
            this.txtbbdd.Name = "txtbbdd";
            this.txtbbdd.Size = new System.Drawing.Size(295, 26);
            this.txtbbdd.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 150);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(2, 5, 2, 2);
            this.label3.Size = new System.Drawing.Size(295, 27);
            this.label3.TabIndex = 12;
            this.label3.Text = "Servidor";
            // 
            // txtservidor
            // 
            this.txtservidor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtservidor.Location = new System.Drawing.Point(3, 180);
            this.txtservidor.Name = "txtservidor";
            this.txtservidor.Size = new System.Drawing.Size(295, 26);
            this.txtservidor.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 209);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(2, 5, 2, 2);
            this.label4.Size = new System.Drawing.Size(295, 27);
            this.label4.TabIndex = 13;
            this.label4.Text = "Usuario";
            // 
            // txtusuario
            // 
            this.txtusuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtusuario.Location = new System.Drawing.Point(3, 239);
            this.txtusuario.Name = "txtusuario";
            this.txtusuario.Size = new System.Drawing.Size(295, 26);
            this.txtusuario.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 268);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(2, 10, 2, 2);
            this.label5.Size = new System.Drawing.Size(295, 32);
            this.label5.TabIndex = 16;
            this.label5.Text = "Contraseña";
            // 
            // txtpwd
            // 
            this.txtpwd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpwd.Location = new System.Drawing.Point(3, 303);
            this.txtpwd.Name = "txtpwd";
            this.txtpwd.Size = new System.Drawing.Size(295, 26);
            this.txtpwd.TabIndex = 14;
            // 
            // pbotones
            // 
            this.pbotones.Controls.Add(this.bttnuevo);
            this.pbotones.Controls.Add(this.btteditar);
            this.pbotones.Controls.Add(this.bttborrar);
            this.pbotones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pbotones.Location = new System.Drawing.Point(328, 551);
            this.pbotones.Name = "pbotones";
            this.pbotones.Size = new System.Drawing.Size(320, 82);
            this.pbotones.TabIndex = 2;
            // 
            // bttAñadir
            // 
            this.bttAñadir.Image = Properties.Resources.mas;
            this.bttAñadir.Location = new System.Drawing.Point(3, 335);
            this.bttAñadir.Name = "bttAñadir";
            this.bttAñadir.Size = new System.Drawing.Size(75, 75);
            this.bttAñadir.TabIndex = 15;
            this.bttAñadir.UseVisualStyleBackColor = true;
            this.bttAñadir.Click += new System.EventHandler(this.bttAñadir_Click);
            // 
            // bttnuevo
            // 
            this.bttnuevo.Image = global::GestionConstructora.Properties.Resources.mas;
            this.bttnuevo.Location = new System.Drawing.Point(3, 3);
            this.bttnuevo.Name = "bttnuevo";
            this.bttnuevo.Size = new System.Drawing.Size(75, 75);
            this.bttnuevo.TabIndex = 1;
            this.bttnuevo.UseVisualStyleBackColor = true;
            this.bttnuevo.Click += new System.EventHandler(this.bttnuevo_Click);
            // 
            // btteditar
            // 
            this.btteditar.Image = global::GestionConstructora.Properties.Resources.editar;
            this.btteditar.Location = new System.Drawing.Point(84, 3);
            this.btteditar.Name = "btteditar";
            this.btteditar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btteditar.Size = new System.Drawing.Size(75, 75);
            this.btteditar.TabIndex = 0;
            this.btteditar.UseVisualStyleBackColor = true;
            this.btteditar.Click += new System.EventHandler(this.btteditar_Click);
            // 
            // bttborrar
            // 
            this.bttborrar.Image = global::GestionConstructora.Properties.Resources.cancelar;
            this.bttborrar.Location = new System.Drawing.Point(165, 3);
            this.bttborrar.Name = "bttborrar";
            this.bttborrar.Size = new System.Drawing.Size(75, 75);
            this.bttborrar.TabIndex = 2;
            this.bttborrar.UseVisualStyleBackColor = true;
            this.bttborrar.Click += new System.EventHandler(this.bttborrar_Click);
            // 
            // dgempresas
            // 
            this.dgempresas.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgempresas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgempresas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgempresas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id_Empresa,
            this.Empresa,
            this.bbdd,
            this.Servidor});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.MintCream;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgempresas.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgempresas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgempresas.Location = new System.Drawing.Point(3, 3);
            this.dgempresas.Name = "dgempresas";
            this.dgempresas.ReadOnly = true;
            this.dgempresas.RowHeadersVisible = false;
            this.dgempresas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgempresas.Size = new System.Drawing.Size(319, 502);
            this.dgempresas.TabIndex = 3;
            this.dgempresas.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgempresas_ColumnHeaderMouseClick);
            this.dgempresas.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgempresas_RowEnter);
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
            // bbdd
            // 
            this.bbdd.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.bbdd.DataPropertyName = "BBDD";
            this.bbdd.HeaderText = "BBDD";
            this.bbdd.Name = "bbdd";
            this.bbdd.ReadOnly = true;
            // 
            // Servidor
            // 
            this.Servidor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Servidor.DataPropertyName = "Servidor";
            this.Servidor.HeaderText = "Servidor";
            this.Servidor.Name = "Servidor";
            this.Servidor.ReadOnly = true;
            // 
            // Form_Empresas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 636);
            this.Controls.Add(this.pcontenedor);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_Empresas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Empresas";
            this.pcontenedor.ResumeLayout(false);
            this.pdatos.ResumeLayout(false);
            this.pdatos.PerformLayout();
            this.pbotones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgempresas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel pcontenedor;
        private System.Windows.Forms.FlowLayoutPanel pdatos;
        private System.Windows.Forms.Label llegenda;
        private System.Windows.Forms.TextBox txtnombre;
        private System.Windows.Forms.Label lnombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel pbotones;
        private System.Windows.Forms.Button bttnuevo;
        private System.Windows.Forms.Button btteditar;
        private System.Windows.Forms.Button bttborrar;
        private System.Windows.Forms.TextBox txtbbdd;
        private System.Windows.Forms.TextBox txtservidor;
        private System.Windows.Forms.TextBox txtusuario;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtpwd;
        private System.Windows.Forms.Button bttAñadir;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgempresas;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id_Empresa;
        private System.Windows.Forms.DataGridViewTextBoxColumn Empresa;
        private System.Windows.Forms.DataGridViewTextBoxColumn bbdd;
        private System.Windows.Forms.DataGridViewTextBoxColumn Servidor;
    }
}