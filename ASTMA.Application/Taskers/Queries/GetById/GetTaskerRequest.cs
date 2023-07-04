using ASTMA.Application.Common.Models;
using MediatR;

namespace ASTMA.Application.Taskers.Queries.GetById;

/// <summary>
/// Request to get a single Tasker
/// </summary>
public record GetTaskerRequest : IRequest<TaskerDto>
{
    /// <summary>
    /// The Id of the tasker
    /// </summary>
    public string Id { get; set; } = null!;
}
