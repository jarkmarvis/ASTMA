namespace ASTMA.Application.Taskers.Commands.Create;

/// <summary>
/// Args passed in used to create tasker objects
/// </summary>
public class CreateTaskerArgs
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
