Public Class frmKhoiTaoDuLieuBanDoPhuong

    Private Sub UcListDVHC1_AfterCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles UcListDVHC1.AfterCheck
        If UcListDVHC1.Get_CurrDVHC = 0 Then
            Return
        End If
        If UcListDVHC1.Get_CurrDVHC <> 0 Then
            Dim cmd As New SqlClient.SqlCommand("select * from tbltudiendonvihanhchinh where madonvihanhchinh='" & UcListDVHC1.Get_CurrDVHC.ToString & "'", User.SQLConnection)
            If User.SQLConnection.State <> ConnectionState.Open Then
                User.SQLConnection.Open()
            End If
            cmd.ExecuteNonQuery()
            Dim da As New SqlClient.SqlDataAdapter(cmd)
            Dim dt As New DataTable
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                txttenPhuong.Text = dt.Rows(0).Item("ten").ToString
                txtTenTat.Text = chuyensangkhongdau(dt.Rows(0).Item("ten").ToString.Replace(" ", ""))
                txtDonViHanhChinh.Text = UcListDVHC1.Get_CurrDVHC.ToString
            End If

        Else
            MessageBox.Show("  Chưa chọn đơn vị hành chính! ")
        End If
    End Sub

    Private Sub cmdKhoiTao_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdKhoiTao.Click
        If KtraTonTaiDVHCKhoiTao() Then
            Dim cls As New clsHoSoCapGCN
            cls.Connection = GetConnection(bolKetNoiCSDL)
            'insert record khoi tao
            cls.insDVHCKhoiTao(txttenPhuong.Text.Trim, "P" & txtDonViHanhChinh.Text.Trim, txtDonViHanhChinh.Text.Trim)
            'tao bang map
            cls.KhoiTaoBangMapByDonViHanhChinh("P" & txtDonViHanhChinh.Text.Trim, txtDonViHanhChinh.Text.Trim)
        End If
    End Sub

    Public Function KtraTonTaiDVHCKhoiTao() As Boolean
        Dim kt As Boolean = True
        Dim cls As New clsHoSoCapGCN
        cls.Connection = GetConnection(bolKetNoiCSDL)
        Dim dt As New DataTable
        cls.selKTTonPhuongKhoiTao(dt, txtDonViHanhChinh.Text.Trim)
        If dt.Rows.Count > 0 Then
            kt = False
            MessageBox.Show("Phường " & txttenPhuong.Text.Trim.ToUpper & " đã tồn tại !!!", "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Return kt
    End Function
End Class