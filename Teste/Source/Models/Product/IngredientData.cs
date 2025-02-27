using System.ComponentModel.DataAnnotations;

namespace Server.Source.Models.Product;

public record IngredientData (
    [Required]
    string Name,
    [Required]
    float Value
);