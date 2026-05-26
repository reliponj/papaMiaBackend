using Microsoft.AspNetCore.Mvc;
using papaMiaBackend.Api.Auth;
using papaMiaBackend.Api.Swagger;
using papaMiaBackend.BusinessLogic;
using papaMiaBackend.BusinessLogic.Interfaces;
using papaMiaBackend.Domain.Models.Article;

namespace papaMiaBackend.Api.Controller;

[AdminPermission("articles")]
[SwaggerBearer]
[Route("api/admin/article")]
[ApiController]
public class ArticleAdminController : ControllerBase
{
    private readonly IArticleAction _article;

    public ArticleAdminController(BusinessLogicManager bl)
    {
        _article = bl.ArticleAction();
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

    [HttpPost]
    public IActionResult CreateArticle([FromBody] ArticleCreateDto dto)
    {
        var created = _article.CreateArticleAction(dto);
        if (created is null)
            return BadRequest(new { message = "invalid_article" });

        return Ok(created);
    }

    [HttpPut("{id:int}")]
    public IActionResult UpdateArticle(int id, [FromBody] ArticleUpdateDto dto)
    {
        if (_article.GetArticleByIdAction(id) is null)
            return NotFound(new { message = "article_not_found" });

        var updated = _article.UpdateArticleAction(id, dto);
        if (updated is null)
            return BadRequest(new { message = "invalid_article" });

        return Ok(updated);
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteArticle(int id)
    {
        if (!_article.DeleteArticleAction(id))
            return NotFound(new { message = "article_not_found" });

        return NoContent();
    }
}
