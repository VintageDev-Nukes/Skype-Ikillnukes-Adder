<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ArchivoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AñadirNuevoContactoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ObtenerContactosDeUnaConversaciónToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ManualmenteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(12, 223)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(127, 27)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Añadir contactos"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(12, 38)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(261, 173)
        Me.ListBox1.TabIndex = 2
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ArchivoToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(285, 24)
        Me.MenuStrip1.TabIndex = 3
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ArchivoToolStripMenuItem
        '
        Me.ArchivoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AñadirNuevoContactoToolStripMenuItem, Me.ObtenerContactosDeUnaConversaciónToolStripMenuItem})
        Me.ArchivoToolStripMenuItem.Name = "ArchivoToolStripMenuItem"
        Me.ArchivoToolStripMenuItem.Size = New System.Drawing.Size(60, 20)
        Me.ArchivoToolStripMenuItem.Text = "Archivo"
        '
        'AñadirNuevoContactoToolStripMenuItem
        '
        Me.AñadirNuevoContactoToolStripMenuItem.Name = "AñadirNuevoContactoToolStripMenuItem"
        Me.AñadirNuevoContactoToolStripMenuItem.Size = New System.Drawing.Size(284, 22)
        Me.AñadirNuevoContactoToolStripMenuItem.Text = "Añadir nuevo contacto"
        '
        'ObtenerContactosDeUnaConversaciónToolStripMenuItem
        '
        Me.ObtenerContactosDeUnaConversaciónToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ManualmenteToolStripMenuItem})
        Me.ObtenerContactosDeUnaConversaciónToolStripMenuItem.Name = "ObtenerContactosDeUnaConversaciónToolStripMenuItem"
        Me.ObtenerContactosDeUnaConversaciónToolStripMenuItem.Size = New System.Drawing.Size(284, 22)
        Me.ObtenerContactosDeUnaConversaciónToolStripMenuItem.Text = "Obtener contactos de una conversación"
        '
        'ManualmenteToolStripMenuItem
        '
        Me.ManualmenteToolStripMenuItem.Name = "ManualmenteToolStripMenuItem"
        Me.ManualmenteToolStripMenuItem.Size = New System.Drawing.Size(148, 22)
        Me.ManualmenteToolStripMenuItem.Text = "Manualmente"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(146, 222)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(127, 28)
        Me.Button2.TabIndex = 4
        Me.Button2.Text = "Eliminar repetidos"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(12, 256)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(261, 16)
        Me.ProgressBar1.TabIndex = 5
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(285, 284)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.Name = "frmMain"
        Me.Text = "Agregueitor 6000"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ArchivoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AñadirNuevoContactoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ObtenerContactosDeUnaConversaciónToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ManualmenteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar

End Class
