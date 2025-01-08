using ServiceCollections.Models;

var builder = WebApplication.CreateBuilder(args);

#region Service Collection Dependency Injection Configuration with single class

//------Cannot use multiple service with same combination of interface and class---------------

/*builder.Services.AddSingleton<IItem, Item>();
builder.Services.AddTransient<IItem, Item>();
*/

builder.Services.AddScoped<IItem, Item>();
#endregion
#region Service Colleciton Dependency Injection Configuration with multiple class
builder.Services.AddKeyedScoped<IProduct, Product1>("Product1");
builder.Services.AddKeyedScoped<IProduct, Product2>("Product2");
#endregion
// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
