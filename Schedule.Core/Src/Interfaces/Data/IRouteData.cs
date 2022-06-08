using Schedule.Data.Models;

namespace Schedule.Core.Interfaces.Data;

public interface IRouteData
{
    IEnumerable<RouteItem> GetAllRoutes();
    IEnumerable<RoutePack> GetAllPacks();
}