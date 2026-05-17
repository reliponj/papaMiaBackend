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

public enum OrderStatus
{
    New = 0,
    Process = 1,
    Done = 2,
    Cancel = 3
}
