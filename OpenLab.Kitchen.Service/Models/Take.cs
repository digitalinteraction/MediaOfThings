using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenLab.Kitchen.Service.Models
{
    public class Take
    {
        public string Name { get; set; }

        public IEnumerable<Media> Media { get; set; }
    }
}
