using System.Text.RegularExpressions;
using Schedule.Core.Interfaces.Services;

namespace Schedule.Services;

public class NavigationService : INavigation
{
    public Dictionary<string, string> GetParamsFromQuery(string query)
    {
        Uri uri = new Uri(query);

        string queryFromUrl = uri.Query;
        
        var keys = queryFromUrl.Split('&', StringSplitOptions.RemoveEmptyEntries);
        var result = keys.ToDictionary(key => Regex.Replace(key.Split("=")[0], "[^a-zA-Z]", ""),
            value => value.Split("=")[1]);
        

        return result;
    }
}