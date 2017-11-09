namespace Warships.Models
{
    public class BattleViewModel
    {
        public int? BattleId { get; set; }
        public string Name { get; set; }
        public NationViewModel Nation { get; set; }
    }
}