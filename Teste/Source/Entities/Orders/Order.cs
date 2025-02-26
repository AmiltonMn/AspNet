namespace Server.Source.Entities.Orders;

public class Order
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public Meal? OrderedMeal { get; set; }

    public Drink? OrderedDrink { get; set;}

    public ICollection<Ingredient>? Additional { get; set; }

    public ICollection<Ingredient>? RemovedIngredients { get; set; }

    public float Value { get; set; }
}