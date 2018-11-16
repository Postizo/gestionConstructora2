namespace GestionConstructora
{
    partial class Form_ComparaObras
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_ComparaObras));
            this.pgeneral = new System.Windows.Forms.TableLayoutPanel();
            this.pizquierda = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.rbpresupuesto = new System.Windows.Forms.RadioButton();
            this.rbcostereal = new System.Windows.Forms.RadioButton();
            this.rbcertificado = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.listObras = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pderecha = new System.Windows.Forms.TableLayoutPanel();
            this.treemetros = new Ai.Control.MultiColumnTree();
            this.ltitulo = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbescriturados = new System.Windows.Forms.RadioButton();
            this.rbconstruidos = new System.Windows.Forms.RadioButton();
            this.rbutiles = new System.Windows.Forms.RadioButton();
            this.pgeneral.SuspendLayout();
            this.pizquierda.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.pderecha.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
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
            this.pgeneral.Size = new System.Drawing.Size(1052, 610);
            this.pgeneral.TabIndex = 0;
            // 
            // pizquierda
            // 
            this.pizquierda.BackColor = System.Drawing.SystemColors.Control;
            this.pizquierda.ColumnCount = 1;
            this.pizquierda.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pizquierda.Controls.Add(this.flowLayoutPanel1, 0, 3);
            this.pizquierda.Controls.Add(this.button1, 0, 2);
            this.pizquierda.Controls.Add(this.listObras, 0, 1);
            this.pizquierda.Controls.Add(this.label2, 0, 0);
            this.pizquierda.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pizquierda.Location = new System.Drawing.Point(3, 3);
            this.pizquierda.Name = "pizquierda";
            this.pizquierda.RowCount = 4;
            this.pizquierda.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7F));
            this.pizquierda.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 54.4702F));
            this.pizquierda.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.788079F));
            this.pizquierda.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 31.95364F));
            this.pizquierda.Size = new System.Drawing.Size(194, 604);
            this.pizquierda.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.GhostWhite;
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.Controls.Add(this.rbpresupuesto);
            this.flowLayoutPanel1.Controls.Add(this.rbcostereal);
            this.flowLayoutPanel1.Controls.Add(this.rbcertificado);
            this.flowLayoutPanel1.Controls.Add(this.groupBox1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 413);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(188, 188);
            this.flowLayoutPanel1.TabIndex = 9;
            // 
            // rbpresupuesto
            // 
            this.rbpresupuesto.AutoSize = true;
            this.rbpresupuesto.Checked = true;
            this.rbpresupuesto.Location = new System.Drawing.Point(3, 3);
            this.rbpresupuesto.Name = "rbpresupuesto";
            this.rbpresupuesto.Size = new System.Drawing.Size(84, 17);
            this.rbpresupuesto.TabIndex = 0;
            this.rbpresupuesto.TabStop = true;
            this.rbpresupuesto.Text = "Presupuesto";
            this.rbpresupuesto.UseVisualStyleBackColor = true;
            this.rbpresupuesto.CheckedChanged += new System.EventHandler(this.rbpresupuesto_CheckedChanged);
            // 
            // rbcostereal
            // 
            this.rbcostereal.AutoSize = true;
            this.rbcostereal.Location = new System.Drawing.Point(3, 26);
            this.rbcostereal.Name = "rbcostereal";
            this.rbcostereal.Size = new System.Drawing.Size(77, 17);
            this.rbcostereal.TabIndex = 1;
            this.rbcostereal.Text = "Coste Real";
            this.rbcostereal.UseVisualStyleBackColor = true;
            this.rbcostereal.CheckedChanged += new System.EventHandler(this.rbpresupuesto_CheckedChanged);
            // 
            // rbcertificado
            // 
            this.rbcertificado.AutoSize = true;
            this.rbcertificado.Location = new System.Drawing.Point(3, 49);
            this.rbcertificado.Name = "rbcertificado";
            this.rbcertificado.Size = new System.Drawing.Size(75, 17);
            this.rbcertificado.TabIndex = 2;
            this.rbcertificado.Text = "Certificado";
            this.rbcertificado.UseVisualStyleBackColor = true;
            this.rbcertificado.CheckedChanged += new System.EventHandler(this.rbpresupuesto_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Location = new System.Drawing.Point(3, 373);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(188, 34);
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
            this.listObras.Location = new System.Drawing.Point(3, 45);
            this.listObras.Name = "listObras";
            this.listObras.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listObras.Size = new System.Drawing.Size(188, 322);
            this.listObras.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(188, 42);
            this.label2.TabIndex = 2;
            this.label2.Text = "OBRAS";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pderecha
            // 
            this.pderecha.ColumnCount = 1;
            this.pderecha.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pderecha.Controls.Add(this.treemetros, 0, 1);
            this.pderecha.Controls.Add(this.ltitulo, 0, 0);
            this.pderecha.Controls.Add(this.tableLayoutPanel2, 0, 2);
            this.pderecha.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pderecha.Location = new System.Drawing.Point(203, 3);
            this.pderecha.Name = "pderecha";
            this.pderecha.RowCount = 3;
            this.pderecha.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.pderecha.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.pderecha.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.pderecha.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.pderecha.Size = new System.Drawing.Size(846, 604);
            this.pderecha.TabIndex = 1;
            // 
            // treemetros
            // 
            this.treemetros.Culture = new System.Globalization.CultureInfo("es-ES");
            this.treemetros.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treemetros.Indent = -1;
            this.treemetros.Location = new System.Drawing.Point(0, 30);
            this.treemetros.Margin = new System.Windows.Forms.Padding(0);
            this.treemetros.Name = "treemetros";
            this.treemetros.Padding = new System.Windows.Forms.Padding(1);
            this.treemetros.SelectedNode = null;
            this.treemetros.Size = new System.Drawing.Size(846, 543);
            this.treemetros.TabIndex = 19;
            // 
            // ltitulo
            // 
            this.ltitulo.AutoSize = true;
            this.ltitulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ltitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ltitulo.Location = new System.Drawing.Point(3, 0);
            this.ltitulo.Name = "ltitulo";
            this.ltitulo.Size = new System.Drawing.Size(840, 30);
            this.ltitulo.TabIndex = 2;
            this.ltitulo.Text = "label5";
            this.ltitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 576);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(840, 25);
            this.tableLayoutPanel2.TabIndex = 15;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            this.imageList1.Images.SetKeyName(2, "");
            this.imageList1.Images.SetKeyName(3, "");
            this.imageList1.Images.SetKeyName(4, "carpeta(8).png");
            this.imageList1.Images.SetKeyName(5, "carpeta(10).png");
            this.imageList1.Images.SetKeyName(6, "d.png");
            this.imageList1.Images.SetKeyName(7, "carpeta_morada.png");
            this.imageList1.Images.SetKeyName(8, "carpeta_rojo.png");
            this.imageList1.Images.SetKeyName(9, "recibir(1).png");
            this.imageList1.Images.SetKeyName(10, "recibir.png");
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbescriturados);
            this.groupBox1.Controls.Add(this.rbconstruidos);
            this.groupBox1.Controls.Add(this.rbutiles);
            this.groupBox1.Location = new System.Drawing.Point(3, 72);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(184, 109);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // rbescriturados
            // 
            this.rbescriturados.AutoSize = true;
            this.rbescriturados.Checked = true;
            this.rbescriturados.Location = new System.Drawing.Point(2, 19);
            this.rbescriturados.Name = "rbescriturados";
            this.rbescriturados.Size = new System.Drawing.Size(83, 17);
            this.rbescriturados.TabIndex = 3;
            this.rbescriturados.TabStop = true;
            this.rbescriturados.Text = "Escriturados";
            this.rbescriturados.UseVisualStyleBackColor = true;
            this.rbescriturados.CheckedChanged += new System.EventHandler(this.rbpresupuesto_CheckedChanged);
            // 
            // rbconstruidos
            // 
            this.rbconstruidos.AutoSize = true;
            this.rbconstruidos.Location = new System.Drawing.Point(2, 42);
            this.rbconstruidos.Name = "rbconstruidos";
            this.rbconstruidos.Size = new System.Drawing.Size(80, 17);
            this.rbconstruidos.TabIndex = 4;
            this.rbconstruidos.Text = "Construidos";
            this.rbconstruidos.UseVisualStyleBackColor = true;
            this.rbconstruidos.CheckedChanged += new System.EventHandler(this.rbpresupuesto_CheckedChanged);
            // 
            // rbutiles
            // 
            this.rbutiles.AutoSize = true;
            this.rbutiles.Location = new System.Drawing.Point(2, 65);
            this.rbutiles.Name = "rbutiles";
            this.rbutiles.Size = new System.Drawing.Size(51, 17);
            this.rbutiles.TabIndex = 5;
            this.rbutiles.Text = "Utiles";
            this.rbutiles.UseVisualStyleBackColor = true;
            this.rbutiles.CheckedChanged += new System.EventHandler(this.rbpresupuesto_CheckedChanged);
            // 
            // Form_ComparaObras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1052, 610);
            this.Controls.Add(this.pgeneral);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_ComparaObras";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Comparacion de Obras";
            this.pgeneral.ResumeLayout(false);
            this.pizquierda.ResumeLayout(false);
            this.pizquierda.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.pderecha.ResumeLayout(false);
            this.pderecha.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel pgeneral;
        private System.Windows.Forms.TableLayoutPanel pizquierda;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listObras;
        private System.Windows.Forms.TableLayoutPanel pderecha;
        private System.Windows.Forms.Label ltitulo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.ImageList imageList1;
        private Ai.Control.MultiColumnTree treemetros;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.RadioButton rbpresupuesto;
        private System.Windows.Forms.RadioButton rbcostereal;
        private System.Windows.Forms.RadioButton rbcertificado;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbescriturados;
        private System.Windows.Forms.RadioButton rbconstruidos;
        private System.Windows.Forms.RadioButton rbutiles;
    }
}