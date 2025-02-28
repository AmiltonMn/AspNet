namespace Server.Source.Controllers.ProductControllers;

using Microsoft.AspNetCore.Mvc;
using Server.Source.Models.Drink;
using Server.Source.Services.Drink;

[Route("/drink")]
[ApiController]

public class DrinkController(
    IDrinkService service
) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> NewDrink([FromBody]DrinkData drinkData)
    {
        var res = await service.NewDrink(drinkData);

        return Ok(res);
    }
}