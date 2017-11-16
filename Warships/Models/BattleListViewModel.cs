using System.Collections.Generic;

namespace Warships.Models
{
    //Puts the battles into a list model for use
    public class BattleListViewModel
    {
        public List<BattleViewModel> Battles { get; set; }
        public int TotalBattles { get; set; }
    }
}