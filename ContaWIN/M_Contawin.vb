Imports Contawin2009
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports ADODB
Imports System.Configuration
Imports System.IO

Public Class M_Contawin
    Public Cn_CONTA As New ADODB.Connection
    Public Cn_CONTA2 As New OleDb.OleDbConnection
    Public Cn_CONTA3 As New SqlClient.SqlConnection

    Public clsEmpresa As New cwoEmpresa
    Public clsDiario As New cwoDiario
    Public clsplan As New cwoPlanDeCuenta
    Public clsventas As New cwoVentas
    Public clscompras As New cwoCompras
    Public clsmaestros As New cwoMaestros

    Dim FRASESQL As String
    Dim command As New OleDb.OleDbCommand
    Dim adapter As New OleDb.OleDbDataAdapter
    Dim log As String

    Private cNNWIN As String

#Region "Conexiones con ContaWin"
    Public Sub Escribe_Log(ByVal Archivo As String, Frase As String)
        Dim sw As System.IO.StreamWriter
        sw = File.AppendText(Archivo)
        sw.WriteLine(Frase)
        sw.Close()

    End Sub
    Public Sub New(CNNWIN As String)

        Cn_CONTA = CreateObject("ADODB.Connection")
        Cn_CONTA.ConnectionString = CNNWIN ' Creamos la conexion de ContaWin
        Cn_CONTA2.ConnectionString = CNNWIN ' Creamos la conexion de ContaWin

    End Sub
    Public Function CW_AgregaApunte(Apunte As Apunte) As Boolean
        Try
            Apunte.Conexion.Open()
            CW_AgregaApunte = clsDiario.Apunte(Apunte.Conexion, Apunte.asiento, Apunte.Id_Cuenta, Apunte.Importe, Apunte.TipoImporte, "0", Apunte.Descripcion, Apunte.fecha, Apunte.AñoEjercicio, Apunte.Referencia, Apunte.TipoDOC, Apunte.Canal, , , , , , , Apunte.sOpc1)
            If CW_AgregaApunte = False Then
                log = "DEVUELVE FALSE LA FUNCION  CONTAWIN APUNTE: " & "-FECHA:" & Apunte.fecha.ToString & "-IMPORTE:" & Apunte.Importe.ToString & "-CUENTA:" & Apunte.Id_Cuenta & " -DESCRIPCION: " & Apunte.Descripcion & ""
            End If
            If (CW_AgregaApunte = False And Apunte.Importe = 0) Then
                CW_AgregaApunte = True
            End If

        Catch ex As Exception
            log = "ERROR CONEXION CONTAWIN APUNTE:" & ex.Message & "-FECHA:" & Apunte.fecha.ToString & "-IMPORTE:" & Apunte.Importe.ToString & "-CUENTA:" & Apunte.Id_Cuenta & ""
            'Escribe_Log("", log)
            Apunte.Conexion.Close()
            CW_AgregaApunte = False
        Finally
            Apunte.Conexion.Close()
        End Try
    End Function
    Public Function CW_ProximoAsiento(ByVal cn As ADODB.Connection, ByVal Ejercicio As Integer) As Long
        Try
            cn.Open()
            CW_ProximoAsiento = clsDiario.ProximoNumeroDeAsiento(cn, Ejercicio)
        Catch ex As Exception
            cn.Close()
            log = "ERROR CONEXION CONTAWIN PROXIMO ASIENTO:" & ex.Message & ""
            'Escribe_Log(ConfigurationManager.AppSettings("Log_ContaWin"), log)
            CW_ProximoAsiento = 0
        Finally
            cn.Close()
        End Try
    End Function
    Public Function CW_AgregarIVASOPORTADO(Ivasoportado As IvaSoportado) As Boolean
        Try
            Ivasoportado.Conexion.Open()
            clscompras.IvaSoportado(Ivasoportado.Conexion, Ivasoportado.N_factura, Ivasoportado.Cuenta_IVA, Ivasoportado.Cuenta_Total, Ivasoportado.Cuenta_Base, Ivasoportado.Titular, Ivasoportado.Cif, Ivasoportado.Base, Ivasoportado.Importe, Ivasoportado.IVA_porcentaje, Ivasoportado.Cuota, 0, 0, Ivasoportado.asiento, Ivasoportado.fecha, Ivasoportado.AñoEjercicio, , , , , Ivasoportado.Canal, Ivasoportado.fecha, Ivasoportado.TipoIVA, , , Ivasoportado.sTipo340, Ivasoportado.fecha.ToString, Ivasoportado.NO347, Ivasoportado.ndato340_1, , , , , , , , )
            CW_AgregarIVASOPORTADO = True
        Catch ex As Exception
            Ivasoportado.Conexion.Close()
            log = "ERROR CONEXION IVASOPORTADO:" & ex.Message & "-FECHA:" & Ivasoportado.fecha.ToString & "-IMPORTE:" & Ivasoportado.Importe.ToString & "-CUENTA:" & Ivasoportado.Cuenta_Total & ""
            '  Escribe_Log(ConfigurationManager.AppSettings("Log_ContaWin"), log)
            CW_AgregarIVASOPORTADO = False
        Finally
            Ivasoportado.Conexion.Close()
        End Try
    End Function
    Public Function CW_AgregarIVAREPERCUTIDO(Ivarepercutido As IvaRepercutido) As Boolean
        Try
            Ivarepercutido.Conexion.Open()
            clsventas.IvaRepercutido(Ivarepercutido.Conexion, Ivarepercutido.N_factura, Ivarepercutido.Cuenta_IVA, Ivarepercutido.Cuenta_Total, Ivarepercutido.Cuenta_Base, Ivarepercutido.Titular, Ivarepercutido.Cif, Ivarepercutido.Base, Ivarepercutido.Importe, Ivarepercutido.IVA_porcentaje, Ivarepercutido.Cuota, 0, 0, Ivarepercutido.asiento, Ivarepercutido.fecha, Ivarepercutido.AñoEjercicio, , , , , Ivarepercutido.canal, Ivarepercutido.fecha, Ivarepercutido.TipoIVA, , , Ivarepercutido.sTipo340, Ivarepercutido.fecha.ToString, Ivarepercutido.NO347, Ivarepercutido.ndato340_1, , , , , , , )
            CW_AgregarIVAREPERCUTIDO = True
        Catch ex As Exception
            Ivarepercutido.Conexion.Close()
            log = "ERROR CONEXION IVASOPORTADO:" & ex.Message & "-FECHA:" & Ivarepercutido.fecha.ToString & "-IMPORTE:" & Ivarepercutido.Importe.ToString & "-CUENTA:" & Ivarepercutido.Cuenta_Total & ""
            ' Escribe_Log(ConfigurationManager.AppSettings("Log_ContaWin"), log)
            CW_AgregarIVAREPERCUTIDO = False
        Finally
            Ivarepercutido.Conexion.Close()
        End Try
    End Function


