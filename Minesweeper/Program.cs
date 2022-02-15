using Microsoft.EntityFrameworkCore;
using Minesweeper.DataAccess;
using Minesweeper.DataAccess.Repositories;
using Minesweeper.Services.Services;
using Entities = Minesweeper.DataAccess.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
{
    var services = builder.Services;
    services.AddControllersWithViews();

    string connection = builder.Configuration.GetConnectionString("DefaultConnection");

    services.AddDbContext<DataContext>(
        options => options.UseSqlite(
            connection,
            opt => opt.MigrationsAssembly("Minesweeper.DataAccess")
            )
    );
    services.AddScoped<DbContext, DataContext>();

    services.AddScoped<IRepository<Entities.GameResult, Guid>, GameResultRepositories>();
    services.AddScoped<IGameResultService, GameResultService>();
}

var app = builder.Build();

// Configure the HTTP request pipeline.
{
    if (!app.Environment.IsDevelopment())
    {
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }

    app.UseHttpsRedirection();
    app.UseStaticFiles();
    app.UseRouting();

    app.MapControllers();
    app.MapFallbackToFile("index.html");
}

app.Run();