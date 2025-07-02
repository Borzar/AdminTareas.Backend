using AutoMapper;
using Dto.Input;
using MediatR;
using Models.Input;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var configuration = new MapperConfiguration(cfg => 
{
    cfg.CreateMap<InputCrearTarea, InputCrearTareaDto>();
});

// Registrar MediatR 
builder.Services.AddMediatR(typeof(InputCrearTarea).Assembly);

// Registros inyeccion de dependencias
// builder.Services.AddScoped<IUsuarioService, UsuarioService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
