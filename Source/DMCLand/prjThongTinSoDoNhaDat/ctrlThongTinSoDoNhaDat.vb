Imports System.Drawing
Imports System.Windows.Forms

Public Class ctrlThongTinSoDoNhaDat
    Private Structure Image_Pos
        Dim Top As Long
        Dim Left As Long
        Dim Height As Long
        Dim Width As Long
    End Structure

    Private iHeightMin As Single, iWidthMin As Single, Z_index As Integer
    Private Tmp_Pos As Image_Pos, Ori_pos As Image_Pos

    Private pointPanStart As New Point
    Private bytSoDoNhaDat As Byte()
    Private imgSoDoNhaDat As Image
    'Khai báo biến chuỗi kết nối cơ sở dữ liệu
    Private strConnection As String = ""
    'Khai báo Mã hồ sơ cấp GCN
    Private strMaHoSoCapGCN As String = ""

    Private strMaDonViHanhChinh As String
    Public Property MaDonVihanhChinh() As String
        Get
            Return strMaDonViHanhChinh
        End Get
        Set(ByVal value As String)
            strMaDonViHanhChinh = value
        End Set
    End Property
    'Khai báo thuộc tính nhận chuỗi kết nối cơ sở dữ liệu
    Public WriteOnly Property Connection() As String
        'Get
        '    Return strConnection
        'End Get
        Set(ByVal value As String)
            strConnection = value
        End Set
    End Property
    'Khai báo thuộc tính nhận Mã hồ sơ cấp GCN
    Public Property MaHoSoCapGCN() As String
        'Get
        '    Return strMaHoSoCapGCN
        'End Get
        Set(ByVal value As String)
            strMaHoSoCapGCN = value
        End Set
        Get
            Return strMaHoSoCapGCN
        End Get
    End Property
    Private MaLoaiBienDong As String = ""
    Public Property MaKhoa() As String
        Get
            Return MaLoaiBienDong
        End Get
        Set(ByVal value As String)
            MaLoaiBienDong = value
        End Set
    End Property

    Private Sub btnMoTep_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMoTep.Click
        'Me.Panel1.AutoScroll = True
        'Me.picSoDoNhaDat.SizeMode = Windows.Forms.PictureBoxSizeMode.CenterImage
        'Me.MoTep()
        Dim Path As String = ""
        Path = System.Windows.Forms.Application.StartupPath & "\UpLoadAnh.exe"
        If System.IO.File.Exists(Path) Then
            Process.Start(Path)
        Else
            MessageBox.Show("Kiểm tra lại file thực thi Upload ảnh!!!", "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub MoTep()
        With OpenFileDialog1
            .Title = "Chọn ảnh sơ đồ Nhà đất"
            '.InitialDirectory = "C:\My HORSES & NICE HORSES Files"
            .FileName = ""
            .CheckFileExists = True
            .Filter = "Tệp ảnh (*)|*.bmp;*.gif;*.jpg;*.jpeg;*.png;*.tif"
            .ShowDialog()
            If (.FileName.Trim = "") Then
                Exit Sub
            End If
            Me.Panel1.AutoScroll = True
            imgSoDoNhaDat = Image.FromFile(.FileName)
            ' Me.picSoDoNhaDat.Image = imgSoDoNhaDat

            With Me.picSoDoNhaDat
                .SizeMode = PictureBoxSizeMode.StretchImage
                .Height = imgSoDoNhaDat.Height * Me.Panel1.ClientSize.Width / imgSoDoNhaDat.Width
                .Width = Me.Panel1.ClientSize.Width
                If Me.Panel1.ClientSize.Height > imgSoDoNhaDat.Height Then
                    .Width -= SystemInformation.VerticalScrollBarWidth
                End If
                .Image = imgSoDoNhaDat
            End With
        End With
    End Sub

    Public Sub ShowData()
        If Me.MaLoaiBienDong <> "MG" Then
            Me.GroupBox2.Enabled = True
        Else
            Me.GroupBox2.Enabled = False
        End If
        Dim mapTools As New DMC.GIS.Common.mapTools
        Dim HoSoKiThuat As New DMC.GIS.Common.HoSoKiThuat
        HoSoKiThuat.Connection = strConnection
        HoSoKiThuat.MaHoSoCapGCN = strMaHoSoCapGCN
        'Kiểm tra tính hợp lệ của dữ liệu 
        'Chắc chắn rằng tồn tại chuỗi kết nối cơ sở dữ liệu
        If (strConnection = "") Then
            System.Windows.Forms.MessageBox.Show("Không tìm thấy kết nối cơ sở dữ liệu", "DMCLand", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Warning)
            Return
        End If
        'Chắc chắn rằng tồn tại Mã hồ sơ cấp GCN cần cập nhật sơ đồ Nhà, đất
        If (strMaHoSoCapGCN = "") Then
            System.Windows.Forms.MessageBox.Show("Không tìm thấy Mã hồ sơ cấp GCN", "DMCLand", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Warning)
            Return
        End If
        HoSoKiThuat.Connection = strConnection
        HoSoKiThuat.MaHoSoCapGCN = strMaHoSoCapGCN
        'Khởi tạo giá trị 
        bytSoDoNhaDat = HoSoKiThuat.SelectHoSoKiThuat("spSelectSoDoNhaDatByMaHoSoCapGCN")
        'Chắc chắn rằng tồn tại Sơ đồ thửa đất
        If (bytSoDoNhaDat Is Nothing) Then
            Me.picSoDoNhaDat.Image = Nothing
            Return
        End If
        If HoSoKiThuat.HienThiAnhThua = "True" Then
            chkHienThiAnhThua.Checked = True
        Else
            chkHienThiAnhThua.Checked = False
        End If
        'Hiển thị lên Form

        Me.picSoDoNhaDat.Image = mapTools.byteArrayToImage(bytSoDoNhaDat)

    End Sub

    Private Sub UpdateSoDoNhaDatThamDinh()
        Dim mapTools As New DMC.GIS.Common.MapTools
        Dim HoSoKiThuat As New DMC.GIS.Common.HoSoKiThuat
        HoSoKiThuat.Connection = strConnection
        HoSoKiThuat.MaHoSoCapGCN = strMaHoSoCapGCN
        'Kiểm tra tính hợp lệ của dữ liệu 
        'Chắc chắn rằng tồn tại chuỗi kết nối cơ sở dữ liệu
        If (strConnection = "") Then
            System.Windows.Forms.MessageBox.Show("Không tìm thấy kết nối cơ sở dữ liệu", "DMCLand", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Warning)
            Return
        End If
        'Chắc chắn rằng tồn tại Mã hồ sơ cấp GCN cần cập nhật sơ đồ Nhà, đất
        If (strMaHoSoCapGCN = "") Then
            System.Windows.Forms.MessageBox.Show("Không tìm thấy Mã hồ sơ cấp GCN", "DMCLand", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Warning)
            Return
        End If
        'Xác nhận hình ảnh sơ đồ Nhà, đất cần cập nhật
        bytSoDoNhaDat = mapTools.imageToByteArray(imgSoDoNhaDat)
        'Chắc chắn rằng có hình ảnh sơ đồ Nhà, đất cần cập nhật
        'If (bytSoDoNhaDat Is Nothing) Then
        '    System.Windows.Forms.MessageBox.Show("Không có sơ đồ nhà, đất nào", "DMCLand", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Warning)
        '    Exit Sub
        'End If
        If (chkHienThiAnhThua.Checked) Then
            HoSoKiThuat.HienThiAnhThua = "1"
        Else
            HoSoKiThuat.HienThiAnhThua = "0"
        End If
        HoSoKiThuat.HoSoKiThuatThuaDat = bytSoDoNhaDat
        HoSoKiThuat.UpdateHoSoCapGCNByHoSoKiThuatThamDinh()
    End Sub

    Private Function ReadFile(ByVal strPath As String) As Byte()
        'Khở tạo mảng Byte với giá trị khởi tạo là Nothing
        Dim bytData As Byte() = Nothing
        'Use FileInfo object to get file size.
        Dim fileInfo As New IO.FileInfo(strPath)
        Dim longBytes As Long = fileInfo.Length
        'Open FileStream to read file
        Dim fileStream As New IO.FileStream(strPath, IO.FileMode.Open, IO.FileAccess.Read)
        'Use BinaryReader to read file stream into byte array.
        Dim binaryReader As New IO.BinaryReader(fileStream)
        'When you use BinaryReader, you need to 
        'supply number of bytes to read from file.
        'In this case we want to read entire file. 
        'So supplying total number of bytes.
        bytData = binaryReader.ReadBytes(Convert.ToInt32(longBytes))
        Return bytData
    End Function

    Private Sub picSoDoNhaDat_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles picSoDoNhaDat.MouseDown
        'Capture the initial point 
        pointPanStart = New Point(e.X, e.Y)
    End Sub

    Private Sub picSoDoNhaDat_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles picSoDoNhaDat.MouseMove
        'Verify Left Button is pressed while the mouse is moving
        If e.Button = Windows.Forms.MouseButtons.Left Then
            'Here we get the change in coordinates.
            'We multiply it by -1 because of how the panels autoscroll works.
            'Dim DeltaX As Integer = (e.X - m_PanStartPoint.X) * -1
            'Dim DeltaY As Integer = (e.Y - m_PanStartPoint.Y) * -1
            Dim DeltaX As Integer = (pointPanStart.X - e.X)
            Dim DeltaY As Integer = (pointPanStart.Y - e.Y)
            'Set the new autoscroll position.
            'ALWAYS pass positive integers to the panels autoScrollPosition method
            Panel1.AutoScrollPosition = _
                    New Drawing.Point((DeltaX - Panel1.AutoScrollPosition.X), _
                                      (DeltaY - Panel1.AutoScrollPosition.Y))
        End If
    End Sub

    Private Sub ctrlThongTinSoDoNhaDat_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Panel1.AutoScroll = True
        Me.picSoDoNhaDat.SizeMode = Windows.Forms.PictureBoxSizeMode.StretchImage
        ''Xóa sạch hình ảnh trên Picture Sơ đồ Nhà, đất
        'Me.picSoDoNhaDat.Image.Dispose()
        ' picSoDoNhaDat.Stretch = True
        Ori_pos.Top = picSoDoNhaDat.Top
        Ori_pos.Left = picSoDoNhaDat.Left
        Ori_pos.Height = picSoDoNhaDat.Height
        Ori_pos.Width = picSoDoNhaDat.Width
    End Sub

    Private Sub btnGhi_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGhi.Click
        'Cập nhật thông tin hình ảnh sơ đồ Nhà, đất vào cơ sở dữ liệu
        Me.UpdateSoDoNhaDatThamDinh()
    End Sub

    Private Sub btnXoa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXoa.Click
        'Xóa thông tin sơ đồ nhà đất
        If (System.Windows.Forms.MessageBox.Show("Bạn chắc chắn muốn xóa?", "DMCLand", Windows.Forms.MessageBoxButtons.YesNo, Windows.Forms.MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes) Then
            Dim SoDoNhaDat As New clsThongTinSoDoNhaDat
            SoDoNhaDat.Connection = strConnection
            SoDoNhaDat.MaHoSoCapGCN = strMaHoSoCapGCN
            SoDoNhaDat.DeleteSoDoNhaDatThamDinhByMaHoSoCapGCN()
            System.Windows.Forms.MessageBox.Show("Xóa thành công!", "DMCLand", Windows.Forms.MessageBoxButtons.OK)
            picSoDoNhaDat.Image = Nothing
        End If
    End Sub
 

    Private Sub HScroll1_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles HScroll1.Scroll
        'Label1.Text = Trim(Str(HScroll1.Value)) & "%"

        'Tmp_Pos.Top = Ori_pos.Top - (((Ori_pos.Height * HScroll1.Value / 100) - Ori_pos.Height) / 2)
        'Tmp_Pos.Left = Ori_pos.Left - (((Ori_pos.Width * HScroll1.Value / 100) - Ori_pos.Width) / 2)
        'Tmp_Pos.Height = (Ori_pos.Height * HScroll1.Value / 100)
        'Tmp_Pos.Width = (Ori_pos.Width * HScroll1.Value / 100)

        'picSoDoNhaDat.Visible = False
        'picSoDoNhaDat.Top = Tmp_Pos.Top
        'picSoDoNhaDat.Left = Tmp_Pos.Left
        'picSoDoNhaDat.Height = Tmp_Pos.Height
        'picSoDoNhaDat.Width = Tmp_Pos.Width
        'picSoDoNhaDat.Visible = True
    End Sub

     
End Class
