using System;

namespace ErrorhandlingService.BackgroundServices
{
    public class CallbackService: BackgroundService
    {
        private ILogger<CallbackService> _logger;

        public CallbackService(ILogger<CallbackService> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("monitor running at: {time}", DateTimeOffset.Now);
                await Task.Delay(10000, CancellationToken.None);
            }

        }
    }
}
