using MediatR;
using Models.Output;

namespace Models.Input;

public class InputCrearTarea : IRequest<JsonResponse>
{
    public int Id { get; set; }
    public string Titulo { get; set; }
    public string Descripcion { get; set; }
}
