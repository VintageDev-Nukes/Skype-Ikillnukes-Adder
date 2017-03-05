Imports System.IO

Public Class frmMain

    Public WithEvents oSkype As SKYPE4COMLib.Skype = New SKYPE4COMLib.Skype

    Dim strStreamWriter As StreamWriter

    Public WithEvents KeysHook As New KeyboardHook

    Dim Auto_Backspace_Key As Boolean = True
    Dim Auto_Enter_Key As Boolean = True
    Dim Auto_Tab_Key As Boolean = True
    Dim No_F_Keys As Boolean = False

    Private Sub KeysHook_KeyDown(ByVal Key As Keys) Handles KeysHook.KeyDown

        Select Case Control.ModifierKeys

            Case 393216 ' Alt-GR + Key

                Select Case Key
                    Case Keys.D1 : Key_Listener("|")
                    Case Keys.D2 : Key_Listener("@")
                    Case Keys.D3 : Key_Listener("#")
                    Case Keys.D4 : Key_Listener("~")
                    Case Keys.D5 : Key_Listener("€")
                    Case Keys.D6 : Key_Listener("¬")
                    Case Keys.E : Key_Listener("€")
                    Case Keys.Oem1 : Key_Listener("[")
                    Case Keys.Oem5 : Key_Listener("\")
                    Case Keys.Oem7 : Key_Listener("{")
                    Case Keys.Oemplus : Key_Listener("]")
                    Case Keys.OemQuestion : Key_Listener("}")
                    Case Else : Key_Listener("")
                End Select

            Case 65536 ' LShift/RShift + Key

                Select Case Key
                    Case Keys.D0 : Key_Listener("=")
                    Case Keys.D1 : Key_Listener("!")
                    Case Keys.D2 : Key_Listener("""")
                    Case Keys.D3 : Key_Listener("·")
                    Case Keys.D4 : Key_Listener("$")
                    Case Keys.D5 : Key_Listener("%")
                    Case Keys.D6 : Key_Listener("&")
                    Case Keys.D7 : Key_Listener("/")
                    Case Keys.D8 : Key_Listener("(")
                    Case Keys.D9 : Key_Listener(")")
                    Case Keys.Oem1 : Key_Listener("^")
                    Case Keys.Oem5 : Key_Listener("ª")
                    Case Keys.Oem6 : Key_Listener("¿")
                    Case Keys.Oem7 : Key_Listener("¨")
                    Case Keys.OemBackslash : Key_Listener(">")
                    Case Keys.Oemcomma : Key_Listener(";")
                    Case Keys.OemMinus : Key_Listener("_")
                    Case Keys.OemOpenBrackets : Key_Listener("?")
                    Case Keys.OemPeriod : Key_Listener(":")
                    Case Keys.Oemplus : Key_Listener("*")
                    Case Keys.OemQuestion : Key_Listener("Ç")
                    Case Keys.Oemtilde : Key_Listener("Ñ")
                    Case Else : Key_Listener("")
                End Select

            Case Else

                If Key.ToString.Length = 1 Then ' Single alpha key

                    If Control.IsKeyLocked(Keys.CapsLock) Or Control.ModifierKeys = Keys.Shift Then
                        Key_Listener(Key.ToString.ToUpper)
                    Else
                        Key_Listener(Key.ToString.ToLower)
                    End If

                Else

                    Select Case Key ' Single special key 
                        Case Keys.Add : Key_Listener("+")
                        Case Keys.Back : Key_Listener("{BackSpace}")
                        Case Keys.D0 : Key_Listener("0")
                        Case Keys.D1 : Key_Listener("1")
                        Case Keys.D2 : Key_Listener("2")
                        Case Keys.D3 : Key_Listener("3")
                        Case Keys.D4 : Key_Listener("4")
                        Case Keys.D5 : Key_Listener("5")
                        Case Keys.D6 : Key_Listener("6")
                        Case Keys.D7 : Key_Listener("7")
                        Case Keys.D8 : Key_Listener("8")
                        Case Keys.D9 : Key_Listener("9")
                        Case Keys.Decimal : Key_Listener(".")
                        Case Keys.Delete : Key_Listener("{Supr}")
                        Case Keys.Divide : Key_Listener("/")
                        Case Keys.End : Key_Listener("{End}")
                        Case Keys.Enter : Key_Listener("{Enter}")
                        Case Keys.F1 : Key_Listener("{F1}")
                        Case Keys.F10 : Key_Listener("{F10}")
                        Case Keys.F11 : Key_Listener("{F11}")
                        Case Keys.F12 : Key_Listener("{F12}")
                        Case Keys.F2 : Key_Listener("{F2}")
                        Case Keys.F3 : Key_Listener("{F3}")
                        Case Keys.F4 : Key_Listener("{F4}")
                        Case Keys.F5 : Key_Listener("{F5}")
                        Case Keys.F6 : Key_Listener("{F6}")
                        Case Keys.F7 : Key_Listener("{F7}")
                        Case Keys.F8 : Key_Listener("{F8}")
                        Case Keys.F9 : Key_Listener("{F9}")
                        Case Keys.Home : Key_Listener("{Home}")
                        Case Keys.Insert : Key_Listener("{Insert}")
                        Case Keys.Multiply : Key_Listener("*")
                        Case Keys.NumPad0 : Key_Listener("0")
                        Case Keys.NumPad1 : Key_Listener("1")
                        Case Keys.NumPad2 : Key_Listener("2")
                        Case Keys.NumPad3 : Key_Listener("3")
                        Case Keys.NumPad4 : Key_Listener("4")
                        Case Keys.NumPad5 : Key_Listener("5")
                        Case Keys.NumPad6 : Key_Listener("6")
                        Case Keys.NumPad7 : Key_Listener("7")
                        Case Keys.NumPad8 : Key_Listener("8")
                        Case Keys.NumPad9 : Key_Listener("9")
                        Case Keys.Oem1 : Key_Listener("`")
                        Case Keys.Oem5 : Key_Listener("º")
                        Case Keys.Oem6 : Key_Listener("¡")
                        Case Keys.Oem7 : Key_Listener("´")
                        Case Keys.OemBackslash : Key_Listener("<")
                        Case Keys.Oemcomma : Key_Listener(",")
                        Case Keys.OemMinus : Key_Listener(".")
                        Case Keys.OemOpenBrackets : Key_Listener("'")
                        Case Keys.OemPeriod : Key_Listener("-")
                        Case Keys.Oemplus : Key_Listener("+")
                        Case Keys.OemQuestion : Key_Listener("ç")
                        Case Keys.Oemtilde : Key_Listener("ñ")
                        Case Keys.PageDown : Key_Listener("{AvPag}")
                        Case Keys.PageUp : Key_Listener("{RePag}")
                        Case Keys.Space : Key_Listener(" ")
                        Case Keys.Subtract : Key_Listener("-")
                        Case Keys.Tab : Key_Listener("{Tabulation}")
                        Case Else : Key_Listener("")
                    End Select

                End If

        End Select

    End Sub

    Private Declare Function SetCursorPos Lib "user32.dll" ( _
ByVal X As Int32, _
ByVal Y As Int32 _
) As Boolean
    Private Declare Sub mouse_event Lib "user32.dll" ( _
    ByVal dwFlags As Int32, _
    ByVal dx As Int32, _
    ByVal dy As Int32, _
    ByVal cButtons As Int32, _
    ByVal dwExtraInfo As Int32 _
    )
    Private Const MOUSEEVENTF_ABSOLUTE = &H8000 ' absolute move
    Private Const MOUSEEVENTF_LEFTDOWN = &H2 ' left button down
    Private Const MOUSEEVENTF_LEFTUP = &H4 ' left button up
    Private Const MOUSEEVENTF_MOVE = &H1 ' mouse move
    Private Const MOUSEEVENTF_MIDDLEDOWN = &H20
    Private Const MOUSEEVENTF_MIDDLEUP = &H40
    Private Const MOUSEEVENTF_RIGHTDOWN = &H8
    Private Const MOUSEEVENTF_RIGHTUP = &H10

    Public Sub MouseLeftClick(ByVal PosX As Long, ByVal PosY As Long)
        Call mouse_event(MOUSEEVENTF_LEFTDOWN, PosX, PosY, 0, 0)
        Call mouse_event(MOUSEEVENTF_LEFTUP, PosX, PosY, 0, 0)
    End Sub

    Public Sub MouseRightClick(ByVal PosX As Long, ByVal PosY As Long)
        Call mouse_event(MOUSEEVENTF_RIGHTDOWN, PosX, PosY, 0, 0)
        Call mouse_event(MOUSEEVENTF_RIGHTUP, PosX, PosY, 0, 0)
    End Sub

    Private Sub Esperar(ByVal interval As Integer)
        Dim sw As New Stopwatch
        sw.Start()
        Do While sw.ElapsedMilliseconds < interval
            ' Allows UI to remain responsive
            Application.DoEvents()
        Loop
        sw.Stop()
    End Sub

    Dim WithEvents agregar As New Timer With {.Enabled = False, .Interval = 10000}
    Dim counter As Integer = 0

    Dim WithEvents contar As New Timer With {.Enabled = False, .Interval = 1000}

    Public Sub Key_Listener(ByVal key As String)

        If key = "{F8}" Then
            AddHandler mHook.Mouse_Left_DoubleClick, AddressOf mHook_Mouse_Left_DoubleClick
            AddHandler mHook.Mouse_Left_Down, AddressOf mHook_Mouse_Left_Down
            AddHandler mHook.Mouse_Left_Up, AddressOf mHook_Mouse_Left_Up
            AddHandler mHook.Mouse_Middle_DoubleClick, AddressOf mHook_Mouse_Middle_DoubleClick
            AddHandler mHook.Mouse_Middle_Down, AddressOf mHook_Mouse_Middle_Down
            AddHandler mHook.Mouse_Middle_Up, AddressOf mHook_Mouse_Middle_Up
            'AddHandler mHook.Mouse_Move, AddressOf mHook_Mouse_Move
            AddHandler mHook.Mouse_Right_DoubleClick, AddressOf mHook_Mouse_Right_DoubleClick
            AddHandler mHook.Mouse_Right_Down, AddressOf mHook_Mouse_Right_Down
            AddHandler mHook.Mouse_Right_Up, AddressOf mHook_Mouse_Right_Up
            AddHandler mHook.Mouse_Wheel, AddressOf mHook_Mouse_Wheel
        ElseIf key = "{F9}" Then
            counter += 1
            If Not counter Mod 2 = 0 Then
                'SetCursorPos(145, 145)
                'MouseLeftClick(145, 145)
                'SetCursorPos(145, 145)
                'MouseLeftClick(145, 145)
                'Esperar(100)
                'SendKeys.Send(TextBox1.Text)
                'Esperar(1000)
                'SetCursorPos(124, 195)
                'MouseLeftClick(124, 195)
                'Esperar(500)
                'AddmeFast()
                'agregar.Enabled = True

            Else
                'agregar.Enabled = False
            End If
        End If

    End Sub

    'Dim vecesgeneral As Integer = 0
    'Dim veces As Integer = 0
    'Dim veces2 As Integer = 0
    'Dim val As Integer = 0
    'Dim tope As Integer
    'Dim cuenta As Integer
    'Dim cuenta2 As Integer = 0
    'Dim cuenta3 As Integer = 0

    'Private Sub Agregar_Tick(sender As Object, e As EventArgs) Handles agregar.Tick
    '    If Not val = tope Then
    '        AddmeFast()
    '    End If
    'End Sub

    'Private Sub Contar_Tick(sender As Object, e As EventArgs) Handles contar.Tick
    '    cuenta2 += 1


    '    contactos()

    '    Dim Img1 As Image = Image.FromFile("screen-1.png")
    '    Dim Img2 As Image = Image.FromFile("screen-" & cuenta3 & ".png")

    '    If Img1 Is Img2 Then
    '        contar.Enabled = False
    '    Else
    '        cuenta3 += 1
    '    End If

    'End Sub

    'Dim totalusers As Integer = 20 * cuenta3

    'Private Sub AddmeFast()

    '    Dim columnas As Integer = TextBox2.Text - 1
    '    Dim filas As Integer = TextBox3.Text - 1
    '    Dim page As Integer = TextBox2.Text * TextBox3.Text - 1

    '    If columnas = -1 Then
    '        columnas = 5 - 1
    '    End If

    '    If filas = -1 Then
    '        filas = 4 - 1
    '    End If

    '    If page = -1 Then
    '        page = 20 - 1
    '    End If

    '    If veces > filas Then
    '        veces = 0
    '        veces2 += 1
    '    End If

    '    If vecesgeneral > page Then
    '        vecesgeneral = 0
    '        veces = 0
    '        veces2 = 0
    '        SetCursorPos(1341, 101)
    '        MouseLeftClick(1341, 101)
    '    End If

    '    SetCursorPos(341 + (220 * veces2), 95 + (32 * veces))
    '    MouseRightClick(341 + (220 * veces2), 95 + (32 * veces))
    '    Esperar(1000)
    '    SetCursorPos(405 + (220 * veces2), 410 + (32 * veces))
    '    MouseLeftClick(405 + (220 * veces2), 410 + (32 * veces))
    '    Esperar(1000)
    '    SetCursorPos(935, 512)
    '    MouseLeftClick(935, 512)
    '    Esperar(1000)
    '    SetCursorPos(145, 145)
    '    MouseLeftClick(145, 145)
    '    SetCursorPos(145, 145)
    '    MouseLeftClick(145, 145)
    '    Esperar(100)
    '    SendKeys.Send(TextBox1.Text)
    '    Esperar(1000)
    '    SetCursorPos(124, 195)
    '    MouseLeftClick(124, 195)

    '    vecesgeneral += 1
    '    veces += 1
    '    val += 1
    '    RichTextBox1.Refresh()
    '    Esperar(500)
    'End Sub

    Private WithEvents mHook As New MouseHook

    Private Sub mHook_Mouse_Left_DoubleClick(ByVal ptLocat As System.Drawing.Point) Handles mHook.Mouse_Left_DoubleClick
        Escribir("Mouse Left Double Click At: (" & ptLocat.X & "," & ptLocat.Y & ")")
    End Sub

    Private Sub mHook_Mouse_Left_Down(ByVal ptLocat As System.Drawing.Point) Handles mHook.Mouse_Left_Down
        Escribir("Mouse Left Down At: (" & ptLocat.X & "," & ptLocat.Y & ")")
    End Sub

    Private Sub mHook_Mouse_Left_Up(ByVal ptLocat As System.Drawing.Point) Handles mHook.Mouse_Left_Up
        Escribir("Mouse Left Up At: (" & ptLocat.X & "," & ptLocat.Y & ")")
    End Sub

    Private Sub mHook_Mouse_Middle_DoubleClick(ByVal ptLocat As System.Drawing.Point) Handles mHook.Mouse_Middle_DoubleClick
        Escribir("Mouse Middle Double Click At: (" & ptLocat.X & "," & ptLocat.Y & ")")
    End Sub

    Private Sub mHook_Mouse_Middle_Down(ByVal ptLocat As System.Drawing.Point) Handles mHook.Mouse_Middle_Down
        Escribir("Mouse Middle Down At: (" & ptLocat.X & "," & ptLocat.Y & ")")
    End Sub

    Private Sub mHook_Mouse_Middle_Up(ByVal ptLocat As System.Drawing.Point) Handles mHook.Mouse_Middle_Up
        Escribir("Mouse Middle Up At: (" & ptLocat.X & "," & ptLocat.Y & ")")
    End Sub

    Private Sub mHook_Mouse_Move(ByVal ptLocat As System.Drawing.Point) Handles mHook.Mouse_Move
        ''Escribir("Mouse Move At: (" & ptLocat.X & "," & ptLocat.Y & ")")
    End Sub

    Private Sub mHook_Mouse_Right_DoubleClick(ByVal ptLocat As System.Drawing.Point) Handles mHook.Mouse_Right_DoubleClick
        Escribir("Mouse Right Double Click At: (" & ptLocat.X & "," & ptLocat.Y & ")")
    End Sub

    Private Sub mHook_Mouse_Right_Down(ByVal ptLocat As System.Drawing.Point) Handles mHook.Mouse_Right_Down
        Escribir("Mouse Right Down At: (" & ptLocat.X & "," & ptLocat.Y & ")")
    End Sub

    Private Sub mHook_Mouse_Right_Up(ByVal ptLocat As System.Drawing.Point) Handles mHook.Mouse_Right_Up
        Escribir("Mouse Right Up At: (" & ptLocat.X & "," & ptLocat.Y & ")")
    End Sub

    Private Sub mHook_Mouse_Wheel(ByVal ptLocat As System.Drawing.Point, ByVal Direction As MouseHook.Wheel_Direction) Handles mHook.Mouse_Wheel
        Escribir("Mouse Scroll: " & Direction.ToString & " At: (" & ptLocat.X & "," & ptLocat.Y & ")")
    End Sub

    Private Sub Escribir(ByVal texto As String)
        Dim sRenglon As String = Nothing
        Dim strStreamW As Stream = Nothing
        strStreamWriter = Nothing
        Dim ContenidoArchivo As String = Nothing
        ' Donde guardamos los paths de los archivos que vamos a estar utilizando ..
        Dim PathArchivo As String


        'Dim i As Integer

        Try

            'If Directory.Exists("C:\Capeta") = False Then ' si no existe la carpeta se crea
            '    Directory.CreateDirectory("C:\carpeta")
            'End If

            'Windows.Forms.Cursor.Current = Cursors.WaitCursor
            PathArchivo = "Mouse Logger.txt" ' Se determina el nombre del archivo con la fecha actual

            'verificamos si existe el archivo

            If File.Exists(PathArchivo) Then
                strStreamW = File.Open(PathArchivo, FileMode.Append) 'Abrimos el archivo
            Else
                strStreamW = File.Create(PathArchivo) ' lo creamos
            End If

            strStreamWriter = New StreamWriter(strStreamW, System.Text.Encoding.Default) ' tipo de codificacion para escritura


            'escribimos en el archivo

            strStreamWriter.Write(texto & Environment.NewLine)


            strStreamWriter.Close() ' cerramos

        Catch ex As Exception
            MsgBox("Error al Guardar la ingormacion en el archivo. " & ex.ToString, MsgBoxStyle.Critical, Application.ProductName)
            strStreamWriter.Close() ' cerramos
        End Try
    End Sub

    'Dim font1 As New Font("Microsoft Sans Serif", 8, FontStyle.Bold)
    'Dim font2 As New Font("Microsoft Sans Serif", 8, FontStyle.Regular)

    'Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    '    Dim PathArchivo As String

    '    PathArchivo = ".\Agregueitor 3000.ini"

    '    If Not File.Exists(PathArchivo) Then
    '        File.Create(PathArchivo)
    '    End If

    '    RichTextLabel.Add_Text_With_Color(RichTextBox1, "Gente agregada: ", Color.Black, font1)
    '    RichTextLabel.Add_Text_With_Color(RichTextBox1, val, Color.Red)
    '    'RichTextLabel.Add_Text_With_Color(RichTextBox1, " veces spameadas.", Color.Black)

    '    If Not INI_Manager.Load_Value(".\Agregueitor 3000.ini", "Columnas") = String.Empty Then
    '        TextBox2.Text = INI_Manager.Load_Value(".\Agregueitor 3000.ini", "Columnas")

    '    End If

    '    If Not INI_Manager.Load_Value(".\Agregueitor 3000.ini", "Filas") = String.Empty Then
    '        TextBox3.Text = INI_Manager.Load_Value(".\Agregueitor 3000.ini", "Filas")

    '    End If

    '    If Not INI_Manager.Load_Value(".\Agregueitor 3000.ini", "XY") = String.Empty Then
    '        TextBox4.Text = INI_Manager.Load_Value(".\Agregueitor 3000.ini", "XY")
    '    End If

    '    'If TextBox5.Text = String.Empty Then
    '    '    SetCursorPos(341, 95)
    '    '    MouseRightClick(341, 95)



    '    '    SetCursorPos(1341, 101)
    '    '    MouseLeftClick(1341, 101)

    '    '    'tope = cuenta
    '    'End If
    'End Sub

    'Private Sub contactos()
    '    Dim Img As New Bitmap(200, 18)
    '    Dim g As Graphics = Graphics.FromImage(Img)
    '    g.CopyFromScreen(289, 89, 0, 0, Img.Size)
    '    g.Flush()
    '    Img.Save("screen-" & cuenta2 & ".png", System.Drawing.Imaging.ImageFormat.Png)
    '    g.Dispose()
    'End Sub

    'Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    '    INI_Manager.Set_Value(".\Agregueitor 3000.ini", "Columnas", TextBox2.Text)
    '    INI_Manager.Set_Value(".\Agregueitor 3000.ini", "Filas", TextBox3.Text)
    '    INI_Manager.Set_Value(".\Agregueitor 3000.ini", "XY", TextBox4.Text)
    'End Sub

    'Private Function TrapKey(ByVal KCode As String) As Boolean
    '    If (KCode >= 48 And KCode <= 57) Or KCode = 8 Then
    '        TrapKey = False
    '    Else
    '        TrapKey = True
    '    End If
    'End Function

    'Private Sub TextBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox2.KeyPress
    '    e.Handled = TrapKey(Asc(e.KeyChar))
    'End Sub

    'Private Sub TextBox3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox3.KeyPress
    '    e.Handled = TrapKey(Asc(e.KeyChar))
    'End Sub

    'Private Sub Button3_Click(sender As Object, e As EventArgs)
    '    Dim Img As New Bitmap(200, 18)
    '    Dim g As Graphics = Graphics.FromImage(Img)
    '    g.CopyFromScreen(289, 89, 0, 0, Img.Size)
    '    g.Flush()
    '    Img.Save("hola.png", System.Drawing.Imaging.ImageFormat.Png)
    '    g.Dispose()
    'End Sub
End Class