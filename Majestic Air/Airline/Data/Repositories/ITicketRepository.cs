using Airline.Data.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace Airline.Data.Repositories
{
    public interface ITicketRepository : IGenericRepository<Ticket>
    {
        public IQueryable GetAllWithUsers();

        public IEnumerable<SelectListItem> GetComboTickets();
    }
}
