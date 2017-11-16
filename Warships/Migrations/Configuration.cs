namespace Warships.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Warships.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Warships.WarshipsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Warships.WarshipsContext context)
        {

            context.ShipTypes.AddOrUpdate(
                t => t.ShipTypeId,
                new ShipType { ShipTypeId = 1, ShipTypeName = "Battleship" },
                new ShipType { ShipTypeId = 2, ShipTypeName = "Cruiser" },
                new ShipType { ShipTypeId = 3, ShipTypeName = "Aircraft Carrier" },
                new ShipType { ShipTypeId = 4, ShipTypeName = "Destroyer" },
                new ShipType { ShipTypeId = 5, ShipTypeName = "Submarine" }
                );

            context.Battles.AddOrUpdate(
                r => r.BattleId,
                new Battle { BattleId = 1, BattleName = "Battle of the Santa Cruz Islands" },
                new Battle { BattleId = 2, BattleName = "Battle of the Eastern Solomons" },
                new Battle { BattleId = 3, BattleName = "Battle of Okinawa" },
                new Battle { BattleId = 4, BattleName = "Battle of the Philippine Sea" },
                new Battle { BattleId = 5, BattleName = "Battle of the Denmark Strait" },
                new Battle { BattleId = 6, BattleName = "Battle of the North Cape" },
                new Battle { BattleId = 7, BattleName = "Battle of the Java Sea" }
             );

            context.SaveChanges();

            context.Ships.AddOrUpdate(
                p => p.ShipId,
                new Ship { ShipId = 1, ShipName = "USS Enterprise", ShipTypeId = 3 },
                new Ship { ShipId = 2, ShipName = "USS Saratoga", ShipTypeId = 3 },
                new Ship { ShipId = 3, ShipName = "USS Missouri", ShipTypeId = 1 },
                new Ship { ShipId = 4, ShipName = "Zuikaku", ShipTypeId = 3 },
                new Ship { ShipId = 5, ShipName = "Bismarck", ShipTypeId = 1 },
                new Ship { ShipId = 6, ShipName = "Scharnhorst", ShipTypeId = 1 },
                new Ship { ShipId = 7, ShipName = "USS Des Moines", ShipTypeId = 2 },
                new Ship { ShipId = 8, ShipName = "USS Newport News", ShipTypeId = 2 },
                new Ship { ShipId = 9, ShipName = "Roma", ShipTypeId = 1 },
                new Ship { ShipId = 10, ShipName = "HMS Hood", ShipTypeId = 1 },
                new Ship { ShipId = 11, ShipName = "HMS King George V", ShipTypeId = 1 },
                new Ship { ShipId = 12, ShipName = "Zara", ShipTypeId = 2 },
                new Ship { ShipId = 13, ShipName = "Atago", ShipTypeId = 2 },
                new Ship { ShipId = 14, ShipName = "Richelieu", ShipTypeId = 1 },
                new Ship { ShipId = 15, ShipName = "Dunkerque", ShipTypeId = 1 }
            );

            context.SaveChanges();




        }
    }
}