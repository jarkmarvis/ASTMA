using ASTMA.Application.Taskers.Commands.Create;
using ASTMA.Application.Taskers.Commands.Update;
using ASTMA.Application.Taskers.Queries.GetByFilter;
using ASTMA.Domain.Entities;

namespace ASTMA.Application.Common.Interfaces;

public interface ITaskerRepository
{
    /// <summary>
    /// Create a new tasker
    /// </summary>
    /// <param name="args">Args to create the tasker</param>
    /// <returns>Tasker</returns>
    Task<Tasker> CreateAsync(CreateTaskerArgs args);

    /// <summary>
    /// Retrieve a tasker by id
    /// </summary>
    /// <param name="id">Id of the tasker to retrieve</param>
    /// <returns>Tasker</returns>
    Task<Tasker> GetAsync(string id);

    /// <summary>
    /// Retrieve a list of Tasker filtered by args
    /// </summary>
    /// <returns>List of Tasker</returns>
    Task<IEnumerable<Tasker>> GetAsync(GetTaskerArgs args);

    /// <summary>
    /// Create a new tasker
    /// </summary>
    /// <param name="args">Args to create the tasker</param>
    /// <returns>Tasker</returns>
    Task<Tasker> UpdateAsync(UpdateTaskerArgs args);

    /// <summary>
    /// Create a new tasker
    /// </summary>
    /// <param name="id">Id of the tasker to delete</param>
    /// <returns>Tasker</returns>
    Task<Tasker> DeleteAsync(int id);
}