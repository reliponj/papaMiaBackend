namespace papaMiaBackend.Domain.Entities.Order;

public enum OrderPaymentKind
{
    Cash = 0,
    Card = 1
}

public enum OrderCardProvider
{
    Visa = 0,
    Mastercard = 1,
    PayPal = 2
}
