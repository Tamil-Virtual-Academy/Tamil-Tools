<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmWordsCountMultipleFile
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
        Me.cmbTypes = New System.Windows.Forms.ComboBox
        Me.lblDelimiter_2 = New System.Windows.Forms.Label
        Me.clbFileName = New System.Windows.Forms.CheckedListBox
        Me.rtbOutput_2 = New System.Windows.Forms.RichTextBox
        Me.rtbContent_2 = New System.Windows.Forms.RichTextBox
        Me.chkSort_2 = New System.Windows.Forms.CheckBox
        Me.btnTxt_2 = New System.Windows.Forms.Button
        Me.btnClear_2 = New System.Windows.Forms.Button
        Me.btnCount_2 = New System.Windows.Forms.Button
        Me.txtDelimeter_2 = New System.Windows.Forms.TextBox
        Me.btnUpload_2 = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'cmbTypes
        '
        Me.cmbTypes.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.cmbTypes.ForeColor = System.Drawing.Color.ForestGreen
        Me.cmbTypes.FormattingEnabled = True
        Me.cmbTypes.Location = New System.Drawing.Point(535, 30)
        Me.cmbTypes.Name = "cmbTypes"
        Me.cmbTypes.Size = New System.Drawing.Size(216, 21)
        Me.cmbTypes.TabIndex = 80
        '
        'lblDelimiter_2
        '
        Me.lblDelimiter_2.AutoSize = True
        Me.lblDelimiter_2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblDelimiter_2.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.lblDelimiter_2.Location = New System.Drawing.Point(175, 37)
        Me.lblDelimiter_2.Name = "lblDelimiter_2"
        Me.lblDelimiter_2.Size = New System.Drawing.Size(127, 13)
        Me.lblDelimiter_2.TabIndex = 79
        Me.lblDelimiter_2.Text = "சொற்பிரிப்பு வரம்பு"
        '
        'clbFileName
        '
        Me.clbFileName.BackColor = System.Drawing.SystemColors.Control
        Me.clbFileName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.clbFileName.CheckOnClick = True
        Me.clbFileName.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.clbFileName.FormattingEnabled = True
        Me.clbFileName.HorizontalScrollbar = True
        Me.clbFileName.Location = New System.Drawing.Point(21, 74)
        Me.clbFileName.Name = "clbFileName"
        Me.clbFileName.Size = New System.Drawing.Size(366, 452)
        Me.clbFileName.TabIndex = 78
        '
        'rtbOutput_2
        '
        Me.rtbOutput_2.BackColor = System.Drawing.SystemColors.Control
        Me.rtbOutput_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.rtbOutput_2.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.rtbOutput_2.Location = New System.Drawing.Point(892, 74)
        Me.rtbOutput_2.Name = "rtbOutput_2"
        Me.rtbOutput_2.ReadOnly = True
        Me.rtbOutput_2.Size = New System.Drawing.Size(365, 452)
        Me.rtbOutput_2.TabIndex = 77
        Me.rtbOutput_2.Text = ""
        '
        'rtbContent_2
        '
        Me.rtbContent_2.BackColor = System.Drawing.SystemColors.Control
        Me.rtbContent_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.rtbContent_2.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.rtbContent_2.Location = New System.Drawing.Point(411, 74)
        Me.rtbContent_2.Name = "rtbContent_2"
        Me.rtbContent_2.ReadOnly = True
        Me.rtbContent_2.Size = New System.Drawing.Size(458, 452)
        Me.rtbContent_2.TabIndex = 76
        Me.rtbContent_2.Text = ""
        '
        'chkSort_2
        '
        Me.chkSort_2.AutoSize = True
        Me.chkSort_2.Checked = True
        Me.chkSort_2.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkSort_2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkSort_2.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.chkSort_2.Location = New System.Drawing.Point(413, 35)
        Me.chkSort_2.Name = "chkSort_2"
        Me.chkSort_2.Size = New System.Drawing.Size(101, 17)
        Me.chkSort_2.TabIndex = 75
        Me.chkSort_2.Text = "அகர வரிசை"
        Me.chkSort_2.UseVisualStyleBackColor = True
        '
        'btnTxt_2
        '
        Me.btnTxt_2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTxt_2.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.btnTxt_2.Location = New System.Drawing.Point(1090, 28)
        Me.btnTxt_2.Name = "btnTxt_2"
        Me.btnTxt_2.Size = New System.Drawing.Size(166, 30)
        Me.btnTxt_2.TabIndex = 74
        Me.btnTxt_2.Text = "பதிவிறக்கம் @ .txt"
        Me.btnTxt_2.UseVisualStyleBackColor = True
        '
        'btnClear_2
        '
        Me.btnClear_2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClear_2.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.btnClear_2.Location = New System.Drawing.Point(997, 29)
        Me.btnClear_2.Name = "btnClear_2"
        Me.btnClear_2.Size = New System.Drawing.Size(69, 30)
        Me.btnClear_2.TabIndex = 73
        Me.btnClear_2.Text = "அழி"
        Me.btnClear_2.UseVisualStyleBackColor = True
        '
        'btnCount_2
        '
        Me.btnCount_2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCount_2.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.btnCount_2.Location = New System.Drawing.Point(891, 30)
        Me.btnCount_2.Name = "btnCount_2"
        Me.btnCount_2.Size = New System.Drawing.Size(91, 30)
        Me.btnCount_2.TabIndex = 72
        Me.btnCount_2.Text = "எண்ணு"
        Me.btnCount_2.UseVisualStyleBackColor = True
        '
        'txtDelimeter_2
        '
        Me.txtDelimeter_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDelimeter_2.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.txtDelimeter_2.ForeColor = System.Drawing.Color.ForestGreen
        Me.txtDelimeter_2.Location = New System.Drawing.Point(322, 31)
        Me.txtDelimeter_2.Name = "txtDelimeter_2"
        Me.txtDelimeter_2.Size = New System.Drawing.Size(44, 20)
        Me.txtDelimeter_2.TabIndex = 71
        '
        'btnUpload_2
        '
        Me.btnUpload_2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUpload_2.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.btnUpload_2.Location = New System.Drawing.Point(21, 26)
        Me.btnUpload_2.Name = "btnUpload_2"
        Me.btnUpload_2.Size = New System.Drawing.Size(147, 33)
        Me.btnUpload_2.TabIndex = 70
        Me.btnUpload_2.Text = "கோப்பு இணை"
        Me.btnUpload_2.UseVisualStyleBackColor = True
        '
        'frmWordsCountMultipleFile
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1284, 551)
        Me.Controls.Add(Me.cmbTypes)
        Me.Controls.Add(Me.lblDelimiter_2)
        Me.Controls.Add(Me.clbFileName)
        Me.Controls.Add(Me.rtbOutput_2)
        Me.Controls.Add(Me.rtbContent_2)
        Me.Controls.Add(Me.chkSort_2)
        Me.Controls.Add(Me.btnTxt_2)
        Me.Controls.Add(Me.btnClear_2)
        Me.Controls.Add(Me.btnCount_2)
        Me.Controls.Add(Me.txtDelimeter_2)
        Me.Controls.Add(Me.btnUpload_2)
        Me.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmWordsCountMultipleFile"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "சொல் எண்ணிக்கை பல கோப்புக்களை இணை"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmbTypes As System.Windows.Forms.ComboBox
    Friend WithEvents lblDelimiter_2 As System.Windows.Forms.Label
    Friend WithEvents clbFileName As System.Windows.Forms.CheckedListBox
    Friend WithEvents rtbOutput_2 As System.Windows.Forms.RichTextBox
    Friend WithEvents rtbContent_2 As System.Windows.Forms.RichTextBox
    Friend WithEvents chkSort_2 As System.Windows.Forms.CheckBox
    Friend WithEvents btnTxt_2 As System.Windows.Forms.Button
    Friend WithEvents btnClear_2 As System.Windows.Forms.Button
    Friend WithEvents btnCount_2 As System.Windows.Forms.Button
    Friend WithEvents txtDelimeter_2 As System.Windows.Forms.TextBox
    Friend WithEvents btnUpload_2 As System.Windows.Forms.Button
End Class
