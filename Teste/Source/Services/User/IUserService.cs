namespace Server.Source.Services.User;

using Server.Source.Entities;
using Models.User;

public interface IUserService
{
    Task<ApplicationUser> CreateUser(AccountData data);

    Task<ApplicationUser> CreateUser(AccountData data, Guid invitedByUserId);

    Task<ApplicationUser?> Authenticate(LoginData data);
}