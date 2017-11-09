using System.Collections.Generic;

namespace Warships.Models
{
    public class Nation
    {
        public int NationId { get; set; }
        public string Name { get; set; }
        public ICollection<Ship> Ships { get; set; }
    }
}