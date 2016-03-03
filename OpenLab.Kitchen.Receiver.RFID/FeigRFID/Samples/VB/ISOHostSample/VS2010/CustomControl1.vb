Public Class CustomControl1
    Inherits System.Windows.Forms.Control

#Region " Vom Component Designer generierter Code "

    Public Sub New()
        MyBase.New()

        'Dieser Aufruf ist für den Komponenten-Designer erforderlich.
        InitializeComponent()

        'Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu

    End Sub

    'Das Steuerelement überschreibt den Löschvorgang zum Bereinigen der Komponentenliste.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Für den Steuerelement-Designer erforderlich
    Private components As System.ComponentModel.IContainer

    ' HINWEIS: Die folgende Prozedur ist für den Komponenten-Designer erforderlich.
    ' Sie kann mit dem Komponenten-Designer bearbeitet werden. Verwenden Sie nicht den
    ' Code-Editor zur Bearbeitung.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        components = New System.ComponentModel.Container()
    End Sub

#End Region

    Protected Overrides Sub OnPaint(ByVal pe As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(pe)

        ' Benutzerdefinierten Farbcode hier einfügen
    End Sub

End Class
