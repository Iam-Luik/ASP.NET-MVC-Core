using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using AspNetCoreIdentity.Areas.Identity.Data;
using AspNetCoreIdentity.Extensions;
using Microsoft.AspNetCore.Authorization;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("AspNetCoreIdentityContextConnection");
builder.Services.AddDbContext<AspNetCoreIdentityContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddRoles<IdentityRole>().AddDefaultUI().AddEntityFrameworkStores<AspNetCoreIdentityContext>();
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("PodeExcluir", policy => policy.RequireClaim("PodeExcluir"));
    options.AddPolicy("PodeLer", policy => policy.Requirements.Add(new PermissaoNecessaria("PodeLer")));
    options.AddPolicy("PodeEscrever", policy => policy.Requirements.Add(new PermissaoNecessaria("PodeEscrever")));
});

builder.Services.AddSingleton<IAuthorizationHandler, PermissaoNecessariaHandler>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();