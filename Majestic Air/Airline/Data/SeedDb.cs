using Airline.Data.Entities;
using Airline.Helpers;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System;
using System.Linq;
using System.Xml.Linq;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace Airline.Data
{
    public class SeedDb
    {
        private readonly DataContext _contex;
        private readonly IUserHelper _userHelper;
        private Random _random;

        public SeedDb(DataContext contex, IUserHelper userHelper)
        {
            _contex = contex;
            _userHelper = userHelper;
            _random = new Random();
        }

        public async Task SeedAsync()
        {
            await _contex.Database.MigrateAsync();

            await _userHelper.CheckRoleAsync("Admin");
            await _userHelper.CheckRoleAsync("Employee");
            await _userHelper.CheckRoleAsync("Customer");

            //Criação Admin

            var user = await _userHelper.GetUserbyEmailAsync("ngoncalorsilva@gmail.com");
            if (user == null)
            {
                user = new User
                {
                    FirstName = "Nuno",
                    LastName = "Silva",
                    Email = "ngoncalorsilva@gmail.com",
                    UserName = "ngoncalorsilva@gmail.com",
                    PhoneNumber = "212344555"
                };

                var result = await _userHelper.AddUserAsync(user, "123456");

                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create the user in seeder");
                }

                await _userHelper.AddUserToRoleAsync(user, "Admin");
            }

            var isInRole = await _userHelper.IsUserInRoleAsync(user, "Admin");

            if (!isInRole)
            {
                await _userHelper.AddUserToRoleAsync(user, "Admin");
            }

            //Criação Employee

            var user3 = await _userHelper.GetUserbyEmailAsync("joaoricardo@gmail.com");
            if (user3 == null)
            {
                user3 = new User
                {
                    FirstName = "Luis",
                    LastName = "Souza",
                    Email = "Lsouza@gmail.com",
                    UserName = "Lsouza@gmail.com",
                    PhoneNumber = "212344555"
                };

                var result = await _userHelper.AddUserAsync(user3, "123456");

                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create the user in seeder");
                }

                await _userHelper.AddUserToRoleAsync(user3, "Employee");
            }

            var isInRole3 = await _userHelper.IsUserInRoleAsync(user, "Employee");

            if (!isInRole3)
            {
                await _userHelper.AddUserToRoleAsync(user3, "Employee");
            }

            //Criação customer

            var user2 = await _userHelper.GetUserbyEmailAsync("joaoricardo@gmail.com");
            if (user2 == null)
            {
                user2 = new User
                {
                    FirstName = "Joao",
                    LastName = "Ricardo",
                    Email = "joaoricardo@gmail.com",
                    UserName = "joaoricardo@gmail.com",
                    PhoneNumber = "212344555"
                };

                var result = await _userHelper.AddUserAsync(user2, "123456");

                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create the user in seeder");
                }

                await _userHelper.AddUserToRoleAsync(user2, "Customer");
            }

            var isInRole2 = await _userHelper.IsUserInRoleAsync(user, "Customer");

            if (!isInRole2)
            {
                await _userHelper.AddUserToRoleAsync(user2, "Customer");
            }

            if (!_contex.Models.Any())
            {
                Model model1 = new Model
                {
                    Name = "AA44",
                    Tickets1stClass = 40,
                    TicketsBusiness = 60,
                    TicketsPremiumEconomy = 45,
                    TicketsEconomy = 80,
                    User = user
                };

                _contex.Models.Add(model1);

                Airship airship1 = new Airship
                {
                    AirshipName = "Magestic 1",
                    CreationDate = DateTime.Today,
                    model = model1,
                    User = user
                };

                _contex.Airships.Add(airship1);

                Airports airports1 = new Airports
                {
                    Name = "Humberto Delgado",
                    City = "Lisbon",
                    Country = "Portugal",
                    User = user
                };

                _contex.Airports.Add(airports1);

                Airports airports2 = new Airports
                {
                    Name = "London City Airport ",
                    City = "London",
                    Country = "England",
                    User = user
                };

                _contex.Airports.Add(airports2);

                Flight flight1 = new Flight
                {
                    FlightNumber = "Humberto Delgado",
                    Day = DateTime.Today,
                    Time = DateTime.Now,
                    AirshipName = airship1,
                    Price1stClass = 250,
                    PriceBusiness = 200,
                    PricePremiumEconomy = 160,
                    PriceEconomy = 150,
                    Origin = airports1,
                    Destination = airports2,
                    User = user
                };

                _contex.Flights.Add(flight1);

                Ticket ticket1 = new Ticket
                {
                    Code = _random.Next(10000).ToString(),
                    FlightName = flight1,
                    Class = "1st Class",
                    User = user
                };

                _contex.Tickets.Add(ticket1);


                await _contex.SaveChangesAsync();


                
            }
        }

        
    }
}
