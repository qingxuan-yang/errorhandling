using ErrorhandlingService.Interfaces;
namespace ErrorhandlingService.Controllers
{
    public class WarningReportController: IWarningReport
    {
        private readonly IDatsbaseController _databasecontroller;
        public WarningReportController(IDatsbaseController databasecontroller)
        {
            _databasecontroller = databasecontroller;
        }


        public async Task<PostWarningReportResponse> PostWarning(PostWarningReportRequest data)
        {
            Console.WriteLine(data);

            var response = new PostWarningReportResponse()
            {
                RequestId = 114522,
                Success = true,
                Message = "successful"
            };
            return await Task.FromResult(response);
        }

        public async Task<GetWarningReportResponse> GetWarning(GetWarningReportRequest data)
        {
            var response = new GetWarningReportResponse();
            return await Task.FromResult(response);
        }
    }
}
