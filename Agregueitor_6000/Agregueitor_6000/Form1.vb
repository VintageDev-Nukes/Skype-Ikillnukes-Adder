Imports SKYPE4COMLib
Imports System.IO
Imports System.Net
Imports System.Net.Mail
Imports System.Text
Imports System.Security.Cryptography

Public Class frmMain

    Public Shared WithEvents oSkype As New SKYPE4COMLib.Skype

    Private Sub Form1_Load(sender As Object, e As EventArgs)

        If oSkype.Client.IsRunning = True Then
            oSkype.Attach()
        Else
            oSkype.Client.Start()
        End If

    End Sub

    Private Sub ListBox1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ListBox1.KeyDown
        If e.KeyCode = Keys.Delete AndAlso ListBox1.SelectedItem IsNot Nothing Then
            ListBox1.Items.RemoveAt(ListBox1.SelectedIndex)
        End If
    End Sub

    Dim cambio As Integer
    'Dim WithEvents reloj As New Timer With {.Interval = 100, .Enabled = False}

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click


        'Dim pUser As SKYPE4COMLib.User
        Dim total As Integer = ListBox1.Items.Count

        'If contactos < 200 Then
        '    For Each oUser In ListBox1.Items

        '        pUser = oSkype.User(oUser)
        '        'If Not pUser.BuddyStatus = SKYPE4COMLib.TBuddyStatus.budFriend Then
        '        pUser.BuddyStatus = SKYPE4COMLib.TBuddyStatus.budPendingAuthorization
        '        'oSkype.Message.Sender(pUser) = "a"
        '        oSkype.Friends.Add(pUser)
        '        contactos += 1


        '        'End If

        '        'ListBox1.Dispose()
        '    Next
        'Else
        '    'System.Windows.Forms.Application.Restart()
        '    'I need a code that continues where I was, here...
        'End If

        Dim archivo As String = ".\contactos-temp.txt"

        Dim startingPosition As Integer = 0
        If File.Exists(archivo) Then
            Using sr As New StreamReader(archivo)
                If Not sr.ReadToEnd = String.Empty Then
                    sr.Read()
                    startingPosition = Convert.ToInt32(sr.ReadToEnd)
                    sr.Close()
                End If
            End Using
        Else
            File.Create(archivo)
        End If

        Dim contactos As Integer
        Dim CurrentPosition As Integer = 0
        If contactos < 2 And startingPosition < ListBox1.Items.Count Then
            For x As Integer = startingPosition To ListBox1.Items.Count - 1
                Dim oUser As String = CType(ListBox1.Items(x), String)
                Dim pUser As SKYPE4COMLib.User
                pUser = oSkype.User(oUser)
                pUser.BuddyStatus = SKYPE4COMLib.TBuddyStatus.budPendingAuthorization
                oSkype.Friends.Add(pUser)
                contactos += 1
                pUser = Nothing
                CurrentPosition = x
                MsgBox("Cantidad de contactos: " & contactos & ", Sitio concreto: " & CurrentPosition)
            Next
        Else
            Using sw As New StreamWriter(".\contactos-temp.txt")
                sw.Write(CurrentPosition)
                sw.Close()
            End Using
            Process.Start(".\Agregueitor_6000.exe")
            'Me.Dispose()
        End If

        'cambio = contactos * 100 / total

        'ProgressBar1.Value = cambio

        'reloj.Enabled = True


        'For Each oCall In oSkype.ActiveCalls
        '    If oCall.Participants.Count > 0 Then
        '        MsgBox("Conference call " & oCall.Id & "with " & oCall.PartnerHandle & " has " & oCall.Participants.Count & " participants.")
        '            For Each oParticipant In oCall.Participants
        '            ListBox1.Items.Add("Participant " & oParticipant.Handle & " display name is " & oParticipant.DisplayName)
        '            Next
        '    Else
        '        MsgBox("Active call " & oCall.Id & " with " & oCall.PartnerHandle & " is not a conference call.")
        '    End If
        'Next
    End Sub

    'Private Sub Reloj_Tick(sender As Object, e As EventArgs) Handles reloj.Tick
    '    ProgressBar1.Value = cambio
    'End Sub

    Private Sub AñadirNuevoContactoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AñadirNuevoContactoToolStripMenuItem.Click
        Contactos.ShowDialog()
    End Sub

    Private Sub ManualmenteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ManualmenteToolStripMenuItem.Click
        ManualAdd.ShowDialog()
    End Sub


    Private Sub RemoveDuplicates(ByVal [Listbox] As ListBox)

        Dim ItemArray() As String = [Listbox].Items.Cast(Of String).Distinct().ToArray

        Dim DuplicateCount As Int32 = ([Listbox].Items.Count - ItemArray.Count)

        [Listbox].Items.Clear()
        [Listbox].Items.AddRange(ItemArray)

        MsgBox(DuplicateCount & " elementos duplicados en el List.", MsgBoxStyle.Information)

    End Sub

    Private Function GenerateHash(ByVal SourceText As String) As String
        'Create an encoding object to ensure the encoding standard for the source text
        Dim Ue As New UnicodeEncoding()
        'Retrieve a byte array based on the source text
        Dim ByteSourceText() As Byte = Ue.GetBytes(SourceText)
        'Instantiate an MD5 Provider object
        Dim Md5 As New MD5CryptoServiceProvider()
        'Compute the hash value from the source
        Dim ByteHash() As Byte = Md5.ComputeHash(ByteSourceText)
        'And convert it to String format for return
        Return Convert.ToBase64String(ByteHash)
    End Function


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        RemoveDuplicates(ListBox1)
    End Sub
End Class