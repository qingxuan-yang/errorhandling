namespace ErrorhandlingService.Models
{
    public class DataModel
    {
        public int request_id { get; set; }
        public string? mission_id { get; set; }
        public string? task_id { get; set; }
        public string? device_id { get; set; }
        public int error_code { get; set; } 
        public string? warning_content { get; set; }
    }
}
