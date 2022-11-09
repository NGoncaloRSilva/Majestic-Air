using Airline.Data.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Airline.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ModelsController : Controller
    {
        private readonly IModelRepository _ModelRepository;

        public ModelsController(IModelRepository ModelRepository)
        {
            _ModelRepository = ModelRepository;
        }

        [HttpGet]
        public IActionResult GetModels()
        {
            return Ok(_ModelRepository.GetAllWithUsers());
        }
    }
}
