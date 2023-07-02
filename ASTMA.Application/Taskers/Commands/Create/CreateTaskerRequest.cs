using ASTMA.Domain.Entities;
using MediatR;

namespace ASTMA.Application.Taskers.Commands.Create;

/// <summary>
/// Request to create a tasker
/// </summary>
public class CreateTaskerRequest : IRequest<Tasker>
{
    /// <summary>
    /// Request data transfer object to create a tasker
    /// </summary>
    public CreateTaskerArgs TaskerRequestDto { get; set; }
}

