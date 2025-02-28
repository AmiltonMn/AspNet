namespace Server.Source.Services.Meal;

using Server.Source.Entities.Orders;
using Server.Source.Models.Meal;

public interface IMealService
{
    Task<Meal> NewMeal(MealData data);

    Task<Boolean> DeleteMeal(Guid id);

    Task<ICollection<Meal>> GetMeals();

    Task<Meal?> GetMealById(Guid id);

    Task<Meal?> UpdateMeal(UpdateMealData data, Guid id);

}