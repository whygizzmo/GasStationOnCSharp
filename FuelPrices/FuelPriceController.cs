using Microsoft.AspNetCore.Mvc;

namespace GasStationService.Fuels;
[Route("/api/fuelPrice")]
[ApiController]
public class FuelPriceController:Controller
{
    private readonly FuelPriceService fuelPriceService;

    public FuelPriceController(FuelPriceService fuelPriceService)
    {
        this.fuelPriceService = fuelPriceService;
    }

    [HttpPost("save")]
    public IActionResult saveFuelPrice([FromBody] FuelPriceRequestDto fuelPriceRequestDto)
    {
       return Ok(fuelPriceService.SaveFuelPrice(fuelPriceRequestDto));
       
    }
    [HttpGet("list")]
    public IActionResult getAllFuelPrice()
    {
        return Ok(fuelPriceService.getAllActualFuelPrices());
    }
    
    
    
}