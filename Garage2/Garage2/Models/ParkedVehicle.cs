using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Garage2.Models
{
    public enum Type
    {
        Car,
        Motorcycle,
        Boat,
        Airplane
    }

    public class ParkedVehicle
    {
        public int Id { get; set; }
        public Type TypeOf { get; set; }
        public string Registration { get; set; }
        public string Color { get; set; }
        public string Model { get; set; }
        public string NumberOfWheels { get; set; }
    }
}