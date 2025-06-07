using gs_tria_2025.Connection;
using gs_tria_2025.Repository;
using gs_tria_2025.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
   options.UseOracle(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<EnderecoRepository>();
builder.Services.AddScoped<EnderecoService>();

builder.Services.AddScoped<UsuarioRepository>();
builder.Services.AddScoped<UsuarioService>();

builder.Services.AddScoped<ItemRepository>();
builder.Services.AddScoped<ItemService>();

builder.Services.AddScoped<EstoqueItemRepository>();
builder.Services.AddScoped<EstoqueItemService>();

builder.Services.AddScoped<PontoDistribuicaoRepository>();
builder.Services.AddScoped<PontoDistribuicaoService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
