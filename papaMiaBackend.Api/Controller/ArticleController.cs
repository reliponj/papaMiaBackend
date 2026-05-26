using Microsoft.AspNetCore.Mvc;
using papaMiaBackend.Api.Auth;
using papaMiaBackend.Api.Swagger;
using papaMiaBackend.BusinessLogic;
using papaMiaBackend.BusinessLogic.Interfaces;
using papaMiaBackend.Domain.Models.Article;

namespace papaMiaBackend.Api.Controller;

[Route("api/article")]
[ApiController]
public class ArticleController : ControllerBase
{
    private readonly IArticleAction _article;
    private readonly ICurrentUser _currentUser;

    public ArticleController(BusinessLogicManager bl, ICurrentUser currentUser)
    {
        _article = bl.ArticleAction();
        _currentUser = currentUser;
    }

    [HttpGet]
    public IActionResult GetAllArticles()
    {
        var items = _article.GetAllArticlesAction();
        return Ok(items);
    }

    [HttpGet("{id:int}")]
    public IActionResult GetArticleById(int id)
    {
        var item = _article.GetArticleByIdAction(id);
        if (item is null)
            return NotFound(new { message = "article_not_found" });

        return Ok(item);
    }

    [SwaggerBearer]
    [HttpPost("{id:int}/comments")]
    public IActionResult AddComment(int id, [FromBody] ArticleCommentCreateDto dto)
    {
        if (!_currentUser.TryGetUserId(out var userId))
            return Unauthorized();

        if (string.IsNullOrWhiteSpace(dto?.Text))
            return BadRequest(new { message = "comment_text_required" });

        var comment = _article.AddArticleCommentAction(id, userId, dto!);
        if (comment is null)
            return NotFound(new { message = "article_not_found" });

        return Ok(comment);
    }
}
