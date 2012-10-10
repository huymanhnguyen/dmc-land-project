<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmXuatDuLieuTuBanDo
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
        Me.CtrSoanHS1 = New DMC.Land.SoanHoSo.ctrSoanHS
        Me.cmdXuatDuLieu = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'CtrSoanHS1
        '
        Me.CtrSoanHS1.ChangeNewFeature = False
        Me.CtrSoanHS1.Location = New System.Drawing.Point(7, 12)
        Me.CtrSoanHS1.MaDonViHanhChinh = ""
        Me.CtrSoanHS1.Name = "CtrSoanHS1"
        Me.CtrSoanHS1.Size = New System.Drawing.Size(1028, 709)
        Me.CtrSoanHS1.TabIndex = 0
        '
        'cmdXuatDuLieu
        '
        Me.cmdXuatDuLieu.Location = New System.Drawing.Point(107, 665)
        Me.cmdXuatDuLieu.Name = "cmdXuatDuLieu"
        Me.cmdXuatDuLieu.Size = New System.Drawing.Size(75, 23)
        Me.cmdXuatDuLieu.TabIndex = 1
        Me.cmdXuatDuLieu.Text = "Xuất dữ liệu"
        Me.cmdXuatDuLieu.UseVisualStyleBackColor = True
        '
        'FrmXuatDuLieuTuBanDo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1044, 722)
        Me.Controls.Add(Me.cmdXuatDuLieu)
        Me.Controls.Add(Me.CtrSoanHS1)
        Me.Name = "FrmXuatDuLieuTuBanDo"
        Me.Text = "XuatDuLieuTuBanDo"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CtrSoanHS1 As DMC.Land.SoanHoSo.ctrSoanHS
    Friend WithEvents cmdXuatDuLieu As System.Windows.Forms.Button
End Class
