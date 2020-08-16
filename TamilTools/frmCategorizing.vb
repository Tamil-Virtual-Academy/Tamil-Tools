
#Region " Imports "
Imports System.IO
Imports System.Globalization
Imports System.Data
Imports System.Text.RegularExpressions
Imports System.Text
Imports System.Drawing.Color

#End Region


Public Class frmCategorizingWordsFile

#Region " Declaration "

    ' Variable Declaration

    Dim TextLine As String
    Dim dtable1, dtable2, dtable3, dtable4, dtable5 As New DataTable
    Dim dr1, dr2, dr3, dr4, dr5 As DataRow
    Dim filecontent As String = ""
    Dim pathText As String = My.Application.Info.DirectoryPath
    Dim output As String = pathText & "\output"
    Dim FILE_NAME As String
    Dim arySplitwords() As String
    Dim chkFlag As Boolean = False
    Private btn1_Count As Integer = 0
    Private bg() As String = {"#B3E5FC", "#FFDBA6", "#AAC8FB", "#8D6E63", "#73C5BE", "#f0ffff", "#87CEAC", "#BDD4FF", "#959FD6", "#8097A2", "#A6E8F0", "#B39CDB", "#BDD4FF", "#C47DD1", "#E1EA88", "#F5FFFA", "#E2ECC1", "#E47369", "#EBF1B0", "#F48EB1", "#FDE49B"}
    Private chkcl() As String = {"#E6F7FE", "#FFF3E0", "#E8F0FE", "#EFEBE9", "#E0F2F1", "#fffff0", "#E2F3EB", "#F5FFFA", "#DADEF1", "#ECEFF1", "#E0F7FA", "#EDE7F6", "#fffaf0", "#E5C8EA", "#F9FBE7", "#fffff0", "#fffaf0", "#F8D7D3", "#F9FBE7", "#FCE4EC", "#FEF5DA"}
    Private Count As Integer = 0
    Dim crntClr As String = ""
    Dim chkClr As String = ""
    Dim rcrntClr As String = ""
    Dim rchkClr As String = ""

#End Region

#Region " Form Load "

    Private Sub frmCategorizingWordsFile_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.LinkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel2.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        'Me.BackColor = ColorTranslator.FromHtml(bg(0))
        'chkListBox.BackColor = ColorTranslator.FromHtml(chkcl(0))
        Control.CheckForIllegalCrossThreadCalls = False
        lblOutputPath.Text = ""
        lnkLblOutput.Text = ""
        chkListBox.Items.Clear()
        rbtnSort.Checked = True
        rbtnWDupliChar.Checked = True
        rbtnSingle.Checked = True
        rbtnEnglish.Checked = True
        chckSpclChar.Checked = True
        ProgressBar1.Value = 0
        lblProgressPercentage.Text = "0%"
        loaddt()
        btnFileSelection.Focus()

    End Sub

#End Region

