using Hedgehogs.Data.Abstract;
using Hedgehogs.Data;
using Hedgehogs.DataEF;
using Hedgehogs.Persistance.Context;
using Hedgehogs.Services.Abstract;
using Hedgehogs.Services.Implementations;
using Microsoft.EntityFrameworkCore;
using Hedgehogs.DataEF.Implementations;
using Hedgehogs.MVC.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IHedgehogService, HedgehogService>();

builder.Services.AddScoped<IHedgehogRepository, HedgehogRepository>();
builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));


builder.Services.AddDbContext<HedgehogsContext>(opts => opts.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("Hedgehogs.MVC")));
builder.Services.AddScoped<DbContext, HedgehogsContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Hedgehog}/{action=Index}/{id?}");

app.UseMiddleware<EnglishCulture>();
using (var serviceScope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
{
    serviceScope.ServiceProvider.GetService<HedgehogsContext>().Database.Migrate();
}

app.Run();
