using Server.Source.Entities;
using Server.Source.Entities.Orders;
using Server.Source.Models.Product;

namespace Server.Source.Services.Product;

public class EFIngredientService(
    ParaLancheDbContext ctx
) : IIngredientService
{
    public async Task<Ingredient> NewIngredient(IngredientData data)
    {
        var ingredient = new Ingredient {
            Name = data.Name,
            Value = data.Value
        };

        ctx.Add(ingredient);
        await ctx.SaveChangesAsync();

        return ingredient;
    }

    public Task<Ingredient> DeleteIngredient(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Ingredient> GetIngredientById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Ingredient> GetIngredients()
    {
        throw new NotImplementedException();
    }


    public Task<Ingredient> UpdateIngredient(Guid id)
    {
        throw new NotImplementedException();
    }
}