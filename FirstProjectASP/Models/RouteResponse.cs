namespace FirstProjectASP.Models;

public class RouteResponse
{
    public string? ControllerName { get; set; }
    public string? ActionName { get; set; }
    public string? UserId { get; set; }
    public DateTime Timestamp { get; set; }
}