using Microsoft.AspNetCore.Mvc;
using papaMiaBackend.BusinessLogic;
using papaMiaBackend.BusinessLogic.Interfaces;

namespace papaMiaBackend.Api.Controller;

[Route("api/banner")]
[ApiController]
public class BannerController : ControllerBase
{
    private readonly IBannerAction _banner;

    public BannerController(BusinessLogicManager bl)
    {
        _banner = bl.BannerAction();
    }

    [HttpGet]
    public IActionResult GetAllBanners()
    {
        var items = _banner.GetAllBannersAction();
        return Ok(items);
    }

    [HttpGet("{id:int}")]
    public IActionResult GetBannerById(int id)
    {
        var item = _banner.GetBannerByIdAction(id);
        if (item is null)
            return NotFound(new { message = "banner_not_found" });

        return Ok(item);
    }
}
