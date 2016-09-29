using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenLab.Kitchen.Service.Models
{
    public class Wax3Data : Model
    {
        public float Battery { get; set; }

        public float AccX { get; set; }

        public float AccY { get; set; }

        public float AccZ { get; set; }
    }
}
