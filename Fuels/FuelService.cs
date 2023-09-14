namespace GasStationService.Fuels;

public class FuelService
{
    private readonly DataDbContext _context;

    public FuelService(DataDbContext context)
    {
        _context = context;
    }

    public Fuel save(Fuel fuel)
    {
        _context.Fuels.Add(fuel);
        _context.SaveChanges();

        return fuel;
    }

    public List<Fuel> findAll()
    {
        return _context.Fuels.ToList();
    }
    
    
    
}