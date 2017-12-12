using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Garage2.Models
{

    public class ParkedVehicle
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Type of vehicle")]
        public Type TypeOf { get; set; }

        [Required]
        [RegularExpression(@"^[A-Za-z]{3}(\d{3})$", ErrorMessage = "Use format ABC123")]
        [Display(Name = "Registration number")]
        public string Registration { get; set; }

        [Display(Name = "Color")]
        [RegularExpression(@"^[a-zA-Z'' ']+$", ErrorMessage = "Special character & Numbers should not be entered")]
        public string Color { get; set; }

        [Display(Name = "Model")]
        [RegularExpression(@"^[a-zA-Z0-9'' ']+$", ErrorMessage = "Special character & Numbers should not be entered")]
        public string Model { get; set; }

        [Display(Name = "Number of wheels")]
        [Range(0, 1000)]
        public string NumberOfWheels { get; set; }

        [Display(Name = "Time of arrival")]
        public DateTime ArrivalTime { get; set; }
    }
}