#Region " Button Click "

    Private Sub btnFileSelection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFileSelection.Click
        'Button for choosing a text file(.txt) that you want to categorize.
        'For choosing single files
        If rbtnSingle.Checked = True Then
            OpenFileDialogbox.Title = "Please select a file"
            OpenFileDialogbox.InitialDirectory = "C: temp"
            OpenFileDialogbox.Filter = "TextFiles(*.txt)|*.txt"
            If OpenFileDialogbox.ShowDialog() = Windows.Forms.DialogResult.OK Then
                chkListBox.Items.Add(OpenFileDialogbox.FileName)
                For c As Integer = 0 To chkListBox.Items.Count - 1
                    chkListBox.SetItemCheckState(c, CheckState.Checked)
                Next
            Else
                chkListBox.Items.Clear()
            End If

            'For choosing Multiple Files
        ElseIf rbtnMultiple.Checked = True Then
            FolderBrowserDialog1.ShowNewFolderButton = True
            If FolderBrowserDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
                chkListBox.Items.Add("Select/UnselectAll")
                For Each filename As String In Directory.GetFiles(FolderBrowserDialog1.SelectedPath, "*.txt")
                    chkListBox.Items.Add(filename)
                Next
                For c As Integer = 0 To chkListBox.Items.Count - 1
                    chkListBox.SetItemCheckState(c, CheckState.Checked)
                Next
            Else
                chkListBox.Items.Clear()
            End If
        Else
            If rbtnTamil.Checked = True Then
                MsgBox("கோப்பு தேர்வு வகையினை தேர்வு செய்யவும்")
            ElseIf rbtnEnglish.Checked = True Then
                MsgBox("Please select the type of file selection")
            End If
            grpFileSelection.Focus()
        End If

    End Sub

    Private Sub btnSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        ' Button to execute the overall process., it assigns the files and starts the process.

        If chkListBox.Items.Count > 0 Then
            If chkFlag = False Then
                For l = 0 To chkListBox.Items.Count - 1
                    If chkListBox.GetItemChecked(l) = True Then
                        chkFlag = True
                        Exit For
                    End If
                Next
            End If
            If chkFlag = True Then
                chkFlag = False
                For j = 0 To chkListBox.Items.Count - 1
                    If Not chkListBox.Items(j) = "Select/UnselectAll" Then
                        If chkListBox.GetItemChecked(j) = True Then
                            FILE_NAME = chkListBox.Items(j).ToString
                            If System.IO.File.Exists(FILE_NAME) = True Then
                                Me.Cursor = Cursors.WaitCursor
                                grpLanguage.Enabled = False
                                grpFileSelection.Enabled = False
                                grpSorting.Enabled = False
                                grpDuplication.Enabled = False
                                chckSpclChar.Enabled = False
                                Timer1.Start()
                            End If
                        End If
                    End If
                Next
            Else
                If rbtnTamil.Checked = True Then
                    MsgBox(" ஏதேனும் ஒரு கோப்பினைத் தேர்வு செய்யவும்")
                ElseIf rbtnEnglish.Checked = True Then
                    MsgBox("Please select any one item")
                End If
                chkListBox.Focus()
                Exit Sub
            End If
        Else
            If rbtnTamil.Checked = True Then
                MsgBox(" ஏதேனும் ஒரு அடைவை தேர்வு செய்யவும்")
            ElseIf rbtnEnglish.Checked = True Then
                MsgBox("Please select any folder")
            End If
            btnFileSelection.Focus()
        End If
    End Sub

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        ' Button to reset all the controls to its original state.
        If Me.Cursor = Cursors.Default Then
            Timer1.Stop()
            chkFlag = False
            lblOutputPath.Text = ""
            lnkLblOutput.Text = ""
            chkListBox.Items.Clear()
            ProgressBar1.Value = 0
            lblProgressPercentage.Text = "0%"
            btnFileSelection.Focus()
            grpLanguage.Enabled = True
            grpFileSelection.Enabled = True
            grpSorting.Enabled = True
            grpDuplication.Enabled = True
            chckSpclChar.Enabled = True
            rbtnSort.Checked = True
            rbtnWDupliChar.Checked = True
            chckSpclChar.Checked = True
            rbtnSingle.Checked = True
            rbtnEnglish.Checked = True
            'Me.BackColor = ColorTranslator.FromHtml(bg(0))
            'chkListBox.BackColor = ColorTranslator.FromHtml(chkcl(0))
            Count = 0
            crntClr = ""
            chkClr = ""
            rcrntClr = ""
            rchkClr = ""
            loaddt()
        ElseIf Me.Cursor = Cursors.WaitCursor Then
            MsgBox("In another process please wait....")
        End If
    End Sub

#End Region

