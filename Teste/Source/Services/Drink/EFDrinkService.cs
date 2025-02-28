namespace Server.Source.Services.Drink;

using Entities;
using Entities.Orders;
using Microsoft.EntityFrameworkCore;
using Models.Drink;

public class EFDrinkService(
    ParaLancheDbContext ctx
) : IDrinkService
{

    public async Task<Drink> NewDrink(DrinkData data)
    {
        var drink = new Drink {
            Name = data.Name,
            Value = data.Value,
            Ml = data.Ml,
        };

        ctx.Add(drink);
        await ctx.SaveChangesAsync();

        return drink;
    }

    public async Task<bool> DeleteDrink(Guid id)
    {
        var findDrinks =
            from drinks in ctx.Drinks
            where drinks.Id == id
            select drinks;
        
        var drink = findDrinks.FirstOrDefault();

        if (drink is null)
            return false;

        ctx.Remove(drink);
        await ctx.SaveChangesAsync();

        return true;
    }

    public async Task<Drink?> GetDrinkById(Guid id)
    {
        var findDrinks =
            from drinks in ctx.Drinks
            where drinks.Id == id
            select drinks;

        return await findDrinks.FirstOrDefaultAsync() switch 
        {
            Drink drink when drink is not null => drink,
            _ => null
        };
    }

    public async Task<ICollection<Drink>> GetDrinks()
    {
        var getDrinks = 
            from drinks in ctx.Drinks
            select drinks;

        return await getDrinks.ToListAsync();
    }

    public async Task<Drink?> UpdateDrink(UpdateDrinkData data, Guid id)
    {
        var getDrinks = 
            from drinks in ctx.Drinks
            where drinks.Id == id
            select drinks;

        var drink = await getDrinks.FirstOrDefaultAsync();

        if (drink is null)
            return null;

        drink.Name = data.Name is not null ? data.Name : drink.Name;
        drink.Value = data.Value is not null ? (float)data.Value : drink.Value;
        drink.Description = data.Description is not null ? data.Description : drink.Description;
        drink.Ml = data.Ml is not null ? (int)data.Ml : drink.Ml;

        return drink;
    }
}