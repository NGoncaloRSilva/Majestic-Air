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
    public class TicketRepository : GenericRepository<Ticket>, ITicketRepository
    {
        private readonly DataContext _context;
        public TicketRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable GetAllWithUsers()
        {
            return _context.Tickets
                .Include(p => p.FlightName)
                .ThenInclude(p => p.AirshipName)
                .ThenInclude(p => p.model)
                .Include(p => p.Seat)
                .ThenInclude(p=> p.Classe)
                .Include(p => p.User);
        }

        public async Task<Ticket> GetByIdAsyncwithFlight(int id)
        {
            return await _context.Set<Ticket>()
                .Include(p => p.FlightName)
                .ThenInclude(p => p.AirshipName)
                .ThenInclude(p => p.model)
                .Include(p => p.Seat)
                .ThenInclude(p => p.Classe)
                .OrderBy(a => a.FlightName).AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<TicketViewModel> AddFlightAsync(TicketViewModel model)
        {
            var flight = await _context.Flights.FindAsync(model.FlightId);

            //var flight2 = await _context.Set<Flight>()
            //    .Include(p => p.AirshipName)
            //    .ThenInclude(p => p.model)
            //    .Include(i => i.Origin)
            //    .Include(o => o.Destination)
            //    .Include(p => p.Seatss)
            //    .ThenInclude(p => p.Classe)
            //    .OrderBy(a => a.FlightNumber).AsNoTracking().FirstOrDefaultAsync(e => e.Id == model.FlightId);

            //flight.AirshipName = flight2.AirshipName;

            //var seat = await _context.Seats.FindAsync(model.SeatId);

            var seat2 = await _context.Set<Seats>()
                .Include(p => p.Classe)
                .OrderBy(a => a.Classe).ThenBy(a=> a.Name).AsNoTracking().FirstOrDefaultAsync(e => e.Id == model.SeatId);

            var seat = await _context.Seats.FindAsync(model.SeatId);

            seat.Classe = seat2.Classe;

            model.FlightName = flight;

            model.Seat = seat;

            //var classes = _context.TicketClasses;


            if (model.Seat.Classe.Class == "1st Class")
            {
                model.Price = model.FlightName.Price1stClass;
            }
            else if (model.Seat.Classe.Class == "Business Class")
            {
                model.Price = model.FlightName.PriceBusiness;
            }
            else if (model.Seat.Classe.Class == "Premium Economy Class")
            {
                model.Price = model.FlightName.PricePremiumEconomy;
            }
            else if (model.Seat.Classe.Class == "Economy Class")
            {
                model.Price = model.FlightName.PriceEconomy;
            }

            
            seat.Available = false;

            _context.Set<Seats>().Update(seat);

            await _context.SaveChangesAsync();


            return model;
        }





        public IEnumerable<SelectListItem> GetComboFlight()
        {
            var list =  _context.Flights.Include(o => o.AirshipName)
                .ThenInclude(o => o.model).Include(o => o.Seatss).ThenInclude(o => o.Classe)
                .Where(o => o.Day >= System.DateTime.Now).Select(p => new SelectListItem
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

        public IEnumerable<SelectListItem> GetComboSeats()
        {
            var list = _context.Seats.Include(o => o.Classe).Select(p => new SelectListItem
            {
                Text = p.Name,

                Value = p.Id.ToString(),


            }).ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "(Select a Seat...)",
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
                    Value = p.Id.ToString(),

                }).ToList();

                list.Insert(0, new SelectListItem
                {
                    Text = "(Select a class...)",
                    Value = "0",
                });


            }
            else
            {

                list.Insert(0, new SelectListItem
                {
                    Text = "(First Select a Flight.)",
                    Value = "0",
                });

            }


            return list;
        }

        

        public IEnumerable<SelectListItem> GetComboSeats(int flightId)
        {
            var flight = _context.Flights.Find(flightId);
            var list = new List<SelectListItem>();
            if (flight != null)
            {
                list = _context.Tickets.Select(p => new SelectListItem
                {
                    Text = p.Code,
                    Value = p.Id.ToString(),

                }).ToList();
            }
            else
            {

                list.Insert(0, new SelectListItem
                {
                    Text = "(First Select a Flight.)",
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
            var flight = await _context.Set<Flight>()
                .Include(p => p.AirshipName)
                .ThenInclude(p => p.model)
                .Include(i => i.Origin)
                .Include(o => o.Destination)
                .OrderBy(a => a.FlightNumber).AsNoTracking().FirstOrDefaultAsync(e => e.Id == flightId);
            var list = new List<SelectListItem>();

            if (flight != null)
            {

                list = _context.TicketClasses.Select(p => new SelectListItem
                {
                    Text = p.Class,
                    Value = p.Id.ToString(),

                }).ToList();

                

                int a1 = 0,a2 = 0, a3 = 0, a4 = 0;
                
                if (flight.AirshipName.model.Tickets1stClass < 1)
                {
                    foreach (var item in list)
                    {
                        if (item.Value == "1")
                        {
                            a1++;
                        }
                    }

                    
                }
                if (flight.AirshipName.model.TicketsBusiness < 1)
                {
                    foreach (var item in list)
                    {
                        if (item.Value == "2")
                        {
                            a2++;
                        }
                    }
                }
                if (flight.AirshipName.model.TicketsPremiumEconomy < 1)
                {
                    foreach (var item in list)
                    {
                        if (item.Value == "3")
                        {
                            a3++;
                        }
                    }
                }
                if (flight.AirshipName.model.TicketsEconomy < 1)
                {
                    foreach (var item in list)
                    {
                        if (item.Value == "4")
                        {
                            a4++;
                        }
                    }
                }

                if (a4 > 0)
                {
                    list.Remove(list[3]);
                }
                if (a3 > 0)
                {
                    list.Remove(list[2]);
                }
                if (a2 > 0)
                {
                    list.Remove(list[1]);
                }
                if (a1 > 0)
                {
                    list.Remove(list[0]);
                }

                if (list.Count == 0)
                {
                    

                    list.Insert(0, new SelectListItem
                    {
                        Text = "Flight Sold Out.",
                        Value = "0",
                    });
                }






            }
            else
            {
                list.Insert(0, new SelectListItem
                {
                    Text = "(Select a flight...)",
                    Value = "0",
                });
            }


            return list;
        }

        public async Task<List<SelectListItem>> VerifySeats(int flightId)
        {
            var flight = await _context.Set<Flight>()
                .Include(p => p.AirshipName)
                .ThenInclude(p => p.model)
                .Include(i => i.Origin)
                .Include(o => o.Destination)
                .Include(o => o.Seatss)
                .ThenInclude(o => o.Classe)
                .OrderBy(a => a.FlightNumber).AsNoTracking().FirstOrDefaultAsync(e => e.Id == flightId);
            var list = new List<SelectListItem>();

            if (flight != null)
            {

                var seats = await _context.Set<Seats>().Include(p => p.Classe).Include(p => p.User).Where(p => p.FlightId == flightId).ToListAsync();

                //list = seats;

                list = _context.Seats.Include(p => p.Classe).Include(p => p.User).Where(p => p.FlightId == flightId).Select(p => new SelectListItem
                {
                    Text = p.Name,
                    Value = p.Id.ToString(),

                }).ToList();

                foreach (var item in seats)
                {
                    if (item.Available == false)
                    {
                        SelectListItem delete = new SelectListItem
                        {
                            Text = "Flight Sold Out.",
                            Value = "0",
                        }; 


                        foreach (var item2 in list)
                        {
                            if (item.Id.ToString() == item2.Value)
                            {
                                delete = item2;
                            }
                        }

                        if(delete.Value != "0")
                        {
                            list.Remove(delete);
                        }

                        


                    }
                }

                if (list.Count == 0)
                {


                    list.Insert(0, new SelectListItem
                    {
                        Text = "Flight Sold Out.",
                        Value = "0",
                    });
                }






            }
            else
            {
                list.Insert(0, new SelectListItem
                {
                    Text = "(Select a flight...)",
                    Value = "0",
                });
            }


return list;
        }

        
    }
}