#Region " Functions "

    Private Sub loaddt()
        ' Loads new data table when the form loads.

        dtable1 = New DataTable
        dtable1.Columns.Add("WORDS")
        dtable2 = New DataTable
        dtable2.Columns.Add("WORDS")
        dtable3 = New DataTable
        dtable3.Columns.Add("WORDS")
        dtable4 = New DataTable
        dtable4.Columns.Add("WORDS")
        dtable5 = New DataTable
        dtable5.Columns.Add("WORDS")
    End Sub

    Public Function RemoveDuplicateRows(ByVal dTable As DataTable, ByVal colName As String) As DataTable
        ' Removes the duplicate(repeated) word from the data table.

        Dim hTable As New Hashtable()
        Dim duplicateList As New ArrayList()

        For Each drow1 As DataRow In dTable.Rows
            If hTable.Contains(drow1(colName)) Then
                duplicateList.Add(drow1)
            Else
                hTable.Add(drow1(colName), String.Empty)
            End If
        Next

        For Each dRow2 As DataRow In duplicateList
            dTable.Rows.Remove(dRow2)
        Next

        Return dTable
    End Function

    Private Function countChar(ByVal TextLine As String) As String
        ' It calls the replaceSpclChar function which removes the special characters in it.

        If chckSpclChar.Checked = True Then
            TextLine = replaceSpclChar(TextLine)
        End If
        TextLine = TextLine.Trim()
        If TextLine.Trim <> "" Then
            TextLine = TextLine.ToString
        End If
        If Not TextLine Is Nothing Then
            If Not TextLine = "" Then

                If Len(Trim(TextLine)) > 0 Then
                    Dim myString As String = TextLine.Trim()
                    Dim myTEE As TextElementEnumerator = StringInfo.GetTextElementEnumerator(myString)
                    myTEE.Reset()
                    Dim A As String = ""
                    Dim count As Integer
                    While myTEE.MoveNext()
                        A = ""
                        A = myTEE.Current
                        count += 1
                    End While

                    If count = 1 Then
                        dr1 = dtable1.NewRow()
                        dr1.Item("WORDS") = myString
                        dtable1.Rows.Add(dr1)
                        count = 0
                    ElseIf count = 2 Then
                        dr2 = dtable2.NewRow()
                        dr2.Item("WORDS") = myString
                        dtable2.Rows.Add(dr2)
                        count = 0
                    ElseIf count = 3 Then
                        dr3 = dtable3.NewRow()
                        dr3.Item("WORDS") = myString
                        dtable3.Rows.Add(dr3)
                        count = 0
                    ElseIf count = 4 Then
                        dr4 = dtable4.NewRow()
                        dr4.Item("WORDS") = myString
                        dtable4.Rows.Add(dr4)
                        count = 0
                    ElseIf count >= 5 Then
                        dr5 = dtable5.NewRow()
                        dr5.Item("WORDS") = myString
                        dtable5.Rows.Add(dr5)
                        count = 0
                    End If
                End If
            End If
        End If

        Return TextLine
    End Function

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

#End Region

