namespace Server.Source.Controllers;

using Microsoft.AspNetCore.Mvc;
using Server.Source.Services.Product;
using Server.Source.Models.Product;

[Route("/ingredient")]
[ApiController]

public class IngredientController(
    IIngredientService service
) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> NewIngredient([FromBody]IngredientData ingredientData)
    {
        var res = await service.NewIngredient(ingredientData);

        return Ok(res);
    }
}