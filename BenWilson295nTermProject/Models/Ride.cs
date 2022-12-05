using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BenWilson295nTermProject.Models
{
    public class Ride
    { 
        public int RideId { get; set; }
        public double Distance { get; set; }
        public int Duration { get; set; }
        public string StartPoint { get; set; }
        public string EndPoint { get; set; }
        public string RideDate { get; set; }
        public DateTime DateSubmitted { get; set; }
    }
}