#Region " Timer "

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        'It starts the execution process which includes categorizing the files, sorting, removing duplicate words and special characters from the file.

        Me.Cursor = Cursors.WaitCursor
        ProgressBar1.Increment(1)
        lblProgressPercentage.Text = ProgressBar1.Value & "%"
        If ProgressBar1.Value = ProgressBar1.Maximum Then
            Timer1.Stop()
            dtable1.Rows.Clear()
            dtable2.Rows.Clear()
            dtable3.Rows.Clear()
            dtable4.Rows.Clear()
            dtable5.Rows.Clear()
            For j = 0 To chkListBox.Items.Count - 1
                If Not chkListBox.Items(j) = "Select/UnselectAll" Then
                    If chkListBox.GetItemChecked(j) = True Then
                        Dim FILE_NAME As String = chkListBox.Items(j)
                        If System.IO.File.Exists(FILE_NAME) = True Then

                            ' Analyzing the number of letters in the file and assigning it to data table

                            Dim objReader As New System.IO.StreamReader(FILE_NAME)
                            Do While objReader.Peek() <> -1
                                TextLine = ""
                                TextLine = Trim(objReader.ReadLine())

                                If TextLine.Contains(" ") Then
                                    arySplitwords = TextLine.Split(" "c)
                                    For k = 0 To UBound(arySplitwords)
                                        TextLine = arySplitwords(k)
                                        countChar(TextLine)
                                    Next
                                Else
                                    TextLine = Trim(TextLine.ToString)
                                    countChar(TextLine)
                                End If

                            Loop
                            objReader.Close()

                            ' Here the sorting and duplicate word process has been done and it assigning to the data table
                            ' For removing duplicate words it calls the RemoveDuplicateRows() function.

                            If rbtnSort.Checked = True And rbtnDupliChar.Checked = True Then
                                Dim sortview1 As New DataView(dtable1)
                                sortview1.Sort = "WORDS ASC"

                                Dim sortview2 As New DataView(dtable2)
                                sortview2.Sort = "WORDS ASC"

                                Dim sortview3 As New DataView(dtable3)
                                sortview3.Sort = "WORDS ASC"

                                Dim sortview4 As New DataView(dtable4)
                                sortview4.Sort = "WORDS ASC"

                                Dim sortview5 As New DataView(dtable5)
                                sortview5.Sort = "WORDS ASC"

                            ElseIf rbtnSort.Checked = True And rbtnWDupliChar.Checked = True Then
                                Dim sortview1 As New DataView(dtable1)
                                sortview1.Sort = "WORDS ASC"
                                dtable1 = sortview1.ToTable()
                                RemoveDuplicateRows(dtable1, "WORDS")

                                Dim sortview2 As New DataView(dtable2)
                                sortview2.Sort = "WORDS ASC"
                                dtable2 = sortview2.ToTable()
                                RemoveDuplicateRows(dtable2, "WORDS")

                                Dim sortview3 As New DataView(dtable3)
                                sortview3.Sort = "WORDS ASC"
                                dtable3 = sortview3.ToTable()
                                RemoveDuplicateRows(dtable3, "WORDS")

                                Dim sortview4 As New DataView(dtable4)
                                sortview4.Sort = "WORDS ASC"
                                dtable4 = sortview4.ToTable()
                                RemoveDuplicateRows(dtable4, "WORDS")

                                Dim sortview5 As New DataView(dtable5)
                                sortview5.Sort = "WORDS ASC"
                                dtable5 = sortview5.ToTable()
                                RemoveDuplicateRows(dtable5, "WORDS")

                            ElseIf rbtnUnsort.Checked = True And rbtnDupliChar.Checked = True Then

                                dtable1 = dtable1
                                dtable2 = dtable2
                                dtable3 = dtable3
                                dtable4 = dtable4
                                dtable5 = dtable5

                            ElseIf rbtnUnsort.Checked = True And rbtnWDupliChar.Checked = True Then

                                RemoveDuplicateRows(dtable1, "WORDS")
                                RemoveDuplicateRows(dtable2, "WORDS")
                                RemoveDuplicateRows(dtable3, "WORDS")
                                RemoveDuplicateRows(dtable4, "WORDS")
                                RemoveDuplicateRows(dtable5, "WORDS")
                            Else
                                If rbtnTamil.Checked = True Then
                                    MsgBox(" தேவையான ரேடியோ பொத்தானை தேர்வு செய்யவும்")
                                ElseIf rbtnEnglish.Checked = True Then
                                    MsgBox("Please select the required radio buttons")
                                End If
                            End If
                        Else
                            If rbtnTamil.Checked = True Then
                                MsgBox(" கோப்பு இல்லை..... ஏதேனும் ஒரு கோப்பினை தேர்வு செய்யவும்")
                            ElseIf rbtnEnglish.Checked = True Then
                                MsgBox("File Does Not Exist..... Please select any File")
                            End If
                            btnFileSelection.Focus()
                        End If
                    End If
                End If
            Next

            ' Here the categorized words are written to specific text file

            Dim filecontent As String = ""
            Dim pathText As String = My.Application.Info.DirectoryPath
            Dim output As String = pathText & "\output"
            If (Not System.IO.Directory.Exists(output)) Then
                System.IO.Directory.CreateDirectory(output)
            End If
            Dim fileDateTime As String = DateTime.Now.ToString("ddMMyyyy") & "_" & DateTime.Now.ToString("HHmmss")

            Dim SINGLE_WORDS As String = output & "\1_" & fileDateTime & ".txt"
            Dim objWriter1 As New System.IO.StreamWriter(SINGLE_WORDS, True, System.Text.Encoding.UTF8)
            If System.IO.File.Exists(SINGLE_WORDS) = True Then
                filecontent = ""
                For i As Integer = 0 To dtable1.Rows.Count - 1
                    filecontent = dtable1.Rows(i).Item("WORDS").ToString()
                    If Not filecontent Is Nothing Then
                        objWriter1.Write(filecontent & vbNewLine)
                    End If
                Next
            Else
                If rbtnTamil.Checked = True Then
                    MsgBox(" கோப்பு இல்லை")
                ElseIf rbtnEnglish.Checked = True Then
                    MsgBox("File Does Not Exist")
                End If
            End If
            objWriter1.Close()

            Dim TWO_WORDS As String = output & "\2_" & fileDateTime & ".txt"
            Dim objWriter2 As New System.IO.StreamWriter(TWO_WORDS, True, System.Text.Encoding.UTF8)
            If System.IO.File.Exists(TWO_WORDS) = True Then
                filecontent = ""
                For i As Integer = 0 To dtable2.Rows.Count - 1
                    filecontent = dtable2.Rows(i).Item("WORDS").ToString()
                    If Not filecontent Is Nothing Then
                        objWriter2.Write(filecontent & vbNewLine)
                    End If
                Next
            Else
                If rbtnTamil.Checked = True Then
                    MsgBox(" கோப்பு இல்லை")
                ElseIf rbtnEnglish.Checked = True Then
                    MsgBox("File Does Not Exist")
                End If
            End If
            objWriter2.Close()

            Dim THREE_WORDS As String = output & "\3_" & fileDateTime & ".txt"
            Dim objWriter3 As New System.IO.StreamWriter(THREE_WORDS, True, System.Text.Encoding.UTF8)
            If System.IO.File.Exists(THREE_WORDS) = True Then
                filecontent = ""
                For i As Integer = 0 To dtable3.Rows.Count - 1
                    filecontent = dtable3.Rows(i).Item("WORDS").ToString()
                    If Not filecontent Is Nothing Then
                        objWriter3.Write(filecontent & vbNewLine)
                    End If
                Next
            Else
                If rbtnTamil.Checked = True Then
                    MsgBox(" கோப்பு இல்லை")
                ElseIf rbtnEnglish.Checked = True Then
                    MsgBox("File Does Not Exist")
                End If
            End If
            objWriter3.Close()

            Dim FOUR_WORDS As String = output & "\4_" & fileDateTime & ".txt"
            Dim objWriter4 As New System.IO.StreamWriter(FOUR_WORDS, True, System.Text.Encoding.UTF8)
            If System.IO.File.Exists(FOUR_WORDS) = True Then
                filecontent = ""
                For i As Integer = 0 To dtable4.Rows.Count - 1
                    filecontent = dtable4.Rows(i).Item("WORDS").ToString()
                    If Not filecontent Is Nothing Then
                        objWriter4.Write(filecontent & vbNewLine)
                    End If
                Next
            Else
                If rbtnTamil.Checked = True Then
                    MsgBox(" கோப்பு இல்லை")
                ElseIf rbtnEnglish.Checked = True Then
                    MsgBox("File Does Not Exist")
                End If
            End If
            objWriter4.Close()

            Dim FIVE_WORDS As String = output & "\5_" & fileDateTime & ".txt"
            Dim objWriter5 As New System.IO.StreamWriter(FIVE_WORDS, True, System.Text.Encoding.UTF8)
            If System.IO.File.Exists(FIVE_WORDS) = True Then
                filecontent = ""
                For i As Integer = 0 To dtable5.Rows.Count - 1
                    filecontent = dtable5.Rows(i).Item("WORDS").ToString()
                    If Not filecontent Is Nothing Then
                        objWriter5.Write(filecontent & vbNewLine)
                    End If
                Next
            Else
                If rbtnTamil.Checked = True Then
                    MsgBox(" கோப்பு இல்லை")
                ElseIf rbtnEnglish.Checked = True Then
                    MsgBox("File Does Not Exist")
                End If
            End If
            objWriter5.Close()

            Me.Cursor = Cursors.Default
            grpLanguage.Enabled = True
            grpFileSelection.Enabled = True
            grpSorting.Enabled = True
            grpDuplication.Enabled = True
            chckSpclChar.Enabled = True

            If rbtnTamil.Checked = True Then
                MsgBox(" உரை எழுதப்பட்ட கோப்பின் பாதை " & output & "'")
                lblOutputPath.Text = " வெளியீடு பாதை : "
            ElseIf rbtnEnglish.Checked = True Then
                MsgBox("Text written to the file in the path '" & output & "'")
                lblOutputPath.Text = " Output Path : "
            End If
            lnkLblOutput.Text = output

        End If
    End Sub

