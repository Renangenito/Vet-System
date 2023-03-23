using VetSystem.Extensoes;
using VetSystem.Negocio.Cliente;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigurarServicos(builder.Configuration);

builder.Services.AddScoped<IClienteNegocio, ClienteNegocio>();

builder.Services.ConfigurarJWT();
builder.Services.ConfigurarSwagger();

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    
}
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
