using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Warships.Models
{
    public class ShipType
    {
        public int ShipTypeId { get; set; }
        public string ShipTypeName { get; set; }
        public ICollection<Ship> Ships { get; set; }
    }
}