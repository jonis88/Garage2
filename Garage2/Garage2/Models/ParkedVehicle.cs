using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Garage2.Models
{
    public class ParkedVehicle
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Registration { get; set; }
        public string Color { get; set; }
        public string Model { get; set; }
        public string NumberOfWheels { get; set; }
    }
}