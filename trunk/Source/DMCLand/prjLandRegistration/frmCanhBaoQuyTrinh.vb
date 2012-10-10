Public Class frmCanhBaoQuyTrinh
    Private strCon As String = ""
    Public Property Conection() As String
        Get
            Return strCon
        End Get
        Set(ByVal value As String)
            strCon = value
        End Set
    End Property
    Private strMaDonViHanhChinh As String = "0"
    Public Property MaDonViHanhChinh() As String
        Get
            Return strMaDonViHanhChinh
        End Get
        Set(ByVal value As String)
            strMaDonViHanhChinh = value
        End Set
    End Property
    Private Sub cmdDieuChinh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub CtrCanhBaoQuyTrinhGiaoViec1_NghiepVuHoSo() Handles CtrCanhBaoQuyTrinhGiaoViec1.NghiepVuHoSo
        Dim strMaHoSoCapGCN As String = ""
        Dim strMaThuaDat As String = ""
        strMaHoSoCapGCN = CtrCanhBaoQuyTrinhGiaoViec1.MaHoSoCapGCN
        strMaThuaDat = CtrCanhBaoQuyTrinhGiaoViec1.MaThuaDat
        If strMaHoSoCapGCN <> "" Then
            Dim cls As New clsHoSoCapGCN
            cls.Connection = GetConnection(bolKetNoiCSDL)
            frmMain.HienThiThongTinThuaDat(strMaHoSoCapGCN, strMaThuaDat)
            cls.TrangThaiMoiNhatCuaHoSo(strMaHoSoCapGCN, strMaThuaDat)
            frmMain.BringToFront()
        End If
    End Sub
End Class