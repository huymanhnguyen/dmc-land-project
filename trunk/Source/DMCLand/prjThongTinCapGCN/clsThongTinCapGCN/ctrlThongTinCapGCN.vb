
Public Class ctrlThongTinCapGCN


    'Khai báo biến nhận chuỗi kết nối Database
    Private strConnection As String = ""
    'Khai báo biến kiểm tra lỗi
    Private strError As String = ""
    'Khai báo biến Mã hồ số cấp GCN
    Private strMaHoSoCapGCN As String = ""
    '
    Private strMaDVHC As String = ""
    Private dtThongTinGCN As New DataTable
    '
    Private shortAction As Short = 0
    'Private strToTrinh As String = ""
    'Private strNgayTrinh As String = ""

    'Private strNgayThamDinh As String = ""
    'Private strThangThamDinh As String = ""
    'Private strNguoiThamDinh As String = ""
    'Private strNamThamDinh As String = ""

    'Private strYKienThamDinh As String = ""

    ''Khai báo thuộc tính nhận chuỗi kết nối Database
    'Public WriteOnly Property ToTrinh() As String

    '    Set(ByVal value As String)
    '        strToTrinh = value
    '    End Set
    'End Property
    Private strUserName As String = ""
    Public Property UserName() As String
        Get
            Return strUserName
        End Get
        Set(ByVal value As String)
            strUserName = value
        End Set
    End Property


    Public WriteOnly Property DVHC() As String
        Set(ByVal value As String)
            strMaDVHC = value
        End Set
    End Property
    Public WriteOnly Property Connection() As String
        Set(ByVal value As String)
            strConnection = value
        End Set
    End Property

    Public WriteOnly Property MaHoSoCapGCN() As String
        Set(ByVal value As String)
            strMaHoSoCapGCN = value
        End Set
    End Property

    Private Sub btnXemVaIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXemVaIn.Click
        Try
            If strMaHoSoCapGCN <> "" Then
                Dim RptGCN As New frmRptGCN
                With RptGCN
                    With .CtrlRptGCN
                        .Connection = strConnection
                        .MaHoSoCapGCN = strMaHoSoCapGCN
                    End With
                    .Show()
                End With
            Else
                MsgBox("Chưa có thông tin cấp GCN!", MsgBoxStyle.Information, "DMCLand")
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox("Lỗi trong CtrlThongTinCapGCN: " & vbNewLine & ex.Message, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub
  
End Class
