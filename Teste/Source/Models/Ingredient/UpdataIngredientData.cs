namespace Server.Source.Models.Ingredient;

public record UpdateIngredientData (
    string? Name,
    float? Value
);