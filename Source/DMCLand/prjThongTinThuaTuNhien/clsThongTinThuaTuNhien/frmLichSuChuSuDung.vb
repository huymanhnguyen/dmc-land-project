Imports System.Windows.Forms

Public Class frmLichSuChuSuDung
    ''Biến xác nhận Sao chép lịch sử chủ sử dụng vào hồ sơ
    'Private blnGhi As Boolean = False
    'Khai báo biến kiểm tra lỗi
    Private strError As String = ""
    'Khai báo biến chuỗi kết nối cơ sở dữ liệu
    Private strConnection As String = ""
    'Khai báo biến Mã thửa đất lịch sử
    Private strMaThuaDatLichSu As String = ""
    'Khai báo biến Mã hồ sơ hiện thời
    Private strMaHoSoCapGCNHienThoi As String = ""
    'Khai báo biến lưu thông tin Lịch sử Chủ sử dụng 
    Private dtLichSuChuSuDung As New DataTable
    'Khai báo thuộc tính chỉ ghi chuỗi kết nối cơ sở dữ liệu
    Public WriteOnly Property Connection() As String
        Set(ByVal value As String)
            strConnection = value
        End Set
    End Property
    'Thuộc tính Mã thửa đất lịch sử
    Public WriteOnly Property MaThuaDatLichSu() As String
        Set(ByVal value As String)
            strMaThuaDatLichSu = value
        End Set
    End Property
    Private strMaDonViHanhChinh As String = ""

    Public Property MaDonViHanhChinh() As String
        Get
            Return strMaDonViHanhChinh
        End Get
        Set(ByVal value As String)
            strMaDonViHanhChinh = value
        End Set
    End Property
    'Thuộc tính Mã Hồ sơ cấp GCN hiện thời
    Public WriteOnly Property MaHoSoCapGCNHienThoi() As String
        Set(ByVal value As String)
            strMaHoSoCapGCNHienThoi = value
        End Set
    End Property
    'Thuộc tính thông tin Lịch sử Chủ sử dụng
    Public WriteOnly Property DanhSachLichSuChuSuDung() As DataTable
        Set(ByVal value As DataTable)
            dtLichSuChuSuDung = value
        End Set
    End Property

    Private Sub HideAllColumns(ByRef grdvw As DataGridView)
        'Ẩn tất cả các cột trên Grid
        With grdvw
            For i As Integer = 0 To (.Columns.Count - 1)
                .Columns(i).Visible = False
            Next
            .RowHeadersVisible = False
        End With
    End Sub

    'Add các cột cần thiết cho Grid Lịch sử thửa đất
    Public Sub FormatGridContruction()
        Try
            With Me.grdvw
                'Ẩn tất cả các cột trên Grid
                Me.HideAllColumns(grdvw)
                'Thiết đặt các giá trị cần thiết cho cột
                With .Columns("HoTen")
                    .HeaderText = "Tên"
                    .Width = 120
                    .Visible = True
                End With
                'Số định danh (CMTND,hộ chiếu, giấy phép kinh doanh)
                With .Columns("SoDinhDanh")
                    .HeaderText = "CMTND (Hộ chiếu, GPKD)"
                    .Width = 200
                    .Visible = True
                End With
                'Địa chỉ
                With .Columns("DiaChi")
                    .HeaderText = "Địa chỉ"
                    .Width = 350
                    .Visible = True
                End With
                .BorderStyle = Windows.Forms.BorderStyle.Fixed3D
                .RowHeadersVisible = False
                .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                'Không cho phép lựa chọn nhiều bản ghi trong cùng lúc
                .MultiSelect = False
                .ReadOnly = True
                'Khong cho phep them
                .AllowUserToAddRows = False
                'Khong cho phep xoa
                .AllowUserToDeleteRows = False
                'Khong lua chon bat ky dong nao luc ban dau
                .ClearSelection()
            End With
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Hiển thị thông tin lịch sử chủ sử dụng thửa đất" + vbNewLine + strError, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub

    Public Sub ShowData()
        'Cập nhật thông tin Lịch sử CHỦ SỬ DỤNG ĐẤT 
        Dim LichSuChuSuDung As New clsThongTinHoSoCapGCNThuaDatLichSu  ' clsLichSuChuSuDung 
        LichSuChuSuDung.Connection = strConnection
        LichSuChuSuDung.MaThuaDatLichSu = strMaThuaDatLichSu
        LichSuChuSuDung.MaDonViHanhChinh = strMaDonViHanhChinh
        'Làm sạch dữ liệu trên đối tượng Datatable
        dtLichSuChuSuDung.Clear()
        'Nạp thông tin Lịch sử chủ sử dụng vào đối tượng Datatable
        LichSuChuSuDung.SelectThongTinLichSuChuSuDung(dtLichSuChuSuDung)
        'Hiển thị thông tin Lịch sử Chủ sử dụng lên Form
        With Me.grdvw
            .ClearSelection()
            'Trình bày dữ liệu grdvw
            .DataSource = dtLichSuChuSuDung
            If dtLichSuChuSuDung.Rows.Count > 0 Then
                'Định dạng lại các cột trên Grid
                Me.FormatGridContruction()
            Else
                'Ẩn tất cả các cột
                Me.HideAllColumns(grdvw)
            End If
        End With
    End Sub

    Private Sub btnGhi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGhi.Click
        If (MessageBox.Show("Bạn có muốn sao chép LỊCH SỬ CHỦ SỬ DỤNG vào hồ sơ cấp GCN này không?", "DMCLand", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes) Then
            Dim LichSuChuSuDung As New clsThongTinHoSoCapGCNThuaDatLichSu  '  clsLichSuChuSuDung
            With LichSuChuSuDung
                'Truyền chuỗi kết nối cơ sở dữ liệu
                .Connection = strConnection
                'Chắc chắn rằng tồn tại Mã hồ sơ cấp GCN hiện thời 
                If strMaHoSoCapGCNHienThoi.Trim = "" Then
                    Exit Sub
                End If
                'Truyền Mã hồ sơ cấp GCN hiện thời
                .MaHoSoCapGCNHienThoi = strMaHoSoCapGCNHienThoi
                .MaDonViHanhChinh = strMaDonViHanhChinh
                'Chắc chắn rằng tồn tại Mã thửa đất lịch sử
                If strMaThuaDatLichSu.Trim = "" Then
                    Exit Sub
                End If
                'Truyền Mã thửa đất lịch sử tạo lập thửa đất có hồ sơ cấp GCN hiện thời
                .MaThuaDatLichSu = strMaThuaDatLichSu
                'Sao chép thông tin lịch sử chủ sử dụng thửa đất 
                'vào Hồ sơ cấp GCN hiện thời
                .SaoChepThongTinLichSuChuSuDung()
            End With
        End If
        'Thoát Form
        Me.Hide()
    End Sub

    Private Sub btnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Click
        'Thoát Form
        Me.Hide()
    End Sub

    Private Sub grdvw_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdvw.CellContentClick

    End Sub
End Class