Imports System.Globalization

Public Class ctrThamSoMacDinh
    Private dtBangMa As New DataTable
    'Khai báo cờ cập nhật 
    Private shortAction As Short = 0
    'Khai báo biến nhận chuỗi kết nỗi
    Private strConnection As String = ""
    'Khai báo biến Ký hiệu
    Private strTen As String = ""
    'Khai báo biến nhóm
    Private strNhom As String = ""
    'Khai báo biến Mô tả mã
    Private strMoTa As String = ""
    'Khai báo biến kiểm tra lỗi
    Private strError As String = ""
    Private strMaThamSo As String = ""
    'Khai báo thuộc tính nhận chuỗi kết nối
    Public WriteOnly Property Connection() As String
        Set(ByVal value As String)
            strConnection = value
        End Set
    End Property
    'Khai báo thuộc tính Ký hiệu mã
    Public Property Ten() As String
        Get
            Return strTen
        End Get
        Set(ByVal value As String)
            strTen = value
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
    Public Sub TrangThaiCapNhat(Optional ByVal blnCapNhat As Boolean = False)
        With Me
            .txtBangMaKyHieu.ReadOnly = Not blnCapNhat
            .txtBangMaMoTa.ReadOnly = Not blnCapNhat
            If blnCapNhat Then
                .txtBangMaKyHieu.BackColor = Color.White
                .txtBangMaMoTa.BackColor = Color.White
            Else
                .txtBangMaKyHieu.BackColor = Color.LightYellow
                .txtBangMaMoTa.BackColor = Color.LightYellow
            End If
        End With
    End Sub

    Public Sub TrangThaiBanDau()
        With Me
            .txtBangMaKyHieu.Text = ""
            .txtBangMaMoTa.Text = ""
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
                With .Columns("Ten")
                    .HeaderText = "Tên tham số"
                    .Width = 80
                    .Visible = True
                End With
                'Mô tả
                With .Columns("MoTa")
                    .HeaderText = "Mô tả"
                    .Width = 400
                    .Visible = True
                End With

                .BorderStyle = Windows.Forms.BorderStyle.Fixed3D
                .RowHeadersVisible = False
                .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                'Không cho phép thêm
                .AllowUserToAddRows = False
                'Không cho phép xóa
                .AllowUserToDeleteRows = False
                'Không cho phép lựa chọn bất kỳ dòng nào lúc  ban đầu
                .ClearSelection()
            End With
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" TỪ ĐIỂN THAM SỐ MẶC ĐỊNH" + vbNewLine + " Lỗi: " & vbNewLine & strError, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub
    Private Sub btnThem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThem.Click
      
        'Bỏ lựa chọn trên Grid
        Me.grdvwBangMa.ClearSelection()
        strTen = ""
        shortAction = 1
        With Me
            'Thiet lap trang thai ban dau
            .TrangThaiBanDau()
            'Trang thai cap nhat
            .TrangThaiCapNhat(True)
            'Trang thai chuc nang 
            .TrangThaiChucNang(True)
        End With
    End Sub

    Private Sub btnSua_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSua.Click
        If strTen <> "" Then
            shortAction = 2
            'Trạng thái chức năng
            TrangThaiChucNang(True)
            'Trạng thái cập nhật
            TrangThaiCapNhat(True)
        Else
            MsgBox(" Bạn chưa chọn tham số cần sửa!", MsgBoxStyle.Information, "DMCLand")
        End If
    End Sub

    Private Sub btnXoa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXoa.Click

        'Nếu tồn tại mã cần xóa
        If strTen <> "" Then
            If MsgBox("Bạn chắc chắn muốn xóa không?", MsgBoxStyle.YesNo, "DMCLand!") = MsgBoxResult.Yes Then
                Try
                    With Me
                        shortAction = 3
                        .UpdateData()
                        strTen = ""
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
            MsgBox(" Bạn chưa chọn tham số cần xóa!", MsgBoxStyle.Information, "DMCLand")
        End If
        'Trạng thái ban đầu
        Me.TrangThaiBanDau()
        'Trạng thái chức năng
        Me.TrangThaiChucNang()
        'Trang thai cap nhat 
        Me.TrangThaiCapNhat()
        strError = ""
    End Sub

    Private Sub btnCapNhat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCapNhat.Click
      
        If txtBangMaKyHieu.Text.Trim = "" Then
            MsgBox("Bạn phải nhập tham số mặc định!", MsgBoxStyle.Information, "DMCLand")
            txtBangMaKyHieu.Focus()
            Exit Sub
        End If

        Try
            With Me
                'Cap nhat thong tin Chu su dung (Ho gia dinh - ca nhan)
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
            MsgBox(" Cập nhật dữ liệu " & vbNewLine & " tham số mặc định " & vbNewLine _
                & " Lỗi: " & strError, MsgBoxStyle.Information, "DMCLand")
        End Try
        If (strError = "") Or (strError = "OK") Then
            MsgBox(" Bạn đã cập nhật thành công!", MsgBoxStyle.Information, "DMCLand")
        Else
            MsgBox(" Cập nhật chưa thành công!", MsgBoxStyle.Critical, "DMCLand")
        End If
        'Khởi tạo lại giá trị cho biến dùng chung
        strTen = ""
        strError = ""
    End Sub

    Private Sub btnHuyLenh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHuyLenh.Click
        With Me
            'Hiển thị dữ liệu
            .ShowData()
            'Xóa dữ liệu trên Form
            .TrangThaiBanDau()
            'Khởi tạo giá trị cho biến dùng chung
            strTen = ""
            'Trạng thái chức năng
            .TrangThaiChucNang()
            'Trạng thái cập nhật 
            .TrangThaiCapNhat()
        End With
        shortAction = 0
    End Sub

    Public Sub ShowData()
        'Khai bao va khoi tao doi tuong clsBangMa
        Dim BangMa As New clsThamSoMacDinh
        'Gan gia tri cho cac thuoc tinh doi voi truong hop truy van
        Try
            'Gán chuỗi kết nối cơ sở dữ liệu
            BangMa.Connection = strConnection
            BangMa.Ten = ""
            BangMa.MoTa = ""
            dtBangMa.Clear()
            With Me.grdvwBangMa
                .ClearSelection()
                'Goi phuong thuc GetData de khoi tao doi tuong clsBangMa
                If BangMa.SelectThamSoMacDinh(dtBangMa) = "" Then
                    'Trình bày dữ liệu lên grdvwBangMa
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
    Public Sub UpdateData()
        'Khai bao va khoi tao doi tuong clsMucDich
        Dim BangMa As New clsThamSoMacDinh
        Try
            'Xac nhan ban ghi can xoa
            With BangMa
                .Connection = strConnection 'Gán chuỗi kết nối cơ sở dữ liệu
                .Ten = strTen
                .MoTa = txtBangMaMoTa.Text.Trim
                .Get_Ma = strMaThamSo
            End With
            If txtBangMaKyHieu.Text.Trim <> "" Then
                BangMa.Ten = txtBangMaKyHieu.Text.Trim
            Else
                If (shortAction = 1) Or (shortAction = 2) Then
                    MsgBox("Bạn phải nhập tên tham số", MsgBoxStyle.Information, "DMCLand")
                    Exit Sub
                Else
                    BangMa.Ten = ""
                End If
            End If

            Dim i As Integer
            If (shortAction = 1) Then
                BangMa.InsertThamSoMacDinh(i)
                NhatKyNguoiDung("Thêm", strTen & "_" & txtBangMaMoTa.Text.Trim)
            ElseIf (shortAction = 2) Then
                BangMa.UpdateThamSoMacDinh(i)
                NhatKyNguoiDung("Sửa", strTen & "_" & txtBangMaMoTa.Text.Trim)
            ElseIf (shortAction = 3) Then
                BangMa.DeleteThamSoMacDinh(i)
                NhatKyNguoiDung("Xóa", strTen & "_" & txtBangMaMoTa.Text.Trim)
            End If

            strError = BangMa.Err
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Cập nhật dữ liệu " & vbNewLine & " ĐỐI TƯỢNG SỬ DỤNG ĐẤT " _
                   & " Lỗi: " & strError, MsgBoxStyle.Information, "DMCLand")
        End Try
        shortAction = 0
    End Sub
    Public Sub NhatKyNguoiDung(ByVal ChucNang As String, ByVal MoTa As String)
        Dim clsNhatky As New prjNhatKyNguoiDung.clsNhatKyNguoiDung
        clsNhatky.Connection = strConnection
        clsNhatky.MaHoSoCapGCN = ""
        clsNhatky.MaDonViHanhChinh = ""
        clsNhatky.NghiepVu = "Cập nhật Tham số mặc định"
        clsNhatky.ChucNang = ChucNang
        clsNhatky.MoTa = MoTa
        clsNhatky.DuongDanFile = Application.StartupPath
        clsNhatky.LuuNhatKyNguoiDung()
    End Sub

    Private Sub grdvwBangMa_CellMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grdvwBangMa.CellMouseClick
        Dim BangMa As New clsThamSoMacDinh
        If e.RowIndex >= 0 Then
            Try
                With Me
                    strTen = ""
                    strMoTa = ""
                    strMaThamSo = .grdvwBangMa.Item("Ma", e.RowIndex).Value.ToString()
                    .txtBangMaKyHieu.Text = .grdvwBangMa.Item("Ten", e.RowIndex).Value.ToString()
                    .txtBangMaMoTa.Text = .grdvwBangMa.Item("MoTa", e.RowIndex).Value.ToString()
                    strTen = .grdvwBangMa.Item("Ten", e.RowIndex).Value.ToString()
                    'Gán giá trị cho các thuộc tính ứng với trường hợp truy vấn
                    BangMa.Ten = .txtBangMaKyHieu.Text.Trim
                    strMoTa = .txtBangMaMoTa.Text.Trim
                    BangMa.MoTa = .txtBangMaMoTa.Text.Trim
                    .txtBangMaKyHieu.ReadOnly = True
                End With
            Catch ex As Exception
                MsgBox(" Bảng mã tham số mặc định " & vbNewLine & " Lỗi: " & vbNewLine & ex.Message, MsgBoxStyle.Information, "DMCLand")
            End Try
        End If
    End Sub

    Private Sub grdvwBangMa_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles grdvwBangMa.KeyPress
        If (Char.IsLetter(e.KeyChar)) Then
            Dim i As Integer = 0
            For Each dgvRow As DataGridViewRow In grdvwBangMa.Rows
                If (dgvRow.Cells("Ten").FormattedValue.ToString().StartsWith(e.KeyChar.ToString(), True, CultureInfo.InvariantCulture)) Then
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
            btnCapNhat.Focus()
        End If
    End Sub

    Private Sub ctrThamSoMacDinh_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            'Trang thai cap nhat
            Me.TrangThaiCapNhat()
            'Trang thai chuc nang
            Me.TrangThaiChucNang()
            'Hiển thị dữ liệu của bảng mã tương ứng
            'ShowData()
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Hệ thống bảng mã " & vbNewLine & " Lỗi: " & vbNewLine & ex.Message, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub
End Class
