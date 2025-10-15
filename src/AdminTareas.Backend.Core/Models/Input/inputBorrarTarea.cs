using MediatR;
using Models.Output;

namespace Models.Input;

public class InputBorrarTarea : IRequest<JsonResponse>
{
    public int Id { get; set; }
}
