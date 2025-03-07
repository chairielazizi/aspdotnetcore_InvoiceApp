using InvoiceApp.Services;
using Microsoft.EntityFrameworkCore;
using InvoiceApp.Data;
using Microsoft.AspNetCore.Identity;
using InvoiceApp.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddRazorPages();

// Add user secrets in development environment
if (builder.Environment.IsDevelopment())
{
    builder.Configuration.AddUserSecrets<Program>();
}

builder.Services.AddDbContext<ApplicationDbContext>(options => {
    var connectionString = builder.Configuration.GetConnectionString("PGConnection");
    //options.UseSqlServer(connectionString);
    options.UseNpgsql(connectionString, npgsqlOptions => npgsqlOptions.CommandTimeout(180));
});

builder.Services.AddDbContext<AuthDbContext>(options => {
    var connectionString = builder.Configuration.GetConnectionString("PGConnection");
    //options.UseSqlServer(connectionString);
    options.UseNpgsql(connectionString, npgsqlOptions => npgsqlOptions.CommandTimeout(180));
});

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<AuthDbContext>();

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

app.MapRazorPages();

app.Run();
