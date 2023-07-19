using Core.Repositories.Interfaces;
using Core.Services;
using Core.Services.Interfaces;
using Infrastructure.Contexts;
using Infrastructure.Repositories;
using LocalizeAPI.Middlewares;

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

app.UseAuthorization();

app.UseMiddleware<ErrorMiddleware>();

app.MapControllers();

app.Run();

void ConfigureServices(IServiceCollection services)
{
    services.AddSingleton<IUserRepository, UserRepository>()
            .AddSingleton<IUserService, UserService>()
            .AddSingleton<UserContext>(serviceProvider => new UserContext());
}

