using System.ComponentModel;

namespace Warships.Models
{
    public class ShipViewModel
    {
        public int? ShipId { get; set; }

        [DisplayName("Ship Type")]
        public int ShipTypeId { get; set; }

        [DisplayName("Ship Name")]
        public string ShipName { get; set; }

        [DisplayName("Ship Name and Type")]
        public string FullName => ShipName + " " + ShipTypeId;
    }
}