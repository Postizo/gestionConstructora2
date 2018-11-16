namespace AutomaticosConstructora
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Label6 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.Panel4 = new System.Windows.Forms.Panel();
            this.bttprimerinicio = new System.Windows.Forms.Button();
            this.lerrores = new System.Windows.Forms.Label();
            this.bttparar = new System.Windows.Forms.Button();
            this.Panel3 = new System.Windows.Forms.Panel();
            this.Lvueltas = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.lproxima = new System.Windows.Forms.Label();
            this.lUltima = new System.Windows.Forms.Label();
            this.ListBox1 = new System.Windows.Forms.ListBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            this.LPrincipal = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.lenviomail = new System.Windows.Forms.Label();
            this.bttcreacionFacturas = new System.Windows.Forms.Button();
            this.lfacturas = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.Panel4.SuspendLayout();
            this.Panel3.SuspendLayout();
            this.Panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
            this.Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label6.ForeColor = System.Drawing.Color.Red;
            this.Label6.Location = new System.Drawing.Point(4, 9);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(73, 13);
            this.Label6.TabIndex = 20;
            this.Label6.Text = "ACTIVIDAD";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.ForeColor = System.Drawing.Color.Red;
            this.Label3.Location = new System.Drawing.Point(4, 109);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(131, 13);
            this.Label3.TabIndex = 19;
            this.Label3.Text = "PANEL DE CONTROL";
            // 
            // Panel4
            // 
            this.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Panel4.Controls.Add(this.bttprimerinicio);
            this.Panel4.Controls.Add(this.lerrores);
            this.Panel4.Controls.Add(this.bttparar);
            this.Panel4.Location = new System.Drawing.Point(7, 126);
            this.Panel4.Name = "Panel4";
            this.Panel4.Size = new System.Drawing.Size(263, 300);
            this.Panel4.TabIndex = 14;
            // 
            // bttprimerinicio
            // 
            this.bttprimerinicio.Location = new System.Drawing.Point(4, 12);
            this.bttprimerinicio.Name = "bttprimerinicio";
            this.bttprimerinicio.Size = new System.Drawing.Size(122, 23);
            this.bttprimerinicio.TabIndex = 13;
            this.bttprimerinicio.Text = "Primer Inicio";
            this.bttprimerinicio.UseVisualStyleBackColor = true;
            this.bttprimerinicio.Click += new System.EventHandler(this.Button2_Click);
            // 
            // lerrores
            // 
            this.lerrores.AutoSize = true;
            this.lerrores.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lerrores.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lerrores.Location = new System.Drawing.Point(1, 277);
            this.lerrores.Name = "lerrores";
            this.lerrores.Size = new System.Drawing.Size(132, 13);
            this.lerrores.TabIndex = 11;
            this.lerrores.Text = "0 Errores en Porcesos";
            // 
            // bttparar
            // 
            this.bttparar.Location = new System.Drawing.Point(3, 41);
            this.bttparar.Name = "bttparar";
            this.bttparar.Size = new System.Drawing.Size(122, 23);
            this.bttparar.TabIndex = 5;
            this.bttparar.Text = "Parar Automatico";
            this.bttparar.UseVisualStyleBackColor = true;
            this.bttparar.Click += new System.EventHandler(this.Button3_Click);
            // 
            // Panel3
            // 
            this.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Panel3.Controls.Add(this.Lvueltas);
            this.Panel3.Controls.Add(this.Label5);
            this.Panel3.Controls.Add(this.Label4);
            this.Panel3.Controls.Add(this.lproxima);
            this.Panel3.Controls.Add(this.lUltima);
            this.Panel3.Controls.Add(this.ListBox1);
            this.Panel3.Location = new System.Drawing.Point(588, 126);
            this.Panel3.Name = "Panel3";
            this.Panel3.Size = new System.Drawing.Size(263, 461);
            this.Panel3.TabIndex = 18;
            // 
            // Lvueltas
            // 
            this.Lvueltas.AutoSize = true;
            this.Lvueltas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lvueltas.ForeColor = System.Drawing.Color.DodgerBlue;
            this.Lvueltas.Location = new System.Drawing.Point(3, 442);
            this.Lvueltas.Name = "Lvueltas";
            this.Lvueltas.Size = new System.Drawing.Size(11, 13);
            this.Lvueltas.TabIndex = 13;
            this.Lvueltas.Text = ".";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label5.ForeColor = System.Drawing.Color.DodgerBlue;
            this.Label5.Location = new System.Drawing.Point(3, 387);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(115, 13);
            this.Label5.TabIndex = 12;
            this.Label5.Text = "Proxima Ejecucion:";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.ForeColor = System.Drawing.Color.DodgerBlue;
            this.Label4.Location = new System.Drawing.Point(3, 364);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(106, 13);
            this.Label4.TabIndex = 11;
            this.Label4.Text = "Ultima Ejecucion:";
            // 
            // lproxima
            // 
            this.lproxima.AutoSize = true;
            this.lproxima.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lproxima.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lproxima.Location = new System.Drawing.Point(126, 387);
            this.lproxima.Name = "lproxima";
            this.lproxima.Size = new System.Drawing.Size(11, 13);
            this.lproxima.TabIndex = 10;
            this.lproxima.Text = ".";
            // 
            // lUltima
            // 
            this.lUltima.AutoSize = true;
            this.lUltima.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lUltima.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lUltima.Location = new System.Drawing.Point(126, 364);
            this.lUltima.Name = "lUltima";
            this.lUltima.Size = new System.Drawing.Size(11, 13);
            this.lUltima.TabIndex = 9;
            this.lUltima.Text = ".";
            // 
            // ListBox1
            // 
            this.ListBox1.BackColor = System.Drawing.SystemColors.Control;
            this.ListBox1.FormattingEnabled = true;
            this.ListBox1.Location = new System.Drawing.Point(3, 8);
            this.ListBox1.Name = "ListBox1";
            this.ListBox1.Size = new System.Drawing.Size(255, 342);
            this.ListBox1.TabIndex = 8;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.ForeColor = System.Drawing.Color.Red;
            this.Label2.Location = new System.Drawing.Point(598, 109);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(166, 13);
            this.Label2.TabIndex = 16;
            this.Label2.Text = "REGISTRO DE ACTIVIDAD ";
            // 
            // Panel2
            // 
            this.Panel2.BackColor = System.Drawing.Color.White;
            this.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Panel2.Controls.Add(this.PictureBox1);
            this.Panel2.Controls.Add(this.LPrincipal);
            this.Panel2.Location = new System.Drawing.Point(7, 25);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(844, 66);
            this.Panel2.TabIndex = 17;
            // 
            // PictureBox1
            // 
            this.PictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.PictureBox1.Image = global::AutomaticosConstructora.Properties.Resources.stop;
            this.PictureBox1.Location = new System.Drawing.Point(114, -1);
            this.PictureBox1.Name = "PictureBox1";
            this.PictureBox1.Size = new System.Drawing.Size(73, 66);
            this.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.PictureBox1.TabIndex = 2;
            this.PictureBox1.TabStop = false;
            // 
            // LPrincipal
            // 
            this.LPrincipal.AutoSize = true;
            this.LPrincipal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LPrincipal.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.LPrincipal.Location = new System.Drawing.Point(0, 18);
            this.LPrincipal.Name = "LPrincipal";
            this.LPrincipal.Size = new System.Drawing.Size(16, 24);
            this.LPrincipal.TabIndex = 1;
            this.LPrincipal.Text = ".";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.Red;
            this.Label1.Location = new System.Drawing.Point(303, 109);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(139, 13);
            this.Label1.TabIndex = 15;
            this.Label1.Text = "PANEL DE PROCESOS";
            // 
            // Panel1
            // 
            this.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Panel1.Controls.Add(this.lenviomail);
            this.Panel1.Controls.Add(this.bttcreacionFacturas);
            this.Panel1.Controls.Add(this.lfacturas);
            this.Panel1.Location = new System.Drawing.Point(299, 126);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(263, 243);
            this.Panel1.TabIndex = 13;
            // 
            // lenviomail
            // 
            this.lenviomail.AutoSize = true;
            this.lenviomail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lenviomail.ForeColor = System.Drawing.Color.Black;
            this.lenviomail.Location = new System.Drawing.Point(3, 219);
            this.lenviomail.Name = "lenviomail";
            this.lenviomail.Size = new System.Drawing.Size(12, 13);
            this.lenviomail.TabIndex = 7;
            this.lenviomail.Text = "*";
            // 
            // bttcreacionFacturas
            // 
            this.bttcreacionFacturas.Enabled = false;
            this.bttcreacionFacturas.Location = new System.Drawing.Point(182, 1);
            this.bttcreacionFacturas.Name = "bttcreacionFacturas";
            this.bttcreacionFacturas.Size = new System.Drawing.Size(75, 23);
            this.bttcreacionFacturas.TabIndex = 0;
            this.bttcreacionFacturas.Text = "START";
            this.bttcreacionFacturas.UseVisualStyleBackColor = true;
            // 
            // lfacturas
            // 
            this.lfacturas.AutoSize = true;
            this.lfacturas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lfacturas.ForeColor = System.Drawing.Color.Black;
            this.lfacturas.Location = new System.Drawing.Point(3, 6);
            this.lfacturas.Name = "lfacturas";
            this.lfacturas.Size = new System.Drawing.Size(121, 13);
            this.lfacturas.TabIndex = 2;
            this.lfacturas.Text = "1- Proceso Principal";
            // 
            // timer1
            // 
            this.timer1.Interval = 86400000;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.Timer2_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 600);
            this.Controls.Add(this.Label6);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.Panel4);
            this.Controls.Add(this.Panel3);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Panel2);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.Panel1);
            this.Name = "Form1";
            this.Text = "AUTOMATICOS CONSTRUCTORA";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Panel4.ResumeLayout(false);
            this.Panel4.PerformLayout();
            this.Panel3.ResumeLayout(false);
            this.Panel3.PerformLayout();
            this.Panel2.ResumeLayout(false);
            this.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Panel Panel4;
        internal System.Windows.Forms.Button bttprimerinicio;
        internal System.Windows.Forms.Label lerrores;
        internal System.Windows.Forms.Button bttparar;
        internal System.Windows.Forms.Panel Panel3;
        internal System.Windows.Forms.Label Lvueltas;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label lproxima;
        internal System.Windows.Forms.Label lUltima;
        internal System.Windows.Forms.ListBox ListBox1;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Panel Panel2;
        internal System.Windows.Forms.PictureBox PictureBox1;
        internal System.Windows.Forms.Label LPrincipal;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.Label lenviomail;
        internal System.Windows.Forms.Button bttcreacionFacturas;
        internal System.Windows.Forms.Label lfacturas;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
    }
}

