using System.Collections.Generic;

namespace Warships.Models
{
    public class Ship
    {
        public int ShipId { get; set; }
        public string Name { get; set; }
        public int ShipTypeId { get; set; }
        public int NationId { get; set; }


        Nation Nation;
        ShipType ShipType;
        public ICollection<Battle> Battles { get; set; }
    }
}