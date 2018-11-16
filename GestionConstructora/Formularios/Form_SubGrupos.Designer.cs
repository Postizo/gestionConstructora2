namespace GestionConstructora
{
    partial class Form_SubGrupos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_SubGrupos));
            this.pdatos = new System.Windows.Forms.FlowLayoutPanel();
            this.bttnuevo = new System.Windows.Forms.Button();
            this.btteditar = new System.Windows.Forms.Button();
            this.bttborrar = new System.Windows.Forms.Button();
            this.pbotones = new System.Windows.Forms.FlowLayoutPanel();
            this.pcontenedor = new System.Windows.Forms.TableLayoutPanel();
            this.dgsubgrupos = new System.Windows.Forms.DataGridView();
            this.Id_Subgrupo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Grupos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pbotones.SuspendLayout();
            this.pcontenedor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgsubgrupos)).BeginInit();
            this.SuspendLayout();
            // 
            // pdatos
            // 
            this.pdatos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pdatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pdatos.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pdatos.Location = new System.Drawing.Point(332, 3);
            this.pdatos.Name = "pdatos";
            this.pdatos.Size = new System.Drawing.Size(324, 502);
            this.pdatos.TabIndex = 0;
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
            // pbotones
            // 
            this.pbotones.Controls.Add(this.bttnuevo);
            this.pbotones.Controls.Add(this.btteditar);
            this.pbotones.Controls.Add(this.bttborrar);
            this.pbotones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pbotones.Location = new System.Drawing.Point(332, 551);
            this.pbotones.Name = "pbotones";
            this.pbotones.Size = new System.Drawing.Size(324, 82);
            this.pbotones.TabIndex = 2;
            // 
            // pcontenedor
            // 
            this.pcontenedor.ColumnCount = 2;
            this.pcontenedor.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pcontenedor.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pcontenedor.Controls.Add(this.dgsubgrupos, 0, 0);
            this.pcontenedor.Controls.Add(this.pdatos, 1, 0);
            this.pcontenedor.Controls.Add(this.pbotones, 1, 1);
            this.pcontenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcontenedor.Location = new System.Drawing.Point(0, 0);
            this.pcontenedor.Name = "pcontenedor";
            this.pcontenedor.RowCount = 2;
            this.pcontenedor.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.pcontenedor.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.pcontenedor.Size = new System.Drawing.Size(659, 636);
            this.pcontenedor.TabIndex = 3;
            // 
            // dgsubgrupos
            // 
            this.dgsubgrupos.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgsubgrupos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgsubgrupos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgsubgrupos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id_Subgrupo,
            this.Nombre,
            this.Grupos});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.MintCream;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgsubgrupos.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgsubgrupos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgsubgrupos.Location = new System.Drawing.Point(3, 3);
            this.dgsubgrupos.Name = "dgsubgrupos";
            this.dgsubgrupos.ReadOnly = true;
            this.dgsubgrupos.RowHeadersVisible = false;
            this.dgsubgrupos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgsubgrupos.Size = new System.Drawing.Size(323, 502);
            this.dgsubgrupos.TabIndex = 3;
            this.dgsubgrupos.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgsubgrupos_ColumnHeaderMouseClick);
            this.dgsubgrupos.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgempresas_RowEnter);
            // 
            // Id_Subgrupo
            // 
            this.Id_Subgrupo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Id_Subgrupo.DataPropertyName = "Id_Subgrupo";
            this.Id_Subgrupo.HeaderText = "Id_Subgrupo";
            this.Id_Subgrupo.Name = "Id_Subgrupo";
            this.Id_Subgrupo.ReadOnly = true;
            this.Id_Subgrupo.Visible = false;
            // 
            // Nombre
            // 
            this.Nombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Nombre.DataPropertyName = "Nombre";
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            // 
            // Grupos
            // 
            this.Grupos.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Grupos.DataPropertyName = "Grupos";
            this.Grupos.HeaderText = "Grupo";
            this.Grupos.Name = "Grupos";
            this.Grupos.ReadOnly = true;
            // 
            // Form_SubGrupos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 636);
            this.Controls.Add(this.pcontenedor);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_SubGrupos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SubGrupos";
            this.pbotones.ResumeLayout(false);
            this.pcontenedor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgsubgrupos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel pdatos;
        private System.Windows.Forms.Button bttnuevo;
        private System.Windows.Forms.Button btteditar;
        private System.Windows.Forms.TableLayoutPanel pcontenedor;
        private System.Windows.Forms.FlowLayoutPanel pbotones;
        private System.Windows.Forms.Button bttborrar;
        private System.Windows.Forms.DataGridView dgsubgrupos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id_Subgrupo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Grupos;
    }
}