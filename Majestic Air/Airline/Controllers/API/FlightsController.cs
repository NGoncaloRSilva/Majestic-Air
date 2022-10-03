using Airline.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace Airline.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightsController : Controller
    {
        private readonly IFlightRepository _FlightRepository;

        public FlightsController(IFlightRepository FlightRepository)
        {
            _FlightRepository = FlightRepository;
        }

        [HttpGet]
        public IActionResult GetFlights()
        {
            return Ok(_FlightRepository.GetAllWithUsers());
        }
    }
}
