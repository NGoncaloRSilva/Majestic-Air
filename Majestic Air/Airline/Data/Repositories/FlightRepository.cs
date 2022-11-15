using Airline.Data.Entities;
using Airline.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections;
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

        public  IQueryable GetAllWithUsers()
        {
            return  _context.Flights
                
                .Include(p => p.AirshipName)
                .ThenInclude(p => p.model)
                .Include(p => p.Destination)
                .Include(p => p.Origin)
                .Include(p => p.Seatss)
                .ThenInclude(p => p.Classe)
                .OrderBy(p => p.Day);
        }
        
        public async Task<Flight> GetByIdAsyncwithAirshipAirport(int id)
        {
            return await _context.Set<Flight>()
                .Include(p => p.AirshipName)
                .ThenInclude(p => p.model)
                .Include(p => p.Destination)
                .Include(p => p.Origin)
                .Include(p => p.Seatss)
                .ThenInclude(p => p.Classe)
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

            //var name = await _context.Flights.FindAsync(model.Id);

            //model.FlightNumber = name.FlightNumber;

            var stClass = await _context.TicketClasses.FindAsync(1);
            var Business = await _context.TicketClasses.FindAsync(2);
            var SeatsPremiumEconomy = await _context.TicketClasses.FindAsync(3);
            var Economy = await _context.TicketClasses.FindAsync(4);

            if (model.Seatss != null)
            {
                for (int i = 0; i < model.AirshipName.model.Tickets1stClass; i++)
                {
                    

                    model.Seatss.Add(new Seats
                    {
                        Name = $"{i}A",
                        Classe = stClass,
                        Available = true,

                    });

                    Seats seat = new Seats
                    {
                        Name = $"{i + 1}A",
                        Classe = stClass,
                        Available = true,
                    };

                    _context.Seats.Add(seat);

                    model.Seatss.Add(seat);

                   
                };

                for (int i = 0; i < model.AirshipName.model.TicketsBusiness; i++)
                {


                    model.Seatss.Add(new Seats
                    {
                        Name = $"{i}B",
                        Classe = Business,
                        Available = true,

                    });

                    Seats seat = new Seats
                    {
                        Name = $"{i + 1}B",
                        Classe = Business,
                        Available = true,
                    };

                    _context.Seats.Add(seat);

                    model.Seatss.Add(seat);
                    
                };

                for (int i = 0; i < model.AirshipName.model.TicketsPremiumEconomy; i++)
                {


                    model.Seatss.Add(new Seats
                    {
                        Name = $"{i}C",
                        Classe = SeatsPremiumEconomy,
                        Available = true,

                    });

                    Seats seat = new Seats
                    {
                        Name = $"{i + 1}C",
                        Classe = SeatsPremiumEconomy,
                        Available = true,
                    };

                    _context.Seats.Add(seat);

                    model.Seatss.Add(seat);
                };

                for (int i = 0; i < model.AirshipName.model.TicketsEconomy; i++)
                {


                    model.Seatss.Add(new Seats
                    {
                        Name = $"{i}D",
                        Classe = Economy,
                        Available = true,

                    });

                    Seats seat = new Seats
                    {
                        Name = $"{i + 1}D",
                        Classe = Economy,
                        Available = true,
                    };

                    _context.Seats.Add(seat);

                    model.Seatss.Add(seat); 
                };
            }
            else
            {
                int aux = 0;

                for (int i = 0; i < model.AirshipName.model.Tickets1stClass; i++)
                {


                    model.Seatss[aux].Classe = stClass;

                    aux++;
                };

                for (int i = 0; i < model.AirshipName.model.TicketsBusiness; i++)
                {


                    model.Seatss[aux].Classe = Business;
                    aux++;
                };

                for (int i = 0; i < model.AirshipName.model.TicketsPremiumEconomy; i++)
                {


                    model.Seatss[aux].Classe = SeatsPremiumEconomy;
                    aux++;
                };

                for (int i = 0; i < model.AirshipName.model.TicketsEconomy; i++)
                {


                    model.Seatss[aux].Classe = Economy;
                    aux++;
                };
            }

            



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


        public async Task<List<SelectListItem>> VerifyAirport(int airportId)
        {
            var airport = await _context.Airports.FindAsync(airportId);

            var list = new List<SelectListItem>();

            if (airport != null)
            {

                list = _context.Airports.Select(p => new SelectListItem
                {
                    Text = p.Name,
                    Value = p.Id.ToString(),

                }).ToList();

                inicio:

                foreach (var item in list)
                {
                    if (item.Text == airport.Name)
                    {
                        list.Remove(item);
                        goto inicio;
                    }
                        
                }

                

                if (list.Count == 0)
                {


                    list.Insert(0, new SelectListItem
                    {
                        Text = "Error please introduce more Aiports before continuing",
                        Value = "0",
                    });
                }


            }

            return list;


        }



        private async Task<bool> SaveNumberAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        
    }
}
