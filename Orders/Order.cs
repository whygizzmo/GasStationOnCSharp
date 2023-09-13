using System.ComponentModel.DataAnnotations.Schema;
using GasStationService.Clients;
using GasStationService.Fuels;

namespace GasStationService.Orders;
//[Table("NewOrders")]
public class Order
{
    public long Id { get; set; }
    public Fuel Fuel { get; set; }
    public Client Client { get; set; }
    public double Volume { get; set; }
    public double Amount { get; set; }
    public double Deposite { get; set; }
    public double Change { get; set; }
    public string CarNumber { get; set; }
    public DateTimeOffset date { get; set; }
    public PayStatus PayStatus { get; set; }
}