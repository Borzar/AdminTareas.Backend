using AutoMapper;
using DBContext.ApplicationDbContext;
using Dto.Input;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Models.Input;
using Repository.IRepository.ITareasRepository;
using Repository.TareasRepository;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.

var configuration = new MapperConfiguration(cfg => 
{
    cfg.CreateMap<InputCrearTarea, InputCrearTareaDto>();
});

// Services
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssemblies(
        typeof(Program).Assembly,
        typeof(InputCrearTareaBO).Assembly
    )
);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
);

builder.Services.AddScoped<ITareasRepository, TareasRepository>();

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
