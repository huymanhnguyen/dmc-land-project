Imports System.Drawing
Public Class ctrlXetDuyetCapCoSo
    'Khai bao bien kiem tra loi
    Private strError As String = ""
    Private strConnection As String = ""
    Private strMaHoSoCapGCN As String = ""
    ' Tao thuoc tinh nhan ve MaHoSoCapGCN
    Private strMaDonViHanhChinh As String
    Public Property MaDonViHanhChinh() As String
        Get
            Return strMaDonViHanhChinh
        End Get
        Set(ByVal value As String)
            strMaDonViHanhChinh = value
        End Set
    End Property
    Public Property MaHoSoCapGCN() As String
        Get
            Return strMaHoSoCapGCN
        End Get
        Set(ByVal value As String)
            strMaHoSoCapGCN = value
        End Set
    End Property

    ' Tao thuoc tinh nhan ve chuoi ket noi

    Public Property Connection() As String
        Get
            Return strConnection
        End Get
        Set(ByVal value As String)
            strConnection = value
        End Set
    End Property

    ' Tao thuoc tinh nhan ve loi 

    Public ReadOnly Property Err() As String
        Get
            Return strError
        End Get
    End Property


    Private Sub ctrlXetDuyetCapCoSo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class
