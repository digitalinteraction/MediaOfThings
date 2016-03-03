using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using OBID;
using OBID.TagHandler;

namespace TagHandlerSample
{
    public partial class TagHandlerSample : Form
    {
        bool connected = false;

        // the necessary Reader object
        FedmIscReader Reader = null;

        // the transponder list object
        Dictionary<string, FedmIscTagHandler> TagList;

        public TagHandlerSample()
        {
            InitializeComponent();

            Reader = new FedmIscReader();

            // initializes the internal table for max. 50 tags per Inventory
            Reader.SetTableSize(FedmIscReaderConst.ISO_TABLE, 50);
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                Reader.ConnectUSB(0);
                connected = true;
            
                // display all collected infos about the Reader
                Console.WriteLine(Reader.GetReaderInfo().GetReport());
            }
            catch
            {
            }

        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            Dictionary<string, FedmIscTagHandler>.ValueCollection listTagHandler;

            if (!connected)
                return;

            // RF-Reset
            Reader.SendProtocol(0x69);

            // execute Inventory for all tags with Mode=0 at first Antenna
            TagList = Reader.TagInventory(true, 0x00, 0x01);
            listTagHandler = TagList.Values;
            foreach (FedmIscTagHandler tag in listTagHandler)
            {
                Console.WriteLine(tag.GetUid());
            }
        }

        private void btnTagAction_Click(object sender, EventArgs e)
        {
            int back = 0;
            uint BlockSize = 0;
            byte[] Data = null;
            byte[] respData = null;
            Dictionary<string, FedmIscTagHandler>.ValueCollection listTagHandler;

            if (!connected)
                return;

            listTagHandler = TagList.Values;
            foreach (FedmIscTagHandler tag in listTagHandler)
            {
                if (tag is FedmIscTagHandler_ISO15693)
                {
                    FedmIscTagHandler_ISO15693 newTag = (FedmIscTagHandler_ISO15693)tag;
                    Console.WriteLine(newTag.GetTagName());

                    // read data blocks and write same data back to tag
                    back = newTag.ReadMultipleBlocks((uint)4, (uint)4, out BlockSize, out Data);
                    back = newTag.WriteMultipleBlocks(4, 4, 4, Data);
                }
                else if (tag is FedmIscTagHandler_ISO14443)
                {
                    FedmIscTagHandler newTag = null; 

                    // execute a select command for MIFARE DESFire
                    // TagSelect creates a new TagHandler object internally
                    newTag = Reader.TagSelect(tag, 9);

                    if(newTag is FedmIscTagHandler_ISO14443_4_MIFARE_DESFire)
                    {
                        FedmIscTagHandler_ISO14443_4_MIFARE_DESFire desfireTag = (FedmIscTagHandler_ISO14443_4_MIFARE_DESFire)newTag;

                        Console.WriteLine(desfireTag.GetTagName());

                        // read version information
                        // use the internal Interface IFlexSoftCrypto
                        back = desfireTag.IFlexSoftCrypto.GetVersion((byte)0, out respData);
                    }
                }
                else if (tag is OBID.TagHandler.FedmIscTagHandler_EPC_Class1_Gen2)
                {
                    FedmIscTagHandler_EPC_Class1_Gen2 newTag = (FedmIscTagHandler_EPC_Class1_Gen2)tag;
                    Console.WriteLine(newTag.GetTagName());

                    // write a new EPC number (without password)
                    back = newTag.WriteEPC("1102030405060708090A0B0C", "");
                }
            }
        }
    }
}
