using Grpc.Core;

namespace ErrorhandlingService.Services
{
    public class WarningReportService: WarningReport.WarningReportBase
    {
        private readonly ILogger<WarningReportService> _logger;
        public WarningReportService(ILogger<WarningReportService> logger)
        {
            _logger = logger;
        }

    }
}
