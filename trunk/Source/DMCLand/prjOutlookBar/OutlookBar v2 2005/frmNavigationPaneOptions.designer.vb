<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNavigationPaneOptions
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmNavigationPaneOptions))
        Me.Label1 = New System.Windows.Forms.Label
        Me.CheckedListBox1 = New System.Windows.Forms.CheckedListBox
        Me.btn_Up = New System.Windows.Forms.Button
        Me.btn_Down = New System.Windows.Forms.Button
        Me.btn_Reset = New System.Windows.Forms.Button
        Me.btn_OK = New System.Windows.Forms.Button
        Me.btn_Cancel = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AccessibleDescription = Nothing
        Me.Label1.AccessibleName = Nothing
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Font = Nothing
        Me.Label1.Name = "Label1"
        '
        'CheckedListBox1
        '
        Me.CheckedListBox1.AccessibleDescription = Nothing
        Me.CheckedListBox1.AccessibleName = Nothing
        resources.ApplyResources(Me.CheckedListBox1, "CheckedListBox1")
        Me.CheckedListBox1.BackgroundImage = Nothing
        Me.CheckedListBox1.Font = Nothing
        Me.CheckedListBox1.FormattingEnabled = True
        Me.CheckedListBox1.Name = "CheckedListBox1"
        '
        'btn_Up
        '
        Me.btn_Up.AccessibleDescription = Nothing
        Me.btn_Up.AccessibleName = Nothing
        resources.ApplyResources(Me.btn_Up, "btn_Up")
        Me.btn_Up.BackgroundImage = Nothing
        Me.btn_Up.Font = Nothing
        Me.btn_Up.Name = "btn_Up"
        Me.btn_Up.UseVisualStyleBackColor = True
        '
        'btn_Down
        '
        Me.btn_Down.AccessibleDescription = Nothing
        Me.btn_Down.AccessibleName = Nothing
        resources.ApplyResources(Me.btn_Down, "btn_Down")
        Me.btn_Down.BackgroundImage = Nothing
        Me.btn_Down.Font = Nothing
        Me.btn_Down.Name = "btn_Down"
        Me.btn_Down.UseVisualStyleBackColor = True
        '
        'btn_Reset
        '
        Me.btn_Reset.AccessibleDescription = Nothing
        Me.btn_Reset.AccessibleName = Nothing
        resources.ApplyResources(Me.btn_Reset, "btn_Reset")
        Me.btn_Reset.BackgroundImage = Nothing
        Me.btn_Reset.Font = Nothing
        Me.btn_Reset.Name = "btn_Reset"
        Me.btn_Reset.UseVisualStyleBackColor = True
        '
        'btn_OK
        '
        Me.btn_OK.AccessibleDescription = Nothing
        Me.btn_OK.AccessibleName = Nothing
        resources.ApplyResources(Me.btn_OK, "btn_OK")
        Me.btn_OK.BackgroundImage = Nothing
        Me.btn_OK.Font = Nothing
        Me.btn_OK.Name = "btn_OK"
        Me.btn_OK.UseVisualStyleBackColor = True
        '
        'btn_Cancel
        '
        Me.btn_Cancel.AccessibleDescription = Nothing
        Me.btn_Cancel.AccessibleName = Nothing
        resources.ApplyResources(Me.btn_Cancel, "btn_Cancel")
        Me.btn_Cancel.BackgroundImage = Nothing
        Me.btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btn_Cancel.Font = Nothing
        Me.btn_Cancel.Name = "btn_Cancel"
        Me.btn_Cancel.UseVisualStyleBackColor = True
        '
        'frmNavigationPaneOptions
        '
        Me.AcceptButton = Me.btn_OK
        Me.AccessibleDescription = Nothing
        Me.AccessibleName = Nothing
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Nothing
        Me.CancelButton = Me.btn_Cancel
        Me.Controls.Add(Me.btn_Cancel)
        Me.Controls.Add(Me.btn_OK)
        Me.Controls.Add(Me.btn_Reset)
        Me.Controls.Add(Me.btn_Down)
        Me.Controls.Add(Me.btn_Up)
        Me.Controls.Add(Me.CheckedListBox1)
        Me.Controls.Add(Me.Label1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.HelpButton = True
        Me.Icon = Nothing
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmNavigationPaneOptions"
        Me.ShowIcon = False
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CheckedListBox1 As System.Windows.Forms.CheckedListBox
    Friend WithEvents btn_Up As System.Windows.Forms.Button
    Friend WithEvents btn_Down As System.Windows.Forms.Button
    Friend WithEvents btn_Reset As System.Windows.Forms.Button
    Friend WithEvents btn_OK As System.Windows.Forms.Button
    Friend WithEvents btn_Cancel As System.Windows.Forms.Button
End Class
