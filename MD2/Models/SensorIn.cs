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
        public DateTime InsertTime { get; set; } //dt
        public string DeviceIP { get; set; }
        public string DeviceMac { get; set; }
        public string Location { get; set; }
        public DateTime? DeviceInsertDate { get; set; } //dev d
        public DateTime? DeviceInsertTime { get; set; } //dev dt
    }
}
