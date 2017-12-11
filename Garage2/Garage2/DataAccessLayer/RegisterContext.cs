using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Garage2.DataAccessLayer
{
    public class RegisterContext : DbContext
    {
        public RegisterContext() : base("DefaultConnection2") { }
        public DbSet<Models.ParkedVehicle> ParkedVehicles { get; set; }
    }
}