using Warships.Models;
using System.Data.Entity;

namespace Warships
{
    public class WarshipsContext : DbContext
    {
        public WarshipsContext() : base("name=Warships") { }

        public virtual DbSet<Ship> Ships { get; set; }

        public virtual DbSet<Nation> Nations { get; set; }

        public virtual DbSet<Battle> Battles { get; set; }

        public virtual DbSet<ShipType> ShipTypes { get; set; }
    }
}