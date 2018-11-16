Imports System.Collections.Generic
Imports System.Windows

Public Class PrintOptions
    Public Sub New(ByVal availableFields As List(Of String), ByVal Titulo As String, AjustarColumnas As Boolean, Cabeceras As Boolean)
        InitializeComponent()
        For Each field As String In availableFields
            chklst.Items.Add(field, True)
        Next
        txtTitle.Text = Titulo
        chkFitToPageWidth.Checked = AjustarColumnas
        Chcabecera.Checked = Cabeceras
    End Sub

    Private Sub PrintOptions_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Initialize some controls
        rdoAllRows.Checked = True
        chkFitToPageWidth.Checked = True
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Me.DialogResult = Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Public Function GetSelectedColumns() As List(Of String)
        Dim lst As New List(Of String)
        For Each item As Object In chklst.CheckedItems
            lst.Add(item.ToString)
        Next
        Return lst
    End Function

    Public ReadOnly Property PrintTitle() As String
        Get
            Return txtTitle.Text
        End Get
    End Property

    Public ReadOnly Property PrintAllRows() As Boolean
        Get
            Return rdoAllRows.Checked
        End Get
    End Property

    Public ReadOnly Property FitToPageWidth() As Boolean
        Get
            Return chkFitToPageWidth.Checked
        End Get
    End Property
    Public ReadOnly Property Cabeceraenpagina() As Boolean
        Get
            Return Chcabecera.Checked
        End Get
    End Property


End Class