using ASTMA.Application.Common.Interfaces;
using ASTMA.Application.Common.Models;
using ASTMA.Domain.Entities;
using AutoMapper;
using MediatR;

namespace ASTMA.Application.Taskers.Commands.Create;
    public class CreateTaskerRequestHandler : IRequestHandler<CreateTaskerRequest, Tasker>
    {
        private readonly ITaskerRepository _taskerRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="taskerRepository">Tasker repo</param>
        /// <param name="mapper">mapper</param>
        public CreateTaskerRequestHandler(ITaskerRepository taskerRepository, IMapper mapper)
        {
            _taskerRepository = taskerRepository;
            _mapper = mapper;
        }


        /// <summary>
        /// Handle creating a Tasker object
        /// </summary>
        /// <param name="request">The CreateTaskerRequest</param>
        /// <param name="cancellationToken">The CancellationToken</param>
        /// <returns>Task of TaskerDto</returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<Tasker> Handle(CreateTaskerRequest request, CancellationToken cancellationToken)
        {
            var tasker = await _taskerRepository.CreateAsync(request.TaskerRequestDto);
            return _mapper.Map<Tasker>(tasker);
        }
    }
