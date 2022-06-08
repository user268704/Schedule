namespace Schedule.Data.Models;

public class RoutePack
{
    public List<RouteItem> Routes { get; set; }
    public bool IsSpecialDay { get; set; }
    public string? Note { get; set; }
    public string Route { get; set; }
}