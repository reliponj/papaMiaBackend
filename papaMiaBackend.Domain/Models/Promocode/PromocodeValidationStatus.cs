namespace papaMiaBackend.Domain.Models.Promocode;

public enum PromocodeValidationStatus
{
    Ok,
    NotFound,
    Inactive,
    Expired,
    AlreadyUsedByUser
}
