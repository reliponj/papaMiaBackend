using Microsoft.AspNetCore.Mvc;
using papaMiaBackend.Api.Auth;
using papaMiaBackend.Api.Swagger;
using papaMiaBackend.BusinessLogic;
using papaMiaBackend.BusinessLogic.Interfaces;
using papaMiaBackend.Domain.Models.Review;

namespace papaMiaBackend.Api.Controller;

[AdminPermission("reviews")]
[SwaggerBearer]
[Route("api/admin/review")]
[ApiController]
public class ReviewAdminController : ControllerBase
{
    private readonly IReviewAction _review;

    public ReviewAdminController(BusinessLogicManager bl)
    {
        _review = bl.ReviewAction();
    }

    [HttpGet]
    public IActionResult GetAllReviews()
    {
        var items = _review.GetAllReviewsAction();
        return Ok(items);
    }

    [HttpGet("{id:int}")]
    public IActionResult GetReviewById(int id)
    {
        var item = _review.GetReviewByIdAction(id);
        if (item is null)
            return NotFound(new { message = "review_not_found" });

        return Ok(item);
    }

    [HttpPut("{id:int}")]
    public IActionResult UpdateReview(int id, [FromBody] ReviewUpdateDto dto)
    {
        if (_review.GetReviewByIdAction(id) is null)
            return NotFound(new { message = "review_not_found" });

        var updated = _review.UpdateReviewAction(id, dto);
        if (updated is null)
            return BadRequest(new { message = "invalid_review" });

        return Ok(updated);
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteReview(int id)
    {
        if (!_review.DeleteReviewAction(id))
            return NotFound(new { message = "review_not_found" });

        return NoContent();
    }

    [HttpPost("{id:int}/hide")]
    public IActionResult HideReview(int id)
    {
        var item = _review.SetReviewHiddenAction(id, isHidden: true);
        if (item is null)
            return NotFound(new { message = "review_not_found" });

        return Ok(item);
    }

    [HttpPost("{id:int}/show")]
    public IActionResult ShowReview(int id)
    {
        var item = _review.SetReviewHiddenAction(id, isHidden: false);
        if (item is null)
            return NotFound(new { message = "review_not_found" });

        return Ok(item);
    }
}
