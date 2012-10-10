Imports System.Drawing
Public Class ctrlHoSoKeKhai
    'Khai bao bien kiem tra loi
    Private strError As String = ""
    Private strConnection As String = ""
    Private strMaHoSoCapGCN As String = ""
    ' Tao thuoc tinh nhan ve MaHoSoCapGCN

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


    Public Sub TrangThaiCapNhat(Optional ByVal blnCapNhat As Boolean = False)
        With Me
            'Chủ hồ sơ cấp GCN Cơ quan nhà nước
            .CtrlChuCQNN.TrangThaiCapNhat(blnCapNhat)
            'Chủ Hồ sơ cấp GCN Gia đình, cá nhân
            .CtrlChuGDCN.TrangThaiCapNhat(blnCapNhat)
            'Chủ Hồ sơ cấp GCN Tổ chức, doanh nghiệp
            .CtrlChuTCDN.TrangThaiCapNhat(blnCapNhat)
            'End With
            .CtrlTaiLieuKemTheo.TrangThaiCapNhat(blnCapNhat)
            With .CtrlNhaO
                .TrangThaiCapNhat(blnCapNhat)
            End With
            With .CtrlThongTinRungCay
                .TrangThaiCapNhat(blnCapNhat)
            End With
            With .CtrlThongTinCayLauNam
                .TrangThaiCapNhat(blnCapNhat)
            End With

            .CtrlThongTinThuaKeKhai.TrangThaiCapNhat(blnCapNhat)
        End With
    End Sub

    Private Sub ctrlHoSoKeKhai_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        With Me
            Try
                'Chủ hồ sơ cấp GCN cơ quan nhà nước
                With .CtrlChuCQNN
                    .TrangThaiChucNang()
                End With
                'Chủ Hồ sơ cấp GCN Gia đình, cá nhân
                With .CtrlChuGDCN
                    .TrangThaiChucNang()
                End With
                'Nhà ở (Căn hộ)
                With .CtrlNhaO
                    '.AddColumnsTaiSan()
                    .TrangThaiCapNhat()
                End With
                'End With
                With .CtrlThongTinRungCay
                    .TrangThaiCapNhat()
                End With
                With .CtrlThongTinCayLauNam
                    .TrangThaiCapNhat()
                End With
                'Tai lieu kem theo
                With .CtrlTaiLieuKemTheo
                    '.AddColumnsTaiLieuKemTheo()
                    .TrangThaiCapNhat()
                End With
                'Hien thi trang thai Active bar
                .lblActiveHoSoKeKhai.BackColor = Color.LightGray
            Catch ex As Exception
                strError = ex.Message
                MsgBox("Lỗi: " & vbNewLine & strError, MsgBoxStyle.Information, "DMCLand")
            End Try
        End With
    End Sub
End Class
