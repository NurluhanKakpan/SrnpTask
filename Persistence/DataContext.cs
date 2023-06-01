using Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace Core.Persistence;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        
    }
    
    public DbSet<SrnpInfo> SrnpInfos { get; set; }
    public DbSet<SrnpPrice> SrnpPrices { get; set; }
    public DbSet<ForbiddenSeries> ForbiddenSeries { get; set; }
}