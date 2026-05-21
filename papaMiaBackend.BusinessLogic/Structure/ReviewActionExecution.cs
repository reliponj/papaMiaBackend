using AutoMapper;
using papaMiaBackend.BusinessLogic.Core;
using papaMiaBackend.BusinessLogic.Interfaces;
using papaMiaBackend.DataAccess.Context;
using papaMiaBackend.Domain.Models.Review;

namespace papaMiaBackend.BusinessLogic.Structure;

public class ReviewActionExecution : ReviewActions, IReviewAction
{
    public ReviewActionExecution(IMapper mapper, ReviewContext db)
        : base(mapper, db)
    {
    }

    public List<ReviewDto> GetAllReviewsAction()
    {
        return GetAllReviewsActionExecution();
    }

    public List<ReviewDto> GetPublishedReviewsAction()
    {
        return GetPublishedReviewsActionExecution();
    }

    public ReviewDto? GetReviewByIdAction(int id)
    {
        return GetReviewByIdActionExecution(id);
    }

    public ReviewDto? CreateReviewAction(ReviewCreateDto dto, int userId, string authorName)
    {
        return CreateReviewActionExecution(dto, userId, authorName);
    }

    public ReviewDto? UpdateReviewAction(int id, ReviewUpdateDto dto)
    {
        return UpdateReviewActionExecution(id, dto);
    }

    public bool DeleteReviewAction(int id)
    {
        return DeleteReviewActionExecution(id);
    }

    public ReviewDto? SetReviewHiddenAction(int id, bool isHidden)
    {
        return SetReviewHiddenActionExecution(id, isHidden);
    }
}
