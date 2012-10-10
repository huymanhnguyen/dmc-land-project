Imports System.Data.SqlClient
Imports System.Net

Public Class frmDanhSachDVHC

    Private Sub frmDanhSachDVHC_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        User.DonViHanhChinhHienThoi = UcListDVHC1.Get_CurrDVHC
        frmMain.Show()
        If UcListDVHC1.Get_CurrDVHC = 0 Then
            Return
        End If
        If UcListDVHC1.TrangThai = "0" Then
            Return
        End If
        If User.DonViHanhChinhHienThoi <> 0 Then
            Dim cmd As New SqlClient.SqlCommand("select ten from tbltudiendonvihanhchinh where madonvihanhchinh='" & User.DonViHanhChinhHienThoi.ToString & "'", User.SQLConnection)
            If User.SQLConnection.State <> ConnectionState.Open Then
                User.SQLConnection.Open()
            End If
            cmd.ExecuteNonQuery()
            Dim da As New SqlClient.SqlDataAdapter(cmd)
            Dim ds As New DataSet
            da.Fill(ds, "result")
            'Gan gia tri cho bien Ma don vi hanh chinh hien thoi dung chung
            intGlobalMaDonViHanhChinh = User.DonViHanhChinhHienThoi
            'Gan gia tri cho bien Ten don vi hanh chinh hien thoi
            strGlobalTenDonViHanhChinh = ds.Tables("result").Rows(0).Item(0).ToString
            With frmMain.staTrangThai.Items("DonViHanhChinh")
                'Hien thi Ten Don vi hanh chinh len thanh trang thai
                .Text = "   Đơn vị hành chính: " _
                & strGlobalTenDonViHanhChinh.ToUpper
                'Thiet lap mau hien thi
                .ForeColor = Color.Black
            End With
            ' ''chon don vi lam viec hien thoi
            ''Dim cls As New clsHoSoCapGCN
            ''cls.Connection = GetConnection(bolKetNoiCSDL)
            ''cls.TenMayClient = IpAdd(0).ToString
            ''cls.ThaoTacDonViHanhChinhHienThoi(UcListDVHC1.Get_CurrDVHC.ToString)
            '=================================
            frmTimKiem.CrtTimKiemHoSoThuaDat1.MaDonViHanhChinh = User.DonViHanhChinhHienThoi
            cmd.Dispose()
            '   frmMain.RemoveItemsOnMenuHeThong()
            frmMain.HienThi10ThuaDatMoiThaoTac(User.DonViHanhChinhHienThoi)
        

            If UcListDVHC1.TrangThai = "1" Then
                frmNghiepVuHoSo.CtrlNghiepVuHoSo1.MaHoSoCapGCN = ""
                frmNghiepVuHoSo.CtrlNghiepVuHoSo1.MaThuaDat = ""
                frmNghiepVuHoSo.CtrlNghiepVuHoSo1.ShowProfileInformation()
                frmBanDoTongThe.Close()
            End If

            Dim frm As New frmCanhBaoQuyTrinh
            With frm.CtrCanhBaoQuyTrinhGiaoViec1
                .AddColumnsTimKiem()
                .Conection = GetConnection(bolKetNoiCSDL)
                .MaDonViHanhChinh = User.DonViHanhChinhHienThoi
                .LoadTuDienLuanChuyenHoSo()
                .showData()
                .HienThiGhiChuMau()
                If .CountBanGhi > 0 Then
                    frm.Show()
                Else
                    frm.Close()
                End If

            End With

        Else
            frmMain.staTrangThai.Items("DonViHanhChinh").Text = "   Chưa chọn đơn vị hành chính! "
        End If
    End Sub
    Private Sub frmDanhSachDVHC_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        UcListDVHC1.Get_ArrDVHC = User.DonViHanhChinh   'frmDangNhap.UcKetNoi1.Get_MaDVHC ' User.Get_MaDVHC
        UcListDVHC1.Get_MaQuyen = User.MaQuyen 'frmDangNhap.UcKetNoi1.Get_MaQuyen ' User.Get_MaQuyen
        UcListDVHC1.Get_SqlCon = User.SQLConnection
        UcListDVHC1.Get_CurrDVHC = User.DonViHanhChinhHienThoi
        UcListDVHC1.hienthi()
    End Sub

End Class