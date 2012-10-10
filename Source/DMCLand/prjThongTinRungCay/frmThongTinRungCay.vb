Public Class frmThongTinRungCay
    Private strMaHoSoCapGCN As String = ""
    Private dtThongTinRungCay As New DataTable
    Private blnNonNumberEntered As Boolean
    'Khai báo nhận Tên đơn vị hành chính
    Private strTenDonViHanhChinh As String = ""
    'Khai báo biến nhận chuỗi kết nối Database
    Private strConnection As String = ""
    'Khai báo biến kiểm tra lỗi
    Private strError As String = ""
    Private strMaThongTinRungCay As String = ""
    Private shAction As Short = 0
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
            shAction = value
        End Set
    End Property
    Public WriteOnly Property MaHoSoCapGCN() As String
        Set(ByVal value As String)
            strMaHoSoCapGCN = value
        End Set
    End Property
    Public Property MaThongTinRungCay() As String
        Get
            Return strMaThongTinRungCay
        End Get
        Set(ByVal value As String)
            strMaThongTinRungCay = value
        End Set
    End Property
    Public Sub TrangThaiBanDau(Optional ByVal blnClearGrid As Boolean = False)
        With Me
            'Thiet lap tren Form nhap lieu
            .txtNguonGocTaoLap.Text = ""
            .numDienTichCoRung.Text = ""
            .txtSoHoSoGiaoRung.Text = ""
        End With
    End Sub


    Public Sub UpdateData()
        'Khai báo và khởi tạo đối tượng clsThongTinRungCay
        Dim ThongTinRungCay As New DMC.Land.ThongTinRungCay.clsThongTinRungCay
        Try
            With ThongTinRungCay
                'Nhận chuỗi kết nối cơ sở dữ liệu
                .Connection = strConnection
                .MaHoSoCapGCN = strMaHoSoCapGCN
                .MaThongTinRungCay = strMaThongTinRungCay
                If txtNguonGocTaoLap IsNot Nothing Then
                    .NguonGocTaoLap = txtNguonGocTaoLap.Text
                Else
                    .NguonGocTaoLap = ""
                End If
                .SoHoSoGiaoRung = txtSoHoSoGiaoRung.Text
                If IsNumeric(numDienTichCoRung.Text.Trim) Then
                    .DienTichCoRung = numDienTichCoRung.Text
                Else
                    .DienTichCoRung = Nothing
                End If

                Dim str As String = ""
                Dim strResults As String = ""
                If (shAction = 1) Then
                    strResults = .InsertThongTinRungCay(str)
                ElseIf (shAction = 2) Then
                    strResults = .UpdateThongTinRungCay(str)
                End If

                If strResults = "OK" Then
                    Me.Hide()
                    shAction = 0
                End If

                strError = ThongTinRungCay.Err
            End With
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Thông tin Rừng cây " & vbNewLine & " Cập nhật " & vbNewLine & _
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
        strMaThongTinRungCay = ""
        strError = ""
        'Ẩn Form cập nhật
        Me.Hide()
    End Sub

    Private Sub btnHuyLenh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHuyLenh.Click
        With Me
            'Hien thi du lieu
            shAction = 0
            Me.Close()
        End With
    End Sub
End Class