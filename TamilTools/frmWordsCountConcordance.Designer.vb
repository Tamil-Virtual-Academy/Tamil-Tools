<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmWordsCountConcordance
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
        Me.cmbGram_Con = New System.Windows.Forms.ComboBox()
        Me.btnFill_Con = New System.Windows.Forms.Button()
        Me.txtCon = New System.Windows.Forms.TextBox()
        Me.btnSearch_Con = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtDelimiter_Con = New System.Windows.Forms.TextBox()
        Me.btnUpload_Con = New System.Windows.Forms.Button()
        Me.dgvCon = New System.Windows.Forms.DataGridView()
        Me.clbFileName_Con = New System.Windows.Forms.CheckedListBox()
        Me.rtbContent_Con = New System.Windows.Forms.RichTextBox()
        Me.btnClear_Con = New System.Windows.Forms.Button()
        CType(Me.dgvCon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmbGram_Con
        '
        Me.cmbGram_Con.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.cmbGram_Con.ForeColor = System.Drawing.Color.ForestGreen
        Me.cmbGram_Con.FormattingEnabled = True
        Me.cmbGram_Con.Location = New System.Drawing.Point(588, 27)
        Me.cmbGram_Con.Name = "cmbGram_Con"
        Me.cmbGram_Con.Size = New System.Drawing.Size(69, 21)
        Me.cmbGram_Con.TabIndex = 85
        '
        'btnFill_Con
        '
        Me.btnFill_Con.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFill_Con.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.btnFill_Con.Location = New System.Drawing.Point(425, 24)
        Me.btnFill_Con.Name = "btnFill_Con"
        Me.btnFill_Con.Size = New System.Drawing.Size(91, 30)
        Me.btnFill_Con.TabIndex = 84
        Me.btnFill_Con.Text = "காண்பி"
        Me.btnFill_Con.UseVisualStyleBackColor = True
        '
        'txtCon
        '
        Me.txtCon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCon.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.txtCon.ForeColor = System.Drawing.Color.ForestGreen
        Me.txtCon.Location = New System.Drawing.Point(678, 28)
        Me.txtCon.Name = "txtCon"
        Me.txtCon.Size = New System.Drawing.Size(203, 20)
        Me.txtCon.TabIndex = 83
        '
        'btnSearch_Con
        '
        Me.btnSearch_Con.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearch_Con.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.btnSearch_Con.Location = New System.Drawing.Point(895, 22)
        Me.btnSearch_Con.Name = "btnSearch_Con"
        Me.btnSearch_Con.Size = New System.Drawing.Size(91, 30)
        Me.btnSearch_Con.TabIndex = 82
        Me.btnSearch_Con.Text = "தேடு"
        Me.btnSearch_Con.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label3.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.Label3.Location = New System.Drawing.Point(187, 33)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(127, 13)
        Me.Label3.TabIndex = 81
        Me.Label3.Text = "சொற்பிரிப்பு வரம்பு"
        Me.Label3.Visible = False
        '
        'txtDelimiter_Con
        '
        Me.txtDelimiter_Con.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDelimiter_Con.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.txtDelimiter_Con.ForeColor = System.Drawing.Color.ForestGreen
        Me.txtDelimiter_Con.Location = New System.Drawing.Point(334, 30)
        Me.txtDelimiter_Con.Name = "txtDelimiter_Con"
        Me.txtDelimiter_Con.Size = New System.Drawing.Size(44, 20)
        Me.txtDelimiter_Con.TabIndex = 80
        Me.txtDelimiter_Con.Visible = False
        '
        'btnUpload_Con
        '
        Me.btnUpload_Con.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUpload_Con.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.btnUpload_Con.Location = New System.Drawing.Point(21, 24)
        Me.btnUpload_Con.Name = "btnUpload_Con"
        Me.btnUpload_Con.Size = New System.Drawing.Size(147, 33)
        Me.btnUpload_Con.TabIndex = 79
        Me.btnUpload_Con.Text = "கோப்பு இணை"
        Me.btnUpload_Con.UseVisualStyleBackColor = True
        '
        'dgvCon
        '
        Me.dgvCon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCon.Location = New System.Drawing.Point(359, 298)
        Me.dgvCon.Name = "dgvCon"
        Me.dgvCon.Size = New System.Drawing.Size(891, 219)
        Me.dgvCon.TabIndex = 78
        '
        'clbFileName_Con
        '
        Me.clbFileName_Con.BackColor = System.Drawing.SystemColors.Control
        Me.clbFileName_Con.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.clbFileName_Con.CheckOnClick = True
        Me.clbFileName_Con.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.clbFileName_Con.FormattingEnabled = True
        Me.clbFileName_Con.HorizontalScrollbar = True
        Me.clbFileName_Con.Location = New System.Drawing.Point(21, 81)
        Me.clbFileName_Con.Name = "clbFileName_Con"
        Me.clbFileName_Con.Size = New System.Drawing.Size(317, 437)
        Me.clbFileName_Con.TabIndex = 77
        '
        'rtbContent_Con
        '
        Me.rtbContent_Con.BackColor = System.Drawing.SystemColors.Control
        Me.rtbContent_Con.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.rtbContent_Con.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.rtbContent_Con.Location = New System.Drawing.Point(359, 81)
        Me.rtbContent_Con.Name = "rtbContent_Con"
        Me.rtbContent_Con.ReadOnly = True
        Me.rtbContent_Con.Size = New System.Drawing.Size(891, 206)
        Me.rtbContent_Con.TabIndex = 76
        Me.rtbContent_Con.Text = ""
        '
        'btnClear_Con
        '
        Me.btnClear_Con.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClear_Con.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.btnClear_Con.Location = New System.Drawing.Point(1005, 21)
        Me.btnClear_Con.Name = "btnClear_Con"
        Me.btnClear_Con.Size = New System.Drawing.Size(69, 30)
        Me.btnClear_Con.TabIndex = 86
        Me.btnClear_Con.Text = "அழி"
        Me.btnClear_Con.UseVisualStyleBackColor = True
        '
        'frmWordsCountConcordance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1284, 551)
        Me.Controls.Add(Me.btnClear_Con)
        Me.Controls.Add(Me.cmbGram_Con)
        Me.Controls.Add(Me.btnFill_Con)
        Me.Controls.Add(Me.txtCon)
        Me.Controls.Add(Me.btnSearch_Con)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtDelimiter_Con)
        Me.Controls.Add(Me.btnUpload_Con)
        Me.Controls.Add(Me.dgvCon)
        Me.Controls.Add(Me.clbFileName_Con)
        Me.Controls.Add(Me.rtbContent_Con)
        Me.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmWordsCountConcordance"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "சொல் எண்ணிக்கை"
        CType(Me.dgvCon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmbGram_Con As System.Windows.Forms.ComboBox
    Friend WithEvents btnFill_Con As System.Windows.Forms.Button
    Friend WithEvents txtCon As System.Windows.Forms.TextBox
    Friend WithEvents btnSearch_Con As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtDelimiter_Con As System.Windows.Forms.TextBox
    Friend WithEvents btnUpload_Con As System.Windows.Forms.Button
    Friend WithEvents dgvCon As System.Windows.Forms.DataGridView
    Friend WithEvents clbFileName_Con As System.Windows.Forms.CheckedListBox
    Friend WithEvents rtbContent_Con As System.Windows.Forms.RichTextBox
    Friend WithEvents btnClear_Con As System.Windows.Forms.Button
End Class
