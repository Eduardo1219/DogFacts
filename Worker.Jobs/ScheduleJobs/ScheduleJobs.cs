using Domain.DogFacts.Entity;
using Domain.DogFacts.Service;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Text.Json;
using Worker.Jobs.Dtos.DogFacts;
using Worker.Jobs.Helper;


namespace Worker.Jobs.ScheduleJobs
{
    public class ScheduleJobs : IScheduleJobs
    {
        private static readonly HttpClient _httpClient = new HttpClient();
        private ILogger<ScheduleJobs> _logger;
        private readonly IDogFactsService _dogFactsService;

        public ScheduleJobs(ILogger<ScheduleJobs> logger, IDogFactsService dogFactsService)
        {
            _logger = logger;
            _dogFactsService = dogFactsService;
        }

        public async Task AddNewDogFactsAsync(int callsQnt = 1)
        {
            _logger.LogInformation($"Job to add and update facts running at {DateTime.UtcNow}");
            int callsMade = 0;

            do
            {
                var dogFactDto = await GetNewDogFactsAsync();
                callsMade++;
                if (dogFactDto == null)
                {
                    _logger.LogInformation("Was not possible to get a new dog fact! The job is beeing ended");
                    break;
                }
                _logger.LogInformation($"Job made {callsMade} calls to Dog Facts API");
                var dogFactEntity = dogFactDto.MapDog();
                var entity = await _dogFactsService.GetDogFactByIdAsync(dogFactEntity.Id);
                if (entity != null)
                {
                    entity.ChangeType(dogFactEntity.Type);
                    entity.ChangeBodyAttribute(dogFactEntity.BodyAttribute);
                    await _dogFactsService.UpdateDogFactAsync(entity);
                    _logger.LogInformation($"Dog fact with ID {dogFactEntity.Id} updated.");
                    continue;
                }
                
                await _dogFactsService.AddNewDogFactAsync(dogFactEntity);
                _logger.LogInformation($"New dog fact with ID {dogFactEntity.Id} created.");
            } while (callsMade < callsQnt);
            _logger.LogInformation($"Job to add and update facts end running at {DateTime.UtcNow}");
        }


        public async Task<DogFactsGetDto> GetNewDogFactsAsync()
        {
            _logger.LogInformation($"Calling dog facts API.");
            var response = await _httpClient.GetAsync("https://dogapi.dog/api/v2/facts");
            if (response.IsSuccessStatusCode)
            {
                _logger.LogInformation($"Success on dog facts API request");
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var dogFact = JsonConvert.DeserializeObject<DogFactsGetDto>(jsonResponse);
                return dogFact;
            }
            _logger.LogInformation($"Request to dog facts API Failed.");
            return null;
        }
    }
}
