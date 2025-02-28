using System.ComponentModel.DataAnnotations;

namespace Server.Source.Models.Drink;

public record DrinkData (
    [Required]
    string Name,
    [Required]
    float Value,
    [Required]
    int Ml,
    string Description
);