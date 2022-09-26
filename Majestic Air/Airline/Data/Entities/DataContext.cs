using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Data.Entities
{
    public class DataContext : IdentityDbContext<User>
    {
        public DbSet<Model> Owners { get; set; }
        public DbSet<Airship> Airships { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Ticket> Tickets { get; set; }



        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
    }
}
