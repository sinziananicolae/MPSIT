using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MPSIT.Models
{
    public class SensorsDataModel
    {
        public String GUID { get; set; }
        public int Temperature { get; set; }
        public int Humidity { get; set; }
        public float Weight { get; set; }
        public int Light { get; set; }
        public DateTime Timestamp { get; set; }

    }
}