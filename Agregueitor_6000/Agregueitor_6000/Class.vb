Imports System.Runtime.InteropServices
Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Net.Mail

Public Class MouseHook
    Private Declare Function SetWindowsHookEx Lib "user32" Alias "SetWindowsHookExA" (ByVal idHook As Integer, ByVal lpfn As MouseProcDelegate, ByVal hmod As Integer, ByVal dwThreadId As Integer) As Integer
    Private Declare Function CallNextHookEx Lib "user32" (ByVal hHook As Integer, ByVal nCode As Integer, ByVal wParam As Integer, ByVal lParam As MSLLHOOKSTRUCT) As Integer
    Private Declare Function UnhookWindowsHookEx Lib "user32" (ByVal hHook As Integer) As Integer
    Private Delegate Function MouseProcDelegate(ByVal nCode As Integer, ByVal wParam As Integer, ByRef lParam As MSLLHOOKSTRUCT) As Integer

    Private Structure MSLLHOOKSTRUCT
        Public pt As Point
        Public mouseData As Integer
        Public flags As Integer
        Public time As Integer
        Public dwExtraInfo As Integer
    End Structure

    Public Enum Wheel_Direction
        WheelUp
        WheelDown
    End Enum

    Private Const HC_ACTION As Integer = 0
    Private Const WH_MOUSE_LL As Integer = 14
    Private Const WM_MOUSEMOVE As Integer = &H200
    Private Const WM_LBUTTONDOWN As Integer = &H201
    Private Const WM_LBUTTONUP As Integer = &H202
    Private Const WM_LBUTTONDBLCLK As Integer = &H203
    Private Const WM_RBUTTONDOWN As Integer = &H204
    Private Const WM_RBUTTONUP As Integer = &H205
    Private Const WM_RBUTTONDBLCLK As Integer = &H206
    Private Const WM_MBUTTONDOWN As Integer = &H207
    Private Const WM_MBUTTONUP As Integer = &H208
    Private Const WM_MBUTTONDBLCLK As Integer = &H209
    Private Const WM_MOUSEWHEEL As Integer = &H20A

    Private MouseHook As Integer
    Private MouseHookDelegate As MouseProcDelegate

    Public Event Mouse_Move(ByVal ptLocat As Point)
    Public Event Mouse_Left_Down(ByVal ptLocat As Point)
    Public Event Mouse_Left_Up(ByVal ptLocat As Point)
    Public Event Mouse_Left_DoubleClick(ByVal ptLocat As Point)
    Public Event Mouse_Right_Down(ByVal ptLocat As Point)
    Public Event Mouse_Right_Up(ByVal ptLocat As Point)
    Public Event Mouse_Right_DoubleClick(ByVal ptLocat As Point)
    Public Event Mouse_Middle_Down(ByVal ptLocat As Point)
    Public Event Mouse_Middle_Up(ByVal ptLocat As Point)
    Public Event Mouse_Middle_DoubleClick(ByVal ptLocat As Point)
    Public Event Mouse_Wheel(ByVal ptLocat As Point, ByVal Direction As Wheel_Direction)

    Public Sub New()
        MouseHookDelegate = New MouseProcDelegate(AddressOf MouseProc)
        MouseHook = SetWindowsHookEx(WH_MOUSE_LL, MouseHookDelegate, System.Runtime.InteropServices.Marshal.GetHINSTANCE(System.Reflection.Assembly.GetExecutingAssembly.GetModules()(0)).ToInt32, 0)
    End Sub

    Private Function MouseProc(ByVal nCode As Integer, ByVal wParam As Integer, ByRef lParam As MSLLHOOKSTRUCT) As Integer
        If (nCode = HC_ACTION) Then
            Select Case wParam
                Case WM_MOUSEMOVE
                    RaiseEvent Mouse_Move(lParam.pt)
                Case WM_LBUTTONDOWN
                    RaiseEvent Mouse_Left_Down(lParam.pt)
                Case WM_LBUTTONUP
                    RaiseEvent Mouse_Left_Up(lParam.pt)
                Case WM_LBUTTONDBLCLK
                    RaiseEvent Mouse_Left_DoubleClick(lParam.pt)
                Case WM_RBUTTONDOWN
                    RaiseEvent Mouse_Right_Down(lParam.pt)
                Case WM_RBUTTONUP
                    RaiseEvent Mouse_Right_Up(lParam.pt)
                Case WM_RBUTTONDBLCLK
                    RaiseEvent Mouse_Right_DoubleClick(lParam.pt)
                Case WM_MBUTTONDOWN
                    RaiseEvent Mouse_Middle_Down(lParam.pt)
                Case WM_MBUTTONUP
                    RaiseEvent Mouse_Middle_Up(lParam.pt)
                Case WM_MBUTTONDBLCLK
                    RaiseEvent Mouse_Middle_DoubleClick(lParam.pt)
                Case WM_MOUSEWHEEL
                    Dim wDirection As Wheel_Direction
                    If lParam.mouseData < 0 Then
                        wDirection = Wheel_Direction.WheelDown
                    Else
                        wDirection = Wheel_Direction.WheelUp
                    End If
                    RaiseEvent Mouse_Wheel(lParam.pt, wDirection)
            End Select
        End If
        Return CallNextHookEx(MouseHook, nCode, wParam, lParam)
    End Function

    Protected Overrides Sub Finalize()
        UnhookWindowsHookEx(MouseHook)
        MyBase.Finalize()
    End Sub