#End Region

#Region " LinkLabel "

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkLblOutput.LinkClicked
        ' It opens the output directory.
        Process.Start("explorer.exe", lnkLblOutput.Text)
    End Sub

    Private Sub LinkLabel1_LinkClicked_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        ' It changes the background color of the form and checklist box color in descending order

        chkClr = Me.BackColor.ToArgb().ToString("X6")
        If chkClr.Contains("FF") Then
            chkClr = Regex.Replace(chkClr, "^FF", "#")
        End If
        If crntClr = chkClr Then
            Count -= 2
        End If
        If Count < 0 Then
            Count = bg.Length - 1
        End If
        If bg.Length > Count Then
            Me.BackColor = ColorTranslator.FromHtml(bg(Count))
            rcrntClr = bg(Count)
            chkListBox.BackColor = ColorTranslator.FromHtml(chkcl(Count))
            Count -= 1
        End If
    End Sub

    Private Sub LinkLabel2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        ' It changes the background color of the form and checklist box color in ascending order

        rchkClr = Me.BackColor.ToArgb().ToString("X6")
        If rchkClr.Contains("FF") Then
            rchkClr = Regex.Replace(rchkClr, "^FF", "#")
        End If
        If rcrntClr = rchkClr Then
            Count += 2
        End If
        If Count = bg.Length Or Count > bg.Length And Count = chkcl.Length Then
            Count = 0
        End If
        If Count < bg.Length And Count < chkcl.Length Then
            Me.BackColor = ColorTranslator.FromHtml(bg(Count))
            crntClr = bg(Count)
            chkListBox.BackColor = ColorTranslator.FromHtml(chkcl(Count))
            Count += 1
        End If
    End Sub

