using Airline.Data.Entities;
using Airline.Helpers;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System;
using System.Linq;
using System.Xml.Linq;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Microsoft.CodeAnalysis;
using System.Collections.Generic;

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

            var user = await _userHelper.GetUserbyEmailAsync("ngoncalorsilvabusiness@gmail.com");
            if (user == null)
            {
                user = new User
                {
                    FirstName = "Nuno",
                    LastName = "Silva",
                    Email = "ngoncalorsilvabusiness@gmail.com",
                    UserName = "ngoncalorsilvabusiness@gmail.com",
                    PhoneNumber = "212344555"
                };

                var result = await _userHelper.AddUserAsync(user, "123456");

                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create the user in seeder");
                }

                await _userHelper.AddUserToRoleAsync(user, "Admin");
                var token = await _userHelper.GenerateEmailConfirmationTokenAsync(user);
                await _userHelper.ConfirmEmailAsync(user, token);
            }

            var isInRole = await _userHelper.IsUserInRoleAsync(user, "Admin");

            if (!isInRole)
            {
                await _userHelper.AddUserToRoleAsync(user, "Admin");
            }

            //Criação Employee

            var user3 = await _userHelper.GetUserbyEmailAsync("joaoricardo@yopmail.com");
            if (user3 == null)
            {
                user3 = new User
                {
                    FirstName = "Luis",
                    LastName = "Souza",
                    Email = "joaoricardo@yopmail.com",
                    UserName = "joaoricardo@yopmail.com",
                    PhoneNumber = "212344555"
                };

                var result = await _userHelper.AddUserAsync(user3, "123456");

                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create the user in seeder");
                }

                await _userHelper.AddUserToRoleAsync(user3, "Employee");
                var token = await _userHelper.GenerateEmailConfirmationTokenAsync(user3);
                await _userHelper.ConfirmEmailAsync(user3, token);
            }

            var isInRole3 = await _userHelper.IsUserInRoleAsync(user3, "Employee");

            if (!isInRole3)
            {
                await _userHelper.AddUserToRoleAsync(user3, "Employee");
            }


            //Criação customer

            var user2 = await _userHelper.GetUserbyEmailAsync("luissouza@yopmail.com");
            if (user2 == null)
            {
                user2 = new User
                {
                    FirstName = "Joao",
                    LastName = "Ricardo",
                    Email = "luissouza@yopmail.com",
                    UserName = "luissouza@yopmail.com",
                    PhoneNumber = "212344555"
                };

                var result = await _userHelper.AddUserAsync(user2, "123456");

                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create the user in seeder");
                }

                await _userHelper.AddUserToRoleAsync(user2, "Customer");
                var token = await _userHelper.GenerateEmailConfirmationTokenAsync(user2);
                await _userHelper.ConfirmEmailAsync(user2, token);
            }

            var isInRole2 = await _userHelper.IsUserInRoleAsync(user2, "Customer");

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

                Model model2 = new Model
                {
                    Name = "AA64",
                    Tickets1stClass = 0,
                    TicketsBusiness = 0,
                    TicketsPremiumEconomy = 0,
                    TicketsEconomy = 0,
                    User = user
                };

                _contex.Models.Add(model2);

                Airship airship1 = new Airship
                {
                    AirshipName = "Magestic 1",
                    CreationDate = DateTime.Today,
                    model = model1,
                    User = user
                };

                _contex.Airships.Add(airship1);

                Airship airship2 = new Airship
                {
                    AirshipName = "Magestic 2",
                    CreationDate = DateTime.Today,
                    model = model2,
                    User = user
                };

                _contex.Airships.Add(airship2);

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
                    Country = "United Kingdom",
                    User = user
                };

                _contex.Airports.Add(airports2);


                Flight flight1 = new Flight
                {
                    FlightNumber = "1M",
                    Day = DateTime.Now,
                    AirshipName = airship1,
                    Price1stClass = 250,
                    PriceBusiness = 200,
                    PricePremiumEconomy = 160,
                    PriceEconomy = 150,
                    Origin = airports1,
                    Destination = airports2,
                    //Seatss = lista1,
                    User = user
                };

                Flight flight2 = new Flight
                {
                    FlightNumber = "2M",
                    Day = DateTime.Now,
                    AirshipName = airship2,
                    Price1stClass = 150,
                    PriceBusiness = 100,
                    PricePremiumEconomy = 60,
                    PriceEconomy = 50,
                    Origin = airports2,
                    Destination = airports1,
                    //Seatss = lista2,
                    User = user
                };




                TicketClass class1 = AddTicketClass("1st Class", user);
                TicketClass class2 = AddTicketClass("Business Class", user);
                TicketClass class3 = AddTicketClass("Premium Economy Class", user);
                TicketClass class4 = AddTicketClass("Economy Class", user);

                _contex.TicketClasses.Add(class1);
                _contex.TicketClasses.Add(class2);
                _contex.TicketClasses.Add(class3);
                _contex.TicketClasses.Add(class4);

                List<Seats> lista1 = AddlistSeats(airship1,class1, class2, class3, class4, user, 1);
                List<Seats> lista2 = AddlistSeats(airship2, class1, class2, class3, class4, user, 2);

                flight1.Seatss = lista1;

                flight2.Seatss = lista2;

                _contex.Flights.Add(flight1);

                _contex.Flights.Add(flight2);



                //AddTicket(flight1, class1, 250, user);
                //AddTicket(flight1, class2, 200, user);
                //AddTicket(flight1, class3, 150, user);





                await _contex.SaveChangesAsync();


                
            }
        }

        

        private TicketClass AddTicketClass(string name, User user)
        {
            TicketClass class1 = new TicketClass
            {

                Class = name,
                User = user
            };

            _contex.TicketClasses.Add(class1);

            return class1;
        }

        private void AddTicket(Flight flight1, TicketClass class1, int price ,User user)
        {
            Ticket ticket1 = new Ticket
            {
                Code = _random.Next(10000).ToString(),
                FlightName = flight1,
                Class = class1,
                Price = price,
                User = user
            };

            _contex.Tickets.Add(ticket1);

        }

        public List<Seats> AddlistSeats(Airship f, TicketClass stClass, TicketClass Business, TicketClass SeatsPremiumEconomy, TicketClass Economy, User user, int flightid)
        {
            
            var lista = new List<Seats>();

            for (int i = 0; i < f.model.Tickets1stClass; i++)
            {

                Seats seat = new Seats
                {
                    Name = $"{i+1}A",
                    Classe = stClass,
                    Available = true,
                    FlightId = flightid,
                    User = user
                };

                _contex.Seats.Add(seat);

                lista.Add(seat);


            };

            
            


            for (int i = 0; i < f.model.TicketsBusiness; i++)
            {
                Seats seat = new Seats
                {
                    Name = $"{i+1}B",
                    Classe = Business,
                    Available = true,
                    FlightId = flightid,
                    User = user
                };

                _contex.Seats.Add(seat);

                lista.Add(seat);

                
            };

            

            for (int i = 0; i < f.model.TicketsPremiumEconomy; i++)
                {
                Seats seat = new Seats
                {
                    Name = $"{i + 1}C",
                    Classe = SeatsPremiumEconomy,
                    Available = true,
                    FlightId = flightid,
                    User = user
                };

                _contex.Seats.Add(seat);

                lista.Add(seat);

                
            };

            

            for (int i = 0; i < f.model.TicketsEconomy; i++)
            {
                Seats seat = new Seats
                {
                    Name = $"{i + 1}D",
                    Classe = Economy,
                    Available = true,
                    FlightId = flightid,
                    User = user
                };

                _contex.Seats.Add(seat);

                lista.Add(seat);

                
            };




            

            return lista;
        }


    }
}
