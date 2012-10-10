Public Class clsDoiSoThanhChu
#Region "code bo di"
    'Doi so thanh chu
    Public Function SoChu(ByVal dblSo As Double, Optional ByVal isThapPhan As Boolean = True, Optional ByVal VietAnh As String = "V") As String
        Dim arrTenSoKhongDau(10) As String, arrTenDonViKhongDau(5) As String, arrTenSoCoDau(10) As String, arrTenDonViCoDau(5) As String
        Dim lo(5) As Double, lo_v(5) As String
        Dim dblSo1 As String, solop As Double, dblSo2 As String, strChu As String, dblTram As Double
        Dim huc As Double, dvi As Double, mstrs As String
        Dim i As Integer, j As Integer
        arrTenSoKhongDau(10) = " KHONG"
        arrTenSoKhongDau(1) = " MOT"
        arrTenSoKhongDau(2) = " HAI"
        arrTenSoKhongDau(3) = " BA"
        arrTenSoKhongDau(4) = " BON"
        arrTenSoKhongDau(5) = " NAM"
        arrTenSoKhongDau(6) = " SAU"
        arrTenSoKhongDau(7) = " BAY"
        arrTenSoKhongDau(8) = " TAM"
        arrTenSoKhongDau(9) = " CHIN"
        '************
        arrTenDonViKhongDau(1) = " "
        arrTenDonViKhongDau(2) = " NGAN"
        arrTenDonViKhongDau(3) = " TRIEU"
        arrTenDonViKhongDau(4) = " TI"
        arrTenDonViKhongDau(5) = " NGAN"
        '************
        arrTenSoCoDau(10) = " không"
        arrTenSoCoDau(1) = " một"
        arrTenSoCoDau(2) = " hai"
        arrTenSoCoDau(3) = " ba"
        arrTenSoCoDau(4) = " bốn"
        arrTenSoCoDau(5) = " năm"
        arrTenSoCoDau(6) = " sáu"
        arrTenSoCoDau(7) = " bảy"
        arrTenSoCoDau(8) = " tám"
        arrTenSoCoDau(9) = " chín"
        '************
        arrTenDonViCoDau(1) = " "
        arrTenDonViCoDau(2) = " ngàn"
        arrTenDonViCoDau(3) = " triệu"
        arrTenDonViCoDau(4) = " tỉ"
        arrTenDonViCoDau(5) = " ngàn"
        '************
        dblSo1 = dblSo
        solop = 1
        While dblSo1 > 0
            If isThapPhan Then
                dblSo2 = dblSo1
                dblSo1 = Int(dblSo1 / 1000)
                lo(solop) = dblSo2 - dblSo1 * 1000
                solop = solop + 1
            Else
                dblSo2 = dblSo1
                dblSo1 = Int(dblSo1 / 1000)
                lo(solop) = dblSo2 - dblSo1 * 1000
                solop = solop + 1
            End If
        End While
        '**********
        i = solop - 1
        j = i
        strChu = " "
        While i > 0 'doi 3 so ra chu so
            If isThapPhan Then
                dblSo1 = Int(lo(i))
            End If

            If dblSo1 > 0 Then
                dblTram = Int(dblSo1 / 100)
                huc = Int((dblSo1 - dblTram * 100) / 10)
                dvi = dblSo1 Mod 10
                mstrs = Str(dblTram)
                dblTram = Val(mstrs)
                mstrs = Str(huc)
                huc = Val(mstrs)
                mstrs = Str(dvi)
                dvi = Val(mstrs)

                If dblTram > 0 Then
                    If VietAnh = "A" Then
                        strChu = strChu + arrTenSoKhongDau(dblTram) + " TRAM"
                    Else
                        strChu = strChu + arrTenSoCoDau(dblTram) + " trăm"
                    End If
                Else
                    If i < j Then
                        dblTram = 10
                        If VietAnh = "A" Then
                            strChu = strChu + arrTenSoKhongDau(dblTram) + " TRAM"
                        Else
                            strChu = strChu + arrTenSoCoDau(dblTram) + " trăm"
                        End If
                        dblTram = 0
                    End If
                End If
                '**************
                Select Case huc
                    Case Is > 1
                        If VietAnh = "A" Then
                            strChu = strChu + arrTenSoKhongDau(huc) + " MUOI"
                        Else
                            strChu = strChu + arrTenSoCoDau(huc) + " mươi"
                        End If
                    Case 1
                        If VietAnh = "A" Then
                            strChu = strChu + " MUOI"
                        Else
                            strChu = strChu + " mươi"
                        End If
                    Case 0
                        If dblTram > 0 And dvi <> 0 Then
                            If VietAnh = "A" Then
                                strChu = strChu + " LINH"
                            Else
                                strChu = strChu + " linh"
                            End If
                        End If
                End Select
                Select Case dvi
                    Case Is <> 0, 5
                        If VietAnh = "A" Then
                            strChu = strChu + arrTenSoKhongDau(dvi)
                        Else
                            strChu = strChu + arrTenSoCoDau(dvi)
                        End If
                    Case 5
                        If huc <> 0 Then
                            If VietAnh = "A" Then
                                strChu = strChu + " LAM"
                            Else
                                strChu = strChu + " lăm"
                            End If
                        Else
                            If VietAnh = "A" Then
                                strChu = strChu + " NAM"
                            Else
                                strChu = strChu + " năm"
                            End If
                        End If
                End Select
                If VietAnh = "A" Then
                    strChu = strChu + arrTenDonViKhongDau(i)
                Else
                    strChu = strChu + arrTenDonViCoDau(i)
                End If
            End If
            i = i - 1
        End While

        strChu = Trim(strChu)
        If strChu <> "" Then
            SoChu = Left(strChu, 1) + Right(strChu, Len(strChu) - 1)
        Else
            SoChu = "Không"
        End If
    End Function
    Public Function DoiChu(ByVal strSo As String) As String
        Dim b_so As String, strTemp As String = ""
        Dim dblSoLe As Double
        Dim i As Integer, j As Integer
        Dim c As String
        If strSo = "" Then DoiChu = "" : Exit Function
        c = Trim(Str(strSo)) : i = InStr(c, ".") : j = Len(c)
        If i = 0 Then
            b_so = strSo : dblSoLe = 0
        Else
            b_so = IIf(i > 1, Val(Left(c, i - 1)), 0)
            dblSoLe = IIf(j >= i + 1, Mid(c, i), 0)
        End If
        If dblSoLe = 0 Then
            DoiChu = SoChu(b_so) + " " + "mét vuông"
        Else
            DoiChu = SoChu(b_so) + " phẩy" + " " + SoChu(dblSoLe, False) + " mét vuông"
        End If
        'Viet hoa chu cai dau tien
        strTemp = Left(DoiChu, 1)
        strTemp = strTemp.ToUpper & Right(DoiChu, DoiChu.Length - 1)
        DoiChu = strTemp
    End Function
    'doi tien ra dang chu
    Private Function NumToChar(ByVal So As String) As String
        Dim kq As String
        Select Case So
            Case "1"
                kq = "một"
            Case "2"
                kq = "hai"
            Case "3"
                kq = "ba"
            Case "4"
                kq = "bốn"
            Case "5"
                kq = "năm"
            Case "6"
                kq = "sáu"
            Case "7"
                kq = "bảy"
            Case "8"
                kq = "tám"
            Case "9"
                kq = "chín"

            Case Else
                kq = "không"
        End Select
        NumToChar = kq
    End Function
    Public Function NhomToChar(ByVal nd As String, ByVal Nhom As Byte) As String
        Dim rl As String, cd As Byte
        Dim cs1 As String, cs2 As String, cs3 As String
        cs1 = "" : cs2 = "" : cs3 = ""
        nd = Val(nd)
        cd = Len(nd)
        rl = ""

        Select Case cd

            Case 0      'Nhom co 3 so 0
                cs1 = "" : cs2 = "" : cs3 = ""


            Case 1      'Nhom co 1 so
                cs1 = NumToChar(nd)


            Case 2      'Nhom co 2 so
                'Chu so thu nhat
                Select Case Mid(nd, 1, 1)
                    Case "0"
                        cs1 = ""
                    Case "1"
                        cs1 = "mười "
                    Case Else
                        cs1 = NumToChar(Mid(nd, 1, 1))
                End Select

                'Chu so thu hai
                Select Case Mid(nd, 2, 1)
                    Case "0"
                        If Mid(nd, 1, 1) = "1" Then
                            cs2 = ""
                        Else
                            cs2 = "mươi"
                        End If



                    Case "1"
                        If Mid(nd, 1, 1) <> "1" Then
                            cs2 = "mốt"
                        Else
                            cs2 = "một"
                        End If

                    Case Else
                        cs2 = NumToChar(Mid(nd, 2, 1))
                End Select


            Case 3      'Nhom co 3 so

                '            If mID(nd, 1, 1) = "0" And mID(nd, 1, 2) = "0" And mID(nd, 1, 3) = "0" Then     'moi them cho nay
                '                cs1 = "": cs2 = "": cs3 = ""
                '            Else    'ma cu

                'Chu so thu nhat
                cs1 = LTrim(NumToChar(Mid(nd, 1, 1))) & " trăm"


                'Chu so thu 2
                Select Case Mid(nd, 2, 1)
                    Case "0"
                        If Mid(nd, 3, 1) <> "0" Then
                            cs2 = "linh"
                        Else
                            cs2 = ""
                        End If

                    Case "1"
                        cs2 = "mười"

                    Case Else
                        cs2 = NumToChar(Mid(nd, 2, 1))

                End Select

                'Chu so thu 3
                Select Case Mid(nd, 3, 1)
                    Case "0"
                        If Mid(nd, 2, 1) = "0" Or Mid(nd, 2, 1) = "1" Then
                            cs3 = ""
                        Else
                            cs3 = "mươi"
                        End If

                    Case "1"
                        If Mid(nd, 2, 1) = "0" Or Mid(nd, 2, 1) = "1" Then
                            cs3 = "một"
                        Else
                            cs3 = "mốt"
                        End If


                    Case "4"
                        If Mid(nd, 2, 1) <> "1" Then
                            cs3 = "tư"
                        Else
                            cs3 = NumToChar(Mid(nd, 3, 1))
                        End If

                    Case Else
                        cs3 = NumToChar(Mid(nd, 3, 1))
                End Select

                '            End If      'moi them cho nay

        End Select

        rl = cs1 & IIf(cs2 = "", "", " " & cs2) & IIf(cs3 = "", "", " " & cs3)

        Select Case Nhom
            Case 1
                rl = rl & " "

            Case 2
                rl = rl & " nghìn"

            Case 3
                rl = rl & " triệu"

            Case 4
                rl = rl & " tỷ"

            Case 5
                rl = rl & " nghìn "

            Case Else
                rl = "chưa đổi được"
        End Select

        NhomToChar = rl

    End Function


    Private Function PhanNguyen(ByVal SoTien As String) As String
        Dim i As Byte, SoNhom As Byte
        Dim rl As String

        rl = ""
        Select Case Len(SoTien)
            Case Is <= 3
                SoNhom = 1

            Case Is <= 6
                SoNhom = 2

            Case Is <= 9
                SoNhom = 3

            Case Is <= 12
                SoNhom = 4

            Case Is <= 15
                SoNhom = 5

            Case Else
                SoNhom = 0
                rl = "Chưa đổi được số này"

        End Select


        If SoNhom > 0 Then
            Dim ViTri As Byte

            'Nhom ben trai nhat
            ViTri = Len(SoTien) - (SoNhom - 1) * 3
            rl = rl & NhomToChar(Left(SoTien, ViTri), SoNhom)

            'Cac nhom con lai
            For i = 1 To SoNhom - 1
                rl = rl & " " & NhomToChar(Mid(SoTien, ViTri + 1, 3), SoNhom - i)
                ViTri = ViTri + 3
            Next i

        End If

        PhanNguyen = rl

    End Function
    'Ham loai bo cac dau cach, thay bang chi 1 dau cach
    Public Function SuperTrim(ByVal strValue As String) As String
        Dim Temp As String, Space As String
        Space = Chr(32) & Chr(32)
        Temp = Trim(strValue)
        Temp = Replace(Temp, Space, "")
        Do Until InStr(Temp, Space) = 0
            Temp = Replace(Temp, Space, "")
        Loop
        SuperTrim = Temp
    End Function

    Public Function MoneyToChar(ByVal SoTien As String) As String
        Dim CoLe As Integer
        'SoTien = Val(SoTien)
        MoneyToChar = ""
        'Bá c¸c dÊu trèng d·n c¸ch gi÷a c¸c nhãm
        SoTien = SuperTrim(SoTien)
        SoTien = CDbl(SoTien)

        If Len(SoTien) > 0 Then              'Neu sotien <> rong
            If SoTien < 0 Then MoneyToChar = "âm "

            CoLe = InStr(1, SoTien, ".")
            If CoLe = 0 Then    'Khong co phan thap phan
                MoneyToChar += PhanNguyen(SoTien)
            Else                        'Co phan thap phan
                MoneyToChar += PhanNguyen(Left(SoTien, CoLe - 1)) & " không " & _
                    PhanNguyen(Right(SoTien, Len(SoTien) - CoLe))
            End If
            MoneyToChar = UCase(Left(MoneyToChar, 1)) & Mid(MoneyToChar, 2, Len(MoneyToChar) - 1)
        Else
            MoneyToChar = ""
        End If
    End Function


    '=============================================================
    Dim chữsố() As String = {"không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín"}
    Dim đơnvị() As String = {"đơn vị", "ngàn", "triệu", "tỉ"}

    Function đọc(ByVal số As String) As String
        số = số.TrimStart("0")
        'bỏ những số "0" ở đầu tiên

        If số.Length = 0 Then Return ""

        'số = số.Replace(" ", "").Replace(",", "").Replace(".", "")
        'nếu muốn cho phép có dấu " " hay "," hay "." trong số để dễ nhìn thì uncomment dòng đây
        ' tach nhom thap phan rieng roi doc tung phan mot
        Dim mang(2) As String
        mang = Split(số, ".")
        Dim kq As String = ""
        For k As Integer = 0 To mang.Length - 1
            Dim chiềudài As Integer = mang(k).Length

            'dùng biến để lưu lại từng nhóm ba chữ số dể dễ xài
            Dim sốnhóm As Integer = Math.Ceiling(chiềudài / 3)
            'tính số lượng nhóm 3 chữ số
            Dim nhóm(sốnhóm - 1) As String

            'cóp nhóm đầu tiên , rồi lần lượt những nhóm còn lại , j là chiều dài nhóm đầu tiên
            Dim j As Integer = chiềudài - (sốnhóm - 1) * 3
            nhóm(0) = mang(k).Substring(0, j)
            For i As Integer = 1 To sốnhóm - 1
                nhóm(i) = mang(k).Substring(j + (i - 1) * 3, 3)
            Next

            For i As Integer = 0 To nhóm.Length - 1
                kq &= đọcnhóm3số(nhóm(i), tínhđơnvị(nhóm.Length - 1 - i)) & " "
            Next
            kq = kq & " phẩy "
        Next


        Return kq.Trim.Replace("  ", " ")
        'để chắc chắn không có 2 dấu cách đứng liền nhau và 0 có dấu cách ở 2 đầu
    End Function

    Function tínhđơnvị(ByVal n As Integer) As String
        'hàm đệ qui rất đơn giản
        If n <= 3 Then
            Return đơnvị(n)
        Else
            Return tínhđơnvị(n - 3) & " " & đơnvị(3)
        End If
    End Function

    Function đọcnhóm3số(ByVal số As String, ByVal đơnvị As String) As String
        Dim kq As String = ""
        Dim l As Integer = số.Length

        số = số.PadLeft(3, "0")

        If số = "000" Then Return ""
        'không đọc những nhóm "000" như trong "1.000.000.000"

        If số.StartsWith("00") Then Return đọcsốhàngđơnvị(Val(số(2)), 0, l = 3) & " " & đơnvị
        'chỗ này để tránh khó nghe khi đọc "1.000.000.001" , nó sẽ bỏ qua từ "không trăm" và chỉ đọc "một tỉ lẻ một đơn vị" , nếu không thích thì xóa dòng đây đi cũng được

        kq &= đọcsốhàngtrăm(Val(số(0)), l = 3)
        kq &= đọcsốhàngchục(Val(số(1)))
        kq &= đọcsốhàngđơnvị(Val(số(2)), Val(số(1)), l = 3)

        Return kq & " " & đơnvị
    End Function

    Function đọcsốhàngtrăm(ByVal i As Integer, ByVal đọcsốkhông As Boolean) As String
        'biến đọcsốkhông để tránh đọc chữ "không trăm" trong số < 100 như "75" , nếu không dùng biến này thì sẽ đọc là "không trăm bảy mươi lăm"

        If i = 0 Then
            If đọcsốkhông Then
                Return "không trăm "
            Else
                Return ""
            End If
        Else
            Return chữsố(i) & " trăm "
        End If
    End Function

    Function đọcsốhàngchục(ByVal i As Integer) As String
        Select Case i
            Case 0
                Return ""
            Case 1
                Return "mười "
            Case Else
                Return chữsố(i) & " mươi "
        End Select
    End Function

    Function đọcsốhàngđơnvị(ByVal i As Integer, ByVal hàngchục As Integer, ByVal đọcchữlẻ As Boolean) As String
        'biến đọcchữlẻ để tránh đọc chữ "lẻ" trong số < 10 như "2" , nếu không dùng biến này thì sẽ đọc là "lẻ hai"
        'các lệnh điều khiển If...then và select...case chỉ là để đọc cho giống tiếng việt

        If i = 0 Then
            Return ""
        Else
            If hàngchục = 0 Then
                If đọcchữlẻ Then
                    Return "lẻ " & chữsố(i)
                Else
                    Return chữsố(i)
                End If
            Else
                Select Case i
                    Case 1
                        If hàngchục = 1 Then
                            Return "một"
                        Else
                            Return "mốt"
                        End If
                    Case 5
                        Return "lăm"
                    Case Else
                        Return chữsố(i)
                End Select
            End If
        End If

    End Function
