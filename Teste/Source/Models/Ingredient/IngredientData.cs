namespace Server.Source.Models.Ingredient;

using System.ComponentModel.DataAnnotations;

public record IngredientData (
    [Required]
    string Name,
    [Required]
    float Value
);