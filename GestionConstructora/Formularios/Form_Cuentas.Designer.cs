namespace GestionConstructora
{
    partial class Form_Cuentas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Cuentas));
            this.llegenda = new System.Windows.Forms.Label();
            this.lcuenta = new System.Windows.Forms.Label();
            this.txtcuenta = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtnombre = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pbotones = new System.Windows.Forms.FlowLayoutPanel();
            this.bttnuevo = new System.Windows.Forms.Button();
            this.btteditar = new System.Windows.Forms.Button();
            this.bttborrar = new System.Windows.Forms.Button();
            this.dgcuentas = new System.Windows.Forms.DataGridView();
            this.pdatos = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.cbempresa = new System.Windows.Forms.ComboBox();
            this.cbgrupo = new System.Windows.Forms.ComboBox();
            this.cbsubgrupo = new System.Windows.Forms.ComboBox();
            this.chtratacuenta = new System.Windows.Forms.CheckBox();
            this.bttAñadir = new System.Windows.Forms.Button();
            this.pcontenedor = new System.Windows.Forms.TableLayoutPanel();
            this.pbuscar = new System.Windows.Forms.FlowLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.txtbuscar = new System.Windows.Forms.TextBox();
            this.chbuscatrata = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.Empresa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cuentas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Grupo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tratar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pbotones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgcuentas)).BeginInit();
            this.pdatos.SuspendLayout();
            this.pcontenedor.SuspendLayout();
            this.pbuscar.SuspendLayout();
            this.SuspendLayout();
            // 
            // llegenda
            // 
            this.llegenda.AutoSize = true;
            this.llegenda.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.llegenda.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llegenda.Location = new System.Drawing.Point(3, 0);
            this.llegenda.Name = "llegenda";
            this.llegenda.Padding = new System.Windows.Forms.Padding(2, 10, 2, 2);
            this.llegenda.Size = new System.Drawing.Size(288, 32);
            this.llegenda.TabIndex = 1;
            this.llegenda.Text = "Nombre";
            this.llegenda.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lcuenta
            // 
            this.lcuenta.AutoSize = true;
            this.lcuenta.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lcuenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lcuenta.Location = new System.Drawing.Point(3, 86);
            this.lcuenta.Name = "lcuenta";
            this.lcuenta.Padding = new System.Windows.Forms.Padding(2, 5, 2, 2);
            this.lcuenta.Size = new System.Drawing.Size(288, 27);
            this.lcuenta.TabIndex = 3;
            this.lcuenta.Text = "Cuenta";
            // 
            // txtcuenta
            // 
            this.txtcuenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcuenta.Location = new System.Drawing.Point(3, 116);
            this.txtcuenta.Name = "txtcuenta";
            this.txtcuenta.Size = new System.Drawing.Size(288, 26);
            this.txtcuenta.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 145);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(2, 5, 2, 2);
            this.label2.Size = new System.Drawing.Size(288, 27);
            this.label2.TabIndex = 7;
            this.label2.Text = "Nombre";
            // 
            // txtnombre
            // 
            this.txtnombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtnombre.Location = new System.Drawing.Point(3, 175);
            this.txtnombre.Name = "txtnombre";
            this.txtnombre.Size = new System.Drawing.Size(288, 26);
            this.txtnombre.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 204);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(2, 5, 2, 2);
            this.label3.Size = new System.Drawing.Size(288, 27);
            this.label3.TabIndex = 12;
            this.label3.Text = "Grupo";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 265);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(2, 5, 2, 2);
            this.label4.Size = new System.Drawing.Size(288, 27);
            this.label4.TabIndex = 13;
            this.label4.Text = "Subgrupo";
            // 
            // pbotones
            // 
            this.pbotones.Controls.Add(this.bttnuevo);
            this.pbotones.Controls.Add(this.btteditar);
            this.pbotones.Controls.Add(this.bttborrar);
            this.pbotones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pbotones.Location = new System.Drawing.Point(672, 505);
            this.pbotones.Name = "pbotones";
            this.pbotones.Size = new System.Drawing.Size(311, 82);
            this.pbotones.TabIndex = 2;
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
            // dgcuentas
            // 
            this.dgcuentas.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgcuentas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgcuentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgcuentas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Empresa,
            this.Cuentas,
            this.Nombre,
            this.Grupo,
            this.Tratar});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.MintCream;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgcuentas.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgcuentas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgcuentas.Location = new System.Drawing.Point(3, 3);
            this.dgcuentas.Name = "dgcuentas";
            this.dgcuentas.ReadOnly = true;
            this.dgcuentas.RowHeadersVisible = false;
            this.dgcuentas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgcuentas.Size = new System.Drawing.Size(663, 434);
            this.dgcuentas.TabIndex = 1;
            this.dgcuentas.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgcuentas_ColumnHeaderMouseClick);
            this.dgcuentas.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgempresas_RowEnter);
            // 
            // pdatos
            // 
            this.pdatos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pdatos.Controls.Add(this.llegenda);
            this.pdatos.Controls.Add(this.label1);
            this.pdatos.Controls.Add(this.cbempresa);
            this.pdatos.Controls.Add(this.lcuenta);
            this.pdatos.Controls.Add(this.txtcuenta);
            this.pdatos.Controls.Add(this.label2);
            this.pdatos.Controls.Add(this.txtnombre);
            this.pdatos.Controls.Add(this.label3);
            this.pdatos.Controls.Add(this.cbgrupo);
            this.pdatos.Controls.Add(this.label4);
            this.pdatos.Controls.Add(this.cbsubgrupo);
            this.pdatos.Controls.Add(this.chtratacuenta);
            this.pdatos.Controls.Add(this.bttAñadir);
            this.pdatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pdatos.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pdatos.Location = new System.Drawing.Point(672, 3);
            this.pdatos.Name = "pdatos";
            this.pdatos.Size = new System.Drawing.Size(311, 434);
            this.pdatos.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 20);
            this.label1.TabIndex = 20;
            this.label1.Text = "Empresa";
            // 
            // cbempresa
            // 
            this.cbempresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbempresa.FormattingEnabled = true;
            this.cbempresa.Location = new System.Drawing.Point(3, 55);
            this.cbempresa.Name = "cbempresa";
            this.cbempresa.Size = new System.Drawing.Size(288, 28);
            this.cbempresa.TabIndex = 21;
            // 
            // cbgrupo
            // 
            this.cbgrupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbgrupo.FormattingEnabled = true;
            this.cbgrupo.Location = new System.Drawing.Point(3, 234);
            this.cbgrupo.Name = "cbgrupo";
            this.cbgrupo.Size = new System.Drawing.Size(288, 28);
            this.cbgrupo.TabIndex = 18;
            this.cbgrupo.SelectedIndexChanged += new System.EventHandler(this.cbgrupo_SelectedIndexChanged);
            // 
            // cbsubgrupo
            // 
            this.cbsubgrupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbsubgrupo.FormattingEnabled = true;
            this.cbsubgrupo.Location = new System.Drawing.Point(3, 295);
            this.cbsubgrupo.Name = "cbsubgrupo";
            this.cbsubgrupo.Size = new System.Drawing.Size(288, 28);
            this.cbsubgrupo.TabIndex = 19;
            // 
            // chtratacuenta
            // 
            this.chtratacuenta.AutoSize = true;
            this.chtratacuenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chtratacuenta.Location = new System.Drawing.Point(3, 329);
            this.chtratacuenta.Name = "chtratacuenta";
            this.chtratacuenta.Size = new System.Drawing.Size(126, 24);
            this.chtratacuenta.TabIndex = 24;
            this.chtratacuenta.Text = "Tratar Cuenta";
            this.chtratacuenta.UseVisualStyleBackColor = true;
            this.chtratacuenta.CheckedChanged += new System.EventHandler(this.chtratacuenta_CheckedChanged);
            // 
            // bttAñadir
            // 
            this.bttAñadir.Image = global::GestionConstructora.Properties.Resources.mas;
            this.bttAñadir.Location = new System.Drawing.Point(3, 359);
            this.bttAñadir.Name = "bttAñadir";
            this.bttAñadir.Size = new System.Drawing.Size(45, 39);
            this.bttAñadir.TabIndex = 15;
            this.bttAñadir.UseVisualStyleBackColor = true;
            this.bttAñadir.Click += new System.EventHandler(this.bttAñadir_Click);
            // 
            // pcontenedor
            // 
            this.pcontenedor.ColumnCount = 2;
            this.pcontenedor.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67.95132F));
            this.pcontenedor.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.04868F));
            this.pcontenedor.Controls.Add(this.pbuscar, 0, 1);
            this.pcontenedor.Controls.Add(this.pdatos, 1, 0);
            this.pcontenedor.Controls.Add(this.dgcuentas, 0, 0);
            this.pcontenedor.Controls.Add(this.pbotones, 1, 1);
            this.pcontenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcontenedor.Location = new System.Drawing.Point(0, 0);
            this.pcontenedor.Name = "pcontenedor";
            this.pcontenedor.RowCount = 2;
            this.pcontenedor.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 74.74577F));
            this.pcontenedor.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.25424F));
            this.pcontenedor.Size = new System.Drawing.Size(986, 590);
            this.pcontenedor.TabIndex = 2;
            // 
            // pbuscar
            // 
            this.pbuscar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbuscar.Controls.Add(this.label5);
            this.pbuscar.Controls.Add(this.txtbuscar);
            this.pbuscar.Controls.Add(this.chbuscatrata);
            this.pbuscar.Controls.Add(this.button1);
            this.pbuscar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbuscar.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pbuscar.Location = new System.Drawing.Point(3, 443);
            this.pbuscar.Name = "pbuscar";
            this.pbuscar.Size = new System.Drawing.Size(663, 144);
            this.pbuscar.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(5, 5);
            this.label5.Margin = new System.Windows.Forms.Padding(5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 20);
            this.label5.TabIndex = 21;
            this.label5.Text = "Buscar:";
            // 
            // txtbuscar
            // 
            this.txtbuscar.BackColor = System.Drawing.Color.Snow;
            this.txtbuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbuscar.Location = new System.Drawing.Point(3, 33);
            this.txtbuscar.Name = "txtbuscar";
            this.txtbuscar.Size = new System.Drawing.Size(356, 26);
            this.txtbuscar.TabIndex = 22;
            this.txtbuscar.TextChanged += new System.EventHandler(this.txtbuscar_TextChanged);
            // 
            // chbuscatrata
            // 
            this.chbuscatrata.AutoSize = true;
            this.chbuscatrata.Checked = true;
            this.chbuscatrata.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbuscatrata.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbuscatrata.Location = new System.Drawing.Point(3, 65);
            this.chbuscatrata.Name = "chbuscatrata";
            this.chbuscatrata.Size = new System.Drawing.Size(219, 24);
            this.chbuscatrata.TabIndex = 25;
            this.chbuscatrata.Text = "Solo cuentas que se tratan";
            this.chbuscatrata.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 95);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(114, 25);
            this.button1.TabIndex = 26;
            this.button1.Text = "ACTUALIZAR";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Empresa
            // 
            this.Empresa.DataPropertyName = "Id_Empresa";
            this.Empresa.HeaderText = "Empresa";
            this.Empresa.Name = "Empresa";
            this.Empresa.ReadOnly = true;
            this.Empresa.Visible = false;
            this.Empresa.Width = 80;
            // 
            // Cuentas
            // 
            this.Cuentas.DataPropertyName = "cuenta";
            this.Cuentas.FillWeight = 141.1765F;
            this.Cuentas.HeaderText = "Cuenta";
            this.Cuentas.Name = "Cuentas";
            this.Cuentas.ReadOnly = true;
            this.Cuentas.Width = 120;
            // 
            // Nombre
            // 
            this.Nombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Nombre.DataPropertyName = "nombre";
            this.Nombre.FillWeight = 58.82353F;
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            // 
            // Grupo
            // 
            this.Grupo.DataPropertyName = "Grupos";
            this.Grupo.FillWeight = 250F;
            this.Grupo.HeaderText = "Grupo";
            this.Grupo.Name = "Grupo";
            this.Grupo.ReadOnly = true;
            this.Grupo.Width = 250;
            // 
            // Tratar
            // 
            this.Tratar.DataPropertyName = "tratacuenta";
            this.Tratar.HeaderText = "Tratar";
            this.Tratar.Name = "Tratar";
            this.Tratar.ReadOnly = true;
            this.Tratar.Width = 80;
            // 
            // Form_Cuentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(986, 590);
            this.Controls.Add(this.pcontenedor);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_Cuentas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cuentas";
            this.pbotones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgcuentas)).EndInit();
            this.pdatos.ResumeLayout(false);
            this.pdatos.PerformLayout();
            this.pcontenedor.ResumeLayout(false);
            this.pbuscar.ResumeLayout(false);
            this.pbuscar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btteditar;
        private System.Windows.Forms.Label llegenda;
        private System.Windows.Forms.Label lcuenta;
        private System.Windows.Forms.TextBox txtcuenta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtnombre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button bttnuevo;
        private System.Windows.Forms.FlowLayoutPanel pbotones;
        private System.Windows.Forms.Button bttborrar;
        private System.Windows.Forms.DataGridView dgcuentas;
        private System.Windows.Forms.TableLayoutPanel pcontenedor;
        private System.Windows.Forms.FlowLayoutPanel pdatos;
        private System.Windows.Forms.Button bttAñadir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbempresa;
        private System.Windows.Forms.ComboBox cbgrupo;
        private System.Windows.Forms.ComboBox cbsubgrupo;
        private System.Windows.Forms.CheckBox chtratacuenta;
        private System.Windows.Forms.FlowLayoutPanel pbuscar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtbuscar;
        private System.Windows.Forms.CheckBox chbuscatrata;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Empresa;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cuentas;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Grupo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tratar;
    }
}