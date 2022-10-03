using Airline.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Airline.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : Controller
    {
        private readonly ITicketRepository _TicketRepository;

        public TicketsController(ITicketRepository TicketRepository)
        {
            _TicketRepository = TicketRepository;
        }

        [HttpGet]
        public IActionResult GetTickets()
        {
            return Ok(_TicketRepository.GetAllWithUsers());
        }
    }
}
