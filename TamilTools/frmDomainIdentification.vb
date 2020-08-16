#Region " Imports "

Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Globalization
Imports System.ComponentModel
Imports System.Text

#End Region


Public Class frmDomainIdentification

#Region " Declaration "
    ' Variable Declaration
    Dim DbWords() As String
    Dim words As String = ""
    Dim TextLine As String = ""
    Dim arySplitwords() As String
    Dim dtable, dtable1, dtable2, dtable3, dtable4, dtable5, dtable6, dtable7, dtable8, dtable9, dtable10, dtable11, dtable12, dtable13, dtable14, dtable15, dtable16, dtable17 As New DataTable
    Dim chkFlag As Boolean = False
    Dim wrd() As String
    Dim wr, wr1, word1, word2 As String
    Dim wrd1() As String
    Dim cnt1, cnt2, cnt3, cnt4, cnt5, cnt6, cnt7, cnt8, cnt9, cnt10, cnt11, cnt12, cnt13, cnt14, cnt15, cnt16, cnt17 As Integer
    Dim tot_sb, sb, sb1, sb2, sb3, sb4, sb5, sb6, sb7, sb8, sb9, sb10, sb11, sb12, sb13, sb14, sb15, sb16 As New StringBuilder
    Dim pathText As String = My.Application.Info.DirectoryPath

    Dim output As String = pathText & "\DomainIdentification"
    Dim fileDateTime As String = DateTime.Now.ToString("ddMMyyyy") & "_" & DateTime.Now.ToString("HHmm")
    Dim outputFile As String = ""
#End Region

#Region " Form Load"

    Private Sub frmDomainIdentification_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'InitializeComponent()
        Control.CheckForIllegalCrossThreadCalls = False
        loaddt()
        dtable.Rows.Clear()
        dtable1.Rows.Clear()
        dtable2.Rows.Clear()
        dtable3.Rows.Clear()
        dtable4.Rows.Clear()
        dtable5.Rows.Clear()
        dtable6.Rows.Clear()
        dtable7.Rows.Clear()
        dtable8.Rows.Clear()
        dtable9.Rows.Clear()
        dtable10.Rows.Clear()
        dtable11.Rows.Clear()
        dtable12.Rows.Clear()
        dtable13.Rows.Clear()
        dtable14.Rows.Clear()
        dtable15.Rows.Clear()
        dtable16.Rows.Clear()
        dtable17.Rows.Clear()
        rbSingle.Checked = True
        'Grid_Apperance_Con()
        Clear_Count()
    End Sub

#End Region

