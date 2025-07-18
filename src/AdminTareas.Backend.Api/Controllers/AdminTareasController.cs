using MediatR;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Input;
using Models.Output;

namespace AdminTareas.BackEnd.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AdminTareasController : ControllerBase
{
    private readonly ILogger<AdminTareasController> _logger;
    private readonly IMediator _mediator;

    public AdminTareasController(ILogger<AdminTareasController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpGet]
    [Route("ConsultarTarea")]
    public ActionResult<JsonResponse> ConsultarTarea(InputCrearTarea request)
    {
        var response = _mediator.Send(request);
        if (response is null)
        {
            return NotFound(new JsonResponse { Estado = "ConsultarTarea", Descripcion = "Error al realizar petición" });
        }
        return Ok(response);

    }

    [HttpGet]
    [Route("BorrarTarea")]
    public ActionResult<JsonResponse> BorrarTarea(InputCrearTarea request)
    {
        var response = _mediator.Send(request);
        if (response is null)
        {
            return NotFound(new JsonResponse { Estado = "BorrarTarea", Descripcion = "Error al realizar petición" });
        }
        return Ok(response);

    }

    [HttpGet]
    [Route("ActualizarTarea")]
    public ActionResult<JsonResponse> ActualizarTarea(InputCrearTarea request)
    {
        var response = _mediator.Send(request);
        if (response is null)
        {
            return NotFound(new JsonResponse { Estado = "ActualizarTarea", Descripcion = "Error al realizar petición" });
        }
        return Ok(response);

    }

    [HttpPost]
    [Route("CrearTarea")]
    public async Task<ActionResult<JsonResponse>> CrearTarea(InputCrearTarea request)
    {
        var response = await _mediator.Send(request);
        if (response is null)
        {
            return NotFound(new JsonResponse { Estado = "CrearTarea", Descripcion = "Error al realizar petición" });
        }
        return Ok(response);

    }

}
