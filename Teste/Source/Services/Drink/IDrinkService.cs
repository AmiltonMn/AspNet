namespace Server.Source.Services.Drink;

using Server.Source.Entities.Orders;
using Server.Source.Models.Drink;

public interface IDrinkService
{
    Task<Drink> NewDrink(DrinkData data);

    Task<ICollection<Drink>> GetDrinks();

    Task<Drink?> GetDrinkById(Guid id);

    Task<Drink?> UpdateDrink(UpdateDrinkData data, Guid id);

    Task<Boolean> DeleteDrink(Guid id);
}