#Region " Button "

    Private Sub btnFileSelection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFileSelection.Click
        'Button for choosing a text file(.txt) that you want to categorize.
        dtable.Rows.Clear()
        dtable1.Rows.Clear()
        dtable2.Rows.Clear()
        dtable3.Rows.Clear()
        dtable4.Rows.Clear()
        dtable5.Rows.Clear()
        dtable6.Rows.Clear()
        dtable7.Rows.Clear()
        dtable8.Rows.Clear()
        dtable9.Rows.Clear()
        dtable10.Rows.Clear()
        dtable11.Rows.Clear()
        dtable12.Rows.Clear()
        dtable13.Rows.Clear()
        dtable14.Rows.Clear()
        dtable15.Rows.Clear()
        dtable16.Rows.Clear()
        dtable17.Rows.Clear()
        chckList.Items.Clear()
        'For choosing single files
        If rbSingle.Checked = True Then
            opnFileDlg.Title = "Please select a file"
            opnFileDlg.InitialDirectory = "C: temp"
            opnFileDlg.Filter = "TextFiles(*.txt)|*.txt"
            If opnFileDlg.ShowDialog() = Windows.Forms.DialogResult.OK Then
                chckList.Items.Add(opnFileDlg.FileName)
                For c As Integer = 0 To chckList.Items.Count - 1
                    chckList.SetItemCheckState(c, CheckState.Checked)
                Next
            Else
                chckList.Items.Clear()
            End If
            'For choosing Multiple Files
        ElseIf rbMultiple.Checked = True Then
            fldrBrwsDlg.ShowNewFolderButton = True
            If fldrBrwsDlg.ShowDialog() = Windows.Forms.DialogResult.OK Then
                If Not BackgroundWorker2.IsBusy Then
                    BackgroundWorker2.RunWorkerAsync()
                End If
            Else
                chckList.Items.Clear()
            End If

        Else
            MsgBox("Please select the type of file selection")
            grpFileSelection.Focus()
        End If
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click

        If chckList.Items.Count > 0 Then
            If chkFlag = False Then
                For l = 0 To chckList.Items.Count - 1
                    If chckList.GetItemChecked(l) = True Then
                        chkFlag = True
                        Exit For
                    End If
                Next
            End If
            If chkFlag = True Then
                chkFlag = False
                Me.Cursor = Cursors.WaitCursor
                dtable.Rows.Clear()
                dtable1.Rows.Clear()
                dtable2.Rows.Clear()
                dtable3.Rows.Clear()
                dtable4.Rows.Clear()
                dtable5.Rows.Clear()
                dtable6.Rows.Clear()
                dtable7.Rows.Clear()
                dtable8.Rows.Clear()
                dtable9.Rows.Clear()
                dtable10.Rows.Clear()
                dtable11.Rows.Clear()
                dtable12.Rows.Clear()
                DataGridView1.DataSource = Nothing
                DataGridView1.Refresh()
                Clear_Count()
                If Not BackgroundWorker1.IsBusy Then
                    BackgroundWorker1.WorkerSupportsCancellation = True
                    BackgroundWorker1.RunWorkerAsync()
                End If
                Dim DB_FILE As String = pathText & "\DomainFinalList.txt"
                DbWords = File.ReadAllLines(DB_FILE)
                btnFileSelection.Enabled = False
                grpFileSelection.Enabled = False
                chckList.Enabled = False
                If (Not System.IO.Directory.Exists(output)) Then
                    System.IO.Directory.CreateDirectory(output)
                End If

                For j = 0 To chckList.Items.Count - 1
                    If Not chckList.Items(j) = "Select/UnselectAll" Then
                        If chckList.GetItemChecked(j) = True Then
                            Dim INPUT_FILE As String = chckList.Items(j)
                            If System.IO.File.Exists(INPUT_FILE) = True Then
                                Dim objReader As New System.IO.StreamReader(INPUT_FILE)
                                Do While objReader.Peek() <> -1
                                    TextLine = ""
                                    TextLine = Trim(objReader.ReadLine())
                                    TextLine = replaceSpclChar(TextLine)
                                    If TextLine.Contains(" ") Then
                                        arySplitwords = TextLine.Split(" "c)
                                        For k = 0 To UBound(arySplitwords)
                                            TextLine = arySplitwords(k)
                                            searchWords(TextLine)
                                        Next
                                    Else
                                        TextLine = Trim(TextLine.ToString)
                                        searchWords(TextLine)
                                    End If
                                Loop
                                objReader.Close()
                            End If
                        End If
                    End If
                Next
                Dim dr As DataRow = dtable.NewRow
                For i = 0 To dtable1.Rows.Count - 1
                    If (i = 0) Then
                        dr("DOMAIN NAME") = dtable1.Rows(i)("DOMAIN NAME")
                        dr("Count") = dtable1.Rows(i)("Count")
                        dtable.Rows.Add(dr.ItemArray)
                        tot_sb.Append(Trim(dr("DOMAIN NAME")) & Trim(" -- ") & Trim(dr("Count"))).AppendLine()
                        Exit For
                    End If
                Next
                For i = 0 To dtable2.Rows.Count - 1
                    If (i = 0) Then
                        dr("DOMAIN NAME") = dtable2.Rows(i)("DOMAIN NAME")
                        dr("Count") = dtable2.Rows(i)("Count")
                        dtable.Rows.Add(dr.ItemArray)
                        tot_sb.Append(Trim(dr("DOMAIN NAME")) & Trim(" -- ") & Trim(dr("Count"))).AppendLine()
                        Exit For
                    End If
                Next

                For i = 0 To dtable3.Rows.Count - 1
                    If (i = 0) Then

                        dr("DOMAIN NAME") = dtable3.Rows(i)("DOMAIN NAME")
                        dr("Count") = dtable3.Rows(i)("Count")
                        dtable.Rows.Add(dr.ItemArray)
                        tot_sb.Append(Trim(dr("DOMAIN NAME")) & Trim(" -- ") & Trim(dr("Count"))).AppendLine()
                        Exit For
                    End If
                Next
                For i = 0 To dtable4.Rows.Count - 1
                    If (i = 0) Then
                        dr("DOMAIN NAME") = dtable4.Rows(i)("DOMAIN NAME")
                        dr("Count") = dtable4.Rows(i)("Count")
                        dtable.Rows.Add(dr.ItemArray)
                        tot_sb.Append(Trim(dr("DOMAIN NAME")) & Trim(" -- ") & Trim(dr("Count"))).AppendLine()
                        Exit For
                    End If
                Next
                For i = 0 To dtable5.Rows.Count - 1
                    If (i = 0) Then
                        dr("DOMAIN NAME") = dtable5.Rows(i)("DOMAIN NAME")
                        dr("Count") = dtable5.Rows(i)("Count")
                        dtable.Rows.Add(dr.ItemArray)
                        tot_sb.Append(Trim(dr("DOMAIN NAME")) & Trim(" -- ") & Trim(dr("Count"))).AppendLine()
                        Exit For
                    End If
                Next
                For i = 0 To dtable6.Rows.Count - 1
                    If (i = 0) Then
                        dr("DOMAIN NAME") = dtable6.Rows(i)("DOMAIN NAME")
                        dr("Count") = dtable6.Rows(i)("Count")
                        dtable.Rows.Add(dr.ItemArray)
                        tot_sb.Append(Trim(dr("DOMAIN NAME")) & Trim(" -- ") & Trim(dr("Count"))).AppendLine()
                        Exit For
                    End If
                Next
                For i = 0 To dtable7.Rows.Count - 1
                    If (i = 0) Then
                        dr("DOMAIN NAME") = dtable7.Rows(i)("DOMAIN NAME")
                        dr("Count") = dtable7.Rows(i)("Count")
                        dtable.Rows.Add(dr.ItemArray)
                        tot_sb.Append(Trim(dr("DOMAIN NAME")) & Trim(" -- ") & Trim(dr("Count"))).AppendLine()
                        Exit For
                    End If
                Next
                For i = 0 To dtable8.Rows.Count - 1
                    If (i = 0) Then
                        dr("DOMAIN NAME") = dtable8.Rows(i)("DOMAIN NAME")
                        dr("Count") = dtable8.Rows(i)("Count")
                        dtable.Rows.Add(dr.ItemArray)
                        tot_sb.Append(Trim(dr("DOMAIN NAME")) & Trim(" -- ") & Trim(dr("Count"))).AppendLine()
                        Exit For
                    End If
                Next
                For i = 0 To dtable9.Rows.Count - 1
                    If (i = 0) Then
                        dr("DOMAIN NAME") = dtable9.Rows(i)("DOMAIN NAME")
                        dr("Count") = dtable9.Rows(i)("Count")
                        dtable.Rows.Add(dr.ItemArray)
                        tot_sb.Append(Trim(dr("DOMAIN NAME")) & Trim(" -- ") & Trim(dr("Count"))).AppendLine()
                        Exit For
                    End If
                Next
                For i = 0 To dtable10.Rows.Count - 1
                    If (i = 0) Then
                        dr("DOMAIN NAME") = dtable10.Rows(i)("DOMAIN NAME")
                        dr("Count") = dtable10.Rows(i)("Count")
                        dtable.Rows.Add(dr.ItemArray)
                        tot_sb.Append(Trim(dr("DOMAIN NAME")) & Trim(" -- ") & Trim(dr("Count"))).AppendLine()
                        Exit For
                    End If
                Next
                For i = 0 To dtable11.Rows.Count - 1
                    If (i = 0) Then
                        dr("DOMAIN NAME") = dtable11.Rows(i)("DOMAIN NAME")
                        dr("Count") = dtable11.Rows(i)("Count")
                        dtable.Rows.Add(dr.ItemArray)
                        tot_sb.Append(Trim(dr("DOMAIN NAME")) & Trim(" -- ") & Trim(dr("Count"))).AppendLine()
                        Exit For
                    End If
                Next
                For i = 0 To dtable12.Rows.Count - 1
                    If (i = 0) Then
                        dr("DOMAIN NAME") = dtable12.Rows(i)("DOMAIN NAME")
                        dr("Count") = dtable12.Rows(i)("Count")
                        dtable.Rows.Add(dr.ItemArray)
                        tot_sb.Append(Trim(dr("DOMAIN NAME")) & Trim(" -- ") & Trim(dr("Count"))).AppendLine()
                        Exit For
                    End If
                Next
                For i = 0 To dtable13.Rows.Count - 1
                    If (i = 0) Then
                        dr("DOMAIN NAME") = dtable13.Rows(i)("DOMAIN NAME")
                        dr("Count") = dtable13.Rows(i)("Count")
                        dtable.Rows.Add(dr.ItemArray)
                        tot_sb.Append(Trim(dr("DOMAIN NAME")) & Trim(" -- ") & Trim(dr("Count"))).AppendLine()
                        Exit For
                    End If
                Next
                For i = 0 To dtable14.Rows.Count - 1
                    If (i = 0) Then
                        dr("DOMAIN NAME") = dtable14.Rows(i)("DOMAIN NAME")
                        dr("Count") = dtable14.Rows(i)("Count")
                        dtable.Rows.Add(dr.ItemArray)
                        tot_sb.Append(Trim(dr("DOMAIN NAME")) & Trim(" -- ") & Trim(dr("Count"))).AppendLine()
                        Exit For
                    End If
                Next
                For i = 0 To dtable15.Rows.Count - 1
                    If (i = 0) Then
                        dr("DOMAIN NAME") = dtable15.Rows(i)("DOMAIN NAME")
                        dr("Count") = dtable15.Rows(i)("Count")
                        dtable.Rows.Add(dr.ItemArray)
                        tot_sb.Append(Trim(dr("DOMAIN NAME")) & Trim(" -- ") & Trim(dr("Count"))).AppendLine()
                        Exit For
                    End If
                Next
                For i = 0 To dtable16.Rows.Count - 1
                    If (i = 0) Then
                        dr("DOMAIN NAME") = dtable16.Rows(i)("DOMAIN NAME")
                        dr("Count") = dtable16.Rows(i)("Count")
                        dtable.Rows.Add(dr.ItemArray)
                        tot_sb.Append(Trim(dr("DOMAIN NAME")) & Trim(" -- ") & Trim(dr("Count"))).AppendLine()
                        Exit For
                    End If
                Next
                For i = 0 To dtable17.Rows.Count - 1
                    If (i = 0) Then
                        dr("DOMAIN NAME") = dtable17.Rows(i)("DOMAIN NAME")
                        dr("Count") = dtable17.Rows(i)("Count")
                        dtable.Rows.Add(dr.ItemArray)
                        tot_sb.Append(Trim(dr("DOMAIN NAME")) & Trim(" -- ") & Trim(dr("Count"))).AppendLine()
                        Exit For
                    End If
                Next
                Dim view As DataView = dtable.DefaultView
                view.Sort = "Count DESC"
                DataGridView1.DataSource = view
                DataGridView1.Columns("DOMAIN NAME").Width = 300
                DataGridView1.Columns("Count").Width = 146
                Grid_Apperance_Con()
                outputFile = output & "\DOMAINS & COUNTS_" & fileDateTime & ".txt"
                System.IO.File.WriteAllText(outputFile, tot_sb.ToString, Encoding.UTF8)
                Me.Cursor = Cursors.Default
                btnFileSelection.Enabled = True
                grpFileSelection.Enabled = True
                chckList.Enabled = True

            Else
                MsgBox("Please select any one item")
                chckList.Focus()
                Exit Sub
            End If
        Else
            MsgBox("Please select any folder")
            btnFileSelection.Focus()
        End If

    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        rbSingle.Checked = True
        chckList.Items.Clear()

        dtable.Rows.Clear()
        DataGridView1.DataSource = Nothing
        Clear_Count()
        dtable1.Rows.Clear()
        dtable2.Rows.Clear()
        dtable3.Rows.Clear()
        dtable4.Rows.Clear()
        dtable5.Rows.Clear()
        dtable6.Rows.Clear()
        dtable7.Rows.Clear()
        dtable8.Rows.Clear()
        dtable9.Rows.Clear()
        dtable10.Rows.Clear()
        dtable11.Rows.Clear()
        dtable12.Rows.Clear()
        dtable13.Rows.Clear()
        dtable14.Rows.Clear()
        dtable15.Rows.Clear()
        dtable16.Rows.Clear()
        dtable17.Rows.Clear()
        btnFileSelection.Focus()

    End Sub

#End Region

