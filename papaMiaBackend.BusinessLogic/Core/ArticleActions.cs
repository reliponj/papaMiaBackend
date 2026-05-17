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
        return Mapper.Map<List<ArticleDto>>(entities);
    }

    internal ArticleDto? GetArticleByIdActionExecution(int id)
    {
        var entity = Db.Articles
            .FirstOrDefault(a => a.Id == id);
        if (entity is null)
            return null;

        return Mapper.Map<ArticleDto>(entity);
    }

    internal ArticleDto? CreateArticleActionExecution(ArticleCreateDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Text))
            return null;
        if (string.IsNullOrWhiteSpace(dto.ImageUrl))
            return null;

        var entity = Mapper.Map<Article>(dto);
        entity.Text = entity.Text.Trim();
        entity.ImageUrl = entity.ImageUrl.Trim();
        entity.CreatedAt = DateTime.UtcNow;

        Db.Articles.Add(entity);
        Db.SaveChanges();
        return Mapper.Map<ArticleDto>(entity);
    }

    internal ArticleDto? UpdateArticleActionExecution(int id, ArticleUpdateDto dto)
    {
        var entity = Db.Articles.FirstOrDefault(a => a.Id == id);
        if (entity is null)
            return null;

        if (string.IsNullOrWhiteSpace(dto.Text))
            return null;
        if (string.IsNullOrWhiteSpace(dto.ImageUrl))
            return null;

        entity.Text = dto.Text.Trim();
        entity.ImageUrl = dto.ImageUrl.Trim();

        Db.SaveChanges();
        return Mapper.Map<ArticleDto>(entity);
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
}
