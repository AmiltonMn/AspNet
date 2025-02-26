namespace Server.Source.Services.User;

using Models.User;
using Entities;

using Services.Password;

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
         var user = new ApplicationUser {
            Email = data.Email,
            Name = data.Name,
            PasswordHash = hasher.Hash(data.Password),
            InvitedByUserId = invitedByUserId
        };

        ctx.Add(user);
        await ctx.SaveChangesAsync();

        return user;
    }
}