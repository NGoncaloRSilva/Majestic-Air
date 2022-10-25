using Airline.Data.Entities;
using Airline.Models;
using System;

namespace Airline.Helpers
{
    public class ConverterHelper : IConverterHelper
    {
        
        public Airports toAirports(AirportViewModel model, Guid imageId, bool isNew)
        {
            return new Airports
            {
                Name = model.Name,
                City = model.City,
                Country = model.Country,
                User = model.User
            };
        }

        public AirportViewModel toAirportViewModel(Airports airport)
        {
            return new AirportViewModel
            {
                Name = airport.Name,
                City = airport.City,
                Country = airport.Country,
                User = airport.User
            };
        }

        public Airship toAirship(AirshipViewModel model, Guid imageId, bool isNew)
        {
            return new Airship
            {
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
                AirshipName = airship.AirshipName,
                CreationDate = airship.CreationDate,
                model = airship.model,
                User = airship.User
            };
        }

        public Flight toFlight(FlightViewModel model, Guid imageId, bool isNew)
        {
            return new Flight
            {
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
                User = model.User
            };
        }

        public FlightViewModel toFlightViewModel(Flight flight)
        {
            return new FlightViewModel
            {
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
                User = flight.User
            };
        }

        public Model toModel(ModelViewModel model, Guid imageId, bool isNew)
        {
            return new Model
            {
                Name = model.Name,
                Tickets1stClass = model.Tickets1stClass,
                TicketsBusiness = model.TicketsBusiness,
                TicketsPremiumEconomy = model.TicketsPremiumEconomy,
                TicketsEconomy = model.TicketsEconomy,
                User = model.User
            };
        }

        public ModelViewModel toModelViewModel(Model model)
        {
            return new ModelViewModel
            {
                Name = model.Name,
                Tickets1stClass = model.Tickets1stClass,
                TicketsBusiness = model.TicketsBusiness,
                TicketsPremiumEconomy = model.TicketsPremiumEconomy,
                TicketsEconomy = model.TicketsEconomy,
                User = model.User
            };
        }

        public Ticket toTicket(TicketViewModel model, Guid imageId, bool isNew)
        {
            return new Ticket
            {
                Code = model.Code,
                FlightName = model.FlightName,
                Class = model.Class,
                User = model.User
            };
        }

        public TicketViewModel toTicketViewModel(Ticket ticket)
        {
            return new TicketViewModel
            {
                Code = ticket.Code,
                FlightName = ticket.FlightName,
                Class = ticket.Class,
                User = ticket.User
            };
        }
    }
}
