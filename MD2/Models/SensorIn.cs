using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MD2.Models
{
    public class SensorIn
    {
        public int ID { get; set; }
        public string Detected { get; set; }
        public DateTime InsertTime { get; set; }
        public string DeviceIP { get; set; }
        public string DeviceMac { get; set; }
        public string Location { get; set; }
    }
}
