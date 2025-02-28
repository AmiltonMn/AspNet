namespace Server.Source.Models.Meal;

public record UpdateMealData (
    string? Name,
    float? Value,
    string? Description,
    ICollection<Guid>? Ingredients
);