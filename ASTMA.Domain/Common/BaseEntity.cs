namespace ASTMA.Domain.Common
{
    /// <summary>
    /// Base class for all domain entities
    /// </summary>
    public abstract class BaseEntity
    {
        /// <summary>
        /// The base class id
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// Setter for id
        /// </summary>
        /// <param name="id">The id to set</param>
        public void SetId(int id) 
        {
            Id = id;
        }

        /// <summary>
        /// DateTime the entity was created
        /// </summary>
        public DateTime DateCreated { get; private set; }

        /// <summary>
        /// DateTime the entity was updated
        /// </summary>
        public DateTime DateUpdated { get; private set; }
    }
}
