using AutoMapper;
using papaMiaBackend.DataAccess.Context;
using papaMiaBackend.Domain.Models.Banner;
using papaMiaBackend.Domain.Entities.Banner;

namespace papaMiaBackend.BusinessLogic.Core;

public class BannerActions
{
    protected readonly IMapper Mapper;
    protected readonly BannerContext Db;
    public BannerActions(IMapper mapper, BannerContext db)
    {
        Mapper = mapper;
        Db = db;
    }
    internal List<BannerDto> GetAllBannersActionExecution()
    {
        var entities = Db.Banners.ToList();
        return Mapper.Map<List<BannerDto>>(entities);
    }
    internal BannerDto? GetBannerByIdActionExecution(int id)
    {
        var entity = Db.Banners.FirstOrDefault(b => b.Id == id);
        if (entity == null)
        {
            return null;
        }
        return Mapper.Map<BannerDto>(entity);
    }
    internal BannerDto CreateBannerActionExecution(BannerCreateDto bannerCreateDto)
    {
        var entity = Mapper.Map<Banner>(bannerCreateDto);
        Db.Banners.Add(entity);
        Db.SaveChanges();
        return Mapper.Map<BannerDto>(entity);
    }
    internal BannerDto? UpdateBannerActionExecution(int id, BannerUpdateDto bannerUpdateDto)
    {
        var entity = Db.Banners.FirstOrDefault(b => b.Id == id);
        if (entity == null)
        {
            return null;
        }
        entity.ImageUrl = bannerUpdateDto.ImageUrl;
        entity.Link = bannerUpdateDto.Link;
        entity.Sort = bannerUpdateDto.Sort;
        Db.SaveChanges();
        return Mapper.Map<BannerDto>(entity);
    }
}