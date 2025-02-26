using System.ComponentModel.DataAnnotations;
using Server.Source.Validations;

namespace Server.Source.Models.User;

public record AccountData (
    [MinLength(8)]
    string Name,
    [EmailAddress]
    string Email,
    [Required]
    [MinLength(8)]
    [StrongPassword]
    string Password
);