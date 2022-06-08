using MudBlazor.Services;
using Schedule.Core.Interfaces.Data;
using Schedule.Core.Interfaces.Services;
using Schedule.Data.Models;
using Schedule.Services;
using Schedule.Services.Mail;
using Schedule.Services.Pdf;
using AboutConfig = Schedule.Data.Models.About;
using RouteContext = Schedule.Infrastructure.Data.Context.RouteContext;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddMudServices(options =>
{
    options.SnackbarConfiguration.PreventDuplicates = false;
    options.SnackbarConfiguration.MaxDisplayedSnackbars = 5;
});
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<IRouteData, RouteContext>();
builder.Services.AddScoped<INavigation, NavigationService>();
builder.Services.AddScoped<IPdfBuilder, MainDocument>();
builder.Services.AddScoped<IFindRoute, FindRoutes>();
builder.Services.AddScoped<IMailService, MailService>();

builder.Services.Configure<AboutConfig>(builder.Configuration.GetSection(AboutConfig.SectionName));
builder.Services.Configure<Contacts>(builder.Configuration.GetSection(Contacts.SectionName));

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