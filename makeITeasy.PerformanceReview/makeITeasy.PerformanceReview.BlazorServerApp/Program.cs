using makeITeasy.PerformanceReview.BlazorServerApp.Modules.Startup;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;

using MudBlazor.Services;
using Microsoft.EntityFrameworkCore;
using makeITeasy.PerformanceReview.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("dbConnectionString");;
builder.Services.AddOptions();

builder.Services.AddDbContext<PeformanceReviewDbContext>(options => options.UseSqlServer(connectionString));;

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddMudServices();

//Authentification
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false).AddRoles<IdentityRole>().AddEntityFrameworkStores<PeformanceReviewDbContext>();
builder.Services.AddScoped<AuthenticationStateProvider, makeITeasy.PerformanceReview.BlazorServerApp.Areas.Identity.RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();

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