using AutoMapper;
using Microsoft.EntityFrameworkCore;
using papaMiaBackend.DataAccess.Context;
using papaMiaBackend.Domain.Entities.Article;
using papaMiaBackend.Domain.Models.Article;

namespace papaMiaBackend.BusinessLogic.Core;

public class ArticleActions
{
    protected readonly IMapper Mapper;
    protected readonly ArticleContext Db;

    public ArticleActions(IMapper mapper, ArticleContext db)
    {
        Mapper = mapper;
        Db = db;
    }

    internal List<ArticleDto> GetAllArticlesActionExecution()
    {
        var entities = Db.Articles
            .OrderByDescending(a => a.CreatedAt)
            .ToList();
        return entities.Select(MapArticleListItem).ToList();
    }

    internal ArticleDto? GetArticleByIdActionExecution(int id)
    {
        var entity = Db.Articles
            .Include(a => a.Comments)
            .FirstOrDefault(a => a.Id == id);
        if (entity is null)
            return null;

        return MapArticleDetail(entity);
    }

    internal ArticleDto? CreateArticleActionExecution(ArticleCreateDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Title))
            return null;
        if (string.IsNullOrWhiteSpace(dto.Text))
            return null;
        if (string.IsNullOrWhiteSpace(dto.ImageUrl))
            return null;

        var entity = Mapper.Map<Article>(dto);
        entity.Title = entity.Title.Trim();
        entity.Text = entity.Text.Trim();
        entity.ImageUrl = entity.ImageUrl.Trim();
        entity.CreatedAt = DateTime.UtcNow;

        Db.Articles.Add(entity);
        Db.SaveChanges();
        return MapArticleListItem(entity);
    }

    internal ArticleDto? UpdateArticleActionExecution(int id, ArticleUpdateDto dto)
    {
        var entity = Db.Articles.FirstOrDefault(a => a.Id == id);
        if (entity is null)
            return null;

        if (string.IsNullOrWhiteSpace(dto.Title))
            return null;
        if (string.IsNullOrWhiteSpace(dto.Text))
            return null;
        if (string.IsNullOrWhiteSpace(dto.ImageUrl))
            return null;

        entity.Title = dto.Title.Trim();
        entity.Text = dto.Text.Trim();
        entity.ImageUrl = dto.ImageUrl.Trim();

        Db.SaveChanges();
        return MapArticleListItem(entity);
    }

    internal bool DeleteArticleActionExecution(int id)
    {
        var entity = Db.Articles.FirstOrDefault(a => a.Id == id);
        if (entity is null)
            return false;

        Db.Articles.Remove(entity);
        Db.SaveChanges();
        return true;
    }

    internal ArticleCommentDto? AddArticleCommentActionExecution(int articleId, int userId, ArticleCommentCreateDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Text))
            return null;

        if (!Db.Articles.Any(a => a.Id == articleId))
            return null;

        var entity = new ArticleComment
        {
            ArticleId = articleId,
            UserId = userId,
            Text = dto.Text.Trim(),
            CreatedAt = DateTime.UtcNow
        };

        Db.ArticleComments.Add(entity);
        Db.SaveChanges();
        return Mapper.Map<ArticleCommentDto>(entity);
    }

    private ArticleDto MapArticleListItem(Article entity)
    {
        var dto = Mapper.Map<ArticleDto>(entity);
        dto.Comments = [];
        return dto;
    }

    private ArticleDto MapArticleDetail(Article entity)
    {
        var dto = Mapper.Map<ArticleDto>(entity);
        dto.Comments = Mapper.Map<List<ArticleCommentDto>>(
            entity.Comments.OrderBy(c => c.CreatedAt));
        return dto;
    }
}
