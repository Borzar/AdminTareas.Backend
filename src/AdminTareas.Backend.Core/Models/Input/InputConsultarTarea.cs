using MediatR;
using Models.Output;

namespace Models.Input;

public class InputConsultarTarea : IRequest<JsonResponse>
{
    public int Id { get; set; }
}
