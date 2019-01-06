Imports System.IO
Public Class Form1
    Dim numeroElementos As Integer
    Dim C As Integer
    Private Sub btn_crearTabla_Click(sender As Object, e As EventArgs) Handles btn_crearTabla.Click

        Try
            numeroElementos = Convert.ToInt32(txt_elementos.Text)
        Catch
            MsgBox("Debe teclear un entero como orden", MsgBoxStyle.Information, "Error de entrada")
        End Try
        'se eliminan las filas y columnas
        dgv_ecuacion.Rows.Clear()
        dgv_ecuacion.Columns.Clear()
        'se crean las columnas con el nombre X4, X3 ...
        For orden As Integer = numeroElementos To 1 Step -1
            Dim temp As New DataGridViewTextBoxColumn
            temp.Name = "X" + orden.ToString()
            dgv_ecuacion.Columns.Add(temp)
        Next
        'al final se agrega la coluna constante
        Dim col As New DataGridViewTextBoxColumn
        col.Name = "Constante"
        dgv_ecuacion.Columns.Add(col)
        'en este ciclo se completan tres filas
        While dgv_ecuacion.Rows.Count < 3
            dgv_ecuacion.Rows.Add()
        End While
        btn_Calcular.Enabled = True
    End Sub

    Private Sub txt_elementos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_elementos.KeyPress
        If Not (Char.IsNumber(e.KeyChar) Or Char.IsControl(e.KeyChar)) Then e.Handled = True
    End Sub

    Private Sub btn_Calcular_Click(sender As Object, e As EventArgs) Handles btn_Calcular.Click

        Try
            'se obtiene el valor de C del binomio
            C = Convert.ToInt32(txt_c.Text)
        Catch
            MsgBox("El valor de C debe ser un número entero positivo o negativo")
            Return
        End Try
        Try
            txt_resultado.Text = ""
            Dim resultado As String = ""
            Dim valor As Integer = dgv_ecuacion.Rows(0).Cells(0).Value
            dgv_ecuacion.Rows(2).Cells(0).Value = valor
            'aqui se calculan los datos de la tabla
            For orden As Integer = 1 To numeroElementos
                'se calcula el valor q se pondra en la tercer fila multiplicando el resultado anterior por C
                dgv_ecuacion.Rows(1).Cells(orden).Value = dgv_ecuacion.Rows(2).Cells(orden - 1).Value * C
                'ahora se suman el valor calculado mas el valor de la ecuacion
                dgv_ecuacion.Rows(2).Cells(orden).Value = dgv_ecuacion.Rows(1).Cells(orden).Value + dgv_ecuacion.Rows(0).Cells(orden).Value
            Next
            'construyendo el resultado a partir de la tabla
            For orden As Integer = 0 To numeroElementos - 2
                Dim n As Integer = dgv_ecuacion.Rows(2).Cells(orden).Value
                If n <> 0 Then
                    If (n > 0 And Not txt_resultado.Text.Trim().Equals("")) Then
                        txt_resultado.Text &= "  +" & n & "X" & (numeroElementos - orden - 1)
                    Else
                        txt_resultado.Text &= "  " & n & "X" & (numeroElementos - orden - 1)
                    End If
                End If
            Next

            'obteniendo la constante
            Dim constante As Integer = dgv_ecuacion.Rows(2).Cells(numeroElementos - 1).Value
            'se compara con cero para saber si ponerle un simbolo de + o no
            If (constante > 0) Then
                txt_resultado.Text &= "  +" & constante
            Else
                txt_resultado.Text &= "  " & constante
            End If

            resultado = txt_resultado.Text
            'se obtiene el valor de R de la tabla
            Dim constanteSt As String = dgv_ecuacion.Rows(2).Cells(numeroElementos).Value
            Dim valorR As Integer = dgv_ecuacion.Rows(2).Cells(numeroElementos).Value
            txt_resultado.Text &= "              r= " & valorR
            'construyendo la ecuacion original a partir de la tabla
            Dim ecuacionOriginal As String = ""
            For orden As Integer = 0 To numeroElementos - 1
                Dim n As Integer = dgv_ecuacion.Rows(0).Cells(orden).Value
                If n <> 0 Then
                    If (n > 0 And Not ecuacionOriginal.Trim().Equals("")) Then
                        ecuacionOriginal &= "  +" & n & "X" & (numeroElementos - orden)
                    Else
                        ecuacionOriginal &= "  " & n & "X" & (numeroElementos - orden)
                    End If
                End If
            Next
            'se obtiene la constante de la ecuacion original y se compara con el cero para saber si ponerle el simbolo + o no
            Dim constanteEcuacionOriginal As Integer = dgv_ecuacion.Rows(0).Cells(numeroElementos).Value
            If (constanteEcuacionOriginal > 0) Then
                ecuacionOriginal &= "  +" & constanteEcuacionOriginal
            Else
                ecuacionOriginal &= "  " & constanteEcuacionOriginal
            End If
            'calculando P(x)=
            'Aqui se compara el valor capturado con 0 para saber si ponerle el simbolo + o no
            Dim CSt As String = ""
            If (C > 0) Then
                CSt = "X + " & C
            Else
                CSt = "X " & C
            End If
            Dim ResiduoStr As String = ""
            If valorR > 0 Then
                ResiduoStr = " +" & valorR
            Else
                ResiduoStr = " " & valorR
            End If
            'aqui se concatenan todos los resultados para formar P(x)
            txt_PX.Text = ecuacionOriginal & " = ( " & resultado & " )( " & CSt & " )" & ResiduoStr

            Dim ruta As String = "resultado.txt"
            Dim escritor As StreamWriter
            escritor = File.CreateText(ruta)
            escritor.Write("P(X) = " & txt_PX.Text)
            escritor.Flush()
            escritor.Close()
            MessageBox.Show("El resultado se guardo en el archivo: 'resultado.txt'")

        Catch ex As Exception
            MsgBox("Error, todos los datos capturados deben de ser enteros positivos o negativos.", MsgBoxStyle.Critical, "Error en dato capturado")
        End Try

    End Sub

    Private Sub PictureBox1_MouseClick(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseClick
        Close()
    End Sub
End Class
