using AutoMapper;
using papaMiaBackend.BusinessLogic.Core;
using papaMiaBackend.BusinessLogic.Interfaces;
using papaMiaBackend.DataAccess.Context;
using papaMiaBackend.Domain.Models.Banner;

namespace papaMiaBackend.BusinessLogic.Structure;

public class BannerActionExecution : BannerActions, IBannerAction
{
    public BannerActionExecution(IMapper mapper, BannerContext db)
        : base(mapper, db)
    {
    }
    public List<BannerDto> GetAllBannersAction()
    {
        return GetAllBannersActionExecution();
    }
    public BannerDto? GetBannerByIdAction(int id)
    {
        return GetBannerByIdActionExecution(id);
    }
}
