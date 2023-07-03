namespace ASTMA.Application.Taskers.Queries.GetByFilter;

/// <summary>
/// Params for filtering a list of Taskers
/// </summary>
public class GetTaskersParams
{
    /// <summary>
    /// The task's Title < 50 characters
    /// </summary>
    public string? Title { get; set; }
}
