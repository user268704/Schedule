using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Schedule.Core.Interfaces.Data;
using Schedule.Data;
using Schedule.Data.Models;

namespace Schedule.Infrastructure.Data.Context;

public class RouteContext : DbContext, IRouteData
{
    public IEnumerable<RouteItem> GetAllRoutes()
    {
        List<RouteItem> testResult = new List<RouteItem>()
        {
            new()
            {
                From = "testFrom1",
                Id = 1,
                Note = "testNote1",
                To = "testTo1",
                DepartureTime = TimeOnly.MinValue,
                RouteName = "test1",
                IsSpecialDay = false
            },
            new()
            {
                From = "testFrom1",
                Id = 2,
                Note = "testNote1",
                To = "testTo1",
                DepartureTime = TimeOnly.MinValue,
                RouteName = "test1",
                IsSpecialDay = false
            },
            new()
            {
                From = "testFrom2",
                Id = 3,
                Note = "testFrom2",
                To = "testFrom2",
                DepartureTime = TimeOnly.MinValue,
                RouteName = "test2",
                IsSpecialDay = false
            },
            new()
            {
                From = "",
                Id = 3,
                Note = "",
                To = "",
                DepartureTime = TimeOnly.MinValue,
                RouteName = "",
                IsSpecialDay = false
            },
        };

        return testResult;
    }

    public IEnumerable<RoutePack> GetAllPacks()
    {
        throw new NotImplementedException();
    }
    
    private readonly IConfiguration _configuration;
        
    public RouteContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public RouteContext(DbContextOptions<RouteContext> options)
        : base(options)
    {
    }

    protected virtual DbSet<RouteItem> Routes { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
            optionsBuilder.UseNpgsql(_configuration.GetConnectionString("PostgresSql"));
        }
    }
}