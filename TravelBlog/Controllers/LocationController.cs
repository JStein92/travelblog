using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TravelBlog.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TravelBlog.Controllers
{
    public class LocationController : Controller
    {
        // GET: /<controller>/
        private TravelBlogContext db = new TravelBlogContext();
        public IActionResult Index()
        {
            
            return View(db.Locations.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Location location)
        {
            db.Locations.Add(location);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var myLocation = db.Locations.FirstOrDefault(locations => locations.LocationId == id);
            return View(myLocation);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var myLocation = db.Locations.FirstOrDefault(locations => locations.LocationId == id);
            db.Remove(myLocation);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            var myLocation = db.Locations.FirstOrDefault(locations => locations.LocationId == id);
            ViewBag.Id = new SelectList(db.Locations, "Id", "Name", "Description");
            return View(myLocation);
        }
        [HttpPost]
        public IActionResult Update(Location location)
        {
            db.Entry(location).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Details(int LocationId)
        {
            var myLocation = db.Locations
                               .Include(x => x.Experiences)
                               .FirstOrDefault(x => x.LocationId == LocationId);

            return View(myLocation);
        }
    }
}
