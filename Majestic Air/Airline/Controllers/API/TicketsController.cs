using Airline.Data.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Airline.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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
