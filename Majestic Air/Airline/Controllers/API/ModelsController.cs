using Airline.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Airline.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
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
