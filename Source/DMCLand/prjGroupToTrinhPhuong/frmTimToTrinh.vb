Imports System.Data.SqlClient
Public Class frmTimToTrinh
    Private strError As String = ""
    Private conn As SqlConnection
    Private strMaDVHC As String = ""
    Private strConnection As String = ""
    Private strSoToTrinh As String = ""
    Private strNgayTrinh As String = ""
    Private strNgayLapToTrinh As String = ""
    Private strDonViLapToTrinh As String = ""
    Private strChucNang As String = ""
    Private strMaToTrinh As String = ""
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
    Public Property DonViLapToTrinh() As String
        Get
            Return strDonViLapToTrinh
        End Get
        Set(ByVal value As String)
            strDonViLapToTrinh = value
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
    Public Property NgayLapToTrinh() As String
        Get
            Return strNgayLapToTrinh
        End Get
        Set(ByVal value As String)
            strNgayLapToTrinh = value
        End Set
    End Property
    Public Sub AddColumns()
        Dim txtClnMaToTrinh As New DataGridViewTextBoxColumn
        Dim txtClnSoToTrinh As New DataGridViewTextBoxColumn
        Dim txtClnNgayLapToTrinh As New DataGridViewTextBoxColumn
        Dim txtClnDonViLap As New DataGridViewTextBoxColumn
        Dim txtClnNgayTrinh As New DataGridViewTextBoxColumn
        Try
            With txtClnMaToTrinh
                .HeaderText = ""
                .Name = "MaToTrinhDiaChinh"
                .Width = 200
            End With
            With txtClnSoToTrinh
                .HeaderText = "Tờ trình"
                .Name = "SoToTrinhDiaChinh"
                .Width = 200
            End With
            'Số hiệu thửa
            With txtClnNgayLapToTrinh
                .HeaderText = "Ngày lập tờ trình"
                .Name = "NgayLapToTrinhDiaChinh"
                .Width = 200
            End With
            'Dien tich thửa đất
            With txtClnDonViLap
                .HeaderText = "Đơn vị lập tờ trình"
                .Name = "DonViLapToTrinhDiaChinh"
                .Width = 200
            End With
            With txtClnNgayTrinh
                .HeaderText = "Ngày lập tờ trình"
                .Name = "NgayTrinhDiaChinh"
                .Width = 200
            End With
            'Add all to DataGridView
            With Me.grdToTrinh
                .BorderStyle = Windows.Forms.BorderStyle.Fixed3D
                .RowHeadersVisible = False
                .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                'Add Columns
                With .Columns
                    .Add(txtClnMaToTrinh)
                    .Add(txtClnSoToTrinh)
                    .Add(txtClnNgayLapToTrinh)
                    .Add(txtClnDonViLap)
                    .Add(txtClnNgayTrinh)
                End With
                .Columns("MaToTrinhDiaChinh").Visible = False
                'Không cho phép thêm
                .AllowUserToAddRows = False
                'Không cho phép xóa
                .AllowUserToDeleteRows = False
                'Không lựa chọn bất kỳ dòng nào
                .ClearSelection()
            End With
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Tờ trình" + vbNewLine + " Lỗi: " & vbNewLine & strError, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub
    Public Sub TrangThaiBanDau(ByVal kt As Boolean)
        cmdGhi.Enabled = Not kt
        cmdThem.Enabled = kt
        cmdSua.Enabled = kt
        cmdXoa.Enabled = kt

    End Sub

    Public Sub TrangThaiText(ByVal kt As Boolean)
        txtToTrinhSo.Enabled = kt
        dtpNgayTrinhDiaChinh.Enabled = kt
        dtpNgayLapTrinhDiaChinh.Enabled = kt
        txtDonViLapToTrinh.Enabled = kt
    End Sub

    Private Sub frmTimToTrinh_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            With Me
                With .dtpNgayLapTrinhDiaChinh
                    .CustomFormat = "dd/MM/yyyy"
                    .Format = DateTimePickerFormat.Custom
                    .ShowCheckBox = True
                    .Value = Now
                End With
                With .dtpNgayTrinhDiaChinh
                    .CustomFormat = "dd/MM/yyyy"
                    .Format = DateTimePickerFormat.Custom
                    .ShowCheckBox = True
                    .Value = Now
                End With
            End With
            conn = New SqlConnection
            conn.ConnectionString = strConnection
            conn.Open()
            TrangThaiBanDau(True)
            TrangThaiText(False)
            AddColumns()
            ShowData()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Public Sub ShowData()
        Dim cls As New clsToTrinh
        Dim dt As New DataTable
        grdToTrinh.Rows.Clear()

        With cls
            'Gán chuỗi kết nối Database cho clsTimKiem
            .Connection = strConnection
            .MaDVHC = strMaDVHC
        End With
        Try
            'Goi phuong thuc GetData de khoi tao doi tuong clsTimKiem
            dt = cls.SelectToTrinh()
            If dt.Rows.Count > 0 Then
                LoadGrid(dt)
            Else
                MessageBox.Show("Hồ sơ chưa đủ điều kiện !!!")
            End If
        Catch ex As Exception
            strError = ex.Message
            MsgBox(vbNewLine & "Lỗi: " & vbNewLine + ex.Message, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub
    'load thong tin du lieu vao grid view
    Public Sub LoadGrid(ByVal dtTimKiem As DataTable)
        If dtTimKiem.Rows.Count > 0 Then
            grdToTrinh.Rows.Clear()
            For i As Integer = 0 To dtTimKiem.Rows.Count - 1
                With Me.grdToTrinh
                    .RowCount += 1
                    .Item("MaToTrinhDiaChinh", i).Value = dtTimKiem.Rows(i).Item("MaToTrinhDiaChinh").ToString
                    .Item("SoToTrinhDiaChinh", i).Value = dtTimKiem.Rows(i).Item("SoToTrinhDiaChinh").ToString
                    .Item("NgayLapToTrinhDiaChinh", i).Value = dtTimKiem.Rows(i).Item("NgayLapToTrinhDiaChinh").ToString
                    .Item("DonViLapToTrinhDiaChinh", i).Value = dtTimKiem.Rows(i).Item("DonViLapToTrinhDiaChinh").ToString
                    .Item("NgayTrinhDiaChinh", i).Value = dtTimKiem.Rows(i).Item("NgayTrinhDiaChinh").ToString
                End With
            Next i
        End If
    End Sub

    Private Sub cmdGhi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGhi.Click
        Dim cls As New clsToTrinh
        With cls
            .Connection = strConnection
            .MaDVHC = strMaDVHC

            .SoToTrinh = txtToTrinhSo.Text
            If dtpNgayLapTrinhDiaChinh.Checked Then
                .NgayLapToTrinh = dtpNgayLapTrinhDiaChinh.Value
            Else
                .NgayLapToTrinh = Nothing
            End If

            If txtToTrinhSo.Text.Trim = "" Then
                .SoToTrinh = Nothing
            Else
                .DonViLapToTrinh = txtDonViLapToTrinh.Text
            End If

            If strMaToTrinh <> "" Then
                .MaToTrinh = strMaToTrinh
            Else
                .MaToTrinh = Nothing
            End If
            If dtpNgayTrinhDiaChinh.Checked Then
                .NgayTrinh = dtpNgayTrinhDiaChinh.Value
            Else
                .NgayTrinh = Nothing
            End If
        End With
        If strChucNang = "them".ToUpper Then
            cls.InsertToTrinh()
            ShowData()
        End If

        If strChucNang = "sua".ToUpper Then
            If strMaToTrinh <> "" Then
                cls.UpdateToTrinh()
            Else
                MessageBox.Show("Chọn tờ trình cần xử lý", "DMCLAND", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
        If strChucNang = "Xoa".ToUpper Then
            If strMaToTrinh <> "" Then
                cls.DeleteToTrinh()
            Else
                MessageBox.Show("Chọn tờ trình cần xử lý", "DMCLAND", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
        strMaToTrinh = ""
        ShowData()
        TrangThaiText(False)
        TrangThaiBanDau(True)
        strChucNang = ""
    End Sub

    Private Sub cmdThem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdThem.Click
        strChucNang = "them".ToUpper
        TrangThaiBanDau(False)
        TrangThaiText(True)
        txtToTrinhSo.Text = ""
        txtDonViLapToTrinh.Text = ""
    End Sub

    Private Sub cmdSua_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSua.Click
        strChucNang = "sua".ToUpper
        TrangThaiBanDau(False)
        TrangThaiText(True)
    End Sub

    Private Sub cmdXoa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdXoa.Click
        strChucNang = "Xoa".ToUpper
        TrangThaiBanDau(False)
    End Sub


    Private Sub grdToTrinh_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdToTrinh.CellDoubleClick
        If e.RowIndex >= 0 Then
            strMaToTrinh = grdToTrinh.Rows(e.RowIndex).Cells("MaToTrinhDiaChinh").Value
            strSoToTrinh = grdToTrinh.Rows(e.RowIndex).Cells("SoToTrinhDiaChinh").Value
            strNgayLapToTrinh = grdToTrinh.Rows(e.RowIndex).Cells("NgayLapToTrinhDiaChinh").Value
            strDonViLapToTrinh = grdToTrinh.Rows(e.RowIndex).Cells("DonViLapToTrinhDiaChinh").Value
            strNgayTrinh = grdToTrinh.Rows(e.RowIndex).Cells("NgayTrinhDiaChinh").Value
            Me.Hide()
        End If
    End Sub

   
    Private Sub grdToTrinh_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdToTrinh.CellClick
        If e.RowIndex >= 0 Then
            strMaToTrinh = grdToTrinh.Rows(e.RowIndex).Cells("MaToTrinhDiaChinh").Value
            txtToTrinhSo.Text = grdToTrinh.Rows(e.RowIndex).Cells("SoToTrinhDiaChinh").Value
            dtpNgayLapTrinhDiaChinh.Value = grdToTrinh.Rows(e.RowIndex).Cells("NgayLapToTrinhDiaChinh").Value
            txtDonViLapToTrinh.Text = grdToTrinh.Rows(e.RowIndex).Cells("DonViLapToTrinhDiaChinh").Value
            dtpNgayTrinhDiaChinh.Text = grdToTrinh.Rows(e.RowIndex).Cells("NgayTrinhDiaChinh").Value
        End If
    End Sub

    Private Sub grdToTrinh_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdToTrinh.CellContentClick
        If e.RowIndex >= 0 Then
            strMaToTrinh = grdToTrinh.Rows(e.RowIndex).Cells("MaToTrinhDiaChinh").Value
            txtToTrinhSo.Text = grdToTrinh.Rows(e.RowIndex).Cells("SoToTrinhDiaChinh").Value
            dtpNgayLapTrinhDiaChinh.Value = grdToTrinh.Rows(e.RowIndex).Cells("NgayLapToTrinhDiaChinh").Value
            txtDonViLapToTrinh.Text = grdToTrinh.Rows(e.RowIndex).Cells("DonViLapToTrinhDiaChinh").Value
            dtpNgayTrinhDiaChinh.Text = grdToTrinh.Rows(e.RowIndex).Cells("NgayTrinhDiaChinh").Value
        End If
    End Sub
End Class