using Microsoft.AspNetCore.Mvc;
using papaMiaBackend.Api.Auth;
using papaMiaBackend.Api.Swagger;
using papaMiaBackend.BusinessLogic;
using papaMiaBackend.BusinessLogic.Interfaces;
using papaMiaBackend.Domain.Models.Banner;

namespace papaMiaBackend.Api.Controller;

[AdminMod]
[SwaggerBearer]
[Route("api/admin/banner")]
[ApiController]
public class BannerAdminController : ControllerBase
{
    internal IBannerAction _banner;
    public BannerAdminController(BusinessLogicManager bl)
    {
        _banner = bl.BannerAction();
    }

    [HttpGet]
    public IActionResult GetAllBanners()
    {
        var banners = _banner.GetAllBannersAction();
        return Ok(banners);
    }
    [HttpGet("{id}")]
    public IActionResult GetBannerById(int id)
    {
        var banner = _banner.GetBannerByIdAction(id);
        if (banner == null)
        {
            return NotFound(new { message = "banner_not_found" }); 
        }
        return Ok(banner);
    }
    [HttpPost]
    public IActionResult CreateBanner(BannerCreateDto bannerCreateDto)
    {
        var banner = _banner.CreateBannerAction(bannerCreateDto);
        return Ok(banner);
    }
    [HttpPut("{id}")]
    public IActionResult UpdateBanner(int id, BannerUpdateDto bannerUpdateDto)
    {
        var banner = _banner.UpdateBannerAction(id, bannerUpdateDto);
        if (banner == null)
        {
            return NotFound(new { message = "banner_not_found" });
        }
        return Ok(banner);
    }
    [HttpDelete("{id}")]
    public IActionResult DeleteBanner(int id)
    {
        var result = _banner.DeleteBannerAction(id);
        if (!result)
        {
            return NotFound(new { message = "banner_not_found" });
        }
        return NoContent();
    }
}