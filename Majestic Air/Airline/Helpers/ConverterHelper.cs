using Airline.Data.Entities;
using Airline.Models;
using System;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;

namespace Airline.Helpers
{
    public class ConverterHelper : IConverterHelper
    {
        
        public Airports toAirports(AirportViewModel model, Guid imageId, bool isNew)
        {
            return new Airports
            {
                Id = isNew ? 0 : model.Id,
                Name = model.Name,
                City = model.City,
                Country = model.Country,
                ImageId = imageId,
                User = model.User
            };
        }

        public AirportViewModel toAirportViewModel(Airports airport)
        {
            return new AirportViewModel
            {
                Id = airport.Id,
                Name = airport.Name,
                City = airport.City,
                Country = airport.Country,
                ImageId = airport.ImageId,
                User = airport.User
            };
        }

        public Airship toAirship(AirshipViewModel model, Guid imageId, bool isNew)
        {
            return new Airship
            {
                Id = isNew ? 0 : model.Id,
                AirshipName = model.AirshipName,
                CreationDate = model.CreationDate,
                model = model.model,
                User = model.User
            };
        }

        public AirshipViewModel toAirshipViewModel(Airship airship)
        {
            return new AirshipViewModel
            {
                Id = airship.Id,
                AirshipName = airship.AirshipName,
                CreationDate = airship.CreationDate,
                model = airship.model,
                User = airship.User
            };
        }

        public Flight toFlight(FlightViewModel model, Guid imageId, bool isNew)
        {
            return new Flight
            {Id = isNew ? 0 : model.Id,
                FlightNumber = model.FlightNumber,
                Day = model.Day,
                //Time = model.Time,
                AirshipName = model.AirshipName,
                Price1stClass = model.Price1stClass,
                PriceBusiness = model.PriceBusiness,
                PricePremiumEconomy = model.PricePremiumEconomy,
                PriceEconomy = model.PriceEconomy,
                Origin = model.Origin,
                Destination = model.Destination,
                Seatss = model.Seatss,
                User = model.User
            };
        }

        public FlightViewModel toFlightViewModel(Flight flight)
        {
            

            return new FlightViewModel
            {
                Id = flight.Id,
                FlightNumber = flight.FlightNumber,
                Day = flight.Day,
                //Time = flight.Time,
                AirshipName = flight.AirshipName,
                Price1stClass = flight.Price1stClass,
                PriceBusiness = flight.PriceBusiness,
                PricePremiumEconomy = flight.PricePremiumEconomy,
                PriceEconomy = flight.PriceEconomy,
                Origin = flight.Origin,
                Destination = flight.Destination,
                Seatss = flight.Seatss,
                User = flight.User
            };
        }

        public Model toModel(ModelViewModel model, Guid imageId, bool isNew)
        {
            return new Model
            {
                Id = isNew ? 0 : model.Id,
                Name = model.Name,
                Tickets1stClass = model.Tickets1stClass,
                TicketsBusiness = model.TicketsBusiness,
                TicketsPremiumEconomy = model.TicketsPremiumEconomy,
                TicketsEconomy = model.TicketsEconomy,
                ImageId = imageId,
                User = model.User
            };
        }

        public ModelViewModel toModelViewModel(Model model)
        {
            return new ModelViewModel
            {
                Id = model.Id,
                Name = model.Name,
                Tickets1stClass = model.Tickets1stClass,
                TicketsBusiness = model.TicketsBusiness,
                TicketsPremiumEconomy = model.TicketsPremiumEconomy,
                TicketsEconomy = model.TicketsEconomy,
                ImageId = model.ImageId,
                User = model.User
            };
        }

        public Ticket toTicket(TicketViewModel model, Guid imageId, bool isNew)
        {
            return new Ticket
            {Id = isNew ? 0 : model.Id,
                Code = model.Code,
                FlightName = model.FlightName,
                //Class = model.Class,
                Price = model.Price,
                //Quantity = model.Quantity,
                Seat = model.Seat,
                User = model.User
            };
        }

        public TicketViewModel toTicketViewModel(Ticket ticket)
        {
            return new TicketViewModel
            {
                Id = ticket.Id,
                Code = ticket.Code,
                FlightName = ticket.FlightName,
                //Class = ticket.Class,
                Price = ticket.Price,
                Seat = ticket.Seat,
                //Quantity=ticket.Quantity,
                User = ticket.User
            };
        }
    }
}
