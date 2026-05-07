using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PizzaNs = papaMiaBackend.Domain.Entities.CustomPizza;

namespace papaMiaBackend.Domain.Entities.Order;

[Table("OrderCustomPizzaItems")]
public class OrderCustomPizzaItem
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    public int OrderId { get; set; }

    [Required]
    public int CustomPizzaId { get; set; }

    [Required]
    [Range(1, int.MaxValue)]
    public int Quantity { get; set; } = 1;

    [ForeignKey(nameof(OrderId))]
    public Order Order { get; set; } = null!;

    [ForeignKey(nameof(CustomPizzaId))]
    public PizzaNs.CustomPizza CustomPizza { get; set; } = null!;
}

