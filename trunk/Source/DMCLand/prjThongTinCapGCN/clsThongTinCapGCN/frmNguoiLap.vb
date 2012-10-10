Public Class frmNguoiLap
    Private strConnection As String = "" 'Khai báo biến nhận chuỗi kết nối
    Private strError As String = "" 'Khai bao bien kiem tra loi
    Private strNguoiLap As String = ""
    Private shFlag As Short = 0
    Private ChucNang As String = ""
    Private strMaNguoiLap As String = ""
    'Khai báo thuộc tính nhận chuỗi kết nối Database
    Public WriteOnly Property Connection() As String
        Set(ByVal value As String)
            strConnection = value
        End Set
    End Property
    Public Property NguoiLap() As String
        Get
            Return strNguoiLap
        End Get
        Set(ByVal value As String)
            strNguoiLap = value
        End Set
    End Property
    Public WriteOnly Property Flag() As String
        Set(ByVal value As String)
            shFlag = value
        End Set
    End Property
    Private Sub frmNguoiLap_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SuLyNut(False)
        ShowData()
    End Sub

    Public Sub ShowData()

        'Khai bao va khoi tao doi tuong clsThongTinCapGCN
        Dim ThongTinCapGCN As New clsThongTinCapGCN
        Try
            'Gan gia tri cho cac thuoc tinh doi voi truong hop truy van
            With ThongTinCapGCN
                .Connection = strConnection
                .flag = "1"
            End With

            'Goi phuong thuc GetData de khoi tao doi tuong clsHSKKTaiSan
            Dim dtThongTinNguoilap As DataTable
            dtThongTinNguoilap = ThongTinCapGCN.SelectNguoiLap()
            ' Trinh bay du lieu len grdvwTaiSan
            If dtThongTinNguoilap.Rows.Count > 0 Then
                grdNguoiLapBieu.DataSource = dtThongTinNguoilap
                AddColumnsTongHop()
            End If
        Catch ex As Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub AddColumnsTongHop()

        With grdNguoiLapBieu
            .BorderStyle = Windows.Forms.BorderStyle.Fixed3D
            .RowHeadersVisible = False
            .ColumnHeadersDefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleCenter


            .Columns("MaNguoiLap").Visible = False
            .Columns("HoTen").HeaderText = "Họ tên"
            .Columns("GioiTinh").HeaderText = "Giới tính"
            .Columns("ChucVu").HeaderText = "Chức vụ"

            .Columns("HoTen").Width = 300
            .Columns("GioiTinh").Width = 100
            .Columns("ChucVu").Width = 200

            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .ClearSelection()
        End With
    End Sub

    Public Sub SuLyNut(ByVal update As Boolean)
        cmdGhi.Enabled = update
        cmdHuy.Enabled = update
        cmdThem.Enabled = Not update
        cmdSua.Enabled = Not update
        cmdXoa.Enabled = Not update
        grdNguoiLapBieu.Enabled = Not update
        txtHoTen.ReadOnly = Not update
        cboGioiTinh.Enabled = update
        txtChucVu.ReadOnly = Not update
    End Sub

    Private Sub cmdThem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdThem.Click

        SuLyNut(True)
        ChucNang = "them".ToUpper
    End Sub

    Private Sub cmdSua_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSua.Click
        SuLyNut(True)
        ChucNang = "sua".ToUpper
    End Sub

    Private Sub cmdGhi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGhi.Click
        GhiDuLieu()
    End Sub

    Private Sub cmdHuy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdHuy.Click
        SuLyNut(False)
    End Sub


    Private Sub grdNguoiLapBieu_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdNguoiLapBieu.CellDoubleClick
        If grdNguoiLapBieu.Rows.Count > 0 Then
            strNguoiLap = grdNguoiLapBieu.Rows(e.RowIndex).Cells("HoTen").Value
            Me.Hide()
        End If
    End Sub

    Public Sub GhiDuLieu()
        'Khai bao va khoi tao doi tuong clsThongTinCapGCN
        Dim ThongTinCapGCN As New clsThongTinCapGCN
        Try
            'Gan gia tri cho cac thuoc tinh doi voi truong hop truy van
            With ThongTinCapGCN
                .Connection = strConnection
                If txtHoTen.Text = "" Then
                    System.Windows.Forms.MessageBox.Show("Nhập thông tin họ tên")
                    txtHoTen.Focus()
                    Exit Sub
                End If
                .HoTen = txtHoTen.Text
                .GioiTinh = cboGioiTinh.Text
                .ChucVu = txtChucVu.Text
                .MaNguoilap = strMaNguoiLap
            End With
            If ChucNang = "them".ToUpper() Then
                ThongTinCapGCN.flag = 2
                ThongTinCapGCN.ThemNguoiLap()
                SuLyNut(False)
            End If
            If ChucNang = "sua".ToUpper() Then
                ThongTinCapGCN.flag = 3
                ThongTinCapGCN.SuaNguoiLap()
                SuLyNut(False)
            End If

        Catch ex As Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
        End Try


    End Sub

    Private Sub cmdXoa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdXoa.Click
        Dim ThongTinCapGCN As New clsThongTinCapGCN
        Try
            If strNguoiLap <> "" Then
                'Gan gia tri cho cac thuoc tinh doi voi truong hop truy van
                With ThongTinCapGCN
                    .Connection = strConnection
                    .flag = "4"
                    .MaNguoilap = strMaNguoiLap
                    If txtHoTen.Text = "" Then
                        System.Windows.Forms.MessageBox.Show("Nhập thông tin họ tên")
                        txtHoTen.Focus()
                        Exit Sub
                    End If
                End With
                ThongTinCapGCN.ThemNguoiLap()
                SuLyNut(False)
            End If
        Catch ex As Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
        End Try
    End Sub


    Private Sub grdNguoiLapBieu_CellMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grdNguoiLapBieu.CellMouseClick
        If grdNguoiLapBieu.Rows.Count > 0 Then
            strMaNguoiLap = grdNguoiLapBieu.Rows(e.RowIndex).Cells("MaNguoiLap").Value
            txtHoTen.Text = grdNguoiLapBieu.Rows(e.RowIndex).Cells("HoTen").Value
            cboGioiTinh.Text = grdNguoiLapBieu.Rows(e.RowIndex).Cells("GioiTinh").Value
            txtChucVu.Text = grdNguoiLapBieu.Rows(e.RowIndex).Cells("ChucVu").Value
        End If
    End Sub
End Class