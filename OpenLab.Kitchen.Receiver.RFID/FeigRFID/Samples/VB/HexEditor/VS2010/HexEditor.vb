'---------------------------------------------------------------
'Copyright © 2003-2008	FEIG ELECTRONIC GmbH, All Rights Reserved.
'						Lange Strasse 4
'						D-35781 Weilburg
'						Federal Republic of Germany
'						phone    : +49 6471 31090
'						fax      : +49 6471 310999
'						e-mail   : obid-support@feig.de
'						Internet : http://www.feig.de
'
'OBID® and OBID i-scan® are registered trademarks of FEIG ELECTRONIC GmbH
'----------------------------------------------------------------

Imports System

Namespace OBID

    Public Class HexEditor
        Inherits System.Windows.Forms.UserControl

#Region " Vom Windows Form Designer generierter Code "

        Public Sub New()
            MyBase.New()

            ' Dieser Aufruf ist für den Windows Form-Designer erforderlich.
            InitializeComponent()

            ' Initialisierungen nach dem Aufruf InitializeComponent() hinzufügen

        End Sub

        ' UserControl1 überschreibt den Löschvorgang zur Bereinigung der Komponentenliste.
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                If Not (components Is Nothing) Then
                    components.Dispose()
                End If
            End If
            MyBase.Dispose(disposing)
        End Sub

        ' Für Windows Form-Designer erforderlich
        Private components As System.ComponentModel.IContainer

        'HINWEIS: Die folgende Prozedur ist für den Windows Form-Designer erforderlich
        'Sie kann mit dem Windows Form-Designer modifiziert werden.
        'Verwenden Sie nicht den Code-Editor zur Bearbeitung.
        Friend WithEvents Hexer As System.Windows.Forms.TextBox
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.Hexer = New System.Windows.Forms.TextBox
            Me.SuspendLayout()
            '
            'Hexer
            '
            Me.Hexer.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.Hexer.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Hexer.Location = New System.Drawing.Point(0, 0)
            Me.Hexer.Multiline = True
            Me.Hexer.Name = "Hexer"
            Me.Hexer.ScrollBars = System.Windows.Forms.ScrollBars.Both
            Me.Hexer.Size = New System.Drawing.Size(272, 256)
            Me.Hexer.TabIndex = 1
            Me.Hexer.Text = ""
            Me.Hexer.WordWrap = False
            '
            'UserControl1
            '
            Me.Controls.Add(Me.Hexer)
            Me.Name = "UserControl1"
            Me.Size = New System.Drawing.Size(272, 256)
            Me.ResumeLayout(False)

        End Sub

