namespace Server.Source.Entities.Orders;

public class Drink
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public required string Name { get; set; }

    public required float Value { get; set; }

    public required int Ml { get; set; }

    public string? Description { get; set; }

    public int Rating { get; set; } = 0;
}