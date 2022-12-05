using BenWilson295nTermProject.Controllers;
using BenWilson295nTermProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using Xunit;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenWilson295nTermProject.Data;

namespace Tests
{
    public class RideTrackerControllerTests
    {
        IRideTrackerRepository repo2 = new FakeRideRepository();
        RideTrackerController controller;

        public RideTrackerControllerTests()
        {
            controller = new RideTrackerController(repo2);
        }

        [Fact]
        public void Rides_Test_Success()
        {
            var result = controller.RideInput(new Ride());
            Assert.True(result.GetType() == typeof(RedirectToActionResult));
        }

        [Fact]
        public void Rides_Test_Failure()
        {
            var result = controller.RideInput(null);
            Assert.True(result.GetType() == typeof(ViewResult));
        }
    }
}

