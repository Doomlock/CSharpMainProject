using Warships.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;


namespace Warships.Controllers
{
    public class ShipController : Controller
    {
        public ActionResult Index()
        {
            using (var warshipContext = new WarshipsContext())
            {
                var shipList = new ShipListViewModel
                {
                    //Convert each Ship to a ShipViewModel
                    Ships = warshipContext.Ships.Select(p => new ShipViewModel
                    {
                        ShipId = p.ShipId,
                        ShipName = p.ShipName,
                        ShipTypeName = p.ShipType.ShipTypeName,
                                                
                    }).ToList()
                };

                shipList.TotalShips = shipList.Ships.Count;

                return View(shipList);
            }
        }

        public ActionResult ShipDetail(int id)
        {
            using (var warshipsContext = new WarshipsContext())
            {
                var ship = warshipsContext.Ships.Include("ShipType").SingleOrDefault(p => p.ShipId == id);
                if (ship != null)
                {
                    var ShipViewModel = new ShipViewModel
                    {
                        ShipId = ship.ShipId,
                        ShipName = ship.ShipName,
                        ShipTypeName = ship.ShipType.ShipTypeName
                    };

                    return View(ShipViewModel);
                }
            }

            return new HttpNotFoundResult();
        }

        public ActionResult ShipAdd()
        {
            var shipViewModel = new ShipViewModel();

            using (var warshipContext = new WarshipsContext())
            {
                var shipTypes = warshipContext.ShipTypes.Select(st => new SelectListItem
                {
                    Value = st.ShipTypeId.ToString(),
                    Text = st.ShipTypeName

                }).ToList();

                ViewBag.ShipTypes = shipTypes;
                
            }



                return View("AddEditShip", shipViewModel);
        }

        [HttpPost]
        public ActionResult AddShip(ShipViewModel ShipViewModel)
        {
            using (var warshipContext = new WarshipsContext())
            {
                var ship = new Ship
                {
                    ShipName = ShipViewModel.ShipName,
                    ShipTypeId = ShipViewModel.ShipTypeId
                };

                warshipContext.Ships.Add(ship);
                warshipContext.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public ActionResult ShipEdit(int id)
        {
            using (var warshipContext = new WarshipsContext())
            {                
                
                var shipTypes = warshipContext.ShipTypes.Select(st => new SelectListItem
                {
                    Value = st.ShipTypeId.ToString(),
                    Text = st.ShipTypeName

                }).ToList();

                ViewBag.ShipTypes = shipTypes;

                
                var ship = warshipContext.Ships.SingleOrDefault(p => p.ShipId == id);
                if (ship != null)
                {
                    var shipViewModel = new ShipViewModel
                    {
                        ShipId = ship.ShipId,
                        ShipTypeId = ship.ShipTypeId,
                        ShipName = ship.ShipName
                    };

                    return View("AddEditShip", shipViewModel);
                }


            }

            return new HttpNotFoundResult();
        }

        [HttpPost]
        public ActionResult EditShip(ShipViewModel shipViewModel)
        {
            using (var warshipsContext = new WarshipsContext())
            {
                var ship = warshipsContext.Ships.SingleOrDefault(p => p.ShipId == shipViewModel.ShipId);

                if (ship != null)
                {
                    ship.ShipName = shipViewModel.ShipName;
                    ship.ShipTypeId = shipViewModel.ShipTypeId;
                    warshipsContext.SaveChanges();

                    return RedirectToAction("Index");
                }
            }

            return new HttpNotFoundResult();
        }

        [HttpPost]
        public ActionResult DeleteShip(ShipViewModel shipViewModel)
        {
            using (var warshipsContext = new WarshipsContext())
            {
                var ship = warshipsContext.Ships.SingleOrDefault(p => p.ShipId == shipViewModel.ShipId);

                if (ship != null)
                {
                    warshipsContext.Ships.Remove(ship);
                    warshipsContext.SaveChanges();

                    return RedirectToAction("Index");
                }
            }

            return new HttpNotFoundResult();
        }
    }
}