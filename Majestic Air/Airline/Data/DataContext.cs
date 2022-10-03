using Airline.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Data
{
    public class DataContext : IdentityDbContext<User>
    {
        public DbSet<Model> Models { get; set; }
        public DbSet<Airship> Airships { get; set; }
        public DbSet<Airports> Airports { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Ticket> Tickets { get; set; }



        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
    }
}
