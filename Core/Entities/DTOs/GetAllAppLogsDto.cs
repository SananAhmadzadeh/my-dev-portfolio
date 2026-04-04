namespace Core.Entities.DTOs
{
    public class GetAllAppLogsDto
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public string? StackTrace { get; set; }
        public string? Source { get; set; }
        public string Level { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Endpoint { get; set; }
        public string HttpMethod { get; set; }
    }
}
