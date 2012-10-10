Public Class ctrTrangThaiHoSo
    Private strConnection As String = ""
    'khai bao chuoi nhan ve MaHoSoCapGCN
    Private strMaHoSoCapGCN As String = ""
    'khai bao bien nhan ve loi
    Private strError As String = ""
    Private strMaXacNhan As String = "0"
    Private strTrangThaiHienThoi As String = "0"

    Private strMaDonViHanhChinh As String = ""

    Public Property MaDonViHanhCHinh() As String
        Get
            Return strMaDonViHanhChinh
        End Get
        Set(ByVal value As String)
            strMaDonViHanhChinh = value
        End Set
    End Property


    Public Property MaXacNhan() As String
        Get
            Return strMaXacNhan
        End Get
        Set(ByVal value As String)
            strMaXacNhan = value
        End Set
    End Property
    'khai bao thuoc tinh nhan ve chuoi ket noi DataBase

    Public Property Connection() As String
        Get
            Return strConnection
        End Get
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

    Public Sub ShowTrangThai()
        Dim cls As New clsTrangThaiHoSo
        With cls
            .Connection = strConnection
            .MaHoSoCapGCN = strMaHoSoCapGCN
            .MaDonViHanhCHinh = strMaDonViHanhChinh
            Dim dtHT As New DataTable
            dtHT = .SelGiaTriTrangThaiHoSoHienTHoi
            If dtHT.Rows.Count > 0 Then
                Dim strTrangThai As String = "0"
                strTrangThaiHienThoi = dtHT.Rows(0).Item("TrangThaiHoSoCapGCN")
                strMaXacNhan = strTrangThaiHienThoi + 1
                LabTrangThai.Text = "Đã xong " & dtHT.Rows(0).Item("MoTa")
            End If
        End With

    End Sub

    Public Sub TrangThaiHienThoi()
        Dim cls As New clsTrangThaiHoSo
        With cls
            .Connection = strConnection
            .MaHoSoCapGCN = strMaHoSoCapGCN
            .MaDonViHanhCHinh = strMaDonViHanhChinh
            Dim dtHT As New DataTable
            dtHT = .SelGiaTriTrangThaiHoSoHienTHoi
            If dtHT.Rows.Count > 0 Then
                Dim strTrangThai As String = "0"
                strTrangThaiHienThoi = dtHT.Rows(0).Item("TrangThaiHoSoCapGCN")
            End If
        End With
    End Sub

    Private Sub cmdChapNhan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdChapNhan.Click
        If strConnection = "" Then
            Exit Sub
        End If
        TrangThaiHienThoi()
        Dim cls As New clsTrangThaiHoSo
        With cls
            If chkXacNhan.Checked Then
                If strTrangThaiHienThoi = "41" Or strTrangThaiHienThoi = "42" Or strTrangThaiHienThoi = "31" Or strTrangThaiHienThoi = "32" Or strTrangThaiHienThoi = "51" Then
                    MessageBox.Show("Chưa đủ điều kiện hoàn thành quy trình", "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
                If strTrangThaiHienThoi < 7 Then
                    strTrangThaiHienThoi = strTrangThaiHienThoi
                    .Connection = strConnection
                    .MaHoSoCapGCN = strMaHoSoCapGCN
                    .MaDonViHanhCHinh = strMaDonViHanhChinh
                    .MaXacNhan = strTrangThaiHienThoi + 1
                    .UpdateTrangThaiHoSoCapGCN()
                    chkXacNhan.Checked = False
                    cmdChapNhan.Enabled = False
                    ShowTrangThai()
                End If
            Else
                Exit Sub
            End If

        End With
    End Sub
End Class
