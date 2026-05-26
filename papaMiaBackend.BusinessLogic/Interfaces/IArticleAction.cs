using papaMiaBackend.Domain.Models.Article;

namespace papaMiaBackend.BusinessLogic.Interfaces;

public interface IArticleAction
{
    List<ArticleDto> GetAllArticlesAction();
    ArticleDto? GetArticleByIdAction(int id);
    ArticleDto? CreateArticleAction(ArticleCreateDto dto);
    ArticleDto? UpdateArticleAction(int id, ArticleUpdateDto dto);
    bool DeleteArticleAction(int id);
    ArticleCommentDto? AddArticleCommentAction(int articleId, int userId, ArticleCommentCreateDto dto);
}
