<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PrintOptions
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PrintOptions))
        Me.chklst = New System.Windows.Forms.CheckedListBox()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.lblColumnsToPrint = New System.Windows.Forms.Label()
        Me.gboxRowsToPrint = New System.Windows.Forms.GroupBox()
        Me.rdoSelectedRows = New System.Windows.Forms.RadioButton()
        Me.rdoAllRows = New System.Windows.Forms.RadioButton()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.txtTitle = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Chcabecera = New System.Windows.Forms.CheckBox()
        Me.chkFitToPageWidth = New System.Windows.Forms.CheckBox()
        Me.gboxRowsToPrint.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'chklst
        '
        Me.chklst.CheckOnClick = True
        Me.chklst.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chklst.FormattingEnabled = True
        Me.chklst.Location = New System.Drawing.Point(8, 28)
        Me.chklst.Name = "chklst"
        Me.chklst.Size = New System.Drawing.Size(170, 244)
        Me.chklst.TabIndex = 0
        '
        'btnOK
        '
        Me.btnOK.BackColor = System.Drawing.SystemColors.Control
        Me.btnOK.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnOK.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.btnOK.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnOK.Image = CType(resources.GetObject("btnOK.Image"), System.Drawing.Image)
        Me.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnOK.Location = New System.Drawing.Point(184, 247)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnOK.Size = New System.Drawing.Size(56, 25)
        Me.btnOK.TabIndex = 4
        Me.btnOK.Text = "&OK"
        Me.btnOK.UseVisualStyleBackColor = False
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.SystemColors.Control
        Me.btnCancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnCancel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.btnCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnCancel.Image = CType(resources.GetObject("btnCancel.Image"), System.Drawing.Image)
        Me.btnCancel.Location = New System.Drawing.Point(307, 247)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnCancel.Size = New System.Drawing.Size(56, 25)
        Me.btnCancel.TabIndex = 5
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'lblColumnsToPrint
        '
        Me.lblColumnsToPrint.AutoSize = True
        Me.lblColumnsToPrint.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColumnsToPrint.Location = New System.Drawing.Point(8, 9)
        Me.lblColumnsToPrint.Name = "lblColumnsToPrint"
        Me.lblColumnsToPrint.Size = New System.Drawing.Size(137, 13)
        Me.lblColumnsToPrint.TabIndex = 7
        Me.lblColumnsToPrint.Text = "Columnas para Imprimir"
        '
        'gboxRowsToPrint
        '
        Me.gboxRowsToPrint.Controls.Add(Me.rdoSelectedRows)
        Me.gboxRowsToPrint.Controls.Add(Me.rdoAllRows)
        Me.gboxRowsToPrint.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gboxRowsToPrint.Location = New System.Drawing.Point(184, 22)
        Me.gboxRowsToPrint.Name = "gboxRowsToPrint"
        Me.gboxRowsToPrint.Size = New System.Drawing.Size(202, 42)
        Me.gboxRowsToPrint.TabIndex = 8
        Me.gboxRowsToPrint.TabStop = False
        Me.gboxRowsToPrint.Text = "Filas para Imprimir"
        '
        'rdoSelectedRows
        '
        Me.rdoSelectedRows.AutoSize = True
        Me.rdoSelectedRows.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdoSelectedRows.Location = New System.Drawing.Point(91, 19)
        Me.rdoSelectedRows.Name = "rdoSelectedRows"
        Me.rdoSelectedRows.Size = New System.Drawing.Size(108, 17)
        Me.rdoSelectedRows.TabIndex = 1
        Me.rdoSelectedRows.TabStop = True
        Me.rdoSelectedRows.Text = "Seleccionadas"
        Me.rdoSelectedRows.UseVisualStyleBackColor = True
        '
        'rdoAllRows
        '
        Me.rdoAllRows.AutoSize = True
        Me.rdoAllRows.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdoAllRows.Location = New System.Drawing.Point(9, 19)
        Me.rdoAllRows.Name = "rdoAllRows"
        Me.rdoAllRows.Size = New System.Drawing.Size(60, 17)
        Me.rdoAllRows.TabIndex = 0
        Me.rdoAllRows.TabStop = True
        Me.rdoAllRows.Text = "Todas"
        Me.rdoAllRows.UseVisualStyleBackColor = True
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.Location = New System.Drawing.Point(187, 147)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(106, 13)
        Me.lblTitle.TabIndex = 15
        Me.lblTitle.Text = "Titulo del Informe"
        '
        'txtTitle
        '
        Me.txtTitle.AcceptsReturn = True
        Me.txtTitle.Location = New System.Drawing.Point(187, 164)
        Me.txtTitle.Multiline = True
        Me.txtTitle.Name = "txtTitle"
        Me.txtTitle.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtTitle.Size = New System.Drawing.Size(176, 77)
        Me.txtTitle.TabIndex = 14
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Chcabecera)
        Me.GroupBox1.Controls.Add(Me.chkFitToPageWidth)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(184, 70)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(202, 74)
        Me.GroupBox1.TabIndex = 16
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Opciones"
        '
        'Chcabecera
        '
        Me.Chcabecera.AutoSize = True
        Me.Chcabecera.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Chcabecera.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Chcabecera.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Chcabecera.Location = New System.Drawing.Point(9, 52)
        Me.Chcabecera.Name = "Chcabecera"
        Me.Chcabecera.Size = New System.Drawing.Size(86, 18)
        Me.Chcabecera.TabIndex = 15
        Me.Chcabecera.Text = "Cabecera"
        Me.Chcabecera.UseVisualStyleBackColor = True
        '
        'chkFitToPageWidth
        '
        Me.chkFitToPageWidth.AutoSize = True
        Me.chkFitToPageWidth.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkFitToPageWidth.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.chkFitToPageWidth.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkFitToPageWidth.Location = New System.Drawing.Point(9, 28)
        Me.chkFitToPageWidth.Name = "chkFitToPageWidth"
        Me.chkFitToPageWidth.Size = New System.Drawing.Size(129, 18)
        Me.chkFitToPageWidth.TabIndex = 14
        Me.chkFitToPageWidth.Text = "Ajustar Columnas"
        Me.chkFitToPageWidth.UseVisualStyleBackColor = True
        '
        'PrintOptions
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(400, 308)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.txtTitle)
        Me.Controls.Add(Me.gboxRowsToPrint)
        Me.Controls.Add(Me.lblColumnsToPrint)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.chklst)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "PrintOptions"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Opciones de Impresion"
        Me.gboxRowsToPrint.ResumeLayout(False)
        Me.gboxRowsToPrint.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents chklst As System.Windows.Forms.CheckedListBox
    Protected WithEvents btnOK As System.Windows.Forms.Button
    Protected WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents lblColumnsToPrint As System.Windows.Forms.Label
    Friend WithEvents gboxRowsToPrint As System.Windows.Forms.GroupBox
    Friend WithEvents rdoAllRows As System.Windows.Forms.RadioButton
    Friend WithEvents rdoSelectedRows As System.Windows.Forms.RadioButton
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents txtTitle As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Chcabecera As System.Windows.Forms.CheckBox
    Friend WithEvents chkFitToPageWidth As System.Windows.Forms.CheckBox
End Class
