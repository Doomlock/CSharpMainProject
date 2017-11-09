using System.Collections.Generic;

namespace Warships.Models
{
    public class ShipListViewModel
    {
        public List<ShipViewModel> Ships { get; set; }
        public int TotalShips { get; set; }
    }
}