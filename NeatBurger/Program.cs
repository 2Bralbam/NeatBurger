using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using NeatBurger.Models.Entities;
using NeatBurger.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc();
builder.Services.AddTransient<GenericRepository<Menu>>();
builder.Services.AddDbContext<NeatContext>(
    optionsBuilder => optionsBuilder.UseMySql("server=localhost;user=root;password=root;database=neat", 
    Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.30-mysql"))
);
var app = builder.Build();

app.UseStaticFiles();
app.MapDefaultControllerRoute();
app.UseHttpsRedirection();
app.Run();
