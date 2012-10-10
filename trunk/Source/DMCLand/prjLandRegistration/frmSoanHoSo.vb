Public Class frmSoanHoSo
    Private Sub frmSoanHoSo_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing


        If Me.CtrSoanHS1.ChangeNewFeature Then
            e.Cancel = False
            Me.CtrSoanHS1.FormClosing()
        Else
            Dim dlg As DialogResult = MessageBox.Show("Bạn có muốn lưu lại những thay đổi của hồ sơ kỹ thuật không?", "Warning", MessageBoxButtons.YesNo)
            If dlg = DialogResult.Yes Then
                e.Cancel = False
                Me.CtrSoanHS1.SaveData()
                Me.CtrSoanHS1.FormClosing()
            Else
                e.Cancel = False
                Me.CtrSoanHS1.FormClosing()
            End If
        End If
        
    End Sub


End Class