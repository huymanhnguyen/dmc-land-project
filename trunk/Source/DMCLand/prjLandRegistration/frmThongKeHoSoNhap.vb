Imports Microsoft.Office.Interop

Public Class frmThongKeHoSoNhap
    Private strConnection As String = ""
    Public Property Connection() As String
        Get
            Return strConnection
        End Get
        Set(ByVal value As String)
            strConnection = value
        End Set
    End Property
    Private strMaDonViHanhChinh As String
    Public Property MaDonViHanhChinh() As String
        Get
            Return strMaDonViHanhChinh
        End Get
        Set(ByVal value As String)
            strMaDonViHanhChinh = value
        End Set
    End Property
    Private strError As String = ""

    Private strMaHoSoCapGCN As String = ""


    Public Sub AddColumnsTimKiem()
        Dim txtClnDVHC As New DataGridViewTextBoxColumn
        Dim txtClnToBanDoTimKiem As New DataGridViewTextBoxColumn
        Dim txtClnSoThuaTimKiem As New DataGridViewTextBoxColumn
        Dim txtClnDienTichTimKiem As New DataGridViewTextBoxColumn
        Dim txtClnDiaChiThuaTimKiem As New DataGridViewTextBoxColumn
        Dim txtClnNgayLapToTrinhTimKiem As New DataGridViewTextBoxColumn
        Dim txtClnNgayQuyetDinhCapGCNTimKiem As New DataGridViewTextBoxColumn
        Dim txtClnHoTenTimKiem As New DataGridViewTextBoxColumn
        Dim txtClnHoTenChuChuyenNhuongTimKiem As New DataGridViewTextBoxColumn
        Dim txtClnMaThuaDatTimKiem As New DataGridViewTextBoxColumn
        Dim txtClnMaLoaiBienDong As New DataGridViewTextBoxColumn
        Dim txtClnCanhBaoTranhChap As New DataGridViewTextBoxColumn
        Dim txtClnSoPhatHanhGCN As New DataGridViewTextBoxColumn
        Try
            With txtClnDVHC
                .HeaderText = "Phường"
                .Name = "TenDVHC"
                .Width = 150
                .Visible = True
            End With
            With txtClnSoPhatHanhGCN
                .HeaderText = "Số phát hành GCN"
                .Name = "SoPhatHanhGCN"
                .Width = 250
                .Visible = True
            End With
            'Tờ bản đồ
            With txtClnToBanDoTimKiem
                .HeaderText = "Tờ bản đồ"
                .Name = "ToBanDoTimKiem"
                .Width = 100
            End With
            'Số hiệu thửa
            With txtClnSoThuaTimKiem
                .HeaderText = "Số thửa"
                .Name = "SoThuaTimKiem"
                .Width = 100
            End With
            'Dien tich thửa đất
            With txtClnDienTichTimKiem
                .HeaderText = "Diện tích"
                .Name = "DienTichTimKiem"
                .Width = 100
            End With
            'Địa chỉ thửa
            With txtClnDiaChiThuaTimKiem
                .HeaderText = "Địa chỉ đất"
                .Name = "DiaChiThuaTimKiem"
                .Width = 400
            End With
            'Địa chỉ thửa
            With txtClnNgayLapToTrinhTimKiem
                .HeaderText = "Năm trình"
                .Name = "NgayLapToTrinhTimKiem"
                .Width = 150
            End With

            With txtClnNgayQuyetDinhCapGCNTimKiem
                .HeaderText = "Năm cấp GCN"
                .Name = "NgayQuyetDinhCapGCNTimKiem"
                .Width = 150
            End With
            With txtClnHoTenTimKiem
                .HeaderText = "Chủ sử dụng"
                .Name = "HoTenTimKiem"
                .Width = 250
            End With
            With txtClnHoTenChuChuyenNhuongTimKiem
                .HeaderText = "Người nhận chuyển nhượng"
                .Name = "HoTenChuChuyenNhuongTimKiem"
                .Width = 250
            End With
            With txtClnMaThuaDatTimKiem
                .HeaderText = ""
                .Name = "MaThuaDat"
                .Width = 0
                .Visible = False
            End With
            With txtClnMaLoaiBienDong
                .HeaderText = "Loại biến động"
                .Name = "MaLoaiBienDong"
                .Width = 250

            End With
            With txtClnCanhBaoTranhChap
                .HeaderText = "Cảnh báo tranh chấp"
                .Name = "CanhBaoTranhChapKhieuKien"
                .Width = 250
                .Visible = False
            End With

            'With txtClnSoDinhDanhTimKiem
            '    .HeaderText = "Số định danh"
            '    .Name = "SoDinhDanhTimKiem"
            '    .Width = 100
            'End With
            'Add all to DataGridView
            With Me.grdThongTin
                .BorderStyle = Windows.Forms.BorderStyle.Fixed3D
                .RowHeadersVisible = False
                .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                'Add Columns
                With .Columns
                    .Add(txtClnDVHC)
                    .Add(txtClnSoPhatHanhGCN)
                    .Add(txtClnToBanDoTimKiem)
                    .Add(txtClnSoThuaTimKiem)
                    .Add(txtClnDienTichTimKiem)
                    .Add(txtClnDiaChiThuaTimKiem)
                    .Add(txtClnHoTenTimKiem)
                    .Add(txtClnNgayLapToTrinhTimKiem)
                    .Add(txtClnNgayQuyetDinhCapGCNTimKiem)
                    .Add(txtClnHoTenChuChuyenNhuongTimKiem) 
                    .Add(txtClnMaLoaiBienDong)
                    .Add(txtClnCanhBaoTranhChap)
                    .Add(txtClnMaThuaDatTimKiem)

                End With
                'Không cho phép thêm
                .AllowUserToAddRows = False
                'Không cho phép xóa
                .AllowUserToDeleteRows = False
                'Không lựa chọn bất kỳ dòng nào
                .ClearSelection()
            End With
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Tìm kiếm" + vbNewLine + " Lỗi: " & vbNewLine & strError, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub

    Public Sub LoadGrid(ByVal dtTimKiem As DataTable)
        If dtTimKiem.Rows.Count > 0 Then
            For i As Integer = 0 To dtTimKiem.Rows.Count - 1
                With Me.grdThongTin
                    .RowCount += 1
                    .Item("ToBanDoTimKiem", i).Value = dtTimKiem.Rows(i).Item("ToBanDo").ToString
                    .Item("SoThuaTimKiem", i).Value = dtTimKiem.Rows(i).Item("SoThua").ToString
                    .Item("DiaChiThuaTimKiem", i).Value = dtTimKiem.Rows(i).Item("DiaChi").ToString
                    .Item("DienTichTimKiem", i).Value = dtTimKiem.Rows(i).Item("DienTich").ToString
                    .Item("NgayLapToTrinhTimKiem", i).Value = dtTimKiem.Rows(i).Item("NgayLapToTrinh").ToString
                    .Item("NgayQuyetDinhCapGCNTimKiem", i).Value = dtTimKiem.Rows(i).Item("NgayQuyetDinhCapGCN").ToString
                    .Item("HoTenTimKiem", i).Value = TongHopChu(dtTimKiem.Rows(i).Item("MaHoSoCapGCN").ToString)
                    .Item("HoTenChuChuyenNhuongTimKiem", i).Value = TongHopChuChuyenNhuong(dtTimKiem.Rows(i).Item("MaHoSoCapGCN").ToString)
                    .Item("MaThuaDat", i).Value = dtTimKiem.Rows(i).Item("MaThuaDat").ToString
                    .Item("MaLoaiBienDong", i).Value = MaLoaiBienDong(dtTimKiem.Rows(i).Item("MaHoSoCapGCN").ToString)
                    .Item("CanhBaoTranhChapKhieuKien", i).Value = dtTimKiem.Rows(i).Item("CanhBaoTranhChapKhieuKien").ToString
                    .Item("SoPhatHanhGCN", i).Value = dtTimKiem.Rows(i).Item("SoPhatHanhGCN").ToString
                    .Item("TenDVHC", i).Value = dtTimKiem.Rows(i).Item("Ten").ToString
                End With
            Next i
        End If
    End Sub

    Public Function TongHopChu(ByVal strMaHoSoCapGCN As String) As String
        Dim strTongHop As String = ""
        Dim TimKiem As New clsHoSoCapGCN
        Dim dt As New DataTable

        With TimKiem
            'Gán chuỗi kết nối Database cho clsTimKiem
            .Connection = strConnection
            'Mã đơn vị hành chính
            .MaHoSoCapGCN = strMaHoSoCapGCN
        End With
        Try
            'Goi phuong thuc GetData de khoi tao doi tuong clsTimKiem
            If TimKiem.SelectTongHopChu(dt) = "" Then
                If dt.Rows.Count > 0 Then
                    For i As Integer = 0 To dt.Rows.Count - 1
                        strTongHop = strTongHop & dt.Rows(i).Item("QuanHe") & ": " & dt.Rows(i).Item("HoTen") & ", "
                    Next
                    strTongHop = strTongHop.Substring(0, strTongHop.Length - 2)
                End If
            End If
        Catch ex As Exception
            strError = ex.Message
            MsgBox(vbNewLine & "Lỗi: " & vbNewLine + ex.Message, MsgBoxStyle.Information, "DMCLand")
        End Try
        Return strTongHop
    End Function

    Public Function MaLoaiBienDong(ByVal MaHoSo As String) As String
        Dim dt As New DataTable
        Dim strMaLoaiBD As String = ""
        Dim cls As New clsHoSoCapGCN
        cls.Connection = strConnection
        cls.MaHoSoCapGCN = MaHoSo
        If cls.SelectLoaiBienDong(dt) = "" Then
            If dt.Rows.Count > 0 Then
                strMaLoaiBD = dt.Rows(0).Item("MaLoaiBienDong").ToString.Trim
            End If
        End If
        Return strMaLoaiBD
    End Function

    Public Function TongHopChuChuyenNhuong(ByVal strMaHoSoCapGCN As String) As String


        Dim strTongHop As String = ""
        Dim TimKiem As New clsHoSoCapGCN
        Dim dt As New DataTable

        With TimKiem
            'Gán chuỗi kết nối Database cho clsTimKiem
            .Connection = strConnection
            'Mã đơn vị hành chính
            .MaHoSoCapGCN = strMaHoSoCapGCN
        End With
        Try
            'Goi phuong thuc GetData de khoi tao doi tuong clsTimKiem
            If TimKiem.SelectTongHopChuChuyenNhuong(dt) = "" Then
                If dt.Rows.Count > 0 Then
                    For i As Integer = 0 To dt.Rows.Count - 1
                        strTongHop = strTongHop & dt.Rows(i).Item(0) & ", "
                    Next
                    strTongHop = strTongHop.Substring(0, strTongHop.Length - 2)
                End If
            End If
        Catch ex As Exception
            strError = ex.Message
            MsgBox(vbNewLine & "Lỗi: " & vbNewLine + ex.Message, MsgBoxStyle.Information, "DMCLand")
        End Try
        Return strTongHop
    End Function
    Public Function ToiUuXau(ByVal str As String) As String
        str = str.Replace("[", "[[]")
        str = str.Replace("%", "[%]")
        str = str.Replace("'", "''")
        Return str
    End Function

    Public Sub ShowData()
        Dim dtTimKiem As New DataTable
        Dim TimKiem As New clsHoSoCapGCN
        dtTimKiem = New DataTable
        With Me
            'Lam sach du lieu
            dtTimKiem.Clear()
            strMaHoSoCapGCN = ""
            With .grdThongTin
                .RowCount = 0
                .ClearSelection()
            End With
        End With

        With TimKiem
            'Gán chuỗi kết nối Database cho clsTimKiem
            .Connection = strConnection
            .TuSoPhatHanh = txtTuSoPhatHanh.Text
            .DenSoPhatHanh = txtDenSoPhatHanh.Text

        End With
        Try
            If TimKiem.SelectHoSoBySoPhatHanhGCN(dtTimKiem) = "" Then
                'Kiểm tra tính hợp lệ của dữ liệu
                If dtTimKiem Is Nothing Then
                    Return
                End If
                If dtTimKiem.Rows.Count > 0 Then
                    'Trình bày dữ liệu lên Form
                    LoadGrid(dtTimKiem)
                End If
            End If
        Catch ex As Exception
            strError = ex.Message
            MsgBox(vbNewLine & "Lỗi: " & vbNewLine + ex.Message, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub
    Private Sub frmThongKeHoSoNhap_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' ShowData()
        AddColumnsTimKiem()
    End Sub

    Private Sub cmdThongKe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdThongKe.Click
        ShowData()
    End Sub

    Private Sub cmdXuatExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdXuatExcel.Click
        Dim strFileNameTmp As String
        Dim strFileNameKetQua As String
        Dim pathSourcetmp As String = ""
        'D:\33902001\Tháng           D:\33902001\Qúy
        pathSourcetmp = System.Windows.Forms.Application.StartupPath & "\BaoCaoSoPhatHanhGCN"
        If Not System.IO.Directory.Exists(pathSourcetmp) Then
            System.IO.Directory.CreateDirectory(pathSourcetmp)
        End If

        strFileNameTmp = System.Windows.Forms.Application.StartupPath & "\TmpExcel\DanhSachSoPhatHanhGCN.xls"
        strFileNameKetQua = pathSourcetmp & "\DanhSachSoPhatHanhGCN_Tu_" & Replace(txtDenSoPhatHanh.Text.Trim, " ", "") & "_Den_" & Replace(txtDenSoPhatHanh.Text.Trim, " ", "") & ".xls"


        If grdThongTin.RowCount > 0 Then
            Dim excel As New Excel.ApplicationClass
            Dim wBook As Excel.Workbook
            Dim wSheet As Excel.Worksheet

            wBook = excel.Workbooks.Open(strFileNameTmp)
            wSheet = wBook.ActiveSheet() 
            wSheet.Cells(4, 1) = "Ngày " & Now.Day.ToString() & " tháng " & Now.Month.ToString & " năm " & Now.Year.ToString
            wSheet.Cells(5, 1) = "Số phát hành GCN từ " & txtTuSoPhatHanh.Text & " đến " & txtDenSoPhatHanh.Text.Trim

            For j = 0 To grdThongTin.ColumnCount - 1
                If grdThongTin.Columns(j).Visible Then
                    wSheet.Cells(7, j + 1) = grdThongTin.Columns(j).HeaderText.ToString
                    Dim range As Microsoft.Office.Interop.Excel.Range
                    range = wSheet.Cells(7, j + 1)
                    range.VerticalAlignment = 3
                    range.BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic)
                End If
            Next
            For i = 0 To grdThongTin.RowCount - 1
                For j = 0 To grdThongTin.ColumnCount - 1
                    If grdThongTin.Columns(j).Visible Then
                        If Not System.Convert.IsDBNull(grdThongTin(j, i).Value) Then
                            wSheet.Cells(i + 8, j + 1) = grdThongTin(j, i).Value.ToString()
                        Else
                            wSheet.Cells(i + 8, j + 1) = ""
                        End If
                        Dim range As Microsoft.Office.Interop.Excel.Range
                        range = wSheet.Cells(i + 8, j + 1)
                        range.VerticalAlignment = 3
                        range.BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic)
                    End If
                Next
            Next
            wSheet.Columns.AutoFit()

            wBook.SaveAs(strFileNameKetQua)
            excel.Visible = True
            wBook = Nothing
            wBook = Nothing
            wSheet = Nothing
        End If
    End Sub
  
End Class