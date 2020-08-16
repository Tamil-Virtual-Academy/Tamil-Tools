Imports System
Imports System.Text
Imports System.Collections
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Drawing.Printing
Imports System.Data
Imports System.Windows.Forms
Class DataGridViewPrinter

    Private TheDataGridView As DataGridView

    ' The DataGridView Control which will be printed
    Private ThePrintDocument As PrintDocument

    ' The PrintDocument to be used for printing
    Private IsCenterOnPage As Boolean

    ' Determine if the report will be printed in the Top-Center of the page
    Private IsWithTitle As Boolean

    ' Determine if the page contain title text
    Private TheTitleText As String

    ' The title text to be printed in each page (if IsWithTitle is set to true)
    Private TheTitleFont As Font

    ' The font to be used with the title text (if IsWithTitle is set to true)
    Private TheTitleColor As Color

    ' The color to be used with the title text (if IsWithTitle is set to true)
    Private IsWithPaging As Boolean

    ' Determine if paging is used
    Private Shared CurrentRow As Integer

    ' A static parameter that keep track on which Row (in the DataGridView control) that should be printed
    Private Shared PageNumber As Integer

    Private PageWidth As Integer

    Private PageHeight As Integer

    Private LeftMargin As Integer

    Private TopMargin As Integer

    Private RightMargin As Integer

    Private BottomMargin As Integer

    Private CurrentY As Single

    ' A parameter that keep track on the y coordinate of the page, so the next object to be printed will start from this y coordinate
    Private RowHeaderHeight As Single

    Private RowsHeight As List(Of Single)

    Private ColumnsWidth As List(Of Single)

    Private TheDataGridViewWidth As Single

    ' Maintain a generic list to hold start/stop points for the column printing
    ' This will be used for wrapping in situations where the DataGridView will not fit on a single page
    Private mColumnPoints As List(Of Integer())

    Private mColumnPointsWidth As List(Of Single)

    Private mColumnPoint As Integer

    ' The class constructor
    Public Sub New(ByVal aDataGridView As DataGridView, ByVal aPrintDocument As PrintDocument, ByVal CenterOnPage As Boolean, ByVal WithTitle As Boolean, ByVal aTitleText As String, ByVal aTitleFont As Font, ByVal aTitleColor As Color, ByVal WithPaging As Boolean)
        MyBase.New()
        TheDataGridView = aDataGridView
        ThePrintDocument = aPrintDocument
        IsCenterOnPage = CenterOnPage
        IsWithTitle = WithTitle
        TheTitleText = aTitleText
        TheTitleFont = aTitleFont
        TheTitleColor = aTitleColor
        IsWithPaging = WithPaging
        PageNumber = 0
        RowsHeight = New List(Of Single)
        ColumnsWidth = New List(Of Single)
        mColumnPoints = New List(Of Integer())
        mColumnPointsWidth = New List(Of Single)
        ' Claculating the PageWidth and the PageHeight
        If Not ThePrintDocument.DefaultPageSettings.Landscape Then
            PageWidth = ThePrintDocument.DefaultPageSettings.PaperSize.Width
            PageHeight = ThePrintDocument.DefaultPageSettings.PaperSize.Height
        Else
            PageHeight = ThePrintDocument.DefaultPageSettings.PaperSize.Width
            PageWidth = ThePrintDocument.DefaultPageSettings.PaperSize.Height
        End If
        ' Claculating the page margins
        LeftMargin = ThePrintDocument.DefaultPageSettings.Margins.Left
        TopMargin = ThePrintDocument.DefaultPageSettings.Margins.Top
        RightMargin = ThePrintDocument.DefaultPageSettings.Margins.Right
        BottomMargin = ThePrintDocument.DefaultPageSettings.Margins.Bottom
        ' First, the current row to be printed is the first row in the DataGridView control
        CurrentRow = 0
    End Sub

    ' The function that calculate the height of each row (including the header row), the width of each column (according to the longest text in all its cells including the header cell), and the whole DataGridView width
    Private Sub Calculate(ByVal g As Graphics)
        If (PageNumber = 0) Then
            Dim tmpSize As SizeF = New SizeF
            Dim tmpFont As Font
            Dim tmpWidth As Single
            TheDataGridViewWidth = 0
            Dim i As Integer = 0
            Do While (i < TheDataGridView.Columns.Count)
                tmpFont = TheDataGridView.ColumnHeadersDefaultCellStyle.Font
                If (tmpFont Is Nothing) Then
                    tmpFont = TheDataGridView.DefaultCellStyle.Font
                End If
                tmpSize = g.MeasureString(TheDataGridView.Columns(i).HeaderText, tmpFont)
                tmpWidth = tmpSize.Width
                RowHeaderHeight = tmpSize.Height
                Dim j As Integer = 0
                Do While (j < TheDataGridView.Rows.Count)
                    tmpFont = TheDataGridView.Rows(j).DefaultCellStyle.Font
                    If (tmpFont Is Nothing) Then
                        tmpFont = TheDataGridView.DefaultCellStyle.Font
                    End If
                    tmpSize = g.MeasureString("Anything", tmpFont)
                    RowsHeight.Add(tmpSize.Height)
                    tmpSize = g.MeasureString(TheDataGridView.Rows(j).Cells(i).EditedFormattedValue.ToString, tmpFont)
                    If (tmpSize.Width > tmpWidth) Then
                        tmpWidth = tmpSize.Width
                    End If
                    j = (j + 1)
                Loop
                If TheDataGridView.Columns(i).Visible Then
                    TheDataGridViewWidth = (TheDataGridViewWidth + tmpWidth)
                End If
                ColumnsWidth.Add(tmpWidth)
                i = (i + 1)
            Loop
            ' Define the start/stop column points based on the page width and the DataGridView Width
            ' We will use this to determine the columns which are drawn on each page and how wrapping will be handled
            ' By default, the wrapping will occurr such that the maximum number of columns for a page will be determine
            Dim k As Integer
            Dim mStartPoint As Integer = 0
            k = 0
            Do While (k < TheDataGridView.Columns.Count)
                If TheDataGridView.Columns(k).Visible Then
                    mStartPoint = k
                    Exit Do
                End If
                k = (k + 1)
            Loop
            Dim mEndPoint As Integer = TheDataGridView.Columns.Count
            k = (TheDataGridView.Columns.Count - 1)
            Do While (k >= 0)
                If TheDataGridView.Columns(k).Visible Then
                    mEndPoint = (k + 1)
                    Exit Do
                End If
                k = (k - 1)
            Loop
            Dim mTempWidth As Single = TheDataGridViewWidth
            Dim mTempPrintArea As Single = (CType(PageWidth, Single) _
                        - (CType(LeftMargin, Single) - CType(RightMargin, Single)))
            ' We only care about handling where the total datagridview width is bigger then the print area
            If (TheDataGridViewWidth > mTempPrintArea) Then
                mTempWidth = 0.0!
                k = 0
                Do While (k < TheDataGridView.Columns.Count)
                    If TheDataGridView.Columns(k).Visible Then
                        mTempWidth = (mTempWidth + ColumnsWidth(k))
                        ' If the width is bigger than the page area, then define a new column print range
                        If (mTempWidth > mTempPrintArea) Then
                            mTempWidth = (mTempWidth - ColumnsWidth(k))
                            mColumnPoints.Add(New Integer() {mStartPoint, mEndPoint})
                            mColumnPointsWidth.Add(mTempWidth)
                            mStartPoint = k
                            mTempWidth = ColumnsWidth(k)
                        End If
                    End If
                    ' Our end point is actually one index above the current index
                    mEndPoint = (k + 1)
                    k = (k + 1)
                Loop
            End If
            ' Add the last set of columns
            mColumnPoints.Add(New Integer() {mStartPoint, mEndPoint})
            mColumnPointsWidth.Add(mTempWidth)
            mColumnPoint = 0
        End If
    End Sub

    ' The funtion that print the title, page number, and the header row
    Private Sub DrawHeader(ByVal g As Graphics)
        CurrentY = CType(TopMargin, Single)
        ' Printing the page number (if isWithPaging is set to true)
        If IsWithPaging Then
            PageNumber = (PageNumber + 1)
            Dim PageString As String = ("Page " + PageNumber.ToString)
            Dim PageStringFormat As StringFormat = New StringFormat
            PageStringFormat.Trimming = StringTrimming.Word
            PageStringFormat.FormatFlags = (StringFormatFlags.NoWrap _
                        Or (StringFormatFlags.LineLimit Or StringFormatFlags.NoClip))
            PageStringFormat.Alignment = StringAlignment.Far
            Dim PageStringFont As Font = New Font("Tahoma", 8, FontStyle.Regular, GraphicsUnit.Point)
            Dim PageStringRectangle As RectangleF = New RectangleF(CType(LeftMargin, Single), CurrentY, (CType(PageWidth, Single) _
                            - (CType(RightMargin, Single) - CType(LeftMargin, Single))), g.MeasureString(PageString, PageStringFont).Height)
            g.DrawString(PageString, PageStringFont, New SolidBrush(Color.Black), PageStringRectangle, PageStringFormat)
            CurrentY = (CurrentY + g.MeasureString(PageString, PageStringFont).Height)
        End If
        ' Printing the title (if IsWithTitle is set to true)
        If IsWithTitle Then
            Dim TitleFormat As StringFormat = New StringFormat
            TitleFormat.Trimming = StringTrimming.Word
            TitleFormat.FormatFlags = (StringFormatFlags.NoWrap _
                        Or (StringFormatFlags.LineLimit Or StringFormatFlags.NoClip))
            If IsCenterOnPage Then
                TitleFormat.Alignment = StringAlignment.Center
            Else
                TitleFormat.Alignment = StringAlignment.Near
            End If
            Dim TitleRectangle As RectangleF = New RectangleF(CType(LeftMargin, Single), CurrentY, (CType(PageWidth, Single) _
                            - (CType(RightMargin, Single) - CType(LeftMargin, Single))), g.MeasureString(TheTitleText, TheTitleFont).Height)
            g.DrawString(TheTitleText, TheTitleFont, New SolidBrush(TheTitleColor), TitleRectangle, TitleFormat)
            CurrentY = (CurrentY + g.MeasureString(TheTitleText, TheTitleFont).Height)
        End If
        ' Calculating the starting x coordinate that the printing process will start from
        Dim CurrentX As Single = CType(LeftMargin, Single)
        If IsCenterOnPage Then
            CurrentX = (CurrentX _
                        + (((CType(PageWidth, Single) _
                        - (CType(RightMargin, Single) - CType(LeftMargin, Single))) _
                        - mColumnPointsWidth(mColumnPoint)) _
                        / 2.0!))
        End If
        ' Setting the HeaderFore style
        Dim HeaderForeColor As Color = TheDataGridView.ColumnHeadersDefaultCellStyle.ForeColor
        If HeaderForeColor.IsEmpty Then
            HeaderForeColor = TheDataGridView.DefaultCellStyle.ForeColor
        End If
        Dim HeaderForeBrush As SolidBrush = New SolidBrush(HeaderForeColor)
        ' Setting the HeaderBack style
        Dim HeaderBackColor As Color = TheDataGridView.ColumnHeadersDefaultCellStyle.BackColor
        If HeaderBackColor.IsEmpty Then
            HeaderBackColor = TheDataGridView.DefaultCellStyle.BackColor
        End If
        Dim HeaderBackBrush As SolidBrush = New SolidBrush(HeaderBackColor)
        ' Setting the LinePen that will be used to draw lines and rectangles (derived from the GridColor property of the DataGridView control)
        Dim TheLinePen As Pen = New Pen(TheDataGridView.GridColor, 1)
        ' Setting the HeaderFont style
        Dim HeaderFont As Font = TheDataGridView.ColumnHeadersDefaultCellStyle.Font
        If (HeaderFont Is Nothing) Then
            HeaderFont = TheDataGridView.DefaultCellStyle.Font
        End If
        ' Calculating and drawing the HeaderBounds        
        Dim HeaderBounds As RectangleF = New RectangleF(CurrentX, CurrentY, mColumnPointsWidth(mColumnPoint), RowHeaderHeight)
        g.FillRectangle(HeaderBackBrush, HeaderBounds)
        ' Setting the format that will be used to print each cell of the header row
        Dim CellFormat As StringFormat = New StringFormat
        CellFormat.Trimming = StringTrimming.Word
        CellFormat.FormatFlags = (StringFormatFlags.NoWrap _
                    Or (StringFormatFlags.LineLimit Or StringFormatFlags.NoClip))
        ' Printing each visible cell of the header row
        Dim CellBounds As RectangleF
        Dim ColumnWidth As Single
        Dim i As Integer = CType(mColumnPoints(mColumnPoint).GetValue(0), Integer)
        Do While (i < CType(mColumnPoints(mColumnPoint).GetValue(1), Integer))
            If Not TheDataGridView.Columns(i).Visible Then
                'TODO: Warning!!! continue If
            End If
            ' If the column is not visible then ignore this iteration
            ColumnWidth = ColumnsWidth(i)
            ' Check the CurrentCell alignment and apply it to the CellFormat
            If TheDataGridView.ColumnHeadersDefaultCellStyle.Alignment.ToString.Contains("Right") Then
                CellFormat.Alignment = StringAlignment.Far
            ElseIf TheDataGridView.ColumnHeadersDefaultCellStyle.Alignment.ToString.Contains("Center") Then
                CellFormat.Alignment = StringAlignment.Center
            Else
                CellFormat.Alignment = StringAlignment.Near
            End If
            CellBounds = New RectangleF(CurrentX, CurrentY, ColumnWidth, RowHeaderHeight)
            ' Printing the cell text
            g.DrawString(TheDataGridView.Columns(i).HeaderText, HeaderFont, HeaderForeBrush, CellBounds, CellFormat)
            ' Drawing the cell bounds
            If (TheDataGridView.RowHeadersBorderStyle <> DataGridViewHeaderBorderStyle.None) Then
                g.DrawRectangle(TheLinePen, CurrentX, CurrentY, ColumnWidth, RowHeaderHeight)
            End If
            CurrentX = (CurrentX + ColumnWidth)
            i = (i + 1)
        Loop
        CurrentY = (CurrentY + RowHeaderHeight)
    End Sub

    ' The function that print a bunch of rows that fit in one page
    ' When it returns true, meaning that there are more rows still not printed, so another PagePrint action is required
    ' When it returns false, meaning that all rows are printed (the CureentRow parameter reaches the last row of the DataGridView control) and no further PagePrint action is required
    Private Function DrawRows(ByVal g As Graphics) As Boolean
        ' Setting the LinePen that will be used to draw lines and rectangles (derived from the GridColor property of the DataGridView control)
        Dim TheLinePen As Pen = New Pen(TheDataGridView.GridColor, 1)
        ' The style paramters that will be used to print each cell
        Dim RowFont As Font
        Dim RowForeColor As Color
        Dim RowBackColor As Color
        Dim RowForeBrush As SolidBrush
        Dim RowBackBrush As SolidBrush
        Dim RowAlternatingBackBrush As SolidBrush
        ' Setting the format that will be used to print each cell
        Dim CellFormat As StringFormat = New StringFormat
        CellFormat.Trimming = StringTrimming.Word
        CellFormat.FormatFlags = (StringFormatFlags.NoWrap Or StringFormatFlags.LineLimit)
        ' Printing each visible cell
        Dim RowBounds As RectangleF
        Dim CurrentX As Single
        Dim ColumnWidth As Single

        While (CurrentRow < TheDataGridView.Rows.Count)
            If TheDataGridView.Rows(CurrentRow).Visible Then
                ' Setting the row font style
                RowFont = TheDataGridView.Rows(CurrentRow).DefaultCellStyle.Font
                If (RowFont Is Nothing) Then
                    RowFont = TheDataGridView.DefaultCellStyle.Font
                End If
                ' Setting the RowFore style
                RowForeColor = TheDataGridView.Rows(CurrentRow).DefaultCellStyle.ForeColor
                If RowForeColor.IsEmpty Then
                    RowForeColor = TheDataGridView.DefaultCellStyle.ForeColor
                End If
                RowForeBrush = New SolidBrush(RowForeColor)
                ' Setting the RowBack (for even rows) and the RowAlternatingBack (for odd rows) styles
                RowBackColor = TheDataGridView.Rows(CurrentRow).DefaultCellStyle.BackColor
                If RowBackColor.IsEmpty Then
                    RowBackBrush = New SolidBrush(TheDataGridView.DefaultCellStyle.BackColor)
                    RowAlternatingBackBrush = New SolidBrush(TheDataGridView.AlternatingRowsDefaultCellStyle.BackColor)
                Else
                    RowBackBrush = New SolidBrush(RowBackColor)
                    RowAlternatingBackBrush = New SolidBrush(RowBackColor)
                End If
                ' Calculating the starting x coordinate that the printing process will start from
                CurrentX = CType(LeftMargin, Single)
                If IsCenterOnPage Then
                    CurrentX = (CurrentX _
                                + (((CType(PageWidth, Single) _
                                - (CType(RightMargin, Single) - CType(LeftMargin, Single))) _
                                - mColumnPointsWidth(mColumnPoint)) _
                                / 2.0!))
                End If
                ' Calculating the entire CurrentRow bounds                
                RowBounds = New RectangleF(CurrentX, CurrentY, mColumnPointsWidth(mColumnPoint), RowsHeight(CurrentRow))
                ' Filling the back of the CurrentRow
                If ((CurrentRow Mod 2) _
                            = 0) Then
                    g.FillRectangle(RowBackBrush, RowBounds)
                Else
                    g.FillRectangle(RowAlternatingBackBrush, RowBounds)
                End If
                ' Printing each visible cell of the CurrentRow                
                Dim CurrentCell As Integer = CType(mColumnPoints(mColumnPoint).GetValue(0), Integer)
                Do While (CurrentCell < CType(mColumnPoints(mColumnPoint).GetValue(1), Integer))
                    If Not TheDataGridView.Columns(CurrentCell).Visible Then
                        'TODO: Warning!!! continue If                  
                    End If
                    ' If the cell is belong to invisible column, then ignore this iteration
                    ' Check the CurrentCell alignment and apply it to the CellFormat
                    If TheDataGridView.Columns(CurrentCell).DefaultCellStyle.Alignment.ToString.Contains("Right") Then
                        CellFormat.Alignment = StringAlignment.Far
                    ElseIf TheDataGridView.Columns(CurrentCell).DefaultCellStyle.Alignment.ToString.Contains("Center") Then
                        CellFormat.Alignment = StringAlignment.Center
                    Else
                        CellFormat.Alignment = StringAlignment.Near
                    End If
                    ColumnWidth = ColumnsWidth(CurrentCell)
                    Dim CellBounds As RectangleF = New RectangleF(CurrentX, CurrentY, ColumnWidth, RowsHeight(CurrentRow))
                    ' Printing the cell text
                    g.DrawString(TheDataGridView.Rows(CurrentRow).Cells(CurrentCell).EditedFormattedValue.ToString, RowFont, RowForeBrush, CellBounds, CellFormat)
                    ' Drawing the cell bounds
                    If (TheDataGridView.CellBorderStyle <> DataGridViewCellBorderStyle.None) Then
                        g.DrawRectangle(TheLinePen, CurrentX, CurrentY, ColumnWidth, RowsHeight(CurrentRow))
                    End If
                    CurrentX = (CurrentX + ColumnWidth)
                    CurrentCell = (CurrentCell + 1)
                Loop
                CurrentY = (CurrentY + RowsHeight(CurrentRow))
                ' Checking if the CurrentY is exceeds the page boundries
                ' If so then exit the function and returning true meaning another PagePrint action is required
                If (CType(CurrentY, Integer) _
                            > (PageHeight _
                            - (TopMargin - BottomMargin))) Then
                    CurrentRow = (CurrentRow + 1)
                    Return True
                End If
            End If
            CurrentRow = (CurrentRow + 1)

        End While
        CurrentRow = 0
        mColumnPoint = (mColumnPoint + 1)
        ' Continue to print the next group of columns
        If (mColumnPoint = mColumnPoints.Count) Then
            mColumnPoint = 0
            Return False
        Else
            Return True
        End If
    End Function

    ' The method that calls all other functions
    Public Function DrawDataGridView(ByVal g As Graphics) As Boolean
        Try
            Calculate(g)
            DrawHeader(g)
            Dim bContinue As Boolean = DrawRows(g)
            Return bContinue
        Catch ex As Exception
            MessageBox.Show(("Operation failed: " + ex.Message.ToString), (Application.ProductName + " - Error"), MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function
End Class