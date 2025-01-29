using EcommerseBlazor;
using EcommerseBlazor.Components;
using EcommerseBlazor.Data;
using EcommerseBlazor.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Register BeatStore DbContext
builder.Services.AddDbContext<BeatStoreDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register Beat service
builder.Services.AddScoped<IBeatService, BeatService>();
// Register root path service
builder.Services.AddScoped<RootPathService>();

// Add logging to the container (this ensures ILogger is available)
builder.Services.AddLogging(logging =>
{
    logging.ClearProviders(); // Optional: clears other log providers if needed
    logging.AddConsole();     // Add Console logging provider (you can add other providers as needed)
});

// Add services to the container
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

// Set up Razor components for interactive server rendering
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