#End Region

#Region "OTRAS FUNCIONES"
    Public Function CW_Traecuenta_por_cif(ByVal cn As OleDb.OleDbConnection, ByVal Cif As String) As String
        Dim dt As New DataTable
        FRASESQL = "SELECT Cuenta FROM [Datos supletorios] WHERE Cif = '" & Cif & "'"
        adapter = New OleDb.OleDbDataAdapter(FRASESQL, cn)
        adapter.Fill(dt)
        If dt.Rows.Count > 0 Then
            Return dt.Rows(0).Item(0)
        Else
            Return Nothing
        End If
    End Function

    Public Function CW_TipoIvaContaWIN(ByVal cn As OleDb.OleDbConnection, ByVal Categoria As Long, ByVal Impuesto As Double) As Long
        Dim dt As New DataTable
        FRASESQL = "SELECT * FROM Maestro_tipo_iva WHERE Categoria = " & Str(Categoria) & " AND [% Impuesto] = " & Str(Impuesto) & " AND [% RE]=0"
        adapter = New OleDb.OleDbDataAdapter(FRASESQL, cn)
        adapter.Fill(dt)
        If dt.Rows.Count > 0 Then
            Return dt.Rows(0).Item(0)
        Else
            Return Nothing
        End If
    End Function
    Public Function CW_SumasImporteDHPeriodos(ByVal cn As OleDb.OleDbConnection, Cuenta As String, Ejercicio As Long, DH As String, FechaIni As Date, FechaFin As Date) As Double
        Dim dt As New DataTable
        FRASESQL = "SELECT ISNULL(SUM(Debe),0) AS ImpD, ISNULL(SUM(Haber),0) AS ImpH FROM Apuntes WHERE  (Diario <> 'B' AND Diario <> 'C' AND Diario <> 'A' ) AND Cuenta='" & Trim(Cuenta) & "' AND Ejercicio = " & Str(Ejercicio) & " AND Fecha >='" & FechaIni & "' AND Fecha <='" & FechaFin & "'"
        adapter = New OleDbDataAdapter(FRASESQL, cn)
        adapter.Fill(dt)
        If dt.Rows.Count > 0 Then
            If DH = "D" Then
                Return dt.Rows(0).Item("ImpD")
            Else
                Return dt.Rows(0).Item("ImpH")
            End If
        Else
            Return Nothing
        End If
    End Function
    Public Function CW_ConsultaSaldo(ByVal Cuenta As String, Optional nEje As Long = -1, Optional nCodEmpresa As Long = 0, Optional nPerDesde As Long = 0, Optional nPerHasta As Long = 12, Optional sDiario As String = "-1", Optional nCanal As Long = -1, Optional nMoneda As Long = -1, Optional nPunteo As Long = -1, Optional sOpc1 As String = "", Optional sOpc2 As String = "", Optional sOpc3 As String = "", Optional SaldoRapido As Integer = -1) As Double
        Dim Command As New OleDbCommand("mFin_Financiera", Cn_CONTA2)
        Command.CommandType = CommandType.StoredProcedure
        Command.Parameters.Add(New OleDbParameter("@Cuenta", Cuenta))
        Command.Parameters.Add(New OleDbParameter("@Ejercicio", nEje))
        Command.Parameters.Add(New OleDbParameter("@PeriodoDesde", nPerDesde))
        Command.Parameters.Add(New OleDbParameter("@PeriodoHasta", nPerHasta))
        Command.Parameters.Add(New OleDbParameter("@Diario", sDiario))
        Command.Parameters.Add(New OleDbParameter("@Canal", nCanal))
        Command.Parameters.Add(New OleDbParameter("@Moneda", nMoneda))
        Command.Parameters.Add(New OleDbParameter("@Punteo", nPunteo))
        Command.Parameters.Add(New OleDbParameter("@Opc1", sOpc1))
        Command.Parameters.Add(New OleDbParameter("@Opc2", sOpc2))
        Command.Parameters.Add(New OleDbParameter("@Opc3", sOpc3))
        Command.Parameters.Add(New OleDbParameter("@ECPN", -1))
        Command.Parameters.Add(New OleDbParameter("@DebeOUT", 0.0))
        Command.Parameters.Add(New OleDbParameter("@HaberOUT", 0.0))
        Command.Parameters("@DebeOUT").Direction = ParameterDirection.Output
        Command.Parameters("@HaberOUT").Direction = ParameterDirection.Output

        Try
            Cn_CONTA2.Open()
            Command.ExecuteNonQuery()
        Catch ex As Exception
            ''MessageBox.Show(ex.Message)
        Finally
            Cn_CONTA2.Close()
        End Try

        CW_ConsultaSaldo = Command.Parameters("@DebeOUT").Value - Command.Parameters("@HaberOUT").Value
    End Function

    Public Function CW_CrearCuentas(ByVal Tipo As String, ByVal estacion As Integer, ByVal Codigo As Integer) As String
        ''  CW_CrearCuentas = PrefijosCuentas(Tipo) & estacion.ToString.PadLeft(2, "0") & Codigo.ToString.PadLeft(5, "0")
    End Function

    Public Structure Apunte
        Public Property Conexion As ADODB.Connection
        Public Property asiento As Long
        Public Property Id_Cuenta As String
        Public Property Importe As Double
        Public Property TipoImporte As TipoImporte
        Public Property Descripcion As String
        Public Property fecha As Date
        Public Property AñoEjercicio As Integer
        Public Property Referencia As String
        Public Property Canal As Integer
        Public Property TipoDOC As TipoDeApunteEnum
        Public Property sOpc1 As String

    End Structure

    Public Structure IvaSoportado
        Public Property Conexion As ADODB.Connection
        Public Property N_factura As String
        Public Property Cuenta_IVA As String
        Public Property Cuenta_Total As String
        Public Property Cuenta_Base As String
        Public Property Titular As String
        Public Property Cif As String
        Public Property Base As Double
        Public Property Importe As Double
        Public Property IVA_porcentaje As Double
        Public Property Cuota As Double
        Public Property asiento As Long
        Public Property fecha As Date
        Public Property AñoEjercicio As Integer
        Public Property TipoIVA As Integer
        Public Property ndato340_1 As Integer
        Public Property Canal As Integer
        Public Property sTipo340 As String
        Public Property NO347 As Integer
    End Structure

    Public Structure IvaRepercutido
        Public Property Conexion As ADODB.Connection
        Public Property N_factura As String
        Public Property Cuenta_IVA As String
        Public Property Cuenta_Total As String
        Public Property Cuenta_Base As String
        Public Property Titular As String
        Public Property Cif As String
        Public Property Base As Double
        Public Property Importe As Double
        Public Property IVA_porcentaje As Double
        Public Property Cuota As Double
        Public Property asiento As Long
        Public Property fecha As Date
        Public Property AñoEjercicio As Integer
        Public Property TipoIVA As Integer
        Public Property ndato340_1 As Integer
        Public Property canal As Integer
        Public Property sTipo340 As String
        Public Property NO347 As Integer
    End Structure


#End Region

End Class

