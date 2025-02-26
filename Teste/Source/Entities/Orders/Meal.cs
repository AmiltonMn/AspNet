namespace Server.Source.Entities.Orders;

public class Meal
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public required string Name { get; set; }

    public required float Value { get; set; }

    public required ICollection<Ingredient> Ingredients { get; set; }

    public ICollection<Ingredient>? Additional { get; set; }

    public string? Description { get; set; }

    public float Rating { get; set; } = 0;
}