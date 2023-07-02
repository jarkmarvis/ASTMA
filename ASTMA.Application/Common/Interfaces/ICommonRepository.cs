namespace ASTMA.Application.Common.Interfaces
{
    public interface ICommonRepository<T> where T : class
    {
        /// <summary>
        /// Retrieve a list of all items
        /// </summary>
        /// <returns>List of item type T</returns>
        Task<IEnumerable<T>> GetAllAsync();

        /// <summary>
        /// Retrieve an item of type T by id
        /// </summary>

        Task<T> GetAsync(int id);

        /// <summary>
        /// Create an item of type T
        /// </summary>
        /// <returns>An item of type T</returns>
        Task<T> CreateAsync(T entity);

        /// <summary>
        /// Update an item of type T
        /// </summary>
        /// <returns>An item of type T</returns>
        Task<T> UpdateAsync(T entity);

        /// <summary>
        /// Deletes an item by id
        /// </summary>
        /// <param name="id">Id of the item</param>
        /// <returns>ActionResult</returns>
        Task DeleteAsync(int id);
    }
}
