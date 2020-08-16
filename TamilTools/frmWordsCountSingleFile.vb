Imports System.Text.RegularExpressions
Imports System.Text
Imports System.IO
Imports System.Globalization

Public Class frmWordsCountSingleFile

    Dim builder As New StringBuilder
    Dim builder2 As New StringBuilder
    Dim builder2_ As New StringBuilder
    Dim clbFlag As Boolean = False
    Dim clbFlag_ As Boolean = False
    Dim cnt As Integer = 0

    Dim dtFill_Con As New DataTable
    Dim builder_Con As New StringBuilder
    Public curWord As String = ""
    Dim mdtbColourMap As DataTable = Nothing
    Dim FILE_NAME As String = "" 'd
    Dim TextLine As String = ""

    Private Sub btnUpload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpload.Click
        ' Displays an OpenFileDialog so the user can select a Cursor.
        Dim openFileDialog1 As New OpenFileDialog()
        openFileDialog1.Filter = "Text Files|*.txt"
        openFileDialog1.Title = "Select a Text File"

        If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            ' Assign the cursor in the Stream to the Form's Cursor property.

            'Dim extension = openFileDialog1.FileName.Substring(openFileDialog1.FileName)
            Dim extension = openFileDialog1.FileName.Substring(openFileDialog1.FileName.LastIndexOf("."))
            'If extension Is ".txt" Then
            Me.Cursor = Cursors.WaitCursor
            Me.rtbContent.Text = FileIO.FileSystem.ReadAllText(openFileDialog1.FileName)
            FILE_NAME = openFileDialog1.FileName
            Me.Cursor = Cursors.Default
            'End If
        End If
    End Sub

    Private Sub btnCount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCount.Click
        If Len(Trim(rtbContent.Text)) > 0 Then

            'Call btnClear_Click(sender, e)
            cnt = 0

            rtbOutput.Text = ""
            builder.Length = 0

            Me.Cursor = Cursors.WaitCursor
            ' We want to split this input string.

            'Dim s As String = rtbContent.Text

            ' Split string based on spaces.
            Dim words As String()
            Dim dictionary As New Dictionary(Of String, Integer)()
            If System.IO.File.Exists(FILE_NAME) = True Then
                Dim objReader As New System.IO.StreamReader(FILE_NAME)
                Do While objReader.Peek() <> -1

                    TextLine = Trim(objReader.ReadLine())
                    If Len(Trim(txtDelimeter.Text)) > 0 Then
                        words = TextLine.Split(New Char() {txtDelimeter.Text})
                    Else
                        words = TextLine.Split(New Char() {" "c})
                    End If
                    cnt = 0
                    cnt = words.Length

                    For Each word In words
                        If dictionary.ContainsKey(word) Then
                            dictionary(word) += 1
                        Else
                            dictionary(word) = 1
                        End If
                    Next
                Loop
                objReader.Close()
            End If

            If chkSort.Checked = True Then
                Dim dict2 = From key As KeyValuePair(Of String, Integer) In dictionary Order By key.ToString Ascending
                'Dim dict2 = From key As KeyValuePair(Of String, Integer) In dictionary Order By key.Value
                ' Loop over entries.
                Dim pair As KeyValuePair(Of String, Integer)
                'Dim builder As New StringBuilder
                For Each pair In dict2
                    ' Display Key and Value.
                    builder.Append(pair.Key)
                    builder.Append("(" & pair.Value & ")").AppendLine()
                Next

                Me.rtbOutput.Text = builder.ToString

                'lblWordCount.Text = ""
                'lblWordCount.Text = cnt

                Me.Cursor = Cursors.Default
                MessageBox.Show("முடிவுற்றது...!", "சொல் எண்ணிக்கை", MessageBoxButtons.OK)
            Else
                Dim dict2 = From key As KeyValuePair(Of String, Integer) In dictionary Order By key.Value Descending
                ' Loop over entries.
                Dim pair As KeyValuePair(Of String, Integer)
                'Dim builder As New StringBuilder
                For Each pair In dict2
                    ' Display Key and Value.
                    builder.Append(pair.Key)
                    builder.Append("(" & pair.Value & ")").AppendLine()
                Next

                'Me.rtbOutput.Text = FileIO.FileSystem.ReadAllText(builder.ToString)

                Me.rtbOutput.Text = builder.ToString

                'lblWordCount.Text = ""
                'lblWordCount.Text = cnt

                Me.Cursor = Cursors.Default
                MessageBox.Show("முடிவுற்றது...!", "சொல் எண்ணிக்கை", MessageBoxButtons.OK)
            End If
        Else
            MessageBox.Show("தயவு கூர்ந்து கோப்பினை இணைக்கவும்...!", "சொல் எண்ணிக்கை", MessageBoxButtons.OK, MessageBoxIcon.Error)
            btnUpload.Focus()
            Exit Sub
        End If

        ''Dim dict2 = From key As KeyValuePair(Of String, Integer) In dictionary Order By key.Value Descending
        'Dim dict2 = From key As KeyValuePair(Of String, Integer) In dictionary Order By key.ToString Ascending

        '' Loop over entries.
        'Dim pair As KeyValuePair(Of String, Integer)
        ''Dim builder As New StringBuilder
        'For Each pair In dict2
        '    ' Display Key and Value.
        '    builder.Append(pair.Key)
        '    builder.Append("(" & pair.Value & ")").AppendLine()
        'Next
        'Me.Cursor = Cursors.Default
        'messagebox.show("Completed...!")
    End Sub

    Private Sub SaveToFile(ByVal fileName As String)
        Dim w As System.IO.TextWriter = New System.IO.StreamWriter(fileName)
        w.Write(builder.ToString())
        w.Flush()
        w.Close()
        builder.Length = 0
    End Sub

    Public Function CountWords(ByVal value As String) As Integer
        ' Count matches.
        Dim collection As MatchCollection = Regex.Matches(value, "\S+")
        Return collection.Count
    End Function

    Private Sub btnTxt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTxt.Click
        If Len(Trim(rtbOutput.Text)) > 0 Then
            Using dlg As New SaveFileDialog()
                dlg.Filter = "TXT Files (*.txt*)|*.txt"
                If dlg.ShowDialog() = DialogResult.OK Then
                    Dim fileName As String = dlg.FileName
                    Me.Cursor = Cursors.WaitCursor
                    SaveToFile(fileName)
                    MessageBox.Show("கோப்பு பதிவிறக்கம் முடிவுற்றது...!", "சொல் எண்ணிக்கை")
                    Me.Cursor = Cursors.Default
                End If
            End Using
        Else
            MessageBox.Show("பதிவிறக்கம் செய்ய தரவுகள் இல்லை...!", "சொல் எண்ணிக்கை", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        txtDelimeter.Text = ""
        builder.Length = 0
        rtbContent.Text = ""
        rtbOutput.Text = ""
    End Sub

    Private Sub frmWordsCountSingleFile_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'lblWordCount.Text = ""

        'Dim x = "line1" & vbCrLf & _
        '"line2"
        'MsgBox(x)


        ''You can change the title bar text color to 
        ''anytihng you want by changing the "VbBlack to Whatever you want"
        'Dim s As Object
        's = SetSysColors(1, COLOR_CAPTIONTEXT, vbBlack)

        'Dim lngReturn As Long
        'lngReturn = SetSysColors(1, COLOR_CAPTIONTEXT, RGB(255, 225, 100))

        ''set active forms title bar to red
        'Dim lngReturn_ As Long
        'lngReturn_ = SetSysColors(1, COLOR_ACTIVECAPTION, RGB(255, 0, 0))




        MaximizeBox = False

        txtDelimeter.MaxLength = 1
        txtDelimeter.TextAlign = HorizontalAlignment.Center


        Dim ToolTip1 As New System.Windows.Forms.ToolTip()
        ToolTip1.SetToolTip(Me.btnUpload, "Upload File")

        Dim ToolTip2 As New System.Windows.Forms.ToolTip()
        ToolTip2.SetToolTip(Me.lblDelimiter, "Delimiter")

        Dim ToolTip3 As New System.Windows.Forms.ToolTip()
        ToolTip3.SetToolTip(Me.txtDelimeter, "Delimiter")

        Dim ToolTip4 As New System.Windows.Forms.ToolTip()
        ToolTip4.SetToolTip(Me.chkSort, "Sort")

        Dim ToolTip5 As New System.Windows.Forms.ToolTip()
        ToolTip5.SetToolTip(Me.btnCount, "Count")

        Dim ToolTip6 As New System.Windows.Forms.ToolTip()
        ToolTip6.SetToolTip(Me.btnClear, "Clear")

        Dim ToolTip7 As New System.Windows.Forms.ToolTip()
        ToolTip7.SetToolTip(Me.btnTxt, "Export as .txt")

    End Sub
End Class
