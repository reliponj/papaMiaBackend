using AutoMapper;
using Microsoft.EntityFrameworkCore;
using papaMiaBackend.DataAccess.Context;
using papaMiaBackend.Domain.Models.Review;
using ReviewEntity = papaMiaBackend.Domain.Entities.Review.Review;

namespace papaMiaBackend.BusinessLogic.Core;

public class ReviewActions
{
    protected readonly IMapper Mapper;
    protected readonly ReviewContext Db;

    public ReviewActions(IMapper mapper, ReviewContext db)
    {
        Mapper = mapper;
        Db = db;
    }

    internal List<ReviewDto> GetAllReviewsActionExecution()
    {
        var entities = Db.Reviews
            .OrderByDescending(r => r.CreatedAt)
            .ToList();
        return Mapper.Map<List<ReviewDto>>(entities);
    }

    internal List<ReviewDto> GetPublishedReviewsActionExecution()
    {
        var entities = Db.Reviews
            .Where(r => !r.IsHidden)
            .OrderByDescending(r => r.CreatedAt)
            .ToList();
        return Mapper.Map<List<ReviewDto>>(entities);
    }

    internal ReviewDto? GetReviewByIdActionExecution(int id)
    {
        var entity = Db.Reviews
            .FirstOrDefault(r => r.Id == id);
        if (entity is null)
            return null;

        return Mapper.Map<ReviewDto>(entity);
    }

    internal ReviewDto? CreateReviewActionExecution(ReviewCreateDto dto, int userId, string authorName)
    {
        if (dto.Rating is < 1 or > 5)
            return null;
        if (string.IsNullOrWhiteSpace(dto.Text))
            return null;
        if (string.IsNullOrWhiteSpace(authorName))
            return null;

        var entity = new ReviewEntity
        {
            UserId = userId,
            AuthorName = authorName.Trim(),
            Rating = dto.Rating,
            Text = dto.Text.Trim(),
            CreatedAt = DateTime.UtcNow,
            IsHidden = false
        };

        Db.Reviews.Add(entity);
        Db.SaveChanges();
        return Mapper.Map<ReviewDto>(entity);
    }

    internal ReviewDto? UpdateReviewActionExecution(int id, ReviewUpdateDto dto)
    {
        var entity = Db.Reviews.FirstOrDefault(r => r.Id == id);
        if (entity is null)
            return null;

        if (dto.Rating is < 1 or > 5)
            return null;
        if (string.IsNullOrWhiteSpace(dto.Text))
            return null;
        if (string.IsNullOrWhiteSpace(dto.AuthorName))
            return null;

        entity.AuthorName = dto.AuthorName.Trim();
        entity.Rating = dto.Rating;
        entity.Text = dto.Text.Trim();
        entity.IsHidden = dto.IsHidden;

        Db.SaveChanges();
        return Mapper.Map<ReviewDto>(entity);
    }

    internal bool DeleteReviewActionExecution(int id)
    {
        var entity = Db.Reviews.FirstOrDefault(r => r.Id == id);
        if (entity is null)
            return false;

        Db.Reviews.Remove(entity);
        Db.SaveChanges();
        return true;
    }

    internal ReviewDto? SetReviewHiddenActionExecution(int id, bool isHidden)
    {
        var entity = Db.Reviews.FirstOrDefault(r => r.Id == id);
        if (entity is null)
            return null;

        entity.IsHidden = isHidden;
        Db.SaveChanges();
        return Mapper.Map<ReviewDto>(entity);
    }
}
