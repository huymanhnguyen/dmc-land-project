Imports System.Windows.Forms
Imports System.Drawing
Imports System.Globalization

Public Class ctrlTuDienLoaiHinhBienDong
    Private dtBangMa As New DataTable
    'Khai báo cờ cập nhật 
    Private shortAction As Short = 0
    'Khai báo biến nhận chuỗi kết nỗi
    Private strConnection As String = ""
    'Khai báo biến Ký hiệu
    Private strKyHieu As String = ""
    'Khai báo biến Mã
    Private strMa As String = ""
    'Khai báo biến Mô tả mã
    Private strMoTa As String = ""
    'Khai báo biến kiểm tra lỗi
    Private strError As String = ""
    'Khai báo thuộc tính nhận chuỗi kết nối
    Private strNoiDungGhiSo As String = ""

    Public WriteOnly Property Connection() As String
        Set(ByVal value As String)
            strConnection = value
        End Set
    End Property
    'Khai báo thuộc tính Ký hiệu mã
    Public Property KyHieu() As String
        Get
            Return strKyHieu
        End Get
        Set(ByVal value As String)
            strKyHieu = value
        End Set
    End Property
    Private strDonViDangKy As String = ""
    Public Property DonViDangKy() As String
        Get
            Return strDonViDangKy
        End Get
        Set(ByVal value As String)
            strDonViDangKy = value
        End Set
    End Property

    'Khai báo thuộc tính Mô tả mã
    Public Property MoTa() As String
        Get
            Return strMoTa
        End Get
        Set(ByVal value As String)
            strMoTa = value
        End Set
    End Property
    'Khai báo thuộc tính Mô tả mã
    Public Property NoiDungGhiSo() As String
        Get
            Return strNoiDungGhiSo
        End Get
        Set(ByVal value As String)
            strNoiDungGhiSo = value
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

    Private Sub FormatGridContruction()
        Try
            Me.HideAllColumns(grdvwBangMa)
            With Me.grdvwBangMa
                'Ký hiệu
                With .Columns("KyHieu")
                    .HeaderText = "Ký hiệu"
                    .Width = 80
                    .Visible = True
                End With
                'Mô tả
                With .Columns("MoTa")
                    .HeaderText = "Mô tả"
                    .Width = 400
                    .Visible = True
                End With
                With .Columns("NoiDungGhiSo")
                    .HeaderText = "Nội dung ghi sổ"
                    .Width = 400
                    .Visible = True
                End With
                With .Columns("Ma")
                    .Width = 0
                    .Visible = False
                End With
                .BorderStyle = Windows.Forms.BorderStyle.Fixed3D
                .RowHeadersVisible = False
                .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                'Không cho phép thêm
                .AllowUserToAddRows = False
                'Không cho phép xóa
                .AllowUserToDeleteRows = False
                'Không lựa chọn bất kỳ dòng nào lúc ban đầu
                .ClearSelection()
            End With
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Loại hình biến động" + vbNewLine + " Lỗi: " & vbNewLine & strError, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub


    Private Sub btnBangMaThem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThem.Click
        'Bo lua chon tren Grid
        Me.grdvwBangMa.ClearSelection()
        strKyHieu = ""
        shortAction = 1
        With Me
            'Thiết lập trạng thái ban đầu
            .TrangThaiBanDau()
            'Trạng thái cập nhật
            .TrangThaiCapNhat(True)
            'Trạng thái chức năng 
            .TrangThaiChucNang(True)
        End With
    End Sub

    Private Sub btnBangMaXoa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXoa.Click
        'Nếu tồn tại mã cần xóa
        If strMa <> "" Then
            If MsgBox("Bạn chắc chắn muốn xóa không?", MsgBoxStyle.YesNo, "DMCLand!") = MsgBoxResult.Yes Then
                Try
                    With Me
                        shortAction = 3
                        .UpdateData()
                        strKyHieu = ""
                        strMa = ""
                        'Hiển thị dữ liệu
                        .ShowData()
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
            MsgBox(" Bạn chưa chọn Loại hình biến động cần xóa!", MsgBoxStyle.Information, "DMCLand")
        End If
        'Trạng thái ban đầu
        Me.TrangThaiBanDau()
        'Trạng thái chức năng
        Me.TrangThaiChucNang()
        'Trang thai cap nhat 
        Me.TrangThaiCapNhat()
        strError = ""
    End Sub

    Public Sub btnBangMaCapNhat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGhi.Click
        'Kiểm tra dữ liệu vào
        If txtBangMaKyHieu.Text.Trim = "" Then
            MsgBox("Bạn phải nhập Loại hình biến động!", MsgBoxStyle.Information, "DMCLand")
            txtBangMaKyHieu.Focus()
            Exit Sub
        End If

        Try
            With Me
                'Cập nhật thông tin Loại hình biến động
                .UpdateData()
                'Hien thi du lieu
                .ShowData()
                'Trang thai chuc nang
                .TrangThaiChucNang()
                'Trang thai cap nhat
                .TrangThaiCapNhat()
            End With
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Cập nhật dữ liệu " & vbNewLine & " Loại hình biến động " & vbNewLine _
                & " Lỗi: " & strError, MsgBoxStyle.Information, "DMCLand")
        End Try
        If (strError = "") Or (strError = "OK") Then
            MsgBox(" Bạn đã cập nhật thành công!", MsgBoxStyle.Information, "DMCLand")
        Else
            MsgBox(" Cập nhật chưa thành công!", MsgBoxStyle.Critical, "DMCLand")
        End If
        'Khởi tạo lại giá trị cho biến dùng chung
        strKyHieu = ""
        strError = ""
    End Sub
    Public Sub ShowData()
        'Khai bao va khoi tao doi tuong clsBangMa
        Dim BangMa As New clsBangMa
        'Gan gia tri cho cac thuoc tinh doi voi truong hop truy van
        Try
            'Gán chuỗi kết nối cơ sở dữ liệu
            BangMa.Connection = strConnection
            BangMa.KyHieu = ""
            BangMa.MoTa = ""
            BangMa.DonViDangKy = strDonViDangKy
            dtBangMa.Clear()
            With Me.grdvwBangMa
                .ClearSelection()
                'Goi phuong thuc GetData de khoi tao doi tuong clsBangMa
                If BangMa.SelectTuDienLoaiHinhBienDong(dtBangMa) = "" Then
                    ' Trinh bay du lieu len grdvwBangMa
                    grdvwBangMa.DataSource = dtBangMa
                    If dtBangMa.Rows.Count > 0 Then
                        Me.FormatGridContruction()
                    Else
                        Me.HideAllColumns(grdvwBangMa)
                    End If
                End If
            End With
            'Thiết lập trạng thái ban đầu
            Me.TrangThaiBanDau()
            txtBangMaKyHieu.ReadOnly = True
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Bảng mã " + vbNewLine + "Lỗi: " + vbNewLine + ex.Message, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub
    Public Sub NhatKyNguoiDung(ByVal ChucNang As String, ByVal MoTa As String)
        Dim clsNhatky As New prjNhatKyNguoiDung.clsNhatKyNguoiDung
        clsNhatky.Connection = strConnection
        clsNhatky.MaHoSoCapGCN = ""
        clsNhatky.MaDonViHanhChinh = ""
        clsNhatky.NghiepVu = "Cập nhật loại hình biến động"
        clsNhatky.ChucNang = ChucNang
        clsNhatky.MoTa = MoTa
        clsNhatky.DuongDanFile = Application.StartupPath
        clsNhatky.LuuNhatKyNguoiDung()
    End Sub
    Public Sub UpdateData()
        'Khai báo và khởi tạo đối tượng
        Dim BangMa As New clsBangMa
        Try
            'Xác nhận bản ghi cần xóa
            With BangMa
                .Connection = strConnection 'Gán chuỗi kết nối cơ sở dữ liệu
                .KyHieu = strKyHieu 'ký hiệu
                .MoTa = txtBangMaMoTa.Text.Trim 'mô tả
                .Nhom = txtNoiDungGhiSo.Text.Trim
                .Get_Ma = strMa
            End With
            If txtBangMaKyHieu.Text.Trim <> "" Then
                BangMa.KyHieu = txtBangMaKyHieu.Text.Trim
            Else
                If (shortAction = 1) Or (shortAction = 2) Then
                    MsgBox("Bạn phải nhập Mã Loại hình biến động", MsgBoxStyle.Information, "DMCLand")
                    Exit Sub
                Else
                    BangMa.KyHieu = ""
                End If
            End If

            Dim i As Integer
            If (shortAction = 1) Then
                BangMa.InsertTuDienLoaiHinhBienDong(i)
                NhatKyNguoiDung("Thêm", strKyHieu & "_" & txtBangMaMoTa.Text.Trim)
            ElseIf (shortAction = 2) Then
                BangMa.UpdateTuDienLoaiHinhBienDong(i)
                NhatKyNguoiDung("Sửa", strKyHieu & "_" & txtBangMaMoTa.Text.Trim)
            ElseIf (shortAction = 3) Then
                BangMa.DeleteTuDienLoaiHinhBienDong_Moi(i)
                NhatKyNguoiDung("Xóa", strKyHieu & "_" & txtBangMaMoTa.Text.Trim)
            End If

            strError = BangMa.Err
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Cập nhật dữ liệu " & vbNewLine & " Loại hình biến động " _
                   & " Lỗi: " & strError, MsgBoxStyle.Information, "DMCLand")
        End Try
        shortAction = 0
    End Sub

    Private Sub grdvwBangMa_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grdvwBangMa.CellMouseClick
        Dim BangMa As New clsBangMa
        If e.RowIndex >= 0 Then
            Try
                With Me
                    strKyHieu = ""
                    strMoTa = ""
                    .txtBangMaKyHieu.Text = .grdvwBangMa.Item("KyHieu", e.RowIndex).Value.ToString()
                    .txtBangMaMoTa.Text = .grdvwBangMa.Item("MoTa", e.RowIndex).Value.ToString()
                    .txtNoiDungGhiSo.Text = .grdvwBangMa.Item("NoiDungGhiSo", e.RowIndex).Value.ToString()
                    'Gán giá trị cho các thuộc tính ứng với trường hợp truy vấn
                    BangMa.KyHieu = .txtBangMaKyHieu.Text.Trim
                    strKyHieu = .txtBangMaKyHieu.Text.Trim
                    strNoiDungGhiSo = .grdvwBangMa.Item("NoiDungGhiSo", e.RowIndex).Value.ToString()
                    BangMa.MoTa = .txtBangMaMoTa.Text.Trim
                    BangMa.Nhom = .txtNoiDungGhiSo.Text.Trim
                    .txtBangMaKyHieu.ReadOnly = True
                    strMa = .grdvwBangMa.Item("Ma", e.RowIndex).Value.ToString()
                End With
            Catch ex As Exception
                MsgBox(" Bảng mã Loại hình biến động " & vbNewLine & " Lỗi: " & vbNewLine & ex.Message, MsgBoxStyle.Information, "DMCLand")
            End Try
        End If
    End Sub

    Private Sub btnSua_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSua.Click
        If strKyHieu <> "" Then
            shortAction = 2
            'Trạng thái chức năng
            TrangThaiChucNang(True)
            'Trạng thái cập nhật
            TrangThaiCapNhat(True)
        Else
            MsgBox(" Bạn CHƯA chọn Loại hình biến động!", MsgBoxStyle.Information, "DMCLand")
        End If
    End Sub

    Public Sub TrangThaiCapNhat(Optional ByVal blnCapNhat As Boolean = False)
        With Me
            .txtBangMaKyHieu.ReadOnly = Not blnCapNhat
            .txtBangMaMoTa.ReadOnly = Not blnCapNhat
            .txtNoiDungGhiSo.ReadOnly = Not blnCapNhat
            If blnCapNhat Then
                .txtBangMaKyHieu.BackColor = Color.White
                .txtBangMaMoTa.BackColor = Color.White
                .txtNoiDungGhiSo.BackColor = Color.White
            Else
                .txtBangMaKyHieu.BackColor = Color.LightYellow
                .txtBangMaMoTa.BackColor = Color.LightYellow
                .txtNoiDungGhiSo.BackColor = Color.LightYellow
            End If
        End With
    End Sub

    Public Sub TrangThaiBanDau()
        With Me
            .txtBangMaKyHieu.Text = ""
            .txtBangMaMoTa.Text = ""
            .txtNoiDungGhiSo.Text = ""
        End With
    End Sub

    Public Sub TrangThaiChucNang(Optional ByVal blnStartEdited As Boolean = False, Optional ByVal blnStartDeleted As Boolean = False)
        With Me
            .btnSua.Enabled = Not blnStartEdited
            .btnXoa.Enabled = Not blnStartEdited
            .btnThem.Enabled = Not blnStartEdited
            .btnGhi.Enabled = blnStartEdited
            .btnHuyLenh.Enabled = blnStartEdited
            If blnStartDeleted Then
                .btnGhi.Enabled = Not blnStartDeleted
                .btnHuyLenh.Enabled = Not blnStartDeleted
            End If
        End With
    End Sub

    Private Sub CtrlBangMaMucDich_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            'Trang thai cap nhat
            Me.TrangThaiCapNhat()
            'Trang thai chuc nang
            Me.TrangThaiChucNang()
            'Hiển thị dữ liệu của bảng mã tương ứng
            ShowData()
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Hệ thống bảng mã " & vbNewLine & " Lỗi: " & vbNewLine & ex.Message, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub

    Private Sub btnHuyLenh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHuyLenh.Click
        With Me
            'Hiển thị dữ liệu
            .ShowData()
            'Xóa dữ liệu trên Form
            .TrangThaiBanDau()
            'Khởi tạo giá trị cho biến dùng chung
            strKyHieu = ""
            'Trạng thái chức năng
            .TrangThaiChucNang()
            'Trạng thái cập nhật 
            .TrangThaiCapNhat()
        End With
        shortAction = 0
    End Sub

    Private Sub grdvwBangMa_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles grdvwBangMa.KeyPress
        If (Char.IsLetter(e.KeyChar)) Then
            Dim i As Integer = 0
            For Each dgvRow As DataGridViewRow In grdvwBangMa.Rows
                If (dgvRow.Cells("KyHieu").FormattedValue.ToString().StartsWith(e.KeyChar.ToString(), True, CultureInfo.InvariantCulture)) Then
                    dgvRow.Selected = True
                    Me.grdvwBangMa.CurrentCell = Me.grdvwBangMa.Rows(i).Cells(1)
                    Exit For
                    Return
                End If
                i = i + 1
            Next
        End If
    End Sub
    Private Sub txtBangMaKyHieu_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBangMaKyHieu.KeyDown
        If (e.KeyValue = 13) Then
            txtBangMaMoTa.Focus()
        End If
    End Sub

    Private Sub txtBangMaMoTa_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBangMaMoTa.KeyDown
        If (e.KeyValue = 13) Then
            btnGhi.Focus()
        End If
    End Sub
End Class
