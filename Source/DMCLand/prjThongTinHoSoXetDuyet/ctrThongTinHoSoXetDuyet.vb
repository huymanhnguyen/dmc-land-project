Imports DMC.Database
Public Class ctrThongTinHoSoXetDuyet
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
    Private MaLoaiBienDong As String = ""
    Public Property MaKhoa() As String
        Get
            Return MaLoaiBienDong
        End Get
        Set(ByVal value As String)
            MaLoaiBienDong = value
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
        If Me.MaLoaiBienDong <> "MG" Then
            Me.GroupBox1.Enabled = True
        Else
            Me.GroupBox1.Enabled = False
        End If
        'Khai bao va khoi tao doi tuong clsThongTinXetDuyet
        Dim ThongTinXetDuyet As New clsThongTinHoSoXetDuyet
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
                            Me.txtHienTrangSuDungNhaDat.Text = .Item("TongHopHienTrangSuDungDat").ToString
                            Me.txtPhamViBaoVeHaTang.Text = .Item("HanhLangBaoVeCongTrinhHaTang").ToString
                            Me.txtQuyHoach.Text = .Item("QuyHoach").ToString
                            'Kết quả  xét duyệt
                            Me.cmbKetQuaXetDuyet.Text = dtThongTinXetDuyet.Rows(i).Item("TrangThaiXetDuyet").ToString
                            'Ngày trình Phường
                            If IsDBNull(.Item("NgayTrinhPhuong")) Then
                                Me.dtpNgayTrinh.Value = Date.Now.Date
                                dtpNgayTrinh.Checked = False
                            Else
                                Me.dtpNgayTrinh.Value = Convert.ToDateTime(.Item("NgayTrinhPhuong").ToString)
                                dtpNgayTrinh.Checked = True
                            End If

                            If Not IsDBNull(.Item("HTDienTichBanDo")) Then
                                Me.NumHTDienTichBanDo.Value = .Item("HTDienTichBanDo").ToString
                            End If

                            If Not IsDBNull(.Item("HTDienTichBienBan")) Then
                                Me.NumHTDienTichBienBan.Value = .Item("HTDienTichBienBan").ToString
                            End If

                            If Not IsDBNull(.Item("HTDienTichChenhLech")) Then
                                Me.NumHTDienTichChenhLech.Value = .Item("HTDienTichChenhLech").ToString
                            End If

                            If Not IsDBNull(.Item("HTLyDoChenhLech")) Then
                                Me.txtHTLyDoChenhLech.Text = .Item("HTLyDoChenhLech").ToString
                            End If

                            If Not IsDBNull(.Item("HTDienTIchDatO")) Then
                                Me.NumHTDienTIchDatO.Value = .Item("HTDienTIchDatO").ToString
                            End If
                            If Not IsDBNull(.Item("HTDTChungDatO")) Then
                                Me.NumHTDTChungDatO.Value = .Item("HTDTChungDatO").ToString
                            End If
                            If Not IsDBNull(.Item("HTDTRiengDatO")) Then
                                Me.NumHTDTRiengDatO.Value = .Item("HTDTRiengDatO").ToString
                            End If

                            If Not IsDBNull(.Item("HTDienTichDatVuon")) Then
                                Me.NumHTDienTichDatVuon.Value = .Item("HTDienTichDatVuon").ToString
                            End If
                            If Not IsDBNull(.Item("HTDTChungDatVuon")) Then
                                Me.NumHTDTChungDatVuon.Value = .Item("HTDTChungDatVuon").ToString
                            End If
                            If Not IsDBNull(.Item("HTDTRiengDatVuon")) Then
                                Me.NumHTDTRiengDatVuon.Value = .Item("HTDTRiengDatVuon").ToString
                            End If


                            If Not IsDBNull(.Item("HTDienTichDatNN")) Then
                                Me.NumHTDienTichDatNN.Value = .Item("HTDienTichDatNN").ToString
                            End If
                            If Not IsDBNull(.Item("HTDTChungDatNN")) Then
                                Me.NumHTDTChungDatNN.Value = .Item("HTDTChungDatNN").ToString
                            End If
                            If Not IsDBNull(.Item("HTDTRiengDatNN")) Then
                                Me.NumHTDTRiengDatNN.Value = .Item("HTDTRiengDatNN").ToString
                            End If

                            If Not IsDBNull(.Item("HTDienTichHanhLang")) Then
                                Me.NumHTDienTichHanhLang.Value = .Item("HTDienTichHanhLang").ToString
                            End If

                            If Not IsDBNull(.Item("HTDienTichSDNha")) Then
                                Me.NumHTDienTichSDNha.Value = .Item("HTDienTichSDNha").ToString
                            End If

                            If Not IsDBNull(.Item("HTDienTichXD")) Then
                                Me.NumHTDienTichXD.Value = .Item("HTDienTichXD").ToString
                            End If
                            If Not IsDBNull(.Item("HTKetCau")) Then
                                Me.txtHTKetCau.Text = .Item("HTKetCau").ToString
                            End If
                            If Not IsDBNull(.Item("YKQuyHoachThoiDiem")) Then
                                Me.txtYKQuyHoachThoiDiem.Text = .Item("YKQuyHoachThoiDiem").ToString
                            End If

                            If Not IsDBNull(.Item("YKDienTichDuDK")) Then
                                Me.NumYKDienTichDuDK.Value = .Item("YKDienTichDuDK").ToString
                            End If

                            If Not IsDBNull(.Item("YKDienTichNopTienSDD")) Then
                                Me.NumYKDienTichNopTienSDD.Value = .Item("YKDienTichNopTienSDD").ToString
                            End If
                            If Not IsDBNull(.Item("YKDienTichDatO")) Then
                                Me.NumYKDienTichDatO.Value = .Item("YKDienTichDatO").ToString
                            End If
                            If Not IsDBNull(.Item("YKDienTichVuonAo")) Then
                                Me.NumYKDienTichVuonAo.Value = .Item("YKDienTichVuonAo").ToString
                            End If

                            If Not IsDBNull(.Item("YKDienTichDatNN")) Then
                                Me.NumYKDienTichDatNN.Value = .Item("YKDienTichDatNN").ToString
                            End If

                            If Not IsDBNull(.Item("YKDienTichKhongDuDK")) Then
                                Me.NumYKDienTichKhongDuDK.Value = .Item("YKDienTichKhongDuDK").ToString
                            End If

                            If Not IsDBNull(.Item("YKLyDo")) Then
                                Me.txtYKLyDo.Text = .Item("YKLyDo").ToString
                            End If
                            If Not IsDBNull(.Item("YKDienTichXD")) Then
                                Me.NumYKDienTichXD.Value = .Item("YKDienTichXD").ToString
                            End If
                            If Not IsDBNull(.Item("YKKetCau")) Then
                                Me.txtYKKetCau.Text = .Item("YKKetCau").ToString
                            End If

                            If Not IsDBNull(.Item("YKDienTichSuDungNha")) Then
                                Me.NumYKDienTichSuDungNha.Value = .Item("YKDienTichSuDungNha").ToString
                            End If

                            If Not IsDBNull(.Item("YKDienTichChung")) Then
                                Me.NumYKDienTichChung.Value = .Item("YKDienTichChung").ToString
                            End If
                            If Not IsDBNull(.Item("YKDienTichRieng")) Then
                                Me.NumYKDienTichRieng.Value = .Item("YKDienTichRieng").ToString
                            End If

                            If Not IsDBNull(.Item("YKDienTichHanhLang")) Then
                                Me.NumYKDienTichHanhLang.Value = .Item("YKDienTichHanhLang").ToString
                            End If

                            'Ngày xét duyệt
                            If IsDBNull(.Item("NgayXetDuyet")) Then
                                Me.dtpNgayXetDuyet.Value = Date.Now.Date
                                dtpNgayXetDuyet.Checked = False
                            Else
                                dtpNgayXetDuyet.Checked = True
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
        Dim ThongTinXetDuyet As New clsThongTinHoSoXetDuyet
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
                .MaDonViHanhChinh = strMaDonViHanhChinh
                .MaHoSoCapGCN = strMaHoSoCapGCN
                .KetQuaXetDuyet = Me.cmbKetQuaXetDuyet.FindString(Me.cmbKetQuaXetDuyet.Text.Trim)
                If dtpNgayTrinh.Checked Then
                    .NgayTrinhPhuong = Me.dtpNgayTrinh.Text
                Else
                    .NgayTrinhPhuong = Nothing
                End If
                If dtpNgayXetDuyet.Checked Then
                    .NgayXetDuyet = Me.dtpNgayXetDuyet.Text
                Else
                    .NgayXetDuyet = Nothing
                End If
                .ToTrinhPhuong = Me.txtToTrinh.Text.Trim

                If cmbKetQuaXetDuyet.Text = "Đủ điều kiện" Then
                    '.Flag = "3"
                    '.UpdateTrangThai()
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
                .NoiDungTranhChapKhieuKien = Me.txtNoiDungTranhChapKhieuKien.Text
                .YKienCanBoXetDuyet = Me.txtYKienCanBoXetDuyet.Text
                .TongHopHIenTrangSuDung = Me.txtHienTrangSuDungNhaDat.Text
                .PhamViBaoVeHaTang = txtPhamViBaoVeHaTang.Text
                .QuyHoach = txtQuyHoach.Text

                .HTDienTichBanDo = NumHTDienTichBanDo.Value.ToString
                .HTDienTichBienBan = NumHTDienTichBienBan.Value.ToString
                .HTDienTichChenhLech = NumHTDienTichChenhLech.Value.ToString
                .HTLyDoChenhLech = txtHTLyDoChenhLech.Text
                .HTDienTIchDatO = NumHTDienTIchDatO.Value.ToString
                .HTDTChungDatO = NumHTDTChungDatO.Value.ToString
                .HTDTRiengDatO = NumHTDTRiengDatO.Value.ToString

                .HTDienTichDatVuon = NumHTDienTichDatVuon.Value.ToString
                .HTDTChungDatVuon = NumHTDTChungDatVuon.Value.ToString
                .HTDTRiengDatVuon = NumHTDTRiengDatVuon.Value.ToString

                .HTDientichDatNN = NumHTDienTichDatNN.Value.ToString
                .HTDTChungDatNN = NumHTDTChungDatNN.Value.ToString
                .HTDTRiengDatNN = NumHTDTRiengDatNN.Value.ToString


                .HTDienTichHanhLang = NumHTDienTichHanhLang.Value.ToString
                .HTDienTichSDNha = NumHTDienTichSDNha.Value.ToString
                .HTDienTichXD = NumHTDienTichXD.Value.ToString
                .HTKetCau = txtHTKetCau.Text
                .YKQuyHoachThoiDiem = txtYKQuyHoachThoiDiem.Text
                .YKDienTichDuDK = NumYKDienTichDuDK.Value.ToString
                .YKDienTichNopTienSDD = NumYKDienTichNopTienSDD.Value.ToString
                .YKDienTichDatO = NumYKDienTichDatO.Value.ToString
                .YKDienTichVuonAo = NumYKDienTichVuonAo.Value.ToString
                .YKDienTichDatNN = NumYKDienTichDatNN.Value.ToString
                .YKDienTichKhongDuDK = NumYKDienTichKhongDuDK.Value.ToString
                .YKLyDo = txtYKLyDo.Text
                .YKDienTichXD = NumYKDienTichXD.Value.ToString
                .YKKetCau = txtYKKetCau.Text
                .YKDienTichSuDungNha = NumYKDienTichSuDungNha.Value.ToString
                .YKDienTichChung = NumYKDienTichChung.Value.ToString
                .YKDienTichRieng = NumYKDienTichRieng.Value.ToString
                .YKDienTichHanhLang = NumYKDienTichHanhLang.Value.ToString


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
            .txtHienTrangSuDungNhaDat.ReadOnly = Not blnCapNhat
            .txtPhamViBaoVeHaTang.ReadOnly = Not blnCapNhat
            .txtQuyHoach.ReadOnly = Not blnCapNhat
            'Ngày trình phường
            .dtpNgayTrinh.Enabled = blnCapNhat
            'Ngày xét duyệt
            .dtpNgayXetDuyet.Enabled = blnCapNhat
            'Kết quả xét duyệt cấp Phường
            .cmbKetQuaXetDuyet.Enabled = blnCapNhat

            .NumHTDienTichBanDo.Enabled = blnCapNhat
            .NumHTDienTichBienBan.Enabled = blnCapNhat
            '.NumHTDienTichChenhLech.Enabled = blnCapNhat
            .txtHTLyDoChenhLech.ReadOnly = Not blnCapNhat
            .NumHTDienTIchDatO.Enabled = blnCapNhat
            .NumHTDienTichDatVuon.Enabled = blnCapNhat
            .NumHTDienTichHanhLang.Enabled = blnCapNhat
            .NumHTDienTichSDNha.Enabled = blnCapNhat
            .NumHTDienTichXD.Enabled = blnCapNhat
            .txtHTKetCau.ReadOnly = Not blnCapNhat
            .txtYKQuyHoachThoiDiem.ReadOnly = Not blnCapNhat
            .NumYKDienTichDuDK.Enabled = blnCapNhat
            .NumYKDienTichNopTienSDD.Enabled = blnCapNhat
            .NumYKDienTichDatO.Enabled = blnCapNhat
            .NumYKDienTichVuonAo.Enabled = blnCapNhat
            .NumYKDienTichKhongDuDK.Enabled = blnCapNhat
            .txtYKLyDo.ReadOnly = Not blnCapNhat
            .NumYKDienTichXD.Enabled = blnCapNhat
            .txtYKKetCau.ReadOnly = Not blnCapNhat
            .NumYKDienTichSuDungNha.Enabled = blnCapNhat
            .NumYKDienTichChung.Enabled = blnCapNhat
            .NumYKDienTichRieng.Enabled = blnCapNhat

            .NumYKDienTichHanhLang.Enabled = blnCapNhat

            .NumHTDTChungDatO.Enabled = blnCapNhat
            .NumHTDTRiengDatO .Enabled = blnCapNhat

            .NumHTDTChungDatVuon.Enabled = blnCapNhat
            .NumHTDTRiengDatVuon.Enabled = blnCapNhat

            .NumHTDienTichDatNN.Enabled = blnCapNhat
            .NumHTDTChungDatNN.Enabled = blnCapNhat
            .NumHTDTRiengDatNN.Enabled = blnCapNhat

            .NumYKDienTichDatNN.Enabled = blnCapNhat

            If blnCapNhat Then
                .txtHTLyDoChenhLech.BackColor = Color.White
                .txtHTKetCau.BackColor = Color.White
                .txtYKQuyHoachThoiDiem.BackColor = Color.White
                .txtYKLyDo.BackColor = Color.White
                .txtYKKetCau.BackColor = Color.White

                .txtToTrinh.BackColor = Color.White
                .txtYKienCanBoXetDuyet.BackColor = Color.White
                .txtHienTrangSuDungNhaDat.BackColor = Color.White
                .txtNoiDungTranhChapKhieuKien.BackColor = Color.White
                .txtPhamViBaoVeHaTang.BackColor = Color.White
                .txtQuyHoach.BackColor = Color.White
            Else
                .txtHTLyDoChenhLech.BackColor = Color.LightYellow
                .txtHTKetCau.BackColor = Color.LightYellow
                .txtYKQuyHoachThoiDiem.BackColor = Color.LightYellow
                .txtYKLyDo.BackColor = Color.LightYellow
                .txtYKKetCau.BackColor = Color.LightYellow
                .txtToTrinh.BackColor = Color.LightYellow
                .txtYKienCanBoXetDuyet.BackColor = Color.LightYellow
                .txtHienTrangSuDungNhaDat.BackColor = Color.LightYellow
                .txtNoiDungTranhChapKhieuKien.BackColor = Color.LightYellow
                .txtPhamViBaoVeHaTang.BackColor = Color.LightYellow
                .txtQuyHoach.BackColor = Color.LightYellow
            End If
        End With
    End Sub

    Public Sub TrangThaiBanDau()
        'Thiết lập trạng thái ban đầu
        Dim ThongTinXetDuyet As New clsThongTinHoSoXetDuyet
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
            .txtHienTrangSuDungNhaDat.Text = ""
            .txtPhamViBaoVeHaTang.Text = ""
            .txtQuyHoach.Text = ""
            .dtpNgayTrinh.Value = Date.Now
            .dtpNgayXetDuyet.Value = Date.Now
            .cmbKetQuaXetDuyet.Text = ""
            'Cảnh báo tranh chấp khiếu kiện
            .chkCanhBaoTranhChap.Checked = False
            'Nội dung tranh chấp khiếu kiện
            .txtNoiDungTranhChapKhieuKien.Text = ""


            .NumHTDienTIchDatO.Value = 0
            .NumHTDienTichDatVuon.Value = 0
            .NumHTDienTichHanhLang.Value = 0
            .NumHTDienTichSDNha.Value = 0
            .NumHTDienTichXD.Value = 0
            .txtHTKetCau.Text = ""
            .txtYKQuyHoachThoiDiem.Text = ""
            .NumYKDienTichDuDK.Value = 0
            .NumYKDienTichNopTienSDD.Value = 0
            .NumYKDienTichDatO.Value = 0
            .NumYKDienTichVuonAo.Value = 0
            .NumYKDienTichKhongDuDK.Value = 0
            .txtYKLyDo.Text = ""
            .NumYKDienTichXD.Value = 0
            .txtYKKetCau.Text = ""
            .NumYKDienTichSuDungNha.Value = 0
            .NumYKDienTichChung.Value = 0
            .NumYKDienTichRieng.Value = 0

            .NumYKDienTichHanhLang.Value = 0

            .NumHTDTChungDatO.Value = 0
            .NumHTDTRiengDatO.Value = 0

            .NumHTDTChungDatVuon.Value = 0
            .NumHTDTRiengDatVuon.Value = 0

            .NumHTDienTichDatNN.Value = 0
            .NumHTDTChungDatNN.Value = 0
            .NumHTDTRiengDatNN.Value = 0

            .NumYKDienTichDatNN.Value = 0
        End With
    End Sub

    Public Sub TrangThaiChucNang(Optional ByVal blnStartEdited As Boolean = False, Optional ByVal blnStartDeleted As Boolean = False)
        With Me
            If Me.MaLoaiBienDong <> "MG" Then
                Me.GroupBox1.Enabled = True
                .btnSua.Enabled = Not blnStartEdited
                .btnXoa.Enabled = Not blnStartEdited
                .btnCapNhat.Enabled = blnStartEdited
                .btnHuyLenh.Enabled = blnStartEdited
                If blnStartDeleted Then
                    .btnCapNhat.Enabled = Not blnStartDeleted
                    .btnHuyLenh.Enabled = Not blnStartDeleted
                End If
            Else
                Me.GroupBox1.Enabled = False

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
    Private Sub txtHienTrangSuDungNhaDat_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtHienTrangSuDungNhaDat.KeyDown
        If e.KeyCode = Keys.F7 Then
            Dim str As String = ""
            Dim strNumHTDienTichBanDo As String = ""
            Dim strNumHTDienTichBienBan As String = ""
            Dim strNumHTDienTichChenhLech As String = ""
            Dim strtxtHTLyDoChenhLech As String = ""
            Dim strNumHTDienTIchDatO As String = ""
            Dim strNumHTDienTichDatVuon As String = ""
            Dim strNumHTDienTichHanhLang As String = ""
            Dim strNumHTDienTichSDNha As String = ""
            Dim strNumHTDienTichXD As String = ""
            Dim strtxtHTKetCau As String = ""
            Dim strNoiDungTranhChapKhieuKien As String = ""


            If NumHTDienTichBanDo.Value = "0.00" Then
                strNumHTDienTichBanDo = "....."
            Else
                strNumHTDienTichBanDo = NumHTDienTichBanDo.Value
            End If
            If NumHTDienTichBienBan.Value = "0.00" Then
                strNumHTDienTichBienBan = "....."
            Else
                strNumHTDienTichBienBan = NumHTDienTichBienBan.Value
            End If
            If NumHTDienTichChenhLech.Value = "0.00" Then
                strNumHTDienTichChenhLech = "....."
            Else
                strNumHTDienTichChenhLech = NumHTDienTichChenhLech.Value
            End If
            If txtHTLyDoChenhLech.Text = "" Then
                strtxtHTLyDoChenhLech = "..........................................."
            Else
                strtxtHTLyDoChenhLech = txtHTLyDoChenhLech.Text
            End If
            If NumHTDienTIchDatO.Value = "0.00" Then
                strNumHTDienTIchDatO = "....."
            Else
                strNumHTDienTIchDatO = NumHTDienTIchDatO.Value
            End If
            If NumHTDienTichDatVuon.Value = "0.00" Then
                strNumHTDienTichDatVuon = "....."
            Else
                strNumHTDienTichDatVuon = NumHTDienTichDatVuon.Value
            End If
            If NumHTDienTichHanhLang.Value = "0.00" Then
                strNumHTDienTichHanhLang = "....."
            Else
                strNumHTDienTichHanhLang = NumHTDienTichHanhLang.Value
            End If
            If NumHTDienTichSDNha.Value = "0.00" Then
                strNumHTDienTichSDNha = "....."
            Else
                strNumHTDienTichSDNha = NumHTDienTichSDNha.Value
            End If
            If NumHTDienTichXD.Value = "0.00" Then
                strNumHTDienTichXD = "....."
            Else
                strNumHTDienTichXD = NumHTDienTichXD.Value
            End If
            If txtHTKetCau.Text = "" Then
                strtxtHTKetCau = "....."
            Else
                strtxtHTKetCau = txtHTKetCau.Text
            End If

            If txtNoiDungTranhChapKhieuKien.Text = "" Then
                strNoiDungTranhChapKhieuKien = "........................................."
            Else
                strNoiDungTranhChapKhieuKien = txtNoiDungTranhChapKhieuKien.Text
            End If

            str = str & vbTab & "- Hiện trạng sử dụng đất: Diện tích theo bản đồ là: " & strNumHTDienTichBanDo & " m2. DIện tích theo biên bản kiểm tra hiện trạng nhà đất là: " & strNumHTDienTichBienBan & " m2. Chênh lệch là: " & strNumHTDienTichChenhLech & " m2."
            str = str & " Lý do chênh lệch là: " & strtxtHTLyDoChenhLech & vbNewLine
            str = str & vbTab & "Trong đó: DT đất ở là : " & strNumHTDienTIchDatO & " m2. DT đất ao, vườn: " & strNumHTDienTichDatVuon & " m2;"
            str = str & " Diện tích nằm trong hành lang bảo vệ các công trình: " & strNumHTDienTichHanhLang & " m2 " & vbNewLine
            str = str & vbTab & "- Hiện trạng sử dụng nhà: DT sử dụng: " & strNumHTDienTichSDNha & " DT xây dựng: " & strNumHTDienTichXD & " Kết cấu nhà: " & strtxtHTKetCau & " " & vbNewLine
            str = str & "3. Ranh giới sử dụng: " & strNoiDungTranhChapKhieuKien
            txtHienTrangSuDungNhaDat.Text = str
        End If
    End Sub

    Private Sub txtYKienCanBoXetDuyet_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtYKienCanBoXetDuyet.KeyDown
        If e.KeyCode = Keys.F8 Then
            Dim str As String = ""
            Dim strtxtYKQuyHoachThoiDiem As String = ""
            Dim strNumYKDienTichDuDK As String = ""
            Dim strNumYKDienTichNopTienSDD As String = ""
            Dim strNumYKDienTichDatO As String = ""
            Dim strNumYKDienTichVuonAo As String = ""
            Dim strNumYKDienTichKhongDuDK As String = ""
            Dim strtxtYKLyDo As String = ""
            Dim strNumYKDienTichXD As String = ""
            Dim strtxtYKKetCau As String = ""
            Dim strNumYKDienTichSuDungNha As String = ""

            Dim strNumYKDienTichChung As String = ""
            Dim strNumNumYKDienTichRieng As String = ""
            Dim strNumYKDienTichHanhLang As String = ""


            If txtYKQuyHoachThoiDiem.Text = "" Then
                strtxtYKQuyHoachThoiDiem = "............"
            Else
                strtxtYKQuyHoachThoiDiem = txtYKQuyHoachThoiDiem.Text
            End If
            If NumYKDienTichDuDK.Value = "0.00" Then
                strNumYKDienTichDuDK = "...."
            Else
                strNumYKDienTichDuDK = NumYKDienTichDuDK.Value
            End If
            If NumYKDienTichNopTienSDD.Value = "0.00" Then
                strNumYKDienTichNopTienSDD = "...."
            Else
                strNumYKDienTichNopTienSDD = NumYKDienTichNopTienSDD.Value
            End If

            If NumYKDienTichChung.Value = "0.00" Then
                strNumYKDienTichChung = "......."
            Else
                strNumYKDienTichChung = NumYKDienTichChung.Value
            End If
            If NumYKDienTichRieng.Value = "0.00" Then
                strNumNumYKDienTichRieng = "......."
            Else
                strNumNumYKDienTichRieng = NumYKDienTichRieng.Value
            End If

            If NumYKDienTichDatO.Value = "0.00" Then
                strNumYKDienTichDatO = "......."
            Else
                strNumYKDienTichDatO = NumYKDienTichDatO.Value
            End If
            If NumYKDienTichVuonAo.Value = "0.00" Then
                strNumYKDienTichVuonAo = "......"
            Else
                strNumYKDienTichVuonAo = NumYKDienTichVuonAo.Value
            End If
            If NumYKDienTichHanhLang.Value = "0.00" Then
                strNumYKDienTichHanhLang = "......"
            Else
                strNumYKDienTichHanhLang = NumYKDienTichHanhLang.Value
            End If
            If NumYKDienTichKhongDuDK.Value = "0.00" Then
                strNumYKDienTichKhongDuDK = "....."
            Else
                strNumYKDienTichKhongDuDK = NumYKDienTichKhongDuDK.Value
            End If
            If txtYKLyDo.Text = "" Then
                strtxtYKLyDo = "......................................................"
            Else
                strtxtYKLyDo = txtYKLyDo.Text
            End If
            If NumYKDienTichXD.Value = "0.00" Then
                strNumYKDienTichXD = "......."
            Else
                strNumYKDienTichXD = NumYKDienTichXD.Value
            End If
            If NumYKDienTichSuDungNha.Value = "0.00" Then
                strNumYKDienTichSuDungNha = "........"
            Else
                strNumYKDienTichSuDungNha = NumYKDienTichSuDungNha.Value
            End If
            If txtYKKetCau.Text = "" Then
                strtxtYKKetCau = "........"
            Else
                strtxtYKKetCau = txtYKKetCau.Text
            End If
            str = str & vbTab & "- Về quy hoạch và thời điểm sử dụng đất: Phù hợp với quy hoạch, " & strtxtYKQuyHoachThoiDiem & vbNewLine
            str = str & vbTab & "- Diện tích đủ điều kiện cấp giấy chứng nhận quyền sử dụng đất (không phải nộp tiền sử dụng đất):...."
            str = str & "; Diện tích đất đủ điều kiện cấp giấy chứng nhận quyền sử đụng dất nhưng phải nộp tiền sử dụng đất: " & strNumYKDienTichDuDK & ";"
            str = str & " Trong đó: Đất ở: " & strNumYKDienTichDatO & " m2; Diện tích đất sử dụng riêng: " & strNumNumYKDienTichRieng & " m2;" & vbNewLine
            str = str & vbTab & "- Diện tích đất sử dụng chung: " & strNumYKDienTichChung & " m2; Diện tích đất ao, vườn " & strNumYKDienTichVuonAo & " m2; Diện tích đất nằm trong hành lang bảo vệ các công trình " & strNumYKDienTichHanhLang & " m2." & vbNewLine
            str = str & vbTab & "- Diện tích không đủ điều kiện cấp giấy chứng nhận quyền sử dụng đất: " & strNumYKDienTichKhongDuDK & " m2." & vbNewLine
            str = str & vbTab & "- Lý do không đủ điều kiện: " & strtxtYKLyDo & vbNewLine
            str = str & vbTab & "- Về nhà ở: Diện tích xây dựng: " & strNumYKDienTichXD & " m2; Diện tích sử dụng: " & strNumYKDienTichSuDungNha & " m2; Kết cấu nhà : " & strtxtYKKetCau & vbNewLine
            txtYKienCanBoXetDuyet.Text = str
        End If
    End Sub


    Private Sub NumHTDienTichBanDo_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles NumHTDienTichBanDo.ValueChanged
        NumHTDienTichChenhLech.Value = Math.Abs(NumHTDienTichBanDo.Value - NumHTDienTichBienBan.Value)
    End Sub

    Private Sub NumHTDienTichBienBan_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles NumHTDienTichBienBan.ValueChanged
        NumHTDienTichChenhLech.Value = Math.Abs(NumHTDienTichBanDo.Value - NumHTDienTichBienBan.Value)
    End Sub
End Class
