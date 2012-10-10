<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNghiepVuHoSo
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
        Me.CtrlNghiepVuHoSo1 = New DMCLand.ctrlNghiepVuHoSo
        Me.SuspendLayout()
        '
        'CtrlNghiepVuHoSo1
        '
        Me.CtrlNghiepVuHoSo1.BackColor = System.Drawing.Color.Lavender
        Me.CtrlNghiepVuHoSo1.DiaChiThua = ""
        Me.CtrlNghiepVuHoSo1.DienTichTuNhien = ""
        Me.CtrlNghiepVuHoSo1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CtrlNghiepVuHoSo1.Location = New System.Drawing.Point(0, 0)
        Me.CtrlNghiepVuHoSo1.MaDonViHanhChinh = ""
        Me.CtrlNghiepVuHoSo1.MaHoSoCapGCN = ""
        Me.CtrlNghiepVuHoSo1.MaThuaDat = ""
        Me.CtrlNghiepVuHoSo1.Name = "CtrlNghiepVuHoSo1"
        Me.CtrlNghiepVuHoSo1.Size = New System.Drawing.Size(1016, 742)
        Me.CtrlNghiepVuHoSo1.SoHieuThua = ""
        Me.CtrlNghiepVuHoSo1.TabIndex = 0
        Me.CtrlNghiepVuHoSo1.ToBanDo = ""
        '
        'frmNghiepVuHoSo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(1016, 742)
        Me.Controls.Add(Me.CtrlNghiepVuHoSo1)
        Me.Name = "frmNghiepVuHoSo"
        Me.Text = "Nghiep vu ho so cap GCN"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents CtrlNghiepVuHoSo1 As DMCLand.ctrlNghiepVuHoSo
End Class
