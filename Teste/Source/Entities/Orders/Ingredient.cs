namespace Server.Source.Entities.Orders;

public class Ingredient
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public required string Name { get; set; }

    public required float Value { get; set; } 
}