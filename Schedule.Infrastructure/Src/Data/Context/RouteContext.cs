using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Schedule.Core.Data.Models;
using Schedule.Core.Interfaces.Data;

namespace Schedule.Infrastructure.Data.Context;

public class RouteContext : DbContext, IRouteData
{
    public IEnumerable<RouteItem> GetAllRoutes()
    {
        return Routes;
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
            //optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=schedule;Username=postgres;Password=postgres");
        }
    }
}