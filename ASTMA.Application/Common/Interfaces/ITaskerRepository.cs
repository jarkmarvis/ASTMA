using ASTMA.Application.Common.Models;
using ASTMA.Application.Taskers.Commands.Create;
using ASTMA.Application.Taskers.Commands.Update;
using ASTMA.Application.Taskers.Queries.GetByFilter;

namespace ASTMA.Application.Common.Interfaces;

public interface ITaskerRepository
{
    /// <summary>
    /// Create a new tasker
    /// </summary>
    /// <param name="args">Args to create the tasker</param>
    /// <returns>TaskerDto</returns>
    Task<TaskerDto> CreateAsync(CreateTaskerArgs args);

    /// <summary>
    /// Retrieve a tasker by id
    /// </summary>
    /// <param name="id">Id of the tasker to retrieve</param>
    /// <returns>TaskerDto</returns>
    Task<TaskerDto> GetAsync(string id);

    /// <summary>
    /// Retrieve a list of TaskerDtos filtered by args
    /// </summary>
    /// <returns>List of TaskerDtos</returns>
    Task<IEnumerable<TaskerDto>> GetAsync(GetTaskerArgs args);

    /// <summary>
    /// Create a new tasker
    /// </summary>
    /// <param name="args">Args to create the tasker</param>
    /// <returns>TaskerDto</returns>
    Task<TaskerDto> UpdateAsync(UpdateTaskerArgs args);

    /// <summary>
    /// Create a new tasker
    /// </summary>
    /// <param name="id">Id of the tasker to delete</param>
    /// <returns>TaskerDto</returns>
    Task<TaskerDto> DeleteAsync(int id);
}