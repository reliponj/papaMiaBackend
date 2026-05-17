using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PromoNs = papaMiaBackend.Domain.Entities.Promocode;

namespace papaMiaBackend.Domain.Entities.Order;

[Table("Orders")]
public class Order
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public int? UserId { get; set; }
    public int? PromocodeId { get; set; }

    [Required]
    [StringLength(100)]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [StringLength(100)]
    public string LastName { get; set; } = string.Empty;

    [Required]
    [StringLength(30)]
    public string Phone { get; set; } = string.Empty;

    [Required]
    [StringLength(254)]
    public string Email { get; set; } = string.Empty;

    [Required]
    [StringLength(200)]
    public string District { get; set; } = string.Empty;

    [Required]
    [StringLength(500)]
    public string Address { get; set; } = string.Empty;

    [StringLength(2000)]
    public string? Note { get; set; }

    [Required]
    public OrderPaymentKind PaymentKind { get; set; }

    public OrderCardProvider? CardProvider { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; }

    [Required]
    public OrderStatus Status { get; set; } = OrderStatus.New;

    [ForeignKey(nameof(PromocodeId))]
    public PromoNs.Promocode? Promocode { get; set; }

    public ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();
    public ICollection<OrderCustomPizzaItem> CustomPizzaItems { get; set; } = new List<OrderCustomPizzaItem>();
}
