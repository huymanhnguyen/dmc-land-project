Imports System.Windows.Forms

Public Class ctrlThongBaoCapGCN
    'Khai báo biến nhận chuỗi kết nối Database
    Private strConnection As String = ""
    'Khai báo biến kiểm tra lỗi
    Private strError As String = ""
    'Khai bao bien MaHoSoCapGCN dung chung
    Private strMaHoSoCapGCN As String = ""
    Private dtThongBaoCapGCN As New DataTable
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
    Private MaLoaiBienDong As String = ""
    Public Property MaKhoa() As String
        Get
            Return MaLoaiBienDong
        End Get
        Set(ByVal value As String)
            MaLoaiBienDong = value
        End Set
    End Property

    '
    Public Sub ShowData()
        If Me.MaLoaiBienDong <> "MG" Then
            Me.GroupBox2.Enabled = True
        Else
            Me.GroupBox2.Enabled = False

        End If
        'Khai bao va khoi tao doi tuong clsPheDuyet
        Dim SoQuanLy As New clsThongBaoCapGCN
        Try
            'Gan gia tri cho cac thuoc tinh doi voi truong hop truy van
            With SoQuanLy
                'Nhận chuỗi kết nối Database
                .Connection = strConnection
                .MaHoSoCapGCN = strMaHoSoCapGCN
            End With
            'Khởi tạo trạng thái ban đầu
            TrangThaiBanDau()
            'Goi phuong thuc GetData de khoi tao doi tuong
            If SoQuanLy.GetData(dtThongBaoCapGCN) = "" Then
                ' Trinh bay du lieu
                If dtThongBaoCapGCN.Rows.Count > 0 Then
                    If Not IsDate(dtThongBaoCapGCN.Rows(0).Item("NgayThongBaoUBND").ToString) Then
                        Me.dtpNgayThongBaoUBND.Value = Date.Now.Date
                        Me.dtpNgayThongBaoUBND.Checked = False
                    Else
                        Me.dtpNgayThongBaoUBND.Value = Convert.ToDateTime(dtThongBaoCapGCN.Rows(0).Item("NgayThongBaoUBND").ToString)
                        Me.dtpNgayThongBaoUBND.Checked = True
                    End If
                End If
                If dtThongBaoCapGCN.Rows.Count > 0 Then
                    If Not IsDate(dtThongBaoCapGCN.Rows(0).Item("NgayCongDanNhanThongBao").ToString) Then
                        Me.dtpNgayCongDanNhanThongBao.Value = Date.Now.Date
                        Me.dtpNgayCongDanNhanThongBao.Checked = False
                    Else
                        Me.dtpNgayCongDanNhanThongBao.Value = Convert.ToDateTime(dtThongBaoCapGCN.Rows(0).Item("NgayCongDanNhanThongBao").ToString)
                        Me.dtpNgayCongDanNhanThongBao.Checked = True
                    End If
                End If
            End If
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Thông báo Cấp GCN " & vbNewLine & " Lỗi: " & vbNewLine & ex.Message, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub

    Public Sub UpdateData()
        'Khai bao va khoi tao doi tuong cls
        Dim ThongBaoCapGCN As New clsThongBaoCapGCN
        Try
            'Xac nhan gia tri can cap nhat
            With ThongBaoCapGCN
                'Nhận chuỗi kết nối Database
                .Connection = strConnection
                .MaHoSoCapGCN = strMaHoSoCapGCN
                If Me.dtpNgayThongBaoUBND.Checked Then
                    .NgayThongBaoUBND = Me.dtpNgayThongBaoUBND.Text
                Else
                    .NgayThongBaoUBND = Nothing
                End If
                If Me.dtpNgayCongDanNhanThongBao.Checked Then
                    .NgayCongDanNhanThongBao = Me.dtpNgayCongDanNhanThongBao.Text
                Else
                    .NgayCongDanNhanThongBao = Nothing
                End If
                Dim str As String = ""
                'Trường hợp sửa 
                If shortAction = 2 Then
                    ThongBaoCapGCN.UpdateThongBaoCapGCNByMaHoSoCapGCN()
                ElseIf shortAction = 3 Then
                    ThongBaoCapGCN.DeleteThongBaoCapGCNByMaHoSoCapGCN()
                    'Xoa du lieu tren Form doi voi truong hop xoa du lieu
                    TrangThaiBanDau()
                End If
                shortAction = 0
                strError = .Err
            End With
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Cập nhật Thông báo Cấp GCN " & vbNewLine & " Lỗi: " & vbNewLine & strError, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub

    Public Sub TrangThaiCapNhat(Optional ByVal blnCapNhat As Boolean = False)
        With Me
            .dtpNgayThongBaoUBND.Enabled = blnCapNhat
            .dtpNgayCongDanNhanThongBao.Enabled = blnCapNhat
        End With
    End Sub

    Public Sub TrangThaiBanDau()
        With Me
            dtThongBaoCapGCN.Clear()
            .dtpNgayThongBaoUBND.Value = Date.Now
            .dtpNgayThongBaoUBND.Checked = False
            .dtpNgayCongDanNhanThongBao.Value = Date.Now
            .dtpNgayCongDanNhanThongBao.Checked = False
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
            'Trang thai chuc nang
            .TrangThaiChucNang(True)
            'Trang thai cap nhat
            .TrangThaiCapNhat(True)
        End With
    End Sub

    'Private Sub btnXoa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXoa.Click
    '    If strMaHoSoCapGCN <> "" Then
    '        If MsgBox("Bạn chắc chắn muốn xóa không?", MsgBoxStyle.YesNo, "DMCLand!") = MsgBoxResult.Yes Then
    '            With Me
    '                shortAction = 3
    '                .UpdateData()
    '                'Trang thai ban dau
    '                .TrangThaiBanDau()
    '                'Trang thai chuc nang
    '                .TrangThaiChucNang(True, True)
    '            End With
    '            If (strError = "") Then
    '                MsgBox(" Bạn đã cập nhật thành công!", MsgBoxStyle.Information, "DMCLand")
    '            Else
    '                MsgBox(" Cập nhật chưa thành công!", MsgBoxStyle.Critical, "DMCLand")
    '            End If
    '        Else
    '            'Trang thai chuc nang
    '            Me.TrangThaiChucNang()
    '        End If
    '    End If
    '    'Trang thai cap nhat 
    '    Me.TrangThaiCapNhat()
    '    strError = ""
    'End Sub

    Private Sub btnGhi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGhi.Click
        Try
            'Cập nhật thông báo cấp GCN
            Me.UpdateData()
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Cập nhật Thông báo cấp GCN " & vbNewLine & " Lỗi: " & vbNewLine & ex.Message, MsgBoxStyle.Information, "DMCLand")
        End Try
        'Trang thai chuc nang
        Me.TrangThaiChucNang()
        'Trang thai cap nhat
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
            '.BackColor = Color.LightBlue
            'Active chuc nang phe duyet
            With .dtpNgayThongBaoUBND
                .CustomFormat = "dd/MM/yyyy"
                .Format = DateTimePickerFormat.Custom
                .ShowCheckBox = True
            End With
            With .dtpNgayCongDanNhanThongBao
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
        shortAction = 0
    End Sub


    Private Sub btnInThongBao_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInThongBao.Click
        Dim ThongBaoCapGCN As New frmReportThongBaoCapGCN
        ThongBaoCapGCN.CtrInThongBaoCapGCN1.Conection = strConnection
        ThongBaoCapGCN.CtrInThongBaoCapGCN1.MaHoSoCapGCN = strMaHoSoCapGCN
        ThongBaoCapGCN.CtrInThongBaoCapGCN1.NgayThongBao = "Hà Nội, ngày " & dtpNgayThongBaoUBND.Value.Day.ToString & " tháng " & dtpNgayThongBaoUBND.Value.Month.ToString & " năm " & dtpNgayThongBaoUBND.Value.Year.ToString
        'Thiết lập chế độ hiển thị lên toàn màn hình
        ThongBaoCapGCN.WindowState = FormWindowState.Maximized
        ThongBaoCapGCN.ShowDialog()
    End Sub
End Class
