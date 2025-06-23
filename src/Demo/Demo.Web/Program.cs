using Autofac;
using Autofac.Extensions.DependencyInjection;
using Demo;
using Demo.Application.Features.Books.Commands;
using Demo.Data;
using Demo.Domain;
using Demo.Infrastructure;
using Demo.Infrastructure.Extensions;
using Demo.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.FlowAnalysis;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;
using System.Reflection;

//Bootstrap Logger
var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

Log.Logger = new LoggerConfiguration()
             .ReadFrom.Configuration(configuration)
             .CreateBootstrapLogger();
try
{
    Log.Information("Application starting...");
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
    var migrationAssembly = Assembly.GetExecutingAssembly();
    #region Autofac Configuration
    builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
    builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
    {
        containerBuilder.RegisterModule(new WebModule(connectionString, migrationAssembly.FullName));
    });
    #endregion

    #region Service Colleciton Dependency Injection Configuration with single class and single/multiple interfaces
    builder.Services.AddScoped<IItem, Item>();
    #endregion 

    #region Service Colleciton Dependency Injection Configuration with multiple class
    builder.Services.AddKeyedScoped<IProduct, Product1>("Product1");
    builder.Services.AddKeyedScoped<IProduct, Product2>("Product2");
    #endregion

    #region Serilog Configuration   
    builder.Host.UseSerilog((context, lc) => lc
        .MinimumLevel.Debug()
        .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
        .Enrich.FromLogContext()
        .ReadFrom.Configuration(builder.Configuration)

    );
    #endregion

    #region MediatR Configuration
    builder.Services.AddMediatR(cfg =>
    {
        cfg.RegisterServicesFromAssembly(migrationAssembly);
        cfg.RegisterServicesFromAssembly(typeof(BookAddCommand).Assembly);
    });
    #endregion

    #region Docker IP correction
    builder.WebHost.UseUrls("http://*:80");
    #endregion

    #region Identity configuration
    builder.Services.AddIdentity();
    #endregion

    #region Automapper Configuration
    builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    #endregion

    #region Authorization Policy Configuration
    builder.Services.AddPolicy();
    #endregion

    builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(connectionString, (x) => x.MigrationsAssembly(migrationAssembly)));
    builder.Services.AddDatabaseDeveloperPageExceptionFilter();

    builder.Services.AddRazorPages();
    builder.Services.AddControllersWithViews();

    builder.Services.Configure<SmtpSettings>(builder.Configuration.GetSection("SmtpSettings"));
    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseMigrationsEndPoint();
    }
    else
    {
        app.UseExceptionHandler("/Home/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }

    app.UseHttpsRedirection();
    app.UseRouting();

    app.UseAuthentication();
    app.UseAuthorization();

    app.MapStaticAssets();

    app.MapControllerRoute(
        name: "areas",
        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}")
        .WithStaticAssets();

    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}")
        .WithStaticAssets();

    app.MapRazorPages()
       .WithStaticAssets();

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application crashed!...");
}
finally
{
    Log.CloseAndFlush();
}
