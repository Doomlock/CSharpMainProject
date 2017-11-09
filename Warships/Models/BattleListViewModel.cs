using System.Collections.Generic;

namespace Warships.Models
{
    public class BattleListViewModel
    {
        public List<BattleViewModel> Battles { get; set; }
        public int TotalBattles { get; set; }
    }
}