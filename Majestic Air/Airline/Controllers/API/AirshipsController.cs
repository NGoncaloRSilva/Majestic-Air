using Airline.Data.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Airline.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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
