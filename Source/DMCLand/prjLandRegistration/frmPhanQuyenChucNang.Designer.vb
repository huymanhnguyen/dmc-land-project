﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPhanQuyenChucNang
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
        Me.CtrPhanQuyenQuyTrinhChucNang1 = New prjPhanQuyenQuyTrinhChucNang.ctrPhanQuyenQuyTrinhChucNang
        Me.SuspendLayout()
        '
        'CtrPhanQuyenQuyTrinhChucNang1
        '
        Me.CtrPhanQuyenQuyTrinhChucNang1.BackColor = System.Drawing.Color.Lavender
        Me.CtrPhanQuyenQuyTrinhChucNang1.Connection = Nothing
        Me.CtrPhanQuyenQuyTrinhChucNang1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CtrPhanQuyenQuyTrinhChucNang1.Location = New System.Drawing.Point(0, 0)
        Me.CtrPhanQuyenQuyTrinhChucNang1.MaUser = Nothing
        Me.CtrPhanQuyenQuyTrinhChucNang1.Name = "CtrPhanQuyenQuyTrinhChucNang1"
        Me.CtrPhanQuyenQuyTrinhChucNang1.Size = New System.Drawing.Size(804, 510)
        Me.CtrPhanQuyenQuyTrinhChucNang1.TabIndex = 0
        '
        'frmPhanQuyenChucNang
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(804, 510)
        Me.Controls.Add(Me.CtrPhanQuyenQuyTrinhChucNang1)
        Me.Name = "frmPhanQuyenChucNang"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmPhanQuyenChucNang"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CtrPhanQuyenQuyTrinhChucNang1 As prjPhanQuyenQuyTrinhChucNang.ctrPhanQuyenQuyTrinhChucNang
End Class