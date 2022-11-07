using Airline.Data.Entities;
using Airline.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airline.Data.Repositories
{
    public class TicketRepository : GenericRepository<Ticket>, ITicketRepository
    {
        private readonly DataContext _context;
        public TicketRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable GetAllWithUsers()
        {
            return _context.Tickets.Include(p => p.User);
        }

        public async Task<Ticket> GetByIdAsyncwithFlight(int id)
        {
            return await _context.Set<Ticket>()
                .Include(p => p.FlightName)
                .ThenInclude(p => p.AirshipName)
                .ThenInclude(p => p.model)
                .Include(p => p.Class)
                .OrderBy(a => a.FlightName).AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<TicketViewModel> AddFlightAsync(TicketViewModel model)
        {
            var flight = await _context.Flights.FindAsync(model.FlightId);

            var flight2 = await _context.Set<Flight>()
                .Include(p => p.AirshipName)
                .ThenInclude(p => p.model)
                .Include(i => i.Origin)
                .Include(o => o.Destination)
                .OrderBy(a => a.FlightNumber).AsNoTracking().FirstOrDefaultAsync(e => e.Id == model.FlightId);

            flight.AirshipName = flight2.AirshipName;

            var classe = await _context.TicketClasses.FindAsync(model.ClassId);

            model.FlightName = flight;

            model.Class = classe;

            var classes = _context.TicketClasses;


            if (model.Class.Class == "1st Class")
            {
                model.Price = model.FlightName.Price1stClass;
            }
            else if (model.Class.Class == "Business Class")
            {
                model.Price = model.FlightName.PriceBusiness;
            }
            else if (model.Class.Class == "Premium Economy Class")
            {
                model.Price = model.FlightName.PricePremiumEconomy;
            }
            else if (model.Class.Class == "Economy Class")
            {
                model.Price = model.FlightName.PriceEconomy;
            }

            //model.Price = model.Price * (decimal)model.Quantity;
           


            
               


            return model;
        }


        

       
        

        public IEnumerable<SelectListItem> GetComboFlight()
        {
            var list = _context.Flights.Include(o=> o.AirshipName).ThenInclude(o => o.model).Select(p => new SelectListItem
            {
                Text = p.FlightNumber,
                Value = p.Id.ToString(),
                

            }).ToList();

            

            list.Insert(0, new SelectListItem
            {
                Text = "(Select a flight...)",
                Value = "0",
            });

            return list;
        }

        public IEnumerable<SelectListItem> GetComboClass(int flightId)
        {
            var flight = _context.Flights.Find(flightId);
            var list = new List<SelectListItem>();
            if (flight != null)
            {

                list = _context.TicketClasses.Select(p => new SelectListItem
                {
                    Text = p.Class,
                    Value = p.id.ToString(),

                }).ToList();

                list.Insert(0, new SelectListItem
                {
                    Text = "(Select a class...)",
                    Value = "0",
                });


            }


            return list;
        }

        public IEnumerable<SelectListItem> GetcomboTicket()
        {
            var list = _context.Tickets.Select(p => new SelectListItem
            {
                Text = p.Code,
                Value = p.Id.ToString(),

            }).ToList();


            return list;
        }


        public async Task<List<SelectListItem>> VerifyStock(int flightId)
        {
            var flight = await _context.Flights.FindAsync(flightId);
            var list = new List<SelectListItem>();
            if (flight != null)
            {

                list = _context.TicketClasses.Select(p => new SelectListItem
                {
                    Text = p.Class,
                    Value = p.id.ToString(),

                }).ToList();

                list.Insert(0, new SelectListItem
                {
                    Text = "(Select a class...)",
                    Value = "0",
                });

                var list2 = GetComboClass(flight.Id);

                if (flight.AirshipName.model.Tickets1stClass < 1)
                {
                    list.Remove(list[1]);
                }
                if (flight.AirshipName.model.TicketsBusiness < 1)
                {
                    list.Remove(list[2]);
                }
                if (flight.AirshipName.model.TicketsPremiumEconomy < 1)
                {
                    list.Remove(list[3]);
                }
                if (flight.AirshipName.model.TicketsEconomy < 1)
                {
                    list.Remove(list[4]);
                }


            }


            return list;
        }
    }
}
