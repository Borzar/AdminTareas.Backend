using MediatR;
using Models.Input;
using Models.Output;

public class InputCrearTareaBO : IRequestHandler<InputCrearTarea, JsonResponse>
{
    // private readonly IDatabaseRepository _databaseRepository;
    private readonly IMediator _mediator;

    public InputCrearTareaBO(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<JsonResponse> Handle(InputCrearTarea request, CancellationToken cancellationToken)
    {

        var respuesta = new JsonResponse();

        return respuesta;
    }

}