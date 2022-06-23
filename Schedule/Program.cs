using MudBlazor.Services;
using Schedule.Core.Data.Models.Config;
using Schedule.Core.Interfaces.Data;
using Schedule.Core.Interfaces.Services;
using Schedule.Core.Services;
using Schedule.Core.Services.Mail;
using Schedule.Core.Services.Pdf;
using Schedule.Infrastructure.Data;
using AboutConfig = Schedule.Core.Data.Models.Config.About;
using RouteContext = Schedule.Infrastructure.Data.Context.RouteContext;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddMudServices(options =>
{
    options.SnackbarConfiguration.PreventDuplicates = false;
    options.SnackbarConfiguration.MaxDisplayedSnackbars = 5;
});
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<IRouteData, DriveContext>();
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