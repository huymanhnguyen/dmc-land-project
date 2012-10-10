Imports System.Drawing
Imports System.Windows.Forms
Public Class ctrlThongTinXetDuyet
    ' Định nghĩa trạng thái Xét duyệt Hồ sơ có giá trị bằng 3
    ReadOnly TRANG_THAI_XET_DUYET As Integer = 3
    'Khai báo thuộc tính nhận chuỗi kết nối Database
    Private strConnection As String = ""
    'Khai báo biến kiểm tra lỗi
    Private strError As String = ""
    'Khai báo biến trạng thái Hồ sơ cấp GCN
    Private longTrangThaiHoSoCapGCN As Integer = 0
    Private strMaHoSoCapGCN As String = ""
    Private dtThongTinXetDuyet As New DataTable
    Private shFlag As Short = 0
    Private blnNonNumberEntered As Boolean
    'Khai báo biến kiểm tra trạng thái Load Control hay chưa
    'Biến này phục vụ cho trạng thái điều khiển Checkbox tranh chấp, khiếu kiện
    Private blnLoaded As Boolean = False
    Private strMaDonViHanhChinh As String = ""
    'Khai báo thuộc tính nhận chuỗi kết nối
    Public WriteOnly Property Connection() As String
        Set(ByVal value As String)
            strConnection = value
        End Set
    End Property
    Public WriteOnly Property Flag() As String
        Set(ByVal value As String)
            shFlag = value
        End Set
    End Property
    'Khai báo thuộc tính chỉ đọc Trạng thái Hồ sơ cấp GCN
    Public ReadOnly Property TrangThaiHoSoCapGCN() As Long
        Get
            Return longTrangThaiHoSoCapGCN
        End Get
    End Property
    Public WriteOnly Property MaHoSoCapGCN() As String
        Set(ByVal value As String)
            strMaHoSoCapGCN = value
        End Set
    End Property
    Public WriteOnly Property MaDonViHanhChinh() As String
        Set(ByVal value As String)
            strMaDonViHanhChinh = value
        End Set
    End Property
    ' Hien thi du lieu Phe duyet 
    Public Sub ShowData()
        'Khai bao va khoi tao doi tuong clsThongTinXetDuyet
        Dim ThongTinXetDuyet As New clsThongTinXetDuyet
        Try
            With ThongTinXetDuyet
                'Gán chuỗi kết nối Database
                .Connection = strConnection
                'Gan gia tri cho cac thuoc tinh doi voi truong hop truy van
                .Action = 0
                .MaHoSoCapGCN = strMaHoSoCapGCN
            End With
            'Khoi tao trang thai ban dau
            TrangThaiBanDau()
            'Goi phuong thuc GetData de khoi tao doi tuong clsHSKKTaiSan
            If ThongTinXetDuyet.GetData(dtThongTinXetDuyet) = "" Then
                ' Trinh bay du lieu len grdvwTaiSan
                If dtThongTinXetDuyet.Rows.Count > 0 Then
                    For i As Integer = 0 To dtThongTinXetDuyet.Rows.Count - 1
                        With dtThongTinXetDuyet.Rows(i)
                            'Trạng thái Hồ sơ cấp GCN TrangThaiHoSoCapGCN
                            If IsNumeric(.Item("TrangThaiHoSoCapGCN").ToString) Then
                                Me.longTrangThaiHoSoCapGCN = Convert.ToInt16(.Item("TrangThaiHoSoCapGCN").ToString)
                            Else
                                Me.longTrangThaiHoSoCapGCN = 0
                            End If
                            'Tờ trình phường 
                            Me.txtToTrinh.Text = .Item("ToTrinhPhuong").ToString
                            'Cảnh bao tranh chấp khiếu kiện
                            If .Item("CanhBaoTranhChapKhieuKien").ToString = "True" Then
                                chkCanhBaoTranhChap.Checked = True
                            Else
                                chkCanhBaoTranhChap.Checked = False
                            End If
                            'Nội dung tranh chấp khiếu kiện
                            Me.txtNoiDungTranhChapKhieuKien.Text = .Item("NoiDungTranhChapKhieuKien").ToString
                            'Ý kiến cán bộ xét duyệt
                            Me.txtYKienCanBoXetDuyet.Text = .Item("YKienCanBoXetDuyet").ToString
                            'Lý do không cấp
                            Me.txtLyDoKhongCap.Text = .Item("LyDoKhongCap").ToString
                            Me.txtPhamViBaoVeHaTang.Text = .Item("HanhLangBaoVeCongTrinhHaTang").ToString
                            'Kết quả  xét duyệt
                            Me.cmbKetQuaXetDuyet.Text = dtThongTinXetDuyet.Rows(i).Item("TrangThaiXetDuyet").ToString
                            'Ngày trình Phường
                            If .Item("NgayTrinhPhuong").ToString = "" Then
                                Me.dtpNgayTrinh.Value = Date.Now.Date
                            Else
                                Me.dtpNgayTrinh.Value = Convert.ToDateTime(.Item("NgayTrinhPhuong").ToString)
                            End If
                            'Ngày xét duyệt
                            If .Item("NgayXetDuyet").ToString = "" Then
                                Me.dtpNgayXetDuyet.Value = Date.Now.Date
                            Else
                                Me.dtpNgayXetDuyet.Value = Convert.ToDateTime(.Item("NgayXetDuyet").ToString)
                            End If
                        End With
                    Next i
                End If
            End If
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Hiển thị dữ liệu Thông tin xét duyệt " & vbNewLine & " Lỗi: " & vbNewLine & ex.Message, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub

    Public Sub UpdateData()
        'Khai bao va khoi tao doi tuong clsThongTinXetDuyet
        Dim ThongTinXetDuyet As New clsThongTinXetDuyet
        Try
            'Xac nhan gia tri can cap nhat
            With ThongTinXetDuyet
                'Gán chuỗi kết nối Database
                .Connection = strConnection
                .Action = shFlag
                ' Kiểm tra trạng thái Hồ sơ trước khi cập nhật:
                ' Nếu giá trị trạng thái Hồ sơ hiện thời nhỏ hơn
                ' giá trị trạng thái Xét duyệt thì ta lấy là giá trị 
                ' trạng thái tiếp nhận Hồ sơ, ngược lại giữ nguyên giá trị 
                If (longTrangThaiHoSoCapGCN < TRANG_THAI_XET_DUYET) Then
                    ThongTinXetDuyet.TrangThaiHoSoCapGCN = TRANG_THAI_XET_DUYET
                Else
                    ThongTinXetDuyet.TrangThaiHoSoCapGCN = longTrangThaiHoSoCapGCN
                End If

                .MaHoSoCapGCN = strMaHoSoCapGCN
                .KetQuaXetDuyet = Me.cmbKetQuaXetDuyet.FindString(Me.cmbKetQuaXetDuyet.Text.Trim)
                .NgayTrinhPhuong = Me.dtpNgayTrinh.Text

                .NgayXetDuyet = Me.dtpNgayXetDuyet.Text
                .ToTrinhPhuong = Me.txtToTrinh.Text.Trim

                If cmbKetQuaXetDuyet.Text = "Đủ diều kiện" Then
                    .Flag = "3"
                    .UpdateTrangThai()
                ElseIf cmbKetQuaXetDuyet.Text = "Chưa đủ điều kiện" Then
                    .Flag = "32"
                    .UpdateTrangThai()
                ElseIf cmbKetQuaXetDuyet.Text = "Không đủ điều kiện" Then
                    .Flag = "31"
                    .UpdateTrangThai()
                Else
                    .Flag = "2"
                    .UpdateTrangThai()
                End If


                'Cập nhật trạng thái tranh chấp khiếu kiện
                If Me.chkCanhBaoTranhChap.Checked Then
                    .CanhBaoTranhChapKhieuKien = 1
                Else
                    .CanhBaoTranhChapKhieuKien = 0
                End If
                'Cập nhật nội dung tranh chấp khiếu kiện
                .NoiDungTranhChapKhieuKien = Me.txtNoiDungTranhChapKhieuKien.Text.Trim
                .YKienCanBoXetDuyet = Me.txtYKienCanBoXetDuyet.Text.Trim
                .LyDoKhongCap = Me.txtLyDoKhongCap.Text.Trim
                .PhamViBaoVeHaTang = txtPhamViBaoVeHaTang.Text.Trim
                Dim str As String = ""
                'Neu cap nhat thanh cong
                If .Execute(str) = "" Then
                    If shFlag = 1 Then

                    ElseIf shFlag = 3 Then
                        'Xoa du lieu tren Form doi voi truong hop xoa du lieu
                        TrangThaiBanDau()
                    End If
                    shFlag = 0
                End If
                strError = .Err
            End With
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Cập nhật dữ liệu Thông tin xét duyệt " & vbNewLine & " Lỗi: " & vbNewLine & ex.Message, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub

    Public Sub TrangThaiCapNhat(Optional ByVal blnCapNhat As Boolean = False)
        'Bật tắt trạng thái cập nhật dữ liệu của các điều khiển
        With Me
            'Tờ trình Phường
            .txtToTrinh.ReadOnly = Not blnCapNhat
            'Nội dung tranh chấp khiếu kiện
            .txtNoiDungTranhChapKhieuKien.ReadOnly = Not blnCapNhat
            'Cảnh báo tranh chấp khiếu kiện
            .chkCanhBaoTranhChap.Enabled = blnCapNhat
            'Ý kiến cán bộ xét duyệt
            .txtYKienCanBoXetDuyet.ReadOnly = Not blnCapNhat
            'Lý do không cấp
            .txtLyDoKhongCap.ReadOnly = Not blnCapNhat
            .txtPhamViBaoVeHaTang.ReadOnly = Not blnCapNhat
            'Ngày trình phường
            .dtpNgayTrinh.Enabled = blnCapNhat
            'Ngày xét duyệt
            .dtpNgayXetDuyet.Enabled = blnCapNhat
            'Kết quả xét duyệt cấp Phường
            .cmbKetQuaXetDuyet.Enabled = blnCapNhat
            If blnCapNhat Then
                .txtToTrinh.BackColor = Color.White
                .txtYKienCanBoXetDuyet.BackColor = Color.White
                .txtLyDoKhongCap.BackColor = Color.White
                .txtNoiDungTranhChapKhieuKien.BackColor = Color.White
                txtPhamViBaoVeHaTang.BackColor = Color.White
            Else
                .txtToTrinh.BackColor = Color.LightYellow
                .txtYKienCanBoXetDuyet.BackColor = Color.LightYellow
                .txtLyDoKhongCap.BackColor = Color.LightYellow
                .txtNoiDungTranhChapKhieuKien.BackColor = Color.LightYellow
                txtPhamViBaoVeHaTang.BackColor = Color.LightYellow
            End If
        End With
    End Sub

    Public Sub TrangThaiBanDau()
        'Thiết lập trạng thái ban đầu
        Dim ThongTinXetDuyet As New clsThongTinXetDuyet
        Dim dtTrangThaiXetDuyet As New DataTable
        With Me
            'Hiển thị từ điển trạng thái Phê duyệt lên Form
            If (strConnection <> "") Then
                ThongTinXetDuyet.Connection = strConnection
                ThongTinXetDuyet.SelectTuDienTrangThaiXetDuyet(dtTrangThaiXetDuyet)
                If (dtTrangThaiXetDuyet.Rows.Count > 0) Then
                    .cmbKetQuaXetDuyet.DataSource = dtTrangThaiXetDuyet
                    .cmbKetQuaXetDuyet.DisplayMember = dtTrangThaiXetDuyet.Columns(0).ColumnName
                End If
            End If
            dtThongTinXetDuyet.Clear()
            .txtToTrinh.Text = ""
            .txtYKienCanBoXetDuyet.Text = ""
            .txtLyDoKhongCap.Text = ""
            .txtPhamViBaoVeHaTang.Text = ""
            .dtpNgayTrinh.Value = Date.Now
            .dtpNgayXetDuyet.Value = Date.Now
            .cmbKetQuaXetDuyet.Text = ""
            'Cảnh báo tranh chấp khiếu kiện
            .chkCanhBaoTranhChap.Checked = False
            'Nội dung tranh chấp khiếu kiện
            .txtNoiDungTranhChapKhieuKien.Text = ""
        End With
    End Sub

    Public Sub TrangThaiChucNang(Optional ByVal blnStartEdited As Boolean = False, Optional ByVal blnStartDeleted As Boolean = False)
        With Me
            .btnSua.Enabled = Not blnStartEdited
            .btnXoa.Enabled = Not blnStartEdited
            .btnCapNhat.Enabled = blnStartEdited
            .btnHuyLenh.Enabled = blnStartEdited
            If blnStartDeleted Then
                .btnCapNhat.Enabled = Not blnStartDeleted
                .btnHuyLenh.Enabled = Not blnStartDeleted
            End If
        End With
    End Sub

    Private Sub btnSua_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSua.Click
        shFlag = 2
        With Me
            'Trang thai chuc nang
            .TrangThaiChucNang(True)
            'Trang thai cap nhat
            .TrangThaiCapNhat(True)
        End With
    End Sub

    Private Sub btnXoa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXoa.Click
        With Me
            If strMaHoSoCapGCN <> "" Then
                If MsgBox("Bạn chắc chắn muốn xóa không?", MsgBoxStyle.YesNo, "DMCLand!") = MsgBoxResult.Yes Then
                    shFlag = 3
                    .UpdateData()
                    'Trang thai ban dau
                    .TrangThaiBanDau()
                    'Trang thai chuc nang
                    .TrangThaiChucNang(True, True)
                    If (strError = "") Then
                        MsgBox(" Bạn đã cập nhật thành công!", MsgBoxStyle.Information, "DMCLand")
                    Else
                        MsgBox(" Cập nhật chưa thành công!", MsgBoxStyle.Critical, "DMCLand")
                    End If
                Else
                    'Trang thai chuc nang
                    .TrangThaiChucNang()
                End If
            End If
            'Trang thai cap nhat 
            .TrangThaiCapNhat()
        End With
        strError = ""
    End Sub

    Private Sub btnCapNhat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCapNhat.Click
        Try
            'Kiem tra tinh hop le cua thong tin vao
            If Me.cmbKetQuaXetDuyet.Text.Trim = "" Then
                If (System.Windows.Forms.MessageBox.Show("Bạn chưa lựa chọn Kết quả xét duyệt!" & vbNewLine _
                    & "Bạn có muốn lựa chọn không?", "DMCLand", MessageBoxButtons.YesNo) = DialogResult.Yes) Then
                    Me.cmbKetQuaXetDuyet.Focus()
                    Exit Sub
                End If
            End If
            'Cap nhat thong tin Tham Dinh
            Me.UpdateData()

        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Cập nhật Thông tin xét duyệt " & vbNewLine & " Lỗi: " & vbNewLine & ex.Message, MsgBoxStyle.Information, "DMCLand")
        End Try
        'Trang thai chuc nang
        Me.TrangThaiChucNang()
        'Trang thai cap nhat
        Me.TrangThaiCapNhat()
        'Hiển thị thông tin xét duyệt cấp cơ sở (Phường)
        Me.ShowData()
        If (strError = "") Then
            MsgBox(" Bạn đã cập nhật thành công!", MsgBoxStyle.Information, "DMCLand")
        Else
            MsgBox(" Cập nhật chưa thành công!", MsgBoxStyle.Critical, "DMCLand")
        End If
        strError = ""
    End Sub

    Private Sub ctrlThongTinXetDuyet_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        With Me
            With .dtpNgayTrinh
                .CustomFormat = "dd/MM/yyyy"
                .Format = DateTimePickerFormat.Custom
                .ShowCheckBox = True
            End With
            With .dtpNgayXetDuyet
                .CustomFormat = "dd/MM/yyyy"
                .Format = DateTimePickerFormat.Custom
                .ShowCheckBox = True
            End With
            'Trang thai cap nhat
            .TrangThaiCapNhat()
            'Trang thai chuc nang
            .TrangThaiChucNang(True, True)
        End With
    End Sub

    Private Sub btnHuyLenh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHuyLenh.Click
        With Me
            'Xoa du lieu tren Form
            .TrangThaiBanDau()
            'Hien thi du lieu
            If strMaHoSoCapGCN <> "" Then
                .ShowData()
            End If
            'Trang thai chuc nang
            .TrangThaiChucNang()
            'Trang thai cap nhat 
            .TrangThaiCapNhat()
        End With
        shFlag = 0
    End Sub

    Private Sub btnThem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThem.Click
        shFlag = 1
        With Me
            'Thiet lap trang thai ban dau
            .TrangThaiBanDau()
            'Trang thai cap nhat
            .TrangThaiCapNhat(True)
            'Trang thai chuc nang 
            .TrangThaiChucNang(True)
        End With
    End Sub

    Private Sub chkCanhBaoTranhChap_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCanhBaoTranhChap.CheckedChanged
        If chkCanhBaoTranhChap.Checked Then
            With txtNoiDungTranhChapKhieuKien
                .Enabled = True
                If blnLoaded Then
                    .BackColor = Color.White
                Else
                    blnLoaded = True
                End If
            End With
        Else
            With txtNoiDungTranhChapKhieuKien
                .Enabled = False
                .BackColor = Color.LightYellow
            End With
        End If
    End Sub

    Private Sub btnBienBanXetDuyet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBienBanXetDuyet.Click
        Dim frm As New frmReportBienBanXetDuyet
        With frm.CtrBienBanXetDuyetCapGCN1
            .Conection = strConnection
            .MaHoSoCapGCN = strMaHoSoCapGCN
            .MaDVHC = strMaDonViHanhChinh
            .ctrBienbanXetDuyetHoSoCapGCN_Load()
            frm.Show()
        End With
    End Sub
End Class

