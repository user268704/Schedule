using Schedule.Core.Interfaces.Data;
using Schedule.Core.Interfaces.Services;
using Schedule.Data.Models;

namespace Schedule.Services;

public class FindRoutes : IFindRoute
{
    private readonly List<RouteItem> _routes;

    public FindRoutes(IRouteData data)
    {
        _routes = data.GetAllRoutes().ToList();
    }
    
    public IEnumerable<RouteItem> FindRoutesByDeparturePoint(string point)
    {
        var result = _routes.Where(item => string.Equals(item.From, point, StringComparison.OrdinalIgnoreCase));

        return result;
    }

    public IEnumerable<RouteItem> FindRoutesByArrivalPoint(string point)
    {
        var result = _routes.Where(item => string.Equals(item.To, point, StringComparison.OrdinalIgnoreCase));

        return result;
    }

    public IEnumerable<RouteItem> FindRoutesByRouteName(string routeName)
    {
        var result = _routes.Where(item =>
            string.Equals(item.RouteName, routeName, StringComparison.OrdinalIgnoreCase));

        return result;
    }

    public IEnumerable<RouteItem> FindRoutesByDepartureTime(TimeOnly time)
    {
        var result = _routes.Where(item => item.DepartureTime == time);

        return result;
    }

    public IEnumerable<RouteItem> Find(string value)
    {
        List<RouteItem> result = new List<RouteItem>();
        
        result.AddRange(FindRoutesByArrivalPoint(value));
        result.AddRange(FindRoutesByDeparturePoint(value));
        try
        {
            result.AddRange(FindRoutesByDepartureTime(TimeOnly.Parse(value)));
        }
        catch (FormatException)
        {
            // If it didn't work out to parse, then you don't need to look here
        }
        result.AddRange(FindRoutesByRouteName(value));

        return result;
    }
}