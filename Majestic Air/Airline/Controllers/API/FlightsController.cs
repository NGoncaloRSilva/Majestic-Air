using Airline.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace Airline.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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
