namespace Schedule.Core.Interfaces.Services;

public interface INavigation
{
    Dictionary<string, string> GetParamsFromQuery(string query);
}