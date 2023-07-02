using ASTMA.Domain.Entities;
using MediatR;

namespace ASTMA.Application.Taskers.Queries.GetById
{
    /// <summary>
    /// Request to get a single Tasker
    /// </summary>
    public class GetTaskerRequest : IRequest<Tasker>
    {
        /// <summary>
        /// The Id of the tasker
        /// </summary>
        public int Id { get; set; }
    }
}
