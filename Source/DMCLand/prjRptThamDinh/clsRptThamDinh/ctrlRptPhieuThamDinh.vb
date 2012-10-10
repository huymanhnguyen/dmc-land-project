Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports DMC.Land.MucDich
Imports DMC.Land.NguonGoc
Imports DMC.Land.NhaO
Imports System.Windows.Forms
Public Class ctrlRptPhieuThamDinh
    Private clsSoThanhChu As New clsDoiSoThanhChu
    Private dtPhieuThamDinh As New DataTable
    Private dtChuSuDung As New DataTable
    Private dtMucDich As New DataTable
    Private dtNguonGoc As New DataTable
    Private dtTaiSan As New DataTable
    Private dtTuDienPhieuThamDinh As New DataTable
    'Khai báo biến nhận chuỗi kết nối
    Private strConnection As String = ""
    'Khai báo biến kiểm tra lỗi
    Private strError As String = ""
    Private strMaHoSoCapGCN As String = ""
    Private strMaThuaDat As String = ""
    'Khai báo thuộc tính nhận chuỗi kết nối
    Public WriteOnly Property Connection() As String
        Set(ByVal value As String)
            strConnection = value
        End Set
    End Property
    Public Property MaHoSoCapGCN() As String
        Set(ByVal value As String)
            strMaHoSoCapGCN = value
        End Set
        Get
            Return strMaHoSoCapGCN
        End Get
    End Property
    Public Property MaThuaDat() As String
        Set(ByVal value As String)
            strMaThuaDat = value
        End Set
        Get
            Return strMaThuaDat
        End Get
    End Property

    Private Function GetLandImage(ByVal strMaHoSoCapGCN As String, ByVal strConnection As String) As DataTable
        'Dim strConnection As String = "SERVER=" + "dmcthanh" + ";DATABASE=" + "georgetown" + " ;UID=" + "sa" + " ;PWD=" + "1" + ""
        Dim sqlConnect As System.Data.SqlClient.SqlConnection = New System.Data.SqlClient.SqlConnection(strConnection)
        If (sqlConnect.State = ConnectionState.Closed) Then
            sqlConnect.Open()
        End If
        Dim sqlCommand As System.Data.SqlClient.SqlCommand = New System.Data.SqlClient.SqlCommand()
        sqlCommand.Connection = sqlConnect
        sqlCommand.CommandType = CommandType.Text  ' //"UPDATE [georgetown].[dbo].[tblHoSoCapGCN]" +
        '//System.Drawing.Image  img = byteArrayToImage(imgHoSoKiThua);
        sqlCommand.CommandText = "Select HoSoKiThuatThamDinh as Image from tblHoSoCapGCN " & _
            " WHERE MaHoSoCapGCN = '" + strMaHoSoCapGCN + "'" ' ec9cb0c6-504d-4101-834b-019890b2e11c'"
        Dim dataTable As New DataTable
        Dim sqlDataAdapter As New System.Data.SqlClient.SqlDataAdapter(sqlCommand)
        sqlDataAdapter.Fill(dataTable)
        Return dataTable
    End Function

    Private Function ThongTinThuaDatDeNghiCapGCN() As String
        'Khai báo và khởi tạo lớp thông tin Nhà ở - Căn hộ đề nghị cấp GCN
        Dim ThuaDat As New DMC.Land.RptThamDinh.clsRptPhieuThamDinh
        Dim strThuaDat As String = ""
        With ThuaDat
            'Nhận chuỗi kết nối
            .Connection = strConnection
            'Xác nhận Mã hồ sơ cấp GCN
            .MaHoSoCapGCN = strMaHoSoCapGCN
        End With
        Return strThuaDat
    End Function

    Private Function ThongTinNhaODeNghiCapGCN() As String
        'Khai báo và khởi tạo lớp thông tin Nhà ở - Căn hộ đề nghị cấp GCN
        Dim NhaO As New DMC.Land.NhaO.clsNhaO
        Dim strNhaO As String = ""
        With NhaO
            'Nhận chuỗi kết nối
            .Connection = strConnection
            'Xác nhận Mã hồ sơ cấp GCN
            .MaHoSoCapGCN = strMaHoSoCapGCN
        End With
        Return strNhaO
    End Function


    ''' <summary>
    ''' Thông tin Chủ đề nghị cấp GCN
    ''' </summary>
    ''' <returns>Kết quả trả về kiểu chuỗi thông tin các Chủ in ra Phiếu thẩm định</returns>
    ''' <remarks></remarks>
    Private Function ThongTinChuDeNghiCapGCN() As String
        'Khai báo và khởi tạo lớp thông tin Chủ đề nghị cấp GCN
        Dim Chu As New DMC.Land.RptThamDinh.clsRptPhieuThamDinh
        Dim strChuDeNghiCapGCN As String = ""
        'Khai báo bảng chứa danh sách Chủ đề nghị cấp GCN
        Dim dtChu As New DataTable
        With Chu
            'Nhận chuỗi kết nối
            .Connection = strConnection
            'Xác nhận Mã hồ sơ cấp GCN
            .MaHoSoCapGCN = strMaHoSoCapGCN
            'Nhận danh sách Chủ đề nghị cấp GCN
            dtChu = Chu.SelectChuDeNghiCapGCNByMaHoSoCapGCN()
        End With
        If dtChu Is Nothing Then
            Return ""
        End If
        If dtChu.Rows.Count < 1 Then
            Return ""
        End If
        For i As Int16 = 0 To dtChu.Rows.Count - 1
            'Họ tên
            strChuDeNghiCapGCN += dtChu.Rows(i).Item("QuanHe").ToString() + ": "
            strChuDeNghiCapGCN += dtChu.Rows(i).Item("HoTen").ToString().ToUpper
            If (dtChu.Rows(i).Item("SoDinhDanh").ToString() <> "") Or (dtChu.Rows(i).Item("NamSinh").ToString() <> "") Then
                strChuDeNghiCapGCN += vbNewLine
            End If
            'Năm sinh
            If (dtChu.Rows(i).Item("NamSinh").ToString() <> "") Then
                strChuDeNghiCapGCN += "Năm sinh: " + dtChu.Rows(i).Item("NamSinh").ToString() + " "
            End If
            'Số CMND - Hộ chiếu
            If (dtChu.Rows(i).Item("SoDinhDanh").ToString() <> "") Then
                strChuDeNghiCapGCN += "CMND: " + dtChu.Rows(i).Item("SoDinhDanh").ToString()
            End If
            'Địa chỉ thường trú
            If (dtChu.Rows(i).Item("DiaChi").ToString() <> "") Then
                strChuDeNghiCapGCN += vbNewLine + "Địa chỉ thường trú: " + dtChu.Rows(i).Item("DiaChi").ToString()
            End If
            'Nếu có thông tin chủ tiếp theo thì nhảy xuống dòng dưới
            If (i < dtChu.Rows.Count - 1) Then
                strChuDeNghiCapGCN += vbNewLine
            End If
        Next
        Return strChuDeNghiCapGCN
    End Function

    Public Sub ShowData()
        Try
            'Khai báo và khởi tạo đối tượng ReportDocument
            Dim objRep As New ReportDocument
            Dim strFile As String = ""
            If strMaHoSoCapGCN = "" Then
                MsgBox("Chưa có thông tin phiếu thẩm định!", MsgBoxStyle.Information, "DMCLand")
                Exit Sub
            End If
            strFile = Application.StartupPath & "\Reports\KetQuaThamDinh\" & "rptPhieuThamDinh.rpt"
            objRep.Load(strFile, OpenReportMethod.OpenReportByDefault)
            'Khai báo và khởi tạo đối tượng clsRptPhieuThamDinh
            Dim clsThamDinh As New clsRptPhieuThamDinh
            Dim dtPhieuThamDinh As New DataTable
            With clsThamDinh
                'Nhận chuỗi kết nối
                .Connection = strConnection
                'Xác nhận Mã hồ sơ cấp GCN
                .MaHoSoCapGCN = strMaHoSoCapGCN
                dtPhieuThamDinh = clsThamDinh.PhieuThamDinh
            End With

            'Từ điển phiếu thẩm định
            Dim clsTuDienPhieuThamDinh As New clsTuDienPhieuThamDinh
            'Khoi tao gia tri cho thuoc tinh
            With clsTuDienPhieuThamDinh
                'Nhận chuỗi kết nối
                .Connection = strConnection
                .GetData(dtTuDienPhieuThamDinh)
            End With

            'Sơ đồ nhà đất
            Dim dtLandImage As New DataTable
            dtLandImage = Me.GetLandImage(strMaHoSoCapGCN, strConnection)
            If (dtLandImage IsNot Nothing) Then
                If (dtLandImage.Rows.Count > 0) Then
                    objRep.Subreports("subRptSoDoNhaDat").SetDataSource(dtLandImage)
                Else
                    'Ẩn SubRptSoDoNhaDat
                    Me.HideSubReport(objRep, "subRptSoDoNhaDat")
                End If
            Else
                'Ẩn SubRptSoDoNhaDat
                Me.HideSubReport(objRep, "subRptSoDoNhaDat")
            End If

            If (dtPhieuThamDinh IsNot Nothing) And (dtPhieuThamDinh.Rows.Count > 0) Then
                'Gan doi tuong DataTable vao doi tuong ReportDocument
                With objRep.ParameterFields
                    .Item("ThongTinChuDeNghiCapGCN").CurrentValues.AddValue(Me.ThongTinChuDeNghiCapGCN)
                    If IsDBNull(dtPhieuThamDinh.Rows(0).Item("ThongTinThuaDatDeNghiCapGCN")) Then
                        .Item("ThongTinThuaDatDeNghiCapGCN").CurrentValues.AddValue("")
                    Else
                        .Item("ThongTinThuaDatDeNghiCapGCN").CurrentValues.AddValue(dtPhieuThamDinh.Rows(0).Item("ThongTinThuaDatDeNghiCapGCN").ToString)
                    End If

                    If IsDBNull(dtPhieuThamDinh.Rows(0).Item("GhiChuThamDinh")) Then
                        .Item("GhiChuThamDinh").CurrentValues.AddValue("")
                    Else
                        .Item("GhiChuThamDinh").CurrentValues.AddValue(dtPhieuThamDinh.Rows(0).Item("GhiChuThamDinh").ToString)
                    End If

                    If IsDBNull(dtPhieuThamDinh.Rows(0).Item("ThongTinNhaODeNghiCapGCN")) Then
                        .Item("ThongTinNhaODeNghiCapGCN").CurrentValues.AddValue("")
                    Else
                        .Item("ThongTinNhaODeNghiCapGCN").CurrentValues.AddValue(dtPhieuThamDinh.Rows(0).Item("ThongTinNhaODeNghiCapGCN").ToString)
                    End If

                    If IsDBNull(dtPhieuThamDinh.Rows(0).Item("YKienThamDinh")) Then
                        .Item("YKienKhac").CurrentValues.AddValue("")
                    Else
                        .Item("YKienKhac").CurrentValues.AddValue(dtPhieuThamDinh.Rows(0).Item("YKienThamDinh").ToString)
                    End If

                    If IsDBNull(dtPhieuThamDinh.Rows(0).Item("NghiaVuTaiChinh")) Then
                        .Item("NghiaVuTaiChinh").CurrentValues.AddValue("")
                    Else
                        .Item("NghiaVuTaiChinh").CurrentValues.AddValue(dtPhieuThamDinh.Rows(0).Item("NghiaVuTaiChinh").ToString)
                    End If
                    If IsDBNull(dtPhieuThamDinh.Rows(0).Item("DienTichBangChu")) Then
                        .Item("DienTichThucCapBangChu").CurrentValues.AddValue("")
                    Else
                        .Item("DienTichThucCapBangChu").CurrentValues.AddValue(dtPhieuThamDinh.Rows(0).Item("DienTichBangChu").ToString)
                    End If

                    If IsDBNull(dtPhieuThamDinh.Rows(0).Item("DienTich")) Then
                        .Item("DienTichThucCap").CurrentValues.AddValue("")
                    Else
                        .Item("DienTichThucCap").CurrentValues.AddValue(dtPhieuThamDinh.Rows(0).Item("DienTich").ToString)
                    End If

                    If IsDBNull(dtPhieuThamDinh.Rows(0).Item("HanhLangBaoVeCongTrinhHaTang")) Then
                        .Item("HanhLangBaoVeCongTrinhHaTang").CurrentValues.AddValue("")
                    Else
                        .Item("HanhLangBaoVeCongTrinhHaTang").CurrentValues.AddValue(dtPhieuThamDinh.Rows(0).Item("HanhLangBaoVeCongTrinhHaTang").ToString)
                    End If

                    If IsDBNull(dtPhieuThamDinh.Rows(0).Item("tinhtrangTrangChapKhieuKien")) Then
                        .Item("TinhTrangTranhChapKhieuKien").CurrentValues.AddValue("")
                    Else
                        .Item("TinhTrangTranhChapKhieuKien").CurrentValues.AddValue(dtPhieuThamDinh.Rows(0).Item("tinhtrangTrangChapKhieuKien").ToString)
                    End If

                    If IsDBNull(dtPhieuThamDinh.Rows(0).Item("ChiTietQuiHoach")) Then
                        .Item("QuiHoachChiTiet").CurrentValues.AddValue("")
                    Else
                        .Item("QuiHoachChiTiet").CurrentValues.AddValue(dtPhieuThamDinh.Rows(0).Item("ChiTietQuiHoach").ToString)
                    End If
                    If IsDBNull(dtPhieuThamDinh.Rows(0).Item("TongHopDienTichKhongCap")) Then
                        .Item("TongHopDienTichKhongCap").CurrentValues.AddValue("")
                    Else
                        .Item("TongHopDienTichKhongCap").CurrentValues.AddValue(dtPhieuThamDinh.Rows(0).Item("TongHopDienTichKhongCap").ToString)
                    End If

                    If IsDBNull(dtPhieuThamDinh.Rows(0).Item("TrinhTuThuTucPhuong")) Then
                        .Item("TrinhTuThuTucPhuong").CurrentValues.AddValue("")
                    Else
                        .Item("TrinhTuThuTucPhuong").CurrentValues.AddValue(dtPhieuThamDinh.Rows(0).Item("TrinhTuThuTucPhuong").ToString)
                    End If

                    If IsDBNull(dtPhieuThamDinh.Rows(0).Item("ToTrinhPhuong")) Then
                        .Item("ToTrinhPhuong").CurrentValues.AddValue("")
                    Else
                        .Item("ToTrinhPhuong").CurrentValues.AddValue(dtPhieuThamDinh.Rows(0).Item("ToTrinhPhuong").ToString)
                    End If

                    If IsDBNull(dtPhieuThamDinh.Rows(0).Item("NgayNopDuHoSoHopLe")) Then
                        .Item("NgayNopDuHoSoHopLe").CurrentValues.AddValue("")
                    Else
                        .Item("NgayNopDuHoSoHopLe").CurrentValues.AddValue(dtPhieuThamDinh.Rows(0).Item("NgayNopDuHoSoHopLe").ToString)
                    End If

                    If IsDBNull(dtPhieuThamDinh.Rows(0).Item("HoTenCanBoThamDinh")) Then
                        .Item("TenCanBoThamDinh").CurrentValues.AddValue("")
                    Else
                        .Item("TenCanBoThamDinh").CurrentValues.AddValue(dtPhieuThamDinh.Rows(0).Item("HoTenCanBoThamDinh").ToString)
                    End If

                    'Tiêu đề Phiếu thẩm định

                    If IsDBNull(dtPhieuThamDinh.Rows(0).Item("DonViQuanLy")) Then
                        .Item("DonViQuanLy").CurrentValues.AddValue("")
                    Else
                        .Item("DonViQuanLy").CurrentValues.AddValue(dtTuDienPhieuThamDinh.Rows(0).Item("DonViQuanLy").ToString)
                    End If

                    'If IsDBNull(dtPhieuThamDinh.Rows(0).Item("LanhDaoDVTH")) Then
                    .Item("LanhDaoDVTH").CurrentValues.AddValue("")
                    'Else
                    '.Item("LanhDaoDVTH").CurrentValues.AddValue(dtTuDienPhieuThamDinh.Rows(0).Item("LanhDaoDVTH").ToString)
                    'End If
                End With
            Else
                For i As Integer = 0 To objRep.ParameterFields.Count - 1
                    objRep.ParameterFields.Item(i).CurrentValues.AddValue("")
                Next
            End If
            'Gán đối tượng ReportDocument cho điều khiển CrystalReportViewer
            Me.crptThamDinh.ReportSource = objRep
            Me.crptThamDinh.Refresh()
        Catch ex As Exception
            System.Windows.Forms.MessageBox.Show("Lỗi Hiển thị Phiếu thẩm định: " + vbNewLine + ex.Message, "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub HideSubReport(ByRef objRep As ReportDocument, ByVal strSubReportName As String)
        For Each objX In objRep.ReportDefinition.ReportObjects
            'Neu la SubReportName
            If TypeOf (objX) Is SubreportObject Then
                'Ten cua SubReportName la 
                If objX.Name = strSubReportName Then
                    Dim objSubReport As SubreportObject = CType(objX, SubreportObject)
                    objSubReport.ObjectFormat.EnableSuppress = True
                End If
            End If
        Next
    End Sub

    'Public Sub ShowData()
    '    Try
    '        'Khai bao va khoi tao doi tuong ReportDocument
    '        Dim objRep As New ReportDocument
    '        Dim strFile As String = ""
    '        If strMaHoSoCapGCN = "" Then
    '            MsgBox("Chưa có thông tin phiếu thẩm định!", MsgBoxStyle.Information, "DMCLand")
    '            Exit Sub
    '        End If
    '        strFile = Application.StartupPath & "\Reports\KetQuaThamDinh\" & "rptThamDinh.rpt"
    '        objRep.Load(strFile, OpenReportMethod.OpenReportByDefault)

    '        'Khai bao va khoi tao doi tuong clsRptPhieuThamDinh
    '        Dim clsThamDinh As New clsRptPhieuThamDinh
    '        With clsThamDinh
    '            'Nhận chuỗi kết nối
    '            .Connection = strConnection
    '            'Gan gia tri cho cac thuoc tinh doi voi truong hop truy van
    '            .MaHoSoCapGCN = strMaHoSoCapGCN
    '            'Cap nhat thong tin Ho so vao thuoc tinh cua lop
    '        End With
    '        'CHU SU DUNG
    '        Dim ChuHoSoCapGCN As New DMC.Land.ChuHoSoCapGCN.clsChu
    '        'Gan gia tri thuoc tinh
    '        With ChuHoSoCapGCN
    '            'Nhận chuỗi kết nối
    '            .Connection = strConnection
    '            .MaHoSoCapGCN = strMaHoSoCapGCN
    '        End With
    '        'MUC DICH SU DUNG DAT
    '        Dim clsMucDich As New clsMucDich
    '        'Khoi tao gia tri cho thuoc tinh
    '        With clsMucDich
    '            'Nhận chuỗi kết nối
    '            .Connection = strConnection
    '            .DienTichKeKhai = ""
    '            .GhiChu = ""
    '            .KyHieu = ""
    '            .ThoiHan = ""
    '            '.MaHoSoCapGCN = strMaHoSoCapGCN
    '            .MaMucDichSuDung = ""
    '        End With
    '        'NGUON GOC SU DUNG
    '        Dim clsNguonGoc As New clsNguonGoc
    '        'Khoi tao gia tri cho thuoc tinh
    '        With clsNguonGoc
    '            'Nhận chuỗi kết nối
    '            .Connection = strConnection
    '            .DienTich = ""
    '            .GhiChu = ""
    '            .KyHieu = ""
    '            '.MaHoSoCapGCN = strMaHoSoCapGCN
    '            .MaNguonGoc = ""
    '        End With
    '        'TAI SAN GAN LIEN VOI DAT
    '        Dim NhaO As New DMC.Land.NhaO.clsNhaO
    '        'Khoi tao gia tri cho thuoc tinh
    '        With NhaO
    '            'Nhận chuỗi kết nối
    '            .Connection = strConnection
    '            .MaHoSoCapGCN = strMaHoSoCapGCN
    '        End With
    '        'TU DIEN PHIEU THAM DINH
    '        Dim clsTuDienPhieuThamDinh As New clsTuDienPhieuThamDinh
    '        'Khoi tao gia tri cho thuoc tinh
    '        With clsTuDienPhieuThamDinh
    '            'Nhận chuỗi kết nối
    '            .Connection = strConnection
    '            .ChucVuLanhDaoDVTH = ""
    '            .DonViQuanLy = ""
    '            .DonViThucHien = ""
    '            .LanhDaoDVTH = ""
    '        End With

    '        'Khai bao va khoi tao doi tuong Datatable
    '        dtPhieuThamDinh.Clear()
    '        dtChuSuDung.Clear()
    '        dtMucDich.Clear()
    '        dtNguonGoc.Clear()
    '        dtTaiSan.Clear()
    '        dtTuDienPhieuThamDinh.Clear()

    '        'Test
    '        'THÔNG TIN HÌNH HỌC THỬA ĐẤT 
    '        ' here i have define a simple datatable inwhich image will recide
    '        Dim dtLandImage As New DataTable
    '        dtLandImage = Me.GetLandImage(strMaHoSoCapGCN, strConnection)
    '        objRep.SetDataSource(dtLandImage)
    '        'EndTest

    '        'Goi phuong thuc GetData de khoi tao doi tuong
    '        If (clsThamDinh.GetData(dtPhieuThamDinh) = "") And (dtPhieuThamDinh.Rows.Count > 0) Then
    '            'Gan doi tuong DataTable vao doi tuong ReportDocument
    '            With objRep.ParameterFields
    '                .Item("SoThua").CurrentValues.AddValue(dtPhieuThamDinh.Rows(0).Item("SoThua").ToString)
    '                .Item("ToBanDo").CurrentValues.AddValue(dtPhieuThamDinh.Rows(0).Item("ToBanDo").ToString)
    '                .Item("DiaChiThuaDat").CurrentValues.AddValue(dtPhieuThamDinh.Rows(0).Item("DiaChi").ToString)
    '                .Item("DienTichDat").CurrentValues.AddValue(dtPhieuThamDinh.Rows(0).Item("DienTich").ToString + "(m2).") 'Diện tích tự nhiên
    '                .Item("DienTichSDC").CurrentValues.AddValue(dtPhieuThamDinh.Rows(0).Item("DienTichRieng").ToString + "(m2).")
    '                .Item("DienTichSDR").CurrentValues.AddValue(dtPhieuThamDinh.Rows(0).Item("DienTichChung").ToString + "(m2).")
    '                .Item("DienTichThucCap").CurrentValues.AddValue(dtPhieuThamDinh.Rows(0).Item("DienTich").ToString + "(m2).") ' Diện tích thực cấp
    '                .Item("YKienCanBoThamDinh").CurrentValues.AddValue(dtPhieuThamDinh.Rows(0).Item("YKienThamDinh").ToString)

    '                Dim strToTrinhPhuong As String = ""
    '                strToTrinhPhuong = dtPhieuThamDinh.Rows(0).Item("ToTrinhPhuong").ToString
    '                .Item("ToTrinhPhuong").CurrentValues.AddValue(strToTrinhPhuong)

    '                'Dim strDienTichThucCapBangChu As String = ""
    '                'strDienTichThucCapBangChu = " Bằng chữ: "
    '                'strDienTichThucCapBangChu += clsSoThanhChu.DoiChu(dtPhieuThamDinh.Rows(0).Item("DienTich").ToString)
    '                .Item("DienTichThucCapBangChu").CurrentValues.AddValue(dtPhieuThamDinh.Rows(0).Item("DienTichBangChu").ToString) '
    '                .Item("NghiaVuTaiChinh").CurrentValues.AddValue(dtPhieuThamDinh.Rows(0).Item("NghiaVuTaiChinh").ToString)
    '                .Item("YKienKhac").CurrentValues.AddValue("") 'dtPhieuThamDinh.Rows(0).Item("ToBanDo").ToString) '
    '                '.Item("DienTichKhongCap").CurrentValues.AddValue(dtPhieuThamDinh.Rows(0).Item("TongDienTichKhongCap").ToString + "(m2).")
    '                .Item("QuiHoachChiTiet").CurrentValues.AddValue(dtPhieuThamDinh.Rows(0).Item("ChiTietQuiHoach").ToString)
    '                If IsDate(dtPhieuThamDinh.Rows(0).Item("NgayNopDuHoSoHopLe").ToString) Then
    '                    .Item("NgayNopDuHoSoHopLe").CurrentValues.AddValue(Convert.ToDateTime(dtPhieuThamDinh.Rows(0).Item("NgayNopDuHoSoHopLe").ToString).Date)
    '                Else
    '                    .Item("NgayNopDuHoSoHopLe").CurrentValues.AddValue(" ")
    '                End If
    '                .Item("TrinhTuThuTucPhuong").CurrentValues.AddValue(dtPhieuThamDinh.Rows(0).Item("TrinhTuThuTucPhuong").ToString)
    '                .Item("HanhLangBaoVeCongTrinhHaTang").CurrentValues.AddValue(dtPhieuThamDinh.Rows(0).Item("HanhLangBaoVeCongTrinhHaTang").ToString)
    '                .Item("TinhTrangTranhChapKhieuKien").CurrentValues.AddValue("")
    '                .Item("TenCanBoThamDinh").CurrentValues.AddValue(dtPhieuThamDinh.Rows(0).Item("HoTenCanBoThamDinh").ToString.ToUpper)
    '                .Item("TongHopDienTichKhongCap").CurrentValues.AddValue(dtPhieuThamDinh.Rows(0).Item("DienTichKhongCap").ToString)

    '                Dim strDienTichTuNhienBangChu As String = ""
    '                strDienTichTuNhienBangChu = " Bằng chữ: "
    '                strDienTichTuNhienBangChu += clsSoThanhChu.DoiChu(dtPhieuThamDinh.Rows(0).Item("DienTich").ToString)
    '                .Item("DienTichTuNhienBangChu").CurrentValues.AddValue(strDienTichTuNhienBangChu) '
    '                'CHU SU DUNG DAT VA SO HUU TAI SAN GAN LIEN VOI DAT
    '                Dim strChu1 As String = ""
    '                Dim strChu2 As String = ""
    '                If (ChuHoSoCapGCN.GetData(dtChuSuDung) = "") And (dtChuSuDung.Rows.Count > 0) Then
    '                    If dtChuSuDung.Rows(0).Item("Nhom").ToString() = "0" Then
    '                        If dtChuSuDung.Rows(0).Item("GioiTinh") = "False" Then
    '                            strChu1 = "Bà: "
    '                        ElseIf dtChuSuDung.Rows(0).Item("GioiTinh") = "True" Then
    '                            strChu1 = "Ông: "
    '                        Else
    '                            strChu1 = ""
    '                        End If
    '                    End If
    '                    strChu1 += dtChuSuDung.Rows(0).Item("HoTen").ToString + vbNewLine
    '                    If dtChuSuDung.Rows(0).Item("Nhom").ToString() <> "2" Then
    '                        If dtChuSuDung.Rows(0).Item("Nhom").ToString() = "0" Then
    '                            strChu1 += "Sinh năm: " & dtChuSuDung.Rows(0).Item("NamSinh").ToString
    '                        End If
    '                        If dtChuSuDung.Rows(0).Item("Nhom").ToString() = "0" Then
    '                            strChu1 += ", CMT(HC) số: "
    '                        ElseIf dtChuSuDung.Rows(0).Item("Nhom").ToString() = "1" Then
    '                            strChu1 += ", GPĐK số: "
    '                        End If
    '                    End If
    '                    strChu1 += dtChuSuDung.Rows(0).Item("SoDinhDanh").ToString
    '                    If dtChuSuDung.Rows(0).Item("Nhom").ToString() <> "2" Then
    '                        If IsDate(dtChuSuDung.Rows(0).Item("NgayCap").ToString) Then
    '                            strChu1 += ", cấp ngày: " + Convert.ToDateTime(dtChuSuDung.Rows(0).Item("NgayCap")).Date
    '                        End If
    '                        strChu1 += ", tại: " & dtChuSuDung.Rows(0).Item("NoiCap").ToString + vbNewLine
    '                        If dtChuSuDung.Rows(0).Item("Nhom").ToString() = "0" Then
    '                            strChu1 += "Số hộ khẩu: " + dtChuSuDung.Rows(0).Item("SoHoKhau").ToString
    '                        End If
    '                    End If
    '                    strChu1 += " .Địa chỉ: " + dtChuSuDung.Rows(0).Item("DiaChi").ToString
    '                    'CHU 2
    '                    If dtChuSuDung.Rows.Count = 2 Then
    '                        If dtChuSuDung.Rows(1).Item("Nhom").ToString() = "0" Then
    '                            If dtChuSuDung.Rows(1).Item("GioiTinh") = "False" Then
    '                                strChu2 = "Bà: "
    '                            ElseIf dtChuSuDung.Rows(1).Item("GioiTinh") = "True" Then
    '                                strChu2 = "Ông: "
    '                            Else
    '                                strChu2 = ""
    '                            End If
    '                        End If
    '                        strChu2 += dtChuSuDung.Rows(1).Item("HoTen").ToString + vbNewLine
    '                        If dtChuSuDung.Rows(1).Item("Nhom").ToString() <> "2" Then
    '                            If dtChuSuDung.Rows(1).Item("Nhom") = 0 Then
    '                                strChu2 += "Sinh năm: " & dtChuSuDung.Rows(1).Item("NamSinh").ToString
    '                            End If
    '                            If dtChuSuDung.Rows(1).Item("Nhom").ToString() = "0" Then
    '                                strChu2 += ", CMT(HC) số: "
    '                            ElseIf dtChuSuDung.Rows(1).Item("Nhom").ToString() = "1" Then
    '                                strChu2 += " GPĐK số: "
    '                            End If
    '                        End If
    '                        strChu2 += dtChuSuDung.Rows(1).Item("SoDinhDanh").ToString
    '                        If dtChuSuDung.Rows(1).Item("Nhom").ToString() <> "2" Then
    '                            strChu2 += ", cấp ngày: " + Convert.ToDateTime(dtChuSuDung.Rows(1).Item("NgayCap")).Date
    '                            strChu2 += ", tại: " & dtChuSuDung.Rows(1).Item("NoiCap").ToString + vbNewLine
    '                            If dtChuSuDung.Rows(1).Item("Nhom").ToString() = "0" Then
    '                                strChu2 += " Số hộ khẩu: " + dtChuSuDung.Rows(1).Item("SoHoKhau").ToString
    '                            End If
    '                        End If
    '                        strChu2 += " .Địa chỉ: " + dtChuSuDung.Rows(1).Item("DiaChi").ToString
    '                    ElseIf dtChuSuDung.Rows.Count > 2 Then
    '                        strChu2 += " Và các đồng sử dụng: "
    '                        For i As Integer = 1 To dtChuSuDung.Rows.Count - 1
    '                            strChu2 += dtChuSuDung.Rows(i).Item("HoTen").ToString
    '                            If i < (dtChuSuDung.Rows.Count - 1) Then
    '                                strChu2 += ", "
    '                            Else
    '                                strChu2 += "."
    '                            End If
    '                        Next
    '                    End If
    '                End If
    '                'GAN GIA TRI CHU SU DUNG DAT VA SO HUU TAI SAN GAN LIEN VOI DAT LEN PHIEU THAM DINH
    '                .Item("Chu1").CurrentValues.AddValue(strChu1)
    '                .Item("Chu2").CurrentValues.AddValue(strChu2)
    '                'MUC DICH SU DUNG
    '                Dim strMucDich As String = ""
    '                Dim strThoiHan As String = ""
    '                If (clsMucDich.GetData(dtMucDich) = "") And (dtMucDich.Rows.Count > 0) Then
    '                    If dtMucDich.Rows.Count > 0 Then
    '                        strMucDich = dtMucDich.Rows(0).Item("MoTa").ToString
    '                        'If dtMucDich.Rows(0).Item("LoaiThoiHan").ToString = "True" Then
    '                        '    .Item("ThoiHan").CurrentValues.AddValue("Lâu dài")
    '                        'ElseIf dtMucDich.Rows(0).Item("LoaiThoiHan").ToString = "False" Then
    '                        '    If IsDate(dtMucDich.Rows(0).Item("ThoiDiemBatDau").ToString) Then
    '                        '        strThoiHan = " Từ ngày: " + Convert.ToDateTime(dtMucDich.Rows(0).Item("ThoiDiemBatDau").ToString).Date
    '                        '    End If
    '                        '    If IsDate(dtMucDich.Rows(0).Item("ThoiDiemKetThuc").ToString) Then
    '                        '        strThoiHan += " đến ngày: " + Convert.ToDateTime(dtMucDich.Rows(0).Item("ThoiDiemKetThuc").ToString).Date
    '                        '    End If
    '                        'End If
    '                        strThoiHan = dtMucDich.Rows(0).Item("ThoiHan").ToString
    '                    End If
    '                End If
    '                .Item("ThoiHan").CurrentValues.AddValue(strThoiHan)
    '                .Item("MucDich").CurrentValues.AddValue(strMucDich)
    '                'NGUON GOC SU DUNG
    '                Dim strNguonGoc As String = ""
    '                If (clsNguonGoc.GetData(dtNguonGoc) = "") And (dtNguonGoc.Rows.Count > 0) Then
    '                    If dtNguonGoc.Rows.Count > 0 Then
    '                        strNguonGoc = dtNguonGoc.Rows(0).Item("DienTich").ToString
    '                        strNguonGoc += " (m2). " + dtNguonGoc.Rows(0).Item("MoTa").ToString
    '                    End If
    '                End If
    '                .Item("NguonGoc").CurrentValues.AddValue(strNguonGoc)
    '                'TAI SAN GAN LIEN VOI DAT
    '                Dim strTaiSan As String = ""
    '                'If (clsTaiSan.SelectTaiSanKhacByMaHoSoCapGCN(dtTaiSan) = "") And (dtTaiSan.Rows.Count > 0) Then
    '                If dtTaiSan.Rows.Count > 0 Then
    '                    strTaiSan = " Có " + dtTaiSan.Rows(0).Item("LoaiNha").ToString
    '                    strTaiSan += " tại " + dtTaiSan.Rows(0).Item("DiaChiNha").ToString
    '                End If
    '                '  End If
    '                .Item("TaiSan").CurrentValues.AddValue(strTaiSan)

    '                'TỪ ĐIỂN PHIẾU THẨM ĐỊNH
    '                If clsTuDienPhieuThamDinh.GetData(dtTuDienPhieuThamDinh) = "" Then
    '                    'Duyet tren tung Object cua CrystalReport
    '                    Dim objX As ReportObject
    '                    For Each objX In objRep.ReportDefinition.ReportObjects
    '                        'Neu la TextObject
    '                        If TypeOf (objX) Is TextObject Then
    '                            'Ten cua TextObject la company
    '                            If objX.Name = "txtDonViQuanLy" Then
    '                                Dim objText As TextObject = CType(objX, TextObject)
    '                                'Gan chuoi gia tri
    '                                objText.Text = dtTuDienPhieuThamDinh.Rows(0).Item("DonViQuanLy").ToString
    '                            End If
    '                            If objX.Name = "txtDonViThucHien" Then
    '                                Dim objText As TextObject = CType(objX, TextObject)
    '                                'Gan chuoi gia tri
    '                                objText.Text = dtTuDienPhieuThamDinh.Rows(0).Item("DonViThucHien").ToString
    '                            End If
    '                            If objX.Name = "txtDonViThucHien2" Then
    '                                Dim objText As TextObject = CType(objX, TextObject)
    '                                'Gan chuoi gia tri
    '                                objText.Text = dtTuDienPhieuThamDinh.Rows(0).Item("DonViThucHien").ToString
    '                            End If
    '                            If objX.Name = "txtChucVuLanhDaoDVTH" Then
    '                                Dim objText As TextObject = CType(objX, TextObject)
    '                                'Gan chuoi gia tri
    '                                objText.Text = dtTuDienPhieuThamDinh.Rows(0).Item("ChucVuLanhDaoDVTH").ToString
    '                            End If
    '                            If objX.Name = "txtLanhDaoDVTH" Then
    '                                Dim objText As TextObject = CType(objX, TextObject)
    '                                'Gan chuoi gia tri
    '                                objText.Text = dtTuDienPhieuThamDinh.Rows(0).Item("LanhDaoDVTH").ToString
    '                            End If
    '                        End If
    '                    Next
    '                End If
    '            End With
    '        Else
    '            For i As Integer = 0 To objRep.ParameterFields.Count - 1
    '                objRep.ParameterFields.Item(i).CurrentValues.AddValue("")
    '            Next
    '        End If
    '        'Gan doi tuong ReportDocument cho dieu khien CrystalReportViewer
    '        Me.crptThamDinh.ReportSource = objRep
    '        Me.crptThamDinh.Refresh()
    '        objRep.Dispose()
    '        '/Tim kiem
    '    Catch ex As Exception
    '        MsgBox(" Phiếu thẩm định " & vbNewLine & "Lỗi:" & vbNewLine & ex.Message, MsgBoxStyle.Information, "DMCLand")
    '    End Try
    'End Sub
    Private Sub toolCongCuXem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolCongCuXem.Click
        Try
            With Me
                'Phieu tham dinh
                If .toolLoaiBaoCao.Text.Trim = .toolLoaiBaoCao.Items(0).ToString Then
                    .ShowData()
                    'Ho so ky thuat
                ElseIf .toolLoaiBaoCao.Text.Trim = .toolLoaiBaoCao.Items(1).ToString Then
                    .ShowData()
                End If
            End With
        Catch ex As Exception
            MsgBox(" Hiiển thị Phiếu thẩm định " & vbNewLine & " Lỗi: " & vbNewLine & ex.Message, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub
End Class
