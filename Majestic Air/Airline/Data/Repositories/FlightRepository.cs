using Airline.Data.Entities;
using Airline.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airline.Data.Repositories
{
    public class FlightRepository : GenericRepository<Flight>, IFlightRepository
    {
        private readonly DataContext _context;
        public FlightRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable GetAllWithUsers()
        {
            return _context.Flights
                .Include(p => p.AirshipName)
                .ThenInclude(p => p.model)
                .Include(i => i.Origin)
                .Include(o => o.Destination)
                .Include(p => p.User)
                .OrderBy(a => a.FlightNumber);
        }

        public async Task<Flight> GetByIdAsyncwithAirshipAirport(int id)
        {
            return await _context.Set<Flight>()
                .Include(p => p.AirshipName)
                .ThenInclude(p => p.model)
                .Include(i => i.Origin)
                .Include(o => o.Destination)
                .OrderBy(a => a.FlightNumber).AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<FlightViewModel> AddAirportAirshipAsync(FlightViewModel model)
        {
            model.AirshipName =  await _context.Airships.FindAsync(model.AirshipId);

            var airship2 = await _context.Set<Airship>()
                .Include(p => p.model)
                .OrderBy(a => a.Id).AsNoTracking().FirstOrDefaultAsync(e => e.Id == model.AirshipId);


            model.AirshipName.model = await _context.Models.FindAsync(airship2.model.Id);

            model.Destination =  await _context.Airports.FindAsync(model.DestinationId);

            model.Origin = await _context.Airports.FindAsync(model.OriginId);

            



            return model;
        }

        

        public IEnumerable<SelectListItem> GetComboAirport()
        {
            var list = _context.Airports.Select(p => new SelectListItem
            {
                Text = p.Name,
                Value = p.Id.ToString(),

            }).ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "(Select an airport...)",
                Value = "0",
            });

            return list;
        }

        public IEnumerable<SelectListItem> GetComboAirship()
        {
            var list = _context.Airships.Select(p => new SelectListItem
            {
                Text = p.AirshipName,
                Value = p.Id.ToString(),

            }).ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "(Select an airship...)",
                Value = "0",
            });

            return list;
        }

        

        

        private async Task<bool> SaveNumberAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        
    }
}
