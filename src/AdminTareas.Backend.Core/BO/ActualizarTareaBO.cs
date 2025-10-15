using DBContext.ApplicationDbContext;
using MediatR;
using Models.Input;
using Models.Output;
using Repository.IRepository.ITareasRepository;

public class ActualizarTareaBO : IRequestHandler<InputActualizarTarea, JsonResponse>
{
    private readonly ITareasRepository _ITareasRepository;

    public ActualizarTareaBO(ITareasRepository ITareasRepository)
    {
        _ITareasRepository = ITareasRepository;
    }

    public async Task<JsonResponse> Handle(InputActualizarTarea request, CancellationToken cancellationToken)
    {

        var intputTarea = new Tarea();

        if (!string.IsNullOrWhiteSpace(request.Titulo))
        {
            intputTarea.Titulo = request.Titulo.Trim();
        };

        if (!string.IsNullOrWhiteSpace(request.Descripcion))
        {
            intputTarea.Descripcion = request.Descripcion.Trim();
        };
        
        intputTarea.Id = request.Id;

        var resultDto = await _ITareasRepository.ActualizarTarea(intputTarea);

        var result = new JsonResponse
        {
            Estado = resultDto.EstadoDto,
            Descripcion = resultDto.DescripcionDto
        };

        return result;
       
    }

}