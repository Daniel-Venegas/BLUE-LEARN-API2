using APIBlueLearn.Context;
using APIBlueLearn.Repositories;
using APIBlueLearn.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var conString = builder.Configuration.GetConnectionString("connection");
builder.Services.AddDbContext<BLDbContext>(options => options.UseSqlServer(conString));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add repositories
#region Repositories
builder.Services.AddScoped<IAgricultoresRepository, AgricultoresRepository>();
builder.Services.AddScoped<ICamposRepository, CampoRepository>();
builder.Services.AddScoped<ICosechasRepository, CosechasRepository>();
builder.Services.AddScoped<ICultivosRepository, CultivosRepository>();
builder.Services.AddScoped<IDescripcionMonitoreoRepository, DescripcionMonitoreoRepository>();
builder.Services.AddScoped<IEstadoCultivoRepository, EstadoCultivoRepository>();
builder.Services.AddScoped<IEstadoOperacionRepository, EstadoOperacionRepository>();
builder.Services.AddScoped<IEtapaAprendizajeRepository, EtapaAprendizajeRepository>();
builder.Services.AddScoped<IEtapaRepository, EtapaRepository>();
builder.Services.AddScoped<IJugadorRepository, JugadorRepository>();
builder.Services.AddScoped<ILogroRepository, LogroRepository>();
builder.Services.AddScoped<IMonitoreoRepository, MonitoreoRepository>();
builder.Services.AddScoped<IOperacionesCultivoRepository, OperacionesCultivoRepository>();
builder.Services.AddScoped<IPartidaRepository, PartidaRepository>();
builder.Services.AddScoped<ITemporadasRepository, TemporadasRepository>();

#endregion

//Add Services
#region Services
builder.Services.AddScoped<IAgricultoresService, AgricultoresService>();
builder.Services.AddScoped<ICampoService, CampoService>();
builder.Services.AddScoped<ICosechasService, CosechasService>();
builder.Services.AddScoped<ICultivosService, CultivosService>();
builder.Services.AddScoped<IDescripcionMonitoreoService, DescripcionMonitoreoService>();
builder.Services.AddScoped<IEstadoCultivoService, EstadoCultivoService>();
builder.Services.AddScoped<IEstadoOperacionService, EstadoOperacionService>();
builder.Services.AddScoped<IEtapaAprendizajeService, EtapaAprendizajeService>();
builder.Services.AddScoped<IEtapaService, EtapaService>();
builder.Services.AddScoped<IJugadorService, JugadorService>();
builder.Services.AddScoped<ILogroService, LogroService>();
builder.Services.AddScoped<IMonitoreoService, MonitoreoService>();
builder.Services.AddScoped<IOperacionesCultivoService, OperacionesCultivoService>();
builder.Services.AddScoped<IPartidaService, PartidaService>();
builder.Services.AddScoped<ITemporadaService, TemporadaService>();

#endregion
//builder.Services.AddScoped<EstadoCultivoRepository>();
//builder.Services.AddScoped<EstadoCultivoService>();

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