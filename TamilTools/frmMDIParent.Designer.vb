<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMDIParent
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMDIParent))
        Me.MenuStrip = New System.Windows.Forms.MenuStrip()
        Me.mnuWordsCount = New System.Windows.Forms.ToolStripMenuItem()
        Me.SingleFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MultipleFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CoOccurrenceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDomainIdentification = New System.Windows.Forms.ToolStripMenuItem()
        Me.DomainIdentifierToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DomainIdentifierUsingDictionaryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuCategorizingFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.MenuStrip.SuspendLayout()
        Me.StatusStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip
        '
        Me.MenuStrip.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuWordsCount, Me.mnuDomainIdentification, Me.mnuCategorizingFile})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Padding = New System.Windows.Forms.Padding(7, 2, 0, 2)
        Me.MenuStrip.Size = New System.Drawing.Size(1012, 26)
        Me.MenuStrip.TabIndex = 5
        Me.MenuStrip.Text = "MenuStrip"
        '
        'mnuWordsCount
        '
        Me.mnuWordsCount.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SingleFileToolStripMenuItem, Me.MultipleFileToolStripMenuItem, Me.CoOccurrenceToolStripMenuItem})
        Me.mnuWordsCount.Name = "mnuWordsCount"
        Me.mnuWordsCount.Size = New System.Drawing.Size(99, 22)
        Me.mnuWordsCount.Text = "Words Count"
        '
        'SingleFileToolStripMenuItem
        '
        Me.SingleFileToolStripMenuItem.Name = "SingleFileToolStripMenuItem"
        Me.SingleFileToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.SingleFileToolStripMenuItem.Text = "Single File"
        '
        'MultipleFileToolStripMenuItem
        '
        Me.MultipleFileToolStripMenuItem.Name = "MultipleFileToolStripMenuItem"
        Me.MultipleFileToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.MultipleFileToolStripMenuItem.Text = "Multiple File"
        '
        'CoOccurrenceToolStripMenuItem
        '
        Me.CoOccurrenceToolStripMenuItem.Name = "CoOccurrenceToolStripMenuItem"
        Me.CoOccurrenceToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.CoOccurrenceToolStripMenuItem.Text = "Concordance"
        '
        'mnuDomainIdentification
        '
        Me.mnuDomainIdentification.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DomainIdentifierToolStripMenuItem, Me.DomainIdentifierUsingDictionaryToolStripMenuItem})
        Me.mnuDomainIdentification.Name = "mnuDomainIdentification"
        Me.mnuDomainIdentification.Size = New System.Drawing.Size(152, 22)
        Me.mnuDomainIdentification.Text = "Domain Identification"
        Me.mnuDomainIdentification.Visible = False
        '
        'DomainIdentifierToolStripMenuItem
        '
        Me.DomainIdentifierToolStripMenuItem.Name = "DomainIdentifierToolStripMenuItem"
        Me.DomainIdentifierToolStripMenuItem.Size = New System.Drawing.Size(286, 22)
        Me.DomainIdentifierToolStripMenuItem.Text = "Domain Identifier"
        '
        'DomainIdentifierUsingDictionaryToolStripMenuItem
        '
        Me.DomainIdentifierUsingDictionaryToolStripMenuItem.Name = "DomainIdentifierUsingDictionaryToolStripMenuItem"
        Me.DomainIdentifierUsingDictionaryToolStripMenuItem.Size = New System.Drawing.Size(286, 22)
        Me.DomainIdentifierUsingDictionaryToolStripMenuItem.Text = "Domain Identifier Using Dictionary"
        '
        'mnuCategorizingFile
        '
        Me.mnuCategorizingFile.Name = "mnuCategorizingFile"
        Me.mnuCategorizingFile.Size = New System.Drawing.Size(123, 22)
        Me.mnuCategorizingFile.Text = "Categorizing File"
        Me.mnuCategorizingFile.Visible = False
        '
        'StatusStrip
        '
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 292)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Padding = New System.Windows.Forms.Padding(1, 0, 16, 0)
        Me.StatusStrip.Size = New System.Drawing.Size(1012, 22)
        Me.StatusStrip.TabIndex = 7
        Me.StatusStrip.Text = "StatusStrip"
        '
        'ToolStripStatusLabel
        '
        Me.ToolStripStatusLabel.Name = "ToolStripStatusLabel"
        Me.ToolStripStatusLabel.Size = New System.Drawing.Size(39, 17)
        Me.ToolStripStatusLabel.Text = "Status"
        '
        'frmMDIParent
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1012, 314)
        Me.Controls.Add(Me.MenuStrip)
        Me.Controls.Add(Me.StatusStrip)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip
        Me.Name = "frmMDIParent"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TamilTools -      Copyright @ TVA"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents ToolStripStatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents mnuWordsCount As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDomainIdentification As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuCategorizingFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SingleFileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MultipleFileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CoOccurrenceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DomainIdentifierToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DomainIdentifierUsingDictionaryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
