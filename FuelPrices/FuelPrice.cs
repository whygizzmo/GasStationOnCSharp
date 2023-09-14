using System.ComponentModel.DataAnnotations.Schema;

namespace GasStationService.Fuels;

public class FuelPrice
{
    public long Id { get; set; }
    public Fuel? Fuel { get; set; }
    public double Price { get; set; }
    public DateTimeOffset CreatedDate { get; set; }
    public DateTimeOffset EndDate { get; set; }


    public override string ToString()
    {
        return base.ToString();
    }
}