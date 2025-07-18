using DBContext.ApplicationDbContext;
using MediatR;
using Models.Input;
using Models.Output;
using Repository.IRepository.ITareasRepository;

public class InputCrearTareaBO : IRequestHandler<InputCrearTarea, JsonResponse>
{
    private readonly ITareasRepository _ITareasRepository;

    public InputCrearTareaBO(ITareasRepository ITareasRepository)
    {
        _ITareasRepository = ITareasRepository;
    }

    public async Task<JsonResponse> Handle(InputCrearTarea request, CancellationToken cancellationToken)
    {

        var respuesta = new JsonResponse();


        var entidad = new Tarea
        {
            Titulo = request.Titulo,
            Descripcion = request.Descripcion
        };

        var response = await _ITareasRepository.CrearTarea(entidad);


        return new JsonResponse
        {
            Estado = "OK", // 👈 aquí deberían ir valores reales
            Descripcion = "Tarea creada exitosamente"
        };
    }

}