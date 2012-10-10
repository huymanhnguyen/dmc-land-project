Public Class frmTongHopChuSuDung
    'Private strConnection As String = "" 'Khai báo biến nhận chuỗi kết nối
    'Private strError As String = "" 'Khai bao bien kiem tra loi
    '' Hien thi du lieu Phe duyet 
    'Private strMaHoSoCapGCN As String = ""
    'Private strTongHop As String = ""

    'Private shFlag As Short = 0
    ''Khai báo thuộc tính nhận chuỗi kết nối Database
    'Public WriteOnly Property Connection() As String
    '    Set(ByVal value As String)
    '        strConnection = value
    '    End Set
    'End Property
    'Public WriteOnly Property Flag() As String
    '    Set(ByVal value As String)
    '        shFlag = value
    '    End Set
    'End Property

    'Public WriteOnly Property MaHoSoCapGCN() As String
    '    Set(ByVal value As String)
    '        strMaHoSoCapGCN = value
    '    End Set
    'End Property
    'Public Property TongHop() As String
    '    Get
    '        Return strTongHop
    '    End Get
    '    Set(ByVal value As String)
    '        strTongHop = value
    '    End Set
    'End Property
    'Private Sub frmTongHopChuSuDung_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    '    ShowData()
    'End Sub
    'Public Sub AddColumnsTongHop()

    '    Try
    '        With Me.grdTongHopChiTiet
    '            .BorderStyle = Windows.Forms.BorderStyle.Fixed3D
    '            .RowHeadersVisible = False
    '            .ColumnHeadersDefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleCenter
    '            .SelectionMode = Windows.Forms.DataGridViewSelectionMode.FullRowSelect
    '            'Add Columns
    '            With .Columns

    '                With .Item("MoTa")
    '                    .HeaderText = "Mô tả"
    '                    .Width = 400
    '                End With
    '                With .Item("GiaTriThemVao")
    '                    .HeaderText = "Giá trị thêm vào"
    '                    .Width = 400
    '                End With
    '                .Item("MaTongHop").Visible = False
    '            End With
    '            'Không cho phép thêm
    '            .AllowUserToAddRows = False
    '            'Không cho phép xóa
    '            .AllowUserToDeleteRows = False
    '            'Không lựa chọn bất kỳ dòng nào
    '            .ClearSelection()
    '        End With
    '    Catch ex As Exception
    '        strError = ex.Message
    '        MsgBox(" Tìm kiếm" + vbNewLine + " Lỗi: " & vbNewLine & strError, MsgBoxStyle.Information, "DMCLand")
    '    End Try
    'End Sub
    'Public Function GetTongHopChuSuDung() As String
    '    Dim strTongHopChu As String = ""
    '    If (radTongHop1.Checked) Then
    '        strTongHopChu = "1"
    '    End If
    '    If (radTongHop2.Checked) Then
    '        strTongHopChu = "2"
    '    End If
    '    If (radTongHop3.Checked) Then
    '        strTongHopChu = "3"
    '    End If
    '    Return strTongHopChu
    'End Function

    'Public Sub ShowData()
    '    'Khai bao va khoi tao doi tuong clsThongTinCapGCN
    '    Dim ThongTinCapGCN As New clsThongTinCapGCN
    '    Try
    '        'Gan gia tri cho cac thuoc tinh doi voi truong hop truy van
    '        With ThongTinCapGCN
    '            .Connection = strConnection
    '            .MaTongHop = GetTongHopChuSuDung()
    '        End With

    '        'Goi phuong thuc GetData de khoi tao doi tuong clsHSKKTaiSan
    '        Dim dtThongTinCapGCN As DataTable
    '        dtThongTinCapGCN = ThongTinCapGCN.SelectTongHopCSD()
    '        ' Trinh bay du lieu len grdvwTaiSan
    '        If dtThongTinCapGCN.Rows.Count > 0 Then
    '            grdTongHopChiTiet.ClearSelection()
    '            grdTongHopChiTiet.Columns.Clear()
    '            grdTongHopChiTiet.DataSource = dtThongTinCapGCN
    '            AddColumnsTongHop()
    '        End If
    '    Catch ex As Exception
    '        System.Windows.Forms.MessageBox.Show(ex.Message)
    '    End Try
    'End Sub

    'Private Sub radTongHop2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radTongHop2.CheckedChanged
    '    ShowData()
    'End Sub

    'Private Sub radTongHop3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radTongHop3.CheckedChanged
    '    ShowData()
    'End Sub

    'Public Function GetChuSuDung(ByVal flag As String) As DataTable
    '    Dim cls As New clsThongTinCapGCN()
    '    Dim dt As New DataTable()
    '    cls.Connection = strConnection
    '    cls.MaHoSoCapGCN = strMaHoSoCapGCN
    '    cls.flag = flag
    '    dt = cls.SelectChuSuDung()
    '    Return dt
    'End Function

    'Public Function TenChu(ByVal index As Int16, ByVal nhom As String) As String
    '    Dim str As String = ""
    '    Dim dt As New DataTable
    '    dt = GetChuSuDung(nhom)
    '    If (dt.Rows.Count > 0) Then
    '        Dim NhomDoiTuong As String = ""
    '        NhomDoiTuong = dt.Rows(0).Item("Nhom")
    '        If GetTongHopChuSuDung() = "1" Then

    '            If (dt.Rows.Count) = 1 Then
    '                If (dt.Rows(0).Item("GioiTinh") = True) Then
    '                    str = PTChuoi(grdTongHopChiTiet.Rows(index).Cells("GiaTriThemVao").Value, ",", 0) & ":" & GetThongTinChu(dt)
    '                End If
    '                If (dt.Rows(0).Item("GioiTinh") = False) Then
    '                    str = PTChuoi(grdTongHopChiTiet.Rows(index).Cells("GiaTriThemVao").Value, ",", 1) & ":" & GetThongTinChu(dt)
    '                End If
    '            Else
    '                If (dt.Rows(0).Item("GioiTinh") = True) Then
    '                    str = PTChuoi(grdTongHopChiTiet.Rows(index).Cells("GiaTriThemVao").Value, ",", 0) & " :" & GetThongTinChu(dt)
    '                End If
    '                If (dt.Rows(0).Item("GioiTinh") = False) Then
    '                    str = PTChuoi(grdTongHopChiTiet.Rows(index).Cells("GiaTriThemVao").Value, ",", 1) & " :" & GetThongTinChu(dt)
    '                End If
    '            End If


    '        End If
    '        If GetTongHopChuSuDung() = "2" Then
    '            str = GetThongTinChu(dt) & " , " & grdTongHopChiTiet.Rows(index).Cells("GiaTriThemVao").Value
    '        End If
    '        If GetTongHopChuSuDung() = "3" Then
    '            str = GetThongTinChu(dt) & " , " & grdTongHopChiTiet.Rows(index).Cells("GiaTriThemVao").Value
    '        End If
    '    End If
    '    Return str
    'End Function

    'Public Function PTChuoi(ByVal str As String, ByVal kt As Char, ByVal index As Int16) As String
    '    Dim n As Integer
    '    Dim st() As Char = str.ToCharArray
    '    Dim k As Integer = 0
    '    For n = 0 To st.Length - 1
    '        If st(n) = kt Then
    '            k = k + 1
    '        End If
    '    Next
    '    Dim m() As Char = str.Split(kt)(index)
    '    Dim t As String = CType(m, String)
    '    Return t
    'End Function

    'Public Function GetThongTinChu(ByVal dt As DataTable) As String
    '    Dim str As String = ""
    '    If dt.Rows.Count > 0 Then
    '        Dim NhomDoiTuong As String = ""
    '        For i As Int16 = 0 To dt.Rows.Count - 1
    '            NhomDoiTuong = dt.Rows(i).Item("Nhom")
    '            If NhomDoiTuong = "0" Then
    '                str = str & dt.Rows(i).Item("HoTen") & ", Năm sinh: " & dt.Rows(i).Item("NamSinh") & ",Quốc tịch: " & dt.Rows(i).Item("QuocTich") & ", Số CMT(HC): " & dt.Rows(i).Item("SoDinhDanh") & ", Ngày cấp: " & Format(dt.Rows(i).Item("NgayCap"), "dd/MM/yyyy") & ", Nơi cấp: " & dt.Rows(i).Item("NoiCap") & "\\"
    '            End If
    '            If NhomDoiTuong = "1" Then
    '                str = str & dt.Rows(i).Item("HoTen") & ", Số đăng ký:" & dt.Rows(i).Item("SoDinhDanh") & ",Ngày cấp: " & Format(dt.Rows(i).Item("NgayCap"), "dd/MM/yyyy") & ", Nơi cấp: " & dt.Rows(i).Item("NoiCap") & ", Địa chỉ" & dt.Rows(i).Item("DiaChi") & "\\"
    '            End If
    '            If NhomDoiTuong = "2" Then
    '                str = str & dt.Rows(i).Item("HoTen") & ", Địa chỉ: " & dt.Rows(i).Item("DiaChi") & "\\"
    '            End If
    '        Next
    '    End If
    '    Return str
    'End Function

    'Private Sub grdTongHopChiTiet_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdTongHopChiTiet.CellDoubleClick
    '    Dim index As Int16
    '    index = e.RowIndex
    '    If (GetTongHopChuSuDung() = "1") Then
    '        strTongHop = TenChu(index, "1")
    '        Me.Hide()
    '    End If
    '    If ((GetTongHopChuSuDung() = "2") Or (GetTongHopChuSuDung() = "3")) Then
    '        strTongHop = TenChu(index, "2")
    '        Me.Hide()
    '    End If
    'End Sub

End Class