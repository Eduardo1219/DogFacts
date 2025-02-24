using Hangfire;
using Worker.Jobs.ScheduleJobs;


namespace Worker
{
    public class HangfireWorker : BackgroundService
    {
        private readonly IRecurringJobManager _recurringJobManager;
        private readonly IConfiguration _configuration;

        public HangfireWorker(IRecurringJobManager recurringJobManager, IConfiguration configuration)
        {
            _recurringJobManager = recurringJobManager;
            _configuration = configuration;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            string cronExpression = _configuration["Jobs:DogFactsCronExecution"] ?? "0 * * * *";
            bool parsedSuccess = int.TryParse(_configuration["Jobs:DogFactsQntInsertion"], out int result);
            _recurringJobManager.AddOrUpdate<IScheduleJobs>("NotifyManager", j => j.AddNewDogFactsAsync(parsedSuccess ? result : 2), cronExpression);
            return Task.CompletedTask;
        }
    }
}
