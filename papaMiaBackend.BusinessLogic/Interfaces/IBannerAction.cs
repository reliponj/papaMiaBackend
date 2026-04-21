using papaMiaBackend.Domain.Models.Banner;

namespace papaMiaBackend.BusinessLogic.Interfaces;
public interface IBannerAction
{
    List<BannerDto> GetAllBannersAction();
    BannerDto? GetBannerByIdAction(int id);
    BannerDto CreateBannerAction(BannerCreateDto bannerCreateDto);
    BannerDto? UpdateBannerAction(int id, BannerUpdateDto bannerUpdateDto);
}
