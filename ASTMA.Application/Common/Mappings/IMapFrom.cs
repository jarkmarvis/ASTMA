using AutoMapper;

namespace ASTMA.Application.Common.Mappings;

/// <summary>
/// Create a map of gneric type T
/// </summary>
/// <typeparam name="T">Type</typeparam>
public interface IMapFrom<T>
{
    void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
}
