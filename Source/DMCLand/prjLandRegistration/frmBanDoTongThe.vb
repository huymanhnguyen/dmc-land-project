Imports System.Data.SqlClient
Public Class frmBanDoTongThe

    Private Sub frmBanDoTongThe_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Thiết lập chế độ hiện thị lớn nhất
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub CtrlTachThua_ChonHoSoTuThuaDat(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles CtrlTachThua.ChonHoSoTuThuaDat
        Dim strToBanDo As String = ""
        Dim strSoThua As String = ""
        Dim cls As New clsHoSoCapGCN
        Dim strCon As String = GetConnection(bolKetNoiCSDL)
        cls.Connection = strCon
        cls.ToBanDo = CtrlTachThua.ToBanDo
        cls.SoThua = CtrlTachThua.SoThua
        cls.MaThuaDat = CtrlTachThua.MaThuaDat
        cls.MaDonViHanhChinh = User.DonViHanhChinhHienThoi
        Dim dt As New DataTable
        Dim dtMaThuaDat As New DataTable
        cls.SelectMaHoSoCapGCN(dt)
        cls.SelectMaThuaDatInBanDo(dtMaThuaDat)
        If (dt.Rows.Count > 0) Then
            If dt.Rows(0).Item("MaThuaDat").ToString = "" Then
                MessageBox.Show("Kiểm tra dữ liệu hồ sơ " & dt.Rows(0).Item("MaHoSoCapGCN").ToString)
                Exit Sub
            End If
            frmMain.HienThiThongTinThuaDat(dt.Rows(0).Item("MaHoSoCapGCN").ToString, dt.Rows(0).Item("MaThuaDat").ToString)
            With frmNghiepVuHoSo.CtrlNghiepVuHoSo1.CtrlThongTinThuaTuNhien1
                .Connection = strCon
                .MaDonViHanhChinh = User.DonViHanhChinhHienThoi

            End With

            frmNghiepVuHoSo.CtrlNghiepVuHoSo1.CtrlThongTinThuaTuNhien1.ShowData(dt.Rows(0).Item("MaThuaDat").ToString)
            strGlbMaThuaDat = dt.Rows(0).Item("MaThuaDat")
            frmNghiepVuHoSo.BringToFront()

            'With dtMaThuaDat
            '    If .Rows.Count > 0 Then
            '        frmNghiepVuHoSo.Close()
            '        Dim frm As New frmNghiepVuHoSo
            '        frm.CtrlNghiepVuHoSo1.ToBanDo = .Rows(0).Item("MaThuaDat")
            '        frm.CtrlNghiepVuHoSo1.SoHieuThua = .Rows(0).Item("SoThua")
            '        frm.CtrlNghiepVuHoSo1.MaThuaDat = .Rows(0).Item("MaThuaDat")
            '        frm.CtrlNghiepVuHoSo1.DienTichTuNhien = .Rows(0).Item("DienTichTuNhien")
            '        strGlbMaThuaDat = .Rows(0).Item("MaThuaDat")

            '        With frm.CtrlNghiepVuHoSo1.CtrlThongTinThuaTuNhien1
            '            .Connection = strCon
            '        End With
            '        frm.CtrlNghiepVuHoSo1.ShowLandOriginalInformation()
            '        frm.CtrlNghiepVuHoSo1.activeTaskForm()
            '        frmMain.HienThiNghiepVu()
            '        frm.BringToFront()
            '    End If

            'End With
        Else
            With dtMaThuaDat
                frmNghiepVuHoSo.Close()
                Dim frm As New frmNghiepVuHoSo
                frm.CtrlNghiepVuHoSo1.ToBanDo = .Rows(0).Item("ToBanDo")
                frm.CtrlNghiepVuHoSo1.SoHieuThua = .Rows(0).Item("SoThua")
                frm.CtrlNghiepVuHoSo1.MaThuaDat = .Rows(0).Item("MaThuaDat")
                frm.CtrlNghiepVuHoSo1.DienTichTuNhien = .Rows(0).Item("DienTichTuNhien")
                strGlbMaThuaDat = .Rows(0).Item("MaThuaDat")

                With frm.CtrlNghiepVuHoSo1.CtrlThongTinThuaTuNhien1
                    .Connection = strCon
                    .MaDonViHanhChinh = User.DonViHanhChinhHienThoi
                End With
                frm.CtrlNghiepVuHoSo1.ShowLandOriginalInformation()
                frm.CtrlNghiepVuHoSo1.activeTaskForm()
                frmMain.HienThiNghiepVu()
                frm.BringToFront()
            End With
        End If
    End Sub
    Private Sub frmBanDoTongThe_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing
        'Dim dlg As DialogResult = MessageBox.Show("Bạn có muốn thoát khỏi chức năng tách ghép không?", "Warning", MessageBoxButtons.YesNo)
        'If dlg = DialogResult.Yes Then
        '    e.Cancel = False            '  Me.CtrlTachThua.SaveData()
        '    Me.CtrlTachThua.FormClosing()
        'Else
        '    e.Cancel = True
        'End If
        Try
            Dim dlg As DialogResult = MessageBox.Show("Bạn có muốn thoát khỏi chức năng tách ghép không?", "Warning", MessageBoxButtons.YesNo)
            If dlg = DialogResult.Yes Then
                If CtrlTachThua.KiemTraThuaDat = True Then
                    Dim con As String = GetConnection(bolKetNoiCSDL)
                    Dim connection As New SqlConnection(con)
                    Dim Cmd As New SqlCommand("spUpdateThuaDatDangThaoTac", connection)
                    Cmd.CommandType = CommandType.StoredProcedure

                    Dim Para As New SqlParameter
                    Para = Cmd.Parameters.Add("ToBanDo", SqlDbType.NVarChar, 20)
                    Para.Value = CtrlTachThua.ToBanDoTam
                    Para = Cmd.Parameters.Add("SoThua", SqlDbType.NVarChar, 20)
                    Para.Value = CtrlTachThua.SoThuaTam
                    Para = Cmd.Parameters.Add("MaThuaDat", SqlDbType.Int)
                    Para.Value = CtrlTachThua.MaThuaDatTam
                    Para = Cmd.Parameters.Add("InOut", SqlDbType.Int)
                    Para.Value = 0
                    Para = Cmd.Parameters.Add("MaDonViHanhChinh", SqlDbType.Int)
                    Para.Value = Integer.Parse(CtrlTachThua.MaDonViHanhChinh)
                    connection.Open()
                    Cmd.ExecuteNonQuery()
                    connection.Close()
                    e.Cancel = False
                    Me.CtrlTachThua.FormClosing()
                Else
                    e.Cancel = False
                    Me.CtrlTachThua.FormClosing()
                End If
            Else : e.Cancel = True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    
End Class