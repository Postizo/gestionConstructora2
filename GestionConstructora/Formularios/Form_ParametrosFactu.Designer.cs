namespace GestionConstructora
{
    partial class Form_ParametrosFactu
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.cbempresa = new System.Windows.Forms.ComboBox();
            this.lvencimiento = new System.Windows.Forms.Label();
            this.fvencimiento = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.cbformapago = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Factura en:";
            // 
            // cbempresa
            // 
            this.cbempresa.BackColor = System.Drawing.Color.Ivory;
            this.cbempresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbempresa.FormattingEnabled = true;
            this.cbempresa.Location = new System.Drawing.Point(12, 32);
            this.cbempresa.Name = "cbempresa";
            this.cbempresa.Size = new System.Drawing.Size(246, 24);
            this.cbempresa.TabIndex = 22;
            this.cbempresa.Text = "1";
            this.cbempresa.SelectionChangeCommitted += new System.EventHandler(this.cbempresa_SelectionChangeCommitted);
            // 
            // lvencimiento
            // 
            this.lvencimiento.AutoSize = true;
            this.lvencimiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvencimiento.Location = new System.Drawing.Point(9, 122);
            this.lvencimiento.Name = "lvencimiento";
            this.lvencimiento.Size = new System.Drawing.Size(150, 17);
            this.lvencimiento.TabIndex = 23;
            this.lvencimiento.Text = "Fecha Vencimiento:";
            this.lvencimiento.Visible = false;
            // 
            // fvencimiento
            // 
            this.fvencimiento.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fvencimiento.Location = new System.Drawing.Point(12, 146);
            this.fvencimiento.Name = "fvencimiento";
            this.fvencimiento.Size = new System.Drawing.Size(246, 20);
            this.fvencimiento.TabIndex = 24;
            this.fvencimiento.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 17);
            this.label3.TabIndex = 25;
            this.label3.Text = "Forma de Pago:";
            // 
            // cbformapago
            // 
            this.cbformapago.BackColor = System.Drawing.Color.Ivory;
            this.cbformapago.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbformapago.FormattingEnabled = true;
            this.cbformapago.Items.AddRange(new object[] {
            "Transferencia/Cheque",
            "Pagare 60 Dias\t"});
            this.cbformapago.Location = new System.Drawing.Point(12, 87);
            this.cbformapago.Name = "cbformapago";
            this.cbformapago.Size = new System.Drawing.Size(246, 24);
            this.cbformapago.TabIndex = 26;
            this.cbformapago.SelectedIndexChanged += new System.EventHandler(this.cbformapago_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 172);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(244, 32);
            this.button1.TabIndex = 27;
            this.button1.Text = "CONTABILIZAR";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // Form_ParametrosFactu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Honeydew;
            this.ClientSize = new System.Drawing.Size(272, 222);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cbformapago);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.fvencimiento);
            this.Controls.Add(this.lvencimiento);
            this.Controls.Add(this.cbempresa);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_ParametrosFactu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Parametros Factura";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_ParametrosFactu_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbempresa;
        private System.Windows.Forms.Label lvencimiento;
        private System.Windows.Forms.DateTimePicker fvencimiento;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbformapago;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}