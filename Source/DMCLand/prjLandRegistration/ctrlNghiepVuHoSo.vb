'Imports DMC.WinFormsUI
Imports System.Windows.Forms
Imports System.Drawing
Imports DMC.Interface.OutlookBar
Imports System.Data.SqlClient

'Imports DMC.Land.ChuSuDungDat
'PHẦN HỒ SƠ CẤP GCN
Imports DMC.Land.ThongTinThuaKeKhai
''' <summary>
''' Control này phục vụ cho phần nghiệp vụ về Hồ sơ cấp GCN ban đầu
''' Bao gồm 2 nhiệm vụ cơ bản:
''' 1. ACTIVE CHỨC NĂNG NGHIỆP VỤ VỀ HỒ SƠ
''' 2. LIÊN HỆ GIỮA VIỆC ACTIVE TỪNG CHỨC NĂNG NGHIỆP VỤ VỚI CONTROL NGHIỆP VỤ TƯƠNG ỨNG
''' 3. ACTIVE TỪNG CONTROL NGHIỆP VỤ
''' 4. THÊM MỚI VÀ XÓA HỒ SƠ CẤP GCN (PHẦN NÀY CẦN XEM LẠI)
''' </summary>
''' <remarks></remarks>
Public Class ctrlNghiepVuHoSo

#Region "KHAI BÁO CÁC BIẾN CHO PHẦN ACTIVE CÁC CHỨC NĂNG"
    'Khai báo biến Mã đơn vị hành chính
    Private strMaDonViHanhChinh As String = ""
    Public Property MaDonViHanhChinh() As String
        Get
            Return strMaDonViHanhChinh
        End Get
        Set(ByVal value As String)
            strMaDonViHanhChinh = value
        End Set
    End Property
    'Khai báo biến Mã thửa đất
    Private strMaThuaDat As String = ""
    'Khai báo biến Mã hồ sơ cấp GCN
    Private strMaHoSoCapGCN As String = ""
    'Khai báo biến Tờ bản đồ
    Private strToBanDo As String = ""
    'Khai báo biến số hiệu thửa đất
    Private strSoHieuThua As String = ""
    'Khai báo biến diện tích tự nhiên
    Private strDienTichTuNhien As String = "0"
    'Khai báo biến Địa chỉ thửa đất
    Private strDiaChiThua As String = ""
    'Trạng thái Hồ sơ cấp GCN
    Private intTrangThaiHoSoCapGCN As Integer = 0
    Private strmakhoahoso As String = ""
    Dim blnChangeStatus As Boolean = False
    Private strKhoaSoGCN As String = ""
    Private strMaTaiSan As String = ""
#End Region
    Public Sub NhatKyNguoiDung(ByVal Nghiepvu As String, ByVal ChucNang As String, ByVal MoTa As String)
        Dim clsNhatky As New prjNhatKyNguoiDung.clsNhatKyNguoiDung
        clsNhatky.Connection = GetConnection(bolKetNoiCSDL)
        clsNhatky.MaHoSoCapGCN = strMaHoSoCapGCN
        clsNhatky.MaDonViHanhChinh = User.DonViHanhChinhHienThoi
        clsNhatky.NghiepVu = Nghiepvu
        clsNhatky.ChucNang = ChucNang
        clsNhatky.MoTa = MoTa
        clsNhatky.DuongDanFile = Application.StartupPath
        clsNhatky.LuuNhatKyNguoiDung()
    End Sub
    Public Function TenDonViHanhChinh() As String
        Dim DonViHanhChinh As New clsDonViHanhChinh
        'Khai báo biến kiểu DataTable
        Dim dtDonViHanhChinh As New DataTable
        Dim HoSoCapGCN As New clsHoSoCapGCN
        'Khai báo biến kiểu String chứa Mã xã
        Dim strMaXa As String = ""
        Try
            If Not ((strMaThuaDat = "") Or (strMaThuaDat = 0)) Then
                HoSoCapGCN.MaThuaDat = strMaThuaDat
            Else
                MessageBox.Show("Bạn phải chọn thửa đất cần tạo Hồ sơ cấp GCN", "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return strDiaChiThua
            End If
            '-------------- Xác định Mã xã từ Mã đơn vị hành chính -----------------
            With DonViHanhChinh
                .Connection = GetConnection(bolKetNoiCSDL)
                .MaDonViHanhChinh = intGlobalMaDonViHanhChinh.ToString()
                dtDonViHanhChinh.Clear()
                .SelectTuDienDonViHanhChinhByMaXa(dtDonViHanhChinh)
            End With
            'Xác nhận Mã xã tìm được
            strMaXa = dtDonViHanhChinh.Rows(0).Item("MaXa").ToString()
            'Lấy địa chỉ Mặc định
            strDiaChiThua = dtDonViHanhChinh.Rows(0).Item("Ten").ToString() & " - " + dtDonViHanhChinh.Rows(0).Item("TenQuan").ToString() + " - TP Hà Nội"
        Catch ex As Exception

        End Try
        Return strDiaChiThua
    End Function

    '//lay ten phuong
    Public Function TenPhuong() As String
        Dim DonViHanhChinh As New clsDonViHanhChinh
        'Khai báo biến kiểu DataTable
        Dim dtDonViHanhChinh As New DataTable
        Dim HoSoCapGCN As New clsHoSoCapGCN
        'Khai báo biến kiểu String chứa Mã xã
        Dim strMaXa As String = ""
        Try
            If Not ((strMaThuaDat = "") Or (strMaThuaDat = 0)) Then
                HoSoCapGCN.MaThuaDat = strMaThuaDat
            Else
                MessageBox.Show("Bạn phải chọn thửa đất cần tạo Hồ sơ cấp GCN", "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return strDiaChiThua
            End If
            '-------------- Xác định Mã xã từ Mã đơn vị hành chính -----------------
            With DonViHanhChinh
                .Connection = GetConnection(bolKetNoiCSDL)
                .MaDonViHanhChinh = intGlobalMaDonViHanhChinh.ToString()
                dtDonViHanhChinh.Clear()
                .SelectTuDienDonViHanhChinhByMaXa(dtDonViHanhChinh)
            End With
            'Xác nhận Mã xã tìm được
            strMaXa = dtDonViHanhChinh.Rows(0).Item("MaXa").ToString()
            'Lấy địa chỉ Mặc định
            strDiaChiThua = dtDonViHanhChinh.Rows(0).Item("Ten").ToString()
        Catch ex As Exception

        End Try
        Return strDiaChiThua
    End Function

    Private Sub ctrlNghiepVuHoSo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'With Me
        '    .AutoScroll = False
        'End With
        '' Thiết lập giao diện cho OutLook Bar
        'With Me.outlookChucNang
        '    .Renderer = Renderer.Outlook2007
        '    .Dock = DockStyle.Bottom
        'End With
        'Ẩn tất cả các Form chức năng nghiệp vụ
        Me.activeTaskForm()
        ' Me.HienThiChucNangTrenOutlookBar()
        Me.DieuChinhControl()
    End Sub

    ' Hiển thị chức năng trên OutlookBar
    ' theo sự phân quyền bên quản trị

    Private Sub HienThiChucNangTrenOutlookBar()
        'Dim SqlCon As New SqlConnection("Server = DMC-SVR\Map; Database = georgetown; Uid = sa; Pwd = 1")
        Dim SqlCom As New SqlCommand("ProcLayChucNangTheoNguoiDung", User.SQLConnection)
        SqlCom.CommandType = CommandType.StoredProcedure
        SqlCom.Parameters.Add("@UserName", SqlDbType.NVarChar)
        SqlCom.Parameters(0).Value = User.UserName
        Dim SqlDA As New SqlDataAdapter(SqlCom)
        Dim BangQuyen As New DataTable
        Try
            SqlDA.Fill(BangQuyen)
            ''MessageBox.Show(BangQuyen.Rows.Count.ToString)
            For Each Bt As OutlookBarButton In outlookChucNang.Buttons
                If Bt.Text.Trim <> "Tìm kiếm" Then
                    Bt.Visible = False
                Else
                    Bt.Visible = True
                End If
            Next
            If BangQuyen.Rows.Count > 0 Then
                For i As Integer = 0 To BangQuyen.Rows.Count - 1
                    For j As Integer = 0 To outlookChucNang.Buttons.Length - 1
                        If outlookChucNang.Buttons(j).Text = BangQuyen.Rows(i).Item(0).ToString Then
                            outlookChucNang.Buttons(j).Visible = True
                        End If
                    Next

                Next

            End If
        Catch ex As Exception
            'MessageBox.Show(ex.Message)
        End Try

    End Sub

    ' Điều chỉnh các Control cho phù hợp
    ' với sự hiển thị chức năng trên OutlookBar

    Public Sub DieuChinhControl()
        outlookChucNang.Height = outlookChucNang.Buttons.Length * 37
        Panel1.Height = outlookChucNang.Height + 2 + 50
        outlookChucNang.Width = Panel1.Width - 2
        'lblHinhAnhThua.Location = New Point(Panel1.Location.X, Panel1.Location.Y + Panel1.Height + 2)
        'PicTrangThai.Location = New Pboint(lblHinhAnhThua.Location.X + 2, lblHinhAnhThua.Location.Y + lblHinhAnhThua.Height + 2)
        'LabTrangThai.Location = New Point(PicTrangThai.Location.X + PicTrangThai.Width + 5, PicTrangThai.Location.Y + PicTrangThai.Height - LabTrangThai.Height)
        'rtxtThongTinSoLuoc.Location = New Point(PicTrangThai.Location.X, PicTrangThai.Location.Y + PicTrangThai.Height + 2)
        'rtxtThongTinSoLuoc.Height = splitContainer.Panel1.Height - rtxtThongTinSoLuoc.Location.Y - 2
    End Sub


#Region "CÁC HÀM CHO PHẦN THỰC THI CÁC CHỨC NĂNG"

    Private Sub CtrlThongTinThuaTuNhien_showdata2()
        'Me.CtrlThongTinThuaTuNhien.txtToBanDo.Text = strGlobalMaThuaDat
    End Sub

    ''' <summary>
    ''' Active chức năng cập nhật (Các nút: Thêm, sửa, xóa, hủy lệnh)
    ''' của nghiệp vụ cần thực thi
    ''' NOTE: TRONG PHƯƠNG THỨC NÀY MỘT SỐ CONTROL THÀNH VIÊN CHƯA ĐƯỢC ACTIVE
    ''' CẦN HOÀN THIỆN (KHI CÓ THỜI GIAN) ĐỂ NGƯỜI DÙNG KHÔNG PHẢI REFRESH NHIỀU LẦN
    ''' </summary>
    ''' <param name="blnHoSoKeKhai"></param>
    ''' <param name="blnThongTinXetDuyet"></param>
    ''' <param name="blnThamDinh"></param>
    ''' <param name="blnPheDuyet"></param>
    ''' <param name="blnCapGCN"></param>
    ''' <remarks></remarks>
    Private Sub activeChucNang(Optional ByVal blnHoSoKeKhai As Boolean = False, Optional ByVal blnThongTinXetDuyet As Boolean = False _
                               , Optional ByVal blnThamDinh As Boolean = False, Optional ByVal blnPheDuyet As Boolean = False _
                               , Optional ByVal blnCapGCN As Boolean = False, Optional ByVal blnTiepNhanHoSo As Boolean = False _
                               , Optional ByVal blnDangKyBienDong As Boolean = False)

        With Me
            'ACTIVE CÁC CHỨC NĂNG CẬP NHẬT (THÊM, SỬA, XÓA) TƯƠNG ỨNG 
            'VỚI TỪNG NGHIỆP VỤ CHO PHÉP ACTIVE
            'TIẾP NHẬN HỒ SƠ
            If blnTiepNhanHoSo Then
                .CtrlThongTinTiepNhanHoSo.TrangThaiChucNang(False, False)
                'ACTIVE TRẠNG THÁI CHỨC NĂNG HỒ SƠ KÊ KHAI
            ElseIf blnHoSoKeKhai Then
                .TrangThaiChucNang()
                'ACTIVE TRẠNG THÁI CHỨC NĂNG THÔNG TIN XÉT DUYỆT CẤP  CƠ SỞ (CẤP PHƯỜNG)
            ElseIf blnThongTinXetDuyet Then
                With .CtrlXetDuyetCapCoSo
                    .CtrlThongTinXetDuyet.TrangThaiChucNang()
                    .CtrThongTinHoSoXetDuyet1.TrangThaiChucNang()
                    .CtrlHoiDongXetDuyet.TrangThaiChucNang()
                    .CtrlThongTinBoSung.TrangThaiChucNang()
                End With
                'ACTIVE TRẠNG THÁI CHỨC NĂNG THÔNG TIN THẨM ĐỊNH
            ElseIf blnThamDinh Then
                With .CtrlThamDinh
                    'Yêu cầu bổ xung
                    .CtrlYeuCauBoXungThamDinh.TrangThaiChucNang()
                    .TrangThaiChucNang()
                End With
                'ACTIVE TRẠNG THÁI CHỨC NĂNG THÔNG TIN PHÊ DUYỆT
            ElseIf blnPheDuyet Then
                .CtrlPheDuyet.TrangThaiChucNang()
                'ACTIVE TRẠNG THÁI CHỨC NĂNG THÔNG TIN CẤP GCN
            ElseIf blnCapGCN Then
                '.CtrlThongTinCapGCN.TrangThaiChucNang()
            ElseIf blnDangKyBienDong Then
                .CtrlDangKyBienDong.TrangThaiChucNang(False, False)
            End If
        End With
    End Sub
    ''' <summary>
    ''' Active chức năng tương ứng khi người
    ''' dùng chọn nghiệp vụ cần thực thi trên Outlook Bar
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub OutlookBar1_ButtonClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles outlookChucNang.ButtonClicked
        Dim HoSoCapGCN As New clsHoSoCapGCN
        Dim GiaTriTrangThaiHoSo As String = ""
        strKhoaSoGCN = ""
        ''strtrangthaihoso  lay ra xem ho so do co bị khoa hay ko
        Dim strTrangThaiHoSo As String = TrangThaiHoSoCapGCN()
        Select Case outlookChucNang.SelectedButton.Text
            Case "Tìm kiếm"
                Me.TimKiem()
                'Hiển thị Form TIẾP NHẬN HỒ SƠ
                Me.TiepNhanHoSo()
                KhoaControl(CtrlThongTinTiepNhanHoSo, False)
                UpdateTrangThaiHS(CtrlThongTinTiepNhanHoSo)

            Case "Tiếp nhận hồ sơ"
                'If HoSoCapGCN.ActiveChucNang(User.Get_ChucNang(), "Tiếp nhận hồ sơ") Then

                Me.TiepNhanHoSo()
                UpdateTrangThaiHS(CtrlThongTinTiepNhanHoSo)
                If strKhoaSoGCN = "True" Then
                    KhoaControl(CtrlThongTinTiepNhanHoSo, False)
                Else
                    PhanQuyenChucNang(CtrlThongTinTiepNhanHoSo)
                End If

                'Else
                '    System.Windows.Forms.MessageBox.Show("Bạn KHÔNG CÓ QUYỀN truy cập vào chức năng này!" & _
                '    vbNewLine + vbNewLine + "Vui lòng liên hệ với QUẢN TRỊ VIÊN để biết thêm thông tin!", "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'End If
            Case "Hồ sơ kê khai"
                'If HoSoCapGCN.ActiveChucNang(User.Get_ChucNang(), "Hồ sơ kê khai") Then

                Me.HoSoKeKhai()
                UpdateTrangThaiHS(CtrlHoSoKeKhai)
                If strKhoaSoGCN = "True" Then
                    KhoaControl(CtrlHoSoKeKhai, False)
                Else
                    PhanQuyenChucNang(CtrlHoSoKeKhai)
                End If
                'Else
                '    System.Windows.Forms.MessageBox.Show("Bạn KHÔNG CÓ QUYỀN truy cập vào chức năng này!" & _
                '    vbNewLine + vbNewLine + "Vui lòng liên hệ với QUẢN TRỊ VIÊN để biết thêm thông tin!", "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'End If
            Case "Xét duyệt cấp cơ sở"
                'If HoSoCapGCN.ActiveChucNang(User.Get_ChucNang(), "Xét duyệt cấp cơ sở") Then
                Me.XetDuyetCapCoSo()
                UpdateTrangThaiHS(CtrlXetDuyetCapCoSo)
                If strKhoaSoGCN = "True" Then
                    KhoaControl(CtrlXetDuyetCapCoSo, False)
                Else
                    PhanQuyenChucNang(CtrlXetDuyetCapCoSo)
                End If
                'Else
                '    System.Windows.Forms.MessageBox.Show("Bạn KHÔNG CÓ QUYỀN truy cập vào chức năng này!" & _
                '    vbNewLine + vbNewLine + "Vui lòng liên hệ với QUẢN TRỊ VIÊN để biết thêm thông tin!", "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'End If
            Case "Thẩm định"
                'If HoSoCapGCN.ActiveChucNang(User.Get_ChucNang(), "Thẩm định") Then
                Me.ThamDinh()
                UpdateTrangThaiHS(CtrlThamDinh)
                If strKhoaSoGCN = "True" Then
                    KhoaControl(CtrlThamDinh, False)
                Else
                    PhanQuyenChucNang(CtrlThamDinh)
                End If
                'Else
                '    System.Windows.Forms.MessageBox.Show("Bạn KHÔNG CÓ QUYỀN truy cập vào chức năng này!" & _
                '    vbNewLine + vbNewLine + "Vui lòng liên hệ với QUẢN TRỊ VIÊN để biết thêm thông tin!", "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'End If
            Case "Phê duyệt"
                'If HoSoCapGCN.ActiveChucNang(User.Get_ChucNang(), "Phê duyệt") Then
                Me.PheDuyet()
                UpdateTrangThaiHS(CtrlPheDuyet)
                If strKhoaSoGCN = "True" Then
                    KhoaControl(CtrlPheDuyet, False)
                Else
                    PhanQuyenChucNang(CtrlPheDuyet)
                End If
                'Else
                '    System.Windows.Forms.MessageBox.Show("Bạn KHÔNG CÓ QUYỀN truy cập vào chức năng này!" & _
                '    vbNewLine + vbNewLine + "Vui lòng liên hệ với QUẢN TRỊ VIÊN để biết thêm thông tin!", "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'End If
            Case "Cấp Giấy chứng nhận"
                'If HoSoCapGCN.ActiveChucNang(User.Get_ChucNang(), "Cấp Giấy chứng nhận") Then
                Me.CapGiayChungNhan()
                UpdateTrangThaiHS(CtrlThongTinCapGCN)
                If strKhoaSoGCN = "True" Then
                    KhoaControl(CtrlThongTinCapGCN, False)
                Else
                    PhanQuyenChucNang(CtrlThongTinCapGCN)
                End If
                'Else
                '    System.Windows.Forms.MessageBox.Show("Bạn KHÔNG CÓ QUYỀN truy cập vào chức năng này!" & _
                '    vbNewLine + vbNewLine + "Vui lòng liên hệ với QUẢN TRỊ VIÊN để biết thêm thông tin!", "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'End If
            Case "Đăng ký biến động"
                Me.DangKyBienDong()
                UpdateTrangThaiHS(CtrlDangKyBienDong)
                PhanQuyenChucNang(CtrlDangKyBienDong)
        End Select


    End Sub

    Public Sub PhanQuyenChucNang(ByVal ctr As Control)
        If strMaHoSoCapGCN <> "" Then
            Dim cls As New clsHoSoCapGCN
            cls.Connection = GetConnection(bolKetNoiCSDL)
            cls.MaUser = User.MaUser
            cls.MaChucNang = ctr.Name
            Dim dt As New DataTable
            cls.SelectChucNangDuocPhanQuyen(dt)
            Dim TrangThai As Boolean = False
            If dt.Rows.Count > 0 Then
                If Not IsDBNull(dt.Rows(0).Item("CapNhat")) Then
                    TrangThai = dt.Rows(0).Item("CapNhat")
                    KhoaControl(ctr, TrangThai)
                    Dim cmd As Object = ctr
                    Try
                        If TrangThai Then
                            cmd.TrangThaiChucNang(False, False)
                        End If
                    Catch ex As Exception

                    End Try
                Else
                    KhoaControl(ctr, False)
                End If

            Else
                For Each cmd1 As Object In ctr.Controls
                    If cmd1.Controls.Count > 0 Then
                        PhanQuyenChucNang(cmd1)
                    Else
                        dt = New DataTable
                        cls.MaChucNang = cmd1.Name
                        'MessageBox.Show(cmd1.Name)
                        cls.SelectChucNangDuocPhanQuyen(dt)
                        If dt.Rows.Count > 0 Then
                            If Not IsDBNull(dt.Rows(0).Item("CapNhat")) Then
                                TrangThai = dt.Rows(0).Item("CapNhat")
                                KhoaControl(cmd1, TrangThai)
                            Else
                                KhoaControl(cmd1, False)
                            End If

                        End If

                    End If
                Next
            End If

        Else
            KhoaControl(Me, False)
        End If
    End Sub

    Public Sub UpdateTrangThaiHS(ByVal ctr As Control)
        If ctr.Name = CtrlHoSoKeKhai.Name Then
            With CtrlHoSoKeKhai.CtrTrangThaiHoSo1
                .Connection = GetConnection(bolKetNoiCSDL)
                .MaHoSoCapGCN = strMaHoSoCapGCN
                .MaDonViHanhCHinh = User.DonViHanhChinhHienThoi
                .ShowTrangThai()
                If .MaXacNhan = "2" Then
                    .cmdChapNhan.Enabled = True
                    .chkXacNhan.Enabled = True
                Else
                    .chkXacNhan.Enabled = False
                    .cmdChapNhan.Enabled = False
                End If
            End With
        End If
        If ctr.Name = CtrlXetDuyetCapCoSo.Name Then
            With CtrlXetDuyetCapCoSo.CtrTrangThaiHoSo1
                .Connection = GetConnection(bolKetNoiCSDL)
                .MaHoSoCapGCN = strMaHoSoCapGCN
                .MaDonViHanhCHinh = User.DonViHanhChinhHienThoi
                .ShowTrangThai()
                If .MaXacNhan = "3" Or .MaXacNhan = "41" Or .MaXacNhan = "42" Then
                    .chkXacNhan.Enabled = True
                    .cmdChapNhan.Enabled = True
                Else
                    .chkXacNhan.Enabled = False
                    .cmdChapNhan.Enabled = False
                End If
            End With
        End If
        If ctr.Name = CtrlThongTinTiepNhanHoSo.Name Then
            With CtrlThongTinTiepNhanHoSo.ctrTrangThaiHoSo1
                .Connection = GetConnection(bolKetNoiCSDL)
                .MaHoSoCapGCN = strMaHoSoCapGCN
                .MaDonViHanhCHinh = User.DonViHanhChinhHienThoi
                .ShowTrangThai()
                If .MaXacNhan = "1" Or .MaXacNhan = "0" Then
                    .cmdChapNhan.Enabled = True
                    .chkXacNhan.Enabled = True
                Else
                    .chkXacNhan.Enabled = False
                    .cmdChapNhan.Enabled = False
                End If
            End With
        End If
        If ctr.Name = CtrlThamDinh.Name Then
            With CtrlThamDinh.CtrTrangThaiHoSo1
                .Connection = GetConnection(bolKetNoiCSDL)
                .MaHoSoCapGCN = strMaHoSoCapGCN
                .MaDonViHanhCHinh = User.DonViHanhChinhHienThoi
                .ShowTrangThai()
                If .MaXacNhan = "4" Or .MaXacNhan = "51" Or .MaXacNhan = "41" Or .MaXacNhan = "42" Then
                    .cmdChapNhan.Enabled = True
                    .chkXacNhan.Enabled = True
                Else
                    .chkXacNhan.Enabled = False
                    .cmdChapNhan.Enabled = False
                End If
            End With
        End If
        If ctr.Name = CtrlPheDuyet.Name Then
            With CtrlPheDuyet.CtrTrangThaiHoSo1
                .Connection = GetConnection(bolKetNoiCSDL)
                .MaHoSoCapGCN = strMaHoSoCapGCN
                .MaDonViHanhCHinh = User.DonViHanhChinhHienThoi
                .ShowTrangThai()
                If .MaXacNhan = "5" Or .MaXacNhan = "51" Then
                    .cmdChapNhan.Enabled = True
                    .chkXacNhan.Enabled = True
                Else
                    .chkXacNhan.Enabled = False
                    .cmdChapNhan.Enabled = False
                End If
            End With
        End If
        If ctr.Name = CtrlThongTinCapGCN.Name Then
            With CtrlThongTinCapGCN.CtrTrangThaiHoSo1
                .Connection = GetConnection(bolKetNoiCSDL)
                .MaHoSoCapGCN = strMaHoSoCapGCN
                .MaDonViHanhCHinh = User.DonViHanhChinhHienThoi
                .ShowTrangThai()
                If .MaXacNhan = "6" Then
                    .chkXacNhan.Enabled = True
                    .cmdChapNhan.Enabled = True
                Else
                    .cmdChapNhan.Enabled = False
                    .chkXacNhan.Enabled = False
                End If
            End With
        End If
        If ctr.Name = CtrlDangKyBienDong.Name Then
            With CtrlDangKyBienDong.ctrTrangThaiHoSo1
                .Connection = GetConnection(bolKetNoiCSDL)
                .MaHoSoCapGCN = strMaHoSoCapGCN
                .MaDonViHanhCHinh = User.DonViHanhChinhHienThoi
                .ShowTrangThai()
                If .MaXacNhan = "7" Then
                    .chkXacNhan.Enabled = True
                    .cmdChapNhan.Enabled = True
                Else
                    .cmdChapNhan.Enabled = False
                    .chkXacNhan.Enabled = False
                End If
            End With
        End If
    End Sub

    'hien thi trang thai cua ho so cap giay chung nhan
    Public Function TrangThaiHoSoCapGCN() As String
        Dim strTrangThaiHoSo As String = ""
        If strMaHoSoCapGCN <> "" Then
            Dim cls As New clsHoSoCapGCN
            cls.Connection = GetConnection(bolKetNoiCSDL)
            cls.MaHoSoCapGCN = strMaHoSoCapGCN
            Dim dt As New DataTable
            cls.SelectTrangThaiHoSo(dt)
            Dim R As Integer = 0
            Dim G As Integer = 0
            Dim B As Integer = 0
            If dt.Rows.Count > 0 Then
                PicTrangThai.Visible = True
                LabTrangThai.Visible = True
                R = dt.Rows(0).Item("R")
                G = dt.Rows(0).Item("G")
                B = dt.Rows(0).Item("B")
                PicTrangThai.BackColor = Color.FromArgb(R, G, B)
                LabTrangThai.Text = dt.Rows(0).Item("Mota")
                LabTrangThai.ForeColor = Color.FromArgb(R, G, B)
                strTrangThaiHoSo = dt.Rows(0).Item("TrangThaiHoSoCapGCN")
                If Not IsDBNull(dt.Rows(0).Item("KhoaSoGCN")) Then
                    strKhoaSoGCN = dt.Rows(0).Item("KhoaSoGCN")
                Else
                    strKhoaSoGCN = ""
                End If
            End If
        End If
        Return strTrangThaiHoSo
    End Function


    ''' <summary>
    ''' Khi người dùng thực thi chức năng tìm kiếm
    ''' Nếu tìm được thửa đất, hồ sơ thì hiển thị thông tin Hồ sơ, thửa đất lên Form
    ''' Note: Thủ tục này có vẻ hơi rườm rà, cần xem lại để tối ưu hơn
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub TimKiem()
        Try
            If (User.DonViHanhChinhHienThoi.ToString = "") Or (User.DonViHanhChinhHienThoi.ToString = "0") Then
                MsgBox("Bạn chưa chọn đơn vị hành chính", MsgBoxStyle.Information, "DMCLand")
                frmDanhSachDVHC.ShowDialog()
                Exit Sub
            End If
            ''Me.lblThongTinSoLuoc.Text = "Tìm kiếm"
            'Add cac chuc nang chi tiet len doi tuong lstChucNangChiTiet
            With Me.rtxtThongTinSoLuoc
                .Clear()
            End With

            Dim strTenBangDVHC As String = ThaoTacPhuongHienThoi(User.DonViHanhChinhHienThoi)

            '/Add...
            With frmTimKiem

                .MaximizeBox = False
                .MinimizeBox = False
                'Gán chuỗi kết nối cơ sở dữ liệu
                .CrtTimKiemHoSoThuaDat1.Connection = GetConnection(bolKetNoiCSDL)
                .CrtTimKiemHoSoThuaDat1.TenBangBanDo = strTenBangDVHC & "tblDLieuKGianThuaDat"
                .CrtTimKiemHoSoThuaDat1.LoadTrangThai()
                .CrtTimKiemHoSoThuaDat1.NguonGocHoSo()
                .ShowDialog()
                If frmTimKiem.XacNhanKetQuaTimKiem Then
                    With .CrtTimKiemHoSoThuaDat1
                        For Each f As Form In frmMain.MdiChildren
                            If (f.Name <> frmNghiepVuHoSo.Name) Then
                                f.Close()
                            End If

                        Next
                        'Gán chuỗi kết nối cơ sở dữ liệu
                        .Connection = GetConnection(bolKetNoiCSDL)
                        strMaHoSoCapGCN = .MaHoSoCapGCN
                        strMaThuaDat = .MaThuaDat
                        strGlbMaThuaDat = strMaThuaDat
                        strToBanDo = .ToBanDo
                        strSoHieuThua = .SoThua
                        strDienTichTuNhien = .DienTich
                        strDiaChiThua = .DiaChiThua
                        strMaDonViHanhChinh = User.DonViHanhChinhHienThoi
                        strmakhoahoso = strmakhoahoso
                        ShowLandOriginalInformation()

                        TaoFileMaHoSoCapGCN(strMaHoSoCapGCN)
                    End With
                End If
            End With
            With Me
                If (strMaHoSoCapGCN <> "") And (frmTimKiem.XacNhanKetQuaTimKiem Or frmTimKiem.XacNhanKetQuaTimKiem) And (frmTimKiem.CrtTimKiemHoSoThuaDat1.strmakhoahoso <> "MG") Then
                    'hien thi 10 thua dat dau tien
                    frmMain.HienThi10ThuaDatMoiThaoTac(User.DonViHanhChinhHienThoi)

                    'Trường hợp Mã Thửa đất khác rỗng (Có thửa đất)
                    'Thì hiển thị thông tin thửa đất lến 2 điều khiển:
                    '1. THÔNG TIN THỬA TỰ NHIÊN (CỦA SỔ CHỨC NĂNG)
                    '2. THÔNG TIN THỬA KÊ KHAI (CỬA SỔ HỒ SƠ CẤP GCN)
                    .ShowLandOriginalInformation()
                    ShowCanhBao()
                    .MaHoSoCapGCN = strMaHoSoCapGCN



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
                        .CtrThongTinHoSoXetDuyet1.TrangThaiBanDau()
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
                    Me.ShowProfileInformation()

                ElseIf (strMaHoSoCapGCN <> "") And (frmTimKiem.XacNhanKetQuaTimKiem Or frmTimKiem.XacNhanKetQuaTimKiem) And (frmTimKiem.CrtTimKiemHoSoThuaDat1.strmakhoahoso = "MG") Then
                    .ShowLandOriginalInformation()

                    .MaHoSoCapGCN = strMaHoSoCapGCN

                    With .CtrlHoSoKeKhai
                        .CtrlThongTinThuaKeKhai.TrangThaiBanDau()
                        .CtrlTaiLieuKemTheo.TrangThaiBanDau(True)
                    End With
                    With .CtrlXetDuyetCapCoSo
                        .CtrlThongTinXetDuyet.TrangThaiBanDau()
                        .CtrThongTinHoSoXetDuyet1.TrangThaiBanDau()
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

                    ''HIỂN THỊ DỮ LIỆU LÊN CÁC ĐIỀU KHIỂN
                    ''TRONG TRƯỜNG HỢP THỬA ĐẤT CÓ HÒ SƠ
                    ''NOTE: CẦN KIỂM TRA LẠI XEM CÓ TỐI ƯU ĐƯỢC KHÔNG
                    'Me.ShowProfileInformation()


                End If
            End With
            frmTimKiem.XacNhanKetQuaTimKiem = False
        Catch ex As Exception
            MsgBox(" TÌM KIẾM " + vbNewLine + " Lỗi !", MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub
    '' hiển thị trạng thái cảnh báo
    Public Sub ShowCanhBao()
        If frmTimKiem.CrtTimKiemHoSoThuaDat1.strmakhoahoso = "TH" Then
            Me.lbCanhBao.Text = "Thửa đất bị nhà nước thu hồi"
            Me.lbCanhBao.Visible = True
        ElseIf frmTimKiem.CrtTimKiemHoSoThuaDat1.strmakhoahoso = "TC" Then
            Me.lbCanhBao.Text = "Thửa đất đang có thế chấp"
            Me.lbCanhBao.Visible = True
        ElseIf frmTimKiem.CrtTimKiemHoSoThuaDat1.strmakhoahoso = "MG" Then
            Me.lbCanhBao.Text = "Thửa đất đã đăng ký mất giấy chứng nhận"
            Me.lbCanhBao.Visible = True
        Else
            Me.lbCanhBao.Visible = False
        End If
        If frmTimKiem.CrtTimKiemHoSoThuaDat1.CanhBaoTranhChap = "True" Then
            Me.lbCanhBaoTranhChap.Text = "Thửa đất có tranh chấp khiếu kiện"
            Me.lbCanhBaoTranhChap.Visible = True
        Else
            Me.lbCanhBaoTranhChap.Visible = False
        End If
        If frmTimKiem.CrtTimKiemHoSoThuaDat1.ChuChuyenNhuong <> "" Then
            Me.labChuyenNhuong.Text = "Thửa đất đã chuyển nhượng: " & frmTimKiem.CrtTimKiemHoSoThuaDat1.ChuChuyenNhuong
            Me.labChuyenNhuong.Visible = True
        Else
            Me.labChuyenNhuong.Visible = False
        End If
    End Sub

    ''' <summary>
    ''' Hiển thị thông tin thửa tự nhiên lên Form
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ShowLandOriginalInformation()
        'Chắc chắc rằng tồn tai chuỗi kết nối cơ sở dữ liệu 
        If (GetConnection(bolKetNoiCSDL) = "") Then
            Exit Sub
        End If
        'Chắc chắn rằng tồn tại Mã thửa đất 
        If strMaThuaDat = "" Then
            'Xóa dữ liệu trên Form
            CtrlThongTinThuaTuNhien1.TrangThaiBanDau()
            Exit Sub
        End If

        With Me
            'Hiển thị thông tin thửa tự nhiên lên Form
            With .CtrlThongTinThuaTuNhien1
                'Khai báo chuỗi kết nối Database
                .Connection = GetConnection(bolKetNoiCSDL)
                .MaHoSoCapGCNHienThoi = strMaHoSoCapGCN
                .MaDonViHanhChinh = User.DonViHanhChinhHienThoi

                .ShowData(strMaThuaDat)
                'Nhận thông tin sơ lược về thửa đất
                'Tờ bản đồ
                strToBanDo = .ToBanDo
                'Số thửa
                strSoHieuThua = .SoThua
                'Diện tích
                strDienTichTuNhien = .DienTich


            End With
        End With
    End Sub

    ''' <summary>
    ''' Hiển thị thông tin hồ sơ cấp GCN
    ''' NOTE: CẦN XEM LẠI XEM PHƯƠNG THỨC NÀY CÓ THỰC SỰ CẦN THIẾT KHÔNG
    ''' CÓ THỂ KHÔNG CẦN NẠP DỮ LIỆU CHO TOÀN BỘ FORM NGHIỆP VỤ
    ''' MÀ CHỈ CẦN CHO FORM NGHIỆP VỤ ĐẦU TIÊN ĐƯỢC SHOW RA.
    ''' </summary>
    Public Sub ShowProfileInformation()
        'Chắc chắn rằng tồn tại CHUỖI KẾT NỐI
        If (GetConnection(bolKetNoiCSDL) Is Nothing) Then
            Exit Sub
        ElseIf (GetConnection(bolKetNoiCSDL) = "") Then
            Exit Sub
        End If
        'Chắc chắn rằng tồn tại ĐƠN VỊ HÀNH CHÍNH
        If (strGlobalTenDonViHanhChinh Is Nothing) Then
            Exit Sub
        ElseIf (strGlobalTenDonViHanhChinh = "") Then
            Exit Sub
        End If
        'Chắc chắn rằng tồn tại MÃ THỬA ĐẤT
        If (strMaThuaDat Is Nothing) Then
            Exit Sub
        ElseIf (strMaThuaDat = "") Then
            Exit Sub
        End If
        'Chắc chắn rằng tồn tại MÃ HÒ SƠ CẤP GCN
        If (strMaHoSoCapGCN Is Nothing) Then
            Exit Sub
        ElseIf (strMaHoSoCapGCN = "") Then
            Exit Sub
        End If
        With Me
            strMaDonViHanhChinh = User.DonViHanhChinhHienThoi
            'ĐIỀU KHIỂN THÔNG TIN TIẾP NHẬN HỒ SƠ
            With .CtrlThongTinTiepNhanHoSo
                .Connection = GetConnection(bolKetNoiCSDL)
                .MaDonViHanhChinh = strMaDonViHanhChinh
                .MaHoSoCapGCN = strMaHoSoCapGCN
                .ShowData()
            End With
            'ĐIỀU KHIỂN HỒ SƠ KÊ KHAI
            With .CtrlHoSoKeKhai
                'Thong tin ke khai thua dat
                With .CtrlThongTinThuaKeKhai
                    'Gán chuỗi kết nối cơ sở dữ liệu
                    .Connection = GetConnection(bolKetNoiCSDL)
                    .MaHoSoCapGCN = strMaHoSoCapGCN
                    .ShowData()
                End With
                'Tai lieu kem theo
                With .CtrlTaiLieuKemTheo
                    'Gán chuỗi kết nối cơ sở dữ liệu
                    .Connection = GetConnection(bolKetNoiCSDL)
                    .MaHoSoCapGCN = strMaHoSoCapGCN
                    .ShowData()
                End With
                With .CtrlNhaO
                    'Gán chuỗi kết nối cơ sở dữ liệu
                    .Connection = GetConnection(bolKetNoiCSDL)
                    'Gán Tên đơn vị hành chính
                    .TenDonViHanhChinh = strGlobalTenDonViHanhChinh

                    .MaHoSoCapGCN = strMaHoSoCapGCN
                    .MaNhaO = ""
                    .ShowData()
                End With
                'Công trình xây dựng
                With .CtrlCongTrinhXayDung
                    'Gán chuỗi kết nối cơ sở dữ liệu
                    .Connection = GetConnection(bolKetNoiCSDL)
                    .MaHoSoCapGCN = strMaHoSoCapGCN
                    .MaDonViHanhChinh = User.DonViHanhChinhHienThoi
                    .ShowData()
                End With
                'Thông tin Rừng cây
                With .CtrlThongTinRungCay
                    'Gán chuỗi kết nối Database
                    .Connection = GetConnection(bolKetNoiCSDL)
                    .MaHoSoCapGCN = strMaHoSoCapGCN
                    .ShowData()
                End With
                'Thông tin Cây lâu năm
                With .CtrlThongTinCayLauNam
                    'Gán chuỗi kết nối Database
                    .Connection = GetConnection(bolKetNoiCSDL)
                    .MaHoSoCapGCN = strMaHoSoCapGCN
                    .ShowData()
                End With
                'Thông tin Sơ đồ nhà đất
                With .CtrlThongTinSoDoNhaDat
                    'Gán chuỗi kết nối Database
                    .Connection = GetConnection(bolKetNoiCSDL)
                    .MaHoSoCapGCN = strMaHoSoCapGCN

                    .ShowData()
                End With
                'End With
            End With
            'ĐIỀU KHIỂN XÉT DUYỆT CẤP CƠ SỞ
            With .CtrlXetDuyetCapCoSo
                With .CtrlThongTinXetDuyet
                    'Gán chuỗi kết nối Database
                    .Connection = GetConnection(bolKetNoiCSDL)
                    .MaHoSoCapGCN = strMaHoSoCapGCN
                    .MaDonViHanhChinh = strMaDonViHanhChinh
                    .ShowData()
                End With
                With .CtrThongTinHoSoXetDuyet1
                    'Gán chuỗi kết nối Database
                    .Connection = GetConnection(bolKetNoiCSDL)
                    .MaHoSoCapGCN = strMaHoSoCapGCN
                    .MaDonViHanhChinh = strMaDonViHanhChinh
                    .ShowData()
                End With
                With .CtrlHoiDongXetDuyet
                    'Gán chuỗi kết nối Database
                    .Connection = GetConnection(bolKetNoiCSDL)
                    .MaHoSoCapGCN = strMaHoSoCapGCN
                    .MaDVHC = strMaDonViHanhChinh
                    .ShowData()
                End With
                With .CtrlThongTinBoSung
                    'Gán chuỗi kết nối Database
                    .Connection = GetConnection(bolKetNoiCSDL)
                    .MaHoSoCapGCN = strMaHoSoCapGCN
                    .ShowData()
                End With
            End With
            'ĐIỀU KHIỂN THẦM ĐỊNH
            With .CtrlThamDinh
                'Thông tin cán bộ Thẩm định 
                With .CtrlThongTinCanBoThamDinh
                    'Gán chuỗi kết nối Database
                    .Connection = GetConnection(bolKetNoiCSDL)
                    .MaHoSoCapGCN = strMaHoSoCapGCN
                    .MaDonViHanhChinh = strMaDonViHanhChinh
                    .ShowData()
                End With

                With .CtrlYeuCauBoXungThamDinh
                    'Gán chuỗi kết nối Database
                    .Connection = GetConnection(bolKetNoiCSDL)
                    .MaHoSoCapGCN = strMaHoSoCapGCN
                    .ShowData()
                End With

                With .CtrlThamDinhThuaDat
                    'Gán chuỗi kết nối cơ sở dữ liệu
                    .Connection = GetConnection(bolKetNoiCSDL)
                    .MaHoSoCapGCN = strMaHoSoCapGCN
                    .MaDonViHanhChinh = strMaDonViHanhChinh
                    .ShowData()
                End With
                'Thông tin pháp lý khác
                With .CtrlThongTinPhapLyKhac
                    'Gán chuỗi kết nối Database
                    .Connection = GetConnection(bolKetNoiCSDL)
                    .MaHoSoCapGCN = strMaHoSoCapGCN
                    .MaDonViHanhChinh = strMaDonViHanhChinh
                    .ShowData()
                End With
                'Thông tin GCN
                With .CtrlThongTinGCN
                    'Nhận chuỗi kết nối Database
                    .Connection = GetConnection(bolKetNoiCSDL)
                    .MaHoSoCapGCN = strMaHoSoCapGCN

                    .ShowData()
                End With
                'Mã vạch
                With .CtrlEncodeEAN13
                    .Connection = GetConnection(bolKetNoiCSDL)
                    .MaHoSoCapGCN = strMaHoSoCapGCN
                    .ShowData()
                End With
            End With
            'ĐIỀU KHIỂN PHÊ DUYỆT
            With .CtrlPheDuyet
                'Nhận chuỗi kết nối Database
                .Connection = GetConnection(bolKetNoiCSDL)
                .MaHoSoCapGCN = strMaHoSoCapGCN
                .ShowData()
            End With
            'ĐIỀU KHIỂN THÔNG TIN CẤP GCN
            With .CtrlThongTinCapGCN
                .Connection = GetConnection(bolKetNoiCSDL)
                .MaHoSoCapGCN = strMaHoSoCapGCN

                'Thông tin qui trình cấp GCN
                With .CtrlThongTinQuiTrinhCapGCN
                    .Connection = GetConnection(bolKetNoiCSDL)
                    .MaHoSoCapGCN = strMaHoSoCapGCN
                    .ShowData()
                End With
                'Thông tin Tờ trình địa chính
                With .CtrlThongTinToTrinhDiaChinh
                    .Connection = GetConnection(bolKetNoiCSDL)
                    .MaHoSoCapGCN = strMaHoSoCapGCN

                    .ShowData()
                End With
                'Thông tin Quyết định cấp GCN
                With .CtrlThongTinQuyetDinhCapGCN
                    .Connection = GetConnection(bolKetNoiCSDL)
                    .MaHoSoCapGCN = strMaHoSoCapGCN
                    .ShowData()
                End With
               
                'Thông báo cấp GCN
                With .CtrlThongBaoCapGCN
                    .Connection = GetConnection(bolKetNoiCSDL)
                    .MaHoSoCapGCN = strMaHoSoCapGCN

                    .ShowData()
                End With
                'Thông tin trả GCN
                With .CtrlThongTinTraGCN
                    .Connection = GetConnection(bolKetNoiCSDL)
                    .MaHoSoCapGCN = strMaHoSoCapGCN
                    .ShowData()
                End With
               
            End With
        End With
    End Sub

    Public Sub TiepNhanHoSo()
        Try
            Dim Y As Integer
            Y = 0
            With Me
                strMaDonViHanhChinh = User.DonViHanhChinhHienThoi
                'Không cho Scroll Control
                .AutoScroll = False
                With .CtrlThongTinTiepNhanHoSo
                    'Thiết lập kích thước của Control bằng kích thước của Panel chứa nó
                    .Height = Me.splitContainer.Panel2.Height
                    .Width = Me.splitContainer.Panel2.Width
                    .Location = New Point(0, Y)
                    .Visible = True
                    'Gán giá trị cho một số thuộc tính cần thiết lên Form
                    .Connection = GetConnection(bolKetNoiCSDL)
                    .MaHoSoCapGCN = 0
                End With
            End With
            'Chắc chắn rằng tồn tại MÃ HÒ SƠ CẤP GCN
            If (strMaHoSoCapGCN Is Nothing) Then
                Exit Sub
            ElseIf (strMaHoSoCapGCN = "") Then
                Exit Sub
            End If
            'Add cac chuc nang chi tiet len doi tuong lstChucNangChiTiet
            With Me.rtxtThongTinSoLuoc
                .Clear()
            End With
            '/Add...
            With Me
                ''Không cho Scroll Control
                '.AutoScroll = False
                With .CtrlThongTinTiepNhanHoSo
                    ''Thiết lập kích thước của Control bằng kích thước của Panel chứa nó
                    '.Height = Me.splitContainer.Panel2.Height
                    '.Width = Me.splitContainer.Panel2.Width
                    '.Location = New Point(0, Y)

                    'HIỂN THỊ THÔNG TIN TIẾP NHẬN HỒ SƠ LÊN FORM
                    '.Connection = GetConnection(bolKetNoiCSDL)
                    .MaHoSoCapGCN = strMaHoSoCapGCN
                    .MaKhoa = frmTimKiem.CrtTimKiemHoSoThuaDat1.strmakhoahoso
                    .MaDonViHanhChinh = strMaDonViHanhChinh
                    .ShowData()

                    ''Nhận thông tin Trạng thái Hồ sơ cấp GCN
                    'intTrangThaiHoSoCapGCN = .TrangThaiHoSoCapGCN
                    ''Hiển thị thông tin Trạng thái lên Form
                    'rtxtThongTinSoLuoc.Text = Me.TrangThaiHoSoCapGCN(intTrangThaiHoSoCapGCN)

                End With
                'Hiển thị Form nghiệp vụ tiếp nhận hồ sơ
                .activeTaskForm(, , , , , True)
                'Trạng thái chức năng
                .activeChucNang(, , , , , True)
            End With

            ' KhoaControl(CtrlThongTinTiepNhanHoSo, False)
        Catch ex As Exception
            MsgBox("Lỗi tiếp nhận hồ sơ ...!", MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub

    ''' <summary>
    ''' Thiết lập cho Form Hồ sơ kê khai khi người dùng chọn
    ''' nghiệp vụ Hồ sơ kê khai
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub HoSoKeKhai()

        'KIỂM TRA TÍNH HỢP LỆ CỦA THÔNG
        'Chắc chắn rằng tồn tại CHUỖI KẾT NỐI
        If (GetConnection(bolKetNoiCSDL) Is Nothing) Then
            Exit Sub
        ElseIf (GetConnection(bolKetNoiCSDL) = "") Then
            Exit Sub
        End If
        'Chắc chắn rằng tồn tại ĐƠN VỊ HÀNH CHÍNH
        If (strGlobalTenDonViHanhChinh Is Nothing) Then
            Exit Sub
        ElseIf (strGlobalTenDonViHanhChinh = "") Then
            Exit Sub
        End If
        'Chắc chắn rằng tồn tại MÃ HÒ SƠ CẤP GCN
        If (strMaHoSoCapGCN Is Nothing) Then
            Exit Sub
        ElseIf (strMaHoSoCapGCN = "") Then
            Exit Sub
        End If

        Try
            'Add cac chuc nang chi tiet len doi tuong lstChucNangChiTiet
            With Me.rtxtThongTinSoLuoc
                .Clear()
            End With
            '/Add...
            Dim Y As Integer = 0

            With Me
                strMaDonViHanhChinh = User.DonViHanhChinhHienThoi
                'Không cho Scroll Control
                .AutoScroll = False
                'Thiết lập kích thước của Control bằng kích thước của Panel chứa nó
                .CtrlHoSoKeKhai.Height = .splitContainer.Panel2.Height
                .CtrlHoSoKeKhai.Width = .splitContainer.Panel2.Width
                .CtrlHoSoKeKhai.Location = New Point(0, Y)
                'Hiển thị Form nghiệp vụ Hồ sơ kê khai 
                Me.activeTaskForm(True)
                'Nạp thông tin vào điểu khiển Thông tin thửa đất

                With .CtrlThongTinThuaTuNhien1
                    'Gán chuỗi kết nối cơ sở dữ liệu
                    .Connection = GetConnection(bolKetNoiCSDL)
                    .MaDonViHanhChinh = strMaDonViHanhChinh
                    'Mã Hồ sơ cấp GCN hiện thời
                    .MaHoSoCapGCNHienThoi = strMaHoSoCapGCN
                End With
                'ĐIỀU KHIỂN HỒ SƠ KÊ KHAI
                With .CtrlHoSoKeKhai
                    'Thông tin Chủ hồ sơ cấp GCN
                    .Connection = GetConnection(bolKetNoiCSDL)

                    .MaHoSoCapGCN = strMaHoSoCapGCN
                    With .CtrlChuCQNN
                        'Gán chuỗi kết nối cơ sở dữ liệu
                        .Connection = GetConnection(bolKetNoiCSDL)
                        .MaHoSoCapGCN = strMaHoSoCapGCN

                        .TenPhuong = TenDonViHanhChinh()
                        .MaDonViHanhChinh = User.DonViHanhChinhHienThoi
                        'Thiết lập chế độ active/unactive các chức năng
                        .MaKhoa = frmTimKiem.CrtTimKiemHoSoThuaDat1.strmakhoahoso

                        .TrangThaiChucNang(False, False)
                        .ShowData()
                    End With
                    With .CtrlChuGDCN
                        'Gán chuỗi kết nối cơ sở dữ liệu
                        .Connection = GetConnection(bolKetNoiCSDL)
                        .MaHoSoCapGCN = strMaHoSoCapGCN
                        .MaDonViHanhChinh = User.DonViHanhChinhHienThoi
                        .TenPhuong = TenDonViHanhChinh()
                        'Thiết lập chế độ active/unactive các chức năng
                        .MaKhoa = frmTimKiem.CrtTimKiemHoSoThuaDat1.strmakhoahoso
                        .TrangThaiChucNang(False, False)
                        .ShowData()
                    End With
                    With .CtrlChuTCDN
                        'Gán chuỗi kết nối cơ sở dữ liệu
                        .Connection = GetConnection(bolKetNoiCSDL)
                        .MaHoSoCapGCN = strMaHoSoCapGCN
                        .MaDonViHanhChinh = User.DonViHanhChinhHienThoi
                        .TenPhuong = TenDonViHanhChinh()
                        'Thiết lập chế độ active/unactive các chức năng
                        .MaKhoa = frmTimKiem.CrtTimKiemHoSoThuaDat1.strmakhoahoso
                        .TrangThaiChucNang(False, False)
                        .ShowData()
                    End With
                    'Thong tin ke khai thua dat
                    With .CtrlThongTinThuaKeKhai
                        'Gán chuỗi kết nối cơ sở dữ liệu
                        .Connection = GetConnection(bolKetNoiCSDL)
                        .MaHoSoCapGCN = strMaHoSoCapGCN

                        .MaThuaDat = strMaThuaDat
                        .MaDonViHanhChinh = strMaDonViHanhChinh
                        .TenPhuong = TenDonViHanhChinh()
                        '.MaThuaDat = strMaThuaDat
                        'Thiết lập chế độ active/unactive các chức năng
                        .MaKhoa = frmTimKiem.CrtTimKiemHoSoThuaDat1.strmakhoahoso
                        .TrangThaiChucNang(False, False)
                        .ShowData()
                        ''Hiển thị thông tin Trạng thái lên Form
                        'rtxtThongTinSoLuoc.Text = Me.TrangThaiHoSoCapGCN(intTrangThaiHoSoCapGCN)

                    End With
                    'Tai lieu kem theo
                    With .CtrlTaiLieuKemTheo
                        'Gán chuỗi kết nối cơ sở dữ liệu
                        .Connection = GetConnection(bolKetNoiCSDL)
                        .MaHoSoCapGCN = strMaHoSoCapGCN
                        .MaDonViHanhChinh = User.DonViHanhChinhHienThoi
                        .MaTaiLieuKemTheo = ""
                        'Thiết lập chế độ active/unactive các chức năng
                        .MaKhoa = frmTimKiem.CrtTimKiemHoSoThuaDat1.strmakhoahoso
                        .TrangThaiChucNang(False, False)
                        .ShowData()
                    End With
                    'Nhà ở
                    With .CtrlNhaO
                        'Gán chuỗi kết nối cơ sở dữ liệu
                        .Connection = GetConnection(bolKetNoiCSDL)
                        'Gán Tên đơn vị hành chính
                        .TenDonViHanhChinh = strGlobalTenDonViHanhChinh
                        .MaDonViHanhChinh = User.DonViHanhChinhHienThoi
                        .MaHoSoCapGCN = strMaHoSoCapGCN
                        .MaNhaO = ""
                        'Thiết lập chế độ active/unactive các chức năng
                        .MaKhoa = frmTimKiem.CrtTimKiemHoSoThuaDat1.strmakhoahoso
                        .TrangThaiChucNang(False, False)
                        .ShowData()
                    End With
                    'Công trình xây dựng gắn liền với đất
                    With .CtrlCongTrinhXayDung
                        'Gán chuỗi kết nối cơ sở dữ liệu
                        .Connection = GetConnection(bolKetNoiCSDL)
                        .MaHoSoCapGCN = strMaHoSoCapGCN
                        'Thiết lập chế độ active/unactive các chức năng
                        .MaKhoa = frmTimKiem.CrtTimKiemHoSoThuaDat1.strmakhoahoso
                        .TrangThaiChucNang(False, False)
                        .ShowData()
                    End With
                    'Thông tin Rừng cây
                    With .CtrlThongTinRungCay
                        'Gán chuỗi kết nối cơ sở dữ liệu
                        .Connection = GetConnection(bolKetNoiCSDL)
                        .MaHoSoCapGCN = strMaHoSoCapGCN
                        'Thiết lập chế độ active/unactive các chức năng
                        .MaKhoa = frmTimKiem.CrtTimKiemHoSoThuaDat1.strmakhoahoso
                        .TrangThaiChucNang(False, False)
                        .ShowData()
                    End With
                    'Thông tin Cây lâu năm
                    With .CtrlThongTinCayLauNam
                        'Gán chuỗi kết nối cơ sở dữ liệu
                        .Connection = GetConnection(bolKetNoiCSDL)
                        .MaHoSoCapGCN = strMaHoSoCapGCN
                        'Thiết lập chế độ active/unactive các chức năng
                        .MaKhoa = frmTimKiem.CrtTimKiemHoSoThuaDat1.strmakhoahoso
                        .TrangThaiChucNang(False, False)
                        .ShowData()
                    End With
                    'Thông tin Sơ đồ nhà đất
                    With .CtrlThongTinSoDoNhaDat
                        'Gán chuỗi kết nối cơ sở dữ liệu
                        .Connection = GetConnection(bolKetNoiCSDL)
                        .MaKhoa = frmTimKiem.CrtTimKiemHoSoThuaDat1.strmakhoahoso
                        .MaHoSoCapGCN = strMaHoSoCapGCN
                        .ShowData()
                    End With

                    'End With
                End With

            End With
            'Trang thai chuc nang
            'activeChucNang(True)


        Catch ex As Exception
            MsgBox("Lỗi hiển thị hồ sơ kê khai... !", MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub
    ''' <summary>
    ''' Thiết lập cho Form Xét duyệt cấp cơ sở khi người dùng chọn
    ''' nghiệp vụ Xét duyệt cấp cơ sở
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub XetDuyetCapCoSo()
        Try
            'Chắc chắn rằng tồn tại MÃ HÒ SƠ CẤP GCN
            If (strMaHoSoCapGCN Is Nothing) Then
                Exit Sub
            ElseIf (strMaHoSoCapGCN = "") Then
                Exit Sub
            End If
            ''Me.lblThongTinSoLuoc.Text = "Xét duyệt cấp cơ sở"
            'Add cac chuc nang chi tiet len doi tuong lstChucNangChiTiet
            With Me.rtxtThongTinSoLuoc
                .Clear()
            End With
            '/Add...
            Dim Y As Integer
            Y = 0
            With Me
                strMaDonViHanhChinh = User.DonViHanhChinhHienThoi
                'Không cho Scroll Control
                .AutoScroll = False
                With .CtrlXetDuyetCapCoSo

                    'Thiết lập kích thước của Control bằng kích thước của Panel chứa nó
                    .Height = Me.splitContainer.Panel2.Height
                    .Width = Me.splitContainer.Panel2.Width
                    .Location = New Point(0, Y)
                    .Connection = GetConnection(bolKetNoiCSDL)
                    .MaHoSoCapGCN = strMaHoSoCapGCN
                    .MaDonViHanhChinh = strMaDonViHanhChinh
                    'HIỂN THỊ THÔNG TIN XÉT DUYỆT LÊN FORM

                    ''Hiển thị thông tin Hồi đồng xét duyệt
                    'With .CtrlHoiDongXetDuyet
                    '    .Connection = GetConnection(bolKetNoiCSDL)
                    '    .MaHoSoCapGCN = strMaHoSoCapGCN
                    '    .ShowData()
                    'End With
                    ''Hiển thị thông tin Xét duyệt
                    'With .CtrlThongTinXetDuyet
                    '    .Connection = GetConnection(bolKetNoiCSDL)
                    '    .MaHoSoCapGCN = strMaHoSoCapGCN
                    '    .ShowData()
                    'End With

                    'HIỂN THỊ THÔNG TIN XÉT DUYỆT LÊN FORM
                    'Hiển thị thông tin Hồi đồng xét duyệt
                    With .CtrlHoiDongXetDuyet
                        .Connection = GetConnection(bolKetNoiCSDL)
                        .MaHoSoCapGCN = strMaHoSoCapGCN
                        .MaDVHC = DMCLand.mdlMain.intGlobalMaDonViHanhChinh
                        .MaKhoa = frmTimKiem.CrtTimKiemHoSoThuaDat1.strmakhoahoso
                        .ShowData()
                    End With
                    'Hiển thị thông tin Xét duyệt
                    With .CtrlThongTinXetDuyet
                        .Connection = GetConnection(bolKetNoiCSDL)
                        .MaHoSoCapGCN = strMaHoSoCapGCN
                        .MaDonViHanhChinh = DMCLand.mdlMain.intGlobalMaDonViHanhChinh

                        .ShowData()

                        ''Nhận thông tin Trạng thái Hồ sơ cấp GCN
                        'intTrangThaiHoSoCapGCN = .TrangThaiHoSoCapGCN
                        ''Hiển thị thông tin Trạng thái lên Form
                        'rtxtThongTinSoLuoc.Text = Me.TrangThaiHoSoCapGCN(intTrangThaiHoSoCapGCN)

                    End With

                    With .CtrThongTinHoSoXetDuyet1
                        .Connection = GetConnection(bolKetNoiCSDL)
                        .MaHoSoCapGCN = strMaHoSoCapGCN
                        .MaDonViHanhChinh = DMCLand.mdlMain.intGlobalMaDonViHanhChinh
                        .MaKhoa = frmTimKiem.CrtTimKiemHoSoThuaDat1.strmakhoahoso
                        .ShowData()

                        ''Nhận thông tin Trạng thái Hồ sơ cấp GCN
                        'intTrangThaiHoSoCapGCN = .TrangThaiHoSoCapGCN
                        ''Hiển thị thông tin Trạng thái lên Form
                        'rtxtThongTinSoLuoc.Text = Me.TrangThaiHoSoCapGCN(intTrangThaiHoSoCapGCN)

                    End With

                    With .CtrlThongTinXetDuyet
                        .Connection = GetConnection(bolKetNoiCSDL)
                        .MaHoSoCapGCN = strMaHoSoCapGCN
                        .MaDonViHanhChinh = DMCLand.mdlMain.intGlobalMaDonViHanhChinh
                        .ShowData()
                    End With


                    'Hiển thị thông tin Yêu cầu bổ xung

                    'Hiển thị thông tin Yêu cầu bổ xung
                    With .CtrlThongTinBoSung
                        .Connection = GetConnection(bolKetNoiCSDL)
                        .MaHoSoCapGCN = strMaHoSoCapGCN

                        .MaKhoa = frmTimKiem.CrtTimKiemHoSoThuaDat1.strmakhoahoso
                        .ShowData()
                    End With
                    With .CtrTongHopDatInBienBanXetDuyet1
                        'Gán chuỗi kết nối cơ sở dữ liệu
                        .Connection = GetConnection(bolKetNoiCSDL)
                        .MaHoSoCapGCN = strMaHoSoCapGCN
                        .MaKhoa = frmTimKiem.CrtTimKiemHoSoThuaDat1.strmakhoahoso
                        .MaDonViHanhChinh = strMaDonViHanhChinh
                        .ShowData()
                    End With
                End With
                'Hiển thị Form nghiệp vụ Xét duyệt cấp cơ sở
                Me.activeTaskForm(, True)
            End With
            'Trạng thái chức năng
            activeChucNang(, True)
        Catch ex As Exception
            MsgBox("Lỗi hiển thị xét duyệt cấp cơ sở ...! ", MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub
    ''' <summary>
    ''' Thiết lập cho Form Thẩm định khi người dùng chọn
    ''' nghiệp vụ Thẩm định
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ThamDinh()
        Try
            'Chắc chắn rằng tồn tại MÃ HÒ SƠ CẤP GCN
            If (strMaHoSoCapGCN Is Nothing) Then
                Exit Sub
            ElseIf (strMaHoSoCapGCN = "") Then
                Exit Sub
            End If
            ''Me.lblThongTinSoLuoc.Text = "Thẩm định"
            'Add cac chuc nang chi tiet len doi tuong lstChucNangChiTiet
            With Me.rtxtThongTinSoLuoc
                .Clear()
            End With
            '/Add...
            Dim Y As Integer
            Y = 0
            With Me
                strMaDonViHanhChinh = User.DonViHanhChinhHienThoi
                'Không cho Scroll Control
                .AutoScroll = False
                With .CtrlThamDinh
                    'Thiết lập kích thước của Control bằng kích thước của Panel chứa nó
                    .Height = Me.splitContainer.Panel2.Height
                    .Width = Me.splitContainer.Panel2.Width
                    .Location = New Point(0, Y)

                    .Connection = GetConnection(bolKetNoiCSDL)
                    .MaHoSoCapGCN = strMaHoSoCapGCN
                    .MaDonVihanhChinh = User.DonViHanhChinhHienThoi
                    .UserName = User.UserName
                    .TrangThaiBanDau()
                    .ShowData()
                    'HIỂN THỊ DỮ LIỆU FORM THẨM ĐỊNH
                    'Hiển thị thông tin Cán bộ thẩm định
                    With .CtrlThongTinCanBoThamDinh
                        .Connection = GetConnection(bolKetNoiCSDL)
                        .MaHoSoCapGCN = strMaHoSoCapGCN
                        .MaDonViHanhChinh = strMaDonViHanhChinh
                        .DienTichKeKhai = strDienTichTuNhien
                        'Thiết lập chế độ active/unactive các chức năng
                        .MaKhoa = frmTimKiem.CrtTimKiemHoSoThuaDat1.strmakhoahoso
                        .TrangThaiChucNang(False, False)
                        .ShowData()
                    End With

                    'Hiển thị thông tin Yêu cầu bổ xung
                    With .CtrlYeuCauBoXungThamDinh
                        .MaHoSoCapGCN = strMaHoSoCapGCN
                        .Connection = GetConnection(bolKetNoiCSDL)
                        .MaKhoa = frmTimKiem.CrtTimKiemHoSoThuaDat1.strmakhoahoso

                        .ShowData()
                    End With

                    'Hiển thị thông tin CHỦ (SỬ DỤNG, SỞ HỮU) đề nghị cấp GCN
                    With .CtrlThongTinChuDeNghiCapGCN
                        .MaHoSoCapGCN = strMaHoSoCapGCN
                        .Connection = GetConnection(bolKetNoiCSDL)
                        'Thiết lập chế độ active/unactive các chức năng
                        .MaKhoa = frmTimKiem.CrtTimKiemHoSoThuaDat1.strmakhoahoso
                        .MaDonViHanhChinh = strMaDonViHanhChinh
                        .TrangThaiChucNang(False, False)
                        .ShowData()
                    End With
                    'Hiển thị thông tin Thẩm định thông tin THỬA ĐẤT
                    With .CtrlThamDinhThuaDat
                        'Gán chuỗi kết nối cơ sở dữ liệu
                        .Connection = GetConnection(bolKetNoiCSDL)
                        .MaHoSoCapGCN = strMaHoSoCapGCN
                        .MaDonViHanhChinh = strMaDonViHanhChinh
                        'Thiết lập chế độ active/unactive các chức năng
                        .MaKhoa = frmTimKiem.CrtTimKiemHoSoThuaDat1.strmakhoahoso
                        .TrangThaiChucNang(False, False)
                        .ShowData()
                        ''NHẬN THÔNG TIN TRẠNG THÁI HỒ SƠ CẤP GCN
                        'intTrangThaiHoSoCapGCN = .TrangThaiHoSoCapGCN
                    End With
                    'Hiển thị thông tin NHÀ Ở đề nghị cấp GCN
                    With .CtrlThongTinNhaODeNghiCapGCN
                        .MaDonViHanhChinh = strMaDonViHanhChinh
                        .MaHoSoCapGCN = strMaHoSoCapGCN
                        .Connection = GetConnection(bolKetNoiCSDL)
                        'Thiết lập chế độ active/unactive các chức năng
                        .MaKhoa = frmTimKiem.CrtTimKiemHoSoThuaDat1.strmakhoahoso
                        .TrangThaiChucNang(False, False)
                        .ShowData()
                    End With
                    'Hiển thị thông tin CÔNG TRÌNH XÂY DỰNG đề nghị cấp GCN
                    With .CtrlThongTinCongTrinhXayDungDeNghiCapGCN
                        .MaDonViHanhChinh = strMaDonViHanhChinh
                        .MaHoSoCapGCN = strMaHoSoCapGCN
                        .Connection = GetConnection(bolKetNoiCSDL)
                        'Thiết lập chế độ active/unactive các chức năng
                        .MaKhoa = frmTimKiem.CrtTimKiemHoSoThuaDat1.strmakhoahoso
                        .TrangThaiChucNang(False, False)
                        .ShowData()
                    End With
                    'Hiển thị thông tin RỪNG CÂY đề nghị cấp GCN
                    With .CtrlThongTinRungCayDeNghiCapGCN
                        .MaHoSoCapGCN = strMaHoSoCapGCN
                        .MaDonViHanhChinh = strMaDonViHanhChinh
                        .Connection = GetConnection(bolKetNoiCSDL)
                        'Thiết lập chế độ active/unactive các chức năng
                        .MaKhoa = frmTimKiem.CrtTimKiemHoSoThuaDat1.strmakhoahoso
                        .TrangThaiChucNang(False, False)
                        .ShowData()
                    End With
                    'Hiển thị thông tin CÂY LÂU NĂM đề nghị cấp GCN
                    With .CtrlThongTinCayLauNamDeNghiCapGCN
                        .MaDonViHanhChinh = strMaDonViHanhChinh
                        .MaHoSoCapGCN = strMaHoSoCapGCN
                        .Connection = GetConnection(bolKetNoiCSDL)
                        'Thiết lập chế độ active/unactive các chức năng
                        .MaKhoa = frmTimKiem.CrtTimKiemHoSoThuaDat1.strmakhoahoso
                        .TrangThaiChucNang(False, False)
                        .ShowData()
                    End With
                    'Hiển thị thông tin Sơ đồ nhà, đất đề nghị cấp GCN
                    With .CtrlThongTinSoDoNhaDat
                        .MaHoSoCapGCN = strMaHoSoCapGCN
                        .MaDonVihanhChinh = strMaDonViHanhChinh
                        .Connection = GetConnection(bolKetNoiCSDL)
                        'Thiết lập chế độ active/unactive các chức năng
                        '.TrangThaiChucNang(False, False)
                        .MaKhoa = frmTimKiem.CrtTimKiemHoSoThuaDat1.strmakhoahoso
                        .ShowData()
                    End With

                    With .CtrlThongTinPhapLyKhac
                        'Hiển thị dữ liệu thẩm định
                        .Connection = GetConnection(bolKetNoiCSDL)
                        .MaHoSoCapGCN = strMaHoSoCapGCN
                        .MaDonViHanhChinh = strMaDonViHanhChinh
                        'Thiết lập chế độ active/unactive các chức năng
                        .MaKhoa = frmTimKiem.CrtTimKiemHoSoThuaDat1.strmakhoahoso
                        .TrangThaiChucNang(False, False)
                        .ShowData()
                        ''NHẬN THÔNG TIN TRẠNG THÁI HỒ SƠ CẤP GCN
                        'intTrangThaiHoSoCapGCN = .TrangThaiHoSoCapGCN
                    End With
                    'Hiển thị thông tin GCN
                    With .CtrlThongTinGCN
                        .Connection = GetConnection(bolKetNoiCSDL)
                        .MaHoSoCapGCN = strMaHoSoCapGCN
                        .MaDonViHanhChinh = User.DonViHanhChinhHienThoi
                        'Thiết lập chế độ active/unactive các chức năng
                        .MaKhoa = frmTimKiem.CrtTimKiemHoSoThuaDat1.strmakhoahoso
                        .TrangThaiChucNang(False, False)
                        .ShowData()

                        ''NHẬN THÔNG TIN TRẠNG THÁI HỒ SƠ CẤP GCN
                        'intTrangThaiHoSoCapGCN = .TrangThaiHoSoCapGCN
                        ''Hiển thị thông tin Trạng thái lên Form
                        'rtxtThongTinSoLuoc.Text = Me.TrangThaiHoSoCapGCN(intTrangThaiHoSoCapGCN)

                    End With
                    'Hiển thị thông tin Sổ cấp GCN
                    With .CtrlThongTinSoCapGCN
                        .Connection = GetConnection(bolKetNoiCSDL)
                        .MaDonViHanhChinh = User.DonViHanhChinhHienThoi
                        .MaHoSoCapGCN = strMaHoSoCapGCN
                        'Thiết lập chế độ active/unactive các chức năng
                        .MaKhoa = frmTimKiem.CrtTimKiemHoSoThuaDat1.strmakhoahoso
                        .TrangThaiChucNang(False, False)
                        .ShowData()
                    End With
                    'Hiển thị thông tin ký GCN
                    With .CtrlThongTinKyGCN
                        .Connection = GetConnection(bolKetNoiCSDL)
                        .MaDonViHanhChinh = User.DonViHanhChinhHienThoi
                        .MaHoSoCapGCN = strMaHoSoCapGCN

                        'Thiết lập chế độ active/unactive các chức năng
                        .MaKhoa = frmTimKiem.CrtTimKiemHoSoThuaDat1.strmakhoahoso
                        .TrangThaiChucNang(False, False)
                        .ShowData()
                    End With
                    'Hiển thị thông tin MÃ VẠCH GCN
                    With .CtrlEncodeEAN13
                        .Connection = GetConnection(bolKetNoiCSDL)
                        .MaHoSoCapGCN = strMaHoSoCapGCN
                        .MaDonViHanhChinh = User.DonViHanhChinhHienThoi
                        .UserName = User.UserName
                        .MaKhoa = frmTimKiem.CrtTimKiemHoSoThuaDat1.strmakhoahoso
                        .ShowData()
                    End With
                End With
                ''Hiển thị thông tin Trạng thái lên Form
                'rtxtThongTinSoLuoc.Text = Me.TrangThaiHoSoCapGCN(intTrangThaiHoSoCapGCN)
                'Hiển thị Form nghiệp vụ Thẩm định
                Me.activeTaskForm(, , True)
                'Trạng thái chức năng
                Me.activeChucNang(, , True)
            End With
        Catch ex As Exception
            MsgBox("Lỗi hiển thị thẩm định ...!", MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub
    ''' <summary>
    ''' Thiết lập cho Form Phê duyệt khi người dùng chọn
    ''' nghiệp vụ Phê duyệt
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub PheDuyet()
        Try
            'Chắc chắn rằng tồn tại MÃ HÒ SƠ CẤP GCN
            If (strMaHoSoCapGCN Is Nothing) Then
                Exit Sub
            ElseIf (strMaHoSoCapGCN = "") Then
                Exit Sub
            End If
            ''Me.lblThongTinSoLuoc.Text = "Phê duyệt"
            'Add cac chuc nang chi tiet len doi tuong lstChucNangChiTiet
            With Me.rtxtThongTinSoLuoc
                .Clear()
            End With
            '/Add...
            Dim Y As Integer
            Y = 0
            With Me
                'Không cho Scroll Control
                .AutoScroll = False
                With .CtrlPheDuyet
                    'Thiết lập kích thước của Control bằng kích thước của Panel chứa nó
                    .Height = Me.splitContainer.Panel2.Height
                    .Width = Me.splitContainer.Panel2.Width
                    .Location = New Point(0, Y)

                    'HIỂN THỊ THÔNG TIN PHÊ DUYỆT LÊN FORM
                    .Connection = GetConnection(bolKetNoiCSDL)
                    .MaHoSoCapGCN = strMaHoSoCapGCN
                    .MaDonViHanhChinh = User.DonViHanhChinhHienThoi
                    .MaKhoa = frmTimKiem.CrtTimKiemHoSoThuaDat1.strmakhoahoso
                    .ShowData()

                    ''NHẬN THÔNG TIN TRẠNG THÁI HỒ SƠ CẤP GCN
                    'intTrangThaiHoSoCapGCN = .TrangThaiHoSoCapGCN
                    ''Hiển thị thông tin Trạng thái lên Form
                    'rtxtThongTinSoLuoc.Text = Me.TrangThaiHoSoCapGCN(intTrangThaiHoSoCapGCN)

                End With
                'Hiển thị Form nghiệp vụ Phê duyệt
                .activeTaskForm(, , , True)
                'Trạng thái chức năng
                .activeChucNang(, , , True)
            End With
        Catch ex As Exception
            MsgBox("Lỗi hiển thị phê duyệt ...!", MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub
    ''' <summary>
    ''' Thiết lập cho Form Cấp Giấy chứng nhận khi người dùng chọn
    ''' nghiệp vụ Cấp giấy chứng nhận
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub CapGiayChungNhan()
        Try
            'Chắc chắn rằng tồn tại MÃ HÒ SƠ CẤP GCN
            If (strMaHoSoCapGCN Is Nothing) Then
                Exit Sub
            ElseIf (strMaHoSoCapGCN = "") Then
                Exit Sub
            End If
            'Add cac chuc nang chi tiet len doi tuong lstChucNangChiTiet
            With Me.rtxtThongTinSoLuoc
                .Clear()
            End With
            '/Add...
            Dim Y As Integer
            Y = 0
            With Me
                'Không cho Scroll Control
                .AutoScroll = False
                With .CtrlThongTinCapGCN
                    'Thiết lập kích thước của Control bằng kích thước của Panel chứa nó
                    .Height = Me.splitContainer.Panel2.Height
                    .Width = Me.splitContainer.Panel2.Width
                    .Location = New Point(0, Y)
                    .Connection = GetConnection(bolKetNoiCSDL)

                    .MaHoSoCapGCN = strMaHoSoCapGCN
                    .UserName = User.UserName
                    .DVHC = User.DonViHanhChinhHienThoi
                    If frmTimKiem.CrtTimKiemHoSoThuaDat1.strmakhoahoso.ToString <> "MG" Then
                        .btnXemVaIn.Enabled = True
                    Else
                        .btnXemVaIn.Enabled = False
                    End If
                    'HIỂN THỊ THÔNG TIN CẤP GCN LÊN FORM
                    'Thông tin qui trình cấp GCN
                    With .CtrlThongTinQuiTrinhCapGCN
                        .Connection = GetConnection(bolKetNoiCSDL)
                        .MaHoSoCapGCN = strMaHoSoCapGCN

                        .ShowData()
                    End With
                    'Hiển thị thông tin Tờ trình địa chính
                    With .CtrlThongTinToTrinhDiaChinh
                        .Connection = GetConnection(bolKetNoiCSDL)
                        .MaHoSoCapGCN = strMaHoSoCapGCN

                        'Thiết lập chế độ active/unactive các chức năng
                        .MaKhoa = frmTimKiem.CrtTimKiemHoSoThuaDat1.strmakhoahoso
                        .TrangThaiChucNang(False, False)
                        .ShowData()
                    End With
                    'Thông tin Quyết định cấp GCN
                    With .CtrlThongTinQuyetDinhCapGCN
                        .Connection = GetConnection(bolKetNoiCSDL)
                        .MaHoSoCapGCN = strMaHoSoCapGCN
                        .MaDonViHanhChinh = User.DonViHanhChinhHienThoi
                        'Thiết lập chế độ active/unactive các chức năng
                        .MaKhoa = frmTimKiem.CrtTimKiemHoSoThuaDat1.strmakhoahoso
                        .TrangThaiChucNang(False, False)
                        .ShowData()
                    End With
                   
                    'Thông báo cấp GCN
                    With .CtrlThongBaoCapGCN
                        .Connection = GetConnection(bolKetNoiCSDL)
                        .MaDonViHanhChinh = User.DonViHanhChinhHienThoi
                        .MaHoSoCapGCN = strMaHoSoCapGCN
                        'Thiết lập chế độ active/unactive các chức năng
                        .MaKhoa = frmTimKiem.CrtTimKiemHoSoThuaDat1.strmakhoahoso
                        .TrangThaiChucNang(False, False)
                        .ShowData()
                    End With
                    'Thông tin Trả GCN
                    With .CtrlThongTinTraGCN
                        .Connection = GetConnection(bolKetNoiCSDL)
                        .MaDonViHanhChinh = User.DonViHanhChinhHienThoi
                        .MaHoSoCapGCN = strMaHoSoCapGCN
                        'Thiết lập chế độ active/unactive các chức năng
                        .MaKhoa = frmTimKiem.CrtTimKiemHoSoThuaDat1.strmakhoahoso
                        .TrangThaiChucNang(False, False)
                        .ShowData()
                    End With
                   
                End With
                'Hiển thị Form nghiệp vụ Cấp giấy chứng nhận
                activeTaskForm(, , , , True)
            End With
            'Trạng thái chức năng
            activeChucNang(, , , , True)
        Catch ex As Exception
            MsgBox("Lỗi hiển thị cấp giấy chứng nhận ...!", MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub

    Private Sub DangKyBienDong()
        Try
            'Chắc chắn rằng tồn tại MÃ HÒ SƠ CẤP GCN
            If (strMaHoSoCapGCN Is Nothing) Then
                Exit Sub
            ElseIf (strMaHoSoCapGCN = "") Then
                Exit Sub
            End If
            'Add cac chuc nang chi tiet len doi tuong lstChucNangChiTiet
            With Me.rtxtThongTinSoLuoc
                .Clear()
            End With
            '/Add...
            Dim Y As Integer
            Y = 0
            With Me
                'Không cho Scroll Control
                .AutoScroll = False
                With .CtrlDangKyBienDong
                    'Thiết lập kích thước của Control bằng kích thước của Panel chứa nó
                    .Height = Me.splitContainer.Panel2.Height
                    .Width = Me.splitContainer.Panel2.Width
                    .Location = New Point(0, Y)

                    'HIỂN THỊ THÔNG TIN CẤP GCN LÊN FORM
                    .Connection = GetConnection(bolKetNoiCSDL)
                    .MaHoSoCapGCN = strMaHoSoCapGCN
                    .MaThuaDat = strMaThuaDat
                    .MaDonViHanhChinh = User.DonViHanhChinhHienThoi
                    'Thiết lập chế độ active/unactive các chức năng
                    .MaKhoa = frmTimKiem.CrtTimKiemHoSoThuaDat1 .strmakhoahoso
                    .TrangThaiChucNang(False, False)
                    .LoaiBienDong()
                    .ShowData()
                End With
                'Hiển thị Form nghiệp vụ Cấp giấy chứng nhận
                activeTaskForm(, , , , , , True)
            End With
            'Trạng thái chức năng
            activeChucNang(, , , , , , True)
        Catch ex As Exception
            MsgBox("Lỗi đăng ký biến động ...!", MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub



    ''' <summary>
    ''' Chỉ hiển thị Form nghiệp vụ tương ứng, những Form nghiệp vụ khác sẽ bị ẩn.
    ''' </summary>
    ''' <param name="blnHoSoKeKhai"></param>
    ''' <param name="blnXetDuyetCapCoSo"></param>
    ''' <param name="blnThamDinh"></param>
    ''' <param name="blnPheDuyet"></param>
    ''' <param name="blnCapGCN"></param>
    ''' <remarks></remarks>
    Public Sub activeTaskForm(Optional ByVal blnHoSoKeKhai As Boolean = False, Optional ByVal blnXetDuyetCapCoSo As Boolean = False _
        , Optional ByVal blnThamDinh As Boolean = False, Optional ByVal blnPheDuyet As Boolean = False _
        , Optional ByVal blnCapGCN As Boolean = False, Optional ByVal blnTiepNhanHoSo As Boolean = False, Optional ByVal blnDangKyBienDong As Boolean = False)
        'Mục đích: Chỉ hiển thị Form nghiệp vụ tương ứng, những Form nghiệp vụ khác sẽ bị ẩn.
        Dim strErr As String = ""
        Try
            With Me
                'Ẩn tất cả các Form nghiệp vụ
                .CtrlThongTinTiepNhanHoSo.Visible = False
                .CtrlHoSoKeKhai.Visible = False
                .CtrlPheDuyet.Visible = False
                .CtrlThamDinh.Visible = False
                .CtrlThongTinCapGCN.Visible = False
                .CtrlXetDuyetCapCoSo.Visible = False
                .CtrlDangKyBienDong.Visible = False
                'Active Form nghiệp vụ cần thực thi
                If blnTiepNhanHoSo Then
                    .CtrlThongTinTiepNhanHoSo.Visible = True
                ElseIf blnHoSoKeKhai Then
                    .CtrlHoSoKeKhai.Visible = True
                ElseIf blnXetDuyetCapCoSo Then
                    .CtrlXetDuyetCapCoSo.Visible = True
                ElseIf blnThamDinh Then
                    .CtrlThamDinh.Visible = True
                ElseIf blnPheDuyet Then
                    .CtrlPheDuyet.Visible = True
                ElseIf blnCapGCN Then
                    .CtrlThongTinCapGCN.Visible = True
                ElseIf blnDangKyBienDong Then
                    .CtrlDangKyBienDong.Visible = True
                End If
            End With
        Catch ex As Exception
            strErr = ex.Message
            System.Windows.Forms.MessageBox.Show("Lỗi hiển thị form ...!", "DMCLand")
        End Try
        'Return strErr
    End Sub

    Private Sub outlookChucNang_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles outlookChucNang.KeyDown

        Select Case e.KeyCode
            Case Keys.F2
                TimKiem()
            Case Keys.F3
                HoSoKeKhai()
            Case Keys.F4
                ThamDinh()
            Case Keys.F5
                PheDuyet()
            Case Keys.F6
                CapGiayChungNhan()
        End Select
    End Sub
    ' Kết thúc thiết lập chức năng
#End Region

#Region "CÁC HÀM, CHỨC NĂNG CHO HỒ SƠ CẤP GCN"
    'CẦN XEM LẠI ĐỂ TỐI ƯU HÓA CÁC HÀM, THỦ TỤC TRONG PHẦN NÀY

    Dim dtTimKiemTaiSan As New DataTable
    Dim dtThongTinThuaKeKhai As New DataTable
    'Khai báo biến kiểm tra lỗi
    Private strError As String = ""
    'Khai báo biến chỉ thị hành động
    Private shortAction As Short = 0
    'Khai báo thuộc tính tờ bản đồ
#Region "KHAI BÁO CÁC THUỘC TÍNH"
    Public Property ToBanDo() As String
        Get
            Return strToBanDo
        End Get
        Set(ByVal value As String)
            strToBanDo = value
        End Set
    End Property

    'Khai báo thuộc tính số hiệu thửa đất
    Public Property SoHieuThua() As String
        Get
            Return strSoHieuThua
        End Get
        Set(ByVal value As String)
            strSoHieuThua = value
        End Set
    End Property
    'Khai báo thuộc tính Mã thửa đất
    Public Property MaThuaDat() As String
        Set(ByVal value As String)
            strMaThuaDat = value
        End Set
        Get
            Return strMaThuaDat
        End Get
    End Property
    'Khai báo thuộc tính Diện tích tự nhiên
    Public Property DienTichTuNhien() As String
        Get
            Return strDienTichTuNhien
        End Get
        Set(ByVal value As String)
            strDienTichTuNhien = value
        End Set
    End Property
    'Khai báo thuộc tính Địa chỉ thửa
    Public Property DiaChiThua() As String
        Get
            Return strDiaChiThua
        End Get
        Set(ByVal value As String)
            strDiaChiThua = value
        End Set
    End Property
    'Khai báo thuộc tính Mã hồ sơ cấp GCN
    Public Property MaHoSoCapGCN() As String
        Set(ByVal value As String)
            strMaHoSoCapGCN = value
        End Set
        Get
            Return strMaHoSoCapGCN
        End Get
    End Property
#End Region
    ''' <summary>
    ''' Phương thức thiết đặt trạng thái ban đầu cho toàn bộ điều khiển thành viên
    ''' NOTE: PHƯƠNG THỨC NÀY PHỤC VỤ TRONG PHẦN THÊM MỚI HỒ SƠ VÀ CẬP NHẬT HỒ SƠ
    ''' CHO CHỨC NĂNG THÊM MỚI
    ''' =>  CẦN XEM LẠI CÓ CẦN HÀM NÀY KHÔNG, VÀ CÓ CẦN THIẾT CHỨC NĂNG
    ''' THÊM MỚI VÀ CẬP NHẬT THÊM MỚI HỒ SƠ TRONG ĐIỀU KHIỂN NGHIỆP VỤ HỒ SƠ CẤP GCN KHÔNG
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    Public Sub TrangThaiBanDau()
        With Me
            'THIẾT LẬP TRẠNG THÁI BAN ĐẦU THÔNG TIN KÊ KHAI HỒ SƠ
            With CtrlHoSoKeKhai
                'Thiết lập trạng thái ban đầu thông tin kê khai Thửa đất
                .CtrlThongTinThuaKeKhai.TrangThaiBanDau()
                'End With
                'Thiết lập trạng thái ban đầu thông tin kê khai Tài liệu kèm theo
                .CtrlTaiLieuKemTheo.TrangThaiBanDau()
                'Thiết lập trạng thái ban đầu thông tin nhà ở
                With .CtrlNhaO
                End With
            End With
            'THIẾT LẬP TRẠNG THÁI BAN ĐẦU THÔNG TIN XÉT DUYỆT CẤP CƠ SỞ
            With .CtrlXetDuyetCapCoSo
                .CtrlHoiDongXetDuyet.TrangThaiBanDau()
                .CtrlThongTinXetDuyet.TrangThaiBanDau()
                .CtrThongTinHoSoXetDuyet1.TrangThaiBanDau()
                .CtrlThongTinBoSung.TrangThaiBanDau()
            End With
            'THIẾT LẬP TRẠNG THÁI BAN ĐẦU THÔNG TIN THẨM ĐỊNH
            With .CtrlThamDinh
                'Thông tin yêu cầu bổ xung của cán bộ thẩm định
                .CtrlYeuCauBoXungThamDinh.TrangThaiBanDau()
                .TrangThaiBanDau()
            End With
            'THIẾT LẬP TRẠNG THÁI BAN ĐẦU THÔNG TIN PHÊ DUYỆT
            .CtrlPheDuyet.TrangThaiBanDau()
            ''THIẾT LẬP TRẠNG THÁI BAN ĐẦU THÔNG TIN CẤP GCN
            '.CtrlThongTinCapGCN.TrangThaiBanDau()

        End With
    End Sub
    ''' <summary>
    ''' Thiết lập trạng thái cập nhật cho các đối tượng
    ''' </summary>
    ''' <param name="blnCapNhat"></param>
    ''' <remarks> 
    ''' Coder: Vũ Lê Thành
    ''' Date Modified: 200812
    ''' Thủ tục này chỉ sử dụng cho phần cập nhật Hồ sơ kê khai
    ''' trong trường hợp Thêm mới hồ sơ?
    ''' </remarks>
    Private Sub TrangThaiCapNhat(Optional ByVal blnCapNhat As Boolean = False)
        With Me
            With CtrlHoSoKeKhai
                'Thiết lập trạng thái cập nhật thông tin kê khai Thửa đất
                .CtrlThongTinThuaKeKhai.TrangThaiCapNhat(blnCapNhat)
                If strMaHoSoCapGCN <> "" Then
                    'End With
                    'Thiết lập trạng thái cập nhật thông tin Nhà ở
                    With .CtrlNhaO
                        .TrangThaiCapNhat(blnCapNhat)
                    End With
                    'Thông tin Rừng cây
                    With .CtrlThongTinRungCay
                        .TrangThaiCapNhat(blnCapNhat)
                    End With
                    'Thông tin Cây lâu năm
                    With .CtrlThongTinCayLauNam
                        .TrangThaiCapNhat(blnCapNhat)
                    End With
                    'Thiết lập trạng thái cập nhật thông tin Tài liệu kèm theo
                    .CtrlTaiLieuKemTheo.TrangThaiCapNhat(blnCapNhat)
                End If
            End With
        End With
    End Sub
    ''' <summary>
    ''' Bật tắt các chức năng(Thêm, sửa, xóa...) đối với trường hợp thêm
    ''' mới hồ sơ
    ''' CẦN XEM LẠI CHỨC NĂNG NÀY ĐỂ TỐI ƯU HƠN
    ''' </summary>
    ''' <param name="blnStartEdited"></param>
    ''' <param name="blnStartDeleted"></param>
    ''' <remarks></remarks>
    Private Sub TrangThaiChucNang(Optional ByVal blnStartEdited As Boolean = False, Optional ByVal blnStartDeleted As Boolean = False)
        'Coder: Vũ Lê Thành
        'Date Modifier: 200812
        'Mục đích: Bật tắt các chức năng(Thêm, sửa, xóa...) đối với trường hợp thêm
        'mới hồ sơ
        With Me
            If strMaHoSoCapGCN <> "" Then
                With .CtrlHoSoKeKhai
                    'End With
                    .CtrlTaiLieuKemTheo.TrangThaiChucNang(blnStartEdited, blnStartDeleted)
                    With .CtrlNhaO
                        .TrangThaiChucNang(blnStartEdited, blnStartDeleted)
                    End With
                    'Công trình xây dựng
                    With .CtrlCongTrinhXayDung
                        .TrangThaiChucNang(blnStartEdited, blnStartDeleted)
                    End With
                    With .CtrlThongTinRungCay
                        .TrangThaiChucNang(blnStartEdited, blnStartDeleted)
                    End With
                    With .CtrlThongTinCayLauNam
                        .TrangThaiChucNang(blnStartEdited, blnStartDeleted)
                    End With
                End With
            End If
        End With
    End Sub
    ''' <summary>
    ''' Thiết lập các giá trị hiển trên Form trong trường hợp thêm mới hồ sơ
    ''' Cần xem lại phương thức này để tối ưu hóa 
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub TaoHoSoCapGCNMoiDaCoThongTinKhongGianThuaDat()
        If (User.DonViHanhChinhHienThoi = 0) Or (User.DonViHanhChinhHienThoi = Nothing) Then
            MessageBox.Show("Chọn đơn vị hành chính trước khi tạo hồ sơ mới....", "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        If (strMaThuaDat.Trim = "") Or (strMaThuaDat = 0) Or strGlbMaThuaDat = Nothing Then
            MsgBox("Bạn chưa chọn Thửa đất cần thêm Hồ sơ cấp GCN!", MsgBoxStyle.Information, "DMCLand")
            Exit Sub
        End If
        shortAction = 1

        With Me
            'Cập nhật thông tin Hồ sơ cấp GCN vào bảng tblHoSoCapGCN
            .UpdateHoSoCapGCNDaCoThongTinKhongGianThuaDat()
            'Thiết lập trạng thái ban đầu sau khi cập nhật
            .TrangThaiBanDau()
            'Thiết lập trạng thái chức năng của các điều khiển sau khi cập nhật
            .TrangThaiChucNang(True)
            'Hiển thị thông tin TIẾP NHẬN HỒ SƠ
            Me.TiepNhanHoSo()
        End With
    End Sub

    ''' <summary>
    ''' Cập nhật Hồ sơ cấp GCN đã có thông tin không gian thửa đất
    ''' vào bảng tblHoSoCapGCN
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub UpdateHoSoCapGCNDaCoThongTinKhongGianThuaDat()
        'Khai báo và khởi tạo đối tượng
        Dim HoSoCapGCN As New clsHoSoCapGCN
        Dim DonViHanhChinh As New clsDonViHanhChinh
        'Khai báo biến kiểu DataTable
        Dim dtDonViHanhChinh As New DataTable
        'Khai báo biến kiểu String chứa Mã xã
        Dim strMaXa As String = ""
        Try
            If Not ((strMaThuaDat.Trim = "") Or (strMaThuaDat = 0)) Then
                HoSoCapGCN.MaThuaDat = strMaThuaDat
            Else
                MessageBox.Show("Bạn phải chọn thửa đất cần tạo Hồ sơ cấp GCN", "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            '-------------- Xác định Mã xã từ Mã đơn vị hành chính -----------------
            With DonViHanhChinh
                .Connection = GetConnection(bolKetNoiCSDL)
                .MaDonViHanhChinh = intGlobalMaDonViHanhChinh.ToString()
                dtDonViHanhChinh.Clear()
                .SelectTuDienDonViHanhChinhByMaXa(dtDonViHanhChinh)
            End With
            'Xác nhận Mã xã tìm được
            strMaXa = dtDonViHanhChinh.Rows(0).Item("MaXa").ToString()
            'Lấy địa chỉ Mặc định
            strDiaChiThua = TenDonViHanhChinh()
            ''Cập nhật Mã đơn vị hành chính (Mã xã/Phường) 
            ''đảm bảo gồm 5 số theo qui định tại thông tin 17/2009
            ''Bộ tài nguyên môi trường
            ''vào bảng tblHoSoCapGCN để in ra mã vạch
            'Select Case strMaXa.Trim.Length()
            '    Case 1
            '        strMaXa = "0000" + strMaXa
            '    Case 2
            '        strMaXa = "000" + strMaXa
            '    Case 3
            '        strMaXa = "00" + strMaXa
            '    Case 4
            '        strMaXa = "0" + strMaXa
            '    Case 5
            '        strMaXa = strMaXa
            '    Case Else
            '        strMaXa = "00000"
            'End Select

            Dim kt As Boolean
            kt = CheckTaoHoSoByToBanDoSoThua(strToBanDo, strSoHieuThua, User.DonViHanhChinhHienThoi, strMaThuaDat)
            If kt Then
                If MessageBox.Show("Hồ sơ của tờ bản đồ " & strToBanDo & ", số thửa " & strSoHieuThua & " đã có. Bạn có muốn tạo thêm nữa không ???", "DMCLand", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.No Then
                    Return
                Else
                    strMaHoSoCapGCN = ""
                End If
            Else
                strMaHoSoCapGCN = ""
            End If

            HoSoCapGCN.MaXa = strMaXa
            HoSoCapGCN.DiaChiThua = strDiaChiThua
            HoSoCapGCN.DienTichTuNhien = strDienTichTuNhien.Trim
            HoSoCapGCN.SoThua = strSoHieuThua.Trim
            HoSoCapGCN.ToBanDo = strToBanDo.Trim
            HoSoCapGCN.MaDonViHanhChinh = User.DonViHanhChinhHienThoi
            Dim str As String = "", strError As String = ""
            HoSoCapGCN.Connection = GetConnection(bolKetNoiCSDL)
            'Thêm Hồ sơ cấp GCN mới cho Thửa đất
            strError = HoSoCapGCN.InsertHoSoCapGCNCoThongTinKhongGianThuaDat(str)
            '
            If strError = "" Then
                If shortAction = 3 Then
                    'Xoa du lieu tren Form doi voi truong hop xoa du lieu
                    TrangThaiBanDau()
                End If
                If shortAction = 1 Then
                    'Nhận Mã hồ sơ cấp GCN mới tạo ra
                    strMaHoSoCapGCN = str
                    NhatKyNguoiDung("Thêm hồ sơ đã có thông tin thửa đất", "Thêm", "Tạo hồ sơ " & strMaHoSoCapGCN & " với tờ bản đồ " & strToBanDo.Trim & ", số thửa " & strSoHieuThua.Trim & ", diện tích " & strDienTichTuNhien.Trim)
                End If
                shortAction = 0
                MessageBox.Show("Thêm Hồ sơ cấp GCN mới THÀNH CÔNG!", "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TaoFileMaHoSoCapGCN(strMaHoSoCapGCN)
            Else
                MessageBox.Show("Thêm Hồ sơ cấp GCN mới KHÔNG thành công", "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            strError = HoSoCapGCN.Err
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Hồ sơ cấp GCN " & vbNewLine & " Cập nhật dữ liệu " & vbNewLine _
                   & "Lỗi ....! ", MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub
#Region "Cập nhật Hồ sơ cấp GCN mới khi chưa có thông tin Bản đồ thửa đất"
    Public Function CheckTaoHoSoByToBanDoSoThua(ByVal tobando As String, ByVal SoThua As String, ByVal DonViHanhChinh As String, ByVal strMaThuaDat As String) As Boolean
        Dim kt As Boolean = True
        Dim dt As New DataTable
        Dim cls As New clsHoSoCapGCN
        cls.ToBanDo = tobando
        cls.SoThua = SoThua
        cls.MaThuaDat = strMaThuaDat
        cls.MaDonViHanhChinh = DonViHanhChinh
        cls.SelectHoSoByToBanDoSoThua(dt)
        If dt.Rows.Count > 0 Then
            kt = True
        Else
            kt = False
        End If
        Return kt
    End Function
    Public Sub TaoHoSoCapGCNMoiChuaCoThongTinKhongGianThuaDat()
        If (User.DonViHanhChinhHienThoi = 0) Or (User.DonViHanhChinhHienThoi = Nothing) Then
            MessageBox.Show("Chọn đơn vị hành chính trước khi tạo hồ sơ mới....", "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        If intGlobalMaDonViHanhChinh = 0 Then
            MsgBox("Bạn chưa chọn ĐƠN VỊ HÀNH CHÍNH (XÃ/PHƯỜNG) cần thêm Hồ sơ cấp GCN!", MsgBoxStyle.Information, "DMCLand")
            Exit Sub
        End If
        strMaHoSoCapGCN = ""
        strMaThuaDat = ""
        strGlbMaHoSoCapGCN = ""
        strGlbMaThuaDat = ""
        With Me
            'Thêm thông tin Hồ sơ cấp GCN mới khi vào bảng tblHoSoCapGCN
            .UpdateHoSoCapGCNChuaCoThongTinKhongGianThuaDat()
            .CtrlThongTinThuaTuNhien1.TrangThaiBanDau()
            'Thiết lập trạng thái ban đầu sau khi cập nhật
            .TrangThaiBanDau()
            'Thiết lập trạng thái chức năng của các điều khiển sau khi cập nhật
            .TrangThaiChucNang(True)
            'Hiển thị thông tin TIẾP NHẬN HỒ SƠ
            Me.TiepNhanHoSo()

        End With
    End Sub

    ''' <summary>
    ''' Cập nhật Hồ sơ cấp GCN CHƯA có thông tin không gian thửa đất
    ''' vào bảng tblHoSoCapGCN
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub UpdateHoSoCapGCNChuaCoThongTinKhongGianThuaDat()
        'Khai báo và khởi tạo đối tượng
        Dim HoSoCapGCN As New clsHoSoCapGCN
        Dim DonViHanhChinh As New clsDonViHanhChinh
        'Khai báo biến kiểu DataTable
        Dim dtDonViHanhChinh As New DataTable
        'Khai báo biến kiểu String chứa Mã xã
        Dim strMaXa As String = ""
        Try
            'Kiểm tra dữ liệu đầu vào
            'Chắc chắn rằng tồn tại một đơn vị hành chính cần tạo Hồ sơ cấp GCN mới
            If (intGlobalMaDonViHanhChinh = 0) Then
                MessageBox.Show("Bạn phải chọn một ĐƠN VỊ HÀNH CHÍNH cần thêm mới Hồ sơ cấp GCN", "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            HoSoCapGCN.MaThuaDat = Nothing
            '-------------- Xác định Mã xã từ Mã đơn vị hành chính -----------------
            With DonViHanhChinh
                .Connection = GetConnection(bolKetNoiCSDL)
                .MaDonViHanhChinh = intGlobalMaDonViHanhChinh.ToString()
                dtDonViHanhChinh.Clear()
                .SelectTuDienDonViHanhChinhByMaXa(dtDonViHanhChinh)
            End With
            'Xác nhận Mã xã tìm được
            strMaXa = dtDonViHanhChinh.Rows(0).Item("MaXa").ToString()

            ''Cập nhật Mã đơn vị hành chính (Mã xã/Phường) 
            ''đảm bảo gồm 5 số theo qui định tại thông tin 17/2009
            ''Bộ tài nguyên môi trường
            ''vào bảng tblHoSoCapGCN để in ra mã vạch
            'Select Case strMaXa.Trim.Length()
            '    Case 1
            '        strMaXa = "0000" + strMaXa
            '    Case 2
            '        strMaXa = "000" + strMaXa
            '    Case 3
            '        strMaXa = "00" + strMaXa
            '    Case 4
            '        strMaXa = "0" + strMaXa
            '    Case 5
            '        strMaXa = strMaXa
            '    Case Else
            '        strMaXa = "00000"
            'End Select

            HoSoCapGCN.MaXa = strMaXa
            HoSoCapGCN.DiaChiThua = Nothing
            HoSoCapGCN.DienTichTuNhien = Nothing
            HoSoCapGCN.SoThua = Nothing
            HoSoCapGCN.ToBanDo = Nothing
            Dim str As String = "", strError As String = ""
            HoSoCapGCN.Connection = GetConnection(bolKetNoiCSDL)
            HoSoCapGCN.MaDonViHanhChinh = User.DonViHanhChinhHienThoi
            'Thêm mới Hồ sơ cấp GCN khi chưa có thông tin không gian thửa đất
            ' ''If strGlbMaThuaDat <> "" Or strGlbMaThuaDat <> "0" Then
            ' ''    MessageBox.Show("Kiểm tra lại, hồ sơ đã có bản đồ dữ liệu không gian", "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ' ''    Return
            ' ''End If
            strError = HoSoCapGCN.InsertHoSoCapGCNChuaCoThongTinKhongGianThuaDat(str)

            If strError = "" Then
                'Nhận MaHoSoCapGCN mới tạo ra
                strMaHoSoCapGCN = str
                NhatKyNguoiDung("Thêm hồ sơ không có thông tin thửa đất", "Thêm", "Tạo hồ sơ " & strMaHoSoCapGCN)
                shortAction = 0
                MessageBox.Show("Thêm Hồ sơ cấp GCN mới THÀNH CÔNG!", "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TaoFileMaHoSoCapGCN(strMaHoSoCapGCN)
            Else
                MessageBox.Show("Thêm Hồ sơ cấp GCN mới KHÔNG thành công", "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            strError = HoSoCapGCN.Err
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Lỗi cập nhật Hồ sơ cấp GCN CHƯA CÓ thông tin không gian thửa đất ", MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub
#End Region
#End Region

    ''' <summary>
    ''' Trạng thái Hồ sơ cấp GCN
    ''' Note: Cần xem lại thủ tục này
    ''' </summary>
    ''' <param name="intTrangThaiHoSoCapGCN"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function TrangThaiHoSoCapGCN(ByVal intTrangThaiHoSoCapGCN As Integer) As String
        Dim strTemp As String = ""
        Select Case intTrangThaiHoSoCapGCN
            Case 0 : strTemp = "Hồ sơ mới tạo"
            Case 1 : strTemp = "Tiếp nhận Hồ sơ"
            Case 2 : strTemp = "Hồ sơ kê khai"
            Case 3 : strTemp = "Xét duyệt cấp cơ sở (Phường)"
            Case 4 : strTemp = "Thẩm định"
            Case 5 : strTemp = "Phê duyệt"
            Case 6 : strTemp = "Cấp GCN"
            Case 7 : strTemp = "Hồ sơ hoàn tất cấp GCN"
        End Select
        Return strTemp
    End Function

    Private Sub CtrlThongTinThuaTuNhien1_ChonHoSo() Handles CtrlThongTinThuaTuNhien1.ChonHoSo
        frmMain.HienThiThongTinThuaDat(CtrlThongTinThuaTuNhien1.MaHSChon, strMaThuaDat)
    End Sub

    
  
End Class
