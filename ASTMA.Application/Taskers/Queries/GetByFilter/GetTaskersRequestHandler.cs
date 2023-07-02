using ASTMA.Application.Common.Interfaces;
using ASTMA.Application.Common.Models;
using AutoMapper;
using MediatR;

namespace ASTMA.Application.Taskers.Queries.GetByFilter
{
    public class GetTaskersRequestHandler : IRequestHandler<GetTaskersRequest, List<TaskerDto>>
    {
        private readonly ITaskerRepository _taskerRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="taskerRepository">Tasker Repo</param>
        /// <param name="mapper">Mapper</param>
        public GetTaskersRequestHandler(ITaskerRepository taskerRepository, IMapper mapper)
        {
            _taskerRepository = taskerRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Handle getting a list of Taskers
        /// </summary>
        /// <param name="request">Get request</param>
        /// <param name="cancellationToken">Cancellation Token</param>
        /// <returns>List of TaskerDtos</returns>
        public async Task<List<TaskerDto>> Handle(GetTaskersRequest request, CancellationToken cancellationToken)
        {
            var args = _mapper.Map<Common.Models.GetTaskerArgs>(request.parameters);
            var taskers = await _taskerRepository.GetAsync(args);
            return _mapper.Map<List<TaskerDto>>(taskers);
        }
    }
}
