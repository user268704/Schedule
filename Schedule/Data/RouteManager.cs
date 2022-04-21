namespace Schedule.Data;

public class RouteManager
{
    public Route GetRouteById(int id)
    {
        DataContext db = new();
        var result = db.Routes.Find(id);
        
        return result;
    }

    public async Task<IQueryable<Route>> GetRoutesAsync(int routeNumber)
    {
        DataContext db = new();
        
        return await from result in db.Routes 
            where result.RouteNumber == routeNumber 
            select result;
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