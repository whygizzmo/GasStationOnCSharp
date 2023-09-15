using Microsoft.AspNetCore.Mvc;

namespace GasStationService.Orders;

[Route("/api/order")]
[ApiController]
public class OrderController : Controller
{
    private readonly OrderService _orderService;

    public OrderController(OrderService orderService)
    {
        this._orderService = orderService;
    }

    [HttpPost("calc")]
    public IActionResult saveOrder([FromBody] OrderCalcRequestDto orderCalcRequestDto)
    {
        Order order = _orderService.calc(orderCalcRequestDto);
        if (order == null)
        {
            return NotFound("Fuel id not found");
        }

        return Ok("orderId = " + order.Id + " price = " + order.Amount);
    }

    [HttpPut("pay")]
    public IActionResult payOrder([FromBody] OrderPayRequestDto orderPayRequestDto)
    {
        return Ok(_orderService.pay(orderPayRequestDto));
    }
}