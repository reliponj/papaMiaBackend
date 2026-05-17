using AutoMapper;
using papaMiaBackend.Domain.Entities.User;
using papaMiaBackend.Domain.Models.User;

namespace papaMiaBackend.BusinessLogic.Mapping;

public class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        CreateMap<User, UserDto>();

        CreateMap<UserCreateDto, User>()
            .ForMember(d => d.Id, o => o.Ignore())
            .ForMember(d => d.LastLogin, o => o.MapFrom(_ => DateTime.UtcNow))
            .ForMember(d => d.LastIp, o => o.MapFrom(_ => string.Empty))
            .ForMember(d => d.Roles, o => o.Ignore());
    }
}
