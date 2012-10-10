Public Class ctrLichSuHSBienDong
    Private strConnection As String = ""
    Private strError As String = ""
    Private strMaDangKyBienDong As String = ""
    Private strMaHoSoCapGCN As String = ""
    Private strMaThuaDat As String = ""
    Private strMaDonViHanhChinh As String 


    Public Property MaDonViHanhChinh() As String
        Get
            Return strMaDonViHanhChinh
        End Get
        Set(ByVal value As String)
            strMaDonViHanhChinh = value
        End Set
    End Property
    Public Property Connection() As String
        Get
            Return strConnection
        End Get
        Set(ByVal value As String)
            strConnection = value
        End Set
    End Property
    Public Property MyError() As String
        Get
            Return strError
        End Get
        Set(ByVal value As String)
            strError = value
        End Set
    End Property
    Public Property MaDangKyBienDong() As String

        Get
            Return strMaDangKyBienDong
        End Get
        Set(ByVal value As String)
            strMaDangKyBienDong = value
        End Set
    End Property
    Public Property MaHoSoCapGCN() As String
        Get
            Return strMaHoSoCapGCN
        End Get
        Set(ByVal value As String)
            strMaHoSoCapGCN = value
        End Set
    End Property
    Public Property MaThuaDat() As String
        Get
            Return strMaThuaDat
        End Get
        Set(ByVal value As String)
            strMaThuaDat = value
        End Set
    End Property

    Public Sub ShowData()
        Dim cls As New clsLichSuHSBienDong
        cls.MaThuaDat = strMaThuaDat
        cls.Connection = strConnection
        cls.MaHoSoCapGCN = strMaHoSoCapGCN
        cls.MaDonViHanhChinh = strMaDonViHanhChinh
        Dim dt As New DataTable
        cls.selDanhSachBienDong(dt)
        grdDanhSachBienDong.DataSource = dt
        ChangTile()
    End Sub
    Public Sub ChangTile()
        With grdDanhSachBienDong
            .Columns("MaDangKyBienDong").Visible = False
            .Columns("MaThuaDat").Visible = False
            .Columns("MaHoSoCapGCN").Visible = False
            .Columns("Tobando").HeaderText = "Tờ bản đồ"
            .Columns("SoThua").HeaderText = "Số thửa"
            .Columns("Dientich").HeaderText = "Diện tích"
            .Columns("ThoiDiemDangKy").HeaderText = "Thời điểm ĐK"
            .Columns("NoiDung").HeaderText = "Nội dung"
        End With
    End Sub
    Public Sub NhatKyNguoiDung(ByVal ChucNang As String, ByVal MoTa As String)
        Dim clsNhatky As New prjNhatKyNguoiDung.clsNhatKyNguoiDung
        clsNhatky.Connection = strConnection
        clsNhatky.MaHoSoCapGCN = strMaHoSoCapGCN
        clsNhatky.MaThuaDat = grdDanhSachBienDong.CurrentRow.Cells("MaThuaDat").Value
        clsNhatky.MaDonViHanhChinh = strMaDonViHanhChinh
        clsNhatky.NghiepVu = "Cập nhật hạng mục công trình"
        clsNhatky.ChucNang = ChucNang
        clsNhatky.MoTa = MoTa
        clsNhatky.DuongDanFile = Application.StartupPath
        clsNhatky.LuuNhatKyNguoiDung()
    End Sub
    Private Sub grdDanhSachBienDong_CellMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grdDanhSachBienDong.CellMouseClick
        If e.RowIndex >= 0 Then
            Dim strMaHS As String = ""
            strMaHS = grdDanhSachBienDong.Rows(e.RowIndex).Cells("MaHoSoCapGCN").Value
            Dim strThuaDat As String = ""
            strThuaDat = grdDanhSachBienDong.Rows(e.RowIndex).Cells("MaThuaDat").Value
            Dim cls As New clsLichSuHSBienDong
            cls.Connection = strConnection
            cls.MaHoSoCapGCN = strMaHS
            cls.MaThuaDat = strThuaDat
            cls.MaDonViHanhChinh = strMaDonViHanhChinh
            cls.MaBienDong = grdDanhSachBienDong.Rows(e.RowIndex).Cells("MaDangKyBienDong").Value
            Dim dt As New DataTable
            cls.selThongTinHoSoBienDong(dt)
            Dim strNoiDungBienDong As String = "" & vbNewLine
            strNoiDungBienDong = strNoiDungBienDong & "Thời điểm biến động: " & dt.Rows(0).Item("ThoiDiemDangKy") & vbNewLine
            strNoiDungBienDong = strNoiDungBienDong & "Nội dung biến động: " & dt.Rows(0).Item("NoidungSoDiaChinh") & vbNewLine
            strNoiDungBienDong = strNoiDungBienDong & "Tờ bản đồ: " & dt.Rows(0).Item("ToBanDo") & vbNewLine
            strNoiDungBienDong = strNoiDungBienDong & "Số thửa" & dt.Rows(0).Item("SoThua") & vbNewLine
            strNoiDungBienDong = strNoiDungBienDong & "Địa chỉ : " & dt.Rows(0).Item("DiaChi") & vbNewLine
            strNoiDungBienDong = strNoiDungBienDong & "Diện tích: " & dt.Rows(0).Item("DienTich") & vbNewLine
            strNoiDungBienDong = strNoiDungBienDong & "Họ tên: " & dt.Rows(0).Item("HoTen") & vbNewLine
            RTNoiDungBienDong.Text = strNoiDungBienDong
            Dim ob() As Byte
            If Not IsDBNull(dt.Rows(0).Item("HoSoKiThuatThamDinh")) Then
                ob = dt.Rows(0).Item("HoSoKiThuatThamDinh")
                Dim bm As Image
                bm = Image.FromStream(New System.IO.MemoryStream(ob))
                Dim myBitmap = New Bitmap(bm)
                Clipboard.SetDataObject(myBitmap)
                Dim format = DataFormats.GetFormat(DataFormats.Bitmap)
                RTNoiDungBienDong.Paste(format)
            End If

            NhatKyNguoiDung("Hiển thị báo cáo", strNoiDungBienDong)

        End If
    End Sub
    
End Class
