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
    public class ExperienceController : Controller
    {
        // GET: /<controller>/
        private TravelBlogContext db = new TravelBlogContext();
        public IActionResult Index()
        {
            return View(db.Experiences.ToList());
        }

        public IActionResult Create(int locationId)
        {
            var myLocation = db.Locations.FirstOrDefault(locations => locations.LocationId == locationId);
            ViewBag.currentLocation = myLocation;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Experience Experience)
        {
          //  db.Experiences.Add(Experience);
            db.SaveChanges();
            return RedirectToAction("Index", "Location");
        }
        public IActionResult Delete(int id)
        {
            var myExperience = db.Experiences.FirstOrDefault(Experiences => Experiences.ExperienceId == id);
            return View(myExperience);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {

            var myExperience = db.Experiences.FirstOrDefault(experiences => experiences.ExperienceId == id);
            db.Remove(myExperience);
            db.SaveChanges();
            return RedirectToAction("Details", "Location", new { id = myExperience.LocationId});
        }

        public IActionResult Update(int id)
        {
            var myExperience = db.Experiences.FirstOrDefault(Experiences => Experiences.ExperienceId == id);
            return View(myExperience);
        }
        [HttpPost]
        public IActionResult Update(Experience Experience)
        {
            db.Entry(Experience).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Details", "Location", new { id = Experience.LocationId });
        }
    }
}
