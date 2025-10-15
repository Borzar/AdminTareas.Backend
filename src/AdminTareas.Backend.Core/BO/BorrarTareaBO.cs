using DBContext.ApplicationDbContext;
using MediatR;
using Models.Input;
using Models.Output;
using Repository.IRepository.ITareasRepository;

public class BorrarTareaBO : IRequestHandler<InputBorrarTarea, JsonResponse>
{
    private readonly ITareasRepository _ITareasRepository;

    public BorrarTareaBO(ITareasRepository ITareasRepository)
    {
        _ITareasRepository = ITareasRepository;
    }

    public async Task<JsonResponse> Handle(InputBorrarTarea request, CancellationToken cancellationToken)
    {

        // var intputTarea = new Tarea();

        // intputTarea.Id = request.Id;

        var resultDto = await _ITareasRepository.BorrarTarea(request);

        var result = new JsonResponse
        {
            Estado = resultDto.EstadoDto,
            Descripcion = resultDto.DescripcionDto
        };

        return result;
       
    }

}