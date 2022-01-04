using DevIO.UI.AppModelo.Data;
using DevIO.UI.AppModelo.Servicos;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.Configure<RazorViewEngineOptions>(options =>
{
    options.AreaPageViewLocationFormats.Clear();
    options.AreaPageViewLocationFormats.Add("/Modulos/{2}/Views/{1}/{0}.cshtml");
    options.AreaPageViewLocationFormats.Add("/Modulos/{2}/Views/Shared/{0}.cshtml");
    options.AreaPageViewLocationFormats.Add("/Views/Shared/{0}.cshtml");

});


builder.Services.AddTransient<IPedidoRepository, PedidoRepository>();

//builder.Services.AddTransient<IOperacaoTransient, Operacao>();
//builder.Services.AddScoped<IOperacaoScoped, Operacao>();
//builder.Services.AddSingleton<IOperacaoSingleton, Operacao>();
//builder.Services.AddSingleton<IOperacaoSingletonInstance>(new Operacao(Guid.Empty));
//builder.Services.AddTransient<OperacaoService>();


var app = builder.Build();
IConfiguration configuration = app.Configuration;
IWebHostEnvironment environment = app.Environment;
builder.Services.AddDbContext<MeuDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("MeuDbContext")));




if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapAreaControllerRoute("AreaProdutos", "Produtos", "Produtos/{controller=Cadastro}/{action=Index}/{id?}");
app.MapAreaControllerRoute("AreaVendas", "Vendas", "Vendas/{controller=Pedidos}/{action=Index}/{id?}");

app.Run();


