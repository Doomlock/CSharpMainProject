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
                var battleList = new BattleListViewModel
                {
                    //Convert each Battle to a BattleViewModel
                    Battles = warshipsContext.Battles.Select(r => new BattleViewModel
                    {
                        BattleId = r.BattleId,
                        BattleName = r.BattleName,
                        
                    }).ToList()
                };

                battleList.TotalBattles = battleList.Battles.Count;

                return View(battleList);
            }
        }

        public ActionResult BattleDetail(int id)
        {
            using (var warshipsContext = new WarshipsContext())
            {
                var Battle = warshipsContext.Battles.SingleOrDefault(p => p.BattleId == id);
                if (Battle != null)
                {
                    var battleViewModel = new BattleViewModel
                    {
                        BattleId = Battle.BattleId,
                        BattleName = Battle.BattleName,
                        
                    };

                    return View(battleViewModel);
                }
            }

            return new HttpNotFoundResult();
        }

        
        [HttpPost]
        public ActionResult AddBattle(BattleViewModel battleViewModel)
        {
            using (var warshipsContext = new WarshipsContext())
            {
                var battle = new Battle
                {
                    BattleName = battleViewModel.BattleName,
                    
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
                

                var battle = warshipsContext.Battles.SingleOrDefault(p => p.BattleId == id);
                if (battle != null)
                {
                    var battleViewModel = new BattleViewModel
                    {
                        BattleId = battle.BattleId,
                        BattleName = battle.BattleName,
                        
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
                    battle.BattleName = battleViewModel.BattleName;
                    
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





















