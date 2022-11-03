namespace ErrorhandlingService.Interfaces
{
    public interface IWarningReport
    {
        public Task<PostWarningReportResponse> PostWarning(PostWarningReportRequest data);
        public Task<GetWarningReportResponse> GetWarning(GetWarningReportRequest data);
    }
}
