using Schedule.Data.Models;

namespace Schedule.Core.Interfaces.Services;

public interface IFindRoute
{
    IEnumerable<RouteItem> FindRoutesByDeparturePoint(string point);
    IEnumerable<RouteItem> FindRoutesByArrivalPoint(string point);
    IEnumerable<RouteItem> FindRoutesByRouteName(string routeName);
    IEnumerable<RouteItem> FindRoutesByDepartureTime(TimeOnly time);
    IEnumerable<RouteItem> Find(string value);
}