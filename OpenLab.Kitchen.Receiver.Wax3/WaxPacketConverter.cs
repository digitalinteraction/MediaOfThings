using System;
using System.Diagnostics;

namespace OpenLab.Kitchen.Receiver.Wax3
{
    public class WaxPacketConverter
    {
        public static WaxPacket FromBinary(byte[] buffer, DateTime timestamp)
        {
            WaxPacket waxPacket = null;

            if (buffer != null && buffer.Length > 0)
            {
                if (buffer.Length >= 2 && buffer[0] == 0x12 && buffer[1] == 0x78 && buffer.Length >= 12)           // New WAX hardware (ASCII 'x')
                {
                    ushort deviceId = (ushort)(buffer[2] | (buffer[3] << 8));
                    ushort adcSample = (ushort)(buffer[5] | (buffer[6] << 8));
                    byte format = buffer[7];
                    ushort sequenceId = (ushort)(buffer[8] | (buffer[9] << 8));
                    byte outstanding = buffer[10];
                    byte sampleCount = buffer[11];
                    WaxSample[] sampleData = new WaxSample[sampleCount];

                    int bytesPerSample = 0;
                    if (((format >> 4) & 0x03) == 2) { bytesPerSample = 6; }
                    else if (((format >> 4) & 0x03) == 0) { bytesPerSample = 4; }

                    int expectedLength = 12 + sampleCount * bytesPerSample;
                    if (buffer.Length < expectedLength)
                    {
                        Debug.WriteLine("WARNING: Ignoring truncated- or unknown-format data packet (received " + buffer.Length + " expected " + expectedLength + ").");
                    }
                    else
                    {
                        if (buffer.Length > expectedLength)
                        {
                            Debug.WriteLine("WARNING: Data packet was larger than expected, ignoring additional samples");
                        }

                        int frequency = 3200 / (1 << (15 - (format & 0x0f)));

                        for (int i = 0; i < sampleCount; i++)
                        {
                            int samplesAgo = sampleCount + outstanding - 1 - i;

                            short x = 0, y = 0, z = 0;
                            if (bytesPerSample == 6)
                            {
                                x = (short)((ushort)(buffer[12 + i * 6] | (buffer[13 + i * 6] << 8)));
                                y = (short)((ushort)(buffer[14 + i * 6] | (buffer[15 + i * 6] << 8)));
                                z = (short)((ushort)(buffer[16 + i * 6] | (buffer[17 + i * 6] << 8)));
                            }
                            else if (bytesPerSample == 4)
                            {
                                uint value = buffer[12 + i * 4] | ((uint)buffer[13 + i * 4] << 8) | ((uint)buffer[14 + i * 4] << 16) | ((uint)buffer[15 + i * 4] << 24);
                                x = (short)((short)(0xffc0 & (ushort)(value << 6)) >> (6 - ((byte)(value >> 30))));		// Sign-extend 10-bit value, adjust for exponent
                                y = (short)((short)(0xffc0 & (ushort)(value >> 4)) >> (6 - ((byte)(value >> 30))));		// Sign-extend 10-bit value, adjust for exponent
                                z = (short)((short)(0xffc0 & (ushort)(value >> 14)) >> (6 - ((byte)(value >> 30))));		// Sign-extend 10-bit value, adjust for exponent
                            }
                            uint index = sequenceId + (uint)i;

                            DateTime t = timestamp - TimeSpan.FromMilliseconds(samplesAgo * 1000 / (double) frequency);

                            sampleData[i] = new WaxSample(t, index, x, y, z);
                        }

                        waxPacket = new WaxPacket(timestamp, deviceId, 1, 0, adcSample, sequenceId, format, sampleCount, sampleData);
                    }

                }
                else if (buffer.Length >= 2 && buffer[0] == 0x12 && buffer[1] == 0x58 && buffer.Length >= 12)           // Old WAX hardware (ASCII 'X')
                {
                    if (buffer.Length > 0 && buffer.Length != 90)
                    {
                        Debug.WriteLine("Unexpected packet length: " + buffer.Length + "");
                    }

                    ushort deviceId = (ushort)(buffer[2] | (buffer[3] << 8));
                    byte version = buffer[4];
                    byte battery = buffer[5];
                    ushort adcSample = (ushort)(buffer[6] | (buffer[7] << 8));
                    ushort sequenceId = (ushort)(buffer[8] | (buffer[9] << 8));
                    byte format = buffer[10];
                    byte sampleCount = buffer[11];
                    WaxSample[] sampleData = new WaxSample[sampleCount];

                    int expectedLength = 12 + sampleCount * 6;
                    if (buffer.Length < expectedLength)
                    {
                        Debug.WriteLine("WARNING: Ignoring truncated data packet (received " + buffer.Length + " expected " + expectedLength + ").");
                    }
                    else
                    {
                        if (buffer.Length > expectedLength)
                        {
                            Debug.WriteLine("WARNING: Data packet was larger than expected.");
                        }

                        for (int i = 0; i < sampleCount; i++)
                        {
                            short x = (short)((ushort)(buffer[12 + i * 6] | (buffer[13 + i * 6] << 8)));
                            short y = (short)((ushort)(buffer[14 + i * 6] | (buffer[15 + i * 6] << 8)));
                            short z = (short)((ushort)(buffer[16 + i * 6] | (buffer[17 + i * 6] << 8)));
                            uint index = (uint)sequenceId * sampleCount + (uint)i;
                            sampleData[i] = new WaxSample(timestamp, index, x, y, z);
                        }

                        waxPacket = new WaxPacket(timestamp, deviceId, version, battery, adcSample, sequenceId, format, sampleCount, sampleData);
                    }

                }
                else
                {
                    Debug.WriteLine("Invalid packet.");
                }

            }

            return waxPacket;
        }
    }
}