using Airline.Data.Entities;
using Airline.Models;
using System;

namespace Airline.Helpers
{
    public interface IConverterHelper
    {
        Airports toAirports(AirportViewModel model, Guid imageId, bool isNew);
        Airship toAirship(AirshipViewModel model, Guid imageId, bool isNew);
        Flight toFlight(FlightViewModel model, Guid imageId, bool isNew);
        Model toModel(ModelViewModel model, Guid imageId, bool isNew);
        Ticket toTicket(TicketViewModel model, Guid imageId, bool isNew);

        AirportViewModel toAirportViewModel(Airports airport);
        AirshipViewModel toAirshipViewModel(Airship airship);
        FlightViewModel toFlightViewModel(Flight flight);
        ModelViewModel toModelViewModel(Model model);
        TicketViewModel toTicketViewModel(Ticket ticket);
    }
}
