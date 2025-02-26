namespace Server.Source.Services.Product;

using Server.Source.Entities.Orders;
using Server.Source.Models.Product;

public interface IIngredientService
{
    Task<Ingredient> NewIngredient(IngredientData data);

    Task<Ingredient> GetIngredients();

    Task<Ingredient> GetIngredientById(Guid id);

    Task<Ingredient> UpdateIngredient(Guid id);

    Task<Ingredient> DeleteIngredient(Guid id);
}