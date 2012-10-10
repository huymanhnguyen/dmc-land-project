Public Class fromTuDienSoNgayQuanLyQuyTrinh
    Private strConnection As String = ""
    Private strError As String = ""
    Private strMaSoNgayQUanLy As String = ""
    Private shortAction As Short = 0

    Private strTenLoaiHS As String = ""

    Public Property TenLoaiHS() As String
        Get
            Return strTenLoaiHS
        End Get
        Set(ByVal value As String)
            strTenLoaiHS = value
        End Set
    End Property

    Private strMaLoaiHS As String = ""

    Public Property MaLoaiHS() As String
        Get
            Return strMaLoaiHS
        End Get
        Set(ByVal value As String)
            strMaLoaiHS = value
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


    Public Sub ShowData()

        Dim dt As New DataTable
        Dim cls As New clsQuanLyGiaoViec
        With cls
            .Connection = strConnection
            .MaLoaiHS = strMaLoaiHS
            dt = .selDanhSachSoNgayQuanLy()
            grdDanhSachCongViec.DataSource = dt
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To grdDanhSachCongViec.ColumnCount - 1
                    grdDanhSachCongViec.Columns(i).Visible = False
                Next
                grdDanhSachCongViec.Columns("SoTT").Visible = True
                grdDanhSachCongViec.Columns("SoTT").HeaderText = "Thứ tự"

                grdDanhSachCongViec.Columns("TenCongViec").Visible = True
                grdDanhSachCongViec.Columns("TenCongViec").HeaderText = "Tên công việc"

                grdDanhSachCongViec.Columns("SoNgayThucThi").Visible = True
                grdDanhSachCongViec.Columns("SoNgayThucThi").HeaderText = "Số ngày thực thi"

                grdDanhSachCongViec.Columns("BoPhan").Visible = True
                grdDanhSachCongViec.Columns("BoPhan").HeaderText = "Bộ phận"

                grdDanhSachCongViec.Columns("NgayApDung").Visible = True
                grdDanhSachCongViec.Columns("NgayApDung").HeaderText = "Ngày áp dụng"
                grdDanhSachCongViec.Columns("NgayApDung").DefaultCellStyle.Format = "dd/MM/yyyy"

                grdDanhSachCongViec.Columns("R").Visible = True
                grdDanhSachCongViec.Columns("G").Visible = True
                grdDanhSachCongViec.Columns("B").Visible = True
            End If
        End With
        'Trạng thái chức năng
        Me.TrangThaiChucNang()
        'Trạng thái cập nhật
        Me.TrangThaiCapNhat()
    End Sub
    Private Sub fromTuDienSoNgayQuanLyQuyTrinh_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            With Me
                .TrangThaiBanDau()
                'Trang thai cap nhat
                .TrangThaiCapNhat()
                'Trang thai chuc nang
                .TrangThaiChucNang()

                Me.dtpNgayApDung.CustomFormat = "dd/MM/yyyy"
                Me.dtpNgayApDung.Format = DateTimePickerFormat.Custom
                Me.dtpNgayApDung.ShowCheckBox = True
                LabTenLoaiHS.Text = strTenLoaiHS
                ShowData()

            End With
        Catch ex As Exception
            MsgBox(" Nạp dữ liệu ban đầu " & vbNewLine & " Thông tin số ngày quản lý quy trình " _
            & " Lỗi: " & ex.Message, MsgBoxStyle.Information, "DMCLand")
        End Try

    End Sub
    Public Sub TrangThaiCapNhat(Optional ByVal blnCapNhat As Boolean = False)
        With Me
            NumSoNgayThucThi.Enabled = blnCapNhat
            NumSoTT.Enabled = blnCapNhat
            txtTenCongViec.ReadOnly = Not blnCapNhat
            cboBoPhan.Enabled = blnCapNhat
            dtpNgayApDung.Enabled = blnCapNhat
        End With
    End Sub

    Public Sub TrangThaiBanDau(Optional ByVal blnClearGrid As Boolean = False)
        With Me
            NumSoNgayThucThi.Value = 0
            NumSoTT.Value = 0
            txtTenCongViec.Text = ""
            cboBoPhan.Text = ""
            dtpNgayApDung.Value = Now
        End With
    End Sub

    Public Sub TrangThaiChucNang(Optional ByVal blnStartEdited As Boolean = False, Optional ByVal blnStartDeleted As Boolean = False)
        With Me
            .btnSua.Enabled = Not blnStartEdited
            .btnXoa.Enabled = Not blnStartEdited
            .btnThem.Enabled = Not blnStartEdited
            .btnCapNhat.Enabled = blnStartEdited
            .btnHuyLenh.Enabled = blnStartEdited
            If blnStartDeleted Then
                .btnCapNhat.Enabled = Not blnStartDeleted
                .btnHuyLenh.Enabled = Not blnStartDeleted
            End If
        End With
    End Sub

    Private Sub btnThem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThem.Click
        With Me
            .shortAction = 1
            'Thiet lap trang thai ban dau
            .TrangThaiBanDau()
            'Trang thai cap nhat
            .TrangThaiCapNhat(True)
            'Trang thai chuc nang 
            .TrangThaiChucNang(True)
        End With
    End Sub

    Private Sub btnSua_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSua.Click
        If strMaSoNgayQUanLy <> "" Then
            shortAction = 2
            'Thiết lập trạng thái chức năng
            TrangThaiChucNang(True)
            'Thiết lập trạng thái cập nhật cho các điều khiển
            TrangThaiCapNhat(True)
        Else
            MsgBox("Chưa có thông tin!", MsgBoxStyle.Information, "DMCLand")
        End If
    End Sub

    Private Sub btnXoa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXoa.Click
        If strMaSoNgayQUanLy <> "" Then
            If MsgBox("Bạn chắc chắn muốn xóa không?", MsgBoxStyle.YesNo, "DMCLand!") = MsgBoxResult.Yes Then
                Try
                    With Me
                        .shortAction = 3
                        If Not UpdateData() Then
                            Return
                        End If
                        strMaSoNgayQUanLy = ""
                    End With
                Catch ex As Exception
                    strError = ex.Message
                End Try
                If (strError = "") Or (strError = "OK") Then
                    MsgBox(" Bạn đã cập nhật thành công!", MsgBoxStyle.Information, "DMCLand")
                Else
                    MsgBox(" Cập nhật chưa thành công!", MsgBoxStyle.Critical, "DMCLand")
                End If
            End If
        Else
            MsgBox(" Bạn chưa chọn thông tin cần xóa!", MsgBoxStyle.Information, "DMCLand")
        End If
        strError = ""
    End Sub

    Public Function UpdateData() As Boolean
        Dim kt As Boolean = False
        'Khai báo và khởi tạo đối tượng
        Dim cls As New clsQuanLyGiaoViec
        Try
            If txtMaMau.Text = "" Or txtMaMau.Text.Length < 3 Then
                MessageBox.Show("Hãy nhập màu cảnh báo", "DMCLand")
                Return False
            End If
            If txtTenCongViec.Text = "" Then
                MessageBox.Show("Hãy nhập Tên công việc", "DMCLand")
                Return False
            End If

            'Xác nhận bản ghi cần xóa
            With cls
                .Connection = strConnection 'Gán chuỗi kết nối cơ sở dữ liệu
                .MaSoNgayQUanLy = strMaSoNgayQUanLy
                .NgayApdung = dtpNgayApDung.Value.ToString
                .MaLoaiHS = strMaLoaiHS
                .STT = NumSoTT.Value.ToString
                .TenCongViec = txtTenCongViec.Text
                .BoPhan = cboBoPhan.Text
                .SoNgayThucThi = NumSoNgayThucThi.Value.ToString
                .R = PicMau.BackColor.R
                .G = PicMau.BackColor.G
                .B = PicMau.BackColor.B
            End With
            Dim str As String = ""
            If shortAction = 1 Then
                cls.InsSoNgayQuanLy(str)
            ElseIf shortAction = 2 Then
                cls.UpSoNgayQuanLy(str)
            ElseIf shortAction = 3 Then
                cls.delSoNgayQuanLy(str)
            End If
            ShowData()
            strError = cls.Err
            kt = True
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Cập nhật dữ liệu " & vbNewLine & " Thông tin thửa đất " _
                   & " Lỗi: " & strError, MsgBoxStyle.Information, "DMCLand")
            Return False
        End Try
        TrangThaiBanDau()
        shortAction = 0
        Return kt
    End Function

    Private Sub btnCapNhat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCapNhat.Click
        Try
            With Me
                'Cập nhật thông tin Thửa đất sử dụng
                If Not UpdateData() Then
                    Return
                End If
            End With
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Cập nhật dữ liệu " & vbNewLine & " Thửa đất sử dụng " & vbNewLine _
                & " Lỗi: " & strError, MsgBoxStyle.Information, "DMCLand")
        End Try
        If (strError = "") Or (strError = "OK") Then
            MsgBox(" Bạn đã cập nhật thành công!", MsgBoxStyle.Information, "DMCLand")
        Else
            MsgBox(" Cập nhật chưa thành công!", MsgBoxStyle.Critical, "DMCLand")
        End If
        ShowData()
        strError = ""
    End Sub

    Private Sub btnHuyLenh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHuyLenh.Click
        With Me
            'Hiển thị dữ liệu
            .ShowData()
        End With
        shortAction = 0
    End Sub

    Private Sub grdDanhSachCongViec_CellMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grdDanhSachCongViec.CellMouseClick
        If e.RowIndex >= 0 Then
            Try
                'SoNgayThuLy,SoNgayInGiay,SONgayLanhDaoKy,SoNgayKiemTra,SoNgayKyGCN
                strMaSoNgayQUanLy = grdDanhSachCongViec.Rows(e.RowIndex).Cells("MaSoNgayQUanLy").Value
                NumSoTT.Value = grdDanhSachCongViec.Rows(e.RowIndex).Cells("SoTT").Value
                NumSoNgayThucThi.Value = grdDanhSachCongViec.Rows(e.RowIndex).Cells("SoNgayThucThi").Value
                txtTenCongViec.Text = grdDanhSachCongViec.Rows(e.RowIndex).Cells("TenCongViec").Value
                cboBoPhan.Text = grdDanhSachCongViec.Rows(e.RowIndex).Cells("BoPhan").Value
                dtpNgayApDung.Value = grdDanhSachCongViec.Rows(e.RowIndex).Cells("NgayApDUng").Value
                txtMaMau.Text = grdDanhSachCongViec.Rows(e.RowIndex).Cells("R").Value.ToString & "," & grdDanhSachCongViec.Rows(e.RowIndex).Cells("G").Value.ToString & "," & grdDanhSachCongViec.Rows(e.RowIndex).Cells("B").Value.ToString
                PicMau.BackColor = Color.FromArgb(grdDanhSachCongViec.Rows(e.RowIndex).Cells("R").Value, grdDanhSachCongViec.Rows(e.RowIndex).Cells("G").Value, grdDanhSachCongViec.Rows(e.RowIndex).Cells("B").Value)
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub cmdMauCanhBao_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMauCanhBao.Click
        If Me.ColorDialog1.ShowDialog = DialogResult.OK Then
            PicMau.BackColor = ColorDialog1.Color
            txtMaMau.Text = ColorDialog1.Color.R & "," & ColorDialog1.Color.G & "," & ColorDialog1.Color.B
        End If
    End Sub

    Private Sub cboTuDienLuanChuyenHoSo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ShowData()
    End Sub
End Class