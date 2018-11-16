Imports System.Collections.Generic
Imports System.Drawing
Imports System.Windows.Forms

Public Class M_PrintTREE
    Private Shared StrFormat As StringFormat         ' Holds content of a TextBox Cell to write by DrawString
    Private Shared StrFormatComboBox As StringFormat ' Holds content of a Boolean Cell to write by DrawImage
    Private Shared CellButton As Button          ' Holds the Contents of Button Cell
    Private Shared CellCheckBox As CheckBox      ' Holds the Contents of CheckBox Cell
    Private Shared CellComboBox As ComboBox      ' Holds the Contents of ComboBox Cell

    Private Shared TotalWidth As Int16           ' Summation of Columns widths
    Private Shared NodePos As Int16               ' Position of currently printing row 
    Private Shared NewPage As Boolean            ' Indicates if a new page reached 
    Private Shared PageNo As Int16               ' Number of pages to print 
    Private Shared ColumnLefts As New ArrayList  ' Left Coordinate of Columns
    Private Shared ColumnWidths As New ArrayList ' Width of Columns
    Private Shared ColumnTypes As New ArrayList  ' DataType of Columns
    Private Shared CellHeight As Int16           ' Height of DataGrid Cell
    Private Shared RowsPerPage As Int16          ' Number of Rows per Page 
    Private Shared WithEvents PrintDoc As New System.Drawing.Printing.PrintDocument ' PrintDocumnet Object used for printing

    Private Shared PrintTitle As String = ""               ' Header of pages
    Private Shared dgv As Ai.Control.MultiColumnTree                     ' Holds DataGrid Object to print its contents
    Private Shared SelectedColumns As New List(Of String)  ' The Columns Selected by user to print.
    Private Shared AvailableColumns As New List(Of String) ' All Columns avaiable in DataGrid   
    Private Shared PrintAllRows As Boolean = True          ' True = print all rows,  False = print selected rows    
    Private Shared FitToPageWidth As Boolean = True        ' True = Fits selected columns to page width ,  False = Print columns as showed    
    Private Shared CabeceraenPaginas As Boolean = True        ' True = Para que aparezcan la cabecera en todas las paginas ,  False = Pues no aparecen
    Private Shared VistaPrevia As Boolean = True        ' True = Muestra el formulario de Vista previa ,  False = Pues no aparecen


    Private Shared HeaderHeight As Int16 = 0


    Public Shared Sub Print_DataGridView(ByVal dgv1 As Ai.Control.MultiColumnTree, ByVal Titulo As String, AjustarColumnas As Boolean, Cabeceras As Boolean, VistaPrevia As Boolean, landcope As Boolean)
        Dim ppvw As PrintPreviewDialog
        Try
            ' Getting DataGridView object to print
            dgv = dgv1

            ' Getting all Coulmns Names in the DataGridView
            AvailableColumns.Clear()
            For Each c As Ai.Control.ColumnHeader In dgv.Columns
                If Not c.Visible Then Continue For
                AvailableColumns.Add(c.Text)
            Next

            ' Showing the PrintOption Form
            Dim dlg As New PrintOptions(AvailableColumns, Titulo, AjustarColumnas, Cabeceras)
            If dlg.ShowDialog() <> DialogResult.OK Then Exit Sub

            ' Saving some printing attributes
            PrintTitle = dlg.PrintTitle
            PrintAllRows = dlg.PrintAllRows
            FitToPageWidth = dlg.FitToPageWidth
            SelectedColumns = dlg.GetSelectedColumns
            CabeceraenPaginas = dlg.Cabeceraenpagina
            RowsPerPage = 0
            ppvw = New PrintPreviewDialog
            PrintDoc.DefaultPageSettings.Landscape = landcope
            PrintDoc.DefaultPageSettings.Margins.Bottom = 1
            PrintDoc.DefaultPageSettings.Margins.Top = 20
            PrintDoc.DefaultPageSettings.Margins.Left = 30
            PrintDoc.DefaultPageSettings.Margins.Right = 5


            ppvw.Document = PrintDoc


            If VistaPrevia = True Then
                ' Showing the Print Preview Page
                If ppvw.ShowDialog() <> DialogResult.OK Then Exit Sub
                ' Printing the Documnet
                PrintDoc.Print()
            Else
                PrintDoc.Print()
            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally

        End Try
    End Sub

    Private Shared Sub PrintDoc_BeginPrint(ByVal sender As Object,
                ByVal e As System.Drawing.Printing.PrintEventArgs) Handles PrintDoc.BeginPrint
        Try
            ' Formatting the Content of Text Cells to print
            StrFormat = New StringFormat
            StrFormat.Alignment = StringAlignment.Near
            StrFormat.LineAlignment = StringAlignment.Center
            StrFormat.Trimming = StringTrimming.EllipsisCharacter

            ' Formatting the Content of Combo Cells to print
            StrFormatComboBox = New StringFormat
            StrFormatComboBox.LineAlignment = StringAlignment.Center
            StrFormatComboBox.FormatFlags = StringFormatFlags.NoWrap
            StrFormatComboBox.Trimming = StringTrimming.EllipsisCharacter

            ColumnLefts.Clear()
            ColumnWidths.Clear()
            ColumnTypes.Clear()
            CellHeight = 0
            RowsPerPage = 0

            ' For various column types
            CellButton = New Button
            CellCheckBox = New CheckBox
            CellComboBox = New ComboBox

            TotalWidth = 0
            For Each GridCol As Ai.Control.ColumnHeader In dgv.Columns
                If Not GridCol.Visible Then Continue For
                If Not SelectedColumns.Contains(GridCol.Text) Then Continue For
                TotalWidth += GridCol.Width
            Next
            PageNo = 1
            NewPage = True
            NodePos = 0
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally

        End Try
    End Sub

    Private Shared Sub PrintDoc_PrintPage(ByVal sender As Object,
            ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDoc.PrintPage

        Dim tmpWidth As Int16, i As Int16
        Dim tmpTop As Int16 = e.MarginBounds.Top
        Dim tmpLeft As Int16 = e.MarginBounds.Left - 20

        Try
            ' Before starting first page, it saves Width & Height of Headers and CoulmnType
            If PageNo = 1 Then
                For Each GridCol As Ai.Control.ColumnHeader In dgv.Columns
                    If Not GridCol.Visible Then Continue For
                    If Not SelectedColumns.Contains(GridCol.Text) Then
                        Continue For
                    End If

                    ' Detemining whether the columns are fitted to page or not.
                    If FitToPageWidth Then
                        tmpWidth = CType(Math.Floor(GridCol.Width / TotalWidth *
                                   TotalWidth * (e.MarginBounds.Width / TotalWidth)), Int16)
                    Else
                        tmpWidth = GridCol.Width
                    End If
                    HeaderHeight = e.Graphics.MeasureString(GridCol.Text,
                                   dgv.Font, tmpWidth).Height + 11

                    ColumnLefts.Add(tmpLeft)
                    ColumnWidths.Add(tmpWidth)
                    ColumnTypes.Add(GridCol.GetType)
                    tmpLeft += tmpWidth
                Next
            End If

            ' Printing Current Page, Nodo a Nodo
            Do While NodePos <= dgv.Nodes.Count - 1
                Dim TreeNode As Ai.Control.TreeNode = dgv.Nodes(NodePos)
                ''Ver si esta despleglado o no 

                CellHeight = 20

                If tmpTop + CellHeight >= e.MarginBounds.Height + e.MarginBounds.Top Then
                    DrawFooter(e, RowsPerPage)
                    NewPage = True
                    PageNo += 1
                    e.HasMorePages = True
                    Exit Sub
                Else
                    If NewPage Then
                        ' Draw Header
                        e.Graphics.DrawString(PrintTitle, New Font(dgv.Font, FontStyle.Bold),
                                Brushes.Black, e.MarginBounds.Left, e.MarginBounds.Top -
                        e.Graphics.MeasureString(PrintTitle, New Font(dgv.Font,
                                FontStyle.Bold), e.MarginBounds.Width).Height - 5)

                        tmpTop = e.MarginBounds.Top
                        i = 0
                        For Each TreeCol As Ai.Control.ColumnHeader In dgv.Columns
                            If Not TreeCol.Visible Then Continue For
                            If Not SelectedColumns.Contains(TreeCol.Text) Then
                                Continue For
                            End If
                            If CabeceraenPaginas = True Or PageNo = 1 Then
                                e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.Red),
                                                                   New Rectangle(ColumnLefts(i), tmpTop, ColumnWidths(i), HeaderHeight))

                                e.Graphics.DrawRectangle(Pens.Black, New Rectangle(ColumnLefts(i),
                                        tmpTop, ColumnWidths(i), HeaderHeight))

                                e.Graphics.DrawString(TreeCol.Text, dgv.Font,
                                        New SolidBrush(Color.Black),
                                        New RectangleF(ColumnLefts(i), tmpTop, ColumnWidths(i),
                                        HeaderHeight), StrFormat)

                            End If

                            i += 1
                        Next
                        NewPage = False
                        tmpTop += HeaderHeight
                    End If

                    Dim left As Double
                    i = 0
                    ' For the TextBox Column
                    e.Graphics.FillRectangle(New SolidBrush(TreeNode.BackColor),
                                   New Rectangle(ColumnLefts(i), tmpTop, ColumnWidths(i), HeaderHeight))
                    Left = ColumnLefts(i) + 1
                    'formateamos los datos que vamos a escribir
                    IIf(IsDate(TreeNode.Name.ToString), TreeNode.Name, TreeNode.Text.ToString)
                    e.Graphics.DrawString(TreeNode.Text.ToString, TreeNode.NodeFont,
                                    New SolidBrush(TreeNode.Color),
                                    New RectangleF(left, tmpTop, ColumnWidths(i),
                                    CellHeight), StrFormat)

                    ' Drawing Cells Borders 
                    e.Graphics.DrawRectangle(Pens.Black, New Rectangle(ColumnLefts(i),
                                tmpTop, ColumnWidths(i), CellHeight))

                    i = 1
                    Dim b As Integer = 1
                    For Each Cel As Ai.Control.TreeNode.TreeNodeSubItem In TreeNode.SubItems
                        Dim widthdelvalor As Double
                        If Not dgv.Columns(b).Visible Then
                            b += 1
                            Continue For
                        End If

                        If Not SelectedColumns.Contains(dgv.Columns(b).Text) Then
                            b += 1
                            Continue For
                        End If

                        ' For the TextBox Column
                        e.Graphics.FillRectangle(New SolidBrush(Cel.BackColor),
                                   New Rectangle(ColumnLefts(i), tmpTop, ColumnWidths(i), HeaderHeight))

                        '' IIf(IsDate(Cel.Value.ToString), Cel.Value, Cel.Value)
                        'formateamos los datos que vamos a escribir
                        Dim val As String
                        Select Case dgv.Columns(b).Format
                            Case 22
                                val = Convert.ToDouble(Cel.Value).ToString("#0.00%")
                            Case 15
                                Select Case dgv.Columns(b).CustomFormat
                                    Case "#,#"
                                        val = Convert.ToDouble(Cel.Value).ToString("0,0")
                                    Case "#,#0"
                                        val = Convert.ToDouble(Cel.Value).ToString("0,0")
                                    Case Else
                                        val = Convert.ToDouble(Cel.Value).ToString()
                                End Select
                            Case Else
                                val = Convert.ToDouble(Cel.Value).ToString()
                        End Select

                        If dgv.Columns(b).TextAlign = HorizontalAlignment.Right Then
                            widthdelvalor = e.Graphics.MeasureString(IIf(Cel.Value Is DBNull.Value, 0, val), Cel.Font).Width
                            left = ColumnLefts(i) + (ColumnWidths(i) - widthdelvalor - 3) + 1
                        Else
                            left = ColumnLefts(i) + 1
                        End If

                        e.Graphics.DrawString(val, Cel.Font,
                                    New SolidBrush(Cel.Color),
                                    New RectangleF(left, tmpTop, ColumnWidths(i),
                                    CellHeight), StrFormat)

                        ' Drawing Cells Borders 
                        e.Graphics.DrawRectangle(Pens.Black, New Rectangle(ColumnLefts(i),
                                tmpTop, ColumnWidths(i), CellHeight))

                        i += 1
                        b += 1

                    Next
                    tmpTop += CellHeight

                End If

                NodePos += 1
                ' For the first page it calculates Rows per Page
                If PageNo = 1 Then
                    RowsPerPage += 1
                End If
            Loop

            If RowsPerPage = 0 Then Exit Sub

            ' Write Footer (Page Number)
            DrawFooter(e, RowsPerPage)

            e.HasMorePages = False
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally

        End Try
    End Sub

    Private Shared Sub DrawFooter(ByVal e As System.Drawing.Printing.PrintPageEventArgs, ByVal RowsPerPage As Int32)
        Dim cnt As Integer

        ' Detemining rows number to print
        If PrintAllRows Then
            cnt = dgv.Nodes.Count - 1
        End If

        ' Writing the Page Number on the Bottom of Page
        Dim PageNum As String = PageNo.ToString + " of " +
                    Math.Ceiling(cnt / RowsPerPage).ToString
        e.Graphics.DrawString(PageNum, dgv.Font, Brushes.Black,
                    e.MarginBounds.Left + (e.MarginBounds.Width -
                    e.Graphics.MeasureString(PageNum, dgv.Font,
                    e.MarginBounds.Width).Width) / 2, e.MarginBounds.Top +
                    e.MarginBounds.Height + 31)

    End Sub

End Class
