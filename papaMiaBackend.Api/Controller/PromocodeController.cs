using Microsoft.AspNetCore.Mvc;
using papaMiaBackend.BusinessLogic;
using papaMiaBackend.BusinessLogic.Interfaces;

namespace papaMiaBackend.Api.Controller;

[Route("api/promocode")]
[ApiController]
public class PromocodeController : ControllerBase
{
    internal IPromocodeAction _promocode;
    public PromocodeController(BusinessLogicManager bl)
    {
        _promocode = bl.PromocodeAction();
    }
}

