using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MD2.Models
{
    public class DeviceLoc
    {
        public int ID { get; set; }
        public string DeviceMac { get; set; }
        [StringLength(20)]
        public string Location { get; set; }
        public string Remarks { get; set; }
        public string AssetNo { get; set; }
    }
}
