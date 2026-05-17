using AutoMapper;
using papaMiaBackend.BusinessLogic.Core;
using papaMiaBackend.BusinessLogic.Interfaces;
using papaMiaBackend.DataAccess.Context;
using papaMiaBackend.Domain.Models.Article;

namespace papaMiaBackend.BusinessLogic.Structure;

public class ArticleActionExecution : ArticleActions, IArticleAction
{
    public ArticleActionExecution(IMapper mapper, ArticleContext db)
        : base(mapper, db)
    {
    }

    public List<ArticleDto> GetAllArticlesAction()
    {
        return GetAllArticlesActionExecution();
    }

    public ArticleDto? GetArticleByIdAction(int id)
    {
        return GetArticleByIdActionExecution(id);
    }

    public ArticleDto? CreateArticleAction(ArticleCreateDto dto)
    {
        return CreateArticleActionExecution(dto);
    }

    public ArticleDto? UpdateArticleAction(int id, ArticleUpdateDto dto)
    {
        return UpdateArticleActionExecution(id, dto);
    }

    public bool DeleteArticleAction(int id)
    {
        return DeleteArticleActionExecution(id);
    }
}
