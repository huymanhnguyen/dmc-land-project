Public Class clsDoiSoThanhChu
    'Doi so thanh chu
    Public Function SoChu(ByVal dblSo As Double, Optional ByVal VietAnh As String = "V") As String
        Dim arrTenSoKhongDau(10) As String, arrTenDonViKhongDau(5) As String, arrTenSoCoDau(10) As String, arrTenDonViCoDau(5) As String
        Dim lo(5) As Double, lo_v(5) As String
        Dim dblSo1 As Double, solop As Double, dblSo2 As Double, strChu As String, dblTram As Double
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
            dblSo2 = dblSo1
            dblSo1 = Int(dblSo1 / 1000)
            lo(solop) = dblSo2 - dblSo1 * 1000
            solop = solop + 1
        End While
        '**********
        i = solop - 1
        j = i
        strChu = " "
        While i > 0 'doi 3 so ra chu so
            dblSo1 = Int(lo(i))
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
            dblSoLe = IIf(j >= i + 1, Mid(c, i + 1), 0)
        End If
        If dblSoLe = 0 Then
            DoiChu = SoChu(b_so) + " " + "mét vuông"
        Else
            DoiChu = SoChu(b_so) + " phẩy" + " " + SoChu(dblSoLe) + " mét vuông"
        End If
        'Viet hoa chu cai dau tien
        strTemp = Left(DoiChu, 1)
        strTemp = strTemp.ToUpper & Right(DoiChu, DoiChu.Length - 1)
        DoiChu = strTemp
    End Function
End Class
