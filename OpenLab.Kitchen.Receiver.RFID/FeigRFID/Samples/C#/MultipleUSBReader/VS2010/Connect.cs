using System;
using System.Collections.Generic;
using System.Text;
using OBID;

namespace MultipleUSBReader
{
  
    class Connect : FeUsbListener
        {
            public MultipleUSBReader running;
           
            
            public  void OnConnectReader(int DeviceHdl, long DeviceID)
                {
                    running.AddDevice(DeviceID);
                }
            public  void OnDisConnectReader(int DeviceHdl, long DeviceID)
                {
                    running.RemoveDevice(DeviceID);
                }
        }
   
}
