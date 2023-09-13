using GasStationService.Clients;
using GasStationService.Fuels;
using GasStationService.Orders;
using Microsoft.EntityFrameworkCore;

namespace GasStationService;

public class DataDbContext:DbContext
{
    protected readonly IConfiguration iConfig;
    
    public DbSet<Fuel> Fuels { get; set; }
    public DbSet<Client>Clients { get; set; }
    public DbSet<FuelPrice>FuelPrices { get; set; }
    public DbSet<Order>Orders { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseNpgsql("Server=localhost;Port=5433;Database=test;User Id=postgres;Password=postgres;");
    }
    
    public DataDbContext(DbContextOptions<DataDbContext> options, IConfiguration iConf)
        : base(options)
    {
        iConfig = iConf;
    }
    
}