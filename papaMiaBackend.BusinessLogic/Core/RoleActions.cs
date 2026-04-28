using AutoMapper;
using papaMiaBackend.DataAccess.Context;
using papaMiaBackend.Domain.Models.Role;

namespace papaMiaBackend.BusinessLogic.Core;

public class RoleActions
{
    protected readonly IMapper Mapper;
    protected readonly RoleContext Db;

    public RoleActions(IMapper mapper, RoleContext db)
    {
        Mapper = mapper;
        Db = db;
    }

    internal List<RoleDto> GetAllRolesActionExecution()
    {
        var entities = Db.Roles.ToList();
        return Mapper.Map<List<RoleDto>>(entities);
    }
}
