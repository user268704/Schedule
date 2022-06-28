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
        string url = _configuration["DriveToken"];
        string downloadUrl = GetDownloadUrl(url);
        
        var response = _http.GetAsync(downloadUrl).Result; 
        var content = response.Content.ReadAsStringAsync();
        var routes = JsonConvert.DeserializeObject<IEnumerable<RouteItem>>(content.Result);
        return routes;
    }

    private string GetDownloadUrl(string token)
    {
        string url = "https://cloud-api.yandex.net/v1/disk/public/resources/download?public_key=" + "https://disk.yandex.ru/d/mpdfcmS4SC8RgA";
        using (HttpRequestMessage message = new(HttpMethod.Get, url)) 
        {
            message.Headers.Add("Authorization", "OAuth " + token);
            message.Headers.Add("Host", "cloud-api.yandex.net");
            var response = _http.SendAsync(message).Result;

            // get href from json response
            var json = JsonDocument.Parse(response.Content.ReadAsStringAsync().Result);
            var href = json.RootElement.GetProperty("href").GetString();
            
            return href;
        }
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