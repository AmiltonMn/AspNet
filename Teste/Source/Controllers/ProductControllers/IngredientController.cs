namespace Server.Source.Controllers;

using Microsoft.AspNetCore.Mvc;
using Server.Source.Services.Product;
using Server.Source.Models.Product;
using Microsoft.Identity.Client;
using Server.Source.Entities.Orders;
using Azure.Messaging;

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

    [HttpDelete("{id}")]
    public IActionResult DeleteIngredient(Guid id)
    {
        var res = service.DeleteIngredient(id);

        if (!res)
            return NotFound("Could not found this ingredient!");

        return Ok("Ingredient deleted successfully!");
    }

    [HttpGet]
    public async Task<IActionResult> GetIngredients()
    {
        var res = await service.GetIngredients();

        if (res is null)
            return NotFound("It seems that you don't have registered ingredients");

        return Ok(res);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetIngredients(Guid id)
    {
        var res = await service.GetIngredientById(id);

        if (res is null)
            return NotFound("Ingredient not found!");

        return Ok(res);
    }

    [HttpPatch("update/{id}")]
    public async Task<IActionResult> UpdateIngredient([FromBody]UpdateIngredientData data, Guid id)
    {
        var res = await service.UpdateIngredient(data, id);

        if (res is null)
            return NotFound("Ingredient not found!");

        return Ok(res);
    }
}