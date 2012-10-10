Imports System.Drawing

Public Class ctrlThongTinQuiTrinhCapGCN
    'Khai báo biến nhận chuỗi kết nối Database
    Private strConnection As String = ""
    'Khai báo biến kiểm tra lỗi
    Private strError As String = ""
    'Khai bao bien MaHoSoCapGCN dung chung
    Private strMaHoSoCapGCN As String = ""
    Private dtThongTinQuiTrinhCapGCN As New DataTable
    Private shortAction As Short = 0
    'Khai báo thuộc tính nhận chuỗi kết nối Database
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

    '
    Public Sub ShowData()
        'Khai báo và khởi tạo đối tượng
        Dim ThongTinQuiTrinhCapGCN As New clsThongTinQuiTrinhCapGCN
        Try
            'Gan gia tri cho cac thuoc tinh doi voi truong hop truy van
            With ThongTinQuiTrinhCapGCN
                'Nhận chuỗi kết nối Database
                .Connection = strConnection
                .MaHoSoCapGCN = strMaHoSoCapGCN
            End With
            'Khởi tạo trạng thái ban đầu
            TrangThaiBanDau()
            'Goi phuong thuc GetData de khoi tao doi tuong
            If ThongTinQuiTrinhCapGCN.GetData(dtThongTinQuiTrinhCapGCN) = "" Then
                'Trình bày dữ liệu
                If dtThongTinQuiTrinhCapGCN.Rows.Count > 0 Then
                    Me.txtKetQuaPheDuyet.Text = dtThongTinQuiTrinhCapGCN.Rows(0).Item("KetQuaPheDuyet").ToString
                    Me.txtKetQuaThamDinh.Text = dtThongTinQuiTrinhCapGCN.Rows(0).Item("KetQuaThamDinh").ToString
                    Me.txtNgayPheDuyet.Text = dtThongTinQuiTrinhCapGCN.Rows(0).Item("NgayPheDuyet").ToString
                    Me.txtNgayThamDinh.Text = dtThongTinQuiTrinhCapGCN.Rows(0).Item("NgayThamDinh").ToString
                    Me.txtNgayTrinhPhuong.Text = dtThongTinQuiTrinhCapGCN.Rows(0).Item("NgayTrinhPhuong").ToString
                    Me.txtToTrinhPhuong.Text = dtThongTinQuiTrinhCapGCN.Rows(0).Item("ToTrinhPhuong").ToString
                End If
            End If
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Thông tin Qui trình cấp GCN" & vbNewLine & " Lỗi: " & vbNewLine & ex.Message, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub
    Public Sub TrangThaiCapNhat(Optional ByVal blnCapNhat As Boolean = False)
        With Me
            .txtKetQuaPheDuyet.ReadOnly = Not blnCapNhat
            .txtKetQuaThamDinh.ReadOnly = Not blnCapNhat
            .txtNgayPheDuyet.ReadOnly = Not blnCapNhat
            .txtNgayThamDinh.ReadOnly = Not blnCapNhat
            .txtNgayTrinhPhuong.ReadOnly = Not blnCapNhat
            .txtToTrinhPhuong.ReadOnly = Not blnCapNhat
            If blnCapNhat Then
                .txtKetQuaPheDuyet.BackColor = Color.White
                .txtKetQuaThamDinh.BackColor = Color.White
                .txtNgayPheDuyet.BackColor = Color.White
                .txtNgayThamDinh.BackColor = Color.White
                .txtNgayTrinhPhuong.BackColor = Color.White
                .txtToTrinhPhuong.BackColor = Color.White
            Else
                .txtKetQuaPheDuyet.BackColor = Color.LightYellow
                .txtKetQuaThamDinh.BackColor = Color.LightYellow
                .txtNgayPheDuyet.BackColor = Color.LightYellow
                .txtNgayThamDinh.BackColor = Color.LightYellow
                .txtNgayTrinhPhuong.BackColor = Color.LightYellow
                .txtToTrinhPhuong.BackColor = Color.LightYellow
            End If
        End With
    End Sub

    Public Sub TrangThaiBanDau()
        With Me
            dtThongTinQuiTrinhCapGCN.Clear()
            .txtKetQuaPheDuyet.Text = ""
            .txtKetQuaThamDinh.Text = ""
            .txtNgayPheDuyet.Text = ""
            .txtNgayThamDinh.Text = ""
            .txtNgayTrinhPhuong.Text = ""
            .txtToTrinhPhuong.Text = ""
        End With
    End Sub

    Private Sub ctrlThongTinQuiTrinhCapGCN_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        With Me
            'Trạng thái cập nhật
            .TrangThaiCapNhat()
        End With
    End Sub
End Class
