using ASTMA.Domain.Common;

namespace ASTMA.Domain.Entities
{
    /// <summary>
    /// Class defining properties of a Task
    /// </summary>
    public sealed class Tasker : BaseEntity
    {
        /// <summary>
        /// Parameterless ctor to resove issue with automapper
        /// </summary>
        public Tasker()
        {}

        /// <summary>
        /// The task's Title < 50 characters
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// The task's Description < 250 characters
        /// </summary>
        public string? Description { get; set; }
    }
}
