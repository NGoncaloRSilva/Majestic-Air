using Airline.Data.Entities;
using Airline.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airline.Data.Repositories
{
    public interface IFlightRepository : IGenericRepository<Flight>
    {
        public IQueryable GetAllWithUsers();

        public Task<Flight> GetByIdAsyncwithAirshipAirport(int id);

        public IEnumerable<SelectListItem> GetComboAirship();

        public IEnumerable<SelectListItem> GetComboAirport();

        Task<FlightViewModel> AddSeatstoEditAsync(FlightViewModel model);
        Task<FlightViewModel> AddAirportAirshipAsync(FlightViewModel model);

        Task<Flight> AddSeatsAsync(int flightId);

        public Task<List<SelectListItem>> VerifyAirport(int airportId);




    }
}
