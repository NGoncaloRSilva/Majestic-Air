using Airline.Data.Entities;
using Airline.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airline.Data.Repositories
{
    public interface ITicketRepository : IGenericRepository<Ticket>
    {
        public IQueryable GetAllWithUsers();

        public Task<Ticket> GetByIdAsyncwithFlight(int id);

        public IEnumerable<SelectListItem> GetComboFlight();

        public IEnumerable<SelectListItem> GetComboClass(int flightId);

        public IEnumerable<SelectListItem> GetComboSeats(int classId);

        public IEnumerable<SelectListItem> GetcomboTicket();

        

        public Task<List<SelectListItem>> VerifyStock(int flightId);

        public Task<List<SelectListItem>> VerifySeats(int flightId);

        Task<TicketViewModel> AddFlightAsync(TicketViewModel model);

    }
}
