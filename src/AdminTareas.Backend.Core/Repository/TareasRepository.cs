using System.Runtime.InteropServices;
using DBContext.ApplicationDbContext;
using Dto.Input;
using Dto.Output;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Models.Input;
using Repository.IRepository.ITareasRepository;

namespace Repository.TareasRepository;

public class TareasRepository : ITareasRepository
{
    private readonly ApplicationDbContext _context;

    public TareasRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<JsonResponseDto> CrearTarea(Tarea input)
    {
        await _context.Tareas.AddAsync(input);
        await _context.SaveChangesAsync();
        return new JsonResponseDto { EstadoDto = "Ok", DescripcionDto = "Creación exitosa" };
    }

    public async Task<JsonResponseDto> ActualizarTarea(Tarea input)
    {
        var tareaOriginal = await _context.Tareas.FindAsync(input.Id);

        if (tareaOriginal == null)
        {
            return new JsonResponseDto { EstadoDto = "Fallido", DescripcionDto = $"La tarea con el ID {input.Id} no existe" };
        }

        if (!string.IsNullOrWhiteSpace(input.Titulo))
        tareaOriginal.Titulo = input.Titulo.Trim();

        if (!string.IsNullOrWhiteSpace(input.Descripcion))
        tareaOriginal.Descripcion = input.Descripcion.Trim();

        await _context.SaveChangesAsync();

        return new JsonResponseDto { EstadoDto = "Ok", DescripcionDto = "Actualización exitosa" };
    }

    public async Task<JsonResponseDto> BorrarTarea(InputBorrarTarea input)
    {
        var tareaOriginal = await _context.Tareas.FindAsync(input.Id);

        if (tareaOriginal == null)
        {
            return new JsonResponseDto { EstadoDto = "Fallido", DescripcionDto = $"La tarea con el ID {input.Id} no existe" };
        }
      
        _context.Tareas.Remove(tareaOriginal);

        await _context.SaveChangesAsync();

        return new JsonResponseDto { EstadoDto = "Ok", DescripcionDto = "Borrado exitoso" };
    }

    public async Task<JsonResponseDto> ConsultarTarea(InputConsultarTarea input)
    {
        var tareaOriginal = await _context.Tareas.FindAsync(input.Id);

        if (tareaOriginal == null)
        {
            return new JsonResponseDto { EstadoDto = "Fallido", DescripcionDto = $"La tarea con el ID {input.Id} no existe" };
        }
      
        var tareaDto = new TareasOutputDto
        {
            IdDto = tareaOriginal.Id,
            TituloDto = tareaOriginal.Titulo,
            DescripcionDto = tareaOriginal.Descripcion
        };

        return new JsonResponseDto { EstadoDto = "Ok", DescripcionDto = "Consulta exitosa", MisTareas =  new List<TareasOutputDto> { tareaDto }};
    }


}