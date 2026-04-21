using papaMiaBackend.Domain.Models.Banner;

namespace papaMiaBackend.BusinessLogic.Interfaces;
public interface IBannerAction
{
    List<BannerDto> GetAllBannersAction();
    BannerDto? GetBannerByIdAction(int id);
}
