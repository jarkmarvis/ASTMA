namespace ASTMA.Application.Common.Models;

public class TaskerDto : BaseDto
{
    /// <summary>
    /// The task's Title < 50 characters
    /// </summary>
    public string? Title { get; set; }

    /// <summary>
    /// The task's Description < 250 characters
    /// </summary>
    public string? Description { get; set; }
}
