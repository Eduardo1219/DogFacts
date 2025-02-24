using Domain.DogFacts.Service;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace DogFacts.Controllers.DogFacts.Http
{
    [Route("api/[controller]")]
    [SwaggerTag("Endpoints to manage dog facts")]
    [Produces("application/json")]
    public class DogFactsController : Controller
    {
        private readonly IDogFactsService _dogFactsService;
        public DogFactsController(IDogFactsService dogFactsService)
        {
            _dogFactsService = dogFactsService;
        }

        /// <summary>
        /// Get dog Facts
        /// </summary>
        /// <param name="search">Search by body attribute or type</param>
        /// <param name="start">Start</param>
        /// <param name="take">Take</param>
        /// <response code="200">Dog Facts</response>
        /// <response code="500">Internal server error</response>
        [HttpGet]
        public async Task<IActionResult> GetDogFactsAsync(
            [FromQuery] string search,
            [FromQuery] int start = 1,
            [FromQuery] int take = 5)
        {

            var dogFacts = await _dogFactsService.GetDogFactPagedAsync(search, start, take);
            if (!dogFacts.Any())
                return StatusCode(StatusCodes.Status404NotFound, "Any dog facts was found!");

            return Ok(dogFacts);
        }

        /// <summary>
        /// Get dog Facts count
        /// </summary>
        /// <param name="search">Search by body attribute or type</param>
        /// <response code="200">Count</response>
        /// <response code="500">Internal Server error</response>
        [HttpGet("count")]
        public async Task<IActionResult> GetDogFactCountAsync(
            [FromQuery] string search)
        {

            var dogFactsCount = await _dogFactsService.GetDogFactCountAsync(search);

            return Ok(dogFactsCount);
        }
    }
}
