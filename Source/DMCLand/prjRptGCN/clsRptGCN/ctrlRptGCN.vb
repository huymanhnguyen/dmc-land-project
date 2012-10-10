Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports DMC.Land.MucDich
Imports DMC.Land.NguonGoc
Imports DMC.Land.NhaO
Imports CrystalDecisions.Windows.Forms
Imports System.Windows.Forms
Imports System.Drawing

Public Class ctrlRptGCN
    Private clsSoThanhChu As New clsDoiSoThanhChu
    Private dtGCN As New DataTable
    Private dtChuGCN As New DataTable
    Private dtMucDich As New DataTable
    Private dtNguonGoc As New DataTable
    Private dtTaiSan As New DataTable
    Private dtTaiSanNhaO As New DataTable
    Private dtRungCay As New DataTable
    Private dtCayLauNam As New DataTable
    Private dtTuDienGCN As New DataTable
    'Khai báo biến nhận chuỗi kết nối Database
    Private strConnection As String = ""
    'Khai báo biến nhận thông báo lỗi
    Private strError As String = ""
    'Khai báo Mã hồ sơ cấp GCN
    Private strMaHoSoCapGCN As String = ""
    Private objRep As ReportDocument
    'Khai báo thuộc tính nhận chuỗi kết nối Database
    Public WriteOnly Property Connection() As String
        Set(ByVal value As String)
            strConnection = value
        End Set
    End Property
    'Khai báo thuộc tính Mã hồ sơ cấp GCN
    Public Property MaHoSoCapGCN() As String
        Set(ByVal value As String)
            strMaHoSoCapGCN = value
        End Set
        Get
            Return strMaHoSoCapGCN
        End Get
    End Property

    Private Function GetLandImage(ByVal strMaHoSoCapGCN As String, ByVal strConnection As String) As DataTable
        Dim sqlConnect As System.Data.SqlClient.SqlConnection = New System.Data.SqlClient.SqlConnection(strConnection)
        If (sqlConnect.State = ConnectionState.Closed) Then
            sqlConnect.Open()
        End If

        Dim sqlCommand As System.Data.SqlClient.SqlCommand = New System.Data.SqlClient.SqlCommand()
        sqlCommand.Connection = sqlConnect
        sqlCommand.CommandType = CommandType.Text

        sqlCommand.CommandText = "Select HoSoKiThuatThamDinh as Image from tblHoSoCapGCN " & _
            " WHERE MaHoSoCapGCN = '" + strMaHoSoCapGCN + "'"

        Dim dataTable As New DataTable
        Dim sqlDataAdapter As New System.Data.SqlClient.SqlDataAdapter(sqlCommand)

        sqlDataAdapter.Fill(dataTable)

        Return dataTable
    End Function

    Private Function addColumnValue(ByRef dtChu As DataTable, ByVal intRowIndex As Int32) As DataTable
        Dim strError As String
        Dim dtTemp As New DataTable
        Try
            'Chắc chắn rằng tồn tại ít nhất một bản ghi trong bảng dtChu
            If (dtChu Is Nothing) Then
                Return Nothing
            End If
            'Chắc chắn rằng có ít nhất intRowIndex bản ghi trong bảng 
            If (dtChu.Rows.Count <= intRowIndex) Then
                Return Nothing
            End If
            'Dòng một
            Dim workColumn0 As New DataColumn("Line0", Type.GetType("System.String"))
            dtTemp.Columns.Add(workColumn0)
            workColumn0.AllowDBNull = True
            'Dòng một
            Dim workColumn1 As New DataColumn("Line1", Type.GetType("System.String"))
            dtTemp.Columns.Add(workColumn1)
            workColumn1.AllowDBNull = True
            'Dòng hai
            Dim workColumn2 As New DataColumn("Line2", Type.GetType("System.String"))
            dtTemp.Columns.Add(workColumn2)
            workColumn2.AllowDBNull = True
            'Gán giá trị cho các Cột trong bảng dtTemp
            Dim strLine0 As String = "", strLine1 As String = "", strLine2 As String = ""
            'If (dtChu.Rows(intRowIndex).Item("GioiTinh").ToString = "True") Then
            '    strLine1 = "Ông: "
            'ElseIf (dtChu.Rows(intRowIndex).Item("GioiTinh").ToString = "False") Then
            '    strLine1 = "Bà: "
            'End If
            If (dtChu.Rows(intRowIndex).Item("QuanHe").ToString.Trim() <> "") Then
                strLine1 = dtChu.Rows(intRowIndex).Item("QuanHe").ToString.Trim() + ": "
            End If
            'Gán tên chủ
            If (dtChu.Rows(intRowIndex).Item("HoTen").ToString <> "") Then
                strLine1 += dtChu.Rows(intRowIndex).Item("HoTen").ToString
            End If
            'Năm sinh, CMND, Địa chỉ thường trú
            If (dtChu.Rows(intRowIndex).Item("NamSinh").ToString <> "") Then
                strLine2 = "Năm sinh: " + dtChu.Rows(intRowIndex).Item("NamSinh").ToString
            End If
            If (dtChu.Rows(intRowIndex).Item("SoDinhDanh").ToString <> "") Then
                'Chèn thêm dấu , vào giữa năm sinh và CMND
                If strLine2 <> "" Then
                    strLine2 += ", "
                End If
                strLine2 += "CMND: " + dtChu.Rows(intRowIndex).Item("SoDinhDanh").ToString
            End If
            If (dtChu.Rows(intRowIndex).Item("DiaChi").ToString <> "") Then
                strLine2 += vbNewLine + "Địa chỉ thường trú: " + dtChu.Rows(intRowIndex).Item("DiaChi").ToString
            End If

            If (dtChu.Rows(intRowIndex).Item(0).ToString.Trim() <> "") Then
                strLine0 = dtChu.Rows(0).Item(0).ToString.Trim()
            End If
            If (dtChu.Rows(intRowIndex).Item(0).ToString.Trim() <> "") Then
                strLine1 = dtChu.Rows(0).Item(1).ToString.Trim()
            End If
            If (dtChu.Rows(intRowIndex).Item(0).ToString.Trim() <> "") Then
                strLine2 = dtChu.Rows(0).Item(2).ToString.Trim()
            End If
            dtTemp.Rows.Add(strLine0, strLine1, strLine2)
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return dtTemp
    End Function

