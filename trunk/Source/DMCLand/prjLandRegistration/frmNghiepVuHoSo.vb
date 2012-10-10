Imports System.Data.SqlClient
Public Class frmNghiepVuHoSo

    Private Sub frmNghiepVuHoSo_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed


    End Sub
    Private Sub frmNghiepVuHoSo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub frmNghiepVuHoSo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyValue
            Case Keys.Escape

            Case Keys.Enter

            Case Keys.F2
                MessageBox.Show("them")
            Case Keys.F3
                MessageBox.Show("sua")
            Case Keys.F4
                MessageBox.Show("xoa")
            Case Keys.F5
                MessageBox.Show("Lam tuoi")
            Case Keys.F
        End Select
    End Sub


   
End Class