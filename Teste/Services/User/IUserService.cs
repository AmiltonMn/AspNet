namespace Server.Services.User;

using Server.Entities;
using Server.Models;

public interface IUserService
{
    Task<ApplicationUser> CreateUser(AccountData data);

    Task<ApplicationUser> CreateUser(AccountData data, Guid invitedByUserId);

    Task<ApplicationUser?> Authenticate(LoginData data);
}