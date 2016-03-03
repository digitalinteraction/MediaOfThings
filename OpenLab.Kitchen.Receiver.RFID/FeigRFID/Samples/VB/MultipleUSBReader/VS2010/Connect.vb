Imports OBID
Imports System


Public Class Connect
    Implements FeUsbListener
    Public running As MultipleUSBReader

    Public Sub OnConnectReader(ByVal DeviceHandle As Integer, ByVal DeviceID As Long) Implements OBID.FeUsbListener.OnConnectReader
        running.AddDevice(DeviceID)
    End Sub

    Public Sub OnDisConnectReader(ByVal DeviceHandle As Integer, ByVal DeviceID As Long) Implements OBID.FeUsbListener.OnDisConnectReader
        running.RemoveDevice(DeviceID)
    End Sub
End Class
