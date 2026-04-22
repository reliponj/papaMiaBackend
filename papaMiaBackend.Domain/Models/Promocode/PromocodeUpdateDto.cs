namespace papaMiaBackend.Domain.Models.Promocode;

public class PromocodeUpdateDto
{
    public string Code { get; set; } = string.Empty;
    public int Percent { get; set; } = 0;
    public DateTime ExpiryDate { get; set; } = DateTime.Now.AddDays(30);
    public bool IsActive { get; set; } = true;
}