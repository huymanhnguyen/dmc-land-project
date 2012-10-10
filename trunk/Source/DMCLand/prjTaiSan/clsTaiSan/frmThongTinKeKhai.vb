Imports System.Windows.Forms
Imports System.Drawing
Public Class frmThongTinKeKhai
    Private strMaHoSoCapGCN As String = ""
    Private dtNhaO As New DataTable
    Private blnNonNumberEntered As Boolean
    'Khai báo nhận Tên đơn vị hành chính
    Private strTenDonViHanhChinh As String = ""
    'Khai báo biến nhận chuỗi kết nối Database
    Private strConnection As String = ""
    'Khai báo biến kiểm tra lỗi
    Private strError As String = ""
    Private strMaNhaO As String = ""
    Private shortAction As Short = 0
    'Khai báo nhận Tên đơn vị hành chính
    Public WriteOnly Property TenDonViHanhChinh() As String
        Set(ByVal value As String)
            strTenDonViHanhChinh = value
        End Set
    End Property

    'Khai báo thuộc tính nhận chuỗi kết nối Database
    Public WriteOnly Property Connection() As String
        Set(ByVal value As String)
            strConnection = value
        End Set
    End Property
    Public WriteOnly Property Action() As String
        Set(ByVal value As String)
            shortAction = value
        End Set
    End Property
    Public WriteOnly Property MaHoSoCapGCN() As String
        Set(ByVal value As String)
            strMaHoSoCapGCN = value
        End Set
    End Property
    Public Property MaNhaO() As String
        Get
            Return strMaNhaO
        End Get
        Set(ByVal value As String)
            strMaNhaO = value
        End Set
    End Property
    Public Sub TrangThaiBanDau(Optional ByVal blnClearGrid As Boolean = False)
        With Me
            'Thiet lap tren Form nhap lieu
            .txtCoQuanCapGPXD.Text = ""
            .numDienTichSanPhu.Text = ""
            .txtSoGPXD.Text = ""
            'Năm cấp phép xây dựng
            .dtpNgayCapPhepXayDung.Value = Now
            .dtpNgayCapPhepXayDung.Checked = True
            'Thông tin xử lý vi phạm
            .txtThongTinViPham.Text = ""
            'Địa chỉ nhà
            .txtDiaChiNha.Text = ""
            .numDienTichXayDung.Text = ""
            .txtKetCauNha.Text = ""
            .numSoTang.Text = ""
            .cmbCapHangNha.Text = ""
            .cmbLoaiNha.Text = ""
            .txtThoiHanSoHuu.Text = ""
            .numNamXayDung.Text = ""
            .numNamHoanThanhXayDung.Text = ""
            .numDienTichSanXayDung.Text = ""
        End With
    End Sub


    Public Sub UpdateData()
        'Khai báo và khởi tạo đối tượng Nhà ở
        Dim NhaO As New clsNhaO
        Try
            With NhaO
                'Nhận chuỗi kết nối cơ sở dữ liệu
                .Connection = strConnection
                .MaHoSoCapGCN = strMaHoSoCapGCN
                .MaNhaO = strMaNhaO
                If txtDiaChiNha IsNot Nothing Then
                    .DiaChiNha = txtDiaChiNha.Text
                Else
                    .DiaChiNha = ""
                End If
                .DienTichXayDung = numDienTichXayDung.Value

                .KetCauNha = txtKetCauNha.Text

                .CapHangNha = cmbCapHangNha.Text.Trim

                .SoTang = numSoTang.Value

                .LoaiNha = cmbLoaiNha.Text.Trim
                .ThoiHanSoHuu = txtThoiHanSoHuu.Text.Trim
                If IsNumeric(numNamXayDung.Text.Trim) Then
                    .NamXayDung = numNamXayDung.Text
                Else
                    .NamXayDung = Nothing
                End If
                If IsNumeric(numNamHoanThanhXayDung.Text.Trim) Then
                    .NamHoanThanhXayDung = numNamHoanThanhXayDung.Text
                Else
                    .NamHoanThanhXayDung = Nothing
                End If
                .ThoiHanSoHuu = txtThoiHanSoHuu.Text.Trim
                .CoQuanCapGPXD = txtCoQuanCapGPXD.Text.Trim
                .DienTichSanPhu = numDienTichSanPhu.Text
                .DienTichSanXayDung = numDienTichSanXayDung.Text
                'Số giấy phép xây dựng
                .SoGiayPhepXayDung = txtSoGPXD.Text.Trim
                'Năm cấp phép xây dựng
                If (dtpNgayCapPhepXayDung.Checked = True) Then
                    .NgayCapPhepXayDung = dtpNgayCapPhepXayDung.Text
                Else
                    .NgayCapPhepXayDung = Nothing
                End If

                'Thông tin xử lý vi phạm
                .ThongTinXuLyViPham = txtThongTinViPham.Text.Trim
                Dim str As String = ""

                Dim strResults As String = ""
                If (shortAction = 1) Then
                    strResults = .InsertNhaO(str)
                ElseIf (shortAction = 2) Then
                    strResults = .UpdateNhaO(str)
                End If

                If strResults = "OK" Then
                    Me.Hide()
                    shortAction = 0
                End If

                strError = NhaO.Err
            End With
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Nhà ở (Căn hộ) " & vbNewLine & " Cập nhật " & vbNewLine & _
                   " Lỗi " & strError, MsgBoxStyle.Information, "DMCLand")
        End Try

    End Sub

    Private Sub btnCapNhat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCapNhat.Click
        'Truong hop them moi mau tin
        With Me
            'Cập nhật thông tin
            .UpdateData()
        End With
        If (strError = "") Or (strError = "OK") Then
            MsgBox(" Bạn đã cập nhật thành công!", MsgBoxStyle.Information, "DMCLand")
        Else
            MsgBox(" Cập nhật chưa thành công!", MsgBoxStyle.Critical, "DMCLand")
        End If
        strMaNhaO = ""
        strError = ""
        'Ẩn Form cập nhật
        Me.Hide()
    End Sub

    Private Sub btnHuyLenh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHuyLenh.Click
        With Me
            'Hien thi du lieu
            shortAction = 0
            Me.Close()
        End With
    End Sub
    Private Sub frmThongTinKeKhai_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            With Me
                'Định dạng lại Ngày cấp phép xây dựng theo kiểu Pháp
                With .dtpNgayCapPhepXayDung
                    .CustomFormat = "dd/MM/yyyy"
                    .Format = DateTimePickerFormat.Custom
                    .ShowCheckBox = True
                End With
            End With
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Nạp dữ liệu ban đầu " & vbNewLine & " Nhà ở (Căn hộ) " & vbNewLine _
            & " Lỗi: " & strError, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub
End Class