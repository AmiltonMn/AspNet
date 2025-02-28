namespace Server.Source.Services.Ingredient;

using Server.Source.Entities.Orders;
using Server.Source.Models.Ingredient;

public interface IIngredientService
{
    Task<Ingredient> NewIngredient(IngredientData data);

    Task<ICollection<Ingredient>?> GetIngredients();

    Task<Ingredient?> GetIngredientById(Guid id);

    Task<Ingredient?> UpdateIngredient(UpdateIngredientData data, Guid id);

    Task<bool> DeleteIngredient(Guid id);
}