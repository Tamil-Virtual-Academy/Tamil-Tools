Imports System.Windows.Forms

Public Class frmMDIParent
    Dim flag As Boolean = False
    'Dim objBo As New Markers.DataManager


    Public Function Close_ChildForm()
        Close_ChildForm = 0
        For Each child As Form In Me.MdiChildren
            child.Close()
        Next child
    End Function

    Private Sub frmMDIParent_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Application.Exit()

        'If flag = False Then

        '    Dim result As DialogResult = MessageBox.Show("There have been changes since you last saved, would you like to save before you close?", "Recent Changes", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
        '    If result = Windows.Forms.DialogResult.Yes Then
        '        'Me.Close()
        '        e.Cancel = True
        '        flag = False
        '    ElseIf result = Windows.Forms.DialogResult.No Then
        '        flag = True
        '        Application.Exit()
        '    End If
        'Else
        '    Application.Exit()
        'End If

    End Sub

    

    Private Sub mnuWordsCount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuWordsCount.Click

    End Sub

    Private Sub SingleFileToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SingleFileToolStripMenuItem.Click
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        Close_ChildForm()
        Dim mDI As frmWordsCountSingleFile
        mDI = New frmWordsCountSingleFile
        mDI.MdiParent = Me
        mDI.Show()
        mDI.Location = New Point(1, 1)
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub MultipleFileToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MultipleFileToolStripMenuItem.Click
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        Close_ChildForm()
        Dim mDI As frmWordsCountMultipleFile
        mDI = New frmWordsCountMultipleFile
        mDI.MdiParent = Me
        mDI.Show()
        mDI.Location = New Point(1, 1)
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub CoOccurrenceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CoOccurrenceToolStripMenuItem.Click
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        Close_ChildForm()
        Dim mDI As frmWordsCountConcordance
        mDI = New frmWordsCountConcordance
        mDI.MdiParent = Me
        mDI.Show()
        mDI.Location = New Point(1, 1)
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub DomainIdentifierToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DomainIdentifierToolStripMenuItem.Click
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        Close_ChildForm()
        Dim mDI As frmDomainIdentification
        mDI = New frmDomainIdentification
        mDI.MdiParent = Me
        mDI.Show()
        mDI.Location = New Point(1, 1)
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub DomainIdentifierUsingDictionaryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DomainIdentifierUsingDictionaryToolStripMenuItem.Click
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        Close_ChildForm()
        Dim mDI As frmUsingDictionary
        mDI = New frmUsingDictionary
        mDI.MdiParent = Me
        mDI.Show()
        mDI.Location = New Point(1, 1)
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub mnuCategorizingFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCategorizingFile.Click
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        Close_ChildForm()
        Dim mDI As frmCategorizingWordsFile
        mDI = New frmCategorizingWordsFile
        mDI.MdiParent = Me
        mDI.Show()
        mDI.Location = New Point(1, 1)
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
    End Sub
End Class
