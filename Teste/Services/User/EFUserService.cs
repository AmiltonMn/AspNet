namespace Server.Services.User;

using Models;
using Entities;
using Server.Services.Password;
using Microsoft.EntityFrameworkCore;

public class EFUserService(
    ParaLancheDbContext ctx,
    IPasswordService hasher
) : IUserService
{
    public async Task<ApplicationUser?> Authenticate(LoginData data)
    {
        var users =
            from user in ctx.Users
            where user.Name == data.Login || user.Email == data.Login
            select user;

        var findeuser = users.FirstOrDefault();

        return await users.FirstOrDefaultAsync() switch 
        {
            ApplicationUser user when hasher.Verify(data.Password, user.PasswordHash) => user, 
            _ => null
        };
    }

    public async Task<ApplicationUser> CreateUser(AccountData data)
    {
        var user = new ApplicationUser {
            Email = data.Email,
            Name = data.Name,
            PasswordHash = hasher.Hash(data.Password)
        };

        ctx.Add(user);
        await ctx.SaveChangesAsync();

        return user;
    }

    public async Task<ApplicationUser> CreateUser(AccountData data, Guid invitedByUserId)
    {
        return null;
    }
}