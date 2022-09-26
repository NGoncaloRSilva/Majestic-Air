using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Airline.Data.Entities;

namespace Airline.Data
{
    public class AirlineContext : DbContext
    {
        public AirlineContext (DbContextOptions<AirlineContext> options)
            : base(options)
        {
        }

        public DbSet<Airline.Data.Entities.Model> Model { get; set; }
    }
}
