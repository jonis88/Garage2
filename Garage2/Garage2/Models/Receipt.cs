using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Garage2.Models
{
    public class Receipt
    {
        public int Id { get; set; }

            [Display(Name = "Type of vehicle")]
            public Type TypeOf { get; set; }

            [Display(Name = "Registration number")]
            public string Registration { get; set; }

            [Display(Name = "Color")]
            public string Color { get; set; }

            [Display(Name = "Model")]
            public string Model { get; set; }

            [Display(Name = "Number of wheels")]
            public string NumberOfWheels { get; set; }

            [Display(Name = "Time of arrival")]
            public DateTime ArrivalTime { get; set; }

            [Display(Name = "Time of departure")]
            public DateTime Departure { get; set; }
        
    }
}