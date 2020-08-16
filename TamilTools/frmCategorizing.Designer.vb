<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCategorizingWordsFile
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.OpenFileDialogbox = New System.Windows.Forms.OpenFileDialog
        Me.btnFileSelection = New System.Windows.Forms.Button
        Me.rbtnSort = New System.Windows.Forms.RadioButton
        Me.rbtnUnsort = New System.Windows.Forms.RadioButton
        Me.btnSubmit = New System.Windows.Forms.Button
        Me.grpSorting = New System.Windows.Forms.GroupBox
        Me.rbtnDupliChar = New System.Windows.Forms.RadioButton
        Me.rbtnWDupliChar = New System.Windows.Forms.RadioButton
        Me.grpDuplication = New System.Windows.Forms.GroupBox
        Me.chckSpclChar = New System.Windows.Forms.CheckBox
        Me.btnReset = New System.Windows.Forms.Button
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.lnkLblOutput = New System.Windows.Forms.LinkLabel
        Me.lblOutputPath = New System.Windows.Forms.Label
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.chkListBox = New System.Windows.Forms.CheckedListBox
        Me.grpFileSelection = New System.Windows.Forms.GroupBox
        Me.rbtnMultiple = New System.Windows.Forms.RadioButton
        Me.rbtnSingle = New System.Windows.Forms.RadioButton
        Me.rbtnTamil = New System.Windows.Forms.RadioButton
        Me.rbtnEnglish = New System.Windows.Forms.RadioButton
        Me.lblProgressPercentage = New System.Windows.Forms.Label
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog
        Me.grpLanguage = New System.Windows.Forms.GroupBox
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel
        Me.Label1 = New System.Windows.Forms.Label
        Me.grpSorting.SuspendLayout()
        Me.grpDuplication.SuspendLayout()
        Me.grpFileSelection.SuspendLayout()
        Me.grpLanguage.SuspendLayout()
        Me.SuspendLayout()
        '
        'OpenFileDialogbox
        '
        Me.OpenFileDialogbox.FileName = "OpenFileDialogbox"
        '
        'btnFileSelection
        '
        Me.btnFileSelection.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFileSelection.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnFileSelection.Location = New System.Drawing.Point(10, 14)
        Me.btnFileSelection.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnFileSelection.Name = "btnFileSelection"
        Me.btnFileSelection.Size = New System.Drawing.Size(101, 49)
        Me.btnFileSelection.TabIndex = 0
        Me.btnFileSelection.Text = "Select a File"
        Me.ToolTip1.SetToolTip(Me.btnFileSelection, "Click here to browse the file you want to categorize.")
        Me.btnFileSelection.UseVisualStyleBackColor = True
        '
        'rbtnSort
        '
        Me.rbtnSort.AutoSize = True
        Me.rbtnSort.Location = New System.Drawing.Point(139, 23)
        Me.rbtnSort.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.rbtnSort.Name = "rbtnSort"
        Me.rbtnSort.Size = New System.Drawing.Size(54, 20)
        Me.rbtnSort.TabIndex = 2
        Me.rbtnSort.TabStop = True
        Me.rbtnSort.Text = "Sort"
        Me.ToolTip1.SetToolTip(Me.rbtnSort, "Select here to write the words in ascending order.")
        Me.rbtnSort.UseVisualStyleBackColor = True
        '
        'rbtnUnsort
        '
        Me.rbtnUnsort.AutoSize = True
        Me.rbtnUnsort.Location = New System.Drawing.Point(6, 23)
        Me.rbtnUnsort.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.rbtnUnsort.Name = "rbtnUnsort"
        Me.rbtnUnsort.Size = New System.Drawing.Size(69, 20)
        Me.rbtnUnsort.TabIndex = 3
        Me.rbtnUnsort.TabStop = True
        Me.rbtnUnsort.Text = "Unsort"
        Me.ToolTip1.SetToolTip(Me.rbtnUnsort, "Select here to write the words in the unsorting order")
        Me.rbtnUnsort.UseVisualStyleBackColor = True
        '
        'btnSubmit
        '
        Me.btnSubmit.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSubmit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnSubmit.Location = New System.Drawing.Point(547, 636)
        Me.btnSubmit.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(88, 31)
        Me.btnSubmit.TabIndex = 6
        Me.btnSubmit.Text = "Go"
        Me.ToolTip1.SetToolTip(Me.btnSubmit, "Click here to execute the process")
        Me.btnSubmit.UseVisualStyleBackColor = True
        '
        'grpSorting
        '
        Me.grpSorting.Controls.Add(Me.rbtnUnsort)
        Me.grpSorting.Controls.Add(Me.rbtnSort)
        Me.grpSorting.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpSorting.Location = New System.Drawing.Point(401, 6)
        Me.grpSorting.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.grpSorting.Name = "grpSorting"
        Me.grpSorting.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.grpSorting.Size = New System.Drawing.Size(238, 58)
        Me.grpSorting.TabIndex = 7
        Me.grpSorting.TabStop = False
        Me.grpSorting.Text = "Sorting"
        Me.ToolTip1.SetToolTip(Me.grpSorting, "Sorting")
        '
        'rbtnDupliChar
        '
        Me.rbtnDupliChar.AutoSize = True
        Me.rbtnDupliChar.Location = New System.Drawing.Point(17, 22)
        Me.rbtnDupliChar.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.rbtnDupliChar.Name = "rbtnDupliChar"
        Me.rbtnDupliChar.Size = New System.Drawing.Size(127, 20)
        Me.rbtnDupliChar.TabIndex = 4
        Me.rbtnDupliChar.TabStop = True
        Me.rbtnDupliChar.Text = "With Duplicate "
        Me.ToolTip1.SetToolTip(Me.rbtnDupliChar, "Select here to write the file with repeated words.")
        Me.rbtnDupliChar.UseVisualStyleBackColor = True
        '
        'rbtnWDupliChar
        '
        Me.rbtnWDupliChar.AutoSize = True
        Me.rbtnWDupliChar.Location = New System.Drawing.Point(155, 22)
        Me.rbtnWDupliChar.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.rbtnWDupliChar.Name = "rbtnWDupliChar"
        Me.rbtnWDupliChar.Size = New System.Drawing.Size(149, 20)
        Me.rbtnWDupliChar.TabIndex = 5
        Me.rbtnWDupliChar.TabStop = True
        Me.rbtnWDupliChar.Text = "Without Duplicate "
        Me.ToolTip1.SetToolTip(Me.rbtnWDupliChar, "Select here to remove the repeated words")
        Me.rbtnWDupliChar.UseVisualStyleBackColor = True
        '
        'grpDuplication
        '
        Me.grpDuplication.Controls.Add(Me.rbtnDupliChar)
        Me.grpDuplication.Controls.Add(Me.rbtnWDupliChar)
        Me.grpDuplication.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpDuplication.Location = New System.Drawing.Point(645, 9)
        Me.grpDuplication.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.grpDuplication.Name = "grpDuplication"
        Me.grpDuplication.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.grpDuplication.Size = New System.Drawing.Size(311, 58)
        Me.grpDuplication.TabIndex = 8
        Me.grpDuplication.TabStop = False
        Me.grpDuplication.Text = "Duplication"
        Me.ToolTip1.SetToolTip(Me.grpDuplication, "Duplication")
        '
        'chckSpclChar
        '
        Me.chckSpclChar.AutoSize = True
        Me.chckSpclChar.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chckSpclChar.Location = New System.Drawing.Point(962, 29)
        Me.chckSpclChar.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.chckSpclChar.Name = "chckSpclChar"
        Me.chckSpclChar.Size = New System.Drawing.Size(207, 20)
        Me.chckSpclChar.TabIndex = 14
        Me.chckSpclChar.Text = "Remove Special Characters"
        Me.ToolTip1.SetToolTip(Me.chckSpclChar, "Removes the special characters from the given file.")
        Me.chckSpclChar.UseVisualStyleBackColor = True
        '
        'btnReset
        '
        Me.btnReset.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReset.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnReset.Location = New System.Drawing.Point(646, 635)
        Me.btnReset.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(73, 31)
        Me.btnReset.TabIndex = 15
        Me.btnReset.Text = "Clear"
        Me.ToolTip1.SetToolTip(Me.btnReset, "Click here to reset the controls.")
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'ProgressBar1
        '
        Me.ProgressBar1.BackColor = System.Drawing.SystemColors.ControlDark
        Me.ProgressBar1.Location = New System.Drawing.Point(19, 694)
        Me.ProgressBar1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(672, 41)
        Me.ProgressBar1.TabIndex = 17
        '
        'Timer1
        '
        '
        'lnkLblOutput
        '
        Me.lnkLblOutput.AutoSize = True
        Me.lnkLblOutput.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lnkLblOutput.Location = New System.Drawing.Point(150, 603)
        Me.lnkLblOutput.Name = "lnkLblOutput"
        Me.lnkLblOutput.Size = New System.Drawing.Size(18, 16)
        Me.lnkLblOutput.TabIndex = 18
        Me.lnkLblOutput.TabStop = True
        Me.lnkLblOutput.Text = ".."
        '
        'lblOutputPath
        '
        Me.lblOutputPath.AutoSize = True
        Me.lblOutputPath.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOutputPath.Location = New System.Drawing.Point(19, 607)
        Me.lblOutputPath.Name = "lblOutputPath"
        Me.lblOutputPath.Size = New System.Drawing.Size(18, 16)
        Me.lblOutputPath.TabIndex = 16
        Me.lblOutputPath.Text = ".."
        '
        'chkListBox
        '
        Me.chkListBox.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.chkListBox.CheckOnClick = True
        Me.chkListBox.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkListBox.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkListBox.FormattingEnabled = True
        Me.chkListBox.HorizontalScrollbar = True
        Me.chkListBox.Location = New System.Drawing.Point(12, 111)
        Me.chkListBox.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.chkListBox.Name = "chkListBox"
        Me.chkListBox.Size = New System.Drawing.Size(1246, 346)
        Me.chkListBox.TabIndex = 22
        Me.ToolTip1.SetToolTip(Me.chkListBox, "To List the selected Files")
        '
        'grpFileSelection
        '
        Me.grpFileSelection.Controls.Add(Me.rbtnMultiple)
        Me.grpFileSelection.Controls.Add(Me.rbtnSingle)
        Me.grpFileSelection.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpFileSelection.Location = New System.Drawing.Point(118, 6)
        Me.grpFileSelection.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.grpFileSelection.Name = "grpFileSelection"
        Me.grpFileSelection.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.grpFileSelection.Size = New System.Drawing.Size(256, 58)
        Me.grpFileSelection.TabIndex = 23
        Me.grpFileSelection.TabStop = False
        Me.grpFileSelection.Text = "FileSelection"
        Me.ToolTip1.SetToolTip(Me.grpFileSelection, "File Selection")
        '
        'rbtnMultiple
        '
        Me.rbtnMultiple.AutoSize = True
        Me.rbtnMultiple.Location = New System.Drawing.Point(125, 23)
        Me.rbtnMultiple.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.rbtnMultiple.Name = "rbtnMultiple"
        Me.rbtnMultiple.Size = New System.Drawing.Size(110, 20)
        Me.rbtnMultiple.TabIndex = 1
        Me.rbtnMultiple.TabStop = True
        Me.rbtnMultiple.Text = "Multiple Files"
        Me.ToolTip1.SetToolTip(Me.rbtnMultiple, "Select here to choose Multiple files")
        Me.rbtnMultiple.UseVisualStyleBackColor = True
        '
        'rbtnSingle
        '
        Me.rbtnSingle.AutoSize = True
        Me.rbtnSingle.Location = New System.Drawing.Point(8, 23)
        Me.rbtnSingle.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.rbtnSingle.Name = "rbtnSingle"
        Me.rbtnSingle.Size = New System.Drawing.Size(92, 20)
        Me.rbtnSingle.TabIndex = 0
        Me.rbtnSingle.TabStop = True
        Me.rbtnSingle.Text = "Single File"
        Me.ToolTip1.SetToolTip(Me.rbtnSingle, "Select here to choose single file")
        Me.rbtnSingle.UseVisualStyleBackColor = True
        '
        'rbtnTamil
        '
        Me.rbtnTamil.AutoSize = True
        Me.rbtnTamil.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnTamil.Location = New System.Drawing.Point(18, 21)
        Me.rbtnTamil.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.rbtnTamil.Name = "rbtnTamil"
        Me.rbtnTamil.Size = New System.Drawing.Size(58, 20)
        Me.rbtnTamil.TabIndex = 24
        Me.rbtnTamil.TabStop = True
        Me.rbtnTamil.Text = "Tamil"
        Me.ToolTip1.SetToolTip(Me.rbtnTamil, "Select here to change the text in Tamil")
        Me.rbtnTamil.UseVisualStyleBackColor = True
        '
        'rbtnEnglish
        '
        Me.rbtnEnglish.AutoSize = True
        Me.rbtnEnglish.Location = New System.Drawing.Point(89, 21)
        Me.rbtnEnglish.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.rbtnEnglish.Name = "rbtnEnglish"
        Me.rbtnEnglish.Size = New System.Drawing.Size(71, 20)
        Me.rbtnEnglish.TabIndex = 25
        Me.rbtnEnglish.TabStop = True
        Me.rbtnEnglish.Text = "English"
        Me.ToolTip1.SetToolTip(Me.rbtnEnglish, "Select here to change the text in English")
        Me.rbtnEnglish.UseVisualStyleBackColor = True
        '
        'lblProgressPercentage
        '
        Me.lblProgressPercentage.AutoSize = True
        Me.lblProgressPercentage.BackColor = System.Drawing.Color.Transparent
        Me.lblProgressPercentage.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblProgressPercentage.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblProgressPercentage.Location = New System.Drawing.Point(696, 705)
        Me.lblProgressPercentage.Name = "lblProgressPercentage"
        Me.lblProgressPercentage.Size = New System.Drawing.Size(29, 16)
        Me.lblProgressPercentage.TabIndex = 19
        Me.lblProgressPercentage.Text = "0%"
        Me.lblProgressPercentage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FolderBrowserDialog1
        '
        Me.FolderBrowserDialog1.SelectedPath = "C:\"
        '
        'grpLanguage
        '
        Me.grpLanguage.Controls.Add(Me.rbtnTamil)
        Me.grpLanguage.Controls.Add(Me.rbtnEnglish)
        Me.grpLanguage.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpLanguage.Location = New System.Drawing.Point(1086, 14)
        Me.grpLanguage.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.grpLanguage.Name = "grpLanguage"
        Me.grpLanguage.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.grpLanguage.Size = New System.Drawing.Size(177, 58)
        Me.grpLanguage.TabIndex = 26
        Me.grpLanguage.TabStop = False
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel1.LinkColor = System.Drawing.Color.Black
        Me.LinkLabel1.Location = New System.Drawing.Point(1159, 76)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(17, 16)
        Me.LinkLabel1.TabIndex = 27
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "<"
        '
        'LinkLabel2
        '
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel2.LinkColor = System.Drawing.Color.Black
        Me.LinkLabel2.Location = New System.Drawing.Point(1246, 78)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(17, 16)
        Me.LinkLabel2.TabIndex = 28
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = ">"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(1178, 79)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 16)
        Me.Label1.TabIndex = 30
        Me.Label1.Text = "Themes"
        '
        'frmCategorizingWordsFile
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(1274, 541)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LinkLabel2)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.grpLanguage)
        Me.Controls.Add(Me.grpFileSelection)
        Me.Controls.Add(Me.chkListBox)
        Me.Controls.Add(Me.lblProgressPercentage)
        Me.Controls.Add(Me.lnkLblOutput)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.lblOutputPath)
        Me.Controls.Add(Me.btnReset)
        Me.Controls.Add(Me.chckSpclChar)
        Me.Controls.Add(Me.grpDuplication)
        Me.Controls.Add(Me.grpSorting)
        Me.Controls.Add(Me.btnSubmit)
        Me.Controls.Add(Me.btnFileSelection)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.SystemColors.ControlText
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frmCategorizingWordsFile"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "உரைக்கோப்பினை வகைப்படுத்துதல் / Categorizing TextFiles"
        Me.grpSorting.ResumeLayout(False)
        Me.grpSorting.PerformLayout()
        Me.grpDuplication.ResumeLayout(False)
        Me.grpDuplication.PerformLayout()
        Me.grpFileSelection.ResumeLayout(False)
        Me.grpFileSelection.PerformLayout()
        Me.grpLanguage.ResumeLayout(False)
        Me.grpLanguage.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OpenFileDialogbox As System.Windows.Forms.OpenFileDialog
    Friend WithEvents btnFileSelection As System.Windows.Forms.Button
    Friend WithEvents rbtnSort As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnUnsort As System.Windows.Forms.RadioButton
    Friend WithEvents btnSubmit As System.Windows.Forms.Button
    Friend WithEvents grpSorting As System.Windows.Forms.GroupBox
    Friend WithEvents rbtnDupliChar As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnWDupliChar As System.Windows.Forms.RadioButton
    Friend WithEvents grpDuplication As System.Windows.Forms.GroupBox
    Friend WithEvents chckSpclChar As System.Windows.Forms.CheckBox
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents lnkLblOutput As System.Windows.Forms.LinkLabel
    Friend WithEvents lblOutputPath As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents lblProgressPercentage As System.Windows.Forms.Label
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents chkListBox As System.Windows.Forms.CheckedListBox
    Friend WithEvents grpFileSelection As System.Windows.Forms.GroupBox
    Friend WithEvents rbtnMultiple As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnSingle As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnTamil As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnEnglish As System.Windows.Forms.RadioButton
    Friend WithEvents grpLanguage As System.Windows.Forms.GroupBox
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel2 As System.Windows.Forms.LinkLabel
    Friend WithEvents Label1 As System.Windows.Forms.Label

End Class
