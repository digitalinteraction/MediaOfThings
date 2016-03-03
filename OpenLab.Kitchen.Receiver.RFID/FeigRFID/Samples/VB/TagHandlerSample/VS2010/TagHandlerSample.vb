Imports OBID
Imports OBID.TagHandler

Public Class TagHandlerSample

    Private Reader As FedmIscReader
    Private TagList As Dictionary(Of String, FedmIscTagHandler)
    Private connected As Boolean

    Private Sub TagHandlerSample_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        connected = False

        ' the necessary Reader object
        Reader = New FedmIscReader

        ' initializes the internal table for max. 50 tags per Inventory
        Reader.SetTableSize(FedmIscReaderConst.ISO_TABLE, 50)

        ' the transponder list object
        TagList = New Dictionary(Of String, FedmIscTagHandler)

    End Sub

    Private Sub BtnConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnConnect.Click
        Try
            ' create a connection to a Reader at USB
            Reader.ConnectUSB(0)
            connected = True

            ' display all collected infos about the Reader
            Console.WriteLine("")
            Console.WriteLine(Reader.GetReaderInfo().GetReport())
        Catch ex As FePortDriverException
            Console.WriteLine("Exception: " + ex.ToString())
        End Try

    End Sub

    Private Sub BtnInventory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnInventory.Click
        Dim valueColl As Dictionary(Of String, FedmIscTagHandler).ValueCollection = TagList.Values


        If Not connected Then
            Return
        End If

        Try
            ' RF-Reset
            Reader.SendProtocol(&H69)

            ' Required Reader Mode (Operating Mode): Host Mode
            ' execute Inventory for all tags with Mode=0 at first Antenna
            TagList = Reader.TagInventory(True, 0, 1)

            If (TagList.Count > 0) Then
                For Each tag As FedmIscTagHandler In valueColl
                    Console.WriteLine(vbCr + vbLf + "Tag UID: " + tag.GetUid())
                Next tag
            ElseIf (Reader.GetLastStatus() = &H82) Then
                Console.WriteLine(vbCr + vbLf + "Wrong Reader Mode (Host Mode required)!")
            ElseIf (Reader.GetLastStatus() = &H1) Then
                Console.WriteLine(vbCr + vbLf + "No Transponder in Reader Field")
            Else
                Console.WriteLine(vbCr + vbLf + "Error Code: " + Reader.GetLastStatus().ToString)
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnTagAction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTagAction.Click
        Dim valueColl As Dictionary(Of String, FedmIscTagHandler).ValueCollection = TagList.Values
        Dim back As Integer
        Dim BlockSize As UInteger
        Dim Data As Byte()
        Dim respData As Byte()

        If Not connected Then
            Return
        End If

        ' if tags are collected, find out the correct TagHandler type and execute any tag specific command
        For Each tag As FedmIscTagHandler In valueColl

            If TypeOf tag Is FedmIscTagHandler_ISO15693 Then
                Dim newTag As FedmIscTagHandler_ISO15693

                newTag = tag

                Console.WriteLine("Tag Type: " + newTag.GetTagName())

                ' read data blocks and write same data back to tag
                back = newTag.ReadMultipleBlocks(4, 4, BlockSize, Data)
                back = newTag.WriteMultipleBlocks(4, 4, 4, Data)

            ElseIf TypeOf tag Is FedmIscTagHandler_ISO14443 Then
                Dim newTag As FedmIscTagHandler

                ' execute a select command for MIFARE DESFire
                ' TagSelect creates a new TagHandler object internally
                newTag = Reader.TagSelect(tag, 9)

                If TypeOf newTag Is FedmIscTagHandler_ISO14443_4_MIFARE_DESFire Then
                    Dim desfireTag As FedmIscTagHandler_ISO14443_4_MIFARE_DESFire
                    desfireTag = newTag
                    Console.WriteLine("Tag Type: " + desfireTag.GetTagName())
                    ' read version information
                    ' use the internal Interface IFlexSoftCrypto
                    back = desfireTag.IFlexSoftCrypto.GetVersion(0, respData)
                End If

            ElseIf TypeOf tag Is FedmIscTagHandler_EPC_Class1_Gen2 Then
                Dim newTag As FedmIscTagHandler_EPC_Class1_Gen2

                newTag = tag

                Console.WriteLine("Tag Type: " + newTag.GetTagName())

                ' write a new EPC number (without password)
                ' newTag.WriteEPC("0102030405060708090A0B0C", "")
            End If
        Next tag

    End Sub
End Class
