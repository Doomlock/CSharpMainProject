using System.ComponentModel;

namespace Warships.Models
{
    public class ShipViewModel
    {
        public int? ShipId { get; set; }

        [DisplayName("Class Name")]
        public string ClassName { get; set; }

        [DisplayName("Ship Name")]
        public string ShipName { get; set; }

        [DisplayName("Name")]
        public string FullName => ShipName + " " + ClassName;
    }
}