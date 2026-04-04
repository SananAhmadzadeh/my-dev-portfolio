using Core.Entities.Abstract;

namespace Core.Logging;

public class AppLog : IEntity
{
    public int Id { get; set; }
    public string Message { get; set; }
    public string? StackTrace { get; set; }
    public string? Source { get; set; }
    public string Level { get; set; }  
    public DateTime CreatedDate { get; set; }
    public string? UserId { get; set; }  
    public string Endpoint { get; set; }  
    public string HttpMethod { get; set; } 
}
