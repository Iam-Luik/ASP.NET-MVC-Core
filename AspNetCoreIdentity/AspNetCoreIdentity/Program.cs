using AspNetCoreIdentity.Config;
using AspNetCoreIdentity.Extensions;
using IdentityStudy.Config;
using KissLog.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager Configuration = builder.Configuration;

builder.Host.ConfigureAppConfiguration((hostingContext, config) =>
{
    config
    .AddJsonFile("appsettings.json", true, true)
    .AddJsonFile($"appsettings.{hostingContext.HostingEnvironment.EnvironmentName}.json", true, true)
    .AddEnvironmentVariables();

    if (hostingContext.HostingEnvironment.IsProduction())
    {
        config.AddUserSecrets<Program>();
    }
    
});

builder.Services.AddIdentityConfig(Configuration);

builder.Services.AddAuthorizationConfig();

builder.Services.ResolveDependencies();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/erro/500");
    app.UseStatusCodePagesWithRedirects("/erro/{0}");
    app.UseHsts();
}   

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseKissLogMiddleware(options => {
    LogConfig.ConfigureKissLog(options, Configuration);
});

app.UseAuthorization();

app.MapRazorPages();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
