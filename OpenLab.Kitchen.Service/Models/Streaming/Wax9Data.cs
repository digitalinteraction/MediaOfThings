﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenLab.Kitchen.Service.Models.Streaming
{
    public class Wax9Data : StreamingModel
    {
        public float AccX { get; set; }

        public float AccY { get; set; }

        public float AccZ { get; set; }

        public float GyroX { get; set; }

        public float GyroY { get; set; }

        public float GyroZ { get; set; }

        public float MagX { get; set; }

        public float MagY { get; set; }

        public float MagZ { get; set; }
    }
}