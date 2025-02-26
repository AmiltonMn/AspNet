using Server.Source.Entities.Orders;

namespace Server.Source.Entities;

public class Review
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public required ApplicationUser User { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public Meal? Meal { get; set; }

    public Drink? Drink { get; set; }

    public required int Rating { get; set; }
}