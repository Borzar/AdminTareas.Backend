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

    [HttpPost]
    [Route("CrearTarea")]
    public async Task<ActionResult<JsonResponse>> CrearTarea(InputCrearTarea request)
    {
        var response = await _mediator.Send(request);
        if (response is null)
        {
            return NotFound(new JsonResponse { Estado = "Error", Descripcion = "Error al realizar petición" });
        }
        return Ok(response);

    }

    [HttpPatch]
    [Route("ActualizarTarea")]
    public async Task<ActionResult<JsonResponse>> ActualizarTarea(InputActualizarTarea request)
    {
        var response = await _mediator.Send(request);
        if (response is null)
        {
            return NotFound(new JsonResponse { Estado = "Error", Descripcion = "Error al realizar petición" });
        }
        return Ok(response);

    }

    [HttpDelete]
    [Route("BorrarTarea")]
    public async Task<ActionResult<JsonResponse>> BorrarTarea(InputBorrarTarea request)
    {
        var response = await _mediator.Send(request);
        if (response is null)
        {
            return NotFound(new JsonResponse { Estado = "Error", Descripcion = "Error al realizar petición" });
        }
        return Ok(response);

    }

    [HttpPost]
    [Route("ConsultarTarea")]
    public async Task<ActionResult<JsonResponse>> ConsultarTarea(InputConsultarTarea request)
    {
        var response = await _mediator.Send(request);
        if (response is null)
        {
            return NotFound(new JsonResponse { Estado = "Error", Descripcion = "Error al realizar petición" });
        }
        return Ok(response);

    }
}