#Region " Function "

    Private Sub loaddt()
        'Loading new datatable
        dtable = New DataTable
        dtable.Columns.Add("DOMAIN NAME")
        dtable.Columns.Add("Count", GetType(Integer))
        dtable.Columns("DOMAIN NAME").MaxLength = 120

        dtable1 = New DataTable
        dtable1.Columns.Add("WORDS")
        dtable1.Columns.Add("DOMAIN NAME")
        dtable1.Columns.Add("Count", GetType(Integer))

        dtable2 = New DataTable
        dtable2.Columns.Add("WORDS")
        dtable2.Columns.Add("DOMAIN NAME")
        dtable2.Columns.Add("Count", GetType(Integer))

        dtable3 = New DataTable
        dtable3.Columns.Add("WORDS")
        dtable3.Columns.Add("DOMAIN NAME")
        dtable3.Columns.Add("Count", GetType(Integer))

        dtable4 = New DataTable
        dtable4.Columns.Add("WORDS")
        dtable4.Columns.Add("DOMAIN NAME")
        dtable4.Columns.Add("Count", GetType(Integer))

        dtable5 = New DataTable
        dtable5.Columns.Add("WORDS")
        dtable5.Columns.Add("DOMAIN NAME")
        dtable5.Columns.Add("Count", GetType(Integer))

        dtable6 = New DataTable
        dtable6.Columns.Add("WORDS")
        dtable6.Columns.Add("DOMAIN NAME")
        dtable6.Columns.Add("Count", GetType(Integer))

        dtable7 = New DataTable
        dtable7.Columns.Add("WORDS")
        dtable7.Columns.Add("DOMAIN NAME")
        dtable7.Columns.Add("Count", GetType(Integer))

        dtable8 = New DataTable
        dtable8.Columns.Add("WORDS")
        dtable8.Columns.Add("DOMAIN NAME")
        dtable8.Columns.Add("Count", GetType(Integer))

        dtable9 = New DataTable
        dtable9.Columns.Add("WORDS")
        dtable9.Columns.Add("DOMAIN NAME")
        dtable9.Columns.Add("Count", GetType(Integer))

        dtable10 = New DataTable
        dtable10.Columns.Add("WORDS")
        dtable10.Columns.Add("DOMAIN NAME")
        dtable10.Columns.Add("Count", GetType(Integer))

        dtable11 = New DataTable
        dtable11.Columns.Add("WORDS")
        dtable11.Columns.Add("DOMAIN NAME")
        dtable11.Columns.Add("Count", GetType(Integer))

        dtable12 = New DataTable
        dtable12.Columns.Add("WORDS")
        dtable12.Columns.Add("DOMAIN NAME")
        dtable12.Columns.Add("Count", GetType(Integer))

        dtable13 = New DataTable
        dtable13.Columns.Add("WORDS")
        dtable13.Columns.Add("DOMAIN NAME")
        dtable13.Columns.Add("Count", GetType(Integer))

        dtable14 = New DataTable
        dtable14.Columns.Add("WORDS")
        dtable14.Columns.Add("DOMAIN NAME")
        dtable14.Columns.Add("Count", GetType(Integer))

        dtable15 = New DataTable
        dtable15.Columns.Add("WORDS")
        dtable15.Columns.Add("DOMAIN NAME")
        dtable15.Columns.Add("Count", GetType(Integer))

        dtable16 = New DataTable
        dtable16.Columns.Add("WORDS")
        dtable16.Columns.Add("DOMAIN NAME")
        dtable16.Columns.Add("Count", GetType(Integer))


        dtable17 = New DataTable
        dtable17.Columns.Add("WORDS")
        dtable17.Columns.Add("DOMAIN NAME")
        dtable17.Columns.Add("Count", GetType(Integer))
    End Sub

    Private Function replaceSpclChar(ByVal TextLine As String) As String
        ' Removes the special characters from the text file.

        TextLine = TextLine.Replace(",", "")
        TextLine = TextLine.Replace("~", "")
        TextLine = TextLine.Replace("`", "")
        TextLine = TextLine.Replace("@", "")
        TextLine = TextLine.Replace("#", "")
        TextLine = TextLine.Replace("$", "")
        TextLine = TextLine.Replace("%", "")
        TextLine = TextLine.Replace("^", "")
        TextLine = TextLine.Replace("&", "")
        TextLine = TextLine.Replace("*", "")
        TextLine = TextLine.Replace("_", "")
        TextLine = TextLine.Replace("+", "")
        TextLine = TextLine.Replace("=", "")
        TextLine = TextLine.Replace("{", "")
        TextLine = TextLine.Replace("}", "")
        TextLine = TextLine.Replace("[", "")
        TextLine = TextLine.Replace("]", "")
        TextLine = TextLine.Replace("|", "")
        TextLine = TextLine.Replace("\", "")
        TextLine = TextLine.Replace("‘", "")
        TextLine = TextLine.Replace("’", "")
        TextLine = TextLine.Replace("<", "")
        TextLine = TextLine.Replace(">", "")
        TextLine = TextLine.Replace("?", "")
        TextLine = TextLine.Replace("/", "")
        TextLine = TextLine.Replace("""", "")
        TextLine = TextLine.Replace("....", " ")
        TextLine = TextLine.Replace(".....", " ")
        TextLine = TextLine.Replace("...", " ")
        TextLine = TextLine.Replace("..", " ")

        TextLine = TextLine.Replace("ツ", "")
        TextLine = TextLine.Replace(":'(", "")
        TextLine = TextLine.Replace(":-(", "")
        TextLine = TextLine.Replace(":-)))", "")
        TextLine = TextLine.Replace(":)))", "")
        TextLine = TextLine.Replace("-))))))))", "")
        TextLine = TextLine.Replace("—", "")
        TextLine = TextLine.Replace(";-))))))", "")
        TextLine = TextLine.Replace(";)))))))", "")
        TextLine = TextLine.Replace(";-)", "")
        TextLine = TextLine.Replace("(!)", "")
        TextLine = TextLine.Replace(":-))", "")
        TextLine = TextLine.Replace(":-)", "")
        TextLine = TextLine.Replace(":)))", "")
        TextLine = TextLine.Replace(":)", "")

        TextLine = TextLine.Replace("-", "")
        TextLine = TextLine.Replace(":", "")
        TextLine = TextLine.Replace(";", "")
        TextLine = TextLine.Replace("'", "")
        TextLine = TextLine.Replace("!", "")

        TextLine = TextLine.Replace("»", "")
        TextLine = TextLine.Replace("«", "")
        TextLine = TextLine.Replace("\s", "")
        TextLine = TextLine.Replace(".(", "(")
        TextLine = TextLine.Replace("‪(", "(")
        TextLine = TextLine.Replace("¨", "")
        TextLine = TextLine.Replace("↔", "")
        TextLine = TextLine.Replace("©", "")
        TextLine = TextLine.Replace("☎", "")
        TextLine = TextLine.Replace("❄", "")
        TextLine = TextLine.Replace("❤", "")
        TextLine = TextLine.Replace("✨", "")
        TextLine = TextLine.Replace("‏", "")
        TextLine = TextLine.Replace("‎", "")
        TextLine = TextLine.Replace("‏)", ")")
        TextLine = TextLine.Replace("•", "")
        TextLine = TextLine.Replace("…(", "(")
        TextLine = TextLine.Replace("·(", "(")

        TextLine = TextLine.TrimEnd(".")
        TextLine = TextLine.TrimStart(".")
        TextLine = TextLine.Replace("((", "(")
        TextLine = TextLine.Replace("()", "")
        TextLine = TextLine.Replace("(", "(")
        TextLine = TextLine.Replace("( ", "")
        TextLine = TextLine.Replace("‌", "")
        TextLine = TextLine.Replace("😂", "")
        TextLine = TextLine.Replace("♣", "")
        TextLine = TextLine.Replace("♠", "")
        TextLine = TextLine.Replace("♦", "")
        TextLine = TextLine.Replace("♥", "")
        TextLine = TextLine.Replace("♧", "")
        TextLine = TextLine.Replace("­", "")
        TextLine = TextLine.Replace("️", "")
        TextLine = TextLine.Replace("✯", "")
        TextLine = TextLine.Replace("‛", "")
        TextLine = TextLine.Replace("➰", "")
        TextLine = TextLine.Replace("‍", "")
        TextLine = TextLine.Replace("♏", "")
        TextLine = TextLine.Replace("®", "")
        TextLine = TextLine.Replace("�", "")
        TextLine = TextLine.Replace("£", "")
        TextLine = TextLine.Replace("", "")
        TextLine = TextLine.Replace("✌", "")
        TextLine = TextLine.Replace("⇝", "")
        TextLine = TextLine.Replace("⇜", "")
        TextLine = TextLine.Replace("♬", "")
        TextLine = TextLine.Replace("♩", "")
        TextLine = TextLine.Replace("♪", "")
        TextLine = TextLine.Replace("❝", "")
        TextLine = TextLine.Replace("❞", "")
        TextLine = TextLine.Replace("♔", "")
        TextLine = TextLine.Replace("│", "")
        TextLine = TextLine.Replace("☺", "")
        TextLine = TextLine.Replace("¸", "")
        TextLine = TextLine.Replace("♡", "")
        TextLine = TextLine.Replace("★", "")
        TextLine = TextLine.Replace("☆", "")
        TextLine = TextLine.Replace("✴", "")
        TextLine = TextLine.Replace("，", "")
        TextLine = TextLine.Replace("।", "")
        TextLine = TextLine.Replace("॥", "")
        TextLine = TextLine.Replace("¤", "")
        TextLine = TextLine.Replace("¥", "")
        TextLine = TextLine.Replace("÷", "")
        TextLine = TextLine.Replace("↓", "")
        TextLine = TextLine.Replace("–", "")
        TextLine = TextLine.Replace("–", "")
        TextLine = TextLine.Replace("…", "")
        TextLine = TextLine.Replace("¬", "")
        TextLine = TextLine.Replace("·", "")
        TextLine = TextLine.Replace("…", "")
        TextLine = TextLine.Replace("✆", "")
        TextLine = TextLine.Replace("….", "")

        ' Removes the other language characters

        Dim txtPattern As String = "[a-z]"
        If Regex.IsMatch(TextLine, "\p{IsTamil}") Then
            Dim myString As String = TextLine.Trim()
            Dim myTEE As TextElementEnumerator = StringInfo.GetTextElementEnumerator(myString)
            myTEE.Reset()
            Dim A As String = ""
            Dim s As String
            Dim ss As String = ""
            While myTEE.MoveNext()
                A = ""
                A = myTEE.Current
                s = A.ToString
                Dim withoutSpecial = New String(s.Where(Function(c) [Char].IsLetterOrDigit(c) OrElse [Char].IsWhiteSpace(c) OrElse [Char].IsSeparator(c)).ToArray())
                Dim hexVal As Integer
                If s <> withoutSpecial Then
                    If Not Regex.IsMatch(s, "\p{IsTamil}") Then
                        If Not s = "." Then
                            If Not s = "·" Then
                                If Not s = "¼" Then
                                    If Not s = "½" Then
                                        If Not s = "₹" Then
                                            If Not s = "¬" Then
                                                If Not s = "¢" Then
                                                    If Not s = "😁" Then
                                                        If Not s = "⭐" Then
                                                            If Not s = "﻿" Then
                                                                If Not s = "😜" Then
                                                                    If Not s = "👎" Then
                                                                        If Not s = "👇" Then
                                                                            If Not s = "🏻" Then
                                                                                If Not s = "😊" Then
                                                                                    If Not s = "🙏" Then
                                                                                        If Not s = "🏽" Then
                                                                                            If Not s = "​" Then
                                                                                                If Not s = "😱" Then
                                                                                                    If Not s = "" Then
                                                                                                        If Not s = "‪" Then
                                                                                                            If Not s = "‬" Then
                                                                                                                If Not s = "😭" Then
                                                                                                                    If Not s = "○" Then
                                                                                                                        If Not s = "👀" Then
                                                                                                                            If Not s = "📱" Then
                                                                                                                                If Not s = "😢" Then
                                                                                                                                    If Not s = "😟" Then
                                                                                                                                        If Not s = "🌱" Then
                                                                                                                                            If Not s = "🏠" Then
                                                                                                                                                If Not s = "👫" Then
                                                                                                                                                    If Not s = "😷" Then
                                                                                                                                                        If Not s = "👰" Then
                                                                                                                                                            If Not s = "😘" Then
                                                                                                                                                                If Not s = "💪" Then
                                                                                                                                                                    If Not s = "😎" Then
                                                                                                                                                                        If Not s = "😉" Then
                                                                                                                                                                            If Not s = "🙄" Then
                                                                                                                                                                                If Not s = "😝" Then
                                                                                                                                                                                    If Not s = "😆" Then
                                                                                                                                                                                        If Not s = "😄" Then
                                                                                                                                                                                            If Not s = "👸" Then
                                                                                                                                                                                                If Not s = "💋" Then
                                                                                                                                                                                                    If Not s = "󾌩" Then
                                                                                                                                                                                                        If Not s = "👊" Then
                                                                                                                                                                                                            If Not s = "" Then
                                                                                                                                                                                                                If Not s = "🎂" Then
                                                                                                                                                                                                                    If Not s = "🎉" Then
                                                                                                                                                                                                                        If Not s = "👍" Then
                                                                                                                                                                                                                            If Not s = "👌" Then
                                                                                                                                                                                                                                If Not s = "🎊" Then
                                                                                                                                                                                                                                    If Not s = "📢" Then
                                                                                                                                                                                                                                        If Not s = "😍" Then
                                                                                                                                                                                                                                            If Not s = "💞" Then
                                                                                                                                                                                                                                                If Not s = "😃" Then
                                                                                                                                                                                                                                                    If Not s = "😋" Then
                                                                                                                                                                                                                                                        If Not s = "🍷" Then
                                                                                                                                                                                                                                                            If Not s = "🍻" Then
                                                                                                                                                                                                                                                                If Not s = "🌄" Then
                                                                                                                                                                                                                                                                    If Not s = "🙍" Then
                                                                                                                                                                                                                                                                        If Not s = "😒" Then
                                                                                                                                                                                                                                                                            If Not s = "😞" Then
                                                                                                                                                                                                                                                                                If Not s = "😨" Then
                                                                                                                                                                                                                                                                                    If Not s = "😖" Then
                                                                                                                                                                                                                                                                                        If Not s = "😐" Then
                                                                                                                                                                                                                                                                                            If Not s = "😏" Then
                                                                                                                                                                                                                                                                                                If Not s = "🐒" Then
                                                                                                                                                                                                                                                                                                    If Not s = "👈" Then
                                                                                                                                                                                                                                                                                                        If Not s = "°" Then
                                                                                                                                                                                                                                                                                                            If Not s = "§" Then
                                                                                                                                                                                                                                                                                                                If Not s = "😼" Then
                                                                                                                                                                                                                                                                                                                    If Not s = "👏" Then
                                                                                                                                                                                                                                                                                                                        If Not s = "😸" Then
                                                                                                                                                                                                                                                                                                                            If Not s = "🙌" Then
                                                                                                                                                                                                                                                                                                                                If Not s = "😥" Then
                                                                                                                                                                                                                                                                                                                                    If Not s = "×" Then
                                                                                                                                                                                                                                                                                                                                        If Not s = "🏼" Then
                                                                                                                                                                                                                                                                                                                                            If Not s = "😛" Then
                                                                                                                                                                                                                                                                                                                                                If Not s = "😩" Then
                                                                                                                                                                                                                                                                                                                                                    If Not s = "😛" Then
                                                                                                                                                                                                                                                                                                                                                        If Not s = "😀" Then
                                                                                                                                                                                                                                                                                                                                                            If Not s = "😯" Then
                                                                                                                                                                                                                                                                                                                                                                If Not s = "⛪" Then
                                                                                                                                                                                                                                                                                                                                                                    If Not s = "👮" Then
                                                                                                                                                                                                                                                                                                                                                                        If Not s = "👂" Then
                                                                                                                                                                                                                                                                                                                                                                            If Not s = "👃" Then
                                                                                                                                                                                                                                                                                                                                                                                If Not s = "👄" Then
                                                                                                                                                                                                                                                                                                                                                                                    If Not s = "✋" Then
                                                                                                                                                                                                                                                                                                                                                                                        If Not s = "👕" Then
                                                                                                                                                                                                                                                                                                                                                                                            If Not s = "👖" Then
                                                                                                                                                                                                                                                                                                                                                                                                If Not s = "👞" Then
                                                                                                                                                                                                                                                                                                                                                                                                    If Not s = "" Then
                                                                                                                                                                                                                                                                                                                                                                                                        If Not s = "³" Then
                                                                                                                                                                                                                                                                                                                                                                                                            If Not s = "¡" Then
                                                                                                                                                                                                                                                                                                                                                                                                                If Not s = "²" Then
                                                                                                                                                                                                                                                                                                                                                                                                                    If Not s = "◦" Then
                                                                                                                                                                                                                                                                                                                                                                                                                        If Not s = "″" Then
                                                                                                                                                                                                                                                                                                                                                                                                                            hexVal = Hex(Strings.Asc(s.ToString()))
                                                                                                                                                                                                                                                                                                                                                                                                                            If hexVal = 93 Or hexVal = 94 Then
                                                                                                                                                                                                                                                                                                                                                                                                                                s = s.Replace(s, "")
                                                                                                                                                                                                                                                                                                                                                                                                                            End If
                                                                                                                                                                                                                                                                                                                                                                                                                        End If
                                                                                                                                                                                                                                                                                                                                                                                                                    End If
                                                                                                                                                                                                                                                                                                                                                                                                                End If
                                                                                                                                                                                                                                                                                                                                                                                                            End If
                                                                                                                                                                                                                                                                                                                                                                                                        End If
                                                                                                                                                                                                                                                                                                                                                                                                    End If
                                                                                                                                                                                                                                                                                                                                                                                                End If
                                                                                                                                                                                                                                                                                                                                                                                            End If
                                                                                                                                                                                                                                                                                                                                                                                        End If
                                                                                                                                                                                                                                                                                                                                                                                    End If
                                                                                                                                                                                                                                                                                                                                                                                End If
                                                                                                                                                                                                                                                                                                                                                                            End If
                                                                                                                                                                                                                                                                                                                                                                        End If
                                                                                                                                                                                                                                                                                                                                                                    End If
                                                                                                                                                                                                                                                                                                                                                                End If
                                                                                                                                                                                                                                                                                                                                                            End If
                                                                                                                                                                                                                                                                                                                                                        End If
                                                                                                                                                                                                                                                                                                                                                    End If
                                                                                                                                                                                                                                                                                                                                                End If
                                                                                                                                                                                                                                                                                                                                            End If
                                                                                                                                                                                                                                                                                                                                        End If
                                                                                                                                                                                                                                                                                                                                    End If
                                                                                                                                                                                                                                                                                                                                End If
                                                                                                                                                                                                                                                                                                                            End If
                                                                                                                                                                                                                                                                                                                        End If
                                                                                                                                                                                                                                                                                                                    End If
                                                                                                                                                                                                                                                                                                                End If
                                                                                                                                                                                                                                                                                                            End If
                                                                                                                                                                                                                                                                                                        End If
                                                                                                                                                                                                                                                                                                    End If
                                                                                                                                                                                                                                                                                                End If
                                                                                                                                                                                                                                                                                            End If
                                                                                                                                                                                                                                                                                        End If
                                                                                                                                                                                                                                                                                    End If
                                                                                                                                                                                                                                                                                End If
                                                                                                                                                                                                                                                                            End If
                                                                                                                                                                                                                                                                        End If
                                                                                                                                                                                                                                                                    End If
                                                                                                                                                                                                                                                                End If
                                                                                                                                                                                                                                                            End If
                                                                                                                                                                                                                                                        End If
                                                                                                                                                                                                                                                    End If
                                                                                                                                                                                                                                                End If
                                                                                                                                                                                                                                            End If
                                                                                                                                                                                                                                        End If
                                                                                                                                                                                                                                    End If
                                                                                                                                                                                                                                End If
                                                                                                                                                                                                                            End If
                                                                                                                                                                                                                        End If
                                                                                                                                                                                                                    End If
                                                                                                                                                                                                                End If
                                                                                                                                                                                                            End If
                                                                                                                                                                                                        End If
                                                                                                                                                                                                    End If
                                                                                                                                                                                                End If
                                                                                                                                                                                            End If
                                                                                                                                                                                        End If
                                                                                                                                                                                    End If
                                                                                                                                                                                End If
                                                                                                                                                                            End If
                                                                                                                                                                        End If
                                                                                                                                                                    End If
                                                                                                                                                                End If
                                                                                                                                                            End If
                                                                                                                                                        End If
                                                                                                                                                    End If
                                                                                                                                                End If
                                                                                                                                            End If
                                                                                                                                        End If
                                                                                                                                    End If
                                                                                                                                End If
                                                                                                                            End If
                                                                                                                        End If
                                                                                                                    End If
                                                                                                                End If
                                                                                                            End If
                                                                                                        End If
                                                                                                    End If
                                                                                                End If
                                                                                            End If
                                                                                        End If
                                                                                    End If
                                                                                End If
                                                                            End If
                                                                        End If
                                                                    End If
                                                                End If
                                                            End If
                                                        End If
                                                    End If
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
                ss = ss & s
            End While
            TextLine = ss.ToString
        End If
        Return TextLine
    End Function

    Private Function searchWords(ByVal TextLine As String) As String
        'Searching the Domain words
        If (Not System.IO.Directory.Exists(output)) Then
            System.IO.Directory.CreateDirectory(output)
        End If
        For Each word As String In DbWords
            wrd = word.Split("|"c)
            wr = Trim(wrd(0))
            wr1 = Trim(wrd(1))
            If wr.Contains("(") Then
                wrd1 = wr.Split("("c)
                word1 = Trim(wrd1(0))
                word2 = Trim(wrd1(1))
                word2 = word2.Replace(")", "")
            Else
                word1 = Trim(wr)
            End If
            If Len(Trim(word1)) > 0 AndAlso Len(Trim(TextLine)) > 0 Then
                If Trim(word1) = Trim(TextLine) Then
                    'If (Trim(wr1) = "Jok") Then
                    '    Dim R As DataRow = dtable1.NewRow
                    '    R("WORDS") = Trim(word1).ToString
                    '    R("DOMAIN NAME") = "ஜோக்ஸ்_Jokes"
                    '    cnt1 += 1
                    '    R("Count") = cnt1
                    '    dtable1.Rows.Add(R)
                    '    sb.Append(Trim(R("WORDS"))).AppendLine()
                    '    Dim view1 As DataView = dtable1.DefaultView
                    '    view1.Sort = "Count DESC"
                    '    dtable1 = view1.ToTable
                    '    outputFile = output & "\" & R("DOMAIN NAME") & "_" & fileDateTime & ".txt"
                    '    System.IO.File.WriteAllText(outputFile, sb.ToString, Encoding.UTF8)
                    'ElseIf (Trim(wr1) = "Dev") Then
                    '    Dim R1 As DataRow = dtable2.NewRow
                    '    R1("WORDS") = Trim(word1).ToString
                    '    R1("DOMAIN NAME") = "ஆன்மீகம்_Devotional"
                    '    cnt2 += 1
                    '    R1("Count") = cnt2
                    '    dtable2.Rows.Add(R1)
                    '    sb1.Append(Trim(R1("WORDS"))).AppendLine()
                    '    Dim view2 As DataView = dtable2.DefaultView
                    '    view2.Sort = "Count DESC"
                    '    dtable2 = view2.ToTable
                    '    outputFile = output & "\" & R1("DOMAIN NAME") & "_" & fileDateTime & ".txt"
                    '    System.IO.File.WriteAllText(outputFile, sb1.ToString, Encoding.UTF8)
                    'ElseIf (Trim(wr1) = "DEH") Then
                    '    Dim R2 As DataRow = dtable3.NewRow
                    '    R2("WORDS") = Trim(word1).ToString
                    '    R2("DOMAIN NAME") = "ஆன்மீகம் இந்து மதம் தவிர_Devotional except Hindu Religion"
                    '    cnt3 += 1
                    '    R2("Count") = cnt3
                    '    dtable3.Rows.Add(R2)
                    '    sb2.Append(Trim(R2("WORDS"))).AppendLine()
                    '    Dim view3 As DataView = dtable3.DefaultView
                    '    view3.Sort = "Count DESC"
                    '    dtable3 = view3.ToTable
                    '    outputFile = output & "\" & R2("DOMAIN NAME") & "_" & fileDateTime & ".txt"
                    '    System.IO.File.WriteAllText(outputFile, sb2.ToString, Encoding.UTF8)
                    'Else
                    If (Trim(wr1) = "AC") Then
                        Dim R3 As DataRow = dtable4.NewRow
                        R3("WORDS") = Trim(word1).ToString
                        R3("DOMAIN NAME") = "கலை,கலாச்சாரம்_Art&Culture"
                        cnt4 += 1
                        R3("Count") = cnt4
                        dtable4.Rows.Add(R3)
                        sb3.Append(Trim(R3("WORDS"))).AppendLine()
                        Dim view4 As DataView = dtable4.DefaultView
                        view4.Sort = "Count DESC"
                        dtable4 = view4.ToTable
                        outputFile = output & "\" & R3("DOMAIN NAME") & "_" & fileDateTime & ".txt"
                        System.IO.File.WriteAllText(outputFile, sb3.ToString, Encoding.UTF8)
                        'ElseIf (Trim(wr1) = "SRel") Then
                        '    Dim R4 As DataRow = dtable5.NewRow
                        '    R4("WORDS") = Trim(word1).ToString
                        '    R4("DOMAIN NAME") = "சமயம்_SReligion"
                        '    cnt5 += 1
                        '    R4("Count") = cnt5
                        '    dtable5.Rows.Add(R4)
                        '    sb4.Append(Trim(R4("WORDS"))).AppendLine()
                        '    Dim view5 As DataView = dtable5.DefaultView
                        '    view5.Sort = "Count DESC"
                        '    dtable5 = view5.ToTable
                        '    outputFile = output & "\" & R4("DOMAIN NAME") & "_" & fileDateTime & ".txt"
                        '    System.IO.File.WriteAllText(outputFile, sb4.ToString, Encoding.UTF8)
                    ElseIf (Trim(wr1) = "Cok") Then
                        Dim R5 As DataRow = dtable6.NewRow
                        R5("WORDS") = Trim(word1).ToString
                        R5("DOMAIN NAME") = "சமையல்_Cookery"
                        cnt6 += 1
                        R5("Count") = cnt6
                        dtable6.Rows.Add(R5)
                        sb5.Append(Trim(R5("WORDS"))).AppendLine()
                        Dim view6 As DataView = dtable6.DefaultView
                        view6.Sort = "Count DESC"
                        dtable6 = view6.ToTable
                        outputFile = output & "\" & R5("DOMAIN NAME") & "_" & fileDateTime & ".txt"
                        System.IO.File.WriteAllText(outputFile, sb5.ToString, Encoding.UTF8)
                    ElseIf (Trim(wr1) = "Cin") Then
                        Dim R6 As DataRow = dtable7.NewRow
                        R6("WORDS") = Trim(word1).ToString
                        R6("DOMAIN NAME") = "சினிமா_Cinema"
                        cnt7 += 1
                        R6("Count") = cnt7
                        dtable7.Rows.Add(R6)
                        sb6.Append(Trim(R6("WORDS"))).AppendLine()
                        Dim view7 As DataView = dtable7.DefaultView
                        view7.Sort = "Count DESC"
                        dtable7 = view7.ToTable
                        outputFile = output & "\" & R6("DOMAIN NAME") & "_" & fileDateTime & ".txt"
                        System.IO.File.WriteAllText(outputFile, sb6.ToString, Encoding.UTF8)
                        'ElseIf (Trim(wr1) = "Rel") Then
                        '    Dim R7 As DataRow = dtable8.NewRow
                        '    R7("WORDS") = Trim(word1).ToString
                        '    R7("DOMAIN NAME") = "மதம்_Religion"
                        '    cnt8 += 1
                        '    R7("Count") = cnt8
                        '    dtable8.Rows.Add(R7)
                        '    sb7.Append(Trim(R7("WORDS"))).AppendLine()
                        '    Dim view8 As DataView = dtable8.DefaultView
                        '    view8.Sort = "Count DESC"
                        '    dtable8 = view8.ToTable
                        '    outputFile = output & "\" & R7("DOMAIN NAME") & "_" & fileDateTime & ".txt"
                        '    System.IO.File.WriteAllText(outputFile, sb7.ToString, Encoding.UTF8)
                    ElseIf (Trim(wr1) = "Med") Then
                        Dim R8 As DataRow = dtable9.NewRow
                        R8("WORDS") = Trim(word1).ToString
                        R8("DOMAIN NAME") = "மருத்துவம்_Medical"
                        cnt9 += 1
                        R8("Count") = cnt9
                        dtable9.Rows.Add(R8)
                        sb8.Append(Trim(R8("WORDS"))).AppendLine()
                        Dim view9 As DataView = dtable9.DefaultView
                        view9.Sort = "Count DESC"
                        dtable9 = view9.ToTable
                        outputFile = output & "\" & R8("DOMAIN NAME") & "_" & fileDateTime & ".txt"
                        System.IO.File.WriteAllText(outputFile, sb8.ToString, Encoding.UTF8)
                    ElseIf (Trim(wr1) = "Agr") Then
                        Dim R9 As DataRow = dtable10.NewRow
                        R9("WORDS") = Trim(word1).ToString
                        R9("DOMAIN NAME") = "விவசாயம்_Agriculture"
                        cnt10 += 1
                        R9("Count") = cnt10
                        dtable10.Rows.Add(R9)
                        sb9.Append(Trim(R9("WORDS"))).AppendLine()
                        Dim view10 As DataView = dtable10.DefaultView
                        view10.Sort = "Count DESC"
                        dtable10 = view10.ToTable
                        outputFile = output & "\" & R9("DOMAIN NAME") & "_" & fileDateTime & ".txt"
                        System.IO.File.WriteAllText(outputFile, sb9.ToString, Encoding.UTF8)
                    ElseIf (Trim(wr1) = "Spo") Then
                        Dim R10 As DataRow = dtable11.NewRow
                        R10("WORDS") = Trim(word1).ToString
                        R10("DOMAIN NAME") = "விளையாட்டு_Sports"
                        cnt11 += 1
                        R10("Count") = cnt11
                        dtable11.Rows.Add(R10)

                        sb10.Append(Trim(R10("WORDS"))).AppendLine()
                        Dim view11 As DataView = dtable11.DefaultView
                        view11.Sort = "Count DESC"
                        dtable11 = view11.ToTable
                        outputFile = output & "\" & R10("DOMAIN NAME") & "_" & fileDateTime & ".txt"
                        System.IO.File.WriteAllText(outputFile, sb10.ToString, Encoding.UTF8)
                        'ElseIf (Trim(wr1) = "Ast") Then
                        '    Dim R11 As DataRow = dtable12.NewRow
                        '    R11("WORDS") = Trim(word1).ToString
                        '    R11("DOMAIN NAME") = "ஜோதிடம்_Astrology"
                        '    cnt12 += 1
                        '    R11("Count") = cnt12
                        '    dtable12.Rows.Add(R11)
                        '    sb11.Append(Trim(R11("WORDS"))).AppendLine()
                        '    Dim view12 As DataView = dtable12.DefaultView
                        '    view12.Sort = "Count DESC"
                        '    dtable12 = view12.ToTable
                        '    outputFile = output & "\" & R11("DOMAIN NAME") & "_" & fileDateTime & ".txt"
                        '    System.IO.File.WriteAllText(outputFile, sb11.ToString, Encoding.UTF8)
                    ElseIf (Trim(wr1) = "DR") Then
                        Dim R12 As DataRow = dtable13.NewRow
                        R12("WORDS") = Trim(word1).ToString
                        R12("DOMAIN NAME") = "ஆன்மீகம் & சமயம்_Devotional & Religion"
                        cnt13 += 1
                        R12("Count") = cnt13
                        dtable13.Rows.Add(R12)
                        sb12.Append(Trim(R12("WORDS"))).AppendLine()
                        Dim view13 As DataView = dtable13.DefaultView
                        view13.Sort = "Count DESC"
                        dtable13 = view13.ToTable
                        outputFile = output & "\" & R12("DOMAIN NAME") & "_" & fileDateTime & ".txt"
                        System.IO.File.WriteAllText(outputFile, sb12.ToString, Encoding.UTF8)
                    ElseIf (Trim(wr1) = "Edu") Then
                        Dim R13 As DataRow = dtable14.NewRow
                        R13("WORDS") = Trim(word1).ToString
                        R13("DOMAIN NAME") = "கல்விச் செய்தி_EDUCATIONAL NEWS"
                        cnt14 += 1
                        R13("Count") = cnt14
                        dtable14.Rows.Add(R13)
                        sb13.Append(Trim(R13("WORDS"))).AppendLine()
                        Dim view14 As DataView = dtable14.DefaultView
                        view14.Sort = "Count DESC"
                        dtable14 = view14.ToTable
                        outputFile = output & "\" & R13("DOMAIN NAME") & "_" & fileDateTime & ".txt"
                        System.IO.File.WriteAllText(outputFile, sb13.ToString, Encoding.UTF8)
                    ElseIf (Trim(wr1) = "Soc") Then
                        Dim R14 As DataRow = dtable15.NewRow
                        R14("WORDS") = Trim(word1).ToString
                        R14("DOMAIN NAME") = "சமூகம்_Society"
                        cnt15 += 1
                        R14("Count") = cnt15
                        dtable15.Rows.Add(R14)
                        sb14.Append(Trim(R14("WORDS"))).AppendLine()
                        Dim view15 As DataView = dtable15.DefaultView
                        view15.Sort = "Count DESC"
                        dtable15 = view15.ToTable
                        outputFile = output & "\" & R14("DOMAIN NAME") & "_" & fileDateTime & ".txt"
                        System.IO.File.WriteAllText(outputFile, sb14.ToString, Encoding.UTF8)
                    ElseIf (Trim(wr1) = "Tec") Then
                        Dim R15 As DataRow = dtable16.NewRow
                        R15("WORDS") = Trim(word1).ToString
                        R15("DOMAIN NAME") = "தொழில்நுட்பம்_Techonology"
                        cnt16 += 1
                        R15("Count") = cnt16
                        dtable16.Rows.Add(R15)
                        sb15.Append(Trim(R15("WORDS"))).AppendLine()
                        Dim view16 As DataView = dtable16.DefaultView
                        view16.Sort = "Count DESC"
                        dtable16 = view16.ToTable
                        outputFile = output & "\" & R15("DOMAIN NAME") & "_" & fileDateTime & ".txt"
                        System.IO.File.WriteAllText(outputFile, sb15.ToString, Encoding.UTF8)
                    ElseIf (Trim(wr1) = "Tou") Then
                        Dim R16 As DataRow = dtable17.NewRow
                        R16("WORDS") = Trim(word1).ToString
                        R16("DOMAIN NAME") = "சுற்றுலா_Tourism"
                        cnt17 += 1
                        R16("Count") = cnt17
                        dtable17.Rows.Add(R16)
                        sb16.Append(Trim(R16("WORDS"))).AppendLine()
                        Dim view17 As DataView = dtable17.DefaultView
                        view17.Sort = "Count DESC"
                        dtable17 = view17.ToTable
                        outputFile = output & "\" & R16("DOMAIN NAME") & "_" & fileDateTime & ".txt"
                        System.IO.File.WriteAllText(outputFile, sb16.ToString, Encoding.UTF8)
                    End If
                End If
            End If
        Next
        Return TextLine
    End Function

    Private Sub Grid_Apperance_Con()


        ' Set the column header style.

        'Dim f As New System.Drawing.Font("Latha", 9)
        Dim f As New System.Drawing.Font("Verdana", 8)
        ' Assign the font to the control
        DataGridView1.Font = f

        Dim columnHeaderStyle As New DataGridViewCellStyle()
        columnHeaderStyle.Font = New Font("Verdana", 8, FontStyle.Bold)
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridView1.ColumnHeadersDefaultCellStyle = columnHeaderStyle

        DataGridView1.EnableHeadersVisualStyles = False

        'Makes the row header color
        DataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black
        DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.YellowGreen
        DataGridView1.RowHeadersDefaultCellStyle.BackColor = Color.YellowGreen
        'Me.DataGridView1.DefaultCellStyle.ForeColor = Color.Coral
        ' Change back color of each row
        Me.DataGridView1.RowsDefaultCellStyle.BackColor = Color.AliceBlue

        DataGridView1.DefaultCellStyle.SelectionBackColor = Color.AliceBlue
        DataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black
        ' DataGridView1 GridLine Color
        'Me.DataGridView1.GridColor = Color.Blue
        ' Change Grid Border Style
        Me.DataGridView1.BorderStyle = BorderStyle.Fixed3D

        'DataGridView1.Columns("Result").Width = 800
        DataGridView1.RowHeadersVisible = False
        DataGridView1.AllowUserToResizeColumns = False
        DataGridView1.MultiSelect = False
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells

        Helper.SetGridViewSortState(DataGridView1, DataGridViewColumnSortMode.NotSortable)
        DataGridView1.ReadOnly = True
        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect

        'To remove last empty row
        DataGridView1.AllowUserToAddRows = False

    End Sub

    Private Sub Clear_Count()
        cnt1 = 0
        cnt2 = 0
        cnt3 = 0
        cnt4 = 0
        cnt5 = 0
        cnt6 = 0
        cnt7 = 0
        cnt8 = 0
        cnt9 = 0
        cnt10 = 0
        cnt11 = 0
        cnt12 = 0
        cnt13 = 0
        cnt14 = 0
        cnt15 = 0
        cnt16 = 0
        cnt17 = 0
    End Sub

#End Region

#Region "CheckListBox"

    Private Sub chckList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chckList.SelectedIndexChanged
        'Changes selected Items of the checklist box
        If chckList.SelectedIndex = 0 Then
            If chckList.GetItemChecked(0) = False Then
                For idx As Integer = 1 To chckList.Items.Count - 1

                    Me.chckList.SetItemChecked(idx, False)
                Next
            Else
                For idx As Integer = 1 To chckList.Items.Count - 1

                    Me.chckList.SetItemChecked(idx, True)
                Next
            End If
        ElseIf chckList.SelectedIndex > 0 Then
            If chckList.CheckedItems.Count = chckList.Items.Count - 1 And chckList.GetItemChecked(0) = False Then
                chckList.SetItemCheckState(0, CheckState.Checked)
            End If
            For idx As Integer = 1 To chckList.Items.Count - 1

                If chckList.GetItemChecked(idx) = False Then
                    chckList.SetItemCheckState(0, CheckState.Unchecked)

                End If
            Next
        End If
    End Sub

#End Region

#Region " BackgroundWorker "

    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        'Identifies the domain words and counts the occurrencce
        'Dim DB_FILE As String = pathText & "\DomainFinalList.txt"
        'DbWords = File.ReadAllLines(DB_FILE)
        'btnFileSelection.Enabled = False
        'grpFileSelection.Enabled = False
        'chckList.Enabled = False
        'If (Not System.IO.Directory.Exists(output)) Then
        '    System.IO.Directory.CreateDirectory(output)
        'End If

        'For j = 0 To chckList.Items.Count - 1
        '    If Not chckList.Items(j) = "Select/UnselectAll" Then
        '        If chckList.GetItemChecked(j) = True Then
        '            Dim INPUT_FILE As String = chckList.Items(j)
        '            If System.IO.File.Exists(INPUT_FILE) = True Then
        '                Dim objReader As New System.IO.StreamReader(INPUT_FILE)
        '                Do While objReader.Peek() <> -1
        '                    TextLine = ""
        '                    TextLine = Trim(objReader.ReadLine())
        '                    TextLine = replaceSpclChar(TextLine)
        '                    If TextLine.Contains(" ") Then
        '                        arySplitwords = TextLine.Split(" "c)
        '                        For k = 0 To UBound(arySplitwords)
        '                            TextLine = arySplitwords(k)
        '                            searchWords(TextLine)
        '                        Next
        '                    Else
        '                        TextLine = Trim(TextLine.ToString)
        '                        searchWords(TextLine)
        '                    End If
        '                Loop
        '                objReader.Close()
        '            End If
        '        End If
        '    End If
        'Next
        'Dim dr As DataRow = dtable.NewRow
        'For i = 0 To dtable1.Rows.Count - 1
        '    If (i = 0) Then
        '        dr("DOMAIN NAME") = dtable1.Rows(i)("DOMAIN NAME")
        '        dr("Count") = dtable1.Rows(i)("Count")
        '        dtable.Rows.Add(dr.ItemArray)
        '        tot_sb.Append(Trim(dr("DOMAIN NAME")) & Trim(" -- ") & Trim(dr("Count"))).AppendLine()
        '        Exit For
        '    End If
        'Next
        'For i = 0 To dtable2.Rows.Count - 1
        '    If (i = 0) Then
        '        dr("DOMAIN NAME") = dtable2.Rows(i)("DOMAIN NAME")
        '        dr("Count") = dtable2.Rows(i)("Count")
        '        dtable.Rows.Add(dr.ItemArray)
        '        tot_sb.Append(Trim(dr("DOMAIN NAME")) & Trim(" -- ") & Trim(dr("Count"))).AppendLine()
        '        Exit For
        '    End If
        'Next

        'For i = 0 To dtable3.Rows.Count - 1
        '    If (i = 0) Then

        '        dr("DOMAIN NAME") = dtable3.Rows(i)("DOMAIN NAME")
        '        dr("Count") = dtable3.Rows(i)("Count")
        '        dtable.Rows.Add(dr.ItemArray)
        '        tot_sb.Append(Trim(dr("DOMAIN NAME")) & Trim(" -- ") & Trim(dr("Count"))).AppendLine()
        '        Exit For
        '    End If
        'Next
        'For i = 0 To dtable4.Rows.Count - 1
        '    If (i = 0) Then
        '        dr("DOMAIN NAME") = dtable4.Rows(i)("DOMAIN NAME")
        '        dr("Count") = dtable4.Rows(i)("Count")
        '        dtable.Rows.Add(dr.ItemArray)
        '        tot_sb.Append(Trim(dr("DOMAIN NAME")) & Trim(" -- ") & Trim(dr("Count"))).AppendLine()
        '        Exit For
        '    End If
        'Next
        'For i = 0 To dtable5.Rows.Count - 1
        '    If (i = 0) Then
        '        dr("DOMAIN NAME") = dtable5.Rows(i)("DOMAIN NAME")
        '        dr("Count") = dtable5.Rows(i)("Count")
        '        dtable.Rows.Add(dr.ItemArray)
        '        tot_sb.Append(Trim(dr("DOMAIN NAME")) & Trim(" -- ") & Trim(dr("Count"))).AppendLine()
        '        Exit For
        '    End If
        'Next
        'For i = 0 To dtable6.Rows.Count - 1
        '    If (i = 0) Then
        '        dr("DOMAIN NAME") = dtable6.Rows(i)("DOMAIN NAME")
        '        dr("Count") = dtable6.Rows(i)("Count")
        '        dtable.Rows.Add(dr.ItemArray)
        '        tot_sb.Append(Trim(dr("DOMAIN NAME")) & Trim(" -- ") & Trim(dr("Count"))).AppendLine()
        '        Exit For
        '    End If
        'Next
        'For i = 0 To dtable7.Rows.Count - 1
        '    If (i = 0) Then
        '        dr("DOMAIN NAME") = dtable7.Rows(i)("DOMAIN NAME")
        '        dr("Count") = dtable7.Rows(i)("Count")
        '        dtable.Rows.Add(dr.ItemArray)
        '        tot_sb.Append(Trim(dr("DOMAIN NAME")) & Trim(" -- ") & Trim(dr("Count"))).AppendLine()
        '        Exit For
        '    End If
        'Next
        'For i = 0 To dtable8.Rows.Count - 1
        '    If (i = 0) Then
        '        dr("DOMAIN NAME") = dtable8.Rows(i)("DOMAIN NAME")
        '        dr("Count") = dtable8.Rows(i)("Count")
        '        dtable.Rows.Add(dr.ItemArray)
        '        tot_sb.Append(Trim(dr("DOMAIN NAME")) & Trim(" -- ") & Trim(dr("Count"))).AppendLine()
        '        Exit For
        '    End If
        'Next
        'For i = 0 To dtable9.Rows.Count - 1
        '    If (i = 0) Then
        '        dr("DOMAIN NAME") = dtable9.Rows(i)("DOMAIN NAME")
        '        dr("Count") = dtable9.Rows(i)("Count")
        '        dtable.Rows.Add(dr.ItemArray)
        '        tot_sb.Append(Trim(dr("DOMAIN NAME")) & Trim(" -- ") & Trim(dr("Count"))).AppendLine()
        '        Exit For
        '    End If
        'Next
        'For i = 0 To dtable10.Rows.Count - 1
        '    If (i = 0) Then
        '        dr("DOMAIN NAME") = dtable10.Rows(i)("DOMAIN NAME")
        '        dr("Count") = dtable10.Rows(i)("Count")
        '        dtable.Rows.Add(dr.ItemArray)
        '        tot_sb.Append(Trim(dr("DOMAIN NAME")) & Trim(" -- ") & Trim(dr("Count"))).AppendLine()
        '        Exit For
        '    End If
        'Next
        'For i = 0 To dtable11.Rows.Count - 1
        '    If (i = 0) Then
        '        dr("DOMAIN NAME") = dtable11.Rows(i)("DOMAIN NAME")
        '        dr("Count") = dtable11.Rows(i)("Count")
        '        dtable.Rows.Add(dr.ItemArray)
        '        tot_sb.Append(Trim(dr("DOMAIN NAME")) & Trim(" -- ") & Trim(dr("Count"))).AppendLine()
        '        Exit For
        '    End If
        'Next
        'For i = 0 To dtable12.Rows.Count - 1
        '    If (i = 0) Then
        '        dr("DOMAIN NAME") = dtable12.Rows(i)("DOMAIN NAME")
        '        dr("Count") = dtable12.Rows(i)("Count")
        '        dtable.Rows.Add(dr.ItemArray)
        '        tot_sb.Append(Trim(dr("DOMAIN NAME")) & Trim(" -- ") & Trim(dr("Count"))).AppendLine()
        '        Exit For
        '    End If
        'Next
        'For i = 0 To dtable13.Rows.Count - 1
        '    If (i = 0) Then
        '        dr("DOMAIN NAME") = dtable13.Rows(i)("DOMAIN NAME")
        '        dr("Count") = dtable13.Rows(i)("Count")
        '        dtable.Rows.Add(dr.ItemArray)
        '        tot_sb.Append(Trim(dr("DOMAIN NAME")) & Trim(" -- ") & Trim(dr("Count"))).AppendLine()
        '        Exit For
        '    End If
        'Next
        'For i = 0 To dtable14.Rows.Count - 1
        '    If (i = 0) Then
        '        dr("DOMAIN NAME") = dtable14.Rows(i)("DOMAIN NAME")
        '        dr("Count") = dtable14.Rows(i)("Count")
        '        dtable.Rows.Add(dr.ItemArray)
        '        tot_sb.Append(Trim(dr("DOMAIN NAME")) & Trim(" -- ") & Trim(dr("Count"))).AppendLine()
        '        Exit For
        '    End If
        'Next
        'For i = 0 To dtable15.Rows.Count - 1
        '    If (i = 0) Then
        '        dr("DOMAIN NAME") = dtable15.Rows(i)("DOMAIN NAME")
        '        dr("Count") = dtable15.Rows(i)("Count")
        '        dtable.Rows.Add(dr.ItemArray)
        '        tot_sb.Append(Trim(dr("DOMAIN NAME")) & Trim(" -- ") & Trim(dr("Count"))).AppendLine()
        '        Exit For
        '    End If
        'Next
        'For i = 0 To dtable16.Rows.Count - 1
        '    If (i = 0) Then
        '        dr("DOMAIN NAME") = dtable16.Rows(i)("DOMAIN NAME")
        '        dr("Count") = dtable16.Rows(i)("Count")
        '        dtable.Rows.Add(dr.ItemArray)
        '        tot_sb.Append(Trim(dr("DOMAIN NAME")) & Trim(" -- ") & Trim(dr("Count"))).AppendLine()
        '        Exit For
        '    End If
        'Next
        'For i = 0 To dtable17.Rows.Count - 1
        '    If (i = 0) Then
        '        dr("DOMAIN NAME") = dtable17.Rows(i)("DOMAIN NAME")
        '        dr("Count") = dtable17.Rows(i)("Count")
        '        dtable.Rows.Add(dr.ItemArray)
        '        tot_sb.Append(Trim(dr("DOMAIN NAME")) & Trim(" -- ") & Trim(dr("Count"))).AppendLine()
        '        Exit For
        '    End If
        'Next
        'Dim view As DataView = dtable.DefaultView
        'view.Sort = "Count DESC"
        'DataGridView1.DataSource = view
        'DataGridView1.Columns("DOMAIN NAME").Width = 300
        'DataGridView1.Columns("Count").Width = 200
        'Grid_Apperance_Con()
        'outputFile = output & "\DOMAINS & COUNTS_" & fileDateTime & ".txt"
        'System.IO.File.WriteAllText(outputFile, tot_sb.ToString, Encoding.UTF8)
        'Me.Cursor = Cursors.Default
        'btnFileSelection.Enabled = True
        'grpFileSelection.Enabled = True
        'chckList.Enabled = True
        'If BackgroundWorker1.IsBusy Then

        '    'Dim worker As BackgroundWorker = New BackgroundWorker()
        '    'worker.WorkerSupportsCancellation = True
        '    'worker.RunWorkerAsync()

        '    'If (BackgroundWorker1.CancellationPending) Then
        '    e.Cancel = True
        '    Return
        '    'End If

        '    'BackgroundWorker1.WorkerSupportsCancellation = True
        '    ''If BackgroundWorker1.CancellationPending Then
        '    ''e.Cancel = True
        '    'Me.BackgroundWorker1.CancelAsync()
        '    'Exit Sub
        '    'End If
        '    'If BackgroundWorker1.WorkerSupportsCancellation Then
        '    'BackgroundWorker1.CancelAsync()
        '    'End If
        '    'Exit Sub

        'End If
    End Sub

    Private Sub BackgroundWorker2_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker2.DoWork
        'loads the file names to the checklist box
        chckList.Items.Add("Select/UnselectAll")
        For Each filename As String In Directory.GetFiles(fldrBrwsDlg.SelectedPath, "*.txt")
            chckList.Items.Add(filename)
        Next
        For c As Integer = 0 To chckList.Items.Count - 1
            chckList.SetItemCheckState(c, CheckState.Checked)
        Next

    End Sub

#End Region
   

End Class
