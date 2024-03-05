using Microsoft.AspNetCore.Mvc;
using PlanetunAPI.Services;
using System.Diagnostics.Metrics;

namespace PlanetunAPI.Controllers
{
    [ApiController]
    [Route("api/")]
    public class PlanetunController : ControllerBase
    {
        

        private readonly ILogger<PlanetunController> _logger;
        private IPlanetunService _planetunService;

        public PlanetunController(ILogger<PlanetunController> logger, IPlanetunService planetunService)
        {
            _logger = logger;
            _planetunService = planetunService;
        }

         
        [HttpPost("v1/[controller]/CriarTabuada")]
        public async Task RunMultiplicationTable(IEnumerable<int> numbers)
        {
            await _planetunService.GenerateMultiplationTable(numbers);
        }
    }
}