End Class

Public Class KeyboardHook

    <DllImport("User32.dll", CharSet:=CharSet.Auto, CallingConvention:=CallingConvention.StdCall)> _
    Private Overloads Shared Function SetWindowsHookEx(ByVal idHook As Integer, ByVal HookProc As KBDLLHookProc, ByVal hInstance As IntPtr, ByVal wParam As Integer) As Integer
    End Function

    <DllImport("User32.dll", CharSet:=CharSet.Auto, CallingConvention:=CallingConvention.StdCall)> _
    Private Overloads Shared Function CallNextHookEx(ByVal idHook As Integer, ByVal nCode As Integer, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As Integer
    End Function

    <DllImport("User32.dll", CharSet:=CharSet.Auto, CallingConvention:=CallingConvention.StdCall)> _
    Private Overloads Shared Function UnhookWindowsHookEx(ByVal idHook As Integer) As Boolean
    End Function

    <StructLayout(LayoutKind.Sequential)> _
    Private Structure KBDLLHOOKSTRUCT
        Public vkCode As UInt32
        Public scanCode As UInt32
        Public flags As KBDLLHOOKSTRUCTFlags
        Public time As UInt32
        Public dwExtraInfo As UIntPtr
    End Structure

    <Flags()> _
    Private Enum KBDLLHOOKSTRUCTFlags As UInt32
        LLKHF_EXTENDED = &H1
        LLKHF_INJECTED = &H10
        LLKHF_ALTDOWN = &H20
        LLKHF_UP = &H80
    End Enum

    Public Shared Event KeyDown(ByVal Key As Keys)
    Public Shared Event KeyUp(ByVal Key As Keys)

    Private Const WH_KEYBOARD_LL As Integer = 13
    Private Const HC_ACTION As Integer = 0
    Private Const WM_KEYDOWN = &H100
    Private Const WM_KEYUP = &H101
    Private Const WM_SYSKEYDOWN = &H104
    Private Const WM_SYSKEYUP = &H105

    Private Delegate Function KBDLLHookProc(ByVal nCode As Integer, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As Integer

    Private KBDLLHookProcDelegate As KBDLLHookProc = New KBDLLHookProc(AddressOf KeyboardProc)
    Private HHookID As IntPtr = IntPtr.Zero

    Private Function KeyboardProc(ByVal nCode As Integer, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As Integer
        If (nCode = HC_ACTION) Then
            Dim struct As KBDLLHOOKSTRUCT
            Select Case wParam
                Case WM_KEYDOWN, WM_SYSKEYDOWN
                    RaiseEvent KeyDown(CType(CType(Marshal.PtrToStructure(lParam, struct.GetType()), KBDLLHOOKSTRUCT).vkCode, Keys))
                Case WM_KEYUP, WM_SYSKEYUP
                    RaiseEvent KeyUp(CType(CType(Marshal.PtrToStructure(lParam, struct.GetType()), KBDLLHOOKSTRUCT).vkCode, Keys))
            End Select
        End If
        Return CallNextHookEx(IntPtr.Zero, nCode, wParam, lParam)
    End Function

    Public Sub New()
        HHookID = SetWindowsHookEx(WH_KEYBOARD_LL, KBDLLHookProcDelegate, System.Runtime.InteropServices.Marshal.GetHINSTANCE(System.Reflection.Assembly.GetExecutingAssembly.GetModules()(0)).ToInt32, 0)
        If HHookID = IntPtr.Zero Then
            Throw New Exception("Could not set keyboard hook")
        End If
    End Sub

    Protected Overrides Sub Finalize()
        If Not HHookID = IntPtr.Zero Then
            UnhookWindowsHookEx(HHookID)
        End If
        MyBase.Finalize()
    End Sub

End Class

Public Class INI_Manager

    ''' <summary>
    ''' The INI File Location.
    ''' </summary>
    Public Shared INI_File As String = IO.Path.Combine(Application.StartupPath, Process.GetCurrentProcess().ProcessName & ".ini")

    ''' <summary>
    ''' Set a value.
    ''' </summary>
    ''' <param name="File">The INI file location</param>
    ''' <param name="ValueName">The value name</param>
    ''' <param name="Value">The value data</param>
    Public Shared Sub Set_Value(ByVal File As String, ByVal ValueName As String, ByVal Value As String)

        Try

            If Not IO.File.Exists(File) Then ' Create a new INI File with "Key=Value""

                My.Computer.FileSystem.WriteAllText(File, ValueName & "=" & Value, False)
                Exit Sub

            Else ' Search line by line in the INI file for the "Key"

                Dim Line_Number As Int64 = 0
                Dim strArray() As String = IO.File.ReadAllLines(File)

                For Each line In strArray
                    If line.ToLower.StartsWith(ValueName.ToLower & "=") Then
                        strArray(Line_Number) = ValueName & "=" & Value
                        IO.File.WriteAllLines(File, strArray) ' Replace "value"
                        Exit Sub
                    End If
                    Line_Number += 1
                Next

                Application.DoEvents()

                My.Computer.FileSystem.WriteAllText(File, vbNewLine & ValueName & "=" & Value, True) ' Key don't exist, then create the new "Key=Value"

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' Load a value.
    ''' </summary>
    ''' <param name="File">The INI file location</param>
    ''' <param name="ValueName">The value name</param>
    ''' <returns>The value itself</returns>
    Public Shared Function Load_Value(ByVal File As String, ByVal ValueName As String) As Object

        If Not IO.File.Exists(File) Then

            Throw New Exception(File & " not found.") ' INI File not found.
            Return Nothing

        Else

            For Each line In IO.File.ReadAllLines(File)
                If line.ToLower.StartsWith(ValueName.ToLower & "=") Then Return line.Split("=").Last
            Next

            Application.DoEvents()

            Throw New Exception("Key: " & """" & ValueName & """" & " not found.") ' Key not found.
            Return Nothing

        End If

    End Function

    ''' <summary>
    ''' Delete a key.
    ''' </summary>
    ''' <param name="File">The INI file location</param>
    ''' <param name="ValueName">The value name</param>
    Public Shared Sub Delete_Value(ByVal File As String, ByVal ValueName As String)

        If Not IO.File.Exists(File) Then

            Throw New Exception(File & " not found.") ' INI File not found.
            Exit Sub

        Else

            Try

                Dim Line_Number As Int64 = 0
                Dim strArray() As String = IO.File.ReadAllLines(File)

                For Each line In strArray
                    If line.ToLower.StartsWith(ValueName.ToLower & "=") Then
                        strArray(Line_Number) = Nothing
                        Exit For
                    End If
                    Line_Number += 1
                Next

                Array.Copy(strArray, Line_Number + 1, strArray, Line_Number, UBound(strArray) - Line_Number)
                ReDim Preserve strArray(UBound(strArray) - 1)

                My.Computer.FileSystem.WriteAllText(File, String.Join(vbNewLine, strArray), False)

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        End If

    End Sub

    ''' <summary>
    ''' Sorts the entire INI File.
    ''' </summary>
    ''' <param name="File">The INI file location</param>
    Public Shared Sub Sort_Values(ByVal File As String)

        If Not IO.File.Exists(File) Then

            Throw New Exception(File & " not found.") ' INI File not found.
            Exit Sub

        Else

            Try

                Dim Line_Number As Int64 = 0
                Dim strArray() As String = IO.File.ReadAllLines(File)
                Dim TempList As New List(Of String)

                For Each line As String In strArray
                    If line <> "" Then TempList.Add(strArray(Line_Number))
                    Line_Number += 1
                Next

                TempList.Sort()
                IO.File.WriteAllLines(File, TempList)

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        End If

    End Sub

End Class

Public Class RichTextLabel

    Public Shared Sub Add_Text_With_Color(ByVal richTextBox As RichTextBox, _
                                              ByVal text As String, _
                                              ByVal color As Color, _
                                              Optional ByVal font As Font = Nothing)

        'richTextBox.Enabled = False
        richTextBox.ReadOnly = True
        richTextBox.BorderStyle = BorderStyle.None
        richTextBox.ScrollBars = RichTextBoxScrollBars.None

        Dim index As Int32 = richTextBox.TextLength
        richTextBox.AppendText(text)
        richTextBox.SelectionStart = index
        richTextBox.SelectionLength = richTextBox.TextLength - index
        richTextBox.SelectionColor = color
        If font IsNot Nothing Then richTextBox.SelectionFont = font
        'richTextBox.BackColor = Drawing.Color.White

    End Sub

End Class

'Public Class Pastebin
'    Public Function NewPaste(ByVal Content As String)
'        Dim api_dev_key As String = "eb62df0c04e9453e612a2136101f388a" '<-- Your API key here
'        Dim api_paste_code As String = URLEncode(Content)
'        Dim api_paste_private As String = "2"
'        'Dim api_paste_name As String = URLEncode(Name)
'        Dim api_paste_expire_date As String = "10M"
'        Dim api_paste_format As String = "php"
'        Dim api_user_key As String = ""
'        Dim Response As String = HttpPost("http://pastebin.com/api/api_post.php", "api_option=paste&api_dev_key=" & api_dev_key & "&api_paste_code=" & api_paste_code)
'        If Response.Contains("Bad API request") = False Then
'            Return Raw(Response)
'        Else
'            Return "Error"
'        End If
'    End Function
'    Private Function URLEncode(ByVal EncodeStr As String) As String
'        Dim i As Integer
'        Dim erg As String
'        erg = EncodeStr
'        erg = Replace(erg, "%", Chr(1))
'        erg = Replace(erg, "+", Chr(2))
'        For i = 0 To 255
'            Select Case i
'                Case 37, 43, 48 To 57, 65 To 90, 97 To 122
'                Case 1
'                    erg = Replace(erg, Chr(i), "%25")
'                Case 2
'                    erg = Replace(erg, Chr(i), "%2B")
'                Case 32
'                    erg = Replace(erg, Chr(i), "+")
'                Case 3 To 15
'                    erg = Replace(erg, Chr(i), "%0" & Hex(i))
'                Case Else
'                    erg = Replace(erg, Chr(i), "%" & Hex(i))
'            End Select
'        Next
'        Return erg
'    End Function
'    Public Shared Function Raw(ByVal URL As String)
'        Dim ID As String = URL.Substring(URL.LastIndexOf("/") + 1)
'        ID = "http://pastebin.com/raw.php?i=" & ID
'        Return New System.Net.WebClient().DownloadString(ID)
'    End Function
'    Private Function HttpPost(ByVal URL As String, ByVal Data As String)
'        Dim request As WebRequest = WebRequest.Create(URL)
'        request.Method = "POST"
'        Dim byteArray As Byte() = Encoding.UTF8.GetBytes(Data)
'        request.ContentType = "application/x-www-form-urlencoded"
'        request.ContentLength = byteArray.Length
'        Dim dataStream As Stream = request.GetRequestStream()
'        dataStream.Write(byteArray, 0, byteArray.Length)
'        dataStream.Close()
'        Dim response As WebResponse = request.GetResponse()
'        'Console.WriteLine(CType(response, HttpWebResponse).StatusDescription)
'        dataStream = response.GetResponseStream()
'        Dim reader As New StreamReader(dataStream)
'        Dim responseFromServer As String = reader.ReadToEnd()
'        reader.Close()
'        dataStream.Close()
'        response.Close()
'        Return responseFromServer
'    End Function
'End Class

'' '' ''Public Class Pass
'' '' ''    'Public URL As String

'' '' ''    Shared Function Gettear(ByVal URL As String)
'' '' ''        Dim Instance As New WebClient
'' '' ''        Instance.Headers(HttpRequestHeader.UserAgent) = "40"
'' '' ''        Instance.Headers(HttpRequestHeader.ContentType)
'' '' ''        Dim WebRequest As String = Instance.DownloadString(URL)
'' '' ''        MsgBox(WebRequest)
'' '' ''        If WebRequest.StartsWith("<despiste>") = True Then
'' '' ''            Return Coliflor(URL, "<!--")
'' '' ''        Else
'' '' ''            Return "No se pudo obtener la contraseña."
'' '' ''        End If
'' '' ''    End Function

'' '' ''    Shared Function Coliflor(ByVal URL As String, ByVal Response As String)
'' '' ''        'Dim ID As String = URL.Substring(URL.LastIndexOf("/") + 1)
'' '' ''        Dim ID As String = "http://mastermusik.bugs3.com/Ikillnukes/File.php?get_pass=" & Response
'' '' ''        Dim Web404 As String = New System.Net.WebClient().DownloadString(ID)
'' '' ''        Dim Resultado As String = Regex.Replace(Web404, "/\A<despiste>|(?m)<!--.*?>\z/", "")
'' '' ''        Return MsgBox(Resultado)
'' '' ''    End Function

'' '' ''    Shared Function HttpPost(ByVal URL As String, ByVal Data As String)
'' '' ''        Dim request As WebRequest = WebRequest.Create(URL)
'' '' ''        request.Method = "POST"
'' '' ''        Dim byteArray As Byte() = Encoding.UTF8.GetBytes(Data)
'' '' ''        request.ContentType = "application/x-www-form-urlencoded"
'' '' ''        request.ContentLength = byteArray.Length
'' '' ''        Dim dataStream As Stream = request.GetRequestStream()
'' '' ''        dataStream.Write(byteArray, 0, byteArray.Length)
'' '' ''        dataStream.Close()
'' '' ''        Dim response As WebResponse = request.GetResponse()
'' '' ''        'Console.WriteLine(CType(response, HttpWebResponse).StatusDescription)
'' '' ''        dataStream = response.GetResponseStream()
'' '' ''        Dim reader As New StreamReader(dataStream)
'' '' ''        Dim responseFromServer As String = reader.ReadToEnd()
'' '' ''        reader.Close()
'' '' ''        dataStream.Close()
'' '' ''        response.Close()
'' '' ''        Return responseFromServer
'' '' ''    End Function
'' '' ''End Class

Public Class Emaileitor
    Shared Function SendEmail(ByVal Recipients As List(Of String), _
                  ByVal FromAddress As String, _
                  ByVal Subject As String, _
                  ByVal Body As String, _
                  ByVal UserName As String, _
                  ByVal Password As String, _
                  Optional ByVal Server As String = "smtp.live.com", _
                  Optional ByVal Port As Integer = 587, _
                  Optional ByVal Attachments As List(Of String) = Nothing) As String
        Dim Email As New MailMessage()
        Try
            Dim SMTPServer As New SmtpClient
            For Each Attachment As String In Attachments
                Email.Attachments.Add(New Attachment(Attachment))
            Next
            Email.From = New MailAddress(FromAddress)
            For Each Recipient As String In Recipients
                Email.To.Add(Recipient)
            Next
            Email.Subject = Subject
            Email.Body = Body
            SMTPServer.Host = Server
            SMTPServer.Port = Port
            SMTPServer.Credentials = New System.Net.NetworkCredential(UserName, Password)
            SMTPServer.EnableSsl = True
            SMTPServer.Send(Email)
            Email.Dispose()
            Return "Email to " & Recipients(0) & " from " & FromAddress & " was sent."
        Catch ex As SmtpException
            Email.Dispose()
            Return "Sending Email Failed. Smtp Error. " & ex.Message
        Catch ex As ArgumentOutOfRangeException
            Email.Dispose()
            Return "Sending Email Failed. Check Port Number."
        Catch Ex As InvalidOperationException
            Email.Dispose()
            Return "Sending Email Failed. Check Port Number."
        End Try
    End Function

End Class
