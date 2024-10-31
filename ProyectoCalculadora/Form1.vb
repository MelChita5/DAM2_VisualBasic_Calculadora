Public Class formPrincipal

    ' Alexandra Leyli
    ' Macedo Cotrina
    ' DAM2
    ' Desarrollo de interfaces
    ' Actividad 03 - Calculadora

    ' Declaración de variables globales para almacenar valores y la operación actual
    Dim valor1 As Double    ' Primer valor ingresado
    Dim valor2 As Double    ' Segundo valor ingresado
    Dim operacion As String ' Tipo de operación seleccionada (+, -, *, /, ^, %)

    ' Evento para ingresar números en el testDisplay
    Private Sub btnNumero_Click(sender As Button, e As EventArgs) Handles btnComa.Click, btn9.Click, btn8.Click, btn7.Click, btn6.Click, btn5.Click, btn4.Click, btn3.Click, btn2.Click, btn1.Click, btn0.Click
        ' Concatenar el texto del botón presionado al texto actual en el display
        ' esta en la manera mas eficiente para hacer que parezcan los numeros en el display
        textDisplay.Text += sender.Text
    End Sub

    ' Evento para limpiar el display y reiniciar valores y operación
    Private Sub btnC_Click(sender As Object, e As EventArgs) Handles btnC.Click
        ' Limpiar el display y reiniciar las variables 
        textDisplay.Text = "" 'para reinicair el display, el texto debe de ser ""
        valor1 = 0 'para reinicair el valor1 (variable global), debe de ser un 0
        valor2 = 0 'para reinicair el valor2 (variable global), debe de ser un 0
        operacion = "" 'para reinicair la operacion que es un string, el texto debe de ser ""
    End Sub

    ' Evento para calcular el porcentaje
    Private Sub btnPorcentaje_Click(sender As Object, e As EventArgs) Handles btnPorcentaje.Click
        ' Verificar si el display no está vacío y contiene un número válido
        If textDisplay.Text <> "" AndAlso IsNumeric(textDisplay.Text) Then
            valor1 = CDbl(textDisplay.Text)  ' Convertir el texto en número y asignarlo a valor1
            operacion = "%"                 ' Asignar la operación de porcentaje
            textDisplay.Text = (valor1 / 100).ToString()  ' Calcular el porcentaje (valor1 entre 100), convertirlo a String y mostrarlo en el display
        Else
            ' Mostrar un mensaje de error si el display está vacío o no contiene un número válido
            MessageBox.Show("Por favor, ingresa un número antes de seleccionar la operación de porcentaje.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    ' Evento para seleccionar una operación aritmética (suma, resta, multiplicación, división)
    Private Sub btnOperacion_Click(sender As Object, e As EventArgs) Handles btnSuma.Click, btnResta.Click, btnMulti.Click, btnDiv.Click
        ' Verificar si el display no está vacío
        If textDisplay.Text <> "" Then
            valor1 = CDbl(textDisplay.Text)  ' Convertir el texto en número y asignarlo a valor1
            operacion = sender.Text          ' Asignar la operación (el texto del botón presionado)
            textDisplay.Text = ""            ' Limpiar/vaciar el display para el próximo valor
        Else
            ' Mostrar un mensaje de error si el display está vacío
            MessageBox.Show("Por favor, ingresa un número antes de seleccionar una operación.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    ' Evento para seleccionar la operación de potencia
    Private Sub btnPotencia_Click(sender As Object, e As EventArgs) Handles btnPotencia.Click
        ' Verificar si el display no está vacío
        If textDisplay.Text <> "" Then
            valor1 = CDbl(textDisplay.Text)  ' Convertir el texto en número y asignarlo a valor1
            operacion = "^"                  ' Asignar la operación de potencia
            textDisplay.Text = ""            ' Limpiar el display para el próximo valor
        Else
            ' Mostrar un mensaje de error si el display está vacío
            MessageBox.Show("Por favor, ingresa un número antes de seleccionar la operación de potencia.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    ' Evento para el botón igual, realiza la operación seleccionada y muestra el resultado
    Private Sub btnIgual_Click(sender As Object, e As EventArgs) Handles btnIgual.Click
        ' Verificar que el display no esté vacío y contenga un número válido
        If textDisplay.Text <> "" AndAlso IsNumeric(textDisplay.Text) Then
            Dim resultado As Double 'Variable de duble para almacenar el resultado

            ' Si la operación es porcentaje, se calcula directamente y no se requiere un segundo valor
            If operacion = "%" Then
                resultado = valor1 / 100  ' Calcular el porcentaje
                listHistorial.Items.Add($"{valor1} % = {resultado}") ' Guardar el cálculo en el historial
                textDisplay.Text = resultado.ToString()              ' Mostrar el resultado en el display
                operacion = ""                                       ' Limpiar la operación
                Exit Sub                                             ' Terminar el procedimiento aquí
            End If

            valor2 = CDbl(textDisplay.Text)  ' Convertir el texto del display en número y asignarlo a valor2

            ' Seleccionar la operación aritmética según el valor de la variable "operacion"
            Select Case operacion
                Case "+"
                    resultado = valor1 + valor2  ' Sumar valor1 y valor2
                Case "-"
                    resultado = valor1 - valor2  ' Restar valor2 de valor1
                Case "*"
                    resultado = valor1 * valor2  ' Multiplicar valor1 y valor2
                Case "/"
                    If valor2 <> 0 Then          ' Verificar que valor2 no sea 0
                        resultado = valor1 / valor2  ' Dividir valor1 por valor2
                    Else
                        textDisplay.Text = "Error"  ' Mostrar error si valor2 es 0
                        Exit Sub
                    End If
                Case "^"
                    resultado = Math.Pow(valor1, valor2)  ' Elevar valor1 a la potencia de valor2
                Case Else
                    textDisplay.Text = "Error"            ' Mostrar error si la operación es desconocida
                    Exit Sub
            End Select

            ' Mostrar el resultado (que se convierte en String) de la operación en el display
            textDisplay.Text = resultado.ToString()

            ' Agregar el cálculo al historial en formato legible
            listHistorial.Items.Add($"{valor1} {operacion} {valor2} = {resultado}")  ' aparecera el Valor1 / la operacion / valor2 / = / resultado(variable creada al inicio)
        Else
            ' Mostrar mensaje de error si el display está vacío o no tiene un número válido
            MessageBox.Show("Por favor, ingresa un número válido antes de presionar el botón Igual.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
End Class



