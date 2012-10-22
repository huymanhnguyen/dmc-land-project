<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrlTrangThaiHSXetDuyet
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.btnhuylenh = New System.Windows.Forms.Button
        Me.btnghi = New System.Windows.Forms.Button
        Me.btnsua = New System.Windows.Forms.Button
        Me.chkXacNhan = New System.Windows.Forms.CheckBox
        Me.SuspendLayout()
        '
        'btnhuylenh
        '
        Me.btnhuylenh.Enabled = False
        Me.btnhuylenh.Location = New System.Drawing.Point(270, 130)
        Me.btnhuylenh.Name = "btnhuylenh"
        Me.btnhuylenh.Size = New System.Drawing.Size(75, 23)
        Me.btnhuylenh.TabIndex = 4
        Me.btnhuylenh.Text = "Hủy lệnh"
        Me.btnhuylenh.UseVisualStyleBackColor = True
        '
        'btnghi
        '
        Me.btnghi.Enabled = False
        Me.btnghi.Location = New System.Drawing.Point(270, 98)
        Me.btnghi.Name = "btnghi"
        Me.btnghi.Size = New System.Drawing.Size(75, 23)
        Me.btnghi.TabIndex = 3
        Me.btnghi.Text = "Ghi"
        Me.btnghi.UseVisualStyleBackColor = True
        '
        'btnsua
        '
        Me.btnsua.Location = New System.Drawing.Point(270, 63)
        Me.btnsua.Name = "btnsua"
        Me.btnsua.Size = New System.Drawing.Size(75, 23)
        Me.btnsua.TabIndex = 2
        Me.btnsua.Text = "Sửa"
        Me.btnsua.UseVisualStyleBackColor = True
        '
        'chkXacNhan
        '
        Me.chkXacNhan.AutoSize = True
        Me.chkXacNhan.Enabled = False
        Me.chkXacNhan.Location = New System.Drawing.Point(43, 97)
        Me.chkXacNhan.Name = "chkXacNhan"
        Me.chkXacNhan.Size = New System.Drawing.Size(137, 17)
        Me.chkXacNhan.TabIndex = 1
        Me.chkXacNhan.Text = "Hoàn Thành Xác Nhận"
        Me.chkXacNhan.UseVisualStyleBackColor = True
        '
        'ctrlTrangThaiHSXetDuyet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.btnhuylenh)
        Me.Controls.Add(Me.btnghi)
        Me.Controls.Add(Me.btnsua)
        Me.Controls.Add(Me.chkXacNhan)
        Me.Name = "ctrlTrangThaiHSXetDuyet"
        Me.Size = New System.Drawing.Size(475, 264)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnhuylenh As System.Windows.Forms.Button
    Friend WithEvents btnghi As System.Windows.Forms.Button
    Friend WithEvents btnsua As System.Windows.Forms.Button
    Friend WithEvents chkXacNhan As System.Windows.Forms.CheckBox

End Class
