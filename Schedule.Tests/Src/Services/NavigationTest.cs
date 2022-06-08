using Schedule.Core.Interfaces.Services;
using Schedule.Services;

namespace Schedule.Tests.Services;

public class NavigationTest
{
    private readonly INavigation _navigation;

    public NavigationTest()
    {
        _navigation = new NavigationService();
    }
    
    [Fact]
    public void QueryParseTest()
    {
        string testQuery1 = "https://localhost:80/api/test?search=simpleSearchQuery";
        string testQuery2 = "https://localhost:80/api/test?search=simple-search-Query";
        string testQuery3 = "https://localhost:80/api/test?search=simpleSearchQuery&simpleTestKey=key";
        string testQuery4 = "https://localhost:80/api/test?search=&simpleTestKey=key2";
        
        var queryParseResult1 = _navigation.GetParamsFromQuery(testQuery1);
        var queryParseResult2 = _navigation.GetParamsFromQuery(testQuery2);
        var queryParseResult3 = _navigation.GetParamsFromQuery(testQuery3);
        var queryParseResult4 = _navigation.GetParamsFromQuery(testQuery4);
        
        Assert.Equal("simpleSearchQuery", queryParseResult1["search"]);
        
        Assert.Equal("simple-search-Query", queryParseResult2["search"]);
        
        Assert.Equal("simpleSearchQuery", queryParseResult3["search"]);
        Assert.Equal("key", queryParseResult3["simpleTestKey"]);
        
        Assert.Equal(String.Empty, queryParseResult4["search"]);
        Assert.Equal("key2", queryParseResult4["simpleTestKey"]);
    }
}