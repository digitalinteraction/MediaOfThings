using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenLab.Kitchen.Receiver
{
    class Slip
    {
        public const byte SLIP_END = 0xC0;                   // 192 End of packet indicator
        public const byte SLIP_ESC = 0xDB;                   // 219 Escape character, next character will be a substitution
        public const byte SLIP_ESC_END = 0xDC;               // 220 Escaped substitution for the END data byte
        public const byte SLIP_ESC_ESC = 0xDD;               // 221 Escaped substitution for the ESC data byte

        // Remove and return a SLIP (RFC 1055) encoded packet from the serial port
        public static byte[] ExtractSlipPacket(List<byte> originalBuffer)
        {
            int endIndex = originalBuffer.IndexOf(SLIP_END);
            if (endIndex < 0)
            {
                return null;
            }

            // Create a new buffer that contains the encoded packet
            byte[] buffer = new byte[endIndex];
            originalBuffer.CopyTo(0, buffer, 0, endIndex);
            originalBuffer.RemoveRange(0, endIndex + 1);

            List<byte> packet = new List<byte>();
            bool lastWasEscape = false;
            for (int i = 0; i < buffer.Length; i++)
            {
                byte c = buffer[i];
                if (c == SLIP_END) { break; }
                else if (!lastWasEscape && c == SLIP_ESC) { lastWasEscape = true; }
                else
                {
                    if (lastWasEscape)
                    {
                        // Substitute escaped char
                        if (c == SLIP_ESC_END) { c = SLIP_END; lastWasEscape = false; }
                        else if (c == SLIP_ESC_ESC) { c = SLIP_ESC; lastWasEscape = false; }
                        else if (c == SLIP_ESC)
                        {
                            Debug.WriteLine("SLIP: Invalid double-ESC");
                            c = SLIP_ESC;
                            lastWasEscape = true;
                        }
                        else
                        {
                            Debug.WriteLine("SLIP: Invalid code after ESC: " + c);
                            //c = c;               // Invalid escaped char!
                            lastWasEscape = false;
                        }
                    }
                    // Add character to packet
                    packet.Add(c);
                }
            }
            if (lastWasEscape)
            {
                Debug.WriteLine("SLIP: Invalid packet END after ESC");
            }

            byte[] packetArray = packet.ToArray();
            return packetArray;
        }
    }
}
