Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports DMC.Land.ThongTinThuaKeKhai
Imports Microsoft.Office.Interop.Word
Imports Microsoft.Office.Interop
Imports DMC.Land.TimKiem
Imports System.IO
Imports System.Xml

Public Class frmMain
    Dim cls_BaoCaoNoiBoChuSuDung As New clsBaoCaoNoiBo
    Dim cls_BaoCaoNoiBoNhaO As New clsBaoCaoNoiBo
    Dim cls_BaoCaoNoiBoThuaDat As New clsBaoCaoNoiBo
    Dim cls_BaoCaoNoiBoNghiaVuTaiChinh_TranhChap_NguoiKyGCN As New clsBaoCaoNoiBo
    Public OW As Word.Application
    Public DOC As Word.Document
    Dim ThuaDat(11) As ToolStripMenuItem
    Dim Thoat As ToolStripMenuItem
    Dim i As Integer = 0
    Private strDuoiWord As String = ""
    Private Sub FrmMain_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If blnGlobalDangNhap = True Then
            User.LogOut()
            strGlbMaThuaDat = ""
            DeleteProcess()
        End If
    End Sub

    Private Sub FrmMain_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        Select Case e.KeyValue
            'Case Keys.F2
            '    frmNghiepVuHoSo.TimKiem()
            'Case Keys.F3
            '    frmNghiepVuHoSo.HoSoKeKhai()
            'Case Keys.F4
            '    frmNghiepVuHoSo.ThamDinh()
            'Case Keys.F5
            '    frmNghiepVuHoSo.PheDuyet()
            'Case Keys.F6
            '    frmNghiepVuHoSo.CapGiayChungNhan()
            Case Keys.F7
                frmDanhSachDVHC.Show()
            Case Keys.F8
                mnuThongTinTaiKhoan_Click(sender, e)
            Case Keys.Alt + Keys.X
                mnuThongTinTaiKhoan_Click(sender, e)
        End Select
    End Sub

    Private Sub FrmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Ẩn mọi chức năng
        ActiveFunc(False)
        '20100208
        'Cần xem lại xem có cần thiết dùng hàm sau không 
        'HienThiNghiepVu(False)
        'Hiển thị Form đăng nhập
        bolKetNoiCSDL = True
        Me.Text = "DMCLand - @CSDL Phuong"
        Dim DangNhap As New frmDangNhap
        DangNhap.ShowDialog()
        If User.UserName <> "" And mnuHeThongDangNhap.Text = "Đăng nhập" Then
            'Nếu đăng nhập thành công
            mnuHeThongDangNhap.Text = "Đăng xuất"
            ActiveFunc()
            HienThiNghiepVu()
            'Thiết đặt trạng thái hiển thị ban đầu
            strGlbMaThuaDat = ""
            mnuHienThiThongTinThuaTuNhien.Checked = False
        Else
            'Nếu đăng nhập thất bại
            mnuHeThongDangNhap.Text = "Đăng nhập"
            ActiveFunc(False)
            HienThiNghiepVu(False)
        End If
        mnuHeThongThoat.Visible = True
        'HienThi10ThuaDatMoiThaoTac()
        ToolStripSeparator2.Visible = True
        ToolStripSeparator3.Visible = True
        DeleteProcess()
    End Sub

    ' Hai hàm này mới thêm vào, để hiện thị chức năng
    ' theo sự phân quyền bên quản trị

    Private Sub HienThiChucNangTrenMenu()
        'Dim SqlCon As New SqlConnection("Server = DMC-SVR\Map; Database = georgetown; Uid = sa; Pwd = 1")
        Dim SqlCom As New SqlCommand("ProcLayChucNangTheoNguoiDung", User.SQLConnection)
        SqlCom.CommandType = CommandType.StoredProcedure
        SqlCom.Parameters.Add("@UserName", SqlDbType.NVarChar)
        SqlCom.Parameters(0).Value = User.UserName
        Dim SqlDA As New SqlDataAdapter(SqlCom)
        Dim BangQuyen As New DataTable
        Try
            SqlDA.Fill(BangQuyen)
            For ii As Integer = 0 To mnuCapGCN.DropDownItems.Count - 1
                mnuCapGCN.DropDownItems(ii).Visible = False
            Next
            If BangQuyen.Rows.Count > 0 Then
                For i As Integer = 0 To BangQuyen.Rows.Count - 1
                    For j As Integer = 0 To mnuCapGCN.DropDownItems.Count - 1
                        If mnuCapGCN.DropDownItems(j).Text = BangQuyen.Rows(i).Item(0).ToString Then
                            mnuCapGCN.DropDownItems(j).Visible = True
                        End If
                    Next

                Next

            End If

        Catch ex As Exception
            'MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub DieuChinhControl()
        frmNghiepVuHoSo.CtrlNghiepVuHoSo1.DieuChinhControl()
    End Sub

    Public Sub HienThi10ThuaDatMoiThaoTac(ByVal MaDonViHanhChinh As Integer)
        RemoveItemsOnMenuHeThong()
        Dim DtTable As New DataTable
        Dim Rowcount As Integer = 0
        Dim con As String = GetConnection(bolKetNoiCSDL)
        Dim connection As New SqlConnection(con)
        Dim cmd As New SqlCommand("spSelect10ThuaDatMoiThaoTac", connection)
        cmd.CommandType = CommandType.StoredProcedure
        Dim Para As New SqlParameter
        Dim Para1 As New SqlParameter
        Para = cmd.Parameters.Add("MaDonViHanhChinh", SqlDbType.Int)
        Para.Value = Integer.Parse(MaDonViHanhChinh)
        
        Dim sqlDataAdapter As New SqlDataAdapter(cmd)
        'Điền dữ liệu vào đối tượng DataTable
        sqlDataAdapter.Fill(DtTable)
        Rowcount = DtTable.Rows.Count
        For Me.i = 0 To Rowcount - 1
            ThuaDat(i) = New ToolStripMenuItem()
            ThuaDat(i).Text = DtTable.Rows(i).Item("MaHoSoCapGCN").ToString
            ThuaDat(i).Name = (i + 1) & ":  Thửa đất: " & DtTable.Rows(i).Item("SoThua") & "/" & DtTable.Rows(i).Item("ToBanDo") & " - Diện tích:" & DtTable.Rows(i).Item("DienTich") & "(m2) - Địa chỉ: " & DtTable.Rows(i).Item("DiaChiDat") & "-" & DtTable.Rows(i).Item("MaHoSoCapGCN").ToString & "-" & DtTable.Rows(i).Item("MaThuaDat").ToString
            'mnuHeThong.DropDownItems.Insert(7, ThuaDat(i))
            'MenuItemHienThi10ThuaDatMoiThaoTac.DropDownItems.Add(ThuaDat(i).Name, Nothing, AddressOf MenuItemClickHandler)
            mnuHeThong.DropDownItems.Add(ThuaDat(i).Name, Nothing, AddressOf MenuItemClickHandler)
        Next
        mnuHeThong.DropDownItems.Add(ToolStripSeparator1)
        ThuaDat(i + 1) = New ToolStripMenuItem()
        ThuaDat(i + 1).Name = "Thoát"
        mnuHeThong.DropDownItems.Add(ThuaDat(i + 1).Name, Nothing, AddressOf XuLySuKienClickNutThoat)
        If Rowcount = 0 Then
            ToolStripSeparator1.Visible = False
        Else
            ToolStripSeparator1.Visible = True
        End If

        Me.ToolStripSeparator2.Visible = True
        Me.ToolStripSeparator3.Visible = True
        Me.mnuHeThongThoat.Visible = False
    End Sub
    Private Sub XuLySuKienClickNutThoat(ByVal sender As Object, ByVal e As EventArgs)
        Global.System.Windows.Forms.Application.Exit()
    End Sub
    Private Sub MenuItemClickHandler(ByVal sender As Object, ByVal e As EventArgs)
        Dim clickedMenuItem As ToolStripMenuItem = DirectCast(sender, ToolStripMenuItem)
        Dim a As String = clickedMenuItem.Text
        Dim MaHoSoCapGCN As String = ""
        Dim MaThuaDat As Integer
        Dim index As Integer
        Dim mang() As String = {}
        mang = a.Split("-")
        index = a.LastIndexOf("-")
        MaThuaDat = mang(mang.Length - 1)
        MaHoSoCapGCN = mang(mang.Length - 2)
        ' lay thong tin MaHoSo 
        '  MaHoSoCapGCN = a.Substring(index + 1)
        If MaHoSoCapGCN <> "" Then
            Dim cls As New clsHoSoCapGCN
            cls.Connection = GetConnection(bolKetNoiCSDL)
            HienThiThongTinThuaDat(MaHoSoCapGCN, MaThuaDat)
            cls.TrangThaiMoiNhatCuaHoSo(MaHoSoCapGCN, MaThuaDat)
        End If
        'If a(1) = "0" Then
        '    For i As Integer = 4 To a.Length - 1
        '        If a(i) <> " " Then
        '            MaHoSoCapGCN = MaHoSoCapGCN & a(i)
        '        ElseIf a(i) = " " Then
        '            Exit For
        '        End If
        '    Next
        '    HienThiThongTinThuaDat(MaHoSoCapGCN, MaThuaDat)
        'Else
        '    For i As Integer = 3 To a.Length - 1
        '        If a(i) <> " " Then
        '            MaHoSoCapGCN = MaHoSoCapGCN & a(i)
        '        ElseIf a(i) = " " Then
        '            Exit For
        '        End If
        '    Next
        '    HienThiThongTinThuaDat(MaHoSoCapGCN, MaThuaDat)
        'End If
    End Sub

    Public Sub HienThiThongTinThuaDat(ByVal strMaHoSoCapGCN As String, ByVal strMaThuaDat As Integer)

        With frmNghiepVuHoSo.CtrlNghiepVuHoSo1
            If (strMaHoSoCapGCN <> "") Then
                TaoFileMaHoSoCapGCN(strMaHoSoCapGCN)

                'Trường hợp Mã Thửa đất khác rỗng (Có thửa đất)
                'Thì hiển thị thông tin thửa đất lến 2 điều khiển:
                '1. THÔNG TIN THỬA TỰ NHIÊN (CỦA SỔ CHỨC NĂNG)
                '2. THÔNG TIN THỬA KÊ KHAI (CỬA SỔ HỒ SƠ CẤP GCN)
                .MaThuaDat = strMaThuaDat
                strGlbMaThuaDat = strMaThuaDat
                .MaHoSoCapGCN = strMaHoSoCapGCN
                .ShowLandOriginalInformation()

                'KhoiTaoGiaTri()
                'THIẾT LẬP TRẠNG THÁI  BAN ĐẦU CHO CÁC ĐIỀU KHIỂN
                'VỚI ĐIỀU KHIỂN NÀO CÓ GRID THÌ XÓA DỮ LIỆU TRÊN GRID ĐÓ
                'NOTE: KIỂM TRA LẠI ĐOẠN CODE NÀY XEM CÓ THỂ XỬ LÝ NGAY TRONG ĐIỀU
                'KHIỂN
                'Thông tin tiếp nhận Hồ sơ
                With .CtrlThongTinTiepNhanHoSo
                    .TrangThaiBanDau()
                End With
                With .CtrlHoSoKeKhai
                    .CtrlThongTinThuaKeKhai.TrangThaiBanDau()
                    .CtrlTaiLieuKemTheo.TrangThaiBanDau(True)
                End With
                With .CtrlXetDuyetCapCoSo
                    .CtrlThongTinXetDuyet.TrangThaiBanDau()
                    .CtrlHoiDongXetDuyet.TrangThaiBanDau()
                    .CtrlThongTinBoSung.TrangThaiBanDau(True)
                End With
                With .CtrlThamDinh
                    .CtrlYeuCauBoXungThamDinh.TrangThaiBanDau(True)
                End With
                .CtrlPheDuyet.TrangThaiBanDau()
                With .CtrlThongTinCapGCN
                    '.TrangThaiBanDau()
                End With

                'HIỂN THỊ DỮ LIỆU LÊN CÁC ĐIỀU KHIỂN
                'TRONG TRƯỜNG HỢP THỬA ĐẤT CÓ HÒ SƠ
                'NOTE: CẦN KIỂM TRA LẠI XEM CÓ TỐI ƯU ĐƯỢC KHÔNG
                .ShowProfileInformation()
            End If
        End With
    End Sub
    Public Sub HienThiNghiepVu(Optional ByVal blnHienThi As Boolean = True) 'ByVal sender As Object, ByVal e As EventArgs)
        With frmNghiepVuHoSo
            If blnHienThi Then
                'Form Nghiệp vụ hồ sơ cấp GCN nhận Form Main là MDIForm
                .MdiParent = Me
                .WindowState = FormWindowState.Maximized
                'Hiển thị Form nghiệp vụ hồ sơ cấp GCN
                .Show()
                'Hiển thị nội dung thông tin cấp GCN trong Form nghiệp vụ 
                With .CtrlNghiepVuHoSo1
                    '' '' ''If (frmBanDoTongThe.CtrlTachThua.MaThuaDat IsNot Nothing) Then
                    '' '' ''    If (frmBanDoTongThe.CtrlTachThua.MaThuaDat <> "") And (frmBanDoTongThe.CtrlTachThua.MaThuaDat <> "0") Then
                    '' '' ''        strGlbMaThuaDat = frmBanDoTongThe.CtrlTachThua.MaThuaDat
                    '' '' ''        strGlbMaHoSoCapGCN = frmBanDoTongThe.CtrlTachThua.MaHoSoCapGCN
                    '' '' ''        .MaHoSoCapGCN = strGlbMaHoSoCapGCN
                    '' '' ''    End If
                    '' '' ''End If
                    .MaThuaDat = strGlbMaThuaDat
                    .ShowLandOriginalInformation()
                End With
            Else
                .Hide()
            End If
        End With
    End Sub

    Private Sub StatusBarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mnuHienThiThanhTrangThai.Click
        Me.staTrangThai.Visible = Me.mnuHienThiThanhTrangThai.Checked
    End Sub

    Private Sub mnuHeThongThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Global.System.Windows.Forms.Application.Exit()
        'Me.Close()
    End Sub

    Private Sub mnuHeThongKetNoiDuLieu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub mnuHeThongBangMa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuHeThongBangMa.Click
        'With frmBangMa
        '    .MaximizeBox = False
        '    .MinimizeBox = False
        '    'Gán chuỗi kết nối cơ sở dữ liệu cho điều khiển bảng mã
        '    .CtrlBangMa.Connection = GetConnection(bolKetNoiCSDL)
        '    .ShowDialog()
        'End With
    End Sub

    Private Sub mnuHeThongDangNhap_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuHeThongDangNhap.Click
        If mnuHeThongDangNhap.Text = "Đăng xuất" Then
            mnuHeThongDangNhap.Text = "Đăng nhập"
            User.UserName = ""
            User.DonViHanhChinhHienThoi = 0
            strGlbMaThuaDat = ""
            ActiveFunc(False)
            HienThiNghiepVu(False)
            RemoveItemsOnMenuHeThong()
            For Each f As Form In Me.MdiChildren
                f.Close()
            Next
        Else
            'mnuHeThong.DropDownItems.Remove(Thoat)
            FrmMain_Load(sender, e)
            'mnuHeThong.DropDownItems.Remove(Thoat)
        End If


        ''Dich
        'If blnGlobalDangNhap = False Then
        '    Dim f As New frmDangNhap
        '    f.Text = "Dang nhap"
        '    f.ShowDialog()
        'Else
        '    User.LogOut()
        '    With Me
        '        mnuHeThongDangNhap.Text = "Đăng nhập"
        '    End With
        '    blnGlobalDangNhap = False
        'End If
    End Sub
    Public Sub RemoveItemsOnMenuHeThong()
        Dim i As Integer = 0
        For j As Integer = 7 To mnuHeThong.DropDownItems.Count - 1 - i
            mnuHeThong.DropDownItems.RemoveAt(7)
            i = i + 1
        Next
        ToolStripSeparator2.Visible = False
        ToolStripSeparator3.Visible = False
        mnuHeThongThoat.Visible = True
        'Thoat = New ToolStripMenuItem
        'Thoat.Name = "Thoát"
        'mnuHeThong.DropDownItems.Add(Thoat.Name, Nothing, AddressOf XuLySuKienClickNutThoat)
    End Sub
    Public Sub ActiveFunc(Optional ByVal boolAccept As Boolean = True)
        If boolAccept Then
            mnuCapGCN.Visible = True
            mnuTrangThaiHienThi.Visible = True
            mnuHienThi.Visible = True
            mnuThongTinNguoiDung.Visible = True
            mnuHeThongBangMa.Visible = True
            mnuHeThongChonDVHC.Visible = True
            'MenuItemHienThi10ThuaDatMoiThaoTac.Visible = True
            'ToolStripMenuItem3.Visible = True
            toolSoanHoSoKyThuat.Visible = True
            mnuBaoCao.Visible = True
        Else
            mnuCapGCN.Visible = False
            mnuTrangThaiHienThi.Visible = False
            mnuHienThi.Visible = False
            mnuThongTinNguoiDung.Visible = False
            mnuHeThongBangMa.Visible = False
            mnuHeThongChonDVHC.Visible = False
            'MenuItemHienThi10ThuaDatMoiThaoTac.Visible = False
            'ToolStripMenuItem3.Visible = False
            toolSoanHoSoKyThuat.Visible = False
            mnuBaoCao.Visible = False
            'mnuHeThong.DropDownItems.Remove(Thoat)
        End If

    End Sub


    Private Sub mnuHeThongQuanTriLog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ''Dich
        'Dim f As New frmLog
        'f.Text = "Quan ly Log"
        'f.ShowDialog()
        'Chức năng này sẽ được add vào sau
        'Hiện tại chưa Add Project Log vào Solution này
    End Sub

    Private Sub mnuHeThongChonDVHC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuHeThongChonDVHC.Click
        frmDanhSachDVHC.Show()
      

    End Sub

    Public Sub HienThiBaoDo(Optional ByVal blnHienThi As Boolean = True)
        'Hiển thị bản đồ thửa đất
        If intGlobalMaDonViHanhChinh = 0 Then
            frmDanhSachDVHC.ShowDialog()
        End If
        If intGlobalMaDonViHanhChinh = 0 Then
            Return
        End If
        If User.DonViHanhChinhHienThoi.ToString = "0" Then
            Return
        End If
        If (blnHienThi) Then
            Dim frm As Form
            Dim Count As Integer
            For Each frm In Me.MdiChildren
                If frm.Name = "frmBanDoTongThe" Then
                    Count = Count + 1
                End If
            Next
            If Count > 0 Then
                frmBanDoTongThe.BringToFront()
                Return
            End If
            With frmBanDoTongThe
                'Hiển thị Form bản đồ tổng thể
                .MdiParent = Me
                .WindowState = FormWindowState.Maximized
                'Xác nhận chuỗi kết nối cơ sở dữ liệu
                .CtrlTachThua.Connection = GetConnection(bolKetNoiCSDL)
                .CtrlTachThua.MaDonViHanhChinh = User.DonViHanhChinhHienThoi

                .Show()
                'HIỂN THỊ THÔNG TIN NỘI DUNG BẢN ĐỒ (NẾU CÓ)

                'Xác nhận Mã thửa đất 
                strGlbMaThuaDat = frmNghiepVuHoSo.CtrlNghiepVuHoSo1.MaThuaDat
                .CtrlTachThua.MaThuaDat = strGlbMaThuaDat  'frmNghiepVuHoSo.CtrlNghiepVuHoSo1.MaThuaDat
                'Xác nhận Mã đơn vị hành chính
                .CtrlTachThua.MaDonViHanhChinh = User.DonViHanhChinhHienThoi

                'SAU NÀY SẼ BỎ PHẦN NÀY
                'Xác nhận Mã Hồ sơ cấp GCN
                .CtrlTachThua.MaHoSoCapGCN = frmNghiepVuHoSo.CtrlNghiepVuHoSo1.MaHoSoCapGCN


                'HIỂN THỊ THÔNG TIN BẢN ĐỒ TỔNG THỂ (NHÀ, ĐẤT)
                'Kiểm tra xem bản đồ đã từng được hiển thị chưa
                'Nếu chưa hiển thị thì hiển thị lên, ngược lại không cần hiển thị lại
                'If (Not (.CtrlTachThua.MapShowed)) Then
                Dim strTenBangDVHC As String = ThaoTacPhuongHienThoi(User.DonViHanhChinhHienThoi)

                .CtrlTachThua.HienThiBanDoTongThe(strTenBangDVHC & "tblDLieuKGianThuaDat", "Đất", strTenBangDVHC & "NHA", "Nhà", strTenBangDVHC & "tblDLieuKGianQuiHoach", "Qui Hoạch")
                .CtrlTachThua.TenBangDat = strTenBangDVHC & "tblDLieuKGianThuaDat"
                '.CtrlTachThua.MapShowed = True
                'End If
                If (.CtrlTachThua.MaThuaDat IsNot Nothing) Then
                    'CẦN KIỂM TRA LẠI VÀ TỐI ƯU HÓA ĐOẠN CODE NÀY
                    If (.CtrlTachThua.MaThuaDat <> "0") Then
                        'Hiển thị thửa đất được lựa chọn 
                        .CtrlTachThua.HienThiThuaDat("Đất")
                    End If
                End If
            End With
        ElseIf (blnHienThi = False) Then
            'Ẩn Form bản đồ tổng thể
            frmBanDoTongThe.Hide()
        End If
    End Sub

    Private Sub mnuTrangThaiHienThi_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuTrangThaiHienThi.Click
        'If mnuTrangThaiHienThi.Text = "Hiển thị bản đồ" Then
        '    With Me
        '        'Ẩn Form chức năng và Form nghiệp vụ
        '        .HienThiNghiepVu(False)
        '        'Hiện Form bản đồ tổng thể
        '        .HienThiBaoDo()
        '    End With
        '    'Thay đổi nhãn 
        '    mnuTrangThaiHienThi.Text = "Hiển thị hồ sơ"
        'Else
        '    With Me
        '        'Hiện Form chức năng và Form nghiệp vụ
        '        .HienThiNghiepVu()
        '        'Ẩn Form bản đồ tổng thể
        '        .HienThiBaoDo(False)
        '    End With
        '    'Thay đổi nhãn 
        '    mnuTrangThaiHienThi.Text = "Hiển thị bản đồ"
        'End If
    End Sub

    Private Sub mnuThongTinTaiKhoan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuThongTinTaiKhoan.Click
        Dim fTaiKhoanNguoiDung As New frmTaiKhoanNguoiDung
        With fTaiKhoanNguoiDung.UcTaiKhoanNguoiDung1
            .Connection = GetConnection(bolKetNoiCSDL)
            .ucTaiKhoanNguoiDungConnect()
            .strTenTruyCap = User.UserName
            .HienThiThongTin()
        End With
        fTaiKhoanNguoiDung.ShowDialog()
    End Sub

    Private Sub mnuCapGCNThamDinh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCapGCNThamDinh.Click
        'frmNghiepVuHoSo.ThamDinh()
    End Sub

    Private Sub mnuCapGCNPheDuyet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCapGCNPheDuyet.Click
        'frmNghiepVuHoSo.PheDuyet()
    End Sub

    Private Sub mnuCapGCNCapGCN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCapGCNCapGCN.Click
        'frmNghiepVuHoSo.CapGiayChungNhan()
    End Sub

    Private Sub mnuCapGCNXetDuyetCapCoSo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCapGCNXetDuyetCapCoSo.Click
        'frmNghiepVuHoSo.XetDuyetCapCoSo()
    End Sub

    Private Sub mnuCapGCNHoSoKeKhai_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCapGCNHoSoKeKhai.Click
        'frmNghiepVuHoSo.HoSoKeKhai()
    End Sub

    'Private Sub mnuSoanHoSoKiThuat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '    'If Me.ActiveMdiChild.Name.Length = 0 Then
    '    '    Me.ActiveMdiChild.Hide()
    '    'End If
    '    If intGlobalMaDonViHanhChinh = 0 Then
    '        frmDanhSachDVHC.ShowDialog()
    '    End If
    '    If intGlobalMaDonViHanhChinh = 0 Then
    '        Return
    '    End If
    '    If User.DonViHanhChinhHienThoi.ToString = "0" Then
    '        Return
    '    End If
    '    If frmNghiepVuHoSo.CtrlNghiepVuHoSo1.MaHoSoCapGCN = "" Then
    '        Return
    '    End If
    '    Try
    '        Dim MaHoSo As Long
    '        Dim myfrmSoanHS As New frmSoanHoSo
    '        myfrmSoanHS.MdiParent = Me
    '        With myfrmSoanHS.CtrSoanHS1
    '            .SererName = strGlobalServerName
    '            .DatabaseName = strGlobalDatabaseName
    '            .UID = strGlobalUserID
    '            .Upass = strGlobalUserPassword
    '            MaHoSo = Convert.ToInt64(frmNghiepVuHoSo.CtrlNghiepVuHoSo1.MaHoSoCapGCN)
    '            .HoSoCapGCN = MaHoSo
    '            .MaDonViHanhChinh = intGlobalMaDonViHanhChinh.ToString()

    '            Dim strTenBangDVHC As String = ThaoTacPhuongHienThoi(User.DonViHanhChinhHienThoi)
    '            .tabNha = strTenBangDVHC & "Nha"
    '            .tabBanDo = strTenBangDVHC & "tblDLieuKGianThuaDat"
    '            .tabSoanHoSo = strTenBangDVHC & "TBLSOANHOSOTHUADAT"
    '            .LoadForm()

    '        End With
    '        myfrmSoanHS.Show()
    '    Catch ex As Exception
    '        System.Windows.Forms.MessageBox.Show(Me, "Lỗi mở chức năng soạn Sơ đồ Nhà, đất", "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub

    Private Sub mnuTaoMoiHoSo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuTaoMoiHoSo.Click

    End Sub

    

    Private Sub mnuTaoMoiHoSoCoBanDo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuTaoMoiHoSoCoBanDo.Click
        If (strGlbMaThuaDat <> "") Then
            If (System.Windows.Forms.MessageBox.Show("Bạn thực sự muốn tạo Hồ sơ cấp GCN MỚI của thửa đất " & strGlbMaThuaDat.ToUpper & " không?", "DMCLand", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = System.Windows.Forms.DialogResult.Yes) Then
                frmNghiepVuHoSo.CtrlNghiepVuHoSo1.TaoHoSoCapGCNMoiDaCoThongTinKhongGianThuaDat()
            End If
        Else
            System.Windows.Forms.MessageBox.Show("Hãy chọn thửa đất trước khi tạo mới hồ sơ !!!", "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub mnuTaoMoiHoSoKhongCoBanDo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuTaoMoiHoSoKhongCoBanDo.Click
        If (System.Windows.Forms.MessageBox.Show("Bạn thực sự muốn tạo Hồ sơ cấp GCN mới khi CHƯA có thông tin BẢN ĐỒ thửa đất?", "DMCLand", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = System.Windows.Forms.DialogResult.Yes) Then

            frmNghiepVuHoSo.CtrlNghiepVuHoSo1.TaoHoSoCapGCNMoiChuaCoThongTinKhongGianThuaDat()
        End If
    End Sub

    Private Sub mnuBaoCaoToTrinhQuyetDinh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuBaoCaoToTrinhQuyetDinh.Click
        Try
            If frmNghiepVuHoSo.CtrlNghiepVuHoSo1.MaHoSoCapGCN = "" Then
                Return
            End If
            Dim frm As New frmTinToTrinhQuyetDinh
            With frm.CtrToTrinhQuyetDinh1
                .Connection = GetConnection(bolKetNoiCSDL)
                .MaHoSoCapGCN = Convert.ToInt64(frmNghiepVuHoSo.CtrlNghiepVuHoSo1.MaHoSoCapGCN)
                .MaDVHC = intGlobalMaDonViHanhChinh.ToString()
                frm.StartPosition = FormStartPosition.CenterScreen
                frm.ShowDialog()
            End With
        Catch ex As Exception
            MessageBox.Show("Lỗi báo cáo tờ trình quyết định !")
        End Try
    End Sub

    Private Sub mnuBaoCaoketQuaThamDinh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuBaoCaoKetQuaThamDinh.Click
        Try
            If frmNghiepVuHoSo.CtrlNghiepVuHoSo1.MaHoSoCapGCN = "" Then
                Return
            End If
            Dim frm As New frmBaoCaoKetQuaThamDinh
            With frm.CtrInBaoCaoKetQuaThamDinh1
                .Connection = GetConnection(bolKetNoiCSDL)
                .MaHoSoCapGCN = Convert.ToInt64(frmNghiepVuHoSo.CtrlNghiepVuHoSo1.MaHoSoCapGCN)
                .MaDVHC = intGlobalMaDonViHanhChinh.ToString()
                .ctrInBaoCaoKetQuaThamDinh_Load()
                frm.StartPosition = FormStartPosition.CenterScreen
                frm.WindowState = FormWindowState.Maximized
                frm.ShowDialog()
            End With
        Catch ex As Exception
            MessageBox.Show("Lỗi báo cáo kết quả thẩm định !")
        End Try
    End Sub

    Private Sub toolLapToTrinh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolLapToTrinh.Click
        Try
            If frmNghiepVuHoSo.CtrlNghiepVuHoSo1.MaHoSoCapGCN = "" Then
                Return
            End If
            Dim frm As New frmLapDanhSachToTrinh
            With frm.CtrToTrinh1
                .Conection = GetConnection(bolKetNoiCSDL)
                .MaHoSoCapGCN = Convert.ToInt64(frmNghiepVuHoSo.CtrlNghiepVuHoSo1.MaHoSoCapGCN)
                .MaDVHC = intGlobalMaDonViHanhChinh.ToString()
                .ctrToTrinh_Load()
                frm.ShowDialog()
            End With
        Catch ex As Exception
            MessageBox.Show("Lỗi báo cáo lập tờ trình !", "DMCLand")
        End Try
    End Sub

    Private Sub toolInPhieu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolInPhieu.Click
        Try
            If frmNghiepVuHoSo.CtrlNghiepVuHoSo1.MaHoSoCapGCN = "" Then
                Return
            End If
            Dim frm As New frmInDanhSachToTrinh
            With frm.CtrInToTrinh1
                .Conection = GetConnection(bolKetNoiCSDL)
                .MaHoSoCapGCN = Convert.ToInt64(frmNghiepVuHoSo.CtrlNghiepVuHoSo1.MaHoSoCapGCN)
                .MaDVHC = intGlobalMaDonViHanhChinh.ToString()
                .ctrInToTrinh_Load()
                frm.ShowDialog()
            End With
        Catch ex As Exception
            MessageBox.Show("Lỗi in phiếu !", "DMCLand")
        End Try
    End Sub

    Private Sub toolPhieuChuyenThongTinDiaChinh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolPhieuChuyenThongTinDiaChinh.Click
        If frmNghiepVuHoSo.CtrlNghiepVuHoSo1.MaHoSoCapGCN <> "" Then
            Dim MaHoSoCapGCN As String
            MaHoSoCapGCN = frmNghiepVuHoSo.CtrlNghiepVuHoSo1.MaHoSoCapGCN
            If MaHoSoCapGCN = "" Then
                MessageBox.Show("Bạn chưa chọn hồ sơ để in báo cáo", Nothing, MessageBoxButtons.OK)
            Else : InBaoCaoPhieuChuyenThongTinDiaChinh(MaHoSoCapGCN)
            End If
        End If

        ' ''Try
        ' ''    If frmNghiepVuHoSo.CtrlNghiepVuHoSo1.MaHoSoCapGCN = "" Then
        ' ''        Return
        ' ''    End If
        ' ''    If User.DonViHanhChinhHienThoi.ToString = "0" Then
        ' ''        Return
        ' ''    End If
        ' ''    Dim frm As New frmPhieuChuyenThongTinDiaChinh
        ' ''    With frm.CtrPhieuChuyenThongTinDiaChinh1
        ' ''        .Connection = GetConnection(bolKetNoiCSDL)
        ' ''        .MaHoSoCapGCN = Convert.ToInt64(frmNghiepVuHoSo.CtrlNghiepVuHoSo1.MaHoSoCapGCN)
        ' ''        .MaDVHC = intGlobalMaDonViHanhChinh.ToString()
        ' ''        .ctrPhieuChuyenThongTinDiaChinh_Load()
        ' ''        frm.StartPosition = FormStartPosition.CenterScreen
        ' ''        frm.WindowState = FormWindowState.Maximized
        ' ''        frm.ShowDialog()
        ' ''    End With
        ' ''Catch ex As Exception
        ' ''    MessageBox.Show("Lỗi hiển thị phiếu chuyển địa chính !", "DMCLand")
        ' ''End Try
    End Sub


    Private Sub ToolStripHienThiBanDo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripHienThiBanDo.Click
        With Me
            'Hiện Form bản đồ tổng thể
            .HienThiBaoDo()
        End With
    End Sub

    Private Sub ToolStripHienThiHoSo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripHienThiHoSo.Click
        With Me
            'Hiện Form chức năng và Form nghiệp vụ
            .HienThiNghiepVu()
        End With
    End Sub

    Private Sub AsfsdToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub MenuItemHienThi10ThuaDatMoiThaoTac1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub MenuItemHienThi10ThuaDatMoiThaoTac_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub mnuHeThong_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuHeThong.Click

    End Sub

    Private Sub ThoátToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuHeThongThoat.Click
        Global.System.Windows.Forms.Application.Exit()
    End Sub
    Private Sub InBaoCaoNoiBo(ByVal MaHoSoCapGCN As String)

        Dim strTemp As String
        Dim strOut As String
        strDuoiWord = GetSetting(System.Reflection.Assembly.GetExecutingAssembly.Location, "DuoiWord", "DuoiWord")
        If strDuoiWord = "" Then
            strDuoiWord = "doc"
        End If
        BaoCaoNoiBoChuSuDung(MaHoSoCapGCN)
        'strTemp = System.Windows.Forms.Application.StartupPath + "\temp\Mau ho so cap GCN 2010 - Hoan Kiem.doc"
        strTemp = System.Windows.Forms.Application.StartupPath + "\temp\HoSoCapGCN." & strDuoiWord
        strOut = System.Windows.Forms.Application.StartupPath + "\Ketqua\TT_QD_TTDC_" + Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + "h_" + Now.Minute.ToString + "'_" + Now.Second.ToString + "s_" + BaoCaoNoiBoChuSuDung(MaHoSoCapGCN).Get_ChuSuDung + "." + strDuoiWord + ""
        Creat_Word_BaoCaoNoiBo_HoangMai(strTemp, strOut, MaHoSoCapGCN)
        OW = New Word.Application
        OW.Visible = True
        Try
            DOC = OW.Documents.Open(strOut)
            OW.Activate()
        Catch ex As Exception
            OW.Quit()
        End Try
    End Sub
    Private Sub InBaoCaoPhieuChuyenThongTinDiaChinh(ByVal MaHoSoCapGCN As String)

        Dim strTemp As String
        Dim strOut As String
        strDuoiWord = GetSetting(System.Reflection.Assembly.GetExecutingAssembly.Location, "DuoiWord", "DuoiWord")
        If strDuoiWord = "" Then
            strDuoiWord = "doc"
        End If
        BaoCaoNoiBoChuSuDung(MaHoSoCapGCN)
        'strTemp = System.Windows.Forms.Application.StartupPath + "\temp\Mau ho so cap GCN 2010 - Hoan Kiem.doc"
        strTemp = System.Windows.Forms.Application.StartupPath + "\temp\PhieuChuyenThongTinDiaChinh." & strDuoiWord
        strOut = System.Windows.Forms.Application.StartupPath + "\Ketqua\PhieuChuyenThongTinDiaChinh" + Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + "h_" + Now.Minute.ToString + "'_" + Now.Second.ToString + "s_" + BaoCaoNoiBoChuSuDung(MaHoSoCapGCN).Get_ChuSuDung + "." + strDuoiWord + ""
        Creat_Word_BaoCaoToTrinhDiaChinh(strTemp, strOut, MaHoSoCapGCN)
        OW = New Word.Application
        OW.Visible = True
        Try
            DOC = OW.Documents.Open(strOut)
            OW.Activate()
        Catch ex As Exception
            OW.Quit()
        End Try
    End Sub
    Private Sub InBaoCaoQuyetDinhCapGCNHoGD(ByVal MaHoSoCapGCN As String)

        Dim strTemp As String
        Dim strOut As String
        strDuoiWord = GetSetting(System.Reflection.Assembly.GetExecutingAssembly.Location, "DuoiWord", "DuoiWord")
        If strDuoiWord = "" Then
            strDuoiWord = "doc"
        End If
        BaoCaoNoiBoChuSuDungInGCNHoGiaDinh(MaHoSoCapGCN)
        If cls_BaoCaoNoiBoChuSuDung.Get_ChuSuDung = "" Then
            MessageBox.Show("Hồ sơ cấp GCN không phải của hộ gia đình", "DMCLand")
            Return
        End If
        'strTemp = System.Windows.Forms.Application.StartupPath + "\temp\Mau ho so cap GCN 2010 - Hoan Kiem.doc"
        strTemp = System.Windows.Forms.Application.StartupPath + "\temp\QuyetDinhCapGCNHoGiaDinh." + strDuoiWord
        strOut = System.Windows.Forms.Application.StartupPath + "\Ketqua\QD_HGD_" + Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + "h_" + Now.Minute.ToString + "'_" + Now.Second.ToString + "s_" + MaHoSoCapGCN + "." + strDuoiWord + "" 'BaoCaoNoiBoChuSuDung(MaHoSoCapGCN).Get_ChuSuDung + ".rtf"""
        Creat_Word_BaoCaoNoiBo_HoangMai(strTemp, strOut, MaHoSoCapGCN)
        OW = New Word.Application
        OW.Visible = True
        Try
            DOC = OW.Documents.Open(strOut)
            OW.Activate()
        Catch ex As Exception
            OW.Quit()
        End Try
    End Sub
    Public Sub Creat_Word_BaoCaoNoiBo_HoangMai(ByVal s1 As String, ByVal s2 As String, ByVal MaHoSoCapGCN As Integer)
        'Phục vụ word
        Dim oWord As New Word.Application  ' biến khai báo ứng dụng word
        Dim oDoc As Word.Document        ' Khai báo biến tài liệu word

        Try
            If MaHoSoCapGCN = 0 Then
                Return
            End If


            BaoCaoNoiBoChuSuDung(MaHoSoCapGCN)
            BaoCaoNoiBoNghiaVuTaiChinh_TranhChap_NguoiKyGCN(MaHoSoCapGCN)
            Dim dtBaoCaoNoiBoThuaDat As clsBaoCaoNoiBo = BaoCaoNoiBoThuaDat(MaHoSoCapGCN)
            Dim dtBaoCaoNoiBoNhaO As clsBaoCaoNoiBo = BaoCaoNoiBoNhaO(MaHoSoCapGCN)

            Dim diachi As String = dtBaoCaoNoiBoThuaDat.Get_DiaChiNha
            oDoc = oWord.Documents.Open(s1)
            oWord.Visible = False
            Dim rngRange As Word.Range = oDoc.Range
            RP(rngRange, "{DiaChiNha}", dtBaoCaoNoiBoThuaDat.Get_DiaChiNha)
            RP(rngRange, "{DiaChiDat}", dtBaoCaoNoiBoThuaDat.Get_DiaChiNha)
            'MessageBox.Show(BaoCaoNoiBo(MaHoSoCapGCN).Get_DiaChiNha)
            RP(rngRange, "{ChuSuDung}", BaoCaoNoiBoChuSuDung(MaHoSoCapGCN).Get_ChuSuDung)
            RP(rngRange, "{Phuong}", BaoCaoNoiBoChuSuDung(MaHoSoCapGCN).Get_Phuong)
            RP(rngRange, "{ChuSuDung1}", BaoCaoNoiBoChuSuDung(MaHoSoCapGCN).Get_ChuSuDung1)
            RP(rngRange, "{ChuSuDung2}", BaoCaoNoiBoChuSuDung(MaHoSoCapGCN).Get_ChuSuDung2)
            'RP(rngRange, "{DiaChiNha}", BaoCaoNoiBo(MaHoSoCapGCN).Get_DiaChi)
            RP(rngRange, "{DienTich}", dtBaoCaoNoiBoThuaDat.Get_DienTich)
            RP(rngRange, "{DienTichRieng}", dtBaoCaoNoiBoThuaDat.Get_DienTichRieng)
            RP(rngRange, "{DienTichChung}", dtBaoCaoNoiBoThuaDat.Get_DienTichChung)
            RP(rngRange, "{DienTichSuDung}", dtBaoCaoNoiBoNhaO.Get_DienTichSuDung)
            RP(rngRange, "{SoTang}", dtBaoCaoNoiBoNhaO.Get_SoTang)
            RP(rngRange, "{NguonGocNha}", dtBaoCaoNoiBoNhaO.Get_NguonGocNha)
            RP(rngRange, "{GiaTriConLai}", dtBaoCaoNoiBoNhaO.Get_GiaTriConLai)
            RP(rngRange, "{NguoiPheDuyet}", dtBaoCaoNoiBoNhaO.Get_NguoiPheDuyet)
            RP(rngRange, "{DienTichDat}", dtBaoCaoNoiBoThuaDat.Get_DienTich)
            RP(rngRange, "{KhieuNai_TranhChap}", BaoCaoNoiBoNghiaVuTaiChinh_TranhChap_NguoiKyGCN(MaHoSoCapGCN).Get_KhieuNaiTranhChap)
            RP(rngRange, "{DienTichDeNghiCapGCN}", dtBaoCaoNoiBoNhaO.Get_DienTichDeNghiCapGCN)
            RP(rngRange, "{KetCau}", dtBaoCaoNoiBoNhaO.Get_KetCau)
            RP(rngRange, "{NghiaVuTaiChinh}", BaoCaoNoiBoNghiaVuTaiChinh_TranhChap_NguoiKyGCN(MaHoSoCapGCN).Get_NghiaVuTaiChinh)
            RP(rngRange, "{TruongPhong}", BaoCaoNoiBoNghiaVuTaiChinh_TranhChap_NguoiKyGCN(MaHoSoCapGCN).Get_TruongPhong)
            RP(rngRange, "{SoThua}", dtBaoCaoNoiBoThuaDat.Get_ThuaDat.ToUpper())
            RP(rngRange, "{ToBanDo}", dtBaoCaoNoiBoThuaDat.Get_ToBanDo.ToUpper())
            RP(rngRange, "{dientichXD}", dtBaoCaoNoiBoNhaO.Get_DienTichXD)
            RP(rngRange, "{HoTenCanBoThamDinh}", dtBaoCaoNoiBoThuaDat.get_HoTenCanBoThamDinh)
            RP(rngRange, "{SoPhatHanhGCN}", dtBaoCaoNoiBoThuaDat.SoPhatHanhGCN)

            RP(rngRange, "{DatO}", dtBaoCaoNoiBoThuaDat.Get_DatO)
            RP(rngRange, "{DatVuon}", dtBaoCaoNoiBoThuaDat.Get_DatVuon)
            RP(rngRange, "{SoSerriToTrinh}", dtBaoCaoNoiBoThuaDat.Get_SoSeriToTrinh)
            RP(rngRange, "{DieuKhoan}", dtBaoCaoNoiBoThuaDat.Get_DieuKhoan)

            RP(rngRange, "{LoaiDuong}", dtBaoCaoNoiBoThuaDat.Get_LoaiDuong)
            RP(rngRange, "{NgoRong}", dtBaoCaoNoiBoThuaDat.Get_NgoRong)
            RP(rngRange, "{ViTri}", dtBaoCaoNoiBoThuaDat.Get_ViTri)
            RP(rngRange, "{CachDuongChinh}", dtBaoCaoNoiBoThuaDat.Get_CachDuongChinh)
            RP(rngRange, "{LPTB}", dtBaoCaoNoiBoThuaDat.Get_LPTB)
            RP(rngRange, "{TTNCN}", dtBaoCaoNoiBoThuaDat.Get_TTNCN)

            RP(rngRange, "{DT100GiaDat}", dtBaoCaoNoiBoThuaDat.DT100GiaDat)
            RP(rngRange, "{DT50GiaDat}", dtBaoCaoNoiBoThuaDat.DT50GiaDat)
            RP(rngRange, "{DT40GiaDat}", dtBaoCaoNoiBoThuaDat.DT40GiaDat)
            RP(rngRange, "{DT20GiaDat}", dtBaoCaoNoiBoThuaDat.DT20GiaDat)

            RP(rngRange, "{ToTrinhPhuong}", dtBaoCaoNoiBoThuaDat.Get_ToTrinhPhuong)
            RP(rngRange, "{NgayTrinhPhuong}", dtBaoCaoNoiBoThuaDat.Get_NgayTrinhPhuong)
            RP(rngRange, "{SoToTrinhDiaChinh}", dtBaoCaoNoiBoThuaDat.get_SoToTrinhDiaChinh)
            RP(rngRange, "{NgayTrinhDiaChinh}", dtBaoCaoNoiBoThuaDat.get_NgayTrinhDiaChinh)
            RP(rngRange, "{NoiDungHoSo}", dtBaoCaoNoiBoThuaDat.Get_NoiDungHoSo)

            RP(rngRange, "{NguonGocSuDung}", dtBaoCaoNoiBoThuaDat.Get_NguonGocSuDung)
            RP(rngRange, "{CapNha}", dtBaoCaoNoiBoNhaO.Get_CapNha)
            RP(rngRange, "{SoNha}", dtBaoCaoNoiBoNhaO.Get_SoNha)
            RP(rngRange, "{ThoiHanSoHuu}", dtBaoCaoNoiBoNhaO.Get_ThoiHanSoHuu)
            RP(rngRange, "{ThoiHanSuDung}", dtBaoCaoNoiBoThuaDat.Get_ThoiHanSuDung)
            RP(rngRange, "{MucDichSuDung}", dtBaoCaoNoiBoThuaDat.Get_MucDichSuDung)
            RP(rngRange, "{NamSinh}", BaoCaoNoiBoChuSuDung(MaHoSoCapGCN).Get_NamSinh)
            RP(rngRange, "{NamSinh1}", BaoCaoNoiBoChuSuDung(MaHoSoCapGCN).Get_NamSinh1)
            RP(rngRange, "{NamSinh2}", BaoCaoNoiBoChuSuDung(MaHoSoCapGCN).Get_NamSinh2)
            RP(rngRange, "{SoCMND}", BaoCaoNoiBoChuSuDung(MaHoSoCapGCN).Get_SoCMND)
            RP(rngRange, "{SoCMND1}", BaoCaoNoiBoChuSuDung(MaHoSoCapGCN).Get_SoCMND1)
            RP(rngRange, "{SoCMND2}", BaoCaoNoiBoChuSuDung(MaHoSoCapGCN).Get_SoCMND2)
            RP(rngRange, "{NoiCap}", BaoCaoNoiBoChuSuDung(MaHoSoCapGCN).Get_NoiCap)
            RP(rngRange, "{NoiCap1}", BaoCaoNoiBoChuSuDung(MaHoSoCapGCN).Get_NoiCap1)
            RP(rngRange, "{NoiCap2}", BaoCaoNoiBoChuSuDung(MaHoSoCapGCN).Get_NoiCap2)
            RP(rngRange, "{DienTichNha}", BaoCaoNoiBoChuSuDung(MaHoSoCapGCN).Get_DienTichNha)
            RP(rngRange, "{NamXayDung}", dtBaoCaoNoiBoNhaO.Get_NamXayDung)
            RP(rngRange, "{tenphuong}", frmNghiepVuHoSo.CtrlNghiepVuHoSo1.TenPhuong())

            Dim dtThuaDat_NhaO As New DataTable
            dtThuaDat_NhaO = BaoCaoDuThaoCapGCN(MaHoSoCapGCN)

            RP(rngRange, "{ChuSuDungDuThaoGCN}", ChuSuDungDuThaoGCN(MaHoSoCapGCN))
            If Not IsDBNull(dtThuaDat_NhaO.Rows(0).Item("ThongTinThuaDatDeNghiCapGCN")) Then
                RP(rngRange, "{ThongTinThuaDatDeNghiCapGCN}", dtThuaDat_NhaO.Rows(0).Item("ThongTinThuaDatDeNghiCapGCN"))
            Else
                RP(rngRange, "{ThongTinThuaDatDeNghiCapGCN}", "")
            End If
            If Not IsDBNull(dtThuaDat_NhaO.Rows(0).Item("ThongTinNhaODeNghiCapGCN")) Then
                RP(rngRange, "{ThongTinNhaODeNghiCapGCN}", dtThuaDat_NhaO.Rows(0).Item("ThongTinNhaODeNghiCapGCN"))
            Else
                RP(rngRange, "{ThongTinNhaODeNghiCapGCN}", "")
            End If
            If Not IsDBNull(dtThuaDat_NhaO.Rows(0).Item("GhiChuGCN")) Then
                RP(rngRange, "{ghichuGCN}", dtThuaDat_NhaO.Rows(0).Item("GhiChuGCN"))
            Else
                RP(rngRange, "{ghichuGCN}", "")
            End If



            'RP(rngRange, "{LoaiNha}", BaoCaoNoiBoNhaO(MaHoSoCapGCN).Get_LoaiNha)

            oDoc.SaveAs(s2)
            oDoc.Close()

            oDoc = Nothing
            oWord.Quit()
            oWord = Nothing

        Catch ex As Exception
            oWord.Quit()
            oWord = Nothing
            releaseObject(oWord)
        End Try
    End Sub

    Public Sub Creat_Word_BaoCaoToTrinhDiaChinh(ByVal s1 As String, ByVal s2 As String, ByVal MaHoSoCapGCN As Integer)
        'Phục vụ word
        Dim oWord As New Word.Application  ' biến khai báo ứng dụng word
        Dim oDoc As Word.Document        ' Khai báo biến tài liệu word

        Try
            If MaHoSoCapGCN = 0 Then
                Return
            End If

            Dim strChuSD As String = ""
            Dim strChuChuyenNhuong As String = ""
            Dim strDTChuyenDIch As String = ""

            Dim dtChuSD As New DataTable
            Dim dtChuChuyenNhuong As New DataTable
            Dim dt As New DataTable
            Dim dtDTChuyenDIch As New DataTable
            Dim cls As New clsBaoCaoNoiBo
            cls.Connection = GetConnection(bolKetNoiCSDL)
            cls.MaHoSoCapGCN = MaHoSoCapGCN

            dtChuSD = cls.selChuSuDungChuyenNhuong("0")
            dtChuChuyenNhuong = cls.selChuSuDungChuyenNhuong("1")
            dtDTChuyenDIch = cls.selDienTichChuyenDich

            If dtChuSD.Rows.Count > 0 Then
                strChuSD = dtChuSD.Rows(0).Item(0)
            End If
            If dtChuChuyenNhuong.Rows.Count > 0 Then
                strChuChuyenNhuong = dtChuChuyenNhuong.Rows(0).Item(0)
            End If
            If dtDTChuyenDIch.Rows.Count > 0 Then
                strDTChuyenDIch = dtDTChuyenDIch.Rows(0).Item(0)
            End If


            Dim dtBaoCaoNoiBoThuaDat As New clsBaoCaoNoiBo
            dtBaoCaoNoiBoThuaDat = BaoCaoNoiBoThuaDat(MaHoSoCapGCN)
            Dim dtBaoCaoNoiBoNhaO As New clsBaoCaoNoiBo
            dtBaoCaoNoiBoNhaO = BaoCaoNoiBoNhaO(MaHoSoCapGCN)

            oDoc = oWord.Documents.Open(s1)
            oWord.Visible = False
            Dim rngRange As Word.Range = oDoc.Range
            RP(rngRange, "{ChuSuDung}", strChuSD)
            RP(rngRange, "{ChuChuyenNhuong}", strChuChuyenNhuong)

            RP(rngRange, "{DiaChiDat}", dtBaoCaoNoiBoThuaDat.Get_DiaChiNha)
            RP(rngRange, "{SoPhatHanhGCN}", dtBaoCaoNoiBoThuaDat.SoPhatHanhGCN)
            RP(rngRange, "{NgayCapGCN}", dtBaoCaoNoiBoThuaDat.Get_NgayCap)
            RP(rngRange, "{SoThua}", dtBaoCaoNoiBoThuaDat.Get_ThuaDat.ToUpper())
            RP(rngRange, "{ToBanDo}", dtBaoCaoNoiBoThuaDat.Get_ToBanDo.ToUpper())
            RP(rngRange, "{DienTich}", dtBaoCaoNoiBoThuaDat.Get_DienTich)
            RP(rngRange, "{KetCau}", dtBaoCaoNoiBoNhaO.Get_KetCau)
            RP(rngRange, "{dientichXD}", dtBaoCaoNoiBoNhaO.Get_DienTichXD)
            RP(rngRange, "{DienTichSuDung}", dtBaoCaoNoiBoNhaO.Get_DienTichSuDung)
            RP(rngRange, "{DienTichChuyenDich}", strDTChuyenDIch)
 
            oDoc.SaveAs(s2)
            oDoc.Close()

            oDoc = Nothing
            oWord.Quit()
            oWord = Nothing

        Catch ex As Exception
            oWord.Quit()
            oWord = Nothing
            releaseObject(oWord)
        End Try
    End Sub
    'Public Sub Creat_Word_BaoCaoNoiBo(ByVal s1 As String, ByVal s2 As String, ByVal MaHoSoCapGCN As Integer)
    '    'Phục vụ word
    '    Dim oWord As New Word.Application  ' biến khai báo ứng dụng word
    '    Dim oDoc As Word.Document        ' Khai báo biến tài liệu word

    '    Try
    '        If MaHoSoCapGCN = 0 Then
    '            Return
    '        End If
    '        BaoCaoNoiBoChuSuDung(MaHoSoCapGCN)
    '        BaoCaoNoiBoNghiaVuTaiChinh_TranhChap_NguoiKyGCN(MaHoSoCapGCN)
    '        BaoCaoNoiBoThuaDat(MaHoSoCapGCN)
    '        BaoCaoNoiBoNhaO(MaHoSoCapGCN)
    '        oDoc = oWord.Documents.Open(s1)
    '        oWord.Visible = False
    '        Dim rngRange As Word.Range = oDoc.Range
    '        RP(rngRange, "{DiaChiNha}", BaoCaoNoiBoChuSuDung(MaHoSoCapGCN).Get_DiaChiNha)
    '        RP(rngRange, "{DiaChiDat}", BaoCaoNoiBoThuaDat(MaHoSoCapGCN).Get_DiaChiNha)
    '        'MessageBox.Show(BaoCaoNoiBo(MaHoSoCapGCN).Get_DiaChiNha)
    '        RP(rngRange, "{ChuSuDung}", BaoCaoNoiBoChuSuDung(MaHoSoCapGCN).Get_ChuSuDung)
    '        RP(rngRange, "{Phuong}", BaoCaoNoiBoChuSuDung(MaHoSoCapGCN).Get_Phuong)
    '        RP(rngRange, "{ChuSuDung1}", BaoCaoNoiBoChuSuDung(MaHoSoCapGCN).Get_ChuSuDung1)
    '        RP(rngRange, "{ChuSuDung2}", BaoCaoNoiBoChuSuDung(MaHoSoCapGCN).Get_ChuSuDung2)
    '        'RP(rngRange, "{DiaChiNha}", BaoCaoNoiBo(MaHoSoCapGCN).Get_DiaChi)
    '        RP(rngRange, "{DienTich}", BaoCaoNoiBoThuaDat(MaHoSoCapGCN).Get_DienTich)
    '        RP(rngRange, "{DienTichRieng}", BaoCaoNoiBoThuaDat(MaHoSoCapGCN).Get_DienTichRieng)
    '        RP(rngRange, "{DienTichChung}", BaoCaoNoiBoThuaDat(MaHoSoCapGCN).Get_DienTichChung)
    '        RP(rngRange, "{DienTichSuDung}", BaoCaoNoiBoNhaO(MaHoSoCapGCN).Get_DienTichSuDung)
    '        RP(rngRange, "{SoTang}", BaoCaoNoiBoNhaO(MaHoSoCapGCN).Get_SoTang)
    '        RP(rngRange, "{NguoiPheDuyet}", BaoCaoNoiBoNhaO(MaHoSoCapGCN).Get_NguoiPheDuyet)
    '        RP(rngRange, "{DienTichDat}", BaoCaoNoiBoThuaDat(MaHoSoCapGCN).Get_DienTich)
    '        RP(rngRange, "{KhieuNai_TranhChap}", BaoCaoNoiBoNghiaVuTaiChinh_TranhChap_NguoiKyGCN(MaHoSoCapGCN).Get_KhieuNaiTranhChap)
    '        RP(rngRange, "{DienTichDeNghiCapGCN}", BaoCaoNoiBoNhaO(MaHoSoCapGCN).Get_DienTichDeNghiCapGCN)
    '        RP(rngRange, "{KetCau}", BaoCaoNoiBoNhaO(MaHoSoCapGCN).Get_KetCau)
    '        RP(rngRange, "{NghiaVuTaiChinh}", BaoCaoNoiBoNghiaVuTaiChinh_TranhChap_NguoiKyGCN(MaHoSoCapGCN).Get_NghiaVuTaiChinh)
    '        RP(rngRange, "{TruongPhong}", BaoCaoNoiBoNghiaVuTaiChinh_TranhChap_NguoiKyGCN(MaHoSoCapGCN).Get_TruongPhong)
    '        RP(rngRange, "{SoThua}", BaoCaoNoiBoThuaDat(MaHoSoCapGCN).Get_ThuaDat)
    '        RP(rngRange, "{ToBanDo}", BaoCaoNoiBoThuaDat(MaHoSoCapGCN).Get_ToBanDo)
    '        RP(rngRange, "{NguonGocSuDung}", BaoCaoNoiBoThuaDat(MaHoSoCapGCN).Get_NguonGocSuDung)
    '        RP(rngRange, "{CapNha}", BaoCaoNoiBoNhaO(MaHoSoCapGCN).Get_CapNha)
    '        RP(rngRange, "{ThoiHanSuDung}", BaoCaoNoiBoThuaDat(MaHoSoCapGCN).Get_ThoiHanSuDung)
    '        RP(rngRange, "{MucDichSuDung}", BaoCaoNoiBoThuaDat(MaHoSoCapGCN).Get_MucDichSuDung)
    '        RP(rngRange, "{NamSinh}", BaoCaoNoiBoChuSuDung(MaHoSoCapGCN).Get_NamSinh)
    '        RP(rngRange, "{NamSinh1}", BaoCaoNoiBoChuSuDung(MaHoSoCapGCN).Get_NamSinh1)
    '        RP(rngRange, "{NamSinh2}", BaoCaoNoiBoChuSuDung(MaHoSoCapGCN).Get_NamSinh2)
    '        RP(rngRange, "{SoCMND}", BaoCaoNoiBoChuSuDung(MaHoSoCapGCN).Get_SoCMND)
    '        RP(rngRange, "{SoCMND1}", BaoCaoNoiBoChuSuDung(MaHoSoCapGCN).Get_SoCMND1)
    '        RP(rngRange, "{SoCMND2}", BaoCaoNoiBoChuSuDung(MaHoSoCapGCN).Get_SoCMND2)
    '        RP(rngRange, "{NoiCap}", BaoCaoNoiBoChuSuDung(MaHoSoCapGCN).Get_NoiCap)
    '        RP(rngRange, "{NoiCap1}", BaoCaoNoiBoChuSuDung(MaHoSoCapGCN).Get_NoiCap1)
    '        RP(rngRange, "{NoiCap2}", BaoCaoNoiBoChuSuDung(MaHoSoCapGCN).Get_NoiCap2)
    '        RP(rngRange, "{DienTichNha}", BaoCaoNoiBoChuSuDung(MaHoSoCapGCN).Get_DienTichNha)
    '        RP(rngRange, "{NamXayDung}", BaoCaoNoiBoNhaO(MaHoSoCapGCN).Get_NamXayDung)


    '        Dim dtThuaDat_NhaO As New DataTable
    '        dtThuaDat_NhaO = BaoCaoDuThaoCapGCN(MaHoSoCapGCN)

    '        RP(rngRange, "{ChuSuDungDuThaoGCN}", ChuSuDungDuThaoGCN(MaHoSoCapGCN))
    '        If Not IsDBNull(dtThuaDat_NhaO.Rows(0).Item("ThongTinThuaDatDeNghiCapGCN")) Then
    '            RP(rngRange, "{ThongTinThuaDatDeNghiCapGCN}", dtThuaDat_NhaO.Rows(0).Item("ThongTinThuaDatDeNghiCapGCN"))
    '        Else
    '            RP(rngRange, "{ThongTinThuaDatDeNghiCapGCN}", "")
    '        End If
    '        If Not IsDBNull(dtThuaDat_NhaO.Rows(0).Item("ThongTinNhaODeNghiCapGCN")) Then
    '            RP(rngRange, "{ThongTinNhaODeNghiCapGCN}", dtThuaDat_NhaO.Rows(0).Item("ThongTinNhaODeNghiCapGCN"))
    '        Else
    '            RP(rngRange, "{ThongTinNhaODeNghiCapGCN}", "")
    '        End If
    '        If Not IsDBNull(dtThuaDat_NhaO.Rows(0).Item("GhiChuGCN")) Then
    '            RP(rngRange, "{ghichuGCN}", dtThuaDat_NhaO.Rows(0).Item("GhiChuGCN"))
    '        Else
    '            RP(rngRange, "{ghichuGCN}", "")
    '        End If



    '        'RP(rngRange, "{LoaiNha}", BaoCaoNoiBoNhaO(MaHoSoCapGCN).Get_LoaiNha)

    '        oDoc.SaveAs(s2)
    '        oDoc.Close()

    '        oDoc = Nothing
    '        oWord.Quit()
    '        oWord = Nothing

    '    Catch ex As Exception
    '        oWord.Quit()
    '        oWord = Nothing
    '        releaseObject(oWord)
    '    End Try
    'End Sub
    Public Function ChuSuDungDuThaoGCN(ByVal MaHoSoCapGCN As String) As String
        TableChuSuDung(MaHoSoCapGCN)
        Dim strCSD As String = ""
        If TableChuSuDung(MaHoSoCapGCN).Rows.Count = 0 Then
            MessageBox.Show("Không có dữ liệu", Nothing, MessageBoxButtons.OK)
            Return ""
        Else
            If TableChuSuDung(MaHoSoCapGCN).Rows.Count > 0 Then
                For i As Integer = 0 To TableChuSuDung(MaHoSoCapGCN).Rows.Count - 1

                    With TableChuSuDung(MaHoSoCapGCN).Rows(i)
                        If .Item("Nhom") IsNot DBNull.Value Then
                            If .Item("Nhom").ToString = "0" Then
                                strCSD = strCSD & .Item("HoTen").ToString & Chr(13)
                                strCSD = strCSD & "Năm sinh: " & .Item("NamSinh").ToString
                                strCSD = strCSD & "Số CMND: " & .Item("SoDinhDanh").ToString & vbTab & Chr(13)
                                strCSD = strCSD & "Nơi cấp: " & .Item("NoiCap").ToString & Chr(13)
                                strCSD = strCSD & "Địa chỉ: " & .Item("DiaChiNha").ToString & Chr(13)
                            ElseIf .Item("Nhom").ToString = "1" Then
                                strCSD = strCSD & "Giấy phép đăng ký số: " & .Item("SoDinhDanh") & Chr(13)
                                strCSD = strCSD & "Nơi cấp: " & .Item("NoiCap") & Chr(13)
                                strCSD = strCSD & "Ngày cấp: " & .Item("NgayCap") & Chr(13)
                                strCSD = strCSD & "Địa chỉ: " & .Item("DiaChiNha").ToString & Chr(13)
                            ElseIf .Item("Nhom").ToString = "2" Then
                                strCSD = strCSD & .Item("HoTen").ToString & Chr(13)
                                strCSD = strCSD & "Địa chỉ: " & .Item("DiaChiNha").ToString & Chr(13)
                            End If
                        End If
                    End With

                Next

            End If
            Return strCSD
        End If
    End Function
    Public Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub
    Public Sub RP(ByVal rngRange As Word.Range, ByVal Findstring As String, ByVal Replacestring As String)
        Trim(Replacestring)
        Dim s As String
        While Len(Replacestring) > 200
            s = Mid(Replacestring, 1, 200)
            s += Findstring
            Replacestring = Mid(Replacestring, 200 + 1, Len(Replacestring) - 200)
            With rngRange.Find
                .ClearFormatting()
                .Replacement.ClearFormatting()
                .Text = Findstring
                .Replacement.Text = s
                .Execute(Replace:=Word.WdReplace.wdReplaceAll)
            End With
        End While
        With rngRange.Find
            .ClearFormatting()
            .Replacement.ClearFormatting()
            .Text = Findstring
            .Replacement.Text = Replacestring
            .Execute(Replace:=Word.WdReplace.wdReplaceAll)
        End With
        With rngRange.Find
            .ClearFormatting()
            .Replacement.ClearFormatting()
            .Text = ChrW(10)
            .Replacement.Text = ChrW(13)
            .Execute(Replace:=Word.WdReplace.wdReplaceAll)
        End With

    End Sub
    Public Function TableChuSuDung(ByVal MaHoSoCapGCN As String) As DataTable
        Dim tbChuSuDung As New DataTable
        Dim con As String = GetConnection(bolKetNoiCSDL)
        Dim Connection As New SqlConnection(con)
        'Đổ dữ liệu vào DataTable chủ sử dụng
        Dim cmd As New SqlCommand("spSelectThongTinChuSuDungByMaHoSoCapGCN", Connection)
        cmd.CommandType = CommandType.StoredProcedure
        Dim Para As New SqlParameter
        Para = cmd.Parameters.Add("MaHoSoCapGCN", SqlDbType.BigInt)
        Para.Value = Integer.Parse(MaHoSoCapGCN)
        Dim sqlDataAdapter As New SqlDataAdapter(cmd)
        'Điền dữ liệu vào đối tượng DataTable
        sqlDataAdapter.Fill(tbChuSuDung)
        Return tbChuSuDung
    End Function
    Public Function TableNhaO(ByVal MaHoSoCapGCN As String) As DataTable
        Dim tbNhaO As New DataTable
        Dim con As String = GetConnection(bolKetNoiCSDL)
        Dim Connection As New SqlConnection(con)
        'Đổ dữ liệu vào DataTable nhà ở
        Dim cmd As New SqlCommand("spSelectThongTinNhaOByMaHoSoCapGCN", Connection)
        cmd.CommandType = CommandType.StoredProcedure
        Dim Para As New SqlParameter
        Para = cmd.Parameters.Add("MaHoSoCapGCN", SqlDbType.BigInt)
        Para.Value = Integer.Parse(MaHoSoCapGCN)
        Dim sqlDataAdapter As New SqlDataAdapter(cmd)
        'Điền dữ liệu vào đối tượng DataTable
        sqlDataAdapter.Fill(tbNhaO)
        Return tbNhaO
    End Function
    Public Function TableThuaDat(ByVal MaHoSoCapGCN As String) As DataTable
        Dim tbThuaDat As New DataTable
        Dim con As String = GetConnection(bolKetNoiCSDL)
        Dim Connection As New SqlConnection(con)
        'Đổ dữ liệu vào DataTable thửa đất
        Dim cmd As New SqlCommand("spSelectThongTinThuaDatByMaHoSoCapGCN", Connection)
        cmd.CommandType = CommandType.StoredProcedure
        Dim Para As New SqlParameter
        Para = cmd.Parameters.Add("MaHoSoCapGCN", SqlDbType.BigInt)
        Para.Value = Integer.Parse(MaHoSoCapGCN)
        Dim sqlDataAdapter As New SqlDataAdapter(cmd)
        'Điền dữ liệu vào đối tượng DataTable
        sqlDataAdapter.Fill(tbThuaDat)
        Return tbThuaDat
    End Function
    Public Function TableNghiaVuTaiChinh_TranhChap_NguoiKyGCN(ByVal MaHoSoCapGCN As String) As DataTable
        Dim tbNghiaVuTaiChinh As New DataTable
        Dim con As String = GetConnection(bolKetNoiCSDL)
        Dim Connection As New SqlConnection(con)
        'Đổ dữ liệu vào DataTable thửa đất
        Dim cmd As New SqlCommand("spSelectThongTinNghiaVuTaiChinh_TranhChap_NguoiKyGCNByMaHoSoCapGCN", Connection)
        cmd.CommandType = CommandType.StoredProcedure
        Dim Para As New SqlParameter
        Para = cmd.Parameters.Add("MaHoSoCapGCN", SqlDbType.BigInt)
        Para.Value = Integer.Parse(MaHoSoCapGCN)
        Dim sqlDataAdapter As New SqlDataAdapter(cmd)
        'Điền dữ liệu vào đối tượng DataTable
        sqlDataAdapter.Fill(tbNghiaVuTaiChinh)
        Return tbNghiaVuTaiChinh
    End Function
    'Public Function TableQuyetDinh(ByVal MaHoSoCapGCN As String) As DataTable
    '    Dim dtQuyetDinh As New DataTable
    '    Dim con As String = strConnection(bolKetNoiCSDL)
    '    Dim Connection As New SqlConnection(con)
    '    'Đổ dữ liệu vào DataTable Quyết định
    '    Dim cmd As New SqlCommand("spSelectThongTinQuyetDinhByMaHoSoCapGCN", Connection)
    '    cmd.CommandType = CommandType.StoredProcedure
    '    Dim Para As New SqlParameter
    '    Para = cmd.Parameters.Add("MaHoSoCapGCN", SqlDbType.BigInt)
    '    Para.Value = Integer.Parse(MaHoSoCapGCN)
    '    Dim sqlDataAdapter As New SqlDataAdapter(cmd)
    '    'Điền dữ liệu vào đối tượng DataTable
    '    sqlDataAdapter.Fill(dtQuyetDinh)
    '    Return dtQuyetDinh
    'End Function
    'Public Function TableToTrinh(ByVal MaHoSoCapGCN As String) As DataTable
    '    Dim dtToTrinh As New DataTable
    '    Dim con As String = strConnection(bolKetNoiCSDL)
    '    Dim Connection As New SqlConnection(con)
    '    'Đổ dữ liệu vào DataTable Tờ trình
    '    Dim cmd1 As New SqlCommand("spSelectThongTinToTrinhByMaHoSoCapGCN", Connection)
    '    cmd1.CommandType = CommandType.StoredProcedure
    '    Dim Para1 As New SqlParameter
    '    Para1 = cmd1.Parameters.Add("MaHoSoCapGCN", SqlDbType.BigInt)
    '    Para1.Value = Integer.Parse(MaHoSoCapGCN)
    '    Dim sqlDataAdapter1 As New SqlDataAdapter(cmd1)
    '    'Điền dữ liệu vào đối tượng DataTable
    '    sqlDataAdapter1.Fill(dtToTrinh)
    '    Return dtToTrinh
    'End Function
    'Public Function TableDuThao(ByVal MaHoSoCapGCN As String) As DataTable
    '    Dim dtBanDuThao As New DataTable
    '    Dim con As String = strConnection(bolKetNoiCSDL)
    '    Dim Connection As New SqlConnection(con)
    '    'Đổ dữ liệu vào DataTable Bản dự thảo
    '    Dim cmd2 As New SqlCommand("spSelectThongTinBanDuThaoByMaHoSoCapGCN", Connection)
    '    cmd2.CommandType = CommandType.StoredProcedure
    '    Dim Para2 As New SqlParameter
    '    Para2 = cmd2.Parameters.Add("MaHoSoCapGCN", SqlDbType.BigInt)
    '    Para2.Value = Integer.Parse(MaHoSoCapGCN)
    '    Dim sqlDataAdapter2 As New SqlDataAdapter(cmd2)
    '    'Điền dữ liệu vào đối tượng DataTable
    '    sqlDataAdapter2.Fill(dtBanDuThao)
    '    Return dtBanDuThao
    'End Function
    'Public Function TableKetQuaThamDinh(ByVal MaHoSoCapGCN As String) As DataTable
    '    Dim dtKetQuaThamDinh As New DataTable
    '    Dim con As String = strConnection(bolKetNoiCSDL)
    '    Dim Connection As New SqlConnection(con)
    '    'Đổ dữ liệu vào DataTable Kết quả thẩm định
    '    Dim cmd4 As New SqlCommand("spSelectThongTinKetQuaThamDinhByMaHoSoCapGCN", Connection)
    '    cmd4.CommandType = CommandType.StoredProcedure
    '    Dim Para4 As New SqlParameter
    '    Para4 = cmd4.Parameters.Add("MaHoSoCapGCN", SqlDbType.BigInt)
    '    Para4.Value = Integer.Parse(MaHoSoCapGCN)
    '    Dim sqlDataAdapter4 As New SqlDataAdapter(cmd4)
    '    'Điền dữ liệu vào đối tượng DataTable
    '    sqlDataAdapter4.Fill(dtKetQuaThamDinh)
    '    Return dtKetQuaThamDinh
    'End Function
    'Public Function TablePhieuChuyenThongTinDiaChinh(ByVal MaHoSoCapGCN As String) As DataTable
    '    Dim dtPhieuChuyenThongTinDiaChinh As New DataTable
    '    Dim con As String = strConnection(bolKetNoiCSDL)
    '    Dim Connection As New SqlConnection(con)
    '    'Đổ dữ liệu vào DataTable Phiếu chuyển thông tin địa chính
    '    Dim cmd3 As New SqlCommand("spSelectThongTinPhieuChuyenThongTinDiaChinhByMaHoSoCapGCN", Connection)
    '    cmd3.CommandType = CommandType.StoredProcedure
    '    Dim Para3 As New SqlParameter
    '    Para3 = cmd3.Parameters.Add("MaHoSoCapGCN", SqlDbType.BigInt)
    '    Para3.Value = Integer.Parse(MaHoSoCapGCN)
    '    Dim sqlDataAdapter3 As New SqlDataAdapter(cmd3)
    '    'Điền dữ liệu vào đối tượng DataTable
    '    sqlDataAdapter3.Fill(dtPhieuChuyenThongTinDiaChinh)
    '    Return dtPhieuChuyenThongTinDiaChinh
    'End Function
    Public Function BaoCaoNoiBoChuSuDung(ByVal MaHoSoCapGCN As String) As clsBaoCaoNoiBo
        TableChuSuDung(MaHoSoCapGCN)
        If TableChuSuDung(MaHoSoCapGCN).Rows.Count = 0 Then
            MessageBox.Show("Không có dữ liệu", Nothing, MessageBoxButtons.OK)
            Return cls_BaoCaoNoiBoChuSuDung
        Else

            If TableChuSuDung(MaHoSoCapGCN).Rows.Count > 0 Then
                If TableChuSuDung(MaHoSoCapGCN).Rows.Count = 1 Then

                    With TableChuSuDung(MaHoSoCapGCN).Rows(0)
                        If .Item("Nhom") IsNot DBNull.Value Then
                            If .Item("Nhom").ToString = "0" Then
                                cls_BaoCaoNoiBoChuSuDung.Get_NamSinh1 = "Năm sinh: " + .Item("NamSinh").ToString + ", "
                                cls_BaoCaoNoiBoChuSuDung.Get_SoCMND1 = "Số CMND: " + .Item("SoDinhDanh").ToString + ", "
                                cls_BaoCaoNoiBoChuSuDung.Get_NoiCap1 = "Nơi cấp: " + .Item("NoiCap").ToString
                            ElseIf .Item("Nhom").ToString = "1" Then
                                cls_BaoCaoNoiBoChuSuDung.Get_SoCMND1 = "Giấy phép đăng ký số: " + .Item("SoDinhDanh") + ", "
                                cls_BaoCaoNoiBoChuSuDung.Get_NoiCap1 = "Nơi cấp: " + .Item("NoiCap") + ", "
                                cls_BaoCaoNoiBoChuSuDung.Get_NgayCap = "Ngày cấp: " + .Item("NgayCap")
                            ElseIf .Item("Nhom").ToString = "2" Then
                            End If
                            cls_BaoCaoNoiBoChuSuDung.Get_ChuSuDung = .Item("HoTen").ToString
                            cls_BaoCaoNoiBoChuSuDung.Get_ChuSuDung1 = .Item("HoTen").ToString

                            cls_BaoCaoNoiBoChuSuDung.Get_ChuSuDung2 = ""
                            cls_BaoCaoNoiBoChuSuDung.Get_NamSinh2 = ""
                            cls_BaoCaoNoiBoChuSuDung.Get_SoCMND2 = ""
                            cls_BaoCaoNoiBoChuSuDung.Get_NoiCap2 = ""
                        End If
                    End With
                    With TableChuSuDung(MaHoSoCapGCN).Rows(0)
                        If .Item("Nhom") IsNot DBNull.Value Then
                            If .Item("Nhom").ToString = "0" Then
                                cls_BaoCaoNoiBoChuSuDung.Get_NamSinh1 = "Năm sinh: " + .Item("NamSinh").ToString + ", "
                                cls_BaoCaoNoiBoChuSuDung.Get_SoCMND1 = "Số CMND: " + .Item("SoDinhDanh").ToString + ", "
                                cls_BaoCaoNoiBoChuSuDung.Get_NoiCap1 = "Nơi cấp: " + .Item("NoiCap").ToString
                            ElseIf .Item("Nhom").ToString = "1" Then
                                cls_BaoCaoNoiBoChuSuDung.Get_SoCMND1 = "Giấy phép đăng ký số: " + .Item("SoDinhDanh") + ", "
                                cls_BaoCaoNoiBoChuSuDung.Get_NoiCap1 = "Nơi cấp: " + .Item("NoiCap") + ", "
                                cls_BaoCaoNoiBoChuSuDung.Get_NgayCap = "Ngày cấp: " + .Item("NgayCap")
                            ElseIf .Item("Nhom").ToString = "2" Then
                            End If
                            cls_BaoCaoNoiBoChuSuDung.Get_ChuSuDung = .Item("HoTen").ToString
                            cls_BaoCaoNoiBoChuSuDung.Get_ChuSuDung1 = .Item("HoTen").ToString

                            cls_BaoCaoNoiBoChuSuDung.Get_ChuSuDung2 = ""
                            cls_BaoCaoNoiBoChuSuDung.Get_NamSinh2 = ""
                            cls_BaoCaoNoiBoChuSuDung.Get_SoCMND2 = ""
                            cls_BaoCaoNoiBoChuSuDung.Get_NoiCap2 = ""
                        End If
                    End With
                End If
                If TableChuSuDung(MaHoSoCapGCN).Rows.Count = 2 Then
                    With TableChuSuDung(MaHoSoCapGCN).Rows(0)
                        cls_BaoCaoNoiBoChuSuDung.Get_ChuSuDung1 = .Item("HoTen").ToString
                        cls_BaoCaoNoiBoChuSuDung.Get_NamSinh1 = "Năm sinh: " + .Item("NamSinh").ToString + ", "
                        cls_BaoCaoNoiBoChuSuDung.Get_SoCMND1 = "Số CMND: " + .Item("SoDinhDanh").ToString + ", "
                        cls_BaoCaoNoiBoChuSuDung.Get_NoiCap1 = "Nơi cấp: " + .Item("NoiCap").ToString + ", "
                    End With
                    With TableChuSuDung(MaHoSoCapGCN).Rows(1)
                        cls_BaoCaoNoiBoChuSuDung.Get_ChuSuDung2 = .Item("HoTen").ToString
                        cls_BaoCaoNoiBoChuSuDung.Get_NamSinh2 = "Năm sinh: " + .Item("NamSinh").ToString + ", "
                        cls_BaoCaoNoiBoChuSuDung.Get_SoCMND2 = "Số CMND: " + .Item("SoDinhDanh").ToString + ", "
                        cls_BaoCaoNoiBoChuSuDung.Get_NoiCap2 = "Nơi cấp: " + .Item("NoiCap").ToString
                    End With
                    cls_BaoCaoNoiBoChuSuDung.Get_DiaChiNha = TableChuSuDung(MaHoSoCapGCN).Rows(0).Item("DiaChiNha").ToString
                    cls_BaoCaoNoiBoChuSuDung.Get_ChuSuDung = TableChuSuDung(MaHoSoCapGCN).Rows(0).Item("HoTen").ToString + " và " + TableChuSuDung(MaHoSoCapGCN).Rows(1).Item("HoTen").ToString
                End If
                If TableChuSuDung(MaHoSoCapGCN).Rows.Count = 3 Then
                    cls_BaoCaoNoiBoChuSuDung.Get_DiaChiNha = TableChuSuDung(MaHoSoCapGCN).Rows(0).Item("DiaChiNha").ToString
                    cls_BaoCaoNoiBoChuSuDung.Get_ChuSuDung = TableChuSuDung(MaHoSoCapGCN).Rows(0).Item("HoTen").ToString + ", " + TableChuSuDung(MaHoSoCapGCN).Rows(1).Item("HoTen").ToString + " và " + TableChuSuDung(MaHoSoCapGCN).Rows(2).Item("HoTen").ToString
                End If
                If TableChuSuDung(MaHoSoCapGCN).Rows.Count > 3 Then
                    Dim strChu As String = ""
                    For i As Integer = 0 To TableChuSuDung(MaHoSoCapGCN).Rows.Count - 1
                        If Not IsDBNull(TableChuSuDung(MaHoSoCapGCN).Rows(i).Item("HoTen").ToString) Then
                            strChu = strChu & TableChuSuDung(MaHoSoCapGCN).Rows(i).Item("HoTen").ToString & ","
                        End If
                    Next
                    cls_BaoCaoNoiBoChuSuDung.Get_ChuSuDung = strChu.Substring(0, strChu.Length - 1)
                End If
                cls_BaoCaoNoiBoChuSuDung.Get_Phuong = TableChuSuDung(MaHoSoCapGCN).Rows(0).Item("Phuong").ToString
            End If
            Return cls_BaoCaoNoiBoChuSuDung
        End If
    End Function
    Public Function BaoCaoNoiBoChuSuDungInGCNHoGiaDinh(ByVal MaHoSoCapGCN As String) As clsBaoCaoNoiBo
        Dim strChuSuDung As String = ""
        strChuSuDung = ChuSuDungHoGiaDinh(MaHoSoCapGCN)
        If strChuSuDung <> "" Then
            cls_BaoCaoNoiBoChuSuDung.Get_ChuSuDung = strChuSuDung
        End If
        Return cls_BaoCaoNoiBoChuSuDung
    End Function
    Public Function BaoCaoNoiBoNhaO(ByVal MaHoSoCapGCN As String) As clsBaoCaoNoiBo
        TableNhaO(MaHoSoCapGCN)
        If TableNhaO(MaHoSoCapGCN).Rows.Count > 0 Then
            With TableNhaO(MaHoSoCapGCN).Rows(0)
                If IsDBNull(.Item("SoTang").ToString) Or .Item("SoTang").ToString = "" Then
                    cls_BaoCaoNoiBoNhaO.Get_SoTang = "-/-"
                Else
                    cls_BaoCaoNoiBoNhaO.Get_SoTang = .Item("SoTang").ToString
                End If
                If IsDBNull(.Item("SoNha").ToString) Or .Item("SoNha").ToString = "" Then
                    cls_BaoCaoNoiBoNhaO.Get_SoNha = "-/-"
                Else
                    cls_BaoCaoNoiBoNhaO.Get_SoNha = .Item("SoNha").ToString
                End If
                If IsDBNull(.Item("CapHangNha").ToString) Or .Item("CapHangNha").ToString = "" Then
                    cls_BaoCaoNoiBoNhaO.Get_CapNha = "-/-"
                Else
                    cls_BaoCaoNoiBoNhaO.Get_CapNha = .Item("CapHangNha").ToString
                End If
                If IsDBNull(.Item("HoTenCanBoPheDuyet").ToString) Or .Item("HoTenCanBoPheDuyet").ToString = "" Then
                    cls_BaoCaoNoiBoNhaO.Get_NguoiPheDuyet = "-/-"
                Else
                    cls_BaoCaoNoiBoNhaO.Get_NguoiPheDuyet = .Item("HoTenCanBoPheDuyet").ToString
                End If
                If IsDBNull(.Item("KetCauNha").ToString) Or .Item("KetCauNha").ToString = "" Then
                    cls_BaoCaoNoiBoNhaO.Get_KetCau = "-/-"
                Else
                    cls_BaoCaoNoiBoNhaO.Get_KetCau = .Item("KetCauNha").ToString
                End If
                If IsDBNull(.Item("NamXayDung").ToString) Or .Item("NamXayDung").ToString = "" Then
                    cls_BaoCaoNoiBoNhaO.Get_NamXayDung = "-/-"
                Else
                    cls_BaoCaoNoiBoNhaO.Get_NamXayDung = .Item("NamXayDung").ToString
                End If
                If IsDBNull(.Item("DienTichXayDung").ToString) Or .Item("DienTichXayDung").ToString = "" Then
                    cls_BaoCaoNoiBoNhaO.Get_DienTichXD = "-/-"
                Else
                    cls_BaoCaoNoiBoNhaO.Get_DienTichXD = .Item("DienTichXayDung").ToString
                End If
                If IsDBNull(.Item("DienTichSanXayDung").ToString) Or .Item("DienTichSanXayDung").ToString = "" Then
                    cls_BaoCaoNoiBoNhaO.Get_DienTichSuDung = "-/-"
                Else
                    cls_BaoCaoNoiBoNhaO.Get_DienTichSuDung = .Item("DienTichSanXayDung").ToString
                End If
                If IsDBNull(.Item("DienTichXayDung").ToString) Or .Item("DienTichXayDung").ToString = "" Then
                    cls_BaoCaoNoiBoNhaO.Get_DienTichDeNghiCapGCN = "-/-"
                Else
                    cls_BaoCaoNoiBoNhaO.Get_DienTichDeNghiCapGCN = .Item("DienTichXayDung").ToString
                End If
                If IsDBNull(.Item("DiaChi").ToString) Or .Item("DiaChi").ToString = "" Then
                    cls_BaoCaoNoiBoNhaO.Get_DiaChiNha = "-/-"
                Else
                    cls_BaoCaoNoiBoNhaO.Get_DiaChiNha = .Item("DiaChi").ToString
                End If
                If IsDBNull(.Item("LoaiNha").ToString) Or .Item("LoaiNha").ToString = "" Then
                    cls_BaoCaoNoiBoNhaO.Get_LoaiNha = "-/-"
                Else
                    cls_BaoCaoNoiBoNhaO.Get_LoaiNha = .Item("LoaiNha").ToString
                End If

                If IsDBNull(.Item("NguonGocNha").ToString) Or .Item("NguonGocNha").ToString = "" Then
                    cls_BaoCaoNoiBoNhaO.Get_NguonGocNha = "-/-"
                Else
                    cls_BaoCaoNoiBoNhaO.Get_NguonGocNha = .Item("NguonGocNha").ToString
                End If
                If IsDBNull(.Item("GiaTriConLai").ToString) Or .Item("GiaTriConLai").ToString = "" Then
                    cls_BaoCaoNoiBoNhaO.Get_GiaTriConLai = "-/-"
                Else
                    cls_BaoCaoNoiBoNhaO.Get_GiaTriConLai = .Item("GiaTriConLai").ToString
                End If
                If IsDBNull(.Item("ThoiHanSoHuu").ToString) Or .Item("ThoiHanSoHuu").ToString = "" Then
                    cls_BaoCaoNoiBoNhaO.Get_ThoiHanSoHuu = "-/-"
                Else
                    cls_BaoCaoNoiBoNhaO.Get_ThoiHanSoHuu = .Item("ThoiHanSoHuu").ToString
                End If
            End With
        End If
        Return cls_BaoCaoNoiBoNhaO
    End Function
    Public Function BaoCaoDuThaoCapGCN(ByVal MaHoSoCapGCN As String) As DataTable
        Dim dt As New DataTable
        If frmNghiepVuHoSo.CtrlNghiepVuHoSo1.MaHoSoCapGCN <> "" Then
            Dim cls As New clsBaoCaoNoiBo
            cls.Connection = GetConnection(bolKetNoiCSDL)
            cls.MaHoSoCapGCN = MaHoSoCapGCN
            cls.SelecThongTinThuaDat_NhaO(dt)
        End If
        Return dt
    End Function
    Public Function BaoCaoNoiBoThuaDat(ByVal MaHoSoCapGCN As String) As clsBaoCaoNoiBo
        Try
            TableThuaDat(MaHoSoCapGCN)
            If TableThuaDat(MaHoSoCapGCN).Rows.Count > 0 Then
                With TableThuaDat(MaHoSoCapGCN).Rows(0)
                    cls_BaoCaoNoiBoThuaDat.Get_ToBanDo = .Item("ToBanDo").ToString.ToUpper()
                    cls_BaoCaoNoiBoThuaDat.Get_ThuaDat = .Item("SoThua").ToString.ToUpper()
                    cls_BaoCaoNoiBoThuaDat.Get_DiaChiNha = .Item("DiaChi").ToString
                    cls_BaoCaoNoiBoThuaDat.Get_DienTich = .Item("DienTich").ToString
                    cls_BaoCaoNoiBoThuaDat.Get_DienTichRieng = .Item("DienTichRieng").ToString
                    cls_BaoCaoNoiBoThuaDat.Get_DienTichChung = .Item("DienTichChung").ToString
                    cls_BaoCaoNoiBoThuaDat.Get_MucDichSuDung = .Item("MucDichSuDung").ToString
                    cls_BaoCaoNoiBoThuaDat.Get_ThoiHanSuDung = .Item("ThoiHanSuDung").ToString
                    cls_BaoCaoNoiBoThuaDat.Get_NguonGocSuDung = .Item("NguonGocSuDung").ToString
                    If IsDBNull(.Item("ToTrinhPhuong").ToString) Or .Item("ToTrinhPhuong").ToString = "" Then
                        cls_BaoCaoNoiBoThuaDat.Get_ToTrinhPhuong = "     "
                    Else
                        cls_BaoCaoNoiBoThuaDat.Get_ToTrinhPhuong = .Item("ToTrinhPhuong").ToString
                    End If

                    If IsDBNull(.Item("NgayTrinhPhuong").ToString) Or .Item("NgayTrinhPhuong").ToString = "" Then
                        cls_BaoCaoNoiBoThuaDat.Get_NgayTrinhPhuong = "Ngày ..../..../" & Now.Year
                    Else
                        cls_BaoCaoNoiBoThuaDat.Get_NgayTrinhPhuong = .Item("NgayTrinhPhuong").ToString
                    End If
                    If IsDBNull(.Item("SoToTrinhDiaChinh").ToString) Or .Item("SoToTrinhDiaChinh").ToString = "" Then
                        cls_BaoCaoNoiBoThuaDat.get_SoToTrinhDiaChinh = "     "
                    Else
                        cls_BaoCaoNoiBoThuaDat.get_SoToTrinhDiaChinh = .Item("SoToTrinhDiaChinh").ToString
                    End If
                    If IsDBNull(.Item("NgayTrinhDiaChinh").ToString) Then
                        cls_BaoCaoNoiBoThuaDat.get_NgayTrinhDiaChinh = "Ngày ..../..../" & Now.Year
                    Else
                        cls_BaoCaoNoiBoThuaDat.get_NgayTrinhDiaChinh = .Item("NgayTrinhDiaChinh").ToString
                    End If
                    If IsDBNull(.Item("SoPhatHanhGCN").ToString) Then
                        cls_BaoCaoNoiBoThuaDat.SoPhatHanhGCN = "    " & Now.Year
                    Else
                        cls_BaoCaoNoiBoThuaDat.SoPhatHanhGCN = .Item("SoPhatHanhGCN").ToString
                    End If
                    cls_BaoCaoNoiBoThuaDat.get_HoTenCanBoThamDinh = .Item("HoTenCanBoThamDinhDKND").ToString
                    cls_BaoCaoNoiBoThuaDat.Get_DatO = .Item("YKDienTichDatO").ToString
                    cls_BaoCaoNoiBoThuaDat.Get_DatVuon = .Item("YKDienTichVuonAo").ToString
                    cls_BaoCaoNoiBoThuaDat.Get_SoSeriToTrinh = .Item("SoSerriToTrinh").ToString
                    cls_BaoCaoNoiBoThuaDat.Get_DienTichXD = .Item("YKDienTichXD").ToString

                    cls_BaoCaoNoiBoThuaDat.Get_LoaiDuong = .Item("LoaiDuong").ToString
                    cls_BaoCaoNoiBoThuaDat.Get_NgoRong = .Item("NgoRong").ToString
                    cls_BaoCaoNoiBoThuaDat.Get_ViTri = .Item("ViTri").ToString
                    cls_BaoCaoNoiBoThuaDat.Get_CachDuongChinh = .Item("CachDuongChinh").ToString
                    cls_BaoCaoNoiBoThuaDat.Get_LPTB = .Item("LPTB").ToString
                    cls_BaoCaoNoiBoThuaDat.Get_TTNCN = .Item("TTNCN").ToString
                    cls_BaoCaoNoiBoThuaDat.Get_NoiDungHoSo = .Item("NoiDungHoSo").ToString
                    cls_BaoCaoNoiBoThuaDat.Get_DieuKhoan = .Item("DieuKhoan").ToString

                    cls_BaoCaoNoiBoThuaDat.DT100GiaDat = .Item("DT100GiaDat").ToString
                    cls_BaoCaoNoiBoThuaDat.DT50GiaDat = .Item("DT50GiaDat").ToString
                    cls_BaoCaoNoiBoThuaDat.DT40GiaDat = .Item("DT40GiaDat").ToString
                    cls_BaoCaoNoiBoThuaDat.DT20GiaDat = .Item("DT20GiaDat").ToString

                End With
            End If
        Catch ex As Exception
            Return Nothing
        End Try
        Return cls_BaoCaoNoiBoThuaDat
    End Function
    Public Function BaoCaoNoiBoNghiaVuTaiChinh_TranhChap_NguoiKyGCN(ByVal MaHoSoCapGCN As String) As clsBaoCaoNoiBo

        TableNghiaVuTaiChinh_TranhChap_NguoiKyGCN(MaHoSoCapGCN)
        If TableNghiaVuTaiChinh_TranhChap_NguoiKyGCN(MaHoSoCapGCN).Rows.Count > 0 Then
            With TableNghiaVuTaiChinh_TranhChap_NguoiKyGCN(MaHoSoCapGCN).Rows(0)
                cls_BaoCaoNoiBoNghiaVuTaiChinh_TranhChap_NguoiKyGCN.Get_NghiaVuTaiChinh = .Item("NghiaVuTaiChinh").ToString
                cls_BaoCaoNoiBoNghiaVuTaiChinh_TranhChap_NguoiKyGCN.Get_KhieuNaiTranhChap = .Item("NoiDungTranhChapKhieuKien").ToString
                cls_BaoCaoNoiBoNghiaVuTaiChinh_TranhChap_NguoiKyGCN.Get_TruongPhong = .Item("NguoiKyGCN").ToString
            End With
        End If
        Return cls_BaoCaoNoiBoNghiaVuTaiChinh_TranhChap_NguoiKyGCN
    End Function
    Private Sub mnuBaoCaoBaoCaoNoiBo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuBaoCaoBaoCaoNoiBo.Click
        If frmNghiepVuHoSo.CtrlNghiepVuHoSo1.MaHoSoCapGCN <> "" Then
            Dim MaHoSoCapGCN As String
            MaHoSoCapGCN = frmNghiepVuHoSo.CtrlNghiepVuHoSo1.MaHoSoCapGCN
            If MaHoSoCapGCN = "" Then
                MessageBox.Show("Bạn chưa chọn hồ sơ để in báo cáo", Nothing, MessageBoxButtons.OK)
            Else : InBaoCaoNoiBo(MaHoSoCapGCN)
            End If
        End If
        'MsgBox(MaHoSoCapGCN.ToString)
    End Sub

    Private Sub toolSoanHoSoKyThuat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolSoanHoSoKyThuat.Click
        If intGlobalMaDonViHanhChinh = 0 Then
            frmDanhSachDVHC.ShowDialog()
        End If
        If frmNghiepVuHoSo.CtrlNghiepVuHoSo1.MaHoSoCapGCN = "" Then
            Return
        End If
        If User.DonViHanhChinhHienThoi.ToString = "0" Then
            Return
        End If
        'If Me.ActiveMdiChild.Name.Length = 0 Then
        '    Me.ActiveMdiChild.Hide()
        'End If
        DeleteProcess()
        Try
            Dim MaHoSo As Long
            'Dim myfrmSoanHS As frmSoanHoSo
            'myfrmSoanHS.MdiParent = Me

            Dim frm As Form
            Dim Count As Integer = 0
            For Each frm In Me.MdiChildren
                If frm.Name = "frmSoanHoSo" Then
                    Count = Count + 1
                End If
            Next
            If Count > 0 Then
                frmSoanHoSo.BringToFront()
                Return
            End If
            With frmSoanHoSo
                .MdiParent = Me
                .WindowState = FormWindowState.Maximized
            End With

            With frmSoanHoSo.CtrSoanHS1
                .SererName = strGlobalServerName
                .DatabaseName = strGlobalDatabaseName
                .UID = strGlobalUserID
                .Upass = strGlobalUserPassword
                MaHoSo = Convert.ToInt64(frmNghiepVuHoSo.CtrlNghiepVuHoSo1.MaHoSoCapGCN)
                .HoSoCapGCN = MaHoSo
                .MaDonViHanhChinh = intGlobalMaDonViHanhChinh.ToString()
                Dim strTenBangDVHC As String = ThaoTacPhuongHienThoi(User.DonViHanhChinhHienThoi)
                .tabNha = strTenBangDVHC & "Nha"
                .tabBanDo = strTenBangDVHC & "tblDLieuKGianThuaDat"
                .tabSoanHoSo = strTenBangDVHC & "TBLSOANHOSOTHUADAT"
                .TenBangDVHC = strTenBangDVHC 'ThaoTacPhuongHienThoi(User.DonViHanhChinhHienThoi)
                .LoadForm()

            End With
            frmSoanHoSo.Show()
        Catch ex As Exception
            System.Windows.Forms.MessageBox.Show(Me, "Hãy tạo hồ sơ cho thửa đất trước khi thực hiện chức năng Soạn bản đồ !!!", "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub toolTinhToanDenBu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolTinhToanDenBu.Click
        'Dim TinhToanDenBu As New DMC.Land.TinhToanDenBu.frmTinhToanDenBu
        'TinhToanDenBu.ctrlTinhToanDenBu.Connection = GetConnection(bolKetNoiCSDL)
        'TinhToanDenBu.ctrlTinhToanDenBu.DonViHanhChinh = intGlobalMaDonViHanhChinh.ToString()
        'TinhToanDenBu.StartPosition = FormStartPosition.CenterScreen
        'TinhToanDenBu.WindowState = FormWindowState.Maximized
        'TinhToanDenBu.Show()
    End Sub

    'Private Sub XuấtDữLiệuTừBảnĐồToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripXuatDuLieuTuBanDo.Click
    '    'Try
    '    '    Dim MaHoSo As Long
    '    '    Dim frmXuatDuLieu As New FrmXuatDuLieuTuBanDo
    '    '    frmXuatDuLieu.MdiParent = Me
    '    '    With frmXuatDuLieu.CtrSoanHS1
    '    '        .SererName = strGlobalServerName
    '    '        .DatabaseName = strGlobalDatabaseName
    '    '        .UID = strGlobalUserID
    '    '        .Upass = strGlobalUserPassword
    '    '        MaHoSo = Convert.ToInt64(frmNghiepVuHoSo.CtrlNghiepVuHoSo1.MaHoSoCapGCN)
    '    '        .HoSoCapGCN = MaHoSo
    '    '        .MaDonViHanhChinh = intGlobalMaDonViHanhChinh.ToString()
    '    '        .LoadForm()
    '    '    End With
    '    '    frmXuatDuLieu.Show()
    '    'Catch ex As Exception
    '    '    System.Windows.Forms.MessageBox.Show(Me, "Lỗi mở chức năng soạn Sơ đồ Nhà, đất: " + ex.Message, "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    'End Try01693268869
    'End Sub

    Private Sub ToolLichSuBienDong_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolLichSuBienDong.Click
        If frmNghiepVuHoSo.CtrlNghiepVuHoSo1.MaHoSoCapGCN <> "" And frmNghiepVuHoSo.CtrlNghiepVuHoSo1.MaThuaDat <> "" And frmNghiepVuHoSo.CtrlNghiepVuHoSo1.MaThuaDat <> Nothing Then
            If intGlobalMaDonViHanhChinh = 0 Or intGlobalMaDonViHanhChinh = "0" Then
                frmDanhSachDVHC.ShowDialog()
            End If
            Dim frm As New frmLichSuBienDong
            With frm.CtrLichSuHSBienDong1
                .Connection = GetConnection(bolKetNoiCSDL)
                .MaHoSoCapGCN = Convert.ToInt64(frmNghiepVuHoSo.CtrlNghiepVuHoSo1.MaHoSoCapGCN)
                .MaThuaDat = Convert.ToInt64(frmNghiepVuHoSo.CtrlNghiepVuHoSo1.MaThuaDat)
                .MaDonViHanhChinh = User.DonViHanhChinhHienThoi
                .ShowData()
            End With
            frm.ShowDialog()
        End If
    End Sub

    Private Sub ToolBaoCaoKyThuat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolBaoCaoKyThuat.Click
        Try
            If frmNghiepVuHoSo.CtrlNghiepVuHoSo1.MaHoSoCapGCN = "" Then
                Return
            End If
            If User.DonViHanhChinhHienThoi.ToString = "0" Then
                Return
            End If
            Dim shostname As String
            shostname = System.Net.Dns.GetHostName

            Dim dt = New DataTable()
            Dim cls As New clsHoSoCapGCN
            cls.Connection = GetConnection(bolKetNoiCSDL)
            Dim strMaHoSo As String = ""
            strMaHoSo = frmNghiepVuHoSo.CtrlNghiepVuHoSo1.MaHoSoCapGCN
            TaoFileMaHoSoCapGCN(strMaHoSo)
            If strMaHoSo <> "" Then
                cls.MaHoSoCapGCN = strMaHoSo
                cls.MaDonViHanhChinh = User.DonViHanhChinhHienThoi
                cls.GetFileMap(0, dt)
                Dim dir As New DirectoryInfo(System.Windows.Forms.Application.StartupPath & "\dataHSKT\")
                Dim file() As System.IO.FileInfo = dir.GetFiles("*.tab")
                For i As Integer = 0 To file.Length - 1
                    XoaFileTmp(dir.FullName & "\" & file(i).Name)
                Next
                If (dt.Rows.Count > 0) Then
                 
                    DeleteProcess()
                    If WriteFile(strMaHoSo.ToString(), "tab", CType(dt.Rows(0)("FileTab"), Byte())) = False Then
                        MessageBox.Show(" Không export được file Tab")
                        Return
                    End If
                    If WriteFile(strMaHoSo.ToString(), "Dat", CType(dt.Rows(0)("FileDat"), Byte())) = False Then

                        MessageBox.Show(" Không export được file Dat")
                        Return
                    End If
                    If WriteFile(strMaHoSo.ToString(), "ID", CType(dt.Rows(0)("FileID"), Byte())) = False Then
                        MessageBox.Show(" Không export được file ID")
                        Return
                    End If
                    If WriteFile(strMaHoSo.ToString(), "Map", CType(dt.Rows(0)("FileMap"), Byte())) = False Then
                        MessageBox.Show(" Không export được file Map")
                        Return
                    End If
                End If
                ' ExportAnhThua()
                Dim Path As String = ""
                Path = System.Windows.Forms.Application.StartupPath & "\InGiayChungNhan.exe"
                If System.IO.File.Exists(Path) Then
                    Process.Start(Path)
                Else
                    MessageBox.Show("Kiểm tra lại file thực thi in giấy chứng nhận!!!", "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
                'Else
                '    MessageBox.Show("Soạn hồ sơ kỹ thuật trước khi thực thi việc in ấn!!!", "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                'End If
            Else
                MessageBox.Show("Chọn hồ sơ trước khi thực hiện chức năng này !!!", "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MessageBox.Show("Hãy tắt chức năng rồi thử lại !!!", "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try

    End Sub

    Public Sub ExportAnhThua()
        If frmNghiepVuHoSo.CtrlNghiepVuHoSo1.MaHoSoCapGCN <> "" Then
            Dim cls As New clsHoSoCapGCN
            Dim dt As New DataTable
            With cls
                .Connection = GetConnection(bolKetNoiCSDL)
                .MaHoSoCapGCN = frmNghiepVuHoSo.CtrlNghiepVuHoSo1.MaHoSoCapGCN
                .MaDonViHanhChinh = User.DonViHanhChinhHienThoi
                .SelectAnhThuaDat(dt)
                If dt.Rows.Count > 0 Then
                    If dt.Rows(0).Item(0).ToString = "True" Then
                        Dim objFstream As System.IO.FileStream
                        Dim byteContent As Byte() = CType(dt.Rows(0)("anhthuadat"), Byte())
                        Dim Path As String = ""
                        Path = System.Windows.Forms.Application.StartupPath
                        Try
                            objFstream = System.IO.File.Open(Path & "\" & frmNghiepVuHoSo.CtrlNghiepVuHoSo1.MaHoSoCapGCN.ToString().Trim + ".jpg", FileMode.Create, FileAccess.Write)
                            Dim lngLen As Long = byteContent.Length
                            objFstream.Write(byteContent, 0, CInt(lngLen))
                            objFstream.Flush()
                        Catch ex As Exception
                            MessageBox.Show(" Lỗi ghi dữ liệu !", "DMCLand")
                        Finally
                            objFstream.Close()
                        End Try
                    End If
                End If
            End With
        End If
    End Sub
    Public Sub XoaFileTmp(ByVal fileName As String)
        Try
            Dim tabFile, datFile, idFile, mapFile As String
            Dim tabFileObj As System.IO.FileInfo
            tabFileObj = New System.IO.FileInfo(fileName.ToUpper)
            tabFile = tabFileObj.Name.ToString()
            datFile = tabFileObj.Name.Replace(".TAB".ToUpper, ".DAT".ToUpper)
            Dim datFileObj As New System.IO.FileInfo(tabFileObj.Directory.FullName & "\" & datFile)
            idFile = tabFileObj.Name.Replace(".TAB".ToUpper, ".ID".ToUpper)
            Dim idFileObj As New System.IO.FileInfo(tabFileObj.Directory.FullName & "\" & idFile)
            mapFile = tabFileObj.Name.Replace(".TAB".ToUpper, ".MAP".ToUpper)
            Dim mapFileObj As New System.IO.FileInfo(tabFileObj.Directory.FullName + "\" + mapFile)
            tabFileObj.Delete()
            datFileObj.Delete()
            idFileObj.Delete()
            mapFileObj.Delete()
        Catch ex As Exception

        End Try
    End Sub
    Public Function WriteFile(ByVal MaHoSoCapGCN As String, ByVal KieuFile As String, ByVal byteContent As Byte()) As Boolean

        Dim objFstream As System.IO.FileStream
        Dim Path As String = ""
        Path = System.Windows.Forms.Application.StartupPath
        Try
            objFstream = System.IO.File.Open(Path & "\DataHSKT\" & MaHoSoCapGCN + "." + KieuFile, FileMode.Create, FileAccess.Write)
            Dim lngLen As Long = byteContent.Length
            objFstream.Write(byteContent, 0, CInt(lngLen))
            objFstream.Flush()
            Return True
        Catch ex As Exception
            MessageBox.Show(" Lỗi ghi dữ liệu !", "DMCLand")
            Return False
        Finally
            objFstream.Close()
        End Try
    End Function

    Public Sub DeleteProcess()
        For Each myProcess As Diagnostics.Process In Diagnostics.Process.GetProcessesByName("InGiayChungNhan")
            'If Not myProcess.CloseMainWindow Then
            myProcess.Kill()
            'End If
        Next
    End Sub

    Private Sub mnuTroGiup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuTroGiup.Click
        Dim Path As String = ""
        Path = System.Windows.Forms.Application.StartupPath & "\HELP_DMCLAND.CHM"
        If System.IO.File.Exists(Path) Then
            Process.Start(Path)
        End If
    End Sub

    Private Sub UploadToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UploadToolStripMenuItem.Click
        Dim frm As New frmUploadBanDo
        frm.CtrToolUploadMap1.Connection = GetConnection(bolKetNoiCSDL)
        frm.CtrToolUploadMap1.LoadDanhSachDuAn()
        frm.Show()
    End Sub

    Private Sub ToolStripMenuItemMayChuPhuong_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)


    End Sub

    Private Sub ToolStripMenuItemMayChuQuan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub



    Private Sub ToolStripMenuItemTaiDuLieuQuan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemTaiDuLieuQuan.Click
        If bolKetNoiCSDL Then
            If frmNghiepVuHoSo.CtrlNghiepVuHoSo1.MaHoSoCapGCN <> "" And frmNghiepVuHoSo.CtrlNghiepVuHoSo1.MaHoSoCapGCN <> "0" Then
                Dim cls As New clsHoSoCapGCN
                cls.Connection = GetConnection(False)
                Dim dt As New DataTable
                Dim kt As String = ""
                With cls
                    .MaHoSoCapGCN = frmNghiepVuHoSo.CtrlNghiepVuHoSo1.MaHoSoCapGCN
                    .MaDonViHanhChinh = User.DonViHanhChinhHienThoi
                    .selKTTonTaiCuaHoSo(dt)
                    cls.Connection = GetConnection(True)
                    If dt.Rows.Count > 0 Then
                        If (MessageBox.Show("Đã tồn tại hồ sơ " & frmNghiepVuHoSo.CtrlNghiepVuHoSo1.MaHoSoCapGCN & " ! " & vbNewLine & " Bạn có muốn tạo lại không ?", "DMCLand", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = System.Windows.Forms.DialogResult.Yes) Then
                            'truong hop update lai ho so
                            kt = cls.UpDateDuLieuTuPhuongLenQuan(1)
                            If kt <> "0" Then
                                MessageBox.Show("Tải dữ liệu thành công !", "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Else
                                MessageBox.Show("Tải dữ liệu thất bại!", "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            End If
                        End If
                    Else
                        'truong hop them moi
                        kt = cls.UpDateDuLieuTuPhuongLenQuan(0)
                        If kt <> "0" Then
                            MessageBox.Show("Tải dữ liệu thành công !", "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Else
                            MessageBox.Show("Tải dữ liệu thất bại!", "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    End If
                End With

            End If
        End If
    End Sub

    Private Sub ToolStripMenuItemKhoiTaoDuLieuBanDo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ToolStripMenuItemQuanLyGiaoViec_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemQuanLyGiaoViec.Click
        Dim frm As New frmLichGiaoViec
        With frm
            .CtrQuanLyGiaoViec1.Conection = GetConnection(bolKetNoiCSDL)
            .CtrQuanLyGiaoViec1.UserName = User.ServerName
            .CtrQuanLyGiaoViec1.MaDonViHanhChinh = User.DonViHanhChinhHienThoi
            .Show()
        End With
    End Sub

    Private Sub MenuItemQuyetDinhCapGCNHoGiaDinh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemQuyetDinhCapGCNHoGiaDinh.Click
        If frmNghiepVuHoSo.CtrlNghiepVuHoSo1.MaHoSoCapGCN <> "" Then
            Dim MaHoSoCapGCN As String
            MaHoSoCapGCN = frmNghiepVuHoSo.CtrlNghiepVuHoSo1.MaHoSoCapGCN
            If MaHoSoCapGCN = "" Then
                MessageBox.Show("Bạn chưa chọn hồ sơ để in báo cáo", Nothing, MessageBoxButtons.OK)
            Else : InBaoCaoQuyetDinhCapGCNHoGD(MaHoSoCapGCN)
            End If
        End If
    End Sub

    Public Function ChuSuDungHoGiaDinh(ByVal strMaHoSoCapGCN As String) As String
        Dim strCSD As String = ""
        If strMaHoSoCapGCN <> "" Then
            Dim dt As New DataTable
            Dim cls As New clsBaoCaoNoiBo
            With cls
                .Connection = GetConnection(bolKetNoiCSDL)
                .MaHoSoCapGCN = strMaHoSoCapGCN
                dt = .selChuSuDungInQuyetDinhByHoGiaDinh()
            End With
            If dt.Rows.Count > 0 Then
                strCSD = dt.Rows(0).Item(0).ToString
            End If
        End If
        Return strCSD
    End Function

    Private Sub ToolStripBaoCaoTongHop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripBaoCaoTongHop.Click
        If User.DonViHanhChinhHienThoi <> "0" Then
            Dim frm As New frmBaoCaoTongHop
            With frm.CtrTongHop1
                'truyen tham so
                .AutoScroll = False
                .Connection = GetConnection(bolKetNoiCSDL)
                .UserName = User.UserName
                .DVHC = User.DonViHanhChinhHienThoi
                .MaQuyen = User.MaQuyen
                .ctrLoad_Tonghop()
            End With
            frm.Show()
        Else
            MessageBox.Show("Chọn đơn vị hành chính trước khi thức hiện xem, in báo cáo", "DMCLand")
        End If
    End Sub

    Private Sub Word972003ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Word2007ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub MáyChủPhườngToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MáyChủPhườngToolStripMenuItem.Click
        Dim conn As New SqlConnection
        Try
            bolKetNoiCSDL = True
            Me.Text = "DMCLand - @CSDL Phuong"
            conn.ConnectionString = GetConnection(bolKetNoiCSDL)
            conn.Open()
            MessageBox.Show("Kết nối dữ liệu Phường thành công !", "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Information)
            conn.Close()
        Catch ex As Exception
            MessageBox.Show("Kết nối dữ liệu Phường thất bại !", "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Information)
            conn.Dispose()
        End Try
    End Sub

    Private Sub MáyChủQuậnToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MáyChủQuậnToolStripMenuItem.Click
        Dim conn As New SqlConnection
        Try
            bolKetNoiCSDL = False
            Me.Text = "DMCLand - @CSDL Quan"
            conn.ConnectionString = GetConnection(bolKetNoiCSDL)
            conn.Open()
            MessageBox.Show("Kết nối dữ liệu Quận thành công !", "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Information)
            conn.Close()
        Catch ex As Exception
            MessageBox.Show("Kết nối dữ liệu Quận thất bại !", "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Information)
            conn.Dispose()
        End Try
    End Sub

    Private Sub KhởiTạoDữLiệuToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KhởiTạoDữLiệuToolStripMenuItem.Click
        Dim frm As New frmKhoiTaoDuLieuBanDoPhuong
        With frm.UcListDVHC1
            .Get_ArrDVHC = User.DonViHanhChinh
            .Get_MaQuyen = User.MaQuyen
            .Get_SqlCon = User.SQLConnection
            .Get_CurrDVHC = User.DonViHanhChinhHienThoi
            .hienthi()
        End With

        frm.ShowDialog()
    End Sub

    Private Sub Word972003ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Word972003ToolStripMenuItem1.Click
        SaveSetting(System.Reflection.Assembly.GetExecutingAssembly.Location, "DuoiWord", "DuoiWord", "doc")
    End Sub

    Private Sub Word2007ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Word2007ToolStripMenuItem1.Click
        SaveSetting(System.Reflection.Assembly.GetExecutingAssembly.Location, "DuoiWord", "DuoiWord", "docx")
    End Sub

    Private Sub ToolStripMenuItemNhatKyNguoiDung_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemNhatKyNguoiDung.Click
        Dim frm As New frmNhatKyNguoiDung
        frm.Connection = GetConnection(bolKetNoiCSDL)
        frm.ShowDialog()
    End Sub

    Private Sub PhanQuyenChucNangToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PhanQuyenChucNangToolStripMenuItem.Click
        If User.MaQuyen > 2 Then
            MessageBox.Show("Bạn không có quyền thực hiện chức năng này", "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        Else
            Dim frm As New frmPhanQuyenChucNang
            frm.CtrPhanQuyenQuyTrinhChucNang1.Connection = GetConnection(bolKetNoiCSDL)
            frm.CtrPhanQuyenQuyTrinhChucNang1.ShowDanhSachNguoiDung()
            frm.Show()
        End If
     
    End Sub

    Private Sub toolQuanLyLuanChuyenHoSo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolQuanLyLuanChuyenHoSo.Click
        If User.DonViHanhChinhHienThoi > 0 Then
            Dim frm As New frmLuanChuyenHoSo
            With frm.CtrLuanChuyen1
                .Conection = GetConnection(bolKetNoiCSDL)
                .MaDonViHanhChinh = User.DonViHanhChinhHienThoi
            End With
            frm.Show()
        Else
            MessageBox.Show("Hãy chọn đơn vị hành chính trước khi thực hiện luân chuyển hồ sơ", "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub


    Private Sub TaiHoSoKyThuatToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TaiHoSoKyThuatToolStripMenuItem.Click
        If frmNghiepVuHoSo.CtrlNghiepVuHoSo1.MaHoSoCapGCN.ToString <> "0" And frmNghiepVuHoSo.CtrlNghiepVuHoSo1.MaHoSoCapGCN.ToString <> "" Then
            Dim dlgOpenFile As New OpenFileDialog
            With dlgOpenFile
                .Title = "Chon tai lieu"
                .Multiselect = True
                .Filter = "Table File (*.Tab)|*.Tab"
                If .ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    Dim file As String = ""
                    file = .FileName
                    Dim strFileTab As String = file
                    Dim strFileMap As String = strFileTab.Split(".")(0) & ".Map"
                    Dim strFileID As String = strFileTab.Split(".")(0) & ".ID"
                    Dim strFiledat As String = strFileTab.Split(".")(0) & ".Dat"

                    Dim clsData As New DMC.GIS.Common.clsDatabase
                    'Dim Conn As New SqlConnection
                    'Conn.ConnectionString = GetConnection(bolKetNoiCSDL)
                    'Conn.Open()

                    clsData.SetConnection(GetConnection(bolKetNoiCSDL))
                    Dim TablFile() As Byte = ReadFile(strFileTab)
                    Dim MaplFile() As Byte = ReadFile(strFileMap)
                    Dim IDlFile() As Byte = ReadFile(strFileID)
                    Dim DatlFile() As Byte = ReadFile(strFiledat)
                    clsData.UpdateMapFile(1, frmNghiepVuHoSo.CtrlNghiepVuHoSo1.MaHoSoCapGCN, TablFile, MaplFile, IDlFile, DatlFile, 0, 0, 0)

                End If
            End With
        End If
    End Sub
    Public Function ReadFile(ByVal strPath As String) As Byte()
        Dim byteData() As Byte
        Dim fInfo As New System.IO.FileInfo(strPath)
        Dim numBytes As Long
        numBytes = fInfo.Length
        Dim fStream As FileStream
        fStream = New System.IO.FileStream(strPath, System.IO.FileMode.Open, System.IO.FileAccess.Read)
        Dim br As New System.IO.BinaryReader(fStream)
        byteData = br.ReadBytes(Convert.ToInt32(numBytes))
        Return byteData
    End Function
    Private Sub InBaoCao(ByVal MaHoSoCapGCN As String)

        Dim strTemp As String = ""
        Dim strOut As String = ""
        strDuoiWord = GetSetting(System.Reflection.Assembly.GetExecutingAssembly.Location, "DuoiWord", "DuoiWord")
        If strDuoiWord = "" Then
            strDuoiWord = "doc"
        End If
        BaoCaoNoiBoChuSuDung(MaHoSoCapGCN)
        Dim NguonGoc As String
        NguonGoc = TableNguonGocCap(MaHoSoCapGCN)
        If NguonGoc = "3" Then
            'strTemp = System.Windows.Forms.Application.StartupPath + "\temp\Mau ho so cap GCN 2010 - Hoan Kiem.doc"
            strTemp = System.Windows.Forms.Application.StartupPath + "\temp\HoSoCapGCNVPDD." & strDuoiWord
            strOut = System.Windows.Forms.Application.StartupPath + "\Ketqua\TT_QD_TTDC_" + Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + "h_" + Now.Minute.ToString + "'_" + Now.Second.ToString + "s_" + BaoCaoNoiBoChuSuDung(MaHoSoCapGCN).Get_ChuSuDung + "." + strDuoiWord + ""
        ElseIf NguonGoc = "2" Or NguonGoc = "4" Then
            strTemp = System.Windows.Forms.Application.StartupPath + "\temp\HoSoCapGCNCtyNha." & strDuoiWord
            strOut = System.Windows.Forms.Application.StartupPath + "\Ketqua\TT_QD_TTDC_" + Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + "h_" + Now.Minute.ToString + "'_" + Now.Second.ToString + "s_" + BaoCaoNoiBoChuSuDung(MaHoSoCapGCN).Get_ChuSuDung + "." + strDuoiWord + ""
        ElseIf NguonGoc = "1" Then
            strTemp = System.Windows.Forms.Application.StartupPath + "\temp\HoSoCapGCN." & strDuoiWord
            strOut = System.Windows.Forms.Application.StartupPath + "\Ketqua\TT_QD_TTDC_" + Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + "h_" + Now.Minute.ToString + "'_" + Now.Second.ToString + "s_" + BaoCaoNoiBoChuSuDung(MaHoSoCapGCN).Get_ChuSuDung + "." + strDuoiWord + ""
        End If
        If NguonGoc <> "" Then
            Creat_Word_BaoCaoNoiBo_HoangMai(strTemp, strOut, MaHoSoCapGCN)
            OW = New Word.Application
            OW.Visible = True
            Try
                DOC = OW.Documents.Open(strOut)
                OW.Activate()
            Catch ex As Exception
                OW.Quit()
            End Try
        End If
    End Sub

    Private Sub TờTrìnhQuyếtĐịnhToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TờTrìnhQuyếtĐịnhToolStripMenuItem.Click
        If frmNghiepVuHoSo.CtrlNghiepVuHoSo1.MaHoSoCapGCN <> "" Then
            Dim MaHoSoCapGCN As String
            MaHoSoCapGCN = frmNghiepVuHoSo.CtrlNghiepVuHoSo1.MaHoSoCapGCN
            If MaHoSoCapGCN = "" Then
                MessageBox.Show("Bạn chưa chọn hồ sơ để in báo cáo", Nothing, MessageBoxButtons.OK)
            Else : InBaoCao(MaHoSoCapGCN)
            End If
        End If

    End Sub
    Public Function TableNguonGocCap(ByVal MaHoSoCapGCN As String) As String
        Dim MaNguon As String = ""
        Dim tbThuaDat As New DataTable
        Dim con As String = GetConnection(bolKetNoiCSDL)
        Dim Connection As New SqlConnection(con)
        'Đổ dữ liệu vào DataTable thửa đất
        Dim cmd As New SqlCommand("SPSelectNguonGocCap", Connection)
        cmd.CommandType = CommandType.StoredProcedure
        Dim Para As New SqlParameter
        Para = cmd.Parameters.Add("MaHoSoCapGCN", SqlDbType.BigInt)
        Para.Value = Integer.Parse(MaHoSoCapGCN)
        Dim sqlDataAdapter As New SqlDataAdapter(cmd)
        'Điền dữ liệu vào đối tượng DataTable
        sqlDataAdapter.Fill(tbThuaDat)
        If (tbThuaDat.Rows.Count > 0) Then
            MaNguon = tbThuaDat.Rows(0).Item(0).ToString()
        End If
        Return MaNguon
    End Function

    Private Sub ToolStripMenuItemThamSoMacDinh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemThamSoMacDinh.Click
        Dim frm As New frmThamSoMacDinh
        With frm.CtrThamSoMacDinh1
            .Connection = GetConnection(bolKetNoiCSDL)
            .ShowData()
        End With
        frm.Show()
    End Sub

    Private Sub ToolStripMenuItemThongKeHoSoNhap_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemThongKeHoSoNhap.Click
        Dim frm As New frmThongKeHoSoNhap
        With frm
            .Connection = GetConnection(bolKetNoiCSDL)
            .MaDonViHanhChinh = User.DonViHanhChinhHienThoi
            .ShowData()
        End With
        frm.Show()
    End Sub

    Private Sub mnuBaoCao_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuBaoCao.Click

    End Sub
End Class




