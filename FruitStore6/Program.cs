using FruitStore6.Models;
using FruitStore6.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<MenuService>();
builder.Services.AddDbContext<fruteriashopContext>(
    optionsBuilder =>
                    optionsBuilder.UseMySql("server=sistemas19.com;password=fruteria6;user=sistem21_fruteria;database=sistem21_fruteriashop", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.27-mysql"))

    );


builder.Services.AddMvc();
var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.UseEndpoints(x =>
{
    x.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
          );
    x.MapDefaultControllerRoute();
}
);



app.Run();
