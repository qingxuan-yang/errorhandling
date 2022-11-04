using ErrorhandlingService.Interfaces;
using TacDynamics.ErrorHandlingService.Protos;
using Grpc.Core;


namespace ErrorhandlingService.Services
{
    public class ErrorService: WarningReport.WarningReportBase
    {
        private readonly ILogger<ErrorService> _logger;
        private readonly IWarningReport _warningreporter;

        public ErrorService(ILogger<ErrorService> logger, IWarningReport warningreporter)
        {
            _logger = logger;
            _warningreporter = warningreporter;
        }


        public override async Task<PostWarningReportResponse> Post(PostWarningReportRequest request, ServerCallContext context)
        {

            return await _warningreporter.PostWarning(request);
        }

        public override async Task<GetWarningReportResponse> Get(GetWarningReportRequest request, ServerCallContext context)
        {
            return await _warningreporter.GetWarning(request);
        }

    }
}
