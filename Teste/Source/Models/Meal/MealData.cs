namespace Server.Source.Models.Meal;

using System.ComponentModel.DataAnnotations;

public record MealData (
    [Required]
    string Name,
    [Required]
    float Value,
    [MinLength(1)]
    ICollection<Guid> Ingredients,
    string? Description
);