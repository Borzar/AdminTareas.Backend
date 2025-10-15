using DBContext.ApplicationDbContext;
using Dto.Output;
using Models.Input;

namespace Repository.IRepository.ITareasRepository;

public interface ITareasRepository
{
    public Task<JsonResponseDto> CrearTarea(Tarea input);
    public Task<JsonResponseDto> ActualizarTarea(Tarea input);
    public Task<JsonResponseDto> BorrarTarea(InputBorrarTarea input);
    public Task<JsonResponseDto> ConsultarTarea(InputConsultarTarea input);
}