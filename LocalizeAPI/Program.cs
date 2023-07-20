using Core.Authentication.Interfaces;
using Core.Repositories.Interfaces;
using Core.Services;
using Core.Services.Interfaces;
using Infrastructure.Authentication;
using Infrastructure.Contexts;
using Infrastructure.Repositories;
using LocalizeAPI.Middlewares;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

ConfigureServices(builder.Services);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.UseMiddleware<ErrorMiddleware>();

app.MapControllers();

app.Run();

void ConfigureServices(IServiceCollection services)
{
    services.AddSingleton<IUserRepository, UserRepository>()
            .AddSingleton<IUserService, UserService>()
            .AddSingleton<UserContext>(serviceProvider => new UserContext())
            .AddSingleton<IAuthenticationService, AuthenticationService>()
            .AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>()
            .AddSingleton<IConsultingService, ConsultingService>()
            .AddSingleton<IConsultingRepository, ConsultingRepository>()
            .AddSingleton<ConsultingContext>(serviceProvider => new ConsultingContext());

    string jwtIssuer = default;
    string jwtAudience = default;
    var jwtSecretKey = "VeryStrongAndVeryLongSecretKey123456";
    var secretBytes = Encoding.UTF8.GetBytes(jwtSecretKey!);

    services
        .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtIssuer,
                ValidAudience = jwtAudience,
                IssuerSigningKey = new SymmetricSecurityKey(secretBytes)
            };
        });
}


