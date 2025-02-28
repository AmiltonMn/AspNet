namespace Server.Source.Services.Meal;

using Microsoft.EntityFrameworkCore;
using Server.Source.Entities;
using Server.Source.Entities.Orders;
using Server.Source.Models.Meal;

public class EFMealService(
    ParaLancheDbContext ctx
) : IMealService
{

    public async Task<Meal> NewMeal(MealData data)
    {
        var Meal = new Meal {
            Name = data.Name,
            Value = data.Value,
            Ingredients = data.Ingredients,
            Description = data.Description,
        };

        ctx.Add(Meal);
        await ctx.SaveChangesAsync();

        return Meal;
    }

    public async Task<Boolean> DeleteMeal(Guid id)
    {
        var findMeal = 
            from meals in ctx.Meals
            where meals.Id == id
            select meals;

        var meal = findMeal.FirstOrDefault();

        if (meal is null)
            return false;

        ctx.Remove(meal);
        await ctx.SaveChangesAsync();

        return true;
    }

    public async Task<Meal?> GetMealById(Guid id)
    {
        var findMeals =
            from meals in ctx.Meals
            where meals.Id == id
            select meals;
        
        return await findMeals.FirstOrDefaultAsync() switch
        {
            Meal meal when meal is not null => meal,
            _ => null
        };
    }

    public async Task<ICollection<Meal>> GetMeals()
    {
        var getMeals = 
            from meals in ctx.Meals
            select meals;

        return await getMeals.ToListAsync();
    }

    public async Task<Meal?> UpdateMeal(UpdateMealData data, Guid id)
    {
        var findMeals =
            from meals in ctx.Meals
            where meals.Id == id
            select meals;

        var meal = await findMeals.FirstOrDefaultAsync();

        if (meal is null)
            return null;

        meal.Name = data.Name is not null ? data.Name : meal.Name;
        meal.Value = data.Value is not null ? (float)data.Value : meal.Value;
        meal.Description = data.Description is not null ? data.Description : meal.Description;
        meal.Ingredients = data.Ingredients is not null ? data.Ingredients : meal.Ingredients;

        return meal;
    }
}