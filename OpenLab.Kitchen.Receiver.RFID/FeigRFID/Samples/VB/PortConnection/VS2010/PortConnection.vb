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
    Public Class PortConfig
        Inherits System.Windows.Forms.Form

#Region " Vom Windows Form Designer generierter Code "

        Public Sub New(ByRef reader As FedmIscReader)
            MyBase.New()

            ' Dieser Aufruf ist für den Windows Form-Designer erforderlich.
            InitializeComponent()

            Try
                Dim i As Integer
                For i = 1 To 4
                    Me.ComboBoxPortNumber.Items.Add(i)
                Next
                Me.ComboBoxPortNumber.SelectedIndex = 0
            Catch ex As FePortDriverException
                Return
            End Try

            Me.ComboBoxBaudrate.SelectedIndex = 5
            Me.ComboBoxFrame.SelectedIndex = 7
            Me.Reader = reader
        End Sub

        ' Die Form überschreibt den Löschvorgang der Basisklasse, um Komponenten zu bereinigen.
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
        Friend WithEvents RadioButtonTcp As System.Windows.Forms.RadioButton
        Friend WithEvents RadioButtonSerial As System.Windows.Forms.RadioButton
        Friend WithEvents ButtonConnect As System.Windows.Forms.Button
        Friend WithEvents TextBoxTcpHost As System.Windows.Forms.TextBox
        Friend WithEvents TextBoxTcpPort As System.Windows.Forms.TextBox
        Friend WithEvents TextBoxTcpTimeout As System.Windows.Forms.TextBox
        Friend WithEvents ComboBoxPortNumber As System.Windows.Forms.ComboBox
        Friend WithEvents ComboBoxBaudrate As System.Windows.Forms.ComboBox
        Friend WithEvents ComboBoxFrame As System.Windows.Forms.ComboBox
        Friend WithEvents TextBoxTimeout As System.Windows.Forms.TextBox
        Friend WithEvents GroupBoxTcp As System.Windows.Forms.GroupBox
        Friend WithEvents LabelTcpTimeout As System.Windows.Forms.Label
        Friend WithEvents LabelTcpPort As System.Windows.Forms.Label
        Friend WithEvents LabelHost As System.Windows.Forms.Label
        Friend WithEvents GroupBoxSerial As System.Windows.Forms.GroupBox
        Friend WithEvents LabelTimeout As System.Windows.Forms.Label
        Friend WithEvents LabelFrame As System.Windows.Forms.Label
        Friend WithEvents LabelBaudrate As System.Windows.Forms.Label
        Friend WithEvents LabelPortNumber As System.Windows.Forms.Label
        Friend WithEvents RadioButtonUSB As System.Windows.Forms.RadioButton
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PortConfig))
            Me.GroupBoxTcp = New System.Windows.Forms.GroupBox()
            Me.TextBoxTcpTimeout = New System.Windows.Forms.TextBox()
            Me.TextBoxTcpPort = New System.Windows.Forms.TextBox()
            Me.TextBoxTcpHost = New System.Windows.Forms.TextBox()
            Me.LabelTcpTimeout = New System.Windows.Forms.Label()
            Me.LabelTcpPort = New System.Windows.Forms.Label()
            Me.LabelHost = New System.Windows.Forms.Label()
            Me.GroupBoxSerial = New System.Windows.Forms.GroupBox()
            Me.TextBoxTimeout = New System.Windows.Forms.TextBox()
            Me.ComboBoxFrame = New System.Windows.Forms.ComboBox()
            Me.ComboBoxBaudrate = New System.Windows.Forms.ComboBox()
            Me.ComboBoxPortNumber = New System.Windows.Forms.ComboBox()
            Me.LabelTimeout = New System.Windows.Forms.Label()
            Me.LabelFrame = New System.Windows.Forms.Label()
            Me.LabelBaudrate = New System.Windows.Forms.Label()
            Me.LabelPortNumber = New System.Windows.Forms.Label()
            Me.RadioButtonTcp = New System.Windows.Forms.RadioButton()
            Me.RadioButtonSerial = New System.Windows.Forms.RadioButton()
            Me.ButtonConnect = New System.Windows.Forms.Button()
            Me.RadioButtonUSB = New System.Windows.Forms.RadioButton()
            Me.GroupBoxTcp.SuspendLayout()
            Me.GroupBoxSerial.SuspendLayout()
            Me.SuspendLayout()
            '
            'GroupBoxTcp
            '
            Me.GroupBoxTcp.Controls.Add(Me.TextBoxTcpTimeout)
            Me.GroupBoxTcp.Controls.Add(Me.TextBoxTcpPort)
            Me.GroupBoxTcp.Controls.Add(Me.TextBoxTcpHost)
            Me.GroupBoxTcp.Controls.Add(Me.LabelTcpTimeout)
            Me.GroupBoxTcp.Controls.Add(Me.LabelTcpPort)
            Me.GroupBoxTcp.Controls.Add(Me.LabelHost)
            Me.GroupBoxTcp.Location = New System.Drawing.Point(8, 8)
            Me.GroupBoxTcp.Name = "GroupBoxTcp"
            Me.GroupBoxTcp.Size = New System.Drawing.Size(160, 184)
            Me.GroupBoxTcp.TabIndex = 0
            Me.GroupBoxTcp.TabStop = False
            Me.GroupBoxTcp.Text = "TCP/IP"
            '
            'TextBoxTcpTimeout
            '
            Me.TextBoxTcpTimeout.Location = New System.Drawing.Point(64, 112)
            Me.TextBoxTcpTimeout.Name = "TextBoxTcpTimeout"
            Me.TextBoxTcpTimeout.Size = New System.Drawing.Size(88, 20)
            Me.TextBoxTcpTimeout.TabIndex = 5
            Me.TextBoxTcpTimeout.Text = "3000"
            '
            'TextBoxTcpPort
            '
            Me.TextBoxTcpPort.Location = New System.Drawing.Point(64, 72)
            Me.TextBoxTcpPort.Name = "TextBoxTcpPort"
            Me.TextBoxTcpPort.Size = New System.Drawing.Size(88, 20)
            Me.TextBoxTcpPort.TabIndex = 4
            Me.TextBoxTcpPort.Text = "10001"
            '
            'TextBoxTcpHost
            '
            Me.TextBoxTcpHost.Location = New System.Drawing.Point(64, 32)
            Me.TextBoxTcpHost.Name = "TextBoxTcpHost"
            Me.TextBoxTcpHost.Size = New System.Drawing.Size(88, 20)
            Me.TextBoxTcpHost.TabIndex = 3
            Me.TextBoxTcpHost.Text = "192.168.10.10"
            '
            'LabelTcpTimeout
            '
            Me.LabelTcpTimeout.Location = New System.Drawing.Point(16, 112)
            Me.LabelTcpTimeout.Name = "LabelTcpTimeout"
            Me.LabelTcpTimeout.Size = New System.Drawing.Size(100, 20)
            Me.LabelTcpTimeout.TabIndex = 2
            Me.LabelTcpTimeout.Text = "Timeout"
            '
            'LabelTcpPort
            '
            Me.LabelTcpPort.Location = New System.Drawing.Point(16, 72)
            Me.LabelTcpPort.Name = "LabelTcpPort"
            Me.LabelTcpPort.Size = New System.Drawing.Size(100, 20)
            Me.LabelTcpPort.TabIndex = 1
            Me.LabelTcpPort.Text = "Port"
            '
            'LabelHost
            '
            Me.LabelHost.Location = New System.Drawing.Point(16, 32)
            Me.LabelHost.Name = "LabelHost"
            Me.LabelHost.Size = New System.Drawing.Size(100, 20)
            Me.LabelHost.TabIndex = 0
            Me.LabelHost.Text = "Host"
            '
            'GroupBoxSerial
            '
            Me.GroupBoxSerial.Controls.Add(Me.TextBoxTimeout)
            Me.GroupBoxSerial.Controls.Add(Me.ComboBoxFrame)
            Me.GroupBoxSerial.Controls.Add(Me.ComboBoxBaudrate)
            Me.GroupBoxSerial.Controls.Add(Me.ComboBoxPortNumber)
            Me.GroupBoxSerial.Controls.Add(Me.LabelTimeout)
            Me.GroupBoxSerial.Controls.Add(Me.LabelFrame)
            Me.GroupBoxSerial.Controls.Add(Me.LabelBaudrate)
            Me.GroupBoxSerial.Controls.Add(Me.LabelPortNumber)
            Me.GroupBoxSerial.Location = New System.Drawing.Point(176, 8)
            Me.GroupBoxSerial.Name = "GroupBoxSerial"
            Me.GroupBoxSerial.Size = New System.Drawing.Size(184, 184)
            Me.GroupBoxSerial.TabIndex = 1
            Me.GroupBoxSerial.TabStop = False
            Me.GroupBoxSerial.Text = "Serial Port"
            '
            'TextBoxTimeout
            '
            Me.TextBoxTimeout.Location = New System.Drawing.Point(88, 144)
            Me.TextBoxTimeout.Name = "TextBoxTimeout"
            Me.TextBoxTimeout.Size = New System.Drawing.Size(88, 20)
            Me.TextBoxTimeout.TabIndex = 8
            Me.TextBoxTimeout.Text = "1000"
            '
            'ComboBoxFrame
            '
            Me.ComboBoxFrame.Items.AddRange(New Object() {"7N1", "7E1", "7O1", "7N2", "7E2", "7O2", "8N1", "8E1", "8O1"})
            Me.ComboBoxFrame.Location = New System.Drawing.Point(88, 104)
            Me.ComboBoxFrame.Name = "ComboBoxFrame"
            Me.ComboBoxFrame.Size = New System.Drawing.Size(88, 21)
            Me.ComboBoxFrame.TabIndex = 7
            '
            'ComboBoxBaudrate
            '
            Me.ComboBoxBaudrate.Items.AddRange(New Object() {"1200", "2400", "4800", "9600", "19200", "38400", "57600", "115200"})
            Me.ComboBoxBaudrate.Location = New System.Drawing.Point(88, 64)
            Me.ComboBoxBaudrate.Name = "ComboBoxBaudrate"
            Me.ComboBoxBaudrate.Size = New System.Drawing.Size(88, 21)
            Me.ComboBoxBaudrate.TabIndex = 6
            '
            'ComboBoxPortNumber
            '
            Me.ComboBoxPortNumber.Location = New System.Drawing.Point(88, 32)
            Me.ComboBoxPortNumber.Name = "ComboBoxPortNumber"
            Me.ComboBoxPortNumber.Size = New System.Drawing.Size(88, 21)
            Me.ComboBoxPortNumber.TabIndex = 5
            '
            'LabelTimeout
            '
            Me.LabelTimeout.Location = New System.Drawing.Point(16, 152)
            Me.LabelTimeout.Name = "LabelTimeout"
            Me.LabelTimeout.Size = New System.Drawing.Size(48, 23)
            Me.LabelTimeout.TabIndex = 4
            Me.LabelTimeout.Text = "Timeout"
            '
            'LabelFrame
            '
            Me.LabelFrame.Location = New System.Drawing.Point(16, 112)
            Me.LabelFrame.Name = "LabelFrame"
            Me.LabelFrame.Size = New System.Drawing.Size(40, 23)
            Me.LabelFrame.TabIndex = 3
            Me.LabelFrame.Text = "Frame"
            '
            'LabelBaudrate
            '
            Me.LabelBaudrate.Location = New System.Drawing.Point(16, 72)
            Me.LabelBaudrate.Name = "LabelBaudrate"
            Me.LabelBaudrate.Size = New System.Drawing.Size(56, 23)
            Me.LabelBaudrate.TabIndex = 2
            Me.LabelBaudrate.Text = "Baudrate"
            '
            'LabelPortNumber
            '
            Me.LabelPortNumber.Location = New System.Drawing.Point(16, 32)
            Me.LabelPortNumber.Name = "LabelPortNumber"
            Me.LabelPortNumber.Size = New System.Drawing.Size(64, 23)
            Me.LabelPortNumber.TabIndex = 1
            Me.LabelPortNumber.Text = "Portnumber"
            '
            'RadioButtonTcp
            '
            Me.RadioButtonTcp.Location = New System.Drawing.Point(368, 8)
            Me.RadioButtonTcp.Name = "RadioButtonTcp"
            Me.RadioButtonTcp.Size = New System.Drawing.Size(104, 24)
            Me.RadioButtonTcp.TabIndex = 2
            Me.RadioButtonTcp.Text = "TCP/IP"
            '
            'RadioButtonSerial
            '
            Me.RadioButtonSerial.Checked = True
            Me.RadioButtonSerial.Location = New System.Drawing.Point(368, 32)
            Me.RadioButtonSerial.Name = "RadioButtonSerial"
            Me.RadioButtonSerial.Size = New System.Drawing.Size(104, 24)
            Me.RadioButtonSerial.TabIndex = 3
            Me.RadioButtonSerial.TabStop = True
            Me.RadioButtonSerial.Text = "Serial Port"
            '
            'ButtonConnect
            '
            Me.ButtonConnect.Location = New System.Drawing.Point(368, 168)
            Me.ButtonConnect.Name = "ButtonConnect"
            Me.ButtonConnect.Size = New System.Drawing.Size(75, 23)
            Me.ButtonConnect.TabIndex = 5
            Me.ButtonConnect.Text = "C&onnect"
            '
            'RadioButtonUSB
            '
            Me.RadioButtonUSB.Location = New System.Drawing.Point(368, 56)
            Me.RadioButtonUSB.Name = "RadioButtonUSB"
            Me.RadioButtonUSB.Size = New System.Drawing.Size(104, 24)
            Me.RadioButtonUSB.TabIndex = 6
            Me.RadioButtonUSB.Text = "USB"
            '
            'PortConfig
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(450, 199)
            Me.Controls.Add(Me.RadioButtonUSB)
            Me.Controls.Add(Me.ButtonConnect)
            Me.Controls.Add(Me.RadioButtonSerial)
            Me.Controls.Add(Me.RadioButtonTcp)
            Me.Controls.Add(Me.GroupBoxSerial)
            Me.Controls.Add(Me.GroupBoxTcp)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "PortConfig"
            Me.Text = "Connection configuration"
            Me.GroupBoxTcp.ResumeLayout(False)
            Me.GroupBoxTcp.PerformLayout()
            Me.GroupBoxSerial.ResumeLayout(False)
            Me.GroupBoxSerial.PerformLayout()
            Me.ResumeLayout(False)

        End Sub

