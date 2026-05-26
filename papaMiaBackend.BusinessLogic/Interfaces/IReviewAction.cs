using papaMiaBackend.Domain.Models.Review;

namespace papaMiaBackend.BusinessLogic.Interfaces;

public interface IReviewAction
{
    List<ReviewDto> GetAllReviewsAction();
    List<ReviewDto> GetPublishedReviewsAction();
    ReviewDto? GetReviewByIdAction(int id);
    ReviewDto? CreateReviewAction(ReviewCreateDto dto, int userId, string authorName);
    ReviewDto? UpdateReviewAction(int id, ReviewUpdateDto dto);
    bool DeleteReviewAction(int id);
    ReviewDto? SetReviewHiddenAction(int id, bool isHidden);
}
