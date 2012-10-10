Imports System.Windows.Forms

Public Class frmLichSuNguonGocSuDung
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
    'Khai báo biến lưu thông tin Lịch sử NGUỒN GỐC sử dụng 
    Private dtLichSuNguonGocSuDung As New DataTable
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
                With .Columns("MoTa")
                    .HeaderText = "Mô tả"
                    .Width = 150
                    .Visible = True
                End With
                '
                With .Columns("DienTich")
                    .HeaderText = "Diện tích"
                    .Width = 130
                    .Visible = True
                End With
                '
                With .Columns("TenTaiLieuChungThuc")
                    .HeaderText = "Tài liệu chứng thực"
                    .Width = 150
                    .Visible = True
                End With
                '
                With .Columns("NoiDungChungThuc")
                    .HeaderText = "Nội dung chứng thực"
                    .Width = 150
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
            MsgBox(" Hiển thị thông tin lịch sử NGUỒN GỐC sử dụng thửa đất" + vbNewLine + strError, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub

    Public Sub ShowData()
        'Cập nhật thông tin Lịch sử NGUỒN GỐC SỬ DỤNG ĐẤT 
        Dim LichSuNguonGocSuDung As New clsThongTinHoSoCapGCNThuaDatLichSu
        LichSuNguonGocSuDung.Connection = strConnection
        LichSuNguonGocSuDung.MaThuaDatLichSu = strMaThuaDatLichSu
        LichSuNguonGocSuDung.MaDonViHanhChinh = strMaDonViHanhChinh
        'Làm sạch dữ liệu trên đối tượng Datatable
        dtLichSuNguonGocSuDung.Clear()
        'Nạp thông tin Lịch sử NGUỒN GỐC sử dụng vào đối tượng Datatable
        LichSuNguonGocSuDung.SelectThongTinLichSuNguonGocSuDung(dtLichSuNguonGocSuDung)
        'Hiển thị thông tin Lịch sử Chủ sử dụng lên Form
        With Me.grdvw
            .ClearSelection()
            'Trình bày dữ liệu grdvw
            .DataSource = dtLichSuNguonGocSuDung
            If dtLichSuNguonGocSuDung.Rows.Count > 0 Then
                'Định dạng lại các cột trên Grid
                Me.FormatGridContruction()
            Else
                'Ẩn tất cả các cột
                Me.HideAllColumns(grdvw)
            End If
        End With
    End Sub

    Private Sub btnGhi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGhi.Click
        If (MessageBox.Show("Bạn có muốn sao chép LỊCH SỬ NGUỒN GỐC SỬ DỤNG vào hồ sơ cấp GCN này không?", "DMCLand", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes) Then
            Dim LichSuNguonGocSuDung As New clsThongTinHoSoCapGCNThuaDatLichSu
            With LichSuNguonGocSuDung
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
                'Sao chép thông tin lịch sử NGUỒN GỐC sử dụng thửa đất 
                'vào Hồ sơ cấp GCN hiện thời
                .SaoChepThongTinLichSuNguonGocSuDung()
            End With
        End If
        'Thoát Form
        Me.Hide()
    End Sub

    Private Sub btnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Click
        'Thoát Form
        Me.Hide()
    End Sub
End Class