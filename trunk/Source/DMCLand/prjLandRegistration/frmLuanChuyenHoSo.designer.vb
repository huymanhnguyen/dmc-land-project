<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLuanChuyenHoSo
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
        Me.CtrLuanChuyen1 = New prjQuyTrinhLuanChuyen.ctrLuanChuyen
        Me.SuspendLayout()
        '
        'CtrLuanChuyen1
        '
        Me.CtrLuanChuyen1.BackColor = System.Drawing.Color.Lavender
        Me.CtrLuanChuyen1.Conection = ""
        Me.CtrLuanChuyen1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CtrLuanChuyen1.Location = New System.Drawing.Point(0, 0)
        Me.CtrLuanChuyen1.MaDonViHanhChinh = "0"
        Me.CtrLuanChuyen1.Name = "CtrLuanChuyen1"
        Me.CtrLuanChuyen1.Size = New System.Drawing.Size(1009, 583)
        Me.CtrLuanChuyen1.TabIndex = 0
        Me.CtrLuanChuyen1.UserName = ""
        '
        'frmLuanChuyenHoSo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(1009, 583)
        Me.Controls.Add(Me.CtrLuanChuyen1)
        Me.IsMdiContainer = True
        Me.Name = "frmLuanChuyenHoSo"
        Me.Text = "frmLuanChuyenHoSo"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CtrLuanChuyen1 As prjQuyTrinhLuanChuyen.ctrLuanChuyen
End Class
