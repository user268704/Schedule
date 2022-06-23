using System.Text.Json;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Schedule.Core.Data.Models;
using Schedule.Core.Interfaces.Data;

namespace Schedule.Infrastructure.Data;

public class DriveContext : IRouteData
{
    private HttpClient _http;
    private IConfiguration _configuration;
    
    public DriveContext(IConfiguration configuration)
    {
        _configuration = configuration;
        _http = new();
    }

    private async Task<IEnumerable<RouteItem>?> GetRoutesAsync()
    {
        var httpResponse =  _http.GetAsync(_configuration.GetConnectionString("Drive")).Result;

        return Deserialize(await httpResponse.Content.ReadAsStringAsync());
    }
    
    private IEnumerable<RouteItem>? Deserialize(string json)
    {
        return JsonConvert.DeserializeObject<IEnumerable<RouteItem>>(json);
    }

    public IEnumerable<RouteItem> GetAllRoutes()
    {
        var routes = GetRoutesAsync();
        return routes.Result;
    }

    public IEnumerable<RoutePack> GetAllPacks()
    {
        throw new NotImplementedException();
    }
}