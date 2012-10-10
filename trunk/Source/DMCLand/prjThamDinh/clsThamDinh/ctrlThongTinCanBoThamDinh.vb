Imports System.Drawing
Imports System.Windows.Forms

Public Class ctrlThongTinCanBoThamDinh
    '' Định nghĩa trạng thái Phê duyệt Hồ sơ có giá trị bằng 5
    'ReadOnly TRANG_THAI_PHE_DUYET As Integer = 5
    Private strConnection As String = "" 'Khai báo biến nhận chuỗi kết nối Database
    Private strError As String = "" 'Khai bao bien kiem tra loi
    ''Khai báo biến trạng thái Hồ sơ cấp GCN
    'Private longTrangThaiHoSoCapGCN As Integer = 0
    'Khai báo biến Mã hồ sơ cấp GCN
    Private strMaHoSoCapGCN As String = ""
    'Mã Hồ sơ thẩm định
    Private strMaHoSoThamDinh As String

    Private shortAction As Short = 0
    Private strThongTinCu As String

    Private strDienTichKeKhai As String = "0"
    Public Property DienTichKeKhai() As String
        Get
            Return strDienTichKeKhai
        End Get
        Set(ByVal value As String)
            strDienTichKeKhai = value
        End Set
    End Property

    Private strMaDonViHanhChinh As String
    Public Property MaDonViHanhChinh() As String
        Get
            Return strMaDonViHanhChinh
        End Get
        Set(ByVal value As String)
            strMaDonViHanhChinh = value
        End Set
    End Property
    ' khai bao flag
    Private strFlag As String = ""
    ' Khai bao thuoc tinh ung voi Flag 
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
    ''Khai báo thuộc tính chỉ đọc Trạng thái Hồ sơ cấp GCN
    'Public ReadOnly Property TrangThaiHoSoCapGCN() As Long
    '    Get
    '        Return longTrangThaiHoSoCapGCN
    '    End Get
    'End Property
    Public WriteOnly Property MaHoSoCapGCN() As String
        Set(ByVal value As String)
            strMaHoSoCapGCN = value
        End Set
    End Property
    Public Sub NhatKyNguoiDung(ByVal ChucNang As String, ByVal MoTa As String)
        Dim clsNhatky As New prjNhatKyNguoiDung.clsNhatKyNguoiDung
        clsNhatky.Connection = strConnection
        clsNhatky.MaHoSoCapGCN = strMaHoSoCapGCN
        clsNhatky.MaDonViHanhChinh = strMaDonViHanhChinh
        clsNhatky.NghiepVu = "Thẩm định"
        clsNhatky.ChucNang = ChucNang
        clsNhatky.MoTa = MoTa
        clsNhatky.DuongDanFile = Application.StartupPath
        clsNhatky.LuuNhatKyNguoiDung()
    End Sub
    Private Sub HideAllColumns(ByRef grdvw As DataGridView)
        'Ẩn tất cả các cột trên Grid
        With grdvw
            For i As Integer = 0 To (.Columns.Count - 1)
                .Columns(i).Visible = False
            Next
            .RowHeadersVisible = False
        End With
    End Sub
    ''' <summary>
    ''' Định dạng lại cấu trúc Grid
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub FormatGridContruction(ByRef grdvw As DataGridView)
        Try
            'Ẩn tất cả các cột
            Me.HideAllColumns(grdvw)
            With grdvw
                '              MaHoSoThamDinh, MaHoSoCapGCN, DonViThamDinh, HoTenCanBoThamDinhDKND, YKienThamDinhDKND
                ',KetQuaThamDinhDKND,NgayThamDinhDKND,HoTenCanBoThamDinhTNMT,YKienThamDinhTNMT
                ',KetQuaThamDinhTNMT,NgayThamDinhTNMT,LyDoKhongCap,TuDien.MoTa AS TrangThaiThamDinh,GhiChu
                '	,DienTichCapDatO
                '	,DienTIchCapDatVuon
                '	,DienTichKhongCap
                '	,YKienKhac,DienTich,DienTichBangChu,DienTichChung,DienTichRieng
                With .Columns("DonViThamDinh")
                    .HeaderText = "Đơn vị thẩm định"
                    .Width = 200
                    .Visible = True
                End With
                With .Columns("HoTenCanBoThamDinhDKND")
                    .HeaderText = "CB thẩm định"
                    .Width = 200
                    .Visible = True
                End With
                With .Columns("TrangThaiThamDinh")
                    .HeaderText = "Kết quả thẩm định"
                    .Width = 200
                    .Visible = True
                End With

                With .Columns("YKienThamDinhDKND")
                    .HeaderText = "YK thẩm định"
                    .Width = 200
                    .Visible = True
                End With
            
                With .Columns("NgayThamDinhDKND")
                    .HeaderText = "Ngày thẩm định"
                    .Width = 150
                    .Visible = True
                End With
                With .Columns("DienTich")
                    .HeaderText = "Diện tích"
                    .Width = 150
                    .Visible = True
                End With
                With .Columns("DienTichBangChu")
                    .HeaderText = "DT bằng chữ"
                    .Width = 300
                    .Visible = True
                End With
                With .Columns("DienTichChung")
                    .HeaderText = "DT chung"
                    .Width = 150
                    .Visible = True
                End With
                With .Columns("DienTichRieng")
                    .HeaderText = "DT riêng"
                    .Width = 150
                    .Visible = True
                End With
                With .Columns("DienTichCapDatO")
                    .HeaderText = "DT đất ở"
                    .Width = 150
                    .Visible = True
                End With
                With .Columns("DienTIchCapDatVuon")
                    .HeaderText = "DT đất vườn"
                    .Width = 200
                    .Visible = True
                End With
                With .Columns("DienTichKhongCap")
                    .HeaderText = "DT không cấp"
                    .Width = 150
                    .Visible = True
                End With
                With .Columns("LyDoKhongCap")
                    .HeaderText = "Lý do không cấp"
                    .Width = 200
                    .Visible = True
                End With
                With .Columns("GhiChu")
                    .HeaderText = "Ghi chú"
                    .Width = 300
                    .Visible = True
                End With
                .BackgroundColor = Color.WhiteSmoke
                .GridColor = Color.WhiteSmoke
                .RowHeadersVisible = False
                .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                'Khong cho phep them
                .AllowUserToAddRows = False
                'Khong cho phep xoa
                .AllowUserToDeleteRows = False
                'Khong lua chon bat ky dong nao luc ban dau
                .ClearSelection()
            End With
        Catch ex As Exception
            'strError = ex.Message
            MsgBox(" Tài liệu kèm theo " & vbNewLine & _
                   "Lỗi: " & vbNewLine & ex.Message, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub
    ''' <summary>
    ''' Hiển thị thông tin cán bộ thẩm định
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ShowData()
        'Khai báo và khởi tạo lớp thông tin Cán bộ thẩm định
        Dim CanBoThamDinh As New clsThongTinCanBoThamDinh
        Try
            'Gán giá trị cho các thuộc tính đối với trường hợp truy vấn
            With CanBoThamDinh
                'Nhận chuỗi kết nối Database
                .Connection = strConnection
                .MaHoSoCapGCN = strMaHoSoCapGCN
            End With
            'Khởi tạo Mã hồ sơ thẩm định
            strMaHoSoThamDinh = ""
            'Khởi tạo trạng thái ban đầu
            TrangThaiBanDau()

            'Hiển thị từ điển trạng thái Thẩm định lên Form 
            Dim dtTrangThaiThamDinh As New DataTable
            CanBoThamDinh.SelectTuDienTrangThaiThamDinh("1", dtTrangThaiThamDinh)
            If (dtTrangThaiThamDinh.Rows.Count > 0) Then
                cmbKetQuaDKND.DataSource = dtTrangThaiThamDinh
                cmbKetQuaDKND.DisplayMember = "mota"
                cmbKetQuaDKND.ValueMember = "KyHieu"
            End If
            dtTrangThaiThamDinh = New DataTable
            CanBoThamDinh.SelectTuDienTrangThaiThamDinh("2", dtTrangThaiThamDinh)
            If (dtTrangThaiThamDinh.Rows.Count > 0) Then
                cmbKetQuaTNMT.DataSource = dtTrangThaiThamDinh
                cmbKetQuaTNMT.DisplayMember = "mota"
                cmbKetQuaTNMT.ValueMember = "KyHieu"
            End If 

            'Gọi phương thức truy vấn cơ sở dữ liệu
            Dim dtCanBoThamDinh As New DataTable
            If CanBoThamDinh.SelectThongTinCanBoThamDinhByMaHoSoCapGCN(dtCanBoThamDinh) = "" Then
                grdvwDonViThamDinh.DataSource = dtCanBoThamDinh
                If (grdvwDonViThamDinh.Rows.Count > 0) Then
                    'Định dạng lại cột trên Grid
                    Me.FormatGridContruction(grdvwDonViThamDinh)
                Else
                    Me.HideAllColumns(grdvwDonViThamDinh)
                End If

                'Trình bày dữ liệu lên Form
                'If dtCanBoThamDinh.Rows.Count > 0 Then
                '    For i As Integer = 0 To dtCanBoThamDinh.Rows.Count - 1
                '        'Nhận giá trị cho Mã hồ sơ thẩm đinh
                '        strMaHoSoThamDinh = dtCanBoThamDinh.Rows(i).Item("MaHoSoThamDinh").ToString

                '        ''Trạng thái Hồ sơ cấp GCN TrangThaiHoSoCapGCN
                '        'If IsNumeric(dtCanBoThamDinh.Rows(i).Item("TrangThaiHoSoCapGCN").ToString) Then
                '        '    Me.longTrangThaiHoSoCapGCN = Convert.ToInt16(dtPheDuyet.Rows(i).Item("TrangThaiHoSoCapGCN").ToString)
                '        'Else
                '        '    Me.longTrangThaiHoSoCapGCN = 0
                '        'End If
                '        Me.txtDonViThamDinh.Text = dtCanBoThamDinh.Rows(i).Item("DonViThamDinh").ToString
                '        Me.txtHoTenCanBoDKND.Text = dtCanBoThamDinh.Rows(i).Item("HoTenCanBoThamDinhDKND").ToString
                '        Me.txtYKienDKND.Text = dtCanBoThamDinh.Rows(i).Item("YKienThamDinhDKND").ToString
                '        Me.txtHoTenCanBoTNMT.Text = dtCanBoThamDinh.Rows(i).Item("HoTenCanBoThamDinhTNMT").ToString
                '        Me.txtYKienTNMT.Text = dtCanBoThamDinh.Rows(i).Item("YKienThamDinhTNMT").ToString
                '        'Thông tin Kết quả thẩm định
                '        Me.cmbKetQuaDKND.Text = dtCanBoThamDinh.Rows(i).Item("TrangThaiThamDinh").ToString
                '        'Me.cmbKetQuaDKND.Text = dtCanBoThamDinh.Rows(i).Item("TrangThaiThamDinh").ToString
                '        If IsDBNull(dtCanBoThamDinh.Rows(i).Item("KetQuaThamDinhTNMT")) Then
                '            Me.cmbKetQuaTNMT.Text = ""
                '        Else
                '            Me.cmbKetQuaTNMT.SelectedValue = dtCanBoThamDinh.Rows(i).Item("KetQuaThamDinhTNMT").ToString
                '        End If

                '        Me.GhiChuThamDinh.Text = dtCanBoThamDinh.Rows(i).Item("GhiChu").ToString
                '        If Not IsDBNull(dtCanBoThamDinh.Rows(i).Item("DienTichCapDato")) Then
                '            Me.NumCapDatO.Value = dtCanBoThamDinh.Rows(i).Item("DienTichCapDato").ToString
                '        End If
                '        If Not IsDBNull(dtCanBoThamDinh.Rows(i).Item("DienTichCapDatVuon")) Then
                '            Me.NumCapDatVuon.Value = dtCanBoThamDinh.Rows(i).Item("DienTichCapDatVuon").ToString
                '        End If
                '        If Not IsDBNull(dtCanBoThamDinh.Rows(i).Item("DienTichKhongCap")) Then
                '            Me.NumDatKhongCap.Value = dtCanBoThamDinh.Rows(i).Item("DienTichKhongCap").ToString
                '        End If
                '        'Thông tin Kết quả thẩm định
                '        Me.YKienKhac.Text = dtCanBoThamDinh.Rows(i).Item("YKienKhac").ToString

                '        If Not IsDBNull(dtCanBoThamDinh.Rows(i).Item("DienTich")) Then
                '            Me.numDienTich.Value = dtCanBoThamDinh.Rows(i).Item("DienTich").ToString
                '        End If
                '        If Not IsDBNull(dtCanBoThamDinh.Rows(i).Item("DienTichBangChu")) Then
                '            Me.txtDienTichBangChu.Text = dtCanBoThamDinh.Rows(i).Item("DienTichBangChu").ToString
                '        End If
                '        If Not IsDBNull(dtCanBoThamDinh.Rows(i).Item("DienTichRieng")) Then
                '            Me.numDienTichRieng.Value = dtCanBoThamDinh.Rows(i).Item("DienTichRieng").ToString
                '        End If
                '        If Not IsDBNull(dtCanBoThamDinh.Rows(i).Item("DienTichChung")) Then
                '            Me.numDienTichChung.Value = dtCanBoThamDinh.Rows(i).Item("DienTichChung").ToString
                '        End If

                '        If Not IsDate(dtCanBoThamDinh.Rows(i).Item("NgayThamDinhDKND").ToString) Then
                '            Me.DTPNgayThamDinhDKND.Value = Date.Now.Date
                '            Me.DTPNgayThamDinhDKND.Checked = False
                '        Else
                '            Me.DTPNgayThamDinhDKND.Value = Convert.ToDateTime(dtCanBoThamDinh.Rows(i).Item("NgayThamDinhDKND").ToString)
                '            Me.DTPNgayThamDinhDKND.Checked = True
                '        End If
                '        If Not IsDate(dtCanBoThamDinh.Rows(i).Item("NgayThamDinhTNMT").ToString) Then
                '            Me.DTPNgayThamDinhTNMT.Value = Date.Now.Date
                '            Me.DTPNgayThamDinhTNMT.Checked = False
                '        Else
                '            Me.DTPNgayThamDinhTNMT.Value = Convert.ToDateTime(dtCanBoThamDinh.Rows(i).Item("NgayThamDinhTNMT").ToString)
                '            Me.DTPNgayThamDinhTNMT.Checked = True
                '        End If
                '        Me.txtLyDoKhongCap.Text = dtCanBoThamDinh.Rows(i).Item("LyDoKhongCap").ToString
                '    Next i
                'End If
            End If
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Hiển thị thông tin Cán bộ Thẩm định " & vbNewLine & " Lỗi: " & vbNewLine & ex.Message, MsgBoxStyle.Information, "DMCLand")
        End Try
        'Trạng thái chức năng
        Me.TrangThaiChucNang()
        'Trạng thái cập nhật
        Me.TrangThaiCapNhat()
    End Sub

    Public Sub UpdateData()
        'Khai báo và khởi tạo lớp thông tin Cán bộ Thẩm định
        Dim CanBoThamDinh As New clsThongTinCanBoThamDinh
        Try
            'Xác nhận giá trị cần cập nhật
            With CanBoThamDinh
                'Nhận chuỗi kết nối Database
                .Connection = strConnection

                '' Kiểm tra trạng thái Hồ sơ trước khi cập nhật:
                '' Nếu giá trị trạng thái Hồ sơ hiện thời nhỏ hơn
                '' giá trị trạng thái Phê duyệt thì ta lấy là giá trị 
                '' trạng thái Phê duyệt Hồ sơ, ngược lại giữ nguyên giá trị 
                'If (longTrangThaiHoSoCapGCN < TRANG_THAI_PHE_DUYET) Then
                '    PheDuyet.TrangThaiHoSoCapGCN = TRANG_THAI_PHE_DUYET
                'Else
                '    PheDuyet.TrangThaiHoSoCapGCN = longTrangThaiHoSoCapGCN
                'End If
                .MaHoSoThamDinh = strMaHoSoThamDinh
                .MaHoSoCapGCN = strMaHoSoCapGCN
                .MaDonViHanhChinh = strMaDonViHanhChinh
                .Flag = strFlag
                .DonViThamDinh = txtDonViThamDinh.Text.Trim
                .HoTenCanBoThamDinhDKND = Me.txtHoTenCanBoDKND.Text.Trim
                .YKienThamDinhDKND = Me.txtYKienDKND.Text.Trim
                'Kết quả tiến trình luôn chuyển hồ sơ (Kết quả Thẩm định)
                '.KetQuaThamDinhDKND = Me.cmbKetQuaDKND.FindString(Me.cmbKetQuaDKND.Text.Trim)
                .KetQuaThamDinhDKND = Me.cmbKetQuaDKND.SelectedValue
                .HoTenCanBoThamDinhTNMT = Me.txtHoTenCanBoTNMT.Text.Trim
                .YKienThamDinhTNMT = Me.txtYKienTNMT.Text.Trim
                'Kết quả tiến trình luôn chuyển hồ sơ (Kết quả Thẩm định)
                '.KetQuaThamDinhTNMT = Me.cmbKetQuaTNMT.FindString(Me.cmbKetQuaTNMT.Text.Trim)
                .KetQuaThamDinhTNMT = Me.cmbKetQuaTNMT.SelectedValue

                If IsNumeric(numDienTich.Value.ToString) Then
                    .DienTich = numDienTich.Value.ToString
                Else
                    .DienTich = Nothing
                End If
                .DienTichBangChu = txtDienTichBangChu.Text.Trim
                If IsNumeric(numDienTichRieng.Value.ToString) Then
                    .DienTichRieng = numDienTichRieng.Value.ToString
                Else
                    .DienTichRieng = Nothing
                End If
                If IsNumeric(numDienTichChung.Value.ToString) Then
                    .DienTichChung = numDienTichChung.Value.ToString
                Else
                    .DienTichChung = Nothing
                End If

                If IsNumeric(NumCapDatO.Value.ToString) Then
                    .DienTichDatO = NumCapDatO.Value.ToString
                Else
                    .DienTichDatO = Nothing
                End If
                If IsNumeric(NumCapDatVuon.Value.ToString) Then
                    .DienTichDatVuon = NumCapDatVuon.Value.ToString
                Else
                    .DienTichDatVuon = Nothing
                End If
                If IsNumeric(NumDatKhongCap.Value.ToString) Then
                    .DienTichKhongCap = NumDatKhongCap.Value.ToString
                Else
                    .DienTichKhongCap = Nothing
                End If
                .YKienKhac = YKienKhac.Text
                .GhiChu = GhiChuThamDinh.Text.Trim
                'Ngày thẩm định
                If Me.DTPNgayThamDinhDKND.Checked Then
                    .NgayThamDinhDKND = Me.DTPNgayThamDinhDKND.Text
                Else
                    .NgayThamDinhDKND = Nothing
                End If
                If Me.DTPNgayThamDinhTNMT.Checked Then
                    .NgayThamDinhTNMT = Me.DTPNgayThamDinhTNMT.Text
                Else
                    .NgayThamDinhTNMT = Nothing
                End If
                ' Lý do không cấp nếu có
                .LyDoKhongCap = Me.txtLyDoKhongCap.Text.Trim
                Dim str As String = ""
                'Trường hợp thêm cán bộ thẩm định
                If shortAction = 1 Then
                    CanBoThamDinh.InsertThongTinCanBoThamDinhByMaHoSoCapGCN()
                    'strThongTinCu = "Tên: " & txtHoTenCanBoDKND.Text & "- Kết quả:" & cmbKetQuaDKND.Text & " - Diện tích: " & numDienTich.Value.ToString & " - Diện tích riêng" & numDienTichRieng.Value.ToString
                    NhatKyNguoiDung("Thêm", "Tên: " & txtHoTenCanBoDKND.Text & "- Kết quả:" & cmbKetQuaDKND.Text & " - Diện tích: " & numDienTich.Value.ToString & " - Diện tích riêng" & numDienTichRieng.Value.ToString)
                    If cmbKetQuaDKND.Text = "Đủ điều kiện" Then
                        '.Flag = "4"
                        'CanBoThamDinh.UpdateThamDinh()
                    ElseIf cmbKetQuaDKND.Text = "Chưa đủ điều kiện" Then
                        .Flag = "42"
                        CanBoThamDinh.UpdateThamDinh()
                    ElseIf cmbKetQuaDKND.Text = "Không đủ điều kiện" Then
                        .Flag = "41"
                        CanBoThamDinh.UpdateThamDinh()
                    Else
                        .Flag = "3"
                        CanBoThamDinh.UpdateThamDinh()
                    End If
                    'Trường hợp sửa thông tin cán bộ thẩm định
                ElseIf shortAction = 2 Then
                    CanBoThamDinh.UpdateThongTinCanBoThamDinhByMaHoSoCapGCN()
                    NhatKyNguoiDung("Sửa", "Thay (" & strThongTinCu & " bằng ( Tên: " & txtHoTenCanBoDKND.Text & "- Kết quả:" & cmbKetQuaDKND.Text & " - Diện tích: " & numDienTich.Value.ToString & " - Diện tích riêng" & numDienTichRieng.Value.ToString & ")")
                    If cmbKetQuaDKND.Text = "Đủ điều kiện" Then
                        .Flag = "4"
                        CanBoThamDinh.UpdateThamDinh()
                    ElseIf cmbKetQuaDKND.Text = "Chưa đủ điều kiện" Then
                        .Flag = "42"
                        CanBoThamDinh.UpdateThamDinh()
                    ElseIf cmbKetQuaDKND.Text = "Không đủ điều kiện" Then
                        .Flag = "41"
                        CanBoThamDinh.UpdateThamDinh()
                    Else
                        .Flag = "3"
                        CanBoThamDinh.UpdateThamDinh()
                    End If
                End If
                shortAction = 0
                strError = .Err

            End With
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Cập nhật thông tin Cán bộ thẩm định " & vbNewLine & " Lỗi: " & vbNewLine & strError, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub

    Public Sub TrangThaiCapNhat(Optional ByVal blnCapNhat As Boolean = False)
        With Me
            With .numDienTich
                .ReadOnly = Not blnCapNhat
                .Enabled = blnCapNhat
            End With
            'Diện tích Riêng
            With .numDienTichRieng
                .ReadOnly = Not blnCapNhat
                .Enabled = blnCapNhat
            End With
            'Diện tích Chung
            With .numDienTichChung
                .ReadOnly = Not blnCapNhat
                .Enabled = blnCapNhat
            End With
            .txtDonViThamDinh.ReadOnly = Not blnCapNhat
            .txtDienTichBangChu.ReadOnly = Not blnCapNhat
            .txtHoTenCanBoDKND.ReadOnly = Not blnCapNhat
            .txtYKienDKND.ReadOnly = Not blnCapNhat 
            .cmbKetQuaDKND.Enabled = blnCapNhat
            .DTPNgayThamDinhDKND.Enabled = blnCapNhat
            .txtHoTenCanBoTNMT.ReadOnly = Not blnCapNhat
            .txtYKienTNMT.ReadOnly = Not blnCapNhat
            .cmbKetQuaTNMT.Enabled = blnCapNhat
            .DTPNgayThamDinhTNMT.Enabled = blnCapNhat

            .txtLyDoKhongCap.ReadOnly = Not blnCapNhat
            .GhiChuThamDinh.ReadOnly = Not blnCapNhat
            NumCapDatO.Enabled = blnCapNhat
            NumCapDatVuon.Enabled = blnCapNhat
            NumDatKhongCap.Enabled = blnCapNhat
            YKienKhac.ReadOnly = Not blnCapNhat
            If blnCapNhat Then
                .txtDonViThamDinh.BackColor = Color.White
                .txtHoTenCanBoDKND.BackColor = Color.White
                .txtYKienDKND.BackColor = Color.White
                txtHoTenCanBoTNMT.BackColor = Color.White
                .txtYKienTNMT.BackColor = Color.White
                .txtLyDoKhongCap.BackColor = Color.White
                .GhiChuThamDinh.BackColor = Color.White
            Else
                .txtDonViThamDinh.BackColor = Color.LightYellow
                .txtHoTenCanBoDKND.BackColor = Color.LightYellow
                .txtYKienDKND.BackColor = Color.LightYellow
                .txtHoTenCanBoTNMT.BackColor = Color.LightYellow
                .txtYKienTNMT.BackColor = Color.LightYellow
                .txtLyDoKhongCap.BackColor = Color.LightYellow
                .GhiChuThamDinh.BackColor = Color.LightYellow
            End If
        End With
    End Sub

    Public Sub TrangThaiBanDau()
        Dim ThongTinCanBoThamDinh As New clsThongTinCanBoThamDinh
        Dim dtTrangThaiThamDinh As New DataTable
        With Me
            If strDienTichKeKhai = "" Then
                DienTichKeKhai = 0
            End If
            ''Hiển thị từ điển trạng thái Thẩm định lên Form
            'If (strConnection <> "") Then
            '    ThongTinCanBoThamDinh.Connection = strConnection
            '    dtTrangThaiThamDinh = New DataTable
            '    ThongTinCanBoThamDinh.SelectTuDienTrangThaiThamDinh("1", dtTrangThaiThamDinh)
            '    If (dtTrangThaiThamDinh.Rows.Count > 0) Then
            '        .cmbKetQuaDKND.DataSource = dtTrangThaiThamDinh
            '        .cmbKetQuaDKND.DisplayMember = "mota"
            '        .cmbKetQuaDKND.ValueMember = "KyHieu"
            '    End If
            '    dtTrangThaiThamDinh = New DataTable
            '    ThongTinCanBoThamDinh.SelectTuDienTrangThaiThamDinh("2", dtTrangThaiThamDinh)
            '    If (dtTrangThaiThamDinh.Rows.Count > 0) Then
            '        .cmbKetQuaTNMT.DataSource = dtTrangThaiThamDinh
            '        .cmbKetQuaTNMT.DisplayMember = "mota"
            '        .cmbKetQuaTNMT.ValueMember = "KyHieu"
            '    End If
            'End If
            'dtCanBoThamDinh.Clear()
            .txtDonViThamDinh.Text = ""
            .numDienTich.Value = strDienTichKeKhai
            .numDienTichRieng.Value = strDienTichKeKhai
            .numDienTichChung.Value = 0
            .txtDienTichBangChu.Text = ""

            .txtHoTenCanBoDKND.Text = ""
            .txtYKienDKND.Text = ""
            .txtHoTenCanBoTNMT.Text = ""
            .txtYKienTNMT.Text = ""
            .txtLyDoKhongCap.Text = ""
            .GhiChuThamDinh.Text = ""
            NumCapDatO.Value = strDienTichKeKhai
            NumCapDatVuon.Value = 0
            NumDatKhongCap.Value = 0
            YKienKhac.Text = ""
            With .DTPNgayThamDinhDKND
                .Checked = False
                .Value = Date.Now.Date
            End With
            With .DTPNgayThamDinhTNMT
                .Checked = False
                .Value = Date.Now.Date
            End With
            .cmbKetQuaDKND.Text = ""
            .cmbKetQuaTNMT.Text = ""
        End With
    End Sub

    Public Sub TrangThaiChucNang(Optional ByVal blnStartEdited As Boolean = False, Optional ByVal blnStartDeleted As Boolean = False)
        With Me
            If Me.MaLoaiBienDong <> "MG" Then
                Me.GroupBox2.Enabled = True
                .btnThem.Enabled = Not blnStartDeleted
                .btnSua.Enabled = Not blnStartEdited
                .btnXoa.Enabled = Not blnStartEdited
                .btnCapNhat.Enabled = blnStartEdited
                .btnTraCuu.Enabled = blnStartEdited
                .btnHuyLenh.Enabled = blnStartEdited
                If blnStartDeleted Then
                    .btnCapNhat.Enabled = Not blnStartDeleted
                    .btnHuyLenh.Enabled = Not blnStartDeleted
                    .btnTraCuu.Enabled = Not blnStartDeleted
                End If
            Else
                Me.GroupBox2.Enabled = False
            End If

        End With
    End Sub


    Private Sub btnSua_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSua.Click
        If strMaHoSoCapGCN <> "" Then
            shortAction = 2
            With Me
                'Trạng thái chức năng
                .TrangThaiChucNang(True)
                'Trạng thái cập nhật
                .TrangThaiCapNhat(True)
                strThongTinCu = "Tên: " & txtHoTenCanBoDKND.Text & "- Kết quả:" & cmbKetQuaDKND.Text & " - Diện tích: " & numDienTich.Value.ToString & " - Diện tích riêng" & numDienTichRieng.Value.ToString
            End With
        Else
            MsgBox(" Chọn đơn vi thẩm định cần sửa!", MsgBoxStyle.Information, "DMCLand")
            Return
        End If
    End Sub

    Private Sub btnXoa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXoa.Click
        If strMaHoSoCapGCN <> "" And strMaHoSoThamDinh <> "" Then
            If MsgBox("Bạn chắc chắn muốn xóa không?", MsgBoxStyle.YesNo, "DMCLand!") = MsgBoxResult.Yes Then
                Dim CanBoThamDinh As New clsThongTinCanBoThamDinh
                With Me
                    'Xác định Hồ sơ cần xóa thông tin Cán bộ Thẩm định
                    CanBoThamDinh.Connection = strConnection
                    CanBoThamDinh.MaHoSoCapGCN = strMaHoSoCapGCN
                    CanBoThamDinh.MaHoSoThamDinh = strMaHoSoThamDinh
                    'Xóa thông tin Cán bộ thẩm định
                    CanBoThamDinh.DeleteThongTinCanBoThamDinhByMaHoSoCapGCN()
                    NhatKyNguoiDung("Xóa", "Tên: " & txtHoTenCanBoDKND.Text & "- Kết quả:" & cmbKetQuaDKND.Text & " - Diện tích: " & numDienTich.Value.ToString & " - Diện tích riêng" & numDienTichRieng.Value.ToString)
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
        'Thiết lập giá trị mặc định cho biến Mã hồ sơ thẩm định về rỗng
        strMaHoSoThamDinh = Nothing
        strError = ""
    End Sub

    Private Sub btnCapNhat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCapNhat.Click
        Try
            'Kiem tra tinh hop le cua thong tin vao
            If Me.cmbKetQuaDKND.Text.Trim = "" Then
                If (System.Windows.Forms.MessageBox.Show("Bạn chưa lựa chọn Kết quả Thẩm định!" & vbNewLine _
                    & "Bạn có muốn lựa chọn không?", "DMCLand", MessageBoxButtons.YesNo) = DialogResult.Yes) Then
                    Me.cmbKetQuaDKND.Focus()
                    Exit Sub
                End If
            End If
       
            'Cập nhật thông tin Cán bộ thẩm định
            Me.UpdateData()
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Cập nhật Thông tin cán bộ thẩm định " & vbNewLine & " Lỗi: " & vbNewLine & ex.Message, MsgBoxStyle.Information, "DMCLand")
        End Try
        Me.ShowData()
        If (strError = "") Then
            MsgBox(" Bạn đã cập nhật thành công!", MsgBoxStyle.Information, "DMCLand")
        Else
            MsgBox(" Cập nhật chưa thành công!", MsgBoxStyle.Critical, "DMCLand")
        End If
        strError = ""
    End Sub

    Private Sub ctrlThongTinCanBoThamDinh_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        With Me
            With .DTPNgayThamDinhDKND
                .CustomFormat = "dd/MM/yyyy"
                .Format = DateTimePickerFormat.Custom
                .ShowCheckBox = True
            End With
            With .DTPNgayThamDinhTNMT
                .CustomFormat = "dd/MM/yyyy"
                .Format = DateTimePickerFormat.Custom
                .ShowCheckBox = True
            End With
            'Trạng thái cập nhật
            .TrangThaiCapNhat()
            'Trạng thái chức năng
            .TrangThaiChucNang(True, True)
        End With
    End Sub

    Private Sub btnHuyLenh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHuyLenh.Click
        With Me
            'Xóa dữ liệu trên Form
            .TrangThaiBanDau()
            'Hiển thị dữ liệu
            If strMaHoSoCapGCN <> "" Then
                .ShowData()
            End If
        End With
        shortAction = 0
    End Sub

    Private Sub txtHoTenCanBoThamDinh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub btnThem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnThem.Click
        'If ((strMaHoSoThamDinh = Nothing) Or (strMaHoSoThamDinh = "")) Then
        shortAction = 1
        ' Thiết lập trạng thái ban đầu 
        Me.TrangThaiBanDau()
        ' Thiết lập trạng thái cập nhật cho các điều khiển 
        Me.TrangThaiCapNhat(True)
        ' Trạng thái chức năng 
        Me.TrangThaiChucNang(True, False)
        ' End If
    End Sub

    Private Sub btnTraCuu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTraCuu.Click
        If txtHoTenCanBoDKND.ReadOnly = False Then
            Try
                With Me
                    Dim frm As New frmTuDienCanBoThamDinh
                    With frm
                        With .CtrlTuDienNguoiThamDinh
                            'Gán chuỗi kết nối cơ sở dữ liệu
                            .Connection = strConnection
                            .Ma = ""
                            .showData()
                        End With
                        .StartPosition = FormStartPosition.CenterScreen
                        .ShowDialog()
                        With .CtrlTuDienNguoiThamDinh
                            If .Ma <> "" Then
                                If .dtTuDienSelect.Rows.Count < 1 Then
                                    Return
                                End If
                                'Hiển thị tên cán bộ thẩm định
                                txtHoTenCanBoDKND.Text = .dtTuDienSelect.Rows(0).Item("HoTen").ToString()
                                .Ma = ""
                            End If
                        End With
                    End With
                End With
            Catch ex As Exception
                strError = ex.Message
                MsgBox(" Thông tin cán bộ Thẩm định " & vbNewLine & "TỪ ĐIỂN cán bộ thẩm định" & vbNewLine & " Lỗi: " & vbNewLine & ex.Message, MsgBoxStyle.Information, "DMCLand")
            End Try
        End If
    End Sub

    Private Sub btnDienTichBangChu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDienTichBangChu.Click
        Dim DoiSoThanhChu As New clsDoiSoThanhChu
        Dim strDienTich As String = ""
        strDienTich = String.Format("{0:0.00}", numDienTich.Value)
        If (strDienTich = "") Then
            txtDienTichBangChu.Text = ""
            Exit Sub
        End If
        If IsNumeric(strDienTich) Then
            txtDienTichBangChu.Text = clsDoiSoThanhChu.Number2Text(strDienTich) & " mét vuông"
        End If
    End Sub

    Private Sub numDienTich_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles numDienTich.ValueChanged
        numDienTichChung.Value = numDienTich.Value
        numDienTichRieng.Text = "0.0"
    End Sub

    Private Sub numDienTichRieng_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles numDienTichRieng.ValueChanged
        If (numDienTichRieng.Value > numDienTich.Value) Then
            System.Windows.Forms.MessageBox.Show("Diện tích Riêng phải nhỏ hơn hoặc bằng diện tích thửa đất", "DMCLand", MessageBoxButtons.OK)
            numDienTichRieng.Value = 0.0
            numDienTichRieng.Text = ""
            numDienTichRieng.Focus()
            Return
        End If
        Dim dblDienTichChung As Decimal
        Dim dblDienTichDat As New Decimal
        Dim dblDienTichRieng As New Decimal
        dblDienTichChung = numDienTich.Value - numDienTichRieng.Value
        'End If
        numDienTichChung.Text = dblDienTichChung
    End Sub

    Private Sub numDienTichChung_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles numDienTichChung.ValueChanged
        If (numDienTichChung.Value > numDienTich.Value) Then
            System.Windows.Forms.MessageBox.Show("Diện tích Chung phải nhỏ hơn hoặc bằng diện tích thửa đất", "DMCLand", MessageBoxButtons.OK)
            numDienTichChung.Value = 0.0
            numDienTichChung.Text = ""
            numDienTichChung.Focus()
            Return
        End If
        Dim dblDienTichDat As New Decimal
        Dim dblDienTichRieng As New Decimal
        dblDienTichRieng = numDienTich.Value - numDienTichChung.Value
        numDienTichRieng.Text = dblDienTichRieng
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If txtHoTenCanBoTNMT.ReadOnly = False Then
            Try
                With Me
                    Dim frm As New frmTuDienCanBoThamDinh
                    With frm
                        With .CtrlTuDienNguoiThamDinh
                            'Gán chuỗi kết nối cơ sở dữ liệu
                            .Connection = strConnection
                            .Ma = ""
                            .showData()
                        End With
                        .StartPosition = FormStartPosition.CenterScreen
                        .ShowDialog()
                        With .CtrlTuDienNguoiThamDinh
                            If .Ma <> "" Then
                                If .dtTuDienSelect.Rows.Count < 1 Then
                                    Return
                                End If
                                'Hiển thị tên cán bộ thẩm định
                                txtHoTenCanBoTNMT.Text = .dtTuDienSelect.Rows(0).Item("HoTen").ToString()
                                .Ma = ""
                            End If
                        End With
                    End With
                End With
            Catch ex As Exception
                strError = ex.Message
                MsgBox(" Thông tin cán bộ Thẩm định " & vbNewLine & "TỪ ĐIỂN cán bộ thẩm định" & vbNewLine & " Lỗi: " & vbNewLine & ex.Message, MsgBoxStyle.Information, "DMCLand")
            End Try
        End If
    End Sub

    Private Sub txtDonViThamDinh_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDonViThamDinh.KeyDown
        If (e.KeyValue = 13) Then
            txtHoTenCanBoDKND.Focus()
        End If
    End Sub

    Private Sub txtHoTenCanBoDKND_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtHoTenCanBoDKND.KeyDown
        If (e.KeyValue = 13) Then
            txtYKienDKND.Focus()
        End If
    End Sub

    Private Sub txtYKienDKND_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtYKienDKND.KeyDown
        If (e.KeyValue = 13) Then
            cmbKetQuaDKND.Focus()
        End If
    End Sub

    Private Sub cmbKetQuaDKND_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbKetQuaDKND.KeyDown
        If (e.KeyValue = 13) Then
            numDienTich.Focus()
        End If
    End Sub

    Private Sub numDienTich_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles numDienTich.KeyDown
        If (e.KeyValue = 13) Then
            txtDienTichBangChu.Focus()
        End If
    End Sub

    Private Sub txtDienTichBangChu_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDienTichBangChu.KeyDown
        If (e.KeyValue = 13) Then
            numDienTichRieng.Focus()
        End If
    End Sub

    Private Sub numDienTichRieng_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles numDienTichRieng.KeyDown
        If (e.KeyValue = 13) Then
            numDienTichChung.Focus()
        End If
    End Sub

    Private Sub numDienTichChung_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles numDienTichChung.KeyDown
        If (e.KeyValue = 13) Then
            NumCapDatO.Focus()
        End If
    End Sub

    Private Sub NumCapDatO_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles NumCapDatO.KeyDown
        If (e.KeyValue = 13) Then
            NumCapDatVuon.Focus()
        End If
    End Sub

    Private Sub NumCapDatVuon_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles NumCapDatVuon.KeyDown
        If (e.KeyValue = 13) Then
            NumDatKhongCap.Focus()
        End If
    End Sub

    Private Sub NumDatKhongCap_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles NumDatKhongCap.KeyDown
        If (e.KeyValue = 13) Then
            txtLyDoKhongCap.Focus()
        End If
    End Sub

    Private Sub txtLyDoKhongCap_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtLyDoKhongCap.KeyDown
        If (e.KeyValue = 13) Then
            YKienKhac.Focus()
        End If
    End Sub

    Private Sub YKienKhac_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles YKienKhac.KeyDown
        If (e.KeyValue = 13) Then
            GhiChuThamDinh.Focus()
        End If
    End Sub

    Private Sub GhiChuThamDinh_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GhiChuThamDinh.KeyDown
        If (e.KeyValue = 13) Then
            btnCapNhat.Focus()
        End If
    End Sub

    Private Sub grdvwDonViThamDinh_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grdvwDonViThamDinh.CellMouseClick
        'Trình bày dữ liệu lên Form
        With grdvwDonViThamDinh
            If e.RowIndex >= 0 Then
                Dim i As Integer = e.RowIndex 
                'Nhận giá trị cho Mã hồ sơ thẩm đinh
                strMaHoSoThamDinh = .Rows(i).Cells("MaHoSoThamDinh").Value
                Me.txtDonViThamDinh.Text = .Rows(i).Cells("DonViThamDinh").Value
                Me.txtHoTenCanBoDKND.Text = .Rows(i).Cells("HoTenCanBoThamDinhDKND").Value
                Me.txtYKienDKND.Text = .Rows(i).Cells("YKienThamDinhDKND").Value
                Me.txtHoTenCanBoTNMT.Text = .Rows(i).Cells("HoTenCanBoThamDinhTNMT").Value
                Me.txtYKienTNMT.Text = .Rows(i).Cells("YKienThamDinhTNMT").Value
                'Thông tin Kết quả thẩm định
                Me.cmbKetQuaDKND.Text = .Rows(i).Cells("TrangThaiThamDinh").Value
                'Me.cmbKetQuaDKND.Text = dtCanBoThamDinh.Rows(i).cells("TrangThaiThamDinh").Value
                If Convert.IsDBNull(.Rows(i).Cells("KetQuaThamDinhTNMT")) Then
                    Me.cmbKetQuaTNMT.Text = ""
                Else
                    Me.cmbKetQuaTNMT.SelectedValue = .Rows(i).Cells("KetQuaThamDinhTNMT").Value
                End If

                Me.GhiChuThamDinh.Text = .Rows(i).Cells("GhiChu").Value
                If Not Convert.IsDBNull(.Rows(i).Cells("DienTichCapDato")) Then
                    Me.NumCapDatO.Value = .Rows(i).Cells("DienTichCapDato").Value
                End If
                If Not Convert.IsDBNull(.Rows(i).Cells("DienTichCapDatVuon")) Then
                    Me.NumCapDatVuon.Value = .Rows(i).Cells("DienTichCapDatVuon").Value
                End If
                If Not Convert.IsDBNull(.Rows(i).Cells("DienTichKhongCap")) Then
                    Me.NumDatKhongCap.Value = .Rows(i).Cells("DienTichKhongCap").Value
                End If
                'Thông tin Kết quả thẩm định
                Me.YKienKhac.Text = .Rows(i).Cells("YKienKhac").Value

                If Not Convert.IsDBNull(.Rows(i).Cells("DienTich")) Then
                    Me.numDienTich.Value = .Rows(i).Cells("DienTich").Value
                End If
                If Not Convert.IsDBNull(.Rows(i).Cells("DienTichBangChu")) Then
                    Me.txtDienTichBangChu.Text = .Rows(i).Cells("DienTichBangChu").Value
                End If
                If Not Convert.IsDBNull(.Rows(i).Cells("DienTichRieng")) Then
                    Me.numDienTichRieng.Value = .Rows(i).Cells("DienTichRieng").Value
                End If
                If Not Convert.IsDBNull(.Rows(i).Cells("DienTichChung")) Then
                    Me.numDienTichChung.Value = .Rows(i).Cells("DienTichChung").Value
                End If

                If Not IsDate(.Rows(i).Cells("NgayThamDinhDKND").Value) Then
                    Me.DTPNgayThamDinhDKND.Value = Date.Now.Date
                    Me.DTPNgayThamDinhDKND.Checked = False
                Else
                    Me.DTPNgayThamDinhDKND.Value = Convert.ToDateTime(.Rows(i).Cells("NgayThamDinhDKND").Value)
                    Me.DTPNgayThamDinhDKND.Checked = True
                End If
                If Not IsDate(.Rows(i).Cells("NgayThamDinhTNMT").Value) Then
                    Me.DTPNgayThamDinhTNMT.Value = Date.Now.Date
                    Me.DTPNgayThamDinhTNMT.Checked = False
                Else
                    Me.DTPNgayThamDinhTNMT.Value = Convert.ToDateTime(.Rows(i).Cells("NgayThamDinhTNMT").Value)
                    Me.DTPNgayThamDinhTNMT.Checked = True
                End If
                Me.txtLyDoKhongCap.Text = .Rows(i).Cells("LyDoKhongCap").Value
            End If
        End With
    End Sub

    Private Sub cmdDVThamDinh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDVThamDinh.Click
        Dim frm As New frmThamSoMacDinh
        With frm.CtrThamSoMacDinh1
            .Connection = strConnection
            .ShowData()
        End With
        frm.ShowDialog()
        If frm.CtrThamSoMacDinh1.MoTa <> "" Then
            txtDonViThamDinh.Text = frm.CtrThamSoMacDinh1.MoTa.Trim
        End If
    End Sub

    Private Sub cmdKetCauNha_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdKetCauNha.Click
        Dim frm As New frmThamSoMacDinh
        With frm.CtrThamSoMacDinh1
            .Connection = strConnection
            .ShowData()
        End With
        frm.ShowDialog()
        If frm.CtrThamSoMacDinh1.MoTa <> "" Then
            txtKetCauNha.Text = frm.CtrThamSoMacDinh1.MoTa.Trim
        End If
    End Sub
 
    Private Sub cmdChuDienTichNha_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdChuDienTichNha.Click
        Dim DoiSoThanhChu As New clsDoiSoThanhChu
        Dim strDienTich As String = ""
        strDienTich = String.Format("{0:0.00}", numTongDienTichNha.Value)
        If (strDienTich = "") Then
            txtChuDienTichNha.Text = ""
            Exit Sub
        End If
        If IsNumeric(strDienTich) Then
            txtChuDienTichNha.Text = clsDoiSoThanhChu.Number2Text(strDienTich) & " mét vuông"
        End If
    End Sub
End Class
