using Microsoft.AspNetCore.Mvc;
using papaMiaBackend.BusinessLogic;
using papaMiaBackend.BusinessLogic.Interfaces;

namespace papaMiaBackend.Api.Controller;

[Route("api/article")]
[ApiController]
public class ArticleController : ControllerBase
{
    private readonly IArticleAction _article;

    public ArticleController(BusinessLogicManager bl)
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
}