#End Region

#Region " CheckListBox "

    Private Sub chkListBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkListBox.SelectedIndexChanged
        ' It changes the checklist box selection for select and unselect all

        If chkListBox.SelectedIndex = 0 Then
            If chkListBox.GetItemChecked(0) = False Then
                For idx As Integer = 1 To chkListBox.Items.Count - 1

                    Me.chkListBox.SetItemChecked(idx, False)
                Next
            Else
                For idx As Integer = 1 To chkListBox.Items.Count - 1

                    Me.chkListBox.SetItemChecked(idx, True)
                Next
            End If
        ElseIf chkListBox.SelectedIndex > 0 Then
            If chkListBox.CheckedItems.Count = chkListBox.Items.Count - 1 And chkListBox.GetItemChecked(0) = False Then
                chkListBox.SetItemCheckState(0, CheckState.Checked)
            End If
            For idx As Integer = 1 To chkListBox.Items.Count - 1

                If chkListBox.GetItemChecked(idx) = False Then
                    chkListBox.SetItemCheckState(0, CheckState.Unchecked)

                End If
            Next
        End If
    End Sub

#End Region

#Region " RadioButton "

    Private Sub rbtnTamil_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnTamil.CheckedChanged
        ' It changes the language of the form

        If rbtnTamil.Checked = True Then

            btnFileSelection.Text = "கோப்பினைத் தேர்ந்தெடு"
            grpFileSelection.Text = "கோப்பு தேர்வு"
            rbtnSingle.Text = "ஒற்றை கோப்பு"
            rbtnMultiple.Text = "பல கோப்புகள்"
            rbtnTamil.Text = "தமிழ்"
            rbtnEnglish.Text = "ஆங்கிலம்"
            chckSpclChar.Text = "சிறப்பு குறியீடுகளை நீக்கு"
            grpSorting.Text = "அகரவரிசைப் படுத்த"
            rbtnSort.Text = "அகரவரிசை"
            rbtnUnsort.Text = "சொற்கள் பட்டியல்"
            grpDuplication.Text = "நகல் சொற்கள்"
            rbtnDupliChar.Text = "நகல் சொற்களுடன்"
            rbtnWDupliChar.Text = "நீக்கியவை"
            btnSubmit.Text = "சமர்ப்பி"
            btnReset.Text = "அழி"

        ElseIf rbtnEnglish.Checked = True Then

            btnFileSelection.Text = "Select a File"
            grpFileSelection.Text = "FileSelection"
            rbtnSingle.Text = "Single File"
            rbtnMultiple.Text = "Multiple Files"
            rbtnTamil.Text = "Tamil"
            rbtnEnglish.Text = "English"
            chckSpclChar.Text = "Remove Special Characters"
            grpSorting.Text = "Sorting"
            rbtnSort.Text = "Sort"
            rbtnUnsort.Text = "UnSort"
            grpDuplication.Text = "Duplication"
            rbtnDupliChar.Text = "With Duplicate"
            rbtnWDupliChar.Text = "Without Duplicate"
            btnSubmit.Text = "Go"
            btnReset.Text = "Clear"

        Else

            MsgBox("Please the Language")

        End If
    End Sub

#End Region

End Class
