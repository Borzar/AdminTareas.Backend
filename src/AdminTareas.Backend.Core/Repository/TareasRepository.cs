using DBContext.ApplicationDbContext;
using Dto.Input;
using Dto.Output;
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

    public JsonResponseDto ActualizarTarea()
    {
        throw new NotImplementedException();
    }

    public JsonResponseDto BorrarTarea()
    {
        throw new NotImplementedException();
    }

    public JsonResponseDto ConsultarTarea()
    {
        throw new NotImplementedException();
    }

}