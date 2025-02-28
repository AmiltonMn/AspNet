namespace Server.Source.Services.Ingredient;

using Microsoft.EntityFrameworkCore;
using Server.Source.Entities;
using Server.Source.Entities.Orders;
using Server.Source.Models.Ingredient;

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

    public async Task<bool> DeleteIngredient(Guid id)
    {
        var ingredients =
            from ing in ctx.Ingredients
            where ing.Id == id
            select ing;
        
        var ingredient = ingredients.FirstOrDefault();

        if (ingredient is null)
            return false;

        ctx.Remove(ingredient);
        await ctx.SaveChangesAsync();

        return true;
    }

    public async Task<Ingredient?> GetIngredientById(Guid id)
    {
        var ingredients =
            from ing in ctx.Ingredients
            where ing.Id == id
            select ing;
        
        return await ingredients.FirstOrDefaultAsync() switch
        {
            Ingredient ingredient when ingredient is not null => ingredient,
            _ => null
        };
    }

    public async Task<ICollection<Ingredient>?> GetIngredients()
    {
        var getIngredients = 
            from ing in ctx.Ingredients
            select ing;

        return await getIngredients.ToListAsync();
    }

    public async Task<Ingredient?> UpdateIngredient(UpdateIngredientData data, Guid id)
    {
        var ingredients = 
            from ing in ctx.Ingredients
            where ing.Id == id
            select ing;

        var ingredient = await ingredients.FirstOrDefaultAsync();
        
        if (ingredient is null)
            return null;

        ingredient.Value = data.Value is not null ? (float)data.Value : ingredient.Value;
        ingredient.Name = data.Name is not null ? data.Name : ingredient.Name;        

        return ingredient;
    }
}