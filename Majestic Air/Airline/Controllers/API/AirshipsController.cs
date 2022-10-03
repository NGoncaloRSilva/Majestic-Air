using Airline.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Airline.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirshipsController : Controller
    {
        private readonly IAirshipRepository _AirshipRepository;

        public AirshipsController(IAirshipRepository AirshipRepository)
        {
            _AirshipRepository = AirshipRepository;
        }

        [HttpGet]
        public IActionResult GetAirships()
        {
            return Ok(_AirshipRepository.GetAllWithUsers());
        }
    }
}
