namespace Schedule.Data;

public class RouteManager
{
    public Route GetRouteById(int id)
    {
        DataContext db = new();
        var result = db.Routes.Find(id);
        
        return result;
    }

    public IQueryable<Route> GetRoutes(int routeNumber)
    {
        DataContext db = new();
        
        return from result in db.Routes 
            where result.RouteNumber == routeNumber 
            select result;
    }

    public IQueryable<Route> GetAllRoutes()
    {
        DataContext db = new();
        return db.Routes;
    }

    public IQueryable<Route> GetRoutesByPoint(string fromOrTo)
    {
        DataContext db = new();
        
        var from = db.Routes.Where(item => item.From.Contains(fromOrTo));
        var to = db.Routes.Where(item => item.To.Contains(fromOrTo));

        return from.Any() ? from : to;
    }

    public List<int> GetRouteNumbers()
    {
        DataContext db = new();
        
        List<int> result = new();
        foreach (Route route in db.Routes)
        {
            result.Add(route.RouteNumber);
        }

        return result;
    }
}