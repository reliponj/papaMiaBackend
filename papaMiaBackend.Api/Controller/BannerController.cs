using Microsoft.AspNetCore.Mvc;
using papaMiaBackend.BusinessLogic;
using papaMiaBackend.BusinessLogic.Interfaces;

namespace papaMiaBackend.Api.Controller;

[Route("api/banner")]
[ApiController]
public class BannerController : ControllerBase
{
    internal IBannerAction _banner;
    public BannerController(BusinessLogicManager bl)
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
}