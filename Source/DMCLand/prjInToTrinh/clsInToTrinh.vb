Imports DMC.Database
Imports System.Data.SqlClient
Public Class clsInToTrinh
    Private Para() As String = {"@MaHoSoCapGCN"}
    Private ParaToTrinh() As String = {"@SoToTrinhDiaChinh", "@NgayTrinhDiaChinh", "@MaDonVIHanhCHinh"}
    Private ParaDVHC() As String = {"@MaDVHC"}
    Private strMaHoSoCapGCN As String = ""
    Private strConnection As String = ""
    Private strMaDVHC As String = ""
    Private strFlag As String = ""
    Private strSoToTrinh As String = ""
    Private strNgayTrinhPhuong As String = ""
    Public Property MaHoSoCapGCN() As String
        Get
            Return strMaHoSoCapGCN
        End Get
        Set(ByVal value As String)
            strMaHoSoCapGCN = value
        End Set
    End Property

    Public Property Connection()
        Get
            Return strConnection
        End Get
        Set(ByVal value)
            strConnection = value
        End Set
    End Property
    Public Property MaDVHC() As String
        Get
            Return strMaDVHC
        End Get
        Set(ByVal value As String)
            strMaDVHC = value
        End Set
    End Property
    Public Property SoToTrinh() As String
        Get
            Return strSoToTrinh
        End Get
        Set(ByVal value As String)
            strSoToTrinh = value
        End Set
    End Property
    Public Property NgayTrinhPhuong() As String
        Get
            Return strNgayTrinhPhuong
        End Get
        Set(ByVal value As String)
            strNgayTrinhPhuong = value
        End Set
    End Property
    Public Property Flag() As String
        Get
            Return strFlag
        End Get
        Set(ByVal value As String)
            strFlag = value
        End Set
    End Property
    Public Function SelectHoSoThuaDat(ByVal sp As String, ByVal Values() As String, ByVal paras() As String) As DataTable
        Dim strError As String = ""
        Dim MyTable As New DataTable
        Try
            'Khoi tao doi tuong DMC.clsDatabase
            Dim Database As New clsDatabase
            Database.Connection = strConnection
            If (Database.OpenConnection) Then
                'Chắc chắn rằng mảng giá trị truyền vào tương đương với mảng tham biến
                If (paras.Length <> Values.Length) Then
                    Return Nothing
                End If
                'Gọi phương thức GetValue của đối tượng clsDatabase
                Database.getValue(MyTable, sp, paras, Values)
                Database.CloseConnection()
            End If
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return MyTable
    End Function
    Public Function SelectGCN() As DataTable
        Dim dt As New DataTable
        Dim strError As String = ""
        Try
            Dim Values() As String = {strMaHoSoCapGCN}
            dt = SelectHoSoThuaDat("sp_SeletAllHoSoCapGCN", Values, Para)
            strError = ""
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return dt
    End Function
    Public Function SelectThongTinToTrinh() As DataTable
        Dim dt As New DataTable
        Dim strError As String = ""
        Try
            Dim Values() As String = {strSoToTrinh, strNgayTrinhPhuong, strMaDVHC}
            dt = SelectHoSoThuaDat("sp_SelectThongTinToTrinh", Values, ParaToTrinh)
            strError = ""
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return dt
    End Function
    Public Function SelectGroupNghiaVuTaiChinh() As DataTable
        Dim dt As New DataTable
        Dim strError As String = ""
        Try
            Dim Values() As String = {strMaHoSoCapGCN}
            dt = SelectHoSoThuaDat("sp_SelectGroupNghiaVuTaiChinh", Values, Para)
            strError = ""
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return dt
    End Function

    Public Function SelectDVHC() As DataTable
        Dim dt As New DataTable
        Dim strError As String = ""
        Try
            Dim Values() As String = {strMaDVHC}
            dt = SelectHoSoThuaDat("spSelectHuyenTinh", Values, ParaDVHC)
            strError = ""
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return dt
    End Function

    Public Function SelectChuSuDung() As DataTable
        Dim dt As New DataTable
        Dim strError As String = ""
        Try
            Dim Values() As String = {strMaHoSoCapGCN}
            dt = SelectHoSoThuaDat("sp_SelectInPhieuChuSuDung", Values, Para)
            strError = ""
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return dt
    End Function
    Public Function SelectMucDich() As DataTable
        Dim dt As New DataTable
        Dim strError As String = ""
        Try
            Dim Values() As String = {strMaHoSoCapGCN}
            dt = SelectHoSoThuaDat("sp_SelectInPhieuMucDichSuDung", Values, Para)
            strError = ""
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return dt
    End Function
    Public Function SelectNguonGoc() As DataTable
        Dim dt As New DataTable
        Dim strError As String = ""
        Try
            Dim Values() As String = {strMaHoSoCapGCN}
            dt = SelectHoSoThuaDat("sp_SelectInPhieuNguonGocSuDungDat", Values, Para)
            strError = ""
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return dt
    End Function
    Public Function SelectTaiSan() As DataTable
        Dim dt As New DataTable
        Dim strError As String = ""
        Try
            Dim Values() As String = {strMaHoSoCapGCN}
            dt = SelectHoSoThuaDat("sp_selectInPhieuTaiSan", Values, Para)
            strError = ""
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return dt
    End Function
    Public Function SelectThongTinRung(ByVal Flag As String) As DataTable
        Dim dt As New DataTable
        Dim strError As String = ""
        Try
            Dim Values() As String = {Flag, strMaHoSoCapGCN}
            Dim paraRung() As String = {"@Flag", "@MaHoSoCapGCN"}
            dt = SelectHoSoThuaDat("sp_SelectInPhieuThongTinRung", Values, paraRung)
            strError = ""
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return dt
    End Function

    Public Sub VeKhung(ByVal app As Object, ByVal i As Int16, ByVal str1 As String, ByVal j As Int16, ByVal str2 As String)
        With app
            With .Range(.Cells(i, str1), .Cells(j, str2)).Borders(7)
                .LineStyle = 1
                .Weight = -4138
                .ColorIndex = -4105
            End With
            With .Range(.Cells(i, str1), .Cells(j, str2)).Borders(8)
                .LineStyle = 1
                .Weight = -4138
                .ColorIndex = -4105
            End With
            With .Range(.Cells(i, str1), .Cells(j, str2)).Borders(9)
                .LineStyle = 1
                .Weight = -4138
                .ColorIndex = -4105
            End With
            With .Range(.Cells(i, str1), .Cells(j, str2)).Borders(10)
                .LineStyle = 1
                .Weight = -4138
                .ColorIndex = -4105
            End With
        End With
    End Sub

    Public Sub QuyetDinh(ByVal app As Object, ByVal dtDVHC() As String, ByVal dtNVTC As DataTable, ByVal ToTrinh() As String, ByVal SoHo As Int16)
        Dim Tang As Int16 = dtNVTC.Rows.Count - 1
        With app
            .Range("A3").ColumnWidth = 6
            .Range("B3").ColumnWidth = 13.86
            .Range("C3").ColumnWidth = 20.14
            .Range("D3").ColumnWidth = 43.57
            With .worksheets(1)
                .Shapes.AddLine(225.0#, 31.5, 339.0#, 31.5).Select()
                .Shapes.AddLine(111.75, 108.75, 375.0#, 108.75).Select()
                .Shapes.AddLine(18.0#, 29.25, 87.75, 29.25).Select()
            End With
            For i As Int16 = 1 To 100
                .Range(.Cells(i, "A"), .Cells(i, "D")).WrapText = True
                .Range(.Cells(i, "A"), .Cells(i, "D")).VerticalAlignment = -4160
            Next
            For i As Int16 = 1 To 10
                .Range(.Cells(i, "A"), .Cells(i, "D")).HorizontalAlignment = -4108
            Next
            .Range(.Cells(22, "A"), .Cells(22, "D")).HorizontalAlignment = -4108
            For i As Int16 = 35 + Tang To 38 + Tang
                .Range(.Cells(i, "A"), .Cells(i, "D")).HorizontalAlignment = -4108
            Next

            .Range(.Cells(22, "A"), .Cells(22, "B")).HorizontalAlignment = -4108
            .Range(.Cells(4, "C"), .Cells(4, "D")).MergeCells = True
            For i As Int16 = 35 + Tang To 38 + Tang
                .Range(.Cells(i, "A"), .Cells(i, "B")).MergeCells = True
            Next
            .Range(.Cells(7, "A"), .Cells(7, "D")).RowHeight = 24.75
            For i As Int16 = 14 To 17
                .Range(.Cells(i, "A"), .Cells(i, "D")).RowHeight = 39
            Next
            .Range(.Cells(18, "A"), .Cells(18, "D")).RowHeight = 51.75
            .Range(.Cells(19, "A"), .Cells(19, "D")).RowHeight = 25
            .Range(.Cells(25, "A"), .Cells(25, "D")).RowHeight = 25
            .Range(.Cells(29 + Tang, "A"), .Cells(29 + Tang, "D")).RowHeight = 25
            .Range(.Cells(30 + Tang, "A"), .Cells(30 + Tang, "D")).RowHeight = 25
            .Range(.Cells(33 + Tang, "A"), .Cells(33 + Tang, "D")).RowHeight = 64.5

            For i As Int16 = 1 To 2
                .Range(.Cells(i, "A"), .Cells(i, "B")).MergeCells = True
                .Range(.Cells(i, "C"), .Cells(i, "D")).MergeCells = True
                .Range(.Cells(i, "A"), .Cells(i, "D")).Font.Bold = True
            Next
            For i As Int16 = 6 To 33 + Tang
                .Range(.Cells(i, "A"), .Cells(i, "D")).MergeCells = True
            Next
            For i As Int16 = 6 To 10
                .Range(.Cells(i, "A"), .Cells(i, "D")).Font.Bold = True
            Next
            .Range(.Cells(22, "A"), .Cells(22, "D")).Font.Bold = True
            .Range(.Cells(24, "A"), .Cells(24, "D")).Font.Bold = True
            .Range(.Cells(27 + Tang, "A"), .Cells(27 + Tang, "D")).Font.Bold = True
            .Range(.Cells(32 + Tang, "A"), .Cells(32 + Tang, "D")).Font.Bold = True
            .Range(.Cells(35 + Tang, "A"), .Cells(35 + Tang, "D")).Font.Bold = True
            .Range(.Cells(35 + Tang, "D"), .Cells(35 + Tang, "D")).Value = True
            .Range(.Cells(36 + Tang, "D"), .Cells(36 + Tang, "D")).Font.Bold = True
            .Range(.Cells(37 + Tang, "D"), .Cells(37 + Tang, "D")).Font.Bold = True


            .Range(.Cells(1, "A"), .Cells(1, "B")).Value = "UỶ BAN NHÂN DÂN"
            .Range(.Cells(2, "A"), .Cells(2, "B")).Value = dtDVHC(1).ToUpper
            .Range(.Cells(1, "C"), .Cells(1, "D")).Value = "CỘNG HOÀ XÃ HỘI CHỦ NGHĨA VIỆT NAM"
            .Range(.Cells(2, "C"), .Cells(2, "D")).Value = "Độc lập - Tự do - Hạnh phúc"
            .Range(.Cells(3, "A"), .Cells(3, "A")).Value = "Số:"
            .Range(.Cells(3, "B"), .Cells(3, "B")).Value = "/QĐ-UBND"
            .Range(.Cells(4, "D"), .Cells(4, "D")).Value = dtDVHC(1) & ", ngày…. Tháng….năm 2008"
            .Range(.Cells(6, "A"), .Cells(6, "D")).Value = "QUYẾT ĐỊNH"

            .Range(.Cells(7, "A"), .Cells(7, "D")).Value = "Về việc cấp giấy chứgn nhận quyền sử dụng đất cùng với quyền sở hữu tài sản gắn liền với đất cho " & SoHo & " Hộ gia đình, cá nhân tại " & dtDVHC(0) & ", " & dtDVHC(1) & ", " & dtDVHC(2)
            .Range(.Cells(10, "A"), .Cells(10, "D")).Value = "UỶ BAN NHÂN DÂN " & dtDVHC(2).ToUpper
            .Range(.Cells(12, "A"), .Cells(12, "D")).Value = "     Căn cứ Luật tổ chứ HĐND và UBND"
            .Range(.Cells(13, "A"), .Cells(13, "D")).Value = "     Căn cứ Luật đất đai năm 2003; Luật nhà ở năm 2005"
            .Range(.Cells(14, "A"), .Cells(14, "D")).Value = "     Căn cứ Nghị định 181/2004/NĐ-CP ngày 29/10/2004 của Chính phủ về việc thi hành Luật đất đai và Thông tư số 01/2005/TT-BTNMT ngày 13/4/2005 của Bộ Tài nguyên và Môi trường hướng dẫn thi hàn Nghị định số 181/2004/NĐ-CP;"
            .Range(.Cells(15, "A"), .Cells(15, "D")).Value = "     Căn cứ Nghị định số 198/2004/NĐ-CP ngày 03/12/2004 của Chính phủ về thu tiền sử dụng đất và Thông tư số 117/2004/TT-BNT ngày 07/12/2004 của Bộ Tài chính hướng dẫn thực hiện Nghị định số 198/2004/NĐ-CP;"
            .Range(.Cells(16, "A"), .Cells(16, "D")).Value = "     Căn cứ Nghị định số 90/2006/NĐ-CP ngày 06/9/2006 của Chính phủ quy định chi tiết và hướng dẫn Luật Nhà ở và THông tư số 05/2006/TT-BXD ngày 01/11/2006 của Bộ Xây dựng và hướng dẫn thực hiện một số nội dung của Nghị định số 90/2006/NĐ-CP;"
            .Range(.Cells(17, "A"), .Cells(17, "D")).Value = "     Căn cứ nghị định 84/2007/NĐ-CP ngày 25/5/2007 của chính phủ quy định bổ sung về việc cấp Giấy chứng nhận quyền sử dụng đất, thu hồi đât, trình tự, thủ tục bồi thường, hỗ trợ tái định cư khi Nhà nướ thu hồi đất và giải quyết khiếu nại về đất đai;"
            .Range(.Cells(18, "A"), .Cells(18, "D")).Value = "     Căn cứ quyết định số 23/2007/QD-UBND ngày 09/5/2008 của UBND thành phố Hà Nội về việc ban hành quy định về cấp giấy chứng nhận quyền sử dụng ddaats cùng với quyền sở hữu tài sản gắn liền với đất cho hộ gia đình, cá nhận, cộng đồng dân cư, người Việt Nam định cư ở nước ngoài trên địa bàn thành phố Hà Nội;"
            .Range(.Cells(19, "A"), .Cells(19, "D")).Value = "     Căn cứ hồ sơ để nghị cấp giấy chứng nhận của các hộ gia đình cá nhân đã được UBND " & dtDVHC(0) & " và phòng Tài nguyên và Môi trường thẩm định;"
            .Range(.Cells(20, "A"), .Cells(20, "D")).Value = "Xét đề nghị của Trưởng phòng Tài nguyên và Môi trường tại Tờ trình số :" & ToTrinh(0) & "/TTrinh-TN&MT " & ToTrinh(1)

            .Range(.Cells(22, "A"), .Cells(22, "D")).Value = "QUYẾT ĐỊNH"

            .Range(.Cells(24, "A"), .Cells(24, "D")).Value = "Điều 1:"
            .Range(.Cells(25, "A"), .Cells(25, "D")).Value = "Cấp giấy chứng nhận quyền sử dụng đất cùng với quyền sở dữu tài sản gắn liền với đất cho " & SoHo & " hộ gia đình, cá nhân tại " & dtDVHC(0) & ", " & dtDVHC(1) & ", " & dtDVHC(2) & " (Có danh sách kèm theo), trong đó:"

            '.Range(.Cells(26, "A"), .Cells(26, "D")).Value = " + …….. Trường hợp cấp đổi GCN không phải nộp lệ phí trước bạ đất."
            '.Range(.Cells(27, "A"), .Cells(27, "D")).Value = " +……….Trường hợp phải nộp phí trước bạ đất"
            '.Range(.Cells(28, "A"), .Cells(28, "D")).Value = " +……….trường hợp phải nộp lệ phí trước bạ nhà, đất."
            '.Range(.Cells(29, "A"), .Cells(29, "D")).Value = " +……….trường hợp phải nộp lệ phí trước bạ đất và thuế chuyển quyền sử dụng đất."
            '.Range(.Cells(30, "A"), .Cells(30, "D")).Value = " +……….trường hợp phải nộp lệ phí trước bạ nhà, đất và thuế chuyển quyền sử dụng đất."
            For i As Int16 = 0 To dtNVTC.Rows.Count - 1
                If IsDBNull(dtNVTC.Rows(i).Item("NghiaVuTaiChinh")) Then
                    .Range(.Cells(26 + i, "A"), .Cells(26 + i, "D")).Value = " +  " & dtNVTC.Rows(i).Item("soluong") & " trường hợp khác"
                Else
                    .Range(.Cells(26 + i, "A"), .Cells(26 + i, "D")).Value = " +  " & dtNVTC.Rows(i).Item("soluong") & " trường hợp " & dtNVTC.Rows(i).Item("NghiaVuTaiChinh")
                End If

            Next

            .Range(.Cells(27 + Tang, "A"), .Cells(27 + Tang, "D")).Value = "Điều 2:"
            .Range(.Cells(28 + Tang, "A"), .Cells(28 + Tang, "D")).Value = "Hộ gia đình, cá nhân được cấp Giấy chứng nhận tại Điều 1 có trách nhiệm:"
            .Range(.Cells(29 + Tang, "A"), .Cells(29 + Tang, "D")).Value = " Liên hệ với Văn phòng đăng ký đất và nhà quận Hai Bà Trưng (sau khi nhận được thông báo về việc cấp giấy chứng nhận) để làm thủ tục kê khai nọp các khoảng nghĩa vụ tài chính (nếu có)."
            .Range(.Cells(30 + Tang, "A"), .Cells(30 + Tang, "D")).Value = " Nộp các khoảng nghĩa vụ tài chính trước khi nhận Giấy chứng nhận và các giấy tờ gốc về nhà, đất được cấp Giấy chứng nhận (Nếu có)"
            .Range(.Cells(31 + Tang, "A"), .Cells(31 + Tang, "D")).Value = "  Liên hệ với UBND " & dtDVHC(0) & " Để đăng ký vào Sổ địa chính theo quy định."
            .Range(.Cells(32 + Tang, "A"), .Cells(32 + Tang, "D")).Value = "Điều 3:"
            .Range(.Cells(33 + Tang, "A"), .Cells(33 + Tang, "D")).Value = "Quyết định này có hiệu lực kể từ ngày ký. Các ông (bà): Chánh Văn phòng HĐND và UBND quận " & dtDVHC(1) & "; Trưởng phòng Tài nguyên và Môi trường " & dtDVHC(1) & "; Giám đốc Văn phòng đăng ký nhà đất và Nhà " & dtDVHC(1) & "; Chi cục trưởng Chi cục Thuế " & dtDVHC(1) & "; Giám đốc Kho bạc Nhà nước " & dtDVHC(1) & "; Chủ tich UBND " & dtDVHC(0) & " và các hộ gia định, cá nhân có trên trong danh sách kèm theo chịu trách nhiệm thi hành Quyết định này./."

            .Range(.Cells(35 + Tang, "A"), .Cells(35 + Tang, "B")).Value = "Nơi nhận"
            .Range(.Cells(36 + Tang, "A"), .Cells(36 + Tang, "B")).Value = " - Như điều 3;"
            .Range(.Cells(37 + Tang, "A"), .Cells(37 + Tang, "B")).Value = " - Sở TN&MT;"
            .Range(.Cells(38 + Tang, "A"), .Cells(38 + Tang, "B")).Value = " - Lưu:VT."

            .Range(.Cells(35 + Tang, "D"), .Cells(35 + Tang, "D")).Value = "TM. UỶ BAN NHÂN DÂN"
            .Range(.Cells(36 + Tang, "D"), .Cells(36 + Tang, "D")).Value = " KÝ THAY CHỦ TỊCH"
            .Range(.Cells(37 + Tang, "D"), .Cells(37 + Tang, "D")).Value = "PHÓ CHỦ TỊCH"

        End With
    End Sub

    Public Function CauHinhTrangQuyetDinh(ByVal app As Object, ByVal dt As DataTable, ByVal arrPhuong() As String) As Int32
        With app
            .Cells.Font.Size = 12

            For i As Int16 = 1 To 8

            Next
            Dim VeSize As Double = 0
            Dim ksize As Double = 0
            Dim SoHoSo As Int16 = 0
            .Cells(1, "A").ColumnWidth = 45.43
            .Cells(1, "B").ColumnWidth = 13.29
            .Cells(1, "C").ColumnWidth = 18.57
            .Cells(1, "D").ColumnWidth = 13.14

            For i As Int16 = 1 To (dt.Rows.Count) * 115
                .Range(.Cells(i, "A"), .Cells(i, "D")).WrapText = True
                .Range(.Cells(i, "A"), .Cells(i, "D")).VerticalAlignment = -4160
            Next

            .Range(.Cells(1 + SoHoSo, "A"), .Cells((dt.Rows.Count) * 115, "D")).Font.Size = 10
            For index As Int16 = 0 To dt.Rows.Count - 1
                strMaHoSoCapGCN = dt.Rows(index).Item("MaHoSoCapGCN")
                Dim dtChuSuDung As New DataTable
                Dim dtMucDich As New DataTable
                Dim dtNguonGoc As New DataTable
                Dim dtTaiSan As New DataTable
                Dim dtRung As New DataTable
                Dim dtCayLauNam As New DataTable
                dtChuSuDung = SelectChuSuDung()
                dtMucDich = SelectMucDich()
                dtNguonGoc = SelectNguonGoc()
                dtTaiSan = SelectTaiSan()
                dtRung = SelectThongTinRung("1")
                dtCayLauNam = SelectThongTinRung("2")

                'xet truong hop cho chu su dung
                Dim strChu As String = ""
                If dtChuSuDung.Rows.Count > 0 Then
                    If dtChuSuDung.Rows.Count = 1 Then
                        If dtChuSuDung.Rows(0).Item("Nhom") = 0 Then
                            strChu = "Ông (bà):  " & dtChuSuDung.Rows(0).Item("HoTen") & " - Năm sinh: " & dtChuSuDung.Rows(0).Item("NamSinh") & " - CMT(HC):" & dtChuSuDung.Rows(0).Item("SoDinhDanh")
                        End If
                        If dtChuSuDung.Rows(0).Item("Nhom") = 1 Then
                            strChu = dtChuSuDung.Rows(0).Item("HoTen") & " - CMT(HC):" & dtChuSuDung.Rows(0).Item("SoDinhDanh") & " - Ngày cấp: " & dtChuSuDung.Rows(0).Item("NgayCap")
                        End If
                        If dtChuSuDung.Rows(0).Item("Nhom") = 2 Then
                            strChu = dtChuSuDung.Rows(0).Item("HoTen")
                        End If
                    Else
                        Dim strTmp As String = ""
                        For i As Int16 = 0 To dtChuSuDung.Rows.Count - 1

                            If dtChuSuDung.Rows(i).Item("Nhom") = 0 Then

                                If i = 0 Then
                                    strChu = "Hộ ông (bà):  " & dtChuSuDung.Rows(i).Item("HoTen") & " - Năm sinh: " & dtChuSuDung.Rows(i).Item("NamSinh") & " - CMT(HC):" & dtChuSuDung.Rows(i).Item("SoDinhDanh") & ","
                                    strTmp = dtChuSuDung.Rows(0).Item("HoTen") & ","
                                Else
                                    If i = 1 Then
                                        strChu = strChu & dtChuSuDung.Rows(i).Item("HoTen") & " - Năm sinh: " & dtChuSuDung.Rows(0I).Item("NamSinh") & " - CMT(HC):" & dtChuSuDung.Rows(i).Item("SoDinhDanh") & ","
                                        strTmp = strTmp & dtChuSuDung.Rows(i).Item("HoTen") & ","
                                    Else
                                        strTmp = strTmp & dtChuSuDung.Rows(i).Item("HoTen") & ","
                                        strChu = strTmp
                                    End If
                                End If

                            End If
                            If dtChuSuDung.Rows(i).Item("Nhom") = 1 Then
                                strChu = strChu & dtChuSuDung.Rows(i).Item("HoTen") & ","
                            End If
                            If dtChuSuDung.Rows(i).Item("Nhom") = 2 Then
                                strChu = strChu & dtChuSuDung.Rows(i).Item("HoTen") & ","
                            End If
                        Next
                        strChu = strChu.Substring(0, strChu.Length - 1)
                    End If

                End If



                For i As Int16 = 1 + SoHoSo To 8 + SoHoSo
                    .Range(.Cells(i, "A"), .Cells(i, "B")).MergeCells = True
                    .Range(.Cells(i, "A"), .Cells(i, "B")).Font.Bold = True
                    .Range(.Cells(i, "A"), .Cells(i, "B")).WrapText = True
                    .Range(.Cells(i, "A"), .Cells(i, "B")).HorizontalAlignment = -4108
                Next

                For i As Int16 = 1 + SoHoSo To 8 + SoHoSo
                    .Range(.Cells(i, "C"), .Cells(i, "D")).MergeCells = True
                    .Range(.Cells(i, "C"), .Cells(i, "D")).Font.Bold = True
                    .Range(.Cells(i, "C"), .Cells(i, "D")).WrapText = True
                    .Range(.Cells(i, "C"), .Cells(i, "D")).HorizontalAlignment = -4108
                Next

                'dinh dang khung
                VeKhung(app, 2 + SoHoSo, "C", 7 + SoHoSo, "D")
                VeKhung(app, 11 + SoHoSo, "A", 14 + SoHoSo, "D")
                VeKhung(app, 15 + SoHoSo, "A", 17 + SoHoSo, "D")
                VeKhung(app, 18 + SoHoSo, "A", 29 + SoHoSo, "D")

                Dim KHUNG As Int16 = dtMucDich.Rows.Count + dtNguonGoc.Rows.Count + dtTaiSan.Rows.Count - 3
                With .Range(.Cells(10 + SoHoSo + KHUNG, "A"), .Cells(53 + SoHoSo + KHUNG, "D")).Borders(7)
                    .LineStyle = -4119
                    .Weight = 4
                    .ColorIndex = -4105
                End With
                With .Range(.Cells(10 + SoHoSo + KHUNG, "A"), .Cells(53 + SoHoSo + KHUNG, "D")).Borders(8)
                    .LineStyle = -4119
                    .Weight = 4
                    .ColorIndex = -4105
                End With
                With .Range(.Cells(10 + SoHoSo + KHUNG, "A"), .Cells(53 + SoHoSo + KHUNG, "D")).Borders(9)
                    .LineStyle = -4119
                    .Weight = 4
                    .ColorIndex = -4105
                End With
                With .Range(.Cells(10 + SoHoSo + KHUNG, "A"), .Cells(53 + SoHoSo + KHUNG, "D")).Borders(10)
                    .LineStyle = -4119
                    .Weight = 4
                    .ColorIndex = -4105
                End With




                'het dinh dang khung

                '--------------------------------------------------

                .Range(.Cells(7 + SoHoSo, "A"), .Cells(7 + SoHoSo, "D")).RowHeight = 47.25
                .Range(.Cells(7 + SoHoSo, "A"), .Cells(7 + SoHoSo, "B")).Font.Bold = True
                .Range(.Cells(1 + SoHoSo, "A"), .Cells(1 + SoHoSo, "B")).Value = "CỘNG HÒA XÃ HỘI CHỦ NGHĨA VIỆT NAM"
                .Range(.Cells(2 + SoHoSo, "A"), .Cells(2 + SoHoSo, "B")).Value = "Độc lập - Tự do - Hạnh phúc"


                .Range(.Cells(4 + SoHoSo, "A"), .Cells(4 + SoHoSo, "D")).RowHeight = 27.25
                .Range(.Cells(4 + SoHoSo, "A"), .Cells(4 + SoHoSo, "B")).Value = "ĐƠN ĐỀ NGHỊ CẤP GIẤY CHỨNG NHẬN, QUYỀN SỬ DỤNG ĐẤT, QUYỀN SỞ HỮU NHÀ Ở VÀ TÀI SẢN KHÁC GẮN LIỀN VỚI ĐẤT"
                .Range(.Cells(5 + SoHoSo, "A"), .Cells(5 + SoHoSo, "B")).Value = "Sử dụng để kê khai cả đối với trường hợp chứng nhận bổ sung quyền sở hữu tài sản)"
                .Range(.Cells(5 + SoHoSo, "A"), .Cells(5 + SoHoSo, "B")).Font.Italic = True
                .Range(.Cells(7 + SoHoSo, "A"), .Cells(7 + SoHoSo, "B")).Value = "Kính gửi: UBND " & arrPhuong(0).ToUpper

                .Range(.Cells(3 + SoHoSo, "A"), .Cells(3 + SoHoSo, "B")).Font.Bold = True
                .Range(.Cells(1 + SoHoSo, "C"), .Cells(1 + SoHoSo, "D")).Value = "Mẫu số 01/ĐK-GCN"
                .Range(.Cells(2 + SoHoSo, "C"), .Cells(2 + SoHoSo, "D")).Value = "PHẦN GHI CỦA NGƯỜI NHẬN HỒ SƠ"
                .Range(.Cells(3 + SoHoSo, "C"), .Cells(3 + SoHoSo, "D")).Value = "Vào sổ tiếp nhận hồ sơ:"
                .Range(.Cells(3 + SoHoSo, "C"), .Cells(4 + SoHoSo, "D")).Font.Italic = True
                .Range(.Cells(4 + SoHoSo, "C"), .Cells(4 + SoHoSo, "D")).Value = "Ngày " & dt.Rows(index).Item("ThoiDiemTiepNhan")
                .Range(.Cells(5 + SoHoSo, "C"), .Cells(5 + SoHoSo, "D")).Value = "Quyển số " & dt.Rows(index).Item("SoHoSoTiepNhan") & ", Số thứ tự " & dt.Rows(index).Item("ThuTuTiepNhan")
                .Range(.Cells(6 + SoHoSo, "C"), .Cells(6 + SoHoSo, "D")).Value = "Người nhận hồ sơ"
                .Range(.Cells(7 + SoHoSo, "C"), .Cells(7 + SoHoSo, "D")).Value = "(Ký và ghi rõ họ, tên)                                " & dt.Rows(index).Item("DonViLapToTrinhDiaChinh")

                '--------------------------------------------------------------
                For i As Int16 = 9 + SoHoSo To 14 + SoHoSo
                    .Range(.Cells(i, "A"), .Cells(i, "D")).MergeCells = True
                    .Range(.Cells(i, "A"), .Cells(i, "D")).WrapText = True
                    .Range(.Cells(i, "A"), .Cells(i, "D")).HorizontalAlignment = -4131
                Next
                .Range(.Cells(9 + SoHoSo, "A"), .Cells(9 + SoHoSo, "D")).Font.Bold = True
                .Range(.Cells(11 + SoHoSo, "A"), .Cells(11 + SoHoSo, "D")).Font.Bold = True

                .Range(.Cells(9 + SoHoSo, "A"), .Cells(9 + SoHoSo, "D")).Value = "I. PHẦN KÊ KHAI CỦA NGƯỜI SỬ DỤNG ĐẤT, CHỦ SỞ HỮU TÀI SẢN GẮN LIỀN VỚI ĐẤT"
                .Range(.Cells(10 + SoHoSo, "A"), .Cells(10 + SoHoSo, "D")).Font.Italic = True
                .Range(.Cells(10 + SoHoSo, "A"), .Cells(10 + SoHoSo, "D")).Value = "(Xem kỹ hướng dẫn viết đơn trước khi kê khai; không tẩy xoá, sửa chữa trên đơn)"
                .Range(.Cells(11 + SoHoSo, "A"), .Cells(11 + SoHoSo, "D")).Value = "1. Người sử dụng đất, chủ sở hữu tài sản gắn liền với đất"

                .Range(.Cells(12 + SoHoSo, "A"), .Cells(13 + SoHoSo, "B")).Font.Bold = False
                .Range(.Cells(12 + SoHoSo, "A"), .Cells(12 + SoHoSo, "D")).RowHeight = 21
                .Range(.Cells(12 + SoHoSo, "A"), .Cells(12 + SoHoSo, "D")).Value = " 1.1. Tên (viết chữ in hoa): " & strChu
                .Range(.Cells(13 + SoHoSo, "A"), .Cells(13 + SoHoSo, "D")).Value = " 1.2. Địa chỉ thường trú: " & dt.Rows(index).Item("DiaChi")

                .Range(.Cells(14 + SoHoSo, "A"), .Cells(14 + SoHoSo, "D")).RowHeight = 69.75
                .Range(.Cells(14 + SoHoSo, "A"), .Cells(14 + SoHoSo, "D")).Font.Italic = True
                .Range(.Cells(14 + SoHoSo, "A"), .Cells(14 + SoHoSo, "D")).Value = " (Cá nhân ghi họ tên, năm sinh, số giấy CMND; hộ gia đình ghi chữ ""Hộ"" trước họ tên, năm sinh, số giấy CMND của  người đại diện cùng có quyền sử dụng đất và sở hữu  tài sản của hộ. Tổ chức ghi tên và quyết định thành lập hoặc giấy đăng ký kinh doanh, giấy phép đầu tư (gồm tên và số, ngày ký, cơ quan ký văn bản). Cá nhân nước ngoài và người Việt Nam định cư ở nước ngoài ghi họ tên, năm sinh, quốc tịch, số và ngày cấp, nơi cấp hộ chiếu. Trường hợp nhiều chủ cùng sử dụng đất, cùng sở hữu tài sản  thì kê khai tên các chủ đó vào danh sách kèm theo)"

                '--------------------------------------
                .Range(.Cells(15 + SoHoSo, "A"), .Cells(15 + SoHoSo, "D")).MergeCells = True
                .Range(.Cells(16 + SoHoSo, "A"), .Cells(16 + SoHoSo, "C")).MergeCells = True
                .Range(.Cells(17 + SoHoSo, "A"), .Cells(17 + SoHoSo, "C")).MergeCells = True
                .Range(.Cells(16 + SoHoSo, "D"), .Cells(17 + SoHoSo, "D")).MergeCells = True

                .Range(.Cells(15 + SoHoSo, "A"), .Cells(15 + SoHoSo, "C")).Font.Bold = True
                .Range(.Cells(16 + SoHoSo, "D"), .Cells(17 + SoHoSo, "D")).Font.Italic = True
                .Range(.Cells(16 + SoHoSo, "D"), .Cells(17 + SoHoSo, "D")).RowHeight = 21
                .Range(.Cells(17 + SoHoSo, "D"), .Cells(17 + SoHoSo, "D")).RowHeight = 21
                .Range(.Cells(15 + SoHoSo, "A"), .Cells(15 + SoHoSo, "C")).Value = "2.Đề nghị"
                .Range(.Cells(16 + SoHoSo, "A"), .Cells(16 + SoHoSo, "C")).Value = "- Chứng nhận bổ xung quyền sở hữu tài sản gắn liền với đất"

                With .worksheets(1)
                    .Shapes.AddShape(1, 384.75, 338.25 + VeSize, 15.75 + ksize, 15.75)
                    .Shapes.AddShape(1, 385.5, 358.5 + VeSize, 16.5 + ksize, 15.75)
                    .Shapes.AddShape(1, 456.75, 360.75 + VeSize, 17.25 + ksize, 15.0#)
                End With

                .Range(.Cells(17 + SoHoSo, "A"), .Cells(17 + SoHoSo, "C")).Value = " - Cấp GCN đối với thửa đất       ,  Tài sản gắn liền với đất"

                .Range(.Cells(16 + SoHoSo, "D"), .Cells(17 + SoHoSo, "D")).Font.Italic = True
                .Range(.Cells(16 + SoHoSo, "D"), .Cells(17 + SoHoSo, "D")).Value = "(Đánh dấu vào ô trống lựa chọn)"


                '-------------------------------------------------
                For i As Int16 = 18 + SoHoSo To 37 + SoHoSo
                    .Range(.Cells(i, "A"), .Cells(i, "D")).MergeCells = True
                    .Range(.Cells(i, "A"), .Cells(i, "D")).WrapText = True
                    .Range(.Cells(i, "A"), .Cells(i, "D")).HorizontalAlignment = -4131
                Next
                .Range(.Cells(18 + SoHoSo, "A"), .Cells(18 + SoHoSo, "D")).Value = "3. Thửa đất đăng ký quyền sử dụng"
                .Range(.Cells(18 + SoHoSo, "A"), .Cells(18 + SoHoSo, "D")).Font.Bold = True
                .Range(.Cells(26 + SoHoSo, "A"), .Cells(26 + SoHoSo, "D")).Font.Italic = True
                .Range(.Cells(19 + SoHoSo, "A"), .Cells(19 + SoHoSo, "D")).Value = "(Không phải khai nếu đề nghị chứng nhận bổ sung quyền sở hữu tài sản)"
                .Range(.Cells(20 + SoHoSo, "A"), .Cells(20 + SoHoSo, "D")).Value = "  3.1.Thửa đất số: " & dt.Rows(index).Item("SoThua") & ";           3.2. Tờ bản đồ số: " & dt.Rows(index).Item("ToBanDo") & ";"
                .Range(.Cells(21 + SoHoSo, "A"), .Cells(21 + SoHoSo, "D")).Value = "  3.3. Địa chỉ tại: " & dt.Rows(index).Item("DiaChi") & ";"
                .Range(.Cells(22 + SoHoSo, "A"), .Cells(22 + SoHoSo, "D")).Value = "  3.4. Diện tích: " & dt.Rows(index).Item("DienTich") & " m2;     Sử dụng chung: " & dt.Rows(index).Item("DienTichChung") & " m2;         Sử dụng riêng: " & dt.Rows(index).Item("DienTichRieng") & " m2;"

                Dim SoMucDich As Int16 = 0
                SoMucDich = dt.Rows.Count
                .Range(.Cells(23 + SoHoSo, "A"), .Cells(23 + SoHoSo, "D")).Value = "  3.5. Sử dụng vào mục đích:"
                For j As Int16 = 0 To dtMucDich.Rows.Count - 1

                    .Range(.Cells(23 + SoHoSo + j + 1, "A"), .Cells(23 + SoHoSo + j + 1, "D")).Value = "  + " & dtMucDich.Rows(j).Item("MoTa") & ". Từ thời điểm:   " & dtMucDich.Rows(j).Item("NamSuDung") & " ; "

                Next

                SoHoSo = SoHoSo + dtMucDich.Rows.Count - 1
                .Range(.Cells(24 + SoHoSo, "A"), .Cells(24 + SoHoSo, "D")).Value = "  3.6. Thời hạn đề nghị được sử dụng đất:   " & dtMucDich.Rows(0).Item("NamSuDung") & " năm;"

                Dim SoNguonGoc As Int16 = 0
                For k As Int16 = 0 To dtNguonGoc.Rows.Count - 1
                    .Range(.Cells(25 + SoHoSo + k, "A"), .Cells(25 + SoHoSo + k, "D")).Value = "3.7. Nguồn gốc sử dụng:     " & dtNguonGoc.Rows(k).Item("MoTa") & " (" & dtNguonGoc.Rows(k).Item("KyHieu") & ");"
                Next
                SoHoSo = SoHoSo + dtNguonGoc.Rows.Count

                .Range(.Cells(26 + SoHoSo, "A"), .Cells(26 + SoHoSo, "D")).Font.Italic = True
                .Range(.Cells(26 + SoHoSo, "A"), .Cells(26 + SoHoSo, "D")).rowHeight = 27.75
                .Range(.Cells(26 + SoHoSo, "A"), .Cells(26 + SoHoSo, "D")).Value = "(Ghi cụ thể: được Nhà nước giao có thu tiền hay giao không thu tiền hay cho thuê trả tiền một lần hay thuê trả tiền hàng năm hoặc nguồn gốc khác)"


                '------------------------------------------

                VeKhung(app, 27 + SoHoSo, "A", 28 + SoHoSo, "D") '======================================
                .Range(.Cells(27 + SoHoSo, "A"), .Cells(27 + SoHoSo, "D")).Value = "4. Tài sản gắn liền với đất"
                .Range(.Cells(27 + SoHoSo, "A"), .Cells(27 + SoHoSo, "D")).Font.Bold = True
                .Range(.Cells(28 + SoHoSo, "A"), .Cells(28 + SoHoSo, "D")).Font.Italic = True
                .Range(.Cells(28 + SoHoSo, "A"), .Cells(28 + SoHoSo, "D")).Value = "(Chỉ kê khai nếu có nhu cầu được chứng nhận hoặc chứng nhận bổ sung quyền sở hữu)"


                VeKhung(app, 29 + SoHoSo, "A", 38 + SoHoSo, "D") ''=======================================
                .Range(.Cells(29 + SoHoSo, "A"), .Cells(29 + SoHoSo, "D")).Value = "4.1. Nhà ở, công trình xây dựng khác:"
                .Range(.Cells(29 + SoHoSo, "A"), .Cells(29 + SoHoSo, "D")).Font.Bold = True
                For i As Int16 = 30 + SoHoSo To 38 + SoHoSo
                    .Range(.Cells(i, "A"), .Cells(i, "D")).MergeCells = True
                    .Range(.Cells(i, "A"), .Cells(i, "D")).WrapText = True
                    .Range(.Cells(i, "A"), .Cells(i, "D")).HorizontalAlignment = -4131
                Next


                For m As Int16 = 0 To dtTaiSan.Rows.Count - 1
                    .Range(.Cells(30 + SoHoSo, "A"), .Cells(30 + SoHoSo, "D")).Value = "  a) Tên công trình (nhà ở, nhà xưởng, nhà kho, …): " & dtTaiSan.Rows(m).Item("LoaiNha") & " ;"
                    .Range(.Cells(31 + SoHoSo, "A"), .Cells(31 + SoHoSo, "D")).Value = "  b) Địa chỉ:" & dtTaiSan.Rows(m).Item("DiaChiNha") & ";"
                    .Range(.Cells(32 + SoHoSo, "A"), .Cells(32 + SoHoSo, "D")).Value = "  c) Diện tích xây dựng: " & dtTaiSan.Rows(m).Item("DienTichXayDung") & " (m2);"
                    .Range(.Cells(33 + SoHoSo, "A"), .Cells(33 + SoHoSo, "D")).Value = "  d) Diện tích sàn (đối với nhà) hoặc công suất (đối với công trình khác): " & dtTaiSan.Rows(m).Item("DienTichSanXayDung") & " ;"
                    .Range(.Cells(34 + SoHoSo, "A"), .Cells(34 + SoHoSo, "D")).Value = "  đ) Sở hữu chung: " & dtTaiSan.Rows(m).Item("DienTichChung") & " m2,  sở hữu riêng: " & dtTaiSan.Rows(m).Item("DienTichRieng") & " m2;"
                    .Range(.Cells(35 + SoHoSo, "A"), .Cells(35 + SoHoSo, "D")).Value = "  e) Kết cấu: " & dtTaiSan.Rows(m).Item("KetCauNha") & " ;"
                    .Range(.Cells(36 + SoHoSo, "A"), .Cells(36 + SoHoSo, "D")).Value = "  g) Cấp, hạng: " & dtTaiSan.Rows(m).Item("CapHangNha") & " ; h) Số tầng: " & dtTaiSan.Rows(m).Item("SoTang") & " ;"

                    .Range(.Cells(37 + SoHoSo, "A"), .Cells(37 + SoHoSo, "D")).Value = "  i) Năm hoàn thành xây dựng: " & dtTaiSan.Rows(m).Item("NgayCapPhepXayDung") & "; k) Thời hạn sở hữu từ " & dtTaiSan.Rows(m).Item("ThoiHanSoHuu") & ";"
                Next

                SoHoSo = SoHoSo + dtTaiSan.Rows.Count
                .Range(.Cells(38 + SoHoSo, "A"), .Cells(38 + SoHoSo, "D")).MergeCells = True
                .Range(.Cells(38 + SoHoSo, "A"), .Cells(38 + SoHoSo, "D")).RowHeight = 30
                .Range(.Cells(38 + SoHoSo, "A"), .Cells(38 + SoHoSo, "D")).Font.Italic = True
                .Range(.Cells(38 + SoHoSo, "A"), .Cells(38 + SoHoSo, "D")).Value = "(Trường hợp có nhiều nhà ở, công trình xây dựng khác thì chỉ kê khai các thông tin chung và tổng diện tích của các nhà ở, công trình xây dựng; đồng thời lập danh sách nhà ở, công trình kèm theo đơn)"

                .Range(.Cells(39 + SoHoSo, "A"), .Cells(39 + SoHoSo, "A")).Font.Bold = True


                VeKhung(app, 39 + SoHoSo, "A", 46 + SoHoSo, "D") '====================================
                .Range(.Cells(39 + SoHoSo, "A"), .Cells(39 + SoHoSo, "A")).Value = "4.2. Rừng sản xuất là rừng trồng:"
                If dtRung.Rows.Count > 0 Then
                    .Range(.Cells(40 + SoHoSo, "A"), .Cells(40 + SoHoSo, "A")).Value = "a) Diện tích có rừng: " & dtRung.Rows(0).Item("DienTichCoRung") & " m2;"
                    .Range(.Cells(41 + SoHoSo, "A"), .Cells(41 + SoHoSo, "A")).Value = "b) Nguồn gốc tạo lập: " & dtRung.Rows(0).Item("NguonGocTaoLap") & "."
                Else
                    .Range(.Cells(40 + SoHoSo, "A"), .Cells(40 + SoHoSo, "A")).Value = "a) Diện tích có rừng: 0 m2;"
                    .Range(.Cells(41 + SoHoSo, "A"), .Cells(41 + SoHoSo, "A")).Value = "b) Nguồn gốc tạo lập: ."
                End If


                With .worksheets(1)
                    .Shapes.AddShape(1, 201.75, 796.5 + VeSize, 14.25 + ksize, 13.5)
                    .Shapes.AddShape(1, 202.5, 814.5 + VeSize, 15.75 + ksize, 13.5)
                    .Shapes.AddShape(1, 201.0#, 831.75 + VeSize, 15.75 + ksize, 14.25)
                    .Shapes.AddShape(1, 201.0#, 849.0# + VeSize, 16.5 + ksize, 14.25)
                End With
                ksize = ksize + 1.5
                VeSize = VeSize + 2230.25
                .Range(.Cells(42 + SoHoSo, "A"), .Cells(42 + SoHoSo, "A")).Value = "  - Tự trồng rừng:............"
                .Range(.Cells(43 + SoHoSo, "A"), .Cells(43 + SoHoSo, "A")).Value = "  - Nhà nước giao không thu tiền:....."
                .Range(.Cells(44 + SoHoSo, "A"), .Cells(44 + SoHoSo, "A")).Value = "  - Nhà nước giao có thu tiền:.........."
                .Range(.Cells(45 + SoHoSo, "A"), .Cells(45 + SoHoSo, "A")).Value = "  - Nhận chuyển quyền:........."
                .Range(.Cells(46 + SoHoSo, "A"), .Cells(46 + SoHoSo, "A")).Value = "   - Nguồn vốn trồng, nhận quyền: ……………......…"

                For i As Int16 = 39 + SoHoSo To 46 + SoHoSo
                    .Range(.Cells(i, "B"), .Cells(i, "D")).MergeCells = True
                Next
                .Range(.Cells(39 + SoHoSo, "B"), .Cells(39 + SoHoSo, "D")).Font.Bold = True



                .Range(.Cells(39 + SoHoSo, "B"), .Cells(39 + SoHoSo, "D")).Value = "4.3. Cây lâu năm:"
                For i As Int16 = 40 + SoHoSo To 46 + SoHoSo
                    .Range(.Cells(i, "B"), .Cells(i, "D")).MergeCells = True
                    .Range(.Cells(i, "B"), .Cells(i, "D")).WrapText = True
                    .Range(.Cells(i, "C"), .Cells(i, "D")).HorizontalAlignment = -4131
                Next
                For r As Int16 = 0 To dtCayLauNam.Rows.Count - 1
                    .Range(.Cells(40 + r + SoHoSo, "B"), .Cells(40 + r + SoHoSo, "D")).Value = "+) Loại cây: " & dtCayLauNam.Rows(r).Item("LoaiCay") & ";"
                    .Range(.Cells(41 + r + SoHoSo, "B"), .Cells(41 + r + SoHoSo, "D")).Value = "+) Nguồn gốc tạo lập: ..............."
                Next
                For i As Int16 = 47 + SoHoSo To 56 + SoHoSo
                    '  .Range(.Cells(i, "A"), .Cells(i, "D")).Font.WrapText = True
                    .Range(.Cells(i, "A"), .Cells(i, "D")).MergeCells = True
                    .Range(.Cells(i, "A"), .Cells(i, "D")).WrapText = True
                    .Range(.Cells(i, "A"), .Cells(i, "D")).HorizontalAlignment = -4131
                Next
                .Range(.Cells(47 + SoHoSo, "A"), .Cells(47 + SoHoSo, "D")).Font.Bold = True

                VeKhung(app, 47 + SoHoSo, "A", 48 + SoHoSo, "D") '============================================

                .Range(.Cells(47 + SoHoSo, "A"), .Cells(47 + SoHoSo, "D")).Value = "5. Những giấy tờ nộp kèm theo:"
                .Range(.Cells(48 + SoHoSo, "A"), .Cells(48 + SoHoSo, "D")).Value = "............................."

                .Range(.Cells(49 + SoHoSo, "A"), .Cells(49 + SoHoSo, "D")).Font.Bold = True

                VeKhung(app, 49 + SoHoSo, "A", 51 + SoHoSo, "D") '=======================================
                .Range(.Cells(49 + SoHoSo, "A"), .Cells(49 + SoHoSo, "D")).Value = "6. Đề nghị:"
                .Range(.Cells(50 + SoHoSo, "A"), .Cells(50 + SoHoSo, "D")).Value = "6.2. Ghi nợ đối với loại nghĩa vụ tài chính: " & dt.Rows(index).Item("NghiaVuTaiChinh") & ""
                .Range(.Cells(51 + SoHoSo, "A"), .Cells(51 + SoHoSo, "D")).Value = "6.3. Đề nghị khác: " & dt.Rows(index).Item("GhiChuGCN") & ""


                .Range(.Cells(53 + SoHoSo, "A"), .Cells(53 + SoHoSo, "D")).Value = ("Tôi xin cam đoan nội dung kê khai trên đơn là đúng sự thật.")

                For i As Int16 = 54 + SoHoSo To 56 + SoHoSo
                    .Range(.Cells(i, "A"), .Cells(i, "D")).HorizontalAlignment = -4108
                Next

                .Range(.Cells(54 + SoHoSo, "A"), .Cells(54 + SoHoSo, "D")).Font.Italic = True
                .Range(.Cells(54 + SoHoSo, "A"), .Cells(54 + SoHoSo, "D")).Value = "……………, ngày .... tháng ... năm ......"
                .Range(.Cells(55 + SoHoSo, "A"), .Cells(55 + SoHoSo, "D")).Font.Bold = True
                .Range(.Cells(55 + SoHoSo, "A"), .Cells(55 + SoHoSo, "D")).Value = "Người viết đơn"
                .Range(.Cells(56 + SoHoSo, "A"), .Cells(56 + SoHoSo, "D")).Font.Italic = True
                .Range(.Cells(56 + SoHoSo, "A"), .Cells(56 + SoHoSo, "D")).Value = " (Ký, ghi rõ họ tên và đóng dấu nếu có)"

                ' phan xac nhan cua uy ban ND xa
                For i As Int16 = 82 + SoHoSo To 91 + SoHoSo
                    .Range(.Cells(i, "A"), .Cells(i, "D")).MergeCells = True
                Next
                For i As Int16 = 92 + SoHoSo To 98 + SoHoSo
                    .Range(.Cells(i, "A"), .Cells(i, "B")).MergeCells = True
                    .Range(.Cells(i, "C"), .Cells(i, "D")).MergeCells = True
                Next
                For i As Int16 = 99 + SoHoSo To 104 + SoHoSo
                    .Range(.Cells(i, "A"), .Cells(i, "D")).MergeCells = True
                Next
                For i As Int16 = 105 + SoHoSo To 111 + SoHoSo
                    .Range(.Cells(i, "A"), .Cells(i, "B")).MergeCells = True
                    .Range(.Cells(i, "C"), .Cells(i, "D")).MergeCells = True
                Next

                For i As Int16 = 92 + SoHoSo To 98 + SoHoSo
                    .Range(.Cells(i, "A"), .Cells(i, "D")).HorizontalAlignment = -4108
                Next
                For i As Int16 = 104 + SoHoSo To 108 + SoHoSo
                    .Range(.Cells(i, "A"), .Cells(i, "D")).HorizontalAlignment = -4108
                Next
                .Range(.Cells(83 + SoHoSo, "A"), .Cells(83 + SoHoSo, "D")).RowHeight = 27.75
                .Range(.Cells(95 + SoHoSo, "A"), .Cells(95 + SoHoSo, "D")).RowHeight = 93
                .Range(.Cells(99 + SoHoSo, "A"), .Cells(99 + SoHoSo, "D")).RowHeight = 38
                .Range(.Cells(104 + SoHoSo, "A"), .Cells(104 + SoHoSo, "D")).RowHeight = 38

                .Range(.Cells(82 + SoHoSo, "A"), .Cells(82 + SoHoSo, "D")).Font.Bold = True
                .Range(.Cells(93 + SoHoSo, "A"), .Cells(93 + SoHoSo, "D")).Font.Bold = True
                .Range(.Cells(94 + SoHoSo, "C"), .Cells(94 + SoHoSo, "D")).Font.Bold = True
                .Range(.Cells(99 + SoHoSo, "A"), .Cells(99 + SoHoSo, "D")).Font.Bold = True
                .Range(.Cells(106 + SoHoSo, "A"), .Cells(106 + SoHoSo, "D")).Font.Bold = True

                .Range(.Cells(82 + SoHoSo, "A"), .Cells(82 + SoHoSo, "D")).Value = "II. XÁC NHẬN CỦA UỶ BAN NHÂN DÂN XÃ, PHƯỜNG, THỊ TRẤN"
                .Range(.Cells(83 + SoHoSo, "A"), .Cells(83 + SoHoSo, "D")).Font.Italic = True
                .Range(.Cells(83 + SoHoSo, "A"), .Cells(83 + SoHoSo, "D")).Value = "(Đối với trường hợp hộ gia đình cá nhân, cộng đồng dân cư, người Việt Nam định cư ở nước ngoài sở hữu nhà ở)"

                .Range(.Cells(84 + SoHoSo, "A"), .Cells(84 + SoHoSo, "D")).Value = "- Nội dung kê khai về đất, tài sản so với hiện trạng: .................................. "
                .Range(.Cells(85 + SoHoSo, "A"), .Cells(85 + SoHoSo, "D")).Value = "- Nguồn gốc sử dụng đất: ......................................................."
                .Range(.Cells(86 + SoHoSo, "A"), .Cells(86 + SoHoSo, "D")).Value = "- Thời điểm bắt đầu sử dụng đất vào mục đích hiện nay:............................."
                .Range(.Cells(87 + SoHoSo, "A"), .Cells(87 + SoHoSo, "D")).Value = "- Nguồn gốc tạo lập tài sản:..................................................................."
                .Range(.Cells(88 + SoHoSo, "A"), .Cells(88 + SoHoSo, "D")).Value = "- Thời điểm hình thành tài sản:........................................"
                .Range(.Cells(89 + SoHoSo, "A"), .Cells(89 + SoHoSo, "D")).Value = "- Tình trạng tranh chấp về đất đai và tài sản gắn liền với đất: .................................."
                .Range(.Cells(90 + SoHoSo, "A"), .Cells(90 + SoHoSo, "D")).Value = "- Sự phù hợp với quy hoạch sử dụng đất, quy hoạch xây dựng:.................................."
                .Range(.Cells(91 + SoHoSo, "A"), .Cells(91 + SoHoSo, "D")).Value = "........................................................................"

                .Range(.Cells(92 + SoHoSo, "A"), .Cells(92 + SoHoSo, "D")).Font.Italic = True
                .Range(.Cells(92 + SoHoSo, "A"), .Cells(92 + SoHoSo, "B")).Value = "......., ngày..... tháng..... năm ..........."
                .Range(.Cells(92 + SoHoSo, "C"), .Cells(92 + SoHoSo, "D")).Value = "......., ngày..... tháng..... năm ..........."
                .Range(.Cells(93 + SoHoSo, "A"), .Cells(93 + SoHoSo, "B")).Value = "Cán bộ địa chính"
                .Range(.Cells(93 + SoHoSo, "C"), .Cells(93 + SoHoSo, "D")).Value = "TM. Uỷ ban nhân dân"
                .Range(.Cells(94 + SoHoSo, "A"), .Cells(94 + SoHoSo, "B")).Value = "(Ký, ghi rõ họ, tên)"
                .Range(.Cells(94 + SoHoSo, "C"), .Cells(94 + SoHoSo, "D")).Value = "Chủ tịch"
                .Range(.Cells(95 + SoHoSo, "C"), .Cells(95 + SoHoSo, "D")).Value = "(Ký tên, đóng dấu)"
                .Range(.Cells(95 + SoHoSo, "A"), .Cells(95 + SoHoSo, "B")).Font.Italic = True
                .Range(.Cells(95 + SoHoSo, "A"), .Cells(95 + SoHoSo, "D")).Font.Italic = True
                .Range(.Cells(99 + SoHoSo, "A"), .Cells(99 + SoHoSo, "D")).Value = "III. Ý KIẾN CỦA VĂN PHÒNG ĐĂNG KÝ QUYỀN SỬ DỤNG ĐẤT"

                .Range(.Cells(104 + SoHoSo, "A"), .Cells(104 + SoHoSo, "D")).Font.Italic = True
                .Range(.Cells(104 + SoHoSo, "A"), .Cells(104 + SoHoSo, "D")).Value = "(Phải nêu rõ có đủ hay không đủ điều kiện cấp GCN, lý do và căn cứ pháp lý áp dụng; trường hợp thửa đất có vườn, ao gắn liền nhà ở thì phải xác định rõ diện tích đất ở được công nhận và căn cứ pháp lý)"

                .Range(.Cells(105 + SoHoSo, "A"), .Cells(105 + SoHoSo, "D")).Font.Italic = True
                .Range(.Cells(105 + SoHoSo, "D"), .Cells(105 + SoHoSo, "D")).Value = "......., ngày..... tháng..... năm ..........."
                .Range(.Cells(105 + SoHoSo, "A"), .Cells(105 + SoHoSo, "D")).Value = "......., ngày..... tháng..... năm ..........."
                .Range(.Cells(106 + SoHoSo, "A"), .Cells(106 + SoHoSo, "B")).Value = "Cán bộ thẩm tra"
                .Range(.Cells(106 + SoHoSo, "C"), .Cells(106 + SoHoSo, "D")).Value = " Giám đốc "
                .Range(.Cells(107 + SoHoSo, "A"), .Cells(107 + SoHoSo, "D")).Font.Italic = True
                .Range(.Cells(108 + SoHoSo, "C"), .Cells(108 + SoHoSo, "D")).Value = "(Ký tên, đóng dấu)"
                've khung
                VeKhung(app, 82 + SoHoSo, "A", 82 + SoHoSo, "D")
                VeKhung(app, 99 + SoHoSo, "A", 99 + SoHoSo, "D")
                With .Range(.Cells(82 + SoHoSo, "A"), .Cells(111 + SoHoSo, "D")).Borders(7)
                    .LineStyle = -4119
                    .Weight = 4
                    .ColorIndex = -4105
                End With
                With .Range(.Cells(82 + SoHoSo, "A"), .Cells(111 + SoHoSo, "D")).Borders(8)
                    .LineStyle = -4119
                    .Weight = 4
                    .ColorIndex = -4105
                End With
                With .Range(.Cells(82 + SoHoSo, "A"), .Cells(111 + SoHoSo, "D")).Borders(9)
                    .LineStyle = -4119
                    .Weight = 4
                    .ColorIndex = -4105
                End With
                With .Range(.Cells(82 + SoHoSo, "A"), .Cells(111 + SoHoSo, "D")).Borders(10)
                    .LineStyle = -4119
                    .Weight = 4
                    .ColorIndex = -4105
                End With
                SoHoSo = SoHoSo + 120
            Next
        End With

    End Function

    Public Sub Config(ByVal app As Object, ByVal KhoGiay As String, ByVal KieuIn As String)

        If KhoGiay = "a3" Then
            KhoGiay = 8
        ElseIf KhoGiay = "a4" Then
            KhoGiay = 9
        End If

        If KieuIn = "ngang" Then
            KieuIn = &H2 ' Land
        ElseIf KieuIn = "dung" Then
            KieuIn = &H1 ' Port
        End If


        With app
            Try
                .Workbooks.Add()
                .Sheets.Add()
                .ActiveSheet.Name = "BaoCao"
                .Cells.Font.Name = "Times New Roman"
                Dim s As Double = KhoGiay.TrimEnd.TrimStart
                .Cells.Worksheet.PageSetup.PaperSize = KhoGiay.TrimEnd.TrimStart
                .Cells.Worksheet.PageSetup.Orientation = KieuIn.TrimEnd.TrimStart 'XlPageOrientation.xlLandscape
                '.Cells.Worksheet.PageSetup.DifferentFirstPageHeaderFooter = True //cai nay ko co trong excel
                '.Cells.Worksheet.PageSetup.FitToPagesTall = 1
                '.Cells.Worksheet.PageSetup.FitToPagesWide = 1

                .Cells.Worksheet.PageSetup.FooterMargin = 25.08
                .Cells.Worksheet.PageSetup.TopMargin = 70.56 '0.98"
                .Cells.Worksheet.PageSetup.LeftMargin = 84.96 '1.18"
                .Cells.Worksheet.PageSetup.BottomMargin = 70.56
                .Cells.Worksheet.PageSetup.RightMargin = 56.88 '0.79"
                .Cells.Worksheet.PageSetup.FirstPageNumber = 0
                If KieuIn = &H2 Then ' ngang
                    .Cells.Worksheet.PageSetup.HeaderMargin = 70 '25.08 '0.39"
                Else
                    .Cells.Worksheet.PageSetup.HeaderMargin = 50
                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try

            .Cells.Worksheet.PageSetup.RightHeader = "Trang số: &P&         " ' của  &N"  
            ' .Cells.Font.Size = 12
        End With
    End Sub
End Class

