using EcommerseBlazor.Components;
using EcommerseBlazor.Data;
using EcommerseBlazor.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Register BeatSore db context
builder.Services.AddDbContext<BeatStoreDbContext>( options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//Register Beat service
builder.Services.AddScoped<IBeatService, BeatService>();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
