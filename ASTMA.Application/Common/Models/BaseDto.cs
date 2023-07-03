namespace ASTMA.Application.Common.Models
{
    public abstract class BaseDto
    {
        /// <summary>
        /// Id of the object
        /// </summary>
        public string Id { get; set; }

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
