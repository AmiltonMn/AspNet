namespace Server.Source.Models.Drink;

public record UpdateDrinkData (
    string? Name,
    float? Value,
    int? Ml,
    string? Description
);