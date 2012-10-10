Imports DMC.Database

Public Class ctrTongHopDatInBienBanXetDuyet
    Private strMaHoSoCapGCN As String = ""
    Private strConnection As String = ""
    Private strError As String = ""
    Private strMaDonViHanhChinh As String = ""

    'Khai báo thuộc tính nhận chuỗi kết nối
    Public Property Connection() As String
        Set(ByVal value As String)
            strConnection = value
        End Set
        Get
            Return strConnection
        End Get
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
    Public Property MaHoSoCapGCN() As String
        Set(ByVal value As String)
            strMaHoSoCapGCN = value
        End Set
        Get
            Return strMaHoSoCapGCN
        End Get
    End Property
    Public WriteOnly Property MaDonViHanhChinh() As String
        Set(ByVal value As String)
            strMaDonViHanhChinh = value
        End Set
    End Property
    Private Sub ctrTongHopDatInBienBanXetDuyet_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Leave
        TrangThaiCapNhat()
        'Trang thai chuc nang
        TrangThaiChucNang(True, True)
    End Sub
    Public Sub TrangThaiChucNang(Optional ByVal blnStartEdited As Boolean = False, Optional ByVal blnStartDeleted As Boolean = False)
        With Me
            If Me.MaLoaiBienDong <> "MG" Then
                Me.GroupBox3.Enabled = True
                .btnSua.Enabled = Not blnStartEdited
                .btnXoa.Enabled = Not blnStartEdited
                .btnCapNhat.Enabled = blnStartEdited
                .btnHuyLenh.Enabled = blnStartEdited
                If blnStartDeleted Then
                    .btnCapNhat.Enabled = Not blnStartDeleted
                    .btnHuyLenh.Enabled = Not blnStartDeleted
                End If
            Else
                Me.GroupBox3.Enabled = False
            End If
           
        End With
    End Sub
    Public Sub TrangThaiCapNhat(Optional ByVal blnCapNhat As Boolean = False)
        'Bật tắt trạng thái cập nhật dữ liệu của các điều khiển
        With Me
            .richTheoGiayTo.ReadOnly = Not blnCapNhat
            .richKhongTheoGiayTo.ReadOnly = Not blnCapNhat
            .richGiayToKhac.ReadOnly = Not blnCapNhat
            .richDeNghiCapDat.ReadOnly = Not blnCapNhat
            .richDeNghiCapTaiSan.ReadOnly = Not blnCapNhat
            If blnCapNhat Then
                .richTheoGiayTo.BackColor = Color.White
                .richKhongTheoGiayTo.BackColor = Color.White
                .richGiayToKhac.BackColor = Color.White
                .richDeNghiCapDat.BackColor = Color.White
                .richDeNghiCapTaiSan.BackColor = Color.White
            Else
                .richTheoGiayTo.BackColor = Color.LightYellow
                .richKhongTheoGiayTo.BackColor = Color.LightYellow
                .richGiayToKhac.BackColor = Color.LightYellow
                .richDeNghiCapDat.BackColor = Color.LightYellow
                .richDeNghiCapTaiSan.BackColor = Color.LightYellow
            End If
        End With
    End Sub

    Private Sub btnThem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThem.Click

        With Me
            'Trang thai cap nhat
            .TrangThaiCapNhat(True)
            'Trang thai chuc nang 
            .TrangThaiChucNang(True)
        End With
    End Sub
    Private Sub btnHuyLenh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHuyLenh.Click
        With Me
            'Hien thi du lieu
            If strMaHoSoCapGCN <> "" Then
                .ShowData()
            End If
            'Trang thai chuc nang
            .TrangThaiChucNang()
            'Trang thai cap nhat 
            .TrangThaiCapNhat()
        End With
    End Sub
    Private Sub btnSua_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSua.Click

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
                    .UpdateData(3)
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
            Me.UpdateData(1)
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
    Public Sub ShowData()
        If Me.MaLoaiBienDong <> "MG" Then
            Me.GroupBox3.Enabled = True
        Else
            Me.GroupBox3.Enabled = False

        End If
        'Khai bao va khoi tao doi tuong clsThongTinXetDuyet
        Dim ThongTinTongHop As New clsTongHopDatInBienBanXetDuyet
        Try
            With ThongTinTongHop
                'Gán chuỗi kết nối Database
                .Connection = strConnection
                .MaHoSoCapGCN = strMaHoSoCapGCN
            End With
            Dim dtTongHop As New DataTable
            'Goi phuong thuc GetData de khoi tao doi tuong clsHSKKTaiSan
            If ThongTinTongHop.GetData(dtTongHop) = "" Then
                ' Trinh bay du lieu len grdvwTaiSan
                If dtTongHop.Rows.Count > 0 Then
                    For i As Integer = 0 To dtTongHop.Rows.Count - 1
                        With dtTongHop.Rows(i)
                            If Not IsDBNull(.Item("TongHopTheoGiayTo").ToString) And .Item("TongHopTheoGiayTo").ToString <> "" Then
                                Me.richTheoGiayTo.Text = .Item("TongHopTheoGiayTo").ToString
                            End If
                            'Ý kiến cán bộ xét duyệt
                            If Not IsDBNull(.Item("TongHopKhongTheoGiayTo").ToString) And .Item("TongHopKhongTheoGiayTo").ToString <> "" Then
                                Me.richKhongTheoGiayTo.Text = .Item("TongHopKhongTheoGiayTo").ToString
                            End If
                            'Kết quả  xét duyệt
                            If Not IsDBNull(.Item("TongHopGiayToKhac").ToString) And .Item("TongHopGiayToKhac").ToString <> "" Then
                                Me.richGiayToKhac.Text = .Item("TongHopGiayToKhac").ToString
                            End If
                            If Not IsDBNull(.Item("DeNghiCapDat").ToString) And .Item("DeNghiCapDat").ToString <> "" Then
                                Me.richDeNghiCapDat.Text = .Item("DeNghiCapDat").ToString
                            End If
                            If Not IsDBNull(.Item("DeNghiCapTaiSan").ToString) And .Item("DeNghiCapTaiSan").ToString <> "" Then
                                Me.richDeNghiCapTaiSan.Text = .Item("DeNghiCapTaiSan").ToString
                            End If
                        End With
                    Next i
                End If
            End If
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Hiển thị dữ liệu Tổng hợp thông tin đất để in biên bản xét duyệt " & vbNewLine & " Lỗi: " & vbNewLine & ex.Message, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub
    Public Sub UpdateData(ByVal flag As Integer)
        'Khai bao va khoi tao doi tuong clsThongTinXetDuyet
        Dim ThongTinTongHop As New clsTongHopDatInBienBanXetDuyet
        Try
            'Xac nhan gia tri can cap nhat
            With ThongTinTongHop
                'Gán chuỗi kết nối Database
                .Connection = strConnection

                .MaHoSoCapGCN = strMaHoSoCapGCN
                .TheoGiayTo = richTheoGiayTo.Text
                .KhongTheoGiayTo = Me.richKhongTheoGiayTo.Text
                .GiayToKhac = Me.richGiayToKhac.Text
                .DeNghiCapDat = Me.richDeNghiCapDat.Text.Trim
                .DeNghiCapTaiSan = Me.richDeNghiCapTaiSan.Text.Trim
                Dim str As String = ""
                'Neu cap nhat thanh cong
                If .Execute(str, flag) = "" Then
                End If
                strError = .Err
            End With
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Cập nhật dữ liệu Thông tin xét duyệt " & vbNewLine & " Lỗi: " & vbNewLine & ex.Message, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub

End Class
