using DesignPatterns.Models.Data;
using DesignPatterns.Repository;
using DesignPatterns.Repository.UnitOfWork;
using DesignPatternsASP.Configuration;
using Microsoft.EntityFrameworkCore;
using Tools.Earn;
using Tools.Generator;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.Configure<MyConfig>(builder.Configuration.GetSection("MyConfig"));
builder.Services.AddTransient(factory =>
{
    return new LocalEarnFactory(
        builder.Configuration
            .GetSection("MyConfig")
            .GetValue<decimal>("LocalEarnFactory"));
});
builder.Services.AddTransient(factory =>
{
    return new ForeignEarnFactory(
        builder.Configuration
            .GetSection("MyConfig")
            .GetValue<decimal>("ForeignEarnFactory"),
        builder.Configuration
            .GetSection("MyConfig")
            .GetValue<decimal>("Extra"));
});

builder.Services.AddScoped( typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<Generator>();
builder.Services.AddScoped<GeneratorConcreteBuilder>();

builder.Services.AddDbContext<DesignPatternDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Connection"));
});

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
