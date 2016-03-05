using System.Threading;

namespace OpenLab.Kitchen.Receiver.Wax3.Wax3.Rfid
{
    class Program
    {
        static void Main(string[] args)
        {
            var rfid = new Rfid();
            rfid.InitUsb();

            Thread.Sleep(-1);
        }
    }
}
