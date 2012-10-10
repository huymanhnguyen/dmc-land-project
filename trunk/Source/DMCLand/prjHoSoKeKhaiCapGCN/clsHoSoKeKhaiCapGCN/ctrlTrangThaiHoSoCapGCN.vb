Imports DMC.Database
Public Class ctrlTrangThaiHoSoCapGCN
    'khai bao bien nhan ve MaHoSoCapGCN
    Private strMaHoSoCapGCN As String = ""
    'khai bao bien nhan ve chuoi ket noi
    Private strConnection As String = ""
    Private strTrangThaiHoSoCapGCN As String = ""
    Private strFlag As Int32
    'khai bao bien nhan ve loi
    Private strError As String = ""


    Public Property Flag() As Int32
        Get
            Return strFlag
        End Get
        Set(ByVal value As Int32)
            strFlag = value
        End Set
    End Property
    'khai bao thuoc tinh nhan ve chuoi ket noi DataBase
    Private WriteOnly Property Connection() As String
        Set(ByVal value As String)
            strConnection = value
        End Set
    End Property
    'khai bao thuoc tinh nhan ve MaHoSoCapGCN
    Public Property MaHoSoCapGCN() As String
        Get
            Return strMaHoSoCapGCN
        End Get
        Set(ByVal value As String)
            strMaHoSoCapGCN = value
        End Set
    End Property

    Public Property TrangThaiHoSoCapGCN() As String
        Get
            Return strTrangThaiHoSoCapGCN
        End Get
        Set(ByVal value As String)
            strTrangThaiHoSoCapGCN = value
        End Set
    End Property

    'khai bao thuoc tinh nhan ve loi
    Public ReadOnly Property Err() As String
        Get
            Return strError
        End Get
    End Property
    Private Sub btnsua_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsua.Click
        chkXacNhan.Enabled = True
        btnghi.Enabled = True
        btnhuylenh.Enabled = True
        btnsua.Enabled = False
    End Sub

    'Private Sub btnghi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnghi.Click
    '    Dim XacNhan As New clsXacNhan
    '    Try
    '        XacNhan.Connection = strConnection

    '        ' Lay thong tin trang thai Them moi HoSoCapGCN

    '        Dim MyTableThemMoi As DataTable
    '        Dim ParaThemMoiHSCapGCN() As String = {"@TrangThai", "@MaHoSoCapGCN"}
    '        Dim ValuesThemMoiHSCapGCN() As String = {0, strMaHoSoCapGCN}
    '        MyTableThemMoi = XacNhan.GetData("spSelectMaHoSoCapGCN", ValuesThemMoiHSCapGCN, ParaThemMoiHSCapGCN)
    '        If MyTableThemMoi.Rows.Count > 0 Then
    '            strFlag = 0
    '        End If


    '        ' Lay thong tin trang thai HoSoTiepNhan

    '        Dim MyTableHoSoTiepNhan As DataTable
    '        Dim ParaHSTiepNhan() As String = {"@TrangThai", "@MaHoSoCapGCN"}
    '        Dim ValuesHSTiepNhan() As String = {1, strMaHoSoCapGCN}
    '        MyTableHoSoTiepNhan = XacNhan.GetData("spSelectMaHoSoCapGCN", ValuesHSTiepNhan, ParaHSTiepNhan)
    '        If MyTableHoSoTiepNhan.Rows.Count > 0 Then
    '            strFlag = 1
    '        End If

    '        ' Lay thong tin trang thai HoSoKeKhai

    '        Dim MyTableHoSoKeKhai As DataTable
    '        Dim ParaHSKeKhai() As String = {"@TrangThai", "@MaHoSoCapGCN"}
    '        Dim ValuesHSKeKhai() As String = {2, strMaHoSoCapGCN}
    '        MyTableHoSoKeKhai = XacNhan.GetData("spSelectMaHoSoCapGCN", ValuesHSKeKhai, ParaHSKeKhai)
    '        If MyTableHoSoKeKhai.Rows.Count > 0 Then
    '            strFlag = 2
    '        End If

    '        ' Lay thong tin trang thai HoSoXetDuyetCapCoSo

    '        Dim MyTableHSXetDuyetCapCoSo As DataTable
    '        Dim ParaHSXetDuyet() As String = {"@TrangThai", "@MaHoSoCapGCN"}
    '        Dim ValuesHSXetDuyet() As String = {3, strMaHoSoCapGCN}
    '        MyTableHSXetDuyetCapCoSo = XacNhan.GetData("spSelectMaHoSoCapGCN", ValuesHSXetDuyet, ParaHSXetDuyet)
    '        If MyTableHSXetDuyetCapCoSo.Rows.Count > 0 Then
    '            strFlag = 3
    '        End If

    '        ' Lay thong tin trang thai HoSoThamDinh

    '        Dim MyTableHoSoThamDinh As DataTable
    '        Dim ParaHSThamDinh() As String = {"@TrangThai", "@MaHoSoCapGCN"}
    '        Dim ValuesHSThamDinh() As String = {7, strMaHoSoCapGCN}
    '        MyTableHoSoThamDinh = XacNhan.GetData("spSelectMaHoSoCapGCN", ValuesHSThamDinh, ParaHSThamDinh)
    '        If MyTableHoSoThamDinh.Rows.Count > 0 Then
    '            strFlag = 4
    '        Else
    '            strFlag = 7
    '        End If

    '        ' Lay ve trang thai HoSoPheDuyet

    '        Dim MyTableHSPheDuyet As DataTable
    '        Dim ParaHSPheDuyet() As String = {"@TrangThai", "@MaHoSoCapGCN"}
    '        Dim ValuesHSPheDuyet() As String = {5, strMaHoSoCapGCN}
    '        MyTableHSPheDuyet = XacNhan.GetData("spSelectMaHoSoCapGCN", ValuesHSPheDuyet, ParaHSPheDuyet)
    '        If MyTableHSPheDuyet.Rows.Count > 0 Then
    '            strFlag = 5
    '        End If

    '        ' Lay thong tin trang thai HoSoCapGCN

    '        Dim MyTableHSCapGCN As DataTable
    '        Dim ParaHSCapGCN() As String = {"@TrangThai", "@MaHoSoCapGCN"}
    '        Dim ValuesHSCapGCN() As String = {8, strMaHoSoCapGCN}
    '        MyTableHSCapGCN = XacNhan.GetData("", ValuesHSCapGCN, ParaHSCapGCN)
    '        If MyTableHSCapGCN.Rows.Count > 0 Then
    '            strFlag = 8
    '        End If


    '        If Not strMaHoSoCapGCN = Nothing Then
    '            If chkXacNhan.Checked = True Then
    '                XacNhan.UpdateTrangThaiHoSoCapGCN()
    '            End If
    '        End If


    '    Catch ex As Exception
    '        strError = ex.Message
    '        MsgBox(" Cập nhật thông tin Phê duyệt " & vbNewLine & " Lỗi: " & vbNewLine & strError, MsgBoxStyle.Information, "DMCLand")
    '    End Try
    'End Sub

    Private Sub btnhuylenh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnhuylenh.Click
        chkXacNhan.Checked = False
        chkXacNhan.Enabled = False
        btnghi.Enabled = False
        btnsua.Enabled = True
        btnhuylenh.Enabled = False
    End Sub



End Class
