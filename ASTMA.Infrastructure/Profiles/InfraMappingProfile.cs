using ASTMA.Application.Common.Models;
using ASTMA.Infrastructure.Documents;
using AutoMapper;

namespace ASTMA.Infrastructure.Profiles;

public class InfraMappingProfile : Profile
{
    public InfraMappingProfile()
    {
        CreateMap<TaskerDocument, TaskerDto>().ReverseMap();
    }
}

