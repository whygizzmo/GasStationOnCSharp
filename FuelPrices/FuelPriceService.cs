using Microsoft.EntityFrameworkCore;

namespace GasStationService.Fuels;

public class FuelPriceService
{
    private readonly DataDbContext _context;
    private const int countHoursFromUtc = 6;

    public FuelPriceService(DataDbContext context)
    {
        _context = context;
    }

    public FuelPrice SaveFuelPrice(FuelPriceRequestDto fuelPriceRequestDto)
    {
        int countHoursFromUtc = 6;
        FuelPrice fuelPrice = new FuelPrice();
        DateTimeOffset nowDate = DateTimeOffset.Now.ToUniversalTime().AddHours(countHoursFromUtc);
        List<FuelPrice> fuelPrices =
            _context.FuelPrices.Where(e =>
                e.CreatedDate <= nowDate && nowDate <= e.EndDate && e.Fuel.Id == fuelPriceRequestDto.FuelId).ToList();
        if (fuelPrices.Any())
        {


            int currentIndex = 0;
            while (fuelPrices.Skip(currentIndex).Any())
            {
                fuelPrices[currentIndex].EndDate = DateTimeOffset.Now.ToUniversalTime().AddHours(countHoursFromUtc);

                currentIndex++;
            }
        }

        int countYearsForEndDate = 100;
        fuelPrice.Fuel = _context.Fuels.Find(fuelPriceRequestDto.FuelId);
        fuelPrice.Price = fuelPriceRequestDto.Price;
        fuelPrice.CreatedDate = DateTimeOffset.UtcNow.ToUniversalTime().AddHours(countHoursFromUtc);
        fuelPrice.EndDate = fuelPrice.CreatedDate.ToUniversalTime().AddYears(countYearsForEndDate);
        _context.FuelPrices.Add(fuelPrice);

        _context.SaveChanges();

        return fuelPrice;
    }

    public List<FuelPrice> getAllActualFuelPrices()
    {
        DateTimeOffset nowDate = DateTimeOffset.Now.ToUniversalTime().AddHours(countHoursFromUtc);
        return _context.FuelPrices
            .Include(fp => fp.Fuel)
            .Where(e => e.CreatedDate <= nowDate && nowDate <= e.EndDate )
            .ToList();
    }
}
