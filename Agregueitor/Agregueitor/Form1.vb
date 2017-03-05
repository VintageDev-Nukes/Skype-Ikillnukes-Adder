Public Class frmMain
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
    Private Const MOUSEEVENTF_LEFTDOWN = &H2
    Private Const MOUSEEVENTF_LEFTUP = &H4

    Public Sub MouseLeftClick(ByVal PosX As Long, ByVal PosY As Long)
        Call mouse_event(MOUSEEVENTF_LEFTDOWN, PosX, PosY, 0, 0)
        Call mouse_event(MOUSEEVENTF_LEFTUP, PosX, PosY, 0, 0)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        SetCursorPos(50, 800)
        Call MouseLeftClick(50, 800)
    End Sub

End Class
