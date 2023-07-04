using ASTMA.Application.Common.Models;
using ASTMA.Application.Taskers.Queries.GetById;
using Microsoft.AspNetCore.Mvc;

namespace ASTMA.WebUI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TaskerController : ApiControllerBase
{
    private readonly ILogger<TaskerController> _logger;

    public TaskerController(ILogger<TaskerController> logger)
    {
        _logger = logger;
    }

    [HttpGet("{id}", Name = "GetTasker")]
    public async Task<ActionResult<TaskerDto>> GetTaskerAsync(string id, GetTaskerRequest query)
    {
        if (id != query.Id)
        {
            return BadRequest();
        }

        return await Mediator.Send(query);
    }
}