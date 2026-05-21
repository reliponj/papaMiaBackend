using Microsoft.AspNetCore.Mvc;
using papaMiaBackend.Api.Auth;
using papaMiaBackend.Api.Swagger;
using papaMiaBackend.BusinessLogic;
using papaMiaBackend.BusinessLogic.Interfaces;
using papaMiaBackend.Domain.Models.Review;

namespace papaMiaBackend.Api.Controller;

[Route("api/review")]
[ApiController]
public class ReviewController : ControllerBase
{
    private readonly IReviewAction _review;
    private readonly IUserAction _user;
    private readonly ICurrentUser _currentUser;

    public ReviewController(BusinessLogicManager bl, ICurrentUser currentUser)
    {
        _review = bl.ReviewAction();
        _user = bl.UserAction();
        _currentUser = currentUser;
    }

    [HttpGet]
    public IActionResult GetPublishedReviews()
    {
        var items = _review.GetPublishedReviewsAction();
        return Ok(items);
    }

    [SwaggerBearer]
    [HttpPost]
    public IActionResult CreateReview([FromBody] ReviewCreateDto dto)
    {
        if (!_currentUser.TryGetUserId(out var userId))
            return Unauthorized();

        var user = _user.GetUserByIdAction(userId);
        if (user is null)
            return NotFound(new { message = "user_not_found" });

        var created = _review.CreateReviewAction(dto, userId, user.Username);
        if (created is null)
            return BadRequest(new { message = "invalid_review" });

        return Ok(created);
    }
}
