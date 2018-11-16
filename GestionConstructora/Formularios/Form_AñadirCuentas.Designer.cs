namespace GestionConstructora
{
    partial class Form_AñadirCuentas
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
            this.pdatos = new System.Windows.Forms.FlowLayoutPanel();
            this.llegenda = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbempresa = new System.Windows.Forms.ComboBox();
            this.lcuenta = new System.Windows.Forms.Label();
            this.txtcuenta = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtnombre = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbgrupo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbsubgrupo = new System.Windows.Forms.ComboBox();
            this.chtratacuenta = new System.Windows.Forms.CheckBox();
            this.bttAñadir = new System.Windows.Forms.Button();
            this.pdatos.SuspendLayout();
            this.SuspendLayout();
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
            this.pdatos.Location = new System.Drawing.Point(0, 0);
            this.pdatos.Name = "pdatos";
            this.pdatos.Size = new System.Drawing.Size(381, 517);
            this.pdatos.TabIndex = 1;
            // 
            // llegenda
            // 
            this.llegenda.AutoSize = true;
            this.llegenda.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.llegenda.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llegenda.Location = new System.Drawing.Point(3, 0);
            this.llegenda.Name = "llegenda";
            this.llegenda.Padding = new System.Windows.Forms.Padding(2, 10, 2, 2);
            this.llegenda.Size = new System.Drawing.Size(356, 32);
            this.llegenda.TabIndex = 1;
            this.llegenda.Text = "Nombre";
            this.llegenda.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.cbempresa.BackColor = System.Drawing.Color.AliceBlue;
            this.cbempresa.Enabled = false;
            this.cbempresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbempresa.FormattingEnabled = true;
            this.cbempresa.Location = new System.Drawing.Point(3, 55);
            this.cbempresa.Name = "cbempresa";
            this.cbempresa.Size = new System.Drawing.Size(356, 28);
            this.cbempresa.TabIndex = 21;
            this.cbempresa.Text = "1";
            // 
            // lcuenta
            // 
            this.lcuenta.AutoSize = true;
            this.lcuenta.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lcuenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lcuenta.Location = new System.Drawing.Point(3, 86);
            this.lcuenta.Name = "lcuenta";
            this.lcuenta.Padding = new System.Windows.Forms.Padding(2, 5, 2, 2);
            this.lcuenta.Size = new System.Drawing.Size(356, 27);
            this.lcuenta.TabIndex = 3;
            this.lcuenta.Text = "Cuenta";
            // 
            // txtcuenta
            // 
            this.txtcuenta.BackColor = System.Drawing.Color.AliceBlue;
            this.txtcuenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcuenta.Location = new System.Drawing.Point(3, 116);
            this.txtcuenta.Name = "txtcuenta";
            this.txtcuenta.ReadOnly = true;
            this.txtcuenta.Size = new System.Drawing.Size(356, 26);
            this.txtcuenta.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 145);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(2, 5, 2, 2);
            this.label2.Size = new System.Drawing.Size(356, 27);
            this.label2.TabIndex = 7;
            this.label2.Text = "Nombre";
            // 
            // txtnombre
            // 
            this.txtnombre.BackColor = System.Drawing.Color.Ivory;
            this.txtnombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtnombre.Location = new System.Drawing.Point(3, 175);
            this.txtnombre.Name = "txtnombre";
            this.txtnombre.Size = new System.Drawing.Size(356, 20);
            this.txtnombre.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 198);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(2, 5, 2, 2);
            this.label3.Size = new System.Drawing.Size(356, 27);
            this.label3.TabIndex = 12;
            this.label3.Text = "Grupo";
            // 
            // cbgrupo
            // 
            this.cbgrupo.BackColor = System.Drawing.Color.Ivory;
            this.cbgrupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbgrupo.FormattingEnabled = true;
            this.cbgrupo.Location = new System.Drawing.Point(3, 228);
            this.cbgrupo.Name = "cbgrupo";
            this.cbgrupo.Size = new System.Drawing.Size(356, 28);
            this.cbgrupo.TabIndex = 5;
            this.cbgrupo.SelectedIndexChanged += new System.EventHandler(this.cbgrupo_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 259);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(2, 5, 2, 2);
            this.label4.Size = new System.Drawing.Size(356, 27);
            this.label4.TabIndex = 13;
            this.label4.Text = "Subgrupo";
            // 
            // cbsubgrupo
            // 
            this.cbsubgrupo.BackColor = System.Drawing.Color.Ivory;
            this.cbsubgrupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbsubgrupo.FormattingEnabled = true;
            this.cbsubgrupo.Location = new System.Drawing.Point(3, 289);
            this.cbsubgrupo.Name = "cbsubgrupo";
            this.cbsubgrupo.Size = new System.Drawing.Size(356, 28);
            this.cbsubgrupo.TabIndex = 6;
            // 
            // chtratacuenta
            // 
            this.chtratacuenta.AutoSize = true;
            this.chtratacuenta.Enabled = false;
            this.chtratacuenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chtratacuenta.Location = new System.Drawing.Point(3, 323);
            this.chtratacuenta.Name = "chtratacuenta";
            this.chtratacuenta.Size = new System.Drawing.Size(126, 24);
            this.chtratacuenta.TabIndex = 7;
            this.chtratacuenta.Text = "Tratar Cuenta";
            this.chtratacuenta.UseVisualStyleBackColor = true;
            // 
            // bttAñadir
            // 
            this.bttAñadir.Image = global::GestionConstructora.Properties.Resources.mas;
            this.bttAñadir.Location = new System.Drawing.Point(3, 353);
            this.bttAñadir.Name = "bttAñadir";
            this.bttAñadir.Size = new System.Drawing.Size(75, 75);
            this.bttAñadir.TabIndex = 8;
            this.bttAñadir.UseVisualStyleBackColor = true;
            this.bttAñadir.Click += new System.EventHandler(this.bttAñadir_Click);
            // 
            // Form_AñadirCuentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.ClientSize = new System.Drawing.Size(381, 517);
            this.Controls.Add(this.pdatos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_AñadirCuentas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Añadir Cuenta";
            this.pdatos.ResumeLayout(false);
            this.pdatos.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel pdatos;
        private System.Windows.Forms.Label llegenda;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbempresa;
        private System.Windows.Forms.Label lcuenta;
        private System.Windows.Forms.TextBox txtcuenta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtnombre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbgrupo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbsubgrupo;
        private System.Windows.Forms.CheckBox chtratacuenta;
        private System.Windows.Forms.Button bttAñadir;
    }
}