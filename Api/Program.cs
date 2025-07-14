using Api.DatabaseContext;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<CmsXTicketsContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("postgres_cms")));


var app = builder.Build();

app.MapGet("/", () => "Welcome to the X-Tickets API!");

app.MapControllers();

app.Run();
