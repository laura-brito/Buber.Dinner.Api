using System.Collections.Immutable;
using BuberDinner.Application;
using BuberDinner.Infra;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddApplication();
    builder.Services.AddInfra(builder.Configuration);
    builder.Services.AddControllers();
}

WebApplication app = builder.Build();
{
    app.UseHttpsRedirection();
    app.MapControllers();

    app.Run();
}


