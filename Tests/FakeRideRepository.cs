using BenWilson295nTermProject.Data;
using BenWilson295nTermProject.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class FakeRideRepository : IRideTrackerRepository
    {
        private List<Ride> rides = new List<Ride> { new Ride { RideId = 1 } };

        public List<Ride> PopulateRides()
        {
            return rides;
        }
        public Ride GetRideById(int id)
        {
            Ride ride = rides.Find(r => r.RideId == id);

            return ride;
        }

        public int StoreRide(Ride model)
        {
            int status = 0;
            if (model != null)
            {
                model.RideId = rides.Count + 1;
                rides.Add(model);
                status = 1;
            }
            return status;
        }
    }
}
