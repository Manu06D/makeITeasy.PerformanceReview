using makeITeasy.PerformanceReview.BlazorServerApp.Modules.Security;
using makeITeasy.PerformanceReview.BlazorServerApp.Modules.Startup;
using makeITeasy.PerformanceReview.Infrastructure.Data;
using makeITeasy.PerformanceReview.Models;

using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using MudBlazor.Services;

using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, config) => config.WriteTo.Console().WriteTo.Debug()) ;

builder.Services.AddOptions();

//register db
var connectionString = builder.Configuration.GetConnectionString("dbConnectionString");;
builder.Services.AddDbContext<PeformanceReviewDbContext>(options => options.UseSqlServer(connectionString));;

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddMudServices();

//Authentification
builder.Services.AddDefaultIdentity<AppUser>(options => 
    { 
        options.User.RequireUniqueEmail = true;
        options.SignIn.RequireConfirmedAccount = false;
        options.SignIn.RequireConfirmedEmail = false;
        options.SignIn.RequireConfirmedPhoneNumber = false;

        if (builder.Environment.IsDevelopment())
        {
            options.Password.RequireDigit = false;
            options.Password.RequiredLength = 1;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = false;
            options.Password.RequireLowercase = false;
        }
    })
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<PeformanceReviewDbContext>()
    .AddClaimsPrincipalFactory<ExtendedUserClaimsPrincipalFactory>()
    ;
;

builder.Services
    .AddScoped<AuthenticationStateProvider, makeITeasy.PerformanceReview.BlazorServerApp.Areas.Identity.RevalidatingIdentityAuthenticationStateProvider<AppUser>>()
    .AddScoped<TokenProvider>();

////MakeItEasy
builder.ConfigureDatabase();
builder.ConfigureAutofac();
    
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
    endpoints.MapRazorPages();
});

app.Run();