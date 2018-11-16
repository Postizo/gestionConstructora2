namespace GestionConstructora
{
    partial class Form_AjusteGasto
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txctimporte = new System.Windows.Forms.TextBox();
            this.txtcomentario = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Importe";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Comntarios";
            // 
            // txctimporte
            // 
            this.txctimporte.BackColor = System.Drawing.Color.Ivory;
            this.txctimporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txctimporte.Location = new System.Drawing.Point(12, 30);
            this.txctimporte.Name = "txctimporte";
            this.txctimporte.Size = new System.Drawing.Size(100, 20);
            this.txctimporte.TabIndex = 21;
            this.txctimporte.Text = "0";
            this.txctimporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txctimporte.Enter += new System.EventHandler(this.entrada);
            this.txctimporte.Leave += new System.EventHandler(this.salida);
            // 
            // txtcomentario
            // 
            this.txtcomentario.BackColor = System.Drawing.Color.Ivory;
            this.txtcomentario.Location = new System.Drawing.Point(12, 84);
            this.txtcomentario.Name = "txtcomentario";
            this.txtcomentario.Size = new System.Drawing.Size(350, 209);
            this.txtcomentario.TabIndex = 22;
            this.txtcomentario.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(238, 299);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(125, 29);
            this.button1.TabIndex = 23;
            this.button1.Text = "GUARDAR";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form_AjusteGasto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 336);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtcomentario);
            this.Controls.Add(this.txctimporte);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_AjusteGasto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_AjusteGasto";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txctimporte;
        private System.Windows.Forms.RichTextBox txtcomentario;
        private System.Windows.Forms.Button button1;
    }
}