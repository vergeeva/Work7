Public Class Form1
    Private Sub Button1_MouseDown(sender As Object, e As MouseEventArgs) Handles Button1.MouseDown
        Me.Button1.DoDragDrop(Me.Button1, DragDropEffects.Move)
        Cursor.Current = Cursors.Hand

    End Sub

    Private Sub TabPage1_DragOver(sender As Object, e As DragEventArgs) Handles TabPage1.DragOver
        Me.Button1.Location = Me.PointToClient(New Point(e.X, e.Y))
        Cursor.Current = Cursors.Hand
    End Sub

    Private Sub TextBox1_MouseDown(sender As Object, e As MouseEventArgs) Handles TextBox1.MouseDown
        Me.TextBox1.DoDragDrop(Me.TextBox1.Text, DragDropEffects.Copy)
    End Sub

    Private Sub TextBox2_DragEnter(sender As Object, e As DragEventArgs) Handles TextBox2.DragEnter
        e.Effect = DragDropEffects.Copy
    End Sub

    Private Sub TextBox2_DragDrop(sender As Object, e As DragEventArgs) Handles TextBox2.DragDrop
        TextBox2.AppendText(e.Data.GetData(DataFormats.Text).ToString)
    End Sub

    Private Sub Form1_DragEnter(sender As Object, e As DragEventArgs) Handles MyBase.DragEnter

    End Sub

    Private Sub TextBox3_DragEnter(sender As Object, e As DragEventArgs) Handles TextBox3.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then e.Effect = DragDropEffects.Copy
    End Sub

    Private Sub TextBox3_DragDrop(sender As Object, e As DragEventArgs) Handles TextBox3.DragDrop
        Dim mas() As String = e.Data.GetData(DataFormats.FileDrop, True)
        Dim j As Integer
        Dim fd As Integer
        Dim str As String = ""
        For j = 0 To UBound(mas)
            fd = FreeFile()
            FileOpen(fd, mas(j), OpenMode.Input, OpenAccess.Read, OpenShare.LockReadWrite)
            While Not EOF(fd)
                str = str & LineInput(fd) & vbCrLf
            End While
            FileClose(fd)
            str &= vbCrLf
        Next
        Me.TextBox3.Text = str
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RichTextBox1.AllowDrop = True
    End Sub

    Private Sub TabPage4_DragEnter(sender As Object, e As DragEventArgs) Handles TabPage4.DragEnter
        If e.Data.GetDataPresent(DataFormats.Rtf) Then e.Effect = DragDropEffects.Copy
    End Sub

    Private Sub TabPage4_DragDrop(sender As Object, e As DragEventArgs) Handles TabPage4.DragDrop
        Me.RichTextBox1.Text = Me.RichTextBox1.Text & vbCrLf & e.Data.GetData(DataFormats.Text).ToString
    End Sub

    Private Sub RichTextBox1_MouseDown(sender As Object, e As MouseEventArgs) Handles RichTextBox1.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Me.RichTextBox1.DoDragDrop(Me.RichTextBox1.SelectedText, DragDropEffects.Copy)
        End If
    End Sub
End Class
