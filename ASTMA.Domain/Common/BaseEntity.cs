namespace ASTMA.Domain.Common;

/// <summary>
/// Base class for all domain entities
/// </summary>
public abstract class BaseEntity
{
    /// <summary>
    /// The base class id
    /// </summary>
    public string Id { get; private set; }

    /// <summary>
    /// Setter for id
    /// </summary>
    /// <param name="id">The id to set</param>
    public void SetId(string id) 
    {
        Id = id;
    }

    /// <summary>
    /// DateTime the entity was created
    /// </summary>
    public DateTime DateCreated { get; private set; }

    /// <summary>
    /// Setter for DateCreated
    /// </summary>
    /// <param name="date">The date to set</param>
    public void SetDateCreated(DateTime date)
    {
        DateCreated = date;
    }

    /// <summary>
    /// DateTime the entity was updated
    /// </summary>
    public DateTime DateUpdated { get; private set; }

    /// <summary>
    /// Setter for DateUpdated
    /// </summary>
    /// <param name="date">The date to set</param>
    public void SetDateUpdated(DateTime date)
    {
        DateUpdated = date;
    }
}
