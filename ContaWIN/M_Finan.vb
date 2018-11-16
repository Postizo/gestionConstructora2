Public Class M_Finan
    Public Shared Function P_IRR(ByRef d As Double()) As Double
        Dim CalcRetRate As Double
        Try
            CalcRetRate = Math.Round(Financial.IRR(d, 0.1) * 100, 2)

        Catch ex As ArgumentException
            MsgBox("Argumentos no validos para calcular el TIR")

        Catch ex As Exception
            ' Se ha producido otro Exception diferente a una ArgumentException.
            '
            ' Ejecutar aquí el código que proceda.
            '
            ' ...

        End Try

        Return CalcRetRate
    End Function
End Class
