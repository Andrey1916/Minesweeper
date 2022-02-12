using Microsoft.EntityFrameworkCore;
using Minesweeper.DataAccess;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
{
    builder.Services.AddControllersWithViews();

    string connection = builder.Configuration.GetConnectionString("DefaultConnection");
    builder.Services.AddDbContext<DataContext>(
        options => options.UseSqlServer(connection)
    );
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