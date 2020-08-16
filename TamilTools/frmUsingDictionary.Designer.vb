<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUsingDictionary
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.rtbDict = New System.Windows.Forms.RichTextBox
        Me.btnClear = New System.Windows.Forms.Button
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.btnSearch = New System.Windows.Forms.Button
        Me.chckList = New System.Windows.Forms.CheckedListBox
        Me.grpFileSelection = New System.Windows.Forms.GroupBox
        Me.rbMultiple = New System.Windows.Forms.RadioButton
        Me.rbSingle = New System.Windows.Forms.RadioButton
        Me.btnFileSelection = New System.Windows.Forms.Button
        Me.opnFileDlg = New System.Windows.Forms.OpenFileDialog
        Me.fldrBrwsDlg = New System.Windows.Forms.FolderBrowserDialog
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker
        Me.BackgroundWorker2 = New System.ComponentModel.BackgroundWorker
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpFileSelection.SuspendLayout()
        Me.SuspendLayout()
        '
        'rtbDict
        '
        Me.rtbDict.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.rtbDict.Location = New System.Drawing.Point(912, 12)
        Me.rtbDict.Name = "rtbDict"
        Me.rtbDict.ReadOnly = True
        Me.rtbDict.Size = New System.Drawing.Size(352, 504)
        Me.rtbDict.TabIndex = 0
        Me.rtbDict.Text = ""
        '
        'btnClear
        '
        Me.btnClear.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.btnClear.Location = New System.Drawing.Point(809, 38)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(87, 23)
        Me.btnClear.TabIndex = 11
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToResizeColumns = False
        Me.DataGridView1.AllowUserToResizeRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 8.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.Location = New System.Drawing.Point(521, 92)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(377, 424)
        Me.DataGridView1.TabIndex = 10
        '
        'btnSearch
        '
        Me.btnSearch.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.btnSearch.Location = New System.Drawing.Point(697, 38)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(87, 23)
        Me.btnSearch.TabIndex = 9
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'chckList
        '
        Me.chckList.CheckOnClick = True
        Me.chckList.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.chckList.FormattingEnabled = True
        Me.chckList.HorizontalScrollbar = True
        Me.chckList.Location = New System.Drawing.Point(13, 92)
        Me.chckList.Name = "chckList"
        Me.chckList.Size = New System.Drawing.Size(493, 424)
        Me.chckList.TabIndex = 8
        '
        'grpFileSelection
        '
        Me.grpFileSelection.Controls.Add(Me.rbMultiple)
        Me.grpFileSelection.Controls.Add(Me.rbSingle)
        Me.grpFileSelection.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.grpFileSelection.Location = New System.Drawing.Point(129, 29)
        Me.grpFileSelection.Name = "grpFileSelection"
        Me.grpFileSelection.Size = New System.Drawing.Size(272, 30)
        Me.grpFileSelection.TabIndex = 7
        Me.grpFileSelection.TabStop = False
        '
        'rbMultiple
        '
        Me.rbMultiple.AutoSize = True
        Me.rbMultiple.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.rbMultiple.Location = New System.Drawing.Point(140, 10)
        Me.rbMultiple.Name = "rbMultiple"
        Me.rbMultiple.Size = New System.Drawing.Size(97, 17)
        Me.rbMultiple.TabIndex = 1
        Me.rbMultiple.TabStop = True
        Me.rbMultiple.Text = "Multiple Files"
        Me.rbMultiple.UseVisualStyleBackColor = True
        '
        'rbSingle
        '
        Me.rbSingle.AutoSize = True
        Me.rbSingle.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.rbSingle.Location = New System.Drawing.Point(22, 10)
        Me.rbSingle.Name = "rbSingle"
        Me.rbSingle.Size = New System.Drawing.Size(83, 17)
        Me.rbSingle.TabIndex = 0
        Me.rbSingle.TabStop = True
        Me.rbSingle.Text = "Single File"
        Me.rbSingle.UseVisualStyleBackColor = True
        '
        'btnFileSelection
        '
        Me.btnFileSelection.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.btnFileSelection.Location = New System.Drawing.Point(14, 34)
        Me.btnFileSelection.Name = "btnFileSelection"
        Me.btnFileSelection.Size = New System.Drawing.Size(87, 23)
        Me.btnFileSelection.TabIndex = 6
        Me.btnFileSelection.Text = "Select File"
        Me.btnFileSelection.UseVisualStyleBackColor = True
        '
        'opnFileDlg
        '
        Me.opnFileDlg.FileName = "OpenFileDialog1"
        '
        'BackgroundWorker1
        '
        '
        'BackgroundWorker2
        '
        '
        'frmUsingDictionary
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1274, 541)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.chckList)
        Me.Controls.Add(Me.grpFileSelection)
        Me.Controls.Add(Me.btnFileSelection)
        Me.Controls.Add(Me.rtbDict)
        Me.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmUsingDictionary"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Domain Identification Using Dictionary"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpFileSelection.ResumeLayout(False)
        Me.grpFileSelection.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rtbDict As System.Windows.Forms.RichTextBox
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents chckList As System.Windows.Forms.CheckedListBox
    Friend WithEvents grpFileSelection As System.Windows.Forms.GroupBox
    Friend WithEvents rbMultiple As System.Windows.Forms.RadioButton
    Friend WithEvents rbSingle As System.Windows.Forms.RadioButton
    Friend WithEvents btnFileSelection As System.Windows.Forms.Button
    Friend WithEvents opnFileDlg As System.Windows.Forms.OpenFileDialog
    Friend WithEvents fldrBrwsDlg As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents BackgroundWorker2 As System.ComponentModel.BackgroundWorker
End Class
