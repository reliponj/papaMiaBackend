using AutoMapper;
using papaMiaBackend.DataAccess.Context;

namespace papaMiaBackend.BusinessLogic.Core;

public class BannerActions
{
    protected readonly IMapper Mapper;
    protected readonly BannerContext Db;
    public BannerActions(IMapper mapper, BannerContext db)
    {
        Mapper = mapper;
        Db = db;
    }
}