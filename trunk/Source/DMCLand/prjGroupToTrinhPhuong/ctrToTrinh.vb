Imports System.Data.SqlClient
Public Class ctrToTrinh
    Private dtInPhieu As DataTable
    Private strError As String = ""
    Private conn As SqlConnection
    Private strMaDVHC As String = "" '"100241"
    Private strConnection As String = "" ' "Server=DMC-SVR\MAP;Database=georgetown;User ID=sa;Password=1"
    Private strMaHoSoCapGCN As String = ""
    Private index As Int16 = 0
    Private arrMaHoSoCapGCN() As String = {}
    Dim app As New Object
    Private strSoToTrinh As String = ""
    Private strNgayTrinh As String = ""
    Private strMaToTrinh As String = ""
    Public Property MaHoSoCapGCN() As String
        Get
            Return strMaHoSoCapGCN
        End Get
        Set(ByVal value As String)
            strMaHoSoCapGCN = value
        End Set
    End Property
    Public Property MaToTrinh() As String
        Get
            Return strMaToTrinh
        End Get
        Set(ByVal value As String)
            strMaToTrinh = value
        End Set
    End Property

    Public Property MaDVHC() As String
        Get
            Return strMaDVHC
        End Get
        Set(ByVal value As String)
            strMaDVHC = value
        End Set

    End Property
    Public Property Conection() As String
        Get
            Return strConnection
        End Get
        Set(ByVal value As String)
            strConnection = value
        End Set
    End Property
    Public Property SoToTrinh() As String
        Get
            Return strSoToTrinh
        End Get
        Set(ByVal value As String)
            strSoToTrinh = value
        End Set
    End Property
    Public Property NgayTrinh() As String
        Get
            Return strNgayTrinh
        End Get
        Set(ByVal value As String)
            strNgayTrinh = value
        End Set
    End Property
    Public Function TongHopChuSuDung(ByVal MaHoSoCapGCN As String) As String
        Dim strChuSuDung As String = ""
        Dim clsToTrinhCSD As New clsToTrinh
        Dim dtInPhieuCSD As New DataTable
        With Me
            'Lam sach du lieu
            dtInPhieuCSD.Clear()
            .strMaHoSoCapGCN = ""
        End With

        With clsToTrinhCSD
            'Gán chuỗi kết nối Database cho clsTimKiem
            .Connection = strConnection
            .MaHoSoCapGCN = MaHoSoCapGCN
        End With
        Try
            'Goi phuong thuc GetData de khoi tao doi tuong clsTimKiem
            dtInPhieuCSD = clsToTrinhCSD.SelectChuSuDung()
            If dtInPhieuCSD.Rows.Count > 0 Then
                For i As Int16 = 0 To dtInPhieuCSD.Rows.Count - 1
                    strChuSuDung = strChuSuDung & dtInPhieuCSD.Rows(i).Item("HoTen") & ","
                Next
                strChuSuDung = strChuSuDung.Substring(0, strChuSuDung.Length - 1)
            End If
        Catch ex As Exception
            strError = ex.Message
            MsgBox(vbNewLine & "Lỗi: " & vbNewLine + ex.Message, MsgBoxStyle.Information, "DMCLand")
        End Try
        Return strChuSuDung
    End Function
    'Public Function ToiUuXau(ByVal str As String) As String
    '    str = str.Replace("[", "[[]")
    '    str = str.Replace("%", "[%]")
    '    str = str.Replace("'", "''")
    '    Return str
    'End Function
    Public Sub ShowData()
        Dim InPhieu As New clsToTrinh
        dtInPhieu = New DataTable
        With Me
            'Lam sach du lieu
            .dtInPhieu.Clear()
            .strMaHoSoCapGCN = ""

            'With .grdChonIn
            '    .RowCount = 0
            '    .ClearSelection()
            'End With
        End With

        With InPhieu
            'Gán chuỗi kết nối Database cho clsTimKiem
            .Connection = strConnection
            .MaHoSoCapGCN = CrtTimKiemHoSoThuaDat1.MaHoSoCapGCN
        End With
        Try
            If CrtTimKiemHoSoThuaDat1.MaHoSoCapGCN <> "" Then
                'Goi phuong thuc GetData de khoi tao doi tuong clsTimKiem
                dtInPhieu = InPhieu.SelectGCN()
                If dtInPhieu.Rows.Count > 0 Then
                    ' Trinh bay du lieu len DtGrdTimKiem
                    Dim strChu As String = ""
                    strChu = TongHopChuSuDung(CrtTimKiemHoSoThuaDat1.MaHoSoCapGCN)
                    LoadGrid(dtInPhieu, strChu)
                Else
                    MessageBox.Show("Hồ sơ chưa đủ điều kiện !!!")
                End If
            Else
                MessageBox.Show("Chưa có hồ sơ!!!")
            End If
        Catch ex As Exception
            strError = ex.Message
            MsgBox(vbNewLine & "Lỗi: " & vbNewLine + ex.Message, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub
    Public Sub ShowDataToTrinh()
        Dim InPhieu As New clsToTrinh
        dtInPhieu = New DataTable
        With Me
            'Lam sach du lieu
            .dtInPhieu.Clear()
            .strMaHoSoCapGCN = ""

            'With .grdChonIn
            '    .RowCount = 0
            '    .ClearSelection()
            'End With
        End With

        With InPhieu
            'Gán chuỗi kết nối Database cho clsTimKiem
            .Connection = strConnection
            .SoToTrinh = txtToTrinhSo.Text
            .NgayTrinh = dtpNgayTrinhDiaChinh.Value
        End With
        Try
            'Goi phuong thuc GetData de khoi tao doi tuong clsTimKiem
            dtInPhieu = InPhieu.SelectThongTinToTrinh()
            grdChonIn.Rows.Clear()
            If dtInPhieu.Rows.Count > 0 Then
                ' Trinh bay du lieu len DtGrdTimKiem
                Dim strChu As String = ""
                strChu = "" 'TongHopChuSuDung(CrtTimKiemHoSoThuaDat1.MaHoSoCapGCN)
                LoadGrid(dtInPhieu, strChu)

            End If
        Catch ex As Exception
            strError = ex.Message
            MsgBox(vbNewLine & "Lỗi: " & vbNewLine + ex.Message, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub
    Public Sub LoadGrid(ByVal dt As DataTable, ByVal ChuSuDung As String)


        Dim j As Int16 = 0
        j = grdChonIn.Rows.Count
        For i As Integer = 0 To dt.Rows.Count - 1

            Dim dr As New DataGridViewRow()
            grdChonIn.Rows.Add(dr)
            If Not IsDBNull(dt.Rows(i).Item("ToBanDo")) Then
                grdChonIn.Rows(j).Cells(0).Value = dt.Rows(i).Item("ToBanDo")
            End If
            If Not IsDBNull(dt.Rows(i).Item("SoThua")) Then
                grdChonIn.Rows(j).Cells(1).Value = dt.Rows(i).Item("SoThua")
            End If
            If Not IsDBNull(dt.Rows(i).Item("DienTich")) Then
                grdChonIn.Rows(j).Cells(2).Value = dt.Rows(i).Item("DienTich")
            End If
            If Not IsDBNull(dt.Rows(i).Item("DiaChi")) Then
                grdChonIn.Rows(j).Cells(3).Value = dt.Rows(i).Item("DiaChi")
            End If
            If Not IsDBNull(dt.Rows(i).Item("NgayLapToTrinh")) Then
                grdChonIn.Rows(j).Cells(4).Value = dt.Rows(i).Item("NgayLapToTrinh")
            End If
            If Not IsDBNull(dt.Rows(i).Item("NgayQuyetDinhCapGCN")) Then
                grdChonIn.Rows(j).Cells(5).Value = dt.Rows(i).Item("NgayQuyetDinhCapGCN")
            End If
            grdChonIn.Rows(j).Cells(6).Value = ChuSuDung
            grdChonIn.Rows(j).Cells(7).Value = dt.Rows(i).Item("MaHoSoCapGCN")
            grdChonIn.Rows(j).HeaderCell.Value = i
            j = j + 1
        Next i

    End Sub
    'load thong tin du lieu vao grid view
    Public Sub LoadGrid(ByVal dtTimKiem As DataTable)
        If dtTimKiem.Rows.Count > 0 Then
            grdChonIn.Rows.Clear()
            For i As Integer = 0 To dtTimKiem.Rows.Count - 1
                With Me.grdChonIn
                    .RowCount += 1
                    .Item("ToBanDo", i).Value = dtTimKiem.Rows(i).Item("ToBanDo").ToString
                    .Item("SoThua", i).Value = dtTimKiem.Rows(i).Item("SoThua").ToString
                    .Item("DienTich", i).Value = dtTimKiem.Rows(i).Item("DienTichTuNhien").ToString
                    .Item("DiaChiThua", i).Value = dtTimKiem.Rows(i).Item("DiaChiThua").ToString
                    .Item("NgayLapToTrinh", i).Value = dtTimKiem.Rows(i).Item("NgayLapToTrinh").ToString
                    .Item("NgayQuyetDinhCapGCN", i).Value = dtTimKiem.Rows(i).Item("NgayQuyetDinhCapGCN").ToString
                    Dim strChu As String = ""
                    strChu = TongHopChuSuDung(dtTimKiem.Rows(i).Item("MaHoSoCapGCN").ToString)
                    .Item("HoTen", i).Value = strChu
                    .Item("MaHoSoCapGCN", i).Value = dtTimKiem.Rows(i).Item("MaHoSoCapGCN").ToString
                End With
            Next i
        End If
    End Sub

    Public Sub ctrToTrinh_Load() '(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            With Me
                With .dtpNgayTrinhDiaChinh
                    .CustomFormat = "dd/MM/yyyy"
                    .Format = DateTimePickerFormat.Custom
                    .ShowCheckBox = True
                    .Value = Now
                End With
            End With
            With Me
                With .dtpNgayLapTrinhDiaChinh
                    .CustomFormat = "dd/MM/yyyy"
                    .Format = DateTimePickerFormat.Custom
                    .ShowCheckBox = True
                    .Value = Now
                End With
            End With
            conn = New SqlConnection
            conn.ConnectionString = strConnection
            conn.Open()
            app = Nothing
            AddColumns()

            With Me.CrtTimKiemHoSoThuaDat1
                .Connection = strConnection
                .MaDonViHanhChinh = strMaDVHC
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub AddColumns()
        Dim txtClnToBanDo As New DataGridViewTextBoxColumn
        Dim txtClnSoThua As New DataGridViewTextBoxColumn
        Dim txtClnDienTich As New DataGridViewTextBoxColumn
        Dim txtClnDiaChiThua As New DataGridViewTextBoxColumn
        Dim txtClnNgayLapToTrinh As New DataGridViewTextBoxColumn
        Dim txtClnNgayQuyetDinhCapGCN As New DataGridViewTextBoxColumn
        Dim txtClnHoTen As New DataGridViewTextBoxColumn
        Dim txtClnMaHoSoCapGCN As New DataGridViewTextBoxColumn
        Try
            'Tờ bản đồ
            With txtClnToBanDo
                .HeaderText = "Tờ bản đồ"
                .Name = "ToBanDo"
                .Width = 100
            End With
            'Số hiệu thửa
            With txtClnSoThua
                .HeaderText = "Số thửa"
                .Name = "SoThua"
                .Width = 100
            End With
            'Dien tich thửa đất
            With txtClnDienTich
                .HeaderText = "Diện tích"
                .Name = "DienTich"
                .Width = 100
            End With
            'Địa chỉ thửa
            With txtClnDiaChiThua
                .HeaderText = "Địa chỉ đất"
                .Name = "DiaChiThua"
                .Width = 400
            End With
            'Địa chỉ thửa
            With txtClnNgayLapToTrinh
                .HeaderText = "Năm trình"
                .Name = "NgayLapToTrinh"
                .Width = 150
            End With

            With txtClnNgayQuyetDinhCapGCN
                .HeaderText = "Năm cấp GCN"
                .Name = "NgayQuyetDinhCapGCN"
                .Width = 150
            End With
            With txtClnHoTen
                .HeaderText = "Chủ sử dụng"
                .Name = "HoTen"
                .Width = 300
            End With
            With txtClnMaHoSoCapGCN
                .HeaderText = ""
                .Name = "MaHoSoCapGCN"
                .Width = 100
            End With
            'Add all to DataGridView
            With Me.grdChonIn
                .BorderStyle = Windows.Forms.BorderStyle.Fixed3D
                .RowHeadersVisible = False
                .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                'Add Columns
                With .Columns
                    .Add(txtClnToBanDo)
                    .Add(txtClnSoThua)
                    .Add(txtClnDienTich)
                    .Add(txtClnDiaChiThua)
                    .Add(txtClnNgayLapToTrinh)
                    .Add(txtClnNgayQuyetDinhCapGCN)
                    .Add(txtClnHoTen)
                    .Add(txtClnMaHoSoCapGCN)

                End With
                .Columns("MaHoSoCapGCN").Visible = False
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

    Private Sub cmdChapNhan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdChapNhan.Click
        If txtToTrinhSo.Text = "" Then
            MessageBox.Show("Nhập thông tin tờ trình!", "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        If dtpNgayTrinhDiaChinh.Checked = False Then
            MessageBox.Show("Nhập ngày trình!", "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        Dim bol As Boolean = True
        Dim cls As New clsToTrinh
        cls.Connection = strConnection
        cls.SoToTrinh = txtToTrinhSo.Text
        cls.NgayTrinh = dtpNgayTrinhDiaChinh.Value
        For i As Int16 = 0 To grdChonIn.Rows.Count - 1
            cls.MaHoSoCapGCN = grdChonIn.Rows(i).Cells("MaHoSoCapGCN").Value
            If cls.ExecuteToTrinh("") <> "" Then
                bol = False
                MessageBox.Show("Lỗi  " & grdChonIn.Rows(i).Cells("MaHoSoCapGCN").Value)
                Exit For
            End If
        Next
        If bol Then
            MessageBox.Show("Cập nhật thành công !")
        End If
    End Sub

    Private Sub cboBoChon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboBoChon.Click
        Try
            If grdChonIn.Rows.Count > 0 Then
                grdChonIn.Rows.RemoveAt(index)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub cboChon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboChon.Click
        ShowData()
    End Sub

   
    Private Sub cmdTimToTrinh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTimToTrinh.Click
        Dim frm As New frmTimToTrinh
        frm.Conection = strConnection
        frm.MaDVHC = strMaDVHC
        frm.ShowDialog()
        If (frm.SoToTrinh <> "") Then
            
            dtpNgayLapTrinhDiaChinh.Value = frm.NgayLapToTrinh
            txtDonViLapToTrinh.Text = frm.DonViLapToTrinh
            txtToTrinhSo.Text = frm.SoToTrinh
            dtpNgayTrinhDiaChinh.Value = frm.NgayTrinh
            strMaToTrinh = frm.MaToTrinh
            If (frm.NgayTrinh.Trim <> "") Then
                ShowDataToTrinh()
            End If
            frm.Close()
        End If
    End Sub

 
    Private Sub txtToTrinhSo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtToTrinhSo.TextChanged
       
    End Sub
End Class
