﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrlTrangThaiHoSoCapGCN
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ctrlTrangThaiHoSoCapGCN))
        Me.lblTrangThaiHoSoCapGCN = New System.Windows.Forms.Label
        Me.chkXacNhan = New System.Windows.Forms.CheckBox
        Me.btnsua = New System.Windows.Forms.Button
        Me.btnhuylenh = New System.Windows.Forms.Button
        Me.btnghi = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'lblTrangThaiHoSoCapGCN
        '
        Me.lblTrangThaiHoSoCapGCN.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTrangThaiHoSoCapGCN.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTrangThaiHoSoCapGCN.Image = CType(resources.GetObject("lblTrangThaiHoSoCapGCN.Image"), System.Drawing.Image)
        Me.lblTrangThaiHoSoCapGCN.Location = New System.Drawing.Point(3, 0)
        Me.lblTrangThaiHoSoCapGCN.Name = "lblTrangThaiHoSoCapGCN"
        Me.lblTrangThaiHoSoCapGCN.Size = New System.Drawing.Size(380, 20)
        Me.lblTrangThaiHoSoCapGCN.TabIndex = 28
        Me.lblTrangThaiHoSoCapGCN.Text = "Xác Nhận Trạng Thái Hồ Sơ Cấp GCN"
        Me.lblTrangThaiHoSoCapGCN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'chkXacNhan
        '
        Me.chkXacNhan.AutoSize = True
        Me.chkXacNhan.Enabled = False
        Me.chkXacNhan.Location = New System.Drawing.Point(34, 77)
        Me.chkXacNhan.Name = "chkXacNhan"
        Me.chkXacNhan.Size = New System.Drawing.Size(137, 17)
        Me.chkXacNhan.TabIndex = 0
        Me.chkXacNhan.Text = "Hoàn Thành Xác Nhận"
        Me.chkXacNhan.UseVisualStyleBackColor = True
        '
        'btnsua
        '
        Me.btnsua.Location = New System.Drawing.Point(261, 43)
        Me.btnsua.Name = "btnsua"
        Me.btnsua.Size = New System.Drawing.Size(75, 23)
        Me.btnsua.TabIndex = 1
        Me.btnsua.Text = "Sửa"
        Me.btnsua.UseVisualStyleBackColor = True
        '
        'btnhuylenh
        '
        Me.btnhuylenh.Enabled = False
        Me.btnhuylenh.Location = New System.Drawing.Point(261, 110)
        Me.btnhuylenh.Name = "btnhuylenh"
        Me.btnhuylenh.Size = New System.Drawing.Size(75, 23)
        Me.btnhuylenh.TabIndex = 3
        Me.btnhuylenh.Text = "Hủy lệnh"
        Me.btnhuylenh.UseVisualStyleBackColor = True
        '
        'btnghi
        '
        Me.btnghi.Enabled = False
        Me.btnghi.Location = New System.Drawing.Point(261, 78)
        Me.btnghi.Name = "btnghi"
        Me.btnghi.Size = New System.Drawing.Size(75, 23)
        Me.btnghi.TabIndex = 2
        Me.btnghi.Text = "Ghi"
        Me.btnghi.UseVisualStyleBackColor = True
        '
        'ctrlTrangThaiHoSoCapGCN
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.btnhuylenh)
        Me.Controls.Add(Me.btnghi)
        Me.Controls.Add(Me.btnsua)
        Me.Controls.Add(Me.chkXacNhan)
        Me.Controls.Add(Me.lblTrangThaiHoSoCapGCN)
        Me.Name = "ctrlTrangThaiHoSoCapGCN"
        Me.Size = New System.Drawing.Size(383, 161)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents lblTrangThaiHoSoCapGCN As System.Windows.Forms.Label
    Friend WithEvents chkXacNhan As System.Windows.Forms.CheckBox
    Friend WithEvents btnsua As System.Windows.Forms.Button
    Friend WithEvents btnhuylenh As System.Windows.Forms.Button
    Friend WithEvents btnghi As System.Windows.Forms.Button

End Class
