using DBContext.ApplicationDbContext;
using MediatR;
using Models.Input;
using Models.Output;
using Repository.IRepository.ITareasRepository;

public class CrearTareaBO : IRequestHandler<InputCrearTarea, JsonResponse>
{
    private readonly ITareasRepository _ITareasRepository;

    public CrearTareaBO(ITareasRepository ITareasRepository)
    {
        _ITareasRepository = ITareasRepository;
    }

    public async Task<JsonResponse> Handle(InputCrearTarea request, CancellationToken cancellationToken)
    {

        var inputTarea = new Tarea
        {
            Titulo = request.Titulo,
            Descripcion = request.Descripcion
        };

        var resultDto = await _ITareasRepository.CrearTarea(inputTarea);

        var result = new JsonResponse
        {
            Estado = resultDto.EstadoDto,
            Descripcion = resultDto.DescripcionDto
        };

        return result;
       
    }

}