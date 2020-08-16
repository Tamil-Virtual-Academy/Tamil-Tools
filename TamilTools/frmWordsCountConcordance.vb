Imports System.Text.RegularExpressions
Imports System.Text
Imports System.IO
Imports System.Globalization

Public Class frmWordsCountConcordance

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
    Dim chkFlag As Boolean = False


    Private Sub frmWordsCountConcordance_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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


        ''Tab 3 Code
        Dim f As New System.Drawing.Font("Latha", 9)
        dgvCon.Font = f
        dtFill_Con = New DataTable
        dtFill_Con.Columns.Add("Result", GetType(String))
        dgvCon.DataSource = dtFill_Con


        'Define the search terms and color for each
        mdtbColourMap = New DataTable
        mdtbColourMap.Columns.Add(New DataColumn("SearchTerm", GetType(String)))
        mdtbColourMap.Columns.Add(New DataColumn("TextColor", GetType(Brush)))
        mdtbColourMap.Rows.Add(txtCon.Text, Drawing.Brushes.Red)
        'mdtbColourMap.Rows.Add("+", Drawing.Brushes.Red)
        'mdtbColourMap.Rows.Add("-", Drawing.Brushes.Purple)

        Grid_Apperance_Con()

        cmbGram_Con.Items.Add("1")
        cmbGram_Con.Items.Add("2")
        cmbGram_Con.Items.Add("3")
        cmbGram_Con.Items.Add("4")
        'cmbGram_Con.SelectedIndex = 0

        'rtbContent_Con.SelectionStart = 0
        'rtbContent_Con.SelectionCharOffset = 200

        Dim ToolTip1 As New System.Windows.Forms.ToolTip()
        ToolTip1.SetToolTip(Me.btnUpload_Con, "Upload File")

        Dim ToolTip2 As New System.Windows.Forms.ToolTip()
        ToolTip2.SetToolTip(Me.Label3, "Delimiter")

        Dim ToolTip3 As New System.Windows.Forms.ToolTip()
        ToolTip3.SetToolTip(Me.txtDelimiter_Con, "Delimiter")

        Dim ToolTip4 As New System.Windows.Forms.ToolTip()
        ToolTip4.SetToolTip(Me.btnFill_Con, "Fill")

        Dim ToolTip5 As New System.Windows.Forms.ToolTip()
        ToolTip5.SetToolTip(Me.cmbGram_Con, "Selection")

        Dim ToolTip6 As New System.Windows.Forms.ToolTip()
        ToolTip6.SetToolTip(Me.txtCon, "Search Word")

        Dim ToolTip7 As New System.Windows.Forms.ToolTip()
        ToolTip7.SetToolTip(Me.btnSearch_Con, "Search")

        Dim ToolTip8 As New System.Windows.Forms.ToolTip()
        ToolTip8.SetToolTip(Me.btnClear_Con, "Clear")

    End Sub

    Private Sub btnUpload_Con_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpload_Con.Click
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
                If clbFlag_ = False Then
                    clbFlag_ = True
                    clbFileName_Con.Items.Add("Select/UnSelect All", CheckState.Checked)
                End If
                If Not dFI.FullName.Contains("$") OrElse Not dFI.FullName.Contains("~") Then
                    clbFileName_Con.Items.Add(dFI.FullName, CheckState.Checked)
                End If
            Next
        Else
            clbFileName_Con.Items.Clear()
        End If
    End Sub

    Private Sub clbFileName_Con_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles clbFileName_Con.ItemCheck
        'If e.Index = 0 Then
        '    Dim newCheckedState As CheckState = e.NewValue
        '    For idx As Integer = 1 To clbFileName_Con.Items.Count - 1
        '        Me.clbFileName_Con.SetItemCheckState(idx, newCheckedState)
        '    Next
        'End If

    End Sub

    Private Sub Fill_Data_For_Concordance()
        Me.Cursor = Cursors.WaitCursor

        For l As Integer = 0 To clbFileName_Con.Items.Count - 1
            If clbFileName_Con.GetItemChecked(l) = True Then
                If Not clbFileName_Con.Items(l).ToString = "Select/UnSelect All" Then
                    If System.IO.File.Exists(clbFileName_Con.Items(l).ToString) = True Then
                        ' Open file and store in String.
                        Dim value As String = ""
                        value = File.ReadAllText(clbFileName_Con.Items(l).ToString)
                        builder_Con.Append(value).AppendLine()
                    End If
                End If
            End If
        Next

        If builder_Con.Length > 0 Then
            Me.rtbContent_Con.Text = builder_Con.ToString
            rtbContent_Con.SelectionCharOffset = 800

        End If

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Search_Concordance()
        If Len(Trim(rtbContent_Con.Text)) > 0 Then
            If Len(Trim(txtCon.Text)) > 0 Then

                Dim str() As String
                Dim example As String = rtbContent_Con.Text
                Dim word As String = Trim(txtCon.Text)

                If Len(Trim(txtDelimiter_Con.Text)) > 0 Then
                    str = example.Split(txtDelimiter_Con.Text)
                Else
                    str = example.Split(" "c)
                End If


                ''To Clear the DataGridView
                Dim f As New System.Drawing.Font("Latha", 9)
                dgvCon.Font = f
                dtFill_Con = New DataTable
                dtFill_Con.Columns.Add("Result", GetType(String))
                dgvCon.DataSource = dtFill_Con

                'Define the search terms and color for each
                mdtbColourMap = New DataTable
                mdtbColourMap.Columns.Add(New DataColumn("SearchTerm", GetType(String)))
                mdtbColourMap.Columns.Add(New DataColumn("TextColor", GetType(Brush)))
                mdtbColourMap.Rows.Add(txtCon.Text, Drawing.Brushes.Red)

                If cmbGram_Con.Text = "1" Then
                    One_Gram(str, word)
                ElseIf cmbGram_Con.Text = "2" Then
                    Two_Gram(str, word)
                ElseIf cmbGram_Con.Text = "3" Then
                    Three_Gram(str, word)
                ElseIf cmbGram_Con.Text = "4" Then
                    Four_Gram(str, word)
                    'Else
                    'Dim dr As DataRow

                    'For i = 0 To UBound(str)
                    '    If str(i) = word Then

                    '        'MessageBox.Show(str(i))

                    '        If (i = 0) Then
                    '            'MessageBox.Show("PREFIX : NILL")
                    '            'MessageBox.Show(" - " & " " & word & " " & str(i + 1))

                    '            dr = dtFill_Con.NewRow
                    '            dr("Result") = " - " & " " & word & " " & str(i + 1)
                    '            dtFill_Con.Rows.Add(dr)

                    '        ElseIf (i = UBound(str)) Then
                    '            'MessageBox.Show("PREFIX  : " & str(i - 1))
                    '            'MessageBox.Show(str(i - 1) & " " & word & " " & str(i + 1))
                    '            'MessageBox.Show(str(i - 1) & " " & word & " " & " - ")

                    '            dr = dtFill_Con.NewRow
                    '            dr("Result") = str(i - 1) & " " & word & " " & " - "
                    '            dtFill_Con.Rows.Add(dr)

                    '        Else
                    '            'MessageBox.Show(str(i - 1) & " " & word & " " & str(i + 1))

                    '            dr = dtFill_Con.NewRow
                    '            dr("Result") = str(i - 1) & " " & word & " " & str(i + 1)
                    '            dtFill_Con.Rows.Add(dr)

                    '        End If

                    '        'If (i = UBound(str)) Then
                    '        '    MessageBox.Show("POSTFIX : NILL")
                    '        'Else
                    '        '    MessageBox.Show("POSTFIX : " & str(i + 1))
                    '        'End If
                    '    End If
                    'Next
                End If
                If Not dtFill_Con Is Nothing Then
                    If dtFill_Con.Rows.Count > 0 Then

                        'Dim dataView As New DataView(dtFill)
                        'dataView.Sort = " Without Duplicate DESC"
                        'Dim dataTableF As DataTable = dataView.ToTable()
                        dgvCon.DataSource = dtFill_Con
                        Grid_Apperance_Con()
                    Else
                        dgvCon.DataSource = Nothing
                        'Grid_Apperance_Con()
                    End If
                End If

            Else
                MsgBox("Enter some Text to Search for the Concordance...!")
                txtCon.Focus()
                Exit Sub
            End If
        Else
            MsgBox("Upload Some text...!")
            Exit Sub
        End If
    End Sub


    Private Sub One_Gram(ByVal Str() As String, ByVal word As String)
        Dim dr As DataRow

        For i = 0 To UBound(Str)
            If Str(i) = word Then

                'MessageBox.Show(str(i))

                If (i = 0) Then
                    'MessageBox.Show("PREFIX : NILL")
                    'MessageBox.Show(" - " & " " & word & " " & str(i + 1))

                    dr = dtFill_Con.NewRow
                    dr("Result") = " - " & " " & word & " " & Str(i + 1)
                    dtFill_Con.Rows.Add(dr)

                ElseIf (i = UBound(Str)) Then
                    'MessageBox.Show("PREFIX  : " & str(i - 1))
                    'MessageBox.Show(str(i - 1) & " " & word & " " & str(i + 1))
                    'MessageBox.Show(str(i - 1) & " " & word & " " & " - ")

                    dr = dtFill_Con.NewRow
                    dr("Result") = Str(i - 1) & " " & word & " " & " - "
                    dtFill_Con.Rows.Add(dr)

                Else
                    'MessageBox.Show(str(i - 1) & " " & word & " " & str(i + 1))

                    dr = dtFill_Con.NewRow
                    dr("Result") = Str(i - 1) & " " & word & " " & Str(i + 1)
                    dtFill_Con.Rows.Add(dr)

                End If

                'If (i = UBound(str)) Then
                '    MessageBox.Show("POSTFIX : NILL")
                'Else
                '    MessageBox.Show("POSTFIX : " & str(i + 1))
                'End If
            End If
        Next
    End Sub

    Private Sub Two_Gram(ByVal Str() As String, ByVal word As String)
        Dim dr As DataRow

        For i = 0 To UBound(Str)
            If Str(i) = word Then

                If (i = 0) Then
                    dr = dtFill_Con.NewRow
                    dr("Result") = " - " & " " & " - " & " " & word & " " & Str(i + 1) & " " & Str(i + 2) & " " & Str(i + 3)
                    dtFill_Con.Rows.Add(dr)
                ElseIf (i = 1) Then
                    dr = dtFill_Con.NewRow
                    dr("Result") = " - " & " " & Str(i - 1) & " " & word & " " & Str(i + 1) & " " & Str(i + 2)
                    dtFill_Con.Rows.Add(dr)
                ElseIf (i = 2) Then
                    dr = dtFill_Con.NewRow
                    dr("Result") = Str(i - 2) & " " & Str(i - 1) & " " & word & " " & Str(i + 1) & " " & Str(i + 2)
                    dtFill_Con.Rows.Add(dr)
                ElseIf (i = 3) Then
                    dr = dtFill_Con.NewRow
                    dr("Result") = Str(i - 2) & " " & Str(i - 1) & " " & word & " " & Str(i + 1) & " " & Str(i + 2)
                    dtFill_Con.Rows.Add(dr)


                ElseIf (i = UBound(Str)) Then
                    dr = dtFill_Con.NewRow
                    dr("Result") = Str(i - 2) & " " & Str(i - 1) & " " & word & " " & " - " & " " & " - "
                    dtFill_Con.Rows.Add(dr)
                ElseIf (i = UBound(Str) - 1) Then
                    dr = dtFill_Con.NewRow
                    dr("Result") = Str(i - 2) & " " & Str(i - 1) & " " & word & " " & Str(i + 1) & " " & " - "
                    dtFill_Con.Rows.Add(dr)
                ElseIf (i = UBound(Str) - 2) Then
                    dr = dtFill_Con.NewRow
                    dr("Result") = Str(i - 2) & " " & Str(i - 1) & " " & word & " " & Str(i + 1) & " " & Str(i + 2)
                    dtFill_Con.Rows.Add(dr)
                ElseIf (i = UBound(Str) - 3) Then
                    dr = dtFill_Con.NewRow
                    dr("Result") = Str(i - 2) & " " & Str(i - 1) & " " & word & " " & Str(i + 1) & " " & Str(i + 2)
                    dtFill_Con.Rows.Add(dr)
                Else
                    dr = dtFill_Con.NewRow
                    dr("Result") = Str(i - 2) & " " & Str(i - 1) & " " & word & " " & Str(i + 1) & " " & Str(i + 2)
                    dtFill_Con.Rows.Add(dr)

                End If
            End If
        Next
    End Sub

    Private Sub Three_Gram(ByVal Str() As String, ByVal word As String)
        Dim dr As DataRow

        For i = 0 To UBound(Str)
            If Str(i) = word Then

                If (i = 0) Then
                    dr = dtFill_Con.NewRow
                    dr("Result") = " - " & " " & " - " & " " & " - " & " " & word & " " & Str(i + 1) & " " & Str(i + 2) & " " & Str(i + 3)
                    dtFill_Con.Rows.Add(dr)
                ElseIf (i = 1) Then
                    dr = dtFill_Con.NewRow
                    dr("Result") = " - " & " " & " - " & " " & Str(i - 1) & " " & word & " " & Str(i + 1) & " " & Str(i + 2) & " " & Str(i + 3)
                    dtFill_Con.Rows.Add(dr)
                ElseIf (i = 2) Then
                    dr = dtFill_Con.NewRow
                    dr("Result") = " - " & " " & Str(i - 2) & " " & Str(i - 1) & " " & word & " " & Str(i + 1) & " " & Str(i + 2) & " " & Str(i + 3)
                    dtFill_Con.Rows.Add(dr)
                ElseIf (i = 3) Then
                    dr = dtFill_Con.NewRow
                    dr("Result") = Str(i - 3) & " " & Str(i - 2) & " " & Str(i - 1) & " " & word & " " & Str(i + 1) & " " & Str(i + 2) & " " & Str(i + 3)
                    dtFill_Con.Rows.Add(dr)


                ElseIf (i = UBound(Str)) Then
                    dr = dtFill_Con.NewRow
                    dr("Result") = Str(i - 3) & " " & Str(i - 2) & " " & Str(i - 1) & " " & word & " " & " - " & " " & " - " & " " & " - "
                    dtFill_Con.Rows.Add(dr)
                ElseIf (i = UBound(Str) - 1) Then
                    dr = dtFill_Con.NewRow
                    dr("Result") = Str(i - 3) & " " & Str(i - 2) & " " & Str(i - 1) & " " & word & " " & Str(i + 1) & " " & " - " & " " & " - "
                    dtFill_Con.Rows.Add(dr)
                ElseIf (i = UBound(Str) - 2) Then
                    dr = dtFill_Con.NewRow
                    dr("Result") = Str(i - 3) & " " & Str(i - 2) & " " & Str(i - 1) & " " & word & " " & Str(i + 1) & " " & Str(i + 2) & " " & " - "
                    dtFill_Con.Rows.Add(dr)
                ElseIf (i = UBound(Str) - 3) Then
                    dr = dtFill_Con.NewRow
                    dr("Result") = Str(i - 3) & " " & Str(i - 2) & " " & Str(i - 1) & " " & word & " " & Str(i + 1) & " " & Str(i + 2) & " " & Str(i + 3)
                    dtFill_Con.Rows.Add(dr)
                Else
                    dr = dtFill_Con.NewRow
                    dr("Result") = Str(i - 3) & " " & Str(i - 2) & " " & Str(i - 1) & " " & word & " " & Str(i + 1) & " " & Str(i + 2) & " " & Str(i + 3)
                    dtFill_Con.Rows.Add(dr)

                End If
            End If
        Next
    End Sub

    Private Sub Four_Gram(ByVal Str() As String, ByVal word As String)
        Dim dr As DataRow

        For i = 0 To UBound(Str)
            If Str(i) = word Then

                If (i = 0) Then
                    dr = dtFill_Con.NewRow
                    dr("Result") = " - " & " " & " - " & " " & " - " & " " & " - " & " " & word & " " & Str(i + 1) & " " & Str(i + 2) & " " & Str(i + 3) & " " & Str(i + 4)
                    dtFill_Con.Rows.Add(dr)
                ElseIf (i = 1) Then
                    dr = dtFill_Con.NewRow
                    dr("Result") = " - " & " " & " - " & " " & " - " & " " & Str(i - 1) & " " & word & " " & Str(i + 1) & " " & Str(i + 2) & " " & Str(i + 3) & " " & Str(i + 4)
                    dtFill_Con.Rows.Add(dr)
                ElseIf (i = 2) Then
                    dr = dtFill_Con.NewRow
                    dr("Result") = " - " & " " & " - " & " " & Str(i - 2) & " " & Str(i - 1) & " " & word & " " & Str(i + 1) & " " & Str(i + 2) & " " & Str(i + 3) & " " & Str(i + 4)
                    dtFill_Con.Rows.Add(dr)
                ElseIf (i = 3) Then
                    dr = dtFill_Con.NewRow
                    dr("Result") = " - " & " " & Str(i - 3) & " " & Str(i - 2) & " " & Str(i - 1) & " " & word & " " & Str(i + 1) & " " & Str(i + 2) & " " & Str(i + 3) & " " & Str(i + 4)
                    dtFill_Con.Rows.Add(dr)
                ElseIf (i = 4) Then
                    dr = dtFill_Con.NewRow
                    dr("Result") = Str(i - 4) & " " & Str(i - 3) & " " & Str(i - 2) & " " & Str(i - 1) & " " & word & " " & Str(i + 1) & " " & Str(i + 2) & " " & Str(i + 3) & " " & Str(i + 4)
                    dtFill_Con.Rows.Add(dr)


                ElseIf (i = UBound(Str)) Then
                    dr = dtFill_Con.NewRow
                    dr("Result") = Str(i - 4) & " " & Str(i - 3) & " " & Str(i - 2) & " " & Str(i - 1) & " " & word & " " & " - " & " " & " - " & " " & " - " & " " & " - "
                    dtFill_Con.Rows.Add(dr)
                ElseIf (i = UBound(Str) - 1) Then
                    dr = dtFill_Con.NewRow
                    dr("Result") = Str(i - 4) & " " & Str(i - 3) & " " & Str(i - 2) & " " & Str(i - 1) & " " & word & " " & Str(i + 1) & " " & " - " & " " & " - " & " " & " - "
                    dtFill_Con.Rows.Add(dr)
                ElseIf (i = UBound(Str) - 2) Then
                    dr = dtFill_Con.NewRow
                    dr("Result") = Str(i - 4) & " " & Str(i - 3) & " " & Str(i - 2) & " " & Str(i - 1) & " " & word & " " & Str(i + 1) & " " & Str(i + 2) & " " & " - " & " " & " - "
                    dtFill_Con.Rows.Add(dr)
                ElseIf (i = UBound(Str) - 3) Then
                    dr = dtFill_Con.NewRow
                    dr("Result") = Str(i - 4) & " " & Str(i - 3) & " " & Str(i - 2) & " " & Str(i - 1) & " " & word & " " & Str(i + 1) & " " & Str(i + 2) & " " & Str(i + 3) & " " & " - "
                    dtFill_Con.Rows.Add(dr)
                Else
                    dr = dtFill_Con.NewRow
                    dr("Result") = Str(i - 4) & " " & Str(i - 3) & " " & Str(i - 2) & " " & Str(i - 1) & " " & word & " " & Str(i + 1) & " " & Str(i + 2) & " " & Str(i + 3) & " " & Str(i + 4)
                    dtFill_Con.Rows.Add(dr)

                End If
            End If
        Next
    End Sub

    Private Sub btnFill_Con_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFill_Con.Click
        Fill_Data_For_Concordance()
    End Sub


    Private Sub btnSearch_Con_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch_Con.Click
        Search_Concordance()
    End Sub

    Private Sub rtbContent_Con_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles rtbContent_Con.MouseClick
        curWord = GetWordUnderMouse(Me.rtbContent_Con, e.X, e.Y)
        txtCon.Text = ""
        txtCon.Text = curWord

        Call btnSearch_Con_Click(sender, e)

    End Sub

    Private Sub Grid_Apperance_Con()

        ' Set the column header style.

        'Dim f As New System.Drawing.Font("Latha", 9)
        Dim f As New System.Drawing.Font("Latha", 9)
        ' Assign the font to the control
        dgvCon.Font = f

        Dim columnHeaderStyle As New DataGridViewCellStyle()
        columnHeaderStyle.Font = New Font("Latha", 9, FontStyle.Bold)
        dgvCon.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        dgvCon.ColumnHeadersDefaultCellStyle = columnHeaderStyle

        dgvCon.EnableHeadersVisualStyles = False

        'Makes the row header color
        dgvCon.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black
        dgvCon.ColumnHeadersDefaultCellStyle.BackColor = Color.YellowGreen
        dgvCon.RowHeadersDefaultCellStyle.BackColor = Color.YellowGreen
        'Me.dgvCon.DefaultCellStyle.ForeColor = Color.Coral
        ' Change back color of each row
        Me.dgvCon.RowsDefaultCellStyle.BackColor = Color.AliceBlue

        dgvCon.DefaultCellStyle.SelectionBackColor = Color.AliceBlue
        dgvCon.DefaultCellStyle.SelectionForeColor = Color.Black
        ' dgvCon GridLine Color
        'Me.dgvCon.GridColor = Color.Blue
        ' Change Grid Border Style
        Me.dgvCon.BorderStyle = BorderStyle.Fixed3D

        dgvCon.Columns("Result").Width = 885
        dgvCon.RowHeadersVisible = False
        dgvCon.AllowUserToResizeColumns = False
        dgvCon.MultiSelect = False
        dgvCon.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        dgvCon.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
        dgvCon.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells
        dgvCon.ReadOnly = True
    End Sub


    Public Function GetWordUnderMouse(ByRef Rtf As System.Windows.Forms.RichTextBox, ByVal X As Integer, ByVal Y As Integer) As String
        On Error Resume Next
        Dim POINT As System.Drawing.Point = New System.Drawing.Point()
        Dim Pos As Integer, i As Integer, lStart As Integer, lEnd As Integer
        Dim lLen As Integer, sTxt As String, sChr As String
        '
        POINT.X = X
        POINT.Y = Y
        GetWordUnderMouse = vbNullString
        '
        With Rtf
            lLen = Len(.Text)
            sTxt = .Text
            Pos = Rtf.GetCharIndexFromPosition(POINT)
            If Pos > 0 Then
                For i = Pos To 1 Step -1
                    sChr = Mid(sTxt, i, 1)
                    If sChr = " " Or sChr = Chr(13) Or i = 1 Then
                        'if the starting character is vbcrlf then
                        'we want to chop that off
                        If sChr = Chr(13) Then
                            lStart = (i + 2)
                        Else
                            lStart = i
                        End If
                        Exit For
                    End If
                Next i
                For i = Pos To lLen
                    If Mid(sTxt, i, 1) = " " Or Mid(sTxt, i, 1) = Chr(13) Or i = lLen Then
                        lEnd = i + 1
                        Exit For
                    End If
                Next i
                If lEnd >= lStart Then
                    GetWordUnderMouse = Trim(Mid(sTxt, lStart, lEnd - lStart))
                End If
            End If
        End With
    End Function



    Private Sub dgvCon_CellPainting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles dgvCon.CellPainting
        If e.ColumnIndex >= 0 And e.RowIndex >= 0 Then
            'Dim newRect As New Rectangle(e.CellBounds.X + 1, e.CellBounds.Y + 1, _
            '    e.CellBounds.Width - 4, e.CellBounds.Height - 4)
            Dim backColorBrush As New SolidBrush(e.CellStyle.BackColor)
            Dim gridBrush As New SolidBrush(Me.dgvCon.GridColor)
            Dim gridLinePen As New Pen(gridBrush)
            Try
                ' Erase the cell.
                e.Graphics.FillRectangle(backColorBrush, e.CellBounds)

                ' Draw the grid lines (only the right and bottom lines; 
                ' DataGridView takes care of the others).
                e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left, _
                    e.CellBounds.Bottom - 1, e.CellBounds.Right - 1, _
                    e.CellBounds.Bottom - 1)
                e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1, _
                    e.CellBounds.Top, e.CellBounds.Right - 1, _
                    e.CellBounds.Bottom)

                ' Draw the inset highlight box.
                'e.Graphics.DrawRectangle(Pens.Blue, newRect)

                ' Draw the text content of the cell, ignoring alignment. 
                If (e.Value IsNot Nothing) Then
                    Dim strValue As String = CStr(e.Value)
                    Dim strWords() As String = Split(strValue, " ")
                    Dim strAlignment As String = "LEFT"
                    'If e.ColumnIndex = 0 Then strAlignment = "RIGHT"
                    If e.ColumnIndex = 0 Then strAlignment = "LEFT"
                    Dim sngX As Integer
                    If strAlignment = "LEFT" Then
                        sngX = e.CellBounds.X + 2
                    Else
                        sngX = e.CellBounds.Right - 4 - e.Graphics.MeasureString(strValue, e.CellStyle.Font).Width
                    End If
                    For i As Integer = 0 To strWords.GetUpperBound(0)
                        Dim brsTextColor As Drawing.Brush = Nothing
                        For j As Integer = 0 To mdtbColourMap.Rows.Count - 1
                            Dim strSearchTerm As String = mdtbColourMap.Rows(j).Item("SearchTerm").ToString
                            If InStr(strWords(i), strSearchTerm) > 0 Then
                                brsTextColor = DirectCast(mdtbColourMap.Rows(j).Item("TextColor"), Drawing.Brush) 'change the color
                                Exit For
                            End If
                        Next j
                        If brsTextColor Is Nothing Then
                            brsTextColor = Brushes.Black 'default
                        End If
                        e.Graphics.DrawString(strWords(i), e.CellStyle.Font, brsTextColor, sngX, e.CellBounds.Y + 2, StringFormat.GenericDefault)
                        sngX += e.Graphics.MeasureString(strWords(i), e.CellStyle.Font).Width
                    Next i
                End If
                e.Handled = True
            Finally
                gridLinePen.Dispose()
                gridBrush.Dispose()
                backColorBrush.Dispose()
            End Try

        End If

    End Sub


    Private Sub clbFileName_Con_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles clbFileName_Con.SelectedIndexChanged
        If clbFileName_Con.SelectedIndex = 0 Then
            If clbFileName_Con.GetItemChecked(0) = False Then
                For idx As Integer = 1 To clbFileName_Con.Items.Count - 1

                    Me.clbFileName_Con.SetItemChecked(idx, False)
                Next
            Else
                For idx As Integer = 1 To clbFileName_Con.Items.Count - 1

                    Me.clbFileName_Con.SetItemChecked(idx, True)
                Next
            End If
        ElseIf clbFileName_Con.SelectedIndex > 0 Then
            If clbFileName_Con.CheckedItems.Count = clbFileName_Con.Items.Count - 1 And clbFileName_Con.GetItemChecked(0) = False Then
                clbFileName_Con.SetItemCheckState(0, CheckState.Checked)
            End If
            For idx As Integer = 1 To clbFileName_Con.Items.Count - 1

                If clbFileName_Con.GetItemChecked(idx) = False Then
                    clbFileName_Con.SetItemCheckState(0, CheckState.Unchecked)

                End If
            Next
        End If
    End Sub

    Private Sub btnClear_Con_Click(sender As Object, e As EventArgs) Handles btnClear_Con.Click
        rtbContent_Con.Text = ""
        dgvCon.DataSource = Nothing
        dgvCon.Rows.Clear()
        txtCon.Text = ""
        cmbGram_Con.SelectedIndex = 0
        txtDelimiter_Con.Text = ""
        clbFileName_Con.Items.Clear()
        clbFlag_ = False
        btnUpload_Con.Focus()
        Me.Refresh()
    End Sub
End Class