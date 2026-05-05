namespace papaMiaBackend.Domain.Models.Promocode;

public sealed class PromocodeValidationResult
{
    public PromocodeValidationResult(PromocodeValidationStatus status, PromocodeDto? promocode = null)
    {
        Status = status;
        Promocode = promocode;
    }

    public PromocodeValidationStatus Status { get; }
    public PromocodeDto? Promocode { get; }
}
