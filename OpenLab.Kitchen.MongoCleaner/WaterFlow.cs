﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenLab.Kitchen.MongoCleaner
{
    public class WaterFlow : Model
    {
        public float WaterUsed { get; set; }

        public DateTime Time { get; set; }
    }
}