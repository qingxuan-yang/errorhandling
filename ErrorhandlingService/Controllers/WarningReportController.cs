using ErrorhandlingService.Interfaces;
using ErrorhandlingService.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using TacDynamics.ErrorHandlingService.Protos;

namespace ErrorhandlingService.Controllers
{
    public class WarningReportController: IWarningReport
    {
        IDatabaseController _databasecontroller;

        public WarningReportController( IDatabaseController databasecontroller)
        {
            _databasecontroller = databasecontroller;
        }


        public async Task<PostWarningReportResponse> PostWarning(PostWarningReportRequest data)
        {
            var collection = _databasecontroller.GetDBCollection<DataModel>(data.ServiceName);
            try
            {
                await collection.InsertManyAsync(Conver2DataModelList(data));
                return await Task.FromResult(new PostWarningReportResponse() { RequestId = data.RequestId, Message = "ok", Success = true});
            }
            catch(Exception error)
            {
                Console.WriteLine(error);
                var result = new PostWarningReportResponse
                {
                    RequestId = data.RequestId,
                    Message = error.ToString(),
                    Success = false
                };
                return await Task.FromResult(result);
            }

        }

        public async Task<GetWarningReportResponse> GetWarning(GetWarningReportRequest data)
        {
            var response = new GetWarningReportResponse();
            return await Task.FromResult(response);
        }


        private List<DataModel> Conver2DataModelList(PostWarningReportRequest reportdata)
        {
            List<DataModel> result = new List<DataModel>();
            if(reportdata.WarningData.Count != 0)
            {
                foreach(var warning_data in reportdata.WarningData)
                {
                    var error = new DataModel();
                    error.request_id = (int)reportdata.RequestId;
                    error.mission_id = warning_data.MissionId;
                    error.task_id = warning_data.TaskId;
                    error.device_id = warning_data.DeviceId;
                    error.error_code = warning_data.ErrorCode;
                    error.warning_content = warning_data.WarningContent;
                    result.Add(error);
                }
                return result;
            }
            else { return result; }

        }

    }
}