#Region "Dự thảo GCN"
    Public Sub ShowDataBanThaoGCN()
        Try
            'Khai bao va khoi tao doi tuong ReportDocument
            objRep = New ReportDocument
            Dim strFile As String = ""
            If strMaHoSoCapGCN = "" Then
                MsgBox("Chưa có thông tin cấp GCN!", MsgBoxStyle.Information, "DMCLand")
                Exit Sub
            End If
            strFile = Application.StartupPath & "\Reports\BanThaoGCN\" & "rptBanThaoGCN.rpt"
            objRep.Load(strFile, OpenReportMethod.OpenReportByDefault)
            'Tổng hợp Thông tin CHỦ GIẤY CHỨNG NHẬN
            Dim clsChuGCN As New clsThongTinChuGCN
            'Gán giá trị cho các thuộc tính trong trường hợp truy vấn
            With clsChuGCN
                'Nhận chuỗi kết nối Database
                .Connection = strConnection
                .MaHoSoCapGCN = strMaHoSoCapGCN
            End With
            dtChuGCN.Clear()
            'Hiển thị thông tin Chủ 1
            '' ''Dim ThongTinChu As New clsThongTinChuGCN
            '' ''Dim dtThongTinChu As New DataTable
            '' ''Dim dtThongTinChu1 As New DataTable
            '' ''With ThongTinChu
            '' ''    'Nhận chuỗi kết nối Database
            '' ''    .Connection = strConnection
            '' ''    .MaHoSoCapGCN = strMaHoSoCapGCN
            '' ''    .SelectChuDeNghiCapGCNByMaHoSoCapGCN(dtThongTinChu)
            '' ''End With
            '' ''dtThongTinChu1 = Me.addColumnValue(dtThongTinChu, 0)
            ' '' ''Chắc chắn rằng tồn tại ít nhất một Chủ hồ sơ cấp GCN
            '' '' '' ''If (dtThongTinChu1 IsNot Nothing) Then
            '' ''If ((dtThongTinChu1.Rows.Count > 0) And (dtThongTinChu1.Rows(0).Item(0).ToString <> "")) Then
            '' ''    objRep.Subreports("subRptChu1").SetDataSource(dtThongTinChu1)
            '' ''Else
            '' ''    'Nếu không có thì ẩn SubReport
            '' ''    Me.HideSubReport(objRep, "subRptChu1")
            '' ''End If
            '' ''    'Hiển thị thông tin Chủ 2
            '' ''    Dim dtThongTinChu2 As New DataTable
            '' ''    dtThongTinChu2 = Me.addColumnValue(dtThongTinChu, 1)
            '' ''    If (dtThongTinChu2 IsNot Nothing) Then
            '' ''        If ((dtThongTinChu2.Rows.Count > 0) And (dtThongTinChu2.Rows(0).Item(0).ToString <> "")) Then
            '' ''            objRep.Subreports("subRptChu2").SetDataSource(dtThongTinChu2)
            '' ''        Else
            '' ''            'Nếu không có thì ẩn SubReport
            '' ''            Me.HideSubReport(objRep, "subRptChu2")
            '' ''        End If
            '' ''    Else
            '' ''        'Nếu không có thì ẩn SubReport
            '' ''        Me.HideSubReport(objRep, "subRptChu2")
            '' ''    End If
            '' ''    'Hiển thị thông tin Chủ 3
            '' ''    Dim dtThongTinChu3 As New DataTable
            '' ''    dtThongTinChu3 = Me.addColumnValue(dtThongTinChu, 2)
            '' ''    If (dtThongTinChu3 IsNot Nothing) Then
            '' ''        If ((dtThongTinChu3.Rows.Count > 0) And (dtThongTinChu3.Rows(0).Item(0).ToString <> "")) Then
            '' ''            objRep.Subreports("subRptChu3").SetDataSource(dtThongTinChu3)
            '' ''        Else
            '' ''            'Nếu không có thì ẩn SubReport
            '' ''            Me.HideSubReport(objRep, "subRptChu3")
            '' ''        End If
            '' ''    Else
            '' ''        'Nếu không có thì ẩn SubReport
            '' ''        Me.HideSubReport(objRep, "subRptChu3")
            '' ''    End If

            '' ''Else
            '' ''    'Nếu không có Chủ hồ sơ nào đề nghị cấp GCN thì ẩn SubReport
            '' ''    Me.HideSubReport(objRep, "subRptChu1")
            '' ''    Me.HideSubReport(objRep, "subRptChu2")
            '' ''    Me.HideSubReport(objRep, "subRptChu3")
            '' ''End If
            Dim ThongTinChu As New clsThongTinChuGCN
            Dim dtThongTinChu As New DataTable
            Dim dtThongTinChu1 As New DataTable
            Dim dtThongTinChu2 As New DataTable
            With ThongTinChu
                'Nhận chuỗi kết nối Database
                .Connection = strConnection
                .MaHoSoCapGCN = strMaHoSoCapGCN
                .SelectChuDeNghiCapGCNByMaHoSoCapGCN(dtThongTinChu)
            End With

            ' phan tich chuoi chu su dung
            Dim strCSD As String = ""
            strCSD = dtThongTinChu.Rows(0).Item(0)
            Dim arrCSD() As String = strCSD.Split("^")
            Dim strLine0 As String = "", strLine1 As String = "", strLine2 As String = ""
            If arrCSD.Length >= 3 Then
                'truong hop co dong so huu             
                Dim CSD1() As String = arrCSD(1).Split("~")
                Dim CSD2() As String = arrCSD(3).Split("~")
                dtThongTinChu1.Columns.Add("Line0")
                dtThongTinChu1.Columns.Add("Line1")
                dtThongTinChu1.Columns.Add("Line2")

                dtThongTinChu2.Columns.Add("Line0")
                dtThongTinChu2.Columns.Add("Line1")
                dtThongTinChu2.Columns.Add("Line2")
                dtThongTinChu1.Rows.Add(arrCSD(0).ToString.Trim, CSD1(0).ToString.Trim, CSD1(1).ToString.Trim)
                strLine0 = arrCSD(2)
                If CSD2.Length > 1 Then
                    strLine1 = CSD2(0)
                    strLine2 = CSD2(1)
                Else
                    strLine1 = CSD2(0)
                    strLine2 = ""
                End If
                dtThongTinChu2.Rows.Add(strLine0.ToString.Trim, strLine1.ToString.Trim, strLine2.ToString.Trim)
            ElseIf arrCSD.Length = 2 Then
                ' truong hop khogn co dogn so huu
                Dim CSD1() As String = arrCSD(0).Split("~")
                Dim CSD2() As String = arrCSD(1).Split("~")

                dtThongTinChu1.Columns.Add("Line0")
                dtThongTinChu1.Columns.Add("Line1")
                dtThongTinChu1.Columns.Add("Line2")

                dtThongTinChu2.Columns.Add("Line0")
                dtThongTinChu2.Columns.Add("Line1")
                dtThongTinChu2.Columns.Add("Line2")
                dtThongTinChu1.Rows.Add("", CSD1(0).ToString.Trim, CSD1(1).ToString.Trim)
                strLine0 = ""
                If CSD2.Length > 1 Then
                    strLine1 = CSD2(0)
                    strLine2 = CSD2(1)
                Else
                    strLine1 = CSD2(0)
                    strLine2 = ""
                End If
                dtThongTinChu2.Rows.Add(strLine0.ToString.Trim, strLine1.ToString.Trim, strLine2.ToString.Trim)
            Else
                'truong hop co 1 chu su dung
                Dim CSD1() As String = arrCSD(0).Split("~")
                If CSD1.Length > 1 Then
                    dtThongTinChu1.Columns.Add("Line0")
                    dtThongTinChu1.Columns.Add("Line1")
                    dtThongTinChu1.Columns.Add("Line2")
                    dtThongTinChu2.Columns.Add("Line0")
                    dtThongTinChu2.Columns.Add("Line1")
                    dtThongTinChu2.Columns.Add("Line2")
                    dtThongTinChu1.Rows.Add("", CSD1(0).ToString.Trim, CSD1(1).ToString.Trim)
                    If CSD1.Length > 3 Then
                        dtThongTinChu2.Rows.Add("", CSD1(2).ToString.Trim, CSD1(3).ToString.Trim)
                    Else
                        dtThongTinChu2.Rows.Add("", CSD1(2).ToString.Trim, "")
                    End If

                Else
                    dtThongTinChu1.Columns.Add("line0")
                    dtThongTinChu1.Columns.Add("Line1")
                    dtThongTinChu1.Columns.Add("Line2")
                    dtThongTinChu1.Rows.Add("", CSD1(0).ToString.Trim, CSD1(1).ToString.Trim)
                End If

            End If

            '  dtThongTinChu1 = Me.addColumnValue(dtThongTinChu, 0)
            'Chắc chắn rằng tồn tại ít nhất một Chủ hồ sơ cấp GCN
            If (dtThongTinChu1 IsNot Nothing) Then
                If ((dtThongTinChu1.Rows.Count > 0)) Then
                    objRep.Subreports("subRptChu1").SetDataSource(dtThongTinChu1)
                Else
                    'Nếu không có thì ẩn SubReport
                    Me.HideSubReport(objRep, "subRptChu1")
                End If
                'Hiển thị thông tin Chủ 2

                '  dtThongTinChu2 = Me.addColumnValue(dtThongTinChu, 1)
                If (dtThongTinChu2 IsNot Nothing) Then
                    If ((dtThongTinChu2.Rows.Count > 0)) Then
                        objRep.Subreports("subRptChu2").SetDataSource(dtThongTinChu2)
                    Else
                        'Nếu không có thì ẩn SubReport
                        Me.HideSubReport(objRep, "subRptChu2")
                    End If
                Else
                    'Nếu không có thì ẩn SubReport
                    Me.HideSubReport(objRep, "subRptChu2")
                End If
                ''Hiển thị thông tin Chủ 3
                'Dim dtThongTinChu3 As New DataTable
                'dtThongTinChu3 = Me.addColumnValue(dtThongTinChu, 2)
                'If (dtThongTinChu3 IsNot Nothing) Then
                '    If ((dtThongTinChu3.Rows.Count > 0) And (dtThongTinChu3.Rows(0).Item(0).ToString <> "")) Then
                '        objRep.Subreports("subRptChu3").SetDataSource(dtThongTinChu3)
                '    Else
                '        'Nếu không có thì ẩn SubReport
                '        Me.HideSubReport(objRep, "subRptChu3")
                '    End If
                'Else
                '    'Nếu không có thì ẩn SubReport
                '    Me.HideSubReport(objRep, "subRptChu3")
                'End If
            Else
                'Nếu không có Chủ hồ sơ nào đề nghị cấp GCN thì ẩn SubReport
                Me.HideSubReport(objRep, "subRptChu1")
                Me.HideSubReport(objRep, "subRptChu2")
                Me.HideSubReport(objRep, "subRptChu3")
            End If


            'THÔNG TIN THỬA ĐẤT
            Dim ThongTinThuaDat As New clsRptThongTinThuaDat
            Dim dtThongTinThuaDat As New DataTable
            With ThongTinThuaDat
                'Nhận chuỗi kết nối Database
                .Connection = strConnection
                .MaHoSoCapGCN = strMaHoSoCapGCN
                dtThongTinThuaDat = .SelectThongTinThuaDat()
            End With
            If (dtThongTinThuaDat.Rows.Count > 0) Then
                If (dtThongTinThuaDat.Rows(0).Item(0).ToString <> "") Then
                    objRep.Subreports("subRptThongTinThuaDatDeNghiCapGCN").SetDataSource(dtThongTinThuaDat)
                Else
                    'Nếu không có thì ẩn SubReport
                    Me.HideSubReport(objRep, "subRptThongTinThuaDatDeNghiCapGCN")
                End If
            Else
                'Nếu không có thì ẩn SubReport
                Me.HideSubReport(objRep, "subRptThongTinThuaDatDeNghiCapGCN")
            End If
            'THÔNG TIN NHÀ Ở
            Dim ThongTinNhaO As New clsRptThongTinNhaO
            Dim dtThongTinNhaO As New DataTable
            With ThongTinNhaO
                'Nhận chuỗi kết nối Database
                .Connection = strConnection
                .MaHoSoCapGCN = strMaHoSoCapGCN
                dtThongTinNhaO = .SelecThongTinNhaO()
            End With
            If ((dtThongTinNhaO.Rows.Count > 0) And (dtThongTinNhaO.Rows(0).Item(0).ToString <> "")) Then
                objRep.Subreports("subRptThongTinNhaODeNghiCapGCN").SetDataSource(dtThongTinNhaO)
                Me.HideTextObject(objRep, "txtNhaO")
            Else
                'Nếu không có thì ẩn SubReport
                Me.HideSubReport(objRep, "subRptThongTinNhaODeNghiCapGCN")
            End If
            'Thông tin Ghi chú
            With objRep.ParameterFields
                Dim ThongTinGCN As New clsRptGCN
                ThongTinGCN.Connection = strConnection
                ThongTinGCN.MaHoSoCapGCN = strMaHoSoCapGCN
                ThongTinGCN.GetData(dtGCN)
                Dim strGhiChuGCN As String = ""
                Dim strGhiChuNoiDungChuDeNghiCapGCN As String = ""
                If (dtGCN IsNot Nothing) Then
                    'Thông tin ghi chú CHỦ GIẤY CHỨNG NHẬN
                    If (dtGCN.Rows.Count > 0) Then
                        strGhiChuNoiDungChuDeNghiCapGCN = dtGCN.Rows(0).Item("GhiChuNoiDungChuDeNghiCapGCN").ToString
                    End If
                    .Item("GhiChuNoiDungChuDeNghiCapGCN").CurrentValues.AddValue(strGhiChuNoiDungChuDeNghiCapGCN)
                    'Thông tin Ghi chú GCN
                    strGhiChuGCN = dtGCN.Rows(0).Item("GhiChuGCN").ToString
                    .Item("GhiChuGCN").CurrentValues.AddValue(strGhiChuGCN)
                    If (strGhiChuGCN <> "") Then
                        'Nếu có thông tin ghi chú GCN thì ẩn TextObject
                        Me.HideTextObject(objRep, "txtGhiChuGCN")
                    End If
                Else
                    .Item("GhiChuNoiDungChuDeNghiCapGCN").CurrentValues.AddValue(strGhiChuNoiDungChuDeNghiCapGCN)
                    'Nếu có thông tin ghi chú GCN thì ẩn TextObject
                    Me.HideTextObject(objRep, "txtGhiChuGCN")
                End If

            End With
            'Gan doi tuong ReportDocument cho dieu khien CrystalReportViewer
            Me.crptGCN.ReportSource = objRep
            Me.crptGCN.Refresh()
        Catch ex As Exception
            MsgBox(" Hiển thị bản thảo Giấy chứng nhận: " & vbNewLine & ex.Message, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub
#End Region

    Private Function DiaChiThuaDat() As String
        Dim strDiaChi As String = ""
        Try
            'Khai báo bảng chứa thông tin Thửa đất
            Dim dtDiaChi As New DataTable
            'Khai báo lớp thông tin Thửa đất
            Dim ThuaDat As New clsRptThongTinThuaDat
            ThuaDat.Connection = strConnection
            ThuaDat.MaHoSoCapGCN = strMaHoSoCapGCN
            dtDiaChi = ThuaDat.SelectDiaChiThuaDatByMaHoSoCapGCN()
            If (dtDiaChi IsNot Nothing) Then
                If (dtDiaChi.Rows.Count > 0) Then
                    'Trước mắt chỉ lấy địa chỉ Nhà đất, tương ứng với bản ghi đầu tiên.
                    strDiaChi = "Địa chỉ: " + dtDiaChi.Rows(0).Item("DiaChi").ToString
                End If
            End If
        Catch ex As Exception
            MsgBox("Lỗi xác nhận địa chỉ Nhà đất: " + vbNewLine + ex.Message, MsgBoxStyle.OkOnly)
        End Try
        Return strDiaChi
    End Function

    Public Sub ShowDataGCN14HoanKiem()
        Try
            'Khai báo và khởi tạo đối tượng ReportDocument
            objRep = New ReportDocument
            Dim strFile As String = ""
            If strMaHoSoCapGCN = "" Then
                MsgBox("Chưa có thông tin cấp GCN!", MsgBoxStyle.Information, "DMCLand")
                Exit Sub
            End If
            strFile = Application.StartupPath & "\Reports\GiayChungNhan\" & "rptGCN14HoanKiem.rpt"
            objRep.Load(strFile, OpenReportMethod.OpenReportByDefault)
            'Tổng hợp Thông tin CHỦ GIẤY CHỨNG NHẬN
            Dim clsChuGCN As New clsThongTinChuGCN
            'Gán giá trị cho các thuộc tính trong trường hợp truy vấn
            With clsChuGCN
                'Nhận chuỗi kết nối Database
                .Connection = strConnection
                .MaHoSoCapGCN = strMaHoSoCapGCN
            End With
            dtChuGCN.Clear()
            'chứa thông tin Mã vạch
            Dim dtMaVach As New DataTable
            Dim clsThongTinMaVach As New clsThongTinMaVach
            With clsThongTinMaVach
                .Connection = strConnection
                .MaHoSoCapGCN = strMaHoSoCapGCN
                .SelectData(dtMaVach)
                If (dtMaVach IsNot Nothing) Then
                    If ((dtMaVach.Rows.Count > 0) And (dtMaVach.Rows(0).Item(0).ToString <> "") And (dtMaVach.Rows(0).Item("InMaVach").ToString = "True")) Then
                        objRep.Subreports("subRptBarcode").SetDataSource(dtMaVach)
                    Else
                        'Nếu không có thì ẩn SubReport
                        Me.HideSubReport(objRep, "subRptBarcode")
                    End If
                Else
                    'Nếu không có thì ẩn SubReport
                    Me.HideSubReport(objRep, "subRptBarcode")
                End If
            End With
            'Hiển thị thông tin Chủ 1
            '' ''Dim ThongTinChu As New clsThongTinChuGCN
            '' ''Dim dtThongTinChu As New DataTable
            '' ''Dim dtThongTinChu1 As New DataTable
            '' ''With ThongTinChu
            '' ''    'Nhận chuỗi kết nối Database
            '' ''    .Connection = strConnection
            '' ''    .MaHoSoCapGCN = strMaHoSoCapGCN
            '' ''    .SelectChuDeNghiCapGCNByMaHoSoCapGCN(dtThongTinChu)
            '' ''End With
            '' ''dtThongTinChu1 = Me.addColumnValue(dtThongTinChu, 0)
            ' '' ''Chắc chắn rằng tồn tại ít nhất một Chủ hồ sơ cấp GCN
            '' ''If (dtThongTinChu1 IsNot Nothing) Then
            '' ''    If ((dtThongTinChu1.Rows.Count > 0) And (dtThongTinChu1.Rows(0).Item(0).ToString <> "")) Then
            '' ''        objRep.Subreports("subRptChu1").SetDataSource(dtThongTinChu1)
            '' ''    Else
            '' ''        'Nếu không có thì ẩn SubReport
            '' ''        Me.HideSubReport(objRep, "subRptChu1")
            '' ''    End If
            '' ''    'Hiển thị thông tin Chủ 2
            '' ''    Dim dtThongTinChu2 As New DataTable
            '' ''    dtThongTinChu2 = Me.addColumnValue(dtThongTinChu, 1)
            '' ''    If (dtThongTinChu2 IsNot Nothing) Then
            '' ''        If ((dtThongTinChu2.Rows.Count > 0) And (dtThongTinChu2.Rows(0).Item(0).ToString <> "")) Then
            '' ''            objRep.Subreports("subRptChu2").SetDataSource(dtThongTinChu2)
            '' ''        Else
            '' ''            'Nếu không có thì ẩn SubReport
            '' ''            Me.HideSubReport(objRep, "subRptChu2")
            '' ''        End If
            '' ''    Else
            '' ''        'Nếu không có thì ẩn SubReport
            '' ''        Me.HideSubReport(objRep, "subRptChu2")
            '' ''    End If
            '' ''    'Hiển thị thông tin Chủ 3
            '' ''    Dim dtThongTinChu3 As New DataTable
            '' ''    dtThongTinChu3 = Me.addColumnValue(dtThongTinChu, 2)
            '' ''    If (dtThongTinChu3 IsNot Nothing) Then
            '' ''        If ((dtThongTinChu3.Rows.Count > 0) And (dtThongTinChu3.Rows(0).Item(0).ToString <> "")) Then
            '' ''            objRep.Subreports("subRptChu3").SetDataSource(dtThongTinChu3)
            '' ''        Else
            '' ''            'Nếu không có thì ẩn SubReport
            '' ''            Me.HideSubReport(objRep, "subRptChu3")
            '' ''        End If
            '' ''    Else
            '' ''        'Nếu không có thì ẩn SubReport
            '' ''        Me.HideSubReport(objRep, "subRptChu3")
            '' ''    End If
            '' ''Else
            '' ''    'Nếu không có Chủ hồ sơ nào đề nghị cấp GCN thì ẩn SubReport
            '' ''    Me.HideSubReport(objRep, "subRptChu1")
            '' ''    Me.HideSubReport(objRep, "subRptChu2")
            '' ''    Me.HideSubReport(objRep, "subRptChu3")
            '' ''End If
            Dim ThongTinChu As New clsThongTinChuGCN
            Dim dtThongTinChu As New DataTable
            Dim dtThongTinChu1 As New DataTable
            Dim dtThongTinChu2 As New DataTable
            With ThongTinChu
                'Nhận chuỗi kết nối Database
                .Connection = strConnection
                .MaHoSoCapGCN = strMaHoSoCapGCN
                .SelectChuDeNghiCapGCNByMaHoSoCapGCN(dtThongTinChu)
            End With

            ' phan tich chuoi chu su dung
            Dim strCSD As String = ""
            strCSD = dtThongTinChu.Rows(0).Item(0)
            Dim arrCSD() As String = strCSD.Split("^")
            Dim strLine0 As String = "", strLine1 As String = "", strLine2 As String = ""
            If arrCSD.Length >= 3 Then
                'truong hop co dong so huu             
                Dim CSD1() As String = arrCSD(1).Split("~")
                Dim CSD2() As String = arrCSD(3).Split("~")
                dtThongTinChu1.Columns.Add("Line0")
                dtThongTinChu1.Columns.Add("Line1")
                dtThongTinChu1.Columns.Add("Line2")

                dtThongTinChu2.Columns.Add("Line0")
                dtThongTinChu2.Columns.Add("Line1")
                dtThongTinChu2.Columns.Add("Line2")
                dtThongTinChu1.Rows.Add(arrCSD(0).ToString.Trim, CSD1(0).ToString.Trim, CSD1(1).ToString.Trim)
                strLine0 = arrCSD(2)
                If CSD2.Length > 1 Then
                    strLine1 = CSD2(0)
                    strLine2 = CSD2(1)
                Else
                    strLine1 = CSD2(0)
                    strLine2 = ""
                End If
                dtThongTinChu2.Rows.Add(strLine0.ToString.Trim, strLine1.ToString.Trim, strLine2.ToString.Trim)
            ElseIf arrCSD.Length = 2 Then
                ' truong hop khogn co dogn so huu
                Dim CSD1() As String = arrCSD(0).Split("~")
                Dim CSD2() As String = arrCSD(1).Split("~")

                dtThongTinChu1.Columns.Add("Line0")
                dtThongTinChu1.Columns.Add("Line1")
                dtThongTinChu1.Columns.Add("Line2")

                dtThongTinChu2.Columns.Add("Line0")
                dtThongTinChu2.Columns.Add("Line1")
                dtThongTinChu2.Columns.Add("Line2")
                dtThongTinChu1.Rows.Add("", CSD1(0).ToString.Trim, CSD1(1).ToString.Trim)
                strLine0 = ""
                If CSD2.Length > 1 Then
                    strLine1 = CSD2(0)
                    strLine2 = CSD2(1)
                Else
                    strLine1 = CSD2(0)
                    strLine2 = ""
                End If
                dtThongTinChu2.Rows.Add(strLine0.ToString.Trim, strLine1.ToString.Trim, strLine2.ToString.Trim)
            Else
                'truong hop co 1 chu su dung
                Dim CSD1() As String = arrCSD(0).Split("~")
                If CSD1.Length > 1 Then
                    dtThongTinChu1.Columns.Add("Line0")
                    dtThongTinChu1.Columns.Add("Line1")
                    dtThongTinChu1.Columns.Add("Line2")
                    dtThongTinChu2.Columns.Add("Line0")
                    dtThongTinChu2.Columns.Add("Line1")
                    dtThongTinChu2.Columns.Add("Line2")
                    dtThongTinChu1.Rows.Add("", CSD1(0).ToString.Trim, CSD1(1).ToString.Trim)
                    If CSD1.Length > 3 Then
                        dtThongTinChu2.Rows.Add("", CSD1(2).ToString.Trim, CSD1(3).ToString.Trim)
                    Else
                        dtThongTinChu2.Rows.Add("", CSD1(2).ToString.Trim, "")
                    End If

                Else
                    dtThongTinChu1.Columns.Add("line0")
                    dtThongTinChu1.Columns.Add("Line1")
                    dtThongTinChu1.Columns.Add("Line2")
                    dtThongTinChu1.Rows.Add("", CSD1(0).ToString.Trim, CSD1(1).ToString.Trim)
                End If

            End If

            '  dtThongTinChu1 = Me.addColumnValue(dtThongTinChu, 0)
            'Chắc chắn rằng tồn tại ít nhất một Chủ hồ sơ cấp GCN
            If (dtThongTinChu1 IsNot Nothing) Then
                If ((dtThongTinChu1.Rows.Count > 0)) Then
                    objRep.Subreports("subRptChu1").SetDataSource(dtThongTinChu1)
                Else
                    'Nếu không có thì ẩn SubReport
                    Me.HideSubReport(objRep, "subRptChu1")
                End If
                'Hiển thị thông tin Chủ 2

                '  dtThongTinChu2 = Me.addColumnValue(dtThongTinChu, 1)
                If (dtThongTinChu2 IsNot Nothing) Then
                    If ((dtThongTinChu2.Rows.Count > 0)) Then
                        objRep.Subreports("subRptChu2").SetDataSource(dtThongTinChu2)
                    Else
                        'Nếu không có thì ẩn SubReport
                        Me.HideSubReport(objRep, "subRptChu2")
                    End If
                Else
                    'Nếu không có thì ẩn SubReport
                    Me.HideSubReport(objRep, "subRptChu2")
                End If
                ''Hiển thị thông tin Chủ 3
                'Dim dtThongTinChu3 As New DataTable
                'dtThongTinChu3 = Me.addColumnValue(dtThongTinChu, 2)
                'If (dtThongTinChu3 IsNot Nothing) Then
                '    If ((dtThongTinChu3.Rows.Count > 0) And (dtThongTinChu3.Rows(0).Item(0).ToString <> "")) Then
                '        objRep.Subreports("subRptChu3").SetDataSource(dtThongTinChu3)
                '    Else
                '        'Nếu không có thì ẩn SubReport
                '        Me.HideSubReport(objRep, "subRptChu3")
                '    End If
                'Else
                '    'Nếu không có thì ẩn SubReport
                '    Me.HideSubReport(objRep, "subRptChu3")
                'End If
            Else
                'Nếu không có Chủ hồ sơ nào đề nghị cấp GCN thì ẩn SubReport
                Me.HideSubReport(objRep, "subRptChu1")
                Me.HideSubReport(objRep, "subRptChu2")
                Me.HideSubReport(objRep, "subRptChu3")
            End If
            'Hiển thị thông tin Chủ lên Giấy chứng nhận
            With objRep.ParameterFields
                'Thông tin Địa chỉ Nhà đất thể hiện trên mặt 1 Giấy chứng nhận
                '(CHỈ DÀNH CHO QUẬN HOÀN KIẾM)
                Dim strDiaChiNhaDat As String = ""
                strDiaChiNhaDat = Me.DiaChiThuaDat
                .Item("DiaChiNhaDat").CurrentValues.AddValue(strDiaChiNhaDat)
                'Thông tin Tổng hợp CHỦ GIẤY CHỨNG NHẬN
                Dim strGhiChuNoiDungChuDeNghiCapGCN As String = ""
                If (clsChuGCN.SelectGhiChuNoiDungChuDeNghiCapGCN(dtChuGCN) = "") And (dtChuGCN.Rows.Count > 0) Then
                    strGhiChuNoiDungChuDeNghiCapGCN = dtChuGCN.Rows(0).Item("GhiChuNoiDungChuDeNghiCapGCN").ToString
                End If
                .Item("GhiChuNoiDungChuDeNghiCapGCN").CurrentValues.AddValue(strGhiChuNoiDungChuDeNghiCapGCN)
            End With
            'Gán đối tượng ReportDocument cho điều khiển CrystalReportViewer
            Me.crptGCN.ReportSource = objRep
            Me.crptGCN.Refresh()
        Catch ex As Exception
            MsgBox(" Hiển thị Giấy chứng nhận mặt 1-4 (HK): " & vbNewLine & ex.Message, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub
    Public Function PTChuoi(ByVal str As String, ByVal kt As Char) As String
        Dim n As Integer
        Dim st() As Char = str.ToCharArray
        Dim k As Integer = 0
        For n = 0 To st.Length - 1
            If st(n) = kt Then
                k = k + 1
            End If
        Next
        Dim m() As Char = str.Split(kt)(k)
        Dim t As String = CType(m, String)
        Return t
    End Function

    Public Function DinhDangChuSuDung(ByVal strChu As String) As String
        Dim Lan1() As String = strChu.Split("^")
        Dim str As String = ""
        For i As Integer = 0 To Lan1.Length - 1
            Dim Lan2() As String = Lan1(i).Split("~")
            If Lan2.Length >= 0 Then
                For j As Integer = 0 To Lan2.Length - 1
                    If j = 0 Then

                        str = str & Lan2(0)
                    Else
                        str = str & Lan2(j)
                    End If
                Next
            End If
        Next
        Return str
    End Function
   

    Public Sub ShowDataGCN14()
        Try
            'Khai báo và khởi tạo đối tượng ReportDocument
            objRep = New ReportDocument
            Dim strFile As String = ""
            If strMaHoSoCapGCN = "" Then
                MsgBox("Chưa có thông tin cấp GCN!", MsgBoxStyle.Information, "DMCLand")
                Exit Sub
            End If
            strFile = Application.StartupPath & "\Reports\GiayChungNhan\" & "rptGCN14.rpt"
            objRep.Load(strFile, OpenReportMethod.OpenReportByDefault)
            'Tổng hợp Thông tin CHỦ GIẤY CHỨNG NHẬN
            Dim clsChuGCN As New clsThongTinChuGCN
            'Gán giá trị cho các thuộc tính trong trường hợp truy vấn
            With clsChuGCN
                'Nhận chuỗi kết nối Database
                .Connection = strConnection
                .MaHoSoCapGCN = strMaHoSoCapGCN
            End With
            dtChuGCN.Clear()
            'chứa thông tin Mã vạch
            Dim dtMaVach As New DataTable
            Dim clsThongTinMaVach As New clsThongTinMaVach
            With clsThongTinMaVach
                .Connection = strConnection
                .MaHoSoCapGCN = strMaHoSoCapGCN
                .SelectData(dtMaVach)
                If (dtMaVach IsNot Nothing) Then
                    If ((dtMaVach.Rows.Count > 0) And (dtMaVach.Rows(0).Item(0).ToString <> "") And (dtMaVach.Rows(0).Item("InMaVach").ToString = "True")) Then
                        objRep.Subreports("subRptBarcode").SetDataSource(dtMaVach)
                    Else
                        'Nếu không có thì ẩn SubReport
                        Me.HideSubReport(objRep, "subRptBarcode")
                    End If
                Else
                    'Nếu không có thì ẩn SubReport
                    Me.HideSubReport(objRep, "subRptBarcode")
                End If
            End With
            'Hiển thị thông tin Chủ 1
            Dim ThongTinChu As New clsThongTinChuGCN
            Dim dtThongTinChu As New DataTable
            Dim dtThongTinChu1 As New DataTable
            Dim dtThongTinChu2 As New DataTable
            With ThongTinChu
                'Nhận chuỗi kết nối Database
                .Connection = strConnection
                .MaHoSoCapGCN = strMaHoSoCapGCN
                .SelectChuDeNghiCapGCNByMaHoSoCapGCN(dtThongTinChu)
            End With

            ' phan tich chuoi chu su dung
            Dim strCSD As String = ""
            strCSD = dtThongTinChu.Rows(0).Item(0)
            Dim arrCSD() As String = strCSD.Split("^")
            Dim strLine0 As String = "", strLine1 As String = "", strLine2 As String = ""
            If arrCSD.Length >= 3 Then
                'truong hop co dong so huu             
                Dim CSD1() As String = arrCSD(1).Split("~")
                Dim CSD2() As String = arrCSD(3).Split("~")
                dtThongTinChu1.Columns.Add("Line0")
                dtThongTinChu1.Columns.Add("Line1")
                dtThongTinChu1.Columns.Add("Line2")

                dtThongTinChu2.Columns.Add("Line0")
                dtThongTinChu2.Columns.Add("Line1")
                dtThongTinChu2.Columns.Add("Line2")
                dtThongTinChu1.Rows.Add(arrCSD(0).ToString.Trim, CSD1(0).ToString.Trim, CSD1(1).ToString.Trim)
                strLine0 = arrCSD(2)
                If CSD2.Length > 1 Then
                    strLine1 = CSD2(0)
                    strLine2 = CSD2(1)
                Else
                    strLine1 = CSD2(0)
                    strLine2 = ""
                End If
                dtThongTinChu2.Rows.Add(strLine0.ToString.Trim, strLine1.ToString.Trim, strLine2.ToString.Trim)
            ElseIf arrCSD.Length = 2 Then
                ' truong hop khogn co dogn so huu
                Dim CSD1() As String = arrCSD(0).Split("~")
                Dim CSD2() As String = arrCSD(1).Split("~")

                dtThongTinChu1.Columns.Add("Line0")
                dtThongTinChu1.Columns.Add("Line1")
                dtThongTinChu1.Columns.Add("Line2")

                dtThongTinChu2.Columns.Add("Line0")
                dtThongTinChu2.Columns.Add("Line1")
                dtThongTinChu2.Columns.Add("Line2")
                dtThongTinChu1.Rows.Add("", CSD1(0).ToString.Trim, CSD1(1).ToString.Trim)
                strLine0 = ""
                If CSD2.Length > 1 Then
                    strLine1 = CSD2(0)
                    strLine2 = CSD2(1)
                Else
                    strLine1 = CSD2(0)
                    strLine2 = ""
                End If
                dtThongTinChu2.Rows.Add(strLine0.ToString.Trim, strLine1.ToString.Trim, strLine2.ToString.Trim)
            Else
                'truong hop co 1 chu su dung
                Dim CSD1() As String = arrCSD(0).Split("~")
                If CSD1.Length > 1 Then
                    dtThongTinChu1.Columns.Add("Line0")
                    dtThongTinChu1.Columns.Add("Line1")
                    dtThongTinChu1.Columns.Add("Line2")
                    dtThongTinChu2.Columns.Add("Line0")
                    dtThongTinChu2.Columns.Add("Line1")
                    dtThongTinChu2.Columns.Add("Line2")
                    dtThongTinChu1.Rows.Add("", CSD1(0).ToString.Trim, CSD1(1).ToString.Trim)
                    If CSD1.Length > 3 Then
                        dtThongTinChu2.Rows.Add("", CSD1(2).ToString.Trim, CSD1(3).ToString.Trim)
                    Else
                        dtThongTinChu2.Rows.Add("", CSD1(2).ToString.Trim, "")
                    End If

                Else
                    dtThongTinChu1.Columns.Add("line0")
                    dtThongTinChu1.Columns.Add("Line1")
                    dtThongTinChu1.Columns.Add("Line2")
                    dtThongTinChu1.Rows.Add("", CSD1(0).ToString.Trim, CSD1(1).ToString.Trim)
                End If

            End If

            '  dtThongTinChu1 = Me.addColumnValue(dtThongTinChu, 0)
            'Chắc chắn rằng tồn tại ít nhất một Chủ hồ sơ cấp GCN
            If (dtThongTinChu1 IsNot Nothing) Then
                If ((dtThongTinChu1.Rows.Count > 0)) Then
                    objRep.Subreports("subRptChu1").SetDataSource(dtThongTinChu1)
                Else
                    'Nếu không có thì ẩn SubReport
                    Me.HideSubReport(objRep, "subRptChu1")
                End If
                'Hiển thị thông tin Chủ 2

                '  dtThongTinChu2 = Me.addColumnValue(dtThongTinChu, 1)
                If (dtThongTinChu2 IsNot Nothing) Then
                    If ((dtThongTinChu2.Rows.Count > 0)) Then
                        objRep.Subreports("subRptChu2").SetDataSource(dtThongTinChu2)
                    Else
                        'Nếu không có thì ẩn SubReport
                        Me.HideSubReport(objRep, "subRptChu2")
                    End If
                Else
                    'Nếu không có thì ẩn SubReport
                    Me.HideSubReport(objRep, "subRptChu2")
                End If
                ''Hiển thị thông tin Chủ 3
                'Dim dtThongTinChu3 As New DataTable
                'dtThongTinChu3 = Me.addColumnValue(dtThongTinChu, 2)
                'If (dtThongTinChu3 IsNot Nothing) Then
                '    If ((dtThongTinChu3.Rows.Count > 0) And (dtThongTinChu3.Rows(0).Item(0).ToString <> "")) Then
                '        objRep.Subreports("subRptChu3").SetDataSource(dtThongTinChu3)
                '    Else
                '        'Nếu không có thì ẩn SubReport
                '        Me.HideSubReport(objRep, "subRptChu3")
                '    End If
                'Else
                '    'Nếu không có thì ẩn SubReport
                '    Me.HideSubReport(objRep, "subRptChu3")
                'End If
            Else
                'Nếu không có Chủ hồ sơ nào đề nghị cấp GCN thì ẩn SubReport
                Me.HideSubReport(objRep, "subRptChu1")
                Me.HideSubReport(objRep, "subRptChu2")
                Me.HideSubReport(objRep, "subRptChu3")
            End If
            'Hiển thị thông tin Chủ lên Giấy chứng nhận
            With objRep.ParameterFields
                'Thông tin Tổng hợp CHỦ GIẤY CHỨNG NHẬN
                Dim strGhiChuNoiDungChuDeNghiCapGCN As String = ""
                If (clsChuGCN.SelectGhiChuNoiDungChuDeNghiCapGCN(dtChuGCN) = "") And (dtChuGCN.Rows.Count > 0) Then
                    strGhiChuNoiDungChuDeNghiCapGCN = dtChuGCN.Rows(0).Item("GhiChuNoiDungChuDeNghiCapGCN").ToString
                End If
                .Item("GhiChuNoiDungChuDeNghiCapGCN").CurrentValues.AddValue(strGhiChuNoiDungChuDeNghiCapGCN)
            End With
            'Gán đối tượng ReportDocument cho điều khiển CrystalReportViewer
            Me.crptGCN.ReportSource = objRep
            Me.crptGCN.Refresh()
        Catch ex As Exception
            MsgBox(" Hiển thị Giấy chứng nhận mặt 1-4: " & vbNewLine & ex.Message, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub

    Public Sub ShowDataGCN23()
        Try
            'Khai báo và khởi tạo đối tượng ReportDocument
            objRep = New ReportDocument
            Dim strFile As String = ""
            If strMaHoSoCapGCN = "" Then
                MsgBox("Chưa có thông tin cấp GCN!", MsgBoxStyle.Information, "DMCLand")
                Exit Sub
            End If
            strFile = Application.StartupPath & "\Reports\GiayChungNhan\" & "rptGCN23.rpt"
            objRep.Load(strFile, OpenReportMethod.OpenReportByDefault)
            'Khai bao va khoi tao doi tuong clsRptGCN
            Dim GCN As New clsRptGCN
            With GCN
                'Nhận chuỗi kết nối Database
                .Connection = strConnection
                .MaHoSoCapGCN = strMaHoSoCapGCN
                'Cap nhat thong tin Ho so vao thuoc tinh cua lop
            End With
            'Khai bao va khoi tao doi tuong Datatable
            dtGCN.Clear()
            'Goi phuong thuc GetData de khoi tao doi tuong
            If (GCN.GetData(dtGCN) = "") And (dtGCN.Rows.Count > 0) Then
                'THÔNG TIN HÌNH HỌC THỬA ĐẤT 
                'Dim dtLandImage As New DataTable
                'dtLandImage = Me.GetLandImage(strMaHoSoCapGCN, strConnection)
                ''Nếu có Sơ đồ thửa đất thì hiển thị lên Report
                'If ((dtLandImage.Rows.Count > 0) And (dtLandImage.Rows(0).Item(0).ToString <> "")) Then
                '    objRep.Subreports("subRptSoDoNhaDat").SetDataSource(dtLandImage)
                '    'objRep.SetDataSource(dtLandImage)
                'Else
                '    'Nếu không có thì ẩn SubReport
                Me.HideSubReport(objRep, "subRptSoDoNhaDat")
                'End If

                'THÔNG TIN THỬA ĐẤT
                Dim ThongTinThuaDat As New clsRptThongTinThuaDat
                Dim dtThongTinThuaDat As New DataTable
                With ThongTinThuaDat
                    'Nhận chuỗi kết nối Database
                    .Connection = strConnection
                    .MaHoSoCapGCN = strMaHoSoCapGCN
                    dtThongTinThuaDat = .SelectThongTinThuaDat()
                End With
                If (dtThongTinThuaDat.Rows.Count > 0) Then
                    If (dtThongTinThuaDat.Rows(0).Item(0).ToString <> "") Then
                        objRep.Subreports("subRptThongTinThuaDatDeNghiCapGCN").SetDataSource(dtThongTinThuaDat)
                    Else
                        'Nếu không có thì ẩn SubReport
                        Me.HideSubReport(objRep, "subRptThongTinThuaDatDeNghiCapGCN")
                    End If
                Else
                    'Nếu không có thì ẩn SubReport
                    Me.HideSubReport(objRep, "subRptThongTinThuaDatDeNghiCapGCN")
                End If
                'THÔNG TIN NHÀ Ở
                Dim ThongTinNhaO As New clsRptThongTinNhaO
                Dim dtThongTinNhaO As New DataTable
                With ThongTinNhaO
                    'Nhận chuỗi kết nối Database
                    .Connection = strConnection
                    .MaHoSoCapGCN = strMaHoSoCapGCN
                    dtThongTinNhaO = .SelecThongTinNhaO()
                End With
                If ((dtThongTinNhaO.Rows.Count > 0) And (dtThongTinNhaO.Rows(0).Item(0).ToString <> "")) Then
                    objRep.Subreports("subRptThongTinNhaODeNghiCapGCN").SetDataSource(dtThongTinNhaO)
                    Me.HideTextObject(objRep, "txtNhaO")
                Else
                    'Nếu không có thì ẩn SubReport
                    Me.HideSubReport(objRep, "subRptThongTinNhaODeNghiCapGCN")
                End If
                'Gan doi tuong DataTable vao doi tuong ReportDocument
                With objRep.ParameterFields
                    'Thông tin Ghi chú GCN
                    .Item("GhiChuGCN").CurrentValues.AddValue(dtGCN.Rows(0).Item("GhiChuGCN").ToString)
                    If (dtGCN.Rows(0).Item("GhiChuGCN").ToString <> "") Then
                        'Nếu có thông tin ghi chú GCN thì ẩn TextObject
                        Me.HideTextObject(objRep, "txtGhiChuGCN")
                    End If
                    .Item("SoVaoSoCapGCN").CurrentValues.AddValue(dtGCN.Rows(0).Item("SoVaoSoCapGCN").ToString)
                    .Item("TieuDeKyGCN").CurrentValues.AddValue(dtGCN.Rows(0).Item("TieuDeKyGCN").ToString)
                    .Item("NguoiKyGCN").CurrentValues.AddValue(dtGCN.Rows(0).Item("NguoiKyGCN").ToString)
                End With
                'Gan doi tuong DataTable vao doi tuong ReportDocument
            Else
                'Ẩn tất cả các Report
                'Ẩn SubReport thông tin Thửa đất
                Me.HideSubReport(objRep, "subRptThongTinThuaDatDeNghiCapGCN")
                'Ẩn SubReport thông tin Nhà
                Me.HideSubReport(objRep, "subRptThongTinNhaODeNghiCapGCN")
                'Ẩn sơ đồ thửa đất
                Me.HideSubReport(objRep, "subRptSoDoNhaDat")
                'Thiết lập tất cả các giá trị của ParameterFields về chuỗi rỗng
                For i As Integer = 0 To objRep.ParameterFields.Count - 1
                    objRep.ParameterFields.Item(i).CurrentValues.AddValue("")
                Next
            End If
            'Gan doi tuong ReportDocument cho dieu khien CrystalReportViewer
            Me.crptGCN.ReportSource = objRep
            Me.crptGCN.Refresh()
            'objRep.Dispose()
            '/Tim kiem
        Catch ex As Exception
            MsgBox(" Hiển thị Giấy chứng nhận mặt 2,3: " & vbNewLine & " Lỗi: " & ex.Message, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub

    Private Sub HideBarcode(ByRef objRep As ReportDocument, ByVal strPictureBoxName As String)
        For Each objX In objRep.ReportDefinition.ReportObjects
            If objX.Name = strPictureBoxName Then
                Dim objBlobFieldObject As BlobFieldObject = CType(objX, BlobFieldObject)
                objBlobFieldObject.Width = 0.1
                objBlobFieldObject.Height = 0.1
            End If
        Next
    End Sub

    Private Sub HideTextObject(ByRef objRep As ReportDocument, ByVal strTextObjectName As String)
        For Each objX In objRep.ReportDefinition.ReportObjects
            'Neu la TextObject
            If TypeOf (objX) Is TextObject Then
                'Ten cua TextObject la company
                If objX.Name = strTextObjectName Then
                    Dim objTextObject As TextObject = CType(objX, TextObject)
                    objTextObject.Text = ""
                End If
            End If
        Next
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

    Private Sub toolCongCuXem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolCongCuXem.Click
        Try
            With Me
                If .toolCongCuLoaiMauGCN.Text.Trim = .toolCongCuLoaiMauGCN.Items(0).ToString Then
                    .ShowDataBanThaoGCN()
                ElseIf .toolCongCuLoaiMauGCN.Text.Trim = .toolCongCuLoaiMauGCN.Items(1).ToString Then
                    .ShowDataGCN14()
                ElseIf .toolCongCuLoaiMauGCN.Text.Trim = .toolCongCuLoaiMauGCN.Items(2).ToString Then
                    .ShowDataGCN23()
                ElseIf .toolCongCuLoaiMauGCN.Text.Trim = .toolCongCuLoaiMauGCN.Items(3).ToString Then
                    .ShowDataGCN14HoanKiem()
                End If
            End With
        Catch ex As Exception
            MsgBox(" Hiển thị Giấy chứng nhận " & vbNewLine & " Lỗi: " & vbNewLine & ex.Message, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub

    Private Sub toolCongCuIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolCongCuIn.Click
        Try
            PrintDialog.Document = PrintDocument
            PrintDialog.AllowSomePages = False
            PrintDialog.AllowSelection = False
            PrintDocument.DefaultPageSettings.Landscape = True

            If PrintDialog.ShowDialog() = DialogResult.OK Then
                Dim ncopy As Integer = PrintDocument.PrinterSettings.Copies
                Dim printerName As String = Me.PrintDocument.PrinterSettings.PrinterName
                With objRep
                    .PrintOptions.PrinterName = printerName
                    .PrintOptions.PaperSize = PaperSize.PaperA3    ' CrystalDecisions.[Shared].PaperSize.PaperA4
                    .PrintToPrinter(ncopy, False, 0, 0)
                End With
            End If
        Catch ex As Exception
            MsgBox(" In Giấy chứng nhận " & vbNewLine & " Lỗi: " & vbNewLine & ex.Message, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub
End Class
