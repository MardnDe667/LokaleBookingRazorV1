using LokaleBookingRazor.EFDbContext;
using LokaleBookingRazor.Services;
using Microsoft.AspNetCore.Cors.Infrastructure;

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

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
