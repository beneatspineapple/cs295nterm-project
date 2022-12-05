using Microsoft.AspNetCore.Mvc;
using BenWilson295nTermProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using BenWilson295nTermProject.Data;

namespace BenWilson295nTermProject.Controllers
{
    public class RideTrackerController : Controller
    {
        IRideTrackerRepository repo2;

        public RideTrackerController(IRideTrackerRepository r)
        {
            repo2 = r;
        }

        public IActionResult Index()
        {
            List<Ride> rides = repo2.PopulateRides();

            return View(rides);
        }

        public IActionResult Rides(int RideId)
        {
            Ride ride = repo2.GetRideById(RideId);

            return View(ride);
        }
        public IActionResult RideInput()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RideInput(Ride model)
        {
            if (repo2.StoreRide(model) > 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
    }
}
