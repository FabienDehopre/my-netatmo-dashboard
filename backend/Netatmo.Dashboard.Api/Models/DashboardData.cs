﻿using System;

namespace Netatmo.Dashboard.Api.Models
{
    public abstract class DashboardData
    {
        public int Id { get; set; }
        public DateTime TimeUtc { get; set; }
        public string DeviceId { get; set; }
        public virtual Device Device { get; set; }
    }

    public class MainDashboardData : DashboardData
    {
        public virtual TemperatureData Temperature { get; set; }
        public virtual PressureData Pressure { get; set; }
        public int CO2 { get; set; }
        public int Humidity { get; set; }
        public int Noise { get; set; }
    }

    public class OutdoorDashboardData : DashboardData
    {
        public virtual TemperatureData Temperature { get; set; }
        public int Humidity { get; set; }
    }

    public class WindGaugeDashboardData : DashboardData
    {
        public decimal WindStrength { get; set; }
        public int WindAngle { get; set; }
        public decimal GustStrength { get; set; }
        public int GustAngle { get; set; }
    }

    public class RainGaugeDashboardData : DashboardData
    {
        public decimal Rain { get; set; }
        public decimal Sum1H { get; set; }
        public decimal Sum24H { get; set; }
    }

    public class IndoorDashboardData : DashboardData
    {
        public virtual TemperatureData Temperature { get; set; }
        public int CO2 { get; set; }
        public int Humidity { get; set; }
    }
}
