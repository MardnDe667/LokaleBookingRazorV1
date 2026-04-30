using LokaleBookingRazor.EFDbContext;
using LokaleBookingRazor.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Singleton, transient og dbContext for lokale class
builder.Services.AddSingleton<LokaleService>();
builder.Services.AddTransient<DBLokaleService>();
builder.Services.AddDbContext<LokaleDbContext>();

// Singleton, transient og dbContext for booking class
builder.Services.AddSingleton<BookingService>();
builder.Services.AddTransient<DBBookingService>();
builder.Services.AddDbContext<BookingDbContext>();

// Singleton, transient og dbContext for bruger class
builder.Services.AddSingleton<BrugerService>();
builder.Services.AddTransient<DBBrugerService>();
builder.Services.AddDbContext<BrugerDbContext>();

// cookie login 
builder.Services.Configure<CookiePolicyOptions>(options => {
    // This lambda determines whether user consent for non-essential cookies is needed for a given request. options.CheckConsentNeeded = context => true; 
    options.MinimumSameSitePolicy = SameSiteMode.None;

});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(cookieOptions => {
    cookieOptions.LoginPath = "/Login/LogIn";

});
builder.Services.AddMvc().AddRazorPagesOptions(options => {
    options.Conventions.AuthorizeFolder("/Lokale");

}).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();


app.MapRazorPages();

app.Run();

