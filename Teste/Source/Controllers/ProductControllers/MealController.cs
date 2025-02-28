namespace Server.Source.Controllers.ProductControllers;

using Microsoft.AspNetCore.Mvc;
using Server.Source.Models.Meal;
using Server.Source.Services.Meal;

[Route("/meal")]
[ApiController]

public class MealController ( 
    IMealService service
): ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> NewMeal([FromBody]MealData mealData)
    {
        var res = await service.NewMeal(mealData);

        return Ok(res);
    }

    [HttpDelete("/{id}")]
    public async Task<IActionResult> DeleteMeal(Guid id)
    {
        var res = await service.DeleteMeal(id);

        if (!res)
            return NotFound("The meal wasn't found");

        return Ok(res);
    }

    [HttpGet]
    public async Task<IActionResult> GetMeals()
    {
        var res = await service.GetMeals();

        if (res is null)
            return NotFound("Could not find any meal!");

        return Ok(res);
    }

    [HttpGet("/{id}")]
    public async Task<IActionResult> GetMealById(Guid id)
    {
        var res = await service.GetMealById(id);

        if (res is null)
            return NotFound("Meal not found!");

        return Ok(res);
    }

    [HttpPatch("/{id}")]
    public async Task<IActionResult> UpdateMeal([FromBody]UpdateMealData data, Guid id)
    {
        var res = await service.UpdateMeal(data, id);

        if (res is null)
            return NotFound("Meal not found!");

        return Ok(res);
    }
}