﻿using System.Collections.Generic;

namespace Warships.Models
{
    public class Ship
    {
        public int ShipId { get; set; }
        public string ShipName { get; set; }
        public int ShipTypeId { get; set; }
        


        
        public ShipType ShipType { get; set; }
        public ICollection<Battle> Battles { get; set; }
    }
}