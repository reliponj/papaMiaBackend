using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace papaMiaBackend.Domain.Models.Promocode;

public class PromocodeDto
{
    public int Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public int Percent { get; set; } = 0;
    public DateTime ExpiryDate { get; set; } = DateTime.Now.AddDays(30);
    public bool IsActive { get; set; } = true;
}