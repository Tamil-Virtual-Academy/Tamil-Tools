<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmWordsCountSingleFile
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
        Me.rtbOutput = New System.Windows.Forms.RichTextBox
        Me.rtbContent = New System.Windows.Forms.RichTextBox
        Me.chkSort = New System.Windows.Forms.CheckBox
        Me.lblDelimiter = New System.Windows.Forms.Label
        Me.btnTxt = New System.Windows.Forms.Button
        Me.btnClear = New System.Windows.Forms.Button
        Me.btnCount = New System.Windows.Forms.Button
        Me.txtDelimeter = New System.Windows.Forms.TextBox
        Me.btnUpload = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'rtbOutput
        '
        Me.rtbOutput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.rtbOutput.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.rtbOutput.Location = New System.Drawing.Point(840, 80)
        Me.rtbOutput.Name = "rtbOutput"
        Me.rtbOutput.ReadOnly = True
        Me.rtbOutput.Size = New System.Drawing.Size(414, 446)
        Me.rtbOutput.TabIndex = 72
        Me.rtbOutput.Text = ""
        '
        'rtbContent
        '
        Me.rtbContent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.rtbContent.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.rtbContent.Location = New System.Drawing.Point(22, 80)
        Me.rtbContent.Name = "rtbContent"
        Me.rtbContent.ReadOnly = True
        Me.rtbContent.Size = New System.Drawing.Size(799, 446)
        Me.rtbContent.TabIndex = 71
        Me.rtbContent.Text = ""
        '
        'chkSort
        '
        Me.chkSort.AutoSize = True
        Me.chkSort.Checked = True
        Me.chkSort.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkSort.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkSort.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.chkSort.Location = New System.Drawing.Point(518, 32)
        Me.chkSort.Name = "chkSort"
        Me.chkSort.Size = New System.Drawing.Size(101, 17)
        Me.chkSort.TabIndex = 70
        Me.chkSort.Text = "அகர வரிசை"
        Me.chkSort.UseVisualStyleBackColor = True
        '
        'lblDelimiter
        '
        Me.lblDelimiter.AutoSize = True
        Me.lblDelimiter.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblDelimiter.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.lblDelimiter.Location = New System.Drawing.Point(179, 33)
        Me.lblDelimiter.Name = "lblDelimiter"
        Me.lblDelimiter.Size = New System.Drawing.Size(127, 13)
        Me.lblDelimiter.TabIndex = 69
        Me.lblDelimiter.Text = "சொற்பிரிப்பு வரம்பு"
        '
        'btnTxt
        '
        Me.btnTxt.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTxt.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.btnTxt.Location = New System.Drawing.Point(1087, 25)
        Me.btnTxt.Name = "btnTxt"
        Me.btnTxt.Size = New System.Drawing.Size(166, 31)
        Me.btnTxt.TabIndex = 68
        Me.btnTxt.Text = "பதிவிறக்கம் @ .txt"
        Me.btnTxt.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClear.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.btnClear.Location = New System.Drawing.Point(751, 25)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(69, 31)
        Me.btnClear.TabIndex = 66
        Me.btnClear.Text = "அழி"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnCount
        '
        Me.btnCount.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCount.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.btnCount.Location = New System.Drawing.Point(653, 25)
        Me.btnCount.Name = "btnCount"
        Me.btnCount.Size = New System.Drawing.Size(91, 31)
        Me.btnCount.TabIndex = 65
        Me.btnCount.Text = "எண்ணு"
        Me.btnCount.UseVisualStyleBackColor = True
        '
        'txtDelimeter
        '
        Me.txtDelimeter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDelimeter.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.txtDelimeter.ForeColor = System.Drawing.Color.ForestGreen
        Me.txtDelimeter.Location = New System.Drawing.Point(326, 28)
        Me.txtDelimeter.Name = "txtDelimeter"
        Me.txtDelimeter.Size = New System.Drawing.Size(44, 20)
        Me.txtDelimeter.TabIndex = 64
        '
        'btnUpload
        '
        Me.btnUpload.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUpload.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.btnUpload.Location = New System.Drawing.Point(21, 23)
        Me.btnUpload.Name = "btnUpload"
        Me.btnUpload.Size = New System.Drawing.Size(147, 33)
        Me.btnUpload.TabIndex = 63
        Me.btnUpload.Text = "கோப்பு இணை"
        Me.btnUpload.UseVisualStyleBackColor = True
        '
        'frmWordsCountSingleFile
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1284, 551)
        Me.Controls.Add(Me.rtbOutput)
        Me.Controls.Add(Me.rtbContent)
        Me.Controls.Add(Me.chkSort)
        Me.Controls.Add(Me.lblDelimiter)
        Me.Controls.Add(Me.btnTxt)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnCount)
        Me.Controls.Add(Me.txtDelimeter)
        Me.Controls.Add(Me.btnUpload)
        Me.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmWordsCountSingleFile"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "சொல் எண்ணிக்கை ஒரு கோப்பு இணை"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents rtbOutput As System.Windows.Forms.RichTextBox
    Friend WithEvents rtbContent As System.Windows.Forms.RichTextBox
    Friend WithEvents chkSort As System.Windows.Forms.CheckBox
    Friend WithEvents lblDelimiter As System.Windows.Forms.Label
    Friend WithEvents btnTxt As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnCount As System.Windows.Forms.Button
    Friend WithEvents txtDelimeter As System.Windows.Forms.TextBox
    Friend WithEvents btnUpload As System.Windows.Forms.Button
End Class
