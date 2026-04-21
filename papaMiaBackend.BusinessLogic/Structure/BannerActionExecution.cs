using AutoMapper;
using papaMiaBackend.BusinessLogic.Core;
using papaMiaBackend.BusinessLogic.Interfaces;
using papaMiaBackend.DataAccess.Context;

namespace papaMiaBackend.BusinessLogic.Structure;

public class BannerActionExecution : BannerActions, IBannerAction
{
    public BannerActionExecution(IMapper mapper, BannerContext db)
        : base(mapper, db)
    {
    }
}
