using AutoMapper;
using papaMiaBackend.Domain.Entities.Article;
using papaMiaBackend.Domain.Models.Article;

namespace papaMiaBackend.BusinessLogic.Mapping;

public class ArticleMappingProfile : Profile
{
    public ArticleMappingProfile()
    {
        CreateMap<Article, ArticleDto>();
        CreateMap<ArticleCreateDto, Article>()
            .ForMember(d => d.Id, o => o.Ignore())
            .ForMember(d => d.CreatedAt, o => o.Ignore());
        CreateMap<ArticleUpdateDto, Article>()
            .ForMember(d => d.Id, o => o.Ignore())
            .ForMember(d => d.CreatedAt, o => o.Ignore());
    }
}
