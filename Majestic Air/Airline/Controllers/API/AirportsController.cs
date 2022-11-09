using Airline.Data.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Airline.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class AirportsController : Controller
    {
        private readonly IAirportsRepository _AirportRepository;

        public AirportsController(IAirportsRepository AirportRepository)
        {
            _AirportRepository = AirportRepository;
        }

        [HttpGet]
        public IActionResult GetAirports()
        {
            return Ok(_AirportRepository.GetAllWithUsers());
        }
    }
}