#End Region
        Public Sub InsertData(ByVal index As Integer, ByVal b As Byte())
            If b Is Nothing Then Return

            Dim s As String
            Dim i As Integer

            row = Fix(index / _columnCount)
            column = (index Mod _columnCount) * 3 + 8
            For i = 0 To b.Length - 1
                s = Trim(b(i).ToString("X"))
                If s.Length = 1 Then s = "0" + s
                InsertText(Trim(Mid(s, 1)))
                InsertText(Trim(Mid(s, 2)))
            Next
        End Sub

        Public Function GetData(ByVal index As Integer, ByVal count As Integer) As Byte()
            Dim b(count) As Byte
            Dim i As Integer
            Dim s As String

            For i = 0 To count - 1
                s = GetText(index + i)
                If s = "" Then Exit Function
                b(i) = OBID.FeHexConvert.HexStringToByte(s)
            Next

            Return b
        End Function

        Private Sub Hexer_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Hexer.MouseUp
            Hexer.SelectionLength = 0
            row = Fix(Hexer.SelectionStart / (_columnCount * 4 + 10))
            column = Hexer.SelectionStart Mod (_columnCount * 4 + 10)
            ' Cursor auf die richtige Position setzen fall in dem Hex-Bereich geklickt wurde
            If column < 8 Then column = 8
            If column < 7 + _columnCount * 3 Then
                If (column - 7) Mod 3 = 0 Then
                    column = column + 1
                End If
            End If
            Hexer.SelectionStart = row * (_columnCount * 4 + 10) + column
        End Sub

        Private Sub Hexer_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Hexer.KeyPress
            Select Case e.KeyChar
                Case "0" To "9", "a" To "f", "A" To "F"
                    InsertText(e.KeyChar.ToString)
                    e.Handled = True
                Case Else
                    e.Handled = True
            End Select

        End Sub

        Private Sub InsertText(ByVal s As String)
            If (column > 7) And (column < 7 + _columnCount * 3) Then
                Dim pos As Integer
                Dim tmp As String
                column = column + 1
                pos = row * (_columnCount * 4 + 10) + column
                If pos >= Hexer.Text.Length Then Exit Sub
                Mid(Hexer.Text, pos) = s.ToUpper

                ' Block herausnehmen
                If column Mod 3 = 0 Then
                    tmp = Mid(Hexer.Text, pos, 2)
                End If
                If column Mod 3 = 1 Then
                    tmp = Mid(Hexer.Text, pos - 1, 2)
                End If
                ' Position für die ASCII-Schreibweise berechnen
                pos = row * (_columnCount * 4 + 10) + 3 * _columnCount + 9 + Fix((column - 9) / 3)
                Dim i As Integer
                i = OBID.FeHexConvert.HexStringToByte(tmp)
                ' Es sollen nur druckbare Zeichen eingefügen
                Select Case i
                    Case 21 To 255
                        Mid(Hexer.Text, pos) = Chr(i)
                End Select

                ' nur zweierblöcke sollen eingegeben werden können
                If (column - 7) Mod 3 = 0 Then
                    column = column + 1
                End If
                ' Am Ende der Zeile soll der Cursor in die neue Zeile springen
                If column = 7 + _columnCount * 3 Or column = 8 + _columnCount * 3 Then
                    column = 8
                    row = row + 1
                End If
                ' Für die bessere Optik soll auch der Cursor an der richtigen Position angezeigt werden
                Hexer.SelectionLength = 0
                Hexer.SelectionStart = row * (_columnCount * 4 + 10) + column
            End If
        End Sub

        Private Function GetText(ByVal index As Integer) As String
            row = Fix(index / _columnCount)
            column = (index Mod _columnCount) * 3 + 9

            Dim pos As Integer
            Dim s As String
            pos = row * (_columnCount * 4 + 10) + column
            If pos >= Hexer.Text.Length - 5 Then Exit Function
            s = Mid(Hexer.Text, pos, 2)

            Return s
        End Function

        Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            SetSize(128, 4)
        End Sub

        Public Sub SetSize(ByVal rowcount As Integer, ByVal columncount As Integer)
            Dim i As Integer
            Dim j As Integer

            If _rowCount = rowcount And _columnCount = columncount Then
                Return
            End If

            _rowCount = rowcount
            _columnCount = columncount
            Hexer.Visible = False

            Hexer.Text = ""
            For i = 0 To rowcount - 1
                Hexer.AppendText("DB ")
                If i < 10 Then
                    Hexer.AppendText(" ")
                End If
                If i < 100 Then
                    Hexer.AppendText(" ")
                End If
                Hexer.AppendText(i.ToString + ": ")
                For j = 0 To columncount - 1
                    Hexer.AppendText("00 ")
                Next
                For j = 0 To columncount - 1
                    Hexer.AppendText(".")
                Next
                Hexer.AppendText(vbNewLine)
            Next
            Hexer.Visible = True
        End Sub

        Public Property ColumnCount() As Integer
            Get
                Return _columnCount
            End Get
            Set(ByVal Value As Integer)
                Dim b() As Byte

                b = Me.GetData(0, _columnCount * _rowCount)
                Me.SetSize(_rowCount, Value)
                Me.InsertData(0, b)
            End Set
        End Property

        Public ReadOnly Property RowCount() As Integer
            Get
                Return _rowCount
            End Get
        End Property

        Private row As Integer
        Private column As Integer
        Private _columnCount As Integer
        Private _rowCount As Integer
    End Class
End Namespace
