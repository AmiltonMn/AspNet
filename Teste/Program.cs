using Microsoft.EntityFrameworkCore;

using Server.Source.Configuration;
using Server.Source.Entities;
using Server.Source.Services.Password;
using Server.Source.Services.Product;
using Server.Source.Services.Token;
using Server.Source.Services.User;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddJwtAuthentication(builder.Configuration)
    .AddDbContext<ParaLancheDbContext>(options =>
        options.UseSqlServer(
            builder.Configuration.GetConnectionString("DefaultConnection")
        )
    );

builder.Services.AddControllers();
builder.Services.AddAuthorization();

builder.Services
    .AddSingleton(builder.Configuration)
    .AddSingleton<IPasswordService, PBKDF2PasswordService>()
    .AddSingleton<ITokenService, JWTService>()
    .AddScoped<IIngredientService, EFIngredientService>()
    .AddScoped<IUserService, EFUserService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();
app.UseHttpsRedirection();

app.Run();