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
}