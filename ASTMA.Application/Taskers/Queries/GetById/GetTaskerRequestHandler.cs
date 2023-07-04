using System;
using ASTMA.Application.Common.Interfaces;
using ASTMA.Application.Common.Models;
using ASTMA.Domain.Entities;
using AutoMapper;
using MediatR;

namespace ASTMA.Application.Taskers.Queries.GetById;

public class GetTaskerRequestHandler : IRequestHandler<GetTaskerRequest, TaskerDto>
{
    private readonly ITaskerRepository _taskerRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Ctor
    /// </summary>
    /// <param name="taskerRepository">Tasker Repo</param>
    /// <param name="mapper">Mapper</param>
    public GetTaskerRequestHandler(ITaskerRepository taskerRepository, IMapper mapper)
    {
        _taskerRepository = taskerRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handler for getting a single Tasker
    /// </summary>
    /// <param name="request">Get request</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>TaskerDto</returns>
    public async Task<TaskerDto> Handle(GetTaskerRequest request, CancellationToken cancellationToken)
    {
        //Validate request
        //Handle exceptions

        if (request == null)
        {
            throw new ArgumentNullException();
        }

        if (String.IsNullOrEmpty(request.Id.Trim()))
        {
            throw new ArgumentException("Id is required.", nameof(request.Id));
        }

        try
        {
            var result = await _taskerRepository.GetAsync(request.Id);
            return _mapper.Map<TaskerDto>(result);
        }
        catch (Exception ex)
        {
            throw new ApplicationException("We don't yet know what happened.");
        }
    }
}
