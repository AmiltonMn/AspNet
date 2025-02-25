using System.ComponentModel.DataAnnotations;
using Server.Validations;

namespace Server.Models;

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