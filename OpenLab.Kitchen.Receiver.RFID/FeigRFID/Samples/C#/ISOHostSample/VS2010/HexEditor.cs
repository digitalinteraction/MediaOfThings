using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace ISOHostSample
{
    public partial class HexEditor : UserControl
    {
        private int row;
        private int column;
        private int _columnCount;
        private int _rowCount;
        private int bnkidx;

        public HexEditor()
        
        {
            InitializeComponent();
            
        }

        public void InsertData(int index, byte[] b)
        {

            if (b == null)
            { return;
            }
            else
            {
                string s;
                int i;
                //just the interger number
                row = Convert.ToInt16(index / _columnCount);
                column = (index % _columnCount) * 3 + 8;
                for (i = 0; i <= b.Length - 1; i++)
                {
                    s = (b[i].ToString("X")).Trim();
                    if (s.Length == 1)
                    { s = "0" + s; }
                    //just insert this two string
                    InsertText(s.Substring(0).Trim());
                    InsertText(s.Substring(1).Trim());
                }
                
            }
        }
        
        public byte[] GetData(int index, int count)
        {
            byte[] b = new byte[count];
            int i;
            string s;

            for (i = 0; i <count; i++)
                
            {
                s = GetText(index,i);
                b[i] = OBID.FeHexConvert.HexStringToByte(s);
            }
            return b;
        }
                    
        private void InsertText(string s)
        {
            if ((column > 7) && (column < 7 + _columnCount * 3))
            {
                int pos;
                string tmp = null;
                column = column + 1;
                pos = row * (_columnCount * 4 + 10) + column;

                if (pos >= Hexer.Text.Length)
                    return; 
                
                //remove and insert the new byte
                Hexer.Text = Hexer.Text.Remove(pos - 1, s.Length);
                Hexer.Text = Hexer.Text.Insert(pos - 1, s.ToUpper());

                
                //write each byte on each column
                if (column % 3 == 0)
                {
                    tmp = Hexer.Text.Substring(pos - 1, 2);
                }
                if (column % 3 == 1)
                {
                    tmp = Hexer.Text.Substring(pos - 2, 2);
                }
                // Position for Ascii corversion
                pos = row * (_columnCount * 4 + 10) + 3 * _columnCount + 9 + Convert.ToInt16((column - 9) / 3);
                byte i;
                i = OBID.FeHexConvert.HexStringToByte(tmp); 

                //just regular number or letter
                if (i >= 21 && i <= 255)
                {
                    Hexer.Text = Hexer.Text.Remove(pos - 1, 1);
                    Hexer.Text = Hexer.Text.Insert(pos - 1, Convert.ToChar(i).ToString()); 
                }
                // next column
                if ((column - 7) % 3 == 0)
                {
                    column = column + 1;
                }
                // next line
                if (column == 7 + _columnCount * 3 || column == 8 + _columnCount * 3)
                {
                    column = 8;
                    row = row + 1;
                }
                //always put the cursor in the correct position 
                Hexer.SelectionLength = 0;
                Hexer.SelectionStart = row * (_columnCount * 4 + 10) + column;
            }
            else 
            {
                MessageBox.Show("This Fied is just lisible not writable");
            }
        }

        private string GetText(int index,int i )
        {
            int pos;
            pos = 3 * i + _columnCount * index + 13 * index + 3 * (_columnCount - 1)*index + 9;
            string s;
            if (pos >= Hexer.Text.Length - 6)
            { 
                return null ; 
            }   
            s = Hexer.Text.Substring(pos-1, 2);

            return s;
        }
        
        public void SetSize(int rowcount, int columncount, int Bnkidx)
        {
            int i;
            int j;
            string IniText = "";
            bnkidx = Bnkidx;
            

            _rowCount = rowcount;
            _columnCount = columncount;
           
            
            Hexer.Text = "";

            for (i = 0; i <= _rowCount - 1; i++)
            {
                switch (bnkidx)
                {
                    case 0:
                        IniText += "RES";
                        break;
                    case 1:
                        IniText += "EPC";
                        break;
                    case 2:
                        IniText += "TID";
                        break;
                    case 3:
                        IniText += "DB ";
                        break;
                    default:
                        return;
                }               
                if (i < 10)
                {
                    IniText +=  " ";
                }
                if (i < 100)
                {
                    IniText +=  " ";
                }
                IniText = IniText + i.ToString() + ": ";
                for (j = 0; j <= _columnCount - 1; j++)
                {
                    IniText +=  "00 ";
                }
                for (j = 0; j <= _columnCount - 1; j++)
                {
                    IniText +=  ".";
                }
                IniText += Environment.NewLine;
            }
              
              Hexer.AppendText(IniText) ;
      }

        public int ColumnCount
        {
            get
            {
                return _columnCount;
            }
            
            set
            {
                byte[] b;
                

                b = this.GetData(0, _columnCount * _rowCount);
                this.SetSize(_rowCount, value,  bnkidx);
                this.InsertData(0, b);
               
            }
        }

        public  int RowCount
        {
            get
            {
                return _rowCount;
            }
        }
         
        //Clean the HexEditor
        public void HexEditClean(int rowcount, int columncount, int Bnkidx)
        {
            _rowCount = rowcount;
            _columnCount = columncount;
            bnkidx = Bnkidx;

            int i;
            int j;
            string Text = "";

            Hexer.Text = "";
            for (i =0 ; i <=_rowCount  - 1; i++)
            {

                switch (bnkidx)
                {
                    case 0:
                        Text += "RES";
                        break;
                    case 1:
                        Text += "EPC";
                        break;
                    case 2:
                        Text += "TID";
                        break;
                    case 3:
                        Text += "DB ";
                        break;
                    default:
                        return;
                }
                if (i < 10)
                {
                    Text += " ";
                }
                if (i < 100)
                {
                    Text +=  " ";
                }
                Text = Text + i.ToString() + ": ";
                for (j = 0; j <= _columnCount - 1; j++)
                {
                    Text += "00 ";
                }
                    for (j = 0; j <= _columnCount - 1; j++)
                    {
                        Text +=  ".";
                    }
                    Text += Environment.NewLine; 
            }
            Hexer.AppendText(Text);
           
        }

        private void Hexer_MouseUp(object sender, MouseEventArgs e)
        {
            this.Hexer.SelectionLength = 0;
            row = Convert.ToInt16((Hexer.SelectionStart / (_columnCount * 4 + 10)));//Fix
            column = Hexer.SelectionStart % (_columnCount * 4 + 10);
            // Cursor auf die richtige Position setzen fall in dem Hex-Bereich geklickt wurde
            if (column < 8) { column = 8; }
            if (column < 7 + _columnCount * 3)
            {
                if ((column - 7) % 3 == 0)
                {
                    column = column + 1;
                }
            }
            Hexer.SelectionStart = row * (_columnCount * 4 + 10) + column;

        }

        private void Hexer_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            
            //Ascii  dezcimale Value
           int dec = e.KeyChar;
                   
            if ((dec >= 48 && dec <= 57) || (dec >= 97 && dec <= 102) || (dec >= 65 && dec <= 70))
            {
                
                InsertText(e.KeyChar.ToString());
                e.Handled = true;
                return;
            }
            else
            {
                MessageBox.Show("just give a character in range (a-f) or (A-F) or(0-9)");
                e.Handled = true;
                return;
            }

        }
}
}

