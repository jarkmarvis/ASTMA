using ASTMA.Application.Common.Models;
using ASTMA.Application.Taskers.Queries.GetByFilter;
using ASTMA.Domain.Entities;
using AutoMapper;

namespace ASTMA.Application.Common.Mappings;

public class AppMappingProfile : Profile
{
    public AppMappingProfile()
    {
        CreateMap<Tasker, TaskerDto>().ReverseMap();
        CreateMap<GetTaskerArgs, GetTaskersParams>().ReverseMap();
    }
}

