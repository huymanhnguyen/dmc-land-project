Imports System.Windows.Forms
Imports System.Drawing
Public Class ctrlPheDuyet
    ' Định nghĩa trạng thái Phê duyệt Hồ sơ có giá trị bằng 5
    ReadOnly TRANG_THAI_PHE_DUYET As Integer = 5
    'Khai báo biến nhận chuỗi kết nối Database
    Private strConnection As String = ""
    'Khai báo biến nhận thông báo lỗi
    Private strError As String = ""
    'Khai báo biến nhận Mã hồ sơ phê duyệt
    Private strMaHoSoPheDuyet As String = ""
    'Khai báo biến nhận Mã hồ sơ cấp GCN
    Private strMaHoSoCapGCN As String = ""
    ' Khai bao bien nhan ve Flag 
    Private strFlag As Integer
    'Khai báo biến kiểu Bảng nhận thông tin Phê duyệt
    Private dtPheDuyet As New DataTable
    'Khai báo xác nhận hành động cần thực thi
    Private shortAction As Short = 0
    Private strMaDonViHanhChinh As String = ""

    Public Property MaDonViHanhChinh() As String
        Get
            Return strMaDonViHanhChinh
        End Get
        Set(ByVal value As String)
            strMaDonViHanhChinh = value
        End Set
    End Property
    'Khai bao thuoc tinh tuong ung voi Flag
    Public Property Flag() As String
        Get
            Return strFlag
        End Get
        Set(ByVal value As String)
            strFlag = value
        End Set
    End Property
    'Khai báo thuộc tính nhận chuỗi kết nối Database
    Public WriteOnly Property Connection() As String
        Set(ByVal value As String)
            strConnection = value
        End Set
    End Property
    Private MaLoaiBienDong As String = ""
    Public Property MaKhoa() As String
        Get
            Return MaLoaiBienDong
        End Get
        Set(ByVal value As String)
            MaLoaiBienDong = value
        End Set
    End Property
    'Khai báo thuộc tính nhận Hành động cần thực thi
    Public WriteOnly Property Action() As String
        Set(ByVal value As String)
            shortAction = value
        End Set
    End Property
    'Khai báo thuộc tính nhận Mã hồ sơ cấp GCN
    Public WriteOnly Property MaHoSoCapGCN() As String
        Set(ByVal value As String)
            strMaHoSoCapGCN = value
        End Set
    End Property

    ''' <summary>
    ''' Hiển thị thông tin Phê duyệt
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ShowData()
        'Khai báo và khởi tạo lớp Phê duyệt
        Dim PheDuyet As New clsPheDuyet
        Try
            'Gán giá trị cho các thuộc tính đối với trường hợp truy vấn
            With PheDuyet
                'Nhận chuỗi kết nối Database
                .Connection = strConnection
                .MaHoSoCapGCN = strMaHoSoCapGCN
            End With
            'Khởi tạo Mã hồ sơ Phê duyệt
            strMaHoSoPheDuyet = ""
            'Khởi tạo trạng thái ban đầu
            TrangThaiBanDau()
            'Gọi phương thức truy vấn cơ sở dữ liệu
            If PheDuyet.GetData(dtPheDuyet) = "" Then
                ' Trinh bay du lieu len grdvwTaiSan
                If dtPheDuyet.Rows.Count > 0 Then
                    For i As Integer = 0 To dtPheDuyet.Rows.Count - 1
                        'Gán giá trị cho biến Mã hồ sơ phê duyệt
                        strMaHoSoPheDuyet = dtPheDuyet.Rows(i).Item("MaHoSoPheDuyet").ToString
                        Me.txtTenCanBoPheDuyet.Text = dtPheDuyet.Rows(i).Item("HoTenCanBoPheDuyet").ToString
                        'Hiển thị trạng thái Phê duyệt
                        Me.cmbKetQuaPheDuyet.Text = dtPheDuyet.Rows(i).Item("TrangThaiPheDuyet").ToString
                        If dtPheDuyet.Rows(i).Item("NgayPheDuyet").ToString = "" Then
                            Me.DTPNgayPheDuyet.Value = Date.Now.Date
                            Me.DTPNgayPheDuyet.Checked = False
                        Else
                            Me.DTPNgayPheDuyet.Value = Convert.ToDateTime(dtPheDuyet.Rows(i).Item("NgayPheDuyet").ToString)
                            Me.DTPNgayPheDuyet.Checked = True
                        End If
                        Me.txtYKienPheDuyet.Text = dtPheDuyet.Rows(i).Item("YKienPheDuyet").ToString
                    Next i
                End If
            End If
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Hiển thị dữ liệu phê duyệt " & vbNewLine & " Lỗi: " & vbNewLine & ex.Message, MsgBoxStyle.Information, "DMCLand")
        End Try
        'Thiết lập chế độ mặc định trạng thái chức năng
        Me.TrangThaiChucNang()
        'Thiết lập chế độ mặc định trạng thái cập nhật
        Me.TrangThaiCapNhat()
    End Sub
    Public Sub NhatKyNguoiDung(ByVal ChucNang As String, ByVal MoTa As String)
        Dim clsNhatky As New prjNhatKyNguoiDung.clsNhatKyNguoiDung
        clsNhatky.Connection = strConnection
        clsNhatky.MaHoSoCapGCN = strMaHoSoCapGCN
        clsNhatky.MaDonViHanhChinh = strMaDonViHanhChinh
        clsNhatky.NghiepVu = "Cập nhật thông tin phê duyệt"
        clsNhatky.ChucNang = ChucNang
        clsNhatky.MoTa = MoTa
        clsNhatky.DuongDanFile = Application.StartupPath
        clsNhatky.LuuNhatKyNguoiDung()
    End Sub
    Public Sub UpdateData()
        'Khai báo và khởi tạo lớp thông tin Phê duyệt
        Dim PheDuyet As New clsPheDuyet
        Try
            With PheDuyet
                'Nhận chuỗi kết nối Database
                .Connection = strConnection
                .Flag = strFlag
                .MaHoSoPheDuyet = strMaHoSoPheDuyet
                'Xác nhận Mã hồ sơ cấp GCN
                .MaHoSoCapGCN = strMaHoSoCapGCN
                .HoTenCanBoPheDuyet = Me.txtTenCanBoPheDuyet.Text.Trim
                .KetQuaPheDuyet = Me.cmbKetQuaPheDuyet.FindString(Me.cmbKetQuaPheDuyet.Text.Trim)
                If (Me.DTPNgayPheDuyet.Checked = True) Then
                    .NgayPheDuyet = Me.DTPNgayPheDuyet.Text
                Else
                    .NgayPheDuyet = Nothing
                End If
                .LyDo = txtLyDoKhongCap.Text.Trim
                .YKienPheDuyet = Me.txtYKienPheDuyet.Text.Trim
                Dim str As String = ""
                If shortAction = 1 Then
                    PheDuyet.InsertThongTinPheDuyetByMaHoSoCapGCN()
                    NhatKyNguoiDung("Thêm", txtTenCanBoPheDuyet.Text.Trim & " _ " & cmbKetQuaPheDuyet.FindString(Me.cmbKetQuaPheDuyet.Text.Trim) & " - " & DTPNgayPheDuyet.Text)
                    'If cmbKetQuaPheDuyet.Text = "Chưa phê duyệt" Then
                    '    strFlag = "4"
                    '    PheDuyet.UpdateTrangThaiHS()
                    'Else
                    If cmbKetQuaPheDuyet.Text = "Đồng ý" Then
                        '.Flag = "5"
                        'PheDuyet.UpdateTrangThaiHS()
                        'ElseIf cmbKetQuaPheDuyet.Text = "Chưa đủ điều kiện" Then
                        '    strFlag = "4"
                        '    PheDuyet.UpdateTrangThaiHS()
                        'ElseIf cmbKetQuaPheDuyet.Text = "Không đủ điều kiện" Then
                        '    strFlag = "4"
                        '    PheDuyet.UpdateTrangThaiHS()
                    Else
                        .Flag = "51"
                        PheDuyet.UpdateTrangThaiHS()
                    End If
                ElseIf (shortAction = 2) Then
                    PheDuyet.UpdateThongTinPheDuyetByMaHoSoCapGCN()
                    NhatKyNguoiDung("Sửa", txtTenCanBoPheDuyet.Text.Trim & " _ " & cmbKetQuaPheDuyet.FindString(Me.cmbKetQuaPheDuyet.Text.Trim) & " - " & DTPNgayPheDuyet.Text)
                    'If cmbKetQuaPheDuyet.Text = "Chưa phê duyệt" Then
                    '    strFlag = "4"
                    '    PheDuyet.UpdateTrangThaiHS()
                    'Else
                    If cmbKetQuaPheDuyet.Text = "Không đồng ý" Then
                        .Flag = "51"
                        PheDuyet.UpdateTrangThaiHS()
                        'ElseIf cmbKetQuaPheDuyet.Text = "Chưa đủ điều kiện" Then
                        '    strFlag = "4"
                        '    PheDuyet.UpdateTrangThaiHS()
                        'ElseIf cmbKetQuaPheDuyet.Text = "Không đủ điều kiện" Then
                        '    strFlag = "4"
                        '    PheDuyet.UpdateTrangThaiHS()
                    End If
                End If
                shortAction = 0
                strError = .Err
                CtrTrangThaiHoSo1.ShowTrangThai()
            End With
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Cập nhật thông tin Phê duyệt " & vbNewLine & " Lỗi: " & vbNewLine & strError, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub

    ''' <summary>
    ''' Phương thức thiết lập trạng thái cập nhật/không cập nhật cho các điều khiển
    ''' </summary>
    ''' <param name="blnCapNhat">Trạng thái cập nhật/không cập nhật</param>
    ''' <remarks></remarks>
    Public Sub TrangThaiCapNhat(Optional ByVal blnCapNhat As Boolean = False)
        With Me
            .txtTenCanBoPheDuyet.ReadOnly = Not blnCapNhat
            .txtYKienPheDuyet.ReadOnly = Not blnCapNhat
            .DTPNgayPheDuyet.Enabled = blnCapNhat
            .cmbKetQuaPheDuyet.Enabled = blnCapNhat
            .txtLyDoKhongCap.ReadOnly = Not blnCapNhat
            If blnCapNhat Then
                .txtTenCanBoPheDuyet.BackColor = Color.White
                .txtYKienPheDuyet.BackColor = Color.White
                .cmbKetQuaPheDuyet.BackColor = Color.White
                .txtLyDoKhongCap.BackColor = Color.White
            Else
                .txtTenCanBoPheDuyet.BackColor = Color.LightYellow
                .txtYKienPheDuyet.BackColor = Color.LightYellow
                .cmbKetQuaPheDuyet.BackColor = Color.LightYellow
                .txtLyDoKhongCap.BackColor = Color.LightYellow
            End If
        End With
    End Sub

    ''' <summary>
    ''' Thiết lập trạng thái ban đầu cho các điều khiển
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub TrangThaiBanDau()
        Dim PheDuyet As New clsPheDuyet
        Dim dtTrangThaiPheDuyet As New DataTable
        With Me
            'Hiển thị từ điển trạng thái Phê duyệt lên Form
            If (strConnection <> "") Then
                PheDuyet.Connection = strConnection
                PheDuyet.SelectTuDienTrangThaiPheDuyet(dtTrangThaiPheDuyet)
                If (dtTrangThaiPheDuyet.Rows.Count > 0) Then
                    .cmbKetQuaPheDuyet.DataSource = dtTrangThaiPheDuyet
                    .cmbKetQuaPheDuyet.DisplayMember = dtTrangThaiPheDuyet.Columns(0).ColumnName
                End If
            End If
            dtPheDuyet.Clear()
            .txtTenCanBoPheDuyet.Text = ""
            .txtYKienPheDuyet.Text = ""
            .txtLyDoKhongCap.Text = ""
            .DTPNgayPheDuyet.Value = Date.Now
            .DTPNgayPheDuyet.Checked = False
            .cmbKetQuaPheDuyet.Enabled = False
        End With
    End Sub

    ''' <summary>
    ''' Thiết lập trạng thái chức năng cho các Nút chức năng
    ''' </summary>
    ''' <param name="blnStartEdited"></param>
    ''' <param name="blnStartDeleted"></param>
    ''' <remarks></remarks>
    Public Sub TrangThaiChucNang(Optional ByVal blnStartEdited As Boolean = False, Optional ByVal blnStartDeleted As Boolean = False)
        With Me
            If Me.MaLoaiBienDong <> "MG" Then
                Me.GroupBox1.Enabled = True
                .btnThem.Enabled = Not blnStartDeleted
                .btnSua.Enabled = Not blnStartEdited
                .btnXoa.Enabled = Not blnStartEdited
                .btnCapNhat.Enabled = blnStartEdited
                .btnHuyLenh.Enabled = blnStartEdited
                .btnTraCuu.Enabled = blnStartEdited
                If blnStartDeleted Then
                    .btnCapNhat.Enabled = Not blnStartDeleted
                    .btnHuyLenh.Enabled = Not blnStartDeleted
                    .btnTraCuu.Enabled = Not blnStartDeleted
                End If
            Else
                Me.GroupBox1.Enabled = False
            End If
          
        End With
    End Sub

    Private Sub btnSua_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSua.Click
        'Chắc chắn rằng tồn tại thông tin Phê duyệt cần sửa
        If (strMaHoSoPheDuyet = "") Then
            System.Windows.Forms.MessageBox.Show("CHƯA có thông tin Phê duyệt nào được chọn để sửa", "DMCLand")
            Return
        End If
        shortAction = 2
        With Me
            'Trạng thái chức năng
            .TrangThaiChucNang(True)
            'Trạng thái cập nhật
            .TrangThaiCapNhat(True)
        End With
    End Sub

    Private Sub btnXoa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXoa.Click
        If strMaHoSoCapGCN <> "" Then
            If MsgBox("Bạn chắc chắn muốn xóa không?", MsgBoxStyle.YesNo, "DMCLand!") = MsgBoxResult.Yes Then
                With Me
                    Dim PheDuyet As New clsPheDuyet
                    PheDuyet.Connection = strConnection
                    PheDuyet.MaHoSoCapGCN = strMaHoSoCapGCN
                    PheDuyet.DeleteThongTinPheDuyetByMaHoSoCapGCN()
                    NhatKyNguoiDung("Xóa", txtTenCanBoPheDuyet.Text.Trim & " _ " & cmbKetQuaPheDuyet.FindString(Me.cmbKetQuaPheDuyet.Text.Trim) & " - " & DTPNgayPheDuyet.Text)
                    'Trạng thái ban đầu
                    .TrangThaiBanDau()
                End With
                If (strError = "") Then
                    MsgBox(" Bạn đã cập nhật thành công!", MsgBoxStyle.Information, "DMCLand")
                Else
                    MsgBox(" Cập nhật chưa thành công!", MsgBoxStyle.Critical, "DMCLand")
                End If
            End If
        End If
        'Hiển thị thông tin
        Me.ShowData()
        strMaHoSoPheDuyet = ""
        strError = ""
    End Sub

    Private Sub btnCapNhat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCapNhat.Click
        Try
            'Cập nhật thông tin Phê duyệt
            Me.UpdateData()
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Cập nhật phê duyệt " & vbNewLine & " Lỗi: " & vbNewLine & ex.Message, MsgBoxStyle.Information, "DMCLand")
        End Try
        'Thiết lập trạng thái chức năng
        Me.TrangThaiChucNang()
        'Thiết lập trạng thái cập nhật
        Me.TrangThaiCapNhat()
        'Hiển thị thông tin
        Me.ShowData()
        If (strError = "") Then
            MsgBox(" Bạn đã cập nhật thành công!", MsgBoxStyle.Information, "DMCLand")
        Else
            MsgBox(" Cập nhật chưa thành công!", MsgBoxStyle.Critical, "DMCLand")
        End If
        strError = ""
    End Sub

    Private Sub ctrlPheDuyet_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        With Me
            With .DTPNgayPheDuyet
                .CustomFormat = "dd/MM/yyyy"
                .Format = DateTimePickerFormat.Custom
                .ShowCheckBox = True
            End With
            'Thiêt lập trạng thái cập nhật
            .TrangThaiCapNhat()
            'Thiết lập trạng thái chức năng
            .TrangThaiChucNang(True, True)
        End With
    End Sub

    Private Sub btnHuyLenh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHuyLenh.Click
        With Me
            'Xóa dữ liêu trên Form
            .TrangThaiBanDau()
            'Hiển thị dữ liệu
            .ShowData()
        End With
        shortAction = 0
    End Sub

    Private Sub txtTenCanBoPheDuyet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub btnThem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThem.Click
        If ((strMaHoSoPheDuyet = Nothing) Or (strMaHoSoPheDuyet = "")) Then
            shortAction = 1
            ' Thiết lập trạng thái ban đầu 
            Me.TrangThaiBanDau()
            ' Thiết lập trạng thái cập nhật cho các điều khiển 
            Me.TrangThaiCapNhat(True)
            ' Trạng thái chức năng 
            Me.TrangThaiChucNang(True, False)
        End If
    End Sub

    Private Sub btnTraCuu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTraCuu.Click
        If txtTenCanBoPheDuyet.ReadOnly = False Then
            Try
                With Me
                    Dim frm As New frmTuDienCanBoPheDuyet
                    With frm
                        With .CtrlTuDienNguoiPheDuyet
                            'Gán chuỗi kết nối cơ sở dữ liệu
                            .Connection = strConnection
                            .Ma = ""
                            .showData()
                        End With
                        .StartPosition = FormStartPosition.CenterScreen
                        .ShowDialog()
                        With .CtrlTuDienNguoiPheDuyet
                            If .Ma <> "" Then
                                'Hiển thị tên cán bộ thẩm định
                                If (.dtTuDienSelect.Rows.Count > 0) Then
                                    txtTenCanBoPheDuyet.Text = .dtTuDienSelect.Rows(0).Item("HoTen").ToString()
                                End If
                                .Ma = ""
                            End If
                        End With
                    End With
                End With
            Catch ex As Exception
                strError = ex.Message
                MsgBox(" Thông tin PHÊ DUYỆT " & vbNewLine & "TỪ ĐIỂN CÁN BỘ PHÊ DUYỆT" & vbNewLine & " Lỗi: " & vbNewLine & ex.Message, MsgBoxStyle.Information, "DMCLand")
            End Try
        End If
    End Sub

    Private Sub txtTenCanBoPheDuyet_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTenCanBoPheDuyet.KeyDown
        If (e.KeyValue = 13) Then
            txtYKienPheDuyet.Focus()
        End If
    End Sub

    Private Sub txtYKienPheDuyet_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtYKienPheDuyet.KeyDown
        If (e.KeyValue = 13) Then
            cmbKetQuaPheDuyet.Focus()
        End If
    End Sub

    Private Sub cmbKetQuaPheDuyet_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbKetQuaPheDuyet.KeyDown
        If (e.KeyValue = 13) Then
            txtLyDoKhongCap.Focus()
        End If
    End Sub

    Private Sub txtLyDoKhongCap_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtLyDoKhongCap.KeyDown
        If (e.KeyValue = 13) Then
            btnCapNhat.Focus()
        End If
    End Sub
End Class
