using ASTMA.Application.Common.Models;
using MediatR;

namespace ASTMA.Application.Taskers.Queries.GetByFilter
{
    /// <summary>
    /// Request to get a list of Taskers
    /// </summary>
    public class GetTaskersRequest : IRequest<List<TaskerDto>>
    {
        /// <summary>
        /// Params to filter the tasker request by
        /// </summary>
        public GetTaskersParams parameters { get; set; }
    }
}
