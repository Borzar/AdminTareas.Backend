using Dto.Output;

namespace Models.Output;

public class JsonResponse
{
    public string Estado { get; set; }
    public string Descripcion { get; set; }
    public List<TareasOutput> MisTareas { get; set; }

}