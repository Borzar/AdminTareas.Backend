using MediatR;
using Models.Output;

namespace Models.Input;

public class InputActualizarTarea : InputCrearTarea, IRequest<JsonResponse>
{
    public int Id { get; set; }
}
