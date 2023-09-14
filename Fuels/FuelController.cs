using GasStationService.Fuels;
using Microsoft.AspNetCore.Mvc;

namespace GasStationService.Controllers;
[Route("/api/fuel")]
[ApiController]
public class FuelController:Controller
{
    private readonly FuelService fuelService;

    public FuelController(FuelService fuelService)
    {
        this.fuelService = fuelService;
    }

    [HttpPost("save")]
    public IActionResult saveUser([FromBody]Fuel fuel)
    {
        return Ok(fuelService.save(fuel));
    }

    [HttpGet("findAll")]
    public IActionResult findAll()
    {
        return Ok(fuelService.findAll());
        
    }
    
}