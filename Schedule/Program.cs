using MudBlazor.Services;
using Schedule;
using Schedule.Data;
using Schedule.Data.Models;
using Schedule.Services.Js;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddMudServices();
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<BrowserService>();
builder.Services.AddSingleton<RouteManager>();
builder.Services.Configure<Contacts>(builder.Configuration.GetSection(Contacts.BlockName));
builder.Services.Configure<About>(builder.Configuration.GetSection(About.BlockName));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();