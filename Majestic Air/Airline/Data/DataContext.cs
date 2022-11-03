using Airline.Data.Entities;
using Airline.Models;
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

        public DbSet<TicketClass> TicketClasses { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }

        public DbSet<OrderDetailTemp> OrderDetailsTemp { get; set; }


        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        //Habilitar a regra de apagar em cascata (Cascade Delete Rule)

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    var cascadeFKs = modelBuilder.Model
        //        .GetEntityTypes()
        //        .SelectMany(t => t.GetForeignKeys())
        //        .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);
        //    foreach(var fk in cascadeFKs)
        //    {
        //        fk.DeleteBehavior = DeleteBehavior.Restrict;
        //    }

        //    base.OnModelCreating(modelBuilder);
        //}s
    }
}
