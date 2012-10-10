Imports System.Windows.Forms

Public Class ctrlThongTinTraGCN
    'Khai báo biến nhận chuỗi kết nối Database
    Private strConnection As String = ""
    'Khai báo biến kiểm tra lỗi
    Private strError As String = ""
    'Khai bao bien MaHoSoCapGCN dung chung
    Private strMaHoSoCapGCN As String = ""
    Private dtThongTinTraGCN As New DataTable
    Private dtTrangThaiHS As New DataTable
    Private shortAction As Short = 0
    Private strFlag As String = ""
    Private strThongTinCu As String
    Private strMaDonViHanhChinh As String
    Public Property MaDonViHanhChinh() As String
        Get
            Return strMaDonViHanhChinh
        End Get
        Set(ByVal value As String)
            strMaDonViHanhChinh = value
        End Set
    End Property
    Public Property Flag() As String
        Get
            Return strFlag
        End Get
        Set(ByVal value As String)
            strFlag = value
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
    'Khai báo thuộc tính nhận chuỗi kết nối Database
    Public WriteOnly Property Connection() As String
        Set(ByVal value As String)
            strConnection = value
        End Set
    End Property
    Public WriteOnly Property MaHoSoCapGCN() As String
        Set(ByVal value As String)
            strMaHoSoCapGCN = value
        End Set
    End Property

    '
    Public Sub ShowData()
        If Me.MaLoaiBienDong <> "MG" Then
            Me.GroupBox2.Enabled = True
        Else
            Me.GroupBox2.Enabled = False
        End If
        'Khai báo và khởi tạo đối tượng
        Dim ThongTinTraGCN As New clsThongTinTraGCN
        Try
            'Gan gia tri cho cac thuoc tinh doi voi truong hop truy van
            With ThongTinTraGCN
                'Nhận chuỗi kết nối Database
                .Connection = strConnection
                .MaHoSoCapGCN = strMaHoSoCapGCN
            End With
            'Khởi tạo trạng thái ban đầu
            TrangThaiBanDau()
            'Goi phuong thuc GetData de khoi tao doi tuong
            If ThongTinTraGCN.GetData(dtThongTinTraGCN) = "" Then
                ' Trinh bay du lieu
                If dtThongTinTraGCN.Rows.Count > 0 Then
                    If Not IsDate(dtThongTinTraGCN.Rows(0).Item("NgayTraGCN").ToString) Then
                        Me.dtpNgayTraGCN.Value = Date.Now.Date
                        Me.dtpNgayTraGCN.Checked = False
                    Else
                        Me.dtpNgayTraGCN.Value = Convert.ToDateTime(dtThongTinTraGCN.Rows(0).Item("NgayTraGCN").ToString)
                        Me.dtpNgayTraGCN.Checked = True
                    End If
                End If
                If dtThongTinTraGCN.Rows.Count > 0 Then
                    If Not IsDate(dtThongTinTraGCN.Rows(0).Item("NgayHoanTatGCN").ToString) Then
                        Me.dtpNgayHoanTatGCN.Value = Date.Now.Date
                        Me.dtpNgayHoanTatGCN.Checked = False
                    Else
                        Me.dtpNgayHoanTatGCN.Value = Convert.ToDateTime(dtThongTinTraGCN.Rows(0).Item("NgayHoanTatGCN").ToString)
                        Me.dtpNgayHoanTatGCN.Checked = True
                    End If
                End If

                If dtThongTinTraGCN.Rows.Count > 0 Then
                    If Not IsDBNull(dtThongTinTraGCN.Rows(0).Item("TrangThaiHoSoCapGCN").ToString) Then
                        If dtThongTinTraGCN.Rows(0).Item("TrangThaiHoSoCapGCN").ToString = "81" Then
                            radChuaTraGCN.Checked = True
                        ElseIf dtThongTinTraGCN.Rows(0).Item("TrangThaiHoSoCapGCN").ToString = "82" Then
                            radDaTraGCN.Checked = True
                        Else
                            radChuaXuLy.Checked = True
                        End If
                    Else
                        radChuaXuLy.Checked = True
                        radChuaTraGCN.Checked = False
                        radDaTraGCN.Checked = False
                    End If
                End If
                If dtThongTinTraGCN.Rows.Count > 0 Then
                    If Not IsDBNull(dtThongTinTraGCN.Rows(0).Item("YKienTraGCN").ToString) Then
                        Me.txtYKienTraGCN.Text = dtThongTinTraGCN.Rows(0).Item("YKienTraGCN").ToString 
                    Else
                        Me.txtYKienTraGCN.Text = ""
                    End If
                End If
                If dtThongTinTraGCN.Rows.Count > 0 Then
                    If Not IsDBNull(dtThongTinTraGCN.Rows(0).Item("KhoaSoGCN").ToString) Then
                        If dtThongTinTraGCN.Rows(0).Item("KhoaSoGCN").ToString = "True" Then
                            chkKhoaSoGCN.Checked = True
                        Else
                            chkKhoaSoGCN.Checked = False
                        End If
                    Else
                        chkKhoaSoGCN.Checked = True
                    End If
                End If
            End If

        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Thông tin Trả GCN " & vbNewLine & " Lỗi: " & vbNewLine & ex.Message, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub

    Public Sub UpdateData()
        'Khai báo và khởi tạo đối tượng
        Dim ThongTinTraGCN As New clsThongTinTraGCN
        Try
            'Xác nhận giá trị cần cập nhật
            With ThongTinTraGCN
                'Nhận chuỗi kết nối Database
                .Connection = strConnection
                .MaHoSoCapGCN = strMaHoSoCapGCN
                .Flag = strFlag
                If Me.dtpNgayTraGCN.Checked Then
                    .NgayTraGCN = Me.dtpNgayTraGCN.Text
                Else
                    .NgayTraGCN = Nothing
                End If
                If Me.dtpNgayHoanTatGCN.Checked Then
                    .NgayHoanTatGCN = Me.dtpNgayHoanTatGCN.Text
                Else
                    .NgayHoanTatGCN = Nothing
                End If

                If radChuaXuLy.Checked Then
                    .TrangThaiTra = "8"
                ElseIf radChuaTraGCN.Checked Then
                    .TrangThaiTra = "81"
                Else
                    .TrangThaiTra = "82"
                End If
                .YKienTraGCN = txtYKienTraGCN.Text.Trim

                If Me.chkKhoaSoGCN.Checked Then
                    .KhoaSoGCN = "1"
                Else
                    .KhoaSoGCN = "0"
                End If
                Dim str As String = ""
                'Trường hợp sửa 
                If shortAction = 2 Then
                    ThongTinTraGCN.UpdateThongTinTraGCNByMaHoSoCapGCN()
                    'strThongTinCu = "Ngày trả:" & dtpNgayTraGCN.Text & " - Ngày hoàn tất: " & dtpNgayHoanTatGCN.Text
                    NhatKyNguoiDung("Cập nhật", "Ngày trả:" & dtpNgayTraGCN.Text & " - Ngày hoàn tất: " & dtpNgayHoanTatGCN.Text)
                ElseIf shortAction = 3 Then
                    ThongTinTraGCN.DeleteThongTinTraGCNByMaHoSoCapGCN()
                    NhatKyNguoiDung("Xóa", "Ngày trả:" & dtpNgayTraGCN.Text & " - Ngày hoàn tất: " & dtpNgayHoanTatGCN.Text)
                    'Xoa du lieu tren Form doi voi truong hop xoa du lieu
                    TrangThaiBanDau()
                End If
                shortAction = 0
                strError = .Err
            End With
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Cập nhật Thông tin Trả GCN " & vbNewLine & " Lỗi: " & vbNewLine & strError, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub
    Public Sub NhatKyNguoiDung(ByVal ChucNang As String, ByVal MoTa As String)
        Dim clsNhatky As New prjNhatKyNguoiDung.clsNhatKyNguoiDung
        clsNhatky.Connection = strConnection
        clsNhatky.MaHoSoCapGCN = strMaHoSoCapGCN
        clsNhatky.MaDonViHanhChinh = strMaDonViHanhChinh
        clsNhatky.NghiepVu = "Thông tin trả GCN"
        clsNhatky.ChucNang = ChucNang
        clsNhatky.MoTa = MoTa
        clsNhatky.DuongDanFile = Application.StartupPath
        clsNhatky.LuuNhatKyNguoiDung()
    End Sub
    Public Sub TrangThaiCapNhat(Optional ByVal blnCapNhat As Boolean = False)
        With Me
            .dtpNgayTraGCN.Enabled = blnCapNhat
            .dtpNgayHoanTatGCN.Enabled = blnCapNhat
            .radChuaTraGCN.Enabled = blnCapNhat
            .radChuaXuLy.Enabled = blnCapNhat
            .radDaTraGCN.Enabled = blnCapNhat
            .txtYKienTraGCN.ReadOnly = Not blnCapNhat
            .chkKhoaSoGCN.Enabled = blnCapNhat
        End With
    End Sub

    Public Sub TrangThaiBanDau()
        With Me
            dtThongTinTraGCN.Clear()
            .dtpNgayTraGCN.Value = Date.Now
            .dtpNgayTraGCN.Checked = False
            .dtpNgayHoanTatGCN.Value = Date.Now
            .dtpNgayHoanTatGCN.Checked = False
            .chkKhoaSoGCN.Checked = False
        End With
    End Sub

    Public Sub TrangThaiChucNang(Optional ByVal blnStartEdited As Boolean = False, Optional ByVal blnStartDeleted As Boolean = False)
        With Me
            If Me.MaLoaiBienDong <> "MG" Then
                Me.GroupBox2.Enabled = True
                .btnSua.Enabled = Not blnStartEdited
                .btnGhi.Enabled = blnStartEdited
                .btnHuyLenh.Enabled = blnStartEdited
                If blnStartDeleted Then
                    .btnGhi.Enabled = Not blnStartDeleted
                    .btnHuyLenh.Enabled = Not blnStartDeleted
                End If
            Else
                Me.GroupBox2.Enabled = False
            End If
           
        End With
    End Sub


    Private Sub btnSua_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSua.Click
        shortAction = 2
        With Me
            'Trạng thái chức năng
            .TrangThaiChucNang(True)
            'Trạng thái cập nhật
            .TrangThaiCapNhat(True)
            strThongTinCu = "Ngày trả:" & dtpNgayTraGCN.Text & " - Ngày hoàn tất: " & dtpNgayHoanTatGCN.Text
        End With
    End Sub

    Private Sub btnGhi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGhi.Click
        Try
            'Cập nhật thông báo cấp GCN
            Me.UpdateData()
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Cập nhật Thông tin Trả GCN " & vbNewLine & " Lỗi: " & vbNewLine & ex.Message, MsgBoxStyle.Information, "DMCLand")
        End Try
        'Trạng thái chức năng
        Me.TrangThaiChucNang()
        'Trạng thái cập nhật
        Me.TrangThaiCapNhat()
        'Hiển thị dữ liệu
        Me.ShowData()
        If (strError = "") Then
            MsgBox(" Bạn đã cập nhật thành công!", MsgBoxStyle.Information, "DMCLand")
        Else
            MsgBox(" Cập nhật chưa thành công!", MsgBoxStyle.Critical, "DMCLand")
        End If
        strError = ""
    End Sub

    Private Sub ctrlThongBaoCapGCN_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        With Me
            With .dtpNgayTraGCN
                .CustomFormat = "dd/MM/yyyy"
                .Format = DateTimePickerFormat.Custom
                .ShowCheckBox = True
            End With
            With .dtpNgayHoanTatGCN
                .CustomFormat = "dd/MM/yyyy"
                .Format = DateTimePickerFormat.Custom
                .ShowCheckBox = True
            End With
            'Trạng thái cấp GCN
            .TrangThaiCapNhat()
            'Trạng thái chức năng
            .TrangThaiChucNang(True, True)
        End With
    End Sub

    Private Sub btnHuyLenh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHuyLenh.Click
        With Me
            'Xóa dữ liệu trên Form Form
            .TrangThaiBanDau()
            'Hiển thị dữ liệu
            If strMaHoSoCapGCN <> "" Then
                .ShowData()
            End If
            'Trạng thái chức năng
            .TrangThaiChucNang()
            'Trạng thái cập nhật
            .TrangThaiCapNhat()
        End With
        shortAction = 0
    End Sub

End Class
