using AutoMapper;
using papaMiaBackend.Domain.Entities.Role;
using papaMiaBackend.Domain.Models.Role;

namespace papaMiaBackend.BusinessLogic.Mapping;

public class RoleMappingProfile : Profile
{
    public RoleMappingProfile()
    {
        CreateMap<Role, RoleDto>();
        CreateMap<Permission, PermissionDto>();
        CreateMap<PermissionGroup, PermissionGroupDto>();
    }
}
