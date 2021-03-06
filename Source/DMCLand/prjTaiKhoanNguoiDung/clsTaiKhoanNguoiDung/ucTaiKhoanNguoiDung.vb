Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Windows.Forms
Imports DMC.Database

Public Class ucTaiKhoanNguoiDung
    Public strTenTruyCap As String
    Public strTBLNguoidung As String
    Private strConnection As String
    Public sqlConnect As SqlConnection
    Private sqlCmd As New SqlCommand
    Private sqlDA As New SqlDataAdapter
    Private TableUsers As New DataTable
    Private bSua As Boolean = False
    Private MaQuyen As Integer
    Private strTrangThaiKetNoi As Integer
    Private strError As String = ""
    Private strparas() As String = {"@flag", "@MaUsers", "@TenDangNhap", "@MaQuyen", "@MatKhau", "@NgayTaoUser", "@TenDayDu", "@ChucVu", "@PhongBan", "@DiaChi", "@SoDienThoai"}
    Public Sub New()
        MyBase.New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        For Each ob As Object In grpThongtinnguoidung.Controls
            If TypeOf ob Is TextBox Then
                ob.backcolor = Color.LightYellow
                ob.readonly = True
            End If
        Next
    End Sub
    Private Sub tlstpbtSua_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tlstpbtSua.Click
        '
        txtTenDayDu.BackColor = Color.White
        txtTenDayDu.ReadOnly = False
        txtMatKhauHienThoi.BackColor = Color.White
        txtMatKhauHienThoi.ReadOnly = False
        txtMatKhauMoi.BackColor = Color.White
        txtMatKhauMoi.ReadOnly = False
        txtPhongBan.BackColor = Color.White
        txtPhongBan.ReadOnly = False
        txtDiaChi.BackColor = Color.White
        txtDiaChi.ReadOnly = False
        txtSoDienThoai.BackColor = Color.White
        txtSoDienThoai.ReadOnly = False
        txtChucVu.ReadOnly = False
        txtChucVu.BackColor = Color.White
        bSua = True
        tlstpbtSua.Enabled = False
        tlstpbtCapNhat.Enabled = True
    End Sub

    Private Sub tlstpThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.FindForm.Close()
    End Sub
    Private Sub tlstpbtQuayLai_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tlstpbtQuayLai.Click
        'quay tro lai thong tin vua hien thi
        HienThiThongTin()
        txtMatKhauHienThoi.Text = ""
        txtMatKhauMoi.Text = ""
    End Sub
    Private Sub tlstpbtCapNhat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tlstpbtCapNhat.Click

        If bSua Then
            If IsNumeric(txtSoDienThoai.Text) = False Then
                txtSoDienThoai.Text = ""
            End If
            If txtMatKhauHienThoi.Text = "" Then
                MsgBox("Hãy nhập mật khẩu đang sử dụng")
                txtMatKhauHienThoi.Focus()
                Exit Sub
            End If
            If txtMatKhauMoi.Text = "" Then
                MsgBox("Bạn chưa nhập mật khẩu mới")
                txtMatKhauMoi.Focus()
                Exit Sub
            End If
            'truong hop flag=0
            'cap nhat thong tin da duoc sua vao CSDL
            If Encrypt(txtMatKhauHienThoi.Text) = TableUsers.Rows(0).Item(4).ToString Then
                If updateNguoiDung() Then
                    MsgBox("Cập nhật thành công !")
                    tlstpbtSua.Enabled = True
                    tlstpbtCapNhat.Enabled = False
                Else
                    MsgBox("Cập nhật thất bại !")
                End If

            Else
                'truong hop sai mat khau hien thoi
                MsgBox("Mật khẩu hiện thời không chính xác! Hãy nhập lại")
                txtMatKhauHienThoi.Focus()
                Exit Sub
            End If
            bSua = False
            ' dinh dang lai cac dieu khien 
            For Each ob As Object In grpThongtinnguoidung.Controls
                If TypeOf ob Is TextBox Then
                    ob.backcolor = Color.LightYellow
                    ob.readonly = True
                End If
            Next
        End If
    End Sub
    Private result As String = ""
    'thu tuc thuc hien viec update thogn tin nguoi dung
    Public Function updateNguoiDung() As Boolean
        Dim cmd As New SqlCommand
        Dim myParameter As New SqlParameter
        Dim strKT As String = ""
        Try
            strError = ""
            updateNguoiDung = False


            Dim values() As String = {0, TableUsers.Rows(0).Item(0).ToString(), txtTen.Text.ToString(), MaQuyen.ToString(), Encrypt(txtMatKhauMoi.Text), txtNgayTao.Text.ToString(), _
            txtTenDayDu.Text.ToString(), txtChucVu.Text.ToString(), txtPhongBan.Text.ToString(), txtDiaChi.Text.ToString(), txtSoDienThoai.Text.ToString()}

            Dim databse As New DMC.Database.clsDatabase
            databse.Connection = strConnection

            If databse.OpenConnection = True Then

                If (strparas.Length <> values.Length) Then
                    Return "0"
                End If
                'Goi phuong thuc ExecuteSP cua doi tuong clsSQLDatabase
                databse.ExecuteSP("spTaiKhoanNguoiDung", strparas, values, strKT)
                strError = databse.Err
                databse.CloseConnection()
            End If
            updateNguoiDung = True

        Catch ex As Exception
            strError = ex.Message
            MsgBox("Lỗi thực thi dữ liệu !", MsgBoxStyle.Information, "Lỗi thực thi cơ sở dữ liệu")
        End Try
        'cmd.Connection = sqlConnect
        'cmd.CommandText = "spTaiKhoanNguoiDung"
        'cmd.CommandType = CommandType.StoredProcedure
        '.Parameters.Add(New SqlParameter("@flag", SqlDbType.Int))
        '.Parameters("@flag").Value = 0
        '.Parameters.Add(New SqlParameter("@matkhau", SqlDbType.NVarChar, 50))
        '.Parameters("@matkhau").Value = Encrypt(txtMatKhauMoi.Text)
        '.Parameters.Add(New SqlParameter("@TenDayDu", SqlDbType.NVarChar, 50))
        '.Parameters("@TenDayDu").Value = txtTenDayDu.Text
        '.Parameters.Add(New SqlParameter("@ChucVu", SqlDbType.NVarChar, 50))
        '.Parameters("@ChucVu").Value = txtChucVu.Text
        '.Parameters.Add(New SqlParameter("@PhongBan", SqlDbType.NVarChar, 50))
        '.Parameters("@PhongBan").Value = txtPhongBan.Text
        '.Parameters.Add(New SqlParameter("@DiaChi", SqlDbType.NVarChar, 50))
        '.Parameters("@DiaChi").Value = txtDiaChi.Text
        '.Parameters.Add(New SqlParameter("@SoDienThoai", SqlDbType.NVarChar, 50))
        '.Parameters("@SoDienThoai").Value = txtSoDienThoai.Text
        '.Parameters.Add(New SqlParameter("@MaUsers", SqlDbType.NVarChar, 50))
        '.Parameters("@MaUsers").Value = TableUsers.Rows(0).Item(0).ToString
        '.Parameters.Add(New SqlParameter("@TenDangNhap", SqlDbType.NVarChar, 50))
        '.Parameters("@TenDangNhap").Value = txtTen.Text
        '.Parameters.Add(New SqlParameter("@MaQuyen", SqlDbType.NVarChar, 50))
        '.Parameters("@MaQuyen").Value = MaQuyen
        '.Parameters.Add(New SqlParameter("@NgayTaoUser", SqlDbType.NVarChar, 50))
        '.Parameters("@NgayTaoUser").Value = txtNgayTao.Text
        'Try
        '    For i As Integer = 0 To strparas.Length - 1
        '        myParameter = New SqlParameter(strparas(i), values(i))
        '        'Add vào tập hợp thực thi truy vấn SqlCommand
        '        cmd.Parameters.Add(myParameter)
        '    Next
        '    result = cmd.ExecuteScalar
        '    updateNguoiDung = True
        '    sqlConnect.Close()
        'Catch ex As Exception
        'End Try
        Return updateNguoiDung
    End Function
    Public Property getstrTenTruyCap()
        Get
            Return strTenTruyCap
        End Get
        Set(ByVal value)
            strTenTruyCap = value
        End Set
    End Property
    Public Property getConnect() As SqlConnection
        Get
            Return sqlConnect
        End Get
        Set(ByVal value As SqlConnection)
            sqlConnect = value
        End Set
    End Property
    Public Property Connection() As String
        Get
            Return strConnection
        End Get
        Set(ByVal value As String)
            strConnection = value
        End Set
    End Property
    Public Property TrangThaiKetNoi() As Integer
        Get
            Return strTrangThaiKetNoi
        End Get
        Set(ByVal value As Integer)
            strTrangThaiKetNoi = value
        End Set
    End Property

    Public Function MyTable(ByVal SP As String, ByVal flag As Integer, ByVal fiedlName As String, ByVal Values As String) As DataTable
        Dim cmd As New SqlCommand
        Dim datAdap As New SqlDataAdapter
        Dim ds As New DataSet
        Dim myParameter As New SqlParameter
        Dim MyArr() As String = {"MaUsers", "TenDangNhap", "MaQuyen", "MatKhau", "NgayTaoUser", "TenDayDu", "ChucVu", "PhongBan", "DiaChi", "SoDienThoai"}
        Try
            With cmd
                .Connection = sqlConnect
                .CommandText = SP
                .CommandType = CommandType.StoredProcedure
                For i As Integer = 0 To MyArr.Count - 1
                    If Not fiedlName.ToUpper = MyArr(i).ToUpper Then
                        .Parameters.Add(New SqlParameter("@" & MyArr(i) & "", SqlDbType.NVarChar, 50))
                        .Parameters("@" & MyArr(i) & "").Value = DBNull.Value
                    End If
                Next
                .Parameters.Add(New SqlParameter("@flag", SqlDbType.Int))
                .Parameters("@flag").Value = flag
                .Parameters.Add(New SqlParameter("@" & fiedlName & "", SqlDbType.NVarChar, 50))
                .Parameters("@" & fiedlName & "").Value = Values
            End With
            datAdap.SelectCommand = cmd
            datAdap.Fill(ds)
            sqlConnect.Close()
        Catch ex As Exception
            MessageBox.Show("Lỗi : " & ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function MyTableDVHC(ByVal SP As String, ByVal flag As Integer, ByVal fiedlName As String, ByVal Values As String) As DataTable
        Dim cmd As New SqlCommand
        Dim datAdap As New SqlDataAdapter
        Dim ds As New DataSet
        Dim myParameter As New SqlParameter
        Dim MyArr() As String = {"MaDonViHanhChinh", "ten", "MaTinh", "MaHuyen", "MaXa"}
        Dim MyArrValues() As String = {"", "", "", "", ""}
        Try
            With cmd
                .Connection = sqlConnect
                .CommandText = SP
                .CommandType = CommandType.StoredProcedure
                For i As Integer = 0 To MyArr.Count - 1
                    If Not fiedlName.ToUpper = MyArr(i).ToUpper Then
                        .Parameters.Add(New SqlParameter("@" & MyArr(i) & "", SqlDbType.NVarChar, 50))
                        .Parameters("@" & MyArr(i) & "").Value = DBNull.Value
                    End If
                Next
                .Parameters.Add(New SqlParameter("@flag", SqlDbType.Int))
                .Parameters("@flag").Value = flag
                .Parameters.Add(New SqlParameter("@" & fiedlName & "", SqlDbType.NVarChar, 50))
                .Parameters("@" & fiedlName & "").Value = Values
            End With
            datAdap.SelectCommand = cmd
            datAdap.Fill(ds)
            sqlConnect.Close()
        Catch ex As Exception
            MessageBox.Show("Lỗi : " & ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return ds.Tables(0)
    End Function
    Private Sub HienThiThongTin(ByVal dtDS As DataTable)
        'txtMaNguoidung.Text = dtDS.Tables(0).Rows(0).Item(0).ToString
        'load cac thong tin trong cSDL ra cac dieu khien
        txtTen.Text = dtDS.Rows(0).Item("TenDangNhap").ToString
        txtTenDayDu.Text = dtDS.Rows(0).Item("TenDayDu").ToString
        txtNgayTao.Text = dtDS.Rows(0).Item("NgayTaoUser").ToString
        '  txtMatKhauHienThoi.Text = dtDS.Tables(0).Rows(0).Item(3).ToString
        txtDiaChi.Text = dtDS.Rows(0).Item("DiaChi").ToString
        txtChucVu.Text = dtDS.Rows(0).Item("ChucVu").ToString
        txtPhongBan.Text = dtDS.Rows(0).Item("PhongBan").ToString
        txtSoDienThoai.Text = dtDS.Rows(0).Item("SoDienThoai").ToString

        'Tìm đến quyền
        Dim dtdsquyen As New DataSet

        'truong hop flag=1
        Try
            'load ten quyen ra dieu khien textbox
            Dim TableMaQuyen As New DataTable
            TableMaQuyen = MyTable("spTaiKhoanNguoiDung", 1, "MaQuyen", dtDS.Rows(0).Item("MaQuyen").ToString)
            txtQuyen.Text = TableMaQuyen.Rows(0).Item("Quyen").ToString 'TableMaQuyen.Rows(0).Item(1).ToString
            MaQuyen = dtDS.Rows(0).Item("MaQuyen")
        Catch ex As Exception
            txtQuyen.Text = ""
        End Try
        'Tìm các đơn vị hành chính mà người sử dụng quản lý

        Try
            'truong hop flag=2
            'load cac don vi hanh chinh ra gridview
            Dim dtdsdvhc As New DataTable
            dtdsdvhc = MyTable("spTaiKhoanNguoiDung", 2, "MaUsers", dtDS.Rows(0).Item("MaUsers").ToString)
            For i As Integer = 0 To dtdsdvhc.Rows.Count - 1
                grdvwDonViHanhChinh.RowCount = i + 1
                grdvwDonViHanhChinh.Item(0, i).Value = dtdsdvhc.Rows(i).Item(2).ToString
                grdvwDonViHanhChinh.Item(2, i).Value = dtdsdvhc.Rows(i).Item(3).ToString
                '@flag=0 trong spTuDienDonViHanhChinh

                Dim dtset As New DataTable
                dtset = MyTableDVHC("spTuDienDonViHanhChinh", 0, "madonvihanhchinh", grdvwDonViHanhChinh.Item(0, i).Value)
                If dtset.Rows.Count > 0 Then
                    grdvwDonViHanhChinh.Item(1, i).Value = dtset.Rows(0).Item(1).ToString
                    If dtset.Rows(0).Item(2).ToString <> 0 Then
                        '@flag=1 trong spTuDienDonViHanhChinh
                        Dim dst As New DataTable
                        dst = MyTableDVHC("spTuDienDonViHanhChinh", 1, "matinh", dtset.Rows(0).Item("MaTinh").ToString)
                        grdvwDonViHanhChinh.Item(3, i).Value = dst.Rows(0).Item(0).ToString
                        If dtset.Rows(0).Item(3).ToString <> 0 Then
                            '@flag=2 trong spTuDienDonViHanhChinh
                            Dim dst1 As New DataTable
                            dst1 = MyTableDVHC("spTuDienDonViHanhChinh", 2, "mahuyen", dtset.Rows(0).Item("MaHuyen").ToString)
                           grdvwDonViHanhChinh.Item(4, i).Value = dst1.Rows(0).Item(0).ToString
                            If dtset.Rows(0).Item(4).ToString Then
                                '@flag=3 trong spTuDienDonViHanhChinh
                                Dim dst2 As New DataTable
                                dst1 = MyTableDVHC("spTuDienDonViHanhChinh", 3, "maxa", dtset.Rows(0).Item("Maxa").ToString)
                                grdvwDonViHanhChinh.Item(5, i).Value = dst2.Rows(0).Item(0).ToString
                            End If
                        End If
                    End If
                End If
            Next
        Catch ex As Exception

        End Try

    End Sub
    Public Sub chay_query(ByVal sql As String, ByRef ds As DataSet, ByVal Nametable As String)
        Dim cmd As New SqlCommand
        cmd.CommandType = CommandType.Text
        cmd.CommandText = sql
        cmd.Connection = sqlConnect
        cmd.ExecuteNonQuery()
        Dim da As New SqlDataAdapter
        da.SelectCommand = cmd
        da.Fill(ds, Nametable)
        cmd.Dispose()
        sqlConnect.Close()
    End Sub
    'Khi login thành công 
    Public Sub Hienthithongtin()
        If sqlConnect.State <> ConnectionState.Open Then
            sqlConnect.Open()
        End If
        'truong hop flag=3
        TableUsers = MyTable("spTaiKhoanNguoiDung", 3, "Tendangnhap", strTenTruyCap)
        sqlCmd.Dispose()
        HienThiThongTin(TableUsers)
        If sqlConnect.State = ConnectionState.Open Then
            strTrangThaiKetNoi = 1
        Else
            strTrangThaiKetNoi = 0
        End If
    End Sub

    Private Function AddParam(ByVal strArrParam As String, ByVal iNumber As Integer, ByRef sqlCmd As SqlCommand) As DataSet
        Dim strtemp(iNumber * 2) As String
        Dim dtDA As New SqlDataAdapter
        Dim dtds As New DataSet
        TachXau(strArrParam, strtemp)
        'Set our parm properties
        For i As Integer = 1 To iNumber * 2
            If i Mod 2 = 1 Then
                Dim oParam As New SqlClient.SqlParameter
                oParam = sqlCmd.CreateParameter()
                oParam.ParameterName = strtemp(i)
                oParam.Value = strtemp(i + 1)
                sqlCmd.Parameters.Add(oParam)
            End If
        Next
        sqlCmd.ExecuteNonQuery()
        dtDA.SelectCommand = sqlCmd
        dtDA.Fill(dtds, "result")
        Try
            If dtds.Tables("result").Rows.Count > 0 Then
                Return dtds
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Return Nothing
        End Try
        sqlConnect.Close()
    End Function
    Private Sub TachXau(ByVal FullString As String, ByRef SplitString() As String)
        Dim i As Integer, NumStr As Integer
        NumStr = 0
        i = 1
        Do
            Do While (Mid$(FullString, i, 1) = " ") Or (Mid$(FullString, i, 1) = ",") _
                                Or (Mid$(FullString, i, 1) = Chr(32)) Or (Mid$(FullString, i, 1) = ";") _
                                Or (Mid$(FullString, i, 1) = Chr(34)) Or (Mid$(FullString, i, 1) = Chr(9)) _
                                Or (Mid$(FullString, i, 1) = ":") _
                                And (i <= Len(FullString))
                i = i + 1
            Loop
            If i <= Len(FullString) Then
                NumStr = NumStr + 1
                ReDim Preserve SplitString(NumStr)
                SplitString(NumStr) = ""
            End If
            Do While (i <= Len(FullString)) And (Mid$(FullString, i, 1) <> " ") _
                And (Mid$(FullString, i, 1) <> ",") _
                And (Mid$(FullString, i, 1) <> Chr(32)) _
                And (Mid$(FullString, i, 1) <> ";") _
                And (Mid$(FullString, i, 1) <> Chr(34)) _
                And (Mid$(FullString, i, 1) <> Chr(9)) _
                And (Mid$(FullString, i, 1) <> ":")
                SplitString(NumStr) = SplitString(NumStr) + Mid$(FullString, i, 1)
                i = i + 1
            Loop
        Loop Until i > Len(FullString)
    End Sub
    Private Function Encrypt(ByVal mess As String) As String
        Dim x As New System.Security.Cryptography.MD5CryptoServiceProvider
        Dim bs As Byte()
        bs = System.Text.Encoding.UTF8.GetBytes(mess)
        bs = x.ComputeHash(bs)
        Dim s As New System.Text.StringBuilder
        For Each b As Byte In bs
            s.Append(b.ToString("x2").ToLower)
        Next
        Return s.ToString.ToUpper
    End Function



    Public Sub ucTaiKhoanNguoiDungConnect()

        sqlConnect = New SqlConnection
        sqlConnect.ConnectionString = strConnection
        If sqlConnect.State = ConnectionState.Closed Then
            sqlConnect.Open()
            getConnect = sqlConnect
        End If
        'Dim strconnection As String = ""
        'Dim sc As New SqlConnection
        'strconnection = "Data Source=DMC-CHUNG\DMC_CHUNG2005;Initial Catalog=DMCLand20090304;User ID=sa"
        'sc.ConnectionString = strconnection
        'sc.Open()
        'getConnect = sc
        'getstrTenTruyCap = "thanh"
        'HienThiThongTin()
    End Sub

    Private Sub ucTaiKhoanNguoiDung_HandleDestroyed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.HandleDestroyed
        sqlConnect.Close()
    End Sub
End Class
