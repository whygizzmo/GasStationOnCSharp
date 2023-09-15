namespace GasStationService.Orders;

public class OrderCalcRequestDto
{
    public string Email { get; set; }
    public long FuelId { get; set; }
    public double Volume { get; set; }
    public string CarNumber { get; set; }
}
