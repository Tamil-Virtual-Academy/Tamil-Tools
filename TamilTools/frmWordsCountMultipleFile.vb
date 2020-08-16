Imports System.Text.RegularExpressions
Imports System.Text
Imports System.IO
Imports System.Globalization

Public Class frmWordsCountMultipleFile

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

    Private Sub btnUpload_2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpload_2.Click
        Dim Path As String = ""
        Dim folderDlg As New FolderBrowserDialog
        folderDlg.ShowNewFolderButton = True

        If (folderDlg.ShowDialog() = DialogResult.OK) Then
            Path = folderDlg.SelectedPath
            Dim root As Environment.SpecialFolder = folderDlg.RootFolder

            Dim di As New IO.DirectoryInfo(Path)
            Dim diar1 As IO.FileInfo() = di.GetFiles("*.txt")
            'list the names of all files in the specified directory
            Dim dInfo As New IO.DirectoryInfo(Path)
            Dim dGetFI As IO.FileInfo() = dInfo.GetFiles("*.txt")
            Dim dFI As IO.FileInfo

            For Each dFI In dGetFI
                If clbFlag = False Then
                    clbFlag = True
                    clbFileName.Items.Add("Select/UnSelect All", CheckState.Checked)
                End If
                If Not dFI.FullName.Contains("$") OrElse Not dFI.FullName.Contains("~") Then
                    clbFileName.Items.Add(dFI.FullName, CheckState.Checked)
                End If
            Next
        Else
            clbFileName.Items.Clear()
            rtbContent_2.Text = ""
            rtbOutput_2.Text = ""
        End If
    End Sub

    Private Sub clbFileName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles clbFileName.SelectedIndexChanged
        If clbFileName.SelectedIndex = 0 Then
            If clbFileName.GetItemChecked(0) = False Then
                For idx As Integer = 1 To clbFileName.Items.Count - 1

                    Me.clbFileName.SetItemChecked(idx, False)
                Next
            Else
                For idx As Integer = 1 To clbFileName.Items.Count - 1

                    Me.clbFileName.SetItemChecked(idx, True)
                Next
            End If
        ElseIf clbFileName.SelectedIndex > 0 Then
            If clbFileName.CheckedItems.Count = clbFileName.Items.Count - 1 And clbFileName.GetItemChecked(0) = False Then
                clbFileName.SetItemCheckState(0, CheckState.Checked)
            End If
            For idx As Integer = 1 To clbFileName.Items.Count - 1

                If clbFileName.GetItemChecked(idx) = False Then
                    clbFileName.SetItemCheckState(0, CheckState.Unchecked)

                End If
            Next
        End If
    End Sub

    Private Sub btnCount_2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCount_2.Click

        If cmbTypes.Text = "சொல் அளவீடு" Then
            TotalCount()
        ElseIf cmbTypes.Text = "எழுத்தளவீடு" Then
            ToalCountCharacters()
        ElseIf cmbTypes.Text = "முதலெழுத்து அளவீடு" Then
            TotalCountFirstCharacter()
        End If
    End Sub

    Private Sub btnClear_2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear_2.Click
        txtDelimeter_2.Text = ""
        builder2.Length = 0
        builder2_.Length = 0
        rtbContent_2.Text = ""
        rtbOutput_2.Text = ""
        clbFileName.Items.Clear()
        clbFlag = False
        clbFlag_ = False
    End Sub

    Private Sub SaveToFile_2(ByVal fileName As String)
        Dim w As System.IO.TextWriter = New System.IO.StreamWriter(fileName)
        w.Write(builder2_.ToString())
        w.Flush()
        w.Close()
        builder2_.Length = 0
    End Sub

    Private Sub btnTxt_2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTxt_2.Click
        If Len(Trim(rtbOutput_2.Text)) > 0 Then
            Using dlg As New SaveFileDialog()
                dlg.Filter = "TXT Files (*.txt*)|*.txt"
                If dlg.ShowDialog() = DialogResult.OK Then
                    Dim fileName As String = dlg.FileName
                    Me.Cursor = Cursors.WaitCursor
                    SaveToFile_2(fileName)
                    MessageBox.Show("கோப்பு பதிவிறக்கம் முடிவுற்றது...!", "சொல் எண்ணிக்கை")
                    Me.Cursor = Cursors.Default
                End If
            End Using
        Else
            MessageBox.Show("பதிவிறக்கம் செய்ய தரவுகள் இல்லை...!", "சொல் எண்ணிக்கை", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
    End Sub

    Private Sub frmWordsCountMultipleFile_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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


        Fill_TypesCombo()

        MaximizeBox = False


        txtDelimeter_2.MaxLength = 1
        txtDelimeter_2.TextAlign = HorizontalAlignment.Center


        Dim ToolTip8 As New System.Windows.Forms.ToolTip()
        ToolTip8.SetToolTip(Me.btnUpload_2, "Upload File")

        Dim ToolTip9 As New System.Windows.Forms.ToolTip()
        ToolTip9.SetToolTip(Me.lblDelimiter_2, "Delimiter")

        Dim ToolTip10 As New System.Windows.Forms.ToolTip()
        ToolTip10.SetToolTip(Me.txtDelimeter_2, "Delimiter")

        Dim ToolTip11 As New System.Windows.Forms.ToolTip()
        ToolTip11.SetToolTip(Me.chkSort_2, "Sort")

        Dim ToolTip12 As New System.Windows.Forms.ToolTip()
        ToolTip12.SetToolTip(Me.btnCount_2, "Count")

        Dim ToolTip13 As New System.Windows.Forms.ToolTip()
        ToolTip13.SetToolTip(Me.btnClear_2, "Clear")

        Dim ToolTip14 As New System.Windows.Forms.ToolTip()
        ToolTip14.SetToolTip(Me.btnTxt_2, "Export as .txt")

        Dim ToolTip15 As New System.Windows.Forms.ToolTip()
        ToolTip14.SetToolTip(Me.cmbTypes, "Select the type")

        'rtbContent_Con.SelectionStart = 0
        'rtbContent_Con.SelectionCharOffset = 200
    End Sub

    Private Sub Fill_TypesCombo()
        'cmbTypes.Items.Add("எண்ணு")
        'cmbTypes.Items.Add("எண்ணு எழுத்துகள்")
        'cmbTypes.Items.Add("எண்ணு முதல் எழுத்துகள்")

        cmbTypes.Items.Add("சொல் அளவீடு")
        cmbTypes.Items.Add("எழுத்தளவீடு")
        cmbTypes.Items.Add("முதலெழுத்து அளவீடு")
        cmbTypes.SelectedIndex = 0
    End Sub

    Private Sub TotalCount()
        'If Len(Trim(rtbContent_2.Text)) > 0 Then
        cnt = 0

        builder2.Length = 0
        builder2_.Length = 0

        rtbContent_2.Text = String.Empty
        rtbOutput_2.Text = String.Empty

        Me.Cursor = Cursors.WaitCursor

        For l As Integer = 0 To clbFileName.Items.Count - 1
            If clbFileName.GetItemChecked(l) = True Then
                If Not clbFileName.Items(l).ToString = "Select/UnSelect All" Then
                    If System.IO.File.Exists(clbFileName.Items(l).ToString) = True Then
                        ' Open file and store in String.

                        Dim value As String = ""
                        ''value = File.ReadAllText(clbFileName.Items(l).ToString)
                        Dim M_FILE_NAME As String = clbFileName.Items(l)
                        If System.IO.File.Exists(M_FILE_NAME) = True Then


                            Dim objReader As New System.IO.StreamReader(M_FILE_NAME)
                            Do While objReader.Peek() <> -1
                                value = ""
                                value = Trim(objReader.ReadLine())
                                builder2.Append(value).AppendLine()
                            Loop
                            objReader.Close()

                        End If
                    End If
                End If
            End If
        Next

        If builder2.Length > 0 Then
            Me.rtbContent_2.Text = builder2.ToString
            Dim s As String = rtbContent_2.Text

            ' Split string based on spaces.
            Dim words As String()
            If Len(Trim(txtDelimeter_2.Text)) > 0 Then
                words = s.Split(New Char() {txtDelimeter_2.Text})
            Else
                words = s.Split(New Char() {" "c})
            End If

            Dim dictionary As New Dictionary(Of String, Integer)()

            For Each word In words
                If dictionary.ContainsKey(Trim(word)) Then
                    dictionary(word) += 1
                    cnt = cnt + 1
                Else
                    dictionary(word) = 1
                    cnt = cnt + 1
                End If
            Next

            If chkSort_2.Checked = True Then
                Dim dict2 = From key As KeyValuePair(Of String, Integer) In dictionary Order By key.ToString Ascending
                ' Loop over entries.
                Dim pair As KeyValuePair(Of String, Integer)
                'Dim builder As New StringBuilder
                For Each pair In dict2
                    ' Display Key and Value.
                    builder2_.Append(Trim(pair.Key))

                    Dim Total As Decimal
                    Dim num As Decimal
                    Dim output As String = ""
                    If Decimal.TryParse(cnt, num) Then
                        Total = num / 100 * pair.Value
                        output = Total.ToString("#0.00")
                    End If

                    'builder2_.Append("(" & Trim(pair.Value) & ")").AppendLine()

                    'builder2_.Append("(" & Trim(pair.Value) & ")" & " " & "[ " & Total & " %" & " ]").AppendLine().AppendLine()
                    builder2_.Append("(" & Trim(pair.Value) & ")" & " " & "[ " & output & " %" & " ]").AppendLine().AppendLine()

                Next

                Me.rtbOutput_2.Text = builder2_.ToString

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
                    builder2_.Append(Trim(pair.Key))


                    Dim Total As Decimal
                    Dim num As Decimal
                    Dim output As String = ""
                    If Decimal.TryParse(cnt, num) Then
                        Total = num / 100 * pair.Value
                        output = Total.ToString("#0.00")
                    End If

                    'builder2_.Append("(" & Trim(pair.Value) & ")").AppendLine()

                    'builder2_.Append("(" & Trim(pair.Value) & ")" & " " & "[ " & Total & " %" & " ]").AppendLine().AppendLine()
                    builder2_.Append("(" & Trim(pair.Value) & ")" & " " & "[ " & output & " %" & " ]").AppendLine().AppendLine()



                Next

                Me.rtbOutput_2.Text = builder2_.ToString

                'lblWordCount.Text = ""
                'lblWordCount.Text = cnt

                Me.Cursor = Cursors.Default
                MessageBox.Show("முடிவுற்றது...!", "சொல் எண்ணிக்கை", MessageBoxButtons.OK)
            End If
        Else
            MessageBox.Show("தயவு கூர்ந்து கோப்பினை இணைக்கவும்...!", "சொல் எண்ணிக்கை", MessageBoxButtons.OK, MessageBoxIcon.Error)
            btnUpload_2.Focus()
            Me.Cursor = Cursors.Default
            Exit Sub
        End If
        'Else
        '    MessageBox.Show("தயவு கூர்ந்து கோப்பினை இணைக்கவும்...!", "சொல் எண்ணிக்கை", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    btnUpload_2.Focus()
        '    Me.Cursor = Cursors.Default
        '    Exit Sub
        'End If
    End Sub

    Private Sub ToalCountCharacters()

        cnt = 0

        builder2.Length = 0
        builder2_.Length = 0

        rtbContent_2.Text = String.Empty
        rtbOutput_2.Text = String.Empty

        Me.Cursor = Cursors.WaitCursor

        For l As Integer = 0 To clbFileName.Items.Count - 1
            If clbFileName.GetItemChecked(l) = True Then
                If Not clbFileName.Items(l).ToString = "Select/UnSelect All" Then
                    If System.IO.File.Exists(clbFileName.Items(l).ToString) = True Then
                        ' Open file and store in String.
                        Dim value As String = ""
                        value = File.ReadAllText(clbFileName.Items(l).ToString)
                        builder2.Append(value).AppendLine()
                    End If
                End If
            End If
        Next

        If builder2.Length > 0 Then
            Me.rtbContent_2.Text = builder2.ToString
            Dim s As String = rtbContent_2.Text

            '' This below code is used to count the no of words 
            '' Split string based on spaces.
            Dim words As String()
            If Len(Trim(txtDelimeter_2.Text)) > 0 Then
                words = s.Split(New Char() {txtDelimeter_2.Text})
            Else
                words = s.Split(New Char() {" "c})
            End If

            cnt = 0
            cnt = words.Length


            Dim myString As String = s
            ' Creates and initializes a TextElementEnumerator for myString.
            Dim myTEE As TextElementEnumerator = StringInfo.GetTextElementEnumerator(myString)

            myTEE.Reset()
            Dim bu As New StringBuilder

            While myTEE.MoveNext()
                'Console.WriteLine("[{0}]:" + ControlChars.Tab + "{1}" + ControlChars.Tab + "{2}", myTEE.ElementIndex, myTEE.Current, myTEE.GetTextElement())
                bu.Append(myTEE.Current).AppendLine()
            End While

            Dim dictionary As New Dictionary(Of String, Integer)()

            Dim lines() As String = Split(bu.ToString, vbCrLf)
            For Each line As String In lines
                'Debug.Print(line)
                If dictionary.ContainsKey(Trim(line)) Then
                    dictionary(line) += 1
                Else
                    dictionary(line) = 1
                End If
            Next

            If chkSort_2.Checked = True Then
                Dim dict2 = From key As KeyValuePair(Of String, Integer) In dictionary Order By key.ToString Ascending
                ' Loop over entries.
                Dim pair As KeyValuePair(Of String, Integer)
                'Dim builder As New StringBuilder
                For Each pair In dict2
                    ' Display Key and Value.
                    builder2_.Append(Trim(pair.Key))
                    builder2_.Append("(" & Trim(pair.Value) & ")").AppendLine()
                Next

                Me.rtbOutput_2.Text = builder2_.ToString

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
                    builder2_.Append(Trim(pair.Key))
                    builder2_.Append("(" & Trim(pair.Value) & ")").AppendLine()
                Next

                Me.rtbOutput_2.Text = builder2_.ToString

                'lblWordCount.Text = ""
                'lblWordCount.Text = cnt

                Me.Cursor = Cursors.Default
                MessageBox.Show("முடிவுற்றது...!", "சொல் எண்ணிக்கை", MessageBoxButtons.OK)
            End If
        Else
            MessageBox.Show("தயவு கூர்ந்து கோப்பினை இணைக்கவும்...!", "சொல் எண்ணிக்கை", MessageBoxButtons.OK, MessageBoxIcon.Error)
            btnUpload_2.Focus()
            Me.Cursor = Cursors.Default
            Exit Sub
        End If
    End Sub

    Private Sub TotalCountFirstCharacter()

        cnt = 0

        builder2.Length = 0
        builder2_.Length = 0

        rtbContent_2.Text = String.Empty
        rtbOutput_2.Text = String.Empty

        Me.Cursor = Cursors.WaitCursor

        For l As Integer = 0 To clbFileName.Items.Count - 1
            If clbFileName.GetItemChecked(l) = True Then
                If Not clbFileName.Items(l).ToString = "Select/UnSelect All" Then
                    If System.IO.File.Exists(clbFileName.Items(l).ToString) = True Then
                        ' Open file and store in String.
                        Dim value As String = ""
                        value = File.ReadAllText(clbFileName.Items(l).ToString)
                        builder2.Append(value).AppendLine()
                    End If
                End If
            End If
        Next


        If builder2.Length > 0 Then
            Me.rtbContent_2.Text = builder2.ToString
            Dim s As String = rtbContent_2.Text

            ' Split string based on spaces.
            Dim words As String()
            If Len(Trim(txtDelimeter_2.Text)) > 0 Then
                words = s.Split(New Char() {txtDelimeter_2.Text})
            Else
                words = s.Split(New Char() {" "c})
            End If

            cnt = 0
            cnt = words.Length

            Dim bu As New StringBuilder
            For Each word In words

                Dim myString As String = word
                ' Creates and initializes a TextElementEnumerator for myString.
                Dim myTEE As TextElementEnumerator = StringInfo.GetTextElementEnumerator(myString)

                myTEE.Reset()


                While myTEE.MoveNext()
                    'Console.WriteLine("[{0}]:" + ControlChars.Tab + "{1}" + ControlChars.Tab + "{2}", myTEE.ElementIndex, myTEE.Current, myTEE.GetTextElement())
                    bu.Append(myTEE.Current).AppendLine()
                    Exit While
                End While

            Next

            Dim dictionary As New Dictionary(Of String, Integer)()

            Dim lines() As String = Split(bu.ToString, vbCrLf)
            For Each line As String In lines
                'Debug.Print(line)
                If dictionary.ContainsKey(Trim(line)) Then
                    dictionary(line) += 1
                Else
                    dictionary(line) = 1
                End If
            Next

            If chkSort_2.Checked = True Then
                Dim dict2 = From key As KeyValuePair(Of String, Integer) In dictionary Order By key.ToString Ascending
                ' Loop over entries.
                Dim pair As KeyValuePair(Of String, Integer)
                'Dim builder As New StringBuilder
                For Each pair In dict2
                    ' Display Key and Value.
                    builder2_.Append(Trim(pair.Key))
                    builder2_.Append("(" & Trim(pair.Value) & ")").AppendLine()
                Next

                Me.rtbOutput_2.Text = builder2_.ToString

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
                    builder2_.Append(Trim(pair.Key))
                    builder2_.Append("(" & Trim(pair.Value) & ")").AppendLine()
                Next

                Me.rtbOutput_2.Text = builder2_.ToString

                'lblWordCount.Text = ""
                'lblWordCount.Text = cnt

                Me.Cursor = Cursors.Default
                MessageBox.Show("முடிவுற்றது...!", "சொல் எண்ணிக்கை", MessageBoxButtons.OK)
            End If


        Else
            MessageBox.Show("தயவு கூர்ந்து கோப்பினை இணைக்கவும்...!", "சொல் எண்ணிக்கை", MessageBoxButtons.OK, MessageBoxIcon.Error)
            btnUpload_2.Focus()
            Me.Cursor = Cursors.Default
            Exit Sub
        End If

    End Sub
End Class