using Warships.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Warships.Controllers
{
    public class BattleController : Controller
    {
        public ActionResult Index()
        {
            using (var warshipsContext = new WarshipsContext())
            {
                var restaurantList = new BattleListViewModel
                {
                    //Convert each Battle to a BattleViewModel
                    Battles = warshipsContext.Battles.Select(r => new BattleViewModel
                    {
                        BattleId = r.BattleId,
                        Name = r.Name,
                        Nation = new NationViewModel
                        {
                            NationId = r.ShipId,
                            Name = r.Name
                        }
                    }).ToList()
                };

                restaurantList.TotalBattles = restaurantList.Battles.Count;

                return View(restaurantList);
            }
        }

        public ActionResult RestaurantDetail(int id)
        {
            using (var lunchContext = new WarshipsContext())
            {
                var Battle = lunchContext.Battles.SingleOrDefault(p => p.BattleId == id);
                if (Battle != null)
                {
                    var battleViewModel = new BattleViewModel
                    {
                        BattleId = Battle.BattleId,
                        Name = Battle.Name,
                        Nation = new NationViewModel
                        {
                            NationId = Battle.NationId,
                            Name = Battle.Nation.Name
                        }
                    };

                    return View(battleViewModel);
                }
            }

            return new HttpNotFoundResult();
        }

        public ActionResult RestaurantAdd()
        {
            using (var lunchContext = new WarshipsContext())
            {
                ViewBag.Cuisines = lunchContext.Nations.Select(c => new SelectListItem
                {
                    Value = c.NationId.ToString(),
                    Text = c.Name
                }).ToList();
            }

            var battleViewModel = new BattleViewModel();

            return View("AddEditBattle", battleViewModel);
        }

        [HttpPost]
        public ActionResult AddRestaurant(BattleViewModel battleViewModel)
        {
            using (var warshipsContext = new WarshipsContext())
            {
                var battle = new Battle
                {
                    Name = battleViewModel.Name,
                    ShipId = battleViewModel.Nation.NationId.Value
                };

                warshipsContext.Battles.Add(battle);
                warshipsContext.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public ActionResult BattleEdit(int id)
        {
            using (var warshipsContext = new WarshipsContext())
            {
                ViewBag.Nations = warshipsContext.Nations.Select(c => new SelectListItem
                {
                    Value = c.NationId.ToString(),
                    Text = c.Name
                }).ToList();

                var battle = warshipsContext.Battles.SingleOrDefault(p => p.BattleId == id);
                if (battle != null)
                {
                    var battleViewModel = new BattleViewModel
                    {
                        BattleId = battle.BattleId,
                        Name = battle.Name,
                        Nation = new NationViewModel
                        {
                            NationId = battle.NationId,
                            Name = battle.Nation.Name
                        }
                    };

                    return View("AddEditBattle", battleViewModel);
                }
            }

            return new HttpNotFoundResult();
        }

        [HttpPost]
        public ActionResult EditBattle(BattleViewModel battleViewModel)
        {
            using (var warshipsContext = new WarshipsContext())
            {
                var battle = warshipsContext.Battles.SingleOrDefault(p => p.BattleId == battleViewModel.BattleId);

                if (battle != null)
                {
                    battle.Name = battleViewModel.Name;
                    battle.NationId = battleViewModel.Nation.NationId.Value;
                    warshipsContext.SaveChanges();

                    return RedirectToAction("Index");
                }
            }

            return new HttpNotFoundResult();
        }

        [HttpPost]
        public ActionResult DeleteBattle(BattleViewModel battleViewModel)
        {
            using (var warshipsContext = new WarshipsContext())
            {
                var battle = warshipsContext.Battles.SingleOrDefault(p => p.BattleId == battleViewModel.BattleId);

                if (battle != null)
                {
                    warshipsContext.Battles.Remove(battle);
                    warshipsContext.SaveChanges();

                    return RedirectToAction("Index");
                }
            }

            return new HttpNotFoundResult();
        }
    }
}





















//using warships.models;
//using system.data.entity.migrations;

//namespace warships.migrations
//{
//    internal sealed class configuration : dbmigrationsconfiguration<warshipscontext>
//    {
//        public configuration()
//        {
//            automaticmigrationsenabled = false;
//        }

//        protected override void seed(warshipscontext context)
//        {
//            context.ships.addorupdate(
//                p => p.shipid,
//                new ship { shipid = 1, shipname = "uss enterprise", classname = "yorktown-class" },
//                new ship { shipid = 2, shipname = "uss saratoga", classname = "lexington-class" },
//                new ship { shipid = 3, shipname = "uss missouri", classname = "iowa-class" },
//                new ship { shipid = 4, shipname = "zuikaku", classname = "shokaku-class" },
//                new ship { shipid = 5, shipname = "bismarck", classname = "bismarck-class" },
//                new ship { shipid = 6, shipname = "scharnhorst", classname = "scharnhorst-class" },
//                new ship { shipid = 7, shipname = "uss des moines", classname = "des moines-class" },
//                new ship { shipid = 8, shipname = "uss newport news", classname = "des moines-class" },
//                new ship { shipid = 9, shipname = "roma", classname = "littorio-class" },
//                new ship { shipid = 10, shipname = "hms hood", classname = "admiral-class" },
//                new ship { shipid = 11, shipname = "hms king george v", classname = "king george v-class" },
//                new ship { shipid = 12, shipname = "zara", classname = "zara-class" },
//                new ship { shipid = 13, shipname = "atago", classname = "takao-class" },
//                new ship { shipid = 14, shipname = "richelieu", classname = "richelieu-class" },
//                new ship { shipid = 15, shipname = "dunkerque", classname = "dunkerque-class" }
//            );

//            context.nations.addorupdate(
//                c => c.nationid,
//                new nation { nationid = 1, name = "us navy" },
//                new nation { nationid = 2, name = "kriegsmarine" },
//                new nation { nationid = 3, name = "regia marina" },
//                new nation { nationid = 4, name = "imperial japanese navy" },
//                new nation { nationid = 5, name = "marine national" },
//                new nation { nationid = 6, name = "royal navy" }
//            );

//            context.savechanges();

//            context.battles.addorupdate(
//                r => r.battleid,
//                new battle { battleid = 1, name = "battle of the santa cruz islands", shipid = 1 },
//                new battle { battleid = 2, name = "battle of the eastern solomons", shipid = 2 },
//                new battle { battleid = 3, name = "battle of okinawa", shipid = 3 },
//                new battle { battleid = 4, name = "battle of the philippine sea", shipid = 4 },
//                new battle { battleid = 5, name = "battle of the denmark strait", shipid = 5 },
//                new battle { battleid = 6, name = "battle of the north cape", shipid = 6 },
//                new battle { battleid = 7, name = "battle of the java sea", shipid = 13 }
//            );
//        }
//    }
//}