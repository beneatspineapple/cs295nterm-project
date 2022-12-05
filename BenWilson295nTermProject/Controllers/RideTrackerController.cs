using Microsoft.AspNetCore.Mvc;
using BenWilson295nTermProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BenWilson295nTermProject.Controllers
{
    public class RideTrackerController : Controller
    {
        AppDbContext context;

        public RideTrackerController(AppDbContext c)
        {
            context = c;
        }

        public IActionResult Index()
        {
            List<Ride> rides = context.Rides.OrderByDescending(ride => ride.DateSubmitted).ToList();

            return View(rides);
        }

        public IActionResult Rides(int RideId)
        {
            Ride ride = context.Rides.Find(RideId);

            return View(ride);
        }
        public IActionResult RideInput()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RideInput(Ride model)
        {
            model.DateSubmitted = DateTime.Now;
            context.Rides.Add(model);
            context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
