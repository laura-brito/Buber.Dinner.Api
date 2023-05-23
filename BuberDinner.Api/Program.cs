using BuberDinner.Application.Services.Authentication;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();

WebApplication app = builder.Build();

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
