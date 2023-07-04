using ASTMA.Application.Common.Mappings;
using ASTMA.Domain.Entities;

namespace ASTMA.Application.Common.Models;

/// <summary>
/// Data transfer object for tasker used to 
/// </summary>
public class TaskerDto : IMapFrom<Tasker>
{
    /// <summary>
    /// The tasker's id
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// The tasker's Title < 50 characters
    /// </summary>
    public string? Title { get; set; }

    /// <summary>
    /// The tasker's Description < 250 characters
    /// </summary>
    public string? Description { get; set; }
}
