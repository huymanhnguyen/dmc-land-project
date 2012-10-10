<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrTrangThaiHoSo
    Inherits System.Windows.Forms.UserControl

    'UserControl1 overrides dispose to clean up the component list.
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
        Me.chkXacNhan = New System.Windows.Forms.CheckBox
        Me.cmdChapNhan = New System.Windows.Forms.Button
        Me.LabTrangThai = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'chkXacNhan
        '
        Me.chkXacNhan.AutoSize = True
        Me.chkXacNhan.Location = New System.Drawing.Point(15, 14)
        Me.chkXacNhan.Name = "chkXacNhan"
        Me.chkXacNhan.Size = New System.Drawing.Size(15, 14)
        Me.chkXacNhan.TabIndex = 34
        Me.chkXacNhan.UseVisualStyleBackColor = True
        '
        'cmdChapNhan
        '
        Me.cmdChapNhan.Location = New System.Drawing.Point(45, 9)
        Me.cmdChapNhan.Name = "cmdChapNhan"
        Me.cmdChapNhan.Size = New System.Drawing.Size(75, 23)
        Me.cmdChapNhan.TabIndex = 35
        Me.cmdChapNhan.Text = "Chấp nhận"
        Me.cmdChapNhan.UseVisualStyleBackColor = True
        '
        'LabTrangThai
        '
        Me.LabTrangThai.AutoSize = True
        Me.LabTrangThai.BackColor = System.Drawing.Color.Transparent
        Me.LabTrangThai.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabTrangThai.ForeColor = System.Drawing.Color.Red
        Me.LabTrangThai.Location = New System.Drawing.Point(126, 14)
        Me.LabTrangThai.Name = "LabTrangThai"
        Me.LabTrangThai.Size = New System.Drawing.Size(19, 13)
        Me.LabTrangThai.TabIndex = 36
        Me.LabTrangThai.Text = "..."
        '
        'ctrTrangThaiHoSo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Lavender
        Me.Controls.Add(Me.LabTrangThai)
        Me.Controls.Add(Me.cmdChapNhan)
        Me.Controls.Add(Me.chkXacNhan)
        Me.Name = "ctrTrangThaiHoSo"
        Me.Size = New System.Drawing.Size(480, 36)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents cmdChapNhan As System.Windows.Forms.Button
    Public WithEvents chkXacNhan As System.Windows.Forms.CheckBox
    Public WithEvents LabTrangThai As System.Windows.Forms.Label

End Class
