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
        CreateMap<PermissionCreateDto, Permission>()
            .ForMember(d => d.Id, o => o.Ignore())
            .ForMember(d => d.PermissionGroupId, o => o.Ignore())
            .ForMember(d => d.PermissionGroup, o => o.Ignore())
            .ForMember(d => d.Roles, o => o.Ignore());
        CreateMap<PermissionUpdateDto, Permission>()
            .ForMember(d => d.Id, o => o.Ignore())
            .ForMember(d => d.PermissionGroupId, o => o.Ignore())
            .ForMember(d => d.PermissionGroup, o => o.Ignore())
            .ForMember(d => d.Roles, o => o.Ignore());
        CreateMap<PermissionGroup, PermissionGroupDto>();
        CreateMap<PermissionGroupCreateDto, PermissionGroup>()
            .ForMember(d => d.Id, o => o.Ignore())
            .ForMember(d => d.Permissions, o => o.Ignore());
        CreateMap<PermissionGroupUpdateDto, PermissionGroup>()
            .ForMember(d => d.Id, o => o.Ignore())
            .ForMember(d => d.Permissions, o => o.Ignore());
    }
}
