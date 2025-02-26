using System.ComponentModel.DataAnnotations;

namespace Server.Source.Models.User;

public record LoginData (
    [Required]
    string Login,
    [Required]
    [MinLength(8)]
    string Password
);