#End Region
    Private Const _COUNT As Integer = 22
    Public Shared arrNumbers As String()
    Public Shared c4Word As String
    Public Shared cUnit As String
    Shared Sub New()
        arrNumbers = New String(22) {}
    End Sub
    Public Function GetWordNum(ByVal cString As String, ByVal nWordPosition As Integer, ByVal cDelimiter As Char) As String
        cString = (cString & cDelimiter)
        Dim num As Integer = At(cDelimiter, cString, (nWordPosition - 1))
        Dim num2 As Integer = At(cDelimiter, cString, nWordPosition)
        Return Strings.Mid(cString, (num + 1), ((num2 - 1) - num))
    End Function
    Public Function At(ByVal cSearchFor As String, ByVal cSearchIn As String) As Integer
        Return (cSearchIn.IndexOf(cSearchFor) + 1)
    End Function
    Public Function At(ByVal cSearchFor As String, ByVal cSearchIn As String, ByVal nOccurence As Integer) As Integer
        Return _At(cSearchFor, cSearchIn, nOccurence, 1)
    End Function
    Private Function _At(ByVal cSearchFor As String, ByVal cSearchIn As String, ByVal nOccurence As Integer, ByVal nMode As Integer) As Integer
        Dim num2 As Integer = 0
        Dim num3 As Integer = 0
        Dim startIndex As Integer = 0
        If (nMode = 1) Then
            startIndex = 0
        Else
            startIndex = cSearchIn.Length
        End If
        Dim num5 As Integer = (num2 + 1)
        Dim num6 As Integer = nOccurence
        num2 = 1
        Do While (((num5 >> &H1F) Xor num2) <= ((num5 >> &H1F) Xor num6))
            If (nMode = 1) Then
                startIndex = cSearchIn.IndexOf(cSearchFor, startIndex)
            Else
                startIndex = cSearchIn.LastIndexOf(cSearchFor, startIndex)
            End If
            If (startIndex < 0) Then
                Exit Do
            End If
            num3 += 1
            If (num3 = nOccurence) Then
                Return (startIndex + 1)
            End If
            If (nMode = 1) Then
                startIndex += 1
            Else
                startIndex -= 1
            End If
            num2 = (num2 + num5)
        Loop
        Return 0
    End Function
    Public Sub New()
        Dim cString As String = " không, một, hai, ba, bốn, năm, sáu, bảy, tám, chín, tư, âm, lăm, linh, mốt, mười, mươi, trăm, nghìn, triệu, tỷ, phẩy"
        Dim index As Integer = 0
        Do
            arrNumbers(index) = GetWordNum(cString, (index + 1), ","c)
            index += 1
        Loop While (index <= 21)
        c4Word = arrNumbers(10)
        cUnit = ""
    End Sub
    Private Shared Function GroupNumber2Text(ByVal sGroupCount As String, ByVal nOrderGroup As Integer, ByVal nGroupCounts As Integer) As String
        Dim str8 As String = ""
        Dim inputStr As String = Strings.Right(sGroupCount, 1)
        Dim str3 As String = Strings.Mid(sGroupCount, 2, 1)
        Dim str4 As String = Strings.Left(sGroupCount, 1)
        Dim str As String = arrNumbers(CInt(Math.Round(Conversion.Val(inputStr))))
        Dim str6 As String = arrNumbers(CInt(Math.Round(Conversion.Val(str3))))
        Dim str5 As String = arrNumbers(CInt(Math.Round(Conversion.Val(str4))))
        If str4 <> "0" Or ((nOrderGroup = 1) And (nOrderGroup < nGroupCounts)) Then
            str8 = (str8 & str5 & arrNumbers(&H11))
        End If
        If Trim(str6) <> Trim(arrNumbers(0)) Then
            If Trim(str6) <> Trim(arrNumbers(1)) Then
                str8 = (str8 & str6 & arrNumbers(&H10))
                If Trim(str) <> Trim(arrNumbers(5)) Then
                    If Trim(str) <> Trim(arrNumbers(0)) Then
                        If Trim(str) = Trim(arrNumbers(1)) Then
                            str8 = (str8 & arrNumbers(14))
                        ElseIf Trim(str) = Trim(arrNumbers(4)) And (nOrderGroup > 1) Then
                            str8 = (str8 & c4Word)
                        Else
                            str8 = (str8 & str)
                        End If
                    End If
                Else
                    str8 = (str8 & arrNumbers(12))
                End If
            Else
                str8 = (str8 & arrNumbers(15))
                If Trim(str) <> Trim(arrNumbers(5)) Then
                    If Trim(str) <> Trim(arrNumbers(0)) Then
                        str8 = (str8 & str)
                    End If
                Else
                    str8 = (str8 & arrNumbers(12))
                End If
            End If
        ElseIf Trim(str) <> Trim(arrNumbers(0)) Then
            str8 = (str8 & arrNumbers(13))
            If Trim(str) <> Trim(arrNumbers(4)) Then
                str8 = (str8 & str)
            Else
                str8 = (str8 & c4Word)
            End If
        End If
        If (str4 = "0") And (str3 = "0") And (inputStr <> "0") And (nOrderGroup > 1) Then
            str8 = str
        End If
        If (str4 = "0") And (str3 = "0") And (inputStr <> "0") And (nGroupCounts = 1) Then
            str8 = str
        End If
        Select Case nOrderGroup
            Case 2
                str8 = (str8 & arrNumbers(&H12))
                Exit Select
            Case 3
                str8 = (str8 & arrNumbers(&H13))
                Exit Select
            Case 4
                str8 = (str8 & arrNumbers(20))
                Exit Select
            Case 5
                str8 = (str8 & arrNumbers(&H12))
                Exit Select
            Case 6
                str8 = (str8 & arrNumbers(20))
                Exit Select
        End Select
        If ((str4 = "0") And (str3 = "0") And (inputStr = "0")) Then
            str8 = ""
        End If
        Return str8
    End Function
    Public Shared Function Number2Text(ByVal nNumber As Decimal) As String
        Dim str As String = ""
        If (Decimal.Compare(nNumber, Decimal.Zero) < 0) Then
            nNumber = Decimal.Negate(nNumber)
            str = (str & arrNumbers(11))
        End If
        Dim num As Decimal = Decimal.Subtract(nNumber, Conversion.Int(nNumber))
        If (Decimal.Compare(nNumber, Decimal.Zero) = 0) Then
            str = (str & arrNumbers(0) & "0")
        Else
            Dim expression As String = Strings.Trim(Conversion.Str(Conversion.Int(nNumber)))
            If ((Strings.Len(expression) Mod 3) = 1) Then
                expression = ("00" & expression)
            End If
            If ((Strings.Len(expression) Mod 3) = 2) Then
                expression = ("0" & expression)
            End If
            Dim nGroupCounts As Integer = CInt(Math.Round(Conversion.Int(CDbl((CDbl(Strings.Len(expression)) / 3)))))
            Dim nOrderGroup As Integer = nGroupCounts
            Dim i As Integer = 1
            Do While (i <= (Strings.Len(expression) - 2))
                Dim sGroupCount As String = Strings.Mid(expression, i, 3)
                nOrderGroup = CInt(Math.Round(Math.Round(CDbl((CDbl(((Strings.Len(expression) - i) + 1)) / 3)), 0)))
                If (Strings.Len(GroupNumber2Text(sGroupCount, nOrderGroup, nGroupCounts)) > 0) Then
                    If (nOrderGroup < 5) Then
                        str = (str & GroupNumber2Text(sGroupCount, nOrderGroup, nGroupCounts) & ",")
                    Else
                        str = (str & GroupNumber2Text(sGroupCount, nOrderGroup, nGroupCounts))
                    End If
                Else
                    str = (str & GroupNumber2Text(sGroupCount, nOrderGroup, nGroupCounts))
                End If
                i = (i + 3)
            Loop
        End If
        str = Strings.Left(Strings.Trim(str), (Strings.Len(Strings.Trim(str)) - 1))
        If (Decimal.Compare(num, Decimal.Zero) > 0) Then
            str = (str & arrNumbers(&H15))
            Dim str6 As String = Trim(Convert.ToSingle(num))
            If (Strings.Len(str6) > 2) Then
                str6 = (Strings.Right(str6, (Strings.Len(str6) - 2)) & "Z")
            End If
            Do While Left(str6, 1) = "0"
                str = (str & " " & Strings.Trim(arrNumbers(0)))
                str6 = Strings.Right(str6, (Strings.Len(str6) - 1))
            Loop
            Do While (Decimal.Compare(num, Conversion.Int(num)) <> 0)
                num = Decimal.Multiply(num, 10)
            Loop
            'Dim vnnumbertext As New vnnumber2text.vnnumber2text
            Dim vnnumbertext As New clsDoiSoThanhChu
            str = (str & " " & Strings.LCase(Number2Text(num)))
        End If
        Return Strings.Trim((Strings.UCase(Strings.Left(str, 1)) & Strings.Mid(str, 2) & " " & cUnit))
    End Function


End Class
