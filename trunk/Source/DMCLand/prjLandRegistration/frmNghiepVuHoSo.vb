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


   
    'Private Sub frmNghiepVuHoSo_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
    '    Try
    '        If CtrlNghiepVuHoSo1.MaThuaDat <> "" Then
    '            Dim dlg As DialogResult = MessageBox.Show("Bạn muốn thoát nghiệp vụ hồ sơ với thửa đất hiện tại?", "DMCLand", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
    '            If dlg = DialogResult.Yes Then
    '                Dim con As String = GetConnection(bolKetNoiCSDL)
    '                Dim connection As New SqlConnection(con)
    '                Dim Cmd As New SqlCommand("spUpdateThuaDatDangThaoTac", connection)
    '                Cmd.CommandType = CommandType.StoredProcedure
    '                Dim Para As New SqlParameter
    '                Para = Cmd.Parameters.Add("ToBanDo", SqlDbType.NVarChar, 20)
    '                Para.Value = CtrlNghiepVuHoSo1.ToBanDo
    '                Para = Cmd.Parameters.Add("SoThua", SqlDbType.NVarChar, 20)
    '                Para.Value = CtrlNghiepVuHoSo1.SoHieuThua
    '                Para = Cmd.Parameters.Add("MaThuaDat", SqlDbType.Int)
    '                Para.Value = CtrlNghiepVuHoSo1.MaThuaDat
    '                Para = Cmd.Parameters.Add("InOut", SqlDbType.Int)
    '                Para.Value = 0
    '                Para = Cmd.Parameters.Add("MaDonViHanhChinh", SqlDbType.Int)
    '                Para.Value = Integer.Parse(CtrlNghiepVuHoSo1.MaDonViHanhChinh)
    '                connection.Open()
    '                Cmd.ExecuteNonQuery()
    '                connection.Close()
    '                strGlbMaHoSoCapGCN = ""
    '                strGlbMaThuaDat = ""
    '                CtrlNghiepVuHoSo1.MaHoSoCapGCN = ""
    '                CtrlNghiepVuHoSo1.ToBanDo = ""
    '                CtrlNghiepVuHoSo1.SoHieuThua = ""
    '                CtrlNghiepVuHoSo1.MaThuaDat = ""
    '                e.Cancel = False
    '            Else
    '                e.Cancel = True
    '            End If
    '        End If
    '    Catch ex As Exception
    '        MessageBox.Show(ex.ToString)
    '    End Try
    'End Sub
End Class