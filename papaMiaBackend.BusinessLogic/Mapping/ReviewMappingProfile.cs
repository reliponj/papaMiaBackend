using AutoMapper;
using papaMiaBackend.Domain.Models.Review;
using ReviewEntity = papaMiaBackend.Domain.Entities.Review.Review;

namespace papaMiaBackend.BusinessLogic.Mapping;

public class ReviewMappingProfile : Profile
{
    public ReviewMappingProfile()
    {
        CreateMap<ReviewEntity, ReviewDto>();
    }
}
