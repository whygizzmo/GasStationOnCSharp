using GasStationService.Clients;
using GasStationService.Fuels;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace GasStationService.Orders;

public class OrderService
{
    private readonly DataDbContext _context;
    private readonly FuelPriceService _fuelPriceService;

    public OrderService(DataDbContext context, FuelPriceService fuelPriceService)
    {
        _context = context;
        _fuelPriceService = fuelPriceService;
    }


    public Order calc(OrderCalcRequestDto orderCalcRequestDto)
    {
        Fuel fuel = _context.Fuels.Find(orderCalcRequestDto.FuelId);
        if (fuel == null)
        {
            return null;
        }

        Client client = _context.Clients.FirstOrDefault(c => c.Email == orderCalcRequestDto.Email);

        if (client == null)
        {
            client = new Client();
            client.Email = orderCalcRequestDto.Email;
            _context.Clients.Add(client);
            _context.SaveChanges();
        }


        Order order = new Order();
        order.Fuel = fuel;
        order.PayStatus = PayStatus.Pending;
        order.Volume = orderCalcRequestDto.Volume;
        order.CarNumber = orderCalcRequestDto.CarNumber;
        order.date = DateTimeOffset.UtcNow.AddHours(6);
        order.Client = client;
        order.Amount = orderCalcRequestDto.Volume *
                       _fuelPriceService
                           .getAllActualFuelPrices(orderCalcRequestDto.FuelId)
                           .FirstOrDefault().Price;

        _context.Orders.Add(order);
        _context.SaveChanges();

        return order;
    }
}