Public Class frmNhatKyNguoiDung
    Private strConnection As String
    Public Property Connection() As String
        Get
            Return strConnection
        End Get
        Set(ByVal value As String)
            strConnection = value
        End Set
    End Property

    Public Sub showdata()
        Dim cls As New clsHoSoCapGCN
        Dim dt As New DataTable
        cls.Connection = strConnection
        cls.UserName = txtNguoiDung.Text.Trim
        If dtpNgay.Checked Then
            cls.NgaySuDung = dtpNgay.Text
        Else

            cls.NgaySuDung = Nothing
        End If
        cls.ToBanDo = txtToBanDo.Text
        cls.SoThua = txtSoHieuThua.Text
        cls.MaDonViHanhChinh = User.DonViHanhChinhHienThoi
        cls.SelectNhatKyNguoiDung(dt)
        grdDanhSachCongViec.DataSource = dt
        FormatGrid()
    End Sub
    Public Sub FormatGrid()
        With grdDanhSachCongViec
            'LogID, ThoiGian, UserName, MaDonViHanhChinh, NghiepVu, ToBanDo, SoThua, ChuSuDung, ChucNang,MoTa, KetQua
            .Columns("LogID").Visible = False
            .Columns("ThoiGian").HeaderText = "Thời điểm"
            .Columns("UserName").HeaderText = "Người dùng"
            .Columns("MaDonViHanhChinh").HeaderText = "Phường"
            .Columns("NghiepVu").HeaderText = "Chức năng"
            .Columns("ToBanDo").HeaderText = "Tờ bản đồ"
            .Columns("SoThua").HeaderText = "Số thửa"
            .Columns("ChuSuDung").HeaderText = "Chủ sử dụng"
            .Columns("ChucNang").HeaderText = "Thao tác"
            .Columns("MoTa").HeaderText = "Mô tả"
        End With
    End Sub


    Private Sub cmdThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdThoat.Click
        Me.Close()
    End Sub

    Private Sub cmdTim_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTim.Click
        Try
            showdata()
            If Not grdDanhSachCongViec.DataSource Is Nothing Then
                With CtrFilterGrid1
                    .MyGrid = grdDanhSachCongViec
                    .MydataTable = Nothing
                    .MydataTable = grdDanhSachCongViec.DataSource
                    .TaoContol()
                End With
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub grdDanhSachCongViec_ColumnWidthChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewColumnEventArgs) Handles grdDanhSachCongViec.ColumnWidthChanged
        CtrFilterGrid1.TaoContol()
    End Sub

    Private Sub frmNhatKyNguoiDung_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        With Me
            With .dtpNgay
                .CustomFormat = "dd/MM/yyyy"
                .Format = DateTimePickerFormat.Custom
                .ShowCheckBox = True
            End With
        End With
    End Sub
End Class