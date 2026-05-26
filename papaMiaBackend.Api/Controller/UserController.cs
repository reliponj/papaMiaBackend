using Microsoft.AspNetCore.Mvc;
using papaMiaBackend.Api.Auth;
using papaMiaBackend.Api.Swagger;
using papaMiaBackend.BusinessLogic;
using papaMiaBackend.BusinessLogic.Interfaces;
using papaMiaBackend.Domain.Models.User;

namespace papaMiaBackend.Api.Controller;

[Route("api/user")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserAction _user;
    private readonly IFavoriteAction _favorite;
    private readonly ICurrentUser _currentUser;

    public UserController(BusinessLogicManager bl, ICurrentUser currentUser)
    {
        _user = bl.UserAction();
        _favorite = bl.FavoriteAction();
        _currentUser = currentUser;
    }

    [SwaggerBearer]
    [HttpGet("me")]
    public IActionResult Me()
    {
        if (!_currentUser.TryGetUserId(out var id))
            return Unauthorized();

        var user = _user.GetUserByIdAction(id);
        if (user is null)
            return NotFound();

        return Ok(user);
    }

    [SwaggerBearer]
    [HttpPut("me")]
    public IActionResult UpdateMe([FromBody] UserUpdateDto dto)
    {
        if (!_currentUser.TryGetUserId(out var id))
            return Unauthorized();

        var user = _user.UpdateUserAction(id, dto);
        if (user is null)
            return NotFound();

        return Ok(user);
    }

    [SwaggerBearer]
    [HttpGet("favorites")]
    public IActionResult GetFavorites()
    {
        if (!_currentUser.TryGetUserId(out var id))
            return Unauthorized();

        var products = _favorite.GetFavoriteProductsAction(id);
        return Ok(products);
    }

    [SwaggerBearer]
    [HttpPost("favorites/toggle")]
    public IActionResult ToggleFavorite([FromBody] FavoriteToggleRequestDto dto)
    {
        if (!_currentUser.TryGetUserId(out var id))
            return Unauthorized();

        var result = _favorite.ToggleFavoriteAction(id, dto?.ProductId ?? 0);
        if (result is null)
            return BadRequest(new { message = "product_not_found" });

        return Ok(result);
    }

    [SwaggerBearer]
    [HttpPut("me/password")]
    public IActionResult ChangeMyPassword([FromBody] ChangePasswordDto dto)
    {
        if (!_currentUser.TryGetUserId(out var id))
            return Unauthorized();

        return _user.ChangePasswordAction(id, dto) switch
        {
            ChangePasswordResult.Success => NoContent(),
            ChangePasswordResult.UserNotFound => NotFound(),
            ChangePasswordResult.InvalidCurrentPassword => BadRequest(new { message = "invalid_current_password" })
        };
    }
}
