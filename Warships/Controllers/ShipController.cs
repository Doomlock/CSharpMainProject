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
                    //Convert each Person to a PersonViewModel
                    Ships = warshipContext.Ships.Select(p => new ShipViewModel
                    {
                        ShipId = p.ShipId,
                        ClassName = p.Name,
                        ShipName = p.ClassName
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
                var ship = warshipsContext.Ships.SingleOrDefault(p => p.ShipId == id);
                if (ship != null)
                {
                    var personViewModel = new ShipViewModel
                    {
                        ShipId = ship.ShipId,
                        ClassName = ship.Name,
                        ShipName = ship.ClassName
                    };

                    return View(personViewModel);
                }
            }

            return new HttpNotFoundResult();
        }

        public ActionResult PersonAdd()
        {
            var personViewModel = new ShipViewModel();

            return View("AddEditPerson", personViewModel);
        }

        [HttpPost]
        public ActionResult AddPerson(ShipViewModel personViewModel)
        {
            using (var lunchContext = new WarshipsContext())
            {
                var person = new Ship
                {
                    Name = personViewModel.ClassName,
                    ClassName = personViewModel.ShipName
                };

                lunchContext.Ships.Add(person);
                lunchContext.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public ActionResult PersonEdit(int id)
        {
            using (var lunchContext = new WarshipsContext())
            {
                var person = lunchContext.Ships.SingleOrDefault(p => p.ShipId == id);
                if (person != null)
                {
                    var personViewModel = new ShipViewModel
                    {
                        ShipId = person.ShipId,
                        ClassName = person.Name,
                        ShipName = person.ClassName
                    };

                    return View("AddEditPerson", personViewModel);
                }
            }

            return new HttpNotFoundResult();
        }

        [HttpPost]
        public ActionResult EditPerson(ShipViewModel personViewModel)
        {
            using (var lunchContext = new WarshipsContext())
            {
                var person = lunchContext.Ships.SingleOrDefault(p => p.ShipId == personViewModel.ShipId);

                if (person != null)
                {
                    person.Name = personViewModel.ClassName;
                    person.ClassName = personViewModel.ShipName;
                    lunchContext.SaveChanges();

                    return RedirectToAction("Index");
                }
            }

            return new HttpNotFoundResult();
        }

        [HttpPost]
        public ActionResult DeletePerson(ShipViewModel personViewModel)
        {
            using (var lunchContext = new WarshipsContext())
            {
                var person = lunchContext.Ships.SingleOrDefault(p => p.ShipId == personViewModel.ShipId);

                if (person != null)
                {
                    lunchContext.Ships.Remove(person);
                    lunchContext.SaveChanges();

                    return RedirectToAction("Index");
                }
            }

            return new HttpNotFoundResult();
        }
    }
}