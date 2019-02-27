﻿using System;

namespace Netatmo.Dashboard.Core.Models
{
    public class TemperatureData
    {
        public decimal Current { get; set; }
        public TemperatureMinMax Min { get; set; }
        public TemperatureMinMax Max { get; set; }
        public Trend Trend { get; set; }
    }
}