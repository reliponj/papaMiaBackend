using papaMiaBackend.Domain.Models.Promocode;

namespace papaMiaBackend.BusinessLogic.Interfaces;
public interface IPromocodeAction
{
    List<PromocodeDto> GetAllPromocodesAction();
    PromocodeDto? GetPromocodeByIdAction(int id);
    PromocodeDto CreatePromocodeAction(PromocodeCreateDto promocodeCreateDto);
    PromocodeDto? UpdatePromocodeAction(int id, PromocodeUpdateDto promocodeUpdateDto);
}