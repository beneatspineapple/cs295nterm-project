using BenWilson295nTermProject;
using BenWilson295nTermProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BenWilson295nTermProject.Data
{
    public class RideTrackerRepository : IRideTrackerRepository
    {
        private AppDbContext context;
        public RideTrackerRepository(AppDbContext appDbContext)
        {
            context = appDbContext;
        }

        public Ride GetRideById(int id)
        {
            var ride = context.Rides
                .Where(ride => ride.RideId == id)
                .SingleOrDefault();
            return ride;
        }
        public List<Ride> PopulateRides()
        {
            return context.Rides.OrderByDescending(ride => ride.DateSubmitted).ToList();
        }
        public int StoreRide(Ride model)
        {
            model.DateSubmitted = DateTime.Now;
            context.Rides.Add(model);
            return context.SaveChanges();
        }
    }
}
