using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace papaMiaBackend.Domain.Entities.Cart;

[Table("CartItems")]
public class CartItem
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [Display(Name = "Cart")]
    public int CartId { get; set; }

    [Required]
    [Display(Name = "Product")]
    public int ProductId { get; set; }

    [Required]
    [Display(Name = "Quantity")]
    [Range(1, int.MaxValue)]
    public int Quantity { get; set; } = 1;

    [ForeignKey(nameof(CartId))]
    public Cart Cart { get; set; } = null!;
}
