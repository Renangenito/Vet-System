using VetSystem.Comum.Modelo;
using VetSystem.Comum.Servico;
using VetSystem.Extensoes;
using VetSystem.Models.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IApiToken, ApiToken>();


builder.Services.Configure<DadosBase>(builder.Configuration.GetSection("DadosBase"));
builder.Services.AddSingleton<LoginRespostaModel>(); //Design patern singleton, instancia um unico objeto uma unica vez

builder.Services.AddHttpClient();

// Add services to the container.
builder.Services.AddControllersWithViews();

//--
builder.Services.ConfigurarCookiePolicy();
builder.Services.ConfigurarAuthentication();
//--


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

//--
app.UseCookiePolicy();
app.UseAuthentication();
//--

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
