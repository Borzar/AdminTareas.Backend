using DBContext.ApplicationDbContext;
using Dto.Output;
using Models.Input;

namespace Repository.IRepository.ITareasRepository;

public interface ITareasRepository
{
    public Task<JsonResponseDto > CrearTarea(Tarea input);
    public JsonResponseDto ConsultarTarea();
    public JsonResponseDto BorrarTarea();
    public JsonResponseDto ActualizarTarea();
}