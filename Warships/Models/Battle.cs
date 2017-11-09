using System.Collections.Generic;

namespace Warships.Models
{
    public class Battle
    {
        public int BattleId { get; set; }
        public string Name { get; set; }
        public ICollection<Ship> Ships { get; set; }
        
    }
}