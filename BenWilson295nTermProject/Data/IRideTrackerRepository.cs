using BenWilson295nTermProject.Models;
using System.Collections.Generic;

namespace BenWilson295nTermProject.Data
{
    public interface IRideTrackerRepository
    {
        public Ride GetRideById(int id);
        public int StoreRide(Ride ride);
        public List<Ride> PopulateRides();
    }
}