#End Region

        Public Sub ClosePorts()
            fedm.DisConnect()
        End Sub

        Public WriteOnly Property Reader()
            Set(ByVal Value)
                fedm = Value
            End Set
        End Property

        Private Sub RadioButtonTcp_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonTcp.CheckedChanged
            EnableTCP(True)
            EnableSerial(False)
        End Sub

        Private Sub RadioButtonSerial_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonSerial.CheckedChanged
            EnableTCP(False)
            EnableSerial(True)
        End Sub

        Private Sub ButtonClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Me.Visible = False
        End Sub

        Private Sub ButtonConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonConnect.Click
            If Me.fedm.Connected Then fedm.DisConnect()

            If Me.RadioButtonSerial.Checked Then
                OpenSerialPort()
            ElseIf Me.RadioButtonTcp.Checked Then
                OpenTCPConnection()
            Else
                OpenUSBPort()
            End If
            Me.Visible = False
        End Sub

        Private Sub OpenSerialPort()
            Dim back As Int32

            Try
                fedm.ConnectCOMM(Me.ComboBoxPortNumber.SelectedItem, True)
                System.Console.WriteLine(fedm.GetErrorText(back))
                fedm.SetPortPara("Baud", Me.ComboBoxBaudrate.SelectedItem)
                System.Console.WriteLine(fedm.GetErrorText(back))
                fedm.SetPortPara("frame", Me.ComboBoxFrame.SelectedItem)
                System.Console.WriteLine(fedm.GetErrorText(back))
                fedm.SetPortPara("timeout", Me.TextBoxTimeout.Text)
                System.Console.WriteLine(fedm.GetErrorText(back))
            Catch ex As FedmException
                MessageBox.Show(ex.ToString, "Error")
            Catch ex As FePortDriverException
                MessageBox.Show(ex.ToString, "Error")
            End Try
        End Sub

        Private Sub OpenTCPConnection()
            Dim tcpPort As Integer
            Dim host As String
            Dim timeout As Integer

            tcpPort = Val(TextBoxTcpPort.Text)
            host = Me.TextBoxTcpHost.Text
            timeout = Val(Me.TextBoxTcpTimeout.Text)

            Try
                fedm.ConnectTCP(host, tcpPort)
                fedm.SetPortPara("Timeout", timeout)
            Catch ex As FePortDriverException
                MessageBox.Show(ex.ToString, "Error")
            End Try
        End Sub

        Private Sub OpenUSBPort()
            Try
                fedm.ConnectUSB(0)

            Catch ex As FePortDriverException
                MessageBox.Show(ex.ToString, "Error")
            End Try
        End Sub

        Private Sub EnableTCP(ByVal enable As Boolean)
            Me.LabelHost.Enabled = enable
            Me.TextBoxTcpHost.Enabled = enable
            Me.LabelTcpPort.Enabled = enable
            Me.TextBoxTcpPort.Enabled = enable
            Me.LabelTcpTimeout.Enabled = enable
            Me.TextBoxTcpTimeout.Enabled = enable
        End Sub

        Private Sub EnableSerial(ByVal enable As Boolean)
            Me.LabelPortNumber.Enabled = enable
            Me.ComboBoxPortNumber.Enabled = enable
            Me.LabelBaudrate.Enabled = enable
            Me.ComboBoxBaudrate.Enabled = enable
            Me.LabelFrame.Enabled = enable
            Me.ComboBoxFrame.Enabled = enable
            Me.LabelTimeout.Enabled = enable
            Me.TextBoxTimeout.Enabled = enable
        End Sub

        Private Sub PortConfig_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
            Me.Visible = False
        End Sub

        Private fedm As FedmIscReader

        Private Sub RadioButtonUSB_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonUSB.CheckedChanged
            EnableTCP(False)
            EnableSerial(False)
        End Sub
    End Class
End Namespace
