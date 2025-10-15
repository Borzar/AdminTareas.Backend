using DBContext.ApplicationDbContext;
using Dto.Output;
using MediatR;
using Models.Input;
using Models.Output;
using Repository.IRepository.ITareasRepository;

public class ConsultarTareaBO : IRequestHandler<InputConsultarTarea, JsonResponse>
{
    private readonly ITareasRepository _ITareasRepository;

    public ConsultarTareaBO(ITareasRepository ITareasRepository)
    {
        _ITareasRepository = ITareasRepository;
    }

    public async Task<JsonResponse> Handle(InputConsultarTarea request, CancellationToken cancellationToken)
    {

        var resultDto = await _ITareasRepository.ConsultarTarea(request);

        try
        {
            if (resultDto.MisTareas == null || resultDto.MisTareas.Count == 0)
            {
                return new JsonResponse
                {
                    Estado = "Fallido",
                    Descripcion = "No se encontraron tareas",
                    MisTareas = new List<TareasOutput>()
                };
            }

            var tareas = new TareasOutput
            {
                Id = resultDto.MisTareas[0].IdDto,
                Titulo = resultDto.MisTareas[0].TituloDto,
                Descripcion = resultDto.MisTareas[0].DescripcionDto

            };

            var result = new JsonResponse
            {
                Estado = resultDto.EstadoDto,
                Descripcion = resultDto.DescripcionDto,
                MisTareas = new List<TareasOutput> { tareas }
            };  

            return result;
        }
        catch (Exception ex)
        {
            return new JsonResponse
            {
                Estado = "Error",
                Descripcion = $"Ocurrió un error al procesar la solicitud: {ex.Message}",
                MisTareas = new List<TareasOutput>()
            };
        }

    }

}