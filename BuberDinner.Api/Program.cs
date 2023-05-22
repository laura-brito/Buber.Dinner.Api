WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

WebApplication app = builder.Build();

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
