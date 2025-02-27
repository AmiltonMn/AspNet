namespace Server.Source.Services.Product;

using Server.Source.Entities.Orders;
using Server.Source.Models.Product;

public interface IIngredientService
{
    Task<Ingredient> NewIngredient(IngredientData data);

    Task<ICollection<Ingredient>?> GetIngredients();

    Task<Ingredient?> GetIngredientById(Guid id);

    Task<Ingredient?> UpdateIngredient(UpdateIngredientData data, Guid id);

    Boolean DeleteIngredient(Guid id);
}