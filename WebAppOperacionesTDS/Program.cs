 using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebAppOperacionesTDS.Data;
using WebAppOperacionesTDS.Data.DataAccess;
using WebAppOperacionesTDS.Data.Interface;
using static WebAppOperacionesTDS.Data.ApplicationDbContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
builder.Services.AddDefaultIdentity<Usuario>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddAuthorization(
    options =>options.AddPolicy(
        "AllowLayaoutJefe",
        policy => policy.RequireRole("Jefe")
        ));
builder.Services.AddAuthorization(
    options => options.AddPolicy(
        "AllowLayaoutAnalista",
        policy => policy.RequireRole("Analista")
        ));
builder.Services.AddAuthorization(
    options => options.AddPolicy(
        "AllowLayaoutJefeAnalista",
        policy => policy.RequireRole("Jefe", "Analista")
        ));

builder.Services.AddControllersWithViews();

//INYECCIÓN POR DEPENDENCIA
builder.Services.AddSingleton<IDACliente, DACliente>();
builder.Services.AddSingleton<IDALugar, DALugar>();
builder.Services.AddSingleton<IDAServicios, DAServicios>();
builder.Services.AddSingleton<IDAOperacion, DAOperacion>();


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
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(

    name: "WebAppOpe",
    pattern: "WebAppOpe",

    defaults: new { Controller = "Operacion", action = "Index" }

    );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
