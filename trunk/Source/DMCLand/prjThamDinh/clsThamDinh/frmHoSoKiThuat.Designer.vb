﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHoSoKiThuat
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
        Me.CtrInHoSoKyThuat = New prjInHoSoKyThuat.CtrInHoSoKyThuat
        Me.SuspendLayout()
        '
        'CtrInHoSoKyThuat
        '
        Me.CtrInHoSoKyThuat.Conection = ""
        Me.CtrInHoSoKyThuat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CtrInHoSoKyThuat.Location = New System.Drawing.Point(0, 0)
        Me.CtrInHoSoKyThuat.MaHoSoCapGCN = ""
        Me.CtrInHoSoKyThuat.Name = "CtrInHoSoKyThuat"
        Me.CtrInHoSoKyThuat.Size = New System.Drawing.Size(790, 428)
        Me.CtrInHoSoKyThuat.TabIndex = 0
        '
        'frmHoSoKiThuat
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(790, 428)
        Me.Controls.Add(Me.CtrInHoSoKyThuat)
        Me.Name = "frmHoSoKiThuat"
        Me.Text = "Ho so ki thuat"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents CtrInHoSoKyThuat As prjInHoSoKyThuat.CtrInHoSoKyThuat